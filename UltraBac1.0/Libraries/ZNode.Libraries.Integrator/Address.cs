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
    /// Provides an instance properties for customer Billing and Shipping address
    /// </summary>
    public class Address
    {

        #region Member Variables
        private string _firstName = string.Empty;
        private string _middleName = string.Empty;
        private string _lastName = string.Empty;
        private string _companyName = string.Empty;
        private string _street1 = string.Empty;
        private string _street2 = string.Empty;
        private string _city = string.Empty;
        private string _stateCode = string.Empty;
        private string _postalCode = string.Empty;
        private string _countryCode = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _faxNumber = string.Empty;
        private string _emailId = string.Empty;
        #endregion

        #region Public Instance Properties
        /// <summary>
        /// Sets or retrieves the Customer FirstName
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        /// <summary>
        /// Sets or retrieves the Customer MiddleName
        /// </summary>
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer LastName
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer Company Name
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer Address Line 1 
        /// </summary>
        public string Street1
        {
            get { return _street1; }
            set { _street1 = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer Address Line 2
        /// </summary>
        public string Street2
        {
            get { return _street2; }
            set { _street2 = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer City
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer State Code
        /// </summary>
        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer postal code
        /// </summary>
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer Country Code
        /// </summary>
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer Phone Number
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer Fax Number
        /// </summary>
        public string FaxNumber
        {
            get { return _faxNumber; }
            set { _faxNumber = value; }
        }

        /// <summary>
        /// Sets or retrieves the Customer Email id
        /// </summary>
        public string EmailId
        {
            get { return _emailId; }
            set { _emailId = value; }
        }

        #endregion
    }
}
