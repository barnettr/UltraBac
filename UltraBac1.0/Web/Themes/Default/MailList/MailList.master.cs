using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Themes_Default_MailList_MailList : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		SecurityUtility.EnsureSecure(Request, Response);
	}
}
