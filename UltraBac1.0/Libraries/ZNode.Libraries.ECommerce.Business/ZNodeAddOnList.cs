using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents the properties and methods of a product AddOn.
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeAddOnList : ZNodeBusinessBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ZNodeAddOnList() { }

        /// <summary>
        /// Represents Collection of products
        /// </summary>
        private ZNodeGenericCollection<ZNodeAddOn> _addOnCollection = new ZNodeGenericCollection<ZNodeAddOn>();

        /// <summary>
        /// Collection of products contained within this category
        /// </summary>
        [XmlElement("ZNodeAddOn")]
        public ZNodeGenericCollection<ZNodeAddOn> ZNodeAddOnCollection
        {
            get
            {
                return _addOnCollection;
            }
            set
            {
                _addOnCollection = value;
            }
        }

        /// <summary>
        /// Retrieves the total additional retail price value
        /// </summary>
        public decimal RetailPriceAdditional
        {
            get 
            {  
                decimal price = 0;

                foreach(ZNodeAddOn addOn in _addOnCollection)
                {
                    foreach(ZNodeAddOnValue value in addOn.ZNodeAddOnValueCollection)
                    {
                        price += value.RetailPriceAdditional;
                    }
                }

                return price;
            }
        }

        /// <summary>
        /// Retrieves the  total additional weight value
        /// </summary>
        public decimal WeightAdditional
        {
            get
            {
                decimal weight = 0;

                foreach (ZNodeAddOn addOn in _addOnCollection)
                {
                    foreach (ZNodeAddOnValue value in addOn.ZNodeAddOnValueCollection)
                    {
                        weight += value.WeightAdditional;
                    }
                }

                return weight;
            }
        }
        
        # region Public Methods
        /// <summary>
        /// Returns a AddOn based on the productID and Attributes
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static ZNodeAddOnList CreateByProductAndAddOns(int productId, string addOnvalues)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            string xmlOut = productHelper.GetAddOnByValues(productId, addOnvalues);

            ZNodeAddOnList _addOnList = new ZNodeAddOnList();
            
            //serialize the object
            if (xmlOut.Trim().Length > 0)
            {
                ZNodeSerializer ser = new ZNodeSerializer();
                _addOnList = (ZNodeAddOnList)ser.GetContentFromString(xmlOut, typeof(ZNodeAddOnList));
            }
            return _addOnList;
        }
        #endregion
    }
}
