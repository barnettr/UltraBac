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
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Submit payment to PayFlow Pro payment gateway
    /// </summary>
    public class GatewayPayFlowPro
    {
        # region Constructors
        public GatewayPayFlowPro() { }        
        # endregion

        # region Public Methods
        /// <summary>
        /// Populate the authorization transaction from the order details.
        /// Submits credit card payment to a PayFlow pro gateway
        /// </summary>
        /// <param name="BillingAddress"></param>
        /// <param name="ShippingAddress"></param>
        /// <param name="_gatewayInfo"></param>
        /// <param name="_creditCardInfo"></param>
        /// <returns></returns>
        public GatewayResponse SubmitPayment(Address BillingAddress, Address ShippingAddress, GatewayInfo _gatewayInfo, CreditCardInfo _creditCardInfo)
        {   
            // Populate the Billing address details.
            BillTo Bill = new BillTo();
            Bill.FirstName = BillingAddress.FirstName;
            Bill.LastName = BillingAddress.LastName;
            Bill.Street = BillingAddress.Street1 + BillingAddress.Street2;
            Bill.City = BillingAddress.City;
            Bill.Zip = BillingAddress.PostalCode;
            Bill.State = BillingAddress.StateCode;

            // Populate the Shipping address details.
            ShipTo Ship = new ShipTo();
            Ship.ShipToFirstName = ShippingAddress.FirstName;
            Ship.ShipToLastName = ShippingAddress.LastName;
            Ship.ShipToStreet = ShippingAddress.Street1 + ShippingAddress.Street2;
            Ship.ShipToCity = ShippingAddress.City;
            Ship.ShipToZip = ShippingAddress.PostalCode;
            Ship.ShipToState = ShippingAddress.StateCode;

            // Populate the invoice
            Invoice Inv = new Invoice();
            Inv.BillTo = Bill;
            Inv.ShipTo = Ship;
            Inv.InvNum = _creditCardInfo.OrderID.ToString();
            Inv.Amt = new Currency(_creditCardInfo.Amount);

            // Populate the Credit Card details.
            // ExpiredDate should follow the following data format "0107" (which represents Jan,2007)             
            string CardExpireDate = _creditCardInfo.CreditCardExp.Remove(2,3); 
            CreditCard Card = new CreditCard(_creditCardInfo.CardNumber, CardExpireDate);
            
            //Set Credit Card Secutiry Code          
            Card.Cvv2 = _creditCardInfo.CardSecurityCode;

            //Create the Tender.
			CardTender Tender = new CardTender(Card);
            
            //Merchant Account Details
            UserInfo Info = new UserInfo(_gatewayInfo.GatewayLoginID, _gatewayInfo.GatewayLoginID, "paypal", _gatewayInfo.GatewayPassword);
            
            //Set Post URL
            _gatewayInfo.GatewayURL = SetPostURL(_gatewayInfo.TestMode);

            //Connection Settomgs
            PayflowConnectionData _data = new PayflowConnectionData(_gatewayInfo.GatewayURL,443,null,0,null,null);
            
            // Create the transaction.
            SaleTransaction TransSale = new SaleTransaction(Info, _data, Inv, Tender, PayflowUtility.RequestId);

            Response RespAuth = TransSale.SubmitTransaction();
            
            GatewayResponse Response = new GatewayResponse();

            if (RespAuth.TransactionResponse.Result == 0)
            {
                Response.ResponseCode = "0";
                Response.IsSuccess = true;                
                Response.ResponseText = RespAuth.TransactionResponse.RespMsg;
                Response.TransactionId = RespAuth.TransactionResponse.Pnref;                
            }
            // If result code is greater than 0 (Zero), the transaction is discarded 
            // by the Payflow server. The reason why the transaction is discarded is 
            // evident by the result code value and therefore, you should look at this 
            // result code and decide if 
            // 1. The customer has given some wrong inputs,
            // 2. It's a fraudulent transaction.
            // 3. There's a problem with your merchant account credentials etc.
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Response Description : " + RespAuth.TransactionResponse.RespMsg.ToString());

                Response.ResponseCode = "Response Code : " + RespAuth.TransactionResponse.Result.ToString() + "<br>";
                 
                Response.ResponseText = sb.ToString();
            }

            return Response;
        }
        #endregion

        #region public Methods - Related to Express CheckOut payment
        /// <summary>        
        /// Calling SET operation is the first step of PayPal 
        /// express checkout process.
        /// In response of the SET request, you will get a secure session token id.
        /// Using this token id, you should redirect the customer's browser to the PayPal website to establish a secure token.
        /// </summary>
        /// <param name="BillingAddress"></param>
        /// <param name="ShippingAddress"></param>
        /// <param name="_gatewayInfo"></param>
        /// <param name="_creditCardInfo"></param>
        public GatewayResponse GetECTransactionToken(Address BillingAddress, Address ShippingAddress, GatewayInfo _gatewayInfo, CreditCardInfo _creditCardInfo)
        {
            GatewayResponse gatewayResponse = new GatewayResponse();

            // Create the invoice object and set the amount value.
			Invoice Inv = new Invoice();
            Inv.Amt = new Currency(_creditCardInfo.Amount);

            // Create the data object for Express Checkout SET operation 
            // using ECSetRequest Data Object.
            ECSetRequest SetRequest = new ECSetRequest
                (_gatewayInfo.GatewayECReturnURL, // This is the Return URL
                _gatewayInfo.GatewayECCancelURL); // This is the Cancel URL

            // Create the Tender object.
            PayPalTender Tender = new PayPalTender(SetRequest);

            //Merchant Account Details
            UserInfo Info = new UserInfo(_gatewayInfo.GatewayLoginID, _gatewayInfo.GatewayLoginID, "paypal", _gatewayInfo.GatewayPassword);

            //Connection Settomgs
            PayflowConnectionData _data = new PayflowConnectionData(_gatewayInfo.GatewayURL, 443, null, 0, null, null);

            // Create the transaction object.
            AuthorizationTransaction TransAuth = new AuthorizationTransaction(Info, _data, Inv, Tender, PayflowUtility.RequestId);
                        
            // Submit the transaction.
            TransAuth.SubmitTransaction();

            // Check the transaction status.            
            if (TransAuth.Response.TransactionResponse.Result == 0)
            {
                gatewayResponse.ResponseCode = "0";
                gatewayResponse.IsSuccess = true;
                gatewayResponse.ResponseText = TransAuth.Response.TransactionResponse.RespMsg;
                gatewayResponse.TransactionId = TransAuth.Response.TransactionResponse.Pnref;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Response Description : " + TransAuth.Response.TransactionResponse.RespMsg.ToString());

                gatewayResponse.ResponseCode = "Response Code : " + TransAuth.Response.TransactionResponse.Result.ToString() + "<br>";

                gatewayResponse.ResponseText = sb.ToString();
            }

            return gatewayResponse;
        }

        public GatewayResponse DoExpressCheckoutPayment(GatewayInfo _gatewayInfo,CreditCardInfo _creditCardInfo)
        {
            GatewayResponse _response = new GatewayResponse(); 

            ECDoRequest ECReq = new ECDoRequest(_gatewayInfo.GatewayECToken , _gatewayInfo.PaypalPayerID);
            
            // Create the invoice object and set the amount value.
            Invoice Inv = new Invoice();
            Inv.Amt = new Currency(_creditCardInfo.Amount);

            // Create the Tender object.
            PayPalTender Tender = new PayPalTender(ECReq);

            //Merchant Account Details
            UserInfo Info = new UserInfo(_gatewayInfo.GatewayLoginID, _gatewayInfo.GatewayLoginID, "paypal", _gatewayInfo.GatewayPassword);

            //Connection Settomgs
            PayflowConnectionData _data = new PayflowConnectionData(_gatewayInfo.GatewayURL, 443, null, 0, null, null);

            // Create the transaction object.
            AuthorizationTransaction TransAuth = new AuthorizationTransaction(Info, _data, Inv, Tender, PayflowUtility.RequestId);

            // Submit the transaction.
            Response ECPayFlowResp =TransAuth.SubmitTransaction();
            
            
            // Check the transaction status.            
            if (ECPayFlowResp.TransactionResponse.Result >= 0)
            {
                //To DO
            }

            return _response;
        }
        #endregion

        # region Helper Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsTestMode"></param>
        /// <returns></returns>
        private string SetPostURL(bool IsTestMode)
        {
            if (IsTestMode)
            {
                return "pilot-payflowpro.verisign.com/transaction";
            }

            return "payflowpro.verisign.com/transaction";
        }
        #endregion
    }
}
