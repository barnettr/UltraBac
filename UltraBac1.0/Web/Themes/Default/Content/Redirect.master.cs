using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Themes_Default_Content_Redirect : System.Web.UI.MasterPage
{
	private CmsContext _context = new CmsContext();

	protected void Page_Load()
	{		
		if (_context.CurrentPage == null)
		{
			Response.Redirect(string.Format("~/404.aspx?path={0}", Server.UrlEncode(Request.Url.PathAndQuery)));
		}
		else
		{
			ZNode.Libraries.DataAccess.Entities.ContentPage page = _context.CurrentPage;

			if (page != null && page.HasAutomaticRedirect)
			{
				Response.Redirect(page.RedirectPage);
			}
		}
	}
}