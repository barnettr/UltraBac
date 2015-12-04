using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _controls_forms_licensingForm : FormControlBase
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void Submit_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			AddLine("Email Address", emailInput.Value);
			AddLine("Name of Company", companyInput.Value);
			AddLine("Customer Number", customernumberInput.Value);
			AddLine("Last Name", lastnameInput.Value);
			AddLine("First Name", firstnameInput.Value);
			AddLine("Phone Number", phoneInput.Value);
			AddLine("P.O. Number", ponumberInput.Value);
			AddLine("UltraBac Version", versionInput.SelectedValue);
			AddLine("Computer Name", computernameInput.Value);
			AddLine("Licensing Type", licenseInput.Value);
			AddLine("Comments", commentsInput.Value);
			SendEmail();
			uxForm.Visible = false;
			uxMessage.Visible = true;
		}
	}
}
