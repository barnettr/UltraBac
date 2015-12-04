using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _controls_newsletterControl : System.Web.UI.UserControl
{
	private CmsNewsletter _newsletter;

	public CmsNewsletter Newsletter
	{
		get { return _newsletter; }
		set { _newsletter = value; }
	}

	public List<CmsNewsletterArticle> Articles { get { return _newsletter.Articles; } }

	public string Title { get { return _newsletter.Title; } }
	public string Summary { get { return _newsletter.Summary; } }
	public string NewsletterDate { get { return _newsletter.PublishDate; } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			BindData();
		}
	}

	private void BindData()
	{
		if (_newsletter != null)
		{
			uxMenu.Newsletter = _newsletter;
			uxArticleList.DataSource = Articles;
		}
	}

	protected void Page_PreRender()
	{
		uxArticleList.DataBind();
	}
}
