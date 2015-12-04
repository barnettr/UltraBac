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
	/// This class is the base class for any <see cref="ProductCrossSellProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductCrossSellProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ProductCrossSell, ZNode.Libraries.DataAccess.Entities.ProductCrossSellKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCrossSellKey key)
		{
			return Delete(transactionManager, key.ProductCrossSellTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="productCrossSellTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 productCrossSellTypeId)
		{
			return Delete(null, productCrossSellTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCrossSellTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 productCrossSellTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCrossSellType_SC_Product key.
		///		FK_SC_ProductCrossSellType_SC_Product Description: 
		/// </summary>
		/// <param name="productId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCrossSell objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> GetByProductId(System.Int32 productId)
		{
			int count = -1;
			return GetByProductId(productId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCrossSellType_SC_Product key.
		///		FK_SC_ProductCrossSellType_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCrossSell objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> GetByProductId(TransactionManager transactionManager, System.Int32 productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, productId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCrossSellType_SC_Product key.
		///		FK_SC_ProductCrossSellType_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCrossSell objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> GetByProductId(TransactionManager transactionManager, System.Int32 productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCrossSellType_SC_Product key.
		///		fKSCProductCrossSellTypeSCProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCrossSell objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> GetByProductId(System.Int32 productId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductId(null, productId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCrossSellType_SC_Product key.
		///		fKSCProductCrossSellTypeSCProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCrossSell objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> GetByProductId(System.Int32 productId, int start, int pageLength,out int count)
		{
			return GetByProductId(null, productId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCrossSellType_SC_Product key.
		///		FK_SC_ProductCrossSellType_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCrossSell objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> GetByProductId(TransactionManager transactionManager, System.Int32 productId, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ProductCrossSell Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCrossSellKey key, int start, int pageLength)
		{
			return GetByProductCrossSellTypeId(transactionManager, key.ProductCrossSellTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_ProductCrossSellType index.
		/// </summary>
		/// <param name="productCrossSellTypeId"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCrossSell GetByProductCrossSellTypeId(System.Int32 productCrossSellTypeId)
		{
			int count = -1;
			return GetByProductCrossSellTypeId(null,productCrossSellTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductCrossSellType index.
		/// </summary>
		/// <param name="productCrossSellTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCrossSell GetByProductCrossSellTypeId(System.Int32 productCrossSellTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductCrossSellTypeId(null, productCrossSellTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductCrossSellType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCrossSellTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCrossSell GetByProductCrossSellTypeId(TransactionManager transactionManager, System.Int32 productCrossSellTypeId)
		{
			int count = -1;
			return GetByProductCrossSellTypeId(transactionManager, productCrossSellTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductCrossSellType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCrossSellTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCrossSell GetByProductCrossSellTypeId(TransactionManager transactionManager, System.Int32 productCrossSellTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductCrossSellTypeId(transactionManager, productCrossSellTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductCrossSellType index.
		/// </summary>
		/// <param name="productCrossSellTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCrossSell GetByProductCrossSellTypeId(System.Int32 productCrossSellTypeId, int start, int pageLength, out int count)
		{
			return GetByProductCrossSellTypeId(null, productCrossSellTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductCrossSellType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCrossSellTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ProductCrossSell GetByProductCrossSellTypeId(TransactionManager transactionManager, System.Int32 productCrossSellTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ProductCrossSell&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductCrossSell&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ProductCrossSell> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ProductCrossSell c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProductCrossSell" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProductCrossSellTypeId"))?(int)0:(System.Int32)reader["ProductCrossSellTypeId"]).ToString();

					c = EntityManager.LocateOrCreate<ProductCrossSell>(
						key.ToString(), // EntityTrackingKey 
						"ProductCrossSell",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ProductCrossSell();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProductCrossSellTypeId = (System.Int32)reader["ProductCrossSellTypeId"];
					c.PortalId = (System.Int32)reader["PortalId"];
					c.ProductId = (System.Int32)reader["ProductId"];
					c.RelatedProductId = (System.Int32)reader["RelatedProductId"];
					c.DisplayOrder = (reader.IsDBNull(reader.GetOrdinal("DisplayOrder")))?null:(System.Int32?)reader["DisplayOrder"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ProductCrossSell entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductCrossSellTypeId = (System.Int32)reader["ProductCrossSellTypeId"];
			entity.PortalId = (System.Int32)reader["PortalId"];
			entity.ProductId = (System.Int32)reader["ProductId"];
			entity.RelatedProductId = (System.Int32)reader["RelatedProductId"];
			entity.DisplayOrder = (reader.IsDBNull(reader.GetOrdinal("DisplayOrder")))?null:(System.Int32?)reader["DisplayOrder"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ProductCrossSell entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductCrossSellTypeId = (System.Int32)dataRow["ProductCrossSellTypeId"];
			entity.PortalId = (System.Int32)dataRow["PortalId"];
			entity.ProductId = (System.Int32)dataRow["ProductId"];
			entity.RelatedProductId = (System.Int32)dataRow["RelatedProductId"];
			entity.DisplayOrder = (Convert.IsDBNull(dataRow["DisplayOrder"]))?null:(System.Int32?)dataRow["DisplayOrder"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductCrossSell"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductCrossSell Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCrossSell entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ProductIdSource	
			if (CanDeepLoad(entity, "Product", "ProductIdSource", deepLoadType, innerList) 
				&& entity.ProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductId;
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductIdSource = tmpEntity;
				else
					entity.ProductIdSource = DataRepository.ProductProvider.GetByProductID(entity.ProductId);
			
				if (deep && entity.ProductIdSource != null)
				{
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProductIdSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ProductCrossSell object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ProductCrossSell instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductCrossSell Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCrossSell entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductIdSource
			if (CanDeepSave(entity, "Product", "ProductIdSource", deepSaveType, innerList) 
				&& entity.ProductIdSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductIdSource);
				entity.ProductId = entity.ProductIdSource.ProductID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductCrossSellChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ProductCrossSell</c>
	///</summary>
	public enum ProductCrossSellChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
		}
	
	#endregion ProductCrossSellChildEntityTypes
	
	#region ProductCrossSellFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCrossSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCrossSellFilterBuilder : SqlFilterBuilder<ProductCrossSellColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCrossSellFilterBuilder class.
		/// </summary>
		public ProductCrossSellFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCrossSellFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCrossSellFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCrossSellFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCrossSellFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCrossSellFilterBuilder
	
	#region ProductCrossSellParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCrossSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCrossSellParameterBuilder : ParameterizedSqlFilterBuilder<ProductCrossSellColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCrossSellParameterBuilder class.
		/// </summary>
		public ProductCrossSellParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCrossSellParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCrossSellParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCrossSellParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCrossSellParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCrossSellParameterBuilder
} // end namespace
