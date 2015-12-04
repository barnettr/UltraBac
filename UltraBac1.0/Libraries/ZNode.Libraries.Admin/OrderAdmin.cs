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
    /// This Class Manages the Related to the Order,OrderState,OrderLineItem.
    /// </summary>
    public class OrderAdmin:ZNodeBusinessBase 
    {
        # region Order Public Methods

        /// <summary>
        /// Returns all the Order for a Portal
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.Order> GetAllOrders(int portalID)
        {
            ZNode.Libraries.DataAccess.Service.OrderService _OrderService = new OrderService();
            TList<ZNode.Libraries.DataAccess.Entities.Order> OrderList = _OrderService.GetByPortalId(portalID);

            return OrderList;
        }

        /// <summary>
        ///  Get Order for a Order ID
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public Order GetOrderByOrderID(int OrderID)
        {
            ZNode.Libraries.DataAccess.Service.OrderService _OrderService = new OrderService();
            Order OrderList = _OrderService.GetByOrderID(OrderID);

            return OrderList;

        }

        /// <summary>
        /// Returns order for a Account
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public TList<Order> GetByAccountID(int accountID)
        {
            ZNode.Libraries.DataAccess.Service.OrderService _OrderService = new OrderService();
                        
            TList<ZNode.Libraries.DataAccess.Entities.Order> OrderList = _OrderService.GetByAccountID(accountID);                    

            return OrderList;

        }

        /// <summary>
        /// Returns order for a Account and Portal
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public DataSet GetByAccountID(int accountID,int portalID)
        {

            OrderHelper _OrderHelper = new OrderHelper();

            DataSet MyDataSet = _OrderHelper.GetByAccountID(accountID, portalID);

            return MyDataSet;
        }

        /// <summary>
        /// Returns Orders for a given Info
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="billingfirstname"></param>
        /// <param name="billinglastname"></param>
        /// <param name="billingcompanyname"></param>
        /// <param name="accountid"></param>        
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="orderstateID"></param>
        /// <param name="portalID"></param>
        /// <returns></returns>       
        public DataSet FindOrders(string orderid, string billingfirstname, string billinglastname, string billingcompanyname, string accountid, string startdate, string enddate, int orderstateid, int portalid)
        {
            OrderHelper _Orderhelper = new OrderHelper();
            DataSet MyDataSet = _Orderhelper.SearchOrder(orderid, billingfirstname, billinglastname, billingcompanyname, accountid, startdate, enddate, orderstateid, portalid);

            return MyDataSet;
        }

        /// <summary>
        /// Returns OrderLineItems for orders
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="billingfirstname"></param>
        /// <param name="billinglastname"></param>
        /// <param name="billingcompanyname"></param>
        /// <param name="accountid"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="orderstateID"></param>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public DataSet GetOrderLineItems(string orderid, string billingfirstname, string billinglastname, string billingcompanyname, string accountid, string startdate, string enddate, int orderstateID, int portalID)
        {
            OrderHelper _Orderhelper = new OrderHelper();
            DataSet MyDataSet = _Orderhelper.GetOrderLineItems(orderid,billingfirstname,billinglastname,billingcompanyname,accountid ,startdate, enddate, orderstateID, portalID);
            //Return DataSet
            return MyDataSet;
        }

        /// <summary>
        /// Update Order Status
        /// </summary>
        /// <param name="_Order"></param>
        /// <returns></returns>
        public bool Update(Order _Order)
        {
            ZNode.Libraries.DataAccess.Service.OrderService _OrderService = new OrderService();

            bool Status = _OrderService.Update(_Order);

            return Status;
        }

        /// <summary>
        /// Delete Order by Id
        /// </summary>
        /// <param name="_Order"></param>
        /// <returns></returns>
        public bool Delete(int orderID)
        {
            ZNode.Libraries.DataAccess.Service.OrderService _OrderService = new OrderService();

            bool Status = _OrderService.Delete(orderID);

            return Status;
        }

       # endregion

        # region OrderLineItem Public Methods

        /// <summary>
        /// Returns order line items for a orderid
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.OrderLineItem> GetOrderLineItemByOrderID(int OrderID)
        {
            ZNode.Libraries.DataAccess.Service.OrderLineItemService _OrderLineItemServ = new OrderLineItemService();
            TList<OrderLineItem> _orderLineItems = _OrderLineItemServ.GetByOrderID(OrderID);

            return _orderLineItems;
        }

        public void DeleteByOrderId(int orderID)
        {
            TList<ZNode.Libraries.DataAccess.Entities.OrderLineItem> entityCollection = this.GetOrderLineItemByOrderID(orderID);
            ZNode.Libraries.DataAccess.Service.OrderLineItemService _OrderLineItemServ = new OrderLineItemService();

            if (entityCollection.Count > 0)
            {
                OrderLineItem LineItem = entityCollection[0];

                entityCollection.Remove(LineItem);

                //Remove Addon Order Line Item first
                _OrderLineItemServ.Delete(entityCollection);
                //Then Remove Parent/product OrderLine item
                _OrderLineItemServ.Delete(LineItem);
            }
        }
        # endregion

        # region OrderState Public Methods

        /// <summary>
        /// Get All OrderState
        /// </summary>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.OrderState> GetAllOrderState()
        {

            ZNode.Libraries.DataAccess.Service.OrderStateService _orderStateService = new OrderStateService();

            TList<ZNode.Libraries.DataAccess.Entities.OrderState> _OrderStateList = _orderStateService.GetAll();

            return _OrderStateList;

        }

        /// <summary>
        ///  Returns a orderstate for a orderstateid
        /// </summary>
        /// <returns></returns>
        public OrderState GetByOrderStateID(int OrderStateID)
        {

            ZNode.Libraries.DataAccess.Service.OrderStateService _orderStateService = new OrderStateService();

            OrderState _OrderState = _orderStateService.GetByOrderStateID(OrderStateID);

            return _OrderState;

        }

        # endregion
    }
}
