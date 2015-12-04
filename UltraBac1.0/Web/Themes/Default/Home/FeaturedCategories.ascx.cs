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
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;

public partial class Themes_Default_Home_FeaturedCategories : System.Web.UI.UserControl
{
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.BindGrid();
    }
    #endregion

    #region bind
    /// <summary>
    /// Binds a Grid
    /// </summary>
    private void BindGrid()
    {
        uxdatalist.RepeatColumns = ZNodeConfigManager.SiteConfig.MaxCatalogDisplayColumns;

        CategoryHelper categoryHelper = new CategoryHelper();
        DataSet ds = categoryHelper.GetRootCategoryItems(ZNodeConfigManager.SiteConfig.PortalID);
        uxdatalist.DataSource = ds;
        uxdatalist.DataBind();
    }
    #endregion
}
