using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using System.Globalization;

public partial class Admin_Secure_events_add : System.Web.UI.Page
{
	private int _itemId;

	public int ItemId
	{
		get { return _itemId;}
		set { _itemId = value;}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		// Get ItemId from querystring        
		if (Request.Params["itemid"] != null)
		{
			ItemId = int.Parse(Request.Params["itemid"]);
		}
		else
		{
			ItemId = 0;
		}

		if (!IsPostBack)
		{
			//if edit func then bind the data fields
			if (ItemId > 0)
			{
				lblTitle.Text = "Edit event";
				uxSubmit.Text = "Update event";
				FillControls();
			}
			else
			{
				lblTitle.Text = "Add event";
			}
			
		}
	}

	private void FillControls()
	{
		CmsEvent ev = new CmsEvent(ItemId);
		uxTitle.Text = ev.Title;
		uxStartDate.Text = ev.StartDate.ToString("MM/dd/yyyy");
		uxEndDate.Text = ev.EndDate.ToString("MM/dd/yyyy");
		uxLocation.Text = ev.Location;
		uxBooth.Text = ev.Booth;
		uxLink.Text = ev.ExternalLink;
		uxShortDescription.Text = ev.ShortDescription;
		uxDetail.Html = ev.Detail;		
	}

	protected void dates_ServerValidate(object source, ServerValidateEventArgs args)
	{
		CultureInfo enUS = new CultureInfo("en-US");

		DateTime start, end;
		if (DateTime.TryParseExact(uxStartDate.Text, new string[] {"%M/%d/yyyy", "MM/dd/yyyy", "MM-dd-yyyy" }, enUS, System.Globalization.DateTimeStyles.AllowLeadingWhite | System.Globalization.DateTimeStyles.AllowTrailingWhite, out start) &&
			DateTime.TryParseExact(uxEndDate.Text, new string[] { "%M/%d/yyyy", "MM/dd/yyyy", "MM-dd-yyyy" }, enUS, System.Globalization.DateTimeStyles.AllowLeadingWhite | System.Globalization.DateTimeStyles.AllowTrailingWhite, out end))
		{
			if (end < start)
			{ args.IsValid = false; }
		}
		else
		{
			args.IsValid = false;
		}
	}

	protected void uxCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("default.aspx?edit=false");
	}

	protected void uxSubmit_Click(object sender, EventArgs e)
	{
		if (IsValid)
		{
			DateTime startDate = DateTime.Parse(uxStartDate.Text);
			DateTime endDate = DateTime.Parse(uxEndDate.Text);
			CmsEvent ev;
			if (ItemId > 0)
			{
				ev = new CmsEvent(ItemId);
				ev.StartDate = startDate;
				ev.EndDate = endDate;
				ev.Title = uxTitle.Text;
				ev.Location = uxLocation.Text;
				ev.Booth = uxBooth.Text;
				ev.ShortDescription = uxShortDescription.Text;
				ev.Detail = uxDetail.Html;
				ev.ExternalLink = uxLink.Text;
				ev.Update();
			}
			else
			{
				ev = CmsEvent.Create(
					startDate,
					endDate,
					uxTitle.Text,
					uxLocation.Text,
					uxBooth.Text,
					uxShortDescription.Text,
					uxDetail.Html,
					uxLink.Text);
			}
			Response.Redirect(string.Format("default.aspx?{1}=true&id={0}", ev.Id, ItemId > 0 ? "edit" : "add"));
		}
	}
}
