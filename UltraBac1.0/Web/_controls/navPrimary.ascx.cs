using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;

public partial class _controls_navPrimary : System.Web.UI.UserControl
{	
	ContentPageNode _currentNode = null;

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);

		CmsContext context = new CmsContext();
		_currentNode = context.CurrentNode;
		
		BindData();
	}

	private void BindData()
	{
		// add content nodes
		AddNodes(plhNav, Config.RootContentPageID);
	}

	static int recursionLevel = 1;
	private void AddNodes(Control parentControl, int contentPageID)
	{
		recursionLevel++;
		// get children nodes of current ContentPage
		ContentPageNodeCollection nodes = new ContentPageNodeCollection();
		nodes.LoadChildrenNodes(contentPageID);

		if ( nodes != null && nodes.Count > 0 )
		{
			// add ul tag
			HtmlGenericControl ulParent = new HtmlGenericControl("ul");
			parentControl.Controls.Add(ulParent);

			foreach ( ContentPageNode node in nodes )
			{
                if (node != null && node.ContentPage != null)
                {
                    // append li tag
                    HtmlControl li = BuildLITag(node, contentPageID == Config.RootContentPageID);
                    ulParent.Controls.Add(li);

                    if (recursionLevel <= 2)
                    {
                        // load children of this node
                        AddNodes(li, node.ContentPageID);
                    }
                }
			}
		}
		recursionLevel--;
	}

	private HtmlControl BuildLITag(ContentPageNode node, bool isRootNode)
	{
		if ( node == null)
		{
			throw new NullReferenceException();
		} else if (node.ContentPage == null )
		{
			throw new NullReferenceException(string.Format("Node content page is empty on node: {0}", node.LinkText));
		}
		// create new a tag
		HtmlAnchor a = new HtmlAnchor();
		a.HRef = node.LinkPath;
		a.Title = node.LinkText;

		// create new li tag
		HtmlGenericControl li = new HtmlGenericControl("li");
		// add a class and inner span tag if it's a root node
		if ( isRootNode )
		{
			if ( _currentNode != null )
			{
				if ( node.ContentPageID == _currentNode.ContentPageID ||
				node.IsAncestorOf(_currentNode.ContentPageID) )
				{
					li.Attributes.Add("class", "here");
				}
			}
			a.Attributes.Add("class", node.ContentPage.Name.ToLower());
			HtmlGenericControl span = new HtmlGenericControl("span");
			span.InnerText = node.LinkText;
			a.Controls.Add(span);
		}
		else
		{
			a.InnerText = node.LinkText;
		}
		li.Controls.Add(a);
		return li;

	}
}
