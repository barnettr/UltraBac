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
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Custom;
using System.Data.SqlClient;
using SCommImaging.Imaging;
using System.Drawing.Imaging;

public partial class Admin_Secure_categories_add : System.Web.UI.Page
{
    #region Protected Variables
    protected int ItemId;
    protected int ProductImageID = 0;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get ItemId from querystring        
        if (Request.Params["itemid"] != null)
        {
            ItemId = int.Parse(Request.Params["itemid"]);
        }
        else
        {
            ItemId = 0;
        }

        if (Page.IsPostBack == false)
        {
            //if edit func then bind the data fields
            if (ItemId > 0)
            {
                lblTitle.Text = "Edit Category";
                tblShowImage.Visible = true;
                BindListData();
                BindEditData();
            }
            else
            {
                lblTitle.Text = "Add Category";
                tblCategoryDescription.Visible = true;
                BindListData();
            }
        }
    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind data to the fields on the edit screen
    /// </summary>
    protected void BindEditData()
    {
        CategoryAdmin categoryAdmin = new CategoryAdmin();
        Category category = categoryAdmin.GetByCategoryId(ItemId);

        if (category != null)
        {            
            txtName.Text = category.Name;
            txtshortdescription.Text = category.ShortDescription; 
            ctrlHtmlText.Html = category.Description;
            ParentCategoryID.SelectedValue = category.ParentCategoryID.ToString();
            DisplayOrder.Text = category.DisplayOrder.ToString();
            VisibleInd.Checked = category.VisibleInd;

            txtTitle.Text = category.Title;  
            chkSubCategoryGridVisibleInd.Checked = category.SubCategoryGridVisibleInd;
            txtSEOMetaDescription.Text = category.SEODescription;
            txtSEOMetaKeywords.Text = category.SEOKeywords;
            txtSEOTitle.Text = category.SEOTitle;
            Image1.ImageUrl = ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.MediumImagePath + category.ImageFile;

        }
        else
        {
            throw (new ApplicationException("Category Requested could not be found."));
        }
    }

    /// <summary>
    /// Bind category list box
    /// </summary>
    protected void BindListData()
    {
        CategoryAdmin categoryAdmin = new CategoryAdmin();
        CategoryHelper categoryHelper = new CategoryHelper();
        DataSet dsCategory=categoryHelper.GetCategoryHierarchy(ZNodeConfigManager.SiteConfig.PortalID);

        ListItem defaultitem = new ListItem("NONE - Add Category to Root Level", "0");
        defaultitem.Selected = true;
        ParentCategoryID.Items.Add(defaultitem);

        foreach (System.Data.DataRow dr in dsCategory.Tables[0].Rows)
        {
            ListItem item = new ListItem();
            item.Text = CategoryAdmin.GetCategoryPath(dr["Name"].ToString(), dr["Parent1CategoryName"].ToString(), dr["Parent2CategoryName"].ToString());
            item.Value = dr["categoryid"].ToString();
            ParentCategoryID.Items.Add(item);
        }
     
    }

    #endregion

    #region General Events
    /// <summary>
    /// Submit button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        System.IO.FileInfo _FileInfo = null;
        CategoryAdmin categoryAdmin = new CategoryAdmin();        

        Category category = new Category();
        if (ItemId > 0)
        {
            category = categoryAdmin.GetByCategoryId(ItemId);
        }
        category.CategoryID = ItemId;
        category.PortalID = ZNodeConfigManager.SiteConfig.PortalID ;
        category.Name = txtName.Text;
        category.ShortDescription = txtshortdescription.Text;
        category.Description = ctrlHtmlText.Html;
        category.Title = txtTitle.Text;
        category.SubCategoryGridVisibleInd = chkSubCategoryGridVisibleInd.Checked;
        category.SEOTitle = txtSEOTitle.Text;
        category.SEOKeywords = txtSEOMetaKeywords.Text;
        category.SEODescription = txtSEOMetaDescription.Text;

        if (int.Parse(ParentCategoryID.SelectedValue) > 0)
        {
            category.ParentCategoryID = int.Parse(ParentCategoryID.SelectedValue);
        }
        else
        {
            category.ParentCategoryID = null;
        }

        category.DisplayOrder = int.Parse(DisplayOrder.Text);
        category.VisibleInd = VisibleInd.Checked;

        #region Image Validation

        //Validate image
        if ((ItemId == 0) || (RadioCategoryNewImage.Checked == true))
        {
            if(UploadCategoryImage.PostedFile.FileName != "")
            {
                //Check for Product Image
                _FileInfo = new System.IO.FileInfo(UploadCategoryImage.PostedFile.FileName);

                if (_FileInfo != null)
                {                  
                  category.ImageFile = _FileInfo.Name;                   
                }
            }
        }
        else
        {
            category.ImageFile = category.ImageFile; 
        }
        #endregion

        //Upload File if this is a new product or the New Image option was selected for an existing product
        if (RadioCategoryNewImage.Checked || ItemId == 0)
        {
            if (_FileInfo != null)
            {
                UploadCategoryImage.SaveAs(Server.MapPath(ZNodeConfigManager.EnvironmentConfig.OriginalImagePath + _FileInfo.Name));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemLargeWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.LargeImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemThumbnailWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.ThumbnailImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemMediumWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.MediumImagePath));
                this.ResizeImage(_FileInfo, ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemSmallWidth, Server.MapPath(ZNodeConfigManager.EnvironmentConfig.SmallImagePath));
            }
        }   
        bool retval = false;

        if (ItemId > 0)
        {
            retval = categoryAdmin.Update(category);

            if (retval)
            {
                Response.Redirect("~/admin/secure/catalog/product_category/list.aspx");
            }
            else
            {
                lblMsg.Text = "Could not update the product category. Please try again.";
                return;
            }
        }
        else
        {
            retval = categoryAdmin.Add(category);

            if (retval)
            {
                Response.Redirect("~/admin/secure/catalog/product_category/add_next.aspx");
            }
            else
            {
                lblMsg.Text = "Could not add the product category. Please try again.";
                return;
            }
        }
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/catalog/product_category/list.aspx");
    }

    /// <summary>
    /// Radio Button Check Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RadioCategoryCurrentImage_CheckedChanged(object sender, EventArgs e)
    {
        tblCategoryDescription.Visible = false;
    }

    /// <summary>
    /// Radio Button Check Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RadioCategoryNewImage_CheckedChanged(object sender, EventArgs e)
    {
        tblCategoryDescription.Visible = true;
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
