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
	/// This class is the base class for any <see cref="CaseTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CaseTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.CaseType, ZNode.Libraries.DataAccess.Entities.CaseTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CaseTypeKey key)
		{
			return Delete(transactionManager, key.CaseTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="caseTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 caseTypeID)
		{
			return Delete(null, caseTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 caseTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.CaseType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CaseTypeKey key, int start, int pageLength)
		{
			return GetByCaseTypeID(transactionManager, key.CaseTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CaseType index.
		/// </summary>
		/// <param name="caseTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.CaseType GetByCaseTypeID(System.Int32 caseTypeID)
		{
			int count = -1;
			return GetByCaseTypeID(null,caseTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CaseType index.
		/// </summary>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.CaseType GetByCaseTypeID(System.Int32 caseTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseTypeID(null, caseTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CaseType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.CaseType GetByCaseTypeID(TransactionManager transactionManager, System.Int32 caseTypeID)
		{
			int count = -1;
			return GetByCaseTypeID(transactionManager, caseTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CaseType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.CaseType GetByCaseTypeID(TransactionManager transactionManager, System.Int32 caseTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByCaseTypeID(transactionManager, caseTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CaseType index.
		/// </summary>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.CaseType GetByCaseTypeID(System.Int32 caseTypeID, int start, int pageLength, out int count)
		{
			return GetByCaseTypeID(null, caseTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CaseType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="caseTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.CaseType GetByCaseTypeID(TransactionManager transactionManager, System.Int32 caseTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;CaseType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;CaseType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<CaseType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<CaseType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.CaseType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"CaseType" 
							+ (reader.IsDBNull(reader.GetOrdinal("CaseTypeID"))?(int)0:(System.Int32)reader["CaseTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<CaseType>(
						key.ToString(), // EntityTrackingKey 
						"CaseType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.CaseType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.CaseTypeID = (System.Int32)reader["CaseTypeID"];
					c.OriginalCaseTypeID = c.CaseTypeID; //(reader.IsDBNull(reader.GetOrdinal("CaseTypeID")))?(int)0:(System.Int32)reader["CaseTypeID"];
					c.CaseTypeNme = (System.String)reader["CaseTypeNme"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.CaseType entity)
		{
			if (!reader.Read()) return;
			
			entity.CaseTypeID = (System.Int32)reader["CaseTypeID"];
			entity.OriginalCaseTypeID = (System.Int32)reader["CaseTypeID"];
			entity.CaseTypeNme = (System.String)reader["CaseTypeNme"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.CaseType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CaseTypeID = (System.Int32)dataRow["CaseTypeID"];
			entity.OriginalCaseTypeID = (System.Int32)dataRow["CaseTypeID"];
			entity.CaseTypeNme = (System.String)dataRow["CaseTypeNme"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.CaseType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.CaseType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CaseType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByCaseTypeID methods when available
			
			#region CaseCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Case>", "CaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CaseCollection' loaded.");
				#endif 

				entity.CaseCollection = DataRepository.CaseProvider.GetByCaseTypeID(transactionManager, entity.CaseTypeID);

				if (deep && entity.CaseCollection.Count > 0)
				{
					DataRepository.CaseProvider.DeepLoad(transactionManager, entity.CaseCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.CaseType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.CaseType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.CaseType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CaseType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<Case>
				if (CanDeepSave(entity, "List<Case>", "CaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Case child in entity.CaseCollection)
					{
						child.CaseTypeID = entity.CaseTypeID;
					}
				
				if (entity.CaseCollection.Count > 0 || entity.CaseCollection.DeletedItems.Count > 0)
					DataRepository.CaseProvider.DeepSave(transactionManager, entity.CaseCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region CaseTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.CaseType</c>
	///</summary>
	public enum CaseTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>CaseType</c> as OneToMany for CaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<Case>))]
		CaseCollection,
	}
	
	#endregion CaseTypeChildEntityTypes
	
	#region CaseTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CaseType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CaseTypeFilterBuilder : SqlFilterBuilder<CaseTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CaseTypeFilterBuilder class.
		/// </summary>
		public CaseTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CaseTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CaseTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CaseTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CaseTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CaseTypeFilterBuilder
	
	#region CaseTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CaseType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CaseTypeParameterBuilder : ParameterizedSqlFilterBuilder<CaseTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CaseTypeParameterBuilder class.
		/// </summary>
		public CaseTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CaseTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CaseTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CaseTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CaseTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CaseTypeParameterBuilder
} // end namespace
