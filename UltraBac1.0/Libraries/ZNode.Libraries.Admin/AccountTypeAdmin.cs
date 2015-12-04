using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage Account Types
    /// </summary>
    public class AccountTypeAdmin : ZNodeBusinessBase
    {

        /// <summary>
        /// Returns a Accountype for a Account 
        /// </summary>
        /// <param name="accountTypeID"></param>
        /// <returns></returns>
        public AccountType GetByAccountTypeID(int accountTypeID)
        {
            ZNode.Libraries.DataAccess.Service.AccountTypeService _AccountTypeService = new AccountTypeService();

            ZNode.Libraries.DataAccess.Entities.AccountType AccountTypeList = _AccountTypeService.GetByAccountTypeID(accountTypeID);

            return AccountTypeList;
        }

        /// <summary>
        /// Returms all the Account Types
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.AccountType> GetAll()
        {
            ZNode.Libraries.DataAccess.Service.AccountTypeService _AccountTypeService = new AccountTypeService();

            TList <ZNode.Libraries.DataAccess.Entities.AccountType> _AccountTypeList = _AccountTypeService.GetAll();

            return _AccountTypeList;
        }

    }
}
