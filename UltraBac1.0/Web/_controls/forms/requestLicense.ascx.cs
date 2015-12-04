using System;
using System.Text;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_requestLicense : System.Web.UI.UserControl
{
	#region Private Properties
	private string email
	{
		get { return txtEmail.Text; }
	}
	private string companyName
	{
		get { return txtCompanyName.Text; }
	}
	private string customerNumber
	{
		get { return txtCustomerNumber.Text; }
	}
	private string firstName
	{
		get { return txtFirstName.Text; }
	}
	private string lastName
	{
		get { return txtLastName.Text; }
	}
	private string phone
	{
		get { return txtPhone.Text; }
	}
	private string poNumber
	{
		get { return txtPONumber.Text; }
	}
	private string version
	{
		get { return rblVersion.SelectedValue; }
	}
	private string computerName
	{
		get { return txtComputerName.Text; }
	}
	private string licenseType
	{
		get { return rblLicenseType.SelectedValue; }
	}
	private string comments
	{
		get { return txtComments.Text; }
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
		sb.AppendFormat("Email:\t{0}\n", email);
		sb.AppendFormat("Company:\t{0}\n", companyName);
		sb.AppendFormat("Customer Number:\t{0}\n", customerNumber);
		sb.AppendFormat("First Name:\t{0}\n", firstName);
		sb.AppendFormat("Last Name:\t{0}\n", lastName);
		sb.AppendFormat("Phone:\t{0}\n", phone);
		sb.AppendFormat("PO Number:\t{0}\n", poNumber);
		sb.AppendFormat("Version:\t{0}\n", version);
		sb.AppendFormat("Computer Name:\t{0}\n", computerName);
		sb.AppendFormat("License Type:\t{0}\n", licenseType);
		sb.AppendLine();
		sb.AppendFormat("Comments:\n{0}\n\n", comments);
		sb.AppendLine();

		string subject = "License Request";
		ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);

	}

}
