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

public partial class Admin_Secure_cases_list : System.Web.UI.Page
{
    # region Protected Member Variables
    protected static bool SearchBool = false;
    protected string AddLink = "~/admin/secure/cases/add.aspx";
    protected string NotesLink = "~/admin/secure/cases/note_add.aspx?itemid=";
    protected string ViewLink = "~/admin/secure/cases/view.aspx?itemid=";
    protected string EditLink = "~/admin/secure/cases/add.aspx?itemid=";
    protected string EmailLink = "~/admin/secure/cases/case_email.aspx?itemid=";

    # endregion

    # region General Events

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindList();
            this.BindGrid();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindSearchData();
        SearchBool =true;
    }

    protected void btnClearSearch_Click(object sender, EventArgs e)
    {
        SearchBool = false;
        txtcaseid.Text = string.Empty;
        txtfirstname.Text = string.Empty;
        txtlastname.Text = string.Empty;
        txtcompanyname.Text = string.Empty;        
        txttitle.Text = string.Empty;
        this.BindList();
        this.BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(AddLink);
    }
    # endregion

    # region Bind Data

    /// <summary>
    /// Bind Searched Data
    /// </summary>
    private void BindSearchData()
    {
        CaseAdmin _CaseAdminAccess = new CaseAdmin();
        DataSet MyDataSet = _CaseAdminAccess.SearchCase(int.Parse(ListCaseStatus.SelectedValue),txtcaseid.Text.Trim(),txtfirstname.Text.Trim(),txtlastname.Text.Trim(),txtcompanyname.Text.Trim(),txttitle.Text.Trim());
        uxGrid.DataSource = MyDataSet;
        uxGrid.DataBind();
    }

    /// <summary>
    /// Binds a Grid
    /// </summary>
    private void BindGrid()
    {
        CaseAdmin _CaseAdmin = new CaseAdmin();
        TList<Case> caseList = _CaseAdmin.GetAll();
        caseList.Sort("CaseID Asc");

        uxGrid.DataSource = caseList;
        uxGrid.DataBind();
    }
    private void BindList()
    {
        CaseAdmin _AdminAccess = new CaseAdmin();
        ListCaseStatus.DataSource = _AdminAccess.GetAllCaseStatus();
        ListCaseStatus.DataTextField = "CaseStatusNme";
        ListCaseStatus.DataValueField = "CaseStatusID";
        ListCaseStatus.DataBind();
        ListItem newItem = new ListItem();
        newItem.Text = "All";
        newItem.Value = "-1";
        ListCaseStatus.Items.Insert(0, newItem);
    }

    # endregion

    # region Grid Events

    protected void uxGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "page")
        {

        }
        else
        {
            // Convert the row index stored in the CommandArgument
            // Get the values from the appropriate 
            // cell in the GridView control.
             string Id = e.CommandArgument.ToString();

            if (e.CommandName == "Edit")
            {
                EditLink = EditLink + Id;
                Response.Redirect(EditLink);
            }
            else if(e.CommandName == "AddNote")
            {
                Response.Redirect(NotesLink + Id);
            }
            else if (e.CommandName == "Reply")
            {
                Response.Redirect(EmailLink + Id);
            }
            else if (e.CommandName == "View")
            {
                Response.Redirect(ViewLink + Id);
            }

        }
    }
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {        
        if (SearchBool)
        {
            uxGrid.PageIndex = e.NewPageIndex;
            this.BindSearchData();
        }
        else
        {
            uxGrid.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }

    # endregion
    
    # region Helper Methods

    public string GetCaseStatusByCaseID(Object FieldValue)
    {
        if (FieldValue == null)
        {
            return String.Empty;
        }
        else
        {
            CaseAdmin _CaseStatusAdminAccess = new CaseAdmin();
            CaseStatus _caseStatusList = _CaseStatusAdminAccess.GetByCaseStatusID(int.Parse(FieldValue.ToString()));
            if (_caseStatusList == null)
            {
                return string.Empty;
            }
            else
            {
                return _caseStatusList.CaseStatusNme;
            }
            
        }
    }
    public string GetCasePriorityByCaseID(Object FieldValue)
    {
        if (FieldValue == null)
        {
            return String.Empty;
        }
        else
        {
            CaseAdmin _CasePriorityAdmin = new CaseAdmin();
            CasePriority _CasePriority = _CasePriorityAdmin.GetByCasePriorityID(int.Parse(FieldValue.ToString()));
            if(_CasePriority == null)
            {
              return string.Empty;      
            }
            else
            {
            return _CasePriority.CasePriorityNme;
            }

        }
    }

    # endregion
  
}
