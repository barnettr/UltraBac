using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using System.Collections.Generic;

public partial class Admin_Secure_page_Default : System.Web.UI.Page
{
    protected string ListLink = "~/admin/secure/pages/default.aspx";
    protected string AddLink = "~/admin/secure/pages/add.aspx";
    protected string RevertLink = "~/admin/secure/pages/revert.aspx";
    protected string EditLink = "~/admin/secure/pages/add.aspx";
    protected string DeleteLink = "~/admin/secure/pages/delete.aspx";

		private List<BindingClassHelper> _pages;

	protected void Page_Init()
	{
		this.Form.DefaultButton = btnSearch.UniqueID;
	}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindGridData(string.Empty);
    }

		private void BindGridData(string searchTerm)
		{
			searchTerm = searchTerm.ToLower();
			// build collection of ContentPages for datagrid
			_pages = new List<BindingClassHelper>();
			AddNodesToPageList(-1);
			if (!string.IsNullOrEmpty(searchTerm))
			{
				_pages = _pages.FindAll(delegate(BindingClassHelper m)
				{
					return 
						(m.Name != null && m.Name.ToLower().Contains(searchTerm)) ||
						(m.Node.ContentPage.Name.ToLower().Contains(searchTerm)) ||
						(m.Node.ContentPage.Title != null &&	m.Node.ContentPage.Title.ToLower().Contains(searchTerm)) ||
						(m.Node.ContentPage.SEOTitle != null && m.Node.ContentPage.SEOTitle.ToLower().Contains(searchTerm));
				}
				);
			}
			// bind the datagrid to the ContentPage collection
			uxGrid.DataSource = _pages;
			uxGrid.DataBind();
		}

	private static int recursionLevel = -1;
	private void AddNodesToPageList(int contentPageID)
	{
		// increment recursion level
		recursionLevel++;

		// get children nodes of current ContentPage
		ContentPageNodeCollection nodes = new ContentPageNodeCollection();
		nodes.LoadChildrenNodes(contentPageID);

		if ( nodes != null && nodes.Count > 0 )
		{
			foreach ( ContentPageNode node in nodes )
			{
				ContentPage page = node.ContentPage;

                if (page != null)
                {
                    // replace page name with node link text for display purposes
                    StringBuilder name = new StringBuilder();
                    // use recursion level to determine indentation of page name
                    name.Append(new string(Convert.ToChar("-"), recursionLevel * 2));
                    name.AppendFormat(" {0}", node.LinkText);
                    
										BindingClassHelper pageH = new BindingClassHelper(node);
										pageH.Name = name.ToString();

                    // add the ContentPage to the collection
                    _pages.Add(pageH);

                    // load children of this node into the collection
                    AddNodesToPageList(page.ContentPageID);
                }
			}
		}

		// decrement recursion level
		recursionLevel--;
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
        BindGridData(uxSearch.Text);
    }

    /// <summary>
    /// Event triggered when an item is deleted from the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindGridData(uxSearch.Text);
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

			ContentPageAdmin pageAdmin = new ContentPageAdmin();
			ContentPage contentPage = pageAdmin.GetPageByID(int.Parse(Id));

			switch ( e.CommandName )
			{
				case "Preview":
					Response.Redirect(ResolveUrl(GetPageURL(contentPage.Name)));
					break;
				case "Edit":
					EditLink = EditLink + "?itemid=" + Id;
					Response.Redirect(EditLink);
					break;
				case "Publish":
					pageAdmin.PublishPage(contentPage);
					Response.Redirect(ListLink);
					break;
				case "Revert":
					RevertLink = RevertLink + "?itemid=" + Id;
					Response.Redirect(RevertLink);
					break;
				case "Delete":
					Response.Redirect(DeleteLink + "?itemid=" + Id);
					break;
			}
        }
    }

    #endregion

    #region Other Events
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(AddLink);
    }
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			BindGridData(uxSearch.Text);
		}

		protected void btnClear_Click(object sender, EventArgs e)
		{
			uxSearch.Text = string.Empty; 
			BindGridData(uxSearch.Text);
		}
    #endregion

    # region Helper Methods
    /// <summary>
    /// Returns the path to open the html content pages
    /// </summary>
    /// <param name="pageName"></param>
    /// <returns></returns>
    public string GetPageURL(string pageName)
    {
        //if page name is Home, then it must be open with default page.
        if (pageName.Equals("Home"))
        {
            return "~/default.aspx?page=" + pageName;
        }
        //otherwise the content pages should be open with content.aspx page
        //more Specific to Content pages
        return "~/content.aspx?page=" + pageName;
    }
     #endregion
}

public class BindingClassHelper
{
	private int _contentPageID;	
	private string _name;
	private int _sortIndex;
	private ContentPageNode _node;
	
	public BindingClassHelper(ContentPageNode node)
	{
		_node = node;
		_contentPageID = node.ContentPage.ContentPageID;
		_name = node.ContentPage.Name;
		_sortIndex = node.SortIndex;
	}
	
	public ContentPageNode Node
	{
		get { return _node; }
		set { _node = value; }
	}

	public int SortIndex
	{
		get { return _sortIndex; }
		set { _sortIndex = value; }
	}
	
	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}
	public int ContentPageID
	{
		get { return _contentPageID; }
		set { _contentPageID = value; }
	}
}