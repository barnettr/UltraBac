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
    /// Provides methods to manage shipping rules types
    /// </summary>
    public class ShippingRuleTypeAdmin:ZNodeBusinessBase 
    {
        # region Public Methods
        /// <summary>
        /// Returns all Shipping rule types
        /// </summary>
        /// <returns></returns>
        public TList<ShippingRuleType> GetAllShippingRuleType()
        {

            ZNode.Libraries.DataAccess.Service.ShippingRuleTypeService ShippingRuleType = new ShippingRuleTypeService();
            TList<ZNode.Libraries.DataAccess.Entities.ShippingRuleType> _ShippingRuleTypeList = ShippingRuleType.GetAll();

            return _ShippingRuleTypeList;

        }

        /// <summary>
        /// Return a Shipping rule type for this ID
        /// </summary>
        /// <returns></returns>
        public ShippingRuleType GetByShippingRuleTypeID(int shippingRuleTypeID)
        {

            ZNode.Libraries.DataAccess.Service.ShippingRuleTypeService ShippingRuleType = new ShippingRuleTypeService();
            ZNode.Libraries.DataAccess.Entities.ShippingRuleType _ShippingRuleType = ShippingRuleType.GetByShippingRuleTypeID(shippingRuleTypeID);

            return _ShippingRuleType;

        }
        # endregion
    }
}
