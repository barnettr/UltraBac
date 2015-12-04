using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Admin;
using System.Data;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage product images
    /// </summary>
   public class ProductViewAdmin:ZNodeBusinessBase
   {
       #region Public Method
       /// <summary>
        /// Returns the row for the ProductId
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public DataSet GetByProductID(int ProductId)
        {
            ZNode.Libraries.DataAccess.Service.ProductImageService imageservice = new ProductImageService();
            DataSet mydataset = imageservice.GetByProductID(ProductId).ToDataSet(true);//ZNode.Libraries.DataAccess.Entities.ProductImage ProductList = imageservice.GetByProductID(ProductId);
            return mydataset;
        }

       /// <summary>
       /// Gets Product Images for the ProductID
       /// </summary>
       /// <param name="productid"></param>
       /// <returns></returns>
       public TList<ProductImage> GetImageByProductID(int productid)
        {
           ZNode.Libraries.DataAccess.Service.ProductImageService Access = new ProductImageService();
           TList<ZNode.Libraries.DataAccess.Entities.ProductImage> List = Access.GetByProductID(productid);
           return List;
        }

        /// <summary>
        /// Update a ProductImage
        /// </summary>
        /// <param name="prodimage"></param>
        /// <returns></returns>
       public bool Update(ZNode.Libraries.DataAccess.Entities.ProductImage prodimage)
       {
           ZNode.Libraries.DataAccess.Service.ProductImageService imageservice = new ProductImageService();
           bool status = imageservice.Update(prodimage);
           return status;
       }

       /// <summary>
       /// Insert a new ProductImage
       /// </summary>
       /// <param name="prodimage"></param>
       /// <returns></returns>
       public bool Insert(ZNode.Libraries.DataAccess.Entities.ProductImage prodimage)
       {
           ZNode.Libraries.DataAccess.Service.ProductImageService imageservice = new ProductImageService();
           bool status = imageservice.Insert(prodimage);
           return status;
       }

       /// <summary>
       /// Delete ProductImage
       /// </summary>
       /// <param name="ProductID"></param>
       /// <returns></returns>
       public bool Delete(int ProductID)
       {
           ZNode.Libraries.DataAccess.Service.ProductImageService imageservice = new ProductImageService();
           bool status = imageservice.Delete(ProductID);
           return status;
       }

       /// <summary>
       /// Delete ProductImage by ImageID
       /// </summary>
       /// <param name="ImageID"></param>
       /// <returns></returns>
       public void DeleteByProductID(int ImageID)
       {
           ZNode.Libraries.DataAccess.Service.ProductImageService imageservice = new ProductImageService();
           TList<ZNode.Libraries.DataAccess.Entities.ProductImage> imagelist = imageservice.GetByProductID(ImageID);
           imageservice.Delete(imagelist);
       }

       /// <summary>
       /// Get the ProductImage by the ProductImageID
       /// </summary>
       /// <param name="ProductImageID"></param>
       /// <returns></returns>
       public ZNode.Libraries.DataAccess.Entities.ProductImage GetByProductImageID(int ProductImageID)
       {
           ZNode.Libraries.DataAccess.Service.ProductImageService imageservice = new ProductImageService();

           ZNode.Libraries.DataAccess.Entities.ProductImage product = imageservice.GetByProductImageID(ProductImageID);// GetByProductID(ProductID);

           return product;
       }
       #endregion
   } 
}
