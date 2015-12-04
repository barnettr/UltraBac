using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Integrator;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides an abstract base class for Payment
    /// </summary>
    public abstract class ZNodePaymentBase : ZNodeBusinessBase
    {
        /// <summary>
        /// Represents the Customer Billing Address object
        /// </summary>
        public abstract ZNodeAddress BillingAddress { get; set;}
        public abstract ZNodeAddress ShippingAddress { get; set;}
        /// <summary>
        /// Represents the paypal,google,Payflow Pro  payment gateway action
        /// </summary>
        public abstract ECGatewayAction GatewayAction { get; set; }

        /// <summary>
        /// Represents the Current Shopping Cart Object
        /// </summary>
        public abstract ZNodeShoppingCart CurrentShoppingCart { get; set;}

        public  string PaypalToken = string.Empty;
        public  string PayPalPayerID = string.Empty;
        public  string PaypalReturnURL = string.Empty;
        public  string PaypalCancelURL = string.Empty;

        /// <summary>
        /// Abstract method represents submit payment based on payment settings
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public abstract ZNodePaymentResponse SubmitPayment(PaymentSetting PaymentSetting, ZNodeOrder Order);
        public abstract ZNodePaymentResponse SubmitToPaymentGateway(PaymentSetting PaymentSetting, ZNodeOrder Order);
    }
}
