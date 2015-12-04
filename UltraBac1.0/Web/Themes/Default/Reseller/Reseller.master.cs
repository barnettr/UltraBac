using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;

public partial class Themes_Default_Reseller_Reseller : System.Web.UI.MasterPage
{
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		ResellerDb db = new ResellerDb(Config.ResellerConnectionString);
		db.EnsureResellerLogin(Request, Response, Session);
	}
}
