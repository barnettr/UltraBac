using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using POP.UltraBac;

public partial class _controls_error : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Exception ex = null;


		if (Server != null)
		{
			ex = Server.GetLastError();
		}

		if (
			ex != null &&
			(ex is CheckoutException ||
			ex.GetBaseException() is CheckoutException))
		{
			Session.RemoveAll();
			FormsAuthentication.SignOut();
			plhCheckoutError.Visible = true;
		}
		else
		{
			plhGeneralError.Visible = true;
		}
	}
}