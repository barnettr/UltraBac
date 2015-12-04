using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization ;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.ECommerce.Business
{
    #region ZNodeSKU
    /// <summary>
    /// Represents the properties and methods of a ZNodeSKU.
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeSKU : ZNodeBusinessBase
    {
        #region Private Member Variables
        protected int _sKUID;
        protected int _productID;
        protected string _sKU = String.Empty;
        protected int _warehouseNo;
        protected string _note = String.Empty;
        protected decimal _surcharge;
        protected int _quantityOnHand;
        protected int _quantityBuffer;
        protected int _reorderLevel;
        protected decimal _weightAdditional;
        protected string _sKUPicturePath = String.Empty;
        protected int _displayOrder;
        protected decimal _retailPrice;
        protected decimal _wholesalePrice;
        protected bool _isActive;
        protected string _attributesDescription;
        #endregion

        #region Constructor
        public ZNodeSKU()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Retrieves or sets the SKU id
        /// </summary>
        [XmlElement()]
        public int SKUID
        {
            get { return _sKUID; }
            set { _sKUID = value; }
        }

        /// <summary>
        /// Retrieves or sets the productid for this SKU
        /// </summary>
        [XmlElement()]
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
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
        /// Retrieves or sets the Warehouse number for this SKU
        /// </summary>
        [XmlElement()]
        public int WarehouseNo
        {
            get { return _warehouseNo; }
            set { _warehouseNo = value; }
        }

        /// <summary>
        /// Retrieves or sets the text notes for this SKU
        /// </summary>
        [XmlElement()]
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        /// <summary>
        /// Retrieves or sets the sur-charge for this SKU
        /// </summary>
        [XmlElement()]
        public decimal Surcharge
        {
            get { return _surcharge; }
            set { _surcharge = value; }
        }

        /// <summary>
        /// Retrieves or sets the qantity on stock for this SKU
        /// </summary>
        [XmlElement()]
        public int QuantityOnHand
        {
            get { return _quantityOnHand; }
            set { _quantityOnHand = value; }
        }

        /// <summary>
        /// Retrieves or sets the quantity buffer value for this SKU
        /// </summary>
        [XmlElement()]
        public int QuantityBuffer
        {
            get { return _quantityBuffer; }
            set { _quantityBuffer = value; }
        }

        /// <summary>
        /// Retrieves or sets the reorder level for this SKU. 
        /// If the quantity on stock reaches this reorder level, then it will send email to sales department
        /// </summary>
        [XmlElement()]
        public int ReorderLevel
        {
            get { return _reorderLevel; }
            set { _reorderLevel = value; }
        }

        /// <summary>
        /// Retrieves or sets the additional weight value for this SKU
        /// </summary>
        [XmlElement()]
        public decimal WeightAdditional
        {
            get { return _weightAdditional; }
            set { _weightAdditional = value; }
        }

        /// <summary>
        /// Retrieves or sets fully qualified image file path
        /// </summary>
        [XmlElement()]
        public string SKUPicturePath
        {
            get { return _sKUPicturePath; }
            set { _sKUPicturePath = value; }
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
        /// Retrieves or sets the additional retail price value for this SKU
        /// </summary>
        [XmlElement()]
        public decimal RetailPriceAdditional
        {
            get { return _retailPrice; }
            set { _retailPrice = value; }
        }

        /// <summary>
        /// Retrieves or sets the wholesale price value for this SKU
        /// </summary>
        [XmlElement()]
        public decimal WholesalePriceAdditional
        {
            get { return _wholesalePrice; }
            set { _wholesalePrice = value; }
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
        /// Stores metadata on this sku (attribute selection, etc)
        /// This metadata is displayed on the shopping cart list
        /// This property is set explicily by the UI and is not retrieved automatically
        /// </summary>
        [XmlIgnore()]
        public string AttributesDescription
        {
            get { return _attributesDescription; }
            set { _attributesDescription = value; }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Returns a SKU based on the productID and Attributes
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static ZNodeSKU CreateByProductAndAttributes(int productId, string attributes)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            string xmlOut = productHelper.GetSKUByAttributes(productId, attributes);

            ZNodeSKU SKU = new ZNodeSKU();

            //serialize the object
            if (xmlOut.Trim().Length > 0)
            {
                ZNodeSerializer ser = new ZNodeSerializer();
                SKU = (ZNodeSKU)ser.GetContentFromString(xmlOut, typeof(ZNodeSKU));
            }
            return SKU;
        }

        /// <summary>
        /// Returns a SKU based on the SKUID
        /// </summary>
        /// <param name="skuId"></param>
        /// <returns></returns>
        public static ZNodeSKU CreateBySKU(string SKU)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            string xmlOut = productHelper.GetBySKU(SKU);

            ZNodeSKU objSKU = new ZNodeSKU();

            //serialize the object
            if (xmlOut.Trim().Length > 0)
            {
                ZNodeSerializer ser = new ZNodeSerializer();
                objSKU = (ZNodeSKU)ser.GetContentFromString(xmlOut, typeof(ZNodeSKU));
            }
            return objSKU;
        }

        /// <summary>
        /// Returns a Default SKU for a product with no attributes
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static ZNodeSKU CreateByProductDefault(int productId)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            string xmlOut = productHelper.GetDefaultSKU(productId);

            ZNodeSKU SKU = new ZNodeSKU();

            //serialize the object
            if (xmlOut.Trim().Length > 0)
            {
                ZNodeSerializer ser = new ZNodeSerializer();
                SKU = (ZNodeSKU)ser.GetContentFromString(xmlOut, typeof(ZNodeSKU));
            }
            return SKU;
        }

        #endregion

    }
    #endregion
}
