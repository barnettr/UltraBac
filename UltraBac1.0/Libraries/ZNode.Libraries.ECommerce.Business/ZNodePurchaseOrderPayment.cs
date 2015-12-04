using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Integrator;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents Purchase order payment type
    /// </summary>
    public class ZNodePurchaseOrderPayment: ZNodePaymentBase
    {
        #region Member Variables
        private ZNodeAddress _billingAddress = new ZNodeAddress();
        private ZNodeAddress _shippingAddress = new ZNodeAddress();
        private ECGatewayAction _gatewayAction = new ECGatewayAction();
        private ZNodeShoppingCart _shoppingcart = new ZNodeShoppingCart();
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
	        get { return _shoppingcart; }	        
	        set { _shoppingcart = value; }
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

        public override ZNodePaymentResponse SubmitToPaymentGateway(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            ZNodePaymentResponse PurchaseOrderPaymentResponse = new ZNodePaymentResponse();
            PurchaseOrderPaymentResponse.IsSuccess = true;
            PurchaseOrderPaymentResponse.TransactionId = null;

            //submit payment based on payment settings
            return PurchaseOrderPaymentResponse;
        }
        #endregion
    }
}
