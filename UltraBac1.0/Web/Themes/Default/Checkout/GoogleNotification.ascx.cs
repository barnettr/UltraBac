using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using System.Data.SqlClient;
using System.Net.Mail;
using ZNode.Libraries.ECommerce.Business;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

public partial class Themes_Default_Checkout_GoogleNotification : System.Web.UI.UserControl
{
    ZNodeShoppingCart _shoppingCart = new ZNodeShoppingCart();
    ZNodeCheckout _checkout = new ZNodeCheckout();
    # region Page Load Event

    /// <summary>
    /// Page Load Event
    /// This will read the Response from  Google API notifications
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Extract the XML from the request.
        Stream RequestStream = Request.InputStream;
        StreamReader RequestStreamReader = new StreamReader(RequestStream);
        string RequestXml = RequestStreamReader.ReadToEnd();
        RequestStream.Close();

        //serialize the object
        ZNodeSerializer ser = new ZNodeSerializer();

        // Act on the XML.
        switch (GetTopElement(RequestXml))
        {
            case "new-order-notification":
                Google.NewOrderNotification N1 = (Google.NewOrderNotification)ser.GetContentFromString(RequestXml, typeof(Google.NewOrderNotification));
                string OrderNumber1 = N1.googleordernumber;
                string ShipToName = N1.buyershippingaddress.contactname;
                string ShipToAddress1 = N1.buyershippingaddress.address1;
                string ShipToAddress2 = N1.buyershippingaddress.address2;
                string ShipToCity = N1.buyershippingaddress.city;
                string ShipToState = N1.buyershippingaddress.region;
                string ShipToZip = N1.buyershippingaddress.postalcode;

                ZNodeSKU SKU = new ZNodeSKU();
                _shoppingCart = new ZNodeShoppingCart();

                try
                {
                    Google.NewOrderNotification Callback = N1;

                    ZNodeOrder order = new ZNodeOrder();

                    XmlNodeList _MerchantPrivateDataNodes = null;

                    if (Callback.shoppingcart.merchantprivatedata != null &&
                        Callback.shoppingcart.merchantprivatedata != null)
                    {

                        _MerchantPrivateDataNodes = Callback.shoppingcart.merchantprivatedata.ChildNodes;
                    }

                    string merchantPrivateData = _MerchantPrivateDataNodes[2].InnerText;

                    string[] Split = merchantPrivateData.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                    OrderAdmin AdminAccess = new OrderAdmin();
                    Order orderEntity = AdminAccess.GetOrderByOrderID(int.Parse(Split[0]));

                    if (orderEntity != null)
                    {
                        if (orderEntity.CardTransactionID.Length == 0)
                        {
                            orderEntity.CardTransactionID = N1.googleordernumber;
                            AdminAccess.Update(orderEntity);

                            //Decrement inventory level according to the AddOn Inventory settings
                            UpdateValues(N1);
                        }

                        //If Order State is in "Pending Payment", then Charge the amount
                        if (orderEntity.OrderStateID == (int)ZNodeOrderState.PendingPayment)
                        {
                            //Set Properties
                            order.OrderID = orderEntity.OrderID;
                            order.Total = orderEntity.Total.Value;
                            order.PaymentTypeId = orderEntity.PaymentTypeId.Value;
                            order.ShippingID = orderEntity.ShippingID.Value;
                            order.CardTransactionID = orderEntity.CardTransactionID;

                            //Charge Order - non Critical
                            _checkout = new ZNodeCheckout();

                            _checkout.PaymentType = PaymentTypeList.Google_Checkout;
                            bool status = _checkout.DOGoogleExpressCheckout(order);

                            //Update the database - Set order state as "Submitted"
                            if (status)
                            {
                                orderEntity.OrderStateID = (int)ZNodeOrderState.Submitted;
                                AdminAccess.Update(orderEntity);
                            }
                        }
                    }
                }
                catch (ZNodePaymentException)
                {

                }

                break;
            case "risk-information-notification":
                Google.RiskInformationNotification N2 = (Google.RiskInformationNotification)ser.GetContentFromString(RequestXml, typeof(Google.RiskInformationNotification));
                // This notification tells us that Google has authorized the order and it has passed the fraud check.
                // Use the data below to determine if you want to accept the order, then start processing it.
                string OrderNumber2 = N2.googleordernumber;
                string AVS = N2.riskinformation.avsresponse;
                string CVN = N2.riskinformation.cvnresponse;
                bool SellerProtection = N2.riskinformation.eligibleforprotection;
                break;
            case "order-state-change-notification":
                Google.OrderStateChangeNotification N3 = (Google.OrderStateChangeNotification)ser.GetContentFromString(RequestXml, typeof(Google.OrderStateChangeNotification));
                // The order has changed either financial or fulfillment state in Google's system.
                string OrderNumber3 = N3.googleordernumber;
                string NewFinanceState = N3.newfinancialorderstate.ToString();
                string NewFulfillmentState = N3.newfulfillmentorderstate.ToString();
                string PrevFinanceState = N3.previousfinancialorderstate.ToString();
                string PrevFulfillmentState = N3.previousfulfillmentorderstate.ToString();
                break;
            case "charge-amount-notification":
                Google.ChargeAmountNotification N4 = (Google.ChargeAmountNotification)ser.GetContentFromString(RequestXml, typeof(Google.ChargeAmountNotification));
                // Google has successfully charged the customer's credit card.
                string OrderNumber4 = N4.googleordernumber;
                decimal ChargedAmount = N4.latestchargeamount.Value;
                break;
            case "refund-amount-notification":
                Google.RefundAmountNotification N5 = (Google.RefundAmountNotification)ser.GetContentFromString(RequestXml, typeof(Google.RefundAmountNotification));
                // Google has successfully refunded the customer's credit card.
                string OrderNumber5 = N5.googleordernumber;
                decimal RefundedAmount = N5.latestrefundamount.Value;
                break;
            case "chargeback-amount-notification":
                Google.ChargebackAmountNotification N6 = (Google.ChargebackAmountNotification)ser.GetContentFromString(RequestXml, typeof(Google.ChargebackAmountNotification));
                // A customer initiated a chargeback with his credit card company to get her money back.
                string OrderNumber6 = N6.googleordernumber;
                decimal ChargebackAmount = N6.latestchargebackamount.Value;
                break;
            default:
                break;
        }
    }

    #endregion

    # region Helper Methods
    /// <summary>
    /// This method will create objects for ZnodeProduct,ZNodeSKu & ZnodeAddOn with the merchant private data info
    /// Using that object we are updating the inventory level
    /// </summary>
    /// <param name="N1"></param>
    private void UpdateValues(Google.NewOrderNotification N1)
    {
        ZNodeSKU SKU = new ZNodeSKU();

        foreach (Google.Item thisItem in N1.shoppingcart.items)
        {
            int productId = 0;
            XmlNodeList _MerchantItemPrivateDataNodes = null;
            string SKUattributeList = "";
            string SkuId = "";
            string selectedAddOnValues = "";

            if (thisItem.merchantprivateitemdata != null && thisItem.merchantprivateitemdata != null)
            {
                //Retreieve All Child Nodes - ProductId,SKUattributeList,AddonList
                _MerchantItemPrivateDataNodes = thisItem.merchantprivateitemdata.ChildNodes;

                productId = int.Parse(_MerchantItemPrivateDataNodes[0].InnerText);

                //Retrieve SKUId 
                SkuId = _MerchantItemPrivateDataNodes[1].InnerText;

                //Retrieve AddOn Value Id List
                selectedAddOnValues = _MerchantItemPrivateDataNodes[2].InnerText;
            }
            //Create Product Entity using ProductId
            ZNodeProduct _product = ZNodeProduct.Create(productId, ZNodeConfigManager.SiteConfig.PortalID);

            if (_product != null)
            {
                ZNodeAddOnList SelectedAddOn = new ZNodeAddOnList();
                //get a sku based on Add-ons selected
                SelectedAddOn = ZNodeAddOnList.CreateByProductAndAddOns(_product.ProductID, selectedAddOnValues);

                //Set Selected Add-on 
                _product.SelectedAddOnItems = SelectedAddOn;
            }

            if (SkuId.Length > 0)
            {
                SKUAdmin _skuAdmin = new SKUAdmin();
                DataSet ds = _skuAdmin.GetBySKUId(int.Parse(SkuId));

                //Loop throug the items in the dataset
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SKUattributeList += dr["AttributeId"].ToString() + ",";
                }

                //get a sku based on attributes selected
                SKU = ZNodeSKU.CreateByProductAndAttributes(_product.ProductID, SKUattributeList);

            }
            _product.SelectedSKU = SKU;

            //create shopping cart item
            ZNodeShoppingCartItem item = new ZNodeShoppingCartItem();
            item.Product = _product;
            item.Quantity = thisItem.quantity;

            //add item to cart
            _shoppingCart.AddToCart(item);
        }

        UpdateAddOnsInventory();
        UpdateProductSKUInventory();

    }
    /// <summary>
    /// Update SKU table with quantity 
    /// </summary>
    /// <param name="Callback"></param>
    private void UpdateProductSKUInventory()
    {
        //Reduce the Product add-ons quantityAvailable by 1 ,if the order is placed successfully        
        //Loop through the Order Line Items
        //foreach (ZNodeShoppingCartItem Item in _shoppingCart.ShoppingCartItems)
        //{
        //    if (Item.Product.TrackInventoryInd)
        //    {
        //        if (Item.Product.ZNodeAttributeTypeCollection.Count == 0)
        //        {

        //            ZNode.Libraries.Admin.ProductAdmin ProductAdmin = new ProductAdmin();
        //            ZNode.Libraries.DataAccess.Entities.Product _product = ProductAdmin.GetByProductId(Item.Product.ProductID);
        //            if (_product != null)
        //            {
        //                //Subtract Order quantity from the inventory quantity (product Values)
        //                _product.QuantityOnHand = _product.QuantityOnHand - Item.Quantity;
        //                //Update into Product table
        //                ProductAdmin.Update(_product);
        //            }

        //        }
        //        else
        //        {
        //            ZNode.Libraries.Admin.SKUAdmin SKUCodeAdmin = new ZNode.Libraries.Admin.SKUAdmin();
        //            ZNode.Libraries.DataAccess.Entities.SKU _ProductSKU = SKUCodeAdmin.GetBySKUID(Item.Product.SelectedSKU.SKUID);
        //            if (_ProductSKU != null)
        //            {
        //                //Subtract Order quantity from the inventory quantity
        //                _ProductSKU.QuantityOnHand = _ProductSKU.QuantityOnHand - Item.Quantity;
        //                //update into SKU table
        //                SKUCodeAdmin.Update(_ProductSKU);
        //            }
        //        }
        //    }
        //}

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Callback"></param>
    private void UpdateAddOnsInventory()
    {
        //Reduce the Product add-ons quantityAvailable by 1 ,if the order is placed successfully        
        //Loop through the Order Line Items
        //Loop through the Order Line Items
        //foreach (ZNodeShoppingCartItem shoppingCartItem in _shoppingCart.ShoppingCartItems)
        //{
        //    //Loop through the Selected addons for each Shopping cartItem
        //    foreach (ZNodeAddOn AddOn in shoppingCartItem.Product.SelectedAddOnItems.ZNodeAddOnCollection)
        //    {
        //        foreach (ZNodeAddOnValue AddOnValue in AddOn.ZNodeAddOnValueCollection)//Add-On value collection
        //        {
        //            ZNode.Libraries.DataAccess.Service.AddOnValueService AddOnValueServ = new ZNode.Libraries.DataAccess.Service.AddOnValueService();

        //            if (AddOn.TrackInventoryInd)
        //            {
        //                AddOnValue value = AddOnValueServ.GetByAddOnValueID(AddOnValue.AddOnValueID);
        //                value.QuantityOnHand = value.QuantityOnHand - shoppingCartItem.Quantity;

        //                //Update AddOn value to the database
        //                AddOnValueServ.Update(value);
        //            }
        //        }
        //    }
        //}

    }

    #endregion

    # region Encoding helper Methods
    /// <summary>
    /// Converts a string to bytes in UTF-8 encoding.
    /// </summary>
    /// <param name="InString">The string to convert.</param>
    /// <returns>The UTF-8 bytes.</returns>
    public static byte[] StringToUtf8Bytes(string InString)
    {
        System.Text.UTF8Encoding utf8encoder = new System.Text.UTF8Encoding(false, true);
        return utf8encoder.GetBytes(InString);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Xml"></param>
    /// <returns></returns>
    public static string GetTopElement(string Xml)
    {
        return GetTopElement(StringToUtf8Bytes(Xml));
    }

    public static string GetTopElement(byte[] Xml)
    {
        using (MemoryStream ms = new MemoryStream(Xml))
        {
            return GetTopElement(ms);
        }
    }
    /// <summary>
    /// Returns the top element of the xml
    /// </summary>
    /// <param name="Xml"></param>
    /// <returns></returns>
    public static string GetTopElement(Stream Xml)
    {
        //set the begin postion so we can set the stream back when we are done.
        long beginPos = Xml.Position;
        XmlTextReader XReader = new XmlTextReader(Xml);
        XReader.WhitespaceHandling = WhitespaceHandling.None;
        XReader.Read();
        XReader.Read();
        string RetVal = XReader.Name;
        //Do not close the stream, we will still need it for additional
        //operations.
        //XReader.Close();
        //reposition the stream to where it started
        Xml.Position = beginPos;
        return RetVal;
    }
    # endregion
}
