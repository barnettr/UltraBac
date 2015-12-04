using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class _controls_forms_resellersOrder : FormControlBase
{
	const string SeparatorBar = "===========================================================";

	public _controls_forms_resellersOrder()
	{
		Separator = " : ";
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			dateInput.Value = DateTime.Now.ToString("D");
			LoadOrderRows();
			PopulateUserFromGoldmine();
		}
		
	}

	private void PopulateUserFromGoldmine()
	{
		ResellerDb db = new ResellerDb(POP.UltraBac.Config.ResellerConnectionString);
		string email = db.GetResellerEmail(Session);
		if (!string.IsNullOrEmpty(email))
		{
			try
			{
				GoldmineUserRecord record = GoldmineUserRecord.LoadUser(email);
				companyInput.Value = record.Company;
				nameInput.Value = record.Contact;
				emailInput.Value = record.Email;
				phoneInput.Value = record.Phone1;
				addressInput.Value = record.Address1;
				suiteInput.Value = record.Address2;
				cityInput.Value = record.City;
				postalcodeInput.Value = record.Zip;
			}
			catch { }
		}
	}

	private void LoadOrderRows()
	{
		int[] productRows = new int[10];
		ProductQuantityTable.DataSource = productRows;
		ProductQuantityTable.DataBind();
	}

	protected void ProductQuantityTable_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.AlternatingItem ||
			e.Item.ItemType == ListItemType.Item)
		{
			
		}
	}

	protected void Submit_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			AddLine(SeparatorBar);
			AddLine("Please process this order immediately!");
			AddLine("Order Received", dateInput.Value);
			AddLine();

			AddLine(SeparatorBar);
			AddLine("Bill To:");
			AddLine("Cust Num", customerNumberInput.Value);
			AddLine("Company ", companyInput.Value);
			AddLine("Name    ", nameInput.Value);
			AddLine("Email   ", emailInput.Value);
			AddLine("Phone   ", phoneInput.Value);
			AddLine("Address ", addressInput.Value);
			AddLine("Suite   ", suiteInput.Value);
			AddLine("City    ", cityInput.Value);
			AddLine("Zip Code", postalcodeInput.Value);
			AddLine("Country ", countryInput.Value);
			AddLine();
			AddLine(SeparatorBar);
			AddLine("Ship To    ", shipAddress.SelectedValue);
			AddLine();
			AddLine("Payment    ", shippingType.SelectedValue);
			AddLine("Account    ", shippaymentAcctInput.Value);
			AddLine("Company    ", shipCompanyInput.Value);
			AddLine("Name       ", shipNameInput.Value);
			AddLine("Email      ", shipEmailInput.Value);
			AddLine("Phone      ", shipPhoneInput.Value);
			AddLine("Address    ", shipAddressInput.Value);
			AddLine("Suite      ", shipSuiteInput.Value);
			AddLine("City       ", shipCityInput.Value);
			AddLine("Postal Code", shipPostalcodeInput.Value);
			AddLine("Country    ", shipCountryInput.Value);
			AddLine();
			AddLine(SeparatorBar);
			AddLine("Payment Info", paymentType.SelectedValue);
			AddLine("P.O. #      ", poInput.Value);			
			AddLine("Version     ", versionInput.Value);

			AddLine();
			AddLine(SeparatorBar);
			AddLine("Order Details:");

			foreach (Control row in ProductQuantityTable.Controls)
			{
				if (row is RepeaterItem && (
					(row as RepeaterItem).ItemType == ListItemType.Item ||
					(row as RepeaterItem).ItemType == ListItemType.AlternatingItem))
				{
					HtmlInputText q = row.FindControl("Quantity") as HtmlInputText;
					HtmlInputText d = row.FindControl("Description") as HtmlInputText;
					HtmlInputText p = row.FindControl("Price") as HtmlInputText;
					if (!string.IsNullOrEmpty(q.Value) ||
						!string.IsNullOrEmpty(p.Value) ||
						!string.IsNullOrEmpty(d.Value))
					{
						AddLine("Quantity   ", q.Value);
						AddLine("Description", d.Value);
						AddLine("Price      ", p.Value);
						AddLine();
					}
				}
			}
			AddLine();
			AddLine(SeparatorBar);
			AddLine("End User Information:");
			AddLine();

			AddLine("Company    ", enduserCompanyInput.Value);
			AddLine("Name       ", enduserNameInput.Value);
			AddLine("Email      ", enduserEmailInput.Value);
			AddLine("Phone      ", enduserPhoneInput.Value);
			AddLine("Address    ", enduserAddressInput.Value);
			AddLine("City       ", enduserCityInput.Value);
			AddLine("Postal Code", enduserPostalcodeInput.Value);
			AddLine("Country    ", enduserCountryInput.Value);
			
			AddLine();
			AddLine(SeparatorBar);
			AddLine("Info and Comments:");
			AddLine();

			AddLine("Send lic. to", enduserLicenseemailInput.Value);
			AddLine("License Server", enduserLicenseserverInput.Value);			
			AddLine("Comments", commentsInput.Value);

			AddLine();
			AddLine(SeparatorBar);

			SendEmail();
			//uxForm.Visible = false;
			uxInstructions.Visible = false;
			uxMessage.Visible = true;
		}
	}
}