using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage Customers
    /// </summary>
    public class CustomerAdmin:ZNodeBusinessBase 
    {
        /// <summary>
        /// Returns a Login Name for a User id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetByUserID(int userID)
        {
            string LoginName = string.Empty;

            ZNode.Libraries.DataAccess.Custom.CustomerHelper _CustomerHelper = new CustomerHelper();
            LoginName = _CustomerHelper.GetByUserID(userID);

            return LoginName;
        }

        /// <summary>
        /// Returns a Contact status
        /// </summary>
        /// <param name="_ContactTemperatureID"></param>
        /// <returns></returns>
        public ContactTemperature GetByContactTemperatureID(int _ContactTemperatureID)
        {
            ZNode.Libraries.DataAccess.Service.ContactTemperatureService _ContactTemperatureService = new ZNode.Libraries.DataAccess.Service.ContactTemperatureService();
            ContactTemperature _ContactTemperature = _ContactTemperatureService.GetByContactTemperatureID(_ContactTemperatureID);

            return _ContactTemperature;
        }
        
        /// <summary>
        /// Get all Contact status (Contact Temperature)
        /// </summary>
        /// <returns></returns>
        public TList<ContactTemperature> GetAllContactStatus()
        {
            ZNode.Libraries.DataAccess.Service.ContactTemperatureService _ContactTemperatureService = new ZNode.Libraries.DataAccess.Service.ContactTemperatureService();

            return _ContactTemperatureService.GetAll();
        }

    }
}
