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
	/// This class is the base class for any <see cref="TaxRuleProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TaxRuleProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.TaxRule, ZNode.Libraries.DataAccess.Entities.TaxRuleKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.TaxRuleKey key)
		{
			return Delete(transactionManager, key.TaxRuleID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="taxRuleID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 taxRuleID)
		{
			return Delete(null, taxRuleID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taxRuleID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 taxRuleID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodePortal key.
		///		FK_ZNodeTaxRule_ZNodePortal Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByPortalID(System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(portalID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodePortal key.
		///		FK_ZNodeTaxRule_ZNodePortal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodePortal key.
		///		FK_ZNodeTaxRule_ZNodePortal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodePortal key.
		///		fKZNodeTaxRuleZNodePortal Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByPortalID(System.Int32 portalID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalID(null, portalID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodePortal key.
		///		fKZNodeTaxRuleZNodePortal Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByPortalID(System.Int32 portalID, int start, int pageLength,out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodePortal key.
		///		FK_ZNodeTaxRule_ZNodePortal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodeCountry key.
		///		FK_ZNodeTaxRule_ZNodeCountry Description: 
		/// </summary>
		/// <param name="destinationCountryCode"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByDestinationCountryCode(System.String destinationCountryCode)
		{
			int count = -1;
			return GetByDestinationCountryCode(destinationCountryCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodeCountry key.
		///		FK_ZNodeTaxRule_ZNodeCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="destinationCountryCode"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByDestinationCountryCode(TransactionManager transactionManager, System.String destinationCountryCode)
		{
			int count = -1;
			return GetByDestinationCountryCode(transactionManager, destinationCountryCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodeCountry key.
		///		FK_ZNodeTaxRule_ZNodeCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="destinationCountryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByDestinationCountryCode(TransactionManager transactionManager, System.String destinationCountryCode, int start, int pageLength)
		{
			int count = -1;
			return GetByDestinationCountryCode(transactionManager, destinationCountryCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodeCountry key.
		///		fKZNodeTaxRuleZNodeCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="destinationCountryCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByDestinationCountryCode(System.String destinationCountryCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByDestinationCountryCode(null, destinationCountryCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodeCountry key.
		///		fKZNodeTaxRuleZNodeCountry Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="destinationCountryCode"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByDestinationCountryCode(System.String destinationCountryCode, int start, int pageLength,out int count)
		{
			return GetByDestinationCountryCode(null, destinationCountryCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeTaxRule_ZNodeCountry key.
		///		FK_ZNodeTaxRule_ZNodeCountry Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="destinationCountryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.TaxRule objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<TaxRule> GetByDestinationCountryCode(TransactionManager transactionManager, System.String destinationCountryCode, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.TaxRule Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.TaxRuleKey key, int start, int pageLength)
		{
			return GetByTaxRuleID(transactionManager, key.TaxRuleID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_TaxRule index.
		/// </summary>
		/// <param name="taxRuleID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TaxRule GetByTaxRuleID(System.Int32 taxRuleID)
		{
			int count = -1;
			return GetByTaxRuleID(null,taxRuleID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_TaxRule index.
		/// </summary>
		/// <param name="taxRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TaxRule GetByTaxRuleID(System.Int32 taxRuleID, int start, int pageLength)
		{
			int count = -1;
			return GetByTaxRuleID(null, taxRuleID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_TaxRule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taxRuleID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TaxRule GetByTaxRuleID(TransactionManager transactionManager, System.Int32 taxRuleID)
		{
			int count = -1;
			return GetByTaxRuleID(transactionManager, taxRuleID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_TaxRule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taxRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TaxRule GetByTaxRuleID(TransactionManager transactionManager, System.Int32 taxRuleID, int start, int pageLength)
		{
			int count = -1;
			return GetByTaxRuleID(transactionManager, taxRuleID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_TaxRule index.
		/// </summary>
		/// <param name="taxRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TaxRule GetByTaxRuleID(System.Int32 taxRuleID, int start, int pageLength, out int count)
		{
			return GetByTaxRuleID(null, taxRuleID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_TaxRule index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="taxRuleID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TaxRule GetByTaxRuleID(TransactionManager transactionManager, System.Int32 taxRuleID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;TaxRule&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;TaxRule&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<TaxRule> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<TaxRule> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.TaxRule c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"TaxRule" 
							+ (reader.IsDBNull(reader.GetOrdinal("TaxRuleID"))?(int)0:(System.Int32)reader["TaxRuleID"]).ToString();

					c = EntityManager.LocateOrCreate<TaxRule>(
						key.ToString(), // EntityTrackingKey 
						"TaxRule",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.TaxRule();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.TaxRuleID = (System.Int32)reader["TaxRuleID"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.TaxRate = (System.Decimal)reader["TaxRate"];
					c.DestinationCountryCode = (reader.IsDBNull(reader.GetOrdinal("DestinationCountryCode")))?null:(System.String)reader["DestinationCountryCode"];
					c.DestinationStateCode = (reader.IsDBNull(reader.GetOrdinal("DestinationStateCode")))?null:(System.String)reader["DestinationStateCode"];
					c.Precedence = (System.Int32)reader["Precedence"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TaxRule entity)
		{
			if (!reader.Read()) return;
			
			entity.TaxRuleID = (System.Int32)reader["TaxRuleID"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.TaxRate = (System.Decimal)reader["TaxRate"];
			entity.DestinationCountryCode = (reader.IsDBNull(reader.GetOrdinal("DestinationCountryCode")))?null:(System.String)reader["DestinationCountryCode"];
			entity.DestinationStateCode = (reader.IsDBNull(reader.GetOrdinal("DestinationStateCode")))?null:(System.String)reader["DestinationStateCode"];
			entity.Precedence = (System.Int32)reader["Precedence"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.TaxRule entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TaxRuleID = (System.Int32)dataRow["TaxRuleID"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.TaxRate = (System.Decimal)dataRow["TaxRate"];
			entity.DestinationCountryCode = (Convert.IsDBNull(dataRow["DestinationCountryCode"]))?null:(System.String)dataRow["DestinationCountryCode"];
			entity.DestinationStateCode = (Convert.IsDBNull(dataRow["DestinationStateCode"]))?null:(System.String)dataRow["DestinationStateCode"];
			entity.Precedence = (System.Int32)dataRow["Precedence"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.TaxRule"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.TaxRule Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.TaxRule entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region PortalIDSource	
			if (CanDeepLoad(entity, "Portal", "PortalIDSource", deepLoadType, innerList) 
				&& entity.PortalIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PortalID;
				Portal tmpEntity = EntityManager.LocateEntity<Portal>(EntityLocator.ConstructKeyFromPkItems(typeof(Portal), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PortalIDSource = tmpEntity;
				else
					entity.PortalIDSource = DataRepository.PortalProvider.GetByPortalID(entity.PortalID);
			
				if (deep && entity.PortalIDSource != null)
				{
					DataRepository.PortalProvider.DeepLoad(transactionManager, entity.PortalIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PortalIDSource

			#region DestinationCountryCodeSource	
			if (CanDeepLoad(entity, "Country", "DestinationCountryCodeSource", deepLoadType, innerList) 
				&& entity.DestinationCountryCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DestinationCountryCode ?? string.Empty);
				Country tmpEntity = EntityManager.LocateEntity<Country>(EntityLocator.ConstructKeyFromPkItems(typeof(Country), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DestinationCountryCodeSource = tmpEntity;
				else
					entity.DestinationCountryCodeSource = DataRepository.CountryProvider.GetByCode((entity.DestinationCountryCode ?? string.Empty));
			
				if (deep && entity.DestinationCountryCodeSource != null)
				{
					DataRepository.CountryProvider.DeepLoad(transactionManager, entity.DestinationCountryCodeSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion DestinationCountryCodeSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.TaxRule object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.TaxRule instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.TaxRule Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.TaxRule entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PortalIDSource
			if (CanDeepSave(entity, "Portal", "PortalIDSource", deepSaveType, innerList) 
				&& entity.PortalIDSource != null)
			{
				DataRepository.PortalProvider.Save(transactionManager, entity.PortalIDSource);
				entity.PortalID = entity.PortalIDSource.PortalID;
			}
			#endregion 
			
			#region DestinationCountryCodeSource
			if (CanDeepSave(entity, "Country", "DestinationCountryCodeSource", deepSaveType, innerList) 
				&& entity.DestinationCountryCodeSource != null)
			{
				DataRepository.CountryProvider.Save(transactionManager, entity.DestinationCountryCodeSource);
				entity.DestinationCountryCode = entity.DestinationCountryCodeSource.Code;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region TaxRuleChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.TaxRule</c>
	///</summary>
	public enum TaxRuleChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
			
		///<summary>
		/// Composite Property for <c>Country</c> at DestinationCountryCodeSource
		///</summary>
		[ChildEntityType(typeof(Country))]
		Country,
		}
	
	#endregion TaxRuleChildEntityTypes
	
	#region TaxRuleFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TaxRule"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaxRuleFilterBuilder : SqlFilterBuilder<TaxRuleColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaxRuleFilterBuilder class.
		/// </summary>
		public TaxRuleFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaxRuleFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaxRuleFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaxRuleFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaxRuleFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaxRuleFilterBuilder
	
	#region TaxRuleParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TaxRule"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TaxRuleParameterBuilder : ParameterizedSqlFilterBuilder<TaxRuleColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TaxRuleParameterBuilder class.
		/// </summary>
		public TaxRuleParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TaxRuleParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TaxRuleParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TaxRuleParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TaxRuleParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TaxRuleParameterBuilder
} // end namespace
