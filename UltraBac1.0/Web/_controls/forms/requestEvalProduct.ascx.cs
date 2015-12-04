using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_requestEvalProduct : System.Web.UI.UserControl
{

	const string jsCountryChangedScriptBlock = "jsCountryChanged";

	#region Private Properties
	private string version
	{
		get { return rblVersion.SelectedValue; }
	}
	private string name
	{
		get { return txtName.Text; }
	}
	private string title
	{
		get { return txtTitle.Text; }
	}
	private string companyName
	{
		get { return txtCompanyName.Text; }
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
	private string phone
	{
		get { return txtPhone.Text; }
	}
	private string ext
	{
		get { return txtExt.Text; }
	}
	private string email
	{
		get { return txtEmail.Text; }
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{

		if ( !IsPostBack )
		{
			string js = ClientScriptUtils.BuildLocationSelectionDHTMLScript(divStateDDL.ClientID, divStateTxt.ClientID, string.Empty);
			Page.ClientScript.RegisterStartupScript(typeof(Page), jsCountryChangedScriptBlock, js);
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

			plhContact.Visible = false;
			plhThankYou.Visible = true;
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

	private void BindCountry()
	{
		CountryService countryServ = new CountryService();
		TList<Country> countries = countryServ.GetByPortalIDActiveInd(ZNodeConfigManager.SiteConfig.PortalID, true);
		countries.Sort("DisplayOrder,Name");

		ddlCountry.DataSource = countries;		
		ddlCountry.DataBind();
	}

	private void BindState()
	{
		StateService stateServ = new StateService();
		TList<State> states = stateServ.GetAll();
		states.Sort("Name");

		ddlState.DataSource = states;
		ddlState.DataBind();
	}

	private bool SendCustomerEmail()
	{
		try
		{
			MessageTemplate msgTemplate = new MessageTemplate("RequestEvaluationProductThankYou");
			ZNodeEmail.SendEmail(email, ZNodeConfigManager.SiteConfig.SalesEmail, "", msgTemplate.Subject, msgTemplate.Body, false);
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
		sb.AppendFormat("Version:\t{0}\n", version);
		sb.AppendFormat("Name:\t{0}\n", name);
		sb.AppendFormat("Title:\t{0}\n", title);
		sb.AppendFormat("Company:\t{0}\n", companyName);
		sb.AppendFormat("Address 1:\t{0}\n", address1);
		sb.AppendFormat("Address 2:\t{0}\n", address2);
		sb.AppendFormat("City:\t{0}\n", city);
		sb.AppendFormat("Zip:\t{0}\n", zip);
		sb.AppendFormat("State:\t{0}\n", state);
		sb.AppendFormat("Country:\t{0}\n", country);
		sb.AppendFormat("Phone:\t{0}\n", phone);
		sb.AppendFormat("Ext:\t{0}\n", ext);
		sb.AppendFormat("Email:\t{0}\n", email);
		sb.AppendLine();
		sb.AppendLine("Email successfully sent to customer?");
		sb.AppendLine(customerEmailSent ? "Yes" : "No");

		string subject = "Product Evaluation Request";
		ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);

	}

}
