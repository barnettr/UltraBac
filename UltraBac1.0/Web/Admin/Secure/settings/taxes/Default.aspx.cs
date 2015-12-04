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
using ZNode.Libraries.Admin;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;

public partial class Admin_Secure_settings_tax_Default : System.Web.UI.Page
{
    #region Protected Member Variables
    protected string CatalogImagePath = "";
    protected string AddLink = "~/admin/secure/settings/taxes/add.aspx";
    protected string EditLink = "~/admin/secure/settings/taxes/add.aspx";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindGridData();
    }
    #endregion

    #region Bind Methods
    /// <summary>
    /// Bind data to grid
    /// </summary>
    private void BindGridData()
    {       
        TaxRuleAdmin taxAdmin = new TaxRuleAdmin();
        DataSet ds = taxAdmin.GetAllTaxRulesByPortal(ZNodeConfigManager.SiteConfig.PortalID).ToDataSet(true);
        DataView dv = new DataView(ds.Tables[0]);
        dv.Sort = "Precedence ASC";
        uxGrid.DataSource = dv;
        uxGrid.DataBind();       
    }
    #endregion

    #region Grid Events
    /// <summary>
    /// Event triggered when the grid page is changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        BindGridData();
    }

    /// <summary>
    /// Event triggered when an item is deleted from the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindGridData();
    }

    /// <summary>
    /// Event triggered when a command button is clicked on the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "page")
        {
        }
        else
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the values from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = uxGrid.Rows[index];

            TableCell Idcell = selectedRow.Cells[0];
            string Id = Idcell.Text;


            if (e.CommandName == "Edit")
            {
                EditLink = EditLink + "?itemid=" + Id;
                Response.Redirect(EditLink);
            }
            else if (e.CommandName == "Delete")
            {
                TaxRuleAdmin taxAdmin = new TaxRuleAdmin();
                TaxRule taxRule = new TaxRule();

                taxRule.TaxRuleID = int.Parse(Id);
                taxAdmin.DeleteTaxRule(taxRule);
                
            }
        }
    }

    #endregion

    #region Other Events
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(AddLink);
    }
    #endregion

    /// <summary>
    /// Get a formatted region code for grid display
    /// </summary>
    /// <param name="regionCode"></param>
    /// <returns></returns>
    protected string GetDefaultRegionCode(object regionCode)
    {
        if (regionCode == null)
        {
            return "ALL";
        }

        if (regionCode.ToString().Length == 0)
        {
            return "ALL";
        }
        else
        {
            return regionCode.ToString();
        }
    }
}
