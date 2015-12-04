using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;

public partial class _controls_navBreadcrumb : System.Web.UI.UserControl
{

	private ContentPageNode _currentNode = null;
	private HtmlGenericControl _ctlUL = new HtmlGenericControl("ul");
	CmsContext _context = new CmsContext();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (_context.CurrentPage == null ||
			_context.CurrentNode == null ||
			_context.CurrentNode.ParentContentPageID == -1)
		{
			this.Visible = false;
		}
		
		// get id of page
		CmsContext context = new CmsContext();
		ContentPage currentPage = context.CurrentPage;
		if ( currentPage != null )
		{
			_currentNode = context.CurrentNode;
			BindData();
		}
	}

	private void BindData()
	{
		// add ul wrapper
		plhNav.Controls.Add(_ctlUL);

		// add content nodes
		AddParentNodes(_currentNode);
	}

	private void AddParentNodes(ContentPageNode node)
	{
		// insert li tag
		HtmlControl li = BuildLITag(node);
		if ( node.ContentPageID == _currentNode.ContentPageID )
		{
			li.Attributes.Add("class", "last-child");
		}
		_ctlUL.Controls.AddAt(0, li);

		// recurse if a parent exists
		if ( node.ParentContentPageID != -1 )
		{
			ContentPageNode parentNode = new ContentPageNode(node.ParentContentPageID);
			AddParentNodes(parentNode);
		}
	}

	private HtmlControl BuildLITag(ContentPageNode node)
	{

		// create new a tag
		HtmlAnchor a = new HtmlAnchor();
		a.HRef = node.LinkPath;
		a.Title = node.LinkText;
		a.InnerText = node.LinkText;

		// create new li tag
		HtmlGenericControl li = new HtmlGenericControl("li");
		li.Controls.Add(a);
		return li;

	}
}
