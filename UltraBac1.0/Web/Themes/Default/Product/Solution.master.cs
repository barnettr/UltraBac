using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

public partial class Themes_Default_Solution : System.Web.UI.MasterPage
{
    private ContentPage _contentPage;
    
    protected void Page_Load(object sender, EventArgs e)
	{
        if (!IsPostBack)
        {
					LoadWhitePapers(); 
            CmsContext cmsContext = new CmsContext();
            if (cmsContext.CurrentPage != null)
            {
                _contentPage = cmsContext.CurrentPage;
            }

            if (_contentPage != null)
            {
                LoadProducts();
            }
        }
    }

		private void LoadWhitePapers()
		{			// removed 6/10/2009 per clients request
			//ContentPageNodeCollection coll = new ContentPageNodeCollection();
			//coll.LoadChildrenNodes(Config.WhitePapersPageID);
			//uxWhitePapers.DataSource = coll;
			//uxWhitePapers.DataBind();
		}

    private void LoadProducts()
    {
        ZNodeCategory category = null;
        if (_contentPage.ContentPageID == Config.SmallBusinessPageID)
        {
            category = ZNodeCategory.Create(Config.SmallBusinessCategoryID, ZNodeConfigManager.SiteConfig.PortalID);
        }
        else if (_contentPage.ContentPageID == Config.MediumBusinessPageID)
        {
            category = ZNodeCategory.Create(Config.MediumBusinessCategoryID, ZNodeConfigManager.SiteConfig.PortalID);
        }
        else if (_contentPage.ContentPageID == Config.EnterprisePageID)
        {
            category = ZNodeCategory.Create(Config.EnterpriseCategoryID, ZNodeConfigManager.SiteConfig.PortalID);
        }

        if (category != null)
        {
            uxProducts.DataSource = category.ZNodeProductCollection;
            uxProducts.DataBind();
        }
    }

    protected void UxProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ZNodeProduct product = e.Item.DataItem as ZNodeProduct;
        HtmlAnchor uxProductLink = e.Item.FindControl("uxProductLink") as HtmlAnchor;
        Literal uxProduct = e.Item.FindControl("uxProduct") as Literal;

        uxProduct.Text = product.Name;
        uxProductLink.HRef = string.Format(Config.ProductPageFormat, product.ProductID);
    }
}
