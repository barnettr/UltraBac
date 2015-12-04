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
	/// This class is the base class for any <see cref="ContentPageRevisionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContentPageRevisionProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ContentPageRevision, ZNode.Libraries.DataAccess.Entities.ContentPageRevisionKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPageRevisionKey key)
		{
			return Delete(transactionManager, key.RevisionID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="revisionID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 revisionID)
		{
			return Delete(null, revisionID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="revisionID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 revisionID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePageRevision_ZNodePage key.
		///		FK_ZNodePageRevision_ZNodePage Description: 
		/// </summary>
		/// <param name="contentPageID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPageRevision objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> GetByContentPageID(System.Int32 contentPageID)
		{
			int count = -1;
			return GetByContentPageID(contentPageID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePageRevision_ZNodePage key.
		///		FK_ZNodePageRevision_ZNodePage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contentPageID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPageRevision objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> GetByContentPageID(TransactionManager transactionManager, System.Int32 contentPageID)
		{
			int count = -1;
			return GetByContentPageID(transactionManager, contentPageID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePageRevision_ZNodePage key.
		///		FK_ZNodePageRevision_ZNodePage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contentPageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPageRevision objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> GetByContentPageID(TransactionManager transactionManager, System.Int32 contentPageID, int start, int pageLength)
		{
			int count = -1;
			return GetByContentPageID(transactionManager, contentPageID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePageRevision_ZNodePage key.
		///		fKZNodePageRevisionZNodePage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contentPageID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPageRevision objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> GetByContentPageID(System.Int32 contentPageID, int start, int pageLength)
		{
			int count =  -1;
			return GetByContentPageID(null, contentPageID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePageRevision_ZNodePage key.
		///		fKZNodePageRevisionZNodePage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contentPageID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPageRevision objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> GetByContentPageID(System.Int32 contentPageID, int start, int pageLength,out int count)
		{
			return GetByContentPageID(null, contentPageID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodePageRevision_ZNodePage key.
		///		FK_ZNodePageRevision_ZNodePage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contentPageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.ContentPageRevision objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> GetByContentPageID(TransactionManager transactionManager, System.Int32 contentPageID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.ContentPageRevision Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPageRevisionKey key, int start, int pageLength)
		{
			return GetByRevisionID(transactionManager, key.RevisionID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodePageRevision index.
		/// </summary>
		/// <param name="revisionID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPageRevision GetByRevisionID(System.Int32 revisionID)
		{
			int count = -1;
			return GetByRevisionID(null,revisionID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePageRevision index.
		/// </summary>
		/// <param name="revisionID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPageRevision GetByRevisionID(System.Int32 revisionID, int start, int pageLength)
		{
			int count = -1;
			return GetByRevisionID(null, revisionID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePageRevision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="revisionID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPageRevision GetByRevisionID(TransactionManager transactionManager, System.Int32 revisionID)
		{
			int count = -1;
			return GetByRevisionID(transactionManager, revisionID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePageRevision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="revisionID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPageRevision GetByRevisionID(TransactionManager transactionManager, System.Int32 revisionID, int start, int pageLength)
		{
			int count = -1;
			return GetByRevisionID(transactionManager, revisionID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePageRevision index.
		/// </summary>
		/// <param name="revisionID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContentPageRevision GetByRevisionID(System.Int32 revisionID, int start, int pageLength, out int count)
		{
			return GetByRevisionID(null, revisionID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodePageRevision index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="revisionID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ContentPageRevision GetByRevisionID(TransactionManager transactionManager, System.Int32 revisionID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ContentPageRevision&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ContentPageRevision&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ContentPageRevision> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ContentPageRevision c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ContentPageRevision" 
							+ (reader.IsDBNull(reader.GetOrdinal("RevisionID"))?(int)0:(System.Int32)reader["RevisionID"]).ToString();

					c = EntityManager.LocateOrCreate<ContentPageRevision>(
						key.ToString(), // EntityTrackingKey 
						"ContentPageRevision",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ContentPageRevision();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.RevisionID = (System.Int32)reader["RevisionID"];
					c.ContentPageID = (System.Int32)reader["ContentPageID"];
					c.UpdateDate = (System.DateTime)reader["UpdateDate"];
					c.UpdateUser = (System.String)reader["UpdateUser"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.HtmlText = (reader.IsDBNull(reader.GetOrdinal("HtmlText")))?null:(System.String)reader["HtmlText"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ContentPageRevision entity)
		{
			if (!reader.Read()) return;
			
			entity.RevisionID = (System.Int32)reader["RevisionID"];
			entity.ContentPageID = (System.Int32)reader["ContentPageID"];
			entity.UpdateDate = (System.DateTime)reader["UpdateDate"];
			entity.UpdateUser = (System.String)reader["UpdateUser"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.HtmlText = (reader.IsDBNull(reader.GetOrdinal("HtmlText")))?null:(System.String)reader["HtmlText"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ContentPageRevision entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RevisionID = (System.Int32)dataRow["RevisionID"];
			entity.ContentPageID = (System.Int32)dataRow["ContentPageID"];
			entity.UpdateDate = (System.DateTime)dataRow["UpdateDate"];
			entity.UpdateUser = (System.String)dataRow["UpdateUser"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.HtmlText = (Convert.IsDBNull(dataRow["HtmlText"]))?null:(System.String)dataRow["HtmlText"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContentPageRevision"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ContentPageRevision Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPageRevision entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region ContentPageIDSource	
			if (CanDeepLoad(entity, "ContentPage", "ContentPageIDSource", deepLoadType, innerList) 
				&& entity.ContentPageIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ContentPageID;
				ContentPage tmpEntity = EntityManager.LocateEntity<ContentPage>(EntityLocator.ConstructKeyFromPkItems(typeof(ContentPage), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContentPageIDSource = tmpEntity;
				else
					entity.ContentPageIDSource = DataRepository.ContentPageProvider.GetByContentPageID(entity.ContentPageID);
			
				if (deep && entity.ContentPageIDSource != null)
				{
					DataRepository.ContentPageProvider.DeepLoad(transactionManager, entity.ContentPageIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ContentPageIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ContentPageRevision object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ContentPageRevision instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ContentPageRevision Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContentPageRevision entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ContentPageIDSource
			if (CanDeepSave(entity, "ContentPage", "ContentPageIDSource", deepSaveType, innerList) 
				&& entity.ContentPageIDSource != null)
			{
				DataRepository.ContentPageProvider.Save(transactionManager, entity.ContentPageIDSource);
				entity.ContentPageID = entity.ContentPageIDSource.ContentPageID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region ContentPageRevisionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ContentPageRevision</c>
	///</summary>
	public enum ContentPageRevisionChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ContentPage</c> at ContentPageIDSource
		///</summary>
		[ChildEntityType(typeof(ContentPage))]
		ContentPage,
		}
	
	#endregion ContentPageRevisionChildEntityTypes
	
	#region ContentPageRevisionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContentPageRevision"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContentPageRevisionFilterBuilder : SqlFilterBuilder<ContentPageRevisionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionFilterBuilder class.
		/// </summary>
		public ContentPageRevisionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContentPageRevisionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContentPageRevisionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContentPageRevisionFilterBuilder
	
	#region ContentPageRevisionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContentPageRevision"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContentPageRevisionParameterBuilder : ParameterizedSqlFilterBuilder<ContentPageRevisionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionParameterBuilder class.
		/// </summary>
		public ContentPageRevisionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContentPageRevisionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContentPageRevisionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContentPageRevisionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContentPageRevisionParameterBuilder
} // end namespace
