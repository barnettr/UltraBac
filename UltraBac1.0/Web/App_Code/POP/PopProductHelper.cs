using System;
using System.Collections.Generic;
using System.Web;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

/// <summary>
/// Summary description for ProductHelper
/// </summary>
public static class PopProductHelper
{
	
	/// <summary>
	/// Adds Item to Shopping Cart
	/// </summary>
	public static bool AddToCart(int productId, int quantity)
	{
		if (quantity < 1)
		{
			throw new Exception(string.Format("Must purchase at least one item. Received {0}", quantity));
		}

		ZNodeProduct product = ZNodeProduct.Create(productId, ZNodeConfigManager.SiteConfig.PortalID);
		product.SelectedSKU = ZNodeSKU.CreateByProductDefault(productId);
		product.SelectedSKU.AttributesDescription = string.Empty;

		//create shopping cart item
		ZNodeShoppingCartItem item = new ZNodeShoppingCartItem();
		item.Product = product;
		item.Quantity = quantity;
		
		//add product to cart
		ZNodeShoppingCart shoppingCart = ZNodeShoppingCart.CurrentShoppingCart();
		//if shopping cart is null, create in session
		if (shoppingCart == null)
		{
			shoppingCart = new ZNodeShoppingCart();
			shoppingCart.AddToSession(ZNodeSessionKeyType.ShoppingCart);
		}

		bool result = shoppingCart.AddToCart(item);		
		return result;
	}
}
