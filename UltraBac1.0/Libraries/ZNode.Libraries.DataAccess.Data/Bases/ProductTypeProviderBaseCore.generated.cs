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
	/// This class is the base class for any <see cref="ProductTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ProductType, ZNode.Libraries.DataAccess.Entities.ProductTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductTypeKey key)
		{
			return Delete(transactionManager, key.ProductTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="productTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 productTypeId)
		{
			return Delete(null, productTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 productTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductType_Portals key.
		///		FK_SC_ProductType_Portals Description: 
		/// </summary>
		/// <param name="portalId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductType objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductType> GetByPortalId(System.Int32 portalId)
		{
			int count = -1;
			return GetByPortalId(portalId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductType_Portals key.
		///		FK_SC_ProductType_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductType objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductType> GetByPortalId(TransactionManager transactionManager, System.Int32 portalId)
		{
			int count = -1;
			return GetByPortalId(transactionManager, portalId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductType_Portals key.
		///		FK_SC_ProductType_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductType objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductType> GetByPortalId(TransactionManager transactionManager, System.Int32 portalId, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalId(transactionManager, portalId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductType_Portals key.
		///		fKSCProductTypePortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductType objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductType> GetByPortalId(System.Int32 portalId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalId(null, portalId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductType_Portals key.
		///		fKSCProductTypePortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductType objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductType> GetByPortalId(System.Int32 portalId, int start, int pageLength,out int count)
		{
			return GetByPortalId(null, portalId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductType_Portals key.
		///		FK_SC_ProductType_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductType objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductType> GetByPortalId(TransactionManager transactionManager, System.Int32 portalId, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ProductType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductTypeKey key, int start, int pageLength)
		{
			return GetByProductTypeId(transactionManager, key.ProductTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_ProductType index.
		/// </summary>
		/// <param name="productTypeId"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductType GetByProductTypeId(System.Int32 productTypeId)
		{
			int count = -1;
			return GetByProductTypeId(null,productTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductType index.
		/// </summary>
		/// <param name="productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductType GetByProductTypeId(System.Int32 productTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductTypeId(null, productTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductType GetByProductTypeId(TransactionManager transactionManager, System.Int32 productTypeId)
		{
			int count = -1;
			return GetByProductTypeId(transactionManager, productTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductType GetByProductTypeId(TransactionManager transactionManager, System.Int32 productTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductTypeId(transactionManager, productTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductType index.
		/// </summary>
		/// <param name="productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductType GetByProductTypeId(System.Int32 productTypeId, int start, int pageLength, out int count)
		{
			return GetByProductTypeId(null, productTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ProductType GetByProductTypeId(TransactionManager transactionManager, System.Int32 productTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ProductType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ProductType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ProductType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ProductType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProductType" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProductTypeId"))?(int)0:(System.Int32)reader["ProductTypeId"]).ToString();

					c = EntityManager.LocateOrCreate<ProductType>(
						key.ToString(), // EntityTrackingKey 
						"ProductType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ProductType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProductTypeId = (System.Int32)reader["ProductTypeId"];
					c.PortalId = (System.Int32)reader["PortalId"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ProductType entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductTypeId = (System.Int32)reader["ProductTypeId"];
			entity.PortalId = (System.Int32)reader["PortalId"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ProductType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductTypeId = (System.Int32)dataRow["ProductTypeId"];
			entity.PortalId = (System.Int32)dataRow["PortalId"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region PortalIdSource	
			if (CanDeepLoad(entity, "Portal", "PortalIdSource", deepLoadType, innerList) 
				&& entity.PortalIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PortalId;
				Portal tmpEntity = EntityManager.LocateEntity<Portal>(EntityLocator.ConstructKeyFromPkItems(typeof(Portal), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PortalIdSource = tmpEntity;
				else
					entity.PortalIdSource = DataRepository.PortalProvider.GetByPortalID(entity.PortalId);
			
				if (deep && entity.PortalIdSource != null)
				{
					DataRepository.PortalProvider.DeepLoad(transactionManager, entity.PortalIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PortalIdSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByProductTypeId methods when available
			
			#region ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>", "ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductCollection' loaded.");
				#endif 

				entity.ProductCollection = DataRepository.ProductProvider.GetByProductTypeID(transactionManager, entity.ProductTypeId);

				if (deep && entity.ProductCollection.Count > 0)
				{
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductTypeAttributeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductTypeAttribute>", "ProductTypeAttributeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductTypeAttributeCollection' loaded.");
				#endif 

				entity.ProductTypeAttributeCollection = DataRepository.ProductTypeAttributeProvider.GetByProductTypeId(transactionManager, entity.ProductTypeId);

				if (deep && entity.ProductTypeAttributeCollection.Count > 0)
				{
					DataRepository.ProductTypeAttributeProvider.DeepLoad(transactionManager, entity.ProductTypeAttributeCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ProductType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ProductType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PortalIdSource
			if (CanDeepSave(entity, "Portal", "PortalIdSource", deepSaveType, innerList) 
				&& entity.PortalIdSource != null)
			{
				DataRepository.PortalProvider.Save(transactionManager, entity.PortalIdSource);
				entity.PortalId = entity.PortalIdSource.PortalID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





			#region List<Product>
				if (CanDeepSave(entity, "List<Product>", "ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollection)
					{
						child.ProductTypeID = entity.ProductTypeId;
					}
				
				if (entity.ProductCollection.Count > 0 || entity.ProductCollection.DeletedItems.Count > 0)
					DataRepository.ProductProvider.DeepSave(transactionManager, entity.ProductCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ProductTypeAttribute>
				if (CanDeepSave(entity, "List<ProductTypeAttribute>", "ProductTypeAttributeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductTypeAttribute child in entity.ProductTypeAttributeCollection)
					{
						child.ProductTypeId = entity.ProductTypeId;
					}
				
				if (entity.ProductTypeAttributeCollection.Count > 0 || entity.ProductTypeAttributeCollection.DeletedItems.Count > 0)
					DataRepository.ProductTypeAttributeProvider.DeepSave(transactionManager, entity.ProductTypeAttributeCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ProductType</c>
	///</summary>
	public enum ProductTypeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIdSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
	
		///<summary>
		/// Collection of <c>ProductType</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollection,

		///<summary>
		/// Collection of <c>ProductType</c> as OneToMany for ProductTypeAttributeCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductTypeAttribute>))]
		ProductTypeAttributeCollection,
	}
	
	#endregion ProductTypeChildEntityTypes
	
	#region ProductTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeFilterBuilder : SqlFilterBuilder<ProductTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeFilterBuilder class.
		/// </summary>
		public ProductTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductTypeFilterBuilder
	
	#region ProductTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeParameterBuilder : ParameterizedSqlFilterBuilder<ProductTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeParameterBuilder class.
		/// </summary>
		public ProductTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductTypeParameterBuilder
} // end namespace
