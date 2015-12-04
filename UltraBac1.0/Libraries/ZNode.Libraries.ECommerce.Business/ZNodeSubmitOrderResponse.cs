using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents a response to a order submittal
    /// </summary>
    public class ZNodeSubmitOrderResponse:ZNodeBusinessBase 
    {
        /// <summary>
        /// Represents the Gateway Response code 
        /// </summary>
        public string ResponseCode = string.Empty;
        /// <summary>
        /// Represents the Gateway Response Text
        /// </summary>
        public string ResponseText = string.Empty;
        /// <summary>
        /// Represents the Gateway Response as boolean 
        /// </summary>
        public bool IsSuccess = false;
        /// <summary>
        /// Represents gateway response as a PaymentResponse object
        /// </summary>
        public ZNodePaymentResponse PaymentResponse;
    }
}
