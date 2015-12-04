using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage ProductCategory object
    /// </summary>
    public class ProductCategoryAdmin:ZNodeBusinessBase 
    {
        # region Public Methods

        /// <summary>
        /// Returns All ProductCategories
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.ProductCategory> GetAllProductCategory()
        {
            ZNode.Libraries.DataAccess.Service.ProductCategoryService _ProductCategoryService = new ProductCategoryService();
            TList<ProductCategory> _productCategoryList=_ProductCategoryService.GetAll();

            return _productCategoryList;
        }

        /// <summary>
        /// Returns a productcategory by productcategoryid
        /// </summary>
        /// <param name="productCategoryID"></param>
        /// <returns></returns>
        public ProductCategory GetByProductCategoryID(int productCategoryID)
        {
            ZNode.Libraries.DataAccess.Service.ProductCategoryService _ProductCategoryService = new ProductCategoryService();
            ProductCategory _productCategoryList = _ProductCategoryService.GetByProductCategoryID(productCategoryID);

            return _productCategoryList;
        }

        /// <summary>
        /// Returnds a Product category for a Product
        /// </summary>
        /// <param name="_productID"></param>
        /// <returns></returns>
        public DataSet GetByProductID(int _productID)
        {
            ZNode.Libraries.DataAccess.Custom.ProductCategoryHelper _productCategoryHelper = new ProductCategoryHelper();
           
            return _productCategoryHelper.GetByProductID(_productID);
           

        }

        /// <summary>
        /// Returns product category for a product and category
        /// </summary>
        /// <param name="_productID"></param>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public DataSet GetBycategoryID(int _productID, int CategoryID)
        {

            ZNode.Libraries.DataAccess.Custom.ProductCategoryHelper _productCategoryHelper = new ProductCategoryHelper();

            return _productCategoryHelper.GetByCategoryID(_productID,CategoryID);
        }


        /// <summary>
        /// Add new a product Category
        /// </summary>
        /// <param name="_ProductCategory"></param>
        /// <returns></returns>
        public bool Add(ProductCategory _ProductCategory)
        {
            ZNode.Libraries.DataAccess.Service.ProductCategoryService _ProductCategoryService = new ProductCategoryService();
            
            return _ProductCategoryService.Insert(_ProductCategory);

        }

        /// <summary>
        /// Update a Product Category
        /// </summary>
        /// <param name="_ProductCategory"></param>
        /// <returns></returns>
        public bool Update(ProductCategory _ProductCategory)
        {
            ZNode.Libraries.DataAccess.Service.ProductCategoryService _ProductCategoryService = new ProductCategoryService();

            return _ProductCategoryService.Update(_ProductCategory);

        }

        /// <summary>
        /// Delete a Product Category
        /// </summary>
        /// <param name="_prodoductcategory"></param>
        /// <returns></returns>
        public bool Delete(ProductCategory _prodoductcategory)
        {
            ZNode.Libraries.DataAccess.Service.ProductCategoryService _ProductCategoryService = new ProductCategoryService();

            return _ProductCategoryService.Delete(_prodoductcategory);
        }
        #endregion
    }
}
