using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;

public partial class Admin_Secure_events_delete : System.Web.UI.Page
{
	private int _itemId;

	public int ItemId
	{
		get { return _itemId;}
		set { _itemId = value;}
	}

	private string _eventTitle;

	public string EventTitle
	{
		get { return _eventTitle; }
		set { _eventTitle = value; }
	}
	
	
	protected void Page_Load(object sender, EventArgs e)
	{
		ItemId = int.Parse(Request["itemid"]);
		if (!IsPostBack)
		{
			
			CmsEvent ev = new CmsEvent(ItemId);
			EventTitle = ev.Title;
		}

		btnCancel.Click += new EventHandler(btnCancel_Click);
		btnDelete.Click += new EventHandler(btnDelete_Click);
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		CmsEvent ev = new CmsEvent(ItemId);
		ev.Delete();
		Response.Redirect("default.aspx?delete=true");

	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Response.Redirect("default.aspx?delete=false");
	}
}
