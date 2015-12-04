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
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Admin;


public partial class Admin_Secure_customers_view : System.Web.UI.Page
{

    # region Protected Member Variables
    protected int AccountID;
    # endregion
        
    # region Protected Bind Methods

    protected void BindData()
    {
                
        AccountAdmin _AccountAdmin = new AccountAdmin();
        AccountTypeAdmin _AccountTypeAdmin = new AccountTypeAdmin();
        ProfileAdmin _ProfileAdmin = new ProfileAdmin();
        CustomerAdmin _CustomerAdmin = new CustomerAdmin();

        ZNode.Libraries.DataAccess.Entities.Account AccountList = _AccountAdmin.GetByAccountID(AccountID);

        if (AccountList != null)
        {
           
            //General Information
            
            lblAccountID.Text = AccountList.AccountID.ToString();
            lblCompanyName.Text = AccountList.BillingCompanyName;
            lblExternalAccNumber.Text = AccountList.ExternalAccountNo;
            lblDescription.Text = AccountList.Description;
            lblLoginName.Text = _CustomerAdmin.GetByUserID(int.Parse(AccountID.ToString()));
            lblCustomerDetails.Text = AccountList.AccountID.ToString() + " - " + AccountList.BillingFirstName + " " + AccountList.BillingLastName;
            lblWebSite.Text = AccountList.Website;
            lblSource.Text = AccountList.Source;
            lblCreatedDate.Text = AccountList.CreateDte.ToShortDateString();
            lblCreatedUser.Text = AccountList.CreateUser;

            if (AccountList.UpdateDte != null)
            {
                lblUpdatedDate.Text = AccountList.UpdateDte.Value.ToShortDateString();
            }

            lblUpdatedUser.Text = AccountList.UpdateUser;
            lblCustom1.Text = AccountList.Custom1;
            lblCustom2.Text = AccountList.Custom2;
            lblCustom3.Text = AccountList.Custom3;

            //Get Account Type for a Account
            AccountType _AccountType = _AccountTypeAdmin.GetByAccountTypeID(int.Parse(AccountList.AccountTypeID.ToString()));

            //Get Profile Type Name for a Account
            Profile _profileList = _ProfileAdmin.GetByProfileID(int.Parse(AccountList.ProfileID.ToString()));
            lblProfileTypeName.Text = _profileList.Name;

            //Address Information

            ZNodeAddress AddressFormat = new ZNodeAddress();

            //Format Billing Address
            AddressFormat.FirstName = AccountList.BillingFirstName;
            AddressFormat.LastName = AccountList.BillingLastName;
            AddressFormat.Street1 = AccountList.BillingStreet;
            AddressFormat.Street2 = AccountList.BillingStreet1;
            AddressFormat.City = AccountList.BillingCity;
            AddressFormat.StateCode = AccountList.BillingStateCode;
            AddressFormat.PostalCode = AccountList.BillingPostalCode;
            
            lblBillingAddress.Text = AddressFormat.ToString() + "Tel: " + AccountList.BillingPhoneNumber + "<br />Email: " + AccountList.BillingEmailID;

            //Format Shipping Address

            AddressFormat.FirstName = AccountList.ShipFirstName;
            AddressFormat.LastName = AccountList.ShipLastName;
            AddressFormat.Street1 = AccountList.ShipStreet;
            AddressFormat.Street2 = AccountList.ShipStreet1;
            AddressFormat.City = AccountList.ShipCity;
            AddressFormat.StateCode = AccountList.ShipStateCode;
            AddressFormat.PostalCode = AccountList.ShipPostalCode;
            

            lblShippingAddress.Text = AddressFormat.ToString() + "Tel: " + AccountList.ShipPhoneNumber + "<br />Email: " + AccountList.ShipEmailID;

            if (AccountList.ContactTemperatureID.HasValue)
            {
                ContactTemperature _ContactTempearture = _CustomerAdmin.GetByContactTemperatureID(AccountList.ContactTemperatureID.Value );
                lblContactTemperature.Text = _ContactTempearture.Name;

            }

            //Orders Grid
            this.BindGrid();
        }


    }

    # endregion

    # region Bind Grid

    /// <summary>
    /// Bind Order Grid
    /// </summary>
    protected void BindGrid()
    {
        OrderAdmin _OrderAdmin = new OrderAdmin();
        //TList<Order> _Orders = _OrderAdmin.GetByAccountID(AccountID);
        DataSet DataSetOrderList = _OrderAdmin.GetByAccountID(AccountID, ZNodeConfigManager.SiteConfig.PortalID);

        uxGrid.DataSource = DataSetOrderList;
        uxGrid.DataBind();
        
    }

    /// <summary>
    /// //Bind Repeater
    /// </summary>
    protected void BindNotes()
    {
        
        NoteAdmin _NoteAdmin = new NoteAdmin();
        TList<Note> noteList =  _NoteAdmin.GetByAccountID(AccountID);
        noteList.Sort("NoteID Desc");
        CustomerNotes.DataSource = noteList;
        CustomerNotes.DataBind();
    }

    # endregion

    # region General Events

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["itemid"] != null)
        {
            AccountID = int.Parse(Request.Params["itemid"].ToString());
        }
        else
        {
            AccountID = 0;
        }

        if (!IsPostBack)
        {
            this.BindData();
            this.BindNotes();
        }
    }


    /// <summary>
    /// CustomerList Button  Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerList_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }

    /// <summary>
    /// Edit Customer Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("edit.aspx?itemid=" + AccountID);
    }

    /// <summary>
    /// Add Note Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddNewNote_Click(object sender, EventArgs e)
    {
        Response.Redirect("note_add.aspx?itemid=" + AccountID);
    }

    # endregion

    # region Helper Methods

    /// <summary>
    /// Format the Price with two decimal
    /// </summary>
    /// <param name="Fieldvalue"></param>
    /// <returns></returns>
    protected string FormatPrice(Object Fieldvalue)
    {
        if (Fieldvalue == DBNull.Value)
        {
            return string.Empty;
        }
        else
        {
            if (Fieldvalue.ToString().Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return "$" + Fieldvalue.ToString().Substring(0, Fieldvalue.ToString().Length - 2);
            }
        }
    }

    /// <summary>
    /// Display the Order State name for a Order state
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    protected string DisplayOrderStatus(object FieldValue)
    {
        ZNode.Libraries.Admin.OrderAdmin _OrderStateAdmin = new OrderAdmin();
        OrderState _OrderState = _OrderStateAdmin.GetByOrderStateID(int.Parse(FieldValue.ToString()));
        return _OrderState.OrderStateName.ToString();
    }

    /// <summary>
    ///  Format Customer Note
    /// </summary>
    /// <param name="Field1"></param>
    /// <param name="Field2"></param>
    /// <param name="Field3"></param>
    /// <returns></returns>
    protected string FormatCustomerNote(Object Field1, Object Field2, Object Field3)
    {
        return "<b>" + Field1.ToString() + "</b>  [created by " + Field2.ToString() + " on " + Convert.ToDateTime(Field3).ToShortDateString() + "]";
    }
    # endregion

    # region Grid Events
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    # endregion
}
