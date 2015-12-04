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
	/// This class is the base class for any <see cref="ShippingRuleTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ShippingRuleTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ShippingRuleType, ZNode.Libraries.DataAccess.Entities.ShippingRuleTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRuleTypeKey key)
		{
			return Delete(transactionManager, key.ShippingRuleTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="shippingRuleTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 shippingRuleTypeID)
		{
			return Delete(null, shippingRuleTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 shippingRuleTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.ShippingRuleType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRuleTypeKey key, int start, int pageLength)
		{
			return GetByShippingRuleTypeID(transactionManager, key.ShippingRuleTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_ShippingRuleType index.
		/// </summary>
		/// <param name="shippingRuleTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRuleType GetByShippingRuleTypeID(System.Int32 shippingRuleTypeID)
		{
			int count = -1;
			return GetByShippingRuleTypeID(null,shippingRuleTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRuleType index.
		/// </summary>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRuleType GetByShippingRuleTypeID(System.Int32 shippingRuleTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingRuleTypeID(null, shippingRuleTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRuleType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRuleType GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32 shippingRuleTypeID)
		{
			int count = -1;
			return GetByShippingRuleTypeID(transactionManager, shippingRuleTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRuleType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRuleType GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32 shippingRuleTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingRuleTypeID(transactionManager, shippingRuleTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRuleType index.
		/// </summary>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRuleType GetByShippingRuleTypeID(System.Int32 shippingRuleTypeID, int start, int pageLength, out int count)
		{
			return GetByShippingRuleTypeID(null, shippingRuleTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRuleType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ShippingRuleType GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32 shippingRuleTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRuleType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRuleType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ShippingRuleType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ShippingRuleType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ShippingRuleType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ShippingRuleType" 
							+ (reader.IsDBNull(reader.GetOrdinal("ShippingRuleTypeID"))?(int)0:(System.Int32)reader["ShippingRuleTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<ShippingRuleType>(
						key.ToString(), // EntityTrackingKey 
						"ShippingRuleType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ShippingRuleType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ShippingRuleTypeID = (System.Int32)reader["ShippingRuleTypeID"];
					c.OriginalShippingRuleTypeID = c.ShippingRuleTypeID; //(reader.IsDBNull(reader.GetOrdinal("ShippingRuleTypeID")))?(int)0:(System.Int32)reader["ShippingRuleTypeID"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ShippingRuleType entity)
		{
			if (!reader.Read()) return;
			
			entity.ShippingRuleTypeID = (System.Int32)reader["ShippingRuleTypeID"];
			entity.OriginalShippingRuleTypeID = (System.Int32)reader["ShippingRuleTypeID"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ShippingRuleType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShippingRuleTypeID = (System.Int32)dataRow["ShippingRuleTypeID"];
			entity.OriginalShippingRuleTypeID = (System.Int32)dataRow["ShippingRuleTypeID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRuleType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingRuleType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRuleType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByShippingRuleTypeID methods when available
			
			#region ShippingRuleCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ShippingRule>", "ShippingRuleCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ShippingRuleCollection' loaded.");
				#endif 

				entity.ShippingRuleCollection = DataRepository.ShippingRuleProvider.GetByShippingRuleTypeID(transactionManager, entity.ShippingRuleTypeID);

				if (deep && entity.ShippingRuleCollection.Count > 0)
				{
					DataRepository.ShippingRuleProvider.DeepLoad(transactionManager, entity.ShippingRuleCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Product>", "ProductCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductCollection' loaded.");
				#endif 

				entity.ProductCollection = DataRepository.ProductProvider.GetByShippingRuleTypeID(transactionManager, entity.ShippingRuleTypeID);

				if (deep && entity.ProductCollection.Count > 0)
				{
					DataRepository.ProductProvider.DeepLoad(transactionManager, entity.ProductCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ShippingRuleType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ShippingRuleType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingRuleType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRuleType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





			#region List<ShippingRule>
				if (CanDeepSave(entity, "List<ShippingRule>", "ShippingRuleCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ShippingRule child in entity.ShippingRuleCollection)
					{
						child.ShippingRuleTypeID = entity.ShippingRuleTypeID;
					}
				
				if (entity.ShippingRuleCollection.Count > 0 || entity.ShippingRuleCollection.DeletedItems.Count > 0)
					DataRepository.ShippingRuleProvider.DeepSave(transactionManager, entity.ShippingRuleCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Product>
				if (CanDeepSave(entity, "List<Product>", "ProductCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Product child in entity.ProductCollection)
					{
						child.ShippingRuleTypeID = entity.ShippingRuleTypeID;
					}
				
				if (entity.ProductCollection.Count > 0 || entity.ProductCollection.DeletedItems.Count > 0)
					DataRepository.ProductProvider.DeepSave(transactionManager, entity.ProductCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region ShippingRuleTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ShippingRuleType</c>
	///</summary>
	public enum ShippingRuleTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ShippingRuleType</c> as OneToMany for ShippingRuleCollection
		///</summary>
		[ChildEntityType(typeof(TList<ShippingRule>))]
		ShippingRuleCollection,

		///<summary>
		/// Collection of <c>ShippingRuleType</c> as OneToMany for ProductCollection
		///</summary>
		[ChildEntityType(typeof(TList<Product>))]
		ProductCollection,
	}
	
	#endregion ShippingRuleTypeChildEntityTypes
	
	#region ShippingRuleTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingRuleType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingRuleTypeFilterBuilder : SqlFilterBuilder<ShippingRuleTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingRuleTypeFilterBuilder class.
		/// </summary>
		public ShippingRuleTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingRuleTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingRuleTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingRuleTypeFilterBuilder
	
	#region ShippingRuleTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingRuleType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingRuleTypeParameterBuilder : ParameterizedSqlFilterBuilder<ShippingRuleTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingRuleTypeParameterBuilder class.
		/// </summary>
		public ShippingRuleTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingRuleTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingRuleTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingRuleTypeParameterBuilder
} // end namespace
