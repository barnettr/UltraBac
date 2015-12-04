using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.MobileControls;
using System.Text;
using ZNode.Libraries.Framework.Business;
using System.Web.UI;

/// <summary>
/// Summary description for FormControlBase
/// </summary>
public class FormControlBase : UserControl
{
	CmsContext _context = new CmsContext();
	StringBuilder _emailBody = new StringBuilder();
	protected string Separator = ":\t";

	protected void AddLine(string name, string value, string separator)
	{
		_emailBody.AppendLine(string.Format("{0}{2}{1}", name, value, separator));
	}

	protected void AddLine(string name, string value)
	{
		AddLine(name, value, Separator);
	}

	protected void AddLine(string value)
	{
		_emailBody.AppendLine(value);
	}

	protected void AddLine()
	{
		_emailBody.AppendLine();
	}

	protected void SendEmail()
	{

		string emailtext = _emailBody.ToString();
		string subject = string.Format("UltraBac.com form submission: {0}", _context.CurrentPage.Title);
		if (string.IsNullOrEmpty(_context.CurrentPage.FormEmailRecipient))
		{
			PopEmailExtension.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, emailtext, false);
		}
		else
		{
			string[] emailAddresses = _context.CurrentPage.FormEmailRecipient.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			PopEmailExtension.SendEmail(emailAddresses, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, emailtext, false);
		}

	}
}
