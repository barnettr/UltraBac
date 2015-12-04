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
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Admin;
using ZNode.Libraries.Framework.Business;

public partial class Admin_Secure_catalog_product_Attribute_Types_list : System.Web.UI.Page
{

    #region Protected Member Variables
    protected string AddLink = "~/admin/secure/catalog/product_Attribute_Types/add.aspx";
    protected string DeleteLink = "~/admin/secure/catalog/product_Attribute_Types/delete.aspx?itemid=";
    protected string ViewLink = "~/admin/secure/catalog/product_Attribute_Types/view.aspx?itemid=";
    protected string EditLink = "~/admin/secure/catalog/product_Attribute_Types/add.aspx?itemid=";
    #endregion

    # region General Events

    /// <summary>
    /// Page Load Event
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

        if (!Page.IsPostBack)
        {
            this.BindGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(AddLink);
    }
    # endregion

    # region Grid Events
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument.ToString() == "page")
        {  }
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
                Response.Redirect(EditLink + Id);
            }
            else if (e.CommandName == "View")
            {
                Response.Redirect(ViewLink + Id);
            }
            else if (e.CommandName == "Delete")
            {
                Response.Redirect(DeleteLink +  Id);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    # endregion
    
    # region Bind Methods
    /// <summary>
    /// Bind Grid
    /// </summary>
    private void BindGrid()
    {
        AttributeTypeAdmin _AdminAccess = new AttributeTypeAdmin();
        DataSet ds = _AdminAccess.GetAll().ToDataSet(true);
        DataView dv = new DataView(ds.Tables[0]);
        dv.Sort = "AttributeTypeId DESC";
        uxGrid.DataSource = dv;
        uxGrid.DataBind();
    }
    # endregion

}
