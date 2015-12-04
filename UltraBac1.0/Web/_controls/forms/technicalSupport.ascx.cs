using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_technicalSupport : System.Web.UI.UserControl
{
	private CmsContext _context = new CmsContext();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			Page.Validate();
			if (Page.IsValid)
			{
				SendUltraBacEmail();
				uxForm.Visible = false;
				uxConfirmation.Visible = true;
			}
		}
	}

	private void SendUltraBacEmail()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("CONTACT INFORMATION");
		AddFormItem(sb, "Company Name", companyInput.Value);
		AddFormItem(sb, "Customer Number", customerNumberInput.Value);
		AddFormItem(sb, "Contact Name", contactInput.Value);
		AddFormItem(sb, "Email", emailInput.Value);
		AddFormItem(sb, "Phone Number", phoneInput.Value);
		AddFormItem(sb, "Build Date", buildDateInput.Value);
		AddFormItem(sb, "OS", osInput.Value);
		AddFormItem(sb, "Service Packs", servicePacksInput.Value);
		AddFormItem(sb, "Tape Drive", tapeDriveInput.Value);
		AddFormItem(sb, "Version Number", versionNumberInput.Value);
		AddFormItem(sb, "Short Description", shortDescriptionInput.Value);
		AddFormItem(sb, "Problem", problemInput.Text);
		string subject = string.Format("Technical Support Request: {0}", shortDescriptionInput.Value);
		if (string.IsNullOrEmpty(_context.CurrentPage.FormEmailRecipient))
		{
			ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
		}
		else
		{
			string[] emailAddresses = _context.CurrentPage.FormEmailRecipient.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			PopEmailExtension.SendEmail(emailAddresses, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
		}
	}

	private static void AddFormItem(StringBuilder sb, string formName, string formValue)
	{
		sb.AppendFormat("{0}: {1}\n", formName, formValue);
	}
}
