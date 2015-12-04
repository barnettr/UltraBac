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
	/// This class is the base class for any <see cref="HighlightProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class HighlightProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Highlight, ZNode.Libraries.DataAccess.Entities.HighlightKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.HighlightKey key)
		{
			return Delete(transactionManager, key.HighlightID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="highlightID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 highlightID)
		{
			return Delete(null, highlightID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="highlightID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 highlightID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.Highlight Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.HighlightKey key, int start, int pageLength)
		{
			return GetByHighlightID(transactionManager, key.HighlightID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_Highlight index.
		/// </summary>
		/// <param name="highlightID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Highlight GetByHighlightID(System.Int32 highlightID)
		{
			int count = -1;
			return GetByHighlightID(null,highlightID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Highlight index.
		/// </summary>
		/// <param name="highlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Highlight GetByHighlightID(System.Int32 highlightID, int start, int pageLength)
		{
			int count = -1;
			return GetByHighlightID(null, highlightID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Highlight index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="highlightID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Highlight GetByHighlightID(TransactionManager transactionManager, System.Int32 highlightID)
		{
			int count = -1;
			return GetByHighlightID(transactionManager, highlightID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Highlight index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="highlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Highlight GetByHighlightID(TransactionManager transactionManager, System.Int32 highlightID, int start, int pageLength)
		{
			int count = -1;
			return GetByHighlightID(transactionManager, highlightID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Highlight index.
		/// </summary>
		/// <param name="highlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Highlight GetByHighlightID(System.Int32 highlightID, int start, int pageLength, out int count)
		{
			return GetByHighlightID(null, highlightID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_Highlight index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="highlightID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Highlight GetByHighlightID(TransactionManager transactionManager, System.Int32 highlightID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Highlight&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Highlight&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Highlight> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Highlight> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Highlight c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Highlight" 
							+ (reader.IsDBNull(reader.GetOrdinal("HighlightID"))?(int)0:(System.Int32)reader["HighlightID"]).ToString();

					c = EntityManager.LocateOrCreate<Highlight>(
						key.ToString(), // EntityTrackingKey 
						"Highlight",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Highlight();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.HighlightID = (System.Int32)reader["HighlightID"];
					c.PortalID = (System.Int32)reader["PortalID"];
					c.ImageFile = (reader.IsDBNull(reader.GetOrdinal("ImageFile")))?null:(System.String)reader["ImageFile"];
					c.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.DisplayPopup = (System.Boolean)reader["DisplayPopup"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Highlight entity)
		{
			if (!reader.Read()) return;
			
			entity.HighlightID = (System.Int32)reader["HighlightID"];
			entity.PortalID = (System.Int32)reader["PortalID"];
			entity.ImageFile = (reader.IsDBNull(reader.GetOrdinal("ImageFile")))?null:(System.String)reader["ImageFile"];
			entity.Name = (reader.IsDBNull(reader.GetOrdinal("Name")))?null:(System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.DisplayPopup = (System.Boolean)reader["DisplayPopup"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Highlight entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.HighlightID = (System.Int32)dataRow["HighlightID"];
			entity.PortalID = (System.Int32)dataRow["PortalID"];
			entity.ImageFile = (Convert.IsDBNull(dataRow["ImageFile"]))?null:(System.String)dataRow["ImageFile"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?null:(System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.DisplayPopup = (System.Boolean)dataRow["DisplayPopup"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Highlight"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Highlight Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Highlight entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByHighlightID methods when available
			
			#region ProductHighlightCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductHighlight>", "ProductHighlightCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductHighlightCollection' loaded.");
				#endif 

				entity.ProductHighlightCollection = DataRepository.ProductHighlightProvider.GetByHighlightID(transactionManager, entity.HighlightID);

				if (deep && entity.ProductHighlightCollection.Count > 0)
				{
					DataRepository.ProductHighlightProvider.DeepLoad(transactionManager, entity.ProductHighlightCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Highlight object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Highlight instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Highlight Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Highlight entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<ProductHighlight>
				if (CanDeepSave(entity, "List<ProductHighlight>", "ProductHighlightCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductHighlight child in entity.ProductHighlightCollection)
					{
						child.HighlightID = entity.HighlightID;
					}
				
				if (entity.ProductHighlightCollection.Count > 0 || entity.ProductHighlightCollection.DeletedItems.Count > 0)
					DataRepository.ProductHighlightProvider.DeepSave(transactionManager, entity.ProductHighlightCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region HighlightChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Highlight</c>
	///</summary>
	public enum HighlightChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Highlight</c> as OneToMany for ProductHighlightCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductHighlight>))]
		ProductHighlightCollection,
	}
	
	#endregion HighlightChildEntityTypes
	
	#region HighlightFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Highlight"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HighlightFilterBuilder : SqlFilterBuilder<HighlightColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HighlightFilterBuilder class.
		/// </summary>
		public HighlightFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the HighlightFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HighlightFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HighlightFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HighlightFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HighlightFilterBuilder
	
	#region HighlightParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Highlight"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HighlightParameterBuilder : ParameterizedSqlFilterBuilder<HighlightColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HighlightParameterBuilder class.
		/// </summary>
		public HighlightParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the HighlightParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HighlightParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HighlightParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HighlightParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HighlightParameterBuilder
} // end namespace
