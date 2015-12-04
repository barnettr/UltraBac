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
//using Dart.PowerWEB.TextBox;
using Telerik.WebControls;
using Telerik.RadEditorUtils;

public partial class Controls_HtmlTextBox : System.Web.UI.UserControl
{
    private int _Mode;

    /// <summary>
    /// Gets or sets the html text
    /// </summary>
    public string Html
    {
        get
        {
            return ctrlHTML.Html; 
        }
        set
        {
            ctrlHTML.Html = value;
        }
    }

    /// <summary>
    /// Sets the mode for this control
    /// </summary>
    public int Mode
    {   
        set
        {
            _Mode = value;
        }
        get
        {
            return _Mode;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //initialize properties
        string[] imageUploadPaths = {ZNodeConfigManager.EnvironmentConfig.OriginalImagePath};

        ctrlHTML.AllowScripts = true;
        ctrlHTML.ConvertToXhtml = false;
        ctrlHTML.EnableHtmlIndentation = true;

        ctrlHTML.ImagesPaths = imageUploadPaths;
        ctrlHTML.UploadImagesPaths = imageUploadPaths;
        ctrlHTML.MediaPaths = imageUploadPaths;
        ctrlHTML.UploadMediaPaths = imageUploadPaths;
        ctrlHTML.FlashPaths = imageUploadPaths;
        ctrlHTML.UploadFlashPaths = imageUploadPaths;
        
        ctrlHTML.DeleteImagesPaths = imageUploadPaths;
        ctrlHTML.DeleteFlashPaths = imageUploadPaths;
        ctrlHTML.DeleteMediaPaths = imageUploadPaths;

        string[] documentUploadPaths = {ZNodeConfigManager.EnvironmentConfig.ContentPath };
        ctrlHTML.DocumentsPaths = documentUploadPaths;
        ctrlHTML.UploadDocumentsPaths = documentUploadPaths;
        ctrlHTML.DeleteDocumentsPaths = documentUploadPaths;       
        
        ctrlHTML.Width = Unit.Percentage(100);

        string[] cssPaths = { "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/common/style.css" };
        ctrlHTML.CssFiles = cssPaths;

        //set mode
        if (Mode == 0) //Full Mode
        {
            ctrlHTML.ToolsFile = "~/controls/toolsfilefull.xml";           
        }
        else if (Mode == 1) //Limited editor Mode
        {
            ctrlHTML.ToolsFile = "~/controls/toolsfilelimited.xml";   
        }
    }
}
