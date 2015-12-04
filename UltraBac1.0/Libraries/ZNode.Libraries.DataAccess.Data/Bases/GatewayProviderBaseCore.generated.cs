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
	/// This class is the base class for any <see cref="GatewayProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GatewayProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Gateway, ZNode.Libraries.DataAccess.Entities.GatewayKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.GatewayKey key)
		{
			return Delete(transactionManager, key.GatewayTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="gatewayTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 gatewayTypeID)
		{
			return Delete(null, gatewayTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="gatewayTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 gatewayTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.Gateway Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.GatewayKey key, int start, int pageLength)
		{
			return GetByGatewayTypeID(transactionManager, key.GatewayTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_Gateway index.
		/// </summary>
		/// <param name="gatewayTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Gateway GetByGatewayTypeID(System.Int32 gatewayTypeID)
		{
			int count = -1;
			return GetByGatewayTypeID(null,gatewayTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Gateway index.
		/// </summary>
		/// <param name="gatewayTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Gateway GetByGatewayTypeID(System.Int32 gatewayTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByGatewayTypeID(null, gatewayTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Gateway index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="gatewayTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Gateway GetByGatewayTypeID(TransactionManager transactionManager, System.Int32 gatewayTypeID)
		{
			int count = -1;
			return GetByGatewayTypeID(transactionManager, gatewayTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Gateway index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="gatewayTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Gateway GetByGatewayTypeID(TransactionManager transactionManager, System.Int32 gatewayTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByGatewayTypeID(transactionManager, gatewayTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Gateway index.
		/// </summary>
		/// <param name="gatewayTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Gateway GetByGatewayTypeID(System.Int32 gatewayTypeID, int start, int pageLength, out int count)
		{
			return GetByGatewayTypeID(null, gatewayTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Gateway index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="gatewayTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Gateway GetByGatewayTypeID(TransactionManager transactionManager, System.Int32 gatewayTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Gateway&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Gateway&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Gateway> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Gateway> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Gateway c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Gateway" 
							+ (reader.IsDBNull(reader.GetOrdinal("GatewayTypeID"))?(int)0:(System.Int32)reader["GatewayTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<Gateway>(
						key.ToString(), // EntityTrackingKey 
						"Gateway",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Gateway();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.GatewayTypeID = (System.Int32)reader["GatewayTypeID"];
					c.OriginalGatewayTypeID = c.GatewayTypeID; //(reader.IsDBNull(reader.GetOrdinal("GatewayTypeID")))?(int)0:(System.Int32)reader["GatewayTypeID"];
					c.GatewayName = (System.String)reader["GatewayName"];
					c.WebsiteURL = (reader.IsDBNull(reader.GetOrdinal("WebsiteURL")))?null:(System.String)reader["WebsiteURL"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Gateway entity)
		{
			if (!reader.Read()) return;
			
			entity.GatewayTypeID = (System.Int32)reader["GatewayTypeID"];
			entity.OriginalGatewayTypeID = (System.Int32)reader["GatewayTypeID"];
			entity.GatewayName = (System.String)reader["GatewayName"];
			entity.WebsiteURL = (reader.IsDBNull(reader.GetOrdinal("WebsiteURL")))?null:(System.String)reader["WebsiteURL"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Gateway entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.GatewayTypeID = (System.Int32)dataRow["GatewayTypeID"];
			entity.OriginalGatewayTypeID = (System.Int32)dataRow["GatewayTypeID"];
			entity.GatewayName = (System.String)dataRow["GatewayName"];
			entity.WebsiteURL = (Convert.IsDBNull(dataRow["WebsiteURL"]))?null:(System.String)dataRow["WebsiteURL"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Gateway"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Gateway Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Gateway entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByGatewayTypeID methods when available
			
			#region PaymentSettingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PaymentSetting>", "PaymentSettingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'PaymentSettingCollection' loaded.");
				#endif 

				entity.PaymentSettingCollection = DataRepository.PaymentSettingProvider.GetByGatewayTypeID(transactionManager, entity.GatewayTypeID);

				if (deep && entity.PaymentSettingCollection.Count > 0)
				{
					DataRepository.PaymentSettingProvider.DeepLoad(transactionManager, entity.PaymentSettingCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Gateway object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Gateway instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Gateway Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Gateway entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<PaymentSetting>
				if (CanDeepSave(entity, "List<PaymentSetting>", "PaymentSettingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PaymentSetting child in entity.PaymentSettingCollection)
					{
						child.GatewayTypeID = entity.GatewayTypeID;
					}
				
				if (entity.PaymentSettingCollection.Count > 0 || entity.PaymentSettingCollection.DeletedItems.Count > 0)
					DataRepository.PaymentSettingProvider.DeepSave(transactionManager, entity.PaymentSettingCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region GatewayChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Gateway</c>
	///</summary>
	public enum GatewayChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Gateway</c> as OneToMany for PaymentSettingCollection
		///</summary>
		[ChildEntityType(typeof(TList<PaymentSetting>))]
		PaymentSettingCollection,
	}
	
	#endregion GatewayChildEntityTypes
	
	#region GatewayFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gateway"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GatewayFilterBuilder : SqlFilterBuilder<GatewayColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GatewayFilterBuilder class.
		/// </summary>
		public GatewayFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GatewayFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GatewayFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GatewayFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GatewayFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GatewayFilterBuilder
	
	#region GatewayParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gateway"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GatewayParameterBuilder : ParameterizedSqlFilterBuilder<GatewayColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GatewayParameterBuilder class.
		/// </summary>
		public GatewayParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GatewayParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GatewayParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GatewayParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GatewayParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GatewayParameterBuilder
} // end namespace
