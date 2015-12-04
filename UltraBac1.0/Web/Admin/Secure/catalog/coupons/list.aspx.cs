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

public partial class Admin_Secure_catalog_coupons_list : System.Web.UI.Page
{
    #region Protected Member Variables

    protected string CatalogImagePath = "";
    protected string AddLink = "~/admin/secure/catalog/coupons/add.aspx";
    protected string DeleteLink = "~/admin/secure/catalog/coupons/delete.aspx?ItemID=";

    #endregion  

    #region page load
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridData();
        }
    }
    #endregion

    #region Bind Methods
   
    /// Bind data to grid
   
    private void BindGridData()
    {
        ZNode.Libraries.Admin.CouponAdmin couponbind = new ZNode.Libraries.Admin.CouponAdmin();
        DataSet ds = couponbind.GetAll().ToDataSet(true);
        DataView dv = new DataView(ds.Tables[0]);
        dv.Sort = "CouponID DESC";
        uxGrid.DataSource = dv;
        uxGrid.DataBind();
    }
    #endregion

    #region General Events

    protected void btnAddCoupon_Click(object sender, EventArgs e)
    {
        //Redirect to Add coupon Page    
        Response.Redirect(AddLink);
    }
     # endregion

    # region Grid Events

    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        BindGridData();

    }
    protected void uxGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
        }
        else
        {
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the values from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = uxGrid.Rows[index];

            TableCell Idcell = selectedRow.Cells[0];
            string Id = Idcell.Text;

            if (e.CommandName == "Edit")
            {
                AddLink = AddLink + "?ItemID=" + Id;
                Response.Redirect(AddLink);
            }
            else if (e.CommandName == "Delete")
            {
                Response.Redirect(DeleteLink + Id);
            }

        }
    }
    
     #endregion
}
