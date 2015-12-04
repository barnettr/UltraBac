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
	/// This class is the base class for any <see cref="ContactTemperatureProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContactTemperatureProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.ContactTemperature, ZNode.Libraries.DataAccess.Entities.ContactTemperatureKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContactTemperatureKey key)
		{
			return Delete(transactionManager, key.ContactTemperatureID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="contactTemperatureID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 contactTemperatureID)
		{
			return Delete(null, contactTemperatureID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contactTemperatureID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 contactTemperatureID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.ContactTemperature Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContactTemperatureKey key, int start, int pageLength)
		{
			return GetByContactTemperatureID(transactionManager, key.ContactTemperatureID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeContactTemperature index.
		/// </summary>
		/// <param name="contactTemperatureID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContactTemperature GetByContactTemperatureID(System.Int32 contactTemperatureID)
		{
			int count = -1;
			return GetByContactTemperatureID(null,contactTemperatureID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeContactTemperature index.
		/// </summary>
		/// <param name="contactTemperatureID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContactTemperature GetByContactTemperatureID(System.Int32 contactTemperatureID, int start, int pageLength)
		{
			int count = -1;
			return GetByContactTemperatureID(null, contactTemperatureID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeContactTemperature index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contactTemperatureID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContactTemperature GetByContactTemperatureID(TransactionManager transactionManager, System.Int32 contactTemperatureID)
		{
			int count = -1;
			return GetByContactTemperatureID(transactionManager, contactTemperatureID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeContactTemperature index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contactTemperatureID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContactTemperature GetByContactTemperatureID(TransactionManager transactionManager, System.Int32 contactTemperatureID, int start, int pageLength)
		{
			int count = -1;
			return GetByContactTemperatureID(transactionManager, contactTemperatureID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeContactTemperature index.
		/// </summary>
		/// <param name="contactTemperatureID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.ContactTemperature GetByContactTemperatureID(System.Int32 contactTemperatureID, int start, int pageLength, out int count)
		{
			return GetByContactTemperatureID(null, contactTemperatureID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeContactTemperature index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contactTemperatureID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.ContactTemperature GetByContactTemperatureID(TransactionManager transactionManager, System.Int32 contactTemperatureID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;ContactTemperature&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;ContactTemperature&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<ContactTemperature> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<ContactTemperature> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.ContactTemperature c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"ContactTemperature" 
							+ (reader.IsDBNull(reader.GetOrdinal("ContactTemperatureID"))?(int)0:(System.Int32)reader["ContactTemperatureID"]).ToString();

					c = EntityManager.LocateOrCreate<ContactTemperature>(
						key.ToString(), // EntityTrackingKey 
						"ContactTemperature",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.ContactTemperature();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ContactTemperatureID = (System.Int32)reader["ContactTemperatureID"];
					c.OriginalContactTemperatureID = c.ContactTemperatureID; //(reader.IsDBNull(reader.GetOrdinal("ContactTemperatureID")))?(int)0:(System.Int32)reader["ContactTemperatureID"];
					c.Name = (System.String)reader["Name"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.ContactTemperature entity)
		{
			if (!reader.Read()) return;
			
			entity.ContactTemperatureID = (System.Int32)reader["ContactTemperatureID"];
			entity.OriginalContactTemperatureID = (System.Int32)reader["ContactTemperatureID"];
			entity.Name = (System.String)reader["Name"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.ContactTemperature entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ContactTemperatureID = (System.Int32)dataRow["ContactTemperatureID"];
			entity.OriginalContactTemperatureID = (System.Int32)dataRow["ContactTemperatureID"];
			entity.Name = (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.ContactTemperature"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ContactTemperature Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContactTemperature entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByContactTemperatureID methods when available
			
			#region AccountCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Account>", "AccountCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AccountCollection' loaded.");
				#endif 

				entity.AccountCollection = DataRepository.AccountProvider.GetByContactTemperatureID(transactionManager, entity.ContactTemperatureID);

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
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.ContactTemperature object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.ContactTemperature instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.ContactTemperature Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.ContactTemperature entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<Account>
				if (CanDeepSave(entity, "List<Account>", "AccountCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Account child in entity.AccountCollection)
					{
						child.ContactTemperatureID = entity.ContactTemperatureID;
					}
				
				if (entity.AccountCollection.Count > 0 || entity.AccountCollection.DeletedItems.Count > 0)
					DataRepository.AccountProvider.DeepSave(transactionManager, entity.AccountCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region ContactTemperatureChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.ContactTemperature</c>
	///</summary>
	public enum ContactTemperatureChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ContactTemperature</c> as OneToMany for AccountCollection
		///</summary>
		[ChildEntityType(typeof(TList<Account>))]
		AccountCollection,
	}
	
	#endregion ContactTemperatureChildEntityTypes
	
	#region ContactTemperatureFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactTemperature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTemperatureFilterBuilder : SqlFilterBuilder<ContactTemperatureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTemperatureFilterBuilder class.
		/// </summary>
		public ContactTemperatureFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactTemperatureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactTemperatureFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactTemperatureFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactTemperatureFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactTemperatureFilterBuilder
	
	#region ContactTemperatureParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ContactTemperature"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ContactTemperatureParameterBuilder : ParameterizedSqlFilterBuilder<ContactTemperatureColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ContactTemperatureParameterBuilder class.
		/// </summary>
		public ContactTemperatureParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ContactTemperatureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ContactTemperatureParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ContactTemperatureParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ContactTemperatureParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ContactTemperatureParameterBuilder
} // end namespace
