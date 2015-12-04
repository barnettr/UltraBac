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

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Represents the response returned by a gateway
    /// </summary>
    public class GatewayResponse
    {
        #region Private Member Instance Variables
        // Summary:
        //     Represents the Gateway Response code as a string.
        private string _ResponseCode = string.Empty;
        /// <summary>
        ///  Represents the Gateway Response code as a string.
        /// </summary>
        private string _ResponseText = string.Empty;
        /// <summary>
        /// Represents the Gateway Response transaction id as a string.
        /// </summary>
        private string _TransactionId;
        /// <summary>
        /// Represents the Gateway Response code as boolean value
        /// </summary>
        private bool _IsSuccess = false;    
        /// <summary>
        /// Represents the Gateway AVSResponse code as a string.
        /// </summary>
        private string _AVSResponsecode = string.Empty;
        /// <summary>
        /// Represents the Gateway CCVResponse code as a string.
        /// </summary>
        private string _CCVResponsecode = string.Empty;
        /// <summary>
        /// Respresents the Gateway Unique transaction reference number
        /// </summary>
        private string _ReferenceNumber= string.Empty;
        /// <summary>
        /// Represents the Paypal Gateway express checkout token 
        /// </summary>        
        private string _token = string.Empty;
        /// <summary>
        ///  Represents the Paypal Gateway express checkout payerID
        /// </summary>
        private string _payerID = string.Empty;
        /// <summary>
        /// Represents the Paypal payer address
        /// </summary>
        private Address _CustomerAddress = new Address();
        /// <summary>
        /// Represents the ApprovalCode from the gateway
        /// </summary>
        private string _approvalCode = string.Empty;       

        //Retry Logic Response.
        /// <summary>
        /// Represents the RetryTrace number.
        /// </summary>
        private string _retrytrace = string.Empty;
        /// <summary>
        /// Represents the number of requests processed by the Gateway with the same retryTrace number. 
        /// </summary>
        private string _retryAttempcount = string.Empty;
        /// <summary>
        /// Represents the Last retry date.
        /// </summary>
        private string _lastRetryDate = string.Empty;

        /// <summary>
        /// Represents Express Checkout redirect URL
        /// </summary>
        private string _redirectURL = string.Empty;
        
        #endregion

        # region Public Instance properties

        /// <summary>
        /// Sets or retrieves the Gateway Response code
        /// </summary>
        public String ResponseCode
        {
            get { return  _ResponseCode; }
            set { _ResponseCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Gateway Response Text
        /// </summary>
        public String ResponseText
        {
            get { return _ResponseText; }
            set { _ResponseText = value; }
        }

        /// <summary>
        /// Sets or retrieves the Gateway TransactionID
        /// </summary>
        public String TransactionId
        {
            get { return _TransactionId; }
            set { _TransactionId = value; }
        }

        /// <summary>
        /// Sets or retrieves the Gateway Response as boolean
        /// </summary>
        public bool IsSuccess
        {
            get { return _IsSuccess; }
            set { _IsSuccess = value; }
        }

        /// <summary>
        /// Sets Or Retrieves the Gateway AVSResponse Code.
        /// </summary>
        public String AVSResponseCode
        {
            get { return _AVSResponsecode; }
            set { _AVSResponsecode = value; }
        }

        /// <summary>
        /// Sets Or Retrieves the Gateway CCVResponse Code.
        /// </summary>
        public String CCVResponsecode
        {
            get { return _CCVResponsecode; }
            set { _CCVResponsecode = value; }
        }

        /// <summary>
        /// Sets Or Retrieves the Gateway Transaction Reference number.
        /// </summary>
        public String ReferenceNumber
        {
            get { return _ReferenceNumber; }
            set { _ReferenceNumber = value; }
        }

        /// <summary>
        ///  Sets or retrieves the Paypal Gateway token
        /// </summary>
        public string PaypalECtoken
        {
            get { return _token; }
            set { _token = value; }
        }

        /// <summary>
        ///  Sets or retrieves the Paypal Gateway payer ID
        /// </summary>
        public string PaypalPayerID
        {
            get { return _payerID; }
            set { _payerID = value; }
        }

        /// <summary>
        /// Sets or retrieves the Paypal-payer address
        /// </summary>
        public Address PayerAddress
        {
            get { return _CustomerAddress; }
            set { _CustomerAddress = value; }
        }

        public string ApprovalCode
        {
            get { return _approvalCode; }
            set { _approvalCode = value; }
        }


        //Retry Logic 
        /// <summary>
        /// Sets or retrieves the Retry trace number.
        /// </summary>
        public String RetryTrace
        {
            get { return _retrytrace; }
            set { _retrytrace = value; }
        }
        /// <summary>
        /// Sets or retrives the RetryAttempCount
        /// </summary>
        public String RetryAttemptCount
        {
            get { return _retryAttempcount; }
            set { _retryAttempcount = value;}
        }
        /// <summary>
        /// Sets or retrives the Last RetryDate.
        /// </summary>
        public String LastRetryDate
        {
            get { return _lastRetryDate; }
            set { _lastRetryDate = value;}
        }

        /// <summary>
        /// Sets or retrives the EC Redirect URL.
        /// </summary>
        public String ECRedirectURL
        {
            get { return _redirectURL; }
            set { _redirectURL = value; }
        }
     # endregion
    }
}
