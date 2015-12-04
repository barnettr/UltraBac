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
using System.Net.Mail;

public partial class Themes_Default_Account_ForgotPassword : System.Web.UI.UserControl
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        PasswordRecovery1.MailDefinition.From = ZNodeConfigManager.SiteConfig.CustomerServiceEmail;
        PasswordRecovery1.MailDefinition.Subject = "Your Account";
    }

    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {
        e.Cancel = true;
        string smtpServer = ZNodeConfigManager.SiteConfig.SMTPServer;
        string senderEmail = ZNodeConfigManager.SiteConfig.CustomerServiceEmail;
        string subject = "Account Information";
        string loginName = PasswordRecovery1.UserName;
        MembershipUser user = Membership.GetUser(loginName);
        string LoginPassword = user.ResetPassword(PasswordRecovery1.Answer);
        string body = "Your account credentials have been reset. Please return to the site and log in using the following information.";
        body += Environment.NewLine + "User Name:  " + loginName + Environment.NewLine;
        body += "Password: " + Server.HtmlEncode(LoginPassword);
        ZNodeEmail.SendEmail(user.Email, senderEmail, String.Empty, subject, body, false);
        return;
    }
    #endregion
}
