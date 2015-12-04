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
	/// This class is the base class for any <see cref="OrderStateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderStateProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.OrderState, ZNode.Libraries.DataAccess.Entities.OrderStateKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderStateKey key)
		{
			return Delete(transactionManager, key.OrderStateID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="orderStateID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 orderStateID)
		{
			return Delete(null, orderStateID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStateID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 orderStateID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.OrderState Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderStateKey key, int start, int pageLength)
		{
			return GetByOrderStateID(transactionManager, key.OrderStateID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SC_OrderState_PK index.
		/// </summary>
		/// <param name="orderStateID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderState GetByOrderStateID(System.Int32 orderStateID)
		{
			int count = -1;
			return GetByOrderStateID(null,orderStateID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_PK index.
		/// </summary>
		/// <param name="orderStateID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderState GetByOrderStateID(System.Int32 orderStateID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStateID(null, orderStateID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStateID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderState GetByOrderStateID(TransactionManager transactionManager, System.Int32 orderStateID)
		{
			int count = -1;
			return GetByOrderStateID(transactionManager, orderStateID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStateID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderState GetByOrderStateID(TransactionManager transactionManager, System.Int32 orderStateID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStateID(transactionManager, orderStateID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_PK index.
		/// </summary>
		/// <param name="orderStateID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderState GetByOrderStateID(System.Int32 orderStateID, int start, int pageLength, out int count)
		{
			return GetByOrderStateID(null, orderStateID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStateID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.OrderState GetByOrderStateID(TransactionManager transactionManager, System.Int32 orderStateID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;OrderState&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;OrderState&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<OrderState> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<OrderState> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.OrderState c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"OrderState" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderStateID"))?(int)0:(System.Int32)reader["OrderStateID"]).ToString();

					c = EntityManager.LocateOrCreate<OrderState>(
						key.ToString(), // EntityTrackingKey 
						"OrderState",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.OrderState();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderStateID = (System.Int32)reader["OrderStateID"];
					c.OriginalOrderStateID = c.OrderStateID; //(reader.IsDBNull(reader.GetOrdinal("OrderStateID")))?(int)0:(System.Int32)reader["OrderStateID"];
					c.OrderStateName = (reader.IsDBNull(reader.GetOrdinal("OrderStateName")))?null:(System.String)reader["OrderStateName"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.OrderState entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderStateID = (System.Int32)reader["OrderStateID"];
			entity.OriginalOrderStateID = (System.Int32)reader["OrderStateID"];
			entity.OrderStateName = (reader.IsDBNull(reader.GetOrdinal("OrderStateName")))?null:(System.String)reader["OrderStateName"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.OrderState entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderStateID = (System.Int32)dataRow["OrderStateID"];
			entity.OriginalOrderStateID = (System.Int32)dataRow["OrderStateID"];
			entity.OrderStateName = (Convert.IsDBNull(dataRow["OrderStateName"]))?null:(System.String)dataRow["OrderStateName"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderState"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.OrderState Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderState entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByOrderStateID methods when available
			
			#region OrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Order>", "OrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderCollection' loaded.");
				#endif 

				entity.OrderCollection = DataRepository.OrderProvider.GetByOrderStateID(transactionManager, entity.OrderStateID);

				if (deep && entity.OrderCollection.Count > 0)
				{
					DataRepository.OrderProvider.DeepLoad(transactionManager, entity.OrderCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.OrderState object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.OrderState instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.OrderState Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderState entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<Order>
				if (CanDeepSave(entity, "List<Order>", "OrderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Order child in entity.OrderCollection)
					{
						child.OrderStateID = entity.OrderStateID;
					}
				
				if (entity.OrderCollection.Count > 0 || entity.OrderCollection.DeletedItems.Count > 0)
					DataRepository.OrderProvider.DeepSave(transactionManager, entity.OrderCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region OrderStateChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.OrderState</c>
	///</summary>
	public enum OrderStateChildEntityTypes
	{

		///<summary>
		/// Collection of <c>OrderState</c> as OneToMany for OrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<Order>))]
		OrderCollection,
	}
	
	#endregion OrderStateChildEntityTypes
	
	#region OrderStateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderState"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStateFilterBuilder : SqlFilterBuilder<OrderStateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStateFilterBuilder class.
		/// </summary>
		public OrderStateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStateFilterBuilder
	
	#region OrderStateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderState"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStateParameterBuilder : ParameterizedSqlFilterBuilder<OrderStateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStateParameterBuilder class.
		/// </summary>
		public OrderStateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStateParameterBuilder
} // end namespace
