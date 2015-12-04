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
using ZNode.Libraries.ECommerce.Business;

public partial class Themes_Default_Product_ProductAdditionalImages : System.Web.UI.UserControl
{
    #region Public Variables

    /// <summary>
    /// Returns if there are related images in this control.
    /// </summary>
    public bool HasImages
    {
        get { return _hasImages; }
    }

    /// <summary>
    /// Maximum number of columns used to display the images. Defaults to Max Catalog Display Columns in General Settings.
    /// </summary>
    public int MaxDisplayColumns
    {
        get { return _maxDisplayColumns; }
        set { _maxDisplayColumns = value; }
    }

    /// <summary>
    /// Include the main product picture with the images displayed.
    /// </summary>
    public bool IncludeProductImage
    {
        get { return _includeProductImage; }
        set { _includeProductImage = value; }
    }

    /// <summary>
    /// The directory the images should be pulled from (thumbnail, small, medium or large). You do not need to specify the whole path.
    /// </summary>
    public string imageSizePath
    {
        get { return _imageSizePath; }
        set { _imageSizePath = value; }
    }

    #endregion 

    #region Private Variables
    protected int _productId;
    ZNodeProduct _product = new ZNodeProduct();
    bool _hasImages = false;
    int _maxDisplayColumns = ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogDisplayItems;
    bool _includeProductImage = true;
    string _imageSizePath = "thumbnail";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //retrieve product object from HttpContext (set previously in the page_preinit event of the page)
        _product = (ZNodeProduct)HttpContext.Current.Items["Product"];

        Bind();


        //Include the Client Side Script from the resource file
        //The Resource File is named “Calender.js”
        //Located inside the Calendar directory
        HtmlGenericControl Include = new HtmlGenericControl("script");
        Include.Attributes.Add("type", "text/javascript");
        Include.Attributes.Add("src", "themes/" + ZNodeConfigManager.SiteConfig.Theme + "/common/thumbnailviewer.js");

        //add a script reference for Javascript to the head section
        this.Page.Header.Controls.Add(Include);
    }
    #endregion

    #region Bind Method

    /// <summary>
    /// Bind image view for the product
    /// </summary>
    private void Bind()
    { 
        // Set up our grid.
        DataListAdditionalImages.RepeatColumns = _maxDisplayColumns;

        //retrieve product data
        ZNode.Libraries.Admin.ProductViewAdmin imageadmin = new ZNode.Libraries.Admin.ProductViewAdmin();
        DataSet ds = imageadmin.GetImageByProductID(_product.ProductID).ToDataSet(true);
        ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["ProductImageID"] };
        ds.Tables[0].Columns["ProductImageID"].AutoIncrement = true;

        //Set properties to row
        DataRow dr = null;
        dr = ds.Tables[0].NewRow();
        dr["ProductID"] = _productId;
        dr["Name"] = _product.Name;
        dr["ImageFile"] = _product.ImageFile;
        dr["ActiveInd"] = _includeProductImage; 
        ds.Tables[0].Rows.InsertAt(dr, 0);

        //Create a filtered dataview 
        DataView dv = new DataView(ds.Tables[0]);
        dv.RowFilter = "activeind = true";

        //Bind to the datalist
        DataListAdditionalImages.DataSource = dv;
        DataListAdditionalImages.DataBind();

        _hasImages = dv.Count > 0;       
    }

    #endregion

    # region Helper Methods

    /// <summary>
    /// Get catalog product image Name
    /// </summary>
    /// <param name="Title"></param>
    /// <returns></returns>
    protected string GetImageName(string Title)
    {
        if (Title.Trim().Length > 0)
        {
            return Title;
        }
        else
        {
            return "&nbsp";
        }
    }

    /// <summary>
    /// Get the path to the product image
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    protected string GetImagePath(string path)
    {
        string parmImgPath = "";
        //get input params     
        string temp = Server.UrlDecode(path);
        parmImgPath = Server.MapPath(temp);

        //Create instance for Fileinfo object
        System.IO.FileInfo imgFile = new System.IO.FileInfo(parmImgPath);
        if (imgFile.Exists)
        {
            string str1 = temp;
            string str2 = str1.Replace("~/", "");
            return str2;
        }
        else
        {
            //If file not exist return default image
            ZNodeUrl url = new ZNodeUrl();
            return (url.GetPhysicalDomainPath() + "/Images/pics/noimage.gif");
        }
    }

    #endregion
}
