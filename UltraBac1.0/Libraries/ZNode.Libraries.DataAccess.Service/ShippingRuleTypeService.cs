	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Entities.Validation;

using ZNode.Libraries.DataAccess.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace ZNode.Libraries.DataAccess.Service
{		
	
	///<summary>
	/// An component type implementation of the 'ZNodeShippingRuleType' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ShippingRuleTypeService : ZNode.Libraries.DataAccess.Service.ShippingRuleTypeServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ShippingRuleTypeService class.
		/// </summary>
		public ShippingRuleTypeService() : base()
		{
		}
		
	}//End Class


} // end namespace
