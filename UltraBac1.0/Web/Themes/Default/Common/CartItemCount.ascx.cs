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

/// <summary>
/// Displays number of items in the shopping cart
/// </summary>
public partial class Controls_CartItemCount : System.Web.UI.UserControl
{
    #region Private Variables
    protected string CartItemCount = string.Empty;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //get shopping cart
        ZNodeShoppingCart shoppingCart = (ZNodeShoppingCart)ZNodeCheckout.CreateFromSession(ZNodeSessionKeyType.ShoppingCart);

        if (shoppingCart != null)
        {
            CartItemCount = shoppingCart.ShoppingCartItems.Count.ToString();
        }
        else
        {
            CartItemCount = "0";
        }
    }
    #endregion
}
