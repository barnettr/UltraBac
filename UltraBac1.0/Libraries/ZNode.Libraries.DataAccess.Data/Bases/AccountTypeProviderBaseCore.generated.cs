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
	/// This class is the base class for any <see cref="AccountTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AccountTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.AccountType, ZNode.Libraries.DataAccess.Entities.AccountTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AccountTypeKey key)
		{
			return Delete(transactionManager, key.AccountTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="accountTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 accountTypeID)
		{
			return Delete(null, accountTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 accountTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.AccountType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AccountTypeKey key, int start, int pageLength)
		{
			return GetByAccountTypeID(transactionManager, key.AccountTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AccountType index.
		/// </summary>
		/// <param name="accountTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AccountType GetByAccountTypeID(System.Int32 accountTypeID)
		{
			int count = -1;
			return GetByAccountTypeID(null,accountTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountType index.
		/// </summary>
		/// <param name="accountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AccountType GetByAccountTypeID(System.Int32 accountTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountTypeID(null, accountTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AccountType GetByAccountTypeID(TransactionManager transactionManager, System.Int32 accountTypeID)
		{
			int count = -1;
			return GetByAccountTypeID(transactionManager, accountTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AccountType GetByAccountTypeID(TransactionManager transactionManager, System.Int32 accountTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountTypeID(transactionManager, accountTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountType index.
		/// </summary>
		/// <param name="accountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.AccountType GetByAccountTypeID(System.Int32 accountTypeID, int start, int pageLength, out int count)
		{
			return GetByAccountTypeID(null, accountTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AccountType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.AccountType GetByAccountTypeID(TransactionManager transactionManager, System.Int32 accountTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;AccountType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;AccountType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<AccountType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<AccountType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.AccountType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"AccountType" 
							+ (reader.IsDBNull(reader.GetOrdinal("AccountTypeID"))?(int)0:(System.Int32)reader["AccountTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<AccountType>(
						key.ToString(), // EntityTrackingKey 
						"AccountType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.AccountType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.AccountTypeID = (System.Int32)reader["AccountTypeID"];
					c.OriginalAccountTypeID = c.AccountTypeID; //(reader.IsDBNull(reader.GetOrdinal("AccountTypeID")))?(int)0:(System.Int32)reader["AccountTypeID"];
					c.AccountTypeNme = (System.String)reader["AccountTypeNme"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.AccountType entity)
		{
			if (!reader.Read()) return;
			
			entity.AccountTypeID = (System.Int32)reader["AccountTypeID"];
			entity.OriginalAccountTypeID = (System.Int32)reader["AccountTypeID"];
			entity.AccountTypeNme = (System.String)reader["AccountTypeNme"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.AccountType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AccountTypeID = (System.Int32)dataRow["AccountTypeID"];
			entity.OriginalAccountTypeID = (System.Int32)dataRow["AccountTypeID"];
			entity.AccountTypeNme = (System.String)dataRow["AccountTypeNme"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.AccountType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.AccountType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AccountType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByAccountTypeID methods when available
			
			#region AccountCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Account>", "AccountCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AccountCollection' loaded.");
				#endif 

				entity.AccountCollection = DataRepository.AccountProvider.GetByAccountTypeID(transactionManager, entity.AccountTypeID);

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
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.AccountType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.AccountType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.AccountType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AccountType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
						child.AccountTypeID = entity.AccountTypeID;
					}
				
				if (entity.AccountCollection.Count > 0 || entity.AccountCollection.DeletedItems.Count > 0)
					DataRepository.AccountProvider.DeepSave(transactionManager, entity.AccountCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region AccountTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.AccountType</c>
	///</summary>
	public enum AccountTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AccountType</c> as OneToMany for AccountCollection
		///</summary>
		[ChildEntityType(typeof(TList<Account>))]
		AccountCollection,
	}
	
	#endregion AccountTypeChildEntityTypes
	
	#region AccountTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountTypeFilterBuilder : SqlFilterBuilder<AccountTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountTypeFilterBuilder class.
		/// </summary>
		public AccountTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountTypeFilterBuilder
	
	#region AccountTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountTypeParameterBuilder : ParameterizedSqlFilterBuilder<AccountTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountTypeParameterBuilder class.
		/// </summary>
		public AccountTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountTypeParameterBuilder
} // end namespace
