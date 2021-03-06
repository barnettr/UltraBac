﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Thursday, October 18, 2007
	Important: Do not modify this file. Edit the file SqlAddOnValueProvider.cs instead.
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
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="AddOnValue"/> entity.
	///</summary>
	public partial class SqlAddOnValueProviderBase : AddOnValueProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlAddOnValueProviderBase"/> instance.
		/// </summary>
		public SqlAddOnValueProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlAddOnValueProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlAddOnValueProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
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
		/// <param name="addOnValueID">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int32 addOnValueID)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@AddOnValueID", DbType.Int32, addOnValueID);
			
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
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(AddOnValue)
					,addOnValueID);
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public override ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new ZNode.Libraries.DataAccess.Entities.TList<AddOnValue>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@AddOnValueID", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@AddOnID", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Name", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Description", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@SKU", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@QuantityOnHand", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@DefaultInd", DbType.Boolean, DBNull.Value);
		database.AddInParameter(commandWrapper, "@DisplayOrder", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ImageFile", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Price", DbType.Decimal, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Weight", DbType.Decimal, DBNull.Value);
	
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
				if (clause.Trim().StartsWith("addonvalueid ") || clause.Trim().StartsWith("addonvalueid="))
				{
					database.SetParameterValue(commandWrapper, "@AddOnValueID", 
						clause.Replace("addonvalueid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("addonid ") || clause.Trim().StartsWith("addonid="))
				{
					database.SetParameterValue(commandWrapper, "@AddOnID", 
						clause.Replace("addonid","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("name ") || clause.Trim().StartsWith("name="))
				{
					database.SetParameterValue(commandWrapper, "@Name", 
						clause.Replace("name","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("description ") || clause.Trim().StartsWith("description="))
				{
					database.SetParameterValue(commandWrapper, "@Description", 
						clause.Replace("description","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("sku ") || clause.Trim().StartsWith("sku="))
				{
					database.SetParameterValue(commandWrapper, "@SKU", 
						clause.Replace("sku","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("quantityonhand ") || clause.Trim().StartsWith("quantityonhand="))
				{
					database.SetParameterValue(commandWrapper, "@QuantityOnHand", 
						clause.Replace("quantityonhand","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("defaultind ") || clause.Trim().StartsWith("defaultind="))
				{
					database.SetParameterValue(commandWrapper, "@DefaultInd", 
						clause.Replace("defaultind","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("displayorder ") || clause.Trim().StartsWith("displayorder="))
				{
					database.SetParameterValue(commandWrapper, "@DisplayOrder", 
						clause.Replace("displayorder","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("imagefile ") || clause.Trim().StartsWith("imagefile="))
				{
					database.SetParameterValue(commandWrapper, "@ImageFile", 
						clause.Replace("imagefile","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("price ") || clause.Trim().StartsWith("price="))
				{
					database.SetParameterValue(commandWrapper, "@Price", 
						clause.Replace("price","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("weight ") || clause.Trim().StartsWith("weight="))
				{
					database.SetParameterValue(commandWrapper, "@Weight", 
						clause.Replace("weight","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> rows = new ZNode.Libraries.DataAccess.Entities.TList<AddOnValue>();
	
				
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public override ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> Find(TransactionManager transactionManager, SqlFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_Find_Dynamic", typeof(AddOnValueColumn), parameters, orderBy, start, pageLength);
			
			if ( parameters != null )
			{
				SqlFilterParameter param;

				for ( int i = 0; i < parameters.Count; i++ )
				{
					param = parameters[i];
					database.AddInParameter(commandWrapper, param.Name, param.DbType, param.Value);
				}
			}

			ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> rows = new ZNode.Libraries.DataAccess.Entities.TList<AddOnValue>();
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> rows = new ZNode.Libraries.DataAccess.Entities.TList<AddOnValue>();
			
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public override ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_GetPaged", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> rows = new ZNode.Libraries.DataAccess.Entities.TList<AddOnValue>();
			
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

		#region GetByAddOnID
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOnValue_ZNodeProductAddOn key.
		///		FK_ZNodeProductAddOnValue_ZNodeProductAddOn Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnID", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@AddOnID", DbType.Int32, addOnID);
			
			IDataReader reader = null;
			ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> rows = new ZNode.Libraries.DataAccess.Entities.TList<AddOnValue>();
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

		#region GetByAddOnValueID
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOnValue index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnValueID"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ZNode.Libraries.DataAccess.Entities.AddOnValue GetByAddOnValueID(TransactionManager transactionManager, System.Int32 addOnValueID, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_GetByAddOnValueID", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@AddOnValueID", DbType.Int32, addOnValueID);
			
			IDataReader reader = null;
			ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> tmp = new ZNode.Libraries.DataAccess.Entities.TList<AddOnValue>();
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
		///		After inserting into the datasource, the ZNode.Libraries.DataAccess.Entities.AddOnValue object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<ZNode.Libraries.DataAccess.Entities.AddOnValue> entities)
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
			bulkCopy.DestinationTableName = "ZNodeAddOnValue";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("AddOnValueID", typeof(System.Int32));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("AddOnID", typeof(System.Int32));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("Name", typeof(System.String));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("Description", typeof(System.String));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("SKU", typeof(System.String));
			col4.AllowDBNull = false;		
			DataColumn col5 = dataTable.Columns.Add("QuantityOnHand", typeof(System.Int32));
			col5.AllowDBNull = false;		
			DataColumn col6 = dataTable.Columns.Add("DefaultInd", typeof(System.Boolean));
			col6.AllowDBNull = false;		
			DataColumn col7 = dataTable.Columns.Add("DisplayOrder", typeof(System.Int32));
			col7.AllowDBNull = false;		
			DataColumn col8 = dataTable.Columns.Add("ImageFile", typeof(System.String));
			col8.AllowDBNull = false;		
			DataColumn col9 = dataTable.Columns.Add("Price", typeof(System.Decimal));
			col9.AllowDBNull = false;		
			DataColumn col10 = dataTable.Columns.Add("Weight", typeof(System.Decimal));
			col10.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("AddOnValueID", "AddOnValueID");
			bulkCopy.ColumnMappings.Add("AddOnID", "AddOnID");
			bulkCopy.ColumnMappings.Add("Name", "Name");
			bulkCopy.ColumnMappings.Add("Description", "Description");
			bulkCopy.ColumnMappings.Add("SKU", "SKU");
			bulkCopy.ColumnMappings.Add("QuantityOnHand", "QuantityOnHand");
			bulkCopy.ColumnMappings.Add("DefaultInd", "DefaultInd");
			bulkCopy.ColumnMappings.Add("DisplayOrder", "DisplayOrder");
			bulkCopy.ColumnMappings.Add("ImageFile", "ImageFile");
			bulkCopy.ColumnMappings.Add("Price", "Price");
			bulkCopy.ColumnMappings.Add("Weight", "Weight");
			
			foreach(ZNode.Libraries.DataAccess.Entities.AddOnValue entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["AddOnValueID"] = entity.AddOnValueID;
							
				
					row["AddOnID"] = entity.AddOnID;
							
				
					row["Name"] = entity.Name;
							
				
					row["Description"] = entity.Description;
							
				
					row["SKU"] = entity.SKU;
							
				
					row["QuantityOnHand"] = entity.QuantityOnHand;
							
				
					row["DefaultInd"] = entity.DefaultInd;
							
				
					row["DisplayOrder"] = entity.DisplayOrder;
							
				
					row["ImageFile"] = entity.ImageFile;
							
				
					row["Price"] = entity.Price;
							
				
					row["Weight"] = entity.Weight;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(ZNode.Libraries.DataAccess.Entities.AddOnValue entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a ZNode.Libraries.DataAccess.Entities.AddOnValue object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.AddOnValue object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the ZNode.Libraries.DataAccess.Entities.AddOnValue object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnValue entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@AddOnValueID", DbType.Int32, 4);
			database.AddInParameter(commandWrapper, "@AddOnID", DbType.Int32, entity.AddOnID );
			database.AddInParameter(commandWrapper, "@Name", DbType.String, entity.Name );
			database.AddInParameter(commandWrapper, "@Description", DbType.String, entity.Description );
			database.AddInParameter(commandWrapper, "@SKU", DbType.String, entity.SKU );
			database.AddInParameter(commandWrapper, "@QuantityOnHand", DbType.Int32, entity.QuantityOnHand );
			database.AddInParameter(commandWrapper, "@DefaultInd", DbType.Boolean, entity.DefaultInd );
			database.AddInParameter(commandWrapper, "@DisplayOrder", DbType.Int32, entity.DisplayOrder );
			database.AddInParameter(commandWrapper, "@ImageFile", DbType.String, entity.ImageFile );
			database.AddInParameter(commandWrapper, "@Price", DbType.Decimal, entity.Price );
			database.AddInParameter(commandWrapper, "@Weight", DbType.Decimal, entity.Weight );
			
			int results = 0;
			
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					

			entity.AddOnValueID = (System.Int32) database.GetParameterValue(commandWrapper, "@AddOnValueID");						
			
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Methods
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.AddOnValue object to update.</param>
		/// <remarks>
		///		After updating the datasource, the ZNode.Libraries.DataAccess.Entities.AddOnValue object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnValue entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.ZNODE_NT_ZNodeAddOnValue_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@AddOnValueID", DbType.Int32, entity.AddOnValueID );
			database.AddInParameter(commandWrapper, "@AddOnID", DbType.Int32, entity.AddOnID );
			database.AddInParameter(commandWrapper, "@Name", DbType.String, entity.Name );
			database.AddInParameter(commandWrapper, "@Description", DbType.String, entity.Description );
			database.AddInParameter(commandWrapper, "@SKU", DbType.String, entity.SKU );
			database.AddInParameter(commandWrapper, "@QuantityOnHand", DbType.Int32, entity.QuantityOnHand );
			database.AddInParameter(commandWrapper, "@DefaultInd", DbType.Boolean, entity.DefaultInd );
			database.AddInParameter(commandWrapper, "@DisplayOrder", DbType.Int32, entity.DisplayOrder );
			database.AddInParameter(commandWrapper, "@ImageFile", DbType.String, entity.ImageFile );
			database.AddInParameter(commandWrapper, "@Price", DbType.Decimal, entity.Price );
			database.AddInParameter(commandWrapper, "@Weight", DbType.Decimal, entity.Weight );
			
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
