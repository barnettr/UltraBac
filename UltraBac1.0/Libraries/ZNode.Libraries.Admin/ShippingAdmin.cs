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
    /// Provides methods  to manage shipping options
    /// </summary>
    public class ShippingAdmin:ZNodeBusinessBase 
    {
        # region Public Methods
       
        /// <summary>
        /// Get all the shipping options for this portal
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public DataSet GetAllShippingOptions(int portalId)
        {
            ZNode.Libraries.DataAccess.Custom.ShippingHelper shippingHelper = new ZNode.Libraries.DataAccess.Custom.ShippingHelper();

            DataSet MydataSet = shippingHelper.GetShippingOptionsByPortal(portalId);

            return MydataSet;
        }

        /// <summary>
        /// Get a shipping option
        /// </summary>
        /// <param name="ShippingId"></param>
        /// <returns></returns>
        public Shipping GetShippingOptionById(int shippingId)
        {
            ZNode.Libraries.DataAccess.Service.ShippingService shippingServ = new ZNode.Libraries.DataAccess.Service.ShippingService();
            Shipping shipping = shippingServ.GetByShippingID(shippingId);

            return shipping;
        }

        /// <summary>
        /// Add shipping option
        /// </summary>
        /// <param name="Shipping"></param>
        /// <returns></returns>
        public bool AddShippingOption(Shipping shipping)
        {
            ZNode.Libraries.DataAccess.Service.ShippingService shippingServ = new ZNode.Libraries.DataAccess.Service.ShippingService();

            return shippingServ.Insert(shipping);
        }

        /// <summary>
        /// Update shipping option
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public bool UpdateShippingOption(Shipping shipping)
        {
            ZNode.Libraries.DataAccess.Service.ShippingService shippingServ = new ZNode.Libraries.DataAccess.Service.ShippingService();

            return shippingServ.Update(shipping);
        }

        /// <summary>
        /// Delete shipping option
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public bool DeleteShippingOption(Shipping shipping)
        {
            ZNode.Libraries.DataAccess.Service.ShippingService shippingServ = new ZNode.Libraries.DataAccess.Service.ShippingService();

            return shippingServ.Delete(shipping);
        }

        /// <summary>
        /// Get the list of shipping service codes
        /// </summary>
        /// <param name="shippingTypeID"></param>
        /// <returns></returns>
        public DataSet GetShippingServiceCodes(int shippingTypeID)
        {
            ShippingServiceCodeService ShippingService = new ShippingServiceCodeService();
            TList<ShippingServiceCode> ServiceCodeList = ShippingService.GetByShippingTypeID(shippingTypeID);

            return ServiceCodeList.ToDataSet(true);
        }

        /// <summary>
        /// Get the list of shipping types
        /// </summary>
        /// <returns></returns>
        public TList<ShippingType> GetShippingTypes()
        {
            ShippingTypeService serv = new ShippingTypeService();
            return serv.GetAll();
        }

        /// <summary>
        /// Get the list of destination countries
        /// </summary>
        /// <returns></returns>
        public TList<Country> GetDestinationCountries()
        {
            CountryService countryServ = new CountryService();
            TList<ZNode.Libraries.DataAccess.Entities.Country> countries = countryServ.GetByPortalIDActiveInd(ZNodeConfigManager.SiteConfig.PortalID, true);

            //Add a default country
            Country cty = new Country();
            cty.Name = "All Countries";
            cty.Code = "*";
            cty.DisplayOrder = 0;
            countries.Add(cty);

            //sort
            countries.Sort("DisplayOrder,Name");

            return countries;
        }

        /// <summary>
        /// Get shipping type
        /// </summary>
        /// <param name="shippingTypeID"></param>
        /// <returns></returns>
        public string GetShippingTypeName(int shippingTypeID)
        {
            ShippingTypeService serv = new ShippingTypeService();
            return serv.GetByShippingTypeID(shippingTypeID).Name ;
        }

        /// <summary>
        /// Get profile name
        /// </summary>
        /// <param name="profileID"></param>
        /// <returns></returns>
        public string GetProfileNamee(int profileID)
        {
            ProfileService serv = new ProfileService();
            return serv.GetByProfileID(profileID).Name;
        }

        /// <summary>
        /// Get the shipping rules for an option
        /// </summary>
        /// <param name="shippingID"></param>
        /// <returns></returns>
        public DataSet GetShippingRules(int shippingID)
        {
            ZNode.Libraries.DataAccess.Custom.ShippingHelper shippingHelper = new ZNode.Libraries.DataAccess.Custom.ShippingHelper();

            DataSet MydataSet = shippingHelper.GetShippingRules(shippingID);

            return MydataSet;
        }

        /// <summary>
        /// Get a shipping rule
        /// </summary>
        /// <param name="shippingRuleID"></param>
        /// <returns></returns>
        public ShippingRule GetShippingRule(int shippingRuleID)
        {
            ShippingRuleService serv = new ShippingRuleService();
            return serv.GetByShippingRuleID(shippingRuleID);
        }

        /// <summary>
        /// Get shipping rule types
        /// </summary>
        /// <returns></returns>
        public TList<ShippingRuleType> GetShippingRuleTypes()
        {
            ShippingRuleTypeService serv = new ShippingRuleTypeService();
            return serv.GetAll();
        }




        /// <summary>
        /// Add shipping rule
        /// </summary>
        /// <param name="Shipping"></param>
        /// <returns></returns>
        public bool AddShippingRule(ShippingRule shippingRule)
        {
            ZNode.Libraries.DataAccess.Service.ShippingRuleService serv = new ZNode.Libraries.DataAccess.Service.ShippingRuleService();

            return serv.Insert(shippingRule);
        }

        /// <summary>
        /// Update shipping rule
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public bool UpdateShippingRule(ShippingRule shippingRule)
        {
            ZNode.Libraries.DataAccess.Service.ShippingRuleService serv = new ZNode.Libraries.DataAccess.Service.ShippingRuleService();

            return serv.Update(shippingRule);
        }

        /// <summary>
        /// Delete shipping rule
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public bool DeleteShippingRule(ShippingRule shippingRule)
        {
            ZNode.Libraries.DataAccess.Service.ShippingRuleService serv = new ZNode.Libraries.DataAccess.Service.ShippingRuleService();

            return serv.Delete(shippingRule);
        }

        # endregion

    }
}
