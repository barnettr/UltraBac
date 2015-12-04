using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.DataAccess.Custom;

/// <summary>
/// Summary description for CategoryPageBase
/// </summary>
public class CategoryPageBase : ZNodePageBase
{
    #region Member Variables
    private int _categoryId;
    #endregion

    #region Events
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //set master page
        this.MasterPageFile = "~/themes/" + ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.Theme + "/product/category.master"; 

        //get category id from querystring  
        if (Request.Params["cid"] != null)
        {
            _categoryId = int.Parse(Request.Params["cid"]);
        }
        else
        {         
           throw(new ApplicationException("Invalid Category Request"));
        }

        //retrieve product data
        ZNodeCategory _category = ZNodeCategory.Create(_categoryId, ZNodeConfigManager.SiteConfig.PortalID);

        //Add to httpContext
        HttpContext.Current.Items.Add("Category", _category);

        //Set SEO Properties 
        ZNodeSEO seo = new ZNodeSEO();
        if (_category.SEOTitle.Length > 0)
        {
            seo.SEOTitle = _category.SEOTitle;
        }
        else
        {
            seo.SEOTitle = _category.Name;
        }
        seo.SEOKeywords = _category.SEOKeywords;
        seo.SEODescription = _category.SEODescription;
    }
    #endregion

}
