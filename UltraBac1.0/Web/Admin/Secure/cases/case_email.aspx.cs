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
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

public partial class Admin_Secure_cases_case_email : System.Web.UI.Page
{

    # region Protected Member Variables
        protected int ItemId = 0;
        protected string RedirectLink = "~/admin/secure/cases/list.aspx";
    # endregion

    # region Page Load

        /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["itemid"] != null)
        {
            ItemId = int.Parse(Request.Params["itemid"].ToString());
        }
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    # endregion

    # region General Events

    /// <summary>
    /// Submit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ZNodeEmail.SendEmail(lblEmailid.Text, ZNodeConfigManager.SiteConfig.AdminEmail, string.Empty, txtEmailSubj.Text, ctrlHtmlText.Html, true);
        Response.Redirect(RedirectLink);
    }

    /// <summary>
    /// Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(RedirectLink);
    }

    private void BindData()
    {
        CaseAdmin _CaseAdmin = new CaseAdmin();
        Case _CaseList = _CaseAdmin.GetByCaseID(ItemId);

        if (_CaseList != null)
        {
            txtEmailSubj.Text = _CaseList.Title;
            lblEmailid.Text = _CaseList.EmailID;
        }
    }

    # endregion

}
