using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _controls_forms_licensingVolume : FormControlBase
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void Submit_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			AddLine("Name", nameInput.Value);
			AddLine("Title", titleInput.Value);
			AddLine("Company", companyInput.Value);
			AddLine("Address", addressInput.Value);
			AddLine("Address2", address2Input.Value);
			AddLine("State", stateprovinceInput.Value);
			AddLine("Zip", zippostalcodeInput.Value);
			AddLine("Country", countryInput.Value);
			AddLine("Phone", phoneInput.Value);
			AddLine("Extension", extensionInput.Value);
			AddLine("Email", emailInput.Value);
			AddLine("No. of Servers", serversInput.Value);
			AddLine("Comments", commentsInput.Value);
			SendEmail();
			uxForm.Visible = false;
			uxMessage.Visible = true;
		}
	}
}