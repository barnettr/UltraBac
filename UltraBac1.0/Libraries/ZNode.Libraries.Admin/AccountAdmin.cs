using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;


namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage Customer Accounts
    /// </summary>
    public class AccountAdmin:ZNodeBusinessBase 
    {

        /// <summary>
        /// Return all Customer Details for this portal
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public DataSet GetByPortalID(int portalID)
        {
            AccountHelper _HelperAccess = new AccountHelper();
            DataSet MyDataSet  = _HelperAccess.GetAll(portalID);
            
            return MyDataSet;
        }

        /// <summary>
        /// Return all the Customer Account
        /// </summary>
        /// <returns></returns>
        public TList<Account> GetAllCustomer()
        {
            ZNode.Libraries.DataAccess.Service.AccountService _AccountService = new AccountService();
            
            TList<ZNode.Libraries.DataAccess.Entities.Account> AccountList = _AccountService.GetAll();

            return AccountList;
        }

        /// <summary>
        ///  returns a customer account for a Account id
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public Account GetByAccountID(int AccountID)
        {
            ZNode.Libraries.DataAccess.Service.AccountService _AccountService = new AccountService();
            
            ZNode.Libraries.DataAccess.Entities.Account _AccountList =_AccountService.GetByAccountID(AccountID);

            return _AccountList;

        }

        /// <summary>
        /// Add User Account
        /// </summary>
        /// <param name="UserAccount"></param>
        /// <returns></returns>
        public bool Add(Account UserAccount)
        {
            ZNode.Libraries.DataAccess.Service.AccountService _AccountService = new AccountService();

            return _AccountService.Insert(UserAccount);
        }

        /// <summary>
        /// Update User Account
        /// </summary>
        /// <param name="UserAccount"></param>
        /// <returns></returns>
        public bool Update(Account UserAccount)
        {
            ZNode.Libraries.DataAccess.Service.AccountService _AccountService = new AccountService();

            return _AccountService.Update(UserAccount);

        }

    }
}
