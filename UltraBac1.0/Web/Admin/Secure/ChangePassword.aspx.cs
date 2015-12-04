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
using System.Text;

public partial class Admin_Secure_ChangePassword : System.Web.UI.Page
{

    # region General Events

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void ContinuePushButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/default.aspx");
    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/default.aspx");
    }

    # endregion

    protected void ChangePassword1_ChangePasswordError(object sender, EventArgs e)
    {
        (ChangePassword1.ChangePasswordTemplateContainer.FindControl("PasswordFailureText") as  Literal).Text = " Current Password incorrect";
    }
}
