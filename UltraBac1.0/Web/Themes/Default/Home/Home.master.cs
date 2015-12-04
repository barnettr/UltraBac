using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for Home
/// </summary>
public partial class Themes_Default_Common_main : MasterPage
{
	protected override void OnInit(EventArgs e)
	{
		SecurityUtility.EnsureInsecure(Request, Response);
		base.OnInit(e);		
	}

}
