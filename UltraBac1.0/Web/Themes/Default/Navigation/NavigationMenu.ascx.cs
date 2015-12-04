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
using ZNode.Libraries.ECommerce.Business;

public partial class Controls_NavigationMenu : System.Web.UI.UserControl
{
    #region Page Load
    protected void Page_Load(object sender, System.EventArgs e)
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
        //menu properties
        ctrlMenu.Orientation = Orientation.Horizontal;
               
        //Add default item
        MenuItem miDefault = new MenuItem();
        miDefault.Text = ZNodeConfigManager.MessageConfig.GetMessage("MenuHome");
        miDefault.NavigateUrl = "~/default.aspx";
        ctrlMenu.Items.Add(miDefault);

        ZNodeNavigation navigation = new ZNodeNavigation();
        navigation.PopulateStoreMenu(ctrlMenu);
    }
    #endregion

}
