using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _controls_forms_jpDownloadForm : FormControlBase
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void Submit_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			AddLine("Version", uxiam.SelectedValue);
			AddLine("First Name", firstname.Value);
			AddLine("Last Name", lastname.Value);
			AddLine("Organization", organization.Value);
			AddLine("Phone", phone.Value);
			AddLine("Fax", fax.Value);
			AddLine("Email", email.Value);
			AddLine("Address 1", address_1.Value);
			AddLine("Address 2", address_2.Value);
			AddLine("City", city.Value);
			AddLine("Zip", zip.Value);
			AddLine("Version 2", uxiaml.SelectedValue);
			AddLine("State", stateselect.Value);
			AddLine("Country", countryselect.Value);
			AddLine("Server", ntserver1.Value);
			AddLine("Prios", prios.Value);
			AddLine("Server 2", ntserver2.Value);
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			bool first = true;
			foreach (string val in uxcb.SelectedValues)
			{
				if (!first)
				{
					sb.Append(", ");
				} else
				{
					first = false;
				}
				sb.Append(val);
			}
			AddLine("Existing system", sb.ToString());
			AddLine("Other", buother1.Value);
			AddLine("Disaster Recovery", uxdisaster_rec.SelectedValue);
			AddLine("Reliability", uxreliability.SelectedValue);
			AddLine("Tech support", tech_support.Value);
			AddLine("Problems", problems.Value);
			AddLine("Found via", foundvia.Value);
			SendEmail();
			uxForm.Visible = false;
			uxMessage.Visible = true;
		}
	}
}
