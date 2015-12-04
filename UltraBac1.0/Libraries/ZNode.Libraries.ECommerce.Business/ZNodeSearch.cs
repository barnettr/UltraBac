using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZNode.Libraries.Framework.Business;
using System.Xml.Serialization;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides method to search the product catalogs
    /// </summary>
    public class ZNodeSearch : ZNodeBusinessBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ZNodeSearch()
        {
        }

  
        /// <summary>
        /// Searches for products in the database
        /// </summary>
        /// <param name="Keyword"></param>
        /// <param name="SiteId"></param>
        /// <returns>product collection</returns>
        public ZNodeProductList FindProducts(int portalId, string keywords, string delimiter, int categoryId, int searchOption, string sKU, string productNum )
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            string xmlOut = productHelper.SearchProductsXML(portalId, keywords, delimiter, categoryId, searchOption, sKU, productNum);

            ZNodeProductList pl = new ZNodeProductList();

            //serialize the object
            ZNodeSerializer ser = new ZNodeSerializer();
            pl = (ZNodeProductList)ser.GetContentFromString(xmlOut, typeof(ZNodeProductList));

            return pl ;
        }

    }

}
