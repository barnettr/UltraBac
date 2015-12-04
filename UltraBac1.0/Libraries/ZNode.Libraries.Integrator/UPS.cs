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
using System.Net;
using System.Web.Services;

namespace ZNode.Libraries.Integrator.Shipping
{
    /// <summary>
    /// Represents methods for UPS shipping service
    /// </summary>
    public class UPS
    {
        # region Protected Member Instance Variables
        private string _UPSUserId;
        private string _UPSPassword;
        private string _UPSKey;
        private string _ShipperZipCode;
        private string _ShipperCountryCode;
        private string _ShipToZipCode;
        private string _ShipToCountryCode;
        private string _ShipToAddressType = "Residential";
        private decimal _PackageWeight = 0;
        private string _PickupType = "One Time Pickup";
        private string _UPSServiceCode;
        private string _PackageTypeCode;
        private string _ErrorCode;
        private string _ErrorDescription;
        # endregion

        # region Public Instance Properties
        /// <summary>
        /// Sets or retrieves the Merchant UPS LoginId
        /// </summary>
        public string UPSUserID
        {
            get { return _UPSUserId; }
            set { _UPSUserId = value; }
        }

        /// <summary>
        /// Sets or retrieves the Merchant UPS LoginPassword
        /// </summary>
        public string UPSPassword
        {
            get { return _UPSPassword; }
            set { _UPSPassword = value; }
        }

        /// <summary>
        /// Sets or retrieves the Merchant UPS Merchant Access Key
        /// </summary>
        public string UPSKey
        {
            get { return _UPSKey; }
            set { _UPSKey = value; }
        }

        /// <summary>
        /// Sets or retrieves the Shipper postal code
        /// </summary>
        public string ShipperZipCode
        {
            get { return _ShipperZipCode; }
            set { _ShipperZipCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Shipper Country code
        /// </summary>
        public string ShipperCountryCode
        {
            get { return _ShipperCountryCode; }
            set { _ShipperCountryCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Destination postal code
        /// </summary>
        public string ShipToZipCode
        {
            get { return _ShipToZipCode; }
            set { _ShipToZipCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Destination Country code
        /// </summary>
        public string ShipToCountryCode
        {
            get { return _ShipToCountryCode; }
            set { _ShipToCountryCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Destination Address type
        /// Default address type is 'Residential'
        /// </summary>
        public string ShipToAddressType
        {
            get { return _ShipToAddressType; }
            set { _ShipToAddressType = value; }
        }

        /// <summary>
        /// Sets or retrieves the weight of the package
        /// </summary>
        public decimal PackageWeight
        {
            get{ return _PackageWeight;}
            set{ _PackageWeight = value;}
        }

        /// <summary>
        /// Sets or retrieves the Pickup type
        /// Bydefault pickup type is  'One Time Pickup'
        /// </summary>        
        public string PickupType
        {
            get { return _PickupType; }
            set { _PickupType = value; }
        }

        /// <summary>
        /// Sets or retrieves the UPS Service code
        /// </summary>
        public string UPSServiceCode
        {
            get { return _UPSServiceCode; }
            set { _UPSServiceCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the UPS package type code
        /// </summary>
        public string PackageTypeCode
        {
            get { return _PackageTypeCode; }
            set { _PackageTypeCode = value; }
        }
        /// <summary>
        /// Sets or retrieves the Webservice response code 
        /// </summary>
        public string ErrorCode
        {
            get { return _ErrorCode; }
            set { _ErrorCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Webservice response code description
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }
        # endregion

        #region Public Methods
        /// <summary>
        /// Submits Shipping details to UPS Web Service to get Rate in US dollars
        /// </summary>
        public decimal GetShippingRate()
        {
            # region Local Member Variables
            WebClient objRequest = new WebClient();            
            string[] objRetVals;
            byte[] objRetBytes;
            string strPayload ="";
            #endregion
                        
            //Setting Headers value
            strPayload = "<?xml version='1.0'?>";
            strPayload += "<AccessRequest xml:lang='en-US'>";
            strPayload += "<AccessLicenseNumber>" + UPSKey + "</AccessLicenseNumber>";//UPS Access Key
            strPayload += "<UserId>" + UPSUserID + "</UserId>"; // UPS Login Account ID
            strPayload += "<Password>" + UPSPassword + "</Password>";
            strPayload += "</AccessRequest>";
            strPayload += "<?xml version='1.0'?>";
            strPayload += "<RatingServiceSelectionRequest xml:lang='en-US'>";
            strPayload += "<Request>";
            strPayload += "<TransactionReference>";
            strPayload += "<CustomerContext>Rating and Service</CustomerContext>";
            strPayload += "<XpciVersion>1.0001</XpciVersion>";
            strPayload += "</TransactionReference>";
            strPayload += "<RequestAction>Rate</RequestAction>";
            strPayload += "<RequestOption>Rate</RequestOption>";
            strPayload += "</Request>";
            strPayload += "<PickupType>";
            strPayload += "<Code>" + PickupType + "</Code>"; //Set Picktype code
            strPayload += "</PickupType>";
            strPayload += "<Shipment>";
            strPayload += "<Shipper>";
            strPayload += "<Address>";
            strPayload += "<PostalCode>" + ShipperZipCode + "</PostalCode>";
            strPayload += "<CountryCode>" + ShipperCountryCode + "</CountryCode>";
            strPayload += "</Address>";
            strPayload += "</Shipper>";
            strPayload += "<ShipTo>";
            strPayload += "<Address>";
            strPayload += "<PostalCode>" + ShipToZipCode + "</PostalCode>";
            strPayload += "<CountryCode>" + ShipToCountryCode + "</CountryCode>";
            strPayload += "</Address>";
            strPayload += "</ShipTo>";       
            strPayload += "<Service>";
            strPayload += "<Code>" +  UPSServiceCode + "</Code>";
            strPayload += "</Service>";
            strPayload += "<Package>";
            strPayload += "<PackagingType><Code>" + PackageTypeCode + "</Code>";
            strPayload += "</PackagingType>";       
            strPayload += "<PackageWeight>";
            strPayload += "<UnitOfMeasurement>";
            strPayload += "<Code>LBS</Code>";
            strPayload += "</UnitOfMeasurement>";
            strPayload += "<Weight>" + PackageWeight.ToString() + "</Weight>";
            strPayload += "</PackageWeight>";
            strPayload += "</Package>";
            strPayload += "</Shipment>";
            strPayload += "</RatingServiceSelectionRequest>";
            
            //Convert the input string into byte object
            byte[] objRequestBytes = Encoding.ASCII.GetBytes(strPayload);                        
            objRequest.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            try
            {
                //Post the values into UPS Web Service
                objRetBytes = objRequest.UploadData("https://www.ups.com/ups.app/xml/Rate", "POST", objRequestBytes);
                objRetVals = System.Text.Encoding.ASCII.GetString(objRetBytes).Split("<*></*>".ToCharArray());

                //If Response Successfull
                if (objRetVals[23] == "1")
                {
                    //Set zero
                    ErrorCode = "0";
                    //Return Description
                    ErrorDescription = "Response Status: " + objRetVals[28] + "<br><br>" + "Shipping Rate : " + objRetVals[110] + " " + objRetVals[105];

                    return Decimal.Parse(objRetVals[110].ToString());
                }
                else
                {
                    //Set Error code and Description
                    ErrorCode = objRetVals[40]; //Response Error code
                    ErrorDescription = objRetVals[45]; //Response Error code Description
                    return 0;
                }
            }
            catch (Exception)
            {
                ErrorCode = "Connection failed.";
                ErrorDescription = "Error while trying to connect with Host Server.Please try again."; //Response Error code Description
                return 0;
            }
        }
        #endregion
    }
}
