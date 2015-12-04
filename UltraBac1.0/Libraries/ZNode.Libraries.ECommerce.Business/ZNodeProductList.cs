using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods for list of home specials products and collection of products for a category
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeProductList:ZNodeBusinessBase 
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ZNodeProductList() { }

        /// <summary>
        /// Represents Collection of products
        /// </summary>
        private ZNodeGenericCollection<ZNodeProduct> _productCollection = new ZNodeGenericCollection<ZNodeProduct>();

        /// <summary>
        /// Collection of products contained within this category
        /// </summary>
        [XmlElement("ZNodeProduct")]
        public ZNodeGenericCollection<ZNodeProduct> ZNodeProductCollection
        {
            get
            {
                return _productCollection;
            }
            set
            {
                _productCollection = value;
            }
        }

        /// <summary>
        /// Returns a product list of home page specials
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public static ZNodeProductList GetHomePageSpecials(int portalId)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            StringBuilder xmlOut = new StringBuilder();
            xmlOut.Append("<ZNodeProductList>");
            xmlOut.Append(productHelper.GetHomePageSpecialsXML(portalId));
            xmlOut.Append("</ZNodeProductList>");                            

            //serialize the object
            ZNodeSerializer ser = new ZNodeSerializer();
            return (ZNodeProductList)ser.GetContentFromString(xmlOut.ToString(), typeof(ZNodeProductList));
        }

        /// <summary>
        /// Returns a product list for a brand
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public static ZNodeProductList GetProductsByBrand(int portalId, int manufacturerId)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            StringBuilder xmlOut = new StringBuilder();
            xmlOut.Append("<ZNodeProductList>");
            xmlOut.Append(productHelper.GetProductsByBrandXML(portalId,manufacturerId));
            xmlOut.Append("</ZNodeProductList>");

            //serialize the object
            ZNodeSerializer ser = new ZNodeSerializer();
            return (ZNodeProductList)ser.GetContentFromString(xmlOut.ToString(), typeof(ZNodeProductList));
        }

        /// <summary>
        /// Returns a product list for a price filter
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public static ZNodeProductList GetProductsByPrice(int portalId, decimal StartValue,decimal EndValue)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            StringBuilder xmlOut = new StringBuilder();
            xmlOut.Append("<ZNodeProductList>");
            xmlOut.Append(productHelper.GetProductsByPriceXML(portalId, StartValue,EndValue));
            xmlOut.Append("</ZNodeProductList>");

            //serialize the object
            ZNodeSerializer ser = new ZNodeSerializer();
            return (ZNodeProductList)ser.GetContentFromString(xmlOut.ToString(), typeof(ZNodeProductList));
        }

    }
}
