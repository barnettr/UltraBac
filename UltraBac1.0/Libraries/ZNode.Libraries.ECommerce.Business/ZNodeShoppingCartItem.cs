using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;
using System.Web;
namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents a product items in the shopping cart
    /// </summary>
    [Serializable()]    
    public class ZNodeShoppingCartItem : ZNodeBusinessBase
    {
        #region Member Variables
        private ZNodeProduct _Product = new ZNodeProduct();
        protected int _Quantity = 0;
        protected string _gUID = string.Empty;
        protected decimal _ShippingCost;        
        private ZNodeCoupon _Coupon = new ZNodeCoupon();
        private ZNodeOrder _Order = new ZNodeOrder();
        #endregion

        /// <summary>
        /// Default Constructor - Create GUID value for the shopping cart item
        /// </summary>
        public ZNodeShoppingCartItem()
        {
            //create GUID
            _gUID = System.Guid.NewGuid().ToString();

        }

        #region Public Properties

        /// <summary>
        /// Retrieves the GUID(unique value) for this Shopping cart item. 
        /// </summary>
        [XmlElement()]
        public string GUID
        {
            get
            {
                return _gUID;
            }          
        }

        /// <summary>
        /// Retrieves or sets the product object for this cart item
        /// </summary>
        [XmlElement()]
        public ZNodeProduct Product
        {
            get
            {
                return _Product;
            }
            set
            {
                _Product = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the coupon object for this cart item
        /// </summary>
        [XmlElement()]
        public ZNodeCoupon Coupon
        {
            get
            {
                return _Coupon;
            }
            set
            {
                _Coupon = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the order object for this cart item
        /// </summary>
        [XmlElement()]
        public ZNodeOrder Order
        {
            get
            {
                return _Order;
            }
            set
            {
                _Order = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the quantity value for this cart item
        /// </summary>
        [XmlElement()]
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the shipping cost for this cart item
        /// </summary>
        [XmlElement()]
        public decimal ShippingCost
        {
            get
            {
                return _ShippingCost;
            }
            set
            {
                _ShippingCost = value;
            }
        }     

        #endregion
    }
}
