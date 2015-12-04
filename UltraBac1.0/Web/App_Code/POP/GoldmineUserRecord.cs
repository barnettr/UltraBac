using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using POP.UltraBac;

/// <summary>
/// Summary description for GoldmineUserRecord
/// </summary>
public class GoldmineUserRecord
{
	private string _contact;
	private string _phone1;
	private string _address1;
	private string _address2;
	private string _city;
	private string _zip;
	private string _state;
	private string _contactPreferences;
	private string _email;
	private string _key4;
	private string _company;
	private List<string> _notes;

	public List<string> Notes
	{
		get
		{
			if (_notes == null)
			{
				_notes = GetNewsletterPreferences();
			}
			return _notes;
		}
	}

	public string Company
	{
		get { return _company; }
		set { _company = value; }
	}	

	public string Key4
	{
		get { return _key4; }
		set { _key4 = value; }
	}
	
	public string Email
	{
		get { return _email; }
		set { _email = value; }
	}
	
	public string ContactPreferences
	{
		get { return _contactPreferences; }
		set { _contactPreferences = value; }
	}
	
	public string State
	{
		get { return _state; }
		set { _state = value; }
	}
	
	public string Zip
	{
		get { return _zip; }
		set { _zip = value; }
	}
	
	public string City
	{
		get { return _city; }
		set { _city = value; }
	}	

	public string Address1
	{
		get { return _address1; }
		set { _address1 = value; }
	}	

	public string Address2
	{
		get { return _address2; }
		set { _address2 = value; }
	}	
	
	public string Phone1
	{
		get { return _phone1; }
		set { _phone1 = value; }
	}
	
	public string Contact
	{
		get { return _contact; }
		set { _contact = value; }
	}

	public GoldmineUserRecord(string email, DataSet ds)
	{
		_email = email;
		Fill(ds);
	}

	protected void Fill(DataSet ds)
	{
		if (string.IsNullOrEmpty(Email) || 
			ds == null || 
			ds.Tables.Count < 1 ||
			ds.Tables[0].Rows.Count < 1)
		{
			throw new GoldmineUserNotFoundException(_email);
		}
		DataRow row = ds.Tables[0].Rows[0];
		Company = (string)row["company"];
		Key4 = (string)row["key4"];
		Contact = (string)row["contact"];
		Phone1 = (string)row["phone1"];
		Address1 = (string)row["address1"];
		Address2 = (string)row["address2"];
		City = (string)row["city"];
		Zip = (string)row["zip"];
		State = (string)row["state"];
		ContactPreferences = (string)row["contsupref"];
	}

	public static GoldmineUserRecord LoadUser(string emailAddress)
	{
		return UBGoldMine.GetGoldmineRecord(emailAddress);
	}

	private List<string> GetNewsletterPreferences()
	{
		List<string> notelist = new List<string>();
		string notes = UBGoldMine.GetGoldmineUserNotes(Email);
		if (!string.IsNullOrEmpty(notes))
		{
			string[] splitNotes = notes.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string note in splitNotes)
			{
				notelist.Add(note);
			}
		}
		return notelist;
	}

	public override string ToString()
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.AppendFormat("Email: {0}\r\n", Email);
		sb.AppendFormat("Contact: {0}\r\n", Contact);
		sb.AppendFormat("Phone: {0}\r\n", Phone1);
		sb.AppendFormat("Address: {0}\r\n", Address1);
		sb.AppendFormat("Suite: {0}\r\n", Address2);
		sb.AppendFormat("City: {0}\r\n", City);
		sb.AppendFormat("State: {0}\r\n", State);
		sb.AppendFormat("Zip: {0}\r\n", Zip);
		return sb.ToString();
	}
}
