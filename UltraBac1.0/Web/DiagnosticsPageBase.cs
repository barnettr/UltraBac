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
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Diagnostics;
using System.Security.Principal;
using System.Security.Authentication;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;


public partial class DiagnosticsPageBase : System.Web.UI.Page
{
    # region Protected Variables
    StringBuilder build = new StringBuilder();
    int ErrorCount = 0;
    # endregion

    # region General Events
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
 
        //Check for Postback
        if (!Page.IsPostBack)
        {
            this.CheckDataBaseConnection();

            if (this.CheckPermissions(ZNodeConfigManager.EnvironmentConfig.DataPath))
            {
                lblPublicPermissions.CssClass = "Success";
                lblPublicPermissions.Text = " Public folder - Read + Write Ok";
            }
            else
            {
                lblPublicPermissions.Text = " Permissions on the Public folder failed";
                lblPublicPermissions.CssClass = "DiagnosticError";
            }

            this.LicenseStatus();
            this.CheckEmailAccount();
            if (build.Length > 0)
            {
                lblMsg.Text = build.ToString();
                PnlExceptionSummary.Visible = true;
            }
        }
        
    }
    # endregion

    # region Helper Methods

    /// <summary>
    /// Check SMTP Account
    /// </summary>
    private void CheckEmailAccount()
    {
        try
        {
            ZNodeEmail.SendEmail("support@znode.com", "support@znode.com", "", "Diagnostic Test", "SMTP Account Test", false);

            lblSMTPAccountStatus.Text = " SMTP Settings ok";
            lblSMTPAccountStatus.CssClass = "Success";
        }
        catch (System.Net.Mail.SmtpException SMTPException)
        {
            build.Append("Error " + (++ErrorCount) + ": " + SMTPException.ToString() + "<br /><br />");
            lblSMTPAccountStatus.Text = " Could not connect to a valid SMTP Service.";
            lblSMTPAccountStatus.CssClass = "Optional";
        }
        catch (Exception GeneralException)
        {
            build.Append("Error " + (++ErrorCount) + ": " +  GeneralException.ToString() + "<br /><br />");
            lblSMTPAccountStatus.Text = " Could not connect to a valid SMTP Service.";
            lblSMTPAccountStatus.CssClass = "Optional";
        }
    }

    /// <summary>
    /// Check Public Fodler for Read + Write Permissions
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private bool CheckPermissions(string path)
    {
        bool Check = false;

        try
        {
            FileInfo file = new FileInfo(Server.MapPath(path) + "test.txt");
            FileStream filestream = file.Create();

            filestream.Close();
            file.Delete();
            Check = true;
        }
        catch (Exception)
        {
            build.Append("Error " + (++ErrorCount) + ":" + "Read / Write action is denied for Users<br /><br />");

            //Set to false if folder has no Read/Write Rights
            Check = false;
        }        

        //return Value
        return Check;
        
    }

    /// <summary>
    /// Get the product Version
    /// </summary>
    /// <returns></returns>
    public string GetProductVersion()
    {
        try
        {
            string path = ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.ApplicationPath + "/Bin/ZNode.Libraries.Framework.Business.dll";

            //Create Instance for FileVersionInfo object
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(Server.MapPath(path));
            if (info != null)
            {
                return "- v" + info.FileVersion;
            }
            else
            {
                return String.Empty;
            }
        }
        catch (Exception)
        {
            return String.Empty;
        }
    }

    /// <summary>
    /// Check for Database connection String
    /// </summary>
    private void CheckDataBaseConnection()
    {
        try
        {                        
            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString);

            //Open Connection
            myConnection.Open();

            //Close Connection
            myConnection.Close();

            //Release resources
            myConnection.Dispose();

            lblDatabaseStatus.Text = " Database Connection ok";
            lblDatabaseStatus.CssClass = "Success";
        }
        catch(Exception SQLException)
        {
            build.Append("Error " + (++ErrorCount) + ": " + SQLException.ToString());
            build.Append("<br /><br />");
            //Set Failed message text 
            lblDatabaseStatus.Text = " Database Connection failed";
            lblDatabaseStatus.CssClass = "DiagnosticError";
        }

    }

    /// <summary>
    /// Check for License Status
    /// </summary>
    private void LicenseStatus()
    {
        try
        {
            //Create Instance for License Manager
            ZNodeLicenseManager LicenseManager = new ZNodeLicenseManager();
            ZNodeLicenseType _LicenseStatus = LicenseManager.Validate();

            //Check License Status
            if (_LicenseStatus == ZNodeLicenseType.Trial)
            {
                StringBuilder sbTitle = new StringBuilder(" ");
                sbTitle.Append("Free Trial - ");
                sbTitle.Append(LicenseManager.DemoDaysRemaining().ToString());
                sbTitle.Append(" Days Remaining");
                lblLicenseStatus.CssClass = "DiagnosticError";
                lblLicenseStatus.Text = sbTitle.ToString();
            }
            else if (_LicenseStatus == ZNodeLicenseType.Invalid)
            {
                build.Append("Error " + (++ErrorCount) + ": " + "Invalid ZnodeStorefront License");
                build.Append("<br /><br />");
            }           
            else 
            {
                StringBuilder sbTitle = new StringBuilder(" ");
                sbTitle.Append("Valid Storefront License Found");
                lblLicenseStatus.CssClass = "Success";
                lblLicenseStatus.Text = sbTitle.ToString();
            }
        }
        catch (ZNodeLicenseException LicenseException) 
        {
            build.Append("Error " + (++ErrorCount) + ": " + LicenseException.Message);
        }
    }

	protected void btnTestError_Click(Object sender, EventArgs e)
	{
		throw new Exception("This is a test exception thrown from the diagnostics.aspx page.");
	}

	protected void btnTestEmail_Click(Object sender, EventArgs e)
	{
		try
		{
			ZNodeEmail.SendEmail(txtTestEmailTo.Text, txtTestEmailFrom.Text, "", "Emily's Chocolates Test Email", "Emily's Chocolates Email Message Diagnostics", false);
			lblTestEmailResult.Text = "email sent!";
		}
		catch ( System.Net.Mail.SmtpException SMTPException )
		{
			lblTestEmailResult.Text = SMTPException.ToString();
		}
		catch ( Exception GeneralException )
		{
			lblTestEmailResult.Text = GeneralException.ToString();
		}
	}

	protected void btnTestSessionAbandon_Click(Object sender, EventArgs e)
	{
		try
		{
			Session.Abandon();
			lblSessionAbandon.Text = "Session dropped.";
		}
		catch
		{
			lblSessionAbandon.Text = "Unable to drop session";
		}
	}

	#endregion
}

