using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;

public partial class Admin_Secure_events_Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
			BindGridData();
		
	}

	protected void uxAddEvent_Click(object sender, EventArgs e)
	{
		Response.Redirect("add.aspx");
	}
	#region Grid Events
	/// <summary>
	/// Event triggered when the grid page is changed
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		uxGrid.PageIndex = e.NewPageIndex;
		BindGridData();
	}

	/// <summary>
	/// Event triggered when an item is deleted from the grid
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void uxGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		BindGridData();
	}

	private void BindGridData()
	{
		CmsEventCollection events = new CmsEventCollection(new DateTime(2000,1,1), new DateTime(3000,1,1));
		events.Load();
		uxGrid.DataSource = events;
		uxGrid.DataBind();
	}

	/// <summary>
	/// Event triggered when a command button is clicked on the grid
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void uxGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
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
			GridViewRow selectedRow = uxGrid.Rows[index];

			TableCell Idcell = selectedRow.Cells[0];
			string Id = Idcell.Text;
			string EditLink = "add.aspx", DeleteLink = "delete.aspx";
			switch (e.CommandName)
			{
				case "Edit":
					EditLink = EditLink + "?itemid=" + Id;
					Response.Redirect(EditLink);
					break;
				case "Delete":
					Response.Redirect(DeleteLink + "?itemid=" + Id);
					break;
			}
		}
	}

	#endregion
}
