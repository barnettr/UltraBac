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
using System.IO;
using System.Net;


namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Submit payment to authorize.net
    /// </summary>
    public class GatewayAuthorize
    {
        /// <summary>
        /// Submits credit card payment to a Authorize.NET gateway
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="BillingAddress"></param>
        /// <param name="ShippingAddress"></param>
        /// <param name="CreditCard"></param>
        /// <returns>Gateway Response</returns>
        public GatewayResponse SubmitPayment(GatewayInfo Gateway, Address BillingAddress,Address ShippingAddress, CreditCardInfo CreditCard)
        {
            GatewayResponse PaymentGatewayResponse = new GatewayResponse();

            string AuthNetVersion = "3.1"; // Contains CCV support 
            string AuthNetLoginID = Gateway.GatewayLoginID;
            string AuthNetTransKey = Gateway.TransactionKey;
            WebClient objRequest = new WebClient();
            System.Collections.Specialized.NameValueCollection objInf = new System.Collections.Specialized.NameValueCollection(30);
            System.Collections.Specialized.NameValueCollection objRetInf = new System.Collections.Specialized.NameValueCollection(30);
            byte[] objRetBytes;
            string[] objRetVals;

            //Merchant account Information
            objInf.Add("x_login", AuthNetLoginID);
            objInf.Add("x_tran_key", AuthNetTransKey);
            objInf.Add("x_version", AuthNetVersion);

            //Gateway Response settings            
            objInf.Add("x_delim_data", "True");
            objInf.Add("x_relay_response", "False");
            objInf.Add("x_delim_char", ",");
            objInf.Add("x_encap_char", "|");
            objInf.Add("x_method", "CC"); //Payment method
            objInf.Add("x_type", "AUTH_CAPTURE"); //Transaction Type
            objInf.Add("x_currency_code", "USD");

            // Billing Address 
            objInf.Add("x_first_name", BillingAddress.FirstName);
            objInf.Add("x_last_name", BillingAddress.LastName);
            objInf.Add("x_address", BillingAddress.Street1 + " " + BillingAddress.Street2);
            objInf.Add("x_city", BillingAddress.City);
            objInf.Add("x_state", BillingAddress.StateCode);
            objInf.Add("x_zip", BillingAddress.PostalCode);
            objInf.Add("x_country", BillingAddress.CountryCode);
            objInf.Add("x_phone", BillingAddress.PhoneNumber);
            objInf.Add("x_email", BillingAddress.EmailId);
            
            // Invoice Information
            objInf.Add("x_description", "Description of Order");
            objInf.Add("x_invoice_num", CreditCard.OrderID.ToString());

            //Credit Card Details 
            objInf.Add("x_card_num", CreditCard.CardNumber);
            objInf.Add("x_exp_date", CreditCard.CreditCardExp);
            objInf.Add("x_card_code", CreditCard.CardSecurityCode); // Authorisation code of the card (CCV)                      
            objInf.Add("x_amount", CreditCard.Amount.ToString());
            

            try
            {
                //Check for Authorize.NET Test mode
                if (Gateway.TestMode)
                {
                    // Pure Test Server 
                    objInf.Add("x_test_request", "True");
                    objRequest.BaseAddress = "https://certification.authorize.net/gateway/transact.dll";
                }
                else
                {
                    objInf.Add("x_test_request", "False");
                    // Actual Server 
                    objRequest.BaseAddress = "https://secure.authorize.net/gateway/transact.dll";
                }

                //Post the values into Authorize.net Server
                objRetBytes = objRequest.UploadValues(objRequest.BaseAddress, "POST", objInf);
                objRetVals = System.Text.Encoding.ASCII.GetString(objRetBytes).Split(",".ToCharArray());

                //Transaction Approved if the Response code is 1
                if (objRetVals[0].Trim(char.Parse("|")) == "1")
                {
                    // the transaction was approved!
                    if (objRetVals[6].Trim(char.Parse("|")).Length > 0)
                    {
                        PaymentGatewayResponse.TransactionId = objRetVals[6].Trim(char.Parse("|"));
                        PaymentGatewayResponse.IsSuccess = true;
                    }
                }
                else
                {
                    PaymentGatewayResponse.IsSuccess = false;
                }

                //Set Response code and Response Text
                PaymentGatewayResponse.ResponseCode = "Response Code: " + objRetVals[0].Trim(char.Parse("|")) +"<br>";
                PaymentGatewayResponse.ResponseText = "Response Reason Code :" + objRetVals[2].Trim(char.Parse("|")) + " <br> Description: " + objRetVals[3].Trim(char.Parse("|"));
                PaymentGatewayResponse.ReferenceNumber = "MD5 Hash value :" + objRetVals[37].Trim(char.Parse("|")); 
            }
            catch (Exception)
            {
                PaymentGatewayResponse.IsSuccess = false;
            }

            //Return Payment GatewayResponse
            return PaymentGatewayResponse;
        }
    }
}
