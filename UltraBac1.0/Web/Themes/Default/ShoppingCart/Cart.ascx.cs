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

public partial class Themes_Default_ShoppingCart_Cart : System.Web.UI.UserControl
{
    #region Member Variables
    protected ZNodeShoppingCart _shoppingCart;
    #endregion

    #region Events
    protected override void OnPreRender(EventArgs e)
    {
        ContinueShopping.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/ContinueShopping.gif"; 
        ContinueShopping1.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/ContinueShopping.gif";

        Checkout.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/Checkout.gif";
        Checkout1.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/Checkout.gif"; 

        _shoppingCart = ZNodeShoppingCart.CurrentShoppingCart();

        if (_shoppingCart != null)
        {
            Bind();
        }
        else
        {
            pnlShoppingCart.Visible = false;
            uxMsg.Text = "There are no items in the shopping cart.";
        }
    }

    /// <summary>
    /// Checkout button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Checkout_Click(object sender, ImageClickEventArgs e)
    {
        ZNodeShoppingCart shoppingCart = ZNodeShoppingCart.CurrentShoppingCart();
        uxCart.UpdateQuantity();
        // uxCart.BindCouponData();       

        if (shoppingCart.Count == 0)
        {
            uxMsg.Text = "Please add items to your shopping cart before checking out.";
            return;
        }
        else
        {
            ZNodeUrl url = new ZNodeUrl();
            string link = "~/checkout.aspx";
            if ((uxCart.FindControl("ecoupon") as TextBox).Text.Length > 0)
            {
                if (uxCart.BindCouponData())
                {
                    Response.Redirect(link);
                }
            }
            else
            { Response.Redirect(link); }
        }
    }
    protected void ContinueShopping1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/content.aspx?page=order");
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind All Controls
    /// </summary>
    protected void Bind()
    {
        //show/hide cart
        if (_shoppingCart.Count > 0)
        {
            pnlShoppingCart.Visible = true;
            uxMsg.Text = "";
        }
        else
        {
            pnlShoppingCart.Visible = false;
            uxMsg.Text = "There are no items in the shopping cart.";
        }

        //bind grid
        uxCart.Bind();
    }
    #endregion
}
