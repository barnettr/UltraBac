using System;
using System.Text;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_requestSupport : System.Web.UI.UserControl
{
	#region Private Properties
	private string companyName
	{
		get { return txtCompanyName.Text; }
	}
	private string customerNumber
	{
		get { return txtCustomerNumber.Text; }
	}
	private string email
	{
		get { return txtEmail.Text; }
	}
	private string contactName
	{
		get { return txtContactName.Text; }
	}
	private string phone
	{
		get { return txtPhone.Text; }
	}
	private string version
	{
		get { return txtVersion.Text; }
	}
	private string buildDate
	{
		get { return txtBuildDate.Text; }
	}
	private string operatingSystem
	{
		get { return ddlOperatingSystem.SelectedValue; }
	}
	private string servicePacks
	{
		get { return txtServicePacks.Text; }
	}
	private string tapeDrive
	{
		get { return txtTapeDrive.Text; }
	}
	private string shortDescription
	{
		get { return txtShortDescription.Text; }
	}
	private string problem
	{
		get { return txtProblem.Text; }
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{

		SendUltraBacEmail();

		plhContact.Visible = false;
		plhThankYou.Visible = true;

	}

	private void SendUltraBacEmail()
	{

		StringBuilder sb = new StringBuilder();
		sb.AppendFormat("Company:\t{0}\n", companyName);
		sb.AppendFormat("Customer Number:\t{0}\n", customerNumber);
		sb.AppendFormat("Email:\t{0}\n", email);
		sb.AppendFormat("Contact:\t{0}\n", contactName);
		sb.AppendFormat("Phone:\t{0}\n", phone);
		sb.AppendFormat("Version:\t{0}\n", version);
		sb.AppendFormat("Build Date:\t{0}\n", buildDate);
		sb.AppendFormat("Operating System:\t{0}\n", operatingSystem);
		sb.AppendFormat("Service Packs:\t{0}\n", servicePacks);
		sb.AppendFormat("Tape Drive:\t{0}\n", tapeDrive);
		sb.AppendLine();
		sb.AppendFormat("Short Description:\n{0}\n\n", shortDescription);
		sb.AppendFormat("Problem or Question:\n{0}\n\n", problem);
		sb.AppendLine();

		string subject = "Technical Support Request";
		ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);

	}

}
