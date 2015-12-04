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

public partial class Admin_Secure_catalog_coupons_delete : System.Web.UI.Page
{
    #region Protected Variables
    protected int ItemID;
    protected string RedirectLink = "~/admin/secure/catalog/coupons/list.aspx";
    protected string CouponCode = string.Empty;
    #endregion

    # region Page Load
    
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get ItemID from querystring        
        if (Request.Params["ItemID"] != null)
        {
            ItemID = int.Parse(Request.Params["ItemID"]);
        }
        else
        {
            ItemID = 0;
        }

        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    # endregion

    # region Bind Data

    private void BindData()
    {
        ZNode.Libraries.Admin.CouponAdmin couponbind = new ZNode.Libraries.Admin.CouponAdmin();

        ZNode.Libraries.DataAccess.Entities.Coupon couponlist = couponbind.GetByCouponID(ItemID);

        if (couponlist != null)
        {
            CouponCode = couponlist.CouponCode;
        }
    }

    # endregion

    # region General Events

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ZNode.Libraries.Admin.CouponAdmin couponbind = new ZNode.Libraries.Admin.CouponAdmin();
       
        bool check = false;        
        check = couponbind.Delete(ItemID);
        
        if (check)
        {
            Response.Redirect(RedirectLink);
        }
        else
        {
            lblErrorMsg.Text = "Delete action could not be completed.";
            lblErrorMsg.Visible = true;
        }
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(RedirectLink);
    }

    # endregion
    
}
