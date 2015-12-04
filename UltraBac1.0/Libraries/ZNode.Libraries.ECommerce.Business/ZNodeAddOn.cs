using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents the properties and methods of a product AddOn.
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeAddOn : ZNodeBusinessBase
    {

        #region Private Member Variables
        protected int _addOnId;
        protected int _productId;
        protected string _name = String.Empty;
        protected string _title = String.Empty;
        protected bool _allowbackOrder = false;
        protected bool _trackInventory = false;
        protected bool _isOptional;
        protected int _displayOrder;
        protected string _outofStockMsg = string.Empty;
        protected string _inStockMsg = string.Empty;
        protected string _backOrderMsg = string.Empty;
        protected ZNodeGenericCollection<ZNodeAddOnValue> _addonValueCollection = new ZNodeGenericCollection<ZNodeAddOnValue>();

        #endregion

        #region Constructor
        public ZNodeAddOn()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Collection of product addon values
        /// </summary>
        [XmlElement("ZNodeAddOnValue")]
        public ZNodeGenericCollection<ZNodeAddOnValue> ZNodeAddOnValueCollection
        {
            get
            {
                return _addonValueCollection;
            }
            set
            {
                _addonValueCollection = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the Product Add-onId
        /// </summary>
        [XmlElement()]
        public int AddOnID
        {
            get { return _addOnId; }
            set { _addOnId = value; }
        }

        /// <summary>
        /// Retrieves or sets the ProductID
        /// </summary>
        [XmlElement()]
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        /// <summary>
        /// Retrieves or sets the Product Add-on Name
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Retrieves or sets the Product Add-on Name
        /// </summary>
        [XmlElement()]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Retrieves or sets the AllowbackOrder property
        /// Items can always be added to the cart and Inventory is reduced
        /// </summary>
        [XmlElement()]
        public bool AllowBackOrder
        {
            get { return _allowbackOrder; }
            set { _allowbackOrder = value; }
        }

        /// <summary>
        /// Retrieves or sets the AllowbackOrder property        
        /// </summary>
        [XmlElement()]
        public bool TrackInventoryInd
        {
            get { return _trackInventory; }
            set { _trackInventory = value; }
        }

        /// <summary>
        /// Retrieves or sets the OptionalInd property
        /// </summary>
        [XmlElement()]
        public bool OptionalInd
        {
            get { return _isOptional; }
            set { _isOptional = value; }
        }

        /// <summary>
        /// Retrieves or sets the Product Add-on display order
        /// </summary>
        [XmlElement()]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// <summary>
        /// Retrieves or sets the Out of Stock message
        /// </summary>
        [XmlElement()]
        public string OutOfStockMsg
        {
            get { return _outofStockMsg; }
            set { _outofStockMsg = value; }
        }

        /// <summary>
        /// Retrieves or sets the Out of In-Stock message
        /// </summary>
        [XmlElement()]
        public string InStockMsg
        {
            get { return _inStockMsg; }
            set { _inStockMsg = value; }
        }

        /// <summary>
        /// Retrieves or sets the Out of Back Order message
        /// </summary>
        [XmlElement()]
        public string BackOrderMsg
        {
            get { return _backOrderMsg; }
            set { _backOrderMsg = value; }
        }

        #endregion
    }
}
