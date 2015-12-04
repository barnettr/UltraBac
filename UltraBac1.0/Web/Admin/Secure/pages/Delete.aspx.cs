using System;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;

public partial class Admin_Secure_Page_Delete : System.Web.UI.Page
{
    protected int ItemId;
    protected string PageName = string.Empty;

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
		ContentPageNode pageNode = new ContentPageNode(ItemId);
		ContentPage contentPage = pageNode.ContentPage;
        PageName = contentPage.Name;

        if (!contentPage.AllowDelete || pageNode.IsLocked)
        {
            btnDelete.Enabled = false;
            lblMsg.Text = "This page is a reserved page and cannot be deleted.";
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/pages/default.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ContentPageAdmin pageAdmin = new ContentPageAdmin();
		ContentPageNode pageNode = new ContentPageNode(ItemId);
		ContentPage contentPage = pageNode.ContentPage;

		// disallow delete action if ContentPageNode has children
		if ( pageNode.ChildPageNodes.Count > 0 )
		{
			lblMsg.Text = string.Format("Unable to delete this page because it has {0} other pages in its menu. Please delete or move its child pages first.", pageNode.ChildPageNodes.Count.ToString());
			return;
		}

		// delete ContentPage entity
        bool retval = pageAdmin.DeletePage(contentPage);

		// if ContentPage delete is successful, delete ContentPageNode and redirect
        if (retval)
        {
			ContentPageNode.Delete(ItemId);
			Response.Redirect("~/admin/secure/pages/default.aspx");
        }
        else
        {
			lblMsg.Text = "Error: Delete action could not be completed.";
		}
    }

}
