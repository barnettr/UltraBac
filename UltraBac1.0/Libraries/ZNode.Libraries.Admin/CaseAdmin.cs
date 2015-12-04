using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage Case, CasePriority , CaseStatus
    /// </summary>
    public class CaseAdmin : ZNodeBusinessBase
    {

        # region Case Public Methods

        /// <summary>
        ///  Get all the Cases
        /// </summary>
        /// <returns></returns>   
        public TList<ZNode.Libraries.DataAccess.Entities.Case> GetAll()
        {
            ZNode.Libraries.DataAccess.Service.CaseService _CaseService = new ZNode.Libraries.DataAccess.Service.CaseService();

            TList<ZNode.Libraries.DataAccess.Entities.Case> CaseList = _CaseService.GetAll();

            return CaseList;
        }

        /// <summary>
        /// Get a Case
        /// </summary>
        /// <param name="Caseid"></param>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.Case GetByCaseID(int Caseid)
        {
            ZNode.Libraries.DataAccess.Service.CaseService _CaseService = new ZNode.Libraries.DataAccess.Service.CaseService();

            ZNode.Libraries.DataAccess.Entities.Case _caseList = _CaseService.GetByCaseID(Caseid);

            return _caseList;
        }

        /// <summary>
        /// Get a case for this Account
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.Case> GetByAccountID(int AccountID)
        {
            ZNode.Libraries.DataAccess.Service.CaseService _CaseService = new ZNode.Libraries.DataAccess.Service.CaseService();

            TList<ZNode.Libraries.DataAccess.Entities.Case> CaseList = _CaseService.GetByAccountID(AccountID);
            
            return CaseList;
        }

        /// <summary>
        /// Add New Case 
        /// </summary>
        /// <param name="_case"></param>
        /// <returns></returns>
        public bool Add(Case _case)
        {
            ZNode.Libraries.DataAccess.Service.CaseService _CaseService = new ZNode.Libraries.DataAccess.Service.CaseService();

            bool retval = _CaseService.Insert(_case);
            
            return retval;

        }

        /// <summary>
        /// Update Case
        /// </summary>
        /// <param name="_case"></param>
        /// <returns></returns>
        public bool Update(Case _case)
        {
            ZNode.Libraries.DataAccess.Service.CaseService _CaseService = new ZNode.Libraries.DataAccess.Service.CaseService();
            bool retval = _CaseService.Update(_case);

            return retval;

        }

        /// <summary>
        /// Returns all AccountList for a portal
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public DataSet GetByPortalID(int portalID)
        {
             AccountAdmin _AcccountAccess = new AccountAdmin();
             
             DataSet MyDataSet = _AcccountAccess.GetByPortalID(portalID);

             return MyDataSet;
        }

        /// <summary>
        /// Returns Account type for this AccountTypeid
        /// </summary>
        /// <param name="AccountTypeID"></param>
        /// <returns></returns>
        public AccountType GetByAccountTypeID(int AccountTypeID)
        {
            AccountTypeAdmin _AccountTypeAdmin = new AccountTypeAdmin();

            AccountType _AccountTypeList  = _AccountTypeAdmin.GetByAccountTypeID(AccountTypeID);

            return _AccountTypeList;
        }
        /// <summary>
        /// Get a case for Given Inputs
        /// </summary>
        /// <param name="caseid"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="companyname"></param>
        /// <param name="title"></param>        
        /// <param name="casestatusid"></param>
        /// <returns></returns>
        public DataSet SearchCase(int casestatusid,string caseid, string firstname, string lastname, string companyname, string title)
        {
            CaseHelper _CaseHelper = new CaseHelper();
            
            DataSet MyDataSet = _CaseHelper.SearchCase(casestatusid,caseid,firstname,lastname,companyname,title);

            return MyDataSet;
        }

        # endregion

        # region CasePriority Public Methods

        /// <summary>
        ///  Get all the Case Priority
        /// </summary>
        /// <returns></returns>   
        public TList<ZNode.Libraries.DataAccess.Entities.CasePriority> GetAllCasePriority()
        {
            ZNode.Libraries.DataAccess.Service.CasePriorityService _CasePriorityService = new ZNode.Libraries.DataAccess.Service.CasePriorityService();
            TList<ZNode.Libraries.DataAccess.Entities.CasePriority> CasepriorityList = _CasePriorityService.GetAll();

            return CasepriorityList;
        }

        /// <summary>
        /// Get a casepriority
        /// </summary>
        /// <param name="CasePriorityID"></param>
        /// <returns></returns>
        public CasePriority GetByCasePriorityID(int CasePriorityID)
        {
            ZNode.Libraries.DataAccess.Service.CasePriorityService _CasePriorityService = new ZNode.Libraries.DataAccess.Service.CasePriorityService();
            ZNode.Libraries.DataAccess.Entities.CasePriority _CasePriorityList = _CasePriorityService.GetByCasePriorityID(CasePriorityID);

            return _CasePriorityList;
        }

        # endregion

        # region CaseStatus Public Methods

        /// <summary>
        ///   Get all the Case status
        /// </summary>
        /// <returns></returns>   
        public TList<ZNode.Libraries.DataAccess.Entities.CaseStatus> GetAllCaseStatus()
        {
            ZNode.Libraries.DataAccess.Service.CaseStatusService _CaseStatusService = new ZNode.Libraries.DataAccess.Service.CaseStatusService();

            TList<ZNode.Libraries.DataAccess.Entities.CaseStatus> CaseStatusList = _CaseStatusService.GetAll();

            return CaseStatusList;
        }

        /// <summary>
        /// Get a Case Status
        /// </summary>
        /// <param name="CaseStatusID"></param>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.CaseStatus GetByCaseStatusID(int CaseStatusID)
        {
            ZNode.Libraries.DataAccess.Service.CaseStatusService _CaseStatusService = new ZNode.Libraries.DataAccess.Service.CaseStatusService();

            CaseStatus _caseStatusList = _CaseStatusService.GetByCaseStatusID(CaseStatusID);

            return _caseStatusList;
        }
        # endregion

    }
}
