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
	/// This class is the base class for any <see cref="PaymentTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PaymentTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.PaymentType, ZNode.Libraries.DataAccess.Entities.PaymentTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentTypeKey key)
		{
			return Delete(transactionManager, key.PaymentTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="paymentTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 paymentTypeID)
		{
			return Delete(null, paymentTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 paymentTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.PaymentType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentTypeKey key, int start, int pageLength)
		{
			return GetByPaymentTypeID(transactionManager, key.PaymentTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_PaymentType index.
		/// </summary>
		/// <param name="paymentTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByPaymentTypeID(System.Int32 paymentTypeID)
		{
			int count = -1;
			return GetByPaymentTypeID(null,paymentTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentType index.
		/// </summary>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByPaymentTypeID(System.Int32 paymentTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByPaymentTypeID(null, paymentTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByPaymentTypeID(TransactionManager transactionManager, System.Int32 paymentTypeID)
		{
			int count = -1;
			return GetByPaymentTypeID(transactionManager, paymentTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByPaymentTypeID(TransactionManager transactionManager, System.Int32 paymentTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByPaymentTypeID(transactionManager, paymentTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentType index.
		/// </summary>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByPaymentTypeID(System.Int32 paymentTypeID, int start, int pageLength, out int count)
		{
			return GetByPaymentTypeID(null, paymentTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.PaymentType GetByPaymentTypeID(TransactionManager transactionManager, System.Int32 paymentTypeID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByName(System.String name)
		{
			int count = -1;
			return GetByName(null,name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByName(System.String name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(null, name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByName(TransactionManager transactionManager, System.String name)
		{
			int count = -1;
			return GetByName(transactionManager, name, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength)
		{
			int count = -1;
			return GetByName(transactionManager, name, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentType GetByName(System.String name, int start, int pageLength, out int count)
		{
			return GetByName(null, name, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="name"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.PaymentType GetByName(TransactionManager transactionManager, System.String name, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<PaymentType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<PaymentType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.PaymentType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"PaymentType" 
							+ (reader.IsDBNull(reader.GetOrdinal("PaymentTypeID"))?(int)0:(System.Int32)reader["PaymentTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<PaymentType>(
						key.ToString(), // EntityTrackingKey 
						"PaymentType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.PaymentType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.PaymentTypeID = (System.Int32)reader["PaymentTypeID"];
					c.Name = (System.String)reader["Name"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
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
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.PaymentType entity)
		{
			if (!reader.Read()) return;
			
			entity.PaymentTypeID = (System.Int32)reader["PaymentTypeID"];
			entity.Name = (System.String)reader["Name"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.PaymentType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PaymentTypeID = (System.Int32)dataRow["PaymentTypeID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.PaymentType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.PaymentType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByPaymentTypeID methods when available
			
			#region PaymentSettingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PaymentSetting>", "PaymentSettingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'PaymentSettingCollection' loaded.");
				#endif 

				entity.PaymentSettingCollection = DataRepository.PaymentSettingProvider.GetByPaymentTypeID(transactionManager, entity.PaymentTypeID);

				if (deep && entity.PaymentSettingCollection.Count > 0)
				{
					DataRepository.PaymentSettingProvider.DeepLoad(transactionManager, entity.PaymentSettingCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.PaymentType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.PaymentType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.PaymentType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<PaymentSetting>
				if (CanDeepSave(entity, "List<PaymentSetting>", "PaymentSettingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PaymentSetting child in entity.PaymentSettingCollection)
					{
						child.PaymentTypeID = entity.PaymentTypeID;
					}
				
				if (entity.PaymentSettingCollection.Count > 0 || entity.PaymentSettingCollection.DeletedItems.Count > 0)
					DataRepository.PaymentSettingProvider.DeepSave(transactionManager, entity.PaymentSettingCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region PaymentTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.PaymentType</c>
	///</summary>
	public enum PaymentTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>PaymentType</c> as OneToMany for PaymentSettingCollection
		///</summary>
		[ChildEntityType(typeof(TList<PaymentSetting>))]
		PaymentSettingCollection,
	}
	
	#endregion PaymentTypeChildEntityTypes
	
	#region PaymentTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PaymentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PaymentTypeFilterBuilder : SqlFilterBuilder<PaymentTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PaymentTypeFilterBuilder class.
		/// </summary>
		public PaymentTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PaymentTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PaymentTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PaymentTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PaymentTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PaymentTypeFilterBuilder
	
	#region PaymentTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PaymentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PaymentTypeParameterBuilder : ParameterizedSqlFilterBuilder<PaymentTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PaymentTypeParameterBuilder class.
		/// </summary>
		public PaymentTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PaymentTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PaymentTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PaymentTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PaymentTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PaymentTypeParameterBuilder
} // end namespace
