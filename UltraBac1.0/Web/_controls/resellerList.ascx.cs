using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _controls_resellerList : System.Web.UI.UserControl
{
	private Regex _rexURL = new Regex(
		"(?<Protocol>\\w+):\\/\\/(?<Domain>[\\w@][\\w.:@]+)\\/?[\\w\\.?=%&=\\-@/$,]*",
		RegexOptions.IgnoreCase
		| RegexOptions.CultureInvariant
		| RegexOptions.IgnorePatternWhitespace
		| RegexOptions.Compiled
		);

	private string _countryName;
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if ( Request["countryname"] == null )
		{
			repCountries.Visible = true;
			plhDealerList.Visible = false;
		}
		else
		{
			repCountries.Visible = false;
			plhDealerList.Visible = true;
			_countryName = Server.UrlDecode(Request["countryname"]);
			lblCountryName.Text = _countryName;
			BindDealers();
		}
	}

	private void BindDealers()
	{
		accDealers.SelectParameters.Add("DealerCountry", _countryName);
		repDealers.DataSource = accDealers;
		repDealers.DataBind();
		if ( repDealers.Items.Count == 0 )
		{
			lblNoResults.Visible = true;
		}
	}

	protected void btnCountry_Click(object sender, EventArgs e)
	{
		LinkButton btn = sender as LinkButton;
		if ( btn != null )
		{
			// reload this page with the selected country name added to the query string
			Response.Redirect(string.Format("{0}?countryname={1}", Request.Url, Server.UrlEncode(btn.Text)));
		}
	}

	protected void repDealers_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		DataRowView drv = e.Item.DataItem as DataRowView;
		if ( drv != null )
		{
			// show the dealer url if available
			if ( drv["DealerURL"].ToString().Trim().Length > 0 )
			{
				HyperLink hlk = e.Item.FindControl("hlkDealerName") as HyperLink;
				if ( hlk != null )
				{
					hlk.NavigateUrl = EnforceURLFormat(drv["DealerURL"].ToString().Trim());
					hlk.Visible = true;
				}
			}
			else
			{
				Label lblName = e.Item.FindControl("lblDealerName") as Label;
				if ( lblName != null )
				{
					lblName.Visible = true;
				}
			}
			// build and show the dealer address
			Label lblLocation = e.Item.FindControl("lblDealerLocation") as Label;
			if ( lblLocation != null )
			{
				lblLocation.Text = BuildDealerAddress(drv);
			}
		}
	}

	private string EnforceURLFormat(string url)
	{
		if ( url.Length == 0 || _rexURL.IsMatch(url) )
		{
			return url;
		}

		return string.Format("http://{0}", url);
	}

	private string BuildDealerAddress(DataRowView drv)
	{
		string retVal = string.Empty;

		if ( drv != null )
		{
			string addr1 = (drv["DealerAddress1"] as string ?? "").Trim();
			string addr2 = (drv["DealerAddress2"] as string ?? "").Trim();
			string addr3 = (drv["DealerAddress3"] as string ?? "").Trim();
			string city = (drv["DealerCity"] as string ?? "").Trim();
			string state = (drv["DealerState"] as string ?? "").Trim();
			string zip = (drv["DealerZip"] as string ?? "").Trim();
			string country = (drv["DealerCountry"] as string ?? "").Trim();

			StringBuilder sb = new StringBuilder();
			if ( addr1.Length != 0 )
			{
				sb.AppendFormat("{0}<br />", addr1);
			}
			if ( addr2.Length != 0 )
			{
				sb.AppendFormat("{0}<br />", addr2);
			}
			if ( addr3.Length != 0 )
			{
				sb.AppendFormat("{0}<br />", addr3);
			}
			if ( city.Length != 0 && state.Length != 0 )
			{
				sb.AppendFormat("{0}, {1} {2}<br />", city, state, zip);
			}
			else
			{
				sb.AppendFormat("{0} {1} {2}<br />", city, state, zip);
			}
			retVal = sb.ToString();
		}

		return retVal;

	}

}
