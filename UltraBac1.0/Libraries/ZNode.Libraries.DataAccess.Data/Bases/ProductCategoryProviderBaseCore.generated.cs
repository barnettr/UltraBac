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
	/// This class is the base class for any <see cref="ProductCategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductCategoryProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ProductCategory, ZNode.Libraries.DataAccess.Entities.ProductCategoryKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCategoryKey key)
		{
			return Delete(transactionManager, key.ProductCategoryID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="productCategoryID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 productCategoryID)
		{
			return Delete(null, productCategoryID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCategoryID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 productCategoryID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Category key.
		///		FK_SC_ProductCategory_SC_Category Description: 
		/// </summary>
		/// <param name="categoryID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByCategoryID(System.Int32 categoryID)
		{
			int count = -1;
			return GetByCategoryID(categoryID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Category key.
		///		FK_SC_ProductCategory_SC_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByCategoryID(TransactionManager transactionManager, System.Int32 categoryID)
		{
			int count = -1;
			return GetByCategoryID(transactionManager, categoryID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Category key.
		///		FK_SC_ProductCategory_SC_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByCategoryID(TransactionManager transactionManager, System.Int32 categoryID, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryID(transactionManager, categoryID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Category key.
		///		fKSCProductCategorySCCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="categoryID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByCategoryID(System.Int32 categoryID, int start, int pageLength)
		{
			int count =  -1;
			return GetByCategoryID(null, categoryID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Category key.
		///		fKSCProductCategorySCCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="categoryID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByCategoryID(System.Int32 categoryID, int start, int pageLength,out int count)
		{
			return GetByCategoryID(null, categoryID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Category key.
		///		FK_SC_ProductCategory_SC_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByCategoryID(TransactionManager transactionManager, System.Int32 categoryID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Product key.
		///		FK_SC_ProductCategory_SC_Product Description: 
		/// </summary>
		/// <param name="productID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByProductID(System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(productID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Product key.
		///		FK_SC_ProductCategory_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByProductID(TransactionManager transactionManager, System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Product key.
		///		FK_SC_ProductCategory_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Product key.
		///		fKSCProductCategorySCProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByProductID(System.Int32 productID, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductID(null, productID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Product key.
		///		fKSCProductCategorySCProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByProductID(System.Int32 productID, int start, int pageLength,out int count)
		{
			return GetByProductID(null, productID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductCategory_SC_Product key.
		///		FK_SC_ProductCategory_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductCategory objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ProductCategory Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCategoryKey key, int start, int pageLength)
		{
			return GetByProductCategoryID(transactionManager, key.ProductCategoryID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProductCategory index.
		/// </summary>
		/// <param name="productCategoryID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCategory GetByProductCategoryID(System.Int32 productCategoryID)
		{
			int count = -1;
			return GetByProductCategoryID(null,productCategoryID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCategory index.
		/// </summary>
		/// <param name="productCategoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCategory GetByProductCategoryID(System.Int32 productCategoryID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductCategoryID(null, productCategoryID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCategoryID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCategory GetByProductCategoryID(TransactionManager transactionManager, System.Int32 productCategoryID)
		{
			int count = -1;
			return GetByProductCategoryID(transactionManager, productCategoryID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCategoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCategory GetByProductCategoryID(TransactionManager transactionManager, System.Int32 productCategoryID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductCategoryID(transactionManager, productCategoryID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCategory index.
		/// </summary>
		/// <param name="productCategoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductCategory GetByProductCategoryID(System.Int32 productCategoryID, int start, int pageLength, out int count)
		{
			return GetByProductCategoryID(null, productCategoryID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductCategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productCategoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ProductCategory GetByProductCategoryID(TransactionManager transactionManager, System.Int32 productCategoryID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ProductCategory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductCategory&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ProductCategory> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ProductCategory c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProductCategory" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProductCategoryID"))?(int)0:(System.Int32)reader["ProductCategoryID"]).ToString();

					c = EntityManager.LocateOrCreate<ProductCategory>(
						key.ToString(), // EntityTrackingKey 
						"ProductCategory",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ProductCategory();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProductCategoryID = (System.Int32)reader["ProductCategoryID"];
					c.ProductID = (System.Int32)reader["ProductID"];
					c.CategoryID = (System.Int32)reader["CategoryID"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ProductCategory entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductCategoryID = (System.Int32)reader["ProductCategoryID"];
			entity.ProductID = (System.Int32)reader["ProductID"];
			entity.CategoryID = (System.Int32)reader["CategoryID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ProductCategory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductCategoryID = (System.Int32)dataRow["ProductCategoryID"];
			entity.ProductID = (System.Int32)dataRow["ProductID"];
			entity.CategoryID = (System.Int32)dataRow["CategoryID"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductCategory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductCategory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCategory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region CategoryIDSource	
			if (CanDeepLoad(entity, "Category", "CategoryIDSource", deepLoadType, innerList) 
				&& entity.CategoryIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CategoryID;
				Category tmpEntity = EntityManager.LocateEntity<Category>(EntityLocator.ConstructKeyFromPkItems(typeof(Category), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CategoryIDSource = tmpEntity;
				else
					entity.CategoryIDSource = DataRepository.CategoryProvider.GetByCategoryID(entity.CategoryID);
			
				if (deep && entity.CategoryIDSource != null)
				{
					DataRepository.CategoryProvider.DeepLoad(transactionManager, entity.CategoryIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CategoryIDSource

			#region ProductIDSource	
			if (CanDeepLoad(entity, "Product", "ProductIDSource", deepLoadType, innerList) 
				&& entity.ProductIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductID;
				Product tmpEntity = EntityManager.LocateEntity<Product>(EntityLocator.ConstructKeyFromPkItems(typeof(Product), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductIDSource = tmpEntity;
				else
					entity.ProductIDSource = DataRepository.ProductProvider.GetByProductID(entity.ProductID);
			
				if (deep && entity.ProductIDSource != null)
				{
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProductIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ProductCategory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ProductCategory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductCategory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductCategory entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CategoryIDSource
			if (CanDeepSave(entity, "Category", "CategoryIDSource", deepSaveType, innerList) 
				&& entity.CategoryIDSource != null)
			{
				DataRepository.CategoryProvider.Save(transactionManager, entity.CategoryIDSource);
				entity.CategoryID = entity.CategoryIDSource.CategoryID;
			}
			#endregion 
			
			#region ProductIDSource
			if (CanDeepSave(entity, "Product", "ProductIDSource", deepSaveType, innerList) 
				&& entity.ProductIDSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductIDSource);
				entity.ProductID = entity.ProductIDSource.ProductID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductCategoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ProductCategory</c>
	///</summary>
	public enum ProductCategoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Category</c> at CategoryIDSource
		///</summary>
		[ChildEntityType(typeof(Category))]
		Category,
			
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIDSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
		}
	
	#endregion ProductCategoryChildEntityTypes
	
	#region ProductCategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCategoryFilterBuilder : SqlFilterBuilder<ProductCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCategoryFilterBuilder class.
		/// </summary>
		public ProductCategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCategoryFilterBuilder
	
	#region ProductCategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductCategoryParameterBuilder : ParameterizedSqlFilterBuilder<ProductCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductCategoryParameterBuilder class.
		/// </summary>
		public ProductCategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductCategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductCategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductCategoryParameterBuilder
} // end namespace
