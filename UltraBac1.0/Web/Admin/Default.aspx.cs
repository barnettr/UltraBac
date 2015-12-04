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

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //instantiated just to trigger licensing > Do not remove!
        ZNodeHelper hlp = new ZNodeHelper();

        UserName.Focus();
        if (Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/admin/secure/default.aspx");
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        ZNodeUserAccount userAcct = new ZNodeUserAccount();
        bool loginSuccess = userAcct.Login(ZNodeConfigManager.SiteConfig.PortalID,UserName.Text,Password.Text);

        if (loginSuccess)
        {
            //get account and set to session
            Session.Add(ZNodeSessionKeyType.UserAccount.ToString(), userAcct);

            FormsAuthentication.SetAuthCookie(UserName.Text, false);

            Response.Redirect("~/admin/secure/default.aspx");
        }
        else
        {
            FailureText.Text = "Login unsuccessfull. Please try again.";
        }
    }
}
