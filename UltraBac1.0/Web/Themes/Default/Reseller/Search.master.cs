using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using POP.UltraBac;

public partial class Themes_Default_Reseller_Search : System.Web.UI.MasterPage
{
	private ResellerDb _db = new ResellerDb(Config.ResellerConnectionString);

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			FillControls();
		}
	}

	private void FillControls()
	{
		List<string> regions = _db.GetRegions();
		uxRegion.DataSource = regions;
		uxRegion.DataBind();

		try
		{
			SetContinent("North America");
			SetCountry("USA");
			GetResellers("USA");
		}
		catch
		{
			SetContinent(uxRegion.Items[0].Text);
			GetResellers(uxCountry.Items[0].Text);
		}
	}

	protected void uxResellers_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item ||
			e.Item.ItemType == ListItemType.AlternatingItem)
		{
			DataRow row = e.Item.DataItem as DataRow;
			bool showAddress2 = false;
			try{
				showAddress2 = !string.IsNullOrEmpty(row["DealerMailingAddress1"].ToString());
			}catch{}

			PlaceHolder uxMailingAddressTemplate = e.Item.FindControl("uxMailingAddressTemplate") as PlaceHolder;
			if (uxMailingAddressTemplate != null)
			{
				uxMailingAddressTemplate.Visible = showAddress2;
			}
		}
	}	
	protected void uxCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		GetResellers(uxCountry.SelectedItem.Text);
	}
	protected void uxRegion_SelectedIndexChanged(object sender, EventArgs e)
	{
		SetContinent(uxRegion.SelectedItem.Text);
		SetCountry(uxCountry.Items[0].Text);
		GetResellers(uxCountry.Items[0].Text);
	}

	protected void SetContinent(string continent)
	{
		ListItem continentItem = uxRegion.Items.FindByText(continent);
		if (continentItem == null)
		{
			throw new Exception("Region not found in dropdown list");
		}
		uxRegion.ClearSelection();
		continentItem.Selected = true;
		uxCountry.DataSource = _db.GetCountries(continent);
		uxCountry.DataBind();
	}

	protected void SetCountry(string country)
	{
		ListItem countryItem = uxCountry.Items.FindByText(country);
		if (countryItem == null)
		{
			throw new Exception("Country not found in dropdown list. Did you call SetContinent first?");
		}
		uxCountry.ClearSelection();
		countryItem.Selected = true;
		
	}

	protected void GetResellers(string country)
	{
		uxResellers.DataSource = _db.GetResellers(country);
		uxResellers.DataBind();
	}

	protected string GetColumnTextOrEmpty(object row, string column)
	{
		try
		{
			System.Data.DataRow dataRow = row as System.Data.DataRow;
			if (dataRow == null || dataRow[column] == null)
				return string.Empty;

			return dataRow[column].ToString();
		}
		catch { }
		return string.Empty;
	}
	
	protected string FormatTextOrEmpty(object row, string formatString, bool requireAllColumns, params string[] columns)
	{
		DataRow dr = row as DataRow;
		if (dr == null)
			return string.Empty;

		try
		{

			string[] values = new string[columns.Length];
			int i = 0;
			foreach (string str in columns)
			{
				values[i] = dr[str] == null ? "" : dr[str].ToString();
				if (!requireAllColumns && !String.IsNullOrEmpty(values[i]))
				{
					break;
				}
				else if (requireAllColumns && String.IsNullOrEmpty(values[i]))
				{
					return string.Empty;
				}
				i++;
			}

			string result = string.Format(formatString, values);
			return result;
		}
		catch { }
		return string.Empty;
	}
}