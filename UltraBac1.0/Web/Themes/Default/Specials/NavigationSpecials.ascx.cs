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

public partial class Controls_NavigationSpecials : System.Web.UI.UserControl
{
    #region Private Variables
    protected string _selectedCategoryId = string.Empty;
    protected string _title = string.Empty;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
        navigation.PopulateSpecialsTreeView(ctrlNavigation);

        if (ctrlNavigation.Nodes.Count == 0)
        {
            pnlProductList.Visible = false;
        }
        else
        {
            pnlProductList.Visible = true;
        }

    }
    #endregion

}
