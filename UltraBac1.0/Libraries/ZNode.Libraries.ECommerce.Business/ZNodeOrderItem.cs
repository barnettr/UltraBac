using System;
using System.Collections.Generic;
using System.Text;

namespace ZNode.Libraries.ECommerce.Business
{
    public class ZNodeOrderItem
    {
        #region Protected Properties
        protected int _portalID;
        protected int _orderLineItemID;
        protected int _sKUID;
        protected int _orderID;
        protected int _shipmentID;
        protected string _productNum = String.Empty;
        protected string _name = String.Empty;
        protected string _description = String.Empty;
        protected int _quantity;
        protected decimal _price;
        protected decimal _prePromoPrice;
        #endregion

        #region Constructor
        public ZNodeOrderItem()
        {
        }
        #endregion

        #region Public Properties
        public int PortalID
        {
            get { return _portalID; }
            set { _portalID = value; }
        }

        public int OrderLineItemID
        {
            get { return _orderLineItemID; }
            set { _orderLineItemID = value; }
        }

        public int SKUID
        {
            get { return _sKUID; }
            set { _sKUID = value; }
        }

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public int ShipmentID
        {
            get { return _shipmentID; }
            set { _shipmentID = value; }
        }

        public string ProductNum
        {
            get { return _productNum; }
            set { _productNum = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public decimal PrePromoPrice
        {
            get { return _prePromoPrice; }
            set { _prePromoPrice = value; }
        }
        #endregion
    }
}
