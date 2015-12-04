using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using System.IO;
using System.Web;

namespace ZNode.Libraries.ECommerce.Business
{
    public class ZNodeContentManager : ZNodeBusinessBase
    {

			public static readonly string TildeReplacementString = string.Format("=\"{0}/", HttpRuntime.AppDomainAppVirtualPath);
        /// <summary>
        /// Returns the HTML content of a page
        /// </summary>
        /// <param name="pageName"></param>
				/// <param name="attempResolveUrl">If true, this attempts to convert all instances of &lt;a href="~/ ... /&gt; to &lt;a href="ApplicationPath/... /&gt;</param>
        /// <returns></returns>
			public static string GetPageHTMLByName(string pageName, bool attempResolveUrl)
			{
				TextReader tr = null;
				try
				{
					string filePath = ZNodeConfigManager.EnvironmentConfig.ContentPath + pageName + ".htm";
					tr = new StreamReader(HttpContext.Current.Server.MapPath(filePath));
					string html = tr.ReadToEnd();
					tr.Close();

					if (attempResolveUrl && !string.IsNullOrEmpty(html))
					{
						html = ContentHelper.ResolveRelativeUrls(html);
					}

					return html;
				}
				catch (FileNotFoundException)
				{
					if (tr != null)
					{
						tr.Close();
					}
					throw;
				}
				catch
				{
					if (tr != null)
					{
						tr.Close();
					}

					return "";
				}
			}

        /// <summary>
        /// Returns the HTML content of a page
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
				public static string GetPageHTMLByName(string pageName)
				{
					return GetPageHTMLByName(pageName, false);
				}

        /// <summary>
        /// Returns a content managed page by Name
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>      
        public static ContentPage GetPageByName(string pageName)
        {
            ContentPageService serv = new ContentPageService();
            return serv.GetByName(pageName);
        }
    }
}
