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
using System.Diagnostics;

public partial class Admin_Secure_Default : System.Web.UI.Page
{
    protected DashboardAdmin dashAdmin = new DashboardAdmin();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    /// <summary>
    /// Bind data to the dashboard
    /// </summary>
    protected void BindData()
    {
        dashAdmin.GetDashboardItems();

        //set properties
    }

    # region Helper Methods

    /// <summary>
    /// Get the product Version
    /// </summary>
    /// <returns></returns>
    public string GetProductVersion()
    {
        //hardcoded for Oct 2007 release - please remove this line in the next release
        return "- v4.3" ;

        try
        {
            string path = ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.ApplicationPath + "/Bin/ZNode.Libraries.Framework.Business.dll";

            //Create Instance for FileVersionInfo object
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(Server.MapPath(path));
            if (info != null)
            {
                return "- v" + info.FileVersion;
            }
            else
            {
                return String.Empty;
            }
        }
        catch (Exception)
        {
            return String.Empty;
        }
    }
    # endregion
}
