using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Framework.Business;

public partial class Admin_Secure_News_Article_Add : System.Web.UI.Page
{
	protected int? ItemId;
	protected int? ParentId;
	protected string CancelLink = "~/admin/secure/news/default.aspx";
	protected string NewsletterLink = "~/admin/secure/news/add.aspx";

	protected void Page_Load(object sender, EventArgs e)
	{
		// Get ItemId from querystring        
		if (Request.Params["itemid"] != null)
		{
			ItemId = int.Parse(Request.Params["itemid"]);
		}		

		if (!ItemId.HasValue)
		{
			try
			{
				ParentId = int.Parse(Request.Params["parentId"]);
				CmsNewsletter nl = new CmsNewsletter(ParentId.Value);				
				if (nl == null)
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			catch
			{
				Response.Redirect(CancelLink);
			}
		}

		if (!IsPostBack)
		{
			lblTitle.Text = ItemId.HasValue ? "Edit News Article" : "Add News Article";

			//Bind data to the fields on the page
			BindData();
		}
	}

	protected void BindData()
	{
		if (ItemId.HasValue)
		{
			CmsNewsletterArticle cnl = new CmsNewsletterArticle(ItemId.Value);
			uxTitle.Text = cnl.Title;
			uxShortTitle.Text = cnl.ShortTitle;
			uxSummary.Text = cnl.Summary;
			uxSortOrder.Text = cnl.SortOrder.ToString();
			uxBody.Html = cnl.Body;
		}
		else
		{
			uxSortOrder.Text = "0";
		}

	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		//If edit mode then retrieve data first
		CmsNewsletterArticle article;
		int parentId;
		if (ItemId.HasValue)
		{
			article = new CmsNewsletterArticle(ItemId.Value);
			article.Title = uxTitle.Text;
			article.ShortTitle = uxShortTitle.Text;
			article.Summary = uxSummary.Text;
			article.Body = uxBody.Html;
			article.SortOrder = int.Parse(uxSortOrder.Text);
			article.Update();
			parentId = article.Newsletter.Id;
		}
		else
		{
			article = CmsNewsletterArticle.Create(
				uxTitle.Text,
				uxShortTitle.Text,
				uxSummary.Text,
				uxBody.Html,
				ParentId.Value,
				int.Parse(uxSortOrder.Text));
			parentId = ParentId.Value;
		}
		Response.Redirect(NewsletterLink + "?itemid=" + parentId);
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(CancelLink);
	}

}