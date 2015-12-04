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
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Custom;


public partial class Themes_Default_Search_Search : System.Web.UI.UserControl
{
    #region Member Variables
    protected static bool CheckKeyword = true;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindFields();
            CheckKeyword = true;
        }

        if (Request.Params["keyword"] != null)
        {
            if (CheckKeyword)
            {
                CheckKeyword = false;
                txtKeyword.Text = Request.Params["keyword"];
                //Search products for a keyword
                BindSearchData();
            }


        }
    }
    #endregion

    #region Events
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindSearchData();
    }


    /// <summary>
    /// clears search by redirecting back to same page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ZNodeUrl url = new ZNodeUrl();
        string link = "~/Search.aspx";

        Response.Redirect(link);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind products based on search criteria
    /// </summary>
    protected void BindSearchData()
    {
        ZNodeSearch sm = new ZNodeSearch();

        int CategoryId = int.Parse(lstCategories.SelectedValue);
        int SearchOption = int.Parse(lstSearchOption.SelectedValue);

        uxProductList.ProductList = sm.FindProducts(ZNodeConfigManager.SiteConfig.PortalID, txtKeyword.Text.Trim(), " ", CategoryId, SearchOption, txtSKU.Text.Trim(), txtProductNum.Text.Trim());
        uxProductList.BindProducts();
        if (uxProductList.ProductList.ZNodeProductCollection.Count == 0)
        {
            FailureText.Text = "  No results matching your search were found";
        }
    }

    /// <summary>
    /// Bind selection field data
    /// </summary>
    protected void BindFields()
    {
        //add categories 
        ZNode.Libraries.DataAccess.Custom.CategoryHelper categoryHelper = new CategoryHelper();
        DataSet ds = categoryHelper.GetRootCategoryItems(ZNodeConfigManager.SiteConfig.PortalID);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (Convert.ToBoolean(dr["Visibleind"].ToString()))
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["CategoryId"].ToString();

                lstCategories.Items.Add(li);
            }

        }

    }
    #endregion

}
