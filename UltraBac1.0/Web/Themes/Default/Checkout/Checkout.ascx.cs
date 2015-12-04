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
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Net.Mail;
using ZNode.Libraries.ECommerce.Business;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;


public partial class Themes_Default_Checkout_Checkout : System.Web.UI.UserControl
{
    #region Private Variables
    protected ZNodeCheckout _checkout;
    protected ZNodeShoppingCart _shoppingCart;
    protected ZNodeUserAccount _userAccount;
    protected int ItemID = 0;
    DateTime currentdate = System.DateTime.Now.Date;
    #endregion

    #region Protected instance properties
    protected string Token
    {
        get
        {
            return this.Request.QueryString.Get("token");
        }
    }
    protected string Mode
    {
        get
        {
            return this.Request.QueryString.Get("Mode");
        }
    }
    protected string PayerId
    {
        get
        {
            return this.Request.QueryString.Get("payerid");
        }
    }
    protected string Status
    {
        get
        {
            return this.Request.QueryString.Get("status");
        }
    }
    # endregion

    #region Page Load
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //SubmitArrow.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/submit_arrow.gif";
        
       
        //registers the event for the payment (child) control
        this.uxPayment.EditAddressClicked += new EventHandler(uxPayment_EditAddressClicked);

        //get objects from session
        _shoppingCart = ZNodeShoppingCart.CurrentShoppingCart();
        _userAccount = ZNodeUserAccount.CurrentAccount();
        _checkout = new ZNodeCheckout();

        //check if shopping cart is empty
        if (_shoppingCart == null)
        {
            throw (new ApplicationException("Checkout failed since there are no items in the shopping cart."));
        }
        else
        {
            if (_shoppingCart.Count == 0)
            {
                throw (new ApplicationException("Checkout failed since there are no items in the shopping cart."));
            }
        }

        //This block enforces user logn/registration.
        //Do not allow user to go to any other checkout step unless he is logged-in        
        BindAddressControlData();


        //Check for Cancel option is selected from Paypal Site
        if (this.Status != null)
        {
            if (!Page.IsPostBack)
            {
                //set confirmation step
                uxWizard.ActiveStepIndex = 1;
                uxStepTracker.Step = 2;

                uxPayment.BindPaymentTypeData();
                uxPayment.PaymentName = ((int)PaymentTypeList.PayPal).ToString();
                uxPayment.SetPaymentControl();
                this.BindPaymentControlData();
            }

        }
        if (this.Mode != null)
        {
            ZNodeOrder order = new ZNodeOrder();
            try
            {
                ////Completes an Google Express Checkout Payment 
                ////Display order receipt
                order = (ZNodeOrder)Session["Order"] as ZNodeOrder;
               
                //set confirmation step
                uxWizard.ActiveStepIndex = 2;
                uxStepTracker.Step = 3;

                if (order != null)
                {
                    //send email
                    SendEmailReceipt(order);                    
                }

                //empty cart & logoff user
                Session.Abandon();
                FormsAuthentication.SignOut();

            }
            catch (Exception) { }
        }

        //Paypal Express Checkout - Submit Order 
        if (this.Token != null && this.PayerId != null)
        {
            ZNodeOrder order = new ZNodeOrder();
            try
            {
                //Completes an paypal Express Checkout Payment 
                GetControlData();

                _checkout.PaypalToken = Token;
                _checkout.PaypalPayerID = PayerId;

                order = _checkout.SubmitOrder();
            }
            catch (ZNodePaymentException ex)
            {
                //display payment error message
                lblError.Text = ex.Message;
                return;
            }
            catch
            {
                //display error page
                lblError.Text = "Could not submit your order. Please contact customer support.";
                return;
            }
            if (_checkout.IsSuccess)
            {
                this.OnSubmitOrder(order);
                return;
            }
            else
            {
                lblError.Text = _checkout.PaymentResponseText;

                //set confirmation step
                uxWizard.ActiveStepIndex = 1;
                uxStepTracker.Step = 2;
            }
        }

    }


    #endregion

    #region Events
    /// <summary>
    /// Event triggered when the next button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnNext(object sender, WizardNavigationEventArgs e)
    {
        //if next button was clicked on the address step then set payment billing address
        if (uxWizard.ActiveStep.ID.Equals("step1"))
        {
            //set address objects
            if (_userAccount != null)
            {
                _userAccount.CompanyName = uxAddress.BillingAddress.CompanyName;
                _userAccount.BillingAddress = uxAddress.BillingAddress;
                _userAccount.ShippingAddress = uxAddress.ShippingAddress;
            }

            BindPaymentControlData();
        }
    }

    /// <summary>
    /// Event triggered before the wizard is rendered
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnWizardPreRender(object sender, EventArgs e)
    {
        if (uxWizard.ActiveStep.ID.Equals("step1"))
        {
            uxStepTracker.Step = 1;
        }
        else if (uxWizard.ActiveStep.ID.Equals("step2"))
        {
            uxStepTracker.Step = 2;
        }
        else if (uxWizard.ActiveStep.ID.Equals("step3"))
        {
            uxStepTracker.Step = 3;
        }
    }

    /// <summary>
    /// event triggered when the submit order button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnSubmitOrder(object sender, EventArgs e)
    {
        // check if Shipping option problem
        if (!uxOrder.IsShippingOptionValid)
        {
            //display error page
            lblError.Text = "Please select different shipping option to proceed with order submission.";
            return;
        }

        //get data from user controls
        GetControlData();

        ZNodeOrder order = new ZNodeOrder();
        try
        {
            //Check for paypal gateway
            if (uxPayment.PaymentType == PaymentTypeList.PayPal)
            {
                string returnURL = Request.Url.GetLeftPart(UriPartial.Authority) + Response.ApplyAppPathModifier("checkout.aspx") + "?amount=" + _shoppingCart.Total.ToString() + "&currency=USD&status=false";
                string cancelURL = returnURL.Replace("status=false", "status=true");

                string host = _checkout.SetExpressCheckoutResponse(returnURL, cancelURL);

                if (_checkout.IsSuccess)
                {
                    Response.Redirect("https://" + host + "/cgi-bin/webscr?cmd=_express-checkout&token=" + _checkout.PaypalToken);
                }
                else
                {
                    lblError.Text = _checkout.PaymentResponseText;
                    return;
                }
            }
            else if (uxPayment.PaymentType == PaymentTypeList.Google_Checkout)
            {
                string returnURL = Request.Url.GetLeftPart(UriPartial.Authority) + Response.ApplyAppPathModifier("checkout.aspx") + "?amount=" + _shoppingCart.Total.ToString() + "&Mode=google";
                string cancelURL = returnURL.Replace("checkout.aspx", "shoppingcart.aspx");

                //Set Properties
                _checkout.ReturnURL = returnURL;
                _checkout.CancelURL = cancelURL;

                //Submit Order
                order = _checkout.SubmitOrder();

                //Put Order object into Session
                Session["Order"] = order;

                string host = _checkout.ECRedirectURL;

                if (_checkout.IsSuccess)
                {
                    Response.Redirect(host);
                }
                else
                {
                    lblError.Text = _checkout.PaymentResponseText;
                    return;
                }
            }
            else
            {
                order = _checkout.SubmitOrder();
            }

        }
        catch (ZNodePaymentException ex)
        {
            //display payment error message
            lblError.Text = ex.Message;
            return;
        }
        catch
        {
            //display error page
            lblError.Text = "Could not submit your order. Please contact customer support.";
            return;
        }
        if (_checkout.IsSuccess)
        {
            OnSubmitOrder(order);
        }
        else
        {
            lblError.Text = _checkout.PaymentResponseText;
            return;
        }

    }

    /// <summary>
    /// Edit address Event raised by the payment control - move to first step
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void uxPayment_EditAddressClicked(object sender, EventArgs e)
    {
        uxWizard.MoveTo(uxWizard.WizardSteps[0]);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    private void OnSubmitOrder(ZNodeOrder order)
    {
        //set confirmation step
        uxWizard.ActiveStepIndex = 2;
        uxStepTracker.Step = 3;

        //Reduce the QuantityAvailable by 1 if the Coupon is applied.        
        ZNode.Libraries.Admin.CouponAdmin couponcodeadmin = new ZNode.Libraries.Admin.CouponAdmin();
        ZNodeCoupon cartcoupon = _shoppingCart.ZNodeCoupon;
        ZNode.Libraries.DataAccess.Entities.Coupon _Coupon = couponcodeadmin.GetByCouponID(cartcoupon.CouponID);
        if (cartcoupon.QuantityAvailable > 0 && currentdate >= _Coupon.StartDate && currentdate <= _Coupon.ExpDate && _shoppingCart.SubTotal > _Coupon.Discount)
        {
            _Coupon.QuantityAvailable = _Coupon.QuantityAvailable - 1;
            _Coupon.CouponID = Convert.ToInt32(couponcodeadmin.Update(_Coupon));
        }
        else
        {
            //Nothing todo here
        }

        //Reduce the QuantityAvailable by 1 if the order is placed successfully.            
        //foreach (OrderLineItem items in order.OrderLineItems)
        //{
        //    if (items.ParentOrderLineItemID == null)
        //    {
        //        ZNode.Libraries.Admin.SKUAdmin SKUCodeAdmin = new ZNode.Libraries.Admin.SKUAdmin();
        //        ZNode.Libraries.DataAccess.Entities.SKU _ProductSKU = SKUCodeAdmin.GetBySKU(items.SKU);
        //        if (_ProductSKU != null)
        //        {
        //            //Subtract Oder quantity from the inverntory quantity
        //            _ProductSKU.QuantityOnHand = _ProductSKU.QuantityOnHand - items.Quantity.Value;
        //            //update into SKU table
        //            SKUCodeAdmin.Update(_ProductSKU);
        //        }
        //        else
        //        {

        //        }
        //    }
        //}
   
        //Reduce the Product add-ons quantityAvailable by 1 ,if the order is placed successfully        
        //Loop through the Order Line Items
        //foreach(ZNodeShoppingCartItem Item in _shoppingCart.ShoppingCartItems)
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

        //send email
        SendEmailReceipt(order);

        //empty cart & logoff user
        Session.Abandon();
        FormsAuthentication.SignOut();
    }

    /// <summary>
    /// Bind address
    /// </summary>
    protected void BindAddressControlData()
    {
        if (_userAccount != null)
        {
            //if no address was previously entered
            if (uxAddress.BillingAddress.FirstName.Length == 0)
            {
                uxAddress.BillingAddress = _userAccount.BillingAddress;
                uxAddress.ShippingAddress = _userAccount.ShippingAddress;
            }
        }
    }

    /// <summary>
    /// Bind data to payment control
    /// </summary>
    protected void BindPaymentControlData()
    {
        if (uxPayment.PaymentType == 0)
        {
            ZNodeCreditCardPayment CreditCardPayment = new ZNodeCreditCardPayment();
            CreditCardPayment.BillingAddress = uxAddress.BillingAddress;
						CreditCardPayment.ShippingAddress = uxAddress.ShippingAddress;
            uxPayment.Payment = CreditCardPayment;
        }
        if (uxPayment.PaymentType == PaymentTypeList.PayPal)
        {
            ZNodePaypalPayment PaypalPayment = new ZNodePaypalPayment();
            PaypalPayment.BillingAddress = uxAddress.BillingAddress;
						PaypalPayment.ShippingAddress = uxAddress.ShippingAddress;
            uxPayment.Payment = PaypalPayment;
        }
        if (uxPayment.PaymentType == PaymentTypeList.Purchase_Order)
        {
            ZNodePurchaseOrderPayment PurchaseOrdePayment = new ZNodePurchaseOrderPayment();
            PurchaseOrdePayment.BillingAddress = uxAddress.BillingAddress;
						PurchaseOrdePayment.ShippingAddress = uxAddress.ShippingAddress;
            uxPayment.Payment = PurchaseOrdePayment;
        }

    }

    /// <summary>
    /// Refreshes all the data in the checkout object using the data collected from the forms
    /// </summary>
    protected void GetControlData()
    {
        //get payment name
        _shoppingCart.PaymentName = uxPayment.PaymentName;

        //set address
        _userAccount.BillingAddress = uxAddress.BillingAddress;
        _userAccount.ShippingAddress = uxAddress.ShippingAddress;

        //set payment data in checkout object
        _checkout = uxPayment.PaymentCheckOut;
        _checkout.Payment = uxPayment.Payment;
        _checkout.Payment.BillingAddress = _userAccount.BillingAddress;
        _checkout.ShoppingCart = _shoppingCart;
        _checkout.UserAccount = _userAccount;
        _checkout.PaymentType = uxPayment.PaymentType;

    }

    /// <summary>
    /// Send Email Receipt
    /// </summary>
    private void SendEmailReceipt(ZNodeOrder order)
    {
        try
        {
            uxConfirm.Order = order;
            uxConfirm.ReceiptText = ZNodeConfigManager.MessageConfig.GetMessage("OrderReceiptText");
            uxConfirm.SiteName = ZNodeConfigManager.SiteConfig.CompanyName;
            uxConfirm.CustomerServiceEmail = ZNodeConfigManager.SiteConfig.CustomerServiceEmail;
            uxConfirm.CustomerServicePhoneNumber = ZNodeConfigManager.SiteConfig.CustomerServicePhoneNumber;
            uxConfirm.ShoppingCart = _shoppingCart;
            uxConfirm.GenerateReceipt();

            string senderEmail = ZNodeConfigManager.SiteConfig.CustomerServiceEmail;
            string recepientEmail = order.BillingAddress.EmailId;
            string subject = ZNodeConfigManager.MessageConfig.GetMessage("OrderReceiptEmailSubject");

            //get message text
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            uxConfirm.RenderControl(htw);

            string messageText = sb.ToString();

            ZNodeEmail.SendEmail(recepientEmail, senderEmail, senderEmail, subject, messageText, true);
        }
        catch (Exception ex)
        {
            //log exception
            ExceptionPolicy.HandleException(ex, "ZNODE_GLOBAL_EXCEPTION_POLICY");

            //do not rethrow as this is non-critical
        }
    }

    #endregion
}
