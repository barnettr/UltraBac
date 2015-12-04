using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_downloadTrialProduct : System.Web.UI.UserControl
{

	const string _jsLocationChangedScriptBlock = "jsLocationChanged";

	#region Private Properties
	private CmsContext _cmsContext = new CmsContext();
	private string _orgType
	{
		get { return rblOrgType.SelectedValue; }
	}
	private string _firstName
	{
		get { return txtFirstName.Text; }
	}
	private string _lastName
	{
		get { return txtLastName.Text; }
	}
	private string _companyName
	{
		get { return txtCompanyName.Text; }
	}
	private string _phone
	{
		get { return txtPhone.Text; }
	}
	private string _fax
	{
		get { return txtFax.Text; }
	}
	private string _email
	{
		get { return txtEmail.Text; }
	}
	private string _address1
	{
		get { return txtAddress1.Text; }
	}
	private string _address2
	{
		get { return txtAddress2.Text; }
	}
	private string _city
	{
		get { return txtCity.Text; }
	}
	private string _zip
	{
		get { return txtZip.Text; }
	}
	private string _locatedIn
	{
		get { return rblLocatedIn.SelectedValue; }
	}
	private string _country
	{
		get { return ddlCountry.SelectedValue; }
	}
	private string _state
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
	private string _howManyServers
	{
		get { return txtHowManyServers.Text; }
	}
	private string _primaryServerOS
	{
		get { return txtPrimaryServerOS.Text; }
	}
	private string _howManyBackupServers
	{
		get { return txtHowManyBackupServers.Text; }
	}
	private string _backupProducts
	{
		get
		{
			return FormInputUtils.GetMultiSelectChoices(cblBackupProducts, txtBackupProductsOther.Text, System.Environment.NewLine);
		}
	}
	private string _isDisasterRecoveryIssue
	{
		get
		{
			if ( rblIsDisasterRecoveryIssue.SelectedIndex != -1 )
			{
				return rblIsDisasterRecoveryIssue.SelectedValue;
			}
			else
			{
				return string.Empty;
			}
		}
	}
	private string _haveReliabilityProblems
	{
		get
		{
			if ( rblHaveReliabilityProblems.SelectedIndex != -1 )
			{
				return rblHaveReliabilityProblems.SelectedValue;
			}
			else
			{
				return string.Empty;
			}
		}
	}
	private string _techSupportRating
	{
		get
		{
			if ( ddlTechSupportRating.SelectedValue != "-1" )
			{
				return ddlTechSupportRating.SelectedValue;
			}
			else
			{
				return string.Empty;
			}
		}
	}
	private string _otherProblems
	{
		get { return txtOtherProblems.Text; }
	}
	private string _foundUltraBacVia
	{
		get
		{
			if ( ddlFoundUltraBacVia.SelectedValue != "-1" )
			{
				return ddlFoundUltraBacVia.SelectedValue;
			}
			else
			{
				return string.Empty;
			}
		}
	}
	private bool _isDownloadAuthorized
	{
		get { return Session["TrialDownloadIsAuthorized"] != null; }
		set { Session["TrialDownloadIsAuthorized"] = value.ToString(); }
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{

		ErrorMessage.Visible = false;

		if ( !IsPostBack )
		{
			string js = ClientScriptUtils.BuildLocationSelectionDHTMLScript(divStateDDL.ClientID, divStateTxt.ClientID, ddlCountry.ClientID);
			Page.ClientScript.RegisterStartupScript(typeof(Page), _jsLocationChangedScriptBlock, js);
			foreach ( ListItem li in rblLocatedIn.Items )
			{
				li.Attributes.Add("onclick", "setCountryOption(this);");
			}
			BindCountry();
			BindState();
			BindLeadSources();

			// if user was transferred from upgrade form, grab what values we can
			if ( Request["upg_xfr"] == "true" )
			{
				upgradeRedirectMessage.Visible = true;
				if ( Request["first_name"] != null )
				{
					txtFirstName.Text = Request["first_name"];
				}
				if ( Request["last_name"] != null )
				{
					txtLastName.Text = Request["last_name"];
				}
				if ( Request["email"] != null )
				{
					txtEmail.Text = Request["email"];
				}
				
			}

		}

	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{

		if ( Page.IsValid )
		{
			bool customerEmailSent = SendCustomerEmail();
			SendUltraBacEmail(customerEmailSent);

			_isDownloadAuthorized = true;
			lblTrialKey.Text = Config.TrialLicenseKey;
			lblTrialKey.Visible = true;
			plhDownloadLink.Visible = true;
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

	private void BindLeadSources()
	{
		string filePath = "~/App_Data/LeadSources.xml";

		DataSet ds = new DataSet();
		ds.ReadXml(Server.MapPath(filePath));
		ddlFoundUltraBacVia.DataSource = ds;
		ddlFoundUltraBacVia.DataBind();
	}

	protected void btnDownloadNow_Click(object sender, EventArgs e)
	{
		FileStream fs;
		string downloadPath = Server.MapPath("~/App_Data/downloads/");
		string fileName = Config.TrialDownloadFileName;

		if ( _isDownloadAuthorized )
		{
			try
			{
				fs = File.Open(string.Concat(downloadPath + fileName), FileMode.Open, FileAccess.Read);
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
				// Bad news, you probably have an UnauthorizedAccess 
				lblDownloadError.Text = "The server is unable to initiate your download. For assistance, please contact UltraBac directly.";
				lblDownloadError.Visible = true;
			}
		}
		else
		{
			ErrorMessage.Text = "To be eligible for a trial download, you must fill out the form below.";
			ErrorMessage.Visible = true;
			plhContact.Visible = true;
			plhDownloadLink.Visible = false;
		}
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
			MessageTemplate msgTemplate = new MessageTemplate("DownloadTrialProductThankYou");
			string body = msgTemplate.Body.Replace("[LICENSE_KEY]", Config.TrialLicenseKey);
			ZNodeEmail.SendEmail(_email, ZNodeConfigManager.SiteConfig.SalesEmail, "", msgTemplate.Subject, body, false);
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
		if (_cmsContext.CurrentProduct != null)
		{
			sb.AppendFormat("Requested Product: {0}:{1}\n\n", _cmsContext.CurrentProduct.SKU, _cmsContext.CurrentProduct.Name);
			sb.AppendLine();
		}
		sb.AppendLine("CONTACT INFORMATION");
		sb.AppendLine();
		sb.AppendFormat("Org. Type:\t{0}\n", _orgType);
		sb.AppendFormat("First Name:\t{0}\n", _firstName);
		sb.AppendFormat("Last Name:\t{0}\n", _lastName);
		sb.AppendFormat("Company:\t{0}\n", _companyName);
		sb.AppendFormat("Phone:\t{0}\n", _phone);
		sb.AppendFormat("Fax:\t{0}\n", _fax);
		sb.AppendFormat("Email:\t{0}\n", _email);
		sb.AppendFormat("Address 1:\t{0}\n", _address1);
		sb.AppendFormat("Address 2:\t{0}\n", _address2);
		sb.AppendFormat("City:\t{0}\n", _city);
		sb.AppendFormat("Zip:\t{0}\n", _zip);
		sb.AppendFormat("State:\t{0}\n", _state);
		sb.AppendFormat("Country:\t{0}\n", _country);
		sb.AppendFormat("Located In:\t{0}\n", _locatedIn);
		sb.AppendLine();
		sb.AppendLine("SURVEY RESPONSES");
		sb.AppendLine();
		sb.AppendFormat("How many Windows-based servers do you have?\n{0}\n\n", _howManyServers);
		sb.AppendFormat("Primary Server OS (NT4.0, Win2000, Win2003)\n{0}\n\n", _primaryServerOS);
		sb.AppendFormat("How many Windows-based servers do you use for backup?\n{0}\n\n", _howManyBackupServers);
		sb.AppendFormat("What product(s) do you use for backup?\n{0}\n\n", _backupProducts);
		sb.AppendFormat("Is disaster recovery an issue for your company, separate from your regular backup solution?\n{0}\n\n", _isDisasterRecoveryIssue);
		sb.AppendFormat("Does your current Windows-based backup software have any backup or restore reliability problems?\n{0}\n\n", _haveReliabilityProblems);
		sb.AppendFormat("How would you rate the quality of your current backup software's tech support?\n{0}\n\n", _techSupportRating);
		sb.AppendFormat("Is your company experiencing any other significant backup problems?\n{0}\n\n", _otherProblems);
		sb.AppendFormat("I found UltraBac via\n{0}\n\n", _foundUltraBacVia);
		sb.AppendLine();
		sb.AppendLine("Email successfully sent to customer?");
		sb.AppendLine(customerEmailSent ? "Yes" : "No");

		string subject = "Trial Product Download Notification";
		ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
	}

}
