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
	/// This class is the base class for any <see cref="DiscountTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DiscountTypeProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.DiscountType, ZNode.Libraries.DataAccess.Entities.DiscountTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountTypeKey key)
		{
			return Delete(transactionManager, key.DiscountTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="discountTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 discountTypeID)
		{
			return Delete(null, discountTypeID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTypeID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 discountTypeID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.DiscountType Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountTypeKey key, int start, int pageLength)
		{
			return GetByDiscountTypeID(transactionManager, key.DiscountTypeID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeDiscountType index.
		/// </summary>
		/// <param name="discountTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountType GetByDiscountTypeID(System.Int32 discountTypeID)
		{
			int count = -1;
			return GetByDiscountTypeID(null,discountTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountType index.
		/// </summary>
		/// <param name="discountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountType GetByDiscountTypeID(System.Int32 discountTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByDiscountTypeID(null, discountTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountType GetByDiscountTypeID(TransactionManager transactionManager, System.Int32 discountTypeID)
		{
			int count = -1;
			return GetByDiscountTypeID(transactionManager, discountTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountType GetByDiscountTypeID(TransactionManager transactionManager, System.Int32 discountTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByDiscountTypeID(transactionManager, discountTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountType index.
		/// </summary>
		/// <param name="discountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountType GetByDiscountTypeID(System.Int32 discountTypeID, int start, int pageLength, out int count)
		{
			return GetByDiscountTypeID(null, discountTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.DiscountType GetByDiscountTypeID(TransactionManager transactionManager, System.Int32 discountTypeID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;DiscountType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;DiscountType&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<DiscountType> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<DiscountType> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.DiscountType c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"DiscountType" 
							+ (reader.IsDBNull(reader.GetOrdinal("DiscountTypeID"))?(int)0:(System.Int32)reader["DiscountTypeID"]).ToString();

					c = EntityManager.LocateOrCreate<DiscountType>(
						key.ToString(), // EntityTrackingKey 
						"DiscountType",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.DiscountType();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.DiscountTypeID = (System.Int32)reader["DiscountTypeID"];
					c.OriginalDiscountTypeID = c.DiscountTypeID; //(reader.IsDBNull(reader.GetOrdinal("DiscountTypeID")))?(int)0:(System.Int32)reader["DiscountTypeID"];
					c.DiscountTypeName = (System.String)reader["DiscountTypeName"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.DiscountType entity)
		{
			if (!reader.Read()) return;
			
			entity.DiscountTypeID = (System.Int32)reader["DiscountTypeID"];
			entity.OriginalDiscountTypeID = (System.Int32)reader["DiscountTypeID"];
			entity.DiscountTypeName = (System.String)reader["DiscountTypeName"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.DiscountType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DiscountTypeID = (System.Int32)dataRow["DiscountTypeID"];
			entity.OriginalDiscountTypeID = (System.Int32)dataRow["DiscountTypeID"];
			entity.DiscountTypeName = (System.String)dataRow["DiscountTypeName"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.DiscountType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.DiscountType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByDiscountTypeID methods when available
			
			#region CouponCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Coupon>", "CouponCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CouponCollection' loaded.");
				#endif 

				entity.CouponCollection = DataRepository.CouponProvider.GetByDiscountTypeID(transactionManager, entity.DiscountTypeID);

				if (deep && entity.CouponCollection.Count > 0)
				{
					DataRepository.CouponProvider.DeepLoad(transactionManager, entity.CouponCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.DiscountType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.DiscountType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.DiscountType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountType entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<Coupon>
				if (CanDeepSave(entity, "List<Coupon>", "CouponCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Coupon child in entity.CouponCollection)
					{
						child.DiscountTypeID = entity.DiscountTypeID;
					}
				
				if (entity.CouponCollection.Count > 0 || entity.CouponCollection.DeletedItems.Count > 0)
					DataRepository.CouponProvider.DeepSave(transactionManager, entity.CouponCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region DiscountTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.DiscountType</c>
	///</summary>
	public enum DiscountTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>DiscountType</c> as OneToMany for CouponCollection
		///</summary>
		[ChildEntityType(typeof(TList<Coupon>))]
		CouponCollection,
	}
	
	#endregion DiscountTypeChildEntityTypes
	
	#region DiscountTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DiscountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiscountTypeFilterBuilder : SqlFilterBuilder<DiscountTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiscountTypeFilterBuilder class.
		/// </summary>
		public DiscountTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiscountTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiscountTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiscountTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiscountTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiscountTypeFilterBuilder
	
	#region DiscountTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DiscountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiscountTypeParameterBuilder : ParameterizedSqlFilterBuilder<DiscountTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiscountTypeParameterBuilder class.
		/// </summary>
		public DiscountTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiscountTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiscountTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiscountTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiscountTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiscountTypeParameterBuilder
} // end namespace
