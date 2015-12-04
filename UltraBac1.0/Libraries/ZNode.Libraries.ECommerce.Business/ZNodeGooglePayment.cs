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
    public class ZNodeGooglePayment : ZNodePaymentBase
    {
        #region Member Variables
        private ZNodeAddress _billingAddress = new ZNodeAddress();
        private ZNodeAddress _shippingAddress = new ZNodeAddress();
        private ECGatewayAction _gatewayAction = new ECGatewayAction();
        private ZNodeShoppingCart _shoppingCart = new ZNodeShoppingCart();
        #endregion

        #region Properties
        /// <summary>
        /// Overrides base Billing Address
        /// Retireves or sets Billing adddress
        /// </summary>
        public override ZNodeAddress BillingAddress
        {
            get { return _billingAddress; }
            set { _billingAddress = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override ZNodeAddress ShippingAddress
        {
            get { return _shippingAddress; }
            set { _shippingAddress = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override ECGatewayAction GatewayAction
        {
            get { return _gatewayAction; }
            set { _gatewayAction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ZNodeShoppingCart CurrentShoppingCart
        {
            set { _shoppingCart = value; }
            get { return _shoppingCart; }
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
            _processor.TransactionDesc = "Google Express Checkout payment";
            _processor.InvoiceNumber = Order.OrderID.ToString();
            _processor.ShippingCharge = CurrentShoppingCart.ShippingDiscount;
            _processor.TaxCost = Order.TaxCost;

            //Paypal - General Settings
            _processor.GatewayAction = _gatewayAction;
            _processor.PaypalToken = PaypalToken;
            _processor.PayPalPayerID = PayPalPayerID;

            if (_gatewayAction == ECGatewayAction.SetExpressCheckoutResponse)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(";");                
                sb.Append(Order.OrderID.ToString() + ";");

                //Set merchant Private data Items - OrderID
                _processor.MerchantPrivateData = sb.ToString();

                _processor.CurrentShoppingCart = CurrentShoppingCart;
            }            

            //Gateway Settings
            ZNodeEncryption decrypt = new ZNodeEncryption();            
            _processor.Gateway = ZNode.Libraries.Integrator.GatewayType.GOOGLE.ToString(); // Google Payment
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

            //return Payment Gateway Response
            return PaypalPaymentResponse;
        }
        #endregion
    }
}
