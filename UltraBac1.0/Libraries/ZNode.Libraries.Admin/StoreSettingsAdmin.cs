using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using System.Data;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// This class manages storefront and portal settings
    /// </summary>
    public class StoreSettingsAdmin:ZNodeBusinessBase 
    {
        #region General Store Settings
        /// <summary>
        /// Updates Portal Settings
        /// </summary>
        /// <param name="portal"></param>
        /// <returns></returns>
        public bool Update(Portal Portal)
        {
            PortalService portalServ = new PortalService();
            bool checkStatus = portalServ.Update(Portal);

            return checkStatus;
        }

        /// <summary>
        /// Retrieves store settings for a portal
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public Portal GetByPortalId(int PortalID)
        {
            PortalService portalServ = new PortalService();
            return portalServ.GetByPortalID(PortalID);
        }

        /// <summary>
        /// Retrieves All store settings for a portal
        /// </summary>        
        /// <returns></returns>
        public TList<Portal> Getall()
        {
            PortalService portalserv = new PortalService();
            return portalserv.GetAll();
        }

        /// <summary>
        /// Delete portal setting
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public bool DeletePortal(int PortalId)
        {
            PortalService portalserv = new PortalService();
            bool Status = portalserv.Delete(PortalId);
            return Status;
        }
        #endregion

        #region Payment Settings
        /// <summary>
        /// Retrieves payment settings for a portal
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public DataSet GetPaymentSettings(int PortalID)
        {
            StoreSettingsHelper storeSettingsHelper = new StoreSettingsHelper();
            return storeSettingsHelper.GetPaymentSettingsByPortal(PortalID);
        }

        /// <summary>
        /// Get a specific payment setting
        /// </summary>
        /// <param name="PaymentSettingID"></param>
        /// <returns></returns>
        public PaymentSetting GetPaymentSettingByID(int PaymentSettingID)
        {
            PaymentSettingService pmtSetServ = new PaymentSettingService();
            return pmtSetServ.GetByPaymentSettingID(PaymentSettingID);
        }

        /// <summary>
        /// Get the list of gateways
        /// </summary>
        /// <returns></returns>
        public TList<Gateway> GetGateways()
        {
            GatewayService gwayServ = new GatewayService();
            return gwayServ.GetAll();
        }

        /// <summary>
        ///return the payment type for this paymentypeId
        /// </summary>
        /// <returns></returns>
        public PaymentType GetPaymentTypeById(int paymentTypeId)
        {
            PaymentTypeService paymenTypeServ = new PaymentTypeService();
            return paymenTypeServ.GetByPaymentTypeID(paymentTypeId);
        }

        /// <summary>
        /// Get profiles for this portal
        /// </summary>
        /// <returns></returns>
        public TList<Profile> GetProfiles(int PortalID)
        {
            ProfileService profServ = new ProfileService();
            return profServ.GetByPortalID(PortalID);
        }

        /// <summary>
        /// Get all the payment types
        /// </summary>
        /// <returns></returns>
        public TList<PaymentType> GetPaymentTypes()
        {
            PaymentTypeService pmtTypeServ = new PaymentTypeService();
            return pmtTypeServ.GetAll();
        }

        /// <summary>
        /// Update a payment setting
        /// </summary>
        /// <param name="UpdatedPaymentSetting"></param>
        public bool UpdatePaymentSetting(PaymentSetting UpdatedPaymentSetting)
        {
            PaymentSettingService pmtSetSrv = new PaymentSettingService();
            return pmtSetSrv.Update(UpdatedPaymentSetting);
        }

        /// <summary>
        /// Add a new payment setting
        /// </summary>
        /// <param name="UpdatedPaymentSetting"></param>
        public bool AddPaymentSetting(PaymentSetting NewPaymentSetting)
        {
            PaymentSettingService pmtSetSrv = new PaymentSettingService();
            return pmtSetSrv.Insert(NewPaymentSetting);
        }

        /// <summary>
        /// Delete a payment setting
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <returns></returns>
        public bool DeletePaymentSetting(int PaymentSettingID)
        {
            PaymentSettingService pmtSetSrv = new PaymentSettingService();
            return pmtSetSrv.Delete(PaymentSettingID);            
        }

        /// <summary>
        /// Check if a setting with the paymenttype atleast one for this profile 
        /// </summary>
        /// <param name="ProfileID"></param>
        /// <returns>Return Bool value</returns>
        public bool CheckPaymentSettingProfile(int ProfileID)
        {
            PaymentSettingService pmtSetSrv = new PaymentSettingService();                
            TList<PaymentSetting> pmtSetList = pmtSetSrv.GetByProfileID(ProfileID);

            if (pmtSetList.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if a setting with the paymenttype already exists for this profile
        /// </summary>
        /// <param name="ProfileID"></param>
        /// <param name="PaymentTypeID"></param>
        /// <returns></returns>
        public bool PaymentSettingExists(int ProfileID, int PaymentTypeID)
        {
            PaymentSettingService pmtSetSrv = new PaymentSettingService();
            TList<PaymentSetting> pmtSetList = pmtSetSrv.GetByProfileIDPaymentTypeID(ProfileID, PaymentTypeID);

            if (pmtSetList.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
