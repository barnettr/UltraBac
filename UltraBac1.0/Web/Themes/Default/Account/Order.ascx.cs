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
using ZNode.Libraries.DataAccess;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

public partial class Themes_Default_Account_Order : System.Web.UI.UserControl
{
    #region Private Variables
    private int _itemID;
    private ZNodeUserAccount _userAccount;
    #endregion

    #region Public Variables
    public string AccountPageLink = string.Empty;
    public string OrderNumber = string.Empty;
    public string OrderDate = string.Empty;
    public string OrderTotal = string.Empty;
    public string BillingAddress = string.Empty;
    public string ShippingAddress = string.Empty;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        _userAccount = (ZNodeUserAccount)ZNodeUserAccount.CreateFromSession(ZNodeSessionKeyType.UserAccount);

        // Get ItemId from querystring        
        if (Request.Params["itemid"] != null)
        {
            _itemID = int.Parse(Request.Params["itemid"]);
        }
        else
        {
            _itemID = 0;
            Response.Redirect("account.aspx");
        }

        OrderNumber = _itemID.ToString();

        //Bind grid data
        Bind();

        //account page link
        ZNodeUrl url = new ZNodeUrl();
        AccountPageLink = url.GetURLFromPageId("account");
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Order data
    /// </summary>
    private void Bind()
    {
        //first retrieve order info by orderid to check if it valid for the current account
        ZNode.Libraries.DataAccess.Service.OrderService ordServ = new OrderService();
        ZNode.Libraries.DataAccess.Entities.Order ord = ordServ.GetByOrderID(_itemID);

        if (ord.AccountID == _userAccount.AccountID) //account id on order matches current user's account id
        {
            OrderDate = ord.OrderDate.ToString();
            OrderTotal = ((decimal)ord.Total).ToString("c");

            //print billing address info
            ZNodeAddress billingAddress = new ZNodeAddress();
            billingAddress.FirstName = ord.BillingFirstName;
            billingAddress.LastName = ord.BillingLastName;
            billingAddress.Street1 = ord.BillingStreet;
            billingAddress.Street2 = ord.BillingStreet1;
            billingAddress.City = ord.BillingCity;
            billingAddress.StateCode = ord.BillingStateCode;
            billingAddress.PostalCode = ord.BillingPostalCode;
            billingAddress.CountryCode = ord.BillingCountry;
            billingAddress.CompanyName = ord.BillingCompanyName;
            billingAddress.PhoneNumber = ord.BillingPhoneNumber;
            billingAddress.EmailId = ord.BillingEmailId;
            BillingAddress = billingAddress.ToString();

            //print shipping address info
            ZNodeAddress shippingAddress = new ZNodeAddress();
            shippingAddress.FirstName = ord.ShipFirstName;
            shippingAddress.LastName = ord.ShipLastName;
            shippingAddress.Street1 = ord.ShipStreet;
            shippingAddress.Street2 = ord.ShipStreet1;
            shippingAddress.City = ord.ShipCity;
            shippingAddress.StateCode = ord.ShipStateCode;
            shippingAddress.PostalCode = ord.ShipPostalCode;
            shippingAddress.CountryCode = ord.ShipCountry;
            shippingAddress.CompanyName = ord.ShipCompanyName;
            shippingAddress.PhoneNumber = ord.ShipPhoneNumber;
            shippingAddress.EmailId = ord.ShipEmailID;
            ShippingAddress = shippingAddress.ToString();

            ZNode.Libraries.DataAccess.Service.OrderLineItemService oliServ = new OrderLineItemService();
            TList<OrderLineItem> ordLineItems = oliServ.GetByOrderID(_itemID);

            uxGrid.DataSource = ordLineItems;
            uxGrid.DataBind();
        }
    }
    #endregion
}
