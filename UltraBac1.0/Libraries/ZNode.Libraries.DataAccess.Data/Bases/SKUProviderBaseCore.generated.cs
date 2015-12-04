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
	/// This class is the base class for any <see cref="SKUProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SKUProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.SKU, ZNode.Libraries.DataAccess.Entities.SKUKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKUKey key)
		{
			return Delete(transactionManager, key.SKUID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="skuid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 skuid)
		{
			return Delete(null, skuid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="skuid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 skuid);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.SKU Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKUKey key, int start, int pageLength)
		{
			return GetBySKUID(transactionManager, key.SKUID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SC_SKU_PK index.
		/// </summary>
		/// <param name="skuid"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKU GetBySKUID(System.Int32 skuid)
		{
			int count = -1;
			return GetBySKUID(null,skuid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_SKU_PK index.
		/// </summary>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKU GetBySKUID(System.Int32 skuid, int start, int pageLength)
		{
			int count = -1;
			return GetBySKUID(null, skuid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_SKU_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="skuid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKU GetBySKUID(TransactionManager transactionManager, System.Int32 skuid)
		{
			int count = -1;
			return GetBySKUID(transactionManager, skuid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_SKU_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKU GetBySKUID(TransactionManager transactionManager, System.Int32 skuid, int start, int pageLength)
		{
			int count = -1;
			return GetBySKUID(transactionManager, skuid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_SKU_PK index.
		/// </summary>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.SKU GetBySKUID(System.Int32 skuid, int start, int pageLength, out int count)
		{
			return GetBySKUID(null, skuid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_SKU_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="skuid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.SKU GetBySKUID(TransactionManager transactionManager, System.Int32 skuid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ProductId index.
		/// </summary>
		/// <param name="productID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKU> GetByProductID(System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(null,productID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductId index.
		/// </summary>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKU> GetByProductID(System.Int32 productID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductID(null, productID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKU> GetByProductID(TransactionManager transactionManager, System.Int32 productID)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKU> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength)
		{
			int count = -1;
			return GetByProductID(transactionManager, productID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductId index.
		/// </summary>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<SKU> GetByProductID(System.Int32 productID, int start, int pageLength, out int count)
		{
			return GetByProductID(null, productID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ProductId index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="productID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<SKU> GetByProductID(TransactionManager transactionManager, System.Int32 productID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;SKU&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<SKU> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<SKU> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.SKU c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"SKU" 
							+ (reader.IsDBNull(reader.GetOrdinal("SKUID"))?(int)0:(System.Int32)reader["SKUID"]).ToString();

					c = EntityManager.LocateOrCreate<SKU>(
						key.ToString(), // EntityTrackingKey 
						"SKU",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.SKU();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.SKUID = (System.Int32)reader["SKUID"];
					c.ProductID = (System.Int32)reader["ProductID"];
					c.SKU = (reader.IsDBNull(reader.GetOrdinal("SKU")))?null:(System.String)reader["SKU"];
					c.WarehouseNo = (reader.IsDBNull(reader.GetOrdinal("WarehouseNo")))?null:(System.Int32?)reader["WarehouseNo"];
					c.Note = (reader.IsDBNull(reader.GetOrdinal("Note")))?null:(System.String)reader["Note"];
					c.QuantityOnHand = (System.Int32)reader["QuantityOnHand"];
					c.ReorderLevel = (reader.IsDBNull(reader.GetOrdinal("ReorderLevel")))?null:(System.Int32?)reader["ReorderLevel"];
					c.WeightAdditional = (reader.IsDBNull(reader.GetOrdinal("WeightAdditional")))?null:(System.Decimal?)reader["WeightAdditional"];
					c.SKUPicturePath = (reader.IsDBNull(reader.GetOrdinal("SKUPicturePath")))?null:(System.String)reader["SKUPicturePath"];
					c.DisplayOrder = (reader.IsDBNull(reader.GetOrdinal("DisplayOrder")))?null:(System.Int32?)reader["DisplayOrder"];
					c.RetailPriceAdditional = (reader.IsDBNull(reader.GetOrdinal("RetailPriceAdditional")))?null:(System.Decimal?)reader["RetailPriceAdditional"];
					c.WholesalePriceAdditional = (reader.IsDBNull(reader.GetOrdinal("WholesalePriceAdditional")))?null:(System.Decimal?)reader["WholesalePriceAdditional"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
					c.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
					c.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.SKU entity)
		{
			if (!reader.Read()) return;
			
			entity.SKUID = (System.Int32)reader["SKUID"];
			entity.ProductID = (System.Int32)reader["ProductID"];
			entity.SKU = (reader.IsDBNull(reader.GetOrdinal("SKU")))?null:(System.String)reader["SKU"];
			entity.WarehouseNo = (reader.IsDBNull(reader.GetOrdinal("WarehouseNo")))?null:(System.Int32?)reader["WarehouseNo"];
			entity.Note = (reader.IsDBNull(reader.GetOrdinal("Note")))?null:(System.String)reader["Note"];
			entity.QuantityOnHand = (System.Int32)reader["QuantityOnHand"];
			entity.ReorderLevel = (reader.IsDBNull(reader.GetOrdinal("ReorderLevel")))?null:(System.Int32?)reader["ReorderLevel"];
			entity.WeightAdditional = (reader.IsDBNull(reader.GetOrdinal("WeightAdditional")))?null:(System.Decimal?)reader["WeightAdditional"];
			entity.SKUPicturePath = (reader.IsDBNull(reader.GetOrdinal("SKUPicturePath")))?null:(System.String)reader["SKUPicturePath"];
			entity.DisplayOrder = (reader.IsDBNull(reader.GetOrdinal("DisplayOrder")))?null:(System.Int32?)reader["DisplayOrder"];
			entity.RetailPriceAdditional = (reader.IsDBNull(reader.GetOrdinal("RetailPriceAdditional")))?null:(System.Decimal?)reader["RetailPriceAdditional"];
			entity.WholesalePriceAdditional = (reader.IsDBNull(reader.GetOrdinal("WholesalePriceAdditional")))?null:(System.Decimal?)reader["WholesalePriceAdditional"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
			entity.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
			entity.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.SKU entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SKUID = (System.Int32)dataRow["SKUID"];
			entity.ProductID = (System.Int32)dataRow["ProductID"];
			entity.SKU = (Convert.IsDBNull(dataRow["SKU"]))?null:(System.String)dataRow["SKU"];
			entity.WarehouseNo = (Convert.IsDBNull(dataRow["WarehouseNo"]))?null:(System.Int32?)dataRow["WarehouseNo"];
			entity.Note = (Convert.IsDBNull(dataRow["Note"]))?null:(System.String)dataRow["Note"];
			entity.QuantityOnHand = (System.Int32)dataRow["QuantityOnHand"];
			entity.ReorderLevel = (Convert.IsDBNull(dataRow["ReorderLevel"]))?null:(System.Int32?)dataRow["ReorderLevel"];
			entity.WeightAdditional = (Convert.IsDBNull(dataRow["WeightAdditional"]))?null:(System.Decimal?)dataRow["WeightAdditional"];
			entity.SKUPicturePath = (Convert.IsDBNull(dataRow["SKUPicturePath"]))?null:(System.String)dataRow["SKUPicturePath"];
			entity.DisplayOrder = (Convert.IsDBNull(dataRow["DisplayOrder"]))?null:(System.Int32?)dataRow["DisplayOrder"];
			entity.RetailPriceAdditional = (Convert.IsDBNull(dataRow["RetailPriceAdditional"]))?null:(System.Decimal?)dataRow["RetailPriceAdditional"];
			entity.WholesalePriceAdditional = (Convert.IsDBNull(dataRow["WholesalePriceAdditional"]))?null:(System.Decimal?)dataRow["WholesalePriceAdditional"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
			entity.Custom1 = (Convert.IsDBNull(dataRow["Custom1"]))?null:(System.String)dataRow["Custom1"];
			entity.Custom2 = (Convert.IsDBNull(dataRow["Custom2"]))?null:(System.String)dataRow["Custom2"];
			entity.Custom3 = (Convert.IsDBNull(dataRow["Custom3"]))?null:(System.String)dataRow["Custom3"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.SKU"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.SKU Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKU entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetBySKUID methods when available
			
			#region SKUAttributeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SKUAttribute>", "SKUAttributeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'SKUAttributeCollection' loaded.");
				#endif 

				entity.SKUAttributeCollection = DataRepository.SKUAttributeProvider.GetBySKUID(transactionManager, entity.SKUID);

				if (deep && entity.SKUAttributeCollection.Count > 0)
				{
					DataRepository.SKUAttributeProvider.DeepLoad(transactionManager, entity.SKUAttributeCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.SKU object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.SKU instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.SKU Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.SKU entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<SKUAttribute>
				if (CanDeepSave(entity, "List<SKUAttribute>", "SKUAttributeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SKUAttribute child in entity.SKUAttributeCollection)
					{
						child.SKUID = entity.SKUID;
					}
				
				if (entity.SKUAttributeCollection.Count > 0 || entity.SKUAttributeCollection.DeletedItems.Count > 0)
					DataRepository.SKUAttributeProvider.DeepSave(transactionManager, entity.SKUAttributeCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region SKUChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.SKU</c>
	///</summary>
	public enum SKUChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Product</c> at ProductIDSource
		///</summary>
		[ChildEntityType(typeof(Product))]
		Product,
	
		///<summary>
		/// Collection of <c>SKU</c> as OneToMany for SKUAttributeCollection
		///</summary>
		[ChildEntityType(typeof(TList<SKUAttribute>))]
		SKUAttributeCollection,
	}
	
	#endregion SKUChildEntityTypes
	
	#region SKUFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SKU"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SKUFilterBuilder : SqlFilterBuilder<SKUColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SKUFilterBuilder class.
		/// </summary>
		public SKUFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SKUFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SKUFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SKUFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SKUFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SKUFilterBuilder
	
	#region SKUParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SKU"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SKUParameterBuilder : ParameterizedSqlFilterBuilder<SKUColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SKUParameterBuilder class.
		/// </summary>
		public SKUParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SKUParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SKUParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SKUParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SKUParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SKUParameterBuilder
} // end namespace
