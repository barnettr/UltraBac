using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    #region ZNodeProductType
    /// <summary>
    /// Represents the properties and methods of a ZNodeProductType.
    /// </summary>
    [XmlRoot()]
    public class ZNodeProductType : ZNodeBusinessBase
    {
        #region Private Member Variables
        protected int _productTypeId;
        protected int _portalId;
        protected string _name = String.Empty;
        protected string _description = String.Empty;
        protected int _displayOrder;
        protected string _attributeValue = string.Empty ;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ZNodeProductType()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Retrieves or sets the ProductTypeId
        /// </summary>
        [XmlElement()]
        public int ProductTypeId
        {
            get { return _productTypeId; }
            set { _productTypeId = value; }
        }

        /// <summary>
        /// Retrieves or sets the site portalId
        /// </summary>
        [XmlElement()]
        public int PortalId
        {
            get { return _portalId; }
            set { _portalId = value; }
        }

        /// <summary>
        /// Retrieves or sets the name for this ProductType
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Retrieves or sets the description for this ProductType
        /// </summary>
        [XmlElement()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Retrieves or sets the display order value for this ProductType
        /// </summary>
        [XmlElement()]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        #endregion
    }
    #endregion
}
