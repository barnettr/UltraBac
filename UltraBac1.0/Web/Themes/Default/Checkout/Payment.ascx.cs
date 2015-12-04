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
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess;
using ZNode.Libraries.DataAccess.Entities;

/// <summary>
/// Checkout Payment
/// </summary>
public partial class Controls_ShoppingCartCheckout_Payment : System.Web.UI.UserControl
{
    #region Member Variables
    private ZNodePaymentBase _payment;
    private ZNodeCheckout _CheckoutPayment;    
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (lstPaymentType.Items.Count == 0)
        {
            BindPaymentTypeData();
        }

        if (lstYear.Items.Count < 1)
        {
            BindYearList();
        }
    }
    #endregion   

    #region Public Properties
    public event System.EventHandler EditAddressClicked;

    public ZNodePaymentBase Payment
    {
        get
        {
            //check payment type            
            if (PaymentType == PaymentTypeList.PayPal)
            {
                ZNodePaypalPayment _paypalPayment = new ZNodePaypalPayment();
                _payment = _paypalPayment;
            }
            else if (PaymentType == PaymentTypeList.Google_Checkout)
            {
                ZNodeGooglePayment _googlePayment = new ZNodeGooglePayment();
                _payment = _googlePayment;
            }
            else if (PaymentType == PaymentTypeList.Credit_Card)
            {
                ZNodeCreditCardPayment _creditCardPayment = new ZNodeCreditCardPayment();
                _creditCardPayment.CardNumber = txtCreditCardNumber.Text.Trim();
                _creditCardPayment.CardExpMonth = lstMonth.SelectedValue;
                _creditCardPayment.CardExpYear = lstYear.SelectedValue;
                _creditCardPayment.CardSecurityCode = txtCVV.Text.Trim();                
                _payment = _creditCardPayment;
            }
            else if (PaymentType == PaymentTypeList.Purchase_Order)
            {
                ZNodePurchaseOrderPayment _purchaseOrderPayment = new ZNodePurchaseOrderPayment();
                _payment = _purchaseOrderPayment;
            }
            
            return _payment;
        }
        set
        {
            _payment = value;

             //credit card payment type
            if (PaymentType == PaymentTypeList.Credit_Card)
            {
                ZNodeCreditCardPayment _creditCardPayment = (ZNodeCreditCardPayment)_payment;
                lblBillingAddress.Text = _creditCardPayment.BillingAddress.ToString();
								lblShippingAddress.Text = _creditCardPayment.ShippingAddress.ToString();
            }
            else if (PaymentType == PaymentTypeList.PayPal)
            {
                ZNodePaypalPayment _paypalPayment = (ZNodePaypalPayment)_payment;
                lblBillingAddress.Text = _paypalPayment.BillingAddress.ToString();
								lblShippingAddress.Text = _paypalPayment.ShippingAddress.ToString();
            }
            else if (PaymentType == PaymentTypeList.Google_Checkout)
            {
                ZNodeGooglePayment _googlePayment = (ZNodeGooglePayment)_payment;
                lblBillingAddress.Text = _googlePayment.BillingAddress.ToString();
								lblShippingAddress.Text = _googlePayment.ShippingAddress.ToString();
            }
            else if (PaymentType == PaymentTypeList.Purchase_Order)
            {
                ZNodePurchaseOrderPayment _PurchaseOrdePayment = (ZNodePurchaseOrderPayment)_payment;
                lblBillingAddress.Text = _PurchaseOrdePayment.BillingAddress.ToString();
								lblShippingAddress.Text = _PurchaseOrdePayment.ShippingAddress.ToString();
            }
        }
    }    
    
    /// <summary>
    /// Returns the payment type selected
    /// </summary>
    public PaymentTypeList PaymentType
    {
        get 
        { 
            int _paymentTypeID = int.Parse(lstPaymentType.SelectedValue); 
            
            if(_paymentTypeID == (int)PaymentTypeList.Credit_Card)
            {
                return PaymentTypeList.Credit_Card;
            }
            else if (_paymentTypeID == (int)PaymentTypeList.PayPal)
            {
                return PaymentTypeList.PayPal;
            }
            else if (_paymentTypeID == (int)PaymentTypeList.Google_Checkout)
            {
                return PaymentTypeList.Google_Checkout;
            }
            else if (_paymentTypeID == (int)PaymentTypeList.Purchase_Order)
            {
                return PaymentTypeList.Purchase_Order;
            }

            return PaymentTypeList.Credit_Card; 
        }    
    }

    /// <summary>
    /// Returns Payment Method selected
    /// </summary>
    public string PaymentName
    {
        get
        {
            return lstPaymentType.SelectedItem.Text;
        }
        set 
        {
            lstPaymentType.SelectedValue = value;
        }
    }

    /// <summary>
    /// Returns Checkout payment 
    /// </summary>
    public ZNodeCheckout PaymentCheckOut
    {
        get
        {
            //check payment type
            if (PaymentType == PaymentTypeList.Credit_Card)
            {
                ZNodeCheckout Checkout = new ZNodeCheckout();
                Checkout.CardNumber = txtCreditCardNumber.Text.Trim();
                Checkout.CardExpYear = lstYear.SelectedValue;
                Checkout.CardExpMonth = lstMonth.SelectedValue;
                Checkout.CardSecurityCode = txtCVV.Text.Trim();
                Checkout.AdditionalInstructions = txtAdditionalInstructions.Text.Trim();
                _CheckoutPayment = Checkout;
            }
            else 
            {
                ZNodeCheckout Checkout = new ZNodeCheckout();
                Checkout.AdditionalInstructions = txtAdditionalInstructions.Text.Trim();
                _CheckoutPayment = Checkout;
            }
            return _CheckoutPayment;
        }       
        
    }
   
    #endregion
    
    #region Private Methods
    /// <summary>
    /// Binds the expiration year list based on current year
    /// </summary>
    private void BindYearList()
    {
        ListItem defaultItem = new ListItem("-- Year --","");
        lstYear.Items.Add(defaultItem);
        defaultItem.Selected = true;
        
        int currentYear = System.DateTime.Now.Year;
        int counter = 15;
           
        do
        {
          string itemtext = currentYear.ToString();

          lstYear.Items.Add(new ListItem(itemtext));

          currentYear = currentYear + 1;

          counter = counter - 1;

        } while (counter > 0);           
    }

    /// <summary>
    /// Binds the payment types
    /// </summary>
    public void BindPaymentTypeData()
    {
        ZNodeUserAccount userAccount = (ZNodeUserAccount)ZNodeUserAccount.CreateFromSession(ZNodeSessionKeyType.UserAccount);
        if (userAccount == null)
        {
            if (ZNodeUserAccount.CurrentAccount() != null)
            {
                userAccount = ZNodeUserAccount.CurrentAccount();
                Session.Add(ZNodeSessionKeyType.UserAccount.ToString(), userAccount);
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
        }

        if (lstPaymentType.Items.Count == 0)
        {
            PaymentSettingService _pmtServ = new PaymentSettingService();
            ZNode.Libraries.DataAccess.Entities.TList<PaymentSetting> _pmtSetting = _pmtServ.DeepLoadByProfileID(userAccount.ProfileID, true, DeepLoadType.IncludeChildren, typeof(ZNode.Libraries.DataAccess.Entities.PaymentType));

            _pmtSetting.Sort("DisplayOrder");
            _pmtSetting.Filter = "ActiveInd = true";

            foreach (PaymentSetting _pmt in _pmtSetting)
            {
                ListItem li = new ListItem();
                li.Text = _pmt.PaymentTypeIDSource.Name;
                li.Value = _pmt.PaymentTypeIDSource.PaymentTypeID.ToString();

                lstPaymentType.Items.Add(li);

                if (_pmt.PaymentTypeID == (int)PaymentTypeList.Credit_Card)
                {
                    imgAmex.Visible = (bool)_pmt.EnableAmex;
                    imgMastercard.Visible = (bool)_pmt.EnableMasterCard;
                    imgVisa.Visible = (bool)_pmt.EnableVisa;
                    imgDiscover.Visible = (bool)_pmt.EnableDiscover;
                }
            }

            //select first item
            if (lstPaymentType.Items.Count > 0)
            {
                lstPaymentType.Items[0].Selected = true;

                //show appropriate payment control
                SetPaymentControl();
            }
        }

    }

    /// <summary>
    /// Shows the appropriate payment control based on the option selected
    /// </summary>
    public void SetPaymentControl()
    {
        if (int.Parse(lstPaymentType.SelectedValue) == (int)PaymentTypeList.Credit_Card)
        {
            //show credit card panel
            pnlCreditCard.Visible = true;
        }
        else if(int.Parse(lstPaymentType.SelectedItem.Value) == (int)PaymentTypeList.PayPal)
        {
            //show credit card panel
            pnlCreditCard.Visible = false;
        }
        else if (int.Parse(lstPaymentType.SelectedItem.Value) == (int)PaymentTypeList.Google_Checkout)
        {
            //show credit card panel
            pnlCreditCard.Visible = false;
        }
        else if (int.Parse(lstPaymentType.SelectedValue) == (int)PaymentTypeList.Purchase_Order)
        {
            //show credit card panel
            pnlCreditCard.Visible = false;
        }
    }
    #endregion

    #region Events
    /// <summary>
    /// Payment type changed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetPaymentControl();
    }

    /// <summary>
    /// Raises the edit address event to the parent control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
		protected void lnkEditAddress_Click(object sender, EventArgs e)
    {
        if (this.EditAddressClicked != null)
        {
            this.EditAddressClicked(sender, e);
        }
    }
    #endregion
}
