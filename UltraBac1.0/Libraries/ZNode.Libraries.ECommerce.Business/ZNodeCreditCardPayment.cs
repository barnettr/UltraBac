using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using ZNode.Libraries.Integrator;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to Authorize the credit card payment
    /// </summary>
    public class ZNodeCreditCardPayment: ZNodePaymentBase, ICreditCard
    {
        #region Member Variables
        private string _cardNumber = string.Empty;
        private string _cardExpMonth = string.Empty;
        private string _cardExpYear = string.Empty;
        private string _cardSecurityCode = string.Empty;
        private ZNodeAddress _cardAddress = new ZNodeAddress();
        private ZNodeAddress _znodeshipaddress = new ZNodeAddress();
        private ZNodeShoppingCart _shoppingCart = new ZNodeShoppingCart();
        #endregion

        #region Properties   
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
        public string CardExpMonth
        {
            get { return _cardExpMonth; }
            set { _cardExpMonth = value; }
        }

        /// <summary>
        /// Retrieves or sets the Credit card expiration year
        /// </summary>
        public string CardExpYear
        {
            get { return _cardExpYear; }
            set { _cardExpYear = value; }
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
        /// Retrieves or sets the Billing Address object. 
        /// </summary>
        public override ZNodeAddress BillingAddress
        {
            get { return _cardAddress; }
            set { _cardAddress = value; }
        }
        /// <summary>
        /// Retrieves or sets the Shipping Address object. 
        /// </summary>
        public override ZNodeAddress ShippingAddress
        {
            get { return _znodeshipaddress; }
            set { _znodeshipaddress = value; }
        }
        /// <summary>
        /// Retrieves or sets the shopping Cart object
        /// </summary>
        public override ZNodeShoppingCart CurrentShoppingCart
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

        #region Methods
        public override ZNodePaymentResponse SubmitPayment(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            //submit payment based on payment settings

            return SubmitToPaymentGateway(PaymentSetting, Order);
        }


        /// <summary>
        /// Submits payment to multiple gateways
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public override ZNodePaymentResponse SubmitToPaymentGateway(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            ZNodePaymentResponse PaymentResponse = new ZNodePaymentResponse();                        
               
           //submit payment details to ZNode Integrator Component.
           PaymentResponse = SubmitToGateway(PaymentSetting, Order);

           //Return Payment Gateway Response
           return PaymentResponse;
            
        }       

        #endregion

        # region Protected Member variables
        Address _billingAddress = new Address();
        Address _shippingAddress = new Address();
        Address _payerAddress = new Address();
        CreditCardInfo _cardInfo = new CreditCardInfo();
        GatewayInfo _gatewayInfo = new GatewayInfo();                
        private ECGatewayAction _gatewayaction = new ECGatewayAction();

        /// <summary>
        /// Represents the payment gateway
        /// </summary>
        public string Gateway = string.Empty;
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
        public string CustomerId = "";
        public string InvoiceNumber = "";
        # endregion

        # region Public Instance  Properties  
        /// <summary>
        /// 
        /// </summary>
        public override ECGatewayAction GatewayAction
        {
            get { return _gatewayaction; }
            set { _gatewayaction = value; }
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

        # endregion

        #region Public Methods
        /// <summary>
        /// Submits payment to multiple gateways
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public ZNodePaymentResponse SubmitToGateway(PaymentSetting PaymentSetting, ZNodeOrder Order)
        {
            ZNodePaymentResponse PaymentResponse = new ZNodePaymentResponse();
            ZNodePaymentProcessor _processor = new ZNodePaymentProcessor();

            _processor.TransactionAmount = Order.Total.ToString("N2");
            _processor.TransactionDesc = "";
            _processor.InvoiceNumber = Order.OrderID.ToString();

            //Gateway Settings
            ZNodeEncryption decrypt = new ZNodeEncryption();            
            _processor.MerchantLogin = decrypt.DecryptData(PaymentSetting.GatewayUsername);
            _processor.MerchantPassword = decrypt.DecryptData(PaymentSetting.GatewayPassword);
            _processor.TransactionKey = decrypt.DecryptData(PaymentSetting.TransactionKey);

            //Set Test Mode - Not supported for all gateways
            _processor.IsTestMode = PaymentSetting.TestMode;

            //Set Gateway according to the payment settings
            if (PaymentSetting.GatewayTypeID.Value == 1)
            {
                _processor.Gateway = GatewayType.AUTHORIZE.ToString(); // Authorize.Net
            }
            else if (PaymentSetting.GatewayTypeID.Value == 2)
            {
                _processor.Gateway = GatewayType.VERISIGN.ToString(); //Verisign Payflow Pro
            }
            else if (PaymentSetting.GatewayTypeID.Value == 3)
            {
                _processor.Gateway = GatewayType.PAYMENTECH.ToString(); // Paymenttech Orbital
            }
            else if(PaymentSetting.GatewayTypeID.Value == 4)
            {
                _processor.Gateway = GatewayType.PSIGate.ToString(); //PSI Gate
                _processor.CreditCardInformation.SubTotal = Order.SubTotal - Order.DiscountAmount;
                _processor.TaxCost = Order.TaxCost;
                _processor.ShippingCharge = Order.ShippingCost;
            }
            else if (PaymentSetting.GatewayTypeID.Value == 5)
            {
                _processor.Gateway = GatewayType.NOVA.ToString(); //Nova Payment Gateway
                _processor.TenderType = "0"; //Represents cash payment
                _processor.TransactionType = "ccsale"; //Credit card sale
            }
            else if (PaymentSetting.GatewayTypeID == 6)//nSoftware component is selected
            {
                _processor.Gateway = GatewayType.nSoftware.ToString(); 
            }

            //Customer Address from Account
            _processor.BillingAddress = Order.BillingAddress;
            _processor.ShippingAddress = Order.ShippingAddress;

            //CreditCard Information            
            _processor.CardNumber = _cardNumber;
            _processor.CardSecurityCode = _cardSecurityCode;
            _processor.CardExpirationDate = _cardExpMonth + "/" + _cardExpYear;

            //Submit Payment to Gateway
            PaymentResponse = _processor.SubmitToPaymentGateway();

            return PaymentResponse;

        }     
        # endregion
    }
}
