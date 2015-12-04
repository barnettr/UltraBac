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
using ZNode.Libraries.Framework.Business;


public partial class Admin_Secure_customers_list : System.Web.UI.Page
{

    # region Procted Member Variables
    protected static bool CheckSearch = false;
    protected string EditLink = "~/admin/secure/customers/edit.aspx?itemid=";
    protected string ViewLink = "~/admin/secure/customers/view.aspx?itemid=";

    # endregion
    
    # region Page Load

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindGrid();
            this.BindData();            
            
            if (Page.Cache["ContactList"] != null)
            {
                Page.Cache.Remove("ContactList");
            }
            CheckSearch = false;
        }

        //Call Client Side script Block
        this.RegisterClientScript();

        //Add a JavaScript event listner
        ImageDt1.Attributes.Add("onclick", "displayCalendar(document.forms[0]." + txtStartDate.ClientID + ",'mm/dd/yyyy',document.forms[0]." + ImageDt1.ClientID + ")");
        ImageDt2.Attributes.Add("onclick", "displayCalendar(document.forms[0]." + txtEndDate.ClientID + ",'mm/dd/yyyy',document.forms[0]." + ImageDt2.ClientID + ")");
    }

    # endregion   

    # region Bind Grid Data

    /// <summary>
    /// Bind Grid
    /// </summary>
    protected void BindGrid()
    {
        AccountAdmin _AccountAdmin = new AccountAdmin();
        TList<Account> accountList = _AccountAdmin.GetAllCustomer();
        accountList.Sort("AccountID Desc");
        uxGrid.DataSource = accountList;
        uxGrid.DataBind();
    }

    /// <summary>
    /// Bind Profile drop down list
    /// </summary>
    private void BindData()
    {
        StoreSettingsAdmin settingsAdmin = new StoreSettingsAdmin();

        //get profiles
        lstProfile.DataSource = settingsAdmin.GetProfiles(ZNodeConfigManager.SiteConfig.PortalID);
        lstProfile.DataTextField = "Name";
        lstProfile.DataValueField = "ProfileID";
        lstProfile.DataBind();
        
        //Insert New Item 
        ListItem item = new ListItem("All", "0");
        lstProfile.Items.Insert(0, item);

        //Set Default as "ALL"
        lstProfile.SelectedIndex = 0;

    }

    # endregion

    # region General Events

    /// <summary>
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet MyDataSet = this.BindSearchCustomer();
        CheckSearch = true;

        //Bind DataGrid with Filtered Output
        uxGrid.DataSource = MyDataSet;
        uxGrid.DataBind();

    }

    /// <summary>
    /// Clear Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearSearch_Click(object sender, EventArgs e)
    {
        //Clear Search and Redirect to same page
        string link = "~/admin/secure/customers/list.aspx";
        Response.Redirect(link);
    }

    protected void download_Click(object sender, EventArgs e)
    {
        DataDownloadAdmin _DataDownloadAdmin = new DataDownloadAdmin();
        CustomerHelper HelperAccess = new CustomerHelper();
        DataSet _dataset = new DataSet();

        //Check for Search enabled
        if(CheckSearch)
        {
            if(Page.Cache["ContactList"]!=null)
            _dataset = Page.Cache["ContactList"] as DataSet;
        }
        else
        {
            _dataset = HelperAccess.SearchCustomer(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, "0");
        }
                    
        string StrData = _DataDownloadAdmin.Export(_dataset, true);

        byte[] data = ASCIIEncoding.ASCII.GetBytes(StrData);

        //Release Resources
        _dataset.Dispose();

        Response.Clear();

        // Set as Excel as the primary format
        Response.AddHeader("Content-Type", "application/Excel");

        Response.AddHeader("Content-Disposition", "attachment;filename=Customer.csv");
        Response.ContentType = "application/vnd.xls";

        Response.BinaryWrite(data);

        Response.End();
    }

    /// <summary>
    /// Add Quick Contact Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddQucikContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/customers/Add.aspx");
    }

    # endregion

    # region Grid Events

    protected void uxGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
            //Do nothing
        }
        else
        {
            // Get the Account id  stored in the CommandArgument
            string Id = e.CommandArgument.ToString();

            if (e.CommandName == "Edit")
            {
                EditLink = EditLink +  Id;
                Response.Redirect(EditLink);
            }
            else if (e.CommandName == "View")
            {
                ViewLink = ViewLink + Id;
                Response.Redirect(ViewLink);
            }
            
        }
    }
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        if (CheckSearch)
        {
            if (Page.Cache["ContactList"] != null)
            {                
                DataSet _dataset = Page.Cache["ContactList"] as DataSet;

                uxGrid.DataSource = _dataset;
                uxGrid.DataBind();

                //Release resources
                _dataset.Dispose();
            }
        }
        else
        {
            this.BindGrid();
        }

    }

    # endregion

    # region Helper Methods

    /// <summary>
    /// Return DataSet for a given Input
    /// </summary>
    /// <returns></returns>
    private DataSet BindSearchCustomer()
    {
        //Create Instance for Customer HElper class
        CustomerHelper HelperAccess = new CustomerHelper();
        DataSet Dataset = HelperAccess.SearchCustomer(txtFName.Text.Trim(), txtLName.Text.Trim(), txtComapnyNM.Text.Trim(), txtLoginName.Text.Trim(), txtExternalaccountno.Text.Trim(), txtContactID.Text.Trim(), txtStartDate.Text.Trim(),txtEndDate.Text.Trim(), txtPhoneNumber.Text.Trim(), txtEmailID.Text.Trim(), lstProfile.SelectedValue);

        Page.Cache["ContactList"] = Dataset;

        //Return DataSet
        return Dataset;
        
    }
    /// <summary>
    /// Concat firstname and lastname 
    /// </summary>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <returns></returns>
    protected string ConcatName(Object FirstName, Object LastName)
    {
        return (FirstName.ToString() + " " + LastName.ToString());
    }

    # endregion

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
        Include.Attributes.Add("src", "../Orders/Calendar/Calendar.js");


        //The Resource File is named “Calender.css”
        //Located inside the Calendar directory
        HtmlGenericControl Include1 = new HtmlGenericControl("link");
        Include1.Attributes.Add("type", "text/css");
        Include1.Attributes.Add("rel", "stylesheet");
        Include1.Attributes.Add("href", "../orders/Calendar/Calendar.css");

        //add a script reference for Javascript to the head section
        this.Page.Header.Controls.Add(Include);
        this.Page.Header.Controls.Add(Include1);

    }

# endregion
    
}
