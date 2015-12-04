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
using System.Text;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to create Bread crumb,populate Store menu and tree view with Store categories
    /// </summary>
    public class ZNodeNavigation : ZNodeBusinessBase
    {
        #region Public Methods

        /// <summary>
        /// Creates a bread crumb path using the category and product ids passed in
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="ProductId"></param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public string GetBreadCrumbPath(int CategoryId, int ProductId, string Separator)
        {
            StringBuilder sbBreadCrumbPath = new StringBuilder();

            if (CategoryId > 0)
            {
                CategoryHelper categoryHelper = new CategoryHelper();
                string delimitedString = categoryHelper.GetCategoryPathByCategoryId(CategoryId);
                sbBreadCrumbPath.Append(ParsePath(delimitedString, Separator));
            }
            else if (ProductId > 0)
            {
                CategoryHelper categoryHelper = new CategoryHelper();
                string delimitedString = categoryHelper.GetCategoryPathByProductId(ProductId);
                sbBreadCrumbPath.Append(ParsePath(delimitedString, Separator));
            }

            return sbBreadCrumbPath.ToString();
        }


        /// <summary>
        /// Populate the store menu in the control reference passed in
        /// </summary>
        /// <param name="ctrlMenu"></param>
        public void PopulateStoreMenu(Menu ctrlMenu)
        {
            CategoryHelper categoryHelper = new CategoryHelper();
            System.Data.DataSet ds = categoryHelper.GetNavigationItems(ZNodeConfigManager.SiteConfig.PortalID);

            //add the hierarchical relationship to the dataset
            ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["CategoryId"], ds.Tables[0].Columns["ParentCategoryId"]);

            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                if (dbRow.IsNull("ParentCategoryID"))
                {
                    if ((bool)dbRow["VisibleInd"])
                    {
                        //create new menu item
                        MenuItem mi = new MenuItem();
                        mi.Text = dbRow["Name"].ToString();

                        string categoryId = dbRow["CategoryId"].ToString();

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("~/storecategory");
                        sb.Append(categoryId);
                        sb.Append(".aspx");

                        mi.NavigateUrl = sb.ToString();

                        //add to tree control
                        ctrlMenu.Items.Add(mi);

                        //recursively populate node
                        RecursivelyPopulateMenu(dbRow, mi);

                    }
                }
            }

            //add specials link
            MenuItem si = new MenuItem();
            si.Text = "Specials";
            si.NavigateUrl = "~/specials.aspx";
            ctrlMenu.Items.Add(si);

        }

        /// <summary>
        /// Populates a treeview with store categories
        /// </summary>
        /// <param name="ctrlTreeView"></param>
        public void PopulateStoreTreeView(TreeView ctrlTreeView, string selectedCategoryId)
        {
            CategoryHelper categoryHelper = new CategoryHelper();
            System.Data.DataSet ds = categoryHelper.GetNavigationItems(ZNodeConfigManager.SiteConfig.PortalID);

            //add the hierarchical relationship to the dataset
            ds.Relations.Add("NodeRelation", ds.Tables[0].Columns["CategoryId"], ds.Tables[0].Columns["ParentCategoryId"]);

            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                if (dbRow.IsNull("ParentCategoryID"))
                {
                    if ((bool)dbRow["VisibleInd"])
                    {
                        //create new tree node
                        TreeNode tn = new TreeNode();
                        tn.Text = dbRow["Name"].ToString();

                        string categoryId = dbRow["CategoryId"].ToString();

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("~/storecategory");
                        sb.Append(categoryId);
                        sb.Append(".aspx");

                        tn.NavigateUrl = sb.ToString();

                        tn.SelectAction = TreeNodeSelectAction.Expand;

                        tn.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/Right_arrow.gif";

                        ctrlTreeView.Nodes.Add(tn);
                        
                        if (selectedCategoryId.Equals(categoryId))
                        {
                            tn.Selected = true;
                            RecursivelyExpandTreeView(tn);
                        }

                        RecursivelyPopulateTreeView(dbRow, tn, selectedCategoryId);
                    }
                }
            }

            //add specials link
            TreeNode tn1 = new TreeNode();
            tn1.Text = "Specials";
            tn1.NavigateUrl = "~/specials.aspx";
            tn1.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/Right_arrow.gif";
            ctrlTreeView.Nodes.Add(tn1);
        }


        /// <summary>
        /// Populates a treeview with store specials
        /// </summary>
        /// <param name="ctrlTreeView"></param>
        public void PopulateSpecialsTreeView(TreeView ctrlTreeView)
        {
            ProductService prodServ = new ProductService();
            TList<Product> prodList = prodServ.GetByHomepageSpecialPortalID(true, ZNodeConfigManager.SiteConfig.PortalID);

            foreach (Product prodItem in prodList)
            {
                //create new tree node
                TreeNode tn = new TreeNode();
                tn.Text = prodItem.Name;

                string prodId = prodItem.ProductID.ToString();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("~/storeproduct");
                sb.Append(prodId);
                sb.Append(".aspx");

                tn.NavigateUrl = sb.ToString();

                tn.SelectAction = TreeNodeSelectAction.Expand;

                ctrlTreeView.Nodes.Add(tn);
            }              
        }

        /// <summary>
        /// Populates a treeview with store brands
        /// </summary>
        /// <param name="ctrlTreeView"></param>
        public void PopulateBrandTreeView(TreeView ctrlTreeView)
        {
            ManufacturerService manServ = new ManufacturerService();
            TList<Manufacturer> manList = manServ.GetByPortalID(ZNodeConfigManager.SiteConfig.PortalID);

            foreach (Manufacturer manItem in manList)
            {
                //create new tree node
                TreeNode tn = new TreeNode();
                tn.Text = manItem.Name;

                string manId = manItem.ManufacturerID.ToString();
                if (manItem.ActiveInd)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("~/brand.aspx");
                    sb.Append("?mid=");
                    sb.Append(manId);

                    tn.NavigateUrl = sb.ToString();

                    tn.SelectAction = TreeNodeSelectAction.Expand;

                    ctrlTreeView.Nodes.Add(tn);
                }
            }
        }

        /// <summary>
        /// Populates a treeview with pricing tiers
        /// </summary>
        /// <param name="ctrlTreeView"></param>
        public void PopulatePricedTreeView(TreeView ctrlTreeView)
        {
            PortalService portalServ = new PortalService();
            Portal portal = portalServ.GetByPortalID(ZNodeConfigManager.SiteConfig.PortalID);

            //retrieve the maximum priced product
            int minLimit = (int)portal.ShopByPriceMin ;

            //retrieve the maximum priced product
            int maxLimit = (int)portal.ShopByPriceMax;

            //get increment
            int increment = (int)portal.ShopByPriceIncrement;

            //set running tier
            int tier = minLimit;

            while (tier < maxLimit)
            {
                int minAmt = tier ;
                int maxAmt = tier + increment ;

                System.Text.StringBuilder sbTier = new System.Text.StringBuilder();
                sbTier.Append("$");
                sbTier.Append(minAmt.ToString());
                sbTier.Append(" - $");
                sbTier.Append(maxAmt.ToString());
                
                //create new tree node
                TreeNode tn = new TreeNode();
                tn.Text = sbTier.ToString();
                
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("~/price.aspx");
                sb.Append("?min=");
                sb.Append(minAmt.ToString());
                sb.Append("&max=");
                sb.Append(maxAmt.ToString());

                tn.NavigateUrl = sb.ToString();
                tn.SelectAction = TreeNodeSelectAction.Expand;
                ctrlTreeView.Nodes.Add(tn);

                tier = tier + increment;
            }
        }

        #endregion

        #region Helper Functions

        /// <summary>
        /// Returns a bread crumb path from a delimited string
        /// </summary>
        /// <param name="DelimitedString"></param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        private string ParsePath(string DelimitedString, string Separator)
        {
            StringBuilder sbPath = new StringBuilder();

            string[] delim1 = { "||" };
            string[] pathitems = DelimitedString.Split(delim1, StringSplitOptions.None);

            foreach (string pathitem in pathitems)
            {
                string[] delim2 = { "%%" };
                string[] items = pathitem.Split(delim2, StringSplitOptions.None);

                string categoryId = items.GetValue(0).ToString();
                string categoryName = items.GetValue(1).ToString();

                sbPath.Append(Separator);
                sbPath.Append(CreateCategoryLink(categoryName, categoryId));
            }

            return sbPath.ToString();
        }

        /// <summary>
        /// Creates a category page link
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        private string CreateCategoryLink(string CategoryName, string CategoryId)
        {
            StringBuilder link = new StringBuilder();
            link.Append("category.aspx?cid=");
            link.Append(CategoryId);

            return CreateLink(link.ToString(), CategoryName);
        }

        /// <summary>
        /// Creates a generic <![CDATA[ <a>]]> link
        /// </summary>
        /// <param name="LinkURL"></param>
        /// <param name="LinkText"></param>
        /// <returns></returns>
        public string CreateLink(string LinkURL, string LinkText)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<a href='");
            sb.Append(LinkURL);
            sb.Append("'>");
            sb.Append(LinkText);
            sb.Append("</a>");

            return sb.ToString();
        }

        //Recursively populate a particular node with it's children
        private void RecursivelyPopulateMenu(DataRow dbRow, MenuItem parentMenuItem)
        {
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
            {
                if ((bool)childRow["VisibleInd"])
                {
                    MenuItem mi = new MenuItem();
                    mi.Text = childRow["Name"].ToString();

                    string categoryId = childRow["CategoryId"].ToString();

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("~/storecategory");
                    sb.Append(categoryId);
                    sb.Append(".aspx");

                    mi.NavigateUrl = sb.ToString();

                    parentMenuItem.ChildItems.Add(mi);

                    RecursivelyPopulateMenu(childRow, mi);
                }
            }
        }

        //Recursively populate a particular node with it's children
        private void RecursivelyPopulateTreeView(DataRow dbRow, TreeNode parentNode, string selectedCategoryId)
        {
            ZNodeUrl url = new ZNodeUrl();

            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
            {
                if ((bool)childRow["VisibleInd"])
                {
                    //create new tree node
                    TreeNode tn = new TreeNode();
                    tn.Text = childRow["Name"].ToString();

                    string categoryId = childRow["CategoryId"].ToString();

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("~/storecategory");
                    sb.Append(categoryId);
                    sb.Append(".aspx");

                    tn.NavigateUrl = sb.ToString();

                    parentNode.ChildNodes.Add(tn);

                    if (selectedCategoryId.Equals(categoryId))
                    {
                        tn.Selected = true;
                        tn.Expand();
                        RecursivelyExpandTreeView(tn);
                    }

                    RecursivelyPopulateTreeView(childRow, tn, selectedCategoryId);
                }
            }
        }

        /// <summary>
        /// Recursively expands parent nodes of a selected tree node
        /// </summary>
        /// <param name="nodeItem"></param>
        private void RecursivelyExpandTreeView(TreeNode nodeItem)
        {
            if (nodeItem.Parent != null)
            {
                nodeItem.Parent.Expand();
                RecursivelyExpandTreeView(nodeItem.Parent);
            }
            else
            {
                nodeItem.Expand();
                return;
            }
        }

        #endregion
    }
}
