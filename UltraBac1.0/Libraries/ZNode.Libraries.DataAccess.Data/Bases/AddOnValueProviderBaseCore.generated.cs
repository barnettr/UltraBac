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
	/// This class is the base class for any <see cref="AddOnValueProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AddOnValueProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.AddOnValue, ZNode.Libraries.DataAccess.Entities.AddOnValueKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnValueKey key)
		{
			return Delete(transactionManager, key.AddOnValueID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="addOnValueID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 addOnValueID)
		{
			return Delete(null, addOnValueID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnValueID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 addOnValueID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOnValue_ZNodeProductAddOn key.
		///		FK_ZNodeProductAddOnValue_ZNodeProductAddOn Description: 
		/// </summary>
		/// <param name="addOnID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetByAddOnID(System.Int32 addOnID)
		{
			int count = -1;
			return GetByAddOnID(addOnID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOnValue_ZNodeProductAddOn key.
		///		FK_ZNodeProductAddOnValue_ZNodeProductAddOn Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID)
		{
			int count = -1;
			return GetByAddOnID(transactionManager, addOnID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOnValue_ZNodeProductAddOn key.
		///		FK_ZNodeProductAddOnValue_ZNodeProductAddOn Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID, int start, int pageLength)
		{
			int count = -1;
			return GetByAddOnID(transactionManager, addOnID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOnValue_ZNodeProductAddOn key.
		///		fKZNodeProductAddOnValueZNodeProductAddOn Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="addOnID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetByAddOnID(System.Int32 addOnID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAddOnID(null, addOnID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOnValue_ZNodeProductAddOn key.
		///		fKZNodeProductAddOnValueZNodeProductAddOn Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="addOnID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetByAddOnID(System.Int32 addOnID, int start, int pageLength,out int count)
		{
			return GetByAddOnID(null, addOnID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeProductAddOnValue_ZNodeProductAddOn key.
		///		FK_ZNodeProductAddOnValue_ZNodeProductAddOn Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.AddOnValue objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> GetByAddOnID(TransactionManager transactionManager, System.Int32 addOnID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.AddOnValue Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnValueKey key, int start, int pageLength)
		{
			return GetByAddOnValueID(transactionManager, key.AddOnValueID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeProductAddOnValue index.
		/// </summary>
		/// <param name="addOnValueID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOnValue GetByAddOnValueID(System.Int32 addOnValueID)
		{
			int count = -1;
			return GetByAddOnValueID(null,addOnValueID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOnValue index.
		/// </summary>
		/// <param name="addOnValueID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOnValue GetByAddOnValueID(System.Int32 addOnValueID, int start, int pageLength)
		{
			int count = -1;
			return GetByAddOnValueID(null, addOnValueID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOnValue index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnValueID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOnValue GetByAddOnValueID(TransactionManager transactionManager, System.Int32 addOnValueID)
		{
			int count = -1;
			return GetByAddOnValueID(transactionManager, addOnValueID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOnValue index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnValueID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOnValue GetByAddOnValueID(TransactionManager transactionManager, System.Int32 addOnValueID, int start, int pageLength)
		{
			int count = -1;
			return GetByAddOnValueID(transactionManager, addOnValueID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOnValue index.
		/// </summary>
		/// <param name="addOnValueID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AddOnValue GetByAddOnValueID(System.Int32 addOnValueID, int start, int pageLength, out int count)
		{
			return GetByAddOnValueID(null, addOnValueID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeProductAddOnValue index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="addOnValueID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.AddOnValue GetByAddOnValueID(TransactionManager transactionManager, System.Int32 addOnValueID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;AddOnValue&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;AddOnValue&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<AddOnValue> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.AddOnValue c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"AddOnValue" 
							+ (reader.IsDBNull(reader.GetOrdinal("AddOnValueID"))?(int)0:(System.Int32)reader["AddOnValueID"]).ToString();

					c = EntityManager.LocateOrCreate<AddOnValue>(
						key.ToString(), // EntityTrackingKey 
						"AddOnValue",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.AddOnValue();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.AddOnValueID = (System.Int32)reader["AddOnValueID"];
					c.AddOnID = (System.Int32)reader["AddOnID"];
					c.Name = (System.String)reader["Name"];
					c.Description = (System.String)reader["Description"];
					c.SKU = (System.String)reader["SKU"];
					c.QuantityOnHand = (System.Int32)reader["QuantityOnHand"];
					c.DefaultInd = (System.Boolean)reader["DefaultInd"];
					c.DisplayOrder = (System.Int32)reader["DisplayOrder"];
					c.ImageFile = (System.String)reader["ImageFile"];
					c.Price = (System.Decimal)reader["Price"];
					c.Weight = (System.Decimal)reader["Weight"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.AddOnValue entity)
		{
			if (!reader.Read()) return;
			
			entity.AddOnValueID = (System.Int32)reader["AddOnValueID"];
			entity.AddOnID = (System.Int32)reader["AddOnID"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (System.String)reader["Description"];
			entity.SKU = (System.String)reader["SKU"];
			entity.QuantityOnHand = (System.Int32)reader["QuantityOnHand"];
			entity.DefaultInd = (System.Boolean)reader["DefaultInd"];
			entity.DisplayOrder = (System.Int32)reader["DisplayOrder"];
			entity.ImageFile = (System.String)reader["ImageFile"];
			entity.Price = (System.Decimal)reader["Price"];
			entity.Weight = (System.Decimal)reader["Weight"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.AddOnValue entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AddOnValueID = (System.Int32)dataRow["AddOnValueID"];
			entity.AddOnID = (System.Int32)dataRow["AddOnID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (System.String)dataRow["Description"];
			entity.SKU = (System.String)dataRow["SKU"];
			entity.QuantityOnHand = (System.Int32)dataRow["QuantityOnHand"];
			entity.DefaultInd = (System.Boolean)dataRow["DefaultInd"];
			entity.DisplayOrder = (System.Int32)dataRow["DisplayOrder"];
			entity.ImageFile = (System.String)dataRow["ImageFile"];
			entity.Price = (System.Decimal)dataRow["Price"];
			entity.Weight = (System.Decimal)dataRow["Weight"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AddOnValue"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.AddOnValue Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnValue entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region AddOnIDSource	
			if (CanDeepLoad(entity, "AddOn", "AddOnIDSource", deepLoadType, innerList) 
				&& entity.AddOnIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AddOnID;
				AddOn tmpEntity = EntityManager.LocateEntity<AddOn>(EntityLocator.ConstructKeyFromPkItems(typeof(AddOn), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AddOnIDSource = tmpEntity;
				else
					entity.AddOnIDSource = DataRepository.AddOnProvider.GetByAddOnID(entity.AddOnID);
			
				if (deep && entity.AddOnIDSource != null)
				{
					DataRepository.AddOnProvider.DeepLoad(transactionManager, entity.AddOnIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion AddOnIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.AddOnValue object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.AddOnValue instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.AddOnValue Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AddOnValue entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AddOnIDSource
			if (CanDeepSave(entity, "AddOn", "AddOnIDSource", deepSaveType, innerList) 
				&& entity.AddOnIDSource != null)
			{
				DataRepository.AddOnProvider.Save(transactionManager, entity.AddOnIDSource);
				entity.AddOnID = entity.AddOnIDSource.AddOnID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region AddOnValueChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.AddOnValue</c>
	///</summary>
	public enum AddOnValueChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AddOn</c> at AddOnIDSource
		///</summary>
		[ChildEntityType(typeof(AddOn))]
		AddOn,
		}
	
	#endregion AddOnValueChildEntityTypes
	
	#region AddOnValueFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddOnValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddOnValueFilterBuilder : SqlFilterBuilder<AddOnValueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddOnValueFilterBuilder class.
		/// </summary>
		public AddOnValueFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddOnValueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddOnValueFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddOnValueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddOnValueFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddOnValueFilterBuilder
	
	#region AddOnValueParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AddOnValue"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddOnValueParameterBuilder : ParameterizedSqlFilterBuilder<AddOnValueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddOnValueParameterBuilder class.
		/// </summary>
		public AddOnValueParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddOnValueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddOnValueParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddOnValueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddOnValueParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddOnValueParameterBuilder
} // end namespace
