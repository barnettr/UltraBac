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
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Custom;

/// <summary>
/// Displays the sub-categories on the category page
/// </summary>
public partial class Controls_ShoppingCartCategory_SubCategoryList : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeCategory _category;
    #endregion   

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //Retrieve category data from httpContext (set previously in the page_preinit event)
        _category = (ZNodeCategory)HttpContext.Current.Items["Category"];

        //Bind data to page
        Bind();
    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind control display based on properties set
    /// </summary>
    public void Bind()
    {
        if (_category.SubCategoryGridVisibleInd)
        {
            if (_category.ZNodeCategoryCollection.Count == 0)
            {
                pnlSubCategoryList.Visible = false;
            }
            else
            {
                pnlSubCategoryList.Visible = true;
            }

            //Bind to datalist
            DataListSubCategories.DataSource = _category.ZNodeCategoryCollection;
            DataListSubCategories.RepeatColumns = ZNodeConfigManager.SiteConfig.MaxCatalogDisplayColumns;
            DataListSubCategories.DataBind();                   
        }
        else
        {            
            pnlSubCategoryList.Visible = false; 
        }        
    }

    #endregion

    # region helper method
    /// <summary>
    ///To get the Parent Categories  when the CategoryId is not passed.
    /// </summary>
    public void ParentCategory(int portalid)
    {
        //Retrieve the data
        CategoryHelper categoryHelper = new CategoryHelper();
        DataSet ds = categoryHelper.GetRootCategoryItems(ZNodeConfigManager.SiteConfig.PortalID);

        //Bind to datalist
        DataListParentCategory.DataSource = ds;
        DataListParentCategory.DataBind();       
    }   
    
    #endregion
}
