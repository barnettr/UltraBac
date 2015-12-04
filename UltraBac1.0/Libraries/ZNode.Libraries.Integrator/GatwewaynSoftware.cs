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
// Requires the nSoftware component from http://nsoftware.com/ibiz/epayment/default.aspx
// See comment below.
// using nsoftware.IBizPay;

namespace ZNode.Libraries.Integrator
{
    class GatwewaynSoftware
    {
        /// <summary>
        /// Submits credit card payment to nSoftware Component
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="BillingAddress"></param>
        /// <param name="ShippingAddress"></param>
        /// <param name="CreditCard"></param>
        /// <returns>Gateway Response</returns>
        public GatewayResponse SubmitPayment(GatewayInfo Gateway, Address BillingAddress, Address ShippingAddress, CreditCardInfo _creditCardInfo)
        {
            GatewayResponse PaymentResponse = new GatewayResponse();

            // 
            // This function requires a license to the nSoftware iBiz E-Payment Integrator 
            // (http://nsoftware.com/ibiz/epayment/default.aspx). Once you have purchased a 
            // license for the nSoftware component add a reference to it in your porject and 
            // uncomment the code below as well as the "using" statement at the top of this file.
            //

            // Comment these lines if you have an nSoftware license
            PaymentResponse.ResponseCode = "-1";
            PaymentResponse.ResponseText = "nSoftware Component not installed.";

            // --- nSoftware Code Begin ---
            //Icharge icharge = new nsoftware.IBizPay.Icharge();
            ////Example: icharge.Gateway = (IchargeGateways)Enum.Parse(typeof(IchargeGateways),IchargeGateways.gwAuthorizeNet.ToString());
            //icharge.Gateway = (IchargeGateways)Enum.Parse(typeof(IchargeGateways), <PUT THE nSoftware GATEWAY TYPE ID HERE>);
            


            //// ExpiredDate should be separated into month and year.             
            //string[] split = _creditCardInfo.CreditCardExp.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            //icharge.CardExpMonth = split[0];
            //icharge.CardExpYear = split[1];
            //icharge.CardNumber = _creditCardInfo.CardNumber;

            //icharge.CustomerAddress = BillingAddress.Street1;
            //icharge.CustomerCity = BillingAddress.City;
            //icharge.CustomerCountry = BillingAddress.CountryCode;
            //icharge.CustomerEmail = BillingAddress.EmailId;
            //icharge.CustomerFirstName = BillingAddress.FirstName;
            //icharge.CustomerLastName = BillingAddress.LastName;
            //icharge.CustomerPhone = BillingAddress.PhoneNumber;
            //icharge.CustomerState = BillingAddress.StateCode;
            //icharge.CustomerZip = BillingAddress.PostalCode;

            //icharge.InvoiceNumber = _creditCardInfo.OrderID.ToString();
            //icharge.TransactionAmount = _creditCardInfo.Amount.ToString();
            //icharge.TransactionDesc = "";

            //icharge.MerchantLogin = Gateway.GatewayLoginID;

            //if (icharge.Gateway == IchargeGateways.gwAuthorizeNet)
            //{
            //    if (Gateway.TestMode)
            //    {
            //        icharge.AddSpecialField("x_test_request", "true");
            //    }

            //    icharge.AddSpecialField("x_tran_key", Gateway.TransactionKey);
            //}
            //else
            //{
            //    icharge.MerchantPassword = Gateway.GatewayPassword;
            //}

            //try
            //{
            //    icharge.Authorize(); // DO AUTHORIZATION
            //}
            //catch (Exception ex)
            //{

            //    PaymentResponse.ResponseCode = "-1";
            //    PaymentResponse.ResponseText = "We are unable to process this transaction because of a System Error.";
            //}

            //if (icharge.TransactionApproved)
            //{
            //    // the transaction was approved!
            //    if (icharge.TransactionId.Length > 0)
            //    {
            //        PaymentResponse.TransactionId = icharge.TransactionId.ToString();
            //    }

            //    PaymentResponse.IsSuccess = true;
            //    return PaymentResponse;
            //}
            //else
            //{
            //    PaymentResponse.ResponseCode = icharge.ResponseCode;
            //    PaymentResponse.ResponseText = icharge.ResponseText;
            //}
            // --- nSoftware Code End ---

            return PaymentResponse;
        }
    }
}
