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
	/// This class is the base class for any <see cref="ShippingServiceCodeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ShippingServiceCodeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ShippingServiceCode, ZNode.Libraries.DataAccess.Entities.ShippingServiceCodeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingServiceCodeKey key)
		{
			return Delete(transactionManager, key.ShippingServiceCodeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="shippingServiceCodeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 shippingServiceCodeID)
		{
			return Delete(null, shippingServiceCodeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingServiceCodeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 shippingServiceCodeID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShippingServiceCode_ZNodeShippingType key.
		///		FK_ZNodeShippingServiceCode_ZNodeShippingType Description: 
		/// </summary>
		/// <param name="shippingTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingServiceCode objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> GetByShippingTypeID(System.Int32 shippingTypeID)
		{
			int count = -1;
			return GetByShippingTypeID(shippingTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShippingServiceCode_ZNodeShippingType key.
		///		FK_ZNodeShippingServiceCode_ZNodeShippingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingServiceCode objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID)
		{
			int count = -1;
			return GetByShippingTypeID(transactionManager, shippingTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShippingServiceCode_ZNodeShippingType key.
		///		FK_ZNodeShippingServiceCode_ZNodeShippingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingServiceCode objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingTypeID(transactionManager, shippingTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShippingServiceCode_ZNodeShippingType key.
		///		fKZNodeShippingServiceCodeZNodeShippingType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingServiceCode objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> GetByShippingTypeID(System.Int32 shippingTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByShippingTypeID(null, shippingTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShippingServiceCode_ZNodeShippingType key.
		///		fKZNodeShippingServiceCodeZNodeShippingType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingServiceCode objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> GetByShippingTypeID(System.Int32 shippingTypeID, int start, int pageLength,out int count)
		{
			return GetByShippingTypeID(null, shippingTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeShippingServiceCode_ZNodeShippingType key.
		///		FK_ZNodeShippingServiceCode_ZNodeShippingType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingServiceCode objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> GetByShippingTypeID(TransactionManager transactionManager, System.Int32 shippingTypeID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ShippingServiceCode Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingServiceCodeKey key, int start, int pageLength)
		{
			return GetByShippingServiceCodeID(transactionManager, key.ShippingServiceCodeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeShippingServiceCode index.
		/// </summary>
		/// <param name="shippingServiceCodeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingServiceCode GetByShippingServiceCodeID(System.Int32 shippingServiceCodeID)
		{
			int count = -1;
			return GetByShippingServiceCodeID(null,shippingServiceCodeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeShippingServiceCode index.
		/// </summary>
		/// <param name="shippingServiceCodeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingServiceCode GetByShippingServiceCodeID(System.Int32 shippingServiceCodeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingServiceCodeID(null, shippingServiceCodeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeShippingServiceCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingServiceCodeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingServiceCode GetByShippingServiceCodeID(TransactionManager transactionManager, System.Int32 shippingServiceCodeID)
		{
			int count = -1;
			return GetByShippingServiceCodeID(transactionManager, shippingServiceCodeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeShippingServiceCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingServiceCodeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingServiceCode GetByShippingServiceCodeID(TransactionManager transactionManager, System.Int32 shippingServiceCodeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingServiceCodeID(transactionManager, shippingServiceCodeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeShippingServiceCode index.
		/// </summary>
		/// <param name="shippingServiceCodeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingServiceCode GetByShippingServiceCodeID(System.Int32 shippingServiceCodeID, int start, int pageLength, out int count)
		{
			return GetByShippingServiceCodeID(null, shippingServiceCodeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeShippingServiceCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingServiceCodeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ShippingServiceCode GetByShippingServiceCodeID(TransactionManager transactionManager, System.Int32 shippingServiceCodeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingServiceCode&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingServiceCode&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ShippingServiceCode> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ShippingServiceCode c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ShippingServiceCode" 
							+ (reader.IsDBNull(reader.GetOrdinal("ShippingServiceCodeID"))?(int)0:(System.Int32)reader["ShippingServiceCodeID"]).ToString();

					c = EntityManager.LocateOrCreate<ShippingServiceCode>(
						key.ToString(), // EntityTrackingKey 
						"ShippingServiceCode",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ShippingServiceCode();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ShippingServiceCodeID = (System.Int32)reader["ShippingServiceCodeID"];
					c.ShippingTypeID = (System.Int32)reader["ShippingTypeID"];
					c.Code = (System.String)reader["Code"];
					c.Description = (System.String)reader["Description"];
					c.DisplayOrder = (reader.IsDBNull(reader.GetOrdinal("DisplayOrder")))?null:(System.Int32?)reader["DisplayOrder"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ShippingServiceCode entity)
		{
			if (!reader.Read()) return;
			
			entity.ShippingServiceCodeID = (System.Int32)reader["ShippingServiceCodeID"];
			entity.ShippingTypeID = (System.Int32)reader["ShippingTypeID"];
			entity.Code = (System.String)reader["Code"];
			entity.Description = (System.String)reader["Description"];
			entity.DisplayOrder = (reader.IsDBNull(reader.GetOrdinal("DisplayOrder")))?null:(System.Int32?)reader["DisplayOrder"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ShippingServiceCode entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShippingServiceCodeID = (System.Int32)dataRow["ShippingServiceCodeID"];
			entity.ShippingTypeID = (System.Int32)dataRow["ShippingTypeID"];
			entity.Code = (System.String)dataRow["Code"];
			entity.Description = (System.String)dataRow["Description"];
			entity.DisplayOrder = (Convert.IsDBNull(dataRow["DisplayOrder"]))?null:(System.Int32?)dataRow["DisplayOrder"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingServiceCode"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingServiceCode Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingServiceCode entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ShippingTypeIDSource	
			if (CanDeepLoad(entity, "ShippingType", "ShippingTypeIDSource", deepLoadType, innerList) 
				&& entity.ShippingTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShippingTypeID;
				ShippingType tmpEntity = EntityManager.LocateEntity<ShippingType>(EntityLocator.ConstructKeyFromPkItems(typeof(ShippingType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShippingTypeIDSource = tmpEntity;
				else
					entity.ShippingTypeIDSource = DataRepository.ShippingTypeProvider.GetByShippingTypeID(entity.ShippingTypeID);
			
				if (deep && entity.ShippingTypeIDSource != null)
				{
					DataRepository.ShippingTypeProvider.DeepLoad(transactionManager, entity.ShippingTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ShippingTypeIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ShippingServiceCode object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ShippingServiceCode instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingServiceCode Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingServiceCode entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ShippingTypeIDSource
			if (CanDeepSave(entity, "ShippingType", "ShippingTypeIDSource", deepSaveType, innerList) 
				&& entity.ShippingTypeIDSource != null)
			{
				DataRepository.ShippingTypeProvider.Save(transactionManager, entity.ShippingTypeIDSource);
				entity.ShippingTypeID = entity.ShippingTypeIDSource.ShippingTypeID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ShippingServiceCodeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ShippingServiceCode</c>
	///</summary>
	public enum ShippingServiceCodeChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ShippingType</c> at ShippingTypeIDSource
		///</summary>
		[ChildEntityType(typeof(ShippingType))]
		ShippingType,
		}
	
	#endregion ShippingServiceCodeChildEntityTypes
	
	#region ShippingServiceCodeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingServiceCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingServiceCodeFilterBuilder : SqlFilterBuilder<ShippingServiceCodeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeFilterBuilder class.
		/// </summary>
		public ShippingServiceCodeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingServiceCodeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingServiceCodeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingServiceCodeFilterBuilder
	
	#region ShippingServiceCodeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingServiceCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingServiceCodeParameterBuilder : ParameterizedSqlFilterBuilder<ShippingServiceCodeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeParameterBuilder class.
		/// </summary>
		public ShippingServiceCodeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingServiceCodeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingServiceCodeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingServiceCodeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingServiceCodeParameterBuilder
} // end namespace
