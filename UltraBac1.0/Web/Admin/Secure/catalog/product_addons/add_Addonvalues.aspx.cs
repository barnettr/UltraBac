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
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;

public partial class Admin_Secure_catalog_product_addons_add_Addonvalues : System.Web.UI.Page
{
    #region Protected Variables
    protected int ItemId;
    protected int AddOnValueId = 0;    
    protected string ViewLink = "~/admin/secure/catalog/product_addons/view.aspx?itemid=";
    protected string CancelLink = "~/admin/secure/catalog/product_addons/view.aspx?itemid=";    
    #endregion

    # region Page Load Event
    /// <summary>
    /// Page Load Event - fires while page is loading
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check License
        ZNodeLicenseManager lm = new ZNodeLicenseManager();
        if (!lm.AllowAttributes())
        {
            Server.Transfer("~/admin/secure/denied.aspx");
        }

        // Get ItemId from querystring        
        if (Request.Params["itemid"] != null)
        {
            ItemId = int.Parse(Request.Params["itemid"]);
        }
        else
        {
            ItemId = 0;
        }

        if (Request.Params["AddOnValueId"] != null)
        {
            AddOnValueId = int.Parse(Request.Params["AddOnValueId"]);
        }

        if (Page.IsPostBack == false)
        {
            //if edit func then bind the data fields
            if (AddOnValueId > 0)
            {
                lblTitle.Text = "Edit Add-On Value : ";
                BindEditAddOnValues();
            }
            else
            {
                lblTitle.Text = "Add Add-On Value";                
            }
        }
    }
    # endregion

    # region Bind Methods
    /// <summary>
    /// Bind data to the fields on the edit screen
    /// </summary>
    protected void BindEditAddOnValues()
    {
        ProductAddOnAdmin AddOnAdmin = new ProductAddOnAdmin();
        AddOnValue AddOnValueEntity = AddOnAdmin.GetByAddOnValueID(AddOnValueId);

        if (AddOnValueEntity != null)
        {
            //General Settings
            lblTitle.Text += AddOnValueEntity.Name;
            txtAddOnValueName.Text = AddOnValueEntity.Name;
            txtAddOnValueRetailPrice.Text = AddOnValueEntity.Price.ToString();
            //Display Settings
            txtAddonValueDispOrder.Text = AddOnValueEntity.DisplayOrder.ToString();
            chkIsDefault.Checked = AddOnValueEntity.DefaultInd;
            //Inventory Settings
            txtAddOnValueSKU.Text = AddOnValueEntity.SKU;
            txtAddOnValueQuantity.Text = AddOnValueEntity.QuantityOnHand.ToString();
            txtAddOnValueWeight.Text = AddOnValueEntity.Weight.ToString();
        }
        else
        {
            throw (new ApplicationException("Add-On Value Requested could not be found."));
        }
    }
    #endregion

    # region General Events
    /// <summary>
    /// Submit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddOnValueSubmit_Click(object sender, EventArgs e)
    {
        ProductAddOnAdmin AddOnValueAdmin = new ProductAddOnAdmin();
        AddOnValue addOnValue = new AddOnValue();

        if (AddOnValueId > 0)
        {
            addOnValue = AddOnValueAdmin.GetByAddOnValueID(AddOnValueId);
        }

        //Set Properties
        // General Settings
        addOnValue.AddOnID = ItemId; //AddOnId from querystring 
        addOnValue.Name = txtAddOnValueName.Text.Trim();
        addOnValue.Price = decimal.Parse(txtAddOnValueRetailPrice.Text.Trim());

        //Display Settings
        addOnValue.DisplayOrder = int.Parse(txtAddonValueDispOrder.Text.Trim());
        addOnValue.DefaultInd = chkIsDefault.Checked;

        //Inventory Settings
        addOnValue.SKU = txtAddOnValueSKU.Text.Trim();
        addOnValue.QuantityOnHand = int.Parse(txtAddOnValueQuantity.Text.Trim());
        if (txtAddOnValueWeight.Text.Trim().Length > 0)
        {
            addOnValue.Weight = decimal.Parse(txtAddOnValueWeight.Text.Trim());
        }


        bool status = false;

        if (AddOnValueId > 0)
        {
            //Update option values
            status = AddOnValueAdmin.UpdateAddOnValue(addOnValue);
        }
        else
        {
            //Add new option values
            status = AddOnValueAdmin.AddNewAddOnValue(addOnValue);
        }

        if (status)
        {
            Response.Redirect(ViewLink + ItemId);
        }
        else
        {
            lblAddonValueMsg.Text = "Could not update the Add-On Value. Please try again.";            
            return;
        }
    }

    /// <summary>
    /// Cancel Button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(CancelLink + ItemId);
    }

    #endregion
    
}
