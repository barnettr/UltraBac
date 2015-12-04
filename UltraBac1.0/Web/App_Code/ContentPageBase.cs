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
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.DataAccess.Entities;
using POP.UltraBac;

/// <summary>
/// This class builds the Content Managed Page
/// </summary>
public partial class ContentPageBase : ZNodePageBase
{
	CmsContext _currentContext = new CmsContext();

	protected void Page_PreInit(object sender, EventArgs e)
	{
		//get content page data		
		ContentPage contentPage = _currentContext.CurrentPage;

		//set master page
		string templatePath = "/content/content.master";
		if (contentPage != null)
		{
			if (!string.IsNullOrEmpty(contentPage.TemplateName))
			{
				templatePath = contentPage.TemplateName;
			}

			if (contentPage != null && contentPage.HasAutomaticRedirect)
			{
				Response.Redirect(contentPage.RedirectPage);
			}

			if (contentPage.IsResellerProtectedPage)
			{
				ResellerDb db = new ResellerDb(Config.ResellerConnectionString);
				db.EnsureResellerLogin(Request, Response, Session);
			}

			//SEO stuff
			ZNodeSEO seo = new ZNodeSEO();
			seo.SEODescription = contentPage.SEOMetaDescription;
			seo.SEOKeywords = contentPage.SEOMetaKeywords;
			seo.SEOTitle = contentPage.SEOTitle;
		}
		this.MasterPageFile = "~/themes/" + ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.Theme + templatePath;

	}
}
