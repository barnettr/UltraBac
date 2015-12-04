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
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;

public partial class Admin_Secure_catalog_product_addrelateditems : System.Web.UI.Page
{
    # region Protected Member Variables
    protected int ItemID = 0;
    protected string ViewPage = "view.aspx?itemid=";
    # endregion

    # region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["itemid"] != null)
        {
            ItemID = int.Parse(Request.Params["itemid"].ToString());
        }
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        ProductCrossSellAdmin _ProdCrossAdmin = new ProductCrossSellAdmin();
        string Selvalue = Listproducts.SelectedValue.ToString();

        bool Check =false;

        if (ItemID != int.Parse(Selvalue))
        {
           Check = _ProdCrossAdmin.Insert(ZNodeConfigManager.SiteConfig.PortalID, ItemID, Convert.ToInt32(Selvalue));
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "You are trying to add same product as Related Item";
        }

        if (Check)
        {
            Response.Redirect(ViewPage + ItemID + "&mode=crosssell");
        }
        
    }

    /// <summary>
    /// Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewPage + ItemID + "&mode=crosssell");
    }

# endregion

    # region Bind

    private void BindData()
    {
        ProductAdmin Admin = new ProductAdmin();
        Listproducts.DataSource = Admin.GetAllProducts(ZNodeConfigManager.SiteConfig.PortalID);
        Listproducts.DataValueField = "ProductId";
        Listproducts.DataTextField = "name";
        Listproducts.DataBind();
    }

    # endregion
}
