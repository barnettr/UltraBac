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

public partial class Admin_Secure_catalog_product_manufacturer_Default : System.Web.UI.Page
{
    # region Protected Member Variables
    protected int ItemId = 0;
    # endregion

    # region Page Load
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["itemid"] != null)
        {
            ItemId = int.Parse(Request.Params["itemid"].ToString());
        }
        if (!Page.IsPostBack)
        {
            if (ItemId > 0)
            {
                this.BindEditDatas();
                lblTitle.Text = "Edit Manufacturer";
            }
            else
            {
                lblTitle.Text = "Add New Manufacturer";
            }
        }
    }
    #endregion

    #region Bind Grid

    /// <summary>
    /// Bind Edit Datas
    /// </summary>
    public void BindEditDatas()
    {
        ManufacturerAdmin ManuAdmin = new ManufacturerAdmin();
        Manufacturer Manu = ManuAdmin.GetByManufactureId(ItemId);
        Name.Text = Manu.Name;   
        Description.Text = Manu.Description;
        CheckActiveInd.Checked = Manu.ActiveInd;
    }
    #endregion

    #region General Events

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ManufacturerAdmin ManuAdmin = new ManufacturerAdmin();
        Manufacturer Manu = new Manufacturer();
        if (ItemId > 0)
        {
            Manu.ManufacturerID = ItemId;         
            
        }
        Manu.PortalID = ZNodeConfigManager.SiteConfig.PortalID;              
        Manu.Name = Name.Text;
        Manu.Description = Description.Text;
        Manu.ActiveInd = CheckActiveInd.Checked;
                
        bool check = false;

        if (ItemId > 0)
        {

            check = ManuAdmin.Update (Manu);
        }
        else
        {
            check = ManuAdmin.Insert (Manu);
        }

        if (check)
        {
            //redirect to main page
            Response.Redirect("list.aspx");
        }
        else
        {
            //display error message
            lblError.Text = "An error occurred while updating. Please try again.";
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }
    #endregion    

}       
        


   
