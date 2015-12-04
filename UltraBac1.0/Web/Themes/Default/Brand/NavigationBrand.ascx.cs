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
using System.Xml;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.ECommerce.Business;

public partial class Controls_BrandNavigation : System.Web.UI.UserControl
{
    #region Private Variables
    protected string _selectedCategoryId = string.Empty;
    protected string _title = string.Empty;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            BindData();
        }
    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind data to the treeview
    /// </summary>
    private void BindData()
    {
        ZNodeNavigation navigation = new ZNodeNavigation();
        navigation.PopulateBrandTreeView(ctrlNavigation);

    }
    #endregion

}
