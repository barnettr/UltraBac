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
using System.Web.Services.Protocols;


namespace ZNode.Libraries.Integrator.Shipping
{
    /// <summary>
    /// Represents methods for FedEx shipping service
    /// </summary>
    public class FedEx
    {
        # region Protected Member Instance Variables
        private string _fedExAccountNumber;
        private string _fedExMeterNumber;
        private string _fedExAccessKey;
        private string _fedExSecurityCode;
        private string _shipperZipCode;
        private string _shipperStateCode;
        private string _shipperCountryCode;
        private string _shipToZipCode;
        private string _shipToStateCode;
        private string _shipToCountryCode;
        private bool _shipToAddressType = false;
        private decimal _packageWeight = 0;
        private string _dropOffType = "REGULAR_PICKUP";
        private string _fedExServiceType;
        private string _packageTypeCode = "YOUR_PACKAGING";
        private string _errorCode;
        private string _errorDescription;
        # endregion

        # region Public Instance Properties
        /// <summary>
        /// Sets or retrieves the Merchant FedEx LoginId
        /// </summary>
        public string FedExAccountNumber
        {
            get { return _fedExAccountNumber; }
            set { _fedExAccountNumber = value; }
        }

        /// <summary>
        /// Sets or retrieves the Merchant FedEx LoginPassword
        /// </summary>
        public string FedExMeterNumber
        {
            get { return _fedExMeterNumber; }
            set { _fedExMeterNumber = value; }
        }

        /// <summary>
        /// Sets or retrieves the Merchant FedEx LoginPassword
        /// </summary>
        public string FedExAccessKey
        {
            get { return _fedExAccessKey; }
            set { _fedExAccessKey = value; }
        }

        /// <summary>
        /// Sets or retrieves the FedEx security code
        /// </summary>
        public string FedExSecurityCode
        {
            get { return _fedExSecurityCode; }
            set { _fedExSecurityCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Shipper postal code
        /// </summary>
        public string ShipperZipCode
        {
            get { return _shipperZipCode; }
            set { _shipperZipCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Shipper postal code
        /// </summary>
        public string ShipperStateCode
        {
            get { return _shipperStateCode; }
            set { _shipperStateCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Shipper Country code
        /// </summary>
        public string ShipperCountryCode
        {
            get { return _shipperCountryCode; }
            set { _shipperCountryCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Destination postal code
        /// </summary>
        public string ShipToZipCode
        {
            get { return _shipToZipCode; }
            set { _shipToZipCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Destination postal code
        /// </summary>
        public string ShipToStateCode
        {
            get { return _shipToStateCode; }
            set { _shipToStateCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Destination Country code
        /// </summary>
        public string ShipToCountryCode
        {
            get { return _shipToCountryCode; }
            set { _shipToCountryCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Destination Address type
        /// Default address type is 'Residential'
        /// </summary>
        public bool ShipToAddressType
        {
            get { return _shipToAddressType; }
            set { _shipToAddressType = value; }
        }

        /// <summary>
        /// Sets or retrieves the weight of the package
        /// </summary>
        public decimal PackageWeight
        {
            get { return _packageWeight; }
            set { _packageWeight = value; }
        }

        /// <summary>
        /// Sets or retrieves the Pickup type
        /// Bydefault pickup type is  'One Time Pickup'
        /// </summary>        
        public string DropOffType
        {
            get { return _dropOffType; }
            set { _dropOffType = value; }
        }

        /// <summary>
        /// Sets or retrieves the FedEx Service type
        /// </summary>
        public string FedExServiceType
        {
            get { return _fedExServiceType; }
            set { _fedExServiceType = value; }
        }

        /// <summary>
        /// Sets or retrieves the FedEx package type code
        /// </summary>
        public string PackageTypeCode
        {
            get { return _packageTypeCode; }
            set { _packageTypeCode = value; }
        }
        /// <summary>
        /// Sets or retrieves the Webservice response code 
        /// </summary>
        public string ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        /// <summary>
        /// Sets or retrieves the Webservice response code description
        /// </summary>
        public string ErrorDescription
        {
            get { return _errorDescription; }
            set { _errorDescription = value; }
        }
        # endregion

        # region Public Methods
        /// <summary>
        /// Submits Shipping details to FedEx Web Service to get Rate in US dollars
        /// </summary>
        public decimal GetShippingRate()
        {
            // Build a RateAvailableServices request object
            RateAvailableServicesRequest request = new RateAvailableServicesRequest();
            request.ClientDetail = new ClientDetail();
            request.ClientDetail.AccountNumber = FedExAccountNumber; // Client account number
            request.ClientDetail.MeterNumber = FedExMeterNumber; // Client meter number
            
            //Authentication Details - Access Key
            request.WebAuthenticationDetail = new WebAuthenticationDetail();
            request.WebAuthenticationDetail.UserCredential = new WebAuthenticationCredential();
            request.WebAuthenticationDetail.UserCredential.Key = FedExAccessKey; //FedEx WDSL Access Key
            request.WebAuthenticationDetail.UserCredential.Password = FedExSecurityCode; // FedEx Security Code
            
            request.TransactionDetail = new TransactionDetail();
            // This is a reference field for the customer.  
            // Any value can be used and will be provided in the response.
            request.TransactionDetail.CustomerTransactionId = "Rate Available Request"; 
            
            // WSDL version information, value is automatically set from wsdl
            request.Version = new VersionId();

            // Origin information
            request.Origin = new Address(); 
            request.Origin.StateOrProvinceCode = ShipperStateCode; 
            request.Origin.PostalCode = ShipperZipCode;
            request.Origin.ResidentialSpecified = false;
            request.Origin.CountryCode = ShipperCountryCode;

            // Destination information
            request.Destination = new Address(); 
            request.Destination.StateOrProvinceCode = ShipToStateCode;
            request.Destination.PostalCode = ShipToZipCode;
            request.Destination.ResidentialSpecified = true;
            request.Destination.CountryCode = ShipToCountryCode;
            request.Destination.Residential = ShipToAddressType; //Deliver to home or standard

            //Set Currency type,Service tyoe,
            request.CurrencyType = "USD";
            request.DropoffType = (DropoffType)Enum.Parse(typeof(DropoffType), DropOffType);
            request.DropoffTypeSpecified = true;
            request.ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), FedExServiceType);
            request.ServiceTypeSpecified = true;
            request.PackagingType =(PackagingType)Enum.Parse(typeof(PackagingType), PackageTypeCode);
            request.PackagingTypeSpecified = true;            
            request.ShipDate = DateTime.Now; // Shipping date and time
            request.RateRequestTypes = new RateRequestType[1] { RateRequestType.ACCOUNT }; // Request options are: ACCOUNT, COUNTER, LIST, MULTIWEIGHT

            // -----------------------------------------
            // Passing multi piece shipment rate request
            // -----------------------------------------
            request.RateRequestPackageSummary = new RateRequestPackageSummary();
            //
            request.RateRequestPackageSummary.TotalWeight = new Weight();
            request.RateRequestPackageSummary.TotalWeight.Value = double.Parse(PackageWeight.ToString());
            request.RateRequestPackageSummary.TotalWeight.Units = WeightUnits.LB;
            request.RateRequestPackageSummary.PieceCount = "1";                       
           
            //This is the call to the web service passing in a RateAvailableServicesRequest and returning a RateAvailableServicesReply
            RateAvailableServicesService rateService = new RateAvailableServicesService(); // Initialize the service // Service call
                
            try
            {
                // This is the call to the web service passing in a RateRequest and returning a RateReply
                RateAvailableServicesReply reply = rateService.rateAvailableServices(request); // Service call

                if (reply.HighestSeverity == NotificationSeverityType.SUCCESS) // check if the call was successful
                {
                    ErrorDescription = reply.Notifications[0].Message;
                    ErrorCode = "0";
                    foreach (RateAndServiceOptions option in reply.Options)
                    {
                        foreach (RatedShipmentDetail ratedShipmentDetail in option.RatedShipmentDetails)
                        {
                            foreach (RatedPackageDetail ratedPackage in ratedShipmentDetail.RatedPackages)
                            {
                                return ratedShipmentDetail.ShipmentRateDetail.TotalNetCharge.Amount;
                            }
                        }
                    }
                }
                else
                {
                    ErrorCode = reply.Notifications[0].Code;
                    ErrorDescription = reply.Notifications[0].Message;

                    return 0;
                }
            }
            catch (SoapException e)
            {
                  ErrorCode = "-1";
                  ErrorDescription =  e.Detail.InnerText;
            }
            catch (Exception e)
            {
                ErrorCode = "-1";
                ErrorDescription = e.Message;
            }

            return 0;

        }
        #endregion
    }
}
