﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data;

#endregion

namespace ZNode.Libraries.DataAccess.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ContentPageRevisionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ContentPageRevisionProviderBase : ContentPageRevisionProviderBaseCore
	{
	} // end class
} // end namespace
