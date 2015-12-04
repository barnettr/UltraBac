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
	/// This class is the base class for any <see cref="SKUAttributeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SKUAttributeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.SKUAttribute, ZNode.Libraries.DataAccess.Entities.SKUAttributeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKUAttributeKey key)
		{
			return Delete(transactionManager, key.SKUAttributeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="sKUAttributeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 sKUAttributeID)
		{
			return Delete(null, sKUAttributeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="sKUAttributeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 sKUAttributeID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_Attribute key.
		///		FK_SC_SKUAttribute_SC_Attribute Description: 
		/// </summary>
		/// <param name="attributeId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeId(System.Int32 attributeId)
		{
			int count = -1;
			return GetByAttributeId(attributeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_Attribute key.
		///		FK_SC_SKUAttribute_SC_Attribute Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeId(TransactionManager transactionManager, System.Int32 attributeId)
		{
			int count = -1;
			return GetByAttributeId(transactionManager, attributeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_Attribute key.
		///		FK_SC_SKUAttribute_SC_Attribute Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeId(TransactionManager transactionManager, System.Int32 attributeId, int start, int pageLength)
		{
			int count = -1;
			return GetByAttributeId(transactionManager, attributeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_Attribute key.
		///		fKSCSKUAttributeSCAttribute Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="attributeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeId(System.Int32 attributeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAttributeId(null, attributeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_Attribute key.
		///		fKSCSKUAttributeSCAttribute Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="attributeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeId(System.Int32 attributeId, int start, int pageLength,out int count)
		{
			return GetByAttributeId(null, attributeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_Attribute key.
		///		FK_SC_SKUAttribute_SC_Attribute Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeId(TransactionManager transactionManager, System.Int32 attributeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_SKU key.
		///		FK_SC_SKUAttribute_SC_SKU Description: 
		/// </summary>
		/// <param name="skuid"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetBySKUID(System.Int32 skuid)
		{
			int count = -1;
			return GetBySKUID(skuid, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_SKU key.
		///		FK_SC_SKUAttribute_SC_SKU Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="skuid"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetBySKUID(TransactionManager transactionManager, System.Int32 skuid)
		{
			int count = -1;
			return GetBySKUID(transactionManager, skuid, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_SKU key.
		///		FK_SC_SKUAttribute_SC_SKU Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetBySKUID(TransactionManager transactionManager, System.Int32 skuid, int start, int pageLength)
		{
			int count = -1;
			return GetBySKUID(transactionManager, skuid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_SKU key.
		///		fKSCSKUAttributeSCSKU Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="skuid"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetBySKUID(System.Int32 skuid, int start, int pageLength)
		{
			int count =  -1;
			return GetBySKUID(null, skuid, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_SKU key.
		///		fKSCSKUAttributeSCSKU Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="skuid"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetBySKUID(System.Int32 skuid, int start, int pageLength,out int count)
		{
			return GetBySKUID(null, skuid, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_SKUAttribute_SC_SKU key.
		///		FK_SC_SKUAttribute_SC_SKU Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.SKUAttribute objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetBySKUID(TransactionManager transactionManager, System.Int32 skuid, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.SKUAttribute Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKUAttributeKey key, int start, int pageLength)
		{
			return GetBySKUAttributeID(transactionManager, key.SKUAttributeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_SKUAttribute index.
		/// </summary>
		/// <param name="sKUAttributeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKUAttribute GetBySKUAttributeID(System.Int32 sKUAttributeID)
		{
			int count = -1;
			return GetBySKUAttributeID(null,sKUAttributeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_SKUAttribute index.
		/// </summary>
		/// <param name="sKUAttributeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKUAttribute GetBySKUAttributeID(System.Int32 sKUAttributeID, int start, int pageLength)
		{
			int count = -1;
			return GetBySKUAttributeID(null, sKUAttributeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_SKUAttribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="sKUAttributeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKUAttribute GetBySKUAttributeID(TransactionManager transactionManager, System.Int32 sKUAttributeID)
		{
			int count = -1;
			return GetBySKUAttributeID(transactionManager, sKUAttributeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_SKUAttribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="sKUAttributeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKUAttribute GetBySKUAttributeID(TransactionManager transactionManager, System.Int32 sKUAttributeID, int start, int pageLength)
		{
			int count = -1;
			return GetBySKUAttributeID(transactionManager, sKUAttributeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_SKUAttribute index.
		/// </summary>
		/// <param name="sKUAttributeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKUAttribute GetBySKUAttributeID(System.Int32 sKUAttributeID, int start, int pageLength, out int count)
		{
			return GetBySKUAttributeID(null, sKUAttributeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_SKUAttribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="sKUAttributeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.SKUAttribute GetBySKUAttributeID(TransactionManager transactionManager, System.Int32 sKUAttributeID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ix1 index.
		/// </summary>
		/// <param name="attributeId"></param>
		/// <param name="skuid"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeIdSKUID(System.Int32 attributeId, System.Int32 skuid)
		{
			int count = -1;
			return GetByAttributeIdSKUID(null,attributeId, skuid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix1 index.
		/// </summary>
		/// <param name="attributeId"></param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeIdSKUID(System.Int32 attributeId, System.Int32 skuid, int start, int pageLength)
		{
			int count = -1;
			return GetByAttributeIdSKUID(null, attributeId, skuid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <param name="skuid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeIdSKUID(TransactionManager transactionManager, System.Int32 attributeId, System.Int32 skuid)
		{
			int count = -1;
			return GetByAttributeIdSKUID(transactionManager, attributeId, skuid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeIdSKUID(TransactionManager transactionManager, System.Int32 attributeId, System.Int32 skuid, int start, int pageLength)
		{
			int count = -1;
			return GetByAttributeIdSKUID(transactionManager, attributeId, skuid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix1 index.
		/// </summary>
		/// <param name="attributeId"></param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeIdSKUID(System.Int32 attributeId, System.Int32 skuid, int start, int pageLength, out int count)
		{
			return GetByAttributeIdSKUID(null, attributeId, skuid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ix1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="attributeId"></param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> GetByAttributeIdSKUID(TransactionManager transactionManager, System.Int32 attributeId, System.Int32 skuid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKUAttribute&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<SKUAttribute> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.SKUAttribute c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"SKUAttribute" 
							+ (reader.IsDBNull(reader.GetOrdinal("SKUAttributeID"))?(int)0:(System.Int32)reader["SKUAttributeID"]).ToString();

					c = EntityManager.LocateOrCreate<SKUAttribute>(
						key.ToString(), // EntityTrackingKey 
						"SKUAttribute",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.SKUAttribute();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.SKUAttributeID = (System.Int32)reader["SKUAttributeID"];
					c.SKUID = (System.Int32)reader["SKUID"];
					c.AttributeId = (System.Int32)reader["AttributeId"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.SKUAttribute entity)
		{
			if (!reader.Read()) return;
			
			entity.SKUAttributeID = (System.Int32)reader["SKUAttributeID"];
			entity.SKUID = (System.Int32)reader["SKUID"];
			entity.AttributeId = (System.Int32)reader["AttributeId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.SKUAttribute entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SKUAttributeID = (System.Int32)dataRow["SKUAttributeID"];
			entity.SKUID = (System.Int32)dataRow["SKUID"];
			entity.AttributeId = (System.Int32)dataRow["AttributeId"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.SKUAttribute"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.SKUAttribute Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKUAttribute entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region AttributeIdSource	
			if (CanDeepLoad(entity, "ProductAttribute", "AttributeIdSource", deepLoadType, innerList) 
				&& entity.AttributeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AttributeId;
				ProductAttribute tmpEntity = EntityManager.LocateEntity<ProductAttribute>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductAttribute), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AttributeIdSource = tmpEntity;
				else
					entity.AttributeIdSource = DataRepository.ProductAttributeProvider.GetByAttributeId(entity.AttributeId);
			
				if (deep && entity.AttributeIdSource != null)
				{
					DataRepository.ProductAttributeProvider.DeepLoad(transactionManager, entity.AttributeIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion AttributeIdSource

			#region SKUIDSource	
			if (CanDeepLoad(entity, "SKU", "SKUIDSource", deepLoadType, innerList) 
				&& entity.SKUIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.SKUID;
				SKU tmpEntity = EntityManager.LocateEntity<SKU>(EntityLocator.ConstructKeyFromPkItems(typeof(SKU), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SKUIDSource = tmpEntity;
				else
					entity.SKUIDSource = DataRepository.SKUProvider.GetBySKUID(entity.SKUID);
			
				if (deep && entity.SKUIDSource != null)
				{
					DataRepository.SKUProvider.DeepLoad(transactionManager, entity.SKUIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion SKUIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.SKUAttribute object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.SKUAttribute instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.SKUAttribute Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKUAttribute entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AttributeIdSource
			if (CanDeepSave(entity, "ProductAttribute", "AttributeIdSource", deepSaveType, innerList) 
				&& entity.AttributeIdSource != null)
			{
				DataRepository.ProductAttributeProvider.Save(transactionManager, entity.AttributeIdSource);
				entity.AttributeId = entity.AttributeIdSource.AttributeId;
			}
			#endregion 
			
			#region SKUIDSource
			if (CanDeepSave(entity, "SKU", "SKUIDSource", deepSaveType, innerList) 
				&& entity.SKUIDSource != null)
			{
				DataRepository.SKUProvider.Save(transactionManager, entity.SKUIDSource);
				entity.SKUID = entity.SKUIDSource.SKUID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region SKUAttributeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.SKUAttribute</c>
	///</summary>
	public enum SKUAttributeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ProductAttribute</c> at AttributeIdSource
		///</summary>
		[ChildEntityType(typeof(ProductAttribute))]
		ProductAttribute,
			
		///<summary>
		/// Composite Property for <c>SKU</c> at SKUIDSource
		///</summary>
		[ChildEntityType(typeof(SKU))]
		SKU,
		}
	
	#endregion SKUAttributeChildEntityTypes
	
	#region SKUAttributeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SKUAttribute"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SKUAttributeFilterBuilder : SqlFilterBuilder<SKUAttributeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SKUAttributeFilterBuilder class.
		/// </summary>
		public SKUAttributeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SKUAttributeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SKUAttributeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SKUAttributeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SKUAttributeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SKUAttributeFilterBuilder
	
	#region SKUAttributeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SKUAttribute"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SKUAttributeParameterBuilder : ParameterizedSqlFilterBuilder<SKUAttributeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SKUAttributeParameterBuilder class.
		/// </summary>
		public SKUAttributeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SKUAttributeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SKUAttributeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SKUAttributeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SKUAttributeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SKUAttributeParameterBuilder
} // end namespace
