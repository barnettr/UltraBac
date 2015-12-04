using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Framework.Business;


public partial class Admin_Secure_products_view : System.Web.UI.Page
{

    #region Protected Member Variables  
    protected int ItemId;
    protected int PortalID;
    protected string Mode = "";
    protected static int productTypeID = 0;
    protected int ProductID;    
    protected string EditPageLink = "add.aspx?itemid=";
    protected string EditSEOLink = "edit_seo.aspx?itemid=";
    protected string EditAdvancedPageLink = "edit_advancedsettings.aspx?itemid=";    
    protected string EditAdditionalInfoLink = "edit_additionalinfo.aspx?itemid=";
    protected string InventoryLink = "inventory.aspx?itemid=";
    protected string AddRelatedItemLink = "addrelateditems.aspx?itemid=";
    protected string AddProductAddOnLink = "~/admin/secure/catalog/product/add_addons.aspx?";
    protected string ListLink = "list.aspx";
    protected string PreviewLink = "/product.aspx?pid=";
    protected string AddSKULink = "~/admin/secure/catalog/product/add_sku.aspx?itemid=";
    protected string AddViewlink = "~/admin/secure/catalog/product/add_view.aspx?itemid=";
    protected string DetailsLink = "~/admin/secure/catalog/product_addons/view.aspx?mode=true";


    #endregion

    #region Page Load
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check License
        ZNodeLicenseManager lm = new ZNodeLicenseManager();
        if (!lm.AllowAttributes())
        {
            pnlProductOptions.Enabled = false ;
        }

        // Get mode value from querystring        
        if (Request.Params["mode"] != null)
        {
            Mode = Request.Params["mode"];
        }

        // Get ItemId from querystring        
        if (Request.Params["itemid"] != null)
        {
            ItemId = int.Parse(Request.Params["itemid"]);
        }
        else
        {
            ItemId = 0;
        }

        if (!Page.IsPostBack)
        {
            if (ItemId > 0)
            {
                this.BindViewData();
                ZNodeUrl _Url = new ZNodeUrl();
                PreviewLink = ZNodeConfigManager.EnvironmentConfig.ApplicationPath + "/product.aspx?pid=" + ItemId;
            }
            else 
            {
                throw (new ApplicationException("Product Requested could not be found."));                
            }


            ResetTab();
        }
        //Add Client Side Script
        StringBuilder StringBuild = new StringBuilder();
        StringBuild.Append("<script language=JavaScript>");
        StringBuild.Append("    function  PreviewProduct() {");
        StringBuild.Append("  window.open('" + PreviewLink + "');");
        StringBuild.Append("    }");
        StringBuild.Append("<" + "/script>");


        if (!ClientScript.IsStartupScriptRegistered("Preview"))
        {
            ClientScript.RegisterStartupScript(GetType(),"Preview", StringBuild.ToString());
        }
       

    }
    #endregion

    #region Bind Datas

    /// <summary>
    /// Bind Inventory Grid
    /// </summary>
    private void BindSKU()
    {
        SKUAdmin _SkuAdmin = new SKUAdmin();
        DataSet MyDatas = _SkuAdmin.GetByProductID(ItemId);
        uxGridInventoryDisplay.DataSource = MyDatas;
        uxGridInventoryDisplay.DataBind();
        
    }

    /// <summary>
    /// Binding Product Values into label Boxes
    /// </summary>
    public void BindViewData()
    {
        //Create Instance for Product Admin and Product entity
        ZNode.Libraries.Admin.ProductAdmin ProdAdmin = new ProductAdmin();
        Product _Product=ProdAdmin.GetByProductId(ItemId);

        DataSet ds = ProdAdmin.GetProductDetails(ItemId);
        int Count = 0;

        //Check for Number of Rows
        if (ds.Tables[0].Rows.Count != 0)
        {
            //Bind ProductType,Manufacturer
            lblProdType.Text = ds.Tables[0].Rows[0]["producttype name"].ToString();
            lblManufacturerName.Text = ds.Tables[0].Rows[0]["MANUFACTURER NAME"].ToString();

            //Check For Product Type
            productTypeID = int.Parse(ds.Tables[0].Rows[0]["ProductTypeId"].ToString());
            Count = ProdAdmin.GetAttributeCount(int.Parse(ds.Tables[0].Rows[0]["ProductTypeId"].ToString()), ZNodeConfigManager.SiteConfig.PortalID);
            //Check product atributes count
            if (Count > 0)
            {
                tabProductDetails.Tabs[5].Enabled = true; // Enable Manage inventory tab 
            }
            else
            {
                tabProductDetails.Tabs[5].Enabled = false;// Disable Manage inventory tab
            }
        }

        if (_Product != null)
        {
            //General Information
            lblProdName.Text = _Product.Name;                    
            lblProdNum.Text  =  _Product.ProductNum.ToString();
            if (Count > 0)
            {
                lblProductSKU.Text = "See Manage SKUs tab";
                lblQuantity.Text = "See Manage SKUs tab";
            }
            else
            {
                lblProductSKU.Text = _Product.SKU;

                if(_Product.QuantityOnHand.HasValue)
                lblQuantity.Text = _Product.QuantityOnHand.Value.ToString();
            }

            //image
            if (_Product.ImageFile.Trim().Length > 0)
            {
                string ImageFilePath = ZNodeConfigManager.EnvironmentConfig.MediumImagePath + _Product.ImageFile;
                ItemImage.ImageUrl = ImageFilePath;                
            }               
            else
            {
                ItemImage.ImageUrl = ZNodeConfigManager.SiteConfig.ImageNotAvailablePath;
            }      
             

            //Product Description and Features
						lblProductDescription.Text = _Product.Description;
						lblpurchaseinfo.Text = _Product.PurchaseInformation;
            lbllicenseinfo.Text = _Product.LicensingInformation;
            lblupgradeinfo.Text = _Product.UpgradeInformation;
            lblmaintenanceinfo.Text = _Product.MaintenanceInformation;
            
            //Product Attributes
            lblRetailPrice.Text = FormatPrice(_Product.RetailPrice);
            lblWholeSalePrice.Text = FormatPrice(_Product.WholesalePrice);
            lblSalePrice.Text = FormatPrice(_Product.SalePrice);               
            lblWeight.Text = this.FormatProductWeight(_Product.Weight);
                        

            //Display Settings
            chkProductEnabled.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse(_Product.ActiveInd.ToString()));
            lblProdDisplayOrder.Text = _Product.DisplayOrder.ToString();
            chkIsSpecialProduct.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(this.DisplayVisible(_Product.HomepageSpecial));
            chkProductPricing.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(this.DisplayVisible(_Product.CallForPricing));
            chkproductInventory.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(this.DisplayVisible(_Product.InventoryDisplay));
             
            
            //seo 
            lblSEODescription.Text = _Product.SEODescription;
            lblSEOKeywords.Text = _Product.SEOKeywords;
            lblSEOTitle.Text = _Product.SEOTitle;

            //checking whether the image is active or not
            //ZNode.Libraries.Admin.ProductViewAdmin pp = new ProductViewAdmin();

            //Inventory Setting - Out of Stock Options
            if ((_Product.TrackInventoryInd.Value) && (_Product.AllowBackOrder.Value == false))
            {
                chkCartInventoryEnabled.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse("true"));
                chkIsBackOrderEnabled.Src = SetCheckMarkImage();
                chkIstrackInvEnabled.Src = SetCheckMarkImage();

            }
            else if (_Product.TrackInventoryInd.Value && _Product.AllowBackOrder.Value)
            {
                chkCartInventoryEnabled.Src = SetCheckMarkImage();
                chkIsBackOrderEnabled.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse("true"));
                chkIstrackInvEnabled.Src = SetCheckMarkImage();
            }
            else if ((_Product.TrackInventoryInd.Value == false) && (_Product.AllowBackOrder.Value == false))
            {
                chkCartInventoryEnabled.Src = SetCheckMarkImage();
                chkIsBackOrderEnabled.Src = SetCheckMarkImage();
                chkIstrackInvEnabled.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse("true"));
            }

            //Inventory Setting - Stock Messages
            lblInStockMsg.Text = _Product.InStockMsg;
            lblOutofStock.Text = _Product.OutOfStockMsg;
            lblBackOrderMsg.Text = _Product.BackOrderMsg;

            if (_Product.DropShipInd.HasValue)
            {
                IsDropShipEnabled.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(_Product.DropShipInd.Value);
            }
            else
            {
                IsDropShipEnabled.Src = ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse("false"));
            }
            //Binding product Category 
            DataSet dsCategory = ProdAdmin.Get_CategoryByProductID(ItemId);
            StringBuilder Builder = new StringBuilder();
            foreach (System.Data.DataRow dr in dsCategory.Tables[0].Rows)
            {
                Builder.Append(ProdAdmin.GetCategorypath(dr["Name"].ToString(),dr["Parent1CategoryName"].ToString(), dr["Parent2CategoryName"].ToString()));
                Builder.Append("<br />");
            }
            lblProductCategories.Text = Builder.ToString();
            
            //Bind ShippingRule type
            if(_Product.ShippingRuleTypeID.HasValue)
            lblShippingRuleTypeName.Text = GetShippingRuleTypeName(_Product.ShippingRuleTypeID.Value);

            //Bind Grid - Product Related Items
            this.BindRelatedItems();
            //this.BindImage();
            this.BindImageDatas();
            //Bind Grid - Product Addons
            BindProductAddons();            
            //Bind Grid - Inventory
            BindSKU();
        }
        else
        {
            throw (new ApplicationException("Product Requested could not be found."));
        }
        
    }

    /// <summary>
    /// Bind data to grid
    /// </summary>
    private void BindProductAddons()
    {
        ProductAddOnAdmin ProdAddonAdminAccess = new ProductAddOnAdmin();

        //Bind Associated Addons for this product
        uxGridProductAddOns.DataSource = ProdAddonAdminAccess.GetByProductId(ItemId);
        uxGridProductAddOns.DataBind();
    }    

    /// <summary>
    /// Bind Related Products 
    /// </summary>
    public void BindRelatedItems()
    {
        ProductCrossSellAdmin ProdCrossSellAccess = new ProductCrossSellAdmin();
        DataSet MyDataSet = ProdCrossSellAccess.GetByProductID(ItemId);
        uxGrid.DataSource = MyDataSet;
        uxGrid.DataBind();
    }

    public void BindImage()
    {
        ZNode.Libraries.Admin.StoreSettingsAdmin imageadmin = new StoreSettingsAdmin();
        GridThumb.DataSource = imageadmin.Getall();
        GridThumb.DataBind();
    }

    /// <summary>
    /// Bind Related ImageViews 
    /// </summary>
    private void BindImageDatas()
    {
        ZNode.Libraries.Admin.ProductViewAdmin imageadmin = new ProductViewAdmin();
        DataSet ds = new DataSet();
        ds = imageadmin.GetByProductID(ItemId);
        DataView dv = new DataView(ds.Tables[0]);
        //dv.RowFilter = "activeind = true";       
        GridThumb.DataSource = dv;       
        GridThumb.DataBind();                    
    }  

    #endregion

    #region Grid Events
    
    # region Events for ProductAddon Grid

    /// <summary>
    /// Add Client side event to the Delete Button in the Grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGridProductAddOns_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Retrieve the Button control from the Seventh column.
            Button DeleteButton = (Button)e.Row.Cells[2].FindControl("btnDelete");

            //Set the Button's CommandArgument property with the row's index.
            DeleteButton.CommandArgument = e.Row.RowIndex.ToString();

            //Add Client Side confirmation
            DeleteButton.OnClientClick = "return confirm('Are you sure you want to delete this item?');";           
        }
    }
    /// <summary>
    /// Product Add On Row command event - occurs when delete button is fired.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGridProductAddOns_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
        }
        else
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the values from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = uxGridProductAddOns.Rows[index];

            TableCell Idcell = selectedRow.Cells[0];
            string Id = Idcell.Text;

            if (e.CommandName == "Remove")
            {
                ProductAddOnAdmin AdminAccess = new ProductAddOnAdmin();
                if(AdminAccess.DeleteProductAddOn(int.Parse(Id)))
                BindProductAddons();
            }            
        }
    }

    /// <summary>
    /// Product AddOn grid Items Page Index Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGridProductAddOns_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGridProductAddOns.PageIndex = e.NewPageIndex;
        this.BindProductAddons();
    } 

    # endregion   

    # region Related to CrossSell Grid Events
    /// <summary>
    /// Event triggered when a command button is clicked on the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        { }
        else
        {
            if (e.CommandName == "RemoveItem")
            {
                ProductCrossSellAdmin _prodCrossSellAdmin = new ProductCrossSellAdmin();
                bool Check = _prodCrossSellAdmin.Delete(int.Parse(e.CommandArgument.ToString()),ItemId,ZNodeConfigManager.SiteConfig.PortalID);
                if (Check)
                {
                    this.BindRelatedItems();
                }
            }          
        }
    }

    /// <summary>
    /// Related Items Page Index Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        this.BindRelatedItems();
    }
    #endregion

    # region InventoryDisplay Grid related Methods
    /// <summary>
    /// Event triggered when a command button is clicked on the grid (InventoryDisplay Grid)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGridInventoryDisplay_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument.ToString() == "page")
        { }
        else
        {
            if (e.CommandName == "Edit")
            {
                //Redirect Edit SKUAttrbute Page
                Response.Redirect(AddSKULink + ItemId + "&skuid=" + e.CommandArgument.ToString() + "&typeid=" + productTypeID);
            }
            else if (e.CommandName == "Delete")
            {
                // Delete SKU and SKU Attribute
                SKUAdmin _AdminAccess = new SKUAdmin();
                
                bool check = _AdminAccess.Delete(int.Parse(e.CommandArgument.ToString()));
                if(check)
                {
                    _AdminAccess.DeleteBySKUId(int.Parse(e.CommandArgument.ToString()));
                }
            }
        }
    }

    /// <summary>
    /// Event triggered when the Grid Row is Deleted
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGridInventoryDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.BindSKU();
    }
    /// <summary>
    /// Event triggered when the grid(Inventory) page is changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGridInventoryDisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGridInventoryDisplay.PageIndex = e.NewPageIndex;
        this.BindSKU();
    }

    #endregion

    # region Related to Product Views Grid Events

    /// <summary>
    /// Related Items Page Index Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    protected void GridThumb_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridThumb.PageIndex = e.NewPageIndex;               
        this.BindImageDatas();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridThumb_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.BindImageDatas();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridThumb_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
        }
        else
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(AddViewlink + ItemId + "&productimageid=" + e.CommandArgument.ToString() + "&typeid=" + productTypeID);
            }
            if (e.CommandName == "RemoveItem")
            {
                ZNode.Libraries.Admin.ProductViewAdmin prodadmin = new ProductViewAdmin();
                bool Status = prodadmin.Delete(int.Parse(e.CommandArgument.ToString()));
                if (Status)
                {
                    this.BindImageDatas();
                }
            }
        }
    }
    #endregion

    #endregion

    # region Events

    # region Events for ProductAddon

    /// <summary>
    /// Add AddOn Button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNewAddOn_Click(object sender, EventArgs e)
    {        
        Response.Redirect(AddProductAddOnLink + "&itemid=" + ItemId);
    }  
    
    #endregion


    protected void btnAddSKU_Click(object sender, EventArgs e)
    {
        Response.Redirect(AddSKULink + ItemId + "&typeid=" + productTypeID);
    }
    /// <summary>
    /// Add New Related Item for a Product
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddRelatedItems_Click(object sender, EventArgs e)
    {
        Response.Redirect(AddRelatedItemLink + ItemId);
    }

    /// <summary>
    /// Redirecting to Product Edit Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EditProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect(EditPageLink + ItemId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EditAdvancedSettings_Click(object sender, EventArgs e)
    {
        Response.Redirect(EditAdvancedPageLink + ItemId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EditSEOSettings_Click(object sender, EventArgs e)
    {
        Response.Redirect(EditSEOLink + ItemId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void EditAdditionalInfo_Click(object sender, EventArgs e)
    {
        Response.Redirect(EditAdditionalInfoLink + ItemId);
    }
    
    /// <summary>
    /// Redirecting to Product List Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ProductList_Click(object sender, EventArgs e)
    {
        Response.Redirect(ListLink);
    }

    protected void AddProductView_Click(object sender, EventArgs e)
    {
        Response.Redirect(AddViewlink + ItemId);
    }
   
# endregion

    #region Helper Functions

    /// <summary>
    /// This will automatically pre-select the tab according the query string value(mode)
    /// </summary>
    private void ResetTab()
    {
        if (Mode.Equals("advanced"))
        {
            tabProductDetails.ActiveTabIndex = 1; //Set Advanced Settings as active tab 
        }
        else if (Mode.Equals("crosssell"))
        {
            tabProductDetails.ActiveTabIndex = 2; //For Related Items
        }
        else if (Mode.Equals("views"))
        {
            tabProductDetails.ActiveTabIndex = 3; //For Related Images
        }
        else if (Mode.Equals("addons"))
        {
            tabProductDetails.ActiveTabIndex = 4; //For Product Options
        }  
        else if (Mode.Equals("inventory"))
        {
            tabProductDetails.ActiveTabIndex = 5; //For Manage Inventory
        }
        else if (Mode.Equals("additional"))
        {
            tabProductDetails.ActiveTabIndex = 6; //For Additional Information tab
        }
        else if (Mode.Equals("seo"))
        {
            tabProductDetails.ActiveTabIndex = 7; //For SEO settings
        } 

    }
    /// <summary>
    /// Returns a Format Weight string
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string FormatProductWeight(Object FieldValue)
    {
        if (FieldValue == null)
        {
            return String.Empty;

        }
        else
        {
            if (Convert.ToDecimal(FieldValue.ToString()) == 0)
            {
                return string.Empty;
            }
            else
            {
                return FieldValue.ToString() + " lbs";
            }
        }
    }


    /// <summary>
    /// Format the Price of a Product
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string FormatPrice(Object FieldValue)
    {
        if (FieldValue == null)
        {
            return String.Empty;

        }
        else
        {
            if (Convert.ToDecimal(FieldValue) == 0)
            {
                return String.Empty;
            }
            else
            {
                return String.Format("{0:c}", FieldValue);
            }
            
        }
    }

    /// <summary>
    /// Validate for Null Values and return a Boolean Value
    /// </summary>
    /// <param name="Fieldvalue"></param>
    /// <returns></returns>
    public bool DisplayVisible(Object Fieldvalue)
    {
        if (Fieldvalue == DBNull.Value) 
        {
            return false;
        }
        else
        {
            if (Convert.ToInt32(Fieldvalue) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    /// Gets the name of the Addon for this AddonId
    /// </summary>
    /// <param name="addOnId"></param>
    /// <returns></returns>
    public string GetAddOnName(object addOnId)
    {
        ProductAddOnAdmin AdminAccess = new ProductAddOnAdmin();
        AddOn _addOn = AdminAccess.GetByAddOnId(int.Parse(addOnId.ToString()));

        if (_addOn != null)
        {
            return _addOn.Name;
        }

        return "";
    }

    /// <summary>
    /// Gets the title of the Addon for this AddonId
    /// </summary>
    /// <param name="addOnId"></param>
    /// <returns></returns>
    public string GetAddOnTitle(object addOnId)
    {
        ProductAddOnAdmin AdminAccess = new ProductAddOnAdmin();
        AddOn _addOn = AdminAccess.GetByAddOnId(int.Parse(addOnId.ToString()));

        if (_addOn != null)
        {
            return _addOn.Title;
        }

        return "";
    }

    /// <summary>
    /// Gets the name of the Addon for this AddonId
    /// </summary>
    /// <param name="addOnId"></param>
    /// <returns></returns>
    public string GetShippingRuleTypeName(int shippingRuleTypeID)
    {
        ShippingRuleTypeAdmin _ShippingRuleTypeAdmin = new ShippingRuleTypeAdmin();
       
        ShippingRuleType _shippingRuleType = _ShippingRuleTypeAdmin.GetByShippingRuleTypeID(shippingRuleTypeID);

        if (_shippingRuleType != null)
        {
            return _shippingRuleType.Name;
        }

        return "";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="imagepath"></param>
    public void changeimage(string imagepath)
    {
        ItemImage.ImageUrl = ZNodeConfigManager.EnvironmentConfig.SmallImagePath + imagepath;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string SetCheckMarkImage()
    {
        return ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse("false"));
    }

    # endregion    
    
}
