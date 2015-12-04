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
using ZNode.Libraries.DataAccess;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;

public partial class Themes_Default_Account_Account : System.Web.UI.UserControl
{
    #region Private Variables
    ZNodeUserAccount _userAccount;
    #endregion

    #region Public Variables
    public string BillingAddress = string.Empty;
    public string ShippingAddress = string.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //if user is an admin, then redirect to the admin dashboard
        if(Roles.IsUserInRole("ADMIN"))
        {
            Response.Redirect("~/admin/secure/default.aspx");
        }

        //get the user account from session
        _userAccount = ZNodeUserAccount.CurrentAccount();

        BillingAddress = _userAccount.BillingAddress.ToString();
        ShippingAddress = _userAccount.ShippingAddress.ToString();

        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    /// <summary>
    /// Bind field data
    /// </summary>
    protected void Bind()
    {
        //bind order data
        ZNode.Libraries.DataAccess.Service.OrderService orderServ = new OrderService();

        TList<ZNode.Libraries.DataAccess.Entities.Order> Orders = orderServ.DeepLoadByAccountID(_userAccount.AccountID, true, DeepLoadType.IncludeChildren, typeof(OrderState));
        uxGrid.DataSource = Orders;
        uxGrid.DataBind();

    }

    protected void btnEditAddress_Click(object sender, EventArgs e)
    {
        //redirect to account page
        ZNodeUrl url = new ZNodeUrl();
        Response.Redirect("~/address.aspx");
    }

    /// <summary>
    /// Event triggered when a command button is clicked on the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        // Convert the row index stored in the CommandArgument
        // property to an Integer.
        int index = Convert.ToInt32(e.CommandArgument);

        // Get the values from the appropriate
        // cell in the GridView control.
        GridViewRow selectedRow = uxGrid.Rows[index];

        TableCell Idcell = selectedRow.Cells[0];
        string Id = Idcell.Text;

        if (e.CommandName == "View")
        {
            ZNodeUrl url = new ZNodeUrl();
            string ViewLink = "~/order.aspx?itemid=" + Id;

            Response.Redirect(ViewLink);
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/password.aspx");
    }
}
