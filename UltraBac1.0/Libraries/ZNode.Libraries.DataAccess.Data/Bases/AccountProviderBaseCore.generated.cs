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
	/// This class is the base class for any <see cref="AccountProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AccountProviderBaseCore : EntityProviderBase<ZNode.Libraries.DataAccess.Entities.Account, ZNode.Libraries.DataAccess.Entities.AccountKey>
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
		public override bool Delete(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AccountKey key)
		{
			return Delete(transactionManager, key.AccountID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="accountID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 accountID)
		{
			return Delete(null, accountID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 accountID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Portals key.
		///		FK_Account_Portals Description: 
		/// </summary>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByPortalID(System.Int32? portalID)
		{
			int count = -1;
			return GetByPortalID(portalID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Portals key.
		///		FK_Account_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByPortalID(TransactionManager transactionManager, System.Int32? portalID)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Portals key.
		///		FK_Account_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByPortalID(TransactionManager transactionManager, System.Int32? portalID, int start, int pageLength)
		{
			int count = -1;
			return GetByPortalID(transactionManager, portalID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Portals key.
		///		fKAccountPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByPortalID(System.Int32? portalID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPortalID(null, portalID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Portals key.
		///		fKAccountPortals Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="portalID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByPortalID(System.Int32? portalID, int start, int pageLength,out int count)
		{
			return GetByPortalID(null, portalID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Portals key.
		///		FK_Account_Portals Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="portalID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Account> GetByPortalID(TransactionManager transactionManager, System.Int32? portalID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Account key.
		///		FK_Account_Account Description: 
		/// </summary>
		/// <param name="parentAccountID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByParentAccountID(System.Int32? parentAccountID)
		{
			int count = -1;
			return GetByParentAccountID(parentAccountID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Account key.
		///		FK_Account_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentAccountID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByParentAccountID(TransactionManager transactionManager, System.Int32? parentAccountID)
		{
			int count = -1;
			return GetByParentAccountID(transactionManager, parentAccountID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Account key.
		///		FK_Account_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentAccountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByParentAccountID(TransactionManager transactionManager, System.Int32? parentAccountID, int start, int pageLength)
		{
			int count = -1;
			return GetByParentAccountID(transactionManager, parentAccountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Account key.
		///		fKAccountAccount Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="parentAccountID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByParentAccountID(System.Int32? parentAccountID, int start, int pageLength)
		{
			int count =  -1;
			return GetByParentAccountID(null, parentAccountID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Account key.
		///		fKAccountAccount Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="parentAccountID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByParentAccountID(System.Int32? parentAccountID, int start, int pageLength,out int count)
		{
			return GetByParentAccountID(null, parentAccountID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_Account key.
		///		FK_Account_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parentAccountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Account> GetByParentAccountID(TransactionManager transactionManager, System.Int32? parentAccountID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_AccountType key.
		///		FK_Account_AccountType Description: 
		/// </summary>
		/// <param name="accountTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByAccountTypeID(System.Int32? accountTypeID)
		{
			int count = -1;
			return GetByAccountTypeID(accountTypeID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_AccountType key.
		///		FK_Account_AccountType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountTypeID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByAccountTypeID(TransactionManager transactionManager, System.Int32? accountTypeID)
		{
			int count = -1;
			return GetByAccountTypeID(transactionManager, accountTypeID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_AccountType key.
		///		FK_Account_AccountType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByAccountTypeID(TransactionManager transactionManager, System.Int32? accountTypeID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountTypeID(transactionManager, accountTypeID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_AccountType key.
		///		fKAccountAccountType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountTypeID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByAccountTypeID(System.Int32? accountTypeID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccountTypeID(null, accountTypeID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_AccountType key.
		///		fKAccountAccountType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountTypeID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByAccountTypeID(System.Int32? accountTypeID, int start, int pageLength,out int count)
		{
			return GetByAccountTypeID(null, accountTypeID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_AccountType key.
		///		FK_Account_AccountType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountTypeID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Account> GetByAccountTypeID(TransactionManager transactionManager, System.Int32? accountTypeID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_aspnet_Users key.
		///		FK_Account_aspnet_Users Description: 
		/// </summary>
		/// <param name="userID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByUserID(System.Guid? userID)
		{
			int count = -1;
			return GetByUserID(userID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_aspnet_Users key.
		///		FK_Account_aspnet_Users Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByUserID(TransactionManager transactionManager, System.Guid? userID)
		{
			int count = -1;
			return GetByUserID(transactionManager, userID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_aspnet_Users key.
		///		FK_Account_aspnet_Users Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByUserID(TransactionManager transactionManager, System.Guid? userID, int start, int pageLength)
		{
			int count = -1;
			return GetByUserID(transactionManager, userID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_aspnet_Users key.
		///		fKAccountAspnetUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="userID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByUserID(System.Guid? userID, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserID(null, userID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_aspnet_Users key.
		///		fKAccountAspnetUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="userID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByUserID(System.Guid? userID, int start, int pageLength,out int count)
		{
			return GetByUserID(null, userID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_aspnet_Users key.
		///		FK_Account_aspnet_Users Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="userID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Account> GetByUserID(TransactionManager transactionManager, System.Guid? userID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_SC_Profile key.
		///		FK_Account_SC_Profile Description: 
		/// </summary>
		/// <param name="profileID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByProfileID(System.Int32? profileID)
		{
			int count = -1;
			return GetByProfileID(profileID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_SC_Profile key.
		///		FK_Account_SC_Profile Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByProfileID(TransactionManager transactionManager, System.Int32? profileID)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_SC_Profile key.
		///		FK_Account_SC_Profile Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByProfileID(TransactionManager transactionManager, System.Int32? profileID, int start, int pageLength)
		{
			int count = -1;
			return GetByProfileID(transactionManager, profileID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_SC_Profile key.
		///		fKAccountSCProfile Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="profileID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByProfileID(System.Int32? profileID, int start, int pageLength)
		{
			int count =  -1;
			return GetByProfileID(null, profileID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_SC_Profile key.
		///		fKAccountSCProfile Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="profileID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByProfileID(System.Int32? profileID, int start, int pageLength,out int count)
		{
			return GetByProfileID(null, profileID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Account_SC_Profile key.
		///		FK_Account_SC_Profile Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="profileID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Account> GetByProfileID(TransactionManager transactionManager, System.Int32? profileID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeAccount_ZNodeContactTemperature key.
		///		FK_ZNodeAccount_ZNodeContactTemperature Description: 
		/// </summary>
		/// <param name="contactTemperatureID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByContactTemperatureID(System.Int32? contactTemperatureID)
		{
			int count = -1;
			return GetByContactTemperatureID(contactTemperatureID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeAccount_ZNodeContactTemperature key.
		///		FK_ZNodeAccount_ZNodeContactTemperature Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contactTemperatureID"></param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		/// <remarks></remarks>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByContactTemperatureID(TransactionManager transactionManager, System.Int32? contactTemperatureID)
		{
			int count = -1;
			return GetByContactTemperatureID(transactionManager, contactTemperatureID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeAccount_ZNodeContactTemperature key.
		///		FK_ZNodeAccount_ZNodeContactTemperature Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contactTemperatureID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByContactTemperatureID(TransactionManager transactionManager, System.Int32? contactTemperatureID, int start, int pageLength)
		{
			int count = -1;
			return GetByContactTemperatureID(transactionManager, contactTemperatureID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeAccount_ZNodeContactTemperature key.
		///		fKZNodeAccountZNodeContactTemperature Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contactTemperatureID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByContactTemperatureID(System.Int32? contactTemperatureID, int start, int pageLength)
		{
			int count =  -1;
			return GetByContactTemperatureID(null, contactTemperatureID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeAccount_ZNodeContactTemperature key.
		///		fKZNodeAccountZNodeContactTemperature Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="contactTemperatureID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByContactTemperatureID(System.Int32? contactTemperatureID, int start, int pageLength,out int count)
		{
			return GetByContactTemperatureID(null, contactTemperatureID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ZNodeAccount_ZNodeContactTemperature key.
		///		FK_ZNodeAccount_ZNodeContactTemperature Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="contactTemperatureID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ZNode.Libraries.DataAccess.Entities.Account objects.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Account> GetByContactTemperatureID(TransactionManager transactionManager, System.Int32? contactTemperatureID, int start, int pageLength, out int count);
		
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
		public override ZNode.Libraries.DataAccess.Entities.Account Get(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.AccountKey key, int start, int pageLength)
		{
			return GetByAccountID(transactionManager, key.AccountID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Account index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Account GetByAccountID(System.Int32 accountID)
		{
			int count = -1;
			return GetByAccountID(null,accountID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Account GetByAccountID(System.Int32 accountID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountID(null, accountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Account GetByAccountID(TransactionManager transactionManager, System.Int32 accountID)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Account GetByAccountID(TransactionManager transactionManager, System.Int32 accountID, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountID(transactionManager, accountID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.Account GetByAccountID(System.Int32 accountID, int start, int pageLength, out int count)
		{
			return GetByAccountID(null, accountID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Account index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.Account GetByAccountID(TransactionManager transactionManager, System.Int32 accountID, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IN1 index.
		/// </summary>
		/// <param name="companyName"></param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByCompanyName(System.String companyName)
		{
			int count = -1;
			return GetByCompanyName(null,companyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByCompanyName(System.String companyName, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyName(null, companyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="companyName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByCompanyName(TransactionManager transactionManager, System.String companyName)
		{
			int count = -1;
			return GetByCompanyName(transactionManager, companyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByCompanyName(TransactionManager transactionManager, System.String companyName, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyName(transactionManager, companyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt;"/> class.</returns>
		public ZNode.Libraries.DataAccess.Entities.TList<Account> GetByCompanyName(System.String companyName, int start, int pageLength, out int count)
		{
			return GetByCompanyName(null, companyName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IN1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt;"/> class.</returns>
		public abstract ZNode.Libraries.DataAccess.Entities.TList<Account> GetByCompanyName(TransactionManager transactionManager, System.String companyName, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="ZNode.Libraries.DataAccess.Entities.TList&lt;Account&gt;"/></returns>
		public static ZNode.Libraries.DataAccess.Entities.TList<Account> Fill(IDataReader reader, ZNode.Libraries.DataAccess.Entities.TList<Account> rows, int start, int pageLength)
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
				
				ZNode.Libraries.DataAccess.Entities.Account c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Account" 
							+ (reader.IsDBNull(reader.GetOrdinal("AccountID"))?(int)0:(System.Int32)reader["AccountID"]).ToString();

					c = EntityManager.LocateOrCreate<Account>(
						key.ToString(), // EntityTrackingKey 
						"Account",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ZNode.Libraries.DataAccess.Entities.Account();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.AccountID = (System.Int32)reader["AccountID"];
					c.ParentAccountID = (reader.IsDBNull(reader.GetOrdinal("ParentAccountID")))?null:(System.Int32?)reader["ParentAccountID"];
					c.PortalID = (reader.IsDBNull(reader.GetOrdinal("PortalID")))?null:(System.Int32?)reader["PortalID"];
					c.UserID = (reader.IsDBNull(reader.GetOrdinal("UserID")))?null:(System.Guid?)reader["UserID"];
					c.ExternalAccountNo = (reader.IsDBNull(reader.GetOrdinal("ExternalAccountNo")))?null:(System.String)reader["ExternalAccountNo"];
					c.CompanyName = (reader.IsDBNull(reader.GetOrdinal("CompanyName")))?null:(System.String)reader["CompanyName"];
					c.AccountTypeID = (reader.IsDBNull(reader.GetOrdinal("AccountTypeID")))?null:(System.Int32?)reader["AccountTypeID"];
					c.ProfileID = (reader.IsDBNull(reader.GetOrdinal("ProfileID")))?null:(System.Int32?)reader["ProfileID"];
					c.AccountProfileCode = (reader.IsDBNull(reader.GetOrdinal("AccountProfileCode")))?null:(System.String)reader["AccountProfileCode"];
					c.SubAccountLimit = (reader.IsDBNull(reader.GetOrdinal("SubAccountLimit")))?null:(System.Int32?)reader["SubAccountLimit"];
					c.BillingFirstName = (reader.IsDBNull(reader.GetOrdinal("BillingFirstName")))?null:(System.String)reader["BillingFirstName"];
					c.BillingLastName = (reader.IsDBNull(reader.GetOrdinal("BillingLastName")))?null:(System.String)reader["BillingLastName"];
					c.BillingCompanyName = (reader.IsDBNull(reader.GetOrdinal("BillingCompanyName")))?null:(System.String)reader["BillingCompanyName"];
					c.BillingStreet = (reader.IsDBNull(reader.GetOrdinal("BillingStreet")))?null:(System.String)reader["BillingStreet"];
					c.BillingStreet1 = (reader.IsDBNull(reader.GetOrdinal("BillingStreet1")))?null:(System.String)reader["BillingStreet1"];
					c.BillingCity = (reader.IsDBNull(reader.GetOrdinal("BillingCity")))?null:(System.String)reader["BillingCity"];
					c.BillingStateCode = (reader.IsDBNull(reader.GetOrdinal("BillingStateCode")))?null:(System.String)reader["BillingStateCode"];
					c.BillingPostalCode = (reader.IsDBNull(reader.GetOrdinal("BillingPostalCode")))?null:(System.String)reader["BillingPostalCode"];
					c.BillingCountryCode = (reader.IsDBNull(reader.GetOrdinal("BillingCountryCode")))?null:(System.String)reader["BillingCountryCode"];
					c.BillingPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("BillingPhoneNumber")))?null:(System.String)reader["BillingPhoneNumber"];
					c.BillingEmailID = (reader.IsDBNull(reader.GetOrdinal("BillingEmailID")))?null:(System.String)reader["BillingEmailID"];
					c.ShipFirstName = (reader.IsDBNull(reader.GetOrdinal("ShipFirstName")))?null:(System.String)reader["ShipFirstName"];
					c.ShipLastName = (reader.IsDBNull(reader.GetOrdinal("ShipLastName")))?null:(System.String)reader["ShipLastName"];
					c.ShipCompanyName = (reader.IsDBNull(reader.GetOrdinal("ShipCompanyName")))?null:(System.String)reader["ShipCompanyName"];
					c.ShipStreet = (reader.IsDBNull(reader.GetOrdinal("ShipStreet")))?null:(System.String)reader["ShipStreet"];
					c.ShipStreet1 = (reader.IsDBNull(reader.GetOrdinal("ShipStreet1")))?null:(System.String)reader["ShipStreet1"];
					c.ShipCity = (reader.IsDBNull(reader.GetOrdinal("ShipCity")))?null:(System.String)reader["ShipCity"];
					c.ShipStateCode = (reader.IsDBNull(reader.GetOrdinal("ShipStateCode")))?null:(System.String)reader["ShipStateCode"];
					c.ShipPostalCode = (reader.IsDBNull(reader.GetOrdinal("ShipPostalCode")))?null:(System.String)reader["ShipPostalCode"];
					c.ShipCountryCode = (reader.IsDBNull(reader.GetOrdinal("ShipCountryCode")))?null:(System.String)reader["ShipCountryCode"];
					c.ShipEmailID = (reader.IsDBNull(reader.GetOrdinal("ShipEmailID")))?null:(System.String)reader["ShipEmailID"];
					c.ShipPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("ShipPhoneNumber")))?null:(System.String)reader["ShipPhoneNumber"];
					c.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
					c.CreateUser = (reader.IsDBNull(reader.GetOrdinal("CreateUser")))?null:(System.String)reader["CreateUser"];
					c.CreateDte = (System.DateTime)reader["CreateDte"];
					c.UpdateUser = (reader.IsDBNull(reader.GetOrdinal("UpdateUser")))?null:(System.String)reader["UpdateUser"];
					c.UpdateDte = (reader.IsDBNull(reader.GetOrdinal("UpdateDte")))?null:(System.DateTime?)reader["UpdateDte"];
					c.ActiveInd = (reader.IsDBNull(reader.GetOrdinal("ActiveInd")))?null:(System.Boolean?)reader["ActiveInd"];
					c.Website = (reader.IsDBNull(reader.GetOrdinal("Website")))?null:(System.String)reader["Website"];
					c.Source = (reader.IsDBNull(reader.GetOrdinal("Source")))?null:(System.String)reader["Source"];
					c.ReferredBy = (reader.IsDBNull(reader.GetOrdinal("ReferredBy")))?null:(System.Byte[])reader["ReferredBy"];
					c.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
					c.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
					c.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
					c.ContactTemperatureID = (reader.IsDBNull(reader.GetOrdinal("ContactTemperatureID")))?null:(System.Int32?)reader["ContactTemperatureID"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ZNode.Libraries.DataAccess.Entities.Account entity)
		{
			if (!reader.Read()) return;
			
			entity.AccountID = (System.Int32)reader["AccountID"];
			entity.ParentAccountID = (reader.IsDBNull(reader.GetOrdinal("ParentAccountID")))?null:(System.Int32?)reader["ParentAccountID"];
			entity.PortalID = (reader.IsDBNull(reader.GetOrdinal("PortalID")))?null:(System.Int32?)reader["PortalID"];
			entity.UserID = (reader.IsDBNull(reader.GetOrdinal("UserID")))?null:(System.Guid?)reader["UserID"];
			entity.ExternalAccountNo = (reader.IsDBNull(reader.GetOrdinal("ExternalAccountNo")))?null:(System.String)reader["ExternalAccountNo"];
			entity.CompanyName = (reader.IsDBNull(reader.GetOrdinal("CompanyName")))?null:(System.String)reader["CompanyName"];
			entity.AccountTypeID = (reader.IsDBNull(reader.GetOrdinal("AccountTypeID")))?null:(System.Int32?)reader["AccountTypeID"];
			entity.ProfileID = (reader.IsDBNull(reader.GetOrdinal("ProfileID")))?null:(System.Int32?)reader["ProfileID"];
			entity.AccountProfileCode = (reader.IsDBNull(reader.GetOrdinal("AccountProfileCode")))?null:(System.String)reader["AccountProfileCode"];
			entity.SubAccountLimit = (reader.IsDBNull(reader.GetOrdinal("SubAccountLimit")))?null:(System.Int32?)reader["SubAccountLimit"];
			entity.BillingFirstName = (reader.IsDBNull(reader.GetOrdinal("BillingFirstName")))?null:(System.String)reader["BillingFirstName"];
			entity.BillingLastName = (reader.IsDBNull(reader.GetOrdinal("BillingLastName")))?null:(System.String)reader["BillingLastName"];
			entity.BillingCompanyName = (reader.IsDBNull(reader.GetOrdinal("BillingCompanyName")))?null:(System.String)reader["BillingCompanyName"];
			entity.BillingStreet = (reader.IsDBNull(reader.GetOrdinal("BillingStreet")))?null:(System.String)reader["BillingStreet"];
			entity.BillingStreet1 = (reader.IsDBNull(reader.GetOrdinal("BillingStreet1")))?null:(System.String)reader["BillingStreet1"];
			entity.BillingCity = (reader.IsDBNull(reader.GetOrdinal("BillingCity")))?null:(System.String)reader["BillingCity"];
			entity.BillingStateCode = (reader.IsDBNull(reader.GetOrdinal("BillingStateCode")))?null:(System.String)reader["BillingStateCode"];
			entity.BillingPostalCode = (reader.IsDBNull(reader.GetOrdinal("BillingPostalCode")))?null:(System.String)reader["BillingPostalCode"];
			entity.BillingCountryCode = (reader.IsDBNull(reader.GetOrdinal("BillingCountryCode")))?null:(System.String)reader["BillingCountryCode"];
			entity.BillingPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("BillingPhoneNumber")))?null:(System.String)reader["BillingPhoneNumber"];
			entity.BillingEmailID = (reader.IsDBNull(reader.GetOrdinal("BillingEmailID")))?null:(System.String)reader["BillingEmailID"];
			entity.ShipFirstName = (reader.IsDBNull(reader.GetOrdinal("ShipFirstName")))?null:(System.String)reader["ShipFirstName"];
			entity.ShipLastName = (reader.IsDBNull(reader.GetOrdinal("ShipLastName")))?null:(System.String)reader["ShipLastName"];
			entity.ShipCompanyName = (reader.IsDBNull(reader.GetOrdinal("ShipCompanyName")))?null:(System.String)reader["ShipCompanyName"];
			entity.ShipStreet = (reader.IsDBNull(reader.GetOrdinal("ShipStreet")))?null:(System.String)reader["ShipStreet"];
			entity.ShipStreet1 = (reader.IsDBNull(reader.GetOrdinal("ShipStreet1")))?null:(System.String)reader["ShipStreet1"];
			entity.ShipCity = (reader.IsDBNull(reader.GetOrdinal("ShipCity")))?null:(System.String)reader["ShipCity"];
			entity.ShipStateCode = (reader.IsDBNull(reader.GetOrdinal("ShipStateCode")))?null:(System.String)reader["ShipStateCode"];
			entity.ShipPostalCode = (reader.IsDBNull(reader.GetOrdinal("ShipPostalCode")))?null:(System.String)reader["ShipPostalCode"];
			entity.ShipCountryCode = (reader.IsDBNull(reader.GetOrdinal("ShipCountryCode")))?null:(System.String)reader["ShipCountryCode"];
			entity.ShipEmailID = (reader.IsDBNull(reader.GetOrdinal("ShipEmailID")))?null:(System.String)reader["ShipEmailID"];
			entity.ShipPhoneNumber = (reader.IsDBNull(reader.GetOrdinal("ShipPhoneNumber")))?null:(System.String)reader["ShipPhoneNumber"];
			entity.Description = (reader.IsDBNull(reader.GetOrdinal("Description")))?null:(System.String)reader["Description"];
			entity.CreateUser = (reader.IsDBNull(reader.GetOrdinal("CreateUser")))?null:(System.String)reader["CreateUser"];
			entity.CreateDte = (System.DateTime)reader["CreateDte"];
			entity.UpdateUser = (reader.IsDBNull(reader.GetOrdinal("UpdateUser")))?null:(System.String)reader["UpdateUser"];
			entity.UpdateDte = (reader.IsDBNull(reader.GetOrdinal("UpdateDte")))?null:(System.DateTime?)reader["UpdateDte"];
			entity.ActiveInd = (reader.IsDBNull(reader.GetOrdinal("ActiveInd")))?null:(System.Boolean?)reader["ActiveInd"];
			entity.Website = (reader.IsDBNull(reader.GetOrdinal("Website")))?null:(System.String)reader["Website"];
			entity.Source = (reader.IsDBNull(reader.GetOrdinal("Source")))?null:(System.String)reader["Source"];
			entity.ReferredBy = (reader.IsDBNull(reader.GetOrdinal("ReferredBy")))?null:(System.Byte[])reader["ReferredBy"];
			entity.Custom1 = (reader.IsDBNull(reader.GetOrdinal("Custom1")))?null:(System.String)reader["Custom1"];
			entity.Custom2 = (reader.IsDBNull(reader.GetOrdinal("Custom2")))?null:(System.String)reader["Custom2"];
			entity.Custom3 = (reader.IsDBNull(reader.GetOrdinal("Custom3")))?null:(System.String)reader["Custom3"];
			entity.ContactTemperatureID = (reader.IsDBNull(reader.GetOrdinal("ContactTemperatureID")))?null:(System.Int32?)reader["ContactTemperatureID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ZNode.Libraries.DataAccess.Entities.Account entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AccountID = (System.Int32)dataRow["AccountID"];
			entity.ParentAccountID = (Convert.IsDBNull(dataRow["ParentAccountID"]))?null:(System.Int32?)dataRow["ParentAccountID"];
			entity.PortalID = (Convert.IsDBNull(dataRow["PortalID"]))?null:(System.Int32?)dataRow["PortalID"];
			entity.UserID = (Convert.IsDBNull(dataRow["UserID"]))?null:(System.Guid?)dataRow["UserID"];
			entity.ExternalAccountNo = (Convert.IsDBNull(dataRow["ExternalAccountNo"]))?null:(System.String)dataRow["ExternalAccountNo"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?null:(System.String)dataRow["CompanyName"];
			entity.AccountTypeID = (Convert.IsDBNull(dataRow["AccountTypeID"]))?null:(System.Int32?)dataRow["AccountTypeID"];
			entity.ProfileID = (Convert.IsDBNull(dataRow["ProfileID"]))?null:(System.Int32?)dataRow["ProfileID"];
			entity.AccountProfileCode = (Convert.IsDBNull(dataRow["AccountProfileCode"]))?null:(System.String)dataRow["AccountProfileCode"];
			entity.SubAccountLimit = (Convert.IsDBNull(dataRow["SubAccountLimit"]))?null:(System.Int32?)dataRow["SubAccountLimit"];
			entity.BillingFirstName = (Convert.IsDBNull(dataRow["BillingFirstName"]))?null:(System.String)dataRow["BillingFirstName"];
			entity.BillingLastName = (Convert.IsDBNull(dataRow["BillingLastName"]))?null:(System.String)dataRow["BillingLastName"];
			entity.BillingCompanyName = (Convert.IsDBNull(dataRow["BillingCompanyName"]))?null:(System.String)dataRow["BillingCompanyName"];
			entity.BillingStreet = (Convert.IsDBNull(dataRow["BillingStreet"]))?null:(System.String)dataRow["BillingStreet"];
			entity.BillingStreet1 = (Convert.IsDBNull(dataRow["BillingStreet1"]))?null:(System.String)dataRow["BillingStreet1"];
			entity.BillingCity = (Convert.IsDBNull(dataRow["BillingCity"]))?null:(System.String)dataRow["BillingCity"];
			entity.BillingStateCode = (Convert.IsDBNull(dataRow["BillingStateCode"]))?null:(System.String)dataRow["BillingStateCode"];
			entity.BillingPostalCode = (Convert.IsDBNull(dataRow["BillingPostalCode"]))?null:(System.String)dataRow["BillingPostalCode"];
			entity.BillingCountryCode = (Convert.IsDBNull(dataRow["BillingCountryCode"]))?null:(System.String)dataRow["BillingCountryCode"];
			entity.BillingPhoneNumber = (Convert.IsDBNull(dataRow["BillingPhoneNumber"]))?null:(System.String)dataRow["BillingPhoneNumber"];
			entity.BillingEmailID = (Convert.IsDBNull(dataRow["BillingEmailID"]))?null:(System.String)dataRow["BillingEmailID"];
			entity.ShipFirstName = (Convert.IsDBNull(dataRow["ShipFirstName"]))?null:(System.String)dataRow["ShipFirstName"];
			entity.ShipLastName = (Convert.IsDBNull(dataRow["ShipLastName"]))?null:(System.String)dataRow["ShipLastName"];
			entity.ShipCompanyName = (Convert.IsDBNull(dataRow["ShipCompanyName"]))?null:(System.String)dataRow["ShipCompanyName"];
			entity.ShipStreet = (Convert.IsDBNull(dataRow["ShipStreet"]))?null:(System.String)dataRow["ShipStreet"];
			entity.ShipStreet1 = (Convert.IsDBNull(dataRow["ShipStreet1"]))?null:(System.String)dataRow["ShipStreet1"];
			entity.ShipCity = (Convert.IsDBNull(dataRow["ShipCity"]))?null:(System.String)dataRow["ShipCity"];
			entity.ShipStateCode = (Convert.IsDBNull(dataRow["ShipStateCode"]))?null:(System.String)dataRow["ShipStateCode"];
			entity.ShipPostalCode = (Convert.IsDBNull(dataRow["ShipPostalCode"]))?null:(System.String)dataRow["ShipPostalCode"];
			entity.ShipCountryCode = (Convert.IsDBNull(dataRow["ShipCountryCode"]))?null:(System.String)dataRow["ShipCountryCode"];
			entity.ShipEmailID = (Convert.IsDBNull(dataRow["ShipEmailID"]))?null:(System.String)dataRow["ShipEmailID"];
			entity.ShipPhoneNumber = (Convert.IsDBNull(dataRow["ShipPhoneNumber"]))?null:(System.String)dataRow["ShipPhoneNumber"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?null:(System.String)dataRow["Description"];
			entity.CreateUser = (Convert.IsDBNull(dataRow["CreateUser"]))?null:(System.String)dataRow["CreateUser"];
			entity.CreateDte = (System.DateTime)dataRow["CreateDte"];
			entity.UpdateUser = (Convert.IsDBNull(dataRow["UpdateUser"]))?null:(System.String)dataRow["UpdateUser"];
			entity.UpdateDte = (Convert.IsDBNull(dataRow["UpdateDte"]))?null:(System.DateTime?)dataRow["UpdateDte"];
			entity.ActiveInd = (Convert.IsDBNull(dataRow["ActiveInd"]))?null:(System.Boolean?)dataRow["ActiveInd"];
			entity.Website = (Convert.IsDBNull(dataRow["Website"]))?null:(System.String)dataRow["Website"];
			entity.Source = (Convert.IsDBNull(dataRow["Source"]))?null:(System.String)dataRow["Source"];
			entity.ReferredBy = (Convert.IsDBNull(dataRow["ReferredBy"]))?null:(System.Byte[])dataRow["ReferredBy"];
			entity.Custom1 = (Convert.IsDBNull(dataRow["Custom1"]))?null:(System.String)dataRow["Custom1"];
			entity.Custom2 = (Convert.IsDBNull(dataRow["Custom2"]))?null:(System.String)dataRow["Custom2"];
			entity.Custom3 = (Convert.IsDBNull(dataRow["Custom3"]))?null:(System.String)dataRow["Custom3"];
			entity.ContactTemperatureID = (Convert.IsDBNull(dataRow["ContactTemperatureID"]))?null:(System.Int32?)dataRow["ContactTemperatureID"];
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
		/// <param name="entity">The <see cref="ZNode.Libraries.DataAccess.Entities.Account"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Account Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Account entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region PortalIDSource	
			if (CanDeepLoad(entity, "Portal", "PortalIDSource", deepLoadType, innerList) 
				&& entity.PortalIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PortalID ?? (int)0);
				Portal tmpEntity = EntityManager.LocateEntity<Portal>(EntityLocator.ConstructKeyFromPkItems(typeof(Portal), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PortalIDSource = tmpEntity;
				else
					entity.PortalIDSource = DataRepository.PortalProvider.GetByPortalID((entity.PortalID ?? (int)0));
			
				if (deep && entity.PortalIDSource != null)
				{
					DataRepository.PortalProvider.DeepLoad(transactionManager, entity.PortalIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion PortalIDSource

			#region ParentAccountIDSource	
			if (CanDeepLoad(entity, "Account", "ParentAccountIDSource", deepLoadType, innerList) 
				&& entity.ParentAccountIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ParentAccountID ?? (int)0);
				Account tmpEntity = EntityManager.LocateEntity<Account>(EntityLocator.ConstructKeyFromPkItems(typeof(Account), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ParentAccountIDSource = tmpEntity;
				else
					entity.ParentAccountIDSource = DataRepository.AccountProvider.GetByAccountID((entity.ParentAccountID ?? (int)0));
			
				if (deep && entity.ParentAccountIDSource != null)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.ParentAccountIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ParentAccountIDSource

			#region AccountTypeIDSource	
			if (CanDeepLoad(entity, "AccountType", "AccountTypeIDSource", deepLoadType, innerList) 
				&& entity.AccountTypeIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.AccountTypeID ?? (int)0);
				AccountType tmpEntity = EntityManager.LocateEntity<AccountType>(EntityLocator.ConstructKeyFromPkItems(typeof(AccountType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccountTypeIDSource = tmpEntity;
				else
					entity.AccountTypeIDSource = DataRepository.AccountTypeProvider.GetByAccountTypeID((entity.AccountTypeID ?? (int)0));
			
				if (deep && entity.AccountTypeIDSource != null)
				{
					DataRepository.AccountTypeProvider.DeepLoad(transactionManager, entity.AccountTypeIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion AccountTypeIDSource

			#region ProfileIDSource	
			if (CanDeepLoad(entity, "Profile", "ProfileIDSource", deepLoadType, innerList) 
				&& entity.ProfileIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ProfileID ?? (int)0);
				Profile tmpEntity = EntityManager.LocateEntity<Profile>(EntityLocator.ConstructKeyFromPkItems(typeof(Profile), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProfileIDSource = tmpEntity;
				else
					entity.ProfileIDSource = DataRepository.ProfileProvider.GetByProfileID((entity.ProfileID ?? (int)0));
			
				if (deep && entity.ProfileIDSource != null)
				{
					DataRepository.ProfileProvider.DeepLoad(transactionManager, entity.ProfileIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ProfileIDSource

			#region ContactTemperatureIDSource	
			if (CanDeepLoad(entity, "ContactTemperature", "ContactTemperatureIDSource", deepLoadType, innerList) 
				&& entity.ContactTemperatureIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ContactTemperatureID ?? (int)0);
				ContactTemperature tmpEntity = EntityManager.LocateEntity<ContactTemperature>(EntityLocator.ConstructKeyFromPkItems(typeof(ContactTemperature), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContactTemperatureIDSource = tmpEntity;
				else
					entity.ContactTemperatureIDSource = DataRepository.ContactTemperatureProvider.GetByContactTemperatureID((entity.ContactTemperatureID ?? (int)0));
			
				if (deep && entity.ContactTemperatureIDSource != null)
				{
					DataRepository.ContactTemperatureProvider.DeepLoad(transactionManager, entity.ContactTemperatureIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion ContactTemperatureIDSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByAccountID methods when available
			
			#region OrderCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Order>", "OrderCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderCollection' loaded.");
				#endif 

				entity.OrderCollection = DataRepository.OrderProvider.GetByAccountID(transactionManager, entity.AccountID);

				if (deep && entity.OrderCollection.Count > 0)
				{
					DataRepository.OrderProvider.DeepLoad(transactionManager, entity.OrderCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region CaseCollectionByAccountID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Case>", "CaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CaseCollectionByAccountID' loaded.");
				#endif 

				entity.CaseCollectionByAccountID = DataRepository.CaseProvider.GetByAccountID(transactionManager, entity.AccountID);

				if (deep && entity.CaseCollectionByAccountID.Count > 0)
				{
					DataRepository.CaseProvider.DeepLoad(transactionManager, entity.CaseCollectionByAccountID, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region NoteCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Note>", "NoteCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'NoteCollection' loaded.");
				#endif 

				entity.NoteCollection = DataRepository.NoteProvider.GetByAccountID(transactionManager, entity.AccountID);

				if (deep && entity.NoteCollection.Count > 0)
				{
					DataRepository.NoteProvider.DeepLoad(transactionManager, entity.NoteCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region CaseCollectionByOwnerAccountID
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Case>", "CaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'CaseCollectionByOwnerAccountID' loaded.");
				#endif 

				entity.CaseCollectionByOwnerAccountID = DataRepository.CaseProvider.GetByOwnerAccountID(transactionManager, entity.AccountID);

				if (deep && entity.CaseCollectionByOwnerAccountID.Count > 0)
				{
					DataRepository.CaseProvider.DeepLoad(transactionManager, entity.CaseCollectionByOwnerAccountID, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region AccountCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Account>", "AccountCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'AccountCollection' loaded.");
				#endif 

				entity.AccountCollection = DataRepository.AccountProvider.GetByParentAccountID(transactionManager, entity.AccountID);

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
		/// Deep Save the entire object graph of the ZNode.Libraries.DataAccess.Entities.Account object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ZNode.Libraries.DataAccess.Entities.Account instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ZNode.Libraries.DataAccess.Entities.Account Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, ZNode.Libraries.DataAccess.Entities.Account entity, DeepSaveType deepSaveType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PortalIDSource
			if (CanDeepSave(entity, "Portal", "PortalIDSource", deepSaveType, innerList) 
				&& entity.PortalIDSource != null)
			{
				DataRepository.PortalProvider.Save(transactionManager, entity.PortalIDSource);
				entity.PortalID = entity.PortalIDSource.PortalID;
			}
			#endregion 
			
			#region ParentAccountIDSource
			if (CanDeepSave(entity, "Account", "ParentAccountIDSource", deepSaveType, innerList) 
				&& entity.ParentAccountIDSource != null)
			{
				DataRepository.AccountProvider.Save(transactionManager, entity.ParentAccountIDSource);
				entity.ParentAccountID = entity.ParentAccountIDSource.AccountID;
			}
			#endregion 
			
			#region AccountTypeIDSource
			if (CanDeepSave(entity, "AccountType", "AccountTypeIDSource", deepSaveType, innerList) 
				&& entity.AccountTypeIDSource != null)
			{
				DataRepository.AccountTypeProvider.Save(transactionManager, entity.AccountTypeIDSource);
				entity.AccountTypeID = entity.AccountTypeIDSource.AccountTypeID;
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
			
			#region ContactTemperatureIDSource
			if (CanDeepSave(entity, "ContactTemperature", "ContactTemperatureIDSource", deepSaveType, innerList) 
				&& entity.ContactTemperatureIDSource != null)
			{
				DataRepository.ContactTemperatureProvider.Save(transactionManager, entity.ContactTemperatureIDSource);
				entity.ContactTemperatureID = entity.ContactTemperatureIDSource.ContactTemperatureID;
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
						child.AccountID = entity.AccountID;
					}
				
				if (entity.OrderCollection.Count > 0 || entity.OrderCollection.DeletedItems.Count > 0)
					DataRepository.OrderProvider.DeepSave(transactionManager, entity.OrderCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Case>
				if (CanDeepSave(entity, "List<Case>", "CaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Case child in entity.CaseCollectionByAccountID)
					{
						child.AccountID = entity.AccountID;
					}
				
				if (entity.CaseCollectionByAccountID.Count > 0 || entity.CaseCollectionByAccountID.DeletedItems.Count > 0)
					DataRepository.CaseProvider.DeepSave(transactionManager, entity.CaseCollectionByAccountID, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Note>
				if (CanDeepSave(entity, "List<Note>", "NoteCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Note child in entity.NoteCollection)
					{
						child.AccountID = entity.AccountID;
					}
				
				if (entity.NoteCollection.Count > 0 || entity.NoteCollection.DeletedItems.Count > 0)
					DataRepository.NoteProvider.DeepSave(transactionManager, entity.NoteCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Case>
				if (CanDeepSave(entity, "List<Case>", "CaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Case child in entity.CaseCollectionByOwnerAccountID)
					{
						child.OwnerAccountID = entity.AccountID;
					}
				
				if (entity.CaseCollectionByOwnerAccountID.Count > 0 || entity.CaseCollectionByOwnerAccountID.DeletedItems.Count > 0)
					DataRepository.CaseProvider.DeepSave(transactionManager, entity.CaseCollectionByOwnerAccountID, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				

			#region List<Account>
				if (CanDeepSave(entity, "List<Account>", "AccountCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Account child in entity.AccountCollection)
					{
						child.ParentAccountID = entity.AccountID;
					}
				
				if (entity.AccountCollection.Count > 0 || entity.AccountCollection.DeletedItems.Count > 0)
					DataRepository.AccountProvider.DeepSave(transactionManager, entity.AccountCollection, deepSaveType, childTypes, innerList);
				} 
			#endregion 
				





						
			return true;
		}
		#endregion
	} // end class
	
	#region AccountChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ZNode.Libraries.DataAccess.Entities.Account</c>
	///</summary>
	public enum AccountChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Portal</c> at PortalIDSource
		///</summary>
		[ChildEntityType(typeof(Portal))]
		Portal,
			
		///<summary>
		/// Composite Property for <c>Account</c> at ParentAccountIDSource
		///</summary>
		[ChildEntityType(typeof(Account))]
		Account,
			
		///<summary>
		/// Composite Property for <c>AccountType</c> at AccountTypeIDSource
		///</summary>
		[ChildEntityType(typeof(AccountType))]
		AccountType,
			
		///<summary>
		/// Composite Property for <c>Profile</c> at ProfileIDSource
		///</summary>
		[ChildEntityType(typeof(Profile))]
		Profile,
			
		///<summary>
		/// Composite Property for <c>ContactTemperature</c> at ContactTemperatureIDSource
		///</summary>
		[ChildEntityType(typeof(ContactTemperature))]
		ContactTemperature,
	
		///<summary>
		/// Collection of <c>Account</c> as OneToMany for OrderCollection
		///</summary>
		[ChildEntityType(typeof(TList<Order>))]
		OrderCollection,

		///<summary>
		/// Collection of <c>Account</c> as OneToMany for CaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<Case>))]
		CaseCollectionByAccountID,

		///<summary>
		/// Collection of <c>Account</c> as OneToMany for NoteCollection
		///</summary>
		[ChildEntityType(typeof(TList<Note>))]
		NoteCollection,

		///<summary>
		/// Collection of <c>Account</c> as OneToMany for CaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<Case>))]
		CaseCollectionByOwnerAccountID,

		///<summary>
		/// Collection of <c>Account</c> as OneToMany for AccountCollection
		///</summary>
		[ChildEntityType(typeof(TList<Account>))]
		AccountCollection,
	}
	
	#endregion AccountChildEntityTypes
	
	#region AccountFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountFilterBuilder : SqlFilterBuilder<AccountColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		public AccountFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountFilterBuilder
	
	#region AccountParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Account"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AccountParameterBuilder : ParameterizedSqlFilterBuilder<AccountColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AccountParameterBuilder class.
		/// </summary>
		public AccountParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AccountParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AccountParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AccountParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AccountParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AccountParameterBuilder
} // end namespace
