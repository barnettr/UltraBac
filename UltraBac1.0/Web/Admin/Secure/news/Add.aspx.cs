using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Framework.Business;

public partial class Admin_Secure_News_Add : System.Web.UI.Page
{
	protected int ItemId;
	protected string CancelLink = "~/admin/secure/news/default.aspx";
  protected string EditLink = "~/admin/secure/news/article/add.aspx";
  protected string DeleteLink = "~/admin/secure/news/article/delete.aspx";


	protected void Page_Load(object sender, EventArgs e)
	{
		// Get ItemId from querystring        
		if (Request.Params["itemid"] != null)
		{
			ItemId = int.Parse(Request.Params["itemid"]);
		}
		else
		{
			ItemId = 0;
		}

		if (!IsPostBack)
		{
			lblTitle.Text = ItemId > 0 ? "Edit Newsletter" : "Add Newsletter";

			//Bind data to the fields on the page
			BindData();
		}
	}

	protected void BindData()
	{
		if (ItemId > 0)
		{
			CmsNewsletter nl = new CmsNewsletter(ItemId);
			uxTitle.Text = nl.Title;
			uxNewsletterType.SelectedIndex = (int) nl.NewsletterType;
			uxSummary.Html = nl.Summary;
			uxPublishDate.Text = nl.PublishDate;
			uxSortOrder.Text = nl.SortOrder.ToString();
			uxArticleSection.Visible = true;
			uxArticles.DataSource = nl.Articles;
			uxArticles.DataBind();
		}
		else
		{
			//nothing to do here
			uxSortOrder.Text = "0";
		}

	}

	protected void GridArticle_Command(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "page")
		{
		}
		else
		{
			// Convert the row index stored in the CommandArgument
			// property to an Integer.
			int index = Convert.ToInt32(e.CommandArgument);

			// Get the values from the appropriate
			// cell in the GridView control.
			GridViewRow selectedRow = uxArticles.Rows[index];

			TableCell Idcell = selectedRow.Cells[0];
			string Id = Idcell.Text;
			

			switch (e.CommandName)
			{
				case "EditArticle":
					EditLink = EditLink + "?itemid=" + Id;
					Response.Redirect(EditLink);
					break;
				case "DeleteArticle":
					Response.Redirect(DeleteLink + "?itemid=" + Id);
					break;
			}
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		//If edit mode then retrieve data first
		if (ItemId > 0)
		{
			CmsNewsletter nl = new CmsNewsletter(ItemId);
			nl.PublishDate = uxPublishDate.Text;
			nl.Title = uxTitle.Text;
			nl.NewsletterType = GetNewsletterType();
			nl.Summary = uxSummary.Html;
			nl.SortOrder = int.Parse(uxSortOrder.Text);
			nl.Update();
		}
		else
		{
			CmsNewsletter newsletter = CmsNewsletter.Create(uxTitle.Text, uxSummary.Html, uxPublishDate.Text, int.Parse(uxSortOrder.Text), GetNewsletterType());
			ItemId = newsletter.Id;
		}
		Response.Redirect(CancelLink);
	}

	private NewsletterType GetNewsletterType()
	{
		return (NewsletterType)int.Parse(uxNewsletterType.SelectedValue);
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(CancelLink);
	}

}