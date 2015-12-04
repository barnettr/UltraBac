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
    /// Provides methods to manage Product sku 
    /// </summary>
    public class SKUAdmin:ZNodeBusinessBase 
    {
        #region Public Methods
              
        /// <summary>
        /// Returns all product skus
        /// </summary>
        /// <returns></returns>
        public TList<SKU> GetAllSKU()
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSkuAdmin = new SKUService();

            TList<ZNode.Libraries.DataAccess.Entities.SKU> _SkuList = ProductSkuAdmin.GetAll();

            return _SkuList;
        }

        /// <summary>
        /// Returns Sku for this sku id
        /// </summary>
        /// <param name="skuID"></param>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.SKU GetBySKUID(int skuID)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSkuAdmin = new SKUService();

            ZNode.Libraries.DataAccess.Entities.SKU _SkuList = ProductSkuAdmin.GetBySKUID(skuID);

            return _SkuList;
        }

        /// <summary>
        /// Returns Product SKU for this sku
        /// </summary>
        /// <param name="skuID"></param>
        /// <returns></returns>
        public ZNode.Libraries.DataAccess.Entities.SKU GetBySKU(string SKU)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSkuAdmin = new SKUService();

            TList<SKU> _SkuList = ProductSkuAdmin.Find("SKU='" + SKU + "'");

            SKU _sku = null;

            if (_SkuList.Count > 0) { _sku = _SkuList[0]; }

            return _sku;
        }
      
      

        /// <summary>
        /// Add a new product SKU
        /// </summary>
        /// <param name="_Sku"></param>
        /// <returns></returns>
        public bool Add(SKU _Sku)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSKUAdmin = new SKUService();

            bool Retvalue = ProductSKUAdmin.Insert(_Sku);                   

            return Retvalue;
        }
        
        /// <summary>
        /// Add a new product SKU
        /// </summary>
        /// <param name="_Sku"></param>
        /// <returns></returns>
        public bool Add(SKU _Sku, out int SKUID)
        {
            SKUID = 0;

            ZNode.Libraries.DataAccess.Service.SKUService ProductSKUAdmin = new SKUService();

            bool Retvalue = ProductSKUAdmin.Insert(_Sku);

            SKUID =  _Sku.SKUID;

            return Retvalue;
        }

        /// <summary>
        /// Add a new product SKU and SKU Attribute
        /// </summary>
        /// <param name="_Sku"></param>
        /// <returns></returns>
        public bool Add(SKU _Sku,SKUAttribute _SkuAttrib)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSKUAdmin = new SKUService();

            bool Retvalue = ProductSKUAdmin.Insert(_Sku);

            if (Retvalue)
            {
                _SkuAttrib.SKUID = _Sku.SKUID;
                Retvalue = this.AddSKUAttribute(_SkuAttrib);
            }

            return Retvalue;
        }

        /// <summary>
        /// Update a product SKU
        /// </summary>
        /// <param name="_Sku"></param>
        /// <returns></returns>
        public bool Update(SKU _Sku)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSKUAdmin = new SKUService();

            bool Retvalue = ProductSKUAdmin.Update(_Sku);

            return Retvalue;
        }

        /// <summary>
        /// Update SKU
        /// </summary>
        /// <param name="_Sku"></param>
        /// <param name="_SkuAttrib"></param>
        /// <returns></returns>
        public bool Update(SKU _Sku, SKUAttribute _SkuAttrib)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSKUAdmin = new SKUService();

            bool Retvalue = ProductSKUAdmin.Update(_Sku);

            if (Retvalue)
            {
                Retvalue = this.UpdateSKUAttribute(_SkuAttrib);
            }

            return Retvalue;
        }

        /// <summary>
        /// Delete a ProductSKU
        /// </summary>
        /// <param name="_SKU"></param>
        /// <param name="_SKUattribute"></param>
        /// <returns></returns>
        public bool Delete(int skuId)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSKUAdmin = new SKUService();

            bool Retvalue = ProductSKUAdmin.Delete(skuId);

            if (!Retvalue) { return false; }
                          
            return Retvalue;
        }

        /// <summary>
        /// Delete Product SKU and SKUAttributes
        /// </summary>
        /// <param name="_SKU"></param>
        /// <param name="_SKUattribute"></param>
        /// <returns></returns>
        public void DeleteByProductId(int productId)
        {
            ZNode.Libraries.DataAccess.Service.SKUService ProductSKUAdmin = new SKUService();

            TList<SKU> SKUList = ProductSKUAdmin.GetByProductID(productId);

            foreach (SKU _sku in SKUList)
            {
                DeleteBySKUId(_sku.SKUID);
            }

            ProductSKUAdmin.Delete(SKUList);
            
        }

        /// <summary>
        /// Returns all skus for a product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public DataSet GetByProductID(int ProductID)
        {

            ZNode.Libraries.DataAccess.Service.SKUService _ProductSKUService = new SKUService();

            TList<ZNode.Libraries.DataAccess.Entities.SKU> _SkuList =_ProductSKUService.GetByProductID(ProductID);

            return _SkuList.ToDataSet(true);
        }

        #endregion

        # region SKUAtribute Public Methods

        /// <summary>
        /// Returns product SKUAttribute for this SKUAttributeID
        /// </summary>
        /// <param name="SkuAttributeID"></param>
        /// <returns></returns>
        public SKUAttribute GetBySKUAttributeID(int SkuAttributeID)
        {
            ZNode.Libraries.DataAccess.Service.SKUAttributeService ProductSKUAdmin = new SKUAttributeService();

            ZNode.Libraries.DataAccess.Entities.SKUAttribute _SkuAttrib =  ProductSKUAdmin.GetBySKUAttributeID(SkuAttributeID);

            return _SkuAttrib;
        }
        
              
        /// <summary>
        /// Returns all the SKUAttribute for this SKU 
        /// </summary>
        /// <param name="attributeID"></param>
        /// <param name="SKUID"></param>
        /// <returns></returns>
        public DataSet GetBySKUId(int SKUID)
        {
            ZNode.Libraries.DataAccess.Service.SKUAttributeService ProductSKUAdmin = new SKUAttributeService();

            DataSet MyDataSet = (ProductSKUAdmin.GetBySKUID(SKUID)).ToDataSet(true);

            return MyDataSet;
        }

        /// <summary>
        /// Delete SKUAttributes for this SKUID
        /// </summary>
        /// <param name="SKUID"></param>
        /// <returns></returns>
        public void DeleteBySKUId(int SKUID)
        {
            ZNode.Libraries.DataAccess.Service.SKUAttributeService ProductSKUAdmin = new SKUAttributeService();

            TList<SKUAttribute> _SKUAttribList = ProductSKUAdmin.GetBySKUID(SKUID);

            ProductSKUAdmin.Delete(_SKUAttribList);
            
        }

        /// <summary>
        /// Delete Sku Attribute
        /// </summary>
        /// <param name="_SkuAttrib"></param>
        /// <returns></returns>
        private bool DeleteSKUAttribute(SKUAttribute _SkuAttrib)
        {
            ZNode.Libraries.DataAccess.Service.SKUAttributeService ProductSKUAdmin = new SKUAttributeService();

            bool Retvalue = ProductSKUAdmin.Delete(_SkuAttrib);

            return Retvalue;
        }


        /// <summary>
        /// Update Sku Attribute
        /// </summary>
        /// <param name="_SkuAttrib"></param>
        /// <returns></returns>
        public bool UpdateSKUAttribute(SKUAttribute _SkuAttrib)
        {
            ZNode.Libraries.DataAccess.Service.SKUAttributeService ProductSKUAdmin = new SKUAttributeService();

            bool Retvalue = ProductSKUAdmin.Update(_SkuAttrib);

            return Retvalue;
        }

        

        /// <summary>
        /// Add a new product SKU Attribute
        /// </summary>
        /// <param name="_Sku"></param>
        /// <returns></returns>
        public bool AddSKUAttribute(SKUAttribute _SkuAttrib)
        {
            ZNode.Libraries.DataAccess.Service.SKUAttributeService ProductSKUAdmin = new SKUAttributeService();
            bool Retvalue = ProductSKUAdmin.Insert(_SkuAttrib);

            return Retvalue;
        }
        
        public bool CheckSKUAttributes(int ProductId,int SkuId,string SelectAttributes)
        {
            ZNode.Libraries.DataAccess.Custom.SKUHelper ProductSKUAdmin = new SKUHelper();
            bool SKUvalue = ProductSKUAdmin.GetSKUAttributes(ProductId,SkuId,SelectAttributes);

            return SKUvalue;
        }

        # endregion
    }
}
