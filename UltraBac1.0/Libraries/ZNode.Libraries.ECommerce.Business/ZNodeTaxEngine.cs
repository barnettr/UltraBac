using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.Framework.Business;
using System.ComponentModel;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to calculate tax rules
    /// </summary>
    public class ZNodeTaxEngine:ZNodeBusinessBase 
    {
        /// <summary>
        /// Calculates Sales Taxes based on destination address
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <param name="billingAddress"></param>
        public void CalculateTax(ref ZNodeShoppingCart shoppingCart, ZNodeAddress destinationAddress, int profileID)
        {
            decimal taxRate = 0;            
            string destinationCountry = destinationAddress.CountryCode;
            string destinationState = destinationAddress.StateCode;

            //get all tax rules
            TaxRuleService taxRuleSvc = new TaxRuleService();
            TList<TaxRule> taxRules = taxRuleSvc.GetByPortalID(ZNodeConfigManager.SiteConfig.PortalID);

            // Creates a new collection and assign it the properties for Shipping.
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(taxRules[0].GetType());

            // Sets an PropertyDescriptor to the specific property.
            System.ComponentModel.PropertyDescriptor myProperty = properties.Find("Precedence", false);

            //apply sorting based on precedence 
            taxRules.ApplySort(myProperty, System.ComponentModel.ListSortDirection.Ascending);

            //loop through tax rules and apply to cart based on precedence

            foreach (TaxRule rule in taxRules)
            {
                //check if this applies to all countries
                if (rule.DestinationCountryCode == null)
                {         
                   //check if this applies to all states
                   if (rule.DestinationStateCode == null)
                        {
                            taxRate = rule.TaxRate;
                        }
                   //check if this applies to specific state
                   else if (rule.DestinationStateCode.Equals(destinationAddress.StateCode))
                        {
                            taxRate = rule.TaxRate;                            
                        }
                 }
                if (rule.DestinationCountryCode == null)
                {
                    if (rule.DestinationCountryCode == destinationAddress.CountryCode)
                    {
                        if (rule.DestinationStateCode == null)
                        { 
                            taxRate = rule.TaxRate; 
                        }
                        else if (rule.DestinationStateCode.Equals(destinationAddress.StateCode))
                        {
                            taxRate = rule.TaxRate;
                            break;
                        }                        
                    }
                }
                if (rule.DestinationCountryCode != null)
                {
                    //check if this rule applies to the destination country
                    if (rule.DestinationCountryCode.Equals(destinationAddress.CountryCode))
                    {
                        //check if this applies to all states
                        if (rule.DestinationStateCode != null)
                        {
                            //check if this applies to specific state
                            if (rule.DestinationStateCode.Equals(destinationAddress.StateCode))
                            {
                                taxRate = rule.TaxRate;
                                break;
                            }
                        }
                        if (rule.DestinationStateCode == null)
                        {
                            taxRate = rule.TaxRate;
                        }                        
                    }
                }
            }

            //set shopping cart tax
            shoppingCart.TaxRate = taxRate;                     
                
            }                
        }
    }

