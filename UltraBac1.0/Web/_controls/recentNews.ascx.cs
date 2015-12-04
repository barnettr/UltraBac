using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;

public partial class _controls_recentNews : System.Web.UI.UserControl
{
	private int _selectTopN = 1000;

	public int SelectTopN
	{
		get { return _selectTopN; }
		set { _selectTopN = value; }
	}

	private const string CacheString = "recentNews";
	private const int CacheMinutes = 60;
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			List<ContentPageNode> newsList = Cache[CacheString] as List<ContentPageNode>;
			if (newsList == null)
			{
				newsList = new List<ContentPageNode>();
				ContentPageNodeCollection nodes = new ContentPageNodeCollection();
				nodes.LoadChildrenNodes(Config.ProductNewsPageID);
				int i = 0;

				List<ContentPageNode> tempList = new List<ContentPageNode>();
				tempList.AddRange(nodes);
				tempList.Sort(new Comparison<ContentPageNode>(delegate(ContentPageNode left, ContentPageNode right)
				{
					return left.SortIndex.CompareTo(right.SortIndex);
				}));
				foreach (ContentPageNode node in tempList)
				{
					if (i >= SelectTopN)
					{ break; }
					if (!string.IsNullOrEmpty(node.ContentPage.Summary))
					{
						newsList.Add(node);
						i++;
					}
				}
				Cache.Insert(CacheString, newsList, null, DateTime.Now.AddMinutes(CacheMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
			}
						
			uxNews.DataSource = newsList;
			uxNews.DataBind();
		}
	}
}
