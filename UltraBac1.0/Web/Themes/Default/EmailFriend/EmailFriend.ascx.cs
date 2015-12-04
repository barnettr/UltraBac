using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;

public partial class Themes_Default_EmailFriend_EmailFriend : System.Web.UI.UserControl
{
    # region Protected Variables
    protected int ProductID = 0;
    # endregion

    # region Page Load Event

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            ProductID = int.Parse(Request.QueryString["pid"]);
        }
    }
    # endregion

    # region General Events
    /// <summary>
    /// Email Send Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void but_Send_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder build = new StringBuilder("<font famliy=\"Verdana\" size=\"3\" weight=\"normal\">I thought you would be interested in this item.");
            build.Append("<br />");
            build.Append("Page URL: <a href=http://" + ZNodeConfigManager.SiteConfig.DomainName + "/product.aspx?pid=" + ProductID.ToString() + ">" + this.GetProductName() + "</a>");
            build.Append("<br /><br />");
            build.Append("This email was sent from <a href=http://" + ZNodeConfigManager.SiteConfig.DomainName + ">" + ZNodeConfigManager.SiteConfig.CompanyName + "</a></font>");

            ZNodeEmail.SendEmail(Email.Text.Trim(), FromEmailID.Text.Trim(), "", "Product Link", build.ToString(), true);

            pnlConfirm.Visible = true;
            pnlEmailFriend.Visible = false;

            lblMessage.Text = " Your Email Has Been Sent. ThankYou.";
            //lblMessage.CssClass = "SuccessMsg";
        }
        catch (Exception)
        {
            pnlConfirm.Visible = true;
            lblMessage.Text = "Couldn't send mail to your friend. Please try again.";
            lblMessage.CssClass = "Error";
        }

    }

    /// <summary>
    /// Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/product.aspx?pid=" + ProductID.ToString());
    }

    # endregion

    # region Helper Methods
    /// <summary>
    /// Get product Name
    /// </summary>
    /// <returns></returns>
    public string GetProductName()
    {
        ZNodeProduct _product = ZNodeProduct.Create(ProductID, ZNodeConfigManager.SiteConfig.PortalID);

        if (_product != null)
        {
            return _product.Name;
        }
        else
        {
            return String.Empty;
        }
    }
    # endregion
}
