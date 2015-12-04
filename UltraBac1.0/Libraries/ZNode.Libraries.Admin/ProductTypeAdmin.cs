using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Custom;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ZNode.Libraries.Admin
{

    /// <summary>
    /// Provides methods to manage producttypes
    /// </summary>
    public class ProductTypeAdmin:ZNodeBusinessBase 
    {
        # region Public Methods
        
        /// <summary>
        /// Returns all producttypes for a portal
        /// </summary>
        /// <returns></returns>
        public TList<ProductType> GetAllProductTypes(int portalId)
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeService ProductTypeServ = new ZNode.Libraries.DataAccess.Service.ProductTypeService();
            TList<ZNode.Libraries.DataAccess.Entities.ProductType> ProductTypeList = ProductTypeServ.GetByPortalId(portalId);

            return ProductTypeList;
        }

        /// <summary>
        /// Return All Producttypes for a portal
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns>DataSet</returns>
        public DataSet GetAllProductType(int portalId)
        {
            ZNode.Libraries.DataAccess.Custom.ProductTypeHelper _productHelper = new ZNode.Libraries.DataAccess.Custom.ProductTypeHelper();

            DataSet MydataSet= _productHelper.GetAllProductType(portalId);

            return MydataSet;

        }

        /// <summary>
        /// Returns a ProductType by productTypeid
        /// </summary>
        /// <param name="ProductTypeId"></param>
        /// <returns></returns>
        public ProductType GetByProdTypeId(int ProductTypeId)
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeService ProductTypeServ = new ZNode.Libraries.DataAccess.Service.ProductTypeService();
            ProductType ProductTypes = ProductTypeServ.GetByProductTypeId(ProductTypeId);

            return ProductTypes;
        }

        /// <summary>
        /// Add a new productType
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public bool Add(ProductType ProductType)
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeService ProductTypeServ = new ZNode.Libraries.DataAccess.Service.ProductTypeService();

            return ProductTypeServ.Insert(ProductType);
        }

        /// <summary>
        /// Update a productType
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public bool Update(ProductType ProductType)
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeService ProductTypeServ = new ZNode.Libraries.DataAccess.Service.ProductTypeService();

            return ProductTypeServ.Update(ProductType);
        }

        /// <summary>
        /// Delete a productType
        /// </summary>
        /// <param name="ProductType"></param>
        /// <returns></returns>
        public bool Delete(ProductType ProductType)
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeService ProductTypeServ = new ZNode.Libraries.DataAccess.Service.ProductTypeService();

            return ProductTypeServ.Delete(ProductType);
        }

        /// <summary>
        /// Gets Attribute types for this producttype
        /// </summary>
        /// <param name="productTypeID"></param>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public DataSet GetAttributeNamesByProductTypeid(int productTypeID,int PortalID)
        {
            //ProductTypeHelper _HelperAccess = new ProductTypeHelper();
            AttributeTypeHelper _HelperAccess = new AttributeTypeHelper();
            DataSet MyDataSet  = _HelperAccess.GetByProductTypeID(productTypeID,PortalID);

            return MyDataSet;
        }

        
        # endregion
    }
}
