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
using System.Text;

public partial class Controls_ShoppingCartProduct_ProductTitle : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeProduct _product;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //retrieve product object from HttpContext (set previously in the page_preinit event of the page)
        _product = (ZNodeProduct)HttpContext.Current.Items["Product"];
        Bind();
    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind control display based on properties set
    /// </summary>
    public void Bind()
    {
        if (Visible)
        {
            if (_product.CallForPricing)
            {
                StringBuilder sbPrice = new StringBuilder();
                sbPrice.Append("<span class=CallForPriceMsg>");
                sbPrice.Append(ZNodeConfigManager.MessageConfig.GetMessage("CallForPricing"));
                sbPrice.Append("</span>");

                return;
            }

            if (_product.SalePrice > 0)
            {
                StringBuilder sbPrice = new StringBuilder();
                sbPrice.Append("<span class=RegularPrice>");
                sbPrice.Append(_product.RetailPrice.ToString("C"));
                sbPrice.Append("</span>");

                sbPrice.Append("<span class=SalePrice>");
                sbPrice.Append(_product.SalePrice.ToString("C"));
                sbPrice.Append("</span>");

                Price.Text = sbPrice.ToString();
            }
            else
            {
                StringBuilder sbPrice = new StringBuilder();
                sbPrice.Append("<span class=Price>");
                sbPrice.Append(_product.RetailPrice.ToString("C"));
                sbPrice.Append("</span>");

                Price.Text = sbPrice.ToString();
            }
        }
    }
    #endregion
}
