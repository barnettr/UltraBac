using System;
using System.Text;
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
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.ECommerce.Business;
using SCommImaging.Imaging;
using System.Drawing.Imaging;
//using Dart.PowerWEB.TextBox;


public partial class Admin_Secure_products_add : System.Web.UI.Page
{
    #region protected Member Variables
    protected string CancelLink = "view.aspx?itemid=";
    protected string ListLink = "list.aspx";
    protected string ProductImageName = "";
    protected int ItemID;    
    protected int SKUId = 0;
    protected int _ProductID = 0;
    protected StringBuilder SelectedNodes=null;
    protected StringBuilder DeleteNodes = null;    
    #endregion

    # region Page load

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        SelectedNodes = new StringBuilder();
        DeleteNodes = new StringBuilder();
        
        //Get product id value from query string
        if (Request.Params["itemid"] != null)
        {
           
            ItemID = int.Parse(Request.Params["itemid"].ToString());
        }
        else
        {
            ItemID = 0;
        }
        
        if (!Page.IsPostBack)
        {            

            //if edit func then bind the data fields
            if (ItemID > 0)
            {
                lblTitle.Text = "Edit Product - ";
                //txtimagename.Enabled = false;
                this.BindData();
                this.BindEditData();
                tblShowImage.Visible = true;
                txtimagename.Visible = true;
                
            }
            else
            {
                lblTitle.Text = "Add New Product";
                this.BindData();
                tblProductDescription.Visible = true;
                
            }
        }        

        //Bind SKU Attributes Dynamically
        if (ProductTypeList.SelectedIndex != -1)
        {
            this.Bind(int.Parse(ProductTypeList.SelectedValue));
            if (ItemID > 0)
            {
                //Bind Edit SKU Attributes
                this.BindAttributes(int.Parse(ProductTypeList.SelectedValue));
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(),"Error", "<script>answer = confirm('Please add a product type before you add a new product'); if(answer != '0'){ location='list.aspx' } </script>");
            
        }
    }
    # endregion
    
    # region Bind Data

    public void BindData()
    { 
        //Bind product Type
        ProductTypeAdmin _productTypeAdmin = new ProductTypeAdmin();
                     
        ProductTypeList.DataSource = _productTypeAdmin.GetAllProductTypes(ZNodeConfigManager.SiteConfig.PortalID);
        ProductTypeList.DataTextField = "name";
        ProductTypeList.DataValueField = "productTypeid";
        ProductTypeList.DataBind();
             
        //Bind Manufacturer
        ManufacturerAdmin _ManufacturerAdmin = new ManufacturerAdmin();
        ManufacturerList.DataSource=_ManufacturerAdmin.GetAllByPortalID(ZNodeConfigManager.SiteConfig.PortalID);
        ManufacturerList.DataTextField = "name";
        ManufacturerList.DataValueField = "manufacturerid";
        ManufacturerList.DataBind();
        ListItem li = new ListItem("No Manufacturer Selected", "0");
        ManufacturerList.Items.Insert(0,li);

        //Bind Categories
        this.BindTreeViewCategory();
    }

    /// <summary>
    /// Bind TreeView with Categories
    /// </summary>
    public void BindTreeViewCategory()
    {
      this.PopulateAdminTreeView(string.Empty);
    }

   
    /// <summary>
    /// Bind control display based on properties set-Dynamically adds DropDownList for Each AttributeType
    /// </summary>
    public void Bind(int productTypeID)
    {
       
        //Bind Attributes
        ProductAdmin _adminAccess = new ProductAdmin();

        DataSet MyDataSet = _adminAccess.GetAttributeTypeByProductTypeID(productTypeID);

        //Repeat until Number of Attributetypes for this Product
        foreach (DataRow dr in MyDataSet.Tables[0].Rows)
        {
            //Get all the Attribute for this Attribute
            DataSet _AttributeDataSet = new DataSet();
            _AttributeDataSet = _adminAccess.GetByAttributeTypeID(int.Parse(dr["attributetypeid"].ToString()));
            DataView dv = new DataView(_AttributeDataSet.Tables[0]);
            //Create Instance for the DropDownlist
            System.Web.UI.WebControls.DropDownList lstControl = new DropDownList();
            lstControl.ID = "lstAttribute" + dr["AttributeTypeId"].ToString();

            ListItem li = new ListItem(dr["Name"].ToString(), "0");
            li.Selected = true;
            dv.Sort = "DisplayOrder ASC";
            lstControl.DataSource = dv;//_AttributeDataSet;
            lstControl.DataTextField = "Name";
            lstControl.DataValueField = "AttributeId";
            lstControl.DataBind();
            lstControl.Items.Insert(0, li);

            if (!Convert.ToBoolean(dr["IsPrivate"]))
            {
                //Add the Control to Place Holder
                ControlPlaceHolder.Controls.Add(lstControl);

                RequiredFieldValidator FieldValidator = new RequiredFieldValidator();
                FieldValidator.ID = "Validator" + dr["AttributeTypeId"].ToString();
                FieldValidator.ControlToValidate = "lstAttribute" + dr["AttributeTypeId"].ToString();
                FieldValidator.ErrorMessage = "Select " + dr["Name"].ToString();
                FieldValidator.Display = ValidatorDisplay.Dynamic;
                FieldValidator.CssClass = "Error";
                FieldValidator.InitialValue = "0";

                ControlPlaceHolder.Controls.Add(FieldValidator);
                Literal lit1 = new Literal();
                lit1.Text = "&nbsp;&nbsp;";
                ControlPlaceHolder.Controls.Add(lit1);
            }


        }

        if (MyDataSet.Tables[0].Rows.Count == 0)
        {
            DivAttributes.Visible = false;
            pnlquantity.Visible = true;
        }
        else
        {
            DivAttributes.Visible = true;
            pnlquantity.Visible = false;
        }
    }
    # endregion       

    # region Bind Edit Data
    /// <summary>
    /// Bind value for Particular Product
    /// </summary>
    public void BindEditData()
    {
        ProductAdmin _ProductAdmin = new ProductAdmin();
        Product _Products = new Product();
        SKUAdmin _SkuAdmin = new SKUAdmin();

        if (ItemID > 0)
        {
            _Products = _ProductAdmin.GetByProductId(ItemID);

            //General Information - Section1
			lblTitle.Text += _Products.Name;
            txtProductName.Text = _Products.Name;           
            txtProductNum.Text = _Products.ProductNum;
            if (ProductTypeList.SelectedIndex != -1)
            {
                ProductTypeList.SelectedValue = _Products.ProductTypeID.ToString();
            }
            if (ManufacturerList.SelectedIndex != -1)
            {
                ManufacturerList.SelectedValue = _Products.ManufacturerID.ToString();
            }
                    

            //Product Description and Image - Section2
            txtshortdescription.Text = _Products.ShortDescription;
            ctrlHtmlText.Html = _Products.Description;
            Image1.ImageUrl = ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.MediumImagePath + _Products.ImageFile; 
            //Displaying the Image file name in a textbox           
            txtimagename.Text = _Products.ImageFile;

            //Product properties
            txtproductRetailPrice.Text = this.FormatPrice(_Products.RetailPrice);
            txtproductSalePrice.Text = this.FormatPrice(_Products.SalePrice);
            txtProductWholeSalePrice.Text = this.FormatPrice(_Products.WholesalePrice);

            //category List
            this.BindEditCategoryList();


            //Inventory
            DataSet MySKUDataSet = _SkuAdmin.GetByProductID(ItemID);
            if (MySKUDataSet.Tables[0].Rows.Count != 0)
            {
                ViewState["productSkuId"] = MySKUDataSet.Tables[0].Rows[0]["skuid"].ToString();
                txtProductSKU.Text = MySKUDataSet.Tables[0].Rows[0]["sku"].ToString();
                txtProductQuantity.Text = MySKUDataSet.Tables[0].Rows[0]["quantityonhand"].ToString();

                this.BindAttributes(_Products.ProductTypeID);
            }
            else
            {
                if (_Products.QuantityOnHand.HasValue)
                {
                    txtProductQuantity.Text = _Products.QuantityOnHand.Value.ToString();
                }
                
                txtProductSKU.Text = _Products.SKU;
            }
            
            //Release the Resources
            MySKUDataSet.Dispose();
        }

    }

    /// <summary>
    /// Binds the Sku Attributes for this Product
    /// </summary>
    /// <param name="productTypeID"></param>
    private void BindAttributes(int productTypeID)
    {
        SKUAdmin _adminSKU = new SKUAdmin();
        ProductAdmin _adminAccess = new ProductAdmin();

        if (ViewState["productSkuId"] != null)
        {
            //Get SKUID from the ViewState
            DataSet SkuDataSet = _adminSKU.GetBySKUId(int.Parse(ViewState["productSkuId"].ToString()));
            DataSet MyDataSet = _adminAccess.GetAttributeTypeByProductTypeID(productTypeID);


            foreach (DataRow dr in MyDataSet.Tables[0].Rows)
            {
                foreach (DataRow Dr in SkuDataSet.Tables[0].Rows)
                {
                    System.Web.UI.WebControls.DropDownList lstControl = (System.Web.UI.WebControls.DropDownList)ControlPlaceHolder.FindControl("lstAttribute" + dr["AttributeTypeId"].ToString());

                    if (lstControl != null)
                    {
                        lstControl.SelectedValue = Dr["Attributeid"].ToString();

                    }
                }
            }
        }

    }


    /// <summary>
    /// Check the Category to the particular Product
    /// </summary>
    public void BindEditCategoryList()
    {        
          ProductCategoryAdmin _productCategoryAdmin = new ProductCategoryAdmin();

          if (_productCategoryAdmin != null)
          {
              DataSet MyDataset = _productCategoryAdmin.GetByProductID(ItemID);
              foreach (DataRow dr in MyDataset.Tables[0].Rows)
              {
                  this.PopulateEditTreeView(dr["categoryid"].ToString());
              }
          }
       
    }

    # endregion

    # region General Events

    /// <summary>
    /// Submit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {   
        #region Declarations
        SKUAdmin _SKUAdminAccess = new SKUAdmin();
        ProductAdmin _ProductAdmin = new ProductAdmin();
        SKUAttribute _skuAttribList = new SKUAttribute();
        SKU _SkuList = new SKU();
        ProductCategory _productCategory = new ProductCategory();
        ProductCategoryAdmin  _productCategoryAdmin=new ProductCategoryAdmin();
        Product _Product = new Product(); 
        System.IO.FileInfo _FileInfo=null;
        bool retVal = false;        
             

        //check if category was selected
        if (CategoryTreeView.CheckedNodes.Count > 0)
        {
            lblCategoryError.Visible = false;
        }
        else
        {
            lblCategoryError.Visible = true;
            return;
        }

        #endregion

        #region Set Product Properties

        //passing Values 
        _Product.ProductID = ItemID;
        _Product.PortalID = ZNodeConfigManager.SiteConfig.PortalID;

        //if edit mode then get all the values first
        if (ItemID > 0)
        {
            _Product = _ProductAdmin.GetByProductId(ItemID);
            
            if (ViewState["productSkuId"] != null)
            {
                _SkuList.SKUID = int.Parse(ViewState["productSkuId"].ToString());
            }
        }

        //General Info
        _Product.Name = txtProductName.Text;
        _Product.ImageFile = txtimagename.Text;
        _Product.ProductNum = txtProductNum.Text;
        _Product.PortalID = ZNodeConfigManager.SiteConfig.PortalID;
        _Product.ActiveInd = true;
        if (ProductTypeList.SelectedIndex != -1)
        {
            _Product.ProductTypeID = Convert.ToInt32(ProductTypeList.SelectedValue);
        }
        else
        {
            //"Please add a product type before you add a new product";
        }
        //MANUFACTURER
        if (ManufacturerList.SelectedIndex != -1)
        {
            if (ManufacturerList.SelectedItem.Text.Equals("No Manufacturer Selected"))
            {
                _Product.ManufacturerID = null;
            }
            else
            {
                _Product.ManufacturerID = Convert.ToInt32(ManufacturerList.SelectedValue);
            }
        }

        _Product.ShortDescription = txtshortdescription.Text;
        _Product.Description = ctrlHtmlText.Html;                           
        _Product.RetailPrice = Convert.ToDecimal(txtproductRetailPrice.Text);

        if (txtproductSalePrice.Text.Trim().Length > 0)
        {
            _Product.SalePrice = Convert.ToDecimal(txtproductSalePrice.Text.Trim());
        }
        else { _Product.SalePrice = null; }        

        if (txtProductWholeSalePrice.Text.Trim().Length > 0)
        {
            _Product.WholesalePrice = Convert.ToDecimal(txtProductWholeSalePrice.Text.Trim());
        }
        else { _Product.WholesalePrice  = null; }

        //Quantity Available
        _Product.QuantityOnHand = Convert.ToInt32(txtProductQuantity.Text);

        //Stock
        DataSet MyAttributeTypeDataSet = _ProductAdmin.GetAttributeTypeByProductTypeID(int.Parse(ProductTypeList.SelectedValue));
        if (MyAttributeTypeDataSet.Tables[0].Rows.Count == 0)
        {
            _Product.SKU = txtProductSKU.Text.Trim();
            _Product.QuantityOnHand = Convert.ToInt32(txtProductQuantity.Text);
        }
        else
        {
            //SKU         
            _SkuList.ProductID = ItemID;
            _SkuList.QuantityOnHand = Convert.ToInt32(txtProductQuantity.Text);
            _SkuList.SKU = txtProductSKU.Text;
            _Product.QuantityOnHand = 0; //Reset quantity available in the Product table,If SKU is selected
        }
        #endregion

        #region Image Validation

        //Validate image
        if ((ItemID == 0) || (RadioProductNewImage.Checked == true))
        {
            //Check for Product Image
            _FileInfo = new System.IO.FileInfo(UploadProductImage.PostedFile.FileName);

            if (_FileInfo != null)
            {              
              _Product.ImageFile = _FileInfo.Name;                 
            }  
        }
        #endregion

        #region Database & Image Updates

        //create transaction
        TransactionManager tranManager = ConnectionScope.CreateTransaction();

        try
        {
            if (ItemID > 0) //PRODUCT UPDATE
            {
                //Update product Sku and Product values
                if (MyAttributeTypeDataSet.Tables[0].Rows.Count > 0) //If ProductType has SKU's
                {
                    if (_SkuList.SKUID > 0) //For this product already SKU if on exists
                    {
                        //then Update the database with new property values
                        retVal = _ProductAdmin.Update(_Product, _SkuList);
                    }
                    else
                    {                        
                        retVal = _ProductAdmin.Update(_Product);
                        //If Product doesn't have any SKUs yet,then create new SKU in the database
                        _SKUAdminAccess.Add(_SkuList);
                    }
                }
                else
                {
                    retVal = _ProductAdmin.Update(_Product);
                    //If User selectes Default product type for this product,
                    //then Remove all the existing SKUs for this product
                    _SKUAdminAccess.DeleteByProductId(ItemID);
                }

                if (!retVal) { throw (new ApplicationException()); }

                //Delete existing categories
                _ProductAdmin.DeleteProductCategories(ItemID);

                //Add Product Categories
                foreach (TreeNode Node in CategoryTreeView.CheckedNodes)
                {
                    ProductCategory prodCategory = new ProductCategory();
                    ProductAdmin prodAdmin = new ProductAdmin();

                    prodCategory.CategoryID = int.Parse(Node.Value);
                    prodCategory.ProductID = ItemID;
                    prodAdmin.AddProductCategory(prodCategory);
                }

                //Delete existing SKUAttributes
                _SKUAdminAccess.DeleteBySKUId(_SkuList.SKUID);

                //Add SKU Attributes
                //DataSet MyAttributeTypeDataSet = _ProductAdmin.GetAttributeTypeByProductTypeID(int.Parse(ProductTypeList.SelectedValue));

                foreach (DataRow MyDataRow in MyAttributeTypeDataSet.Tables[0].Rows)
                {
                    System.Web.UI.WebControls.DropDownList lstControl = (System.Web.UI.WebControls.DropDownList)ControlPlaceHolder.FindControl("lstAttribute" + MyDataRow["AttributeTypeId"].ToString());

                    int selValue = int.Parse(lstControl.SelectedValue);

                    if (selValue > 0)
                    {
                        _skuAttribList.AttributeId = selValue;
                    }

                    _skuAttribList.SKUID = _SkuList.SKUID;

                   _SKUAdminAccess.AddSKUAttribute(_skuAttribList);


                }


            }
            else //PRODUCT ADD
            {
                //Add Product/SKU
                if (MyAttributeTypeDataSet.Tables[0].Rows.Count > 0)
                {
                    //if ProductType has SKUs, then insert sku with Product
                    retVal = _ProductAdmin.Add(_Product, _SkuList, out _ProductID, out SKUId);
                }
                else
                {
                    retVal = _ProductAdmin.Add(_Product, out _ProductID); //if ProductType is Default
                }

                if (!retVal) { throw (new ApplicationException()); }

                //Add Category List for the Product
                foreach (TreeNode Node in CategoryTreeView.CheckedNodes)
                {
                    ProductCategory prodCategory = new ProductCategory();
                    ProductAdmin prodAdmin = new ProductAdmin();

                    prodCategory.CategoryID = int.Parse(Node.Value);
                    prodCategory.ProductID = _ProductID;
                    prodAdmin.AddProductCategory(prodCategory);
                }

                
                //Add SKU Attributes
                //DataSet MyAttributeTypeDataSet = _ProductAdmin.GetAttributeTypeByProductTypeID(int.Parse(ProductTypeList.SelectedValue));

                foreach (DataRow MyDataRow in MyAttributeTypeDataSet.Tables[0].Rows)
                {
                    System.Web.UI.WebControls.DropDownList lstControl = (System.Web.UI.WebControls.DropDownList)ControlPlaceHolder.FindControl("lstAttribute" + MyDataRow["AttributeTypeId"].ToString());

                    int selValue = int.Parse(lstControl.SelectedValue);

                    if (selValue > 0)
                    {
                        _skuAttribList.AttributeId = selValue;
                    }

                    _skuAttribList.SKUID = SKUId;

                    _SKUAdminAccess.AddSKUAttribute(_skuAttribList);


                }
            }

            //Commit transaction
            tranManager.Commit();
        }
        catch //error occurred so rollback transaction
        {
            tranManager.Rollback();
            lblMsg.Text = "Unable to update product. Please try again.";
            return;
        }

        //Upload File if this is a new product or the New Image option was selected for an existing product
        if (RadioProductNewImage.Checked || ItemID==0)
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

        #endregion     

        #region Redirect to next page
        //Redirect to next page
        if (ItemID > 0)
        {
            string ViewLink = "~/admin/secure/catalog/product/view.aspx?itemid=" + ItemID.ToString();
            Response.Redirect(ViewLink);
        }
        else
        {
            string NextLink = "~/admin/secure/catalog/product/view.aspx?itemid=" + _ProductID.ToString();
            Response.Redirect(NextLink);
        }
        #endregion
    }

    /// <summary> 
    /// Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ItemID > 0)
        {
            Response.Redirect(CancelLink + ItemID);
        }
        else
        {
            Response.Redirect(ListLink);
        }
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

    # endregion

    # region Helper Methods

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
    
    /// <summary>
    /// Returns a Format Weight string
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string FormatNull(Object FieldValue)
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
                return FieldValue.ToString();
            }
        }
    }

    /// <summary>
    /// Format Retail and Wholesale price
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
            if (FieldValue.ToString().Equals("0"))
            {
                return String.Empty;
            }
            else
            {
                return ((String.Format("{0:c}", FieldValue)).Substring(1).ToString());
            }
            
        }
    }

    /// <summary>
    /// Populates a treeview with store categories for a Product
    /// </summary>
    /// <param name="selectedCategoryId"></param>
    private void PopulateEditTreeView(string selectedCategoryId)
    {
        foreach (TreeNode Tn in CategoryTreeView.Nodes)
        {
            if (Tn.Value.Equals(selectedCategoryId))
            {
                Tn.Checked  = true;
            }
            RecursivelyEditPopulateTreeView(Tn, selectedCategoryId);
        }
    }

    /// <summary>
    /// Recursively populate a particular node with it's children for a product
    /// </summary>
    /// <param name="ChildNodes"></param>
    /// <param name="selectedCategoryid"></param>
    private void RecursivelyEditPopulateTreeView(TreeNode ChildNodes, string selectedCategoryid)
    {
        foreach (TreeNode CNodes in ChildNodes.ChildNodes)
        {
            if (CNodes.Value.Equals(selectedCategoryid))
            {
                CNodes.Checked  = true;
                RecursivelyExpandTreeView(CNodes);
            }

            RecursivelyEditPopulateTreeView(CNodes, selectedCategoryid);
        }
    }

    /// <summary>
    /// Populates a treeview with store categories
    /// </summary>
    /// <param name="ctrlTreeView"></param>
    public void PopulateAdminTreeView(string selectedCategoryId)
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
                    tn.Value = dbRow["categoryid"].ToString();

                    string categoryId = dbRow["CategoryId"].ToString();

                    //Add Root Node to Category Tree view
                    CategoryTreeView.Nodes.Add(tn);

                    if (selectedCategoryId.Equals(categoryId))
                    {
                        tn.Selected = true;
                        RecursivelyExpandTreeView(tn);
                    }

                    RecursivelyPopulateTreeView(dbRow, tn, selectedCategoryId);
                }
            }

        }
    }

    
    /// <summary>
    /// Recursively populate a particular node with it's children
    /// </summary>
    /// <param name="dbRow"></param>
    /// <param name="parentNode"></param>
    /// <param name="selectedCategoryId"></param>
    private void RecursivelyPopulateTreeView(DataRow dbRow, TreeNode parentNode, string selectedCategoryId)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            if ((bool)childRow["VisibleInd"])
            {
                //create new tree node
                TreeNode tn = new TreeNode();
                tn.Text = childRow["Name"].ToString();
                tn.Value = childRow["categoryid"].ToString();

                string categoryId = childRow["CategoryId"].ToString();

                parentNode.ChildNodes.Add(tn);

                if (selectedCategoryId.Equals(categoryId))
                {
                    tn.Selected = true;
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
            nodeItem.Parent.ExpandAll();
            RecursivelyExpandTreeView(nodeItem.Parent);
        }
        else
        {
            nodeItem.Expand();
            return;
        }
    }
   # endregion    
}
