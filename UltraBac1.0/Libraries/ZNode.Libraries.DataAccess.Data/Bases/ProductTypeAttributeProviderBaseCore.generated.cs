﻿#region Using directives

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
	/// This class is the base class for any <see cref="ProductTypeAttributeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductTypeAttributeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute, ZNode.Libraries.DataAccess.Entities.ProductTypeAttributeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductTypeAttributeKey key)
		{
			return Delete(transactionManager, key.ProductAttributeTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="productAttributeTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 productAttributeTypeID)
		{
			return Delete(null, productAttributeTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAttributeTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 productAttributeTypeID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductTypeAttribute_SC_ProductType key.
		///		FK_SC_ProductTypeAttribute_SC_ProductType Description: 
		/// </summary>
		/// <param name="productTypeId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> GetByProductTypeId(System.Int32 productTypeId)
		{
			int count = -1;
			return GetByProductTypeId(productTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductTypeAttribute_SC_ProductType key.
		///		FK_SC_ProductTypeAttribute_SC_ProductType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> GetByProductTypeId(TransactionManager transactionManager, System.Int32 productTypeId)
		{
			int count = -1;
			return GetByProductTypeId(transactionManager, productTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductTypeAttribute_SC_ProductType key.
		///		FK_SC_ProductTypeAttribute_SC_ProductType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> GetByProductTypeId(TransactionManager transactionManager, System.Int32 productTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductTypeId(transactionManager, productTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductTypeAttribute_SC_ProductType key.
		///		fKSCProductTypeAttributeSCProductType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> GetByProductTypeId(System.Int32 productTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductTypeId(null, productTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductTypeAttribute_SC_ProductType key.
		///		fKSCProductTypeAttributeSCProductType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> GetByProductTypeId(System.Int32 productTypeId, int start, int pageLength,out int count)
		{
			return GetByProductTypeId(null, productTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductTypeAttribute_SC_ProductType key.
		///		FK_SC_ProductTypeAttribute_SC_ProductType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> GetByProductTypeId(TransactionManager transactionManager, System.Int32 productTypeId, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductTypeAttributeKey key, int start, int pageLength)
		{
			return GetByProductAttributeTypeID(transactionManager, key.ProductAttributeTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_ProductTypeAttribute index.
		/// </summary>
		/// <param name="productAttributeTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute GetByProductAttributeTypeID(System.Int32 productAttributeTypeID)
		{
			int count = -1;
			return GetByProductAttributeTypeID(null,productAttributeTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductTypeAttribute index.
		/// </summary>
		/// <param name="productAttributeTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute GetByProductAttributeTypeID(System.Int32 productAttributeTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductAttributeTypeID(null, productAttributeTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductTypeAttribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAttributeTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute GetByProductAttributeTypeID(TransactionManager transactionManager, System.Int32 productAttributeTypeID)
		{
			int count = -1;
			return GetByProductAttributeTypeID(transactionManager, productAttributeTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductTypeAttribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAttributeTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute GetByProductAttributeTypeID(TransactionManager transactionManager, System.Int32 productAttributeTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductAttributeTypeID(transactionManager, productAttributeTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductTypeAttribute index.
		/// </summary>
		/// <param name="productAttributeTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute GetByProductAttributeTypeID(System.Int32 productAttributeTypeID, int start, int pageLength, out int count)
		{
			return GetByProductAttributeTypeID(null, productAttributeTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductTypeAttribute index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAttributeTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute GetByProductAttributeTypeID(TransactionManager transactionManager, System.Int32 productAttributeTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ProductTypeAttribute&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductTypeAttribute&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ProductTypeAttribute> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProductTypeAttribute" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProductAttributeTypeID"))?(int)0:(System.Int32)reader["ProductAttributeTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<ProductTypeAttribute>(
						key.ToString(), // EntityTrackingKey 
						"ProductTypeAttribute",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProductAttributeTypeID = (System.Int32)reader["ProductAttributeTypeID"];
					c.ProductTypeId = (System.Int32)reader["ProductTypeId"];
					c.AttributeTypeId = (System.Int32)reader["AttributeTypeId"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductAttributeTypeID = (System.Int32)reader["ProductAttributeTypeID"];
			entity.ProductTypeId = (System.Int32)reader["ProductTypeId"];
			entity.AttributeTypeId = (System.Int32)reader["AttributeTypeId"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductAttributeTypeID = (System.Int32)dataRow["ProductAttributeTypeID"];
			entity.ProductTypeId = (System.Int32)dataRow["ProductTypeId"];
			entity.AttributeTypeId = (System.Int32)dataRow["AttributeTypeId"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ProductTypeIdSource	
			if (CanDeepLoad(entity, "ProductType", "ProductTypeIdSource", deepLoadType, innerList) 
				&& entity.ProductTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductTypeId;
				ProductType tmpEntity = EntityManager.LocateEntity<ProductType>(EntityLocator.ConstructKeyFromPkItems(typeof(ProductType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductTypeIdSource = tmpEntity;
				else
					entity.ProductTypeIdSource = DataRepository.ProductTypeProvider.GetByProductTypeId(entity.ProductTypeId);
			
				if (deep && entity.ProductTypeIdSource != null)
				{
					DataRepository.ProductTypeProvider.DeepLoad(transactionManager, entity.ProductTypeIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProductTypeIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductTypeIdSource
			if (CanDeepSave(entity, "ProductType", "ProductTypeIdSource", deepSaveType, innerList) 
				&& entity.ProductTypeIdSource != null)
			{
				DataRepository.ProductTypeProvider.Save(transactionManager, entity.ProductTypeIdSource);
				entity.ProductTypeId = entity.ProductTypeIdSource.ProductTypeId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductTypeAttributeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ProductTypeAttribute</c>
	///</summary>
	public enum ProductTypeAttributeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ProductType</c> at ProductTypeIdSource
		///</summary>
		[ChildEntityType(typeof(ProductType))]
		ProductType,
		}
	
	#endregion ProductTypeAttributeChildEntityTypes
	
	#region ProductTypeAttributeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductTypeAttribute"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeAttributeFilterBuilder : SqlFilterBuilder<ProductTypeAttributeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeAttributeFilterBuilder class.
		/// </summary>
		public ProductTypeAttributeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeAttributeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductTypeAttributeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeAttributeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductTypeAttributeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductTypeAttributeFilterBuilder
	
	#region ProductTypeAttributeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductTypeAttribute"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductTypeAttributeParameterBuilder : ParameterizedSqlFilterBuilder<ProductTypeAttributeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductTypeAttributeParameterBuilder class.
		/// </summary>
		public ProductTypeAttributeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeAttributeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductTypeAttributeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductTypeAttributeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductTypeAttributeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductTypeAttributeParameterBuilder
} // end namespace
