using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ZNode.Libraries.Framework.Business;
using System.Xml.Serialization;
using System.Data;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using ZNode.Libraries.DataAccess.Service;
using System.Collections;


namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to calculate Coupon discounts
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [Serializable()]
    [XmlRoot("ZNodeCoupon")]
    public class ZNodeCoupon : ZNodeBusinessBase
    {
        #region Private Variables
        private int _CouponID;
        private string _CouponCode;
        private decimal _Discount;
        private int _DiscountTypeID;
        private int _DiscountTargetID;
        private DateTime _StartDate;
        private DateTime _ExpDate;
        private int _QuantityAvailable;
        private string _ProductList;        
        private decimal _OrderMinimum;
        protected ZNodeShoppingCart _shoppingCart = (ZNodeShoppingCart)ZNodeShoppingCart.CreateFromSession(ZNodeSessionKeyType.ShoppingCart);
        private ZNodeGenericCollection<ZNodeShoppingCartItem> _shoppingCartItems = new ZNodeGenericCollection<ZNodeShoppingCartItem>();
        #endregion

        # region Public Properties

        /// <summary>
        /// Retrieves or Sets the Coupon id
        /// </summary>
        [XmlElement()]
        public int CouponID
        {
            get 
            {
                return _CouponID;
            }
            set 
            {
                _CouponID = value;
            }
        }

        /// <summary>
        /// Retrieves or Sets the coupon code
        /// </summary>
        [XmlElement()]
        public string CouponCode
        {
            get
            {
                return _CouponCode;
            }
            set
            {
                _CouponCode = value;
            }
        }

        /// <summary>
        /// Retrieves or Sets the discount value for this coupon
        /// </summary>
        [XmlElement()]
        public decimal Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
            
       }

        /// <summary>
       /// Retrieves the discount amount for this coupon
        /// </summary>
        [XmlElement()]
        public decimal DiscountAmount
        {
            get
            {
                if(_ProductList!= null )
                {
                    return _Discount;
                }
                else
                {
                    return 0;
                }
            }            
        }

        /// <summary>
        /// Retrieves or Sets the discount typeid for this coupon
        /// </summary>
        [XmlElement()]
        public int DiscountTypeID
        {
            get
            {
                return _DiscountTypeID;
            }
            set
            {
                _DiscountTypeID = value;
            }
        }
        
        /// <summary>
        /// Retrieves or Sets the begin date for this coupon
        /// </summary>
        [XmlElement()]
        public DateTime StartDate
        {
            get
            {
                return (DateTime)_StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }

        /// <summary>
        /// Retrieves or Sets the end date for this coupon
        /// </summary>
        [XmlElement()]
        public DateTime ExpDate
        {
            get
            {
                return (DateTime)_ExpDate;
            }
            set
            {
                _ExpDate = value;
            }
        }

        /// <summary>
        /// Retrieves or Sets the available quantity for this coupon
        /// </summary>
        [XmlElement()]
        public int QuantityAvailable
        {
            get
            {
                return _QuantityAvailable;
            }
            set
            {
                _QuantityAvailable = value;
            }
        }

        /// <summary>
        /// Retrieves or Sets the product list for this coupon 
        /// </summary>
        [XmlElement()]
        public string ProductList
        {
            get
            {
                return _ProductList;
            }
            set
            {
                _ProductList = value;
            }
        }

        /// <summary>
        /// Retrieves or Sets the discounttargetid for this coupon
        /// </summary>
        [XmlElement()]
        public int DiscountTargetID
        {
            get
            {
                return _DiscountTargetID;
            }
            set
            {
                _DiscountTargetID = value;
            }
        }
        /// <summary>
        /// Retrieves or Sets the order minimum value for this coupon
        /// </summary>
        [XmlElement()]
        public decimal OrderMinimum
        {
            get
            {
                return _OrderMinimum;
            }
            set
            {
                _OrderMinimum = value;
            }
        }

        #endregion

        # region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ZNodeCoupon()
        {
        }
        # endregion
        
    }  
}
