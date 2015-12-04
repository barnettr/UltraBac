using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using POP.UltraBac;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

public partial class _controls_forms_updateResellerContactInfo : System.Web.UI.UserControl
{
	private CmsContext _context = new CmsContext();
	const string jsLocationChangedScriptBlock = "jsLocationChanged";

	[Serializable]
	private class Contact
	{
		private string _name = string.Empty;
		private string _email = string.Empty;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public Contact(string name, string email)
		{
			_name = name;
			_email = email;
		}
	}

	#region Private Properties
	private string primaryContact
	{
		get { return txtPrimaryContact.Text; }
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
	private string fax
	{
		get { return txtFax.Text; }
	}

	private List<Contact> Contacts
	{
		get
		{
			if ( ViewState["vsContactsData"] != null )
			{
				return (List<Contact>)ViewState["vsContactsData"];
			}
			else
			{
				return new List<Contact>();
			}
		}
		set
		{
			ViewState["vsContactsData"] = value;
		}
	}

	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{

		if ( !IsPostBack )
		{
			ddlCountry.Attributes.Add("onchange", "setCountryOption(this);");
			BindCountry();
			BindState();
		}

		string js = ClientScriptUtils.BuildLocationSelectionDHTMLScript(divStateDDL.ClientID, divStateTxt.ClientID, string.Empty);
		Page.ClientScript.RegisterStartupScript(typeof(Page), jsLocationChangedScriptBlock, js);
		Page.ClientScript.RegisterStartupScript(typeof(Page), "jsPersistDHTML", "setCountryOption(document.getElementById('" + ddlCountry.ClientID + "'));", true);

	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{

		if ( Page.IsValid )
		{
			SendUltraBacEmail();

			plhThankYou.Visible = true;
			plhContact.Visible = false;
		}

	}

	protected void btnSubmitContact_Click(object sender, EventArgs e)
	{
		AddContact(txtContactName.Text, txtContactEmail.Text);
		BindContacts();
		txtContactName.Text = string.Empty;
		txtContactEmail.Text = string.Empty;
	}

	protected void cvState_ServerValidate(object sender, ServerValidateEventArgs e)
	{
		// check for a state selection or value
		if ( ddlState.SelectedValue == "-1" && txtState.Text == string.Empty )
		{
			e.IsValid = false;
		}
	}

	protected void gvContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}

	protected void gvContacts_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if ( e.CommandName == "Delete" )
		{
			int idx = Convert.ToInt32(e.CommandArgument);

			// Get the values from the appropriate
			// cell in the GridView control.
			GridViewRow selectedRow = gvContacts.Rows[idx];

			TableCell keyCell = selectedRow.Cells[1];
			string email = keyCell.Text;

			RemoveContact(email);
			BindContacts();
		}
	}

	private void AddContact(string name, string email)
	{
		List<Contact> contactList = Contacts;
		contactList.Add(new Contact(name.Trim(), email.Trim()));
		Contacts = contactList;
	}

	private void RemoveContact(string email)
	{
		List<Contact> contactList = Contacts; 
		Contact contactToRemove = null;
		foreach ( Contact contact in contactList )
		{
			if ( contact.Email == email )
			{
				contactToRemove = contact;
				break;
			}
		}
		if ( contactToRemove != null )
		{
			contactList.Remove(contactToRemove);
		}
		Contacts = contactList;
	}

	private string BuildContactList()
	{
		if ( Contacts.Count == 0 )
		{
			return "No additional contacts were entered.";
		}
		else
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Additional Contacts:");
			foreach ( Contact contact in Contacts )
			{
				if ( contact.Name.Trim().Length > 0 )
				{
					sb.AppendLine(contact.Name + ", " + contact.Email);
				}
				else
				{
					sb.AppendLine(contact.Email);
				}
			}
			return sb.ToString();
		}
	}

	private void BindContacts()
	{
		gvContacts.DataSource = Contacts;
		gvContacts.DataBind();
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

	private void SendUltraBacEmail()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendFormat("Primary Contact:\t{0}\n", primaryContact);
		sb.AppendFormat("Company:\t{0}\n", companyName);
		sb.AppendFormat("Address 1:\t{0}\n", address1);
		sb.AppendFormat("Address 2:\t{0}\n", address2);
		sb.AppendFormat("City:\t{0}\n", city);
		sb.AppendFormat("Zip:\t{0}\n", zip);
		sb.AppendFormat("State:\t{0}\n", state);
		sb.AppendFormat("Country:\t{0}\n", country);
		sb.AppendFormat("Phone:\t{0}\n", phone);
		sb.AppendFormat("Fax:\t{0}\n", fax);
		sb.AppendLine();
		sb.Append(BuildContactList());

		string subject = "Reseller Contact Information Update";
		if (string.IsNullOrEmpty(_context.CurrentPage.FormEmailRecipient))
		{
			PopEmailExtension.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
		}
		else
		{
			PopEmailExtension.SendEmail(_context.CurrentPage.FormEmailRecipient.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries), ZNodeConfigManager.SiteConfig.AdminEmail, "", subject, sb.ToString(), false);
		}
	}
}
