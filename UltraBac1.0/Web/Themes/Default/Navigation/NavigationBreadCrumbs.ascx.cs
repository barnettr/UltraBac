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
using ZNode.Libraries.ECommerce.Business ;

/// <summary>
/// Displays the bread crumb menu for the storefront pages
/// </summary>
public partial class Controls_NavigationBreadCrumbs : System.Web.UI.UserControl
{
    #region Private Variables
    private int _categoryId = 0;
    private int _productId = 0;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //get category id from querystring  
        if (Request.Params["cid"] != null)
        {
            _categoryId =int.Parse(Request.Params["cid"]);
        }

        //get product id from querystring  
        if (Request.Params["pid"] != null)
        {
            _productId = int.Parse(Request.Params["pid"]);
        }

        //default path
        ZNodeNavigation navigation = new ZNodeNavigation();
        StringBuilder sbBreadCrumbPath = new StringBuilder();
        sbBreadCrumbPath.Append(navigation.CreateLink("default.aspx",ZNode.Libraries.Framework.Business.ZNodeConfigManager.MessageConfig.GetMessage("BreadCrumbHome").ToString()));

        //get bread crumb string based on category/ product        
        sbBreadCrumbPath.Append(navigation.GetBreadCrumbPath(_categoryId, _productId, " > "));
        
        //set label to breadcrumb
        lblPath.Text = sbBreadCrumbPath.ToString();
    }
    #endregion

}
