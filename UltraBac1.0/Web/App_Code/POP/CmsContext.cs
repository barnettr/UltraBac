using System;
using System.Collections.Generic;
using System.Web;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

/// <summary>
/// Summary description for CmsContext
/// </summary>
public class CmsContext
{
	public const string PageQueryString = "page";
	public const string ProductQueryString = "pid";
	public const string CategoryQueryString = "cid";

	public ContentPageNode CurrentNode
	{
		get
		{
			ContentPageNode currentNode = HttpContext.Current.Items["currentPageNode"] as ContentPageNode;
			if (currentNode == null && CurrentPage != null)
			{
				currentNode = new ContentPageNode(CurrentPage.ContentPageID);
				HttpContext.Current.Items["currentPageNode"] = currentNode;
			}

			return currentNode;
		}
	}

	public ContentPage CurrentPage
	{
		get
		{
			ContentPage currentPage = HttpContext.Current.Items["currentPage"] as ContentPage;
			if (currentPage == null)
			{
				string query = HttpContext.Current.Request[PageQueryString];
				currentPage = ZNodeContentManager.GetPageByName(query);
				HttpContext.Current.Items["currentPage"] = currentPage;
			}

			return currentPage;
		}
	}

	public ZNodeProduct CurrentProduct
	{
		get
		{
			ZNodeProduct currentProduct = HttpContext.Current.Items["currentProduct"] as ZNodeProduct;
			if (currentProduct == null)
			{
				string query = HttpContext.Current.Request[ProductQueryString];
				int productId;
				if (query != null && int.TryParse(query, out productId))
				{
					currentProduct = ZNodeProduct.Create(productId, ZNodeConfigManager.SiteConfig.PortalID);
					HttpContext.Current.Items["currentProduct"] = currentProduct;
				}
			}
			return currentProduct;
		}
	}

	public ZNodeCategory CurrentCategory
	{
		get
		{
			ZNodeCategory currentCategory = HttpContext.Current.Items["currentCategory"] as ZNodeCategory;
			if (currentCategory == null)
			{
				string query = HttpContext.Current.Request[CategoryQueryString];
				int CategoryId;
				if (query != null && int.TryParse(query, out CategoryId))
				{
					currentCategory = ZNodeCategory.Create(CategoryId, ZNodeConfigManager.SiteConfig.PortalID);
					HttpContext.Current.Items["currentCategory"] = currentCategory;
				}
			}
			return currentCategory;
		}
	}

	/// <summary>
	/// This returns the current page. Since it is technically feasible to be both a content page and a category
	/// (or product) this is the priority: Product, Category, Page, NotAPage. Since it only looks at the query
	/// string and doesn't actually validate them, it may return true for invalid pages or products
	/// </summary>
	public ZNodePageType CurrentPageType
	{
		get
		{
			if (!string.IsNullOrEmpty(HttpContext.Current.Request[ProductQueryString]))
			{
				return ZNodePageType.ProductPage;
			}
			else if (!string.IsNullOrEmpty(HttpContext.Current.Request[CategoryQueryString]))
			{
				return ZNodePageType.CategoryPage;
			}
			else if (!string.IsNullOrEmpty(HttpContext.Current.Request[PageQueryString]))
			{
				return ZNodePageType.ContentPage;
			}
			else
			{
				return ZNodePageType.NotAPage;
			}
		}
	}
}
