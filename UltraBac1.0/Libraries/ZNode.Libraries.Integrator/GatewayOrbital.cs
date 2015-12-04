
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
using ZNode.Libraries.Integrator.net.paymentech.wsvar;

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Submit payment to Paymentech Orbital gateway
    /// </summary>
    public class GatewayOrbital
    {
        /// <summary>
        /// Submits credit card payment to a Paymenttech Orbital Gateway
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="BillingAddress"></param>
        /// <param name="ShippingAddress"></param>
        /// <param name="CreditCard"></param>
        /// <returns></returns>
        public GatewayResponse SubmitPayment(GatewayInfo Gateway, Address BillingAddress, Address ShippingAddress, CreditCardInfo CreditCard)
        {
            GatewayResponse PaymentGatewayResponse = new GatewayResponse();
            NewOrderResponseElement _authenticationResponse = new NewOrderResponseElement();
            StringBuilder build = new StringBuilder();

            try
            {

                PaymentechGateway _OrbitalGateway = new PaymentechGateway();
                if (Gateway.GatewayURL.Trim().Length == 0)
                {
                    // No URL was set, lets default this to a reasonable value.
                    if (Gateway.TestMode)
                    {
                        // Set to our Certification server.
                        _OrbitalGateway.Url = "https://wsvar.paymentech.net/PaymentechGateway";
                    }
                    else
                    {
                        // Set to the production server.
                        _OrbitalGateway.Url = "https://ws.paymentech.net/PaymentechGateway";
                    }

                    Gateway.GatewayURL = _OrbitalGateway.Url;
                }
                else
                {
                    _OrbitalGateway.Url = Gateway.GatewayURL;
                }

                //Create a request bean
                NewOrderRequestElement _authenticationBean = new NewOrderRequestElement();

                //General Settings
                _authenticationBean.industryType = "EC";
                _authenticationBean.transType = "AC";
                
                //Gateway Merchant Settings
                _authenticationBean.merchantID = Gateway.GatewayLoginID;
                _authenticationBean.bin = Gateway.GatewayPassword;
                _authenticationBean.terminalID = "001";

                //Invoice and  Credit card Information
                _authenticationBean.orderID = CreditCard.OrderID.ToString();
                _authenticationBean.ccAccountNum = CreditCard.CardNumber;
                string month = CreditCard.CreditCardExp.Substring(3) + CreditCard.CreditCardExp.Substring(0, 2);
                _authenticationBean.ccExp = month;
                _authenticationBean.ccCardVerifyNum = CreditCard.CardSecurityCode;

                //Customer Information.
                _authenticationBean.avsZip = BillingAddress.PostalCode;
                _authenticationBean.avsAddress1 = BillingAddress.Street1 + BillingAddress.Street2;
                _authenticationBean.avsCity = BillingAddress.City;
                _authenticationBean.avsState =BillingAddress.StateCode;
                _authenticationBean.avsName = BillingAddress.FirstName + BillingAddress.LastName;
                _authenticationBean.avsCountryCode = BillingAddress.CountryCode;
                _authenticationBean.avsPhone = BillingAddress.PhoneNumber;
                _authenticationBean.customerEmail = BillingAddress.EmailId;
                _authenticationBean.addProfileFromOrder = "A";
                
                //Retry Logic
                //retryTrace value should be unique.
                _authenticationBean.retryTrace = CreditCard.OrderID.ToString();

                // Amount Information
                _authenticationBean.amount = Convert.ToString(Math.Round((CreditCard.Amount * 100), 0));
                _authenticationBean.comments = "This is a test auth w/ avs information";


                // Response from transaction server.
                _authenticationResponse = _OrbitalGateway.NewOrder(_authenticationBean);
                
                //Get Approval status from server
                PaymentGatewayResponse.ResponseCode = _authenticationResponse.approvalStatus;

                //General Response from Payment Gateway
                PaymentGatewayResponse.AVSResponseCode = _authenticationResponse.avsRespCode;
                PaymentGatewayResponse.CCVResponsecode = _authenticationResponse.cvvRespCode;
                PaymentGatewayResponse.ReferenceNumber = _authenticationResponse.txRefNum;

                //Retry Logic Response.
                PaymentGatewayResponse.RetryTrace = _authenticationResponse.retryTrace;
                PaymentGatewayResponse.RetryAttemptCount = _authenticationResponse.retryAttempCount;
                PaymentGatewayResponse.LastRetryDate = _authenticationResponse.lastRetryDate;

                //if Transaction approved
                if (_authenticationResponse.approvalStatus == "1")
                {
                    PaymentGatewayResponse.IsSuccess = true;
                    PaymentGatewayResponse.TransactionId = _authenticationResponse.authorizationCode;
                    PaymentGatewayResponse.ResponseText += _authenticationResponse.procStatusMessage;
                }
                else
                {
                    //if transaction declined
                    build.Append("Response Code: " + _authenticationResponse.respCodeMessage + Environment.NewLine);

                    if (_authenticationResponse.procStatusMessage.Length > 0)
                    {
                        build.Append("Description:" + _authenticationResponse.procStatusMessage + Environment.NewLine);
                    }
                    if (_authenticationResponse.authorizationCode.Length > 0)
                    {
                        build.Append("Authorization Code: " + _authenticationResponse.authorizationCode);
                    }
                    PaymentGatewayResponse.ResponseText = build.ToString();
                }
            }
            catch (Exception SOAPException)
            {
                PaymentGatewayResponse.ResponseText = "Error Code: " + SOAPException.Message + Environment.NewLine + _authenticationResponse.respCodeMessage;
            }

            //Return Payment GatewayResponse
            return PaymentGatewayResponse;
        }
    }
}
