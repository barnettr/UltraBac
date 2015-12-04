using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents the properties and methods of a product AddOn values.
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeAddOnValue : ZNodeBusinessBase
    {
        #region Private Member Variables
        protected int _addOnId;
        protected int _addOnValueId;
        protected string _sKU = String.Empty;        
        protected string _name = String.Empty;
        protected string _description = String.Empty;
        protected int _quantityOnHand;
        protected decimal _weightAdditional;        
        protected int _displayOrder;
        protected decimal _retailPrice;        
        protected bool _isDefault;        
        #endregion

        #region Public Properties
        /// <summary>
        /// Retrieves or sets the AddOnValue id
        /// </summary>
        [XmlElement()]
        public int AddOnValueID
        {
            get { return _addOnValueId; }
            set { _addOnValueId = value; }
        }

        /// <summary>
        /// Retrieves or sets the AddOnid for this AddOn Value
        /// </summary>
        [XmlElement()]
        public int AddOnId
        {
            get { return _addOnId; }
            set { _addOnId = value; }
        }

        /// <summary>
        /// Retrieves or sets the Add-on value Name
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Retrieves or sets the Add-on value description
        /// </summary>
        [XmlElement()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Retrieves or sets the SKU Name
        /// </summary>
        [XmlElement()]
        public string SKU
        {
            get { return _sKU; }
            set { _sKU = value; }
        }

        /// <summary>
        /// Retrieves or sets the IsDefault property
        /// </summary>
        [XmlElement()]
        public bool IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; }
        }

        /// <summary>
        /// Retrieves or sets the qantity on stock for this addonValue
        /// </summary>
        [XmlElement()]
        public int QuantityOnHand
        {
            get { return _quantityOnHand; }
            set { _quantityOnHand = value; }
        }


        /// <summary>
        /// Retrieves or sets the order of the display
        /// </summary>
        [XmlElement()]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// <summary>
        /// Retrieves or sets the additional retail price value for this addon value
        /// </summary>
        [XmlElement()]
        public decimal RetailPriceAdditional
        {
            get { return _retailPrice; }
            set { _retailPrice = value; }
        }

        /// <summary>
        /// Retrieves or sets the weight of this addon value 
        /// </summary>
        [XmlElement()]
        public decimal WeightAdditional
        {
            get
            {
                return _weightAdditional;
            }
            set
            {
                _weightAdditional = value;
            }
        }

        # endregion
    }
}
