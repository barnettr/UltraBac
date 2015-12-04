using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents a payment submission response including response codes and success flags
    /// </summary>
    public class ZNodePaymentResponse : ZNodeBusinessBase
    {
        /// <summary>
        /// Sets or retrieves the Gateway Response code 
        /// </summary>
        public string ResponseCode = string.Empty;
        /// <summary>
        /// Sets or retrieves the Gateway Response Text 
        /// </summary>
        public string ResponseText = string.Empty;
        /// <summary>
        /// Sets or retrieves the Gateway redirect URL - which holds Google Post URL 
        /// </summary>
        public string RedirectURL = string.Empty;        
        /// <summary>
        /// Sets or retrieves the Gateway TransactionID 
        /// </summary>
        public string TransactionId;
        /// <summary>
        /// Sets or retrieves the Gateway Response as boolean 
        /// </summary>
        public bool IsSuccess = false;
        /// <summary>
        ///  Sets or retrieves the Paypal Gateway token
        /// </summary>
        public string PaypalECtoken = string.Empty;       
        /// <summary>
        ///  Sets or retrieves the Paypal Gateway payer ID
        /// </summary>
        public string PaypalPayerID = string.Empty;
        /// <summary>
        /// Represents payer address object
        /// </summary>
        private ZNodeAddress _custAddress = new ZNodeAddress();
        /// <summary>
        /// Sets or retrieves the Paypal Gateway payer address
        /// </summary>
        public ZNodeAddress ShippingAddress 
        { 
            get { return _custAddress; } 
            set { _custAddress = value; } 
        }
            
    }
}
