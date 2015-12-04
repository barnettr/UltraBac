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
using com.paypal.soap.api;

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Provides an instance properties for Gateway settings    
    /// </summary>    
    public class GatewayInfo
    {
        # region Member Variables
        private GatewayType _gateway = new GatewayType();
        private string _loginID = string.Empty;
        private string _gatewayPwd = String.Empty;
        private string _gatewayURL = String.Empty;
        private bool _testmode = false;
        private string _transactionKey = String.Empty;
        private ECGatewayAction _paymentaction = new ECGatewayAction();        
        private string _gatewayECreturnURL = string.Empty;
        private string _gatewayECcancelURL = string.Empty;
        private string _gatewayECtoken = string.Empty;
        private string _paypalPayerId = string.Empty;
        private string _googleOrderNumber = string.Empty;
        private string _transactionType = string.Empty;
        private string _tenderType = string.Empty;
        private string _merchantprivateData = string.Empty;
        private PaymentActionCodeType _paymentCodetype = com.paypal.soap.api.PaymentActionCodeType.Order;
        private CurrencyCodeType _currencyCodetype = com.paypal.soap.api.CurrencyCodeType.USD;        
        #endregion

        #region Public Instance properties

        /// <summary>
        /// Gets or sets the Gateway type object.
        /// </summary>
        public GatewayType gateway
        {
            get { return _gateway; }
            set { _gateway = value; }
        }

        /// <summary>
        /// Gets or sets the Merchant Gatewayid property
        /// </summary>
        public string GatewayLoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }

        /// <summary>
        /// Gets or sets the Mercahnt Gateway password property
        /// </summary>
        public string GatewayPassword
        {
            get { return _gatewayPwd; }
            set { _gatewayPwd = value; }
        }

        /// <summary>
        /// Gets or sets the gateway specific URL. May not be needed for all gateways.
        /// </summary>
        public string GatewayURL
        {
            get { return _gatewayURL; }
            set { _gatewayURL = value; }
        }

        /// <summary>
        /// Gets or sets the gateway into Test Mode. Not supported by all gateways.
        /// </summary>
        public bool TestMode
        {
            get { return _testmode; }
            set { _testmode = value; }
        }
        /// <summary>
        /// Gets or sets the gateway into TransactionType.
        /// </summary>
        public string TransactionType
        {
            get { return _transactionType; }
            set { _transactionType = value; }
        }

        /// <summary>
        /// Gets or sets the gateway into TransactionType.
        /// </summary>
        public string TenderType
        {
            get { return _tenderType; }
            set { _tenderType = value; }
        }

        /// <summary>
        /// Gets or sets the transaction key
        /// </summary>
        public string TransactionKey
        {
            get { return _transactionKey; }
            set { _transactionKey = value; }
        }

        /// <summary>
        /// Retrieves or sets the Paypal/google EC GatewayAction object
        /// </summary>
        public ECGatewayAction ECGatewayAction
        {
            get { return _paymentaction; }
            set { _paymentaction = value; }
        }

        /// <summary>
        /// Retrieves or sets the Paypal return URL
        /// </summary>
        public string GatewayECReturnURL
        {
            get { return _gatewayECreturnURL; }
            set { _gatewayECreturnURL = value; }
        }

        /// <summary>
        /// Retrieves or sets the Paypal cancel URL
        /// </summary>
        public string GatewayECCancelURL
        {
            get { return _gatewayECcancelURL; }
            set { _gatewayECcancelURL = value; }
        }

        /// <summary>
        ///  Retrieves or sets the Paypal Express Checkout token
        /// </summary>
        public string GatewayECToken
        {
            get { return _gatewayECtoken; }
            set { _gatewayECtoken = value; }
        }

        /// <summary>
        ///  Retrieves or sets the Paypal Payer ID
        /// </summary>
        public string PaypalPayerID
        {
            get { return _paypalPayerId; }
            set { _paypalPayerId = value; }
        }

        /// <summary>
        ///  Retrieves or sets the Paypal Payer ID
        /// </summary>
        public string GoogleOrderNumber
        {
            get { return _googleOrderNumber; }
            set { _googleOrderNumber = value; }
        }

        /// <summary>
        ///  Retrieves or sets the Google Merchant private data
        /// </summary>
        public string MerchantPrivateData
        {
            get { return _merchantprivateData; }
            set { _merchantprivateData = value; }
        }

        /// <summary>
        /// Retrieves or sets the Paypal PaymentAction CodeType (Order,sale,Authorization) and default Value is 'Order'
        /// </summary>
        public PaymentActionCodeType PaypalPaymentActionCodeType
        {
            get { return _paymentCodetype; }
            set { _paymentCodetype = (PaymentActionCodeType)Enum.Parse(typeof(PaymentActionCodeType),value.ToString()); }
        }

        /// <summary>
        /// Retrieves or sets the Paypal Currency code type (like USD,USS,UZS,..,etc) 
        /// Default currency code type is 'USD'
        /// </summary>
        public CurrencyCodeType PaypalCurrencyCodeType
        {
            get { return _currencyCodetype; }
            set { _currencyCodetype = (CurrencyCodeType)Enum.Parse(typeof(CurrencyCodeType), value.ToString()); }
        }
        #endregion
    }
}
