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
public partial class Controls_Specials : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeProductList _productList;
    protected string _title = string.Empty;
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
        _productList = ZNodeProductList.GetHomePageSpecials(ZNodeConfigManager.SiteConfig.PortalID);
        BindProducts();
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
            pnlProductList.Visible = false;
        }
        else
        {           
            pnlProductList.Visible = true;
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
        return decPrice.ToString("c");
    }

    public string GetRegularPrice(object retailPrice)
    {
        if (retailPrice == null) { return ""; }
        decimal decPrice = decimal.Parse(retailPrice.ToString());
        return decPrice.ToString("c");
    }    
    #endregion
}
