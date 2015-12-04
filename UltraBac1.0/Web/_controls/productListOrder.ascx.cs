using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

public partial class _controls_productListOrder : System.Web.UI.UserControl
{
	private int? _categoryId;

	public int? CategoryId
	{
		set { _categoryId = value; }
		get { return _categoryId; }
	}

	private ZNodeCategory _category;

	public ZNodeCategory Category
	{
		get { return _category; }
		set { _category = value; }
	}
	

	protected void Page_Load(object sender, EventArgs e)
	{
		if (_categoryId.HasValue)
		{
			 Category = ZNodeCategory.Create(_categoryId.Value, ZNodeConfigManager.SiteConfig.PortalID);
			List<ZNodeProduct> list2 = new List<ZNodeProduct>();

			for (int i = 0; i < Category.ZNodeProductCollection.Count; i++)
			{
				ZNodeProduct prod = ZNodeProduct.Create(Category.ZNodeProductCollection[i].ProductID, ZNodeConfigManager.SiteConfig.PortalID);
				if (!prod.CallForPricing && prod.QuantityOnHand > 0)
				{
					list2.Add(prod);
				}
			}
			
			uxProducts.DataSource = list2;
		}
	}

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (!_databound)
		{
			DataBind();
		}
	}

	private bool _databound = false;
	public override void DataBind()
	{
		_databound = true;
		base.DataBind();
	}
}
