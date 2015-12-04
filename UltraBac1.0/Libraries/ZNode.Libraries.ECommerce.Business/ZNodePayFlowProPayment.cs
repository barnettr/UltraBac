using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Integrator;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class ZNodePayFlowProPayment : ZNodePaymentBase
    {
        #region Member Variables
        private ZNodeAddress _billingAddress = new ZNodeAddress();
        private ZNodeAddress _shippingAddress = new ZNodeAddress();
        private ECGatewayAction _gatewayAction = new ECGatewayAction();
        private ZNodeShoppingCart _shoppingCart = new ZNodeShoppingCart();
        #endregion

        #region Properties
        public override ZNodeAddress BillingAddress
        {
            get { return _billingAddress; }
            set { _billingAddress = value; }
        }
        public override ZNodeAddress ShippingAddress
        {
            get { return _shippingAddress; }
            set { _shippingAddress = value; }
        }
        public override ECGatewayAction GatewayAction
        {
            get { return _gatewayAction; }
            set { _gatewayAction = value; }
        }
        public override ZNodeShoppingCart CurrentShoppingCart
        {
            get
            {
                return _shoppingCart;
            }
            set
            {
                _shoppingCart = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Submit payment based on payment settings
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public override ZNodePaymentResponse SubmitPayment(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            //submit payment based on payment settings

            return new ZNodePaymentResponse();
        }

        /// <summary>
        /// Submit payment to payment processor
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public override ZNodePaymentResponse SubmitToPaymentGateway(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            //submit payment based on payment settings
            ZNodePaymentResponse PaypalPaymentResponse = new ZNodePaymentResponse();
            ZNodePaymentProcessor _processor = new ZNodePaymentProcessor();

            //Order Details
            _processor.TransactionAmount = Order.Total.ToString("N2");
            _processor.TransactionDesc = "Paypal Express Checkout payment";
            _processor.InvoiceNumber = Order.OrderID.ToString();

            //Paypal - General Settings
            _processor.GatewayAction = _gatewayAction;
            _processor.PaypalToken = PaypalToken;
            _processor.PayPalPayerID = PayPalPayerID;

            //Gateway Settings
            ZNodeEncryption decrypt = new ZNodeEncryption();
            _processor.Gateway = "5";
            _processor.MerchantLogin = decrypt.DecryptData(PaymentSetting.GatewayUsername);
            _processor.MerchantPassword = decrypt.DecryptData(PaymentSetting.GatewayPassword);
            _processor.TransactionKey = PaymentSetting.TransactionKey;
            _processor.PaypalCancelURL = PaypalCancelURL;
            _processor.PaypalReturnURL = PaypalReturnURL;

            //Set Test Mode - Not supported for all gateways
            _processor.IsTestMode = PaymentSetting.TestMode;

            //Customer Address from Account
            _processor.BillingAddress = Order.BillingAddress;
            _processor.ShippingAddress = Order.ShippingAddress;

            //Submit Payment to Gateway
            PaypalPaymentResponse = _processor.SubmitToPaymentGateway();

            return PaypalPaymentResponse;
        }
         #endregion
    }
}
