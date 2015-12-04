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
    /// Provides methods to manage product manufacturers
    /// </summary>
    public class ManufacturerAdmin:ZNodeBusinessBase 
    {
        # region Public Methods

        /// <summary>
        /// Returns all manufacturers for a portal
        /// </summary>
        /// <param name="_portalID"></param>
        /// <returns></returns>
        public TList<Manufacturer> GetAllByPortalID(int _portalID)
        {

            ZNode.Libraries.DataAccess.Service.ManufacturerService _manufacturerAccess = new ManufacturerService();
            TList<ZNode.Libraries.DataAccess.Entities.Manufacturer> _ManufacturerList = _manufacturerAccess.GetByPortalID(_portalID);

            return _ManufacturerList;
        }

        /// <summary>
        /// Returns the row for the manufacturerID
        /// </summary>
        /// <param name="manufacturerID"></param>
        /// <returns></returns>
        public Manufacturer GetByManufactureId(int manufacturerID)
        {
            ZNode.Libraries.DataAccess.Service.ManufacturerService _manufacturerAccess = new ManufacturerService();
            Manufacturer _ManufacturerList = _manufacturerAccess.GetByManufacturerID(manufacturerID);

            return _ManufacturerList;
        }

        /// <summary>
        /// Insert a new Manufacturer
        /// </summary>
        /// <param name="_Manuf"></param>
        /// <returns></returns>
        public bool Insert(Manufacturer _Manuf)
        {
            ZNode.Libraries.DataAccess.Service.ManufacturerService _manufacturerAccess = new ManufacturerService();
            bool Status = _manufacturerAccess.Insert(_Manuf);

            return Status;
        }
        /// <summary>
        /// update the Manufacturer
        /// </summary>
        /// <param name="_Manuf"></param>
        /// <returns></returns>
        public bool Update(Manufacturer _Manuf)
        {
            ZNode.Libraries.DataAccess.Service.ManufacturerService _manufacturerAccess = new ManufacturerService();

            bool status = _manufacturerAccess.Update(_Manuf);
            return status;
        }
        /// <summary>
        /// Delete the Manufacturer
        /// </summary>
        /// <param name="_Maunf"></param>
        /// <returns></returns>
        public bool Delete(int ManufacturerId)
        {
            ZNode.Libraries.DataAccess.Service.ManufacturerService _manufacturerAccess = new ManufacturerService();
            bool status = _manufacturerAccess.Delete(ManufacturerId);
            return status;
        }

        # endregion
    }
}
