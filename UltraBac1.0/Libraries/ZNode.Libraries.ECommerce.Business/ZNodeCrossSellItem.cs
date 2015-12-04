using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents a cross-sell product item
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [Serializable()]
    [XmlRoot("ZNodeCrossSellItem")]
    public class ZNodeCrossSellItem : ZNodeBusinessBase
    {
        #region Private Variables
        private int _ProductId = 0;
        private int _PortalId = 0;
        private string _Name = string.Empty;
        private string _Description = string.Empty;        
        private string _ImageFile;
        #endregion      

        #region Public Properties
       
        /// <summary>
        /// Retrieves or Sets the productid for this cross sell product
        /// </summary>
        [XmlElement()]
        public int ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
            }
        }
        /// <summary>
        /// Retrieves or Sets the site portal id
        /// </summary>
        [XmlElement()]
        public int PortalId
        {
            get
            {
                return _PortalId;
            }
            set
            {
                _PortalId = value;
            }
        }

        /// <summary>
        /// Retrieves or Sets the cross sell product Name
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
        /// Retrieves or Sets the description for this cross sell product.
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
        /// Returns the image file name for this cross sell product.
        /// </summary>
        [XmlElement()]
        public string ImageFile
        {
            get
            {
                return _ImageFile;
            }
            set
            {
                _ImageFile = value;
            }
        }       
        #endregion

        #region Constructors
        public ZNodeCrossSellItem()
        {

        }
        #endregion

    }      
}
