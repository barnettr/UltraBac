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
using ZNode.Libraries.Admin;

public partial class Controls_ShoppingCart : System.Web.UI.UserControl
{
    #region Private Variables
    protected ZNodeShoppingCart _shoppingCart = (ZNodeShoppingCart)ZNodeShoppingCart.CreateFromSession(ZNodeSessionKeyType.ShoppingCart);
    DateTime currentdate = System.DateTime.Now.Date;
    private ZNodeCoupon _coupon = new ZNodeCoupon();
    private ZNodeOrder _order = new ZNodeOrder();
    #endregion
    
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateTotal.ImageUrl = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/UpdateTotal.gif"; 

        lblerror.Visible = false;

        if (!Page.IsPostBack)
        {
            if (Request.Params["Mode"] != null)
            {
                ZNodeOrder order = new ZNodeOrder();

                if (Session["order"] != null)
                {
                    order = (ZNodeOrder)Session["order"] as ZNodeOrder;

                    OrderAdmin _orderAdmin = new OrderAdmin();

                    //To avoid duplicate entries of the order
                    //Delete Order Line Items
                    _orderAdmin.DeleteByOrderId(order.OrderID);

                    //Delete Order 
                    _orderAdmin.Delete(order.OrderID);

                    Session.Remove("order");
                }
            }
        }

    }
    #endregion

    #region Events
    protected override void OnPreRender(EventArgs e)
    {
     
    }    
    #endregion

    #region Bind Method

    /// <summary>
    /// Bind control display based on properties set
    /// </summary>
    public void Bind()
    {
        //bind cart
        uxCart.DataSource = _shoppingCart.ShoppingCartItems;
        uxCart.DataBind();
        ZNodeCoupon cartcoupon = _shoppingCart.ZNodeCoupon;

        //bind totals
        SubTotal.Text = _shoppingCart.SubTotal.ToString("c");     
        DiscountDisplay.Text = "-" + _shoppingCart.OrderDiscount.ToString("c");
        if (HttpContext.Current.User.Identity.Name.Length == 0)
        {
            Tax.Text = "$0";
            Shipping.Text = "$0";
         

            if (cartcoupon.DiscountTargetID == 1)// _shoppingCart.DiscountTarget.Equals("Order"))
            {
                Total.Text = _shoppingCart.Total.ToString("c");
            }
            else { Total.Text = _shoppingCart.SubTotal.ToString("c"); }
        }
        else
        {
            Tax.Text = _shoppingCart.TaxCost.ToString("c");
            Shipping.Text = _shoppingCart.ShippingDiscount.ToString("c");
            Total.Text = _shoppingCart.Total.ToString("c");
        }       
    }
    public void UpdateQuantity()
    {
        if (_shoppingCart == null)
        {
            _shoppingCart = new ZNodeShoppingCart();
            _shoppingCart.AddToSession(ZNodeSessionKeyType.ShoppingCart);
        }

        //loop through the grid rows
        foreach (GridViewRow row in uxCart.Rows)
        {
            //find the text box and get quantity
            TextBox uxQty = row.FindControl("uxQty") as TextBox;
            int Qty = int.Parse(uxQty.Text);

            HiddenField uxGUID = row.FindControl("GUID") as HiddenField;
            string GUID = uxGUID.Value;

            //Get Shopping cart item using GUID value
            ZNodeShoppingCartItem item = _shoppingCart.GetItem(GUID);
          
            //update quantity in the shopping cart manager
            if (Qty == 0)
            {
                _shoppingCart.RemoveFromCart(GUID);
            }
            else
            {
                //If Product is set to Allow back order or Track inventory is not enabled
                //then Update the quantity                
                if (item.Product.AllowBackOrder)
                {
                    //Update Quantity for this product
                    _shoppingCart.UpdateItemQuantity(GUID, Qty);
                }
                else if (item.Product.AllowBackOrder == false && item.Product.TrackInventoryInd == false)
                {
                    //Update Quantity for this product
                    _shoppingCart.UpdateItemQuantity(GUID, Qty);
                }
                else
                {
                    //Check for available quantity (which included both Available + Quantity Ordered)
                    if (UpdateQuantity(item))
                    {
                        _shoppingCart.UpdateItemQuantity(GUID, Qty);
                    }
                    else
                    {
                        uxQty.Text = item.Quantity.ToString();
                    }
                }
            }
        }

        Bind();
    }


    /// <summary>
    /// The Coupon values are Binded
    /// </summary>
    public bool BindCouponData()
    {
        bool status = true;
        //Create Instance for Coupon Admin and Coupon entity
        ZNode.Libraries.Admin.CouponAdmin couponcodeadmin = new ZNode.Libraries.Admin.CouponAdmin();
        ZNode.Libraries.DataAccess.Entities.Coupon couponbycode = couponcodeadmin.GetByCouponCode(ecoupon.Text);
        ZNodeCoupon cartcoupon = _shoppingCart.ZNodeCoupon;
        //Bind Shopping Cart Object from Current Session
        _shoppingCart = ZNodeShoppingCart.CurrentShoppingCart();
        cartcoupon.Discount = 0;
        //_shoppingCart.CouponDiscount = 0;

        if (couponbycode != null)
        {

            int DiscountTargetId = couponbycode.DiscountTargetID;
            ZNode.Libraries.DataAccess.Entities.DiscountTarget DiscountTarget = couponcodeadmin.GetByDiscountTargetID(DiscountTargetId);
            int DiscountTypeID = couponbycode.DiscountTypeID;
            ZNode.Libraries.DataAccess.Entities.DiscountType DiscountType = couponcodeadmin.GetByDiscountTypeID(DiscountTypeID);


            //Validate Coupon
            if (currentdate >= couponbycode.StartDate && currentdate <= couponbycode.ExpDate && couponbycode.QuantityAvailable > 0 && _shoppingCart.SubTotal > cartcoupon.Discount)
            {
                if (couponbycode.OrderMinimum < _shoppingCart.SubTotal)
                {
                    if (couponbycode != null)
                    {
                        ZNode.Libraries.ECommerce.Business.ZNodeCoupon couponobject = new ZNodeCoupon();
                        couponobject.CouponCode = couponbycode.CouponCode;
                        couponobject.Discount = couponbycode.Discount;
                        couponobject.StartDate = couponbycode.StartDate;
                        couponobject.ExpDate = couponbycode.ExpDate;
                        couponobject.QuantityAvailable = couponbycode.QuantityAvailable;
                        couponobject.CouponID = couponbycode.CouponID;
                        //couponobject.ProductList = couponbycode.ProductList;
                        couponobject.OrderMinimum = couponbycode.OrderMinimum;
                        couponobject.DiscountTargetID = couponbycode.DiscountTargetID;
                        couponobject.DiscountTypeID = couponbycode.DiscountTypeID;
                        _shoppingCart.ZNodeCoupon = couponobject;

                        if (DiscountTarget != null)
                        {
                            cartcoupon.DiscountTypeID = DiscountType.DiscountTypeID;
                            cartcoupon.DiscountTargetID = DiscountTarget.DiscountTargetID;

                            if (DiscountTarget.DiscountTargetName.Equals("Shipping"))
                            {
                                Shipping.Text = Convert.ToString(_shoppingCart.ShippingDiscount);
                            }
                            else if (DiscountTarget.DiscountTargetName.Equals("Order"))
                            {
                                if (_shoppingCart.ZNodeCoupon.Discount > _shoppingCart.SubTotal && cartcoupon.DiscountTypeID ==2 )
                                {
                                    cartcoupon.Discount = 0;
                                    //_shoppingCart.CouponDiscount = 0;
                                    lblerror.Visible = true;
                                    lblerror.Text = "Your current order total is not eligible for the coupon entered";
                                    return false;
                                }
                                else
                                {
                                    DiscountDisplay.Text = Convert.ToString(_order.Discount);
                                }
                            }
                        }
                    }
                    lblerror.Visible = true;
                    lblerror.Text = "Coupon applied";
                    status = true;
                }
                else if (couponbycode.OrderMinimum > _shoppingCart.SubTotal)
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Your current order is not eligible for the coupon entered";
                    status = false;
                }
                if (DiscountTarget.DiscountTargetName.Equals("Shipping"))
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Discount on shipping will be applied during checkout";
                    status = true;
                }              
            }
            else
            {
                if (couponbycode == null)
                {
                    lblerror.Visible = true;
                    lblerror.Text = "The coupon code you entered is not valid";
                    status = false;
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "The coupon code you entered is either invalid or expired";
                    status = false;
                }
            }
        }
        else
        {
            lblerror.Visible = true;
            lblerror.Text = "Coupon not found.";
            status = false;
        }

        return status;

        }
    #endregion

    #region General Events
    /// <summary>
    /// Update button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Update_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateQuantity();
    }   

    protected void btnapply_click(object sender, EventArgs e)
    {
        if (this.BindCouponData())
        {
            Total.Text = _shoppingCart.Total.ToString("c");         
            
        }
    }
    #endregion

    #region Grid Event

    /// <summary>
    /// Grid command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Cart_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        //the remove link was clicked
        if (e.CommandName.Equals("remove"))
        {
            string GUID = e.CommandArgument.ToString();

            //update in the shopping cart manager
            _shoppingCart.RemoveFromCart(GUID);
        }
    }

    #endregion

    # region HelperMethods

    /// <summary>
    /// Returns boolean value to enable Validator to check against the Quantity textbox
    /// It checks for AllowBackOrder and TrackInventory settings for this product,and returns the value
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public bool EnableStockValidator(string Value)
    {
        //Get Shopping Cart Item
        ZNodeShoppingCartItem item = _shoppingCart.GetItem(Value);

        if (item != null)
        {
            //Allow Back Order
            if (item.Product.AllowBackOrder && item.Product.TrackInventoryInd)
            {
                return false;
            }
            //Don't track inventory
            else if (item.Product.AllowBackOrder == false && item.Product.TrackInventoryInd == false)
            {
                return false;
            }
        }

        return true;

    }
    /// <summary>
    /// Returns Quantity on Hand (inventory stock value)
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public int CheckInventory(string Value)
    {
        //Get Shopping Cart Item
        ZNodeShoppingCartItem item = _shoppingCart.GetItem(Value);

        if (item != null)
        {
            //Get Current Qunatity by Subtracting QunatityOrdered from Quantity On Hand(Inventory)
            int CurrentQuantity = item.Product.QuantityOnHand - _shoppingCart.GetQuantityOrdered(item);

            if (CurrentQuantity <= 0)
            {
                return 0;
            }
            else
            {
                return CurrentQuantity;
            }
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// Check for Qunatity ordered against Quantity On Hand
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private bool UpdateQuantity(ZNodeShoppingCartItem item)
    {
        ZNodeShoppingCartItem _ShoppingCartItem = null;

        int QunatityOrdered = 0;
        //loop through the grid rows
        foreach (GridViewRow row in uxCart.Rows)
        {
            //find the text box and get quantity
            TextBox uxQty = row.FindControl("uxQty") as TextBox;
            int Qty = int.Parse(uxQty.Text);

            //find the hidden form field and get product GUID
            HiddenField uxGUID = row.FindControl("GUID") as HiddenField;
            string GUID = uxGUID.Value;

            //Get the item using GUID
            _ShoppingCartItem = _shoppingCart.GetItem(GUID);

            //If product is removed or update with 0,then this object is set to null.
            //(Above GetItem() method will return the value for this object)
            if (_ShoppingCartItem != null) 
            {
                //Match Product
                if (item.Product.ProductID == _ShoppingCartItem.Product.ProductID)
                {
                    //Check Product has attributes or not 
                    if (item.Product.ZNodeAttributeTypeCollection.Count > 0)
                    {
                        //If Product has attributes then check for SKUID
                        if (item.Product.SelectedSKU.SKUID == _ShoppingCartItem.Product.SelectedSKU.SKUID)
                        {
                            QunatityOrdered += Qty;
                        }
                    }
                    //Product has no attributes
                    else
                    {
                        //Increment QuantityOrdered value
                        QunatityOrdered += Qty;
                    }
                }
            }
        }

        //Check Qunatity on hand is greater than Qunatity Ordered value
        if (item.Product.QuantityOnHand < QunatityOrdered)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    # endregion
   
}
    
