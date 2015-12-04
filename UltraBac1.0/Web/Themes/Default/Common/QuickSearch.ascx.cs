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
using ZNode.Libraries.ECommerce.Business;

public partial class ContentBlocks_ECommerce_QuickSearch : System.Web.UI.UserControl
{
    #region Private Variables
    protected string SearchLink = string.Empty;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //set button image
        btnSearch.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/go.gif";

        ZNodeUrl url = new ZNodeUrl();
        SearchLink = "~/search.aspx";

        lblTitle.Text = ZNodeConfigManager.MessageConfig.GetMessage("QuickSearchTitle");
    }
    #endregion

    #region Events
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ZNodeUrl url = new ZNodeUrl();
        
        System.Text.StringBuilder link = new System.Text.StringBuilder();
        link.Append("~/search.aspx?keyword=");
        link.Append(Server.HtmlEncode(txtKeyword.Text.Trim()));
        
        Response.Redirect(link.ToString());
    }
    #endregion
}
