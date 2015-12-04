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

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// Specifies the supported gateways
    /// </summary>
    public enum GatewayType
    {
        /// <summary>
        /// Represents the custom gateway
        /// </summary>
        CUSTOM = 0,
        /// <summary>
        /// Represents the Authorize.NET gateway
        /// </summary>
        AUTHORIZE = 1,
        /// <summary>
        /// Represents the Paymentech Orbital gateway
        /// </summary>
        PAYMENTECH = 2,
        /// <summary>
        /// Represents the Verisign's PayFlow pro gateway
        /// </summary>
        VERISIGN = 3,
        /// <summary>
        /// Represents the Google's payment gateway
        /// </summary>
        GOOGLE = 4,
        /// <summary>
        /// Represents the Paypal's payment gateway
        /// </summary>
        PAYPAL = 5,        
        /// <summary>
        /// Represents the Verisign's Payflow pro Express Checkout
        /// </summary>
        VERISIGN_EC = 6,
        /// <summary>
        /// Represents the PSI payment gateway
        /// </summary>
        PSIGate = 7,
        /// <summary>
        /// Represents the NOVA payment gateway
        /// </summary>
        NOVA = 8,
        /// <summary>
        /// Represents the nSoftware Component
        /// </summary>
        nSoftware = 9,
    }
}
