using System;
using System.Collections.Generic;
using System.Text;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents an exception thrown when attempting to pass payment gateway.
    /// </summary>
    public class ZNodePaymentException : System.Exception 
    {
        /// <summary>
        /// Represents an payment exception 
        /// </summary>
        /// <param name="message"></param>
        public ZNodePaymentException(string message) : base(message)
        {
        }

    }
}
