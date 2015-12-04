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

public partial class Themes_Default_Account_Password : System.Web.UI.UserControl
{
    #region Events
    protected void ChangePassword1_ChangePasswordError(object sender, EventArgs e)
    {
        (ChangePassword1.ChangePasswordTemplateContainer.FindControl("PasswordFailureText") as Literal).Text = "Current Password Incorrect";
    }
    #endregion
}
