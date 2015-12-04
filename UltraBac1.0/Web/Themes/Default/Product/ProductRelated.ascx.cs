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
/// Displays the related products
/// </summary>
public partial class Controls_ShoppingCartProduct_ProductRelated : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeProduct _product;
    //private string _cssClass;
    //private bool _visible = true;
    #endregion

    #region Public Properties
    /// <summary>
    /// Sets the catalog item object. The control will bind to the data from this object
    /// </summary>
    public ZNodeProduct Product
    {
        get
        {
            return _product;
        }
        set
        {
            _product = value;
        }
    }   

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind control display based on properties set
    /// </summary>
    public void Bind()
    {
        if (Product.ZNodeCrossSellItemCollection.Count > 0)
        {
            pnlRelated.Visible = true;
            DataListRelated.DataSource = Product.ZNodeCrossSellItemCollection;
            DataListRelated.DataBind();
        }
        else
        {
            pnlRelated.Visible = false ;
        }
    }
    #endregion

    #region Helper Functions
    protected string GetProductUrl(string ProductId)
    {
        ZNodeUrl url = new ZNodeUrl();
        string PagePath = "~/product.aspx?pid=" + ProductId;
        return PagePath;
    }
    #endregion
}
