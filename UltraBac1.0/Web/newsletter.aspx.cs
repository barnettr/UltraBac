using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsletter : System.Web.UI.Page
{
	private int? _newsletterId;
	private CmsNewsletter _newsletter;
	
	protected void Page_Init()
	{
		try
		{
			_newsletterId = int.Parse(Request["news"]);
		}
		catch
		{
			Response.Redirect("~/");
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			BindData();
		}
	}

	protected void BindData()
	{
		if (_newsletterId.HasValue)
		{
			_newsletter = new CmsNewsletter(_newsletterId.Value);
			uxNews.Newsletter = _newsletter;
		}
	}
}
