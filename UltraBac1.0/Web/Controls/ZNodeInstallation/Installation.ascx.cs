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
using System.IO;
using System.Security.Permissions;
using System.Security.AccessControl;

public partial class ZNodeInstallation_Installation : System.Web.UI.UserControl
{

    # region Private Member Variables
    string serverName;
    string DBName;
    string UserId;
    string password;
    # endregion

    # region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
           
    }  

    # endregion

    # region Public Properties
    public bool InstallationProgress
    {
        get
        {
            if (RunDataBaseScript)
            {
                ErrorMsg.Text = "<div class=\"CheckMark\">" + "&nbsp;Database successfully Configured.</div><br />";
            }
            else
            {
                ErrorMsg.Text = "<div class=\"ExclamationMark\">" + "&nbsp;Error while configuring Database.</div><br/>";
            }
            if (CheckPublicFolderPermission)
            {
                ErrorMsg.Text += "<div class=\"CheckMark\">" + "&nbsp;Read + Write Permission on Public Folder.</div><br clear=all/>";
            }
            else
            {
                ErrorMsg.Text += "<div class=\"ExclamationMark\">" + "&nbsp;Add Read + Write permissions to the “Public” folder.</div><br clear=all/>";
            }
            if (ConfigurationSettings)
            {
                ErrorMsg.Text += "<div class=\"CheckMark\">" + "&nbsp;Connection string in the web.config file are updated Successfull.</div><br/>";
            }
            else
            {
                ErrorMsg.Text += "<div class=\"ExclamationMark\">" + "&nbsp;Add Read + Write permissions to the Web.config folder</div><br/>";
            }

            return true;
        }
    }
    public bool RunDataBaseScript
    {
        get
        {
            bool Check = false;

            //Create Instance for InstallAdmin
            ZNode.Libraries.Admin.InstallAdmin _InstallAdmin = new ZNode.Libraries.Admin.InstallAdmin();

            Check = _InstallAdmin.ConfigureDataBase(serverName, DBName, UserId, password);

            return Check;
        }
    }
    public bool CheckPublicFolderPermission
    {
        get
        {
            bool Check = false;

            //Create Instance for InstallAdmin
            ZNode.Libraries.Admin.InstallAdmin _InstallAdmin = new ZNode.Libraries.Admin.InstallAdmin();

            Check = _InstallAdmin.ValidateDirectoryPermission();

            return Check;
     
        }
    }
    public bool ConfigurationSettings
    {
        get
        {
            bool check = false;
            //Create Instance for InstallAdmin
            ZNode.Libraries.Admin.InstallAdmin _InstallAdmin = new ZNode.Libraries.Admin.InstallAdmin();

            check = _InstallAdmin.SetupConfiugarationFile(serverName, DBName, UserId, password);

            //Return Boolean Value
            return check;
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
            password = value;
        }
    }
    # endregion
}
