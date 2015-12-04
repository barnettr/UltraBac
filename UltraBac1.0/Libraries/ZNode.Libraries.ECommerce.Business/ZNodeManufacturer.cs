using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ZNode.Libraries.Framework.Business;
using System.Xml.Serialization;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents a product manufacturer in the catalog
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [Serializable()]
    [XmlRoot("ZNodeManufacturer")]
    public class ZNodeManufacturer : ZNodeBusinessBase
    {
        #region Private Variables
        private int _ManufacturerID = 0;
        private int _PortalID = 0;
        private string _Name = string.Empty;       
        private string _Description = string.Empty;
        private bool _ActiveInd;
        # endregion

        # region Public Properties
        /// <summary>
        /// Sets or retrieves the manufacturerid
        /// </summary>
        [XmlElement()]
        public int ManufacturerID
        {
            get
            {
                return _ManufacturerID;
            }
            set
            {
                _ManufacturerID = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the site portal id
        /// </summary>
        [XmlElement()]
        public int PortalID
        {
            get
            {
                return _PortalID;
            }
            set
            {
                _PortalID = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the name for this Manufacturer
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the description for this Manufacturer
        /// </summary>
        [XmlElement()]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the activeind value for this Manufacturer
        /// </summary>
        [XmlElement()]
        public bool ActiveInd
        {

            get
            {
                return _ActiveInd;
            }
            set
            {
                _ActiveInd = value;
            }
        }
        # endregion

        # region Constructors
        public ZNodeManufacturer()
        {
        }
        # endregion

        # region Public Methods

        /// <summary>
        /// This static method creates Manufacturer object using XMLSerializer
        /// </summary>
        /// <param name="ManufacturerID"></param>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public static ZNodeManufacturer Create(int ManufacturerID, int PortalID)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            string xmlOut = productHelper.GetManufacturerXML(ManufacturerID, PortalID);

            //serialize the object
            ZNodeSerializer ser = new ZNodeSerializer();
            return (ZNodeManufacturer)ser.GetContentFromString(xmlOut, typeof(ZNodeManufacturer));
    
        }

        # endregion
    }
}
