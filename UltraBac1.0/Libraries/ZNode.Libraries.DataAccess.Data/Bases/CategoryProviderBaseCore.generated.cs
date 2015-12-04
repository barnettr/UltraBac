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
	/// This class is the base class for any <see cref="CategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CategoryProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Category, ZNode.Libraries.DataAccess.Entities.CategoryKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CategoryKey key)
		{
			return Delete(transactionManager, key.CategoryID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="categoryID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 categoryID)
		{
			return Delete(null, categoryID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 categoryID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_Portals key.
		///		FK_SC_Category_Portals Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByPortalID(System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(portalID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_Portals key.
		///		FK_SC_Category_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_Portals key.
		///		FK_SC_Category_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_Portals key.
		///		fKSCCategoryPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByPortalID(System.Int32 portalID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalID(null, portalID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_Portals key.
		///		fKSCCategoryPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByPortalID(System.Int32 portalID, int start, int pageLength,out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_Portals key.
		///		FK_SC_Category_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Category> GetByPortalID(TransactionManager transactionManager, System.Int32 portalID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_SC_Category key.
		///		FK_SC_Category_SC_Category Description: 
		/// </summary>
		/// <param name="parentCategoryID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByParentCategoryID(System.Int32? parentCategoryID)
		{
			int count = -1;
			return GetByParentCategoryID(parentCategoryID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_SC_Category key.
		///		FK_SC_Category_SC_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentCategoryID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByParentCategoryID(TransactionManager transactionManager, System.Int32? parentCategoryID)
		{
			int count = -1;
			return GetByParentCategoryID(transactionManager, parentCategoryID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_SC_Category key.
		///		FK_SC_Category_SC_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentCategoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByParentCategoryID(TransactionManager transactionManager, System.Int32? parentCategoryID, int start, int pageLength)
		{
			int count = -1;
			return GetByParentCategoryID(transactionManager, parentCategoryID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_SC_Category key.
		///		fKSCCategorySCCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="parentCategoryID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByParentCategoryID(System.Int32? parentCategoryID, int start, int pageLength)
		{
			int count =  -1;
			return GetByParentCategoryID(null, parentCategoryID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_SC_Category key.
		///		fKSCCategorySCCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="parentCategoryID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Category> GetByParentCategoryID(System.Int32? parentCategoryID, int start, int pageLength,out int count)
		{
			return GetByParentCategoryID(null, parentCategoryID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Category_SC_Category key.
		///		FK_SC_Category_SC_Category Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentCategoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Category objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Category> GetByParentCategoryID(TransactionManager transactionManager, System.Int32? parentCategoryID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Category Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CategoryKey key, int start, int pageLength)
		{
			return GetByCategoryID(transactionManager, key.CategoryID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SC_Category_PK index.
		/// </summary>
		/// <param name="categoryID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Category GetByCategoryID(System.Int32 categoryID)
		{
			int count = -1;
			return GetByCategoryID(null,categoryID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Category_PK index.
		/// </summary>
		/// <param name="categoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Category GetByCategoryID(System.Int32 categoryID, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryID(null, categoryID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Category_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Category GetByCategoryID(TransactionManager transactionManager, System.Int32 categoryID)
		{
			int count = -1;
			return GetByCategoryID(transactionManager, categoryID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Category_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Category GetByCategoryID(TransactionManager transactionManager, System.Int32 categoryID, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryID(transactionManager, categoryID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Category_PK index.
		/// </summary>
		/// <param name="categoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Category GetByCategoryID(System.Int32 categoryID, int start, int pageLength, out int count)
		{
			return GetByCategoryID(null, categoryID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Category_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="categoryID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Category GetByCategoryID(TransactionManager transactionManager, System.Int32 categoryID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Category&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Category&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Category> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Category> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Category c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Category" 
							+ (reader.IsDBNull(reader.GetOrdinal("CategoryID"))?(int)0:(System.Int32)reader["CategoryID"]).ToString();

					c = EntityManager.LocateOrCreate<Category>(
						key.ToString(), // EntityTrackingKey 
						"Category",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Category();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.CategoryID = (System.Int32)reader["CategoryID"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.Name = (System.String)reader["Name"];
					c.Title = (reader.IsDBNull(reader.GetOrdinal("Title")))?null:(System.String)reader["Title"];
					c.ShortDescription = (reader.IsDBNull(reader.GetOrdinal("ShortDescription")))?null:(System.String)reader["ShortDescription"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.ParentCategoryID = (reader.IsDBNull(reader.GetOrdinal("ParentCategoryID")))?null:(System.Int32?)reader["ParentCategoryID"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.ImageFile = (reader.IsDBNull(reader.GetOrdinal("ImageFile")))?null:(System.String)reader["ImageFile"];
					c.VisibleInd = (System.Boolean)reader["VisibleInd"];
					c.SubCategoryGridVisibleInd = (System.Boolean)reader["SubCategoryGridVisibleInd"];
					c.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
					c.SEOKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOKeywords")))?null:(System.String)reader["SEOKeywords"];
					c.SEODescription = (reader.IsDBNull(reader.GetOrdinal("SEODescription")))?null:(System.String)reader["SEODescription"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Category entity)
		{
			if (!reader.Read()) return;
			
			entity.CategoryID = (System.Int32)reader["CategoryID"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.Name = (System.String)reader["Name"];
			entity.Title = (reader.IsDBNull(reader.GetOrdinal("Title")))?null:(System.String)reader["Title"];
			entity.ShortDescription = (reader.IsDBNull(reader.GetOrdinal("ShortDescription")))?null:(System.String)reader["ShortDescription"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.ParentCategoryID = (reader.IsDBNull(reader.GetOrdinal("ParentCategoryID")))?null:(System.Int32?)reader["ParentCategoryID"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.ImageFile = (reader.IsDBNull(reader.GetOrdinal("ImageFile")))?null:(System.String)reader["ImageFile"];
			entity.VisibleInd = (System.Boolean)reader["VisibleInd"];
			entity.SubCategoryGridVisibleInd = (System.Boolean)reader["SubCategoryGridVisibleInd"];
			entity.SEOTitle = (reader.IsDBNull(reader.GetOrdinal("SEOTitle")))?null:(System.String)reader["SEOTitle"];
			entity.SEOKeywords = (reader.IsDBNull(reader.GetOrdinal("SEOKeywords")))?null:(System.String)reader["SEOKeywords"];
			entity.SEODescription = (reader.IsDBNull(reader.GetOrdinal("SEODescription")))?null:(System.String)reader["SEODescription"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Category entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CategoryID = (System.Int32)dataRow["CategoryID"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Title = (Convert.IsDBNull(dataRow["Title"]))?null:(System.String)dataRow["Title"];
			entity.ShortDescription = (Convert.IsDBNull(dataRow["ShortDescription"]))?null:(System.String)dataRow["ShortDescription"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.ParentCategoryID = (Convert.IsDBNull(dataRow["ParentCategoryID"]))?null:(System.Int32?)dataRow["ParentCategoryID"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.ImageFile = (Convert.IsDBNull(dataRow["ImageFile"]))?null:(System.String)dataRow["ImageFile"];
			entity.VisibleInd = (System.Boolean)dataRow["VisibleInd"];
			entity.SubCategoryGridVisibleInd = (System.Boolean)dataRow["SubCategoryGridVisibleInd"];
			entity.SEOTitle = (Convert.IsDBNull(dataRow["SEOTitle"]))?null:(System.String)dataRow["SEOTitle"];
			entity.SEOKeywords = (Convert.IsDBNull(dataRow["SEOKeywords"]))?null:(System.String)dataRow["SEOKeywords"];
			entity.SEODescription = (Convert.IsDBNull(dataRow["SEODescription"]))?null:(System.String)dataRow["SEODescription"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Category"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Category Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Category entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
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

			#region ParentCategoryIDSource	
			if (CanDeepLoad(entity, "Category", "ParentCategoryIDSource", deepLoadType, innerList) 
				&& entity.ParentCategoryIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ParentCategoryID ?? (int)0);
				Category tmpEntity = EntityManager.LocateEntity<Category>(EntityLocator.ConstructKeyFromPkItems(typeof(Category), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ParentCategoryIDSource = tmpEntity;
				else
					entity.ParentCategoryIDSource = DataRepository.CategoryProvider.GetByCategoryID((entity.ParentCategoryID ?? (int)0));
			
				if (deep && entity.ParentCategoryIDSource != null)
				{
					DataRepository.CategoryProvider.DeepLoad(transactionManager, entity.ParentCategoryIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ParentCategoryIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByCategoryID methods when available
			
			#region ProductCategoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductCategory>", "ProductCategoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductCategoryCollection' loaded.");
				#endif 

				entity.ProductCategoryCollection = DataRepository.ProductCategoryProvider.GetByCategoryID(transactionManager, entity.CategoryID);

				if (deep && entity.ProductCategoryCollection.Count > 0)
				{
					DataRepository.ProductCategoryProvider.DeepLoad(transactionManager, entity.ProductCategoryCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region CategoryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Category>", "CategoryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CategoryCollection' loaded.");
				#endif 

				entity.CategoryCollection = DataRepository.CategoryProvider.GetByParentCategoryID(transactionManager, entity.CategoryID);

				if (deep && entity.CategoryCollection.Count > 0)
				{
					DataRepository.CategoryProvider.DeepLoad(transactionManager, entity.CategoryCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Category object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Category instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Category Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Category entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
			
			#region ParentCategoryIDSource
			if (CanDeepSave(entity, "Category", "ParentCategoryIDSource", deepSaveType, innerList) 
				&& entity.ParentCategoryIDSource != null)
			{
				DataRepository.CategoryProvider.Save(transactionManager, entity.ParentCategoryIDSource);
				entity.ParentCategoryID = entity.ParentCategoryIDSource.CategoryID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





			#region List<ProductCategory>
				if (CanDeepSave(entity, "List<ProductCategory>", "ProductCategoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductCategory child in entity.ProductCategoryCollection)
					{
						child.CategoryID = entity.CategoryID;
					}
				
				if (entity.ProductCategoryCollection.Count > 0 || entity.ProductCategoryCollection.DeletedItems.Count > 0)
					DataRepository.ProductCategoryProvider.DeepSave(transactionManager, entity.ProductCategoryCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Category>
				if (CanDeepSave(entity, "List<Category>", "CategoryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Category child in entity.CategoryCollection)
					{
						child.ParentCategoryID = entity.CategoryID;
					}
				
				if (entity.CategoryCollection.Count > 0 || entity.CategoryCollection.DeletedItems.Count > 0)
					DataRepository.CategoryProvider.DeepSave(transactionManager, entity.CategoryCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region CategoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Category</c>
	///</summary>
	public enum CategoryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
			
		///<summary>
		/// Composite Property for <c>Category</c> at ParentCategoryIDSource
		///</summary>
		[ChildEntityType(typeof(Category))]
		Category,
	
		///<summary>
		/// Collection of <c>Category</c> as OneToMany for ProductCategoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductCategory>))]
		ProductCategoryCollection,

		///<summary>
		/// Collection of <c>Category</c> as OneToMany for CategoryCollection
		///</summary>
		[ChildEntityType(typeof(TList<Category>))]
		CategoryCollection,
	}
	
	#endregion CategoryChildEntityTypes
	
	#region CategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoryFilterBuilder : SqlFilterBuilder<CategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryFilterBuilder class.
		/// </summary>
		public CategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoryFilterBuilder
	
	#region CategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Category"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoryParameterBuilder : ParameterizedSqlFilterBuilder<CategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoryParameterBuilder class.
		/// </summary>
		public CategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoryParameterBuilder
} // end namespace
