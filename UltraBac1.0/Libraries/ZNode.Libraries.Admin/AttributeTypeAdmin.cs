using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// This Class Manages Product Attribute types,product Attributes , ProductTypeAttribute
    /// </summary>
    public class AttributeTypeAdmin : ZNodeBusinessBase
    {

        # region public Attribute Type Methods

        /// <summary>
        /// Returns all product attribute types
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.AttributeType> GetAll()
        {
            ZNode.Libraries.DataAccess.Service.AttributeTypeService _Service = new ZNode.Libraries.DataAccess.Service.AttributeTypeService();

            TList<ZNode.Libraries.DataAccess.Entities.AttributeType> _AttributeList = _Service.GetAll();

            return _AttributeList;
        }

        /// <summary>
        /// Get a Attribute type
        /// </summary>
        /// <param name="attributeTypeID"></param>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.AttributeType GetByAttributeTypeId(int attributeTypeID)
        {
            ZNode.Libraries.DataAccess.Service.AttributeTypeService _Service = new ZNode.Libraries.DataAccess.Service.AttributeTypeService();

            ZNode.Libraries.DataAccess.Entities.AttributeType _AttributeList = _Service.GetByAttributeTypeId(attributeTypeID);

            return _AttributeList;
        }

        /// <summary>
        /// Add Attribute Type
        /// </summary>
        /// <param name="_AttributeType"></param>
        /// <returns></returns>
        public bool Add(AttributeType _AttributeType)
        {
            ZNode.Libraries.DataAccess.Service.AttributeTypeService _Service = new ZNode.Libraries.DataAccess.Service.AttributeTypeService();

            bool checkbool = _Service.Insert(_AttributeType);

            return checkbool;
        }

        /// <summary>
        /// Update Attribute Type
        /// </summary>
        /// <param name="_AttributeType"></param>
        /// <returns></returns>
        public bool Update(AttributeType _AttributeType)
        {
            ZNode.Libraries.DataAccess.Service.AttributeTypeService _Service = new ZNode.Libraries.DataAccess.Service.AttributeTypeService();

            bool checkbool = _Service.Update(_AttributeType);

            return checkbool;
        }

        /// <summary>
        /// Delete Attribute Type
        /// </summary>
        /// <param name="_AttributeType"></param>
        /// <returns></returns>
        public bool DeleteAttributeType(AttributeType _AttributeType)
        {
            ZNode.Libraries.DataAccess.Service.AttributeTypeService _Service = new ZNode.Libraries.DataAccess.Service.AttributeTypeService();

            bool checkbool = _Service.Delete(_AttributeType);

            return checkbool;
        }

        /// <summary>
        /// Returns No of Product Types for this Attribute Type
        /// </summary>
        /// <param name="AttributeTypeID"></param>
        /// <returns></returns>
        public int GetCountByAttributeTypeID(int AttributeTypeID)
        {
            int CountValue = 0;
            ProductTypeHelper _HelperAccess = new ProductTypeHelper();

            CountValue = _HelperAccess.GetProductTypeCount(AttributeTypeID);

            return CountValue;
        }
        # endregion

        # region Public Product Attributes Methods

        /// <summary>
        /// Returns all product attribute
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.ProductAttribute> GetAllProductAttribute()
        {
            ZNode.Libraries.DataAccess.Service.ProductAttributeService _Service = new ZNode.Libraries.DataAccess.Service.ProductAttributeService();

            TList<ZNode.Libraries.DataAccess.Entities.ProductAttribute> _AttributeList = _Service.GetAll();

            return _AttributeList;
        }

        /// <summary>
        /// Returns a Product Attribute for this attribute type
        /// </summary>
        /// <param name="AttributeTypeID"></param>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.ProductAttribute> GetByAttributeTypeID(int AttributeTypeID)
        {
            ZNode.Libraries.DataAccess.Service.ProductAttributeService _Service = new ZNode.Libraries.DataAccess.Service.ProductAttributeService();

            TList<ZNode.Libraries.DataAccess.Entities.ProductAttribute> AttributeList = _Service.GetByAttributeTypeId(AttributeTypeID);

            return AttributeList;
        }

        /// <summary>
        /// Returns a Product Attribute for this attribute type
        /// </summary>
        /// <param name="AttributeTypeID"></param>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.ProductAttribute GetByAttributeID(int AttributeID)
        {
            ZNode.Libraries.DataAccess.Service.ProductAttributeService _Service = new ZNode.Libraries.DataAccess.Service.ProductAttributeService();

            ZNode.Libraries.DataAccess.Entities.ProductAttribute _AttributeServ = _Service.GetByAttributeId(AttributeID);

            return _AttributeServ;
        }

        /// <summary>
        /// Add Product Attribute
        /// </summary>
        /// <param name="_AttributeType"></param>
        /// <returns></returns>
        public bool AddProductAttribute(ProductAttribute  _ProductAttribute)
        {
            ZNode.Libraries.DataAccess.Service.ProductAttributeService _AttributeService = new ZNode.Libraries.DataAccess.Service.ProductAttributeService();

            bool checkbool = _AttributeService.Insert(_ProductAttribute);

            return checkbool;
        }

        /// <summary>
        /// Update Product Attribute
        /// </summary>
        /// <param name="_AttributeType"></param>
        /// <returns></returns>
        public bool UpdateProductAttribute(ProductAttribute _ProductAttribute)
        {
            ZNode.Libraries.DataAccess.Service.ProductAttributeService _AttributeService = new ZNode.Libraries.DataAccess.Service.ProductAttributeService();

            bool checkbool = _AttributeService.Update (_ProductAttribute);

            return checkbool;
        }

        /// <summary>
        /// Delete Product Attribute
        /// </summary>
        /// <param name="_AttributeType"></param>
        /// <returns></returns>
        public bool DeleteProductAttribute(ProductAttribute _ProductAttribute)
        {
            ZNode.Libraries.DataAccess.Service.ProductAttributeService _AttributeService = new ZNode.Libraries.DataAccess.Service.ProductAttributeService();

            bool checkbool = _AttributeService.Delete(_ProductAttribute);

            return checkbool;
        }

        # endregion

        # region Public ProductType Attribute Methods

        /// <summary>
        /// Returns Attribue type for a ProductType
        /// </summary>
        /// <param name="ProductTypeID"></param>
        /// <returns></returns>
        public DataSet GetAttributeTypeByProductTypeID(int ProductTypeID)
        {
         ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService _Service = new ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService();

         TList<ProductTypeAttribute> _AttributesList =  _Service.GetByProductTypeId(ProductTypeID);

         return _AttributesList.ToDataSet(true);
        
        }
        /// <summary>
        /// Add New Product type Attribute
        /// </summary>
        /// <param name="ProductTypeID"></param>
        /// <param name="AttributeTypeID"></param>
        /// <returns></returns>
        public bool AddProductTypeAttribute(ProductTypeAttribute _ProductTypeAttribute)
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService _Service = new ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService();

            bool Check = _Service.Insert(_ProductTypeAttribute);

            return Check;
        }

       
        /// <summary>
        /// Delete ProductTypeAttribute
        /// </summary>
        /// <param name="_ProductTypeAttribute"></param>
        /// <returns></returns>
        public bool DeleteProductTypeAttribute(ProductTypeAttribute _ProductTypeAttribute)
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService _Service = new ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService();

            bool CheckStatus = false;

            CheckStatus = _Service.Delete(_ProductTypeAttribute);

            return CheckStatus;
        }

        /// <summary>
        /// Returns all product type attributes
        /// </summary>
        /// <returns></returns>
        public TList<ProductTypeAttribute> GetAllProductTypeAttribute()
        {
            ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService _Service = new ZNode.Libraries.DataAccess.Service.ProductTypeAttributeService();

            TList<ProductTypeAttribute> _List  = _Service.GetAll();

            return _List;
        }

        # endregion

    }

}
