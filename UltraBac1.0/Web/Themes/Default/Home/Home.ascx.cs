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
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Custom;

public partial class Themes_Default_Home_Home : System.Web.UI.UserControl
{

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		lblHtml.Text = ZNodeContentManager.GetPageHTMLByName("home", true);
	}

}
