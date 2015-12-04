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
using ZNode.Libraries.ECommerce.Business;

public partial class Controls_ProductAddOns : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeProduct _product;
    #endregion    

    # region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        //retrieve product object from HttpContext (set previously in the page_preinit event of the page)
        _product = (ZNodeProduct)HttpContext.Current.Items["Product"];
        Bind();
    }
    #endregion

    #region Bind Data
    /// <summary>
    /// Bind control display based on properties set
    /// </summary>
    public void Bind()
    {
        if (_product.ZNodeAddOnCollection.Count > 0)
        {
             pnlAddOns.Visible = true;

             ControlsPlaceHolder.Controls.Add(new LiteralControl("<div class='OptionsLabel'> <table>"));

             foreach (ZNodeAddOn AddOn in _product.ZNodeAddOnCollection)
             {
                System.Web.UI.WebControls.DropDownList lstControl = new DropDownList();
                lstControl.ID = "lstAddOn" + AddOn.AddOnID.ToString();


                //Don't display list box if there is no add-on values for AddOns
                if (AddOn.ZNodeAddOnValueCollection.Count > 0)
                {
                    foreach (ZNodeAddOnValue AddOnValue in AddOn.ZNodeAddOnValueCollection)
                    {
                        string AddOnValueName = AddOnValue.Name;

                        if (AddOnValue.RetailPriceAdditional > 0)
                        {
                            AddOnValueName += " - " + AddOnValue.RetailPriceAdditional.ToString("c");
                        }

                        //Added Inventory Message with the Addon Value Name in the dropdownlist
                        AddOnValueName += " " + BindStatusMsg(AddOn, AddOnValue);

                        ListItem li1 = new ListItem(AddOnValueName, AddOnValue.AddOnValueID.ToString());
                        lstControl.Items.Add(li1);

                        if (AddOnValue.IsDefault)
                        {
                            lstControl.SelectedValue = AddOnValue.AddOnValueID.ToString();
                        }
                    }

                    if (AddOn.OptionalInd)
                    {
                        ListItem OptionalItem = new ListItem("Optional", "0");                        
                        lstControl.Items.Insert(0,OptionalItem);
                        lstControl.SelectedValue = "0";
                    }     
                    
                        
                    //Add controls to the place holder
                    Literal lit1 = new Literal();
                    lit1.Text = "<tr><td class='FieldStyle'>" + AddOn.Title + "</td><td class='ValueStyle'>";
                    
                    ControlsPlaceHolder.Controls.Add(lit1);
                    ControlsPlaceHolder.Controls.Add(lstControl); // Dropdown list control

                    Literal lit3 = new Literal();
                    lit3.Text = "</td></tr>";

                    ControlsPlaceHolder.Controls.Add(lit3);
                }
             }

             ControlsPlaceHolder.Controls.Add(new LiteralControl("</table></div>"));
             
        }
        else
        {
            pnlAddOns.Visible = false;
            return;
        }
    }
     #endregion    

    # region Helper  methods
    /// <summary>
    /// Validate selected attributes and return a user message
   /// </summary>
   /// <param name="Message"></param>
   /// <param name="Attributes"></param>
   /// <returns></returns>
    public bool ValidateAddOns(out string Message,out string AddOnValues, out string SelectedAddonDescription)
    {
       System.Text.StringBuilder _description = new System.Text.StringBuilder();
       System.Text.StringBuilder _addonValues = new System.Text.StringBuilder();

       foreach (ZNodeAddOn AddOn in _product.ZNodeAddOnCollection)
       {
           System.Web.UI.WebControls.DropDownList lstCtrl = new DropDownList();

           lstCtrl = (System.Web.UI.WebControls.DropDownList)ControlsPlaceHolder.FindControl("lstAddOn" + AddOn.AddOnID.ToString());

           if (_addonValues.Length > 0)
           {
               _addonValues.Append(",");
           }

           //Loop through the Add-on values for each Add-on
           foreach (ZNodeAddOnValue AddOnValue in AddOn.ZNodeAddOnValueCollection)
           {               
               //Optional Addons are not selected,then leave those addons 
               //If optinal Addons are selected, it should add with the Selected item 
               if (AddOnValue.AddOnValueID.ToString() == lstCtrl.SelectedValue) //Check for Selected Addon value 
               {
                   //Check for quantity on hand and back-order,track inventory settings
                   if (AddOnValue.QuantityOnHand <= 0 && AddOn.AllowBackOrder == false && AddOn.TrackInventoryInd)
                   {
                       Message = "A Required Add-On \'" + AddOn.Title + "\' is out of stock";
                       SelectedAddonDescription = "";
                       AddOnValues = "";
                       return false;
                   }
                   
                   //Add to Selected Addon list for this product
                   _addonValues.Append(AddOnValue.AddOnValueID.ToString());
                                      
                   //Set meta data to display on the shopping cart
                   _description.Append(AddOn.Title);
                   _description.Append(" : ");
                   _description.Append(lstCtrl.SelectedItem.Text);
                   _description.Append("<br />");
                   
               }
           }
       }

       Message="";
       AddOnValues = _addonValues.ToString();
       SelectedAddonDescription = _description.ToString();
       return true;
    }

    /// <summary>
    /// validate selected addons and returns the Inventory related messages
    /// </summary>
    protected string BindStatusMsg(ZNodeAddOn AddOn, ZNodeAddOnValue AddOnValue)
    {
        //If quantity available is less and track inventory is enabled
        if (AddOnValue.QuantityOnHand <= 0 && AddOn.AllowBackOrder == false && AddOn.TrackInventoryInd)
        {
            return AddOn.OutOfStockMsg;                    
        }
        else if (AddOnValue.QuantityOnHand <= 0 && AddOn.AllowBackOrder == true && AddOn.TrackInventoryInd)
        {
            return AddOn.BackOrderMsg;                    
        }
        else if (AddOn.TrackInventoryInd && AddOnValue.QuantityOnHand > 0)
        {
            return AddOn.InStockMsg;                    
        }
        //Don't track Inventory
        //Items can always be added to the cart,TrackInventory is disabled
        else if (AddOn.AllowBackOrder == false && AddOn.TrackInventoryInd == false)
        {
            return AddOn.InStockMsg;
        }

        return string.Empty;
         
    }
    #endregion

}
