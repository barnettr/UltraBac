using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;

public partial class _DND_gm_test : System.Web.UI.Page
{

	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			Exception ex = null;
			bool isEligible = UBGoldMine.CheckUpgradeEligibility(uxEmail.Text, ref ex);
			uxResult.Text = isEligible.ToString();
			if (ex != null && !(ex is GoldmineUserNotFoundException))
			{
				uxResult.Text += "\r\n" + ex.ToString();
			}
		}
	}
}
