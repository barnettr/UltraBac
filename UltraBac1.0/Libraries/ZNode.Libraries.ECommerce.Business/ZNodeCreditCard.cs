using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides information about Credit card and authorization
    /// </summary>
    public class ZNodeCreditCard : ZNodeBusinessBase
    {
        /// <summary>
        /// Represents the payment gateway
        /// </summary>
        public string Gateway = string.Empty;
        /// <summary>
        /// Represents the Merchant loginid. 
        /// </summary>
        public string MerchantLogin = string.Empty;
        /// <summary>
        /// Represents the Merchant Gateway password.
        /// </summary>
        public string MerchantPassword = string.Empty;
        /// <summary>
        /// Represents the transaction amount (Ordered amount).
        /// </summary>
        public string TransactionAmount = string.Empty;
        /// <summary>
        /// Represents the transaction description.
        /// </summary>
        public string TransactionDesc = string.Empty;
        /// <summary>
        /// Represents the Credit card expiration month property.
        /// </summary>
        public string CardExpMonth = string.Empty;
        /// <summary>
        /// Represents the Credit card epiration year property.
        /// </summary>
        public string CardExpYear = string.Empty;
        /// <summary>
        /// Represents the Credit card Number.
        /// </summary>
        public string CardNumber = string.Empty;
        /// <summary>
        /// Represents the Customer billing address.
        /// </summary>
        public string CustomerAddress = string.Empty;
        /// <summary>
        /// Represents the Customer billing city.
        /// </summary>
        public string CustomerCity = string.Empty;
        /// <summary>
        /// Represents the Customer billing country.
        /// </summary>
        public string CustomerCountry = string.Empty;
        /// <summary>
        /// Represents the Customer billing email id.
        /// </summary>
        public string CustomerEmail = string.Empty;
        /// <summary>
        /// Represents the Customer billing first name.
        /// </summary>
        public string CustomerFirstName = string.Empty;
        /// <summary>
        /// Represents the Customer billing Last name.
        /// </summary>
        public string CustomerLastName = string.Empty;
        /// <summary>
        /// Represents the Customer billing state code.
        /// </summary>
        public string CustomerState = string.Empty;
        /// <summary>
        /// Represents the Customer billing postal code
        /// </summary>
        public string CustomerZip = string.Empty;
    }
}
