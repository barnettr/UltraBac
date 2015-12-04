using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;

/// <summary>
/// Summary description for BuyPageBase.cs
/// </summary>
public class BuyPageBase : ZNodePageBase
{
    # region Protected Member Variables
    string SKU = "";
    int ProductID = 0;
    ZNodeProduct _product = null;
    # endregion

    # region General Events

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //this.MasterPageFile = "~/themes/" + ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.Theme + "/shoppingcart/OneClickAddToCart.master"; 
    }

   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["sku"] != null)
        {
            SKU = Request.Params["sku"];
        }

        if (SKU.Length == 0)
        {
            //lblError.Text = "Could not find the product requested in the database.";
            Response.Redirect("~/error.aspx");
            return;
        }

        if (!Page.IsPostBack)
        {
            ZNodeSKU objSKU = new ZNodeSKU();
            objSKU = ZNodeSKU.CreateBySKU(SKU);

            if (objSKU.SKUID > 0)
            {
                objSKU.AttributesDescription = " ";
                ProductID = objSKU.ProductID;

                _product = ZNodeProduct.Create(ProductID, ZNodeConfigManager.SiteConfig.PortalID);

                //set product SKU
                _product.SelectedSKU = objSKU;

                //create shopping cart item
                ZNodeShoppingCartItem item = new ZNodeShoppingCartItem();
                item.Product = _product;
                item.Quantity = 1;

                //add product to cart
                ZNodeShoppingCart shoppingCart = ZNodeShoppingCart.CurrentShoppingCart();
                //if shopping cart is null, create in session
                if (shoppingCart == null)
                {
                    shoppingCart = new ZNodeShoppingCart();
                    shoppingCart.AddToSession(ZNodeSessionKeyType.ShoppingCart);
                }

                //add item to cart
                if (shoppingCart.AddToCart(item))
                {
                    string link = "~/shoppingcart.aspx";
                    Response.Redirect(link);
                }
                else
                {
                    //If Product is out of Stock - Redirected to Product Details  page
                    //lblError.Text = "This product is out of stock.";
                    Response.Redirect("~/error.aspx");
                }
            }
            else
            {
                //If SKUID or Invalid SKU is Zero then Redirected to default page
                //lblError.Text = "Could not find the product requested in the database.";
                Response.Redirect("~/error.aspx");
            }
        }

    }
    # endregion
}
