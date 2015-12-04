using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    #region ZNodeAttribute
    /// <summary>
    /// Represents the properties and methods of a ZNodeAttribute.
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeAttribute : ZNodeBusinessBase
    {
        #region Private Member Variables
        protected int _attributeId;
        protected int _attributeTypeId;
        protected string _name = String.Empty;
        protected string _externalId = String.Empty;
        protected int _displayOrder;
        protected bool _isActive;
        protected int _oldAttributeId;
        #endregion

        #region Constructor
        public ZNodeAttribute()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Retrieves or sets the Product AttributeID
        /// </summary>
        [XmlElement()]
        public int AttributeId
        {
            get { return _attributeId; }
            set { _attributeId = value; }
        }

        /// <summary>
        /// Retrieves or sets the Product AttributeTypeID
        /// </summary>
        [XmlElement()]
        public int AttributeTypeId
        {
            get { return _attributeTypeId; }
            set { _attributeTypeId = value; }
        }

        /// <summary>
        /// Retrieves or sets the Product Attribute Name
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Retrieves or sets the Product Attribute ExternalId
        /// </summary>
        [XmlElement()]
        public string ExternalId
        {
            get { return _externalId; }
            set { _externalId = value; }
        }

        /// <summary>
        /// Retrieves or sets the IsActive property
        /// </summary>
        [XmlElement()]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        /// Retrieves or sets the Product Attribute display order
        /// </summary>
        [XmlElement()]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// <summary>
        /// Retrieves or sets the OldAttributeId property
        /// </summary>
        [XmlElement()]
        public int OldAttributeId
        {
            get { return _oldAttributeId; }
            set { _oldAttributeId = value; }
        }
        #endregion

    }
    #endregion

}
