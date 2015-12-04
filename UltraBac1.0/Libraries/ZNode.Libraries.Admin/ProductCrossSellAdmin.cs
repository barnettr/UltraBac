using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Custom;

namespace ZNode.Libraries.Admin
{

    /// <summary>
    /// Provides methods to manage product cross sell items
    /// </summary>
    public class ProductCrossSellAdmin:ZNodeBusinessBase 
    {

        # region Public Methods
        /// <summary>
        /// Returns all related items for a product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public DataSet GetByProductID(int ProductID)
        {

            ProductCrossSellHelper productCrossHelper = new ProductCrossSellHelper();
            DataSet ds= productCrossHelper.GetByProductID(ProductID);

            //return DataSet
            return ds;
        }

        /// <summary>
        /// Add New related product item for a Product
        /// </summary>
        /// <param name="PortalID"></param>
        /// <param name="ProductId"></param>
        /// <param name="RelatedProductId"></param>
        public bool Insert(int PortalID, int ProductId, int RelatedProductId)
        {
            //Instance for a ProductCrossSellerHelper class
            ProductCrossSellHelper productCrossHelper = new ProductCrossSellHelper();
            
            bool Check = productCrossHelper.Insert(PortalID, ProductId, RelatedProductId);

            return Check;

        }

        /// <summary>
        /// Delete a Related product item for a Product
        /// </summary>
        /// <param name="RelatedProductID"></param>
        /// <param name="productID"></param>
        /// <param name="portalID"></param>
        public bool Delete(int RelatedProductID,int productID,int portalID)
        {
            
            ProductCrossSellHelper _productCrossSellHelper = new ProductCrossSellHelper();
            bool check = _productCrossSellHelper.RemoveProduct(RelatedProductID,productID,portalID);

            return check;
        }

        # endregion

    }
}
