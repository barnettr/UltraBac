using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using POP.UltraBac;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;


/// <summary>
/// Summary description for ProductPageBase
/// </summary>
public class ProductPageBase : ZNodePageBase
{
    #region Private Variables
    private ZNodeProduct _product;
    protected int _productId;
    protected int _productimageid;
    Product _Products = new Product();
    #endregion

    /// <summary>
    /// Page Pre-Initialization Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //set master page
        this.MasterPageFile = "~/themes/" + ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.Theme + "/product/Product.master";


        //get product id from querystring  
        if (Request.Params["pid"] != null)
        {
            _productId = int.Parse(Request.Params["pid"]);
        }
        else
        {
            throw (new ApplicationException("Invalid Product Id"));
        }

        //retrieve product data
        _product = ZNodeProduct.Create(_productId, ZNodeConfigManager.SiteConfig.PortalID);

        // validate product belongs to this page
        ContentPage contentPage = new CmsContext().CurrentPage;
        if (contentPage != null)
        {
            int categoryID = -1;
            if (contentPage.ContentPageID == Config.FileByFilePageID)
            {
                categoryID = Config.FileByFileCategoryID;
            }
            else if (contentPage.ContentPageID == Config.BareMetalDisasterRecoveryPageID)
            {
                categoryID = Config.BareMetalDisasterRecoveryCategoryID;
            }
            else if (contentPage.ContentPageID == Config.SmallBusinessPageID)
            {
                categoryID = Config.SmallBusinessCategoryID;
            }
            else if (contentPage.ContentPageID == Config.MediumBusinessPageID)
            {
                categoryID = Config.MediumBusinessCategoryID;
            }
            else if (contentPage.ContentPageID == Config.EnterprisePageID)
            {
                categoryID = Config.EnterpriseCategoryID;
            }
            if (!_product.IsInCategory(categoryID))
            {
                throw new ArgumentException(string.Format("Product {0} not found in category {1}.", _productId, categoryID));
            }
        }

        //add to http context so it can be shared with user controls
        HttpContext.Current.Items.Add("Product", _product);
     

        //Set SEO Properties
        ZNodeSEO seo = new ZNodeSEO();
        if (_product.SEOTitle.Length > 0)
        {
            seo.SEOTitle = _product.SEOTitle;
        }
        else
        {
            seo.SEOTitle = _product.Name;
        }
        seo.SEOKeywords = _product.SEOKeywords;
        seo.SEODescription = _product.SEODescription;

    }
}
