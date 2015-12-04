using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OleDb;
using POP.UltraBac;
using System.Web.Caching;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Web.Caching;
using System.Text.RegularExpressions;

public class ResellerDb
{
	private const string ResellerSearchCacheString = "country_{0}";
	private const string ResellerCountryCacheString = "country_cache_region_{0}_sort{1}";
	private const string ResellerRegionCacheString = "region_cache_sort_{0}";
	private const string ResellerCacheString = "ResellerDBCache";
	private const int ResellerCacheMinutes = 60 * 24; // one day
	private DataTable _data = null;
	private string _connectionString;

	public string GetResellerEmail(System.Web.SessionState.HttpSessionState userSession)
	{
		if (userSession[ResellerSessionKey] != null &&
			((bool)userSession[ResellerSessionKey]) == true &&
			!String.IsNullOrEmpty((string)userSession[ResellerEmailKey]))
		{
			return (string)userSession[ResellerEmailKey];
		}
		return null;
	}

	public DataTable Data
	{
		get {
			_data = HttpContext.Current.Cache[ResellerCacheString] as DataTable;
			if ( _data == null )
			{
				_data = GetData();
				HttpContext.Current.Cache.Add(ResellerCacheString, 
					_data,
					new CacheDependency(_filePath), 
					DateTime.Today.AddMinutes(ResellerCacheMinutes), // cache will expire at midnight 
					System.Web.Caching.Cache.NoSlidingExpiration, 
					CacheItemPriority.Normal, null
					);
			}
			return _data;
		}
	}

	private string _filePath;

	public ResellerDb(ConnectionStringSettings connectionString)
	{
		Match match = Regex.Match(connectionString.ConnectionString, "Data Source=\'([^\']*)\'");
		if (match.Success)
		{
			_filePath = match.Groups[1].Value;
		}
		_connectionString = connectionString.ConnectionString;
	}

	private DataTable GetData()
	{
		DataSet ds = null;
		using ( OleDbConnection oleCon = new OleDbConnection(_connectionString) )
		{
			OleDbTransaction objTrans = null;
			ds = OleHelper.ExecuteDataset(oleCon, objTrans, CommandType.Text, "select * from tblDealer");
			oleCon.Close();
			if ( ds.Tables.Count > 0 )
			{
				return ds.Tables[0];
			}
		}
		throw new NullReferenceException("Error loading Reseller database");
	}
	
	public void EnsureResellerLogin(HttpRequest userRequest, HttpResponse userResponse, System.Web.SessionState.HttpSessionState userSession)
	{
		if ((bool?)userSession[ResellerSessionKey] == true)
		{
			return;
		}
		userResponse.Redirect(string.Format("{0}?returnUrl={1}", Config.ResellerLoginUrl, HttpUtility.UrlEncode(userRequest.Url.ToString())));
	}

	private const string ResellerSessionKey = "IsReseller";
	private const string ResellerEmailKey = "ResellerEmail";
	public bool ValidateReseller(string emailAddress, string password, System.Web.SessionState.HttpSessionState userSession)
	{
		if (string.IsNullOrEmpty(emailAddress))
		{
			return false;
		}
		// validate the password. Note that all resellers share a password
		if (string.Compare(password, Config.ResellerPassword) != 0)
		{
			return false;
		}
		DataRow [] results = this.Data.Select(string.Format("DealerEmail = '{0}' or DealerEmail2 = '{0}' or DealerEmail3 = '{0}'", emailAddress));
		if (results != null && results.Length > 0)
		{
			userSession[ResellerEmailKey] = emailAddress;
			userSession[ResellerSessionKey] = true;
			return true;
		}
		return false;
	}

	public List<string> GetRegions()
	{
		return GetRegions(true);
	}

	public List<string> GetRegions(bool sort)
	{
		string cachestring = string.Format(ResellerRegionCacheString, sort);
		List<string> list = HttpContext.Current.Cache[cachestring] as List<string>;
		if (list == null)
		{
			list = DistinctRows("DealerContinent");
			if (sort)
			{
				list.Sort();
			}
			HttpContext.Current.Cache.Insert(cachestring, list, new CacheDependency(_filePath), DateTime.Now.AddMinutes(ResellerCacheMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
		}
		return list;
	}
	
	public List<string> DistinctRows(string column)
	{
		DataTable distinct = Data.DefaultView.ToTable(true, column);
		List<string> list = new List<string>();
		foreach (DataRow row in distinct.Rows)
		{
			list.Add(row[column].ToString());
		}
		return list;
	}

	public List<string> GetCountries(string continent)
	{
		return GetCountries(continent, true);
	}

	public List<string> GetCountries(string continent, bool sort)
	{
		string cachestring = string.Format(ResellerCountryCacheString, continent, sort);
		List<string> list = HttpContext.Current.Cache[cachestring] as List<string>;
		if (list == null)
		{
			list = new List<string>();
			DataRow[] rows = Data.Select(string.Format("DealerContinent = '{0}' and ShowOnSite = 'true'", continent));

			Dictionary<string, bool> found = new Dictionary<string, bool>();

			foreach (DataRow row in rows)
			{
				string country = row["DealerCountry"].ToString();
				if (!found.ContainsKey(country))
				{
					found[country] = true;
					list.Add(country);
				}
			}
			if (sort)
			{
				list.Sort();
			}

			HttpContext.Current.Cache.Insert(cachestring, list, new CacheDependency(_filePath), DateTime.Now.AddMinutes(ResellerCacheMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
		}
		return list;
	}

	public IEnumerable<DataRow> GetResellers(string country)
	{
		string cachestring = string.Format(ResellerSearchCacheString, country);
		DataRow[] rows = HttpContext.Current.Cache[cachestring] as DataRow[];
		if (rows == null)
		{
			rows = Data.Select(string.Format("DealerCountry = '{0}' and ShowOnSite='true'", country), "DealerName");
			HttpContext.Current.Cache.Insert(cachestring, rows, new CacheDependency(_filePath), DateTime.Now.AddMinutes(ResellerCacheMinutes), System.Web.Caching.Cache.NoSlidingExpiration);
		}
		return rows;
	}
}
