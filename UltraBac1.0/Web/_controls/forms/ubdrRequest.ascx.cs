using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _controls_forms_ubdrRequest : FormControlBase
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void Submit_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			AddLine("Product Type", ubdrProductType.SelectedValue);
			AddLine("Name", nameInput.Value);
			AddLine("Title", titleInput.Value);
			AddLine("Company", companyInput.Value);
			AddLine("Address", address1Input.Value);
			AddLine("Address 2", address2Input.Value);
			AddLine("City", cityInput.Value);
			AddLine("State/Province", stateInput.Value);
			AddLine("Zip/Mail Code", zipInput.Value);
			AddLine("Country", countryInput.Value);
			AddLine("Phone", phoneInput.Value);
			AddLine("Extension", extensionInput.Value);
			AddLine("Email", emailInput.Value);
			SendEmail();
			uxForm.Visible = false;
			uxMessage.Visible = true;
		}
	}
}