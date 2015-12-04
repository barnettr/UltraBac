using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_downloadUpgrade : System.Web.UI.UserControl
{

	#region Private Properties
	private CmsContext _cmsContext = new CmsContext();
	//private string _currentVersion
	//{
	//  get { return rblVersion.SelectedValue; }
	//}
	private string _firstName
	{
		get { return txtFirstName.Text; }
	}
	private string _lastName
	{
		get { return txtLastName.Text; }
	}
	private string _email
	{
		get { return txtEmail.Text; }
	}
	private bool _isDownloadAuthorized
	{
		get { return Session["UpgradeDownloadIsAuthorized"] != null; }
		set { Session["UpgradeDownloadIsAuthorized"] = value.ToString(); }
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		ErrorMessage.Visible = false;
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		// if user is a valid customer, send message to customer and to UltraBac and show download link
		// make a call to the UltraBac customer eligibility script

		try
		{
			Exception ex = null;
			bool isEligible = UBGoldMine.CheckUpgradeEligibility(_email, ref ex);

			if (ex != null)
			{
				throw ex;
			}
			// evaluate the response and take action as needed
			if (!isEligible)
			{
				RedirectToTrialPage();
				//plhCustomerNotFound.Visible = true;
				//// customer was not found
				//lblNotFoundMsg.Text = "You are not eligible for the upgrade.";

			}
			else
			{
				bool customerEmailSent = SendCustomerEmail();
				RecordDownload(_email);
				SendUltraBacEmail(customerEmailSent);

				_isDownloadAuthorized = true;
				plhDownloadLink.Visible = true;
			}
		}
		catch
		{
			// some other customer check error
			plhCustomerNotFound.Visible = true;
			// customer was not found
			lblNotFoundMsg.Text = "We are unable to verify that you are an UltraBac customer.";
		}
		finally
		{
			plhContact.Visible = false;
		}
	}

	private bool RecordDownload(string email)
	{
		try
		{
			Exception ex = null;
			UBGoldMine.RecordDownload(email, _cmsContext.CurrentProduct.SKU, ref ex);
			if (ex == null)
			{
				return true;
			}
		}
		catch { }
		return false;
	}

	protected void btnDownloadNow_Click(object sender, EventArgs e)
	{
		string downloadPath = Server.MapPath("~/App_Data/downloads/");
		string fileName = Config.UpgradeDownloadFileName;

		if ( _isDownloadAuthorized )
		{
			try
			{
				// stream download file to user
				FileStream fs;
				fs = File.Open(string.Concat(downloadPath, fileName), FileMode.Open, FileAccess.Read);
				byte[] fileData = new byte[fs.Length];
				fs.Read(fileData, 0, (int)fs.Length);
				fs.Close();
				Response.AddHeader("Content-disposition", string.Format("attachment; filename={0}", fileName));
				Response.ContentType = "application/octet-stream";
				Response.BinaryWrite(fileData);
				Response.End();
			}
			catch (System.Threading.ThreadAbortException) { /* Good News! Response.End() will throw this error, which means the download was successful */ }
			catch
			{
				DownloadMessage.Visible = false;
				lblDownloadErrorPh.Visible = true;
			}
		}
		else
		{
			ErrorMessage.Text = "Please fill out the form below in order for us to determine your eligibility for this upgrade.";
			ErrorMessage.Visible = true;
			plhContact.Visible = true;
			plhDownloadLink.Visible = false;
		}
	}

	protected void btnGoToTrialDownload_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			RedirectToTrialPage();
		}
	}

	private void RedirectToTrialPage()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append("~/content.aspx?page=download-trial&upg_xfr=true&");
		sb.AppendFormat("first_name={0}&", Server.UrlEncode(txtFirstName.Text));
		sb.AppendFormat("last_name={0}&", Server.UrlEncode(txtLastName.Text));
		sb.AppendFormat("email={0}", Server.UrlEncode(txtEmail.Text));
		string productId = Request["pid"];
		if (!string.IsNullOrEmpty(productId))
		{
			sb.AppendFormat("&pid={0}", Server.UrlEncode(productId));
		}
		Response.Redirect(sb.ToString(), true);
	}

	private bool SendCustomerEmail()
	{
		try
		{
			MessageTemplate msgTemplate = new MessageTemplate("DownloadUpgradeThankYou");
			ZNodeEmail.SendEmail(_email, ZNodeConfigManager.SiteConfig.SalesEmail, "", msgTemplate.Subject, msgTemplate.Body, false);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void SendUltraBacEmail(bool customerEmailSent)
	{
		try
		{
			StringBuilder sb = new StringBuilder();
			if (_cmsContext.CurrentProduct != null)
			{
				sb.AppendFormat("Requested Product: {0}:{1}\n\n", _cmsContext.CurrentProduct.SKU, _cmsContext.CurrentProduct.Name);
				sb.AppendLine();
			}
			//sb.AppendLine("CURRENT VERSION");
			//sb.AppendLine();
			//sb.AppendFormat("{0}\n", _currentVersion);
			sb.AppendLine();
			sb.AppendLine("CONTACT INFORMATION");
			sb.AppendLine();
			sb.AppendFormat("First Name:\t{0}\n", _firstName);
			sb.AppendFormat("Last Name:\t{0}\n", _lastName);
			sb.AppendFormat("Email:\t{0}\n", _email);
			sb.AppendLine();

			try
			{
				GoldmineUserRecord record = GoldmineUserRecord.LoadUser(_email);
				sb.AppendLine("GOLDMINE ACCOUNT INFORMATION");
				sb.Append(record.ToString());
			}
			catch { }
			sb.AppendLine("Email successfully sent to customer?");
			sb.AppendLine(customerEmailSent ? "Yes" : "No");

			string subject = "Upgrade Download Notification";
			ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
		}
		catch
		{
			// do nothing
		}
	}

}
