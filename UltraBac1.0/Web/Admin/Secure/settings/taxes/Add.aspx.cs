using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using System.Data.SqlClient;


public partial class Admin_Secure_settings_tax_Add : System.Web.UI.Page
{
    #region Protected Variables
    protected int ItemId;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get ItemId from querystring        
        if (Request.Params["itemid"] != null)
        {
            ItemId = int.Parse(Request.Params["itemid"]);
        }
        else
        {
            ItemId = 0;
        }

        if (Page.IsPostBack == false)
        {
            //if edit func then bind the data fields
            if (ItemId > 0)
            {
                lblTitle.Text = "Edit Tax Rule";                
            }
            else
            {
                lblTitle.Text = "Add a Tax Rule";
            }

            //Bind data to the fields on the page
            BindData();
        }
    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind data to the fields 
    /// </summary>
    protected void BindData()
    {
        TaxRuleAdmin taxAdmin = new TaxRuleAdmin();
        TaxRule taxRule = new TaxRule();

        //Bind countries
        BindCountry();


        if (ItemId > 0)
        {
            taxRule = taxAdmin.GetTaxRule(ItemId);

            lstCountries.SelectedValue = taxRule.DestinationCountryCode;

            if (taxRule.DestinationStateCode != null)
            {
                lstStateOption.SelectedValue = "1";
                pnlState.Visible = true;
                txtDestinationStateCode.Text = taxRule.DestinationStateCode;
            }
            else
            {
                lstStateOption.SelectedValue = "0";
                pnlState.Visible = false;
            }

            txtTaxRate.Text = taxRule.TaxRate.ToString();
            txtPrecedence.Text = taxRule.Precedence.ToString();            
        }
        else
        {
           //nothing to do here
        }

    }

     /// <summary>
    /// Binds country drop-down list
    /// </summary>
    private void BindCountry()
    {
        ShippingAdmin shipAdmin = new ShippingAdmin();
        TList<ZNode.Libraries.DataAccess.Entities.Country> countries = shipAdmin.GetDestinationCountries();       

        lstCountries.DataSource = countries;
        lstCountries.DataTextField = "Name";
        lstCountries.DataValueField = "Code";
        lstCountries.DataBind();
        lstCountries.SelectedValue = "ALL";
    }    


    #endregion

    #region General Events
    /// <summary>
    /// Submit button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        TaxRuleAdmin taxAdmin = new TaxRuleAdmin();
        TaxRule taxRule = new TaxRule();

        taxRule.PortalID = ZNodeConfigManager.SiteConfig.PortalID;

        //If edit mode then retrieve data first
        if (ItemId > 0)
        {
            taxRule = taxAdmin.GetTaxRule(ItemId);
        }

        //set values

        if (lstCountries.SelectedValue.Equals("*"))
        {
            taxRule.DestinationCountryCode = null;
        }
        else
        {
            taxRule.DestinationCountryCode = lstCountries.SelectedValue;
        }

        if (lstStateOption.SelectedValue.Equals("1"))
        {
            taxRule.DestinationStateCode = txtDestinationStateCode.Text.ToUpper();
        }
        else
        {
            taxRule.DestinationStateCode = null;
        }

        taxRule.Precedence = int.Parse(txtPrecedence.Text);
        taxRule.TaxRate = decimal.Parse(txtTaxRate.Text);
    

        bool retval = false;

        if (ItemId > 0)
        {
            retval = taxAdmin.UpdateTaxRule(taxRule);
        }
        else
        {
            retval = taxAdmin.AddTaxRule(taxRule);
        }

        if (retval)
        {
            //redirect to main page
            Response.Redirect("~/admin/secure/settings/taxes/default.aspx");
        }
        else
        {
            //display error message
            lblMsg.Text = "An error occurred while updating. Please try again.";
        }
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/settings/taxes/default.aspx");
    }
    
    /// <summary>
    /// state option changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstStateOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstStateOption.SelectedValue.Equals("0"))
        {
            pnlState.Visible = false;
        }
        else
        {
            pnlState.Visible = true;
        }
    }

    

    #endregion   
   
   
}
