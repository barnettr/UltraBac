using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents the properties and methods of a ZNodeAttributeType
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeAttributeType : ZNodeBusinessBase
    {
        #region Private Member Variables
        protected int _attributeTypeId;
        protected int _portalId;
        protected string _name = String.Empty;
        protected string _description = String.Empty;
        protected int _displayOrder;
        protected bool _isPrivate;
        protected int _selectedAttributeId;
        protected ZNodeGenericCollection <ZNodeAttribute> _attributeCollection = new ZNodeGenericCollection <ZNodeAttribute>();
        #endregion

        #region Constructor
        public ZNodeAttributeType()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Collection of product attributes
        /// </summary>
        [XmlElement("ZNodeAttribute")]
        public ZNodeGenericCollection<ZNodeAttribute> ZNodeAttributeCollection
        {
            get
            {
                return _attributeCollection;
            }
            set
            {
                _attributeCollection = value;
            }
        }
        /// <summary>
        /// Corresponds to the Product AttributeTypeId
        /// </summary>
        [XmlElement()]
        public int AttributeTypeId
        {
            get { return _attributeTypeId; }
            set { _attributeTypeId = value; }
        }

        /// <summary>
        /// Corresponds to the site portalId
        /// </summary>
        [XmlElement()]
        public int PortalId
        {
            get { return _portalId; }
            set { _portalId = value; }
        }

        /// <summary>
        /// Corresponds to the AttributeType Name
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Corresponds to the AttributeType Description
        /// </summary>
        [XmlElement()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Corresponds to the AttributeType display order
        /// </summary>
        [XmlElement()]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// <summary>
        /// Retrieves or Sets the IsPrivate property
        /// </summary>
        [XmlElement()]
        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
        }

        /// <summary>
        /// Corresponds to the attribute selected by the user. 
        /// </summary>
        [XmlIgnore()]
        public int SelectedAttributeId
        {
            get { return _selectedAttributeId; }
            set { _selectedAttributeId = value; }
        }

        #endregion

    }

}
