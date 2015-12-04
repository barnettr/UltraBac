using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using System.Data;


namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage catalog products
    /// </summary>
    public class ProductAdmin:ZNodeBusinessBase 
    {
        # region Public Methods

        /// <summary>
        /// Returns all Products for a portal
        /// </summary>
        /// <returns></returns>
        public TList<Product> GetAllProducts(int portalID)
        {
           ZNode.Libraries.DataAccess.Service.ProductService ProdService=new ZNode.Libraries.DataAccess.Service.ProductService();

           TList<ZNode.Libraries.DataAccess.Entities.Product> ProductList=ProdService.GetByPortalID(portalID);

           return ProductList;
        }

        
        /// <summary>
        ///  Returns a Product by productid
        /// </summary>
        /// <param name="ProductID"></param>
        public Product GetByProductId(int ProductID)
        {
            ZNode.Libraries.DataAccess.Service.ProductService ProdService = new ZNode.Libraries.DataAccess.Service.ProductService();

            Product Product = ProdService.GetByProductID(ProductID);

            return Product;
        }

        /// <summary>
        /// Search products for a portal and keywords
        /// </summary>
        /// <param name="portalID"></param>
        /// <param name="Keywords"></param>
        /// <returns>DataSet</returns>
        public DataSet FindProducts(int portalID,string Keywords)
        {

            ZNode.Libraries.DataAccess.Custom.ProductHelper ProdService = new ZNode.Libraries.DataAccess.Custom.ProductHelper();

            DataSet MyDataSet = ProdService.Search(portalID, Keywords);

            return MyDataSet;
        }

        /// <summary>
        /// Search products
        /// </summary>
        /// <param name="Productnum"></param>
        /// <param name="Name"></param>
        /// <param name="sku"></param>
        /// <param name="manufacturerid"></param>
        /// <param name="producttypeid"></param>
        /// <param name="categoryid"></param>
        /// <returns>DataSet</returns>
        public DataSet SearchProduct(string Name, string Productnum, string sku, string manufacturerid, string producttypeid, string categoryid)
        {
            ProductHelper prodhelper = new ProductHelper();

            DataSet mydataset = prodhelper.SearchProduct(Name, Productnum, sku, manufacturerid, producttypeid, categoryid);

            return mydataset;
        }

        /// <summary>
        /// Get All Shipping Rule types
        /// </summary>
        /// <returns></returns>
        public TList<ShippingRuleType> GetAllShippingRuleType()
        {
            ZNode.Libraries.Admin.ShippingRuleTypeAdmin _ShippingRuleTypeAdmin = new ShippingRuleTypeAdmin();

            TList<ZNode.Libraries.DataAccess.Entities.ShippingRuleType> _ShippingRuleTypeList = _ShippingRuleTypeAdmin.GetAllShippingRuleType();

            return _ShippingRuleTypeList;
            
        }
        
        /// <summary>
        ///  Add new product
        /// </summary>
        /// <param name="_Product"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public bool Add(Product _Product, out int ProductID)
        {
            ProductID = 0;            
            ZNode.Libraries.DataAccess.Service.ProductService ProdService = new ZNode.Libraries.DataAccess.Service.ProductService();

            bool retVal = ProdService.Insert(_Product);
            if (!retVal) { return false; }

            ProductID = _Product.ProductID;

            return retVal;
        }
       /// <summary>
       ///  Add new product with SKU
       /// </summary>
       /// <param name="_Product"></param>
       /// <param name="_SKU"></param>
       /// <returns></returns>
        public bool Add(Product _Product, SKU _SKU, out int ProductID,out int SKUId)
        {
            ProductID = 0;
            SKUId = 0;
            ZNode.Libraries.DataAccess.Service.ProductService ProdService = new ZNode.Libraries.DataAccess.Service.ProductService();
            
            bool retVal = ProdService.Insert(_Product);
            if (!retVal) { return false; }

            ProductID = _Product.ProductID;

            //Add SKU
            _SKU.ProductID = _Product.ProductID ;
            SKUAdmin _SKuAdminAccess = new SKUAdmin();
            retVal = _SKuAdminAccess.Add(_SKU);
            SKUId = _SKU.SKUID;

            return retVal;
        }
        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="_Product"></param>        
        /// <returns></returns>
        public bool Update(Product _Product)
        {
            ZNode.Libraries.DataAccess.Service.ProductService ProdService = new ZNode.Libraries.DataAccess.Service.ProductService();

            bool CheckStatus = ProdService.Update(_Product);

            return CheckStatus;
        }

      /// <summary>
      /// Update a product and Product UPC or SKU
      /// </summary>
      /// <param name="_Product"></param>
      /// <param name="_SKu"></param>
      /// <returns></returns>
        public bool Update(Product _Product,SKU _SKu)
        {
            ZNode.Libraries.DataAccess.Service.ProductService ProdService = new ZNode.Libraries.DataAccess.Service.ProductService();

            bool CheckStatus = ProdService.Update(_Product);

            //Update Product SKU
            SKUAdmin _SKuAdminAccess = new SKUAdmin();
            _SKuAdminAccess.Update(_SKu);
          
            return CheckStatus;
        }

        /// <summary>
        ///  Delete a Product for a Product id and Portal id
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public bool DeleteByProductID(int ProductID,int portalID)
        {
            //instance for ProductService
            ZNode.Libraries.DataAccess.Service.ProductService ProdService = new ZNode.Libraries.DataAccess.Service.ProductService();

            //Remove all related items associated with this product
            //Delete Cross Sell Items
            ProductCrossSellService productCrossSellService = new ProductCrossSellService();
            TList<ProductCrossSell> CrossSellItems = productCrossSellService.GetByProductId(ProductID);            
            productCrossSellService.Delete(CrossSellItems);

            //Delete product Images
            ProductImageService productImageService = new ProductImageService();
            TList<ProductImage> productImageList = productImageService.GetByProductID(ProductID);
            productImageService.Delete(productImageList);

            //Delete Add-On list associated with this product
            ProductAddOnService productAddOnService = new ProductAddOnService();
            TList<ProductAddOn> AddOnList = productAddOnService.GetByProductID(ProductID);
            productAddOnService.Delete(AddOnList);
            
            //Delte associated SKUs 
            SKUService skuService = new SKUService();
            TList<SKU> SKUList =  skuService.GetByProductID(ProductID);
            skuService.Delete(SKUList);

            //Delete product category
            ProductCategoryService productCategoryService = new ProductCategoryService();
            TList<ProductCategory> entityCollection = productCategoryService.GetByProductID(ProductID);
            productCategoryService.Delete(entityCollection);

            //Delete associated ProductHighlight items
            ProductHighlightService productHightLightService = new ProductHighlightService();
            TList<ProductHighlight> productHighlightCollection = productHightLightService.GetByProductID(ProductID);
            productHightLightService.Delete(productHighlightCollection);

            //If Product is removed it will return true
            bool Status=ProdService.Delete(ProductID);

            //checking boolean value
            if (Status)
            {
                 ProductHelper _productHelper = new ProductHelper();
                _productHelper.DeleteByProductId(ProductID,portalID);
            }

            return Status;
        }

       

        /// <summary>
        /// Add Category for the Product
        /// </summary>
        /// <param name="_productCategory"></param>
        public void AddProductCategory(ProductCategory _productCategory)
        {
            ProductCategoryAdmin _productcategoryAdmin = new ProductCategoryAdmin();

            _productcategoryAdmin.Add(_productCategory);

        }

        /// <summary>
        /// Update the category for the Product
        /// </summary>
        /// <param name="_productCategory"></param>
        public void UpdateProductCategory(ProductCategory _productCategory)
        {
            ProductCategoryAdmin _productcategoryAdmin = new ProductCategoryAdmin();

            _productcategoryAdmin.Update(_productCategory);
        }

        /// <summary>
        /// Deletes all the categories for a product
        /// </summary>
        /// <param name="productID"></param>
        public void DeleteProductCategories(int productID)
        {
            ProductCategoryService serv = new ProductCategoryService();
            
            TList<ProductCategory> catList = serv.GetByProductID(productID);

            serv.Delete(catList);
        }


        /// <summary>
        /// Get All Product details
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public DataSet GetProductDetails(int ProductID)
        {
            ProductHelper ProductAccess = new ProductHelper();

            DataSet MyDataSet = ProductAccess.GetProductDetails(ProductID);

            return MyDataSet;
        }

        /// <summary>
        /// Gets Attribute types for this producttype
        /// </summary>
        /// <param name="productTypeID"></param>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public DataSet GetAttributeNamesByProductTypeid(int productTypeID, int PortalID)
        {
            
            AttributeTypeHelper _HelperAccess = new AttributeTypeHelper();
            DataSet MyDataSet = _HelperAccess.GetByProductTypeID(productTypeID, PortalID);

            return MyDataSet;
        }

        /// <summary>
        /// Gets the SKUPicturePath
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="attributeid"></param>
        /// <returns></returns>
      /*  public string GetSKUPicturePath(int attributeid, int productid)
        {
            ProductHelper _helperaccess = new ProductHelper();

            string Returnpath = _helperaccess.SKUPicturePath(attributeid, productid);

            return Returnpath;           
        }*/
        
        /// <summary>
        /// Returns Attributes for this Attribute type
        /// </summary>
        /// <param name="AttributeTypeID"></param>
        /// <returns></returns>
        public DataSet GetByAttributeTypeID(int AttributeTypeID)
        {
            AttributeTypeAdmin _adminAccess = new AttributeTypeAdmin();

            DataSet MyDataSet = (_adminAccess.GetByAttributeTypeID(AttributeTypeID)).ToDataSet(true);

            return MyDataSet;
        }

        /// <summary>
        /// Returns Attribute type for a Product type
        /// </summary>
        /// <param name="ProductTypeID"></param>
        /// <returns></returns>
        public DataSet GetAttributeTypeByProductTypeID(int ProductTypeID)
        {
            AttributeTypeHelper _HelperAccess = new AttributeTypeHelper();

            DataSet MydataSet = _HelperAccess.GetAttributeTypesByProductTypeID(ProductTypeID);

            return MydataSet;
        }

        /// <summary>
        /// Returns Category for this product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public DataSet Get_CategoryByProductID(int ProductID)
        {

            ProductHelper _Helper = new  ProductHelper();

            DataSet MyDataSet  = _Helper.Get_CategoryByProductID(ProductID);

            return MyDataSet;
        }

        /// <summary>
        /// Returns the attributes for this product type
        /// </summary>
        /// <param name="ProductTypeID"></param>
        /// <returns></returns>
        public DataSet GetAttributesByProductTypeID(int ProductTypeID)
        {
            AttributeTypeHelper _Helper = new AttributeTypeHelper();

            DataSet MyDataSet = _Helper.GetAttributesByProductTypeID(ProductTypeID);

            return MyDataSet;
        }
        /// <summary>
        /// Returns Category Hierarchical path ( Upto 3 Levels)
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="parentcategoryName1"></param>
        /// <param name="parentcategoryName2"></param>
        /// <returns></returns>
        public string GetCategorypath(string categoryName,string parentcategoryName1,string parentcategoryName2)
        {
            string Returnpath = ProductHelper.GetCategoryPath(categoryName, parentcategoryName1, parentcategoryName2);

            return Returnpath;
        }

        /// <summary>
        /// Returns Attributes count for this product typeid
        /// </summary>
        /// <param name="ProductTypeID"></param>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public int GetAttributeCount(int ProductTypeID, int portalID)
        {

            AttributeTypeHelper _AdminHelper = new AttributeTypeHelper();

            DataSet MyDataSet = _AdminHelper.GetByProductTypeID(ProductTypeID, portalID);

            int RowsCount = 0;
            if (MyDataSet != null)
            {
                RowsCount = MyDataSet.Tables[0].Rows.Count;
            }

            MyDataSet.Dispose();

            return RowsCount;
            
        }                  
        # endregion

        # region Delete Catalog Methods
        /// <summary>
        /// Empty catalog data
        /// </summary>
        /// <returns></returns>
        public bool EmptyCatalog()
        {
            ProductHelper _product = new ProductHelper();
            return _product.EmptyCatalog();
        }

        # endregion
    }
}
