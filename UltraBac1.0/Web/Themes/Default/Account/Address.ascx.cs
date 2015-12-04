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
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;

public partial class Themes_Default_Account_Address : System.Web.UI.UserControl
{
    private ZNodeAddress _billingAddress = new ZNodeAddress();
    private ZNodeAddress _shippingAddress = new ZNodeAddress();
    protected ZNodeUserAccount _userAccount;

    protected void Page_Load(object sender, EventArgs e)
    {
        _userAccount = (ZNodeUserAccount)ZNodeCheckout.CreateFromSession(ZNodeSessionKeyType.UserAccount);

        if (!Page.IsPostBack)
        {
            BindCountry();

            //get user's address
            BillingAddress = _userAccount.BillingAddress;
            ShippingAddress = _userAccount.ShippingAddress;
        }
    }

    /// <summary>
    /// Sets or gets accountobject with addresses
    /// </summary>
    public ZNodeAddress BillingAddress
    {
        get
        {
            //get fields
            _billingAddress.FirstName = txtBillingFirstName.Text;
            _billingAddress.LastName = txtBillingLastName.Text;
            _billingAddress.CompanyName = txtBillingCompanyName.Text;
            _billingAddress.Street1 = txtBillingStreet1.Text;
            _billingAddress.Street2 = txtBillingStreet2.Text;
            _billingAddress.City = txtBillingCity.Text;
            _billingAddress.StateCode = txtBillingState.Text.ToUpper();
            _billingAddress.PostalCode = txtBillingPostalCode.Text;
            _billingAddress.CountryCode = lstBillingCountryCode.SelectedValue;
            _billingAddress.PhoneNumber = txtBillingPhoneNumber.Text;
            if (txtBillingEmail.Text.Trim().Length > 0)
            {
                _billingAddress.EmailId = txtBillingEmail.Text;
            }
            else
            {
                _billingAddress.EmailId = _userAccount.BillingAddress.EmailId;
            }

            return _billingAddress;
        }
        set
        {
            _billingAddress = value;

            //set field values
            txtBillingFirstName.Text = _billingAddress.FirstName;
            txtBillingLastName.Text = _billingAddress.LastName;
            txtBillingCompanyName.Text = _billingAddress.CompanyName;
            txtBillingStreet1.Text = _billingAddress.Street1;
            txtBillingStreet2.Text = _billingAddress.Street2;
            txtBillingCity.Text = _billingAddress.City;
            txtBillingState.Text = _billingAddress.StateCode;
            txtBillingPostalCode.Text = _billingAddress.PostalCode;

            if (_billingAddress.CountryCode.Length > 0)
            {
                lstBillingCountryCode.SelectedValue = _billingAddress.CountryCode;
            }

            txtBillingPhoneNumber.Text = _billingAddress.PhoneNumber;
            txtBillingEmail.Text = _billingAddress.EmailId;
        }
    }

    /// <summary>
    /// Sets or gets accountobject with addresses
    /// </summary>
    public ZNodeAddress ShippingAddress
    {
        get
        {
            if (chkSameAsBilling.Checked)
            {
                _shippingAddress.FirstName = txtBillingFirstName.Text;
                _shippingAddress.LastName = txtBillingLastName.Text;
                _shippingAddress.CompanyName = txtBillingCompanyName.Text;
                _shippingAddress.Street1 = txtBillingStreet1.Text;
                _shippingAddress.Street2 = txtBillingStreet2.Text;
                _shippingAddress.City = txtBillingCity.Text;
                _shippingAddress.StateCode = txtBillingState.Text.ToUpper();
                _shippingAddress.PostalCode = txtBillingPostalCode.Text;
                _shippingAddress.CountryCode = lstBillingCountryCode.SelectedValue;
                _shippingAddress.PhoneNumber = txtBillingPhoneNumber.Text;
                _shippingAddress.EmailId = txtBillingEmail.Text;
            }
            else
            {
                _shippingAddress.FirstName = txtShippingFirstName.Text;
                _shippingAddress.LastName = txtShippingLastName.Text;
                _shippingAddress.CompanyName = txtShippingCompanyName.Text;
                _shippingAddress.Street1 = txtShippingStreet1.Text;
                _shippingAddress.Street2 = txtShippingStreet2.Text;
                _shippingAddress.City = txtShippingCity.Text;
                _shippingAddress.PostalCode = txtShippingPostalCode.Text;
                _shippingAddress.CountryCode = lstShippingCountryCode.SelectedValue;
                _shippingAddress.StateCode = txtShippingState.Text.ToUpper();
                _shippingAddress.PhoneNumber = txtShippingPhoneNumber.Text;
                if (txtShippingEmail.Text.Trim().Length > 0)
                {
                    _shippingAddress.EmailId = txtShippingEmail.Text;
                }
                else
                {
                    _shippingAddress.EmailId = _userAccount.ShippingAddress.EmailId;
                }
            }

            return _shippingAddress;
        }
        set
        {
            _shippingAddress = value;

            //set field values
            txtShippingFirstName.Text = _shippingAddress.FirstName;
            txtShippingLastName.Text = _shippingAddress.LastName;
            txtShippingCompanyName.Text = _shippingAddress.CompanyName;
            txtShippingStreet1.Text = _shippingAddress.Street1;
            txtShippingStreet2.Text = _shippingAddress.Street2;
            txtShippingCity.Text = _shippingAddress.City;
            txtShippingState.Text = _shippingAddress.StateCode;
            txtShippingPostalCode.Text = _shippingAddress.PostalCode;

            if (_shippingAddress.CountryCode.Length > 0)
            {
                lstShippingCountryCode.SelectedValue = _shippingAddress.CountryCode;
            }

            txtShippingPhoneNumber.Text = _shippingAddress.PhoneNumber;
            txtShippingEmail.Text = _shippingAddress.EmailId;
        }
    }


    protected void chkSameAsBilling_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSameAsBilling.Checked)
        {
            pnlShipping.Visible = false;
        }
        else
        {
            pnlShipping.Visible = true;
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

        lstBillingCountryCode.DataSource = countries;
        lstBillingCountryCode.DataTextField = "Name";
        lstBillingCountryCode.DataValueField = "Code";
        lstBillingCountryCode.DataBind();
        lstBillingCountryCode.SelectedValue = "US";

        lstShippingCountryCode.DataSource = countries;
        lstShippingCountryCode.DataTextField = "Name";
        lstShippingCountryCode.DataValueField = "Code";
        lstShippingCountryCode.DataBind();
        lstShippingCountryCode.SelectedValue = "US";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        _userAccount = (ZNodeUserAccount)ZNodeCheckout.CreateFromSession(ZNodeSessionKeyType.UserAccount);

        _userAccount.BillingAddress = BillingAddress;
        _userAccount.ShippingAddress = ShippingAddress;
        _userAccount.UpdateUserAccount();

        //redirect to account page
        ZNodeUrl url = new ZNodeUrl();
        Response.Redirect("~/account.aspx");
    }
}
