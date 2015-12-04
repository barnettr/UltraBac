using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;

public partial class event2 : System.Web.UI.Page
{
	CmsEvent _ev;

	public bool HasLocation { get { return !string.IsNullOrEmpty(_ev.Location); } }
	public bool HasBooth { get { return !string.IsNullOrEmpty(_ev.Booth); } }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			try
			{
				int id = int.Parse(Request["event"]);
				_ev = new CmsEvent(id);
				LoadControls();
			}
			catch
			{
				Response.Redirect("~/");
			}
		}
	}

	private void LoadControls()
	{
		uxTitle.Text = _ev.Title;
		uxDates.Text = _ev.DisplayDate;
		uxLocation.Text = _ev.Location;
		uxBooth.Text = _ev.Booth;
		uxDetails.Text = _ev.Detail;
		if (!string.IsNullOrEmpty(_ev.ExternalLink))
		{
			uxLink.NavigateUrl = _ev.ExternalLink;
			uxLink.Text = "Event site";
		}
		else
		{
			uxLink.Visible = false;
		}
	}
}