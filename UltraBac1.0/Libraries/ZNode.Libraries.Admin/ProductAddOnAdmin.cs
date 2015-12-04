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
    /// Provides methods to manage product addons, addon Values
    /// </summary>
    public class ProductAddOnAdmin : ZNodeBusinessBase
    {
        #region Related to ZNodeProductAddon Table
    
        /// <summary>
        /// Returns all Product Addons for a portal
        /// </summary>
        /// <returns></returns>
        public TList<ProductAddOn> GetAllProductAddOns()
        {
            ZNode.Libraries.DataAccess.Service.ProductAddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.ProductAddOnService();

            TList<ZNode.Libraries.DataAccess.Entities.ProductAddOn> ProductAddonList = ProdAddOnService.GetAll();

            return ProductAddonList;
        }

        /// <summary>
        /// Returns true if this is Addon is already assocaited with this product
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsAddOnExists(ProductAddOn entity)
        {
            ZNode.Libraries.DataAccess.Service.ProductAddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.ProductAddOnService();
            string whereClause = "productid = " + entity.ProductID + " and addonid=" + entity.AddOnID;

            int listCount = ProdAddOnService.GetTotalItems(whereClause,out listCount);

            if (listCount == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Add new product Addon
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddNewProductAddOn(ProductAddOn entity)
        {
            ZNode.Libraries.DataAccess.Service.ProductAddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.ProductAddOnService();                     
            
            bool Status = ProdAddOnService.Insert(entity);
           
            return Status;
        }

        /// <summary>
        /// Delete a product Addon
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteProductAddOn(int productAddOnID)
        {
            ZNode.Libraries.DataAccess.Service.ProductAddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.ProductAddOnService();

            bool Status = ProdAddOnService.Delete(productAddOnID);

            return Status;
        }
        /// <summary>
        ///  Returns a ProductAddons by productid
        /// </summary>
        /// <param name="ProductID"></param>
        public TList<ProductAddOn> GetByProductId(int ProductID)
        {
            ZNode.Libraries.DataAccess.Service.ProductAddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.ProductAddOnService();

            TList<ZNode.Libraries.DataAccess.Entities.ProductAddOn> ProductAddonList = ProdAddOnService.GetByProductID(ProductID);
                        
            return ProductAddonList;
        }


    #endregion

        # region Related to ZNodeAddon table

        /// <summary>
        /// Returns Addons for the given input values
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Title"></param>
        /// <param name="ProductSKU"></param>
        /// <returns></returns>
        public DataSet SearchAddOns(string Name,string Title, string ProductSKU)
        {
            ProductHelper HelperAccess = new ProductHelper();
            
            return HelperAccess.SearchAddOns(Name,Title, ProductSKU);
        }

        /// <summary>
        /// Returns all Product Addons for a portal
        /// </summary>
        /// <returns></returns>
        public TList<AddOn> GetAllAddOns()
        {
            ZNode.Libraries.DataAccess.Service.AddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.AddOnService();

            TList<ZNode.Libraries.DataAccess.Entities.AddOn> ProductAddonList = ProdAddOnService.GetAll();

            return ProductAddonList;
        }

        /// <summary>
        /// Return a Addon entity for this AddOnId
        /// </summary>
        /// <returns></returns>
        public AddOn GetByAddOnId(int addOnId)
        {
            ZNode.Libraries.DataAccess.Service.AddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.AddOnService();

            ZNode.Libraries.DataAccess.Entities.AddOn AddonEntity = ProdAddOnService.GetByAddOnID(addOnId);

            return AddonEntity;
        }
        
        /// <summary>
        ///  Returns all ProductAddons
        /// </summary>
        /// <param name="ProductID"></param>
        public TList<AddOn> GetAddOnByProductId()
        {
            ZNode.Libraries.DataAccess.Service.AddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.AddOnService();

            TList<ZNode.Libraries.DataAccess.Entities.AddOn> ProductAddonList = ProdAddOnService.GetAll();

            return ProductAddonList;
        }

        /// <summary>
        /// Add a new product AddOn
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool CreateNewProductAddOn(AddOn Entity,out int ProductAddOnID)
        {
            ZNode.Libraries.DataAccess.Service.AddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.AddOnService();

            bool Status = ProdAddOnService.Insert(Entity);

            ProductAddOnID = Entity.AddOnID;

            return Status;
        }

        /// <summary>
        /// Update a AddOn Entity
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool UpdateNewProductAddOn(AddOn Entity)
        {
            ZNode.Libraries.DataAccess.Service.AddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.AddOnService();

            bool Status = ProdAddOnService.Update(Entity);

            return Status;
        }

        /// <summary>
        /// Delete a AddOn entity
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool DeleteAddOn(int addOnID)
        {
            ZNode.Libraries.DataAccess.Service.AddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.AddOnService();

            bool Status = ProdAddOnService.Delete(addOnID);

            return Status;
        }

        /// <summary>
        /// Delete a product AddOn (options)
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool DeleteAddOn(AddOn Entity)
        {
            ZNode.Libraries.DataAccess.Service.AddOnService ProdAddOnService = new ZNode.Libraries.DataAccess.Service.AddOnService();

            bool Status = ProdAddOnService.Delete(Entity);

            return Status;
        }
        #endregion

        # region Related to ZNodeAddonValue table
        /// <summary>
        /// Returns all AddOn values for the AddOnId
        /// </summary>
        /// <returns></returns>
        public TList<AddOnValue> GetAddOnValuesByAddOnId(int addOnID)
        {
            AddOnValueService AddOnValueSrv = new AddOnValueService();

            TList<AddOnValue> AddonValueList = AddOnValueSrv.GetByAddOnID(addOnID);

            return AddonValueList;
        }

        /// <summary>
        /// Returns the AddOnValue Entity 
        /// </summary>
        /// <param name="addOnValueID"></param>
        /// <returns></returns>
        public AddOnValue GetByAddOnValueID(int addOnValueID)
        {
            AddOnValueService AddOnValueSrv = new AddOnValueService();
            AddOnValue Entity = AddOnValueSrv.GetByAddOnValueID(addOnValueID);

            return Entity;
        }

        /// <summary>
        /// Add New Addon Value
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool AddNewAddOnValue(AddOnValue Entity)
        {
            AddOnValueService AddOnValueSrv = new AddOnValueService();

            if (Entity.DefaultInd)
            {
                ResetDefault(Entity.AddOnID);
            }

            bool Status = AddOnValueSrv.Insert(Entity);

            return Status;
        }

        /// <summary>
        /// Update AddOn Value
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool UpdateAddOnValue(AddOnValue Entity)
        {
            AddOnValueService AddOnValueSrv = new AddOnValueService();

            if (Entity.DefaultInd)
            {
                ResetDefault(Entity.AddOnID);
            }

            bool Status = AddOnValueSrv.Update(Entity);

            return Status;
        }

        /// <summary>
        /// Update AddOn Value
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool DeleteAddOnValue(int addOnValue)
        {
            AddOnValueService AddOnValueSrv = new AddOnValueService();

            bool Status = AddOnValueSrv.Delete(addOnValue);

            return Status;
        }
        
        /// <summary>
        /// Method will reset all other values in this option when making this default.
        /// </summary>
        /// <param name="addOnID"></param>
        private void ResetDefault(int addOnID)
        {
            AddOnValueService AddOnValueService = new AddOnValueService();

            TList<AddOnValue> list = AddOnValueService.GetByAddOnID(addOnID);

            foreach (AddOnValue _addOnValue in list)
            {
                //Reset Default Value
                _addOnValue.DefaultInd = false;
            }

            AddOnValueService.Update(list);
        }
        #endregion
    }
}
