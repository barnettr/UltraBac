using System;
using System.Collections.Generic;
using System.Text;

namespace ZNode.Libraries.Integrator
{
    /// <summary>
    /// This class contains methods that creates an object 
    /// identifying the items in the customer's shopping cart
    /// </summary>
    public class ShoppingCartItem
    {
        # region Public Member Variables
        System.Collections.ArrayList _cartItems = new System.Collections.ArrayList();
        /// <remarks/>
        //item-name"
        public string itemname;

        /// <remarks/>
        //item-description
        public string itemdescription;

        /// <remarks/>
        //"unit-price"
        public decimal unitprice;

        /// <remarks/>
        public int quantity;

        /// <remarks/>
        //"merchant-item-id"
        public int ItemId;

        /// <remarks />
        /// "Merchant item private data - You can store Product SKU,etc.
        public System.Xml.XmlNodeList ItemPrivateData = null;
        
        # endregion
        
        # region Public Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ShoppingCartItem()
        {
            _cartItems = new System.Collections.ArrayList();
        }

        public ShoppingCartItem(string Name, string Description,int ProductId, decimal Price, int Quantity,System.Xml.XmlNodeList PrivateDataList)
        {
            itemname = Name;
            itemdescription = Description;
            quantity = Quantity;
            unitprice = Price;
            ItemId = ProductId;
            ItemPrivateData = PrivateDataList;
        }
        #endregion

        # region Public Properties
        /// <summary>
        /// Returns number of items in the collection
        /// </summary>
        public int Count
        {
            get { return _cartItems.Count; }
        }        
        #endregion

        # region Public Instance Methods
        /// <summary>
        /// This method adds an item to an order. This method handles items that 
        /// do not have &lt;merchant-private-item-data&gt; XML blocks associated 
        /// with them.
        /// </summary>       
        public void AddItem(string Name, string Description, decimal Price,int ProductId, int Quantity,System.Xml.XmlNodeList NodeList)
        {
            _cartItems.Add(new ShoppingCartItem(Name,Description,ProductId,Price,Quantity,NodeList));
        }

        /// <summary>
        /// This method returns an particular item for given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ShoppingCartItem GetItem(int index)
        {
            return (ShoppingCartItem)_cartItems[index];
        }
        #endregion
        
    }
}
