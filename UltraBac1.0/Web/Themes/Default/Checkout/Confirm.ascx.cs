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
using ZNode.Libraries.ECommerce.Business ;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using ZNode.Libraries.Framework.Business;

/// <summary>
/// Checkout confirmation
/// </summary>
public partial class Controls_ShoppingCartCheckout_Confirm : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeOrder _order = new ZNodeOrder();
    private string _siteName = string.Empty;
    private string _receiptText = string.Empty;
    private string _customerServiceEmail = string.Empty;
    private string _customerServicePhoneNumber = string.Empty;
    protected string _receiptTemplate = string.Empty;
    private ZNodeShoppingCart _shoppingCart = new ZNodeShoppingCart();
    #endregion

    #region Public Properties
    public ZNodeOrder Order
    {
        get
        {
            return _order;
        }
        set
        {
            _order = value;
        }
    }

    public string SiteName
    {
        get
        {
            return _siteName;
        }
        set
        {
            _siteName = value;
        }
    }

    public string ReceiptText
    {
        get
        {
            return _receiptText;
        }
        set
        {
            _receiptText = value;
        }
    }

    public string CustomerServiceEmail
    {
        get
        {
            return _customerServiceEmail;
        }
        set
        {
            _customerServiceEmail = value;
        }
    }

    public string CustomerServicePhoneNumber
    {
        get
        {
            return _customerServicePhoneNumber;
        }
        set
        {
            _customerServicePhoneNumber = value;
        }
    }

    public ZNodeShoppingCart ShoppingCart
    {
        get
        {
            return _shoppingCart;
        }
        set
        {
            _shoppingCart = value;
        }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Helper Functions
    /// <summary>
    /// Generate the receipt using XSL Transformation
    /// </summary>
    public void GenerateReceipt()
    {
        string templatePath = Server.MapPath(ZNodeConfigManager.EnvironmentConfig.ConfigPath + "Receipt.xsl"); 

        XmlDocument xmlDoc = new XmlDocument();
        XmlElement rootElement = GetElement(xmlDoc,"Order","");

        rootElement.AppendChild(GetElement(xmlDoc, "SiteName", SiteName));
        rootElement.AppendChild(GetElement(xmlDoc, "AccountId", Order.AccountID.ToString()));
        rootElement.AppendChild(GetElement(xmlDoc, "ReceiptText", ReceiptText));
        rootElement.AppendChild(GetElement(xmlDoc, "CustomerServiceEmail", CustomerServiceEmail));
        rootElement.AppendChild(GetElement(xmlDoc, "CustomerServicePhoneNumber", CustomerServicePhoneNumber));
        //TODO
        //rootElement.AppendChild(GetElement(xmlDoc, "PromotionCode", Order.PromotionId.ToString()));
        rootElement.AppendChild(GetElement(xmlDoc, "OrderId", Order.OrderID.ToString()));
        rootElement.AppendChild(GetElement(xmlDoc, "OrderDate", Order.OrderDate.ToString()));

        rootElement.AppendChild(GetElement(xmlDoc, "ShippingName", ShoppingCart.ShippingName));
        rootElement.AppendChild(GetElement(xmlDoc, "PaymentName", ShoppingCart.PaymentName));

        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressFirstName", Order.ShippingAddress.FirstName));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressLastName", Order.ShippingAddress.LastName));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressStreet1", Order.ShippingAddress.Street1));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressStreet2", Order.ShippingAddress.Street2));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressCity", Order.ShippingAddress.City));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressStateCode", Order.ShippingAddress.StateCode));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressPostalCode", Order.ShippingAddress.PostalCode));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressCountryCode", Order.ShippingAddress.CountryCode));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingAddressPhoneNumber", Order.ShippingAddress.PhoneNumber));

        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressFirstName", Order.BillingAddress.FirstName));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressLastName", Order.BillingAddress.LastName));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressStreet1", Order.BillingAddress.Street1));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressStreet2", Order.BillingAddress.Street2));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressCity", Order.BillingAddress.City));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressStateCode", Order.BillingAddress.StateCode));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressPostalCode", Order.BillingAddress.PostalCode));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressCountryCode", Order.BillingAddress.CountryCode));
        rootElement.AppendChild(GetElement(xmlDoc, "BillingAddressPhoneNumber", Order.BillingAddress.PhoneNumber));

        
        rootElement.AppendChild(GetElement(xmlDoc, "SubTotal", Order.SubTotal.ToString("c")));
        rootElement.AppendChild(GetElement(xmlDoc, "TaxCost", Order.TaxCost.ToString("c")));        
        //TODO
        rootElement.AppendChild(GetElement(xmlDoc, "DiscountAmount", "-" + Order.DiscountAmount.ToString("c")));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingName", ""));
        rootElement.AppendChild(GetElement(xmlDoc, "ShippingCost", Order.ShippingCost.ToString("c")));
        rootElement.AppendChild(GetElement(xmlDoc, "TotalCost", Order.Total.ToString("c")));
        rootElement.AppendChild(GetElement(xmlDoc, "AdditionalInstructions", Order.AdditionalInstructions));

        XmlElement items = xmlDoc.CreateElement("Items");

        foreach (ZNodeShoppingCartItem shoppingCartItem in ShoppingCart.ShoppingCartItems)
        {
            XmlElement item = xmlDoc.CreateElement("Item");

            item.AppendChild(GetElement(xmlDoc,"Quantity",shoppingCartItem.Quantity.ToString()));
            item.AppendChild(GetElement(xmlDoc,"Name", shoppingCartItem.Product.Name));
            item.AppendChild(GetElement(xmlDoc, "OptionValueDescription", shoppingCartItem.Product.AddOnDescription));
            item.AppendChild(GetElement(xmlDoc, "SKU", shoppingCartItem.Product.SKU));
            item.AppendChild(GetElement(xmlDoc, "Description", shoppingCartItem.Product.SelectedSKU.AttributesDescription));
            item.AppendChild(GetElement(xmlDoc, "Note", ""));
            item.AppendChild(GetElement(xmlDoc, "Price", shoppingCartItem.Product.FinalPrice.ToString("c")));

            Decimal extPrice = shoppingCartItem.Product.FinalPrice * shoppingCartItem.Quantity;
            item.AppendChild(GetElement(xmlDoc, "Extended", extPrice.ToString("c")));

            items.AppendChild(item);
        }        

        rootElement.AppendChild(items);
        xmlDoc.AppendChild(rootElement);

        // Use a memorystream to store the result into the memory
        MemoryStream ms = new MemoryStream();

        XslCompiledTransform xsl = new XslCompiledTransform();
        xsl.Load(templatePath);
        xsl.Transform(xmlDoc, null, ms);

        // Move to the begining 
        ms.Seek(0, SeekOrigin.Begin);

        // Pass the memorystream to a streamreader
        StreamReader sr = new StreamReader(ms);

        _receiptTemplate = sr.ReadToEnd();
    }

    /// <summary>
    /// Creates an XML Element
    /// </summary>
    /// <param name="xmlDoc"></param>
    /// <param name="elementName"></param>
    /// <param name="elementValue"></param>
    /// <returns></returns>
    private XmlElement GetElement(XmlDocument xmlDoc, string elementName, string elementValue)
    {
        XmlElement elmt = xmlDoc.CreateElement(elementName);
        if (elementValue.Length > 0)
        {
            elmt.InnerText = elementValue;
        }
        return elmt;
    }
    #endregion
}
