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

public partial class Admin_Secure_catalog_coupons_add : System.Web.UI.Page
{
    # region Protected Member Variables
    protected int ItemID = 0;
    # endregion
    
    # region Page Load Event
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Request.Params["ItemID"] != null)
        {
            ItemID = int.Parse(Request.Params["ItemID"].ToString());
        }
        if (!Page.IsPostBack)
        {
            if (ItemID > 0)
            {
                this.BindData();
                this.BindEditDatas();
                lblTitle.Text = "Edit Coupon";                
            }
            else
            {
                this.BindData();
                lblTitle.Text = "Add Coupon";  
            }
            
            //Call Client Side script Block
            this.RegisterClientScript();
            
            //Add a JavaScript event listner
            ImageDt1.Attributes.Add("onclick", "displayCalendar(document.forms[0]." + StartDate.ClientID + ",'mm/dd/yyyy',document.forms[0]." + ImageDt1.ClientID + ")");
            ImageDt2.Attributes.Add("onclick", "displayCalendar(document.forms[0]." + ExpDate.ClientID + ",'mm/dd/yyyy',document.forms[0]." + ImageDt2.ClientID + ")");          
        }
        
    }
    #endregion

    # region Client Side Script

    /// <summary>
    /// 
    /// </summary>
    public void RegisterClientScript()
    {
        //Include the Client Side Script from the resource file
        //The Resource File is named “Calender.js”
        //Located inside the Calendar directory
        HtmlGenericControl Include = new HtmlGenericControl("script");
        Include.Attributes.Add("type", "text/javascript");
        Include.Attributes.Add("src", "Calendar/Calendar.js");


        //The Resource File is named “Calender.css”
        //Located inside the Calendar directory
        HtmlGenericControl Include1 = new HtmlGenericControl("link");
        Include1.Attributes.Add("type", "text/css");
        Include1.Attributes.Add("rel", "stylesheet");
        Include1.Attributes.Add("href", "Calendar/Calendar.css");

        //add a script reference for Javascript to the head section
        this.Page.Header.Controls.Add(Include);
        this.Page.Header.Controls.Add(Include1);

    }

    # endregion

    #region Bind Method

    public void BindEditDatas()
    {
        ZNode.Libraries.Admin.CouponAdmin couponadmin = new ZNode.Libraries.Admin.CouponAdmin();
        ZNode.Libraries.DataAccess.Entities.Coupon getcoupon = couponadmin.GetByCouponID(ItemID);        
        CouponCode.Text = getcoupon.CouponCode;   
        Discount.Text = getcoupon.Discount.ToString();
        StartDate.Value = getcoupon.StartDate.ToShortDateString();
        ExpDate.Value = getcoupon.ExpDate.ToShortDateString();        
        DiscountType.SelectedValue = getcoupon.DiscountTypeID.ToString();
        DiscountTarget.SelectedValue = getcoupon.DiscountTargetID.ToString();
        Quantity.Text = getcoupon.QuantityAvailable.ToString();
        OrderMinimum.Text = Convert.ToString(Math.Round(getcoupon.OrderMinimum, 2));        
    }

    public void BindData()
    {   
        //Bind DiscountTypeName
        ZNode.Libraries.Admin.CouponAdmin Discountname = new ZNode.Libraries.Admin.CouponAdmin();
        DiscountType.DataSource = Discountname.GetAllDiscountTypes();
        DiscountType.DataTextField = "DiscountTypeName";
        DiscountType.DataValueField = "DiscountTypeID";
        DiscountType.DataBind();     
   
        //Bind DiscountTarget
        ZNode.Libraries.Admin.CouponAdmin Discounttarget = new ZNode.Libraries.Admin.CouponAdmin();
        DiscountTarget.DataSource = Discounttarget.GetAllDiscountTarget();
        DiscountTarget.DataTextField = "DiscountTargetName";
        DiscountTarget.DataValueField = "DiscountTargetID";
        DiscountTarget.DataBind();
    }

    #endregion

    #region General Events
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ZNode.Libraries.Admin.CouponAdmin couponadmin = new ZNode.Libraries.Admin.CouponAdmin();
        ZNode.Libraries.DataAccess.Entities.Coupon getcoupon = null;
        if (ItemID > 0)
        {
            getcoupon = couponadmin.GetByCouponID(ItemID);
            getcoupon.CouponID= ItemID;
        }        
        else        
        {
            getcoupon = new ZNode.Libraries.DataAccess.Entities.Coupon();
        }
        getcoupon.CouponCode = CouponCode.Text;       

       //DiscountTypeName
        if(DiscountType.SelectedIndex != -1)        
        {
            getcoupon.DiscountTypeID = Convert.ToInt32(DiscountType.SelectedValue);
        }
        if (DiscountType.SelectedItem.Text == "Percentage")
        {
            if (Convert.ToDecimal(Discount.Text) > 100)
            {
                lblerror1.Text = "A percentage Discount cannot be greater than 100%";
                return;
            }
        }

        //DiscountTarget
        if (DiscountTarget.SelectedIndex != -1)
        {
            getcoupon.DiscountTargetID = Convert.ToInt32(DiscountTarget.SelectedValue);
        }
        
        getcoupon.Discount = Convert.ToDecimal(Discount.Text);
        getcoupon.StartDate = Convert.ToDateTime(StartDate.Value.Trim());
        getcoupon.ExpDate = Convert.ToDateTime(ExpDate.Value.Trim());
        getcoupon.QuantityAvailable =int.Parse(Quantity.Text);
        getcoupon.OrderMinimum = Convert.ToDecimal(OrderMinimum.Text);        

        bool check = false;

        if (ItemID > 0)
        {
            check = couponadmin.Update(getcoupon);
        }
        else
        {
            check = couponadmin.Insert(getcoupon);
        }

        if (check)
        {
           Response.Redirect("list.aspx");
        }
        else
        {
           lblError.Text = "An error occurred while updating. Please try again.";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }
    #endregion
}
