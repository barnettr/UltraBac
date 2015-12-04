using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using System.IO;
using System.Web;

namespace ZNode.Libraries.Admin
{    
    /// <summary>
    /// Provides methods to manage pages and revisions
    /// </summary>
    public class ContentPageAdmin:ZNodeBusinessBase 
    {

			private Exception _lastError;
			public Exception LastError { get { return _lastError; } }
        /// <summary>
        /// Adds a new page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
			public bool AddPage(ContentPage page, string html, string updateUser)
			{
				TransactionManager tranManager = null;
				tranManager = ConnectionScope.CreateTransaction();

				try
				{
					ContentPageService serv = new ContentPageService();
					bool retval = serv.Insert(page);
					if (!retval) { throw (new ApplicationException()); }

					//Add HTML update code here
					UpdateHtmlFile(page.Name, html, null);

					//Add Revision update code here
					retval = AddPageRevision(page, html, updateUser, "Added Page");
					if (!retval) { throw (new ApplicationException()); }

					//commit transaction
					tranManager.Commit();

					return true;
				}
				catch (Exception ex)
				{
					tranManager.Rollback();
					_lastError = ex;
					return false;
				}
			}

        /// <summary>
        /// Updates a page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public bool UpdatePage(ContentPage page, string html, string oldPageName, string updateUser)
        {
            TransactionManager tranManager = null;
            tranManager = ConnectionScope.CreateTransaction();

            try
            {
                ContentPageService serv = new ContentPageService();
                bool retval = serv.Update(page);
                if (!retval) { throw (new ApplicationException()); }

                //Add HTML update code here
								UpdateHtmlFile(page.Name, html, oldPageName);

                //Add Revision update code here
                retval = AddPageRevision(page, html, updateUser, "Edited Page");
                if (!retval) { throw (new ApplicationException()); }

                //commit transaction
                tranManager.Commit();

                return true;
            }
            catch (Exception ex)
            {
                tranManager.Rollback();
								_lastError = ex;
                return false;
            }          
        }

        /// <summary>
        /// Creates, updates, and renames an HTML file
        /// </summary>
        /// <param name="pageName">Page name to be written to disk</param>				
        /// <param name="htmlText">Html content of the page</param>
				/// <param name="oldName">If specified, the page is being renamed, and the oldName on disk file will be deleted.</param>
        private void UpdateHtmlFile(string pageName, string html, string oldName)
        {
            string filePath = string.Format("{0}{1}.htm", ZNodeConfigManager.EnvironmentConfig.ContentPath, pageName);						
            TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath(filePath));

            try
            {
                tw.Write(html);
                tw.Close();
								if (!string.IsNullOrEmpty(oldName) &&
									!string.Equals(pageName, oldName, StringComparison.InvariantCultureIgnoreCase))
								{
									DeletePage(oldName);
								}
            }
            catch
            {
                if (tw != null)
                {
                    tw.Close();
                }

                throw; //rethrow exception
            }
        }

        /// <summary>
        /// Returns a list of all the pages
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public TList<ContentPage> GetPages(int portalID)
        {
            ContentPageService serv = new ContentPageService();
            return serv.GetByPortalID(portalID);
        }

        /// <summary>
        /// Returns a page by ID
        /// </summary>
        /// <param name="pageID"></param>
        /// <returns></returns>
        public ContentPage GetPageByID(int contentPageID)
        {
            ContentPageService serv = new ContentPageService();
            return serv.GetByContentPageID(contentPageID);
        }

        /// <summary>
        /// Check if a page name is available
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsNameAvailable(string name)
        {
            ContentPageService serv = new ContentPageService();
            if (serv.GetByName(name) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the HTML content of a page
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public string GetPageHTMLByName(string pageName)
        {
            string filePath = ZNodeConfigManager.EnvironmentConfig.ContentPath + pageName + ".htm";
            TextReader tr = new StreamReader(HttpContext.Current.Server.MapPath(filePath));

            try
            {
                string html = tr.ReadToEnd();
                tr.Close();

                return html;
            }
            catch (Exception ex)
            {
							_lastError = ex;
                if (tr != null)
                {
                    tr.Close();
                }

                return "";
            }
        }

        /// <summary>
        /// Adds a new revision
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private bool AddPageRevision(ContentPage page, string html, string updateUser, string description)
        {
            ContentPageRevisionService serv = new ContentPageRevisionService();
            ContentPageRevision pageRevision = new ContentPageRevision();

            pageRevision.HtmlText = html;
            pageRevision.UpdateDate = System.DateTime.Now;
            pageRevision.UpdateUser = updateUser;
            pageRevision.ContentPageID = page.ContentPageID;
            pageRevision.Description = description;

            return serv.Insert(pageRevision);
        }

        /// <summary>
        /// Get page revisions
        /// </summary>
        /// <param name="pageID"></param>
        /// <returns></returns>
        public TList<ContentPageRevision> GetPageRevisions(int contentPageID)
        {
            ContentPageRevisionService serv = new ContentPageRevisionService();
            return serv.GetByContentPageID(contentPageID);
        }


        /// <summary>
        /// Sets a page status to published
        /// </summary>
        /// <param name="contentPage"></param>
        public void PublishPage(ContentPage contentPage)
        {
            ContentPageService serv = new ContentPageService();

            if (!contentPage.ActiveInd)
            {
                contentPage.ActiveInd = true;
                serv.Update(contentPage);
            }

            return;
        }

        /// <summary>
        /// Delete a page
        /// </summary>
        /// <param name="contentPage"></param>
        public bool DeletePage(ContentPage contentPage)
        {
            TransactionManager tranManager = null;
            tranManager = ConnectionScope.CreateTransaction();

            try
            {
                bool retval = false;

                ContentPageRevisionService revserv = new ContentPageRevisionService();
                ContentPageService pageserv = new ContentPageService();

                //delete revisions
                TList<ContentPageRevision> pageRevisionList = revserv.GetByContentPageID(contentPage.ContentPageID);
                revserv.Delete(pageRevisionList);

                retval = pageserv.Delete(contentPage);
                if (!retval) { return false; }

                //delete html
                DeletePage(contentPage.Name);

                tranManager.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tranManager.Rollback();
								_lastError = ex;
                return false;
            }  
        }


        private void DeletePage(string pageName)
        {
            string filePath = ZNodeConfigManager.EnvironmentConfig.ContentPath + pageName + ".htm";
            File.Delete(HttpContext.Current.Server.MapPath(filePath));
        }

        /// <summary>
        /// Reverts a page to a particular revision
        /// </summary>
        /// <param name="pageRevisionID"></param>
        /// <returns></returns>
        public bool RevertToRevision(int pageRevisionID, string updateUser)
        {
            //get revision
            ContentPageRevisionService serv = new ContentPageRevisionService();
            ContentPageRevision pageRevision = serv.GetByRevisionID(pageRevisionID);

            //get page
            ContentPage page = GetPageByID(pageRevision.ContentPageID);

            //revert html to this revision
            bool retval = UpdatePage(page, pageRevision.HtmlText, null, updateUser);

            return retval;
        }

    }
}
