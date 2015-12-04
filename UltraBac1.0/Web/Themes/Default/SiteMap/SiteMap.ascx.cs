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
using ZNode.Libraries.DataAccess.Entities;
using POP.UltraBac;
using System.Text;
using ZNode.Libraries.Admin;
using System.Collections.Generic;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

public partial class Themes_Default_SiteMap_SiteMap : System.Web.UI.UserControl
{
	private List<SiteMapPage> pages;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			BindPages();
			BindProducts();
		}
	}

	private void BindProducts()
	{
		ZNodeProductList list = ZNodeProductList.GetProductsByPrice(ZNodeConfigManager.SiteConfig.PortalID, 0, 100000);
		if (list != null)
		{
			uxProds.DataSource = list.ZNodeProductCollection;
			uxProds.DataBind();
		}
	}

	private void BindPages()
	{
		// build collection of ContentPages for datagrid
		pages = new List<SiteMapPage>();
		AddNodesToPageList(-1);
		
		// bind the datagrid to the ContentPage collection
		uxRep.DataSource = pages;
		uxRep.DataBind();
	}

	private static int recursionLevel = -1;
	private void AddNodesToPageList(int contentPageID)
	{
		// increment recursion level
		recursionLevel++;

		// get children nodes of current ContentPage
		ContentPageNodeCollection nodes = new ContentPageNodeCollection();
		nodes.LoadChildrenNodes(contentPageID);

		if (nodes != null && nodes.Count > 0)
		{
			foreach (ContentPageNode node in nodes)
			{
				ContentPage page = node.ContentPage;

				if (page != null &&
					!page.IsDeleted &&
					page.ContentPageID > 0)
				{
					// add the ContentPage to the collection
					pages.Add(new SiteMapPage(page, recursionLevel));
					
					// load children of this node into the collection
					AddNodesToPageList(page.ContentPageID);
				}
			}
		}

		// decrement recursion level
		recursionLevel--;
	}

	protected string GetDepth(object item)
	{
		SiteMapPage page = item as SiteMapPage;
		if (page != null)
		{
			return string.Format("depth{0}", page.Depth);
		}
		return string.Empty;
	}
	
}

public class SiteMapPage
{
	private int _depth;
	public int Depth
	{
		get { return _depth; }
		set { _depth = value; }
	}
	private ContentPage _pageItem;

	public SiteMapPage(ContentPage item, int depth)
	{
		_pageItem = item;
		_depth = depth;
	}

	public string Title { get { return _pageItem.Title; } }
	public string Name { get { return _pageItem.Name; } }
}