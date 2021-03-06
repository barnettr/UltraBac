﻿#region Using directives

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
	/// This class is the base class for any <see cref="ContentPageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContentPageProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ContentPage, ZNode.Libraries.DataAccess.Entities.ContentPageKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPageKey key)
		{
			return Delete(transactionManager, key.ContentPageID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="contentPageID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 contentPageID)
		{
			return Delete(null, contentPageID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contentPageID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 contentPageID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		FK_ZNodePage_ZNodePortal Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPage objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPage> GetByPortalID(System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(portalID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		FK_ZNodePage_ZNodePortal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPage objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPage> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		FK_ZNodePage_ZNodePortal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPage objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPage> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		fKZNodePageZNodePortal Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPage objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPage> GetByPortalID(System.Int32 portalID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalID(null, portalID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		fKZNodePageZNodePortal Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPage objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPage> GetByPortalID(System.Int32 portalID, int start, int pageLength,out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		FK_ZNodePage_ZNodePortal Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPage objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ContentPage> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ContentPage Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPageKey key, int start, int pageLength)
		{
			return GetByContentPageID(transactionManager, key.ContentPageID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="contentPageID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByContentPageID(System.Int32 contentPageID)
		{
			int count = -1;
			return GetByContentPageID(null,contentPageID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="contentPageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByContentPageID(System.Int32 contentPageID, int start, int pageLength)
		{
			int count = -1;
			return GetByContentPageID(null, contentPageID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contentPageID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByContentPageID(TransactionManager transactionManager, System.Int32 contentPageID)
		{
			int count = -1;
			return GetByContentPageID(transactionManager, contentPageID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contentPageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByContentPageID(TransactionManager transactionManager, System.Int32 contentPageID, int start, int pageLength)
		{
			int count = -1;
			return GetByContentPageID(transactionManager, contentPageID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="contentPageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByContentPageID(System.Int32 contentPageID, int start, int pageLength, out int count)
		{
			return GetByContentPageID(null, contentPageID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contentPageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ContentPage GetByContentPageID(TransactionManager transactionManager, System.Int32 contentPageID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ZNodePage index.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByName(System.String name)
		{
			int count = -1;
			return GetByName(null,name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ZNodePage index.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByName(System.String name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ZNodePage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByName(TransactionManager transactionManager, System.String name)
		{
			int count = -1;
			return GetByName(transactionManager, name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ZNodePage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ZNodePage index.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPage GetByName(System.String name, int start, int pageLength, out int count)
		{
			return GetByName(null, name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_ZNodePage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ContentPage GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ContentPage&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ContentPage&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ContentPage> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ContentPage> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ContentPage c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ContentPage" 
							+ (reader.IsDBNull(reader.GetOrdinal("ContentPageID"))?(int)0:(System.Int32)reader["ContentPageID"]).ToString();

					c = EntityManager.LocateOrCreate<ContentPage>(
						key.ToString(), // EntityTrackingKey 
						"ContentPage",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ContentPage();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ContentPageID = (System.Int32)reader["ContentPageID"];
					c.Name = (System.String)reader["Name"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.Title = (System.String)reader["Title"];
					c.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
					c.SEOMetaKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOMetaKeywords")))?null:(System.String)reader["SEOMetaKeywords"];
					c.SEOMetaDescription = (reader.IsDBNull(reader.GetOrdinal("SEOMetaDescription")))?null:(System.String)reader["SEOMetaDescription"];
					c.AllowDelete = (System.Boolean)reader["AllowDelete"];
					c.TemplateName = (System.String)reader["TemplateName"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.AnalyticsCode = (reader.IsDBNull(reader.GetOrdinal("AnalyticsCode")))?null:(System.String)reader["AnalyticsCode"];
					c.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
					c.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
					c.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ContentPage entity)
		{
			if (!reader.Read()) return;
			
			entity.ContentPageID = (System.Int32)reader["ContentPageID"];
			entity.Name = (System.String)reader["Name"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.Title = (System.String)reader["Title"];
			entity.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
			entity.SEOMetaKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOMetaKeywords")))?null:(System.String)reader["SEOMetaKeywords"];
			entity.SEOMetaDescription = (reader.IsDBNull(reader.GetOrdinal("SEOMetaDescription")))?null:(System.String)reader["SEOMetaDescription"];
			entity.AllowDelete = (System.Boolean)reader["AllowDelete"];
			entity.TemplateName = (System.String)reader["TemplateName"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.AnalyticsCode = (reader.IsDBNull(reader.GetOrdinal("AnalyticsCode")))?null:(System.String)reader["AnalyticsCode"];
			entity.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
			entity.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
			entity.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ContentPage entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ContentPageID = (System.Int32)dataRow["ContentPageID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.Title = (System.String)dataRow["Title"];
			entity.SEOTitle = (Convert.IsDBNull(dataRow["SEOTitle"]))?null:(System.String)dataRow["SEOTitle"];
			entity.SEOMetaKeywords = (Convert.IsDBNull(dataRow["SEOMetaKeywords"]))?null:(System.String)dataRow["SEOMetaKeywords"];
			entity.SEOMetaDescription = (Convert.IsDBNull(dataRow["SEOMetaDescription"]))?null:(System.String)dataRow["SEOMetaDescription"];
			entity.AllowDelete = (System.Boolean)dataRow["AllowDelete"];
			entity.TemplateName = (System.String)dataRow["TemplateName"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
			entity.AnalyticsCode = (Convert.IsDBNull(dataRow["AnalyticsCode"]))?null:(System.String)dataRow["AnalyticsCode"];
			entity.Custom1 = (Convert.IsDBNull(dataRow["Custom1"]))?null:(System.String)dataRow["Custom1"];
			entity.Custom2 = (Convert.IsDBNull(dataRow["Custom2"]))?null:(System.String)dataRow["Custom2"];
			entity.Custom3 = (Convert.IsDBNull(dataRow["Custom3"]))?null:(System.String)dataRow["Custom3"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContentPage"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ContentPage Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPage entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			// Deep load child collections  - Call GetByContentPageID methods when available
			
			#region ContentPageRevisionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ContentPageRevision>", "ContentPageRevisionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ContentPageRevisionCollection' loaded.");
				#endif 

				entity.ContentPageRevisionCollection = DataRepository.ContentPageRevisionProvider.GetByContentPageID(transactionManager, entity.ContentPageID);

				if (deep && entity.ContentPageRevisionCollection.Count > 0)
				{
					DataRepository.ContentPageRevisionProvider.DeepLoad(transactionManager, entity.ContentPageRevisionCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ContentPage object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ContentPage instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ContentPage Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPage entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			
			



			#region List<ContentPageRevision>
				if (CanDeepSave(entity, "List<ContentPageRevision>", "ContentPageRevisionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ContentPageRevision child in entity.ContentPageRevisionCollection)
					{
						child.ContentPageID = entity.ContentPageID;
					}
				
				if (entity.ContentPageRevisionCollection.Count > 0 || entity.ContentPageRevisionCollection.DeletedItems.Count > 0)
					DataRepository.ContentPageRevisionProvider.DeepSave(transactionManager, entity.ContentPageRevisionCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region ContentPageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ContentPage</c>
	///</summary>
	public enum ContentPageChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
	
		///<summary>
		/// Collection of <c>ContentPage</c> as OneToMany for ContentPageRevisionCollection
		///</summary>
		[ChildEntityType(typeof(TList<ContentPageRevision>))]
		ContentPageRevisionCollection,
	}
	
	#endregion ContentPageChildEntityTypes
	
	#region ContentPageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContentPage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContentPageFilterBuilder : SqlFilterBuilder<ContentPageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContentPageFilterBuilder class.
		/// </summary>
		public ContentPageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContentPageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContentPageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContentPageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContentPageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContentPageFilterBuilder
	
	#region ContentPageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContentPage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContentPageParameterBuilder : ParameterizedSqlFilterBuilder<ContentPageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContentPageParameterBuilder class.
		/// </summary>
		public ContentPageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContentPageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContentPageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContentPageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContentPageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContentPageParameterBuilder
} // end namespace
