using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Integrator;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;

namespace ZNode.Libraries.ECommerce.Business
{
    public class ZNodePaymentProcessor : ZNodePaymentBase
    {
        # region Protected Member variables
        private string _cardNumber = string.Empty;
        private string _cardExpiration = string.Empty;        
        private string _cardSecurityCode = string.Empty;

        private ZNodeAddress _cardAddress = new ZNodeAddress();
        private ZNodeAddress _znodeshipaddress = new ZNodeAddress();
        private Address _billingAddress = new Address();
        private Address _shippingAddress = new Address();
        private Address _payerAddress = new Address();
        private CreditCardInfo _cardInfo = new CreditCardInfo();
        private GatewayInfo _gatewayInfo = new GatewayInfo();
        private ECGatewayAction _action = new ECGatewayAction();
        private ZNodeShoppingCart _shoppingCart = new ZNodeShoppingCart();

        private string _tenderType = string.Empty;
        private string _transactionType = string.Empty;
        private string _merchantprivateData = "";

        /// <summary>
        /// Represents the payment gateway
        /// </summary>
        public string Gateway = "0";
        /// <summary>
        /// Represents the Merchant loginid. 
        /// </summary>
        public string MerchantLogin = string.Empty;
        /// <summary>
        /// Represents the Merchant Gateway password.
        /// </summary>
        public string MerchantPassword = string.Empty;
        /// <summary>
        /// Represents the transaction amount (Ordered amount).
        /// </summary>
        public string TransactionAmount = string.Empty;
        /// <summary>
        /// Represents the transaction description.
        /// </summary>
        public string TransactionDesc = string.Empty;
        /// <summary>
        /// Represents the transaction key (for authorize.net and API signature for Paypal)
        /// </summary>
        public string TransactionKey = string.Empty;
        /// <summary>
        /// Represents the gateway test mode
        /// </summary>
        public bool IsTestMode = false;
        /// <summary>
        /// Represents the unique OrderId
        /// </summary>        
        public string InvoiceNumber = "";
        /// <summary>
        /// Represents the shipping charge for this order
        /// </summary>
        public decimal ShippingCharge = 0m;
        /// <summary>
        /// Represents the tax cost for this order
        /// </summary>
        public decimal TaxCost = 0m;
        # endregion

        # region Public Instance  Properties - Overrides Base class properties
        /// <summary>
        /// Retrieves or sets the Billing Address object. 
        /// </summary>
        public override ZNodeAddress BillingAddress
        {
            get { return _cardAddress; }
            set { _cardAddress = value; }
        }
        public override ZNodeAddress ShippingAddress
        {
            get { return _znodeshipaddress; }
            set { _znodeshipaddress = value; }
        }
        #endregion

        # region Public Properties
        /// <summary>
        ///  Retrieves or sets the Google Merchant private data
        /// </summary>
        public string MerchantPrivateData
        {
            get { return _merchantprivateData; }
            set { _merchantprivateData = value; }
        }

        /// <summary>
        /// Retrieves or sets the gateway tender type
        /// </summary>
        public string TenderType
        {
            get { return _tenderType; }
            set { _tenderType = value; }
        }

        /// <summary>
        /// Retrieves or sets the gateway transaction type
        /// </summary>
        public string TransactionType
        {
            get { return _transactionType; }
            set { _transactionType = value; }
        }
        /// <summary>
        /// Retrieves or sets the Credit card Number 
        /// </summary>
        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        /// <summary>
        /// Retrieves or sets the Credit card expiration month
        /// </summary>
        public string CardExpirationDate
        {
            get { return _cardExpiration; }
            set { _cardExpiration = value; }
        }
       
        /// <summary>
        /// Retrieves or sets the Credit card Security code property 
        /// </summary>
        public string CardSecurityCode
        {
            get { return _cardSecurityCode; }
            set { _cardSecurityCode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override ECGatewayAction GatewayAction
        {
            get { return _action; }
            set { _action = value; }
        }
        /// <summary>
        /// Retrieves the Gateway information 
        /// </summary>
        private GatewayInfo GatewayInformation
        {
            get
            {
                _gatewayInfo.gateway = (GatewayType)(Enum.Parse(typeof(GatewayType), Gateway));
                _gatewayInfo.GatewayLoginID = MerchantLogin;
                _gatewayInfo.GatewayPassword = MerchantPassword;
                _gatewayInfo.TestMode = IsTestMode;
                _gatewayInfo.TransactionKey = TransactionKey;
                _gatewayInfo.ECGatewayAction = _action;
                _gatewayInfo.GatewayECCancelURL = PaypalCancelURL;
                _gatewayInfo.GatewayECReturnURL = PaypalReturnURL;
                _gatewayInfo.GatewayECToken = PaypalToken;
                _gatewayInfo.PaypalPayerID = PayPalPayerID;
                _gatewayInfo.TransactionType = TransactionType;
                _gatewayInfo.TenderType = TenderType;
                _gatewayInfo.MerchantPrivateData = MerchantPrivateData;

                return _gatewayInfo;
            }
        }

        /// <summary>
        /// Get the Credit card information
        /// </summary>
        public CreditCardInfo CreditCardInformation
        {
            get
            {
                _cardInfo.Amount = Decimal.Parse(TransactionAmount);
                _cardInfo.CardNumber = _cardNumber;
                _cardInfo.CardSecurityCode = _cardSecurityCode;
                _cardInfo.CreditCardExp = _cardExpiration;
                _cardInfo.OrderID = int.Parse(InvoiceNumber);
                _cardInfo.ShippingCharge = ShippingCharge;
                _cardInfo.TaxCost = TaxCost;

                return _cardInfo;
            }           
        }

        /// <summary>
        /// Get the accountobject with addresses
        /// </summary>
        private Address CustomerBillingAddress
        {
            get
            {
                //get fields
                _billingAddress.FirstName = _cardAddress.FirstName;
                _billingAddress.LastName = _cardAddress.LastName;
                _billingAddress.CompanyName = _cardAddress.CompanyName;
                _billingAddress.Street1 = _cardAddress.Street1;
                _billingAddress.Street2 = _cardAddress.Street2;
                _billingAddress.City = _cardAddress.City;
                _billingAddress.StateCode = _cardAddress.StateCode;
                _billingAddress.PostalCode = _cardAddress.PostalCode;
                _billingAddress.CountryCode = _cardAddress.CountryCode;
                _billingAddress.PhoneNumber = _cardAddress.PhoneNumber;
                _billingAddress.EmailId = _cardAddress.EmailId;

                return _billingAddress;
            }
        }

        /// <summary>
        /// Get the accountobject with addresses
        /// </summary>
        public Address CustomerShippingAddress
        {
            get
            {
                _shippingAddress.FirstName = _znodeshipaddress.FirstName;
                _shippingAddress.LastName = _znodeshipaddress.LastName;
                _shippingAddress.CompanyName = _znodeshipaddress.MiddleName;
                _shippingAddress.Street1 = _znodeshipaddress.Street1;
                _shippingAddress.Street2 = _znodeshipaddress.Street2;
                _shippingAddress.City = _znodeshipaddress.City;
                _shippingAddress.PostalCode = _znodeshipaddress.PostalCode;
                _shippingAddress.CountryCode = _znodeshipaddress.CountryCode;
                _shippingAddress.StateCode = _znodeshipaddress.StateCode;
                _shippingAddress.PhoneNumber = _znodeshipaddress.PhoneNumber;
                _shippingAddress.EmailId = _znodeshipaddress.EmailId;

                return _shippingAddress;
            }
        }

        /// <summary>
        /// Get the Payer address object with addresses
        /// </summary>
        public ZNodeAddress PayerAddress
        {
            get
            {
                _znodeshipaddress.FirstName = _payerAddress.FirstName;
                _znodeshipaddress.LastName = _payerAddress.LastName;
                _znodeshipaddress.MiddleName = _payerAddress.MiddleName;
                _znodeshipaddress.CompanyName = _payerAddress.CompanyName;
                _znodeshipaddress.Street1 = _payerAddress.Street1;
                _znodeshipaddress.Street2 = _payerAddress.Street2;
                _znodeshipaddress.City = _payerAddress.City;
                _znodeshipaddress.StateCode = _payerAddress.StateCode;
                _znodeshipaddress.CountryCode = _payerAddress.CountryCode;
                _znodeshipaddress.PostalCode = _payerAddress.PostalCode;
                _znodeshipaddress.EmailId = _payerAddress.EmailId;

                return _znodeshipaddress;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override ZNodeShoppingCart CurrentShoppingCart
        {
            set { _shoppingCart = value; }
            get { return _shoppingCart; }
        }

        # endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public override ZNodePaymentResponse SubmitPayment(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            //submit payment based on payment settings

            return new ZNodePaymentResponse();
        }
        /// <summary>
        /// Submits payment to multiple gateways
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public override ZNodePaymentResponse SubmitToPaymentGateway(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            //submit payment based on payment settings

            return new ZNodePaymentResponse();
        }

        /// <summary>
        /// Submits payment to multiple gateways
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public ZNodePaymentResponse SubmitToPaymentGateway()
        {
            ZNodePaymentResponse PaymentResponse = new ZNodePaymentResponse();
            
            //Submit Payment to Gateway
            GatewayResponse _gatewayResponse = SubmitPayment();

            PaymentResponse.IsSuccess = _gatewayResponse.IsSuccess;
            PaymentResponse.ResponseCode = _gatewayResponse.ResponseCode;
            PaymentResponse.ResponseText = _gatewayResponse.ResponseText;
            PaymentResponse.PaypalPayerID = _gatewayResponse.PaypalPayerID;
            PaymentResponse.PaypalECtoken = _gatewayResponse.PaypalECtoken;
            PaymentResponse.TransactionId = _gatewayResponse.TransactionId;
            PaymentResponse.RedirectURL = _gatewayResponse.ECRedirectURL;

            if ((GatewayType)(Enum.Parse(typeof(GatewayType), Gateway)) == GatewayType.PAYPAL)
            {
                //Customer's shipping address as selected on the PayPal site
                _payerAddress = _gatewayResponse.PayerAddress;
                PaymentResponse.ShippingAddress = PayerAddress;
            }          

            return PaymentResponse;

        }
        /// <summary>
        /// Submit payment to ZNodeStorefront Integrator Component
        /// </summary>
        /// <returns></returns>
        private GatewayResponse SubmitPayment()
        {
            PaymentProcessor Paymentprocessor = new PaymentProcessor();
            
            GatewayInformation.GoogleOrderNumber = GatewayInformation.GatewayECToken;
            Paymentprocessor.Gateway = GatewayInformation;
            Paymentprocessor.BillingAddress = CustomerBillingAddress;
            Paymentprocessor.ShippingAddress = CustomerShippingAddress;
            Paymentprocessor.CreditCard = CreditCardInformation;

            if ((GatewayType)(Enum.Parse(typeof(GatewayType), Gateway)) == GatewayType.GOOGLE)
            {
                ShoppingCartItem CartItem = new ShoppingCartItem();
                foreach (ZNodeShoppingCartItem Item in CurrentShoppingCart.ShoppingCartItems)
                {
                    string temp = "";
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    System.Xml.XmlElement elem = doc.CreateElement("root");
                    doc.AppendChild(elem);

                    System.Xml.XmlNode SkuNode = doc.CreateElement("SelectedAttributeList");

                    if (Item.Product.SelectedSKU.SKUID > 0)
                    {
                        SkuNode.InnerText = Item.Product.SelectedSKU.SKUID.ToString();
                    }

                    System.Xml.XmlNode AddOnNode = doc.CreateElement("AddOnList");
                    

                    foreach( ZNodeAddOn Addon in Item.Product.SelectedAddOnItems.ZNodeAddOnCollection)
                    {
                        foreach (ZNodeAddOnValue AddOnValue in Addon.ZNodeAddOnValueCollection)
                        {
                            temp += AddOnValue.AddOnValueID + ",";
                        }
                    }

                    AddOnNode.InnerText = temp;

                    System.Xml.XmlNode ProductIdNode = doc.CreateElement("ItemId");
                    ProductIdNode.InnerText = Item.Product.ProductID.ToString();

                    System.Xml.XmlNode ProductCodeNode = doc.CreateElement("ProductCode");                    
                    ProductCodeNode.InnerText = Item.Product.ProductNum;

                    elem.AppendChild(ProductIdNode);
                    elem.AppendChild(SkuNode);
                    elem.AppendChild(AddOnNode);
                    elem.AppendChild(ProductCodeNode);

                    //Set Product Description
                    string Description =  Item.Product.SelectedSKU.AttributesDescription + Item.Product.AddOnDescription;
                    Description = Description.Replace("<br />", "");

                    CartItem.AddItem(Item.Product.Name, Description , Item.Product.FinalPrice, Item.Product.ProductID, Item.Quantity,doc.FirstChild.ChildNodes );

                    Paymentprocessor.ShoppingCartItems = CartItem;
                }

                //Apply Coupon 
                if(CurrentShoppingCart.OrderDiscount > 0)
                {
                    CartItem.AddItem("Discount ", "", (-CurrentShoppingCart.OrderDiscount), 0, 1, null);   
                }

                //Set Tax Rate
                ZNode.Libraries.Integrator.TaxRuleCollection AddTaxRule = new TaxRuleCollection();
                Google.USZipArea PostalCode = new Google.USZipArea();
                PostalCode.zippattern = "*";
                decimal CalculatedTax = 0;
                try
                {
                    CalculatedTax = CurrentShoppingCart.TaxRate / 100;
                }
                catch { CalculatedTax = 0; }

                double taxRate = double.Parse(CalculatedTax.ToString());
                
                AddTaxRule.AddRule(PostalCode, taxRate, false);

                Paymentprocessor.TaxRules = AddTaxRule;
            }

            GatewayResponse Response = new GatewayResponse();
            Response = Paymentprocessor.SubmitCreditCardPayment();

            return Response;
        }
        # endregion
    }
}
