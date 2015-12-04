using System;
using System.Collections.Generic;
using System.Text;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Specifies the status of the Order
    /// </summary>
    public enum ZNodeOrderState 
    { 
        /// <summary>
        /// Represents that order is not yet started.
        /// </summary>
        NotStarted = 0, 
        /// <summary>
        /// Represents that order is pending for payment.
        /// </summary>
        PendingPayment = 1, 
        /// <summary>
        /// Represents that order is submitted (ready for Shipping)
        /// </summary>
        Submitted = 2, 
        /// <summary>
        /// Represents that order is shipped
        /// </summary>
        Shipped = 3  
    };
}
