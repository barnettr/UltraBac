using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;
using System.Web;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents Shopping cart and shopping cart items
    /// </summary>
    public class ZNodeShoppingCart : ZNodeBusinessBase
    {
        #region Member Variables
        private decimal _taxRate = 0;        
        private ZNodePromotion _promotion = new ZNodePromotion();
        private ZNodeGenericCollection<ZNodeShoppingCartItem> _shoppingCartItems = new ZNodeGenericCollection<ZNodeShoppingCartItem>();
        private string _paymentName = string.Empty;
        private string _shippingName = string.Empty;
        private int _shippingID;
        private decimal _shippingHandlingCharge = 0;       
        private ZNodeCoupon _Coupon = new ZNodeCoupon();        
        private ZNodeProduct _Product = new ZNodeProduct();
        private ZNodeOrder _Order = new ZNodeOrder();
        private ZNodeShoppingCartItem _ShoppingCartItem = new ZNodeShoppingCartItem();                      
        DateTime currentdate = System.DateTime.Now.Date;
        private ZNodeAddress _billingAdress = new ZNodeAddress();
        private ZNodeAddress _shippingAddress = new ZNodeAddress();
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ZNodeShoppingCart()
        {
        }
        #endregion        

        # region Public Instance Properties
        /// <summary>
        /// Retrieves Customer billing address
        /// </summary>
        public ZNodeAddress BillingAddress
        {
            get 
            {
                _billingAdress = _Order.BillingAddress;
                return _billingAdress;
            }
            
        }
        /// <summary>
        /// Retrieves Customer billing address
        /// </summary>
        public ZNodeAddress ShippingAddress
        {
            get
            {
                ZNodeUserAccount _account = (ZNodeUserAccount)CreateFromSession(ZNodeSessionKeyType.UserAccount);
                _shippingAddress = _account.ShippingAddress;

                return _shippingAddress;
            }            
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a collection of shopping cart items
        /// </summary>
        public ZNodeGenericCollection<ZNodeShoppingCartItem> ShoppingCartItems
        {
            get
            {
                return _shoppingCartItems;
            }
            set
            {
               _shoppingCartItems = value;
            }
        }

        /// <summary>
        /// Gets or sets a 
        /// </summary>
        public ZNodeCoupon ZNodeCoupon
        {

            get
            {
                return _Coupon;
            }
            set
            {
                _Coupon = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the ZNodeShoppingCartItem object
        /// </summary>
        public ZNodeShoppingCartItem ZNodeShoppingCartItem
        {

            get
            {
                return _ShoppingCartItem;
            }
            set
            {
               _ShoppingCartItem = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the ZNodeProduct object
        /// </summary>
        public ZNodeProduct ZNodeProduct
        {

            get
            {
                return _Product;
            }
            set
            {
                _Product = value;
            }
        }
     
        /// <summary>
        /// Returns the discount Shipping cost 
        /// </summary>
        public decimal ShippingDiscount
        {
            get 
            { 
                decimal calc = 0;
                decimal shipCost = 0;
                if (_Coupon.OrderMinimum >= 0 && currentdate >= _Coupon.StartDate && currentdate <= _Coupon.ExpDate && _Coupon.QuantityAvailable > 0 && SubTotal > OrderDiscount)
                {
                    if(_Coupon.DiscountTargetID == 2)                    
                    {
                        if ( _Coupon.DiscountTypeID == 2)
                        {
                            shipCost += _Coupon.Discount - _Order.ShippingCost; 
                        }
                        else
                        {
                            shipCost += _Coupon.Discount / 100;
                        }
                    }
                }
                else if (_Coupon.DiscountTargetID == 1 || _Coupon.DiscountTypeID == 2 || _Coupon.DiscountTypeID == 1 || currentdate <= _Coupon.StartDate || currentdate >= _Coupon.ExpDate || _Coupon.QuantityAvailable < 0 || SubTotal < OrderDiscount)
                {
                    return ShippingCost;//_shippingHandlingCharge;
                }
                else
                {
                    return 0;
                }
                if (_Coupon.DiscountTargetID == 2 && _Coupon.DiscountTypeID == 1)
                {
                    calc = ShippingCost * shipCost;
                    return ShippingCost - calc;
                }
                else
                {
                    return ShippingCost - shipCost;
                }          
            }
        }

        /// <summary>
        /// Returns the Shipping cost which includes shipping rules amount
        /// </summary>
        public decimal ShippingCost
        {
            get
            {
                decimal subTotal = 0;

                foreach (ZNodeShoppingCartItem item in _shoppingCartItems)
                {
                    subTotal += item.ShippingCost;
                }

                return subTotal + _shippingHandlingCharge;
            }
        }      

        /// <summary>
        /// Handling Charge for Shipping
        /// </summary>
        public decimal ShippingHandlingCharge
        {
            get { return _shippingHandlingCharge; }
            set {_shippingHandlingCharge = value;}
        }
        
        /// <summary>
        /// Represents the sales tax
        /// </summary>
        public decimal TaxCost
        {
            get 
            {                    
                return (SubTotal - OrderDiscount) * TaxRate /100 ;    
            }
        }

        /// <summary>
        /// Sales tax rate (%)
        /// </summary>
        public decimal TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// <summary>
        /// Promotions
        /// </summary>
        public ZNodePromotion Promotion
        {
            get { return _promotion ; }
            set { _promotion = value; }
        }   

        /// <summary>
        /// Calculating the Discount Amount for the discount target order
        /// <summary>
        public decimal OrderDiscount
        {
            get
            {
                decimal discAmount = 0;

                if (_Coupon.OrderMinimum < SubTotal)
                {
                    if (_Coupon.DiscountTargetID == 1)
                    {
                        if (_Coupon.DiscountTypeID == 2)
                        {
                            discAmount = _Coupon.Discount;
                        }
                        else
                        {
                            discAmount = SubTotal * _Coupon.Discount / 100;
                        }
                    }
                    else
                    {
                        return 0;
                    }                    
                }
                else if ( _Coupon.OrderMinimum >= 0 && currentdate >= _Coupon.StartDate && currentdate <= _Coupon.ExpDate && _Coupon.QuantityAvailable > 0 && SubTotal >= OrderDiscount)
                {
                    if (_Coupon.DiscountTargetID == 1)
                    {
                        if (_Coupon.DiscountTypeID == 2)
                        {
                            discAmount = _Coupon.Discount;
                        }
                        else
                        {
                            discAmount = SubTotal * _Coupon.Discount / 100;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }                
                return discAmount;
            }
        }     
     
        /// <summary>
        /// Returns count of items in the shopping cart
        /// </summary>
        public int Count
        {
            get
            {
                return _shoppingCartItems.Count;
            }
        }

        /// <summary>
        /// Returns total cost of items in the shopping cart before shipping and taxes
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                decimal subTotal = 0;

                foreach (ZNodeShoppingCartItem item in _shoppingCartItems)
                {
                    decimal itemTotal = item.Quantity * item.Product.FinalPrice;
                    subTotal += itemTotal;
                }

                return subTotal;
            }
        }
        
        /// <summary>
        /// Total cost after shipping, taxes and promotions
        /// </summary>        
        public decimal Total
        {
            get
            {
                decimal tempCalc = 0;
                tempCalc = SubTotal + TaxCost + ShippingDiscount - OrderDiscount;              
                return tempCalc; 
            }
        }

        /// <summary>
        /// Shipping Option Name
        /// </summary>
        public string ShippingName
        {
            get
            {
                return _shippingName;
            }
            set
            {
                _shippingName = value;
            }
        }

        /// <summary>
        /// Payment Option Name
        /// </summary>
        public string PaymentName
        {
            get
            {
                return _paymentName;
            }
            set
            {
                _paymentName = value;
            }
        }

        /// <summary>
        /// Shipping Option ID
        /// </summary>
        public int ShippingID
        {
            get
            {
                return _shippingID ;
            }
            set
            {
                _shippingID = value;
            }
        }        
        #endregion

        #region Public Methods

        /// <summary>
        /// Returns Total Qunatity ordered for each Shopping cart Item
        /// </summary>
        /// <param name="ShoppingCartItem"></param>
        /// <returns></returns>
        public int GetQuantityOrdered(ZNodeShoppingCartItem ShoppingCartItem)
        {
            int QuantityOrdered = 0;

            //loop through Shopping cart items
            foreach (ZNodeShoppingCartItem item in _shoppingCartItems)
            {
                if (item.Product.ProductID == ShoppingCartItem.Product.ProductID)
                {
                    //Check Product has any attributes
                    if (item.Product.ZNodeAttributeTypeCollection.Count > 0)
                    {
                        if (item.Product.SelectedSKU.SKUID == ShoppingCartItem.Product.SelectedSKU.SKUID)
                        {
                            if (item.GUID != ShoppingCartItem.GUID)
                                QuantityOrdered += item.Quantity;
                        }
                    }
                    else
                    {
                        if (item.GUID != ShoppingCartItem.GUID)
                            QuantityOrdered += item.Quantity;
                    }
                }

            }
            return QuantityOrdered;

        }

        /// <summary>
        /// Adds an item to the shopping cart
        /// </summary>
        /// <param name="ShoppingCartItem"></param>
        /// <returns>Boolean</returns>
        public bool AddToCart(ZNodeShoppingCartItem ShoppingCartItem)
        {
            int QuantityOrdered = GetQuantityOrdered(ShoppingCartItem);

            if (QuantityOrdered < ShoppingCartItem.Product.QuantityOnHand)
            {
                _shoppingCartItems.Add(ShoppingCartItem);
                return true;
            }
            else
            {                
                //If AllowBack Order is enabled ,then it will add this product into cart
                if (ShoppingCartItem.Product.AllowBackOrder)
                {
                    _shoppingCartItems.Add(ShoppingCartItem);
                    return true;
                }
                //TrackInventory is disabled ,then it will add this product into cart
                else if (ShoppingCartItem.Product.TrackInventoryInd == false)
                {
                    _shoppingCartItems.Add(ShoppingCartItem);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Removes an item from the shopping cart
        /// </summary>
        /// <param name="ShoppingCartItem"></param>
        public void RemoveFromCart(string GUID)
        {
            //first locate the item in the collection
            ZNodeShoppingCartItem itemToRemove = GetItem(GUID);

            if (itemToRemove != null)
            {
                _shoppingCartItems.Remove(itemToRemove);
            }
        }

        /// <summary>
        /// Empty the shopping cart
        /// </summary>
        public void EmptyCart()
        {
            _shoppingCartItems.Clear();
        }

        /// <summary>
        /// Locates a shopping cart item by it's GUID
        /// </summary>
        /// <param name="GUID"></param>
        /// <returns></returns>
        public ZNodeShoppingCartItem GetItem(string GUID)
        {
            foreach (ZNodeShoppingCartItem item in _shoppingCartItems)
            {
                if (item.GUID.Equals(GUID))
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Updates a specific shopping cart item
        /// </summary>
        /// <param name="GUID"></param>
        /// <param name="UpdatedItem"></param>
        public void UpdateItemQuantity(string GUID, int UpdatedQuantity)
        {
            //first locate the item in the collection
            ZNodeShoppingCartItem itemToUpdate = GetItem(GUID);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = UpdatedQuantity;
            }
        }
  #endregion

        #region static methods
        /// <summary>
        /// Returns the current shopping cart
        /// </summary>
        /// <returns></returns>
        public static ZNodeShoppingCart CurrentShoppingCart()
        {
            ZNodeShoppingCart shoppingCart;

            //get the user account from session
            shoppingCart = (ZNodeShoppingCart)HttpContext.Current.Session[ZNodeSessionKeyType.ShoppingCart.ToString()];

            if (shoppingCart == null) //not in session
            {
                return null;
            }
            else //return the value from session
            {
                return shoppingCart;
            }
        }

        /// <summary>
        /// Represents the current session key count
        /// </summary>
        public void Test()
        {
            HttpContext.Current.Response.Write(HttpContext.Current.Session.Keys.Count.ToString());
        }   

        #endregion
    }
}
