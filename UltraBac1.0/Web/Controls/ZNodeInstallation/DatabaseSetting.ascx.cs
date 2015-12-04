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

public partial class ZNodeInstallation_DatabaseSetting : System.Web.UI.UserControl
{
    # region Private Member Variables
    string serverName;
    string DBName;
    string UserId;
    string password;
    # endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    # region Public Properties

    public bool CheckDataBaseSetting
    {
        get
        {
            InstallAdmin _ZNodeInstall = new InstallAdmin();
            
            serverName = txtServerName.Text.Trim();
            DBName = txtDBName.Text.Trim();
            UserId = txtUserName.Text.Trim();
            Password = txtPassword.Text.Trim();

            Session["ServerName"] = serverName;
            Session["DBName"] = DBName;
            Session["UserID"] = UserId;
            Session["Password"] = password;

            bool ValidateSettings = _ZNodeInstall.CheckDataBaseSettings(ServerName,DataBaseName,UserName,Password);

            if (!ValidateSettings)
            {
                ErrorMsg.Text = "<div class=\"Error\"> Unable to connect to the database as per the settings you provided. Please correct the settings and try again</div>";
            }
            else
            {
                
            }

            return ValidateSettings;
        }

    }

    public String ServerName
    {
        get
        {
            return serverName;
        }
        set 
        {
            serverName = value;
        }
    }
    public String DataBaseName
    {
        get
        {
            return DBName;
        }
        set
        {
            DBName = value;
        }
    }
    public String UserName
    {
        get
        {
            return UserId;
        }
        set
        {
            UserId = value;
        }
    }
    public String Password
    {
        get
        {
            return password;
        }
        set
        {
            password  = value;
        }
    }
    # endregion

}
