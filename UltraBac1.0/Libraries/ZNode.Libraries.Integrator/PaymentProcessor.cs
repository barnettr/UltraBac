//Please do not remove this notice!

//Znode E-Commerce Integrator - A General Purpose E-Commerce Library
//Copyright (C) 2007, Znode Inc. All Rights Reserved
//Author's URL: www.znode.com
//Email: support@znode.com

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Submits payment to the target gateway.
    /// </summary>    
    public class PaymentProcessor
    {                 
        #region Protected Member Variables
        private GatewayInfo _gateway = new GatewayInfo();
        private Address _billingAddress = new Address();
        private Address _shippingAddress = new Address();
        private CreditCardInfo _creditCardInfo = new CreditCardInfo();
        private ShoppingCartItem _cartItems = new ShoppingCartItem();
        private TaxRuleCollection _defaultTaxRule = new TaxRuleCollection();
        # endregion
        
        #region Public Properties
        /// <summary>
        /// Sets or retrieves the GatewayInfo type object.
        /// </summary>
        public GatewayInfo Gateway
        {
            get { return _gateway; }
            set { _gateway = value; }
        }

        /// <summary>
        /// Gets or sets the Billing Address object.
        /// </summary>
        public Address BillingAddress
        {
            get { return _billingAddress; }
            set { _billingAddress = value; }
        }

        /// <summary>
        /// Sets or retrieves the Shipping Address object.
        /// </summary>
        public Address ShippingAddress
        {
            get { return _shippingAddress; }
            set { _shippingAddress = value; }
        }

        /// <summary>
        /// Sets or retrieves the Creditcardinfo object
        /// </summary>
        public CreditCardInfo CreditCard
        {
            get { return _creditCardInfo; }
            set { _creditCardInfo = value; }
        }

        /// <summary>
        /// Sets or retrieves the Creditcardinfo object
        /// </summary>
        public ShoppingCartItem ShoppingCartItems
        {
            get { return _cartItems; }
            set { _cartItems = value; }
        }

        /// <summary>
        /// Sets or retrieves the Default tax rules object
        /// </summary>
        public TaxRuleCollection TaxRules
        {
            get { return _defaultTaxRule; }
            set { _defaultTaxRule = value; }
        }

        # endregion

        # region Public Methods
        
        /// <summary>
        /// Submits credit card payment to a selected gateway.        
        /// </summary>
        /// <returns> Submits the payment to a selected gateway and returns the response.</returns>
        public GatewayResponse SubmitCreditCardPayment()
        {
            GatewayResponse resp = new GatewayResponse();

            //Check Selected GatewayType 
            switch (Gateway.gateway)
            {
                case GatewayType.CUSTOM:// If Custom gateway is selected

                        CustomGateway _submitToGateway = new CustomGateway();
                        resp = _submitToGateway.SubmitPayment(Gateway, BillingAddress, ShippingAddress, CreditCard);
                        break;

                case GatewayType.AUTHORIZE: //if Authorize.Net

                        GatewayAuthorize _SubmitToAuthorizeNet = new GatewayAuthorize();
                        resp = _SubmitToAuthorizeNet.SubmitPayment(Gateway, BillingAddress, ShippingAddress, CreditCard);
                        break;

                case GatewayType.GOOGLE: //if google gateway
                        if (Gateway.ECGatewayAction == ECGatewayAction.SetExpressCheckoutResponse)
                        {
                            GatewayGoogle _SubmitToGoogle = new GatewayGoogle();
                            resp = _SubmitToGoogle.SendRequestToGoogle(Gateway,CreditCard, ShoppingCartItems,TaxRules);
                        }
                        else if (Gateway.ECGatewayAction == ECGatewayAction.DoExpressCheckoutPaymentResponse)
                        {
                            GatewayGoogle _SubmitToGoogle = new GatewayGoogle();
                            resp = _SubmitToGoogle.DoGoogleECPayment(CreditCard, Gateway);
                        }
                        
                        break;

                case GatewayType.PAYMENTECH:// if Payment tech orbital gateway

                        GatewayOrbital _SubmitToPaymentechOrbital = new GatewayOrbital();
                        resp = _SubmitToPaymentechOrbital.SubmitPayment(Gateway, BillingAddress, ShippingAddress, CreditCard);
                        break;

                case GatewayType.PAYPAL: // If Paypal gateway

                        //If PaypalGatewayAction is SetExpressCheckoutResponse
                        if (Gateway.ECGatewayAction == ECGatewayAction.SetExpressCheckoutResponse)
                        {
                            GatewayPaypal _SubmitToPayPal = new GatewayPaypal(Gateway);

                            resp = _SubmitToPayPal.SetExpressCheckout(Gateway, CreditCard);

                        }
                        //If PaypalGatewayAction is GetExpressCheckoutDetailsResponse
                        else if (Gateway.ECGatewayAction == ECGatewayAction.GetExpressCheckoutDetailsResponse)
                        {
                            GatewayPaypal _SubmitToPayPal = new GatewayPaypal(Gateway);
                            resp = _SubmitToPayPal.GetExpressCheckoutDetails(Gateway);
                        }
                        //PaypalGatewayAction is DoExpressCheckoutPaymentResponse
                        else if (Gateway.ECGatewayAction == ECGatewayAction.DoExpressCheckoutPaymentResponse)
                        {
                            GatewayPaypal _SubmitToPayPal = new GatewayPaypal(Gateway);
                            resp = _SubmitToPayPal.DoExpressCheckoutPayment(Gateway, CreditCard);
                        }
                        break;

                case GatewayType.VERISIGN_EC:
                        GatewayPayFlowPro _submitToPayflowProEC = new GatewayPayFlowPro();                        
                        resp = _submitToPayflowProEC.GetECTransactionToken(BillingAddress, ShippingAddress, Gateway, CreditCard);
                        break;

                case GatewayType.VERISIGN:
                        GatewayPayFlowPro _submitToPayflowPro = new GatewayPayFlowPro();
                        resp = _submitToPayflowPro.SubmitPayment(BillingAddress, ShippingAddress, Gateway, CreditCard);
                        break;

                case GatewayType.PSIGate:
                        GatewayPSIGate _submitToPSI = new GatewayPSIGate();
                        resp = _submitToPSI.SubmitPayment(Gateway, BillingAddress, ShippingAddress, CreditCard);                        
                        break;
                        
                case GatewayType.NOVA:
                        GatewayNova _submitToNova = new GatewayNova();
                        resp = _submitToNova.SubmitPayment(Gateway, BillingAddress, ShippingAddress, CreditCard);
                        break;

                case GatewayType.nSoftware:
                        GatwewaynSoftware _submitToNSoftware = new GatwewaynSoftware();
                        resp = _submitToNSoftware.SubmitPayment(Gateway, BillingAddress, ShippingAddress, CreditCard);
                        break;

                default:
                        
                        resp.ResponseCode = "Error :";
                        resp.ResponseText = "Unsupported gateway is selected. Please select some other gateway option to process your payment.";
                        break;
            }
           
            return resp;
        }
        #endregion        
    }
}
