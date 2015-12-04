using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ZNode.Libraries.Integrator
{

    /// <summary>    
    /// Summary description for DefaultTaxRule.    
    /// </summary>
    public class TaxRuleCollection
    {
        /// <summary>
        /// Holds the collection of DefaultTaxRule object
        /// </summary>
        private ArrayList _taxRules = new ArrayList();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaxRuleCollection() 
        {
            _taxRules = new ArrayList();
        }

        # region Public Methods
                
        /// <summary>        
        /// Create a new DefaultTaxRule
        /// This method adds a tax rule associated with a particular state
        /// </summary>
        /// <param name="StateAreaCode"></param>
        /// <param name="TaxRate"></param>
        public void AddRule(Google.USStateArea StateAreaCode, double TaxRate)
        {
            Google.DefaultTaxRule _taxRule = new Google.DefaultTaxRule();
            _taxRule.rate = TaxRate;
            _taxRule.taxarea = new Google.DefaultTaxRuleTaxarea();            
            _taxRule.taxarea.Item = StateAreaCode;
                        
            _taxRules.Add(_taxRule);
        }

        /// <summary>
        /// This method adds a tax rule associated with a zip code pattern.
        /// </summary>
        /// <param name="PostalCode"></param>
        /// <param name="TaxRate"></param>
        /// <param name="IsShippingTaxed"></param>
        public void AddRule(Google.USZipArea PostalCode, double TaxRate, bool IsShippingTaxed)
        {
            Google.DefaultTaxRule _taxRule = new Google.DefaultTaxRule();
            _taxRule.rate = TaxRate;
            _taxRule.taxarea = new Google.DefaultTaxRuleTaxarea();
            _taxRule.taxarea.Item = PostalCode;
            _taxRule.shippingtaxed = IsShippingTaxed;
            _taxRules.Add(_taxRule);
        }

        /// <summary>        
        /// This method adds a tax rule associated with a zip code pattern.        
        /// </summary>
        /// <param name="USAreaCode"></param>
        /// <param name="TaxRate"></param>
        public void AddRule(Google.USAreas USAreaCode, double TaxRate)
        {
            Google.DefaultTaxRule _taxRule = new Google.DefaultTaxRule();
            _taxRule.rate = TaxRate;
            _taxRule.taxarea = new Google.DefaultTaxRuleTaxarea();
            _taxRule.taxarea.Item = USAreaCode.ToString();

            _taxRules.Add(_taxRule);
        }

        /// <summary>
        /// Returns the no of items in the list
        /// </summary>
        /// <returns></returns>
        public int GetItemsCount()
        {
            return _taxRules.Count;
        }

        /// <summary>
        /// Returns the Current Tax Rule for this Index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Google.DefaultTaxRule GetByIndex(int i)
        {
            return (Google.DefaultTaxRule)_taxRules[i] as Google.DefaultTaxRule;
        }

        # endregion
    }
}
