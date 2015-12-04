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
using ZNode.Libraries.Framework.Business ;

/// <summary>
/// Displays the logo
/// </summary>
public partial class Controls_Logo_Logo : System.Web.UI.UserControl
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        uxLogoImage.ImageUrl = ZNodeConfigManager.SiteConfig.LogoPath;
    }
    #endregion
}
