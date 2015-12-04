using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;

public partial class resellerLogin : System.Web.UI.Page
{
	string _returnUrl;

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		_returnUrl = Request["returnUrl"] as string;
		
	}

	protected void uxSubmit_Click(object sender, EventArgs e)
	{
		ResellerDb db = new ResellerDb(Config.ResellerConnectionString);

		if (IsValid && db.ValidateReseller(uxEmail.Text, uxPassword.Text, Session))
		{
			Response.Redirect(_returnUrl);
		}
		else
		{
			uxError.Visible = true;
		}
	}
}