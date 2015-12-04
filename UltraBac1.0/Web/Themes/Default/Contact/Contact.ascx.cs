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
using System.Net;
using ZNode.Libraries.Framework.Business;
using System.Text;

public partial class Themes_Default_Contact_Contact : System.Web.UI.UserControl
{
    # region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    # endregion

    # region General Events
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SendEmail();
        CreateCaseRecord();
        pnlContact.Visible = false;
        pnlConfirm.Visible = true;
    }
    # endregion
    
    # region Helper Methods

    /// <summary>
    /// Send Email Receipt
    /// </summary>
    private void SendEmail()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("This message was sent using the contact us form on your website: ");
        sb.Append(System.Environment.NewLine);
        sb.Append(System.Environment.NewLine);
        sb.Append("Name: ");
        sb.Append(FirstName.Text);
        sb.Append(" ");
        sb.Append(LastName.Text);
        sb.Append(System.Environment.NewLine);
        sb.Append("Company Name:");
        sb.Append(CompanyName.Text);
        sb.Append(System.Environment.NewLine);
        sb.Append("Phone Number: ");
        sb.Append(PhoneNumber.Text);
        sb.Append(System.Environment.NewLine);
        sb.Append("Comments: ");
        sb.Append(System.Environment.NewLine);
        sb.Append(Comments.Text);

        ZNodeEmail.SendEmail(ZNodeConfigManager.SiteConfig.CustomerServiceEmail, Email.Text, "", "Feedback from Website Visitor", sb.ToString(), false);

    }

    /// <summary>
    /// Creates New Case Record
    /// </summary>
    private void CreateCaseRecord()
    {
        ZNode.Libraries.Admin.CaseAdmin _CaseAdmin = new ZNode.Libraries.Admin.CaseAdmin();
        ZNode.Libraries.DataAccess.Entities.Case CaseRecord = new ZNode.Libraries.DataAccess.Entities.Case();

        //Set Values 
        CaseRecord.Title = "Contact Form Submission";
        CaseRecord.FirstName = FirstName.Text;
        CaseRecord.LastName = LastName.Text;
        CaseRecord.CompanyName = CompanyName.Text;
        CaseRecord.PhoneNumber = PhoneNumber.Text;
        CaseRecord.EmailID = Email.Text;
        CaseRecord.Description = Comments.Text;

        //Set Some Default Values
        CaseRecord.CasePriorityID = 3;
        CaseRecord.CaseStatusID = 1;
        CaseRecord.CreateDte = System.DateTime.Now;
        CaseRecord.PortalID = ZNodeConfigManager.SiteConfig.PortalID;
        CaseRecord.OwnerAccountID = null;
        CaseRecord.CaseOrigin = "Contact Us Form";
        CaseRecord.CreateUser = System.Web.HttpContext.Current.User.Identity.Name;

        if (Session[ZNodeSessionKeyType.UserAccount.ToString()] != null)
        {
            ZNodeUserAccount _usrAccount = Session[ZNodeSessionKeyType.UserAccount.ToString()] as ZNodeUserAccount;
            CaseRecord.AccountID = _usrAccount.AccountID;

        }
        else
        {
            CaseRecord.AccountID = null;
        }

        //Add New Case for this Email
        _CaseAdmin.Add(CaseRecord);
    }
    # endregion
}
