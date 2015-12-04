using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;
using System.Web.UI;

public partial class Themes_Default_Category : System.Web.UI.MasterPage
{
		private CmsContext _context = new CmsContext();
		private string _categoryName;	
	private const string CategoryMessageIdFormat = "Category_{0}_Message";
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			LoadControls();
		}
		if (_context.CurrentCategory != null)
		{
			uxMessage.MessageKey = string.Format(CategoryMessageIdFormat, _context.CurrentCategory.CategoryID);
		}
		else if (_context.CurrentPage != null)
		{
			uxMessage.Visible = false;
			uxContent.Visible = true;
		}
  }

	private void LoadControls()
	{
		ZNodeCategory category = _context.CurrentCategory;

		if (category == null && _context.CurrentPage != null)
		{
			int catid = -1;
			if ("backup".Equals(_context.CurrentPage.Name, StringComparison.InvariantCultureIgnoreCase))
			{
				catid = Config.FileByFileCategoryID;
			}
			else if ("disaster-recovery".Equals(_context.CurrentPage.Name, StringComparison.InvariantCultureIgnoreCase))
			{
				catid = Config.BareMetalDisasterRecoveryCategoryID;
			}
			category = ZNodeCategory.Create(catid, ZNodeConfigManager.SiteConfig.PortalID);		
		}

		if (category != null )
		{
			_categoryName = category.Title;
			uxH2.Text = string.Format("{0}", category.Title);
			if (category.ZNodeProductCollection.Count > 0)
			{
				uxProducts.DataSource = category.ZNodeProductCollection;
				uxProducts.DataBind();
			}
			if (category.ZNodeCategoryCollection.Count > 0)
			{
				
				uxCategories.DataSource = category.ZNodeCategoryCollection;
				uxCategories.DataBind();
			}
		}
	}

	protected void uxCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Header)
		{
			ITextControl text = e.Item.FindControl("bucketName") as ITextControl;
			text.Text = "Categories";// string.Format("{0} Categories", _categoryName);

		} else if (e.Item.ItemType == ListItemType.AlternatingItem ||
			e.Item.ItemType == ListItemType.Item)
		{
			ZNodeCategory currCategory = e.Item.DataItem as ZNodeCategory;			
			if (currCategory != null)
			{
				// this object is not fully loaded, so reinstantiate
				currCategory = ZNodeCategory.Create(currCategory.CategoryID, ZNodeConfigManager.SiteConfig.PortalID);
				HtmlAnchor uxCategoryLink = e.Item.FindControl("uxCategoryLink") as HtmlAnchor;
				Literal uxProduct = e.Item.FindControl("uxProduct") as Literal;

				uxProduct.Text = currCategory.Title;
				uxCategoryLink.HRef = string.Format(Config.CategoryPageFormat, currCategory.CategoryID);
			}
		}
	}
	protected void UxProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Header)
		{
			ITextControl text = e.Item.FindControl("bucketName") as ITextControl;
			text.Text = "Products";
		}
		else if (e.Item.ItemType == ListItemType.Item ||
			e.Item.ItemType == ListItemType.AlternatingItem)
		{
			ZNodeProduct product = e.Item.DataItem as ZNodeProduct;
			HtmlAnchor uxProductLink = e.Item.FindControl("uxProductLink") as HtmlAnchor;
			Literal uxProduct = e.Item.FindControl("uxProduct") as Literal;

			uxProduct.Text = product.Name;
			uxProductLink.HRef = string.Format(Config.ProductPageFormat, product.ProductID);
		}
	}
}
