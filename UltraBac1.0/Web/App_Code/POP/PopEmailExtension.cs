using System;
using System.Collections.Generic;
using System.Web;
using ZNode.Libraries.Framework.Business;

/// <summary>
/// Summary description for EmailHelper
/// </summary>
public static class PopEmailExtension
{
	public static void SendEmail(string recipient, string from, string CC, string subject, string body, bool isBodyHtml)
	{
		ZNodeEmail.SendEmail(recipient, from, CC, subject, body, isBodyHtml);
	}

	public static bool SendEmail(IEnumerable<string> recipients, string from, string CC, string subject, string body, bool isBodyHtml)
	{
		if (recipients == null)
		{
			throw new ArgumentNullException("IEnumberable<string> recipients is null in SendEmail");
		}
		bool isSuccess = true;

		foreach (string recipient in recipients)
		{
			try
			{
				SendEmail(recipient, from, CC, subject, body, isBodyHtml);
			}
			catch { isSuccess = false; }
		}
		return isSuccess;
	}
}
