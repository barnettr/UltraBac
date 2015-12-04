using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

public partial class _controls_navSidebar : System.Web.UI.UserControl
{
	CmsContext _context = new CmsContext();
	private int _currentPageID = (int) ZNodePageType.NotAPage;
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (_context.CurrentPage == null &&
			_context.CurrentProduct == null &&
			_context.CurrentCategory == null)
		{
			navWrapper.Visible = false;
			return;
		}

		switch (_context.CurrentPageType)
		{ /// identify the content page at which we'll insert product/category controls, since
			/// they don't exist in the ContentPageNode structure
			case ZNodePageType.ProductPage:
				if (_context.CurrentProduct.IsInCategory(Config.FileByFileCategoryID))
				{
					_currentPageID = Config.FileByFilePageID;
				}
				else if (_context.CurrentProduct.IsInCategory(Config.BareMetalDisasterRecoveryCategoryID))
				{
					_currentPageID = Config.BareMetalDisasterRecoveryPageID;
				}
				break;
			case ZNodePageType.CategoryPage:
				if (_context.CurrentCategory.IsInCategory(Config.FileByFileCategoryID))
				{
					_currentPageID = Config.FileByFilePageID;
				}
				else if (_context.CurrentCategory.IsInCategory(Config.BareMetalDisasterRecoveryCategoryID))
				{
					_currentPageID = Config.BareMetalDisasterRecoveryPageID;
				}
				break;
			case ZNodePageType.ContentPage:
				_currentPageID = _context.CurrentPage.ContentPageID;
				break;
		}

		if (_currentPageID > (int)ZNodePageType.NotAPage)
		{
			try
			{
				BindData();
			}
			catch { uxOuterWrapper.Visible = false; }
		}
		else
		{
			navWrapper.Visible = false;
		}
	}

	private void BindData()
	{
		// build collection of ContentPages for datagrid
		Control c = BuildTreeReverse(_context.CurrentPageType, (int)ZNodePageType.NotAPage, _currentPageID, null);
		plhNav.Controls.Add(c);
	}

	/// <summary>
	/// Builds the menu from structure starting at the current node, and going up to the top
	/// </summary>
	/// <param name="childPageId"></param>
	/// <param name="parentPageId"></param>
	/// <param name="container"></param>
	/// <returns></returns>
	private Control BuildTreeReverse(ZNodePageType pagetype, int childPageId, int parentPageId, Control container)
	{
		// get children nodes of current ContentPage
		ContentPageNodeCollection nodes = new ContentPageNodeCollection();
		nodes.LoadChildrenNodes(parentPageId);

		HtmlGenericControl ulParent = null;
		if (nodes.Count > 0)
		{
			ulParent = new HtmlGenericControl("ul");
			foreach (ContentPageNode node in nodes)
			{
				if (node.ContentPage != null)
				{
					HtmlControl ctl = BuildLITag(node);
					ulParent.Controls.Add(ctl);
					if (node.ContentPageID == childPageId && container != null)
					{
						ctl.Controls.Add(container);
					}
				}
			}
		}

		if (parentPageId != -1)
		{
			ContentPageNode newParent = new ContentPageNode(parentPageId);
			if (newParent.ParentContentPageID != Config.RootContentPageID &&
				newParent.ParentContentPageID != -1)
			{
				return BuildTreeReverse(ZNodePageType.ContentPage, parentPageId, newParent.ParentContentPageID, ulParent);
			}
		}
		return ulParent;
	}

	private HtmlControl BuildLITag(ContentPageNode node)
	{

		// create new a tag
		HtmlAnchor a = new HtmlAnchor();
		a.HRef = node.LinkPath;
		a.Title = node.LinkText;
		a.InnerText = node.LinkText;

		// create new li tag
		HtmlGenericControl li = new HtmlGenericControl("li");
		if ((node.ContentPageID == _currentPageID &&
			_context.CurrentPageType != ZNodePageType.ContentPage) ||
			node.IsAncestorOf(_currentPageID))
		{
			li.Attributes.Add("class", "inpath");
		}
		else if (node.ContentPageID == _currentPageID)			
		{
			li.Attributes.Add("class", "here");
		}

		li.Controls.Add(a);

		// get current page as product category
		ZNodeCategory category = null;
		if (node.ContentPageID == _currentPageID &&
			_currentPageID == Config.FileByFilePageID)
		{
			category = ZNodeCategory.Create(Config.FileByFileCategoryID, ZNodeConfigManager.SiteConfig.PortalID);
		}
		else if (node.ContentPageID == _currentPageID &&
			_currentPageID == Config.BareMetalDisasterRecoveryPageID)
		{
			category = ZNodeCategory.Create(Config.BareMetalDisasterRecoveryCategoryID, ZNodeConfigManager.SiteConfig.PortalID);
		}

		if (category != null && category.ZNodeCategoryCollection.Count > 0)
		{
			HtmlGenericControl ulParent = new HtmlGenericControl("ul");
			ZNodeCategory child;
			foreach (ZNodeCategory childCategory in category.ZNodeCategoryCollection)
			{
				// not all needed properties are loaded in the collection, so get again by ID
				child = ZNodeCategory.Create(childCategory.CategoryID, ZNodeConfigManager.SiteConfig.PortalID);

				ulParent.Controls.Add(BuildCategoryLITag(child));
			}
			li.Controls.Add(ulParent);
		}

		return li;
	}

	private HtmlControl BuildCategoryLITag(ZNodeCategory category)
	{
		// create new a tag
		HtmlAnchor a = new HtmlAnchor();
		a.Title = category.Title;
		a.InnerText = category.Title;
		a.HRef = string.Format(Config.CategoryPageFormat, category.CategoryID);

		// create new li tag
		HtmlGenericControl li = new HtmlGenericControl("li");
		li.Controls.Add(a);

		bool addChildren = false;
		if (_context.CurrentCategory != null && 
			_context.CurrentCategory.CategoryID == category.CategoryID)
		{
			li.Attributes.Add("class", "here");
			addChildren = true;
		} else if (_context.CurrentProduct != null && _context.CurrentProduct.IsInCategory(category.CategoryID))
		{
			li.Attributes.Add("class", "inpath");
			addChildren = true;
		}

		if (addChildren)
		{
			HtmlGenericControl ulParent = new HtmlGenericControl("ul");
			foreach (ZNodeProduct product in category.ZNodeProductCollection)
			{
				ulParent.Controls.Add(BuildProductLITag(product));
			}
			li.Controls.Add(ulParent);
		}

		return li;
	}

	private HtmlControl BuildProductLITag(ZNodeProduct product)
	{
		// create new a tag
		HtmlAnchor a = new HtmlAnchor();
		a.HRef = string.Format(Config.ProductPageFormat, product.ProductID);
		a.Title = product.Name;
		a.InnerText = product.Name;
		 
		// create new li tag
		HtmlGenericControl li = new HtmlGenericControl("li");
		if (_context.CurrentProduct != null &&
			product.ProductID == _context.CurrentProduct.ProductID)
		{
			li.Attributes.Add("class", "here");
		}

		li.Controls.Add(a);
		return li;
	}
}