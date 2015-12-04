using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

public partial class Themes_Default_Content_Content : MasterPage
{
	private CmsContext _context = new CmsContext();
	public void Page_Load(object sender, EventArgs e)
	{
		if (_context.CurrentPage == null)
		{
			Response.Redirect(string.Format("~/404.aspx?path={0}", Server.UrlEncode(Request.Url.PathAndQuery)));
		}

		SecurityUtility.EnsureInsecure(Request, Response);
	}
}