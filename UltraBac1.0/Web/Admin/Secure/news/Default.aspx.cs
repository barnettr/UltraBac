using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using System.Collections.Generic;

public partial class Admin_Secure_News_Default : Page
{
	protected string AddLink = "~/admin/secure/news/add.aspx";
	protected string EditLink = "~/admin/secure/news/add.aspx";
	protected string DeleteLink = "~/admin/secure/news/delete.aspx";

	protected string AddArticleLink = "~/admin/secure/news/article/add.aspx";
	protected string EditArticleLink = "~/admin/secure/news/article/add.aspx";
	protected string DeleteArticleLink = "~/admin/secure/news/article/delete.aspx";

	private List<CmsNewsletter> newsletters;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			BindGridData();
		}
	}

	private void BindGridData()
	{
		newsletters = CmsNewsletter.GetAll();
		uxNewsletterGrid.DataSource = newsletters;
		uxNewsletterGrid.DataBind();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect(AddLink);
	}

	#region Grid Events
	/// <summary>
	/// Event triggered when the grid page is changed
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void uxNewsletterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		uxNewsletterGrid.PageIndex = e.NewPageIndex;
	}

	/// <summary>
	/// Event triggered when an item is deleted from the grid
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void uxNewsletterGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}

	/// <summary>
	/// Event triggered when a command button is clicked on the grid
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void uxNewsletterGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
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
			GridViewRow selectedRow = uxNewsletterGrid.Rows[index];

			TableCell Idcell = selectedRow.Cells[0];
			string Id = Idcell.Text;

			switch (e.CommandName)
			{
				case "Edit":
					EditLink = EditLink + "?itemid=" + Id;
					Response.Redirect(EditLink);
					break;
				case "Delete":
					Response.Redirect(DeleteLink + "?itemid=" + Id);
					break;
				case "AddArticle":
					Response.Redirect(AddArticleLink + "?parentId=" + Id);
					break;
			}
		}
	}

	#endregion
	protected int GetArticleCount(object item)
	{
		List<CmsNewsletterArticle> articles = item as List<CmsNewsletterArticle>;
		if (articles == null)
		{
			return 0;
		}
		return articles.Count;
	}
}