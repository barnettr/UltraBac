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
    /// Specifies the Express Checkout Paypal/google gateway Action
    /// </summary>
    public enum ECGatewayAction
    {
        /// <summary>
        /// Initiate Express checkout transaction
        /// </summary>
        SetExpressCheckoutResponse = 1,
        /// <summary>
        /// Get information from Express checkout transaction
        /// </summary>
        GetExpressCheckoutDetailsResponse = 2,
        /// <summary>
        /// Complete an Express checkout transaction
        /// </summary>
        DoExpressCheckoutPaymentResponse = 3,
        /// <summary>
        /// Issue a refund for a PayPal transaction
        /// </summary>
        RefundTransaction = 4,
    }
}
