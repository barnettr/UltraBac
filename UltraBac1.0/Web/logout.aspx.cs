using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class logout : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Session.Abandon();
		FormsAuthentication.SignOut();
		Response.Redirect("~/");
	}
}
