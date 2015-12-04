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
	/// This class is the base class for any <see cref="ShippingTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ShippingTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ShippingType, ZNode.Libraries.DataAccess.Entities.ShippingTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingTypeKey key)
		{
			return Delete(transactionManager, key.ShippingTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="shippingTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 shippingTypeID)
		{
			return Delete(null, shippingTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 shippingTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.ShippingType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingTypeKey key, int start, int pageLength)
		{
			return GetByShippingTypeID(transactionManager, key.ShippingTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_ShippingType index.
		/// </summary>
		/// <param name="shippingTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingType GetByShippingTypeID(System.Int32 shippingTypeID)
		{
			int count = -1;
			return GetByShippingTypeID(null,shippingTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingType index.
		/// </summary>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingType GetByShippingTypeID(System.Int32 shippingTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingTypeID(null, shippingTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingType GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID)
		{
			int count = -1;
			return GetByShippingTypeID(transactionManager, shippingTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingType GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingTypeID(transactionManager, shippingTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingType index.
		/// </summary>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingType GetByShippingTypeID(System.Int32 shippingTypeID, int start, int pageLength, out int count)
		{
			return GetByShippingTypeID(null, shippingTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ShippingType GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ShippingType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ShippingType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ShippingType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ShippingType" 
							+ (reader.IsDBNull(reader.GetOrdinal("ShippingTypeID"))?(int)0:(System.Int32)reader["ShippingTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<ShippingType>(
						key.ToString(), // EntityTrackingKey 
						"ShippingType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ShippingType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ShippingTypeID = (System.Int32)reader["ShippingTypeID"];
					c.OriginalShippingTypeID = c.ShippingTypeID; //(reader.IsDBNull(reader.GetOrdinal("ShippingTypeID")))?(int)0:(System.Int32)reader["ShippingTypeID"];
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
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ShippingType entity)
		{
			if (!reader.Read()) return;
			
			entity.ShippingTypeID = (System.Int32)reader["ShippingTypeID"];
			entity.OriginalShippingTypeID = (System.Int32)reader["ShippingTypeID"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ShippingType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShippingTypeID = (System.Int32)dataRow["ShippingTypeID"];
			entity.OriginalShippingTypeID = (System.Int32)dataRow["ShippingTypeID"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByShippingTypeID methods when available
			
			#region ShippingServiceCodeCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ShippingServiceCode>", "ShippingServiceCodeCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ShippingServiceCodeCollection' loaded.");
				#endif 

				entity.ShippingServiceCodeCollection = DataRepository.ShippingServiceCodeProvider.GetByShippingTypeID(transactionManager, entity.ShippingTypeID);

				if (deep && entity.ShippingServiceCodeCollection.Count > 0)
				{
					DataRepository.ShippingServiceCodeProvider.DeepLoad(transactionManager, entity.ShippingServiceCodeCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ShippingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Shipping>", "ShippingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ShippingCollection' loaded.");
				#endif 

				entity.ShippingCollection = DataRepository.ShippingProvider.GetByShippingTypeID(transactionManager, entity.ShippingTypeID);

				if (deep && entity.ShippingCollection.Count > 0)
				{
					DataRepository.ShippingProvider.DeepLoad(transactionManager, entity.ShippingCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ShippingType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ShippingType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





			#region List<ShippingServiceCode>
				if (CanDeepSave(entity, "List<ShippingServiceCode>", "ShippingServiceCodeCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ShippingServiceCode child in entity.ShippingServiceCodeCollection)
					{
						child.ShippingTypeID = entity.ShippingTypeID;
					}
				
				if (entity.ShippingServiceCodeCollection.Count > 0 || entity.ShippingServiceCodeCollection.DeletedItems.Count > 0)
					DataRepository.ShippingServiceCodeProvider.DeepSave(transactionManager, entity.ShippingServiceCodeCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Shipping>
				if (CanDeepSave(entity, "List<Shipping>", "ShippingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Shipping child in entity.ShippingCollection)
					{
						child.ShippingTypeID = entity.ShippingTypeID;
					}
				
				if (entity.ShippingCollection.Count > 0 || entity.ShippingCollection.DeletedItems.Count > 0)
					DataRepository.ShippingProvider.DeepSave(transactionManager, entity.ShippingCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region ShippingTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ShippingType</c>
	///</summary>
	public enum ShippingTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ShippingType</c> as OneToMany for ShippingServiceCodeCollection
		///</summary>
		[ChildEntityType(typeof(TList<ShippingServiceCode>))]
		ShippingServiceCodeCollection,

		///<summary>
		/// Collection of <c>ShippingType</c> as OneToMany for ShippingCollection
		///</summary>
		[ChildEntityType(typeof(TList<Shipping>))]
		ShippingCollection,
	}
	
	#endregion ShippingTypeChildEntityTypes
	
	#region ShippingTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingTypeFilterBuilder : SqlFilterBuilder<ShippingTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingTypeFilterBuilder class.
		/// </summary>
		public ShippingTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingTypeFilterBuilder
	
	#region ShippingTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingTypeParameterBuilder : ParameterizedSqlFilterBuilder<ShippingTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingTypeParameterBuilder class.
		/// </summary>
		public ShippingTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingTypeParameterBuilder
} // end namespace
