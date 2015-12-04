using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;

public partial class Themes_Default_events_Event : System.Web.UI.MasterPage
{
	DateTime _startDate = new DateTime(2000, 1, 1);
	DateTime _endDate = new DateTime(3000, 1, 1);
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			CmsEventCollection events = new CmsEventCollection(_startDate, _endDate);
			events.Load();
			uxEvents.DataSource = events;
			uxEvents.DataBind();
		}
	}
}
