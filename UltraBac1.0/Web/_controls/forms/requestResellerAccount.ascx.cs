using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_requestResellerAccount : System.Web.UI.UserControl
{
	CmsContext _context = new CmsContext();
	const string jsLocationChangedScriptBlock = "jsLocationChanged";

	#region Private Properties
	private string companyName
	{
		get { return txtCompanyName.Text; }
	}
	private string firstName
	{
		get { return txtFirstName.Text; }
	}
	private string lastName
	{
		get { return txtLastName.Text; }
	}
	private string title
	{
		get { return txtTitle.Text; }
	}
	private string phone
	{
		get { return txtPhone.Text; }
	}
	private string fax
	{
		get { return txtFax.Text; }
	}
	private string email
	{
		get { return txtEmail.Text; }
	}
	private string url
	{
		get { return txtURL.Text; }
	}
	private string address1
	{
		get { return txtAddress1.Text; }
	}
	private string address2
	{
		get { return txtAddress2.Text; }
	}
	private string city
	{
		get { return txtCity.Text; }
	}
	private string zip
	{
		get { return txtZip.Text; }
	}
	private string country
	{
		get { return ddlCountry.SelectedValue; }
	}
	private string state
	{
		get
		{
			if ( ddlState.SelectedValue == "-1" )
			{
				return txtState.Text;
			}
			else
			{
				return ddlState.SelectedValue;
			}
		}
	}
	private string annualRevenue
	{
		get { return txtAnnualRevenue.Text; }
	}
	private string numberOfLocations
	{
		get { return txtNumberOfLocations.Text; }
	}
	private string numberOfEmployees
	{
		get { return txtNumberOfEmployees.Text; }
	}
	private string coverage
	{
		get { return rblCoverage.SelectedValue; }
	}
	private string services
	{
		get
		{
			return FormInputUtils.GetMultiSelectChoices(cblServices, "", System.Environment.NewLine);
		}
	}
	private string operatingSystems
	{
		get
		{
			return FormInputUtils.GetMultiSelectChoices(cblOperatingSystems, txtOperatingSystemsOther.Text, System.Environment.NewLine);
		}
	}
	private string marketingVehicles
	{
		get
		{
			return FormInputUtils.GetMultiSelectChoices(cblMarketingVehicles, txtMarketingVehiclesOther.Text, System.Environment.NewLine);
		}
	}
	private string howHeard
	{
		get
		{
			return FormInputUtils.GetMultiSelectChoices(cblHowHeard, txtHowHeardOther.Text, System.Environment.NewLine);
		}
	}
	private string feedback
	{
		get { return txtFeedback.Text; }
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{

		if ( !IsPostBack )
		{
			string js = ClientScriptUtils.BuildLocationSelectionDHTMLScript(divStateDDL.ClientID, divStateTxt.ClientID, string.Empty);
			Page.ClientScript.RegisterStartupScript(typeof(Page), jsLocationChangedScriptBlock, js);
			ddlCountry.Attributes.Add("onchange", "setCountryOption(this);");
			BindCountry();
			BindState();
		}

	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{

		if ( Page.IsValid )
		{
			bool customerEmailSent = SendCustomerEmail();
			SendUltraBacEmail(customerEmailSent);

			plhThankYou.Visible = true;
			plhContact.Visible = false;
		}

	}

	protected void cvState_ServerValidate(object sender, ServerValidateEventArgs e)
	{
		// check for a state selection or value
		if ( ddlState.SelectedValue == "-1" && txtState.Text == string.Empty )
		{
			e.IsValid = false;
		}
	}

	protected void cvServices_ServerValidate(object sender, ServerValidateEventArgs e)
	{
		// check for a services selection
		e.IsValid = FormInputUtils.EvaluateRequiredMultiSelect(cblServices, "");
		
	}

	protected void cvOperatingSystems_ServerValidate(object sender, ServerValidateEventArgs e)
	{
		// check for an operating systems selection and other value, if selected
		e.IsValid = FormInputUtils.EvaluateRequiredMultiSelect(cblOperatingSystems, txtOperatingSystemsOther.Text);
	}

	protected void cvMarketingVehicles_ServerValidate(object sender, ServerValidateEventArgs e)
	{
		// check for a marketing vehicles selection and other value, if selected
		e.IsValid = FormInputUtils.EvaluateRequiredMultiSelect(cblMarketingVehicles, txtMarketingVehiclesOther.Text);
	}

	protected void cvHowHeard_ServerValidate(object sender, ServerValidateEventArgs e)
	{		
		// check for a how heard selection and other value, if selected
		e.IsValid = FormInputUtils.EvaluateRequiredMultiSelect(cblHowHeard, txtHowHeardOther.Text);
	}

	protected void validateCoverage_ServerValidate(object sender, ServerValidateEventArgs e)
	{
		e.IsValid = FormInputUtils.EvaluateRequiredMultiSelect(rblCoverage, "");
	}

	private void BindCountry()
	{
		CountryService countryServ = new CountryService();
		TList<Country> countries = countryServ.GetByPortalIDActiveInd(ZNodeConfigManager.SiteConfig.PortalID, true);
		countries.Sort("DisplayOrder,Name");

		ddlCountry.DataSource = countries;
		ddlCountry.DataTextField = "Name";
		ddlCountry.DataValueField = "Code";
		ddlCountry.DataBind();
	}

	private void BindState()
	{
		StateService stateServ = new StateService();
		TList<State> states = stateServ.GetAll();
		states.Sort("Name");

		ddlState.DataSource = states;
		ddlState.DataTextField = "Name";
		ddlState.DataValueField = "Code";
		ddlState.DataBind();
	}

	private bool SendCustomerEmail()
	{
		try
		{
			MessageTemplate msgTemplate = new MessageTemplate("RequestResellerAccountThankYou");
			PopEmailExtension.SendEmail(email, ZNodeConfigManager.SiteConfig.SalesEmail, "", msgTemplate.Subject, msgTemplate.Body, false);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void SendUltraBacEmail(bool customerEmailSent)
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("CONTACT INFORMATION");
		sb.AppendLine();
		sb.AppendFormat("Company:\t{0}\n", companyName);
		sb.AppendFormat("First Name:\t{0}\n", firstName);
		sb.AppendFormat("Last Name:\t{0}\n", lastName);
		sb.AppendFormat("Title:\t{0}\n", title);
		sb.AppendFormat("Phone:\t{0}\n", phone);
		sb.AppendFormat("Fax:\t{0}\n", fax);
		sb.AppendFormat("Email:\t{0}\n", email);
		sb.AppendFormat("URL:\t{0}\n", url);
		sb.AppendFormat("Address 1:\t{0}\n", address1);
		sb.AppendFormat("Address 2:\t{0}\n", address2);
		sb.AppendFormat("City:\t{0}\n", city);
		sb.AppendFormat("Zip:\t{0}\n", zip);
		sb.AppendFormat("State:\t{0}\n", state);
		sb.AppendFormat("Country:\t{0}\n", country);
		sb.AppendLine();
		sb.AppendLine("SURVEY RESPONSES");
		sb.AppendLine();
		sb.AppendFormat("Annual Revenue\t{0}\n\n", annualRevenue);
		sb.AppendFormat("Number of Locations\t{0}\n\n", numberOfLocations);
		sb.AppendFormat("Number of Employees at Location\t{0}\n\n", numberOfEmployees);
		sb.AppendFormat("Geographic Coverage\t{0}\n\n", coverage);
		sb.AppendFormat("What sales / service efforts generate your major customer revenue?\n{0}\n\n", services);
		sb.AppendFormat("Operating Systems\n{0}\n\n", operatingSystems);
		sb.AppendFormat("What types of marketing vehicles does your company use to promote products to your customers?\n{0}\n\n", marketingVehicles);
		sb.AppendFormat("How did you hear about the UltraBac Solution Provider Program?\n{0}\n\n", howHeard);
		sb.AppendFormat("What would you like to see included in our Solution Provider Program to make it more meaningful to you?\n{0}\n\n", feedback);
		sb.AppendLine();
		sb.AppendLine("Email successfully sent to customer?");
		sb.AppendLine(customerEmailSent ? "Yes" : "No");

		string subject = "Reseller Account Request Notification";
		if (string.IsNullOrEmpty(_context.CurrentPage.FormEmailRecipient))
		{
			PopEmailExtension.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
		}
		else
		{
			PopEmailExtension.SendEmail(_context.CurrentPage.FormEmailRecipient.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries), ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
		}
	}

}
