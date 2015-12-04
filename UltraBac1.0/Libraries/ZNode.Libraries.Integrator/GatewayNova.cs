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
using System.Web;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Web.Services;

namespace ZNode.Libraries.Integrator
{
    
    /// <summary>
    /// Submit payment to Nova gateway
    /// </summary>    
    public class GatewayNova
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="BillingAddress"></param>
        /// <param name="ShippingAddress"></param>
        /// <param name="CreditCard"></param>
        /// <returns></returns>
        public GatewayResponse SubmitPayment(GatewayInfo Gateway, Address BillingAddress, Address ShippingAddress, CreditCardInfo CreditCard)
        {
            GatewayResponse PaymentGatewayResponse = new GatewayResponse();
            string _postURL = string.Empty;
            string EGCvalue = string.Empty;

            #region Input data in Xml
            //Gateway Details
            EGCvalue += "<txn>";
            EGCvalue += "<ssl_merchant_ID>" + Gateway.GatewayLoginID + "</ssl_merchant_ID>";
            EGCvalue += "<ssl_user_id>" + Gateway.GatewayPassword + "</ssl_user_id>";
            EGCvalue += "<ssl_pin>" + Gateway.TransactionKey + "</ssl_pin>";
            EGCvalue += "<ssl_transaction_type>" + Gateway.TransactionType  + "</ssl_transaction_type>";
            EGCvalue += "<ssl_egc_tender_type>" + Gateway.TenderType + "</ssl_egc_tender_type>";
            //Card Details 
            EGCvalue += "<ssl_card_number>" + CreditCard.CardNumber  + "</ssl_card_number>";
            // ExpiredDate should follow the following data format "0107" (which represents Jan,2007)
            string CardExpireDate = CreditCard.CreditCardExp.Remove(2, 3);
            EGCvalue += "<ssl_exp_date>" + CardExpireDate + "</ssl_exp_date>";
            EGCvalue += "<ssl_amount>" + CreditCard.Amount + "</ssl_amount>";
            EGCvalue += "<ssl_invoice_number>" + CreditCard.OrderID + "</ssl_invoice_number>";
            //Customer BillingDetails
            EGCvalue += "<ssl_company>" + BillingAddress.CompanyName + "</ssl_company>";
            EGCvalue += "<ssl_first_name>" + BillingAddress.FirstName + "</ssl_first_name>";
            EGCvalue += "<ssl_last_name>" + BillingAddress.LastName + "</ssl_last_name>";
            EGCvalue += "<ssl_avs_address>" + BillingAddress.Street1 + "</ssl_avs_address>";
            EGCvalue += "<ssl_address2>" + BillingAddress.Street2 + "</ssl_address2>";
            EGCvalue += "<ssl_city>" + BillingAddress.City + "</ssl_city>";
            EGCvalue += "<ssl_state>" + BillingAddress.StateCode + "</ssl_state>";
            EGCvalue += "<ssl_avs_zip>" + BillingAddress.PostalCode + "</ssl_avs_zip>";
            EGCvalue += "<ssl_phone>" + BillingAddress.PhoneNumber + "</ssl_phone>";
            EGCvalue += "<ssl_email>" + BillingAddress.EmailId + "</ssl_email>";
            //Customer ShippingDetails
            EGCvalue += "<ssl_ship_to_company>" + ShippingAddress.CompanyName + "</ssl_ship_to_company>";
            EGCvalue += "<ssl_ship_to_first_name>" + ShippingAddress.FirstName + "</ssl_ship_to_first_name>";
            EGCvalue += "<ssl_ship_to_last_name>" + ShippingAddress.LastName + "</ssl_ship_to_last_name>";
            EGCvalue += "<ssl_ship_to_avs_address>" + ShippingAddress.Street1 + "</ssl_ship_to_avs_address>";
            EGCvalue += "<ssl_ship_to_address2>" + ShippingAddress.Street2 + "</ssl_ship_to_address2>";
            EGCvalue += "<ssl_ship_to_city>" + ShippingAddress.City + "</ssl_ship_to_city>";
            EGCvalue += "<ssl_ship_to_state>" + ShippingAddress.StateCode + "</ssl_ship_to_state>";
            EGCvalue += "<ssl_ship_to_avs_zip>" + ShippingAddress.PostalCode + "</ssl_ship_to_avs_zip>";
            EGCvalue += "<ssl_ship_to_phone>" + ShippingAddress.PhoneNumber + "</ssl_ship_to_phone>";          
            EGCvalue += "</txn>";

            #endregion

            // To Check Test Mode.
            if (Gateway.TestMode)
            {
                _postURL = "https://www.myvirtualmerchant.com/VirtualMerchantDemo/processxml.do?xmldata=";
            }
            else
            {
                _postURL = "https://www.myvirtualmerchant.com/VirtualMerchant/processxml.do?xmldata=";
            }

            try
            {
                //Post the values into  Web Service   
                WebClient WebRequest = new WebClient();
                WebRequest.Headers.Add("Content-Type", "application/xml; charset=UTF-8");
                string objRespValues = WebRequest.UploadString(_postURL + EGCvalue, "POST", "");

                #region Read XML Data
                // Read the Xml data.              
                StringReader StreamInput = new StringReader(objRespValues);
                XmlTextReader xmlReader = new XmlTextReader(StreamInput);

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.LocalName == "txn")
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.LocalName == "ssl_result")
                            {
                                PaymentGatewayResponse.ResponseCode = xmlReader.ReadElementString("ssl_result");
                                PaymentGatewayResponse.ResponseText = xmlReader.ReadElementString("ssl_result_message");
                                PaymentGatewayResponse.TransactionId = xmlReader.ReadElementString("ssl_txn_id");
                                PaymentGatewayResponse.ApprovalCode = xmlReader.ReadElementString("ssl_approval_code");
                            }
                            else if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.LocalName == "errorCode")
                            {
                                PaymentGatewayResponse.ResponseCode = xmlReader.ReadElementString("errorCode");
                                PaymentGatewayResponse.ResponseText += xmlReader.ReadElementString("errorName") + ". ";
                                PaymentGatewayResponse.ResponseText += xmlReader.ReadElementString("errorMessage");
                            }
                        }
                    }
                }
                #endregion

                if (PaymentGatewayResponse.ResponseCode == "0")
                {
                    PaymentGatewayResponse.IsSuccess = true;
                }
                else
                {
                    PaymentGatewayResponse.IsSuccess = false;
                }

                return PaymentGatewayResponse;
            }
            catch (Exception Ex)
            {                
                PaymentGatewayResponse.ResponseText = Ex.Message.ToString(); //Response Error code Description               
                return PaymentGatewayResponse;
            }
        }        
    }
}

