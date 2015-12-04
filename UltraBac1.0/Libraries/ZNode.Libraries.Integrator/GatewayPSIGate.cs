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
    /// Submit payment to PSIGate merchant gateway
    /// </summary>
    public class GatewayPSIGate
    {
        # region SubmitToPayment Methods
        /// <summary>
        /// Submits credit card payment to a Authorize.NET gateway
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="BillingAddress"></param>
        /// <param name="ShippingAddress"></param>
        /// <param name="CreditCard"></param>
        /// <returns>Gateway Response</returns>
        public GatewayResponse SubmitPayment(GatewayInfo Gateway, Address BillingAddress, Address ShippingAddress, CreditCardInfo CreditCard)
        {
            GatewayResponse PaymentGatewayResponse = new GatewayResponse();            

            //Get Xml data
            byte[] Data = Encoding.ASCII.GetBytes(CreateOrder(Gateway, CreditCard,BillingAddress)); 

            // Prepare web request.            
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(GetPostURL(Gateway.TestMode));
            myRequest.Method = "POST";
            myRequest.ContentLength = Data.Length;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.Accept = "application/xml; charset=UTF-8";
            myRequest.KeepAlive = false;

            // Send the data.
            using (Stream requestStream = myRequest.GetRequestStream())
            {
                requestStream.Write(Data, 0, Data.Length);
            }

            // Read the response.
            string responseXml = string.Empty;
            try
            {
                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    using (Stream ResponseStream = myResponse.GetResponseStream())
                    {
                        using (StreamReader ResponseStreamReader = new StreamReader(ResponseStream))
                        {
                            responseXml = ResponseStreamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException WebExcp)
            {
                if (WebExcp.Response != null)
                {
                    using (HttpWebResponse HttpWResponse = (HttpWebResponse)WebExcp.Response)
                    {
                        using (StreamReader sr = new StreamReader(HttpWResponse.GetResponseStream()))
                        {
                            responseXml = sr.ReadToEnd();
                        }
                    }
                }
            }

            StringReader textStream = new StringReader(responseXml);            
            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(textStream);
            
            // Read through the xml document
            while (reader.Read())
            {
                // check for starting node
                if(reader.IsStartElement() & reader.Name == "Result")
                {
                    while (reader.Read()) // Continue read
                    {
                        // Check if this is an element of name "item", continue reading
                        if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "OrderID")
                        {
                            // Get the content for each element
                            PaymentGatewayResponse.TransactionId = reader.ReadElementString("OrderID");
                            PaymentGatewayResponse.IsSuccess = true;

                            if (PaymentGatewayResponse.TransactionId.Length == 0)
                            {
                                PaymentGatewayResponse.IsSuccess = false;
                            }
                        }
                        else if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "Approved")
                        {
                            // Get the content for each element
                            PaymentGatewayResponse.ResponseText = reader.ReadElementString("Approved");
                        }
                        else if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "ReturnCode")
                        {
                            //
                            PaymentGatewayResponse.ResponseCode = reader.ReadElementString("ReturnCode");
                        }
                        else if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "ErrMsg")
                        {
                            //
                            PaymentGatewayResponse.ResponseText = PaymentGatewayResponse.ResponseText + " " + reader.ReadElementString("ErrMsg");
                        }
                        //if we've hit the item nodes closing tag we need to break
                        //out of the loop and write out the values
                        else if (reader.Name == "Result" & reader.NodeType == System.Xml.XmlNodeType.EndElement)
                        {
                            break;
                        }  
                    }                   
                    
                }
            }
            
            return PaymentGatewayResponse;
        }
        # endregion

        # region Helper Methods
        /// <summary>
        /// Returns the Gateway URL to post the input values
        /// Check for Testmode (Testing or Productoin) and returns the URL
        /// </summary>
        /// <param name="IsTestMode"></param>
        /// <returns></returns>
        private string GetPostURL(bool IsTestMode)
        {
            if (IsTestMode)
            {
                return "https://dev.psigate.com:7989/Messenger/XMLMessenger"; //Testing Server
            }

            return "https://secure.psigate.com:7934/Messenger/XMLMessenger"; //Production server
        }

        /// <summary>
        /// Prepares and returns the XML Input data in String format
        /// </summary>
        /// <param name="Gateway"></param>
        /// <param name="CardInfo"></param>
        /// <param name="BillingAddress"></param>
        /// <returns></returns>
        private string CreateOrder(GatewayInfo Gateway,CreditCardInfo CardInfo,Address BillingAddress)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<Order>");

            //Merchant Account details
            sb.Append("<StoreID>" + Gateway.GatewayLoginID + "</StoreID>");
	        sb.Append("<Passphrase>" + Gateway.GatewayPassword + "</Passphrase>");

            //Customer Billing Address porperties
            sb.Append("<Bname>" + BillingAddress.FirstName + "</Bname>");
            sb.Append("<Bcompany>" + BillingAddress.CompanyName + "</Bcompany>");
            sb.Append("<Baddress1>" + BillingAddress.Street1 + "</Baddress1>");
            sb.Append("<Baddress2>" + BillingAddress.Street2 + "</Baddress2>");
            sb.Append("<Bcity>" + BillingAddress.City + "</Bcity>");
            sb.Append("<Bprovince>" + BillingAddress.StateCode  + "</Bprovince>");
            sb.Append("<Bpostalcode>" + BillingAddress.PostalCode + "</Bpostalcode>");
            sb.Append("<Bcountry>" + BillingAddress.CountryCode + "</Bcountry>");
            sb.Append("<Phone>" + BillingAddress.PhoneNumber + "</Phone>");
            sb.Append("<Fax>" + BillingAddress.FaxNumber + "</Fax>");
            sb.Append("<Email>" + BillingAddress.EmailId + "</Email>");
            sb.Append("<Comments> </Comments>");

            //set Order properties
            sb.Append("<Tax1>" + CardInfo.TaxCost.ToString("N2") + "</Tax1>");
            sb.Append("<ShippingTotal>" + CardInfo.ShippingCharge.ToString("N2") + "</ShippingTotal>");
            sb.Append("<Subtotal>" + CardInfo.SubTotal.ToString("N2") + "</Subtotal>");

            //Payment type and card action 
            sb.Append("<PaymentType>CC</PaymentType>");
            sb.Append("<CardAction>0</CardAction>");

            //Set Credit Card properties
            sb.Append("<CardNumber>" + CardInfo.CardNumber + "</CardNumber>");
            string[] split = CardInfo.CreditCardExp.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            sb.Append("<CardExpMonth>" + split[0] + "</CardExpMonth>");
            sb.Append("<CardExpYear>" + split[1].Remove(1,2) + "</CardExpYear>");
            sb.Append("<CardIDNumber>" + CardInfo.CardSecurityCode + "</CardIDNumber>");
            sb.Append("</Order>");

            return sb.ToString();
        }
        # endregion
    }
}
