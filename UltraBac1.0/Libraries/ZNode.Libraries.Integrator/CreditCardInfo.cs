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
    /// Provides an instance properties for Credit card information
    /// </summary>
    public class CreditCardInfo
    {
        #region Member Variables
        private string _cardNumber = string.Empty;
        private string _cardExp = string.Empty;
        private string _cardSecurityCode = string.Empty;
        private decimal _amount = 0;
        private decimal _subTotal = 0;
        private decimal _shippingCharge = 0;
        private decimal _taxCost = 0;
        private int _orderID = 0;
        # endregion

        #region Credit Card instance Properties

        /// <summary>
        /// Get/set the Credit card Number property
        /// </summary>
        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        /// <summary>
        /// Get/set the Credit card expiration date property
        /// </summary>
        public string CreditCardExp
        {
            get { return _cardExp; }
            set { _cardExp = value; }
        }

        /// <summary>
        /// Get/set the Credit card Security code property
        /// </summary>
        public string CardSecurityCode
        {
            get { return _cardSecurityCode; }
            set { _cardSecurityCode = value; }
        }

        /// <summary>
        /// Gets or sets the Order ID
        /// </summary>
        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        /// <summary>
        /// Get/set the ordered amount property
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// Get/set the ordered Sub Total amount property
        /// </summary>
        public decimal SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }
        /// <summary>
        /// Get/set the Shipping Charge property
        /// </summary>
        public decimal ShippingCharge
        {
            get { return _shippingCharge; }
            set { _shippingCharge  = value; }
        }
        /// <summary>
        /// Get/set the tax cost property
        /// </summary>
        public decimal TaxCost
        {
            get { return _taxCost; }
            set { _taxCost = value; }
        }
        # endregion
    }
}
