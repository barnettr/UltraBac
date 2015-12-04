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
	/// This class is the base class for any <see cref="ShippingRuleProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ShippingRuleProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ShippingRule, ZNode.Libraries.DataAccess.Entities.ShippingRuleKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRuleKey key)
		{
			return Delete(transactionManager, key.ShippingRuleID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="shippingRuleID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 shippingRuleID)
		{
			return Delete(null, shippingRuleID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 shippingRuleID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ShippingRule_SC_ShippingRuleType key.
		///		FK_SC_ShippingRule_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="shippingRuleTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingRuleTypeID(System.Int32 shippingRuleTypeID)
		{
			int count = -1;
			return GetByShippingRuleTypeID(shippingRuleTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ShippingRule_SC_ShippingRuleType key.
		///		FK_SC_ShippingRule_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingRule objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32 shippingRuleTypeID)
		{
			int count = -1;
			return GetByShippingRuleTypeID(transactionManager, shippingRuleTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ShippingRule_SC_ShippingRuleType key.
		///		FK_SC_ShippingRule_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32 shippingRuleTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingRuleTypeID(transactionManager, shippingRuleTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ShippingRule_SC_ShippingRuleType key.
		///		fKSCShippingRuleSCShippingRuleType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingRuleTypeID(System.Int32 shippingRuleTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByShippingRuleTypeID(null, shippingRuleTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ShippingRule_SC_ShippingRuleType key.
		///		fKSCShippingRuleSCShippingRuleType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingRuleTypeID(System.Int32 shippingRuleTypeID, int start, int pageLength,out int count)
		{
			return GetByShippingRuleTypeID(null, shippingRuleTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_ShippingRule_SC_ShippingRuleType key.
		///		FK_SC_ShippingRule_SC_ShippingRuleType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ShippingRule objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingRuleTypeID(TransactionManager transactionManager, System.Int32 shippingRuleTypeID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ShippingRule Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRuleKey key, int start, int pageLength)
		{
			return GetByShippingRuleID(transactionManager, key.ShippingRuleID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_ShippingRule index.
		/// </summary>
		/// <param name="shippingRuleID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRule GetByShippingRuleID(System.Int32 shippingRuleID)
		{
			int count = -1;
			return GetByShippingRuleID(null,shippingRuleID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRule index.
		/// </summary>
		/// <param name="shippingRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRule GetByShippingRuleID(System.Int32 shippingRuleID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingRuleID(null, shippingRuleID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRule GetByShippingRuleID(TransactionManager transactionManager, System.Int32 shippingRuleID)
		{
			int count = -1;
			return GetByShippingRuleID(transactionManager, shippingRuleID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRule GetByShippingRuleID(TransactionManager transactionManager, System.Int32 shippingRuleID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingRuleID(transactionManager, shippingRuleID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRule index.
		/// </summary>
		/// <param name="shippingRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ShippingRule GetByShippingRuleID(System.Int32 shippingRuleID, int start, int pageLength, out int count)
		{
			return GetByShippingRuleID(null, shippingRuleID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_ShippingRule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ShippingRule GetByShippingRuleID(TransactionManager transactionManager, System.Int32 shippingRuleID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="shippingID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingID(System.Int32 shippingID)
		{
			int count = -1;
			return GetByShippingID(null,shippingID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingID(System.Int32 shippingID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingID(null, shippingID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingID(TransactionManager transactionManager, System.Int32 shippingID)
		{
			int count = -1;
			return GetByShippingID(transactionManager, shippingID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingID(TransactionManager transactionManager, System.Int32 shippingID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingID(transactionManager, shippingID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingID(System.Int32 shippingID, int start, int pageLength, out int count)
		{
			return GetByShippingID(null, shippingID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> GetByShippingID(TransactionManager transactionManager, System.Int32 shippingID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ShippingRule&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ShippingRule> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ShippingRule c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ShippingRule" 
							+ (reader.IsDBNull(reader.GetOrdinal("ShippingRuleID"))?(int)0:(System.Int32)reader["ShippingRuleID"]).ToString();

					c = EntityManager.LocateOrCreate<ShippingRule>(
						key.ToString(), // EntityTrackingKey 
						"ShippingRule",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ShippingRule();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ShippingRuleID = (System.Int32)reader["ShippingRuleID"];
					c.ShippingID = (System.Int32)reader["ShippingID"];
					c.ShippingRuleTypeID = (System.Int32)reader["ShippingRuleTypeID"];
					c.LowerLimit = (reader.IsDBNull(reader.GetOrdinal("LowerLimit")))?null:(System.Decimal?)reader["LowerLimit"];
					c.UpperLimit = (reader.IsDBNull(reader.GetOrdinal("UpperLimit")))?null:(System.Decimal?)reader["UpperLimit"];
					c.BaseCost = (System.Decimal)reader["BaseCost"];
					c.PerItemCost = (System.Decimal)reader["PerItemCost"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ShippingRule entity)
		{
			if (!reader.Read()) return;
			
			entity.ShippingRuleID = (System.Int32)reader["ShippingRuleID"];
			entity.ShippingID = (System.Int32)reader["ShippingID"];
			entity.ShippingRuleTypeID = (System.Int32)reader["ShippingRuleTypeID"];
			entity.LowerLimit = (reader.IsDBNull(reader.GetOrdinal("LowerLimit")))?null:(System.Decimal?)reader["LowerLimit"];
			entity.UpperLimit = (reader.IsDBNull(reader.GetOrdinal("UpperLimit")))?null:(System.Decimal?)reader["UpperLimit"];
			entity.BaseCost = (System.Decimal)reader["BaseCost"];
			entity.PerItemCost = (System.Decimal)reader["PerItemCost"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ShippingRule entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShippingRuleID = (System.Int32)dataRow["ShippingRuleID"];
			entity.ShippingID = (System.Int32)dataRow["ShippingID"];
			entity.ShippingRuleTypeID = (System.Int32)dataRow["ShippingRuleTypeID"];
			entity.LowerLimit = (Convert.IsDBNull(dataRow["LowerLimit"]))?null:(System.Decimal?)dataRow["LowerLimit"];
			entity.UpperLimit = (Convert.IsDBNull(dataRow["UpperLimit"]))?null:(System.Decimal?)dataRow["UpperLimit"];
			entity.BaseCost = (System.Decimal)dataRow["BaseCost"];
			entity.PerItemCost = (System.Decimal)dataRow["PerItemCost"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ShippingRule"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingRule Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRule entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ShippingIDSource	
			if (CanDeepLoad(entity, "Shipping", "ShippingIDSource", deepLoadType, innerList) 
				&& entity.ShippingIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShippingID;
				Shipping tmpEntity = EntityManager.LocateEntity<Shipping>(EntityLocator.ConstructKeyFromPkItems(typeof(Shipping), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShippingIDSource = tmpEntity;
				else
					entity.ShippingIDSource = DataRepository.ShippingProvider.GetByShippingID(entity.ShippingID);
			
				if (deep && entity.ShippingIDSource != null)
				{
					DataRepository.ShippingProvider.DeepLoad(transactionManager, entity.ShippingIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ShippingIDSource

			#region ShippingRuleTypeIDSource	
			if (CanDeepLoad(entity, "ShippingRuleType", "ShippingRuleTypeIDSource", deepLoadType, innerList) 
				&& entity.ShippingRuleTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShippingRuleTypeID;
				ShippingRuleType tmpEntity = EntityManager.LocateEntity<ShippingRuleType>(EntityLocator.ConstructKeyFromPkItems(typeof(ShippingRuleType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShippingRuleTypeIDSource = tmpEntity;
				else
					entity.ShippingRuleTypeIDSource = DataRepository.ShippingRuleTypeProvider.GetByShippingRuleTypeID(entity.ShippingRuleTypeID);
			
				if (deep && entity.ShippingRuleTypeIDSource != null)
				{
					DataRepository.ShippingRuleTypeProvider.DeepLoad(transactionManager, entity.ShippingRuleTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ShippingRuleTypeIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ShippingRule object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ShippingRule instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ShippingRule Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ShippingRule entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ShippingIDSource
			if (CanDeepSave(entity, "Shipping", "ShippingIDSource", deepSaveType, innerList) 
				&& entity.ShippingIDSource != null)
			{
				DataRepository.ShippingProvider.Save(transactionManager, entity.ShippingIDSource);
				entity.ShippingID = entity.ShippingIDSource.ShippingID;
			}
			#endregion 
			
			#region ShippingRuleTypeIDSource
			if (CanDeepSave(entity, "ShippingRuleType", "ShippingRuleTypeIDSource", deepSaveType, innerList) 
				&& entity.ShippingRuleTypeIDSource != null)
			{
				DataRepository.ShippingRuleTypeProvider.Save(transactionManager, entity.ShippingRuleTypeIDSource);
				entity.ShippingRuleTypeID = entity.ShippingRuleTypeIDSource.ShippingRuleTypeID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ShippingRuleChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ShippingRule</c>
	///</summary>
	public enum ShippingRuleChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Shipping</c> at ShippingIDSource
		///</summary>
		[ChildEntityType(typeof(Shipping))]
		Shipping,
			
		///<summary>
		/// Composite Property for <c>ShippingRuleType</c> at ShippingRuleTypeIDSource
		///</summary>
		[ChildEntityType(typeof(ShippingRuleType))]
		ShippingRuleType,
		}
	
	#endregion ShippingRuleChildEntityTypes
	
	#region ShippingRuleFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingRule"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingRuleFilterBuilder : SqlFilterBuilder<ShippingRuleColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingRuleFilterBuilder class.
		/// </summary>
		public ShippingRuleFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingRuleFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingRuleFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingRuleFilterBuilder
	
	#region ShippingRuleParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ShippingRule"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippingRuleParameterBuilder : ParameterizedSqlFilterBuilder<ShippingRuleColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippingRuleParameterBuilder class.
		/// </summary>
		public ShippingRuleParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippingRuleParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippingRuleParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippingRuleParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippingRuleParameterBuilder
} // end namespace
