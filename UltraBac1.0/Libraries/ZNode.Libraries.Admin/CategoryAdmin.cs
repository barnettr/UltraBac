using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage Product categories
    /// </summary>
    public class CategoryAdmin:ZNodeBusinessBase 
    {
        /// <summary>
        /// Returns all categories for a portal
        /// </summary>
        /// <returns></returns>
        public TList<Category> GetAllCategories(int portalId)
        {
            ZNode.Libraries.DataAccess.Service.CategoryService categoryServ = new ZNode.Libraries.DataAccess.Service.CategoryService();
            TList<ZNode.Libraries.DataAccess.Entities.Category> categoryList = categoryServ.GetByPortalID(portalId);

            return categoryList;
        }

        /// <summary>
        /// Returns a category by categoryid
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public Category GetByCategoryId(int categoryId)
        {
            ZNode.Libraries.DataAccess.Service.CategoryService categoryServ = new ZNode.Libraries.DataAccess.Service.CategoryService();
            Category category = categoryServ.GetByCategoryID(categoryId);

            return category;
        }

        /// <summary>
        /// Add a new product category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool Add(Category category)
        {
            ZNode.Libraries.DataAccess.Service.CategoryService categoryServ = new ZNode.Libraries.DataAccess.Service.CategoryService();
            return categoryServ.Insert(category);
        }

        /// <summary>
        /// Update a product category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool Update(Category category)
        {
            ZNode.Libraries.DataAccess.Service.CategoryService categoryServ = new ZNode.Libraries.DataAccess.Service.CategoryService();
            return categoryServ.Update(category);
        }

        /// <summary>
        /// Delete a product category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool Delete(Category category)
        {          
            ZNode.Libraries.DataAccess.Service.CategoryService categoryServ = new ZNode.Libraries.DataAccess.Service.CategoryService();
            return categoryServ.Delete(category);            
        }

        /// <summary>
        /// Returns a category hierarchical path (upto 3 levels)
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="ParentCategoryName1"></param>
        /// <param name="ParentCategoryName2"></param>
        /// <returns></returns>
        public static string GetCategoryPath(string CategoryName, string ParentCategoryName1, string ParentCategoryName2)
        {
            System.Text.StringBuilder _path = new StringBuilder();

            if (ParentCategoryName2.Trim().Length > 0)
            {
                _path.Append(ParentCategoryName2);
                _path.Append(" > ");
            }
            if (ParentCategoryName1.Trim().Length > 0)
            {
                _path.Append(ParentCategoryName1);
                _path.Append(" > ");
            }
            _path.Append(CategoryName);
            return _path.ToString();
        }

       
    }
}
