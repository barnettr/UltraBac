using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to calculate promotions
    /// </summary>
    public class ZNodePromotion:ZNodeBusinessBase 
    {
        /// <summary>
        /// Returns discount amount for this Promotion
        /// </summary>
        /// <returns></returns>
        public decimal GetCalculatedDiscount()
        {
            return 0;
        }
    }
}
