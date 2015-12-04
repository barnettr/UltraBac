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
using System.IO;

public partial class Themes_Default_Content_Content : System.Web.UI.UserControl
{
	protected string _pageName = string.Empty;
	private CmsContext _context = new CmsContext();

	public bool ShowH1
	{
		get { return uxH1.Visible; }
		set { uxH1.Visible = value; }
	}

	public string PageName
	{
		get { return _pageName; }
		set { _pageName = value; }
	}

	#region Page Load
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			//get product id from querystring  
			if (string.IsNullOrEmpty(_pageName) &&
				Request.Params["page"] != null)
			{
				_pageName = Request.Params["page"];
			}

			if (string.IsNullOrEmpty(_pageName))
			{
				this.Visible = false;
			}
			else
			{
				ZNode.Libraries.DataAccess.Entities.ContentPage page = _context.CurrentPage;

				if (page == null || page.Name != _pageName)
				{
					page = ZNode.Libraries.ECommerce.Business.ZNodeContentManager.GetPageByName(_pageName);
				}
				//HTML
				lblHtml.Text = ZNode.Libraries.ECommerce.Business.ZNodeContentManager.GetPageHTMLByName(_pageName, true);

				//Title
				if (page != null)
				{
					lblTitle.Text = page.Title;
				}
			}
		}
		catch (FileNotFoundException)
		{
			Response.Redirect(string.Format("~/404.aspx?path={0}", Server.UrlEncode(Request.Url.PathAndQuery)));
		}
	}
	#endregion
}