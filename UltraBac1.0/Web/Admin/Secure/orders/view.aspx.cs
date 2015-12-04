using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;

public partial class Admin_Secure_orders_view : System.Web.UI.Page
{
    # region Protected variables
    protected int OrderID = 0;
    protected string StatusPage = "orderstatus.aspx?itemid=";
    # endregion

    # region Page Load

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Request.Params["itemid"] != null) || (Request.Params["itemid"].Length !=0))
        {
            OrderID = int.Parse(Request.Params["itemid"].ToString());
            lblOrderHeader.Text = OrderID.ToString();
        }
        
        if (!Page.IsPostBack)
        {
            this.BindData();
            this.BindGrid();
        }

        //build the javascript block
        StringBuilder sb = new StringBuilder();
        sb.Append("<script language=JavaScript>");
        sb.Append("    function Back() {");
        sb.Append("        javascript:history.go(-1);");
        sb.Append("    }");
        sb.Append("<" + "/script>");


        if (!ClientScript.IsStartupScriptRegistered("GoBack"))
        {
            ClientScript.RegisterStartupScript(GetType(),"GoBack", sb.ToString());
        }             
        
    }
    # endregion

    # region Bind Data

    public void BindData()
    {
        # region Declarations
        OrderAdmin _OrderAdmin = new OrderAdmin();
        Order _orderList = _OrderAdmin.GetOrderByOrderID(OrderID);
        # endregion

        if (_orderList != null)
        {
            StringBuilder Build = new StringBuilder();
            Build.Append(_orderList.BillingFirstName.ToString() + " ");
            Build.Append(_orderList.BillingLastName.ToString() + "<br />");
            Build.Append(_orderList.BillingStreet.ToString() + " ");
            Build.Append(_orderList.BillingStreet1.ToString() + "<br />");
            Build.Append(_orderList.BillingCity.ToString() + ", ");
            Build.Append(_orderList.BillingCountry.ToString() + " ");
            Build.Append(_orderList.BillingPostalCode.ToString() + "<br />");
            Build.Append("Tel: "+_orderList.BillingPhoneNumber.ToString() + "<br />");
            Build.Append("Email: " + _orderList.BillingEmailId.ToString());
                
            lblBillingAddress.Text = Build.ToString();

            Build.Remove(0, Build.Length);
            Build.Append(_orderList.ShipFirstName.ToString() + " ");
            Build.Append(_orderList.ShipLastName.ToString() + "<br />");
            Build.Append(_orderList.ShipStreet.ToString() + " ");
            Build.Append(_orderList.ShipStreet1.ToString() + "<br />");
            Build.Append(_orderList.ShipCity.ToString() + ", ");
            Build.Append(_orderList.ShipCountry.ToString() + " ");
            Build.Append(_orderList.ShipPostalCode.ToString() + "<br />");
            Build.Append("Tel: " + _orderList.ShipPhoneNumber.ToString() + "<br />");
            Build.Append("Email: " + _orderList.ShipEmailID.ToString());
            
            lblShippingAddress.Text = Build.ToString();


            lblOrderID.Text = _orderList.OrderID.ToString();
            lblOrderDate.Text = _orderList.OrderDate.Value.ToShortDateString();
            lblOrderStatus.Text = this.GetOrderState(_orderList.OrderStateID);
            lblShipAmount.Text = this.Formatprice(_orderList.ShippingCost);
            lblOrderAmount.Text = this.Formatprice(_orderList.Total);
            lblTaxAmount.Text = this.Formatprice(_orderList.TaxCost);
            if (_orderList.DiscountAmount.HasValue)
                lblDiscountAmt.Text = _orderList.DiscountAmount.Value.ToString("c");
            
            if (_orderList.CouponID.HasValue)
                lblCouponCode.Text = GetCouponCode(_orderList.CouponID.Value);          

            if(_orderList.PaymentTypeId.HasValue)
            lblPaymentType.Text = GetPaymentTypeName(_orderList.PaymentTypeId.Value);

            if(_orderList.ShippingID.HasValue)
            lblShippingMethod.Text = GetShippingOptionName(_orderList.ShippingID.Value);

            //Bind custom additional instructions to label field
            lblAdditionalInstructions.Text = _orderList.AdditionalInstructions;

        }
    }

    /// <summary>
    /// Bind grid with Order line items
    /// </summary>
    private void BindGrid()
    {
          ZNode.Libraries.Admin.OrderAdmin _OrderLineItemAdmin = new ZNode.Libraries.Admin.OrderAdmin();
          uxGrid.DataSource = _OrderLineItemAdmin.GetOrderLineItemByOrderID(OrderID);
          uxGrid.DataBind();
    }
    # endregion

    # region General Events

    /// <summary>
    /// Change Status Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ChangeStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect(StatusPage + OrderID);
    }

    # endregion
    
    # region Helper Funtions

    /// <summary>
    /// 
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string Formatprice(Object FieldValue)
    {
        string Price = String.Empty;
        
        if (FieldValue != null)
        {
           Price = String.Format("{0:c}", FieldValue);
        }
        return Price;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string GetOrderState(Object FieldValue)
    {
        string OrderStatus=" ";
        if (FieldValue != null)
        {
            ZNode.Libraries.Admin.OrderAdmin _OrderStateAdmin = new ZNode.Libraries.Admin.OrderAdmin();
            OrderState _orderStateList = _OrderStateAdmin.GetByOrderStateID(int.Parse(FieldValue.ToString()));

            OrderStatus = _orderStateList.OrderStateName.ToString();
        }
        return OrderStatus;
    }

    /// <summary>
    /// Returns shipping option name for this shipping Id
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string GetShippingOptionName(int ShippingId)
    {
        string Name = "";
           
        ZNode.Libraries.Admin.ShippingAdmin shippingAdmin = new ZNode.Libraries.Admin.ShippingAdmin();
        Shipping entity = shippingAdmin.GetShippingOptionById(ShippingId);
        
        if (entity != null)
        {
            Name = entity.Description;
        }

        return Name;
    }

    /// <summary>
    /// Returns promotion code name
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string GetCouponCode(int couponId)
    {
        string Name = "";
        ZNode.Libraries.Admin.CouponAdmin couponAdmin = new ZNode.Libraries.Admin.CouponAdmin();
        Coupon entity = couponAdmin.GetByCouponID(couponId);

        if (entity != null)
        {
            Name = entity.CouponCode;
        }

        return Name;
    }

    /// <summary>
    /// Returns payment type name for this payment type id
    /// </summary>
    /// <param name="FieldValue"></param>
    /// <returns></returns>
    public string GetPaymentTypeName(int PaymentTypeId)
    {
        string Name = "";

        ZNode.Libraries.Admin.StoreSettingsAdmin settingsAdmin = new ZNode.Libraries.Admin.StoreSettingsAdmin();
        PaymentType entity = settingsAdmin.GetPaymentTypeById(PaymentTypeId);

        if (entity != null)
        {
            Name = entity.Name;
        }

        return Name;
    }

    # endregion

    # region Grid Events

    /// <summary>
    /// Order Items Grid Page Index Changing Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        uxGrid.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    # endregion
   
}
