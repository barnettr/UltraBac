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
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;
using SCommImaging.Imaging;
using System.Drawing.Imaging;

public partial class Admin_Secure_catalog_product_add_view : System.Web.UI.Page
{

    #region Protected member variable
    protected int ItemID = 0;
    protected int ProductImageID = 0;
    protected int productTypeID = 0;
    protected string EditLink = "~/admin/secure/catalog/product/view.aspx?itemid=";
    protected string CancelLink = "~/admin/secure/catalog/product/view.aspx?itemid=";
    #endregion

    #region page load

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["itemid"] != null)
        {
            ItemID = int.Parse(Request.Params["itemid"].ToString());
        }
        if (Request.Params["productimageid"] != null)
        {
            ProductImageID = int.Parse(Request.Params["productimageid"].ToString());
        }
        if (Request.Params["typeid"] != null)
        {
            productTypeID = int.Parse(Request.Params["typeid"].ToString());
        }
      

        if (!Page.IsPostBack)
        {
            if ((ItemID > 0) && (ProductImageID > 0))
            {
                lblHeading.Text = "Edit Product Image";               
                this.BindDatas();
                tblShowImage.Visible = true;
                txtimagename.Visible = true;
            }
            else
            {
                tblProductDescription.Visible = true;
                lblHeading.Text = "Add Product Image";
            }

        }
    }
    #endregion

    #region Bind event
    /// <summary>
    /// Bind Datas
    /// </summary>
    private void BindDatas()
    {
        ZNode.Libraries.Admin.ProductViewAdmin imageadmin = new ProductViewAdmin();
        ZNode.Libraries.DataAccess.Entities.ProductImage image = imageadmin.GetByProductImageID(ProductImageID);  
        if (image != null)
        {
        txtimagename.Text = image.ImageFile;
        txttitle.Text = image.Name;            
        VisibleInd.Checked = image.ActiveInd;
        Image1.ImageUrl = ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.SmallImagePath + image.ImageFile;
        }
    }  

     #endregion

    #region General events

    protected void btnSubmit_Click(object sender, EventArgs e)
    {       
       System.IO.FileInfo _FileInfo = null;

       ZNode.Libraries.Admin.ProductViewAdmin imageadmin = new ProductViewAdmin();
       ZNode.Libraries.DataAccess.Entities.ProductImage prod = new ProductImage();

       if (ProductImageID > 0)
       {
           prod = imageadmin.GetByProductImageID(ProductImageID);
       }
       
        prod.Name = txttitle.Text;        
        prod.ActiveInd = VisibleInd.Checked;
        prod.ProductID = ItemID;    
        
        //Validate image
        if ((ProductImageID == 0) || (RadioProductNewImage.Checked == true))
        {
            //Check for Product View Image
            _FileInfo = new System.IO.FileInfo(UploadProductImage.PostedFile.FileName);

            if (_FileInfo != null)
            {             
               prod.ImageFile = _FileInfo.Name;               
            }
        }
        else 
        {
            prod.ImageFile = prod.ImageFile;
        }

        //Upload File if this is a new product or the New Image option was selected for an existing product
        if (RadioProductNewImage.Checked || ProductImageID == 0)
        {
            if (_FileInfo != null)
            {
                UploadProductImage.SaveAs(Server.MapPath(ZNodeConfigManager.EnvironmentConfig.OriginalImagePath + _FileInfo.Name));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemLargeWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.LargeImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemThumbnailWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.ThumbnailImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemMediumWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.MediumImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemSmallWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.SmallImagePath));

            }
        }
       
        bool check = false;

        if (ProductImageID > 0)
        {
            //update the Imageview
            check = imageadmin.Update(prod);
        }
        else
        {            
            check = imageadmin.Insert(prod);                
        }

        if (check)
        {
            Response.Redirect(EditLink + ItemID + "&mode=views");
        }
        else
        {
            //display error message
            lblError.Text = "An error occurred while updating. Please try again.";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(CancelLink + ItemID + "&mode=views");
    }

    /// <summary>
    /// Radio Button Check Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RadioProductCurrentImage_CheckedChanged(object sender, EventArgs e)
    {
        tblProductDescription.Visible = false;
    }

    /// <summary>
    /// Radio Button Check Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RadioProductNewImage_CheckedChanged(object sender, EventArgs e)
    {
        tblProductDescription.Visible = true;
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

        mi.OpenModifyFileFromDisk(Server.MapPath(ZNodeConfigManager.EnvironmentConfig.OriginalImagePath + PhysicalPathToFile.Name));
    }
    #endregion


}
