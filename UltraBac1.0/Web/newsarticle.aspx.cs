using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsarticle : System.Web.UI.Page
{
	private int? _articleId;
	private CmsNewsletterArticle _article;

	public string NewsletterSummary { get { return Newsletter.Summary; } }
	public string Title { get { return _article.Title; } }
	public string Body { get { return _article.Body; } }
	public CmsNewsletter Newsletter { get { return _article.Newsletter; } }
	public string NewsletterDate { get { return Newsletter.PublishDate; } }

	protected void Page_Init()
	{
		try
		{
			_articleId = int.Parse(Request["article"]);
			_article = new CmsNewsletterArticle(_articleId.Value);
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

	protected bool IsActive(object item)
	{
		CmsNewsletterArticle cna = item as CmsNewsletterArticle;
		if (cna != null &&
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
			uxMenu.Article = _article;
		}
	}

	protected void Page_PreRender()
	{
		Page.DataBind();
	}
}
