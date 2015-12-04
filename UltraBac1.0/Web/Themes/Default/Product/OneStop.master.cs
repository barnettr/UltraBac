using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Themes_Default_Product_OneStop : System.Web.UI.MasterPage
{
	Dictionary<int, int> _quantities = null;

	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void AddToCart_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			if (_quantities == null)
			{
				_quantities = new Dictionary<int, int>();
				GetProductQuantities(this, ref _quantities);
			}

			AddToCart(_quantities);

		}
	}

	private void AddToCart(Dictionary<int, int> productQuantities)
	{
		bool itemsAdded = false;
		foreach (int productid in productQuantities.Keys)
		{
			if (productQuantities[productid] > 0)
			{
				bool result = PopProductHelper.AddToCart(productid, productQuantities[productid]);
				if (result)
				{
					itemsAdded = true;
				}
			}
		}
		if (itemsAdded)
		{
			Response.Redirect("~/shoppingcart.aspx");
		}
	}

	private void GetProductQuantities(Control control, ref Dictionary<int, int> quantities)
	{
		foreach (Control c in control.Controls)
		{
			_controls_productorder order = c as _controls_productorder;
			if (order != null && order.Quantity.HasValue && order.ProductId.HasValue)
			{
				if (order.Quantity > 0)
				{
					if (quantities.ContainsKey(order.ProductId.Value))
					{
						quantities[order.ProductId.Value] = quantities[order.ProductId.Value] + order.Quantity.Value;
					}
					else
					{
						quantities[order.ProductId.Value] = order.Quantity.Value;
					}
				}
			}
			else
			{
				if (c.Controls.Count > 0)
				{
					GetProductQuantities(c, ref quantities);
				}
			}
		}
	}

	protected void CheckTotals(object sender, ServerValidateEventArgs e)
	{
		_quantities = new Dictionary<int, int>();
		GetProductQuantities(this, ref _quantities);

		bool atLeastOnePurchase = false;
		foreach (int key in _quantities.Keys)
		{
			if (_quantities[key] > 0)
			{
				atLeastOnePurchase = true;
				break;
			}
		}
		e.IsValid = atLeastOnePurchase;
	}
}