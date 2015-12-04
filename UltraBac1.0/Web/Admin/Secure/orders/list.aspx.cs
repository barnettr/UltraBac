using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business ;

public partial class Admin_Secure_orders_list : System.Web.UI.Page
{

    # region Protected Member Variables
    protected string ViewOrderLink = "view.aspx?itemid=";
    protected string ChangeStatus = "orderStatus.aspx?itemid=";
    protected static bool SearchEnabled = false;
    protected DataSet MyDataSet = null;
    # endregion

    # region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtStartDate.Value = System.DateTime.Today.AddDays(-30).ToShortDateString();
            txtEndDate.Value = System.DateTime.Today.ToShortDateString();
            SearchEnabled = false;
            this.BindGrid();
            this.BindData();
        }

        //Call Client Side script Block
        this.RegisterClientScript();

        //Add a JavaScript event listner
        ImageDt1.Attributes.Add("onclick", "displayCalendar(document.forms[0]." + txtStartDate.ClientID + ",'mm/dd/yyyy',document.forms[0]." + ImageDt1.ClientID + ")");
        ImageDt2.Attributes.Add("onclick", "displayCalendar(document.forms[0]." + txtEndDate.ClientID + ",'mm/dd/yyyy',document.forms[0]." + ImageDt2.ClientID + ")");
       
    }

    # endregion

    # region Bind Data

    /// <summary>
    /// Bind Datas
    /// </summary>
    public void BindGrid()
    {
        ZNode.Libraries.Admin.OrderAdmin OrderAdmin = new ZNode.Libraries.Admin.OrderAdmin();

        //Bind Grid
        TList<Order> orderList = OrderAdmin.GetAllOrders(ZNodeConfigManager.SiteConfig.PortalID);

        if (orderList != null)
        {
            orderList.Sort("OrderID Asc");
        }

        uxGrid.DataSource = orderList;
        uxGrid.DataBind();

    }
    public DataSet BindSearchData(string startdate,string EndDate)
    {
        OrderAdmin _OrderAdmin = new OrderAdmin();
        MyDataSet = _OrderAdmin.FindOrders(txtorderid.Text.Trim(), txtfirstname.Text.Trim(), txtlastname.Text.Trim(), txtcompanyname.Text.Trim(), txtaccountnumber.Text.Trim(), startdate.Trim(), EndDate.Trim(), int.Parse(ListOrderStatus.SelectedValue.ToString()), ZNodeConfigManager.SiteConfig.PortalID);        
        return MyDataSet;
    }
    public void BindData()
    {
        ZNode.Libraries.Admin.OrderAdmin OrderAdmin = new ZNode.Libraries.Admin.OrderAdmin();

        //Add New Item
        ListItem Li = new ListItem();
        Li.Text = "All";
        Li.Value = "-1";

        //Load Order State Item 
        ListOrderStatus.DataSource = OrderAdmin.GetAllOrderState();
        ListOrderStatus.DataTextField = "orderstatename";
        ListOrderStatus.DataValueField = "Orderstateid";
        ListOrderStatus.DataBind();
        ListOrderStatus.Items.Insert(0, Li);
        ListOrderStatus.Items[0].Selected = true;
    }
    # endregion

    #region General Events

    /// <summary>
    /// Search Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string stdate = txtStartDate.Value.Trim();
        string enddate = txtEndDate.Value.Trim();
        MyDataSet  = this.BindSearchData(stdate,enddate);
        uxGrid.DataSource = MyDataSet;
        uxGrid.DataBind();
        SearchEnabled = true;        
    }

    /// <summary>
    /// Clear Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearSearch_Click(object sender, EventArgs e)
    {
        SearchEnabled = false;       
        txtStartDate.Value = String.Empty;
        txtEndDate.Value = String.Empty;
        txtorderid.Text = "";
        txtfirstname.Text = "";
        txtlastname.Text = "";
        txtcompanyname.Text = "";
        txtaccountnumber.Text = "";
        this.BindData();
        this.BindGrid();
    }

    /// <summary>
    /// Download Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButDownload_Click(object sender, EventArgs e)
    {
        DataDownloadAdmin csv = new DataDownloadAdmin();
        DataSet ds = new DataSet();
        string stdate = String.Empty;
        string enddate = String.Empty;

        if (SearchEnabled)
        {
           stdate = txtStartDate.Value.Trim();
           enddate = txtEndDate.Value.Trim();
        }
        
        //Get Filetered Orders in DataSet
        ds = this.BindSearchData(stdate, enddate);

        ZNodeEncryption encrypt = new ZNodeEncryption();
        
        foreach (DataRow dRow in ds.Tables[0].Rows)
        {               
            dRow["CreditCardNumber"] = encrypt.DecryptData(dRow["CreditCardNumber"].ToString());
            dRow["CreditCardExp"] = encrypt.DecryptData(dRow["CreditCardExp"].ToString());
            dRow["CreditCardCVV"] = encrypt.DecryptData(dRow["CreditCardCVV"].ToString());
        }

        //Set Formatted Data from DataSet
        string strData = csv.Export(ds, true);
        
        byte[] data = ASCIIEncoding.ASCII.GetBytes(strData);


        Response.Clear();
        // Set as Excel as the primary format
        Response.AddHeader("Content-Type", "application/Excel");

        Response.AddHeader("Content-Disposition", "attachment;filename=Order.csv");
        Response.ContentType = "application/vnd.xls";        
        Response.BinaryWrite(data);
        
        Response.End();
    }

    /// <summary>
    /// Order ListItem Buttton Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButOrderLineItemsDownload_Click(object sender, EventArgs e)
    {
        DataDownloadAdmin csv = new DataDownloadAdmin();

        //Get OrderLineItems in Dataset
        DataSet ds = GetOrderLineItems();

        string strData = csv.Export(ds, true);

        byte[] data = ASCIIEncoding.ASCII.GetBytes(strData);

        Response.Clear();
        // Set as Excel as the primary format
        Response.AddHeader("Content-Type", "application/Excel");
        
        Response.AddHeader("Content-Disposition", "attachment;filename=OrderLineItems.csv");
        Response.ContentType = "application/vnd.xls";		
        Response.BinaryWrite(data);

        Response.End();
    }

    # endregion

    # region Helper methods

    /// <summary>
    /// Contact first name and last name
    /// </summary>
    /// <param name="Firstname"></param>
    /// <param name="LastName"></param>
    /// <returns></returns>
    public string ReturnName(Object Firstname, Object LastName)
    {
        return Firstname.ToString() + " " + LastName.ToString();
    }

    /// <summary>
    /// Format the Price with two decimal
    /// </summary>
    /// <param name="Fieldvalue"></param>
    /// <returns></returns>
    public string FormatPrice(Object Fieldvalue)
    {
        if (Fieldvalue == DBNull.Value)
        {
            return string.Empty;
        }
        else
        {
            return "$" + Fieldvalue.ToString().Substring(0, Fieldvalue.ToString().Length - 2);
        }
    }

    /// <summary>
    /// Display the Order State name for a Order state
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string DisplayOrderStatus(object FieldValue)
    {
        ZNode.Libraries.Admin.OrderAdmin _OrderAdmin = new ZNode.Libraries.Admin.OrderAdmin();
        OrderState _OrderState = _OrderAdmin.GetByOrderStateID(int.Parse(FieldValue.ToString()));
        return _OrderState.OrderStateName.ToString();
    }

    private DataSet GetOrderLineItems()
    {
        OrderAdmin _OrderAdmin = new OrderAdmin();

        string stdate = String.Empty;
        string enddate = String.Empty;
        
        //Check for Search is enabled or not
        if (SearchEnabled)
        {
            stdate = txtStartDate.Value.Trim();
            enddate = txtEndDate.Value.Trim();
        }       
        
        DataSet MyDataSet = _OrderAdmin.GetOrderLineItems(txtorderid.Text.Trim(),txtfirstname.Text.Trim(),txtlastname.Text.Trim(),txtcompanyname.Text.Trim(),txtaccountnumber.Text.Trim(),stdate ,enddate, int.Parse(ListOrderStatus.SelectedValue.ToString()), ZNodeConfigManager.SiteConfig.PortalID);

        return MyDataSet;
    }

    # endregion

    #region Grid Events

    /// <summary>
    /// Grid Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_Sorting(object sender, GridViewSortEventArgs e)
    {

        OrderAdmin _OrderAdmin = new OrderAdmin();
        DataSet ds = _OrderAdmin.FindOrders(txtorderid.Text.Trim(),txtfirstname.Text.Trim(),txtlastname.Text.Trim(),txtcompanyname.Text.Trim(),txtaccountnumber.Text.Trim() ,txtStartDate.Value.Trim(), txtEndDate.Value.Trim(), int.Parse(ListOrderStatus.SelectedValue.ToString()), ZNodeConfigManager.SiteConfig.PortalID);
        uxGrid.DataSource = ds;
        DataSet dataSet = uxGrid.DataSource as DataSet;

        if (dataSet != null)
        {
            DataView dataView = new DataView(dataSet.Tables[0]);
            string newSortDirection = String.Empty;

            switch (uxGrid.SortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "DESC";
                    e.SortDirection = SortDirection.Descending;
                    break;

                case SortDirection.Descending:
                    newSortDirection = "ASC";
                    e.SortDirection = SortDirection.Ascending;
                    break;
            }

            dataView.Sort = e.SortExpression + " " + newSortDirection;
            uxGrid.DataSource = null;
            uxGrid.DataSource = dataView;
            uxGrid.DataBind();
        }

    }

    /// <summary>
    /// Grid Paging Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        if (SearchEnabled)
        {            
            MyDataSet = this.BindSearchData(txtStartDate.Value.Trim(),txtEndDate.Value.Trim());
            uxGrid.DataSource = MyDataSet;
            uxGrid.DataBind();
        }
        else
        {
            this.BindGrid();
        }
    }

    /// <summary>
    ///  Event triggered when the grid page is changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {  }
        else
        {
            if (e.CommandName == "ViewOrder")
            {
                Response.Redirect(ViewOrderLink + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Status")
            {
                Response.Redirect(ChangeStatus  + e.CommandArgument.ToString());
            }
        }
    }

    #endregion

    # region Client Side Script

    /// <summary>
    /// Includes Javascript file and css file into this page
    /// </summary>
    public void RegisterClientScript()
    {
        //Include the Client Side Script from the resource file
        //The Resource File is named “Calender.js”
        //Located inside the Calendar directory
        HtmlGenericControl Include = new HtmlGenericControl("script");
        Include.Attributes.Add("type", "text/javascript");
        Include.Attributes.Add("src", "Calendar/Calendar.js");


        //The Resource File is named “Calender.css”
        //Located inside the Calendar directory
        HtmlGenericControl Include1 = new HtmlGenericControl("link");
        Include1.Attributes.Add("type", "text/css");
        Include1.Attributes.Add("rel", "stylesheet");
        Include1.Attributes.Add("href", "Calendar/Calendar.css");

        //add a script reference for Javascript to the head section
        this.Page.Header.Controls.Add(Include);
        this.Page.Header.Controls.Add(Include1);

    }

    # endregion

}
