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
	/// This class is the base class for any <see cref="OrderProcessingTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderProcessingTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.OrderProcessingType, ZNode.Libraries.DataAccess.Entities.OrderProcessingTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderProcessingTypeKey key)
		{
			return Delete(transactionManager, key.OrderProcessingTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="orderProcessingTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 orderProcessingTypeID)
		{
			return Delete(null, orderProcessingTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderProcessingTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 orderProcessingTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.OrderProcessingType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderProcessingTypeKey key, int start, int pageLength)
		{
			return GetByOrderProcessingTypeID(transactionManager, key.OrderProcessingTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_OrderProcessingType index.
		/// </summary>
		/// <param name="orderProcessingTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderProcessingType GetByOrderProcessingTypeID(System.Int32 orderProcessingTypeID)
		{
			int count = -1;
			return GetByOrderProcessingTypeID(null,orderProcessingTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderProcessingType index.
		/// </summary>
		/// <param name="orderProcessingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderProcessingType GetByOrderProcessingTypeID(System.Int32 orderProcessingTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderProcessingTypeID(null, orderProcessingTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderProcessingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderProcessingTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderProcessingType GetByOrderProcessingTypeID(TransactionManager transactionManager, System.Int32 orderProcessingTypeID)
		{
			int count = -1;
			return GetByOrderProcessingTypeID(transactionManager, orderProcessingTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderProcessingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderProcessingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderProcessingType GetByOrderProcessingTypeID(TransactionManager transactionManager, System.Int32 orderProcessingTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderProcessingTypeID(transactionManager, orderProcessingTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderProcessingType index.
		/// </summary>
		/// <param name="orderProcessingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.OrderProcessingType GetByOrderProcessingTypeID(System.Int32 orderProcessingTypeID, int start, int pageLength, out int count)
		{
			return GetByOrderProcessingTypeID(null, orderProcessingTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderProcessingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderProcessingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.OrderProcessingType GetByOrderProcessingTypeID(TransactionManager transactionManager, System.Int32 orderProcessingTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;OrderProcessingType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;OrderProcessingType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<OrderProcessingType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<OrderProcessingType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.OrderProcessingType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"OrderProcessingType" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderProcessingTypeID"))?(int)0:(System.Int32)reader["OrderProcessingTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<OrderProcessingType>(
						key.ToString(), // EntityTrackingKey 
						"OrderProcessingType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.OrderProcessingType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderProcessingTypeID = (System.Int32)reader["OrderProcessingTypeID"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.ClassID = (reader.IsDBNull(reader.GetOrdinal("ClassID")))?null:(System.String)reader["ClassID"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.OrderProcessingType entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderProcessingTypeID = (System.Int32)reader["OrderProcessingTypeID"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.ClassID = (reader.IsDBNull(reader.GetOrdinal("ClassID")))?null:(System.String)reader["ClassID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.OrderProcessingType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderProcessingTypeID = (System.Int32)dataRow["OrderProcessingTypeID"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.ClassID = (Convert.IsDBNull(dataRow["ClassID"]))?null:(System.String)dataRow["ClassID"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.OrderProcessingType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.OrderProcessingType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderProcessingType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.OrderProcessingType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.OrderProcessingType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.OrderProcessingType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderProcessingType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region OrderProcessingTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.OrderProcessingType</c>
	///</summary>
	public enum OrderProcessingTypeChildEntityTypes
	{
	}
	
	#endregion OrderProcessingTypeChildEntityTypes
	
	#region OrderProcessingTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderProcessingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderProcessingTypeFilterBuilder : SqlFilterBuilder<OrderProcessingTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeFilterBuilder class.
		/// </summary>
		public OrderProcessingTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderProcessingTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderProcessingTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderProcessingTypeFilterBuilder
	
	#region OrderProcessingTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderProcessingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderProcessingTypeParameterBuilder : ParameterizedSqlFilterBuilder<OrderProcessingTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeParameterBuilder class.
		/// </summary>
		public OrderProcessingTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderProcessingTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderProcessingTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderProcessingTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderProcessingTypeParameterBuilder
} // end namespace
