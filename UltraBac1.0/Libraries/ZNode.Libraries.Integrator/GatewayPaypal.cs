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
using com.paypal.sdk.services;
using com.paypal.soap.api;
using com.paypal.sdk.profiles;

namespace ZNode.Libraries.Integrator
{
    class GatewayPaypal
    {
        # region Protected Member Variables
        /// <summary>
        /// Read only Instance object for Call Services 
        /// </summary>
        private readonly CallerServices caller;

        # endregion

        # region Constructors
        public GatewayPaypal() { }
        public GatewayPaypal(GatewayInfo Gateway)
        {
            caller = new CallerServices();
            caller.APIProfile = CreateAPIProfile(Gateway.GatewayLoginID, Gateway.GatewayPassword, Gateway.TransactionKey,Gateway.TestMode);
        }
        # endregion

        # region private instance properties
        /// <summary>
        /// Initiate Merchant details for an API
        /// </summary>
        /// <param name="apiUsername"></param>
        /// <param name="apiPassword"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        private static IAPIProfile CreateAPIProfile(string apiUsername, string apiPassword, string signature,bool IsTestMode)
        {
            IAPIProfile profile = ProfileFactory.CreateAPIProfile();
            profile.APIUsername = apiUsername;
            profile.APIPassword = apiPassword;
            profile.APISignature = signature;
            profile.Subject = string.Empty;
            
            if(!IsTestMode)
            {
            	// Test mode is not enabled,then set Profile Environment as "live" - Production Server
                profile.Environment = "live";
            }
            
            
            return profile;
        }
        #endregion

        # region Public Methods
        /// <summary>
        /// Method initiate an Express Checkout transaction
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="CreditCard"></param>
        /// <returns>Returns GatewayResponse object</returns>
        public GatewayResponse SetExpressCheckout(GatewayInfo Gateway,CreditCardInfo CreditCard)
        {
            GatewayResponse _response = new GatewayResponse();

            // Create the request object
            SetExpressCheckoutRequestType pp_request = new SetExpressCheckoutRequestType();

            // Create the request details object
            pp_request.SetExpressCheckoutRequestDetails = new SetExpressCheckoutRequestDetailsType();
            pp_request.SetExpressCheckoutRequestDetails.PaymentAction = Gateway.PaypalPaymentActionCodeType;//PaymentActionCodeType.Order;
            pp_request.SetExpressCheckoutRequestDetails.PaymentActionSpecified = true;

            pp_request.SetExpressCheckoutRequestDetails.OrderTotal = new BasicAmountType();

            pp_request.SetExpressCheckoutRequestDetails.OrderTotal.currencyID = Gateway.PaypalCurrencyCodeType;//CurrencyCodeType.USD;
            pp_request.SetExpressCheckoutRequestDetails.OrderTotal.Value = CreditCard.Amount.ToString();

            pp_request.SetExpressCheckoutRequestDetails.CancelURL = Gateway.GatewayECCancelURL;
            pp_request.SetExpressCheckoutRequestDetails.ReturnURL = Gateway.GatewayECReturnURL;

            SetExpressCheckoutResponseType ECResponsetype = (SetExpressCheckoutResponseType)caller.Call("SetExpressCheckout", pp_request);

            if (ECResponsetype.Ack == AckCodeType.Success || ECResponsetype.Ack == AckCodeType.SuccessWithWarning)
            {
                _response.PaypalECtoken = ECResponsetype.Token;
                _response.IsSuccess = true;
            }
            else
            {
                _response.ResponseText = ECResponsetype.Errors[0].LongMessage;
                _response.ResponseCode = ECResponsetype.Errors[0].ErrorCode;
            }

            return _response;

        }

        /// <summary>
        /// Get information about an Express Checkout transaction
        /// </summary>
        /// <param name="Gateway"></param>
        /// <returns></returns>
        public GatewayResponse GetExpressCheckoutDetails(GatewayInfo Gateway)
        {
            // Create the request object
            GetExpressCheckoutDetailsRequestType pp_request = new GetExpressCheckoutDetailsRequestType();
            GatewayResponse _response = new GatewayResponse();

            string token = Gateway.GatewayECToken;
            pp_request.Token = token;

            GetExpressCheckoutDetailsResponseType ECDetailsResponse = (GetExpressCheckoutDetailsResponseType)caller.Call("GetExpressCheckoutDetails", pp_request);

            if (ECDetailsResponse.Ack == AckCodeType.SuccessWithWarning || ECDetailsResponse.Ack == AckCodeType.Success)
            {
                _response.PaypalPayerID = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID;

                //Set Shipping Address 
                Address _shippingAddress = new Address();
                _shippingAddress.City = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.CityName;
                _shippingAddress.FirstName = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Name;
                _shippingAddress.CountryCode = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Country.ToString();
                _shippingAddress.EmailId = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Payer;
                _shippingAddress.PhoneNumber = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.Phone;
                _shippingAddress.StateCode = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.StateOrProvince;
                _shippingAddress.PostalCode = ECDetailsResponse.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.PostalCode;

                _response.PayerAddress = _shippingAddress;
                _response.IsSuccess = true;
            }
            else
            {
                _response.ResponseText = ECDetailsResponse.Errors[0].LongMessage;
                _response.ResponseCode = ECDetailsResponse.Errors[0].ErrorCode;
            }

            return _response;
        }

        /// <summary>
        /// Complete an Express Checkout transaction
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="Creditcard"></param>
        /// <returns></returns>
        public GatewayResponse DoExpressCheckoutPayment(GatewayInfo Gateway,CreditCardInfo Creditcard)
        {
            // Create the request object
            DoExpressCheckoutPaymentRequestType pp_request = new DoExpressCheckoutPaymentRequestType();
            GatewayResponse _response = new GatewayResponse();

            // Create the request details object
            pp_request.DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType();
            pp_request.DoExpressCheckoutPaymentRequestDetails.Token = Gateway.GatewayECToken;
            pp_request.DoExpressCheckoutPaymentRequestDetails.PayerID = Gateway.PaypalPayerID;
            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentAction = Gateway.PaypalPaymentActionCodeType;//PaymentActionCodeType.Order;

            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails = new PaymentDetailsType();

            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails.OrderTotal = new BasicAmountType();

            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = Gateway.PaypalCurrencyCodeType; //CurrencyCodeType.USD;
            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails.OrderTotal.Value = Creditcard.Amount.ToString();

            // Create the response object
            DoExpressCheckoutPaymentResponseType ECPaymentResponse = (DoExpressCheckoutPaymentResponseType)caller.Call("DoExpressCheckoutPayment", pp_request);

            if (ECPaymentResponse.Ack == AckCodeType.Success || ECPaymentResponse.Ack == AckCodeType.SuccessWithWarning)
            {
                _response.ResponseText = ECPaymentResponse.Ack.ToString();
                _response.TransactionId = ECPaymentResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo.TransactionID;
                _response.IsSuccess = true;
            }
            else
            {
                _response.ResponseText = ECPaymentResponse.Errors[0].LongMessage;
                _response.ResponseCode = ECPaymentResponse.Errors[0].ErrorCode;
            }

            return _response;
        }

        /// <summary>
        /// Issue a refund for a PayPal transaction
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="Creditcard"></param>
        /// <returns></returns>
        public GatewayResponse RefundTransaction(GatewayInfo Gateway, CreditCardInfo Creditcard)
        {
            // Create the request object
            RefundTransactionRequestType concreteRequest = new RefundTransactionRequestType();
            GatewayResponse _gatewayResponse = new GatewayResponse();
            
            concreteRequest.TransactionID = Gateway.GatewayECToken;
            string refundType = RefundPurposeTypeCodeType.Full.ToString();

            switch (refundType)
            {
                case "Full":
                    concreteRequest.RefundType = RefundPurposeTypeCodeType.Full;
                    concreteRequest.RefundTypeSpecified = true;
                    break;
                case "Partial":
                    concreteRequest.RefundType = RefundPurposeTypeCodeType.Partial;
                    concreteRequest.RefundTypeSpecified = true;
                    concreteRequest.Amount = new BasicAmountType();

                    concreteRequest.Amount.currencyID = CurrencyCodeType.USD;
                    concreteRequest.Amount.Value = Creditcard.Amount.ToString();
                    break;
            }
            RefundTransactionResponseType _refundtransactionResponse = (RefundTransactionResponseType)caller.Call("RefundTransaction", concreteRequest);

            if(_refundtransactionResponse.Ack == AckCodeType.Success)
            {
                _gatewayResponse.ResponseText = _refundtransactionResponse.Ack.ToString();
                _gatewayResponse.IsSuccess = true;
            }
            else
            {
                _gatewayResponse.ResponseCode = _refundtransactionResponse.Errors[0].ErrorCode;
                _gatewayResponse.ResponseText = _refundtransactionResponse.Errors[0].LongMessage;
            }

            return _gatewayResponse;
        }

        # endregion
    }
}
