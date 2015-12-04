using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents a pricing object and provides properties to return price of a product
    /// </summary>
    [Serializable()]
    public class ZNodePrice : ZNodeBusinessBase
    {
        #region Member Variables
        private decimal _ActualPrice=0;
        private decimal _DiscountedPrice=0;
        private string _DiscountName = string.Empty;
        private string _DiscountText = string.Empty;
        #endregion

        #region Public Properties
        /// <summary>
        /// Actual price of a product or service (without discounts and promotions)
        /// </summary>
        public decimal ActualPrice
        {
            get
            {
                return _ActualPrice;
            }
            set
            {
                _ActualPrice = value;
            }
        }
        
        /// <summary>
        /// Price with discounts or promotions applied. If no discounts applied, it will return the actual price
        /// </summary>
        public decimal DiscountedPrice
        {
            get
            {
                if (_DiscountedPrice == 0)
                {
                    return _ActualPrice;
                }
                else
                {
                    return _DiscountedPrice;
                }
            }
            set
            {
                _DiscountedPrice = value;
            }
        }

        /// <summary>
        /// Name of the discount or promotion applied (ex: Frequent Buyer Discount)
        /// </summary>
        public string DiscountName
        {
            get
            {
                return _DiscountName;
            }
            set
            {
                _DiscountName = value;
            }
        }
        
        /// <summary>
        /// Details of the discount applied
        /// </summary>
        public string DiscountText
        {
            get
            {
                return _DiscountText;
            }
            set
            {
                _DiscountText = value;
            }
        }
        #endregion
    }
}
