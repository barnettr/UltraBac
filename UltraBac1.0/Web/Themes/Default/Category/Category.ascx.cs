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
using ZNode.Libraries.DataAccess.Custom;

public partial class Themes_Default_Category_Category : System.Web.UI.UserControl
{
    #region Member Variables
    protected int _categoryId;
    protected ZNodeCategory _category;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //get category id from querystring  
        if (Request.Params["cid"] != null)
        {
            _categoryId = int.Parse(Request.Params["cid"]);
        }
        else
        {         
           throw(new ApplicationException("Invalid Category Request"));
        }

        //Retrieve category data from httpContext (set previously in the page_preinit event)
        _category = (ZNodeCategory ) HttpContext.Current.Items["Category"];

        //Bind data to page
        Bind();

    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind All Controls to Category Data
    /// </summary>
    protected void Bind()
    {        
        //bind title
        CategoryTitle.Text = _category.Title;
        CategoryDescription.Text = _category.Description;

        //product list
        //uxCategoryProductList.Category = _category;
        //uxCategoryProductList.BindCategory();

        ////subcategory list
        //uxSubCategoryList.Category = _category;
        //uxSubCategoryList.Bind();
    }
    #endregion

}
