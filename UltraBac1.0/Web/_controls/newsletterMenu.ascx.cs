using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _controls_newsletterMenu : System.Web.UI.UserControl
{
	private CmsNewsletterArticle _article;
	private CmsNewsletter _newsletter;

	public CmsNewsletter Newsletter
	{
		get { return _newsletter; }
		set { _newsletter = value; }
	}

	public CmsNewsletterArticle Article
	{
		get { return _article; }
		set { _article = value; }
	}
		
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			BindData();
		}
	}

	protected bool IsActive(object item)
	{
		CmsNewsletterArticle cna = item as CmsNewsletterArticle;
		if (cna != null &&
			_article != null &&
			_article.Id == cna.Id)
		{
			return true;
		}
		return false;
	}

	private void BindData()
	{
		if (_article != null)
		{
			uxArticleNav.DataSource = _article.Newsletter.Articles;
		}
		else if (_newsletter != null)
		{
			uxArticleNav.DataSource = _newsletter.Articles;
		}
	}

	protected void Page_PreRender()
	{
		uxArticleNav.DataBind();
	}
}
