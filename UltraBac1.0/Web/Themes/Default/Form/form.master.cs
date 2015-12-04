using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZNode.Libraries.Framework.Business;
using System.Configuration;

public partial class Themes_Default_Form_form : MasterPage
{

	CmsContext _context = new CmsContext();
	private bool _customFormFound = false;

	protected bool _requireSsl = true;

	/// <summary>
	/// If true, this ensures that the Request.IsSecureConnection == true. The property must be 
	/// set prior to the load event, or it will be ignored. The default value is true.
	/// </summary>
	public bool RequireSsl
	{
		get { return _requireSsl; }
		set { _requireSsl = value; }
	}

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);		
		if (_context.CurrentPage != null)
		{
			TryLoadCustomForm();
		}
	}

	private void TryLoadCustomForm()
	{
		Control form = null;
		string controlPath = FormManager.Default[_context.CurrentPage.Name.ToLower()];
		if (!string.IsNullOrEmpty(controlPath))
		{
			form = this.LoadControl(controlPath);
		}
		if (form != null)
		{
			_customFormFound = true;
			MainContent.Controls.Add(form);
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (RequireSsl)
		{
			SecurityUtility.EnsureSecure(Request, Response);
		}

		/// custom forms can handle their own emails according to business rules,
		/// standard forms will use this general form scraper to get values
		if (IsPostBack && !_customFormFound)
		{
			try
			{
				string emailtext = FormOutputUtils.GetFormattedFormValues(Request);
				string subject = string.Format("UltraBac.com form submission: {0}", _context.CurrentPage.Title);
				if (string.IsNullOrEmpty(_context.CurrentPage.FormEmailRecipient))
				{
					PopEmailExtension.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, emailtext, false);
				}
				else
				{
					string [] emailAddresses = _context.CurrentPage.FormEmailRecipient.Split(new string [] {","}, StringSplitOptions.RemoveEmptyEntries);
					PopEmailExtension.SendEmail(emailAddresses, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, emailtext, false);					
				}
				uxSubmitted.Visible = true;
			}
			catch
			{
				uxError.Visible = true;
			}			
		}
	}
}
