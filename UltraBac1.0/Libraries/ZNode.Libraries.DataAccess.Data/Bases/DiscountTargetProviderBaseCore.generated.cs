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
	/// This class is the base class for any <see cref="DiscountTargetProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DiscountTargetProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.DiscountTarget, ZNode.Libraries.DataAccess.Entities.DiscountTargetKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountTargetKey key)
		{
			return Delete(transactionManager, key.DiscountTargetID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="discountTargetID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 discountTargetID)
		{
			return Delete(null, discountTargetID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTargetID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 discountTargetID);		
		
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
		public override ZNode.Libraries.DataAccess.Entities.DiscountTarget Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountTargetKey key, int start, int pageLength)
		{
			return GetByDiscountTargetID(transactionManager, key.DiscountTargetID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeDiscountTarget index.
		/// </summary>
		/// <param name="discountTargetID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountTarget GetByDiscountTargetID(System.Int32 discountTargetID)
		{
			int count = -1;
			return GetByDiscountTargetID(null,discountTargetID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountTarget index.
		/// </summary>
		/// <param name="discountTargetID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountTarget GetByDiscountTargetID(System.Int32 discountTargetID, int start, int pageLength)
		{
			int count = -1;
			return GetByDiscountTargetID(null, discountTargetID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountTarget index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTargetID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountTarget GetByDiscountTargetID(TransactionManager transactionManager, System.Int32 discountTargetID)
		{
			int count = -1;
			return GetByDiscountTargetID(transactionManager, discountTargetID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountTarget index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTargetID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountTarget GetByDiscountTargetID(TransactionManager transactionManager, System.Int32 discountTargetID, int start, int pageLength)
		{
			int count = -1;
			return GetByDiscountTargetID(transactionManager, discountTargetID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountTarget index.
		/// </summary>
		/// <param name="discountTargetID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.DiscountTarget GetByDiscountTargetID(System.Int32 discountTargetID, int start, int pageLength, out int count)
		{
			return GetByDiscountTargetID(null, discountTargetID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeDiscountTarget index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTargetID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.DiscountTarget GetByDiscountTargetID(TransactionManager transactionManager, System.Int32 discountTargetID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;DiscountTarget&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;DiscountTarget&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<DiscountTarget> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<DiscountTarget> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.DiscountTarget c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"DiscountTarget" 
							+ (reader.IsDBNull(reader.GetOrdinal("DiscountTargetID"))?(int)0:(System.Int32)reader["DiscountTargetID"]).ToString();

					c = EntityManager.LocateOrCreate<DiscountTarget>(
						key.ToString(), // EntityTrackingKey 
						"DiscountTarget",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.DiscountTarget();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.DiscountTargetID = (System.Int32)reader["DiscountTargetID"];
					c.OriginalDiscountTargetID = c.DiscountTargetID; //(reader.IsDBNull(reader.GetOrdinal("DiscountTargetID")))?(int)0:(System.Int32)reader["DiscountTargetID"];
					c.DiscountTargetName = (System.String)reader["DiscountTargetName"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.DiscountTarget entity)
		{
			if (!reader.Read()) return;
			
			entity.DiscountTargetID = (System.Int32)reader["DiscountTargetID"];
			entity.OriginalDiscountTargetID = (System.Int32)reader["DiscountTargetID"];
			entity.DiscountTargetName = (System.String)reader["DiscountTargetName"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.DiscountTarget entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DiscountTargetID = (System.Int32)dataRow["DiscountTargetID"];
			entity.OriginalDiscountTargetID = (System.Int32)dataRow["DiscountTargetID"];
			entity.DiscountTargetName = (System.String)dataRow["DiscountTargetName"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.DiscountTarget"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.DiscountTarget Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountTarget entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByDiscountTargetID methods when available
			
			#region CouponCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Coupon>", "CouponCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CouponCollection' loaded.");
				#endif 

				entity.CouponCollection = DataRepository.CouponProvider.GetByDiscountTargetID(transactionManager, entity.DiscountTargetID);

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
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.DiscountTarget object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.DiscountTarget instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.DiscountTarget Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.DiscountTarget entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
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
						child.DiscountTargetID = entity.DiscountTargetID;
					}
				
				if (entity.CouponCollection.Count > 0 || entity.CouponCollection.DeletedItems.Count > 0)
					DataRepository.CouponProvider.DeepSave(transactionManager, entity.CouponCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region DiscountTargetChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.DiscountTarget</c>
	///</summary>
	public enum DiscountTargetChildEntityTypes
	{

		///<summary>
		/// Collection of <c>DiscountTarget</c> as OneToMany for CouponCollection
		///</summary>
		[ChildEntityType(typeof(TList<Coupon>))]
		CouponCollection,
	}
	
	#endregion DiscountTargetChildEntityTypes
	
	#region DiscountTargetFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DiscountTarget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiscountTargetFilterBuilder : SqlFilterBuilder<DiscountTargetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiscountTargetFilterBuilder class.
		/// </summary>
		public DiscountTargetFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiscountTargetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiscountTargetFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiscountTargetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiscountTargetFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiscountTargetFilterBuilder
	
	#region DiscountTargetParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DiscountTarget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiscountTargetParameterBuilder : ParameterizedSqlFilterBuilder<DiscountTargetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiscountTargetParameterBuilder class.
		/// </summary>
		public DiscountTargetParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiscountTargetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiscountTargetParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiscountTargetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiscountTargetParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiscountTargetParameterBuilder
} // end namespace
