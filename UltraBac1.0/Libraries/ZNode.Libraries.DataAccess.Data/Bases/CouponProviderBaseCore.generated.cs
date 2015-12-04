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
	/// This class is the base class for any <see cref="CouponProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CouponProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Coupon, ZNode.Libraries.DataAccess.Entities.CouponKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CouponKey key)
		{
			return Delete(transactionManager, key.CouponID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="couponID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 couponID)
		{
			return Delete(null, couponID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 couponID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountTarget key.
		///		FK_ZNodeCoupon_ZNodeDiscountTarget Description: 
		/// </summary>
		/// <param name="discountTargetID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTargetID(System.Int32 discountTargetID)
		{
			int count = -1;
			return GetByDiscountTargetID(discountTargetID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountTarget key.
		///		FK_ZNodeCoupon_ZNodeDiscountTarget Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTargetID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTargetID(TransactionManager transactionManager, System.Int32 discountTargetID)
		{
			int count = -1;
			return GetByDiscountTargetID(transactionManager, discountTargetID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountTarget key.
		///		FK_ZNodeCoupon_ZNodeDiscountTarget Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTargetID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTargetID(TransactionManager transactionManager, System.Int32 discountTargetID, int start, int pageLength)
		{
			int count = -1;
			return GetByDiscountTargetID(transactionManager, discountTargetID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountTarget key.
		///		fKZNodeCouponZNodeDiscountTarget Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="discountTargetID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTargetID(System.Int32 discountTargetID, int start, int pageLength)
		{
			int count =  -1;
			return GetByDiscountTargetID(null, discountTargetID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountTarget key.
		///		fKZNodeCouponZNodeDiscountTarget Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="discountTargetID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTargetID(System.Int32 discountTargetID, int start, int pageLength,out int count)
		{
			return GetByDiscountTargetID(null, discountTargetID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountTarget key.
		///		FK_ZNodeCoupon_ZNodeDiscountTarget Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTargetID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTargetID(TransactionManager transactionManager, System.Int32 discountTargetID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountType key.
		///		FK_ZNodeCoupon_ZNodeDiscountType Description: 
		/// </summary>
		/// <param name="discountTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTypeID(System.Int32 discountTypeID)
		{
			int count = -1;
			return GetByDiscountTypeID(discountTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountType key.
		///		FK_ZNodeCoupon_ZNodeDiscountType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTypeID(TransactionManager transactionManager, System.Int32 discountTypeID)
		{
			int count = -1;
			return GetByDiscountTypeID(transactionManager, discountTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountType key.
		///		FK_ZNodeCoupon_ZNodeDiscountType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTypeID(TransactionManager transactionManager, System.Int32 discountTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByDiscountTypeID(transactionManager, discountTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountType key.
		///		fKZNodeCouponZNodeDiscountType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="discountTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTypeID(System.Int32 discountTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByDiscountTypeID(null, discountTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountType key.
		///		fKZNodeCouponZNodeDiscountType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="discountTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTypeID(System.Int32 discountTypeID, int start, int pageLength,out int count)
		{
			return GetByDiscountTypeID(null, discountTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeCoupon_ZNodeDiscountType key.
		///		FK_ZNodeCoupon_ZNodeDiscountType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="discountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Coupon objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Coupon> GetByDiscountTypeID(TransactionManager transactionManager, System.Int32 discountTypeID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Coupon Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.CouponKey key, int start, int pageLength)
		{
			return GetByCouponID(transactionManager, key.CouponID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZNodeCoupon index.
		/// </summary>
		/// <param name="couponID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponID(System.Int32 couponID)
		{
			int count = -1;
			return GetByCouponID(null,couponID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCoupon index.
		/// </summary>
		/// <param name="couponID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponID(System.Int32 couponID, int start, int pageLength)
		{
			int count = -1;
			return GetByCouponID(null, couponID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCoupon index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponID(TransactionManager transactionManager, System.Int32 couponID)
		{
			int count = -1;
			return GetByCouponID(transactionManager, couponID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCoupon index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponID(TransactionManager transactionManager, System.Int32 couponID, int start, int pageLength)
		{
			int count = -1;
			return GetByCouponID(transactionManager, couponID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCoupon index.
		/// </summary>
		/// <param name="couponID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponID(System.Int32 couponID, int start, int pageLength, out int count)
		{
			return GetByCouponID(null, couponID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZNodeCoupon index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponID(TransactionManager transactionManager, System.Int32 couponID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="couponCode"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponCode(System.String couponCode)
		{
			int count = -1;
			return GetByCouponCode(null,couponCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="couponCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponCode(System.String couponCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCouponCode(null, couponCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponCode(TransactionManager transactionManager, System.String couponCode)
		{
			int count = -1;
			return GetByCouponCode(transactionManager, couponCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponCode(TransactionManager transactionManager, System.String couponCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCouponCode(transactionManager, couponCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="couponCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponCode(System.String couponCode, int start, int pageLength, out int count)
		{
			return GetByCouponCode(null, couponCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Coupon GetByCouponCode(TransactionManager transactionManager, System.String couponCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Coupon&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Coupon&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Coupon> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Coupon> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Coupon c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Coupon" 
							+ (reader.IsDBNull(reader.GetOrdinal("CouponID"))?(int)0:(System.Int32)reader["CouponID"]).ToString();

					c = EntityManager.LocateOrCreate<Coupon>(
						key.ToString(), // EntityTrackingKey 
						"Coupon",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Coupon();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.CouponID = (System.Int32)reader["CouponID"];
					c.CouponCode = (System.String)reader["CouponCode"];
					c.Discount = (System.Decimal)reader["Discount"];
					c.DiscountTypeID = (System.Int32)reader["DiscountTypeID"];
					c.DiscountTargetID = (System.Int32)reader["DiscountTargetID"];
					c.StartDate = (System.DateTime)reader["StartDate"];
					c.ExpDate = (System.DateTime)reader["ExpDate"];
					c.QuantityAvailable = (System.Int32)reader["QuantityAvailable"];
					c.ProductList = (reader.IsDBNull(reader.GetOrdinal("ProductList")))?null:(System.String)reader["ProductList"];
					c.OrderMinimum = (System.Decimal)reader["OrderMinimum"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Coupon entity)
		{
			if (!reader.Read()) return;
			
			entity.CouponID = (System.Int32)reader["CouponID"];
			entity.CouponCode = (System.String)reader["CouponCode"];
			entity.Discount = (System.Decimal)reader["Discount"];
			entity.DiscountTypeID = (System.Int32)reader["DiscountTypeID"];
			entity.DiscountTargetID = (System.Int32)reader["DiscountTargetID"];
			entity.StartDate = (System.DateTime)reader["StartDate"];
			entity.ExpDate = (System.DateTime)reader["ExpDate"];
			entity.QuantityAvailable = (System.Int32)reader["QuantityAvailable"];
			entity.ProductList = (reader.IsDBNull(reader.GetOrdinal("ProductList")))?null:(System.String)reader["ProductList"];
			entity.OrderMinimum = (System.Decimal)reader["OrderMinimum"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Coupon entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CouponID = (System.Int32)dataRow["CouponID"];
			entity.CouponCode = (System.String)dataRow["CouponCode"];
			entity.Discount = (System.Decimal)dataRow["Discount"];
			entity.DiscountTypeID = (System.Int32)dataRow["DiscountTypeID"];
			entity.DiscountTargetID = (System.Int32)dataRow["DiscountTargetID"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.ExpDate = (System.DateTime)dataRow["ExpDate"];
			entity.QuantityAvailable = (System.Int32)dataRow["QuantityAvailable"];
			entity.ProductList = (Convert.IsDBNull(dataRow["ProductList"]))?null:(System.String)dataRow["ProductList"];
			entity.OrderMinimum = (System.Decimal)dataRow["OrderMinimum"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Coupon"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Coupon Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Coupon entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region DiscountTargetIDSource	
			if (CanDeepLoad(entity, "DiscountTarget", "DiscountTargetIDSource", deepLoadType, innerList) 
				&& entity.DiscountTargetIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DiscountTargetID;
				DiscountTarget tmpEntity = EntityManager.LocateEntity<DiscountTarget>(EntityLocator.ConstructKeyFromPkItems(typeof(DiscountTarget), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DiscountTargetIDSource = tmpEntity;
				else
					entity.DiscountTargetIDSource = DataRepository.DiscountTargetProvider.GetByDiscountTargetID(entity.DiscountTargetID);
			
				if (deep && entity.DiscountTargetIDSource != null)
				{
					DataRepository.DiscountTargetProvider.DeepLoad(transactionManager, entity.DiscountTargetIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion DiscountTargetIDSource

			#region DiscountTypeIDSource	
			if (CanDeepLoad(entity, "DiscountType", "DiscountTypeIDSource", deepLoadType, innerList) 
				&& entity.DiscountTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DiscountTypeID;
				DiscountType tmpEntity = EntityManager.LocateEntity<DiscountType>(EntityLocator.ConstructKeyFromPkItems(typeof(DiscountType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DiscountTypeIDSource = tmpEntity;
				else
					entity.DiscountTypeIDSource = DataRepository.DiscountTypeProvider.GetByDiscountTypeID(entity.DiscountTypeID);
			
				if (deep && entity.DiscountTypeIDSource != null)
				{
					DataRepository.DiscountTypeProvider.DeepLoad(transactionManager, entity.DiscountTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion DiscountTypeIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByCouponID methods when available
			
			#region OrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Order>", "OrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderCollection' loaded.");
				#endif 

				entity.OrderCollection = DataRepository.OrderProvider.GetByCouponID(transactionManager, entity.CouponID);

				if (deep && entity.OrderCollection.Count > 0)
				{
					DataRepository.OrderProvider.DeepLoad(transactionManager, entity.OrderCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Coupon object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Coupon instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Coupon Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Coupon entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DiscountTargetIDSource
			if (CanDeepSave(entity, "DiscountTarget", "DiscountTargetIDSource", deepSaveType, innerList) 
				&& entity.DiscountTargetIDSource != null)
			{
				DataRepository.DiscountTargetProvider.Save(transactionManager, entity.DiscountTargetIDSource);
				entity.DiscountTargetID = entity.DiscountTargetIDSource.DiscountTargetID;
			}
			#endregion 
			
			#region DiscountTypeIDSource
			if (CanDeepSave(entity, "DiscountType", "DiscountTypeIDSource", deepSaveType, innerList) 
				&& entity.DiscountTypeIDSource != null)
			{
				DataRepository.DiscountTypeProvider.Save(transactionManager, entity.DiscountTypeIDSource);
				entity.DiscountTypeID = entity.DiscountTypeIDSource.DiscountTypeID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<Order>
				if (CanDeepSave(entity, "List<Order>", "OrderCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Order child in entity.OrderCollection)
					{
						child.CouponID = entity.CouponID;
					}
				
				if (entity.OrderCollection.Count > 0 || entity.OrderCollection.DeletedItems.Count > 0)
					DataRepository.OrderProvider.DeepSave(transactionManager, entity.OrderCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region CouponChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Coupon</c>
	///</summary>
	public enum CouponChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>DiscountTarget</c> at DiscountTargetIDSource
		///</summary>
		[ChildEntityType(typeof(DiscountTarget))]
		DiscountTarget,
			
		///<summary>
		/// Composite Property for <c>DiscountType</c> at DiscountTypeIDSource
		///</summary>
		[ChildEntityType(typeof(DiscountType))]
		DiscountType,
	
		///<summary>
		/// Collection of <c>Coupon</c> as OneToMany for OrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<Order>))]
		OrderCollection,
	}
	
	#endregion CouponChildEntityTypes
	
	#region CouponFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Coupon"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CouponFilterBuilder : SqlFilterBuilder<CouponColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CouponFilterBuilder class.
		/// </summary>
		public CouponFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CouponFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CouponFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CouponFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CouponFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CouponFilterBuilder
	
	#region CouponParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Coupon"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CouponParameterBuilder : ParameterizedSqlFilterBuilder<CouponColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CouponParameterBuilder class.
		/// </summary>
		public CouponParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CouponParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CouponParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CouponParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CouponParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CouponParameterBuilder
} // end namespace
