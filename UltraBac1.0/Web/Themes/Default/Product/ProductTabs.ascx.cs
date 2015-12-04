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

public partial class Controls_ProductTabs : System.Web.UI.UserControl
{
    #region Private Variables
    protected int _productId;
    ZNodeProduct _product = new ZNodeProduct();
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //retrieve product object from HttpContext (set previously in the page_preinit event of the page)
        _product = (ZNodeProduct)HttpContext.Current.Items["Product"];
        Bind();
    }

    #endregion

    # region Bind Method

    public void Bind()
    {
        ProductSpecification.Text = _product.Specifications;
        ProductAdditionalInformation.Text = _product.AdditionalInformation;
        ProductFeatureDesc.Text = _product.FeaturesDesc;
        
        //related products        
        uxProductRelated.Product = _product;
        uxProductRelated.Bind();

        int counter = 0;

        //this should be retrieved from the store settings in the future
        bool ShowTabsOnlyIfDataPresent = false;

        //Show tabs only if they contain any information
        if (ShowTabsOnlyIfDataPresent)
        {
            if (_product.FeaturesDesc.Length == 0)
            {                
                ProductTabs.Tabs[0].Visible = false;
                ProductTabs.Tabs[0].HeaderText = "";
                counter++;
            }
            if (_product.Specifications.Length == 0)
            {
                ProductTabs.Tabs[1].Visible = false;
                ProductTabs.Tabs[1].HeaderText = "";
                counter++;
            }
            //if (ProductAdditionalImages1.HasImages)
            //{
                //ProductTabs.Tabs[2].Visible = false;
                //ProductTabs.Tabs[2].HeaderText = "";
                //counter++;
            //}
            if (_product.ZNodeCrossSellItemCollection.Count == 0)
            {
                ProductTabs.Tabs[3].Visible = false;
                ProductTabs.Tabs[3].HeaderText = "";
                counter++;
            }
            if (_product.AdditionalInformation.Length == 0)
            {
                ProductTabs.Tabs[4].Visible = false;
                ProductTabs.Tabs[4].HeaderText = "";
                counter++;
            }
        }

        if (counter == ProductTabs.Tabs.Count)
        {
            ProductTabs.Visible = false;
        }
    }

    #endregion

    # region Helper Methods
    # endregion
}
