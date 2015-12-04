using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage tax rules
    /// </summary>
    public class TaxRuleAdmin:ZNodeBusinessBase 
    {
        /// <summary>
        /// Get all the tax rules
        /// </summary>
        /// <returns></returns>
        public TList<TaxRule> GetAllTaxRulesByPortal(int portalID)
        {
            TaxRuleService serv = new TaxRuleService();
            return serv.GetByPortalID(portalID);
        }

        /// <summary>
        /// Add a new tax rule
        /// </summary>
        /// <param name="taxRule"></param>
        /// <returns></returns>
        public bool AddTaxRule(TaxRule taxRule)
        {
            TaxRuleService serv = new TaxRuleService();
            return serv.Insert(taxRule);
        }

        /// <summary>
        /// Delete tax rule
        /// </summary>
        /// <param name="taxRule"></param>
        /// <returns></returns>
        public bool DeleteTaxRule(TaxRule taxRule)
        {
            TaxRuleService serv = new TaxRuleService();
            return serv.Delete(taxRule);
        }

        /// <summary>
        /// Update a tax rule
        /// </summary>
        /// <param name="taxRule"></param>
        /// <returns></returns>
        public bool UpdateTaxRule(TaxRule taxRule)
        {
            TaxRuleService serv = new TaxRuleService();
            return serv.Update(taxRule);
        }

        /// <summary>
        /// Get tax rule
        /// </summary>
        /// <param name="taxRuleID"></param>
        /// <returns></returns>
        public TaxRule GetTaxRule(int taxRuleID)
        {
            TaxRuleService serv = new TaxRuleService();
            return serv.GetByTaxRuleID(taxRuleID);
        }

    }
}
