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
	/// This class is the base class for any <see cref="ProductHighlightProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductHighlightProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ProductHighlight, ZNode.Libraries.DataAccess.Entities.ProductHighlightKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductHighlightKey key)
		{
			return Delete(transactionManager, key.ProductHighlightID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="productHighlightID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 productHighlightID)
		{
			return Delete(null, productHighlightID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productHighlightID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 productHighlightID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Highlight key.
		///		FK_SC_ProductHighlight_SC_Highlight Description: 
		/// </summary>
		/// <param name="highlightID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByHighlightID(System.Int32 highlightID)
		{
			int count = -1;
			return GetByHighlightID(highlightID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Highlight key.
		///		FK_SC_ProductHighlight_SC_Highlight Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="highlightID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByHighlightID(TransactionManager transactionManager, System.Int32 highlightID)
		{
			int count = -1;
			return GetByHighlightID(transactionManager, highlightID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Highlight key.
		///		FK_SC_ProductHighlight_SC_Highlight Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="highlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByHighlightID(TransactionManager transactionManager, System.Int32 highlightID, int start, int pageLength)
		{
			int count = -1;
			return GetByHighlightID(transactionManager, highlightID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Highlight key.
		///		fKSCProductHighlightSCHighlight Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="highlightID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByHighlightID(System.Int32 highlightID, int start, int pageLength)
		{
			int count =  -1;
			return GetByHighlightID(null, highlightID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Highlight key.
		///		fKSCProductHighlightSCHighlight Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="highlightID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByHighlightID(System.Int32 highlightID, int start, int pageLength,out int count)
		{
			return GetByHighlightID(null, highlightID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Highlight key.
		///		FK_SC_ProductHighlight_SC_Highlight Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="highlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByHighlightID(TransactionManager transactionManager, System.Int32 highlightID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Product key.
		///		FK_SC_ProductHighlight_SC_Product Description: 
		/// </summary>
		/// <param name="productID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByProductID(System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(productID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Product key.
		///		FK_SC_ProductHighlight_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByProductID(TransactionManager transactionManager, System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Product key.
		///		FK_SC_ProductHighlight_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Product key.
		///		fKSCProductHighlightSCProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByProductID(System.Int32 productID, int start, int pageLength)
		{
			int count =  -1;
			return GetByProductID(null, productID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Product key.
		///		fKSCProductHighlightSCProduct Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="productID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByProductID(System.Int32 productID, int start, int pageLength,out int count)
		{
			return GetByProductID(null, productID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ProductHighlight_SC_Product key.
		///		FK_SC_ProductHighlight_SC_Product Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ProductHighlight objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ProductHighlight Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductHighlightKey key, int start, int pageLength)
		{
			return GetByProductHighlightID(transactionManager, key.ProductHighlightID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_ProductHighlight index.
		/// </summary>
		/// <param name="productHighlightID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductHighlight GetByProductHighlightID(System.Int32 productHighlightID)
		{
			int count = -1;
			return GetByProductHighlightID(null,productHighlightID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductHighlight index.
		/// </summary>
		/// <param name="productHighlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductHighlight GetByProductHighlightID(System.Int32 productHighlightID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductHighlightID(null, productHighlightID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductHighlight index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productHighlightID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductHighlight GetByProductHighlightID(TransactionManager transactionManager, System.Int32 productHighlightID)
		{
			int count = -1;
			return GetByProductHighlightID(transactionManager, productHighlightID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductHighlight index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productHighlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductHighlight GetByProductHighlightID(TransactionManager transactionManager, System.Int32 productHighlightID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductHighlightID(transactionManager, productHighlightID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductHighlight index.
		/// </summary>
		/// <param name="productHighlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ProductHighlight GetByProductHighlightID(System.Int32 productHighlightID, int start, int pageLength, out int count)
		{
			return GetByProductHighlightID(null, productHighlightID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ProductHighlight index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productHighlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ProductHighlight GetByProductHighlightID(TransactionManager transactionManager, System.Int32 productHighlightID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ProductHighlight&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ProductHighlight&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ProductHighlight> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ProductHighlight c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ProductHighlight" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProductHighlightID"))?(int)0:(System.Int32)reader["ProductHighlightID"]).ToString();

					c = EntityManager.LocateOrCreate<ProductHighlight>(
						key.ToString(), // EntityTrackingKey 
						"ProductHighlight",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ProductHighlight();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProductHighlightID = (System.Int32)reader["ProductHighlightID"];
					c.OriginalProductHighlightID = c.ProductHighlightID; //(reader.IsDBNull(reader.GetOrdinal("ProductHighlightID")))?(int)0:(System.Int32)reader["ProductHighlightID"];
					c.ProductID = (System.Int32)reader["ProductID"];
					c.HighlightID = (System.Int32)reader["HighlightID"];
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
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ProductHighlight entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductHighlightID = (System.Int32)reader["ProductHighlightID"];
			entity.OriginalProductHighlightID = (System.Int32)reader["ProductHighlightID"];
			entity.ProductID = (System.Int32)reader["ProductID"];
			entity.HighlightID = (System.Int32)reader["HighlightID"];
			entity.DisplayOrder = (reader.IsDBNull(reader.GetOrdinal("DisplayOrder")))?null:(System.Int32?)reader["DisplayOrder"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ProductHighlight entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductHighlightID = (System.Int32)dataRow["ProductHighlightID"];
			entity.OriginalProductHighlightID = (System.Int32)dataRow["ProductHighlightID"];
			entity.ProductID = (System.Int32)dataRow["ProductID"];
			entity.HighlightID = (System.Int32)dataRow["HighlightID"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ProductHighlight"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductHighlight Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductHighlight entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region HighlightIDSource	
			if (CanDeepLoad(entity, "Highlight", "HighlightIDSource", deepLoadType, innerList) 
				&& entity.HighlightIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.HighlightID;
				Highlight tmpEntity = EntityManager.LocateEntity<Highlight>(EntityLocator.ConstructKeyFromPkItems(typeof(Highlight), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.HighlightIDSource = tmpEntity;
				else
					entity.HighlightIDSource = DataRepository.HighlightProvider.GetByHighlightID(entity.HighlightID);
			
				if (deep && entity.HighlightIDSource != null)
				{
					DataRepository.HighlightProvider.DeepLoad(transactionManager, entity.HighlightIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion HighlightIDSource

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
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ProductHighlight object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ProductHighlight instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ProductHighlight Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProductHighlight entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region HighlightIDSource
			if (CanDeepSave(entity, "Highlight", "HighlightIDSource", deepSaveType, innerList) 
				&& entity.HighlightIDSource != null)
			{
				DataRepository.HighlightProvider.Save(transactionManager, entity.HighlightIDSource);
				entity.HighlightID = entity.HighlightIDSource.HighlightID;
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
	
	#region ProductHighlightChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ProductHighlight</c>
	///</summary>
	public enum ProductHighlightChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Highlight</c> at HighlightIDSource
		///</summary>
		[ChildEntityType(typeof(Highlight))]
		Highlight,
			
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIDSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
		}
	
	#endregion ProductHighlightChildEntityTypes
	
	#region ProductHighlightFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductHighlight"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductHighlightFilterBuilder : SqlFilterBuilder<ProductHighlightColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductHighlightFilterBuilder class.
		/// </summary>
		public ProductHighlightFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductHighlightFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductHighlightFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductHighlightFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductHighlightFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductHighlightFilterBuilder
	
	#region ProductHighlightParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductHighlight"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductHighlightParameterBuilder : ParameterizedSqlFilterBuilder<ProductHighlightColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductHighlightParameterBuilder class.
		/// </summary>
		public ProductHighlightParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductHighlightParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductHighlightParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductHighlightParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductHighlightParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductHighlightParameterBuilder
} // end namespace
