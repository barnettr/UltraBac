using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;
using POP.UltraBac;

public partial class _controls_forms_newsletterSignup : System.Web.UI.UserControl
{
	public const string MailSessionKey = "mailListSession";
	protected string ResellerEmail
	{
		get
		{
			string email = ViewState["ResellerEmail"] as string;
			if (email == null)
			{
				ResellerDb db = new ResellerDb(Config.ResellerConnectionString);
				email = db.GetResellerEmail(Session);

				ViewState["ResellerEmail"] = email;
			}
			return email;
		}
	}
	private const string SubscribeFormatString = @"Thank you for updating your settings.

Your subscription preferences are:
SUBSCRIPTION_PREFERENCES_PLACEHOLDER

Your preferred email format is: FORMAT_PLACEHOLDER


Below is your current contact information:
===================================================
Name            = NAME_PLACEHOLDER
Organization    = ORGANIZATION_PLACEHOLDER
Phone           = PHONE_PLACEHOLDER
Email           = EMAIL_PLACEHOLDER
Address         = ADDRESS_PLACEHOLDER
Address 2       = ADDRESS2_PLACEHOLDER
City            = CITY_PLACEHOLDER
State/Province  = STATE_PLACEHOLDER
Zip/Postal Code = ZIP_PLACEHOLDER
Country         = COUNTRY_PLACEHOLDER
===================================================

If you have received this message in error, or wish to change your email preferences, please visit the following link:
http://www.ultrabac.com/content.aspx?page=news-signup

";

	protected void Page_Load(object sender, EventArgs e)
	{
		string sessionEmail = Session[MailSessionKey] as string;
		if (!IsPostBack)
		{
			if (sessionEmail != null)
			{
				uxEmailAddress.Text = sessionEmail;
			}
			try
			{
				GetUserGoldminePreferences();
			}
			catch { }
		}
		else
		{
			Page.Validate();
			if (Page.IsValid)
			{
				SendSubscriptionEmail(uxEmailAddress.Text);
				if (uxAction.SelectedValue.Equals("Unsubscribe", StringComparison.InvariantCultureIgnoreCase))
				{
					string message = ZNodeConfigManager.MessageConfig.GetMessage("UnsubscriptionMessage");
					message = ContentHelper.ResolveRelativeUrls(message);

					uxUnsubConfirmation.Text = string.Format(message, uxEmailAddress.Text);
					uxUnsubConfirmation.Visible = true;
				}
				else
				{
					string message = ZNodeConfigManager.MessageConfig.GetMessage("SubscriptionMessage");

					uxSubscriptionConfirmation.Text = string.Format(message, uxEmailAddress.Text);
					uxSubscriptionConfirmation.Visible = true;
				}

				// clear session key
				Session[MailSessionKey] = null;

				// hide form
				uxForm.Visible = false;
			}
		}
	}

	private void GetUserGoldminePreferences()
	{
		
		string resellerEmail = ResellerEmail;
		
		if (!string.IsNullOrEmpty(resellerEmail))
		{

			GoldmineUserRecord record = UBGoldMine.GetGoldmineRecord(resellerEmail);
			uxEmailAddress.Text = record.ContactPreferences;
			uxAction.ClearSelection();
			foreach (string item in record.Notes)
			{
				string note = item.ToUpper();
				if (note == "UNSUBSCRIBE")
				{
					uxAction.ClearSelection();
					uxAction.Items.FindByValue("Unsubscribe").Selected = true;
					break;
				}
				switch (item.ToUpper())
				{
					case "HTML":
					case "TEXT":
						uxEmailPrefs.ClearSelection();
						uxEmailPrefs.Items.FindByValue(note).Selected = true;
						break;
					case "QUARTERLY":
						uxAction.Items.FindByValue("Quarterly Newsletters").Selected = true;
						break;
					case "SALES":
						uxAction.Items.FindByValue("Sales Promotions").Selected = true;
						break;
					case "BUGS":
						uxAction.Items.FindByValue("Software Updates").Selected = true;
						break;
					default:
						// do nothing for unexpected keys
						break;
				}
			}
		}
	}

	private void SendSubscriptionEmail(string emailAddress)
	{
		// TODO: send email

		string body = SubscribeFormatString
			.Replace("SUBSCRIPTION_PREFERENCES_PLACEHOLDER", GetPrefs())
			.Replace("FORMAT_PLACEHOLDER", uxEmailPrefs.SelectedValue)
			.Replace("NAME_PLACEHOLDER", uxContactName.Text)
			.Replace("ORGANIZATION_PLACEHOLDER", uxCompanyName.Text)
			.Replace("PHONE_PLACEHOLDER", uxPhone.Text)
			.Replace("EMAIL_PLACEHOLDER", uxEmailAddress.Text)
			.Replace("ADDRESS_PLACEHOLDER", uxAddress1.Text)
			.Replace("ADDRESS2_PLACEHOLDER", uxAddress2.Text)
			.Replace("CITY_PLACEHOLDER", uxCity.Text)
			.Replace("STATE_PLACEHOLDER", uxState.Text)
			.Replace("ZIP_PLACEHOLDER", uxPostal.Text)
			.Replace("COUNTRY_PLACEHOLDER", uxCountry.Text);

		string subject = string.Format("Mail List {0}ubscription Request", IsSubscribe() ? "S" : "Uns");

		try
		{
			ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, body, false);
		}
		catch
		{
			// per spec, do nothing on fail, administrators will have to look at logs
		}
		try
		{
			ZNodeEmail.SendEmail(uxEmailAddress.Text, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, body, false);
		}
		catch
		{
			// per spec, do nothing on fail, administrators will have to look at logs
		}
	}

	private string GetPrefs()
	{
		StringBuilder sb = new StringBuilder();
		foreach (ListItem item in uxAction.Items)
		{
			if (item.Selected)
			{
				sb.AppendLine(item.Value);
			}
		}
		return sb.ToString();
	}

	private bool IsSubscribe()
	{
		foreach (ListItem item in uxAction.Items)
		{
			if (item.Selected && item.Value.Equals("Unsubscribe", StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}
		}
		return true;
	}

	protected void ValidateCheckbox(object sender, ServerValidateEventArgs e)
	{
		bool subscriptionOptionChecked = false;
		bool unsubChecked = false;
		foreach (string value in uxAction.SelectedValues)
		{
			if (value.Equals("Unsubscribe", StringComparison.InvariantCultureIgnoreCase))
			{
				unsubChecked = true;
			}
			else
			{
				subscriptionOptionChecked = true;
			}
		}

		if (
			(subscriptionOptionChecked && !unsubChecked) ||
			(!subscriptionOptionChecked && unsubChecked))
		{
			e.IsValid = true;
		}
		else
		{
			e.IsValid = false;
		}
	}
}