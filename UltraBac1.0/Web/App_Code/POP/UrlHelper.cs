using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for UrlHelper
/// </summary>

public static class UrlHelper
{
	public static string GetFullUrl(string relativepath)
	{
		string domainAndPath = string.Format("http://{0}{1}", HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.ApplicationPath);
		bool domainEndsWithSlash = domainAndPath.EndsWith("/");
		bool relativeStartsWithSlash = relativepath.StartsWith("/");
		if (
			(domainEndsWithSlash && !relativeStartsWithSlash) ||
			(!domainEndsWithSlash && relativeStartsWithSlash)
			)
		{
			return domainAndPath + relativepath;
		}
		else if (domainEndsWithSlash && relativeStartsWithSlash)
		{
			return domainAndPath + relativepath.Substring(1);
		}
		else
		{
			return string.Concat(domainAndPath, "/", relativeStartsWithSlash);
		}
		System.Diagnostics.Debug.Assert(false, "This shouldn't happen");
	}
}