using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.Framework.Business;
using System.Web;
using ZNode.Libraries.Framework;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities ;
using ZNode.Libraries.DataAccess.Data ;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Net.Mail;
using System.Data;
using ZNode.Libraries.Integrator;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Provides methods to submit an order and holds data collected during checkout
    /// </summary>
    public class ZNodeCheckout: ZNodeBusinessBase 
    {
        #region Member Variables
        private ZNodeUserAccount _userAccount;
        private ZNodePaymentBase _payment;
        private ZNodeShoppingCart _shoppingCart;
        private PaymentTypeList _paymentType;

        private string _additionalInstructions = string.Empty;
        private string _cardNumber = string.Empty;
        private string _cardExpMonth = string.Empty;
        private string _cardExpYear = string.Empty;
        private string _cardSecurityCode = string.Empty;

        public string ReturnURL = "";
        public string CancelURL = "";
        public string ECRedirectURL = "";
        public string PaypalToken = string.Empty;
        public string PaypalPayerID = string.Empty;
        public string PaymentResponseText = string.Empty;
        public bool IsSuccess = false;
        #endregion

        #region Public Properties

        /// <summary>
        /// Retrieves or Sets the user account object
        /// </summary>
        public ZNodeUserAccount UserAccount
        {
            get
            {                
               return _userAccount;                
            }
            set { _userAccount = value; }
        }      

        /// <summary>
        /// Retrieves or Sets the Znodepaymentbase object
        /// </summary>
        public ZNodePaymentBase Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// <summary>
        /// Retrieves or Sets the paymenttype list object
        /// </summary>
        public PaymentTypeList PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }

        /// <summary>
        /// Retrieves or Sets the shopping cart object
        /// </summary>
        public ZNodeShoppingCart ShoppingCart
        {
            get
            {
                return _shoppingCart;               
            }
            set { _shoppingCart = value; }
        }

        /// <summary>
        /// Retrieves or Sets the Credit card Number property 
        /// </summary>
        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        /// <summary>
        /// Retrieves or Sets the Credit card expiration month property 
        /// </summary>
        public string CardExpMonth
        {
            get { return _cardExpMonth; }
            set { _cardExpMonth = value; }
        }

        /// <summary>
        /// Retrieves or Sets the Credit card epiration year property 
        /// </summary>
        public string CardExpYear
        {
            get { return _cardExpYear; }
            set { _cardExpYear = value; }
        }

        /// <summary>
        /// Retrieves or Sets the Credit card security code property
        /// </summary>
        public string CardSecurityCode
        {
            get { return _cardSecurityCode; }
            set { _cardSecurityCode = value; }
        }

        /// <summary>
        /// Retrieves or Sets the Customer Additional instructions for this order
        /// </summary>
        public string AdditionalInstructions
        {
            get { return _additionalInstructions; }
            set { _additionalInstructions = value; }
        }
        #endregion

        #region Constructor
        public ZNodeCheckout()
        {
            _userAccount = (ZNodeUserAccount)ZNodeUserAccount.CreateFromSession(ZNodeSessionKeyType.UserAccount);
            _shoppingCart = (ZNodeShoppingCart)ZNodeShoppingCart.CreateFromSession(ZNodeSessionKeyType.ShoppingCart);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Submits an order
        /// </summary>
        /// <returns>newly created order</returns>
        public ZNodeOrder SubmitOrder()
        {
            ZNodeOrder order = new ZNodeOrder();

            //get payment settings (merchant gateway, etc)
            PaymentSettingService pmtSetServ = new PaymentSettingService();         
            PaymentSetting pmtSetting = pmtSetServ.GetByProfileIDPaymentTypeID(_userAccount.ProfileID, (int)_paymentType)[0];            
            TransactionManager tranManager = null;

            try
            {
                tranManager = ConnectionScope.CreateTransaction();

                //update account & customer - Non Critical
                _userAccount.UpdateUserAccount();
                
                //create order - Critical
                order = new ZNodeOrder(_userAccount, _shoppingCart, ZNodeConfigManager.SiteConfig.PortalID);
                order.PaymentTypeId = (int)_paymentType;
                order.ShippingID = _shoppingCart.ShippingID;
                order.AdditionalInstructions = AdditionalInstructions;

                //Check to update creditcard info into order table
                if ((bool)pmtSetting.SaveCreditCartInfo)
                {
                    ZNodeEncryption encrypt = new ZNodeEncryption();
                    order.CreditCardNumber = encrypt.EncryptData(_cardNumber);
                    order.CreditCardExp = encrypt.EncryptData(_cardExpMonth + _cardExpYear);
                    order.CreditCardCVV = encrypt.EncryptData(_cardSecurityCode);                 
                }                
                order.SubmitOrder(ZNodeOrderState.PendingPayment);

                //submit payment - Critical
                if (!(bool)pmtSetting.OfflineMode)//Checking Offline processing of orders - Merchant Gateway
                {
                    //if paypal then set Gateway Action as DoExpressCheckoutPaymentResponse
                    if (PaymentTypeList.PayPal == _paymentType)
                    {
                        _payment.GatewayAction = ECGatewayAction.DoExpressCheckoutPaymentResponse;
                        _payment.PayPalPayerID = PaypalPayerID;
                        _payment.PaypalToken = PaypalToken;
                    }
                    else if(PaymentTypeList.Google_Checkout == _paymentType)
                    {
                        _payment.GatewayAction = ECGatewayAction.SetExpressCheckoutResponse;

                        //Set Return Return URL and Cancel URL properties
                        _payment.PaypalCancelURL = CancelURL;
                        _payment.PaypalReturnURL = ReturnURL;

                        //Important - We don't want to update the Add-On inventory level now
                        //After successful completion of the order, Notification page will update 
                        //the inventory for both SKU & Product,Addon there.
                        order.IsupdateInventoryInd = false;

                        //Set Current Shopping Cart to Payment processor object
                        _payment.CurrentShoppingCart = _shoppingCart;
                    }

                    //Submit payment to gateway
                    ZNodePaymentResponse paymentResponse = _payment.SubmitToPaymentGateway(pmtSetting, order);
                    if (paymentResponse.IsSuccess)
                    {
                        order.CardTransactionID = paymentResponse.TransactionId;                        
                        tranManager.Commit();
                    }
                    else
                    {
                        tranManager.Rollback();
                    }

                    PaymentResponseText = paymentResponse.ResponseText;
                    IsSuccess = paymentResponse.IsSuccess;
                    ECRedirectURL = paymentResponse.RedirectURL;

                }
                else
                {
                    //If offline mode is enabled
                    IsSuccess = true;
                    tranManager.Commit();

                    //Return the order with order-status as "Pending Payment"
                    return order;
                }
                
            }
            catch (ZNodePaymentException)
            {
                tranManager.Rollback();

                //rethrow
                throw;
            }
            catch (Exception ex)
            {
                tranManager.Rollback();

                //log exception
                ExceptionPolicy.HandleException(ex, "ZNODE_GLOBAL_EXCEPTION_POLICY");

                //rethrow
                throw ;
            }

            //non critical steps - ignore on failure
            try
            {
                //If Payment Gateway is Google then
                //Remain the Order status as 'Pending Payment'
                //Otherwise change the order status as 'Submitted'
                if (PaymentTypeList.Google_Checkout != _paymentType)
                //set order status
                order.UpdateOrderStatus(ZNodeOrderState.Submitted);
            }
            catch (Exception ex)
            {
                //log exception
                ExceptionPolicy.HandleException(ex, "ZNODE_GLOBAL_EXCEPTION_POLICY");

                //do not rethrow as this is non-critical
            }

            return order;
        }
        #endregion

        # region Helper Methods

        /// <summary>
        ///  Method to initiate an google Express Checkout transaction - Charge Amount
        /// Crictical 
        /// </summary>
        /// <param name="returnURL"></param>
        /// <param name="cancelURL"></param>
        /// <returns></returns>
        public bool DOGoogleExpressCheckout(ZNodeOrder order)
        {            

            //get payment settings (merchant gateway, etc)
            PaymentSettingService pmtSetServ = new PaymentSettingService();
            PaymentSetting pmtSetting = pmtSetServ.GetByPaymentTypeID(order.PaymentTypeId)[0];
            
            //Google gateway settings
            _payment = new ZNodeGooglePayment();
            _payment.GatewayAction = ZNode.Libraries.Integrator.ECGatewayAction.DoExpressCheckoutPaymentResponse;
            _payment.PaypalToken = order.CardTransactionID; //Google Order Number

            ZNodePaymentResponse paymentResponse = _payment.SubmitToPaymentGateway(pmtSetting, order);
            IsSuccess = paymentResponse.IsSuccess;

            return paymentResponse.IsSuccess;            
            
        }

        /// <summary>
        ///  Method to initiate an paypal Express Checkout transaction
        /// </summary>
        /// <param name="returnURL"></param>
        /// <param name="cancelURL"></param>
        /// <returns></returns>
        public string SetExpressCheckoutResponse(string returnURL, string cancelURL)
        {            
            ZNodeOrder order = new ZNodeOrder();

            //get payment settings (merchant gateway, etc)
            PaymentSettingService pmtSetServ = new PaymentSettingService();
            PaymentSetting pmtSetting = pmtSetServ.GetByProfileIDPaymentTypeID(_userAccount.ProfileID, (int)_paymentType)[0];

            //create order - Critical            
            order.Total = _shoppingCart.Total;
            order.BillingAddress = _userAccount.BillingAddress;
            order.ShippingAddress = _userAccount.ShippingAddress;
            order.AdditionalInstructions = AdditionalInstructions;

            //Pay pal gateway settings
            _payment.GatewayAction  = ECGatewayAction.SetExpressCheckoutResponse;
            _payment.PaypalCancelURL = cancelURL;
            _payment.PaypalReturnURL = returnURL;

            ZNodePaymentResponse paymentResponse = _payment.SubmitToPaymentGateway(pmtSetting, order);

            IsSuccess = paymentResponse.IsSuccess;

            if (paymentResponse.IsSuccess)
            {
                PaypalToken = paymentResponse.PaypalECtoken;

                if (pmtSetting.TestMode)
                {
                    return "www.sandbox.paypal.com";//Test environment URL
                }
                else
                {
                    return "www.paypal.com";//Production Site URL
                }
            }
            else
            {
                PaymentResponseText = paymentResponse.ResponseCode + " " + paymentResponse.ResponseText;
                return String.Empty;
            }
        }
        # endregion
    }
}
