using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ZNode.Libraries.DataAccess.Data.SqlClient;

namespace POP.UltraBac
{

	/// <summary>
	/// Represents an enumerable collection of ContentPageNode objects
	/// </summary>
	public class ContentPageNodeCollection : IEnumerable<ContentPageNode>
	{

		private List<ContentPageNode> _nodes = new List<ContentPageNode>() ;
		private int _count = 0;

		/// <summary>
		/// Count of objects in the collection
		/// </summary>
		public int Count
		{
			get { return _nodes.Count; }
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public ContentPageNodeCollection()
		{
		}

		/// <summary>
		/// Loads the immediate children of a parent node into the collection
		/// </summary>
		/// <param name="parentID">ContentPageID of the parent ContentPageNode or ContentPage</param>
		public void LoadChildrenNodes(int parentID)
		{
			try
			{
				DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_ContentPageNode_GetChildrenIDs",
						new SqlParameter("@contentpageid", parentID));
				
				if ( ds.Tables[0].Rows.Count > 0 )
				{
					for ( int i = 0; i < ds.Tables[0].Rows.Count; i++ )
					{
						int childID = (int)ds.Tables[0].Rows[i]["contentpageid"];
						ContentPageNode page = new ContentPageNode(childID);
                        if (page != null)
                        {
                            this.Add(page);
                        }
					}
				}
			}
			catch
			{
			}
		}

		public IEnumerator<ContentPageNode> GetEnumerator()
		{
			foreach ( ContentPageNode node in _nodes )
			{
				yield return node;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Adds a ContentPageNode object to the collection
		/// </summary>
		/// <param name="node">ContentPageNode object to add to the collection</param>
		public void Add(ContentPageNode node)
		{
			_nodes.Add(node);
		}

		/// <summary>
		/// Gets or Sets a ContentPageNode object at the specified position
		/// </summary>
		/// <param name="index">Specifies the collection position</param>
		/// <returns>ContentPageNode object</returns>
		public ContentPageNode this[int index]
		{
			get
			{
				if ( index < 0 || index >= _nodes.Count )
				{
					return null;
				}
				return _nodes[index];
			}
			set
			{
				_nodes[index] = value;
			}
		}

	}

}
