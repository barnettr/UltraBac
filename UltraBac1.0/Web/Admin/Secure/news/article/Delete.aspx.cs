using System;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;

public partial class Admin_Secure_News_Article_Delete : System.Web.UI.Page
{
	protected int ItemId;
	protected string CancelLink = "~/admin/secure/news/default.aspx";
	protected string NewsletterLink = "~/admin/secure/news/add.aspx";

	protected string Title;

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

		BindData();
	}

	protected void BindData()
	{
		CmsNewsletterArticle cna = new CmsNewsletterArticle(ItemId);
		Title = cna.Title;  // Make this dynamic
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(CancelLink);
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		try
		{
			CmsNewsletterArticle cna = new CmsNewsletterArticle(ItemId);
			cna.Delete();
			Response.Redirect(NewsletterLink + "?itemid=" + cna.Newsletter.Id, false);
		}
		catch (Exception ex)
		{
			lblMsg.Text = "Error: Delete action could not be completed. Error: " + Server.HtmlEncode(ex.ToString());
		}

	}
}