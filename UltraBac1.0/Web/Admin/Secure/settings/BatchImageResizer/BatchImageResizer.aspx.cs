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
using ZNode.Libraries.DataAccess.Custom;
using SCommImaging.Imaging;
using System.Drawing.Imaging;

public partial class Admin_Secure_settings_BatchImageResizer_BatchImageResizer : System.Web.UI.Page
{  
   
    #region pageload
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region events

    protected void btnsubmit_click(object sender, EventArgs e)
    {
        System.IO.DirectoryInfo path = new System.IO.DirectoryInfo(Server.MapPath(ZNodeConfigManager.EnvironmentConfig.OriginalImagePath));
        string[] patterns = { "*.jpg", "*.png" , "*.gif" , "*.jpeg" };        
        foreach (string pattern in patterns)
        {
            System.IO.FileInfo[] file = path.GetFiles(pattern);

            foreach (System.IO.FileInfo _FileInfo in file)
            {                
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemLargeWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.LargeImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemThumbnailWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.ThumbnailImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemMediumWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.MediumImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemSmallWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.SmallImagePath));

                lblMessage.Text = "The images have been successfully resized.";
                btnsubmit.Visible = false;
                btnCancel.Visible = false;
                btnback.Visible = true;
            }
        }           
    }

    protected void btncancel_click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/default.aspx");

    }

    protected void btnback_click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/default.aspx");

    }
    #endregion

    #region helper method

    /// <summary>
    /// Resizing the image size and storing it in the respective folder.
    /// </summary>
    /// <param name="PhysicalPathToFile"></param>
    /// <param name="width"></param>
    /// <param name="SaveToFullPath"></param>
    /// <returns></returns>
    public void ResizeImage(System.IO.FileInfo PhysicalPathToFile, int width, string SaveToFullPath)
    {
        SCommImaging.Imaging.ModifyImage mi = new ModifyImage();

        //set new width
        if (width > 0)
        {
            mi.NewWidth = width;
        }

        mi.SaveAsFormat = ImageFormat.Jpeg;
        mi.SaveToFullPath = SaveToFullPath + PhysicalPathToFile.Name;
        mi.SaveFileName = PhysicalPathToFile.Name;
        //mi.OpenModifyFileFromDisk(PhysicalPathToFile.FullName);
        mi.OpenModifyFileFromDisk(Server.MapPath(ZNodeConfigManager.EnvironmentConfig.OriginalImagePath + PhysicalPathToFile.Name));
    }
    #endregion
}
