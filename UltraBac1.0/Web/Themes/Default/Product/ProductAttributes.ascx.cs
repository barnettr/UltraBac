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
using System.Text.RegularExpressions;

public partial class Controls_ShoppingCartProduct_ProductAttributes : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeProduct _product;
    #endregion

    #region Page Load
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
        if (_product.ZNodeAttributeTypeCollection.Count > 0)
        {
            pnlOptions.Visible = true;

            foreach (ZNodeAttributeType AttributeType in _product.ZNodeAttributeTypeCollection)
            {
                System.Web.UI.WebControls.DropDownList lstControl = new DropDownList();
                lstControl.ID = "lstAttribute" + AttributeType.AttributeTypeId.ToString();

                lstControl.AutoPostBack = true;                            
                
                ListItem li = new ListItem(AttributeType.Name,"0");
                li.Selected = true;

                lstControl.SelectedIndexChanged += new EventHandler(lstControl_SelectedIndexChanged);
                lstControl.Items.Add(li);                

                foreach (ZNodeAttribute Attribute in AttributeType.ZNodeAttributeCollection)
                {
                    ListItem li1 = new ListItem(Attribute.Name, Attribute.AttributeId.ToString());

                    lstControl.Items.Add(li1);
                }

                if (!AttributeType.IsPrivate)
                {
                    Literal lit1 = new Literal();
                    lit1.Text = "<span class='Options'>";
                    ControlPlaceHolder.Controls.Add(lit1);

                    ControlPlaceHolder.Controls.Add(lstControl);

                    Literal lit2 = new Literal();
                    lit2.Text = "</span>&nbsp;";

                    ControlPlaceHolder.Controls.Add(lit2);                    
                }
            }
        }
        else
        {
            pnlOptions.Visible = false;
            return;
        }
    }
   
    #endregion

    # region General Events
     /// <summary>
    ///Event Handler for the dynamic control DropDownList
    /// </summary>
    protected void lstControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        # region Local Variables Declaration
        string Message = String.Empty;
        string ProductAttributes = String.Empty;
        string Description = String.Empty;
        ZNodeSKU _SKU = null;
        # endregion

        //validate attributes first - This is to verify that all required attributes have a valid selection
        //if a valid selection is not found then an error message is displayed
        if (this.ValidateAttributes(out Message, out ProductAttributes, out Description))
        {
            //get a sku based on attributes selected
            _SKU = ZNodeSKU.CreateByProductAndAttributes(_product.ProductID, ProductAttributes);

            _SKU.AttributesDescription = Description;
            
            //Check RetailPriceAdditional is greater than zero 
            if (_SKU.RetailPriceAdditional > 0)
            {
                //Display Additional Price message 
                (this.Parent.FindControl("AdditionalPrice") as Literal).Text = _SKU.RetailPriceAdditional.ToString("C") + " additional";                
            }

            //Check Stock level and display inventory message
            if (_SKU.QuantityOnHand > 0 )
            {
                //Display in stock message 
                (this.Parent.FindControl("lblstockmessage") as Label).Text = _product.InStockMsg;
            }
            else if (_SKU.QuantityOnHand <= 0 && (_product.AllowBackOrder))
            {
                //Display back order message 
                (this.Parent.FindControl("lblstockmessage") as Label).Text = _product.BackOrderMsg;
            }
            //Don't track inventory is enabled
            else if (_product.AllowBackOrder == false && _product.TrackInventoryInd == false)
            {
                //Display Inventory In-stock message 
                (this.Parent.FindControl("lblstockmessage") as Label).Text = _product.InStockMsg;
            }
            else if(_SKU.QuantityOnHand <= 0 && (_product.AllowBackOrder == false))
            {
                //Display Additional Price message 
                (this.Parent.FindControl("lblstockmessage") as Label).Text = _product.OutOfStockMsg;
                //Hide if selected SKU inventory level is 0
                (this.Parent.FindControl("uxAddToCart") as ImageButton).Visible = false;
                //Also, hide the additional price message box
                (this.Parent.FindControl("AdditionalPrice") as Literal).Text = "";
            }            
        }                            
        
    }
    # endregion

    #region Helper Functions
    /// <summary>
    /// Validate selected attributes and return a user message
   /// </summary>
   /// <param name="Message"></param>
   /// <param name="Attributes"></param>
   /// <returns></returns>
    public bool ValidateAttributes(out string Message, out string Attributes, out string SelectedAttributesDescription)
    {
        System.Text.StringBuilder _attributes = new System.Text.StringBuilder();
        System.Text.StringBuilder _description = new System.Text.StringBuilder();        

        //loop through types to locate the controls
        foreach (ZNodeAttributeType AttributeType in _product.ZNodeAttributeTypeCollection)
        {
            if (_attributes.Length > 0)
            {
                _attributes.Append(",");
            }

            if (!AttributeType.IsPrivate)
            {
                System.Web.UI.WebControls.DropDownList lstControl = (System.Web.UI.WebControls.DropDownList)ControlPlaceHolder.FindControl("lstAttribute" + AttributeType.AttributeTypeId.ToString());

                int selValue = int.Parse(lstControl.SelectedValue);

                if (selValue > 0)
                {
                    AttributeType.SelectedAttributeId = selValue;

                    _attributes.Append(selValue.ToString());

                    _description.Append(AttributeType.Name);
                    _description.Append(": ");
                    _description.Append(lstControl.SelectedItem.Text);
                    _description.Append("<br />");

                }
                else
                {
                    Message = "Select a valid " + AttributeType.Name;
                    Attributes = _attributes.ToString();
                    SelectedAttributesDescription = "";

                    return false;
                }
             }
        }     

        Message = "";
        Attributes = _attributes.ToString();
        SelectedAttributesDescription = _description.ToString();
        return true;
    }
    #endregion
    
}
