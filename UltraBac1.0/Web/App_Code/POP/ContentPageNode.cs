using System.Data;
using System.Data.SqlClient;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using ZNode.Libraries.DataAccess.Entities;

namespace POP.UltraBac
{

	/// <summary>
	/// Represents a content page node object within the content tree
	/// </summary>
	public class ContentPageNode
	{

		private ContentPage _contentPage = new ContentPage();
		private int _parentContentPageID = -1;		// -1 is effectively an orphaned page
		private int _sortIndex = 1;
		private string _linkText = string.Empty;
		private string _linkPath = string.Empty;
		private bool _isLocked = false;
		private bool _canHaveChildren = true;
		private ContentPageNodeCollection _childPages;

		/// <summary>
		/// Gets the ContentPage corresponding to the ContentPageNode
		/// </summary>
		public ContentPage ContentPage
		{
			get { return _contentPage; }
		}

		/// <summary>
		/// Gets the primary key of the ContentPageNode and its corresponding ContentPage
		/// </summary>
		public int ContentPageID
		{
			get
            {
                if (_contentPage != null)
                {
                    return _contentPage.ContentPageID;
                }
                return -1;
            }
		}

		/// <summary>
		/// Gets or sets the ContentPageNode's parent ContentPageNode and ContentPage
		/// </summary>
		public int ParentContentPageID
		{
			get { return _parentContentPageID; }
			set { _parentContentPageID = value; }
		}

		/// <summary>
		/// Gets or sets the sort position of the ContentPageNode within its parent node
		/// </summary>
		public int SortIndex
		{
			get { return _sortIndex; }
			set { _sortIndex = value; }
		}

		/// <summary>
		/// Gets the link text of the ContentPageNode or the ContentPage title if no link text is found. Sets the link text of the ContentPageNode
		/// </summary>
		public string LinkText
		{
			get
			{
				if ( _linkText == string.Empty && _contentPage != null )
				{
					return _contentPage.Title;
				}
				else
				{
					return _linkText;
				}
			}
			set { _linkText = value; }
		}

		/// <summary>
		/// Gets the path to the content page or string.empty if no page is found
		/// </summary>
		public string LinkPath
		{
			get
			{
				if (_linkPath == string.Empty && _contentPage != null)
				{
					_linkPath = string.Format(Config.ContentPageFormat, _contentPage.Name);
					return _linkPath;
				}
				else
				{
					return _linkPath;
				}
			}
			set { _linkPath = value; }
		}

		/// <summary>
		/// Gets whether the ContentPageNode attributes can be modified
		/// </summary>
		public bool IsLocked
		{
			get { return _isLocked; }
		}

		/// <summary>
		/// Gets whether the ContentPageNode can have child nodes
		/// </summary>
		public bool CanHaveChildren
		{
			get { return _canHaveChildren; }
		}

		/// <summary>
		/// Gets a ContentPageNodeCollection of the ContentPageNode's immediate child nodes
		/// </summary>
		public ContentPageNodeCollection ChildPageNodes
		{
			get
			{
				if ( _childPages == null )
				{
					_childPages = new ContentPageNodeCollection();
                    if (_contentPage != null)
                    {
                        _childPages.LoadChildrenNodes(_contentPage.ContentPageID);
                    }
				}
				return _childPages;
			}
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public ContentPageNode()
		{
		}

		/// <summary>
		/// Constructs a loaded object instance
		/// </summary>
		/// <param name="contentPageID">Primary key of the ContentPageNode to load</param>
		public ContentPageNode(int contentPageID)
		{
			// get the corresponding ContentPage entity
			ContentPageAdmin pageAdmin = new ContentPageAdmin();
			_contentPage = pageAdmin.GetPageByID(contentPageID);

			if (_contentPage == null)
			{
				throw new System.Exception("Could not load contentPageId = " + contentPageID);
			}
			// load the ContentPageNode attributes
			LoadContentPageTreeNode();
		}

		/// <summary>
		/// Determines whether the current content page node instance is an ancestor of a specified node
		/// </summary>
		/// <param name="descendantID">ID of the possible descendant</param>
		/// <returns>boolean</returns>
		public bool IsAncestorOf(int descendantID)
		{
			bool retVal = false;
			foreach ( ContentPageNode child in ChildPageNodes )
			{
                if (child != null)
                {
                    if (child.ContentPageID == descendantID)
                    {
                        retVal = true;
                        break;
                    }
                    retVal = child.IsAncestorOf(descendantID);
                }
			}
			return retVal;
		}

		#region Database IO

		private void LoadContentPageTreeNode()
		{
			DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_ContentPageNode_Get",
				new SqlParameter("@contentpageid", ContentPageID));

			if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
			{
				DataRow dr = ds.Tables[0].Rows[0];

				_parentContentPageID = (int)dr["parentcontentpageid"];
				_sortIndex = (int)dr["sortindex"];
				_linkText = dr["linktext"].ToString();
				_isLocked = (bool)dr["islocked"];
				_canHaveChildren = (bool)dr["canhavechildren"];
			}
		}

		/// <summary>
		/// Inserts the ContentPageNode into the POPContentPageNode table
		/// </summary>
		/// <param name="contentPageID">Primary key of corresponding ContentPage entity</param>
		public void Insert(int contentPageID)
		{
			ConnectionHelper.ZNodeConnection.ExecuteScalar("POP_ContentPageNode_Insert",
				new SqlParameter("@contentpageid", contentPageID),
				new SqlParameter("@parentcontentpageid", _parentContentPageID),
				new SqlParameter("@sortindex", _sortIndex),
				new SqlParameter("@linktext", LinkText));

		}

		/// <summary>
		/// Updates a the ContentPageNode in the POPContentPageNode table
		/// </summary>
		public void Update()
		{
			ConnectionHelper.ZNodeConnection.ExecuteScalar("POP_ContentPageNode_Update",
							new SqlParameter("@contentpageid", ContentPageID),
							new SqlParameter("@parentcontentpageid", _parentContentPageID),
							new SqlParameter("@sortindex", _sortIndex),
							new SqlParameter("@linktext", LinkText));
		}

		/// <summary>
		/// Permanently deletes a ContentPageNode object from the POPContentPageNode table
		/// </summary>
		/// <param name="contentPageID">Primary key of ContentPageNode to delete</param>
		public static void Delete(int contentPageID)
		{
			ConnectionHelper.ZNodeConnection.ExecuteScalar("POP_ContentPageNode_Delete",
								new SqlParameter("@contentpageid", contentPageID));
		}

		#endregion Database IO
		public override string ToString()
		{
			return string.Format("{0}: {1}", _contentPage.ContentPageID, _contentPage.Name);
		}
	}

}
