﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Tuesday, January 02, 2007
	Important: Do not modify this file. Edit the file SqlPageProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Data.Bases;

#endregion

namespace ZNode.Libraries.DataAccess.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="Page"/> entity.
	///</summary>
	public partial class SqlPageProviderBase : PageProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlPageProviderBase"/> instance.
		/// </summary>
		public SqlPageProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlPageProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlPageProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
	
		#region Get Many To Many Relationship Functions
		#endregion
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="pageID">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 pageID)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@PageID", DbType.Int32, pageID);
			
			int results = 0;
			
			if (transactionManager != null)
			{	
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(Page)
					,pageID);
				EntityManager.StopTracking(entityKey);
			}
			
			if (results == 0)
			{
				//throw new DataException("The record has been already deleted.");
				return false;
			}
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions

		#region Parsed Find Methods
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public override ZNode.Libraries.DataAccess.Entities.TList<Page> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new ZNode.Libraries.DataAccess.Entities.TList<Page>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@PageID", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@PortalID", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Title", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@SEOTitle", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@SEOMetaKeywords", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@SEOMetaDescription", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@AllowDelete", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@TemplateName", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ActiveInd", DbType.Boolean, DBNull.Value);
	
			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace(" AND ", "|").Replace(" OR ", "|") ; 
			string[] clauses = whereClause.ToLower().Split('|');
		
			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"
				
			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("pageid ") || clause.Trim().StartsWith("pageid="))
				{
					database.SetParameterValue(commandWrapper, "@PageID", 
						clause.Replace("pageid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("name ") || clause.Trim().StartsWith("name="))
				{
					database.SetParameterValue(commandWrapper, "@Name", 
						clause.Replace("name","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("portalid ") || clause.Trim().StartsWith("portalid="))
				{
					database.SetParameterValue(commandWrapper, "@PortalID", 
						clause.Replace("portalid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("title ") || clause.Trim().StartsWith("title="))
				{
					database.SetParameterValue(commandWrapper, "@Title", 
						clause.Replace("title","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("seotitle ") || clause.Trim().StartsWith("seotitle="))
				{
					database.SetParameterValue(commandWrapper, "@SEOTitle", 
						clause.Replace("seotitle","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("seometakeywords ") || clause.Trim().StartsWith("seometakeywords="))
				{
					database.SetParameterValue(commandWrapper, "@SEOMetaKeywords", 
						clause.Replace("seometakeywords","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("seometadescription ") || clause.Trim().StartsWith("seometadescription="))
				{
					database.SetParameterValue(commandWrapper, "@SEOMetaDescription", 
						clause.Replace("seometadescription","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("allowdelete ") || clause.Trim().StartsWith("allowdelete="))
				{
					database.SetParameterValue(commandWrapper, "@AllowDelete", 
						clause.Replace("allowdelete","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("templatename ") || clause.Trim().StartsWith("templatename="))
				{
					database.SetParameterValue(commandWrapper, "@TemplateName", 
						clause.Replace("templatename","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("activeind ") || clause.Trim().StartsWith("activeind="))
				{
					database.SetParameterValue(commandWrapper, "@ActiveInd", 
						clause.Replace("activeind","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			ZNode.Libraries.DataAccess.Entities.TList<Page> rows = new ZNode.Libraries.DataAccess.Entities.TList<Page>();
	
				
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
				
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if (reader != null) 
					reader.Close();				
			}
			return rows;
		}

		#endregion Parsed Find Methods
		
		#region Parameterized Find Methods
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public override ZNode.Libraries.DataAccess.Entities.TList<Page> Find(TransactionManager transactionManager, SqlFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_Find_Dynamic", typeof(PageColumn), parameters, orderBy, start, pageLength);
			
			if ( parameters != null )
			{
				SqlFilterParameter param;

				for ( int i = 0; i < parameters.Count; i++ )
				{
					param = parameters[i];
					database.AddInParameter(commandWrapper, param.Name, param.DbType, param.Value);
				}
			}

			ZNode.Libraries.DataAccess.Entities.TList<Page> rows = new ZNode.Libraries.DataAccess.Entities.TList<Page>();
			IDataReader reader = null;
			
			try
			{
				if ( transactionManager != null )
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;
				
				if ( reader.NextResult() )
				{
					if ( reader.Read() )
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if ( reader != null )
					reader.Close();
			}
			
			return rows;
		}
		
		#endregion Parameterized Find Methods
		
		#endregion Find Functions
	
		#region GetAll Methods
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ZNode.Libraries.DataAccess.Entities.TList<Page> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			ZNode.Libraries.DataAccess.Entities.TList<Page> rows = new ZNode.Libraries.DataAccess.Entities.TList<Page>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}//end getall
		
		#endregion
				
		#region GetPaged Methods
				
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public override ZNode.Libraries.DataAccess.Entities.TList<Page> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_GetPaged", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			ZNode.Libraries.DataAccess.Entities.TList<Page> rows = new ZNode.Libraries.DataAccess.Entities.TList<Page>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			
			return rows;
		}
		
		#endregion	
		
		#region Get By Foreign Key Functions

		#region GetByPortalID
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		FK_ZNodePage_ZNodePortal Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ZNode.Libraries.DataAccess.Entities.TList<Page> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_GetByPortalID", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@PortalID", DbType.Int32, portalID);
			
			IDataReader reader = null;
			ZNode.Libraries.DataAccess.Entities.TList<Page> rows = new ZNode.Libraries.DataAccess.Entities.TList<Page>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
			
				//Create Collection
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}	
		#endregion
	
	#endregion
	
		#region Get By Index Functions

		#region GetByPageID
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="pageID"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ZNode.Libraries.DataAccess.Entities.Page GetByPageID(TransactionManager transactionManager, System.Int32 pageID, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_GetByPageID", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@PageID", DbType.Int32, pageID);
			
			IDataReader reader = null;
			ZNode.Libraries.DataAccess.Entities.TList<Page> tmp = new ZNode.Libraries.DataAccess.Entities.TList<Page>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion


		#region GetByName
					
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ZNodePage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ZNode.Libraries.DataAccess.Entities.Page GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_GetByName", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, name);
			
			IDataReader reader = null;
			ZNode.Libraries.DataAccess.Entities.TList<Page> tmp = new ZNode.Libraries.DataAccess.Entities.TList<Page>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion

	#endregion Get By Index Functions

		#region Insert Methods
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the ZNode.Libraries.DataAccess.Entities.Page object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<ZNode.Libraries.DataAccess.Entities.Page> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			
			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;
	
			if (transactionManager != null && transactionManager.IsOpen)
			{			
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}
			
			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "ZNodePage";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("PageID", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("Name", typeof(System.String));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("PortalID", typeof(System.Int32));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("Title", typeof(System.String));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("SEOTitle", typeof(System.String));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("SEOMetaKeywords", typeof(System.String));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("SEOMetaDescription", typeof(System.String));
			col6.AllowDBNull = true;		
			DataColumn col7 = dataTable.Columns.Add("AllowDelete", typeof(System.Boolean));
			col7.AllowDBNull = false;		
			DataColumn col8 = dataTable.Columns.Add("TemplateName", typeof(System.String));
			col8.AllowDBNull = false;		
			DataColumn col9 = dataTable.Columns.Add("ActiveInd", typeof(System.Boolean));
			col9.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("PageID", "PageID");
			bulkCopy.ColumnMappings.Add("Name", "Name");
			bulkCopy.ColumnMappings.Add("PortalID", "PortalID");
			bulkCopy.ColumnMappings.Add("Title", "Title");
			bulkCopy.ColumnMappings.Add("SEOTitle", "SEOTitle");
			bulkCopy.ColumnMappings.Add("SEOMetaKeywords", "SEOMetaKeywords");
			bulkCopy.ColumnMappings.Add("SEOMetaDescription", "SEOMetaDescription");
			bulkCopy.ColumnMappings.Add("AllowDelete", "AllowDelete");
			bulkCopy.ColumnMappings.Add("TemplateName", "TemplateName");
			bulkCopy.ColumnMappings.Add("ActiveInd", "ActiveInd");
			
			foreach(ZNode.Libraries.DataAccess.Entities.Page entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["PageID"] = entity.PageID;
							
				
					row["Name"] = entity.Name;
							
				
					row["PortalID"] = entity.PortalID;
							
				
					row["Title"] = entity.Title;
							
				
					row["SEOTitle"] = entity.SEOTitle;
							
				
					row["SEOMetaKeywords"] = entity.SEOMetaKeywords;
							
				
					row["SEOMetaDescription"] = entity.SEOMetaDescription;
							
				
					row["AllowDelete"] = entity.AllowDelete;
							
				
					row["TemplateName"] = entity.TemplateName;
							
				
					row["ActiveInd"] = entity.ActiveInd;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(ZNode.Libraries.DataAccess.Entities.Page entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a ZNode.Libraries.DataAccess.Entities.Page object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Page object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the ZNode.Libraries.DataAccess.Entities.Page object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Page entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@PageID", DbType.Int32, 4);
			database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, entity.Name );
			database.AddInParameter(commandWrapper, "@PortalID", DbType.Int32, entity.PortalID );
			database.AddInParameter(commandWrapper, "@Title", DbType.String, entity.Title );
			database.AddInParameter(commandWrapper, "@SEOTitle", DbType.String, entity.SEOTitle );
			database.AddInParameter(commandWrapper, "@SEOMetaKeywords", DbType.String, entity.SEOMetaKeywords );
			database.AddInParameter(commandWrapper, "@SEOMetaDescription", DbType.String, entity.SEOMetaDescription );
			database.AddInParameter(commandWrapper, "@AllowDelete", DbType.Boolean, entity.AllowDelete );
			database.AddInParameter(commandWrapper, "@TemplateName", DbType.String, entity.TemplateName );
			database.AddInParameter(commandWrapper, "@ActiveInd", DbType.Boolean, entity.ActiveInd );
			
			int results = 0;
			
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					

			entity.PageID = (System.Int32) database.GetParameterValue(commandWrapper, "@PageID");						
			
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Methods
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Page object to update.</param>
		/// <remarks>
		///		After updating the datasource, the ZNode.Libraries.DataAccess.Entities.Page object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Page entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodePage_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@PageID", DbType.Int32, entity.PageID );
			database.AddInParameter(commandWrapper, "@Name", DbType.AnsiString, entity.Name );
			database.AddInParameter(commandWrapper, "@PortalID", DbType.Int32, entity.PortalID );
			database.AddInParameter(commandWrapper, "@Title", DbType.String, entity.Title );
			database.AddInParameter(commandWrapper, "@SEOTitle", DbType.String, entity.SEOTitle );
			database.AddInParameter(commandWrapper, "@SEOMetaKeywords", DbType.String, entity.SEOMetaKeywords );
			database.AddInParameter(commandWrapper, "@SEOMetaDescription", DbType.String, entity.SEOMetaDescription );
			database.AddInParameter(commandWrapper, "@AllowDelete", DbType.Boolean, entity.AllowDelete );
			database.AddInParameter(commandWrapper, "@TemplateName", DbType.String, entity.TemplateName );
			database.AddInParameter(commandWrapper, "@ActiveInd", DbType.Boolean, entity.ActiveInd );
			
			int results = 0;
			
			
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
				EntityManager.StopTracking(entity.EntityTrackingKey);
			
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region Custom Methods
	
		#endregion
	}//end class
} // end namespace