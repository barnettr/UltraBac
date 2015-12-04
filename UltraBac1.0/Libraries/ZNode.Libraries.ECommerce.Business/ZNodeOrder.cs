using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using System.Data;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using ZNode.Libraries.DataAccess.Service;
using System.Collections;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to manage Orders and OrderLine Items during Checkout
    /// </summary>
    public class ZNodeOrder:ZNodeBusinessBase
    {
        #region Private Variables
		private string _cardNumber = string.Empty;        
        private string _cardExpire = string.Empty;
        private string _cardSecurityCode = string.Empty;
        private Order _order = new Order();
        private Coupon _Coupon = new Coupon();          
        private string _DiscountTarget = string.Empty;
        private string _additionalInstructions = string.Empty;
        int? CouponID = null;        
        private decimal _DiscountAmount = 0;       
        protected ZNodeShoppingCart _shoppingCart = (ZNodeShoppingCart)ZNodeShoppingCart.CreateFromSession(ZNodeSessionKeyType.ShoppingCart);
        public bool IsupdateInventoryInd = true;
        #endregion

        #region Member Variables
        /// <summary>
        /// Represents Collection of OrderLineItems
        /// </summary>
        protected TList<OrderLineItem> _orderLineItems = new TList<OrderLineItem>();        
		#endregion

        #region Public Properties
        /// <summary>
        /// Retrieves the collection of orderline items for this order
        /// </summary>
        public TList<OrderLineItem> OrderLineItems
        {
            get
            {
                return _orderLineItems;
            }
        }        
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ZNodeOrder()
		{
		}

        /// <summary>
        /// Submit order into database
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="shoppingCart"></param>
        /// <param name="portalID"></param>
        public ZNodeOrder(ZNodeUserAccount userAccount, ZNodeShoppingCart shoppingCart, int portalID)
        {
            this.PortalId = portalID;
            this.AccountID = userAccount.AccountID;
            this.TaxCost = shoppingCart.TaxCost;            
            //This property will return the Actual ShippingCost - Discount Amount
            this.ShippingCost = shoppingCart.ShippingDiscount;//Final Shippging cost
            this.SubTotal = shoppingCart.SubTotal;
            this.Total = shoppingCart.Total;            
            this.BillingAddress = userAccount.BillingAddress;
            this.ShippingAddress = userAccount.ShippingAddress;
            ////for Coupon
            this.DiscountAmount = DiscountAmount;
            
            if(shoppingCart.ZNodeCoupon.CouponID > 0 )            
            {
                this.CouponID = shoppingCart.ZNodeCoupon.CouponID;
            }
            else
            {
                this.CouponID = null;
            }

            //loop through cart and add line items
            foreach (ZNodeShoppingCartItem shoppingCartItem in shoppingCart.ShoppingCartItems)
            {
                OrderLineItem orderLineItem = new OrderLineItem();
                orderLineItem.Description = shoppingCartItem.Product.SelectedSKU.AttributesDescription + shoppingCartItem.Product.AddOnDescription;
                orderLineItem.Name = shoppingCartItem.Product.Name;
                orderLineItem.SKU = shoppingCartItem.Product.SKU;
                orderLineItem.Quantity = shoppingCartItem.Quantity;
                orderLineItem.ProductNum = shoppingCartItem.Product.ProductNum;
                orderLineItem.Price = shoppingCartItem.Product.ActualProductPrice;
                orderLineItem.PrePromoPrice = shoppingCartItem.Product.RetailPrice;
                orderLineItem.ParentOrderLineItemID = null;

                _orderLineItems.Add(orderLineItem);
                
            }
        }

		#endregion
		
		#region Public Properties
        /// <summary>
        /// Retrieves or sets the Billing Address object.
        /// </summary>
        public ZNodeAddress BillingAddress
        {
            get
            {
                ZNodeAddress _address = new ZNodeAddress();
                _address.FirstName = _order.BillingFirstName;
                _address.LastName = _order.BillingLastName;
                _address.CompanyName = _order.BillingCompanyName;
                _address.Street1 = _order.BillingStreet;
                _address.Street2 = _order.BillingStreet1;
                _address.City = _order.BillingCity;
                _address.StateCode = _order.BillingStateCode;
                _address.PostalCode = _order.BillingPostalCode;
                _address.CountryCode = _order.BillingCountry;
                _address.PhoneNumber = _order.BillingPhoneNumber;
                _address.EmailId = _order.BillingEmailId;

                return _address;
            }
            set
            {
                ZNodeAddress _address = value;

                _order.BillingFirstName = _address.FirstName;
                _order.BillingLastName = _address.LastName;
                _order.BillingCompanyName = _address.CompanyName;
                _order.BillingStreet = _address.Street1;
                _order.BillingStreet1 = _address.Street2;
                _order.BillingCity = _address.City;
                _order.BillingStateCode = _address.StateCode;
                _order.BillingPostalCode = _address.PostalCode;
                _order.BillingCountry = _address.CountryCode;
                _order.BillingPhoneNumber = _address.PhoneNumber;
                _order.BillingEmailId = _address.EmailId;
            }
        }

        /// <summary>
        /// Gets or sets the Shipping Address object. 
        /// </summary>
        public ZNodeAddress ShippingAddress
        {
            get
            {
                ZNodeAddress _address = new ZNodeAddress();
                _address.FirstName = _order.ShipFirstName;
                _address.LastName = _order.ShipLastName;
                _address.CompanyName = _order.ShipCompanyName;
                _address.Street1 = _order.ShipStreet;
                _address.Street2 = _order.ShipStreet1;
                _address.City = _order.ShipCity;
                _address.StateCode = _order.ShipStateCode;
                _address.PostalCode = _order.ShipPostalCode;
                _address.CountryCode = _order.ShipCountry;
                _address.PhoneNumber = _order.ShipPhoneNumber;
                _address.EmailId = _order.ShipEmailID;

                return _address;
            }
            set
            {
                ZNodeAddress _address = value;

                _order.ShipFirstName = _address.FirstName;
                _order.ShipLastName = _address.LastName;
                _order.ShipCompanyName = _address.CompanyName;
                _order.ShipStreet = _address.Street1;
                _order.ShipStreet1 = _address.Street2;
                _order.ShipCity = _address.City;
                _order.ShipStateCode = _address.StateCode;
                _order.ShipPostalCode = _address.PostalCode;
                _order.ShipCountry = _address.CountryCode;
                _order.ShipPhoneNumber = _address.PhoneNumber;
                _order.ShipEmailID = _address.EmailId;
            }
        }       
        
        /// <summary>
        /// Gets or sets the order id for this case
        /// </summary>
        public int OrderID
        {
            get { return _order.OrderID ; }
            set { _order.OrderID = value; }
        }
        
        /// <summary>
        /// Gets or sets the site portal id
        /// </summary>
        public int PortalId
        {
            get { return (int)_order.PortalId; }
            set { _order.PortalId = value; }
        }       
        
        /// <summary>
        /// Gets or sets the account Id
        /// </summary>   
        public int AccountID
        {
            get { return (int)_order.AccountID; }
            set { _order.AccountID  = value; }
        }       

        /// <summary>
        /// Gets or sets the status for this order
        /// </summary>
        public int OrderStateID
        {
            get { return (int)_order.OrderStateID; }
            set { _order.OrderStateID  = value; }
        }

        /// <summary>
        /// Gets or sets the shipping type for this order
        /// </summary>
        public int ShippingID
        {
            get { return (int)_order.ShippingID; }
            set { _order.ShippingID = value; }
        }

        /// <summary>
        /// Gets or sets the payment type for this order
        /// </summary>
        public int PaymentTypeId
        {
            get { return (int)_order.PaymentTypeId; }
            set { _order.PaymentTypeId = value; }
        }

        /// <summary>
        /// Gets or sets the transaction id for this order
        /// </summary>
        public string CardTransactionID
        {
            get { return _order.CardTransactionID; }
            set { _order.CardTransactionID  = value; }
        }

        /// <summary>
        /// Gets or sets the type of the card
        /// </summary>
        public int CardTypeId
        {
            get { return (int)_order.CardTypeId; }
            set { _order.CardTypeId = value; }
        }

        /// <summary>
        /// Gets or sets the credit card expiration date
        /// </summary>
        public string CardEndsIn
        {
            get { return _order.CardEndsIn ; }
            set { _order.CardEndsIn = value; }
        }

        /// <summary>
        /// Gets or sets the tax cost for this order
        /// </summary>
        public decimal TaxCost
        {
            get { return (decimal)_order.TaxCost ; }
            set { _order.TaxCost = value; }
        }

        /// <summary>
        /// Gets or sets the shipping cost for this order
        /// </summary>
        public decimal ShippingCost
        {
            get { return (decimal)_order.ShippingCost; }
            set { _order.ShippingCost = value; }
        }

        /// <summary>
        /// Gets or sets the sub-total amount for this order
        /// </summary>
        public decimal SubTotal
        {
            get { return (decimal)_order.SubTotal; }
            set { _order.SubTotal = value; }
        }

        /// <summary>
        /// Gets or sets the total amount for this order
        /// </summary>
        public decimal Total
        {
            get { return (decimal)_order.Total; }
            set { _order.Total  = value; }
        }

        /// <summary>
        /// Gets or sets the ordered date
        /// </summary>
        public DateTime OrderDate
        {
            get { return (DateTime)_order.OrderDate ; }
            set { _order.OrderDate  = value; }
        }
        /// <summary>
        /// Gets or sets the Credit card Number  
        /// </summary>
        public string CreditCardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }
        /// <summary>
        /// Gets or sets the Credit card expiration date
        /// </summary>
        public string CreditCardExp
        {
            get { return _cardExpire; }
            set { _cardExpire = value; }
        }      
        /// <summary>
        /// Gets or sets the Credit card Security code
        /// </summary>
        public string CreditCardCVV
        {
            get { return _cardSecurityCode; }
            set { _cardSecurityCode = value; }
        }
        /// <summary>
        ///  Gets or sets the coupon discount amount for this order
        /// </summary>
        public decimal DiscountAmount
        {
            get { return Discount; }
            set {_DiscountAmount = value; }
        }
        /// <summary>
        ///  Retrieves the coupon discount for this order
        /// </summary>
        public decimal Discount
        {
            get
            {
                decimal disc = 0;
                disc = _shoppingCart.OrderDiscount;        
                return disc;
            }
        }

        /// <summary>
        ///  Gets or sets the Additional customer Instructions for this order
        /// </summary>
        public string AdditionalInstructions
        {
            get { return _additionalInstructions; }
            set { _additionalInstructions = value; }
        }
		#endregion

        #region Public Methods

        /// <summary>
        /// Submits order to database
        /// </summary>
        public void SubmitOrder(ZNodeOrderState orderState)
        {
            //set order state
            _order.OrderStateID = (int)orderState;

            //set order date and status
            _order.OrderDate = System.DateTime.Now;


            //Coupon
            _order.DiscountAmount = DiscountAmount;
            _order.CouponID = CouponID;
            
            //set Credit Crad Info
            _order.CreditCardNumber = _cardNumber;
            _order.CreditCardExp = _cardExpire;
            _order.CreditCardCVV = _cardSecurityCode;

            //General Setings
            _order.AdditionalInstructions = _additionalInstructions;

            //insert order into database
            OrderService orderServ = new OrderService();
            orderServ.Insert(_order);

            //get new orderid
            int orderID = _order.OrderID;

            //set orderids for line items
            foreach (OrderLineItem orderLineItem in _orderLineItems)
            {
                orderLineItem.OrderID = orderID;
            }

            //add orderline items to database
            OrderLineItemService orderLineItemServ = new OrderLineItemService();
            
            int Counter = 0;

            //Loop through the Order Line Items
            foreach (OrderLineItem orderLineItem in _orderLineItems)
            {
                //Insert parent Order Line Item to the database
                orderLineItemServ.Insert(orderLineItem);

                ZNodeShoppingCartItem shoppingCartItem = _shoppingCart.ShoppingCartItems[Counter++];
                
                //Loop through the Selected addons for each Shopping cartItem
                foreach (ZNodeAddOn AddOn in shoppingCartItem.Product.SelectedAddOnItems.ZNodeAddOnCollection)
                {
                    foreach (ZNodeAddOnValue AddOnValue in AddOn.ZNodeAddOnValueCollection)//Add-On value collection
                    {
                        OrderLineItem AddOnorderLineItem = new OrderLineItem();

                        AddOnorderLineItem.Description = AddOnValue.Name;
                        AddOnorderLineItem.Name = AddOn.Name;
                        AddOnorderLineItem.SKU = AddOnValue.SKU;
                        AddOnorderLineItem.Quantity = shoppingCartItem.Quantity;
                        AddOnorderLineItem.ProductNum = AddOn.Title;
                        AddOnorderLineItem.Price = AddOnValue.RetailPriceAdditional;
                        AddOnorderLineItem.PrePromoPrice = 0;
                        //Set new ParentOrderLineItemId to this item
                        AddOnorderLineItem.ParentOrderLineItemID = orderLineItem.OrderLineItemID;
                        AddOnorderLineItem.OrderID = orderLineItem.OrderID; //Set new OrderId to this Item

                        //Insert Product Addons to the OrderLineItem table
                        orderLineItemServ.Insert(AddOnorderLineItem);

                        if (IsupdateInventoryInd)
                        {
                            //Update stock available for each product addon
                            UpdateInventory(AddOn, AddOnValue, shoppingCartItem.Quantity);
                        }
                    }
                }                
              }
        }

        /// <summary>
        /// Updates Order Status
        /// </summary>
        /// <param name="orderState"></param>
        public void UpdateOrderStatus(ZNodeOrderState orderState)
        {
            _order.OrderStateID = (int)orderState;

            OrderService orderServ = new OrderService();
            orderServ.Update(_order);
        }

        /// <summary>
        /// Add an order line item to the collection
        /// </summary>
        public void AddOrderLineItem(OrderLineItem orderLineItem)
        {
            _orderLineItems.Add(orderLineItem);
        }

        #endregion

        # region Helper Methods
        /// <summary>
        /// Reduce the Product add-ons quantityAvailable by 1 ,if the order is placed successfully
        /// </summary>
        /// <param name="AddOn"></param>
        /// <param name="value"></param>
        private void UpdateInventory(ZNodeAddOn AddOn,ZNodeAddOnValue AddOnValue,int Quantity)
        {
            //AddOnValueService AddOnValueServ = new AddOnValueService();

            //if (AddOn.TrackInventoryInd)
            //{
            //    AddOnValue value = AddOnValueServ.GetByAddOnValueID(AddOnValue.AddOnValueID);
            //    value.QuantityOnHand = value.QuantityOnHand - Quantity;

            //    //Update AddOn value to the database
            //    AddOnValueServ.Update(value);
            //}
        }
        # endregion
    }
}
