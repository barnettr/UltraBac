using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ZNode.Libraries.ECommerce.Business
{
	public static class ContentHelper
	{
		static ContentHelper()
		{
			if (string.Equals(HttpRuntime.AppDomainAppVirtualPath, "/"))
			{
				TildeReplacementString = "=\"";
			}
			else
			{
				TildeReplacementString = string.Format("=\"{0}/", HttpRuntime.AppDomainAppVirtualPath);
			}
		}
		public static readonly string TildeReplacementString;
		public static string ResolveRelativeUrls(string htmlcontent)
		{
			htmlcontent = htmlcontent.Replace("=\"~/", TildeReplacementString);
			htmlcontent = htmlcontent.Replace("=\"%7E/", TildeReplacementString);

			return htmlcontent;
		}
	}
}