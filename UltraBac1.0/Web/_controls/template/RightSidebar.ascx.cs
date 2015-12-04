using System;
using System.Web;
using System.Web.UI;
using POP.UltraBac;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;
using System.Collections.Generic;

public partial class _controls_template_RightSidebar : System.Web.UI.UserControl
{
	public bool ShowResources
	{
		get { return uxResources.Visible; }
		set { uxResources.Visible = value; }
	}

	public bool ShowSupport
	{
		get { return uxSupportArea.Visible; }
		set { uxSupportArea.Visible = value; }
	}

	public bool ShowNews
	{
		get { return uxNewsArea.Visible; }
		set { uxNewsArea.Visible = value; }
	}

	public bool ShowSearch
	{
		get { return uxSearchPanel.Visible; }
		set { uxSearchPanel.Visible = value; }
	}


	public bool ShowCertifications
	{
		get { return uxCertifications.Visible; }
		set { uxCertifications.Visible = value; }
	}

	public _controls_template_RightSidebar()
	{
	}

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		if (!IsPostBack)
		{
			ZNodeCategory category = Cache[_productCacheString] as ZNodeCategory;
			if (category == null)
			{
				category = ZNodeCategory.Create(Config.FeaturedProductCategoryID, ZNodeConfigManager.SiteConfig.PortalID);

				Cache.Insert(_productCacheString, category, null, DateTime.Now.AddMinutes(_productCacheMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
			}
			if (category != null && category.ZNodeProductCollection.Count > 0)
			{
				_maxIndex = category.ZNodeProductCollection.Count - 1;
			}
			uxProducts.DataSource = category.ZNodeProductCollection;
			uxProducts.DataBind();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		// don't redirect to the search page if the search text is "-- search the site --"
		if (IsPostBack && !string.IsNullOrEmpty(uxQuery.Text) && uxQuery.Text != label.Text)
		{
			Response.Redirect(string.Format("~/search.aspx?q={0}", HttpUtility.UrlEncode(uxQuery.Text)));

			// free search, redirect out of site
			//Response.Redirect(Config.GoogleCseUrl + HttpUtility.UrlEncode(uxQuery.Text));
		}

	}

	private int _maxIndex = 0;
	private string _productCacheString = "productsDDl";
	private int _productCacheMinutes = 60;

	protected void uxProducts_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item ||
			e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
		{
			HtmlAnchor a = e.Item.FindControl("a") as HtmlAnchor;
			HtmlGenericControl li = e.Item.FindControl("li") as HtmlGenericControl;
			ZNodeProduct product = e.Item.DataItem as ZNodeProduct;
			if (product != null)
			{
				if (e.Item.ItemIndex == 0)
				{
					li.Attributes.Add("class", "first");
				}
				else if (e.Item.ItemIndex == _maxIndex)
				{
					li.Attributes.Add("class", "last");
				}

				a.InnerText = product.Name;
				a.HRef = ResolveUrl(string.Format("~/product.aspx?pid={0}", product.ProductID));
			}
		}

	}
}