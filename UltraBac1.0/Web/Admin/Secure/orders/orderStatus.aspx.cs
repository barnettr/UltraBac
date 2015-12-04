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

public partial class Admin_Secure_orders_orderStatus : System.Web.UI.Page
{
    # region Protected Member Variables
    protected int OrderID = 0;
    protected string ListPage = "list.aspx";
    # endregion

    # region General Events

    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Request.Params["itemid"] != null) || (Request.Params["itemid"].Length != 0))
        {
            OrderID = int.Parse(Request.Params["itemid"].ToString());
            lblOrderHeader.Text = OrderID.ToString();
        }

        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UpdateOrderStatus_Click(object sender, EventArgs e)
    {

        ZNode.Libraries.Admin.OrderAdmin _OrderAdmin = new ZNode.Libraries.Admin.OrderAdmin();
        ZNode.Libraries.DataAccess.Entities.Order  _OrderList = _OrderAdmin.GetOrderByOrderID(OrderID);
                

        if (_OrderList != null)
        {
            _OrderList.OrderStateID = int.Parse(ListOrderStatus.SelectedValue);
            _OrderList.OrderID = OrderID;

            bool Check = _OrderAdmin.Update(_OrderList);

            if (Check)
            {
                Response.Redirect(ListPage);
            }
            else
            {
                //Do Nothing
            }
            
        }
    }

    /// <summary>
    /// Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CancelStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect(ListPage);
    }

    # endregion

    # region Bind Data

    private void BindData()
    {
        ZNode.Libraries.Admin.OrderAdmin _OrderAdminAccess = new ZNode.Libraries.Admin.OrderAdmin();

        //Load Order State Item 
        ListOrderStatus.DataSource = _OrderAdminAccess.GetAllOrderState();
        ListOrderStatus.DataTextField = "orderstatename";
        ListOrderStatus.DataValueField = "Orderstateid";
        ListOrderStatus.DataBind();

                
        ZNode.Libraries.DataAccess.Entities.Order _OrderList = _OrderAdminAccess.GetOrderByOrderID(OrderID);

        if(_OrderList!=null)
        {
            ListOrderStatus.SelectedValue = _OrderList.OrderStateID.ToString();
           
        }          

    }

    # endregion
    
}
