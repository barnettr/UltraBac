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
    /// Provides methods to manage User profiles
    /// </summary>
    public class ProfileAdmin:ZNodeBusinessBase 
    {
        /// <summary>
        /// Returns all the Profiles
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.Profile> GetAll()
        {
            ZNode.Libraries.DataAccess.Service.ProfileService _ProfileService = new ProfileService();

            TList<ZNode.Libraries.DataAccess.Entities.Profile> _ProfileList = _ProfileService.GetAll();

            return _ProfileList;
        }


        /// <summary>
        /// Returns a Profile for a Profile ID
        /// </summary>
        /// <param name="profileID"></param>
        /// <returns></returns>
        public Profile  GetByProfileID(int profileID)
        {
            ZNode.Libraries.DataAccess.Service.ProfileService _ProfileService = new ProfileService();

            ZNode.Libraries.DataAccess.Entities.Profile _ProfileList = _ProfileService.GetByProfileID(profileID);

            return  _ProfileList;

        }
        
    }
}
