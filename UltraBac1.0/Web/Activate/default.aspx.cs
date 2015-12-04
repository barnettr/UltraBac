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

public partial class Admin_Activate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {     
            chkFreeTrial.Visible = true;
            chkFreeTrial.Checked = true;
            pnlSerial.Visible = false;            
        }
    }

    /// <summary>
    /// Initialize display
    /// </summary>
    private void InitDisplay()
    {
        lblConfirm.Text = "";

        pnlConfirm.Visible = false;
        pnlLicenseActivate.Visible = false;
    }

    /// <summary>
    /// Activate button clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivateLicense_Click(object sender, EventArgs e)
    {
        //check if user agreed to EULA
        if (!chkEULA.Checked)
        {
            lblError.Text = "Storefront Activation requires that you accept the software license agreement";
            return;
        }

        //get the target license requested
        ZNodeLicenseType lt = ZNodeLicenseType.Trial; //default
        if (chkFreeTrial.Checked)
        {
            lt = ZNodeLicenseType.Trial;
        }
        else if (chkStandard.Checked)
        {
            lt = ZNodeLicenseType.Standard;
        }
        else if (chkProfessional.Checked)
        {
            lt = ZNodeLicenseType.Professional;
        }
        else if (chkServer.Checked)
        {
            lt = ZNodeLicenseType.Server;
        }

        //install license
        ZNodeLicenseManager lm = new ZNodeLicenseManager();
        bool retval = false;
        string ErrorMessage = "";
        retval = lm.InstallLicense(lt,txtSerialNumber.Text.Trim(),txtName.Text, txtEmail.Text,out ErrorMessage);
        
        //if success
        if (retval)
        {
            lblConfirm.Text = "Your Znode Storefront license has been successfully activated.";
            pnlConfirm.Visible = true;
            pnlLicenseActivate.Visible = false;
        }
        //install failed
        else
        {
            lblError.Text = "Failed to activate license. ";
            lblError.Text = lblError.Text + ErrorMessage;
        }

    }

    /// <summary>
    /// License option changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkFreeTrial_CheckedChanged(object sender, EventArgs e)
    {
        
        if (chkFreeTrial.Visible)
        {
            if (chkFreeTrial.Checked)
            {
                pnlSerial.Visible = false;
            }
            else
            {
                pnlSerial.Visible = true;
            }
        }
        else
        {
            pnlSerial.Visible = true;
        }
    }
}
