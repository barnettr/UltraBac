using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using POP.UltraBac;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;

/// <summary>
/// Summary description for SearchHelper
/// </summary>
public static class SearchHelper
{
	public static DataSet GetSearchData(string encodedSearchString, int startResult, int numberOfResults)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append("http://www.google.com/search?");
		sb.Append("client=google-csbe&");
		sb.Append("output=xml_no_dtd&");
		sb.AppendFormat("q={0}&", encodedSearchString);
		sb.AppendFormat("cx={0}&", Config.GoogleCSEAccountID);
		sb.AppendFormat("start={0}&", startResult);
		sb.AppendFormat("num={0}", numberOfResults);

		WebRequest request = HttpWebRequest.Create(sb.ToString());
		request.Timeout = 10000;
		request.Method = "GET";

		WebResponse response = request.GetResponse();
		Stream stream = response.GetResponseStream();
		XmlTextReader xReader = new XmlTextReader(stream);

		DataSet ds = new DataSet();
		ds.ReadXml(xReader);
		return ds;
	}
}
