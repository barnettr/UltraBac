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
	/// This class is the base class for any <see cref="ProfileProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProfileProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Profile, ZNode.Libraries.DataAccess.Entities.ProfileKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProfileKey key)
		{
			return Delete(transactionManager, key.ProfileID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="profileID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 profileID)
		{
			return Delete(null, profileID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 profileID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Profile_SC_Portal key.
		///		FK_SC_Profile_SC_Portal Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Profile objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByPortalID(System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(portalID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Profile_SC_Portal key.
		///		FK_SC_Profile_SC_Portal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Profile objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Profile_SC_Portal key.
		///		FK_SC_Profile_SC_Portal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Profile objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Profile_SC_Portal key.
		///		fKSCProfileSCPortal Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Profile objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByPortalID(System.Int32 portalID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalID(null, portalID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Profile_SC_Portal key.
		///		fKSCProfileSCPortal Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Profile objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByPortalID(System.Int32 portalID, int start, int pageLength,out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Profile_SC_Portal key.
		///		FK_SC_Profile_SC_Portal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Profile objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Profile Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ProfileKey key, int start, int pageLength)
		{
			return GetByProfileID(transactionManager, key.ProfileID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_Profile index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Profile GetByProfileID(System.Int32 profileID)
		{
			int count = -1;
			return GetByProfileID(null,profileID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Profile index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Profile GetByProfileID(System.Int32 profileID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileID(null, profileID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Profile index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Profile GetByProfileID(TransactionManager transactionManager, System.Int32 profileID)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Profile index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Profile GetByProfileID(TransactionManager transactionManager, System.Int32 profileID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Profile index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Profile GetByProfileID(System.Int32 profileID, int start, int pageLength, out int count)
		{
			return GetByProfileID(null, profileID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Profile index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Profile GetByProfileID(TransactionManager transactionManager, System.Int32 profileID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Name index.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByName(System.String name)
		{
			int count = -1;
			return GetByName(null,name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Name index.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByName(System.String name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByName(TransactionManager transactionManager, System.String name)
		{
			int count = -1;
			return GetByName(transactionManager, name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Name index.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByName(System.String name, int start, int pageLength, out int count)
		{
			return GetByName(null, name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Name index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Default index.
		/// </summary>
		/// <param name="isDefault"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByIsDefault(System.Boolean isDefault)
		{
			int count = -1;
			return GetByIsDefault(null,isDefault, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Default index.
		/// </summary>
		/// <param name="isDefault"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByIsDefault(System.Boolean isDefault, int start, int pageLength)
		{
			int count = -1;
			return GetByIsDefault(null, isDefault, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Default index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="isDefault"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByIsDefault(TransactionManager transactionManager, System.Boolean isDefault)
		{
			int count = -1;
			return GetByIsDefault(transactionManager, isDefault, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Default index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="isDefault"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByIsDefault(TransactionManager transactionManager, System.Boolean isDefault, int start, int pageLength)
		{
			int count = -1;
			return GetByIsDefault(transactionManager, isDefault, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Default index.
		/// </summary>
		/// <param name="isDefault"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByIsDefault(System.Boolean isDefault, int start, int pageLength, out int count)
		{
			return GetByIsDefault(null, isDefault, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Default index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="isDefault"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Profile> GetByIsDefault(TransactionManager transactionManager, System.Boolean isDefault, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Profile&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Profile> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Profile> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Profile c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Profile" 
							+ (reader.IsDBNull(reader.GetOrdinal("ProfileID"))?(int)0:(System.Int32)reader["ProfileID"]).ToString();

					c = EntityManager.LocateOrCreate<Profile>(
						key.ToString(), // EntityTrackingKey 
						"Profile",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Profile();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ProfileID = (System.Int32)reader["ProfileID"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.Name = (System.String)reader["Name"];
					c.IsDefault = (System.Boolean)reader["IsDefault"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Profile entity)
		{
			if (!reader.Read()) return;
			
			entity.ProfileID = (System.Int32)reader["ProfileID"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.Name = (System.String)reader["Name"];
			entity.IsDefault = (System.Boolean)reader["IsDefault"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Profile entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProfileID = (System.Int32)dataRow["ProfileID"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.IsDefault = (System.Boolean)dataRow["IsDefault"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Profile"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Profile Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Profile entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByProfileID methods when available
			
			#region PaymentSettingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PaymentSetting>", "PaymentSettingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'PaymentSettingCollection' loaded.");
				#endif 

				entity.PaymentSettingCollection = DataRepository.PaymentSettingProvider.GetByProfileID(transactionManager, entity.ProfileID);

				if (deep && entity.PaymentSettingCollection.Count > 0)
				{
					DataRepository.PaymentSettingProvider.DeepLoad(transactionManager, entity.PaymentSettingCollection, deep, deepLoadType, childTypes, innerList);
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

				entity.ShippingCollection = DataRepository.ShippingProvider.GetByProfileID(transactionManager, entity.ProfileID);

				if (deep && entity.ShippingCollection.Count > 0)
				{
					DataRepository.ShippingProvider.DeepLoad(transactionManager, entity.ShippingCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region AccountCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Account>", "AccountCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AccountCollection' loaded.");
				#endif 

				entity.AccountCollection = DataRepository.AccountProvider.GetByProfileID(transactionManager, entity.ProfileID);

				if (deep && entity.AccountCollection.Count > 0)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.AccountCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Profile object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Profile instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Profile Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Profile entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			







			#region List<PaymentSetting>
				if (CanDeepSave(entity, "List<PaymentSetting>", "PaymentSettingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PaymentSetting child in entity.PaymentSettingCollection)
					{
						child.ProfileID = entity.ProfileID;
					}
				
				if (entity.PaymentSettingCollection.Count > 0 || entity.PaymentSettingCollection.DeletedItems.Count > 0)
					DataRepository.PaymentSettingProvider.DeepSave(transactionManager, entity.PaymentSettingCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Shipping>
				if (CanDeepSave(entity, "List<Shipping>", "ShippingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Shipping child in entity.ShippingCollection)
					{
						child.ProfileID = entity.ProfileID;
					}
				
				if (entity.ShippingCollection.Count > 0 || entity.ShippingCollection.DeletedItems.Count > 0)
					DataRepository.ShippingProvider.DeepSave(transactionManager, entity.ShippingCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Account>
				if (CanDeepSave(entity, "List<Account>", "AccountCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Account child in entity.AccountCollection)
					{
						child.ProfileID = entity.ProfileID;
					}
				
				if (entity.AccountCollection.Count > 0 || entity.AccountCollection.DeletedItems.Count > 0)
					DataRepository.AccountProvider.DeepSave(transactionManager, entity.AccountCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				



						
			return true;
		}
		#endregion
	} // end class
	
	#region ProfileChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Profile</c>
	///</summary>
	public enum ProfileChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
	
		///<summary>
		/// Collection of <c>Profile</c> as OneToMany for PaymentSettingCollection
		///</summary>
		[ChildEntityType(typeof(TList<PaymentSetting>))]
		PaymentSettingCollection,

		///<summary>
		/// Collection of <c>Profile</c> as OneToMany for ShippingCollection
		///</summary>
		[ChildEntityType(typeof(TList<Shipping>))]
		ShippingCollection,

		///<summary>
		/// Collection of <c>Profile</c> as OneToMany for AccountCollection
		///</summary>
		[ChildEntityType(typeof(TList<Account>))]
		AccountCollection,
	}
	
	#endregion ProfileChildEntityTypes
	
	#region ProfileFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfileFilterBuilder : SqlFilterBuilder<ProfileColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfileFilterBuilder class.
		/// </summary>
		public ProfileFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfileFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfileFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfileFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfileFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfileFilterBuilder
	
	#region ProfileParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfileParameterBuilder : ParameterizedSqlFilterBuilder<ProfileColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfileParameterBuilder class.
		/// </summary>
		public ProfileParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfileParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfileParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfileParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfileParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfileParameterBuilder
} // end namespace
