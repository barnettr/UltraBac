using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to calculate shipping options.
    /// </summary>
    public class ZNodeShippingEngine:ZNodeBusinessBase
    {
        # region protected Member Variables
        private string _responseCode = "0";
        private string _responseDescription = "";
        #endregion

        # region Public Instance Properties
		/// <summary>
        /// Sets or retrieves the Shipping Option response code
        /// </summary>
        public string ResponseCode 
        {
            get { return _responseCode; }
            set { _responseCode = value; }
        }

		/// <summary>
        /// Sets or retrieves the Shipping Option response code description
        /// </summary>
        public string ResponseDescription
        {
            get { return _responseDescription; }
            set { _responseDescription = value; }
        }
        #endregion

        /// <summary>
        /// Calculates shipping cost for all shopping cart items
        /// </summary>
        /// <param name="shoppingCart">Shopping cart object for which shipping needs to be calculated</param>
        /// <param name="ShippingID">selected shipping ID</param>
        /// <returns></returns>
        public void CalculateShipping(ref ZNodeShoppingCart shoppingCart, int shippingID)
        {
            //get base shipping record
            ShippingService shServ = new ShippingService();
            Shipping shOption = shServ.GetByShippingID(shippingID);
            shoppingCart.ShippingHandlingCharge = shOption.HandlingCharge;           

            //get ALL shipping rules for this shipping code
            ShippingRuleService shRulServ = new ShippingRuleService();
            TList<ShippingRule> shRules = shRulServ.GetByShippingID(shippingID);
                        
            
            //*********************************************************************
            //CALCULATE SHIPPING BASED ON TYPE
            if (shOption.ShippingTypeID == 1)// custom shipping
            {
                //loop through shopping cart
                foreach (ZNodeShoppingCartItem cartItem in shoppingCart.ShoppingCartItems)
                {
                    decimal itemShippingCost = 0;

                    //get item vars
                    int quantity = cartItem.Quantity;
                    int shippingRuleTypeID = (int)cartItem.Product.ShippingRuleTypeID;
                    decimal productWeight = cartItem.Product.Weight;

                   
                    //Filter the rules collection based on shippingruletypeid    
                    TList<ShippingRule> filteredShippingRules = shRules.FindAll(ShippingRuleColumn.ShippingRuleTypeID, shippingRuleTypeID);

                    //foreach item, get shipping rule type
                    if (shippingRuleTypeID == 0)//Flat rate
                    {
                        foreach (ShippingRule rule in filteredShippingRules)
                        {
                            itemShippingCost = rule.BaseCost + (rule.PerItemCost * quantity);
                        }
                    }
                    else if (shippingRuleTypeID == 1)//Quantity
                    {
                        foreach (ShippingRule rule in filteredShippingRules)
                        {
                            if (quantity >= rule.LowerLimit && quantity <= rule.UpperLimit)
                            {
                                itemShippingCost = rule.BaseCost + (rule.PerItemCost * quantity);
                            }
                        }
                    }
                    else if (shippingRuleTypeID == 2)//Weight based rules
                    {
                        foreach (ShippingRule rule in filteredShippingRules)
                        {
                            if (productWeight >= rule.LowerLimit && productWeight <= rule.UpperLimit)
                            {
                                itemShippingCost = rule.BaseCost + (rule.PerItemCost * quantity);
                            }
                        }
                    }

                    //Calculate 

                    //set shipping cost in the cart
                    cartItem.ShippingCost = itemShippingCost;    
                }
                      
            }
            else if (shOption.ShippingTypeID == 2)// UPS shipping
            {
                //vars
                decimal itemShippingCost = 0;
                decimal productWeight = 0;

                productWeight = GetPackageWeight(shoppingCart);

                ZNode.Libraries.Integrator.Shipping.UPS UPS = new ZNode.Libraries.Integrator.Shipping.UPS();

                //Decrypt UPS account info
                ZNodeEncryption encrypt = new ZNodeEncryption();
                UPS.UPSUserID = encrypt.DecryptData(ZNodeConfigManager.SiteConfig.UPSUserName);
                UPS.UPSPassword = encrypt.DecryptData(ZNodeConfigManager.SiteConfig.UPSPassword);
                UPS.UPSKey = encrypt.DecryptData(ZNodeConfigManager.SiteConfig.UPSKey);
                
                //Set UPS general settings
                UPS.ShipperZipCode = ZNodeConfigManager.SiteConfig.ShippingOriginZipCode;
                UPS.ShipToZipCode = shoppingCart.ShippingAddress.PostalCode;
                UPS.ShipToCountryCode = shoppingCart.ShippingAddress.CountryCode;
                UPS.PackageWeight = productWeight;
                UPS.PackageTypeCode = "02"; //Package 
                UPS.UPSServiceCode = shOption.ShippingCode;
                UPS.PickupType = "06"; // One time pickup

                //Get rate from UPS based on total weight
                itemShippingCost = UPS.GetShippingRate();

                ResponseCode = UPS.ErrorCode;
                ResponseDescription = UPS.ErrorDescription;

                //set shipping cost in the cart
                shoppingCart.ShippingHandlingCharge  =  shoppingCart.ShippingHandlingCharge  + itemShippingCost; 
            }
            else if (shOption.ShippingTypeID == 3)// UPS shipping
            {
                //vars
                decimal itemShippingCost = 0;
                decimal packageWeight = 0;

                //Decrypt UPS account info
                ZNodeEncryption encrypt = new ZNodeEncryption();


                packageWeight = GetPackageWeight(shoppingCart);

                ZNode.Libraries.Integrator.Shipping.FedEx _shippingFedEx = new ZNode.Libraries.Integrator.Shipping.FedEx();

                //Set FedEx Account Info porperties
                _shippingFedEx.FedExAccessKey = encrypt.DecryptData(ZNodeConfigManager.SiteConfig.FedExProductionKey);
                _shippingFedEx.FedExAccountNumber = encrypt.DecryptData(ZNodeConfigManager.SiteConfig.FedExAccountNumber);
                _shippingFedEx.FedExMeterNumber = encrypt.DecryptData(ZNodeConfigManager.SiteConfig.FedExMeterNumber);
                _shippingFedEx.FedExSecurityCode = encrypt.DecryptData(ZNodeConfigManager.SiteConfig.FedExSecurityCode);

                ///Set Service type  settings
                _shippingFedEx.FedExServiceType = shOption.ShippingCode;
                _shippingFedEx.PackageTypeCode = ZNode.Libraries.Integrator.Shipping.PackagingType.YOUR_PACKAGING.ToString();
                _shippingFedEx.DropOffType = ZNode.Libraries.Integrator.Shipping.DropoffType.REGULAR_PICKUP.ToString();

                //Set Shipping Origin properties
                _shippingFedEx.ShipperZipCode = ZNodeConfigManager.SiteConfig.ShippingOriginZipCode;
                _shippingFedEx.ShipperStateCode = ZNodeConfigManager.SiteConfig.ShippingOriginStateCode;
                _shippingFedEx.ShipperCountryCode = ZNodeConfigManager.SiteConfig.ShippingOriginCountryCode;

                //set Destination properties
                _shippingFedEx.ShipToZipCode = shoppingCart.ShippingAddress.PostalCode;
                _shippingFedEx.ShipToStateCode = shoppingCart.ShippingAddress.StateCode;
                _shippingFedEx.ShipToCountryCode = shoppingCart.ShippingAddress.CountryCode;
                _shippingFedEx.ShipToAddressType = false; //Ship to residence

                //Set package Weight
                _shippingFedEx.PackageWeight = packageWeight;

                //Get rate from UPS based on total weight
                itemShippingCost = _shippingFedEx.GetShippingRate();

                ResponseCode = _shippingFedEx.ErrorCode;
                ResponseDescription = _shippingFedEx.ErrorDescription;

                //set shipping cost in the cart
                shoppingCart.ShippingHandlingCharge = shoppingCart.ShippingHandlingCharge + itemShippingCost;

            }
        }

        # region Helper Methods
        /// <summary>
        /// Returns the Total products weight
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        private decimal GetPackageWeight(ZNodeShoppingCart shoppingCart)
        {
            decimal productWeight = 0;

            //loop through shopping cart
            foreach (ZNodeShoppingCartItem cartItem in shoppingCart.ShoppingCartItems)
            {
                //get item vars
                int quantity = cartItem.Quantity;
                productWeight = productWeight + (cartItem.Product.Weight * quantity);
            }

            return productWeight;
        }
        #endregion
    }

}
