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
	/// This class is the base class for any <see cref="OrderLineItemProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderLineItemProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.OrderLineItem, ZNode.Libraries.DataAccess.Entities.OrderLineItemKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderLineItemKey key)
		{
			return Delete(transactionManager, key.OrderLineItemID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="orderLineItemID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 orderLineItemID)
		{
			return Delete(null, orderLineItemID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderLineItemID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 orderLineItemID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrderLineItem_ZNodeOrderLineItem key.
		///		FK_ZNodeOrderLineItem_ZNodeOrderLineItem Description: 
		/// </summary>
		/// <param name="parentOrderLineItemID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByParentOrderLineItemID(System.Int32? parentOrderLineItemID)
		{
			int count = -1;
			return GetByParentOrderLineItemID(parentOrderLineItemID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrderLineItem_ZNodeOrderLineItem key.
		///		FK_ZNodeOrderLineItem_ZNodeOrderLineItem Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentOrderLineItemID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByParentOrderLineItemID(TransactionManager transactionManager, System.Int32? parentOrderLineItemID)
		{
			int count = -1;
			return GetByParentOrderLineItemID(transactionManager, parentOrderLineItemID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrderLineItem_ZNodeOrderLineItem key.
		///		FK_ZNodeOrderLineItem_ZNodeOrderLineItem Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentOrderLineItemID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByParentOrderLineItemID(TransactionManager transactionManager, System.Int32? parentOrderLineItemID, int start, int pageLength)
		{
			int count = -1;
			return GetByParentOrderLineItemID(transactionManager, parentOrderLineItemID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrderLineItem_ZNodeOrderLineItem key.
		///		fKZNodeOrderLineItemZNodeOrderLineItem Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="parentOrderLineItemID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByParentOrderLineItemID(System.Int32? parentOrderLineItemID, int start, int pageLength)
		{
			int count =  -1;
			return GetByParentOrderLineItemID(null, parentOrderLineItemID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrderLineItem_ZNodeOrderLineItem key.
		///		fKZNodeOrderLineItemZNodeOrderLineItem Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="parentOrderLineItemID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByParentOrderLineItemID(System.Int32? parentOrderLineItemID, int start, int pageLength,out int count)
		{
			return GetByParentOrderLineItemID(null, parentOrderLineItemID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrderLineItem_ZNodeOrderLineItem key.
		///		FK_ZNodeOrderLineItem_ZNodeOrderLineItem Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentOrderLineItemID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByParentOrderLineItemID(TransactionManager transactionManager, System.Int32? parentOrderLineItemID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_OrderLineItem_SC_Order key.
		///		FK_SC_OrderLineItem_SC_Order Description: 
		/// </summary>
		/// <param name="orderID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByOrderID(System.Int32 orderID)
		{
			int count = -1;
			return GetByOrderID(orderID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_OrderLineItem_SC_Order key.
		///		FK_SC_OrderLineItem_SC_Order Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByOrderID(TransactionManager transactionManager, System.Int32 orderID)
		{
			int count = -1;
			return GetByOrderID(transactionManager, orderID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_OrderLineItem_SC_Order key.
		///		FK_SC_OrderLineItem_SC_Order Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByOrderID(TransactionManager transactionManager, System.Int32 orderID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderID(transactionManager, orderID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_OrderLineItem_SC_Order key.
		///		fKSCOrderLineItemSCOrder Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByOrderID(System.Int32 orderID, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderID(null, orderID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_OrderLineItem_SC_Order key.
		///		fKSCOrderLineItemSCOrder Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByOrderID(System.Int32 orderID, int start, int pageLength,out int count)
		{
			return GetByOrderID(null, orderID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_OrderLineItem_SC_Order key.
		///		FK_SC_OrderLineItem_SC_Order Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.OrderLineItem objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> GetByOrderID(TransactionManager transactionManager, System.Int32 orderID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.OrderLineItem Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderLineItemKey key, int start, int pageLength)
		{
			return GetByOrderLineItemID(transactionManager, key.OrderLineItemID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SC_OrderLineItem_PK index.
		/// </summary>
		/// <param name="orderLineItemID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderLineItem GetByOrderLineItemID(System.Int32 orderLineItemID)
		{
			int count = -1;
			return GetByOrderLineItemID(null,orderLineItemID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderLineItem_PK index.
		/// </summary>
		/// <param name="orderLineItemID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderLineItem GetByOrderLineItemID(System.Int32 orderLineItemID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderLineItemID(null, orderLineItemID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderLineItem_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderLineItemID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderLineItem GetByOrderLineItemID(TransactionManager transactionManager, System.Int32 orderLineItemID)
		{
			int count = -1;
			return GetByOrderLineItemID(transactionManager, orderLineItemID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderLineItem_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderLineItemID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderLineItem GetByOrderLineItemID(TransactionManager transactionManager, System.Int32 orderLineItemID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderLineItemID(transactionManager, orderLineItemID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderLineItem_PK index.
		/// </summary>
		/// <param name="orderLineItemID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderLineItem GetByOrderLineItemID(System.Int32 orderLineItemID, int start, int pageLength, out int count)
		{
			return GetByOrderLineItemID(null, orderLineItemID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderLineItem_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderLineItemID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.OrderLineItem GetByOrderLineItemID(TransactionManager transactionManager, System.Int32 orderLineItemID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;OrderLineItem&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;OrderLineItem&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<OrderLineItem> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.OrderLineItem c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"OrderLineItem" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderLineItemID"))?(int)0:(System.Int32)reader["OrderLineItemID"]).ToString();

					c = EntityManager.LocateOrCreate<OrderLineItem>(
						key.ToString(), // EntityTrackingKey 
						"OrderLineItem",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.OrderLineItem();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderLineItemID = (System.Int32)reader["OrderLineItemID"];
					c.OrderID = (System.Int32)reader["OrderID"];
					c.ShipmentID = (reader.IsDBNull(reader.GetOrdinal("ShipmentID")))?null:(System.Int32?)reader["ShipmentID"];
					c.ProductNum = (reader.IsDBNull(reader.GetOrdinal("ProductNum")))?null:(System.String)reader["ProductNum"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.Quantity = (reader.IsDBNull(reader.GetOrdinal("Quantity")))?null:(System.Int32?)reader["Quantity"];
					c.Price = (reader.IsDBNull(reader.GetOrdinal("Price")))?null:(System.Decimal?)reader["Price"];
					c.Weight = (reader.IsDBNull(reader.GetOrdinal("Weight")))?null:(System.Decimal?)reader["Weight"];
					c.PrePromoPrice = (reader.IsDBNull(reader.GetOrdinal("PrePromoPrice")))?null:(System.Decimal?)reader["PrePromoPrice"];
					c.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
					c.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
					c.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
					c.SKU = (reader.IsDBNull(reader.GetOrdinal("SKU")))?null:(System.String)reader["SKU"];
					c.ParentOrderLineItemID = (reader.IsDBNull(reader.GetOrdinal("ParentOrderLineItemID")))?null:(System.Int32?)reader["ParentOrderLineItemID"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.OrderLineItem entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderLineItemID = (System.Int32)reader["OrderLineItemID"];
			entity.OrderID = (System.Int32)reader["OrderID"];
			entity.ShipmentID = (reader.IsDBNull(reader.GetOrdinal("ShipmentID")))?null:(System.Int32?)reader["ShipmentID"];
			entity.ProductNum = (reader.IsDBNull(reader.GetOrdinal("ProductNum")))?null:(System.String)reader["ProductNum"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.Quantity = (reader.IsDBNull(reader.GetOrdinal("Quantity")))?null:(System.Int32?)reader["Quantity"];
			entity.Price = (reader.IsDBNull(reader.GetOrdinal("Price")))?null:(System.Decimal?)reader["Price"];
			entity.Weight = (reader.IsDBNull(reader.GetOrdinal("Weight")))?null:(System.Decimal?)reader["Weight"];
			entity.PrePromoPrice = (reader.IsDBNull(reader.GetOrdinal("PrePromoPrice")))?null:(System.Decimal?)reader["PrePromoPrice"];
			entity.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
			entity.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
			entity.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
			entity.SKU = (reader.IsDBNull(reader.GetOrdinal("SKU")))?null:(System.String)reader["SKU"];
			entity.ParentOrderLineItemID = (reader.IsDBNull(reader.GetOrdinal("ParentOrderLineItemID")))?null:(System.Int32?)reader["ParentOrderLineItemID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.OrderLineItem entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderLineItemID = (System.Int32)dataRow["OrderLineItemID"];
			entity.OrderID = (System.Int32)dataRow["OrderID"];
			entity.ShipmentID = (Convert.IsDBNull(dataRow["ShipmentID"]))?null:(System.Int32?)dataRow["ShipmentID"];
			entity.ProductNum = (Convert.IsDBNull(dataRow["ProductNum"]))?null:(System.String)dataRow["ProductNum"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.Quantity = (Convert.IsDBNull(dataRow["Quantity"]))?null:(System.Int32?)dataRow["Quantity"];
			entity.Price = (Convert.IsDBNull(dataRow["Price"]))?null:(System.Decimal?)dataRow["Price"];
			entity.Weight = (Convert.IsDBNull(dataRow["Weight"]))?null:(System.Decimal?)dataRow["Weight"];
			entity.PrePromoPrice = (Convert.IsDBNull(dataRow["PrePromoPrice"]))?null:(System.Decimal?)dataRow["PrePromoPrice"];
			entity.Custom1 = (Convert.IsDBNull(dataRow["Custom1"]))?null:(System.String)dataRow["Custom1"];
			entity.Custom2 = (Convert.IsDBNull(dataRow["Custom2"]))?null:(System.String)dataRow["Custom2"];
			entity.Custom3 = (Convert.IsDBNull(dataRow["Custom3"]))?null:(System.String)dataRow["Custom3"];
			entity.SKU = (Convert.IsDBNull(dataRow["SKU"]))?null:(System.String)dataRow["SKU"];
			entity.ParentOrderLineItemID = (Convert.IsDBNull(dataRow["ParentOrderLineItemID"]))?null:(System.Int32?)dataRow["ParentOrderLineItemID"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderLineItem"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.OrderLineItem Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderLineItem entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ParentOrderLineItemIDSource	
			if (CanDeepLoad(entity, "OrderLineItem", "ParentOrderLineItemIDSource", deepLoadType, innerList) 
				&& entity.ParentOrderLineItemIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ParentOrderLineItemID ?? (int)0);
				OrderLineItem tmpEntity = EntityManager.LocateEntity<OrderLineItem>(EntityLocator.ConstructKeyFromPkItems(typeof(OrderLineItem), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ParentOrderLineItemIDSource = tmpEntity;
				else
					entity.ParentOrderLineItemIDSource = DataRepository.OrderLineItemProvider.GetByOrderLineItemID((entity.ParentOrderLineItemID ?? (int)0));
			
				if (deep && entity.ParentOrderLineItemIDSource != null)
				{
					DataRepository.OrderLineItemProvider.DeepLoad(transactionManager, entity.ParentOrderLineItemIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ParentOrderLineItemIDSource

			#region OrderIDSource	
			if (CanDeepLoad(entity, "Order", "OrderIDSource", deepLoadType, innerList) 
				&& entity.OrderIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OrderID;
				Order tmpEntity = EntityManager.LocateEntity<Order>(EntityLocator.ConstructKeyFromPkItems(typeof(Order), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderIDSource = tmpEntity;
				else
					entity.OrderIDSource = DataRepository.OrderProvider.GetByOrderID(entity.OrderID);
			
				if (deep && entity.OrderIDSource != null)
				{
					DataRepository.OrderProvider.DeepLoad(transactionManager, entity.OrderIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion OrderIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByOrderLineItemID methods when available
			
			#region OrderLineItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderLineItem>", "OrderLineItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderLineItemCollection' loaded.");
				#endif 

				entity.OrderLineItemCollection = DataRepository.OrderLineItemProvider.GetByParentOrderLineItemID(transactionManager, entity.OrderLineItemID);

				if (deep && entity.OrderLineItemCollection.Count > 0)
				{
					DataRepository.OrderLineItemProvider.DeepLoad(transactionManager, entity.OrderLineItemCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.OrderLineItem object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.OrderLineItem instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.OrderLineItem Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderLineItem entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ParentOrderLineItemIDSource
			if (CanDeepSave(entity, "OrderLineItem", "ParentOrderLineItemIDSource", deepSaveType, innerList) 
				&& entity.ParentOrderLineItemIDSource != null)
			{
				DataRepository.OrderLineItemProvider.Save(transactionManager, entity.ParentOrderLineItemIDSource);
				entity.ParentOrderLineItemID = entity.ParentOrderLineItemIDSource.OrderLineItemID;
			}
			#endregion 
			
			#region OrderIDSource
			if (CanDeepSave(entity, "Order", "OrderIDSource", deepSaveType, innerList) 
				&& entity.OrderIDSource != null)
			{
				DataRepository.OrderProvider.Save(transactionManager, entity.OrderIDSource);
				entity.OrderID = entity.OrderIDSource.OrderID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<OrderLineItem>
				if (CanDeepSave(entity, "List<OrderLineItem>", "OrderLineItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(OrderLineItem child in entity.OrderLineItemCollection)
					{
						child.ParentOrderLineItemID = entity.OrderLineItemID;
					}
				
				if (entity.OrderLineItemCollection.Count > 0 || entity.OrderLineItemCollection.DeletedItems.Count > 0)
					DataRepository.OrderLineItemProvider.DeepSave(transactionManager, entity.OrderLineItemCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region OrderLineItemChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.OrderLineItem</c>
	///</summary>
	public enum OrderLineItemChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>OrderLineItem</c> at ParentOrderLineItemIDSource
		///</summary>
		[ChildEntityType(typeof(OrderLineItem))]
		OrderLineItem,
			
		///<summary>
		/// Composite Property for <c>Order</c> at OrderIDSource
		///</summary>
		[ChildEntityType(typeof(Order))]
		Order,
	
		///<summary>
		/// Collection of <c>OrderLineItem</c> as OneToMany for OrderLineItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderLineItem>))]
		OrderLineItemCollection,
	}
	
	#endregion OrderLineItemChildEntityTypes
	
	#region OrderLineItemFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderLineItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderLineItemFilterBuilder : SqlFilterBuilder<OrderLineItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderLineItemFilterBuilder class.
		/// </summary>
		public OrderLineItemFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderLineItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderLineItemFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderLineItemFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderLineItemFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderLineItemFilterBuilder
	
	#region OrderLineItemParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderLineItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderLineItemParameterBuilder : ParameterizedSqlFilterBuilder<OrderLineItemColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderLineItemParameterBuilder class.
		/// </summary>
		public OrderLineItemParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderLineItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderLineItemParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderLineItemParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderLineItemParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderLineItemParameterBuilder
} // end namespace
