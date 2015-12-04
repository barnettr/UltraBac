using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _controls_search : System.Web.UI.UserControl
{
	private bool _populateSearchTerm = true;

	public bool PopulateSearchTerm
	{
		get { return _populateSearchTerm; }
		set { _populateSearchTerm = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack && PopulateSearchTerm && Request["q"] != null)
		{
			txtSearchTerm.Text = Server.UrlDecode(Request["q"]);
		}
		if (IsPostBack)
		{
			Response.Redirect(string.Format("~/search.aspx?q={0}", Server.UrlEncode(txtSearchTerm.Text)));
		}
	}	
}
