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
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;

public partial class Admin_Secure_customers_edit : System.Web.UI.Page
{

    # region Protected Member Variables
    protected int AccountID;
    private ZNodeAddress _billingAddress = new ZNodeAddress();
    private ZNodeAddress _shippingAddress = new ZNodeAddress();    
    # endregion

    # region Page Load

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (HttpContext.Current.Request.Params["itemid"] == null)
        {
            AccountID = 0;
        }
        else
        {
            AccountID = int.Parse(Request.Params["itemid"].ToString());
        }

        if (!Page.IsPostBack)
        {
            this.BindCountry();
            this.BindProfile();
            this.BindContactStatus();
            this.BindData();
        }
    }

    # endregion

    # region General Events

    /// <summary>
    /// Submit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        ZNode.Libraries.Admin.AccountAdmin _UserAccountAdmin = new ZNode.Libraries.Admin.AccountAdmin();
        ZNode.Libraries.DataAccess.Entities.Account _UserAccount = _UserAccountAdmin.GetByAccountID(AccountID);
        
        //Set user's address
        _UserAccount.BillingFirstName = txtBillingFirstName.Text;
        _UserAccount.BillingLastName = txtBillingLastName.Text;
        _UserAccount.BillingCompanyName = txtBillingCompanyName.Text;
        _UserAccount.BillingStreet = txtBillingStreet1.Text;
        _UserAccount.BillingStreet1 = txtBillingStreet2.Text;
        _UserAccount.BillingCity = txtBillingCity.Text;
        _UserAccount.BillingStateCode = txtBillingState.Text;
        _UserAccount.BillingPostalCode = txtBillingPostalCode.Text;
        _UserAccount.BillingPhoneNumber = txtBillingPhoneNumber.Text;
        _UserAccount.BillingEmailID = txtBillingEmail.Text;

        if (lstBillingCountryCode.SelectedIndex != -1)
        {
            _UserAccount.BillingCountryCode = lstBillingCountryCode.SelectedValue;
        }
               
        //Get Shipping field values
        _UserAccount.ShipFirstName = txtShippingFirstName.Text;
        _UserAccount.ShipLastName = txtShippingLastName.Text;
        _UserAccount.ShipCompanyName = txtShippingCompanyName.Text;
        _UserAccount.ShipStreet = txtShippingStreet1.Text;
        _UserAccount.ShipStreet1 = txtShippingStreet2.Text;
        _UserAccount.ShipCity = txtShippingCity.Text;
        _UserAccount.ShipStateCode = txtShippingState.Text;
        _UserAccount.ShipPostalCode = txtShippingPostalCode.Text;

        if (lstShippingCountryCode.SelectedIndex != -1)
        {
            _UserAccount.ShipCountryCode = lstShippingCountryCode.SelectedValue;
        }

        _UserAccount.ShipPhoneNumber = txtShippingPhoneNumber.Text;
        _UserAccount.ShipEmailID = txtShippingEmail.Text;

        
        //Set Account Details
        _UserAccount.ExternalAccountNo = txtExternalAccNumber.Text.Trim();
        _UserAccount.Description = txtDescription.Text;
        _UserAccount.CompanyName = txtCompanyName.Text;
        _UserAccount.Website = txtWebSite.Text.Trim();
        _UserAccount.Source = txtSource.Text.Trim();

        if (ListProfileType.SelectedIndex != -1)
        {
            _UserAccount.ProfileID = int.Parse(ListProfileType.SelectedValue);
        }

        if (ListContactStatus.SelectedIndex != -1)
        {
            _UserAccount.ContactTemperatureID = int.Parse(ListContactStatus.SelectedValue);
        }
                            
        _UserAccount.AccountProfileCode = DBNull.Value.ToString();
        _UserAccount.UpdateUser = System.Web.HttpContext.Current.User.Identity.Name;
        _UserAccount.UpdateDte = System.DateTime.Now;

        _UserAccount.UserID = _UserAccount.UserID;
        _UserAccount.AccountID = AccountID;
        _UserAccount.PortalID = int.Parse(ZNodeConfigManager.SiteConfig.PortalID.ToString());
        
        //Custom Information Section
        _UserAccount.Custom1 = txtCustom1.Text.Trim();
        _UserAccount.Custom2 = txtCustom2.Text.Trim();
        _UserAccount.Custom3 = txtCustom3.Text.Trim();

        //Update User Account
        bool Check = _UserAccountAdmin.Update(_UserAccount);
        
        //Check Boolean Value
        if (Check)
        {
            Response.Redirect("~/admin/secure/customers/list.aspx");
        }
        else
        {

        }
    }
    
    /// <summary>
    ///  Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/customers/list.aspx");
    }

    # endregion

    # region Bind Datas

    /// <summary>
    /// Bind Account Details
    /// </summary>
    private void BindData()
    {
       
        ZNode.Libraries.Admin.AccountAdmin _UserAccountAdmin = new ZNode.Libraries.Admin.AccountAdmin();
        ZNode.Libraries.DataAccess.Entities.Account _UserAccount = _UserAccountAdmin.GetByAccountID(AccountID);//new Account();

        if (_UserAccount != null)
        {
            //General Information
            txtExternalAccNumber.Text = _UserAccount.ExternalAccountNo;
            txtCompanyName.Text = _UserAccount.CompanyName;
            if (ListProfileType.SelectedIndex != -1)
            {
                ListProfileType.SelectedValue = _UserAccount.ProfileID.ToString();
            }

            txtWebSite.Text = _UserAccount.Website;
            txtSource.Text = _UserAccount.Source;

            if (ListContactStatus.SelectedIndex != -1)
            {
                if(_UserAccount.ContactTemperatureID.HasValue)
                {
                    ListContactStatus.SelectedValue = _UserAccount.ContactTemperatureID.Value.ToString();
                }
            }

            //Description
            txtDescription.Text = _UserAccount.Description;

            //Billing Address

            //set field values
            txtBillingFirstName.Text = _UserAccount.BillingFirstName;
            txtBillingLastName.Text = _UserAccount.BillingLastName;
            txtBillingCompanyName.Text = _UserAccount.BillingCompanyName;
            txtBillingStreet1.Text = _UserAccount.BillingStreet;
            txtBillingStreet2.Text = _UserAccount.BillingStreet1;
            txtBillingCity.Text = _UserAccount.BillingCity;
            txtBillingState.Text = _UserAccount.BillingStateCode;
            txtBillingPostalCode.Text = _UserAccount.BillingPostalCode;

            if (_billingAddress.CountryCode.Length > 0)
            {
                lstBillingCountryCode.SelectedValue = _UserAccount.BillingCountryCode;
            }

            txtBillingPhoneNumber.Text = _UserAccount.BillingPhoneNumber;
            txtBillingEmail.Text = _UserAccount.BillingEmailID;


            //Shipping Address

            //set field values
            txtShippingFirstName.Text = _UserAccount.ShipFirstName;
            txtShippingLastName.Text = _UserAccount.ShipLastName;
            txtShippingCompanyName.Text = _UserAccount.ShipCompanyName;
            txtShippingStreet1.Text = _UserAccount.ShipStreet;
            txtShippingStreet2.Text = _UserAccount.ShipStreet1;
            txtShippingCity.Text = _UserAccount.ShipCity;
            txtShippingState.Text = _UserAccount.ShipStateCode;
            txtShippingPostalCode.Text = _UserAccount.ShipPostalCode;

            if (_shippingAddress.CountryCode.Length > 0)
            {
                lstShippingCountryCode.SelectedValue = _UserAccount.ShipCountryCode;
            }

            txtShippingPhoneNumber.Text = _UserAccount.ShipPhoneNumber;
            txtShippingEmail.Text = _UserAccount.ShipEmailID;


            txtCustom1.Text = _UserAccount.Custom1;
            txtCustom2.Text = _UserAccount.Custom2;
            txtCustom3.Text = _UserAccount.Custom3;
        }
       
                
    }

    /// <summary>
    /// Binds country drop-down list
    /// </summary>
    private void BindCountry()
    {
        CountryService countryServ = new CountryService();
        TList<ZNode.Libraries.DataAccess.Entities.Country> countries = countryServ.GetByPortalIDActiveInd(ZNodeConfigManager.SiteConfig.PortalID, true);
        countries.Sort("DisplayOrder,Name");

        //Billing Drop Down List
        lstBillingCountryCode.DataSource = countries;
        lstBillingCountryCode.DataTextField = "Name";
        lstBillingCountryCode.DataValueField = "Code";
        lstBillingCountryCode.DataBind();
        lstBillingCountryCode.SelectedValue = "US";

        //Shipping Drop Down List
        lstShippingCountryCode.DataSource = countries;
        lstShippingCountryCode.DataTextField = "Name";
        lstShippingCountryCode.DataValueField = "Code";
        lstShippingCountryCode.DataBind();
        lstShippingCountryCode.SelectedValue = "US";
    }

    /// <summary>
    /// Binds Account Type drop-down list
    /// </summary>
    private void BindProfile()
    {
        ZNode.Libraries.Admin.ProfileAdmin _Profileadmin = new ProfileAdmin();
        ListProfileType.DataSource = _Profileadmin.GetAll();
        ListProfileType.DataTextField = "name";
        ListProfileType.DataValueField = "profileID";
        ListProfileType.DataBind();
        
    }

    /// <summary>
    /// Binds Contact Status drop-down list
    /// </summary>
    private void BindContactStatus()
    {
        CustomerAdmin _CustomerAdmin = new CustomerAdmin();        
        ListContactStatus.DataSource = _CustomerAdmin.GetAllContactStatus();
        ListContactStatus.DataTextField = "Name";
        ListContactStatus.DataValueField = "ContactTemperatureID";
        ListContactStatus.DataBind();
        ListContactStatus.SelectedIndex = 0;
    }
    
    # endregion

}
