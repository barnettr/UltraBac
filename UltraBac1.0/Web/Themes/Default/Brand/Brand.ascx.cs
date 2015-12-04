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
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

/// <summary>
/// Displays home page specials
/// </summary>
public partial class Controls_Brand : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeProductList _productList;
    protected string _title = string.Empty;
    protected int _manufacturerId;
    #endregion

    #region Public Properties   
    /// <summary>
    /// Product list
    /// </summary>
    public ZNodeProductList ProductList
    {
        get
        {
            return _productList;
        }
        set
        {
            _productList = value;
        }
    }
 
    /// <summary>
    /// Sets the title for this control
    /// </summary>
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
   

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //get product id from querystring  
        if (Request.Params["mid"] != null)
        {
            _manufacturerId = int.Parse(Request.Params["mid"]);
        }
        else
        {
            throw (new ApplicationException("Invalid Manufacturer Id"));
        }

        _productList = ZNodeProductList.GetProductsByBrand(ZNodeConfigManager.SiteConfig.PortalID, _manufacturerId);
        BindProducts();

        ZNodeManufacturer manuf = ZNodeManufacturer.Create(_manufacturerId, ZNodeConfigManager.SiteConfig.PortalID);
        lblBrandName.Text = manuf.Name;
    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind display based on a product list
    /// </summary>
    public void BindProducts()
    {
        if (_productList.ZNodeProductCollection.Count == 0)
        {
            lblMsg.Text = "No products were found for this brand.";
            return;
        }  

        DataListProducts.DataSource = _productList.ZNodeProductCollection;
        DataListProducts.RepeatColumns = ZNodeConfigManager.SiteConfig.MaxCatalogDisplayColumns;
        DataListProducts.DataBind();
    }
    #endregion

    #region Helper Functions

    public bool ShowSalePrice(object salePrice)
    {
        decimal decPrice = decimal.Parse(salePrice.ToString());
        if (decPrice > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string CheckForCallForPricing(object FieldValue)
    {

        bool Status = bool.Parse(FieldValue.ToString());

        if (Status)
        {
            return ZNodeConfigManager.MessageConfig.GetMessage("CallForPricing");
        }
        else
        {
            return "";
        }
    }

    public string GetSalePrice(object salePrice)
    {
        if (salePrice == null) { return "" ; }
        decimal decPrice = decimal.Parse(salePrice.ToString());
        return ZNodeConfigManager.MessageConfig.GetMessage("SalePriceLabel") + " " + decPrice.ToString("c");
    }

    public string GetRegularPrice(object retailPrice)
    {
        if (retailPrice == null) { return ""; }
        decimal decPrice = decimal.Parse(retailPrice.ToString());
        return ZNodeConfigManager.MessageConfig.GetMessage("RegularPriceLabel") + " " + decPrice.ToString("c");
    }    
    #endregion
}
