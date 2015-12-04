#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data;

#endregion

namespace ZNode.Libraries.DataAccess.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="StoreProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StoreProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Store, ZNode.Libraries.DataAccess.Entities.StoreKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.StoreKey key)
		{
			return Delete(transactionManager, key.StoreID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="storeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 storeID)
		{
			return Delete(null, storeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="storeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 storeID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override ZNode.Libraries.DataAccess.Entities.Store Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.StoreKey key, int start, int pageLength)
		{
			return GetByStoreID(transactionManager, key.StoreID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_Store index.
		/// </summary>
		/// <param name="storeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Store GetByStoreID(System.Int32 storeID)
		{
			int count = -1;
			return GetByStoreID(null,storeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Store index.
		/// </summary>
		/// <param name="storeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Store GetByStoreID(System.Int32 storeID, int start, int pageLength)
		{
			int count = -1;
			return GetByStoreID(null, storeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Store index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="storeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Store GetByStoreID(TransactionManager transactionManager, System.Int32 storeID)
		{
			int count = -1;
			return GetByStoreID(transactionManager, storeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Store index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="storeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Store GetByStoreID(TransactionManager transactionManager, System.Int32 storeID, int start, int pageLength)
		{
			int count = -1;
			return GetByStoreID(transactionManager, storeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Store index.
		/// </summary>
		/// <param name="storeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Store GetByStoreID(System.Int32 storeID, int start, int pageLength, out int count)
		{
			return GetByStoreID(null, storeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Store index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="storeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Store GetByStoreID(TransactionManager transactionManager, System.Int32 storeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Store&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Store&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Store> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Store> rows, int start, int pageLength)
		{
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
					return rows; // not enough rows, just return
			}

			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done

				string key = null;
				
				ZNode.Libraries.DataAccess.Entities.Store c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Store" 
							+ (reader.IsDBNull(reader.GetOrdinal("StoreID"))?(int)0:(System.Int32)reader["StoreID"]).ToString();

					c = EntityManager.LocateOrCreate<Store>(
						key.ToString(), // EntityTrackingKey 
						"Store",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Store();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.StoreID = (System.Int32)reader["StoreID"];
					c.OriginalStoreID = c.StoreID; //(reader.IsDBNull(reader.GetOrdinal("StoreID")))?(int)0:(System.Int32)reader["StoreID"];
					c.Name = (System.String)reader["Name"];
					c.Address1 = (System.String)reader["Address1"];
					c.Address2 = (reader.IsDBNull(reader.GetOrdinal("Address2")))?null:(System.String)reader["Address2"];
					c.Address3 = (reader.IsDBNull(reader.GetOrdinal("Address3")))?null:(System.String)reader["Address3"];
					c.City = (System.String)reader["City"];
					c.State = (System.String)reader["State"];
					c.Zip = (System.String)reader["Zip"];
					c.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
					c.Fax = (reader.IsDBNull(reader.GetOrdinal("Fax")))?null:(System.String)reader["Fax"];
					c.ContactName = (reader.IsDBNull(reader.GetOrdinal("ContactName")))?null:(System.String)reader["ContactName"];
					c.ContactAddress1 = (reader.IsDBNull(reader.GetOrdinal("ContactAddress1")))?null:(System.String)reader["ContactAddress1"];
					c.ContactAddress2 = (reader.IsDBNull(reader.GetOrdinal("ContactAddress2")))?null:(System.String)reader["ContactAddress2"];
					c.ContactCity = (reader.IsDBNull(reader.GetOrdinal("ContactCity")))?null:(System.String)reader["ContactCity"];
					c.ContactState = (reader.IsDBNull(reader.GetOrdinal("ContactState")))?null:(System.String)reader["ContactState"];
					c.ContactZip = (reader.IsDBNull(reader.GetOrdinal("ContactZip")))?null:(System.String)reader["ContactZip"];
					c.ContactPhone = (reader.IsDBNull(reader.GetOrdinal("ContactPhone")))?null:(System.String)reader["ContactPhone"];
					c.IsDealer = (reader.IsDBNull(reader.GetOrdinal("IsDealer")))?null:(System.String)reader["IsDealer"];
					c.P1 = (reader.IsDBNull(reader.GetOrdinal("p1")))?null:(System.String)reader["p1"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Store entity)
		{
			if (!reader.Read()) return;
			
			entity.StoreID = (System.Int32)reader["StoreID"];
			entity.OriginalStoreID = (System.Int32)reader["StoreID"];
			entity.Name = (System.String)reader["Name"];
			entity.Address1 = (System.String)reader["Address1"];
			entity.Address2 = (reader.IsDBNull(reader.GetOrdinal("Address2")))?null:(System.String)reader["Address2"];
			entity.Address3 = (reader.IsDBNull(reader.GetOrdinal("Address3")))?null:(System.String)reader["Address3"];
			entity.City = (System.String)reader["City"];
			entity.State = (System.String)reader["State"];
			entity.Zip = (System.String)reader["Zip"];
			entity.Phone = (reader.IsDBNull(reader.GetOrdinal("Phone")))?null:(System.String)reader["Phone"];
			entity.Fax = (reader.IsDBNull(reader.GetOrdinal("Fax")))?null:(System.String)reader["Fax"];
			entity.ContactName = (reader.IsDBNull(reader.GetOrdinal("ContactName")))?null:(System.String)reader["ContactName"];
			entity.ContactAddress1 = (reader.IsDBNull(reader.GetOrdinal("ContactAddress1")))?null:(System.String)reader["ContactAddress1"];
			entity.ContactAddress2 = (reader.IsDBNull(reader.GetOrdinal("ContactAddress2")))?null:(System.String)reader["ContactAddress2"];
			entity.ContactCity = (reader.IsDBNull(reader.GetOrdinal("ContactCity")))?null:(System.String)reader["ContactCity"];
			entity.ContactState = (reader.IsDBNull(reader.GetOrdinal("ContactState")))?null:(System.String)reader["ContactState"];
			entity.ContactZip = (reader.IsDBNull(reader.GetOrdinal("ContactZip")))?null:(System.String)reader["ContactZip"];
			entity.ContactPhone = (reader.IsDBNull(reader.GetOrdinal("ContactPhone")))?null:(System.String)reader["ContactPhone"];
			entity.IsDealer = (reader.IsDBNull(reader.GetOrdinal("IsDealer")))?null:(System.String)reader["IsDealer"];
			entity.P1 = (reader.IsDBNull(reader.GetOrdinal("p1")))?null:(System.String)reader["p1"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Store entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.StoreID = (System.Int32)dataRow["StoreID"];
			entity.OriginalStoreID = (System.Int32)dataRow["StoreID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Address1 = (System.String)dataRow["Address1"];
			entity.Address2 = (Convert.IsDBNull(dataRow["Address2"]))?null:(System.String)dataRow["Address2"];
			entity.Address3 = (Convert.IsDBNull(dataRow["Address3"]))?null:(System.String)dataRow["Address3"];
			entity.City = (System.String)dataRow["City"];
			entity.State = (System.String)dataRow["State"];
			entity.Zip = (System.String)dataRow["Zip"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?null:(System.String)dataRow["Phone"];
			entity.Fax = (Convert.IsDBNull(dataRow["Fax"]))?null:(System.String)dataRow["Fax"];
			entity.ContactName = (Convert.IsDBNull(dataRow["ContactName"]))?null:(System.String)dataRow["ContactName"];
			entity.ContactAddress1 = (Convert.IsDBNull(dataRow["ContactAddress1"]))?null:(System.String)dataRow["ContactAddress1"];
			entity.ContactAddress2 = (Convert.IsDBNull(dataRow["ContactAddress2"]))?null:(System.String)dataRow["ContactAddress2"];
			entity.ContactCity = (Convert.IsDBNull(dataRow["ContactCity"]))?null:(System.String)dataRow["ContactCity"];
			entity.ContactState = (Convert.IsDBNull(dataRow["ContactState"]))?null:(System.String)dataRow["ContactState"];
			entity.ContactZip = (Convert.IsDBNull(dataRow["ContactZip"]))?null:(System.String)dataRow["ContactZip"];
			entity.ContactPhone = (Convert.IsDBNull(dataRow["ContactPhone"]))?null:(System.String)dataRow["ContactPhone"];
			entity.IsDealer = (Convert.IsDBNull(dataRow["IsDealer"]))?null:(System.String)dataRow["IsDealer"];
			entity.P1 = (Convert.IsDBNull(dataRow["p1"]))?null:(System.String)dataRow["p1"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Store"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Store Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Store entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Store object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Store instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Store Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Store entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region StoreChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Store</c>
	///</summary>
	public enum StoreChildEntityTypes
	{
	}
	
	#endregion StoreChildEntityTypes
	
	#region StoreFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreFilterBuilder : SqlFilterBuilder<StoreColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreFilterBuilder class.
		/// </summary>
		public StoreFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreFilterBuilder
	
	#region StoreParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Store"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StoreParameterBuilder : ParameterizedSqlFilterBuilder<StoreColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StoreParameterBuilder class.
		/// </summary>
		public StoreParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StoreParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StoreParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StoreParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StoreParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StoreParameterBuilder
} // end namespace
