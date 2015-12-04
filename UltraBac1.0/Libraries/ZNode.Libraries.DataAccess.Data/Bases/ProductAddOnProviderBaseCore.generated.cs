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
	/// This class is the base class for any <see cref="ProductAddOnProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductAddOnProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ProductAddOn, ZNode.Libraries.DataAccess.Entities.ProductAddOnKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAddOnKey key)
		{
			return Delete(transactionManager, key.ProductAddOnID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="productAddOnID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 productAddOnID)
		{
			return Delete(null, productAddOnID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAddOnID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 productAddOnID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeProduct key.
		///		FK_ZNodeProductAddOn_ZNodeProduct Description: 
		/// </summary>
		/// <param name="productID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByProductID(System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(productID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeProduct key.
		///		FK_ZNodeProductAddOn_ZNodeProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByProductID(TransactionManager transactionManager, System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeProduct key.
		///		FK_ZNodeProductAddOn_ZNodeProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeProduct key.
		///		fKZNodeProductAddOnZNodeProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByProductID(System.Int32 productID, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductID(null, productID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeProduct key.
		///		fKZNodeProductAddOnZNodeProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByProductID(System.Int32 productID, int start, int pageLength,out int count)
		{
			return GetByProductID(null, productID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeProduct key.
		///		FK_ZNodeProductAddOn_ZNodeProduct Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeAddOn key.
		///		FK_ZNodeProductAddOn_ZNodeAddOn Description: 
		/// </summary>
		/// <param name="addOnID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByAddOnID(System.Int32 addOnID)
		{
			int count = -1;
			return GetByAddOnID(addOnID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeAddOn key.
		///		FK_ZNodeProductAddOn_ZNodeAddOn Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID)
		{
			int count = -1;
			return GetByAddOnID(transactionManager, addOnID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeAddOn key.
		///		FK_ZNodeProductAddOn_ZNodeAddOn Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID, int start, int pageLength)
		{
			int count = -1;
			return GetByAddOnID(transactionManager, addOnID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeAddOn key.
		///		fKZNodeProductAddOnZNodeAddOn Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="addOnID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByAddOnID(System.Int32 addOnID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAddOnID(null, addOnID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeAddOn key.
		///		fKZNodeProductAddOnZNodeAddOn Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="addOnID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByAddOnID(System.Int32 addOnID, int start, int pageLength,out int count)
		{
			return GetByAddOnID(null, addOnID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOn_ZNodeAddOn key.
		///		FK_ZNodeProductAddOn_ZNodeAddOn Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductAddOn objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ProductAddOn Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAddOnKey key, int start, int pageLength)
		{
			return GetByProductAddOnID(transactionManager, key.ProductAddOnID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeProductAddOn_1 index.
		/// </summary>
		/// <param name="productAddOnID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAddOn GetByProductAddOnID(System.Int32 productAddOnID)
		{
			int count = -1;
			return GetByProductAddOnID(null,productAddOnID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn_1 index.
		/// </summary>
		/// <param name="productAddOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAddOn GetByProductAddOnID(System.Int32 productAddOnID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductAddOnID(null, productAddOnID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAddOnID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAddOn GetByProductAddOnID(TransactionManager transactionManager, System.Int32 productAddOnID)
		{
			int count = -1;
			return GetByProductAddOnID(transactionManager, productAddOnID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAddOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAddOn GetByProductAddOnID(TransactionManager transactionManager, System.Int32 productAddOnID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductAddOnID(transactionManager, productAddOnID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn_1 index.
		/// </summary>
		/// <param name="productAddOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductAddOn GetByProductAddOnID(System.Int32 productAddOnID, int start, int pageLength, out int count)
		{
			return GetByProductAddOnID(null, productAddOnID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productAddOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ProductAddOn GetByProductAddOnID(TransactionManager transactionManager, System.Int32 productAddOnID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAddOn&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductAddOn&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ProductAddOn> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ProductAddOn c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProductAddOn" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProductAddOnID"))?(int)0:(System.Int32)reader["ProductAddOnID"]).ToString();

					c = EntityManager.LocateOrCreate<ProductAddOn>(
						key.ToString(), // EntityTrackingKey 
						"ProductAddOn",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ProductAddOn();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProductAddOnID = (System.Int32)reader["ProductAddOnID"];
					c.ProductID = (System.Int32)reader["ProductID"];
					c.AddOnID = (System.Int32)reader["AddOnID"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ProductAddOn entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductAddOnID = (System.Int32)reader["ProductAddOnID"];
			entity.ProductID = (System.Int32)reader["ProductID"];
			entity.AddOnID = (System.Int32)reader["AddOnID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ProductAddOn entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductAddOnID = (System.Int32)dataRow["ProductAddOnID"];
			entity.ProductID = (System.Int32)dataRow["ProductID"];
			entity.AddOnID = (System.Int32)dataRow["AddOnID"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductAddOn"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductAddOn Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAddOn entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

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

			#region AddOnIDSource	
			if (CanDeepLoad(entity, "AddOn", "AddOnIDSource", deepLoadType, innerList) 
				&& entity.AddOnIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AddOnID;
				AddOn tmpEntity = EntityManager.LocateEntity<AddOn>(EntityLocator.ConstructKeyFromPkItems(typeof(AddOn), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AddOnIDSource = tmpEntity;
				else
					entity.AddOnIDSource = DataRepository.AddOnProvider.GetByAddOnID(entity.AddOnID);
			
				if (deep && entity.AddOnIDSource != null)
				{
					DataRepository.AddOnProvider.DeepLoad(transactionManager, entity.AddOnIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion AddOnIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ProductAddOn object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ProductAddOn instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductAddOn Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductAddOn entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ProductIDSource
			if (CanDeepSave(entity, "Product", "ProductIDSource", deepSaveType, innerList) 
				&& entity.ProductIDSource != null)
			{
				DataRepository.ProductProvider.Save(transactionManager, entity.ProductIDSource);
				entity.ProductID = entity.ProductIDSource.ProductID;
			}
			#endregion 
			
			#region AddOnIDSource
			if (CanDeepSave(entity, "AddOn", "AddOnIDSource", deepSaveType, innerList) 
				&& entity.AddOnIDSource != null)
			{
				DataRepository.AddOnProvider.Save(transactionManager, entity.AddOnIDSource);
				entity.AddOnID = entity.AddOnIDSource.AddOnID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ProductAddOnChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ProductAddOn</c>
	///</summary>
	public enum ProductAddOnChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIDSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
			
		///<summary>
		/// Composite Property for <c>AddOn</c> at AddOnIDSource
		///</summary>
		[ChildEntityType(typeof(AddOn))]
		AddOn,
		}
	
	#endregion ProductAddOnChildEntityTypes
	
	#region ProductAddOnFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductAddOn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductAddOnFilterBuilder : SqlFilterBuilder<ProductAddOnColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductAddOnFilterBuilder class.
		/// </summary>
		public ProductAddOnFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductAddOnFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductAddOnFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductAddOnFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductAddOnFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductAddOnFilterBuilder
	
	#region ProductAddOnParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductAddOn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductAddOnParameterBuilder : ParameterizedSqlFilterBuilder<ProductAddOnColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductAddOnParameterBuilder class.
		/// </summary>
		public ProductAddOnParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductAddOnParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductAddOnParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductAddOnParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductAddOnParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductAddOnParameterBuilder
} // end namespace
