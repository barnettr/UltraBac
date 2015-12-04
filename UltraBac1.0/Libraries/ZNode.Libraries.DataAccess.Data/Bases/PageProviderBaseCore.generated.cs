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
	/// This class is the base class for any <see cref="PageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PageProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Page, ZNode.Libraries.DataAccess.Entities.PageKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PageKey key)
		{
			return Delete(transactionManager, key.PageID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="pageID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 pageID)
		{
			return Delete(null, pageID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="pageID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 pageID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePage_ZNodePortal key.
		///		FK_ZNodePage_ZNodePortal Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Page> GetByPortalID(System.Int32 portalID)
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Page> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Page> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Page> GetByPortalID(System.Int32 portalID, int start, int pageLength)
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Page> GetByPortalID(System.Int32 portalID, int start, int pageLength,out int count)
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
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Page objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Page> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Page Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PageKey key, int start, int pageLength)
		{
			return GetByPageID(transactionManager, key.PageID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="pageID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByPageID(System.Int32 pageID)
		{
			int count = -1;
			return GetByPageID(null,pageID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="pageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByPageID(System.Int32 pageID, int start, int pageLength)
		{
			int count = -1;
			return GetByPageID(null, pageID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="pageID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByPageID(TransactionManager transactionManager, System.Int32 pageID)
		{
			int count = -1;
			return GetByPageID(transactionManager, pageID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="pageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByPageID(TransactionManager transactionManager, System.Int32 pageID, int start, int pageLength)
		{
			int count = -1;
			return GetByPageID(transactionManager, pageID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="pageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByPageID(System.Int32 pageID, int start, int pageLength, out int count)
		{
			return GetByPageID(null, pageID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePage_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="pageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Page GetByPageID(TransactionManager transactionManager, System.Int32 pageID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_ZNodePage index.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByName(System.String name)
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
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByName(System.String name, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByName(TransactionManager transactionManager, System.String name)
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
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Page GetByName(System.String name, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Page GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Page&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Page&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Page> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Page> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Page c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Page" 
							+ (reader.IsDBNull(reader.GetOrdinal("PageID"))?(int)0:(System.Int32)reader["PageID"]).ToString();

					c = EntityManager.LocateOrCreate<Page>(
						key.ToString(), // EntityTrackingKey 
						"Page",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Page();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.PageID = (System.Int32)reader["PageID"];
					c.Name = (System.String)reader["Name"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.Title = (System.String)reader["Title"];
					c.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
					c.SEOMetaKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOMetaKeywords")))?null:(System.String)reader["SEOMetaKeywords"];
					c.SEOMetaDescription = (reader.IsDBNull(reader.GetOrdinal("SEOMetaDescription")))?null:(System.String)reader["SEOMetaDescription"];
					c.AllowDelete = (System.Boolean)reader["AllowDelete"];
					c.TemplateName = (System.String)reader["TemplateName"];
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
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Page entity)
		{
			if (!reader.Read()) return;
			
			entity.PageID = (System.Int32)reader["PageID"];
			entity.Name = (System.String)reader["Name"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.Title = (System.String)reader["Title"];
			entity.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
			entity.SEOMetaKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOMetaKeywords")))?null:(System.String)reader["SEOMetaKeywords"];
			entity.SEOMetaDescription = (reader.IsDBNull(reader.GetOrdinal("SEOMetaDescription")))?null:(System.String)reader["SEOMetaDescription"];
			entity.AllowDelete = (System.Boolean)reader["AllowDelete"];
			entity.TemplateName = (System.String)reader["TemplateName"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Page entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PageID = (System.Int32)dataRow["PageID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.Title = (System.String)dataRow["Title"];
			entity.SEOTitle = (Convert.IsDBNull(dataRow["SEOTitle"]))?null:(System.String)dataRow["SEOTitle"];
			entity.SEOMetaKeywords = (Convert.IsDBNull(dataRow["SEOMetaKeywords"]))?null:(System.String)dataRow["SEOMetaKeywords"];
			entity.SEOMetaDescription = (Convert.IsDBNull(dataRow["SEOMetaDescription"]))?null:(System.String)dataRow["SEOMetaDescription"];
			entity.AllowDelete = (System.Boolean)dataRow["AllowDelete"];
			entity.TemplateName = (System.String)dataRow["TemplateName"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Page"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Page Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Page entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			// Deep load child collections  - Call GetByPageID methods when available
			
			#region PageRevisionCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PageRevision>", "PageRevisionCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'PageRevisionCollection' loaded.");
				#endif 

				entity.PageRevisionCollection = DataRepository.PageRevisionProvider.GetByPageID(transactionManager, entity.PageID);

				if (deep && entity.PageRevisionCollection.Count > 0)
				{
					DataRepository.PageRevisionProvider.DeepLoad(transactionManager, entity.PageRevisionCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Page object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Page instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Page Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Page entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			
			



			#region List<PageRevision>
				if (CanDeepSave(entity, "List<PageRevision>", "PageRevisionCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PageRevision child in entity.PageRevisionCollection)
					{
						child.PageID = entity.PageID;
					}
				
				if (entity.PageRevisionCollection.Count > 0 || entity.PageRevisionCollection.DeletedItems.Count > 0)
					DataRepository.PageRevisionProvider.DeepSave(transactionManager, entity.PageRevisionCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region PageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Page</c>
	///</summary>
	public enum PageChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
	
		///<summary>
		/// Collection of <c>Page</c> as OneToMany for PageRevisionCollection
		///</summary>
		[ChildEntityType(typeof(TList<PageRevision>))]
		PageRevisionCollection,
	}
	
	#endregion PageChildEntityTypes
	
	#region PageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Page"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PageFilterBuilder : SqlFilterBuilder<PageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PageFilterBuilder class.
		/// </summary>
		public PageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PageFilterBuilder
	
	#region PageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Page"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PageParameterBuilder : ParameterizedSqlFilterBuilder<PageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PageParameterBuilder class.
		/// </summary>
		public PageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PageParameterBuilder
} // end namespace
