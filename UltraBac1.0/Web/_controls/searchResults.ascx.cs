using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using POP.UltraBac;

public partial class _controls_searchResults : System.Web.UI.UserControl
{
	private const string CacheSearchFormatSring = "search_{0}_pg_{1}_rpp_{2}";
	private const string TotalResultsCacheString = "search_{0}";
	private const int CacheMinutes = 15;
	private const int ResultsPerPage = 10;
	private string _encodedSearchTerm;
	private DataTable _dataTable;
	private int _page;
	private int _firstSearchPage = 1;
	private int _lastSearchPage;
	private int? _totalSearchResults;

	public string TotalSearchResults { get { return _totalSearchResults.HasValue ? _totalSearchResults.ToString() : "0"; } }


	protected void Page_Load(object sender, EventArgs e)
	{
		// this !IsPostBack logic works because any new search will cause
		// a response.redirect instead of traditional postback logic
		if (!IsPostBack)
		{
			if (Request.Params["q"] == null)
			{
				lblError.Text = "No search term was found. Please try your search again.";
				lblError.Visible = true;
			}
			else
			{
				_encodedSearchTerm = Request.Params["q"];
				_page = GetPageFromQueryString();

				try
				{
					BindResults();					
				}
				catch
				{
					uxSearchError.Visible = true;
					uxNoResults.Visible = false;
				}
			}
		}
	}

	public IEnumerable<DataRow> PageResults
	{
		get
		{
			int startDataRow = 0;
			int lastDataRow = Math.Min(ResultsPerPage, _dataTable.Rows.Count - 1);

			for (int i = startDataRow; i <= lastDataRow; i++)
			{
				yield return _dataTable.Rows[i];
			}
			yield break;
		}
	}

	public IEnumerable<int> SearchPages
	{
		get
		{
			int firstpage = _page < 10 ? _firstSearchPage : Math.Max(_page - 5, _firstSearchPage);
			int lastpage = _page < 10 ? Math.Min(10, _lastSearchPage) : Math.Min(_page + 5, _lastSearchPage);

			for (int i = firstpage; i <= lastpage; i++)
			{
				yield return i;
			}
			yield break;
		}
	}

	private int GetPageFromQueryString()
	{
		int page = 1;
		string pagenum = Request.Params["p"];
		if (!string.IsNullOrEmpty(pagenum))
		{
			int.TryParse(pagenum, out page);
			if (page < 1)
			{
				page = 1;
			}
		}
		return page;
	}

	private static int GetTotalPages(int totalresults, int resultsPerPage)
	{
		System.Diagnostics.Debug.Assert(totalresults > 0 && resultsPerPage > 0);
		return (totalresults - 1) / resultsPerPage + 1;
	}

	private void BindResults()
	{
		// attempt to get data from cache
		string cacheString = string.Format(CacheSearchFormatSring, _encodedSearchTerm, _page, ResultsPerPage);
		string totalResultsCacheString = string.Format(TotalResultsCacheString, _encodedSearchTerm);		
		_dataTable = Cache[cacheString] as DataTable;
		_totalSearchResults = (int?)Cache[totalResultsCacheString];
		
		if (_dataTable == null)
		{
			DataSet ds = SearchHelper.GetSearchData(_encodedSearchTerm, (_page - 1) * ResultsPerPage, ResultsPerPage);
			
			// get the results from the dataset
			_dataTable = ds.Tables["R"];

			// now get the total number of matches, since the are a subset
			DataTable dtr = ds.Tables["RES"];
			if ( dtr != null && dtr.Rows.Count > 0 && dtr.Rows[0]["M"] != null )
			{
				_totalSearchResults = int.Parse(dtr.Rows[0]["M"].ToString());
				Cache.Insert(totalResultsCacheString, _totalSearchResults);
			}
			else
			{
				_totalSearchResults = 0;
			}
			
			// don't cache an empty result set
			if (_dataTable != null && _dataTable.Rows.Count > 0)
			{
				Cache.Insert(cacheString, _dataTable, null, DateTime.Now.AddMinutes(CacheMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
			}
		}

		System.Diagnostics.Debug.Assert(_totalSearchResults.HasValue, "Could not get result count from cache");
		
		if (_dataTable != null && _totalSearchResults.Value > 0)
		{
			repSearchResults.DataSource = PageResults;
			repSearchResults.DataBind();

			_lastSearchPage = GetTotalPages(_totalSearchResults.Value, ResultsPerPage);
			if (_lastSearchPage > 1)
			{
				uxPages.DataSource = SearchPages;
				uxPages.DataBind();
			}
			else
			{
				uxPages.Visible = false;
			}
		}
		else
		{
			uxNoResults.Visible = true;
		}

		lblSearchTerm.Text = string.Format("Search results for <strong>{0}</strong>", Server.UrlDecode(_encodedSearchTerm));
	}

	protected void repSearchResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.AlternatingItem ||
			e.Item.ItemType == ListItemType.Item)
		{
			DataRow row = e.Item.DataItem as DataRow;
			ITextControl text = e.Item.FindControl("uxSearchText") as ITextControl;
			HtmlAnchor link = e.Item.FindControl("uxSearchLink") as HtmlAnchor;

			link.HRef = row["U"].ToString();
			link.InnerHtml = row["T"].ToString();
			text.Text = row["S"].ToString();
		}
	}

	protected void uxPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item ||
			e.Item.ItemType == ListItemType.AlternatingItem)
		{
			if (e.Item.ItemIndex == 0)
			{
				HtmlGenericControl li = e.Item.FindControl("li") as HtmlGenericControl;
				li.Attributes.Add("class", "first");
			}

			int pg = (int)e.Item.DataItem;
			PlaceHolder ph = e.Item.FindControl("pageContents") as PlaceHolder;
			if (ph != null)
			{
				if (pg == _page)
				{
					Literal lt = new Literal();
					lt.Text = pg.ToString();
					ph.Controls.Add(lt);
				}
				else
				{
					HtmlAnchor a = new HtmlAnchor();
					a.HRef = string.Format("~/search.aspx?q={0}&p={1}", _encodedSearchTerm, pg);
					a.InnerHtml = pg.ToString();
					ph.Controls.Add(a);
				}
			}
		}
	}
}