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
	/// This class is the base class for any <see cref="OrderProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Order, ZNode.Libraries.DataAccess.Entities.OrderKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderKey key)
		{
			return Delete(transactionManager, key.OrderID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="orderID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 orderID)
		{
			return Delete(null, orderID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 orderID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_Portals key.
		///		FK_SC_Order_Portals Description: 
		/// </summary>
		/// <param name="portalId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByPortalId(System.Int32? portalId)
		{
			int count = -1;
			return GetByPortalId(portalId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_Portals key.
		///		FK_SC_Order_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalId"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByPortalId(TransactionManager transactionManager, System.Int32? portalId)
		{
			int count = -1;
			return GetByPortalId(transactionManager, portalId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_Portals key.
		///		FK_SC_Order_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByPortalId(TransactionManager transactionManager, System.Int32? portalId, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalId(transactionManager, portalId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_Portals key.
		///		fKSCOrderPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByPortalId(System.Int32? portalId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalId(null, portalId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_Portals key.
		///		fKSCOrderPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByPortalId(System.Int32? portalId, int start, int pageLength,out int count)
		{
			return GetByPortalId(null, portalId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_Portals key.
		///		FK_SC_Order_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Order> GetByPortalId(TransactionManager transactionManager, System.Int32? portalId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_SC_Shipping key.
		///		FK_SC_Order_SC_Shipping Description: 
		/// </summary>
		/// <param name="shippingID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByShippingID(System.Int32? shippingID)
		{
			int count = -1;
			return GetByShippingID(shippingID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_SC_Shipping key.
		///		FK_SC_Order_SC_Shipping Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByShippingID(TransactionManager transactionManager, System.Int32? shippingID)
		{
			int count = -1;
			return GetByShippingID(transactionManager, shippingID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_SC_Shipping key.
		///		FK_SC_Order_SC_Shipping Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByShippingID(TransactionManager transactionManager, System.Int32? shippingID, int start, int pageLength)
		{
			int count = -1;
			return GetByShippingID(transactionManager, shippingID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_SC_Shipping key.
		///		fKSCOrderSCShipping Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByShippingID(System.Int32? shippingID, int start, int pageLength)
		{
			int count =  -1;
			return GetByShippingID(null, shippingID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_SC_Shipping key.
		///		fKSCOrderSCShipping Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="shippingID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByShippingID(System.Int32? shippingID, int start, int pageLength,out int count)
		{
			return GetByShippingID(null, shippingID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_Order_SC_Shipping key.
		///		FK_SC_Order_SC_Shipping Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="shippingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Order> GetByShippingID(TransactionManager transactionManager, System.Int32? shippingID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrder_ZNodeCoupon key.
		///		FK_ZNodeOrder_ZNodeCoupon Description: 
		/// </summary>
		/// <param name="couponID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByCouponID(System.Int32? couponID)
		{
			int count = -1;
			return GetByCouponID(couponID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrder_ZNodeCoupon key.
		///		FK_ZNodeOrder_ZNodeCoupon Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByCouponID(TransactionManager transactionManager, System.Int32? couponID)
		{
			int count = -1;
			return GetByCouponID(transactionManager, couponID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrder_ZNodeCoupon key.
		///		FK_ZNodeOrder_ZNodeCoupon Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByCouponID(TransactionManager transactionManager, System.Int32? couponID, int start, int pageLength)
		{
			int count = -1;
			return GetByCouponID(transactionManager, couponID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrder_ZNodeCoupon key.
		///		fKZNodeOrderZNodeCoupon Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="couponID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByCouponID(System.Int32? couponID, int start, int pageLength)
		{
			int count =  -1;
			return GetByCouponID(null, couponID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrder_ZNodeCoupon key.
		///		fKZNodeOrderZNodeCoupon Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="couponID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByCouponID(System.Int32? couponID, int start, int pageLength,out int count)
		{
			return GetByCouponID(null, couponID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeOrder_ZNodeCoupon key.
		///		FK_ZNodeOrder_ZNodeCoupon Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="couponID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Order> GetByCouponID(TransactionManager transactionManager, System.Int32? couponID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_SC_Order_FK1 key.
		///		SC_OrderState_SC_Order_FK1 Description: 
		/// </summary>
		/// <param name="orderStateID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByOrderStateID(System.Int32? orderStateID)
		{
			int count = -1;
			return GetByOrderStateID(orderStateID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_SC_Order_FK1 key.
		///		SC_OrderState_SC_Order_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStateID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByOrderStateID(TransactionManager transactionManager, System.Int32? orderStateID)
		{
			int count = -1;
			return GetByOrderStateID(transactionManager, orderStateID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_SC_Order_FK1 key.
		///		SC_OrderState_SC_Order_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStateID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByOrderStateID(TransactionManager transactionManager, System.Int32? orderStateID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStateID(transactionManager, orderStateID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_SC_Order_FK1 key.
		///		sCOrderStateSCOrderFK1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderStateID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByOrderStateID(System.Int32? orderStateID, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderStateID(null, orderStateID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_SC_Order_FK1 key.
		///		sCOrderStateSCOrderFK1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderStateID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByOrderStateID(System.Int32? orderStateID, int start, int pageLength,out int count)
		{
			return GetByOrderStateID(null, orderStateID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_OrderState_SC_Order_FK1 key.
		///		SC_OrderState_SC_Order_FK1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderStateID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Order objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Order> GetByOrderStateID(TransactionManager transactionManager, System.Int32? orderStateID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Order Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.OrderKey key, int start, int pageLength)
		{
			return GetByOrderID(transactionManager, key.OrderID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SC_Order_PK index.
		/// </summary>
		/// <param name="orderID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Order GetByOrderID(System.Int32 orderID)
		{
			int count = -1;
			return GetByOrderID(null,orderID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Order_PK index.
		/// </summary>
		/// <param name="orderID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Order GetByOrderID(System.Int32 orderID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderID(null, orderID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Order_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Order GetByOrderID(TransactionManager transactionManager, System.Int32 orderID)
		{
			int count = -1;
			return GetByOrderID(transactionManager, orderID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Order_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Order GetByOrderID(TransactionManager transactionManager, System.Int32 orderID, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderID(transactionManager, orderID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Order_PK index.
		/// </summary>
		/// <param name="orderID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Order GetByOrderID(System.Int32 orderID, int start, int pageLength, out int count)
		{
			return GetByOrderID(null, orderID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SC_Order_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Order GetByOrderID(TransactionManager transactionManager, System.Int32 orderID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Account index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByAccountID(System.Int32? accountID)
		{
			int count = -1;
			return GetByAccountID(null,accountID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByAccountID(System.Int32? accountID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountID(null, accountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Order> GetByAccountID(System.Int32? accountID, int start, int pageLength, out int count)
		{
			return GetByAccountID(null, accountID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Order> GetByAccountID(TransactionManager transactionManager, System.Int32? accountID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Order&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Order> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Order> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Order c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Order" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderID"))?(int)0:(System.Int32)reader["OrderID"]).ToString();

					c = EntityManager.LocateOrCreate<Order>(
						key.ToString(), // EntityTrackingKey 
						"Order",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Order();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderID = (System.Int32)reader["OrderID"];
					c.PortalId = (reader.IsDBNull(reader.GetOrdinal("PortalId")))?null:(System.Int32?)reader["PortalId"];
					c.AccountID = (reader.IsDBNull(reader.GetOrdinal("AccountID")))?null:(System.Int32?)reader["AccountID"];
					c.OrderStateID = (reader.IsDBNull(reader.GetOrdinal("OrderStateID")))?null:(System.Int32?)reader["OrderStateID"];
					c.ShippingID = (reader.IsDBNull(reader.GetOrdinal("ShippingID")))?null:(System.Int32?)reader["ShippingID"];
					c.PaymentTypeId = (reader.IsDBNull(reader.GetOrdinal("PaymentTypeId")))?null:(System.Int32?)reader["PaymentTypeId"];
					c.ShipFirstName = (reader.IsDBNull(reader.GetOrdinal("ShipFirstName")))?null:(System.String)reader["ShipFirstName"];
					c.ShipLastName = (reader.IsDBNull(reader.GetOrdinal("ShipLastName")))?null:(System.String)reader["ShipLastName"];
					c.ShipCompanyName = (reader.IsDBNull(reader.GetOrdinal("ShipCompanyName")))?null:(System.String)reader["ShipCompanyName"];
					c.ShipStreet = (reader.IsDBNull(reader.GetOrdinal("ShipStreet")))?null:(System.String)reader["ShipStreet"];
					c.ShipStreet1 = (reader.IsDBNull(reader.GetOrdinal("ShipStreet1")))?null:(System.String)reader["ShipStreet1"];
					c.ShipCity = (reader.IsDBNull(reader.GetOrdinal("ShipCity")))?null:(System.String)reader["ShipCity"];
					c.ShipStateCode = (reader.IsDBNull(reader.GetOrdinal("ShipStateCode")))?null:(System.String)reader["ShipStateCode"];
					c.ShipPostalCode = (reader.IsDBNull(reader.GetOrdinal("ShipPostalCode")))?null:(System.String)reader["ShipPostalCode"];
					c.ShipCountry = (reader.IsDBNull(reader.GetOrdinal("ShipCountry")))?null:(System.String)reader["ShipCountry"];
					c.ShipPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("ShipPhoneNumber")))?null:(System.String)reader["ShipPhoneNumber"];
					c.ShipEmailID = (reader.IsDBNull(reader.GetOrdinal("ShipEmailID")))?null:(System.String)reader["ShipEmailID"];
					c.BillingFirstName = (reader.IsDBNull(reader.GetOrdinal("BillingFirstName")))?null:(System.String)reader["BillingFirstName"];
					c.BillingLastName = (reader.IsDBNull(reader.GetOrdinal("BillingLastName")))?null:(System.String)reader["BillingLastName"];
					c.BillingCompanyName = (reader.IsDBNull(reader.GetOrdinal("BillingCompanyName")))?null:(System.String)reader["BillingCompanyName"];
					c.BillingStreet = (reader.IsDBNull(reader.GetOrdinal("BillingStreet")))?null:(System.String)reader["BillingStreet"];
					c.BillingStreet1 = (reader.IsDBNull(reader.GetOrdinal("BillingStreet1")))?null:(System.String)reader["BillingStreet1"];
					c.BillingCity = (reader.IsDBNull(reader.GetOrdinal("BillingCity")))?null:(System.String)reader["BillingCity"];
					c.BillingStateCode = (reader.IsDBNull(reader.GetOrdinal("BillingStateCode")))?null:(System.String)reader["BillingStateCode"];
					c.BillingPostalCode = (reader.IsDBNull(reader.GetOrdinal("BillingPostalCode")))?null:(System.String)reader["BillingPostalCode"];
					c.BillingCountry = (reader.IsDBNull(reader.GetOrdinal("BillingCountry")))?null:(System.String)reader["BillingCountry"];
					c.BillingPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("BillingPhoneNumber")))?null:(System.String)reader["BillingPhoneNumber"];
					c.BillingEmailId = (reader.IsDBNull(reader.GetOrdinal("BillingEmailId")))?null:(System.String)reader["BillingEmailId"];
					c.CardTransactionID = (reader.IsDBNull(reader.GetOrdinal("CardTransactionID")))?null:(System.String)reader["CardTransactionID"];
					c.CardTypeId = (reader.IsDBNull(reader.GetOrdinal("CardTypeId")))?null:(System.Int32?)reader["CardTypeId"];
					c.CardEndsIn = (reader.IsDBNull(reader.GetOrdinal("CardEndsIn")))?null:(System.String)reader["CardEndsIn"];
					c.TaxCost = (reader.IsDBNull(reader.GetOrdinal("TaxCost")))?null:(System.Decimal?)reader["TaxCost"];
					c.ShippingCost = (reader.IsDBNull(reader.GetOrdinal("ShippingCost")))?null:(System.Decimal?)reader["ShippingCost"];
					c.SubTotal = (reader.IsDBNull(reader.GetOrdinal("SubTotal")))?null:(System.Decimal?)reader["SubTotal"];
					c.DiscountAmount = (reader.IsDBNull(reader.GetOrdinal("DiscountAmount")))?null:(System.Decimal?)reader["DiscountAmount"];
					c.Total = (reader.IsDBNull(reader.GetOrdinal("Total")))?null:(System.Decimal?)reader["Total"];
					c.CouponID = (reader.IsDBNull(reader.GetOrdinal("CouponID")))?null:(System.Int32?)reader["CouponID"];
					c.OrderDate = (reader.IsDBNull(reader.GetOrdinal("OrderDate")))?null:(System.DateTime?)reader["OrderDate"];
					c.CreditCardNumber = (reader.IsDBNull(reader.GetOrdinal("CreditCardNumber")))?null:(System.String)reader["CreditCardNumber"];
					c.CreditCardExp = (reader.IsDBNull(reader.GetOrdinal("CreditCardExp")))?null:(System.String)reader["CreditCardExp"];
					c.CreditCardCVV = (reader.IsDBNull(reader.GetOrdinal("CreditCardCVV")))?null:(System.String)reader["CreditCardCVV"];
					c.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
					c.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
					c.AdditionalInstructions = (reader.IsDBNull(reader.GetOrdinal("AdditionalInstructions")))?null:(System.String)reader["AdditionalInstructions"];
					c.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Order entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderID = (System.Int32)reader["OrderID"];
			entity.PortalId = (reader.IsDBNull(reader.GetOrdinal("PortalId")))?null:(System.Int32?)reader["PortalId"];
			entity.AccountID = (reader.IsDBNull(reader.GetOrdinal("AccountID")))?null:(System.Int32?)reader["AccountID"];
			entity.OrderStateID = (reader.IsDBNull(reader.GetOrdinal("OrderStateID")))?null:(System.Int32?)reader["OrderStateID"];
			entity.ShippingID = (reader.IsDBNull(reader.GetOrdinal("ShippingID")))?null:(System.Int32?)reader["ShippingID"];
			entity.PaymentTypeId = (reader.IsDBNull(reader.GetOrdinal("PaymentTypeId")))?null:(System.Int32?)reader["PaymentTypeId"];
			entity.ShipFirstName = (reader.IsDBNull(reader.GetOrdinal("ShipFirstName")))?null:(System.String)reader["ShipFirstName"];
			entity.ShipLastName = (reader.IsDBNull(reader.GetOrdinal("ShipLastName")))?null:(System.String)reader["ShipLastName"];
			entity.ShipCompanyName = (reader.IsDBNull(reader.GetOrdinal("ShipCompanyName")))?null:(System.String)reader["ShipCompanyName"];
			entity.ShipStreet = (reader.IsDBNull(reader.GetOrdinal("ShipStreet")))?null:(System.String)reader["ShipStreet"];
			entity.ShipStreet1 = (reader.IsDBNull(reader.GetOrdinal("ShipStreet1")))?null:(System.String)reader["ShipStreet1"];
			entity.ShipCity = (reader.IsDBNull(reader.GetOrdinal("ShipCity")))?null:(System.String)reader["ShipCity"];
			entity.ShipStateCode = (reader.IsDBNull(reader.GetOrdinal("ShipStateCode")))?null:(System.String)reader["ShipStateCode"];
			entity.ShipPostalCode = (reader.IsDBNull(reader.GetOrdinal("ShipPostalCode")))?null:(System.String)reader["ShipPostalCode"];
			entity.ShipCountry = (reader.IsDBNull(reader.GetOrdinal("ShipCountry")))?null:(System.String)reader["ShipCountry"];
			entity.ShipPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("ShipPhoneNumber")))?null:(System.String)reader["ShipPhoneNumber"];
			entity.ShipEmailID = (reader.IsDBNull(reader.GetOrdinal("ShipEmailID")))?null:(System.String)reader["ShipEmailID"];
			entity.BillingFirstName = (reader.IsDBNull(reader.GetOrdinal("BillingFirstName")))?null:(System.String)reader["BillingFirstName"];
			entity.BillingLastName = (reader.IsDBNull(reader.GetOrdinal("BillingLastName")))?null:(System.String)reader["BillingLastName"];
			entity.BillingCompanyName = (reader.IsDBNull(reader.GetOrdinal("BillingCompanyName")))?null:(System.String)reader["BillingCompanyName"];
			entity.BillingStreet = (reader.IsDBNull(reader.GetOrdinal("BillingStreet")))?null:(System.String)reader["BillingStreet"];
			entity.BillingStreet1 = (reader.IsDBNull(reader.GetOrdinal("BillingStreet1")))?null:(System.String)reader["BillingStreet1"];
			entity.BillingCity = (reader.IsDBNull(reader.GetOrdinal("BillingCity")))?null:(System.String)reader["BillingCity"];
			entity.BillingStateCode = (reader.IsDBNull(reader.GetOrdinal("BillingStateCode")))?null:(System.String)reader["BillingStateCode"];
			entity.BillingPostalCode = (reader.IsDBNull(reader.GetOrdinal("BillingPostalCode")))?null:(System.String)reader["BillingPostalCode"];
			entity.BillingCountry = (reader.IsDBNull(reader.GetOrdinal("BillingCountry")))?null:(System.String)reader["BillingCountry"];
			entity.BillingPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("BillingPhoneNumber")))?null:(System.String)reader["BillingPhoneNumber"];
			entity.BillingEmailId = (reader.IsDBNull(reader.GetOrdinal("BillingEmailId")))?null:(System.String)reader["BillingEmailId"];
			entity.CardTransactionID = (reader.IsDBNull(reader.GetOrdinal("CardTransactionID")))?null:(System.String)reader["CardTransactionID"];
			entity.CardTypeId = (reader.IsDBNull(reader.GetOrdinal("CardTypeId")))?null:(System.Int32?)reader["CardTypeId"];
			entity.CardEndsIn = (reader.IsDBNull(reader.GetOrdinal("CardEndsIn")))?null:(System.String)reader["CardEndsIn"];
			entity.TaxCost = (reader.IsDBNull(reader.GetOrdinal("TaxCost")))?null:(System.Decimal?)reader["TaxCost"];
			entity.ShippingCost = (reader.IsDBNull(reader.GetOrdinal("ShippingCost")))?null:(System.Decimal?)reader["ShippingCost"];
			entity.SubTotal = (reader.IsDBNull(reader.GetOrdinal("SubTotal")))?null:(System.Decimal?)reader["SubTotal"];
			entity.DiscountAmount = (reader.IsDBNull(reader.GetOrdinal("DiscountAmount")))?null:(System.Decimal?)reader["DiscountAmount"];
			entity.Total = (reader.IsDBNull(reader.GetOrdinal("Total")))?null:(System.Decimal?)reader["Total"];
			entity.CouponID = (reader.IsDBNull(reader.GetOrdinal("CouponID")))?null:(System.Int32?)reader["CouponID"];
			entity.OrderDate = (reader.IsDBNull(reader.GetOrdinal("OrderDate")))?null:(System.DateTime?)reader["OrderDate"];
			entity.CreditCardNumber = (reader.IsDBNull(reader.GetOrdinal("CreditCardNumber")))?null:(System.String)reader["CreditCardNumber"];
			entity.CreditCardExp = (reader.IsDBNull(reader.GetOrdinal("CreditCardExp")))?null:(System.String)reader["CreditCardExp"];
			entity.CreditCardCVV = (reader.IsDBNull(reader.GetOrdinal("CreditCardCVV")))?null:(System.String)reader["CreditCardCVV"];
			entity.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
			entity.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
			entity.AdditionalInstructions = (reader.IsDBNull(reader.GetOrdinal("AdditionalInstructions")))?null:(System.String)reader["AdditionalInstructions"];
			entity.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Order entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderID = (System.Int32)dataRow["OrderID"];
			entity.PortalId = (Convert.IsDBNull(dataRow["PortalId"]))?null:(System.Int32?)dataRow["PortalId"];
			entity.AccountID = (Convert.IsDBNull(dataRow["AccountID"]))?null:(System.Int32?)dataRow["AccountID"];
			entity.OrderStateID = (Convert.IsDBNull(dataRow["OrderStateID"]))?null:(System.Int32?)dataRow["OrderStateID"];
			entity.ShippingID = (Convert.IsDBNull(dataRow["ShippingID"]))?null:(System.Int32?)dataRow["ShippingID"];
			entity.PaymentTypeId = (Convert.IsDBNull(dataRow["PaymentTypeId"]))?null:(System.Int32?)dataRow["PaymentTypeId"];
			entity.ShipFirstName = (Convert.IsDBNull(dataRow["ShipFirstName"]))?null:(System.String)dataRow["ShipFirstName"];
			entity.ShipLastName = (Convert.IsDBNull(dataRow["ShipLastName"]))?null:(System.String)dataRow["ShipLastName"];
			entity.ShipCompanyName = (Convert.IsDBNull(dataRow["ShipCompanyName"]))?null:(System.String)dataRow["ShipCompanyName"];
			entity.ShipStreet = (Convert.IsDBNull(dataRow["ShipStreet"]))?null:(System.String)dataRow["ShipStreet"];
			entity.ShipStreet1 = (Convert.IsDBNull(dataRow["ShipStreet1"]))?null:(System.String)dataRow["ShipStreet1"];
			entity.ShipCity = (Convert.IsDBNull(dataRow["ShipCity"]))?null:(System.String)dataRow["ShipCity"];
			entity.ShipStateCode = (Convert.IsDBNull(dataRow["ShipStateCode"]))?null:(System.String)dataRow["ShipStateCode"];
			entity.ShipPostalCode = (Convert.IsDBNull(dataRow["ShipPostalCode"]))?null:(System.String)dataRow["ShipPostalCode"];
			entity.ShipCountry = (Convert.IsDBNull(dataRow["ShipCountry"]))?null:(System.String)dataRow["ShipCountry"];
			entity.ShipPhoneNumber = (Convert.IsDBNull(dataRow["ShipPhoneNumber"]))?null:(System.String)dataRow["ShipPhoneNumber"];
			entity.ShipEmailID = (Convert.IsDBNull(dataRow["ShipEmailID"]))?null:(System.String)dataRow["ShipEmailID"];
			entity.BillingFirstName = (Convert.IsDBNull(dataRow["BillingFirstName"]))?null:(System.String)dataRow["BillingFirstName"];
			entity.BillingLastName = (Convert.IsDBNull(dataRow["BillingLastName"]))?null:(System.String)dataRow["BillingLastName"];
			entity.BillingCompanyName = (Convert.IsDBNull(dataRow["BillingCompanyName"]))?null:(System.String)dataRow["BillingCompanyName"];
			entity.BillingStreet = (Convert.IsDBNull(dataRow["BillingStreet"]))?null:(System.String)dataRow["BillingStreet"];
			entity.BillingStreet1 = (Convert.IsDBNull(dataRow["BillingStreet1"]))?null:(System.String)dataRow["BillingStreet1"];
			entity.BillingCity = (Convert.IsDBNull(dataRow["BillingCity"]))?null:(System.String)dataRow["BillingCity"];
			entity.BillingStateCode = (Convert.IsDBNull(dataRow["BillingStateCode"]))?null:(System.String)dataRow["BillingStateCode"];
			entity.BillingPostalCode = (Convert.IsDBNull(dataRow["BillingPostalCode"]))?null:(System.String)dataRow["BillingPostalCode"];
			entity.BillingCountry = (Convert.IsDBNull(dataRow["BillingCountry"]))?null:(System.String)dataRow["BillingCountry"];
			entity.BillingPhoneNumber = (Convert.IsDBNull(dataRow["BillingPhoneNumber"]))?null:(System.String)dataRow["BillingPhoneNumber"];
			entity.BillingEmailId = (Convert.IsDBNull(dataRow["BillingEmailId"]))?null:(System.String)dataRow["BillingEmailId"];
			entity.CardTransactionID = (Convert.IsDBNull(dataRow["CardTransactionID"]))?null:(System.String)dataRow["CardTransactionID"];
			entity.CardTypeId = (Convert.IsDBNull(dataRow["CardTypeId"]))?null:(System.Int32?)dataRow["CardTypeId"];
			entity.CardEndsIn = (Convert.IsDBNull(dataRow["CardEndsIn"]))?null:(System.String)dataRow["CardEndsIn"];
			entity.TaxCost = (Convert.IsDBNull(dataRow["TaxCost"]))?null:(System.Decimal?)dataRow["TaxCost"];
			entity.ShippingCost = (Convert.IsDBNull(dataRow["ShippingCost"]))?null:(System.Decimal?)dataRow["ShippingCost"];
			entity.SubTotal = (Convert.IsDBNull(dataRow["SubTotal"]))?null:(System.Decimal?)dataRow["SubTotal"];
			entity.DiscountAmount = (Convert.IsDBNull(dataRow["DiscountAmount"]))?null:(System.Decimal?)dataRow["DiscountAmount"];
			entity.Total = (Convert.IsDBNull(dataRow["Total"]))?null:(System.Decimal?)dataRow["Total"];
			entity.CouponID = (Convert.IsDBNull(dataRow["CouponID"]))?null:(System.Int32?)dataRow["CouponID"];
			entity.OrderDate = (Convert.IsDBNull(dataRow["OrderDate"]))?null:(System.DateTime?)dataRow["OrderDate"];
			entity.CreditCardNumber = (Convert.IsDBNull(dataRow["CreditCardNumber"]))?null:(System.String)dataRow["CreditCardNumber"];
			entity.CreditCardExp = (Convert.IsDBNull(dataRow["CreditCardExp"]))?null:(System.String)dataRow["CreditCardExp"];
			entity.CreditCardCVV = (Convert.IsDBNull(dataRow["CreditCardCVV"]))?null:(System.String)dataRow["CreditCardCVV"];
			entity.Custom1 = (Convert.IsDBNull(dataRow["Custom1"]))?null:(System.String)dataRow["Custom1"];
			entity.Custom2 = (Convert.IsDBNull(dataRow["Custom2"]))?null:(System.String)dataRow["Custom2"];
			entity.AdditionalInstructions = (Convert.IsDBNull(dataRow["AdditionalInstructions"]))?null:(System.String)dataRow["AdditionalInstructions"];
			entity.Custom3 = (Convert.IsDBNull(dataRow["Custom3"]))?null:(System.String)dataRow["Custom3"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Order"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Order Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Order entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region PortalIdSource	
			if (CanDeepLoad(entity, "Portal", "PortalIdSource", deepLoadType, innerList) 
				&& entity.PortalIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PortalId ?? (int)0);
				Portal tmpEntity = EntityManager.LocateEntity<Portal>(EntityLocator.ConstructKeyFromPkItems(typeof(Portal), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PortalIdSource = tmpEntity;
				else
					entity.PortalIdSource = DataRepository.PortalProvider.GetByPortalID((entity.PortalId ?? (int)0));
			
				if (deep && entity.PortalIdSource != null)
				{
					DataRepository.PortalProvider.DeepLoad(transactionManager, entity.PortalIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PortalIdSource

			#region ShippingIDSource	
			if (CanDeepLoad(entity, "Shipping", "ShippingIDSource", deepLoadType, innerList) 
				&& entity.ShippingIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ShippingID ?? (int)0);
				Shipping tmpEntity = EntityManager.LocateEntity<Shipping>(EntityLocator.ConstructKeyFromPkItems(typeof(Shipping), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShippingIDSource = tmpEntity;
				else
					entity.ShippingIDSource = DataRepository.ShippingProvider.GetByShippingID((entity.ShippingID ?? (int)0));
			
				if (deep && entity.ShippingIDSource != null)
				{
					DataRepository.ShippingProvider.DeepLoad(transactionManager, entity.ShippingIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ShippingIDSource

			#region AccountIDSource	
			if (CanDeepLoad(entity, "Account", "AccountIDSource", deepLoadType, innerList) 
				&& entity.AccountIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AccountID ?? (int)0);
				Account tmpEntity = EntityManager.LocateEntity<Account>(EntityLocator.ConstructKeyFromPkItems(typeof(Account), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccountIDSource = tmpEntity;
				else
					entity.AccountIDSource = DataRepository.AccountProvider.GetByAccountID((entity.AccountID ?? (int)0));
			
				if (deep && entity.AccountIDSource != null)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.AccountIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion AccountIDSource

			#region CouponIDSource	
			if (CanDeepLoad(entity, "Coupon", "CouponIDSource", deepLoadType, innerList) 
				&& entity.CouponIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CouponID ?? (int)0);
				Coupon tmpEntity = EntityManager.LocateEntity<Coupon>(EntityLocator.ConstructKeyFromPkItems(typeof(Coupon), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CouponIDSource = tmpEntity;
				else
					entity.CouponIDSource = DataRepository.CouponProvider.GetByCouponID((entity.CouponID ?? (int)0));
			
				if (deep && entity.CouponIDSource != null)
				{
					DataRepository.CouponProvider.DeepLoad(transactionManager, entity.CouponIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CouponIDSource

			#region OrderStateIDSource	
			if (CanDeepLoad(entity, "OrderState", "OrderStateIDSource", deepLoadType, innerList) 
				&& entity.OrderStateIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.OrderStateID ?? (int)0);
				OrderState tmpEntity = EntityManager.LocateEntity<OrderState>(EntityLocator.ConstructKeyFromPkItems(typeof(OrderState), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderStateIDSource = tmpEntity;
				else
					entity.OrderStateIDSource = DataRepository.OrderStateProvider.GetByOrderStateID((entity.OrderStateID ?? (int)0));
			
				if (deep && entity.OrderStateIDSource != null)
				{
					DataRepository.OrderStateProvider.DeepLoad(transactionManager, entity.OrderStateIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion OrderStateIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByOrderID methods when available
			
			#region OrderLineItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderLineItem>", "OrderLineItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderLineItemCollection' loaded.");
				#endif 

				entity.OrderLineItemCollection = DataRepository.OrderLineItemProvider.GetByOrderID(transactionManager, entity.OrderID);

				if (deep && entity.OrderLineItemCollection.Count > 0)
				{
					DataRepository.OrderLineItemProvider.DeepLoad(transactionManager, entity.OrderLineItemCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Order object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Order instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Order Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Order entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PortalIdSource
			if (CanDeepSave(entity, "Portal", "PortalIdSource", deepSaveType, innerList) 
				&& entity.PortalIdSource != null)
			{
				DataRepository.PortalProvider.Save(transactionManager, entity.PortalIdSource);
				entity.PortalId = entity.PortalIdSource.PortalID;
			}
			#endregion 
			
			#region ShippingIDSource
			if (CanDeepSave(entity, "Shipping", "ShippingIDSource", deepSaveType, innerList) 
				&& entity.ShippingIDSource != null)
			{
				DataRepository.ShippingProvider.Save(transactionManager, entity.ShippingIDSource);
				entity.ShippingID = entity.ShippingIDSource.ShippingID;
			}
			#endregion 
			
			#region AccountIDSource
			if (CanDeepSave(entity, "Account", "AccountIDSource", deepSaveType, innerList) 
				&& entity.AccountIDSource != null)
			{
				DataRepository.AccountProvider.Save(transactionManager, entity.AccountIDSource);
				entity.AccountID = entity.AccountIDSource.AccountID;
			}
			#endregion 
			
			#region CouponIDSource
			if (CanDeepSave(entity, "Coupon", "CouponIDSource", deepSaveType, innerList) 
				&& entity.CouponIDSource != null)
			{
				DataRepository.CouponProvider.Save(transactionManager, entity.CouponIDSource);
				entity.CouponID = entity.CouponIDSource.CouponID;
			}
			#endregion 
			
			#region OrderStateIDSource
			if (CanDeepSave(entity, "OrderState", "OrderStateIDSource", deepSaveType, innerList) 
				&& entity.OrderStateIDSource != null)
			{
				DataRepository.OrderStateProvider.Save(transactionManager, entity.OrderStateIDSource);
				entity.OrderStateID = entity.OrderStateIDSource.OrderStateID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			



			#region List<OrderLineItem>
				if (CanDeepSave(entity, "List<OrderLineItem>", "OrderLineItemCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(OrderLineItem child in entity.OrderLineItemCollection)
					{
						child.OrderID = entity.OrderID;
					}
				
				if (entity.OrderLineItemCollection.Count > 0 || entity.OrderLineItemCollection.DeletedItems.Count > 0)
					DataRepository.OrderLineItemProvider.DeepSave(transactionManager, entity.OrderLineItemCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

						
			return true;
		}
		#endregion
	} // end class
	
	#region OrderChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Order</c>
	///</summary>
	public enum OrderChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIdSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
			
		///<summary>
		/// Composite Property for <c>Shipping</c> at ShippingIDSource
		///</summary>
		[ChildEntityType(typeof(Shipping))]
		Shipping,
			
		///<summary>
		/// Composite Property for <c>Account</c> at AccountIDSource
		///</summary>
		[ChildEntityType(typeof(Account))]
		Account,
			
		///<summary>
		/// Composite Property for <c>Coupon</c> at CouponIDSource
		///</summary>
		[ChildEntityType(typeof(Coupon))]
		Coupon,
			
		///<summary>
		/// Composite Property for <c>OrderState</c> at OrderStateIDSource
		///</summary>
		[ChildEntityType(typeof(OrderState))]
		OrderState,
	
		///<summary>
		/// Collection of <c>Order</c> as OneToMany for OrderLineItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderLineItem>))]
		OrderLineItemCollection,
	}
	
	#endregion OrderChildEntityTypes
	
	#region OrderFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Order"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderFilterBuilder : SqlFilterBuilder<OrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderFilterBuilder class.
		/// </summary>
		public OrderFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderFilterBuilder
	
	#region OrderParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Order"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderParameterBuilder : ParameterizedSqlFilterBuilder<OrderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderParameterBuilder class.
		/// </summary>
		public OrderParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderParameterBuilder
} // end namespace
