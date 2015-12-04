using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Holds Credit Card informations
    /// </summary>
    public interface ICreditCard
    {
        /// <summary>
        /// Retrieves or Sets the Credit card Number property 
        /// </summary>
        string CardNumber { get; set;} 
        /// <summary>
        /// Retrieves or Sets the Credit card expiration month property 
        /// </summary>
        string CardExpMonth { get; set;}        
        /// <summary>
        /// Retrieves or Sets the Credit card epiration year property 
        /// </summary>
        string CardExpYear { get; set;}
        /// <summary>
        /// Retrieves or Sets the Credit card security code property
        /// </summary>
        string CardSecurityCode { get; set;}       
    }
}

