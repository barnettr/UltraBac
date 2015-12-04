using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Framework.Business;

public partial class Themes_Default_Account_Login : System.Web.UI.UserControl
{   
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //set page title
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(ZNodeConfigManager.SiteConfig.StoreName);
        sb.Append(" : ");
        sb.Append("Member Login");
        Page.Title = sb.ToString();

        //check if SSL is required
        if (ZNodeConfigManager.SiteConfig.UseSSL)
        {
            if (!Request.IsSecureConnection)
            {
                string inURL = Request.Url.ToString();
                string outURL = inURL.ToLower().Replace("http://", "https://");

                Response.Redirect(outURL);
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method overrides the default login implementation
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    private bool CustomAuthenticationMethod(string UserName, string Password)
    {
        // Insert code that implements a site-specific custom 
        // authentication method here.
        //
        ZNodeUserAccount userAcct = new ZNodeUserAccount();
        bool loginSuccess = userAcct.Login(ZNodeConfigManager.SiteConfig.PortalID, UserName, Password);

        if (loginSuccess)
        {
            //get account and set to session
            Session.Add(ZNodeSessionKeyType.UserAccount.ToString(), userAcct);
        }

        return loginSuccess;
    }


    //This function registers a new user
    private void RegisterUser()
    {
        //check if loginName already exists in DB
        ZNodeUserAccount userAccount = new ZNodeUserAccount();
        if (!userAccount.IsLoginNameAvailable(ZNodeConfigManager.SiteConfig.PortalID, UserName.Text.Trim()))
        {
            ErrorMessage.Text = "This login name already exists. Please select a different name.";
            return;
        }

        //create user membership
        MembershipCreateStatus memStatus;
        MembershipUser user = Membership.CreateUser(UserName.Text, Password.Text, Email.Text, Question.Text, Answer.Text, true, out memStatus);

        if (memStatus != MembershipCreateStatus.Success)
        {
            ErrorMessage.Text = "Could not create user account. Please contact customer support.";
            return;
        }

        //create the user account
        ZNodeUserAccount newUserAccount = new ZNodeUserAccount();
        newUserAccount.PortalID = ZNodeConfigManager.SiteConfig.PortalID;
        newUserAccount.UserID = (Guid)user.ProviderUserKey;

        //copy info to billing
        ZNodeAddress billingAddress = new ZNodeAddress();
        billingAddress.EmailId = Email.Text;
        newUserAccount.BillingAddress = billingAddress;

        //copy info to shipping
        ZNodeAddress shippingAddress = new ZNodeAddress();
        shippingAddress.EmailId = Email.Text;
        newUserAccount.ShippingAddress = shippingAddress;

        //register account
        newUserAccount.AddUserAccount();

        //login the user
        ZNodeUserAccount userAcct = new ZNodeUserAccount();
        bool loginSuccess = userAcct.Login(ZNodeConfigManager.SiteConfig.PortalID, UserName.Text, Password.Text);

        if (loginSuccess)
        {
            //get account and set to session
            Session.Add(ZNodeSessionKeyType.UserAccount.ToString(), userAcct);

            if (Request.QueryString["ReturnUrl"] != null)
            {
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(UserName.Text, false);
                Response.Redirect("~/default.aspx");
            }
        }
        else
        {
            ErrorMessage.Text = "Invalid UserID or Password";
        }
    }
    #endregion

    #region Events
    /// <summary>
    /// Event fired when user authenticates
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void uxLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool Authenticated = false;
        Authenticated = CustomAuthenticationMethod(uxLogin.UserName, uxLogin.Password);

        e.Authenticated = Authenticated;
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        RegisterUser();
    }

    protected void ForgotPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ForgotPassword.aspx");
    }
    #endregion   
}
