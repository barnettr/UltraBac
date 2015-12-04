using System;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;

public partial class Admin_Secure_News_Delete : System.Web.UI.Page
{
	protected int ItemId;
	protected string CancelLink = "~/admin/secure/news/default.aspx";

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
		CmsNewsletter nl = new CmsNewsletter(ItemId);
		Title = nl.Title;
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect(CancelLink);
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		// delete newsletter entity
		bool retval = false;
		Exception ex = null;
		try
		{
			CmsNewsletter nl = new CmsNewsletter(ItemId);
			nl.Delete();
			retval = true;
		}
		catch (Exception err) { ex = err; }

		// if newsletter delete is successful, redirect
		if (retval)
		{
			Response.Redirect(CancelLink);
		}
		else
		{
			lblMsg.Text = "Error: Delete action could not be completed. Error: " + Server.HtmlEncode(ex.ToString());
		}
	}

}