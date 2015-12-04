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

public partial class Themes_Default_Product_ProductZoom : System.Web.UI.UserControl
{
    #region Member Variables
    private ZNodeProduct _product;
    private int _productId;
    private int productimageid;
    private int totalrecord;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //get product id from querystring  
        if (Request.Params["pid"] != null)
        {
            _productId = int.Parse(Request.Params["pid"]);
        }
        else
        {
            throw (new ApplicationException("Invalid Product Id"));
        }

        if (Request.Params["pimgid"] != null)
        {
            if (Request.QueryString["pimgid"].Length == 0)
            {
                productimageid = 0;
            }
            else
            {
                productimageid = int.Parse(Request.Params["pimgid"]);
            }
        }

        //construct product object
        if (!Page.IsPostBack)
        {
            //retrieve product data
            _product = ZNodeProduct.Create(_productId, ZNodeConfigManager.SiteConfig.PortalID);

            BindGrid();
        }
    }
    #endregion

    #region Methods
    private void BindGrid()
    {
        ZNode.Libraries.Admin.ProductViewAdmin imageadmin = new ZNode.Libraries.Admin.ProductViewAdmin();
        DataSet ds = imageadmin.GetByProductID(_productId);
        ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["ProductImageID"] };
        ds.Tables[0].Columns["ProductImageID"].AutoIncrement = true;
        totalrecord = ds.Tables[0].Rows.Count;
        if (totalrecord > 0)
        {
            pnlPrevNext.Visible = true;
        }
        else
        {
            pnlPrevNext.Visible = false;
        }

        DataRow dr = null;
        ////retrieve product data
        _product = ZNodeProduct.Create(_productId, ZNodeConfigManager.SiteConfig.PortalID);
        dr = ds.Tables[0].NewRow();
        dr["ProductID"] = _productId;
        dr["Name"] = _product.Name;
        dr["ImageFile"] = _product.ImageFile;
        dr["ActiveInd"] = 1;
        ds.Tables[0].Rows.InsertAt(dr, 0);

        DataView dv = new DataView(ds.Tables[0]);
        dv.RowFilter = "activeind = true";

        if (!IsPostBack)
        {
            int imageindex = 0;
            if (productimageid != 0)
            {
                imageindex = ds.Tables[0].Rows.IndexOf(ds.Tables[0].Rows.Find(productimageid));
                GridImage.PageIndex = imageindex;
            }
        }

        GridImage.DataSource = dv;
        GridImage.DataBind();
        ProductTitle.Text = (GridImage.Rows[0].FindControl("CatalogItemImage") as Image).AlternateText;
    }

    /// <summary>
    /// Bind all the controls to the data
    /// </summary>
    /* private void Bind()
     {
         //image
         if (_product.ImageFile.Trim().Length > 0)
         {
             string ImageFilePath = ZNodeConfigManager.EnvironmentConfig.CatalogImagePath + _product.ImageFile;
             CatalogItemImage.ImageUrl = ZNodeConfigManager.SiteConfig.MaxCatalogItemThumbnailWidth.ToString() + ImageFilePath;
         }
         else
         {
             CatalogItemImage.ImageUrl = ZNodeConfigManager.SiteConfig.ImageNotAvailablePath;
         }

         ProductTitle.Text = _product.Name;

     }*/

    public string ReturnPath(string Image)
    {
        string ImageFilePath = ZNodeConfigManager.EnvironmentConfig.LargeImagePath + Image;
        return ImageFilePath;
    }
    #endregion

    #region Events
    protected void GridImage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridImage.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void Forward_Click(object sender, EventArgs e)
    {
        if (GridImage.PageCount - 1 == GridImage.PageIndex)
        {
            GridImage.PageIndex = 0;
        }
        else
        {
            GridImage.PageIndex = GridImage.PageIndex + 1;
        }

        BindGrid();
    }

    protected void Previous_Click(object sender, EventArgs e)
    {
        if (GridImage.PageIndex != 0)
        {
            GridImage.PageIndex = GridImage.PageIndex - 1;
        }
        else
        {
            GridImage.PageIndex = GridImage.PageCount - 1;
        }

        BindGrid();
    }

    #endregion

}
