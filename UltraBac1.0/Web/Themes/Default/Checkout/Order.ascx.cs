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
using System.ComponentModel;

/// <summary>
/// Checkout order information
/// </summary>
public partial class Controls_ShoppingCartCheckout_Order : System.Web.UI.UserControl
{
    #region Private Variables
    private static bool _isShippingOptionValid = false;    
    protected int portalID = 0;
    protected string aa = string.Empty;
    private ZNodeCoupon _coupon = new ZNodeCoupon();
    private ZNodeOrder _order = new ZNodeOrder();
    protected ZNodeShoppingCart _shoppingCart = (ZNodeShoppingCart)ZNodeCheckout.CreateFromSession(ZNodeSessionKeyType.ShoppingCart);
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Events
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ZNodeUserAccount userAccount = (ZNodeUserAccount)ZNodeUserAccount.CreateFromSession(ZNodeSessionKeyType.UserAccount);

        if (userAccount != null)
        {
            BindGrid();

            if (lstShipping.Items.Count == 0)
            {
                BindShipping();
            }

            CalculateTaxes();

            CalculateShipping();            

            BindTotals();
        }
    }
    #endregion

    #region Bind Data
    public void BindGrid()
    {
        uxCart.DataSource = _shoppingCart.ShoppingCartItems;
        uxCart.DataBind();    
    }

    public void BindTotals()
    {
        //bind totals
        SubTotal.Text = _shoppingCart.SubTotal.ToString("c");
        Discount.Text = "-" + _order.Discount.ToString("c");      
        Tax.Text = _shoppingCart.TaxCost.ToString("c");
        Shipping.Text = _shoppingCart.ShippingDiscount.ToString("c");
        Total.Text = _shoppingCart.Total.ToString("c");
    }

    public void BindShipping()
    {
       ZNodeUserAccount userAccount = (ZNodeUserAccount) ZNodeUserAccount.CreateFromSession(ZNodeSessionKeyType.UserAccount);

       if (userAccount != null)
       {
           int profileID = userAccount.ProfileID;

           ShippingService shipServ = new ShippingService();
           TList<Shipping> shippingList = shipServ.GetByProfileID(profileID);
           shippingList.Sort("DisplayOrder Asc");           
           shippingList.Filter = "ActiveInd = true";

           // Creates a new collection and assign it the properties for Shipping.
           //PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(shippingList[0].GetType());

           // Sets an PropertyDescriptor to the specific property.
           //System.ComponentModel.PropertyDescriptor myProperty = properties.Find("DisplayOrder", false);

           //apply sording based on displayorder 
           //shippingList.ApplySort(myProperty, System.ComponentModel.ListSortDirection.Ascending);

           if (shippingList.Count > 0)
           {
               lstShipping.DataSource = shippingList;
               lstShipping.DataTextField = "Description";
               lstShipping.DataValueField = "ShippingID";
               lstShipping.DataBind();

               lstShipping.SelectedIndex = 0;
           }           
       }  
   }

    #endregion

    #region Events
   /// <summary>
    /// Event triggered when shipping option is changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstShipping_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
   #endregion

    # region Public Properties    
    public bool IsShippingOptionValid
    {
        get { return _isShippingOptionValid; }
        set { _isShippingOptionValid = value; }
    }
    #endregion

    #region Helper Functions
    /// <summary>
    /// Re-calculate shipping cost
    /// </summary>
    private void CalculateShipping()
    {
        if (lstShipping.Items.Count > 0)
        {
            int shippingID = int.Parse(lstShipping.SelectedValue);

            //calculate shipping cost
            ZNodeShippingEngine shippingEngine = new ZNodeShippingEngine();
            shippingEngine.CalculateShipping(ref _shoppingCart, shippingID);

            //Shipping Option Service response details
            if (shippingEngine.ResponseCode != "0")
            {
                IsShippingOptionValid = false;
                uxErrorMsg.Text = "Shipping Option Problem: <br />" + shippingEngine.ResponseDescription;
            }
            else
            {   
                IsShippingOptionValid = true;
            }

            //set shipping name in shopping cart object
            _shoppingCart.ShippingName = lstShipping.SelectedItem.Text;
            _shoppingCart.ShippingID = shippingID;
        }

    }

    /// <summary>
    /// Calculate taxes
    /// </summary>
    private void CalculateTaxes()
    {
        ZNodeUserAccount userAccount = (ZNodeUserAccount)ZNodeUserAccount.CreateFromSession(ZNodeSessionKeyType.UserAccount);
        ZNode.Libraries.Admin.TaxRuleAdmin tra = new ZNode.Libraries.Admin.TaxRuleAdmin();
        DataSet ds = (tra.GetAllTaxRulesByPortal(ZNodeConfigManager.SiteConfig.PortalID)).ToDataSet(true);
        
        if(ds.Tables[0].Rows.Count != 0)       
        {
            ZNodeTaxEngine taxEngine = new ZNodeTaxEngine();
            taxEngine.CalculateTax(ref _shoppingCart, userAccount.BillingAddress, userAccount.ProfileID);
            TaxPct.Text = "(" + _shoppingCart.TaxRate + "%)";
        }
        else
        {
            TaxPct.Text = "";
        }
    }
    #endregion
}
