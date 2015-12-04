using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZNode.Libraries.ECommerce.Business;
using Pop.Web.UI.WebControls;

public partial class _controls_productorder : System.Web.UI.UserControl
{
	private ZNodeProduct _product;

	public ZNodeProduct Product
	{
		get { return _product; }
		set { _product = value;
		uxProductId.Text = _product.ProductID.ToString();
		}
	}

	private int? _productId;

	public int? ProductId
	{
		get { return _productId; }
		private set { _productId = value; }
	}

	private int? _quantity;

	public int? Quantity
	{
		get { return _quantity; }
		private set { _quantity = value; }
	}


	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			try
			{
				Quantity = int.Parse(uxQuantity.Text);
				ProductId = int.Parse(uxProductId.Text);
			}
			catch
			{
				ProductId = 0;
				Quantity = 0;
			}
		}
	}
}