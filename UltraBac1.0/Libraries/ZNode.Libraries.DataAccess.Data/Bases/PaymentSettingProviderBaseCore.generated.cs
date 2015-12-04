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
	/// This class is the base class for any <see cref="PaymentSettingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PaymentSettingProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.PaymentSetting, ZNode.Libraries.DataAccess.Entities.PaymentSettingKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentSettingKey key)
		{
			return Delete(transactionManager, key.PaymentSettingID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="paymentSettingID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 paymentSettingID)
		{
			return Delete(null, paymentSettingID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentSettingID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 paymentSettingID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_Gateway key.
		///		FK_SC_PaymentSetting_SC_Gateway Description: 
		/// </summary>
		/// <param name="gatewayTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByGatewayTypeID(System.Int32? gatewayTypeID)
		{
			int count = -1;
			return GetByGatewayTypeID(gatewayTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_Gateway key.
		///		FK_SC_PaymentSetting_SC_Gateway Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="gatewayTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByGatewayTypeID(TransactionManager transactionManager, System.Int32? gatewayTypeID)
		{
			int count = -1;
			return GetByGatewayTypeID(transactionManager, gatewayTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_Gateway key.
		///		FK_SC_PaymentSetting_SC_Gateway Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="gatewayTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByGatewayTypeID(TransactionManager transactionManager, System.Int32? gatewayTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByGatewayTypeID(transactionManager, gatewayTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_Gateway key.
		///		fKSCPaymentSettingSCGateway Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="gatewayTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByGatewayTypeID(System.Int32? gatewayTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByGatewayTypeID(null, gatewayTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_Gateway key.
		///		fKSCPaymentSettingSCGateway Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="gatewayTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByGatewayTypeID(System.Int32? gatewayTypeID, int start, int pageLength,out int count)
		{
			return GetByGatewayTypeID(null, gatewayTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_Gateway key.
		///		FK_SC_PaymentSetting_SC_Gateway Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="gatewayTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByGatewayTypeID(TransactionManager transactionManager, System.Int32? gatewayTypeID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_PaymentType key.
		///		FK_SC_PaymentSetting_SC_PaymentType Description: 
		/// </summary>
		/// <param name="paymentTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByPaymentTypeID(System.Int32 paymentTypeID)
		{
			int count = -1;
			return GetByPaymentTypeID(paymentTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_PaymentType key.
		///		FK_SC_PaymentSetting_SC_PaymentType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByPaymentTypeID(TransactionManager transactionManager, System.Int32 paymentTypeID)
		{
			int count = -1;
			return GetByPaymentTypeID(transactionManager, paymentTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_PaymentType key.
		///		FK_SC_PaymentSetting_SC_PaymentType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByPaymentTypeID(TransactionManager transactionManager, System.Int32 paymentTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByPaymentTypeID(transactionManager, paymentTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_PaymentType key.
		///		fKSCPaymentSettingSCPaymentType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="paymentTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByPaymentTypeID(System.Int32 paymentTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPaymentTypeID(null, paymentTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_PaymentType key.
		///		fKSCPaymentSettingSCPaymentType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="paymentTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByPaymentTypeID(System.Int32 paymentTypeID, int start, int pageLength,out int count)
		{
			return GetByPaymentTypeID(null, paymentTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SC_PaymentSetting_SC_PaymentType key.
		///		FK_SC_PaymentSetting_SC_PaymentType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.PaymentSetting objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByPaymentTypeID(TransactionManager transactionManager, System.Int32 paymentTypeID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.PaymentSetting Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentSettingKey key, int start, int pageLength)
		{
			return GetByPaymentSettingID(transactionManager, key.PaymentSettingID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SC_PaymentSetting index.
		/// </summary>
		/// <param name="paymentSettingID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentSetting GetByPaymentSettingID(System.Int32 paymentSettingID)
		{
			int count = -1;
			return GetByPaymentSettingID(null,paymentSettingID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentSetting index.
		/// </summary>
		/// <param name="paymentSettingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentSetting GetByPaymentSettingID(System.Int32 paymentSettingID, int start, int pageLength)
		{
			int count = -1;
			return GetByPaymentSettingID(null, paymentSettingID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentSetting index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentSettingID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentSetting GetByPaymentSettingID(TransactionManager transactionManager, System.Int32 paymentSettingID)
		{
			int count = -1;
			return GetByPaymentSettingID(transactionManager, paymentSettingID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentSetting index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentSettingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentSetting GetByPaymentSettingID(TransactionManager transactionManager, System.Int32 paymentSettingID, int start, int pageLength)
		{
			int count = -1;
			return GetByPaymentSettingID(transactionManager, paymentSettingID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentSetting index.
		/// </summary>
		/// <param name="paymentSettingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.PaymentSetting GetByPaymentSettingID(System.Int32 paymentSettingID, int start, int pageLength, out int count)
		{
			return GetByPaymentSettingID(null, paymentSettingID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SC_PaymentSetting index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="paymentSettingID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.PaymentSetting GetByPaymentSettingID(TransactionManager transactionManager, System.Int32 paymentSettingID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX1 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="paymentTypeID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileIDPaymentTypeID(System.Int32 profileID, System.Int32 paymentTypeID)
		{
			int count = -1;
			return GetByProfileIDPaymentTypeID(null,profileID, paymentTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileIDPaymentTypeID(System.Int32 profileID, System.Int32 paymentTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileIDPaymentTypeID(null, profileID, paymentTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="paymentTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileIDPaymentTypeID(TransactionManager transactionManager, System.Int32 profileID, System.Int32 paymentTypeID)
		{
			int count = -1;
			return GetByProfileIDPaymentTypeID(transactionManager, profileID, paymentTypeID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileIDPaymentTypeID(TransactionManager transactionManager, System.Int32 profileID, System.Int32 paymentTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileIDPaymentTypeID(transactionManager, profileID, paymentTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileIDPaymentTypeID(System.Int32 profileID, System.Int32 paymentTypeID, int start, int pageLength, out int count)
		{
			return GetByProfileIDPaymentTypeID(null, profileID, paymentTypeID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="paymentTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileIDPaymentTypeID(TransactionManager transactionManager, System.Int32 profileID, System.Int32 paymentTypeID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ix2 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileID(System.Int32 profileID)
		{
			int count = -1;
			return GetByProfileID(null,profileID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix2 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileID(System.Int32 profileID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileID(null, profileID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileID(TransactionManager transactionManager, System.Int32 profileID)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileID(TransactionManager transactionManager, System.Int32 profileID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ix2 index.
		/// </summary>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileID(System.Int32 profileID, int start, int pageLength, out int count)
		{
			return GetByProfileID(null, profileID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ix2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> GetByProfileID(TransactionManager transactionManager, System.Int32 profileID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;PaymentSetting&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.PaymentSetting c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"PaymentSetting" 
							+ (reader.IsDBNull(reader.GetOrdinal("PaymentSettingID"))?(int)0:(System.Int32)reader["PaymentSettingID"]).ToString();

					c = EntityManager.LocateOrCreate<PaymentSetting>(
						key.ToString(), // EntityTrackingKey 
						"PaymentSetting",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.PaymentSetting();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.PaymentSettingID = (System.Int32)reader["PaymentSettingID"];
					c.PaymentTypeID = (System.Int32)reader["PaymentTypeID"];
					c.ProfileID = (System.Int32)reader["ProfileID"];
					c.GatewayTypeID = (reader.IsDBNull(reader.GetOrdinal("GatewayTypeID")))?null:(System.Int32?)reader["GatewayTypeID"];
					c.GatewayUsername = (reader.IsDBNull(reader.GetOrdinal("GatewayUsername")))?null:(System.String)reader["GatewayUsername"];
					c.GatewayPassword = (reader.IsDBNull(reader.GetOrdinal("GatewayPassword")))?null:(System.String)reader["GatewayPassword"];
					c.EnableVisa = (reader.IsDBNull(reader.GetOrdinal("EnableVisa")))?null:(System.Boolean?)reader["EnableVisa"];
					c.EnableMasterCard = (reader.IsDBNull(reader.GetOrdinal("EnableMasterCard")))?null:(System.Boolean?)reader["EnableMasterCard"];
					c.EnableAmex = (reader.IsDBNull(reader.GetOrdinal("EnableAmex")))?null:(System.Boolean?)reader["EnableAmex"];
					c.EnableDiscover = (reader.IsDBNull(reader.GetOrdinal("EnableDiscover")))?null:(System.Boolean?)reader["EnableDiscover"];
					c.TransactionKey = (reader.IsDBNull(reader.GetOrdinal("TransactionKey")))?null:(System.String)reader["TransactionKey"];
					c.ActiveInd = (System.Boolean)reader["ActiveInd"];
					c.DisplayOrder = (System.Byte)reader["DisplayOrder"];
					c.TestMode = (System.Boolean)reader["TestMode"];
					c.OfflineMode = (reader.IsDBNull(reader.GetOrdinal("OfflineMode")))?null:(System.Boolean?)reader["OfflineMode"];
					c.SaveCreditCartInfo = (reader.IsDBNull(reader.GetOrdinal("SaveCreditCartInfo")))?null:(System.Boolean?)reader["SaveCreditCartInfo"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.PaymentSetting entity)
		{
			if (!reader.Read()) return;
			
			entity.PaymentSettingID = (System.Int32)reader["PaymentSettingID"];
			entity.PaymentTypeID = (System.Int32)reader["PaymentTypeID"];
			entity.ProfileID = (System.Int32)reader["ProfileID"];
			entity.GatewayTypeID = (reader.IsDBNull(reader.GetOrdinal("GatewayTypeID")))?null:(System.Int32?)reader["GatewayTypeID"];
			entity.GatewayUsername = (reader.IsDBNull(reader.GetOrdinal("GatewayUsername")))?null:(System.String)reader["GatewayUsername"];
			entity.GatewayPassword = (reader.IsDBNull(reader.GetOrdinal("GatewayPassword")))?null:(System.String)reader["GatewayPassword"];
			entity.EnableVisa = (reader.IsDBNull(reader.GetOrdinal("EnableVisa")))?null:(System.Boolean?)reader["EnableVisa"];
			entity.EnableMasterCard = (reader.IsDBNull(reader.GetOrdinal("EnableMasterCard")))?null:(System.Boolean?)reader["EnableMasterCard"];
			entity.EnableAmex = (reader.IsDBNull(reader.GetOrdinal("EnableAmex")))?null:(System.Boolean?)reader["EnableAmex"];
			entity.EnableDiscover = (reader.IsDBNull(reader.GetOrdinal("EnableDiscover")))?null:(System.Boolean?)reader["EnableDiscover"];
			entity.TransactionKey = (reader.IsDBNull(reader.GetOrdinal("TransactionKey")))?null:(System.String)reader["TransactionKey"];
			entity.ActiveInd = (System.Boolean)reader["ActiveInd"];
			entity.DisplayOrder = (System.Byte)reader["DisplayOrder"];
			entity.TestMode = (System.Boolean)reader["TestMode"];
			entity.OfflineMode = (reader.IsDBNull(reader.GetOrdinal("OfflineMode")))?null:(System.Boolean?)reader["OfflineMode"];
			entity.SaveCreditCartInfo = (reader.IsDBNull(reader.GetOrdinal("SaveCreditCartInfo")))?null:(System.Boolean?)reader["SaveCreditCartInfo"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.PaymentSetting entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PaymentSettingID = (System.Int32)dataRow["PaymentSettingID"];
			entity.PaymentTypeID = (System.Int32)dataRow["PaymentTypeID"];
			entity.ProfileID = (System.Int32)dataRow["ProfileID"];
			entity.GatewayTypeID = (Convert.IsDBNull(dataRow["GatewayTypeID"]))?null:(System.Int32?)dataRow["GatewayTypeID"];
			entity.GatewayUsername = (Convert.IsDBNull(dataRow["GatewayUsername"]))?null:(System.String)dataRow["GatewayUsername"];
			entity.GatewayPassword = (Convert.IsDBNull(dataRow["GatewayPassword"]))?null:(System.String)dataRow["GatewayPassword"];
			entity.EnableVisa = (Convert.IsDBNull(dataRow["EnableVisa"]))?null:(System.Boolean?)dataRow["EnableVisa"];
			entity.EnableMasterCard = (Convert.IsDBNull(dataRow["EnableMasterCard"]))?null:(System.Boolean?)dataRow["EnableMasterCard"];
			entity.EnableAmex = (Convert.IsDBNull(dataRow["EnableAmex"]))?null:(System.Boolean?)dataRow["EnableAmex"];
			entity.EnableDiscover = (Convert.IsDBNull(dataRow["EnableDiscover"]))?null:(System.Boolean?)dataRow["EnableDiscover"];
			entity.TransactionKey = (Convert.IsDBNull(dataRow["TransactionKey"]))?null:(System.String)dataRow["TransactionKey"];
			entity.ActiveInd = (System.Boolean)dataRow["ActiveInd"];
			entity.DisplayOrder = (System.Byte)dataRow["DisplayOrder"];
			entity.TestMode = (System.Boolean)dataRow["TestMode"];
			entity.OfflineMode = (Convert.IsDBNull(dataRow["OfflineMode"]))?null:(System.Boolean?)dataRow["OfflineMode"];
			entity.SaveCreditCartInfo = (Convert.IsDBNull(dataRow["SaveCreditCartInfo"]))?null:(System.Boolean?)dataRow["SaveCreditCartInfo"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.PaymentSetting"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.PaymentSetting Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentSetting entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region GatewayTypeIDSource	
			if (CanDeepLoad(entity, "Gateway", "GatewayTypeIDSource", deepLoadType, innerList) 
				&& entity.GatewayTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.GatewayTypeID ?? (int)0);
				Gateway tmpEntity = EntityManager.LocateEntity<Gateway>(EntityLocator.ConstructKeyFromPkItems(typeof(Gateway), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GatewayTypeIDSource = tmpEntity;
				else
					entity.GatewayTypeIDSource = DataRepository.GatewayProvider.GetByGatewayTypeID((entity.GatewayTypeID ?? (int)0));
			
				if (deep && entity.GatewayTypeIDSource != null)
				{
					DataRepository.GatewayProvider.DeepLoad(transactionManager, entity.GatewayTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion GatewayTypeIDSource

			#region PaymentTypeIDSource	
			if (CanDeepLoad(entity, "PaymentType", "PaymentTypeIDSource", deepLoadType, innerList) 
				&& entity.PaymentTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PaymentTypeID;
				PaymentType tmpEntity = EntityManager.LocateEntity<PaymentType>(EntityLocator.ConstructKeyFromPkItems(typeof(PaymentType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PaymentTypeIDSource = tmpEntity;
				else
					entity.PaymentTypeIDSource = DataRepository.PaymentTypeProvider.GetByPaymentTypeID(entity.PaymentTypeID);
			
				if (deep && entity.PaymentTypeIDSource != null)
				{
					DataRepository.PaymentTypeProvider.DeepLoad(transactionManager, entity.PaymentTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PaymentTypeIDSource

			#region ProfileIDSource	
			if (CanDeepLoad(entity, "Profile", "ProfileIDSource", deepLoadType, innerList) 
				&& entity.ProfileIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProfileID;
				Profile tmpEntity = EntityManager.LocateEntity<Profile>(EntityLocator.ConstructKeyFromPkItems(typeof(Profile), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProfileIDSource = tmpEntity;
				else
					entity.ProfileIDSource = DataRepository.ProfileProvider.GetByProfileID(entity.ProfileID);
			
				if (deep && entity.ProfileIDSource != null)
				{
					DataRepository.ProfileProvider.DeepLoad(transactionManager, entity.ProfileIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProfileIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.PaymentSetting object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.PaymentSetting instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.PaymentSetting Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.PaymentSetting entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GatewayTypeIDSource
			if (CanDeepSave(entity, "Gateway", "GatewayTypeIDSource", deepSaveType, innerList) 
				&& entity.GatewayTypeIDSource != null)
			{
				DataRepository.GatewayProvider.Save(transactionManager, entity.GatewayTypeIDSource);
				entity.GatewayTypeID = entity.GatewayTypeIDSource.GatewayTypeID;
			}
			#endregion 
			
			#region PaymentTypeIDSource
			if (CanDeepSave(entity, "PaymentType", "PaymentTypeIDSource", deepSaveType, innerList) 
				&& entity.PaymentTypeIDSource != null)
			{
				DataRepository.PaymentTypeProvider.Save(transactionManager, entity.PaymentTypeIDSource);
				entity.PaymentTypeID = entity.PaymentTypeIDSource.PaymentTypeID;
			}
			#endregion 
			
			#region ProfileIDSource
			if (CanDeepSave(entity, "Profile", "ProfileIDSource", deepSaveType, innerList) 
				&& entity.ProfileIDSource != null)
			{
				DataRepository.ProfileProvider.Save(transactionManager, entity.ProfileIDSource);
				entity.ProfileID = entity.ProfileIDSource.ProfileID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			
						
			return true;
		}
		#endregion
	} // end class
	
	#region PaymentSettingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.PaymentSetting</c>
	///</summary>
	public enum PaymentSettingChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Gateway</c> at GatewayTypeIDSource
		///</summary>
		[ChildEntityType(typeof(Gateway))]
		Gateway,
			
		///<summary>
		/// Composite Property for <c>PaymentType</c> at PaymentTypeIDSource
		///</summary>
		[ChildEntityType(typeof(PaymentType))]
		PaymentType,
			
		///<summary>
		/// Composite Property for <c>Profile</c> at ProfileIDSource
		///</summary>
		[ChildEntityType(typeof(Profile))]
		Profile,
		}
	
	#endregion PaymentSettingChildEntityTypes
	
	#region PaymentSettingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PaymentSetting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PaymentSettingFilterBuilder : SqlFilterBuilder<PaymentSettingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PaymentSettingFilterBuilder class.
		/// </summary>
		public PaymentSettingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PaymentSettingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PaymentSettingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PaymentSettingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PaymentSettingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PaymentSettingFilterBuilder
	
	#region PaymentSettingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PaymentSetting"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PaymentSettingParameterBuilder : ParameterizedSqlFilterBuilder<PaymentSettingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PaymentSettingParameterBuilder class.
		/// </summary>
		public PaymentSettingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PaymentSettingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PaymentSettingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PaymentSettingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PaymentSettingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PaymentSettingParameterBuilder
} // end namespace
