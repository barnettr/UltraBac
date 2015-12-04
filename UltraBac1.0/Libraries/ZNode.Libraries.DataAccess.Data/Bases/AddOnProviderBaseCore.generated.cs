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
	/// This class is the base class for any <see cref="AddOnProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AddOnProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.AddOn, ZNode.Libraries.DataAccess.Entities.AddOnKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnKey key)
		{
			return Delete(transactionManager, key.AddOnID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="addOnID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 addOnID)
		{
			return Delete(null, addOnID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 addOnID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.AddOn Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnKey key, int start, int pageLength)
		{
			return GetByAddOnID(transactionManager, key.AddOnID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeProductAddOn index.
		/// </summary>
		/// <param name="addOnID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOn GetByAddOnID(System.Int32 addOnID)
		{
			int count = -1;
			return GetByAddOnID(null,addOnID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn index.
		/// </summary>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOn GetByAddOnID(System.Int32 addOnID, int start, int pageLength)
		{
			int count = -1;
			return GetByAddOnID(null, addOnID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOn GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID)
		{
			int count = -1;
			return GetByAddOnID(transactionManager, addOnID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOn GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID, int start, int pageLength)
		{
			int count = -1;
			return GetByAddOnID(transactionManager, addOnID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn index.
		/// </summary>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOn GetByAddOnID(System.Int32 addOnID, int start, int pageLength, out int count)
		{
			return GetByAddOnID(null, addOnID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOn index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.AddOn GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;AddOn&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;AddOn&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<AddOn> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<AddOn> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.AddOn c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"AddOn" 
							+ (reader.IsDBNull(reader.GetOrdinal("AddOnID"))?(int)0:(System.Int32)reader["AddOnID"]).ToString();

					c = EntityManager.LocateOrCreate<AddOn>(
						key.ToString(), // EntityTrackingKey 
						"AddOn",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.AddOn();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.AddOnID = (System.Int32)reader["AddOnID"];
					c.ProductID = (System.Int32)reader["ProductID"];
					c.Title = (System.String)reader["Title"];
					c.Name = (System.String)reader["Name"];
					c.Description = (System.String)reader["Description"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.DisplayType = (System.String)reader["DisplayType"];
					c.OptionalInd = (System.Boolean)reader["OptionalInd"];
					c.AllowBackOrder = (System.Boolean)reader["AllowBackOrder"];
					c.InStockMsg = (System.String)reader["InStockMsg"];
					c.OutOfStockMsg = (System.String)reader["OutOfStockMsg"];
					c.BackOrderMsg = (System.String)reader["BackOrderMsg"];
					c.PromptMsg = (System.String)reader["PromptMsg"];
					c.TrackInventoryInd = (System.Boolean)reader["TrackInventoryInd"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.AddOn entity)
		{
			if (!reader.Read()) return;
			
			entity.AddOnID = (System.Int32)reader["AddOnID"];
			entity.ProductID = (System.Int32)reader["ProductID"];
			entity.Title = (System.String)reader["Title"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (System.String)reader["Description"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.DisplayType = (System.String)reader["DisplayType"];
			entity.OptionalInd = (System.Boolean)reader["OptionalInd"];
			entity.AllowBackOrder = (System.Boolean)reader["AllowBackOrder"];
			entity.InStockMsg = (System.String)reader["InStockMsg"];
			entity.OutOfStockMsg = (System.String)reader["OutOfStockMsg"];
			entity.BackOrderMsg = (System.String)reader["BackOrderMsg"];
			entity.PromptMsg = (System.String)reader["PromptMsg"];
			entity.TrackInventoryInd = (System.Boolean)reader["TrackInventoryInd"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.AddOn entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AddOnID = (System.Int32)dataRow["AddOnID"];
			entity.ProductID = (System.Int32)dataRow["ProductID"];
			entity.Title = (System.String)dataRow["Title"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (System.String)dataRow["Description"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.DisplayType = (System.String)dataRow["DisplayType"];
			entity.OptionalInd = (System.Boolean)dataRow["OptionalInd"];
			entity.AllowBackOrder = (System.Boolean)dataRow["AllowBackOrder"];
			entity.InStockMsg = (System.String)dataRow["InStockMsg"];
			entity.OutOfStockMsg = (System.String)dataRow["OutOfStockMsg"];
			entity.BackOrderMsg = (System.String)dataRow["BackOrderMsg"];
			entity.PromptMsg = (System.String)dataRow["PromptMsg"];
			entity.TrackInventoryInd = (System.Boolean)dataRow["TrackInventoryInd"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AddOn"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.AddOn Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOn entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByAddOnID methods when available
			
			#region AddOnValueCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AddOnValue>", "AddOnValueCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AddOnValueCollection' loaded.");
				#endif 

				entity.AddOnValueCollection = DataRepository.AddOnValueProvider.GetByAddOnID(transactionManager, entity.AddOnID);

				if (deep && entity.AddOnValueCollection.Count > 0)
				{
					DataRepository.AddOnValueProvider.DeepLoad(transactionManager, entity.AddOnValueCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region ProductAddOnCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProductAddOn>", "ProductAddOnCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'ProductAddOnCollection' loaded.");
				#endif 

				entity.ProductAddOnCollection = DataRepository.ProductAddOnProvider.GetByAddOnID(transactionManager, entity.AddOnID);

				if (deep && entity.ProductAddOnCollection.Count > 0)
				{
					DataRepository.ProductAddOnProvider.DeepLoad(transactionManager, entity.ProductAddOnCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.AddOn object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.AddOn instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.AddOn Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOn entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			





			#region List<AddOnValue>
				if (CanDeepSave(entity, "List<AddOnValue>", "AddOnValueCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AddOnValue child in entity.AddOnValueCollection)
					{
						child.AddOnID = entity.AddOnID;
					}
				
				if (entity.AddOnValueCollection.Count > 0 || entity.AddOnValueCollection.DeletedItems.Count > 0)
					DataRepository.AddOnValueProvider.DeepSave(transactionManager, entity.AddOnValueCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<ProductAddOn>
				if (CanDeepSave(entity, "List<ProductAddOn>", "ProductAddOnCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProductAddOn child in entity.ProductAddOnCollection)
					{
						child.AddOnID = entity.AddOnID;
					}
				
				if (entity.ProductAddOnCollection.Count > 0 || entity.ProductAddOnCollection.DeletedItems.Count > 0)
					DataRepository.ProductAddOnProvider.DeepSave(transactionManager, entity.ProductAddOnCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				


						
			return true;
		}
		#endregion
	} // end class
	
	#region AddOnChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.AddOn</c>
	///</summary>
	public enum AddOnChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AddOn</c> as OneToMany for AddOnValueCollection
		///</summary>
		[ChildEntityType(typeof(TList<AddOnValue>))]
		AddOnValueCollection,

		///<summary>
		/// Collection of <c>AddOn</c> as OneToMany for ProductAddOnCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProductAddOn>))]
		ProductAddOnCollection,
	}
	
	#endregion AddOnChildEntityTypes
	
	#region AddOnFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddOn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddOnFilterBuilder : SqlFilterBuilder<AddOnColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddOnFilterBuilder class.
		/// </summary>
		public AddOnFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddOnFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddOnFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddOnFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddOnFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddOnFilterBuilder
	
	#region AddOnParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddOn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddOnParameterBuilder : ParameterizedSqlFilterBuilder<AddOnColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddOnParameterBuilder class.
		/// </summary>
		public AddOnParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddOnParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddOnParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddOnParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddOnParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddOnParameterBuilder
} // end namespace
