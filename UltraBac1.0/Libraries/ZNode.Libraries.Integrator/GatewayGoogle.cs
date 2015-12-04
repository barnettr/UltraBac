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
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
namespace ZNode.Libraries.Integrator
{
    # region GatewayEnvironment Enum Object
    /// <summary>
    /// Determine where the messages are posted (Sandbox, Production)
    /// </summary>
    public enum EnvironmentType
    {
        /// <summary>Use the Sandbox account to post the messages</summary>
        Sandbox = 0,
        /// <summary>Use the Production account to post the messages</summary>
        Production = 1,
        /// <summary>Unknown account.</summary>
        Unknown = 2
    }
    # endregion

    /// <summary>
    /// Class used to create the structure needed by Google Checkout
    /// </summary>
    public class GatewayGoogle
    {
        # region Protected Member Variables
        /// <summary>EnvironmentType used to determine where the messages are posted (Sandbox, Production)</summary>
        protected EnvironmentType _Environment = EnvironmentType.Unknown;
        #endregion

        # region Public Contructors
        public GatewayGoogle() {  }
        #endregion

        # region SendRequestToGoogle Method
        /// <summary>
        /// Send the Message to Google Checkout
        /// </summary>
        /// <returns></returns>
        public GatewayResponse SendRequestToGoogle(GatewayInfo _gatewayInfo, CreditCardInfo Info,ShoppingCartItem _cartItems,TaxRuleCollection Rule)
        {
            # region Local Variables
            GatewayResponse _response = new GatewayResponse();
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            Google.CheckoutShoppingCart MyCart = new Google.CheckoutShoppingCart();
            #endregion

            # region Adding Shopping cart Items to the request
            //Initialize Shopping cart object
            MyCart.shoppingcart = new Google.ShoppingCart();

            // Add the items in the shopping cart to the API request.
            MyCart.shoppingcart.items = new Google.Item[_cartItems.Count];                        
            
            //Loop through the shopping cart item
            for (int i = 0; i < _cartItems.Count; i++)
            {
                ShoppingCartItem  MyItem = (ShoppingCartItem)_cartItems.GetItem(i);
                MyCart.shoppingcart.items[i] = new Google.Item();
                                
                MyCart.shoppingcart.items[i].itemname = this.EscapeXmlChars(MyItem.itemname);
                MyCart.shoppingcart.items[i].itemdescription = this.EscapeXmlChars(MyItem.itemdescription);
                MyCart.shoppingcart.items[i].quantity = MyItem.quantity;
                MyCart.shoppingcart.items[i].unitprice = new Google.Money();
                MyCart.shoppingcart.items[i].unitprice.currency = "USD";
                MyCart.shoppingcart.items[i].unitprice.Value = MyItem.unitprice;

                # region Merchant Private Item Data Settings
                //If product has merchant Private data
                //then it is added to the request
                if (MyItem.ItemPrivateData != null)
                {
                    System.Xml.XmlElement element = doc.CreateElement("merchant-private-item-data");
                    MyCart.shoppingcart.items[i].merchantprivateitemdata = element;

                    foreach (XmlNode node in MyItem.ItemPrivateData)
                    {   
                        System.Xml.XmlNode childNode = doc.CreateNode(System.Xml.XmlNodeType.Element,node.Name,"");
                        childNode.InnerText = node.InnerText;

                        element.AppendChild(childNode);                        
                    }
                }
                #endregion
            }            
            #endregion

            # region Merchant Private Settings

            XmlElement xmlelem = doc.CreateElement("", "merchant-private-data", "");

            // Add a "shopper-id" node.            
            System.Xml.XmlNode tempNode1 = doc.CreateElement("shopper-id");
            tempNode1.InnerText = "";

            xmlelem.AppendChild(tempNode1);

            // Add a "cart-id" node.
            System.Xml.XmlNode tempNode2 = doc.CreateElement("cart-id");
            tempNode2.InnerText = "";

            xmlelem.AppendChild(tempNode2);

            //merchant Notes
            System.Xml.XmlNode tempNode3 = doc.CreateElement("merchant-note");
            tempNode3.InnerText = _gatewayInfo.MerchantPrivateData;

            xmlelem.AppendChild(tempNode3);

            MyCart.shoppingcart.merchantprivatedata = xmlelem;

            #endregion

            # region General Settings
            //Check for Test mode 
            if (_gatewayInfo.TestMode)
            {
                _Environment = EnvironmentType.Sandbox; // Testing Server
            }
            else
            {
                _Environment = EnvironmentType.Production;//Production Server
            }

            // Add the &lt;continue-shopping-url&gt; element to the API request.
            MyCart.checkoutflowsupport = new Google.CheckoutShoppingCartCheckoutflowsupport();

            Google.MerchantCheckoutFlowSupport support = new Google.MerchantCheckoutFlowSupport();
            support.continueshoppingurl = _gatewayInfo.GatewayECReturnURL; //Return URL  
            support.editcarturl = _gatewayInfo.GatewayECCancelURL; //Cancel URL or Edit Cart URL
            #endregion

            # region Shipping Settings
            //Shipping Methods            
            Google.MerchantCalculations Calculations = new Google.MerchantCalculations();
            Google.MerchantCheckoutFlowSupportShippingmethods Shippingmethods = new Google.MerchantCheckoutFlowSupportShippingmethods();

            //Shipping Settings
            Google.Pickup pickUp = new Google.Pickup();
            pickUp.price = new Google.Money();
            //pickUp.price = new Google.PickupPrice();
            pickUp.price.currency = "USD"; //Currently Google Checkout only supports US currency
            pickUp.name = "Selected Shipping Option";
            pickUp.price.Value = Info.ShippingCharge;
            
            //Add Shipping Methods
            Shippingmethods.Items = new object[] { pickUp };
            support.shippingmethods = Shippingmethods;
            #endregion

            # region Tax Cost Settings
            //Tax Rules and Tax settings
            Google.DefaultTaxTable taxTable = new Google.DefaultTaxTable();

            //Add Tax Settings            
            Google.DefaultTaxRule[] TaxRules = new Google.DefaultTaxRule[Rule.GetItemsCount()];
            
            //Loop through the Default Rule items
            for (int i = 0; i < Rule.GetItemsCount(); i++)
            {
                TaxRules[i] = Rule.GetByIndex(i);
            }
            
            taxTable.taxrules = TaxRules;
            
            support.taxtables = new Google.TaxTables();
            support.taxtables.defaulttaxtable = taxTable;
            #endregion
            
            //Add checkout flow support type
            MyCart.checkoutflowsupport.Item = support;
            
            //Get Xml data
            byte[] Data = EncodeHelper.Serialize(MyCart);

            # region Send Request to Google Server
            // Prepare web request.
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(GetPostUrl(_gatewayInfo.GatewayLoginID));
            myRequest.Method = "POST";
            myRequest.ContentLength = Data.Length;
            myRequest.Headers.Add("Authorization",string.Format("Basic {0}",
            GetAuthorization(_gatewayInfo.GatewayLoginID,_gatewayInfo.GatewayPassword)));
            myRequest.ContentType = "application/xml; charset=UTF-8";
            myRequest.Accept = "application/xml; charset=UTF-8";
            myRequest.KeepAlive = false;

            // Send the data.
            using (Stream requestStream = myRequest.GetRequestStream())
            {
                requestStream.Write(Data, 0, Data.Length);
            }
            # endregion

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
                    using (HttpWebResponse HttpWResponse =
                      (HttpWebResponse)WebExcp.Response)
                    {
                        using (StreamReader sr =
                          new StreamReader(HttpWResponse.GetResponseStream()))
                        {
                            responseXml = sr.ReadToEnd();
                        }
                    }
                }
            }


            //Parse the output string and return the response code & text
            return ParseXML(responseXml);

        }
        #endregion

        # region DoPaymentToGoogle methods
        /// <summary>        
        /// methods that construct charge-order (Do payment) API requests.
        /// </summary>
        /// <returns></returns>
        public GatewayResponse DoGoogleECPayment(CreditCardInfo OrderInfo,GatewayInfo MerhcantInfo)
        {
            GatewayResponse Response = new GatewayResponse();

            Google.ChargeOrderRequest Req = new Google.ChargeOrderRequest();

            if (MerhcantInfo.TestMode)
            {
                _Environment = EnvironmentType.Sandbox;
            }
            else
            {
                _Environment = EnvironmentType.Production;
            }

            Req.amount = new Google.Money();
            Req.amount.currency = "USD";
            Req.amount.Value = OrderInfo.Amount;
            //The Google Order Number -We need to retieve this from Google Notification API
            Req.googleordernumber = MerhcantInfo.GoogleOrderNumber;

            //Get Xml data
            byte[] Data = EncodeHelper.Serialize(Req);

            // Prepare web request.
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(GetPostUrl(MerhcantInfo.GatewayLoginID));
            myRequest.Method = "POST";
            myRequest.ContentLength = Data.Length;
            myRequest.Headers.Add("Authorization", string.Format("Basic {0}",
            GetAuthorization(MerhcantInfo.GatewayLoginID, MerhcantInfo.GatewayPassword)));
            myRequest.ContentType = "application/xml; charset=UTF-8";
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
                    using (HttpWebResponse HttpWResponse =
                      (HttpWebResponse)WebExcp.Response)
                    {
                        using (StreamReader sr =
                          new StreamReader(HttpWResponse.GetResponseStream()))
                        {
                            responseXml = sr.ReadToEnd();
                        }
                    }
                }
            }

            return ParseXML(responseXml);
        }
        #endregion

        # region Helper Methods
        private System.Xml.XmlDocument AddMerchantPrivateDataToPost(GatewayInfo Info)
        {
            // First we are going to create a multi node merchant-private data.
            // We are going to treat it like a name value pair so we can store multiple values.
            // You can do this in many different ways, including creating many XmlDocuments.
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            XmlElement xmlelem = doc.CreateElement("","<merchant-private-data>","");            
           
            // Add a "shopper-id" node.            
            System.Xml.XmlNode tempNode = doc.CreateElement("shopper-id");
            tempNode.InnerText = "";
            xmlelem.AppendChild(tempNode);

            // Add a "cart-id" node.
            System.Xml.XmlNode tempNode2 = doc.CreateElement("cart-id");
            tempNode2.InnerText = "";
            xmlelem.AppendChild(tempNode2);

            //merchant Notes
            System.Xml.XmlNode tempNode3 = doc.CreateElement("merchant-note");
            tempNode3.InnerText = Info.MerchantPrivateData;
            xmlelem.AppendChild(tempNode3);

            doc.AppendChild(xmlelem);

            return doc;
            
        }

        /// <summary>
        /// Replaces the symbols with the hex codes
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        public string EscapeXmlChars(string In)
        {
            string RetVal = In;
            RetVal = RetVal.Replace("&", "&#x26;");
            RetVal = RetVal.Replace("<", "&#x3c;");
            RetVal = RetVal.Replace(">", "&#x3e;");
            return RetVal;
        }

        /// <summary>
        /// Returns the string(Merhcnat Id and Key) to add this value to the Request Headers
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        private string GetAuthorization(string User, string Password) 
        {
           UTF8Encoding utf8encoder = new UTF8Encoding(false, true);
           return Convert.ToBase64String(utf8encoder.GetBytes(string.Format("{0}:{1}", User, Password)));            
        }

       /// <summary>
       /// Returns the URL to post the input data for payment
       /// Checks for test mode and returns the URL to post data
       /// </summary>
       /// <param name="_MerchantID"></param>
       /// <returns></returns>
       public string GetPostUrl(string _MerchantID)
       {
           if (_Environment == EnvironmentType.Sandbox)
           {
               return string.Format("https://sandbox.google.com/checkout/cws/v2/Merchant/{0}/request",_MerchantID);
           }
           else
           {
               return string.Format("https://checkout.google.com/cws/v2/Merchant/{0}/request",_MerchantID);
           }
       }       
       
       /// <summary>
       ///Returns the XML returned from Google gateway
       /// </summary>
       /// <param name="ResponseXml"></param>
       /// <returns></returns>
       private GatewayResponse ParseXML(string ResponseXml)
        {
            GatewayResponse _response = new GatewayResponse();
            bool parsed = false;

            try
            {
                if (ResponseXml.IndexOf("<checkout-redirect") > -1)
                {
                    Google.CheckoutRedirect _CheckoutRedirectResponse = (Google.CheckoutRedirect)EncodeHelper.Deserialize(ResponseXml, typeof(Google.CheckoutRedirect));
                    _response.PaypalECtoken = _CheckoutRedirectResponse.serialnumber;
                    _response.ResponseCode = "0";
                    _response.ECRedirectURL = _CheckoutRedirectResponse.redirecturl;
                    _response.IsSuccess = true;

                    parsed = true;
                }
                else if (ResponseXml.IndexOf("<request-received") > -1)
                {
                    Google.RequestReceivedResponse _requestReceivedResponse = (Google.RequestReceivedResponse)EncodeHelper.Deserialize(ResponseXml, typeof(Google.RequestReceivedResponse));
                    _response.PaypalECtoken = _requestReceivedResponse.serialnumber;
                    _response.ResponseCode = "0";
                    _response.IsSuccess = true;
                    parsed = true;
                }
                else if (ResponseXml.IndexOf("<error") > -1)
                {
                    Google.ErrorResponse _ErrorResponse = (Google.ErrorResponse)EncodeHelper.Deserialize(ResponseXml, typeof(Google.ErrorResponse));
                    _response.ResponseCode = "-1";
                    _response.ResponseText = _ErrorResponse.errormessage + "<br>" + _ErrorResponse.warningmessages;
                    parsed = true;
                }
                else
                {
                    _response.ResponseCode = "-1";
                    _response.ResponseText = "Couldn't parse ResponseXml";
                    parsed = true;
                }
            }
            catch
            {
                //let it continue
            }

            if(!parsed)
            {
            }
            return _response;
       }        
       #endregion
    }
}
