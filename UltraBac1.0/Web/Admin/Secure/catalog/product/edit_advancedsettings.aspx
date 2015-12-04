<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master"  AutoEventWireup="true" CodeFile="edit_advancedsettings.aspx.cs" Inherits="Admin_Secure_catalog_product_edit_advancedsettings" %>
<%@ Register TagPrefix="ZNode" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="ZNode" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="ZNode" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
    <div class="Form">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h1><asp:Label ID="lblTitle" runat="server" Text="Edit Advanced Settings for"></asp:Label></h1>
                    <ZNode:demomode id="DemoMode1" runat="server"></ZNode:demomode>
                </td>
                <td align="right">
                    <asp:Button ID="btnSubmitTop" runat="server" CausesValidation="True" class="Button"
                        OnClick="btnSubmit_Click" Text="SUBMIT" />
                    <asp:Button ID="btnCancelTop" runat="server" CausesValidation="False" class="Button"
                        OnClick="btnCancel_Click" Text="CANCEL" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" CssClass="Error"></asp:Label>
        <div>   
            <h4>Display Settings</h4>
            <div class="FieldStyle">Display Product?</div>
            <div class="ValueStyle"><asp:CheckBox Checked="true" ID="CheckEnabled" Text="Check this box to display this product in the storefront"  runat="server" /></div>
            
            <div class="FieldStyle">Display Order<span class="Asterix">*</span></div>
            <small>Enter a number. This determines the order in which the product will be displayed in the storefront. A product with the lower display order will be displayed first.</small>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDisplayOrder" CssClass="Error" Display="Dynamic" ErrorMessage="Enter a Display Order for this product"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDisplayOrder"
                    CssClass="Error" Display="Dynamic" ErrorMessage="You Must Enter a Valid Display Order."
                    ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
            </div>
            <div class="ValueStyle"><asp:TextBox ID="txtDisplayOrder" runat="server" MaxLength="9">500</asp:TextBox></div>
            
            <div class="FieldStyle">Home Page Special?</div>
            <div class="ValueStyle"><asp:CheckBox ID="CheckHomeSpecial" Text="Check this box if this product should be displayed on the Home Page"  runat="server" /></div>
            
            <div class="FieldStyle">Call For Pricing?</div>
            <div class="ValueStyle"><asp:CheckBox ID="CheckCallPricing" Text="Check this box if you want the customer to call you for pricing. This will disable the [Add to Cart button] "  runat="server" /></div>
            
            <div class="FieldStyle" style="display:none;">Display Inventory?</div>
            <div class="ValueStyle" style="display:none;"><asp:CheckBox ID="CheckDisplayInventory" Text="Check this box if you want the available product inventory to be displayed to the user."  runat="server" /></div>
            
            <h4>Inventory Settings</h4>
            
            <div class="FieldStyle">Out of Stock Options</div>
            <small>Select how being out of stock affects if items can be added to the cart</small>
            <div class="ValueStyle">
                <asp:RadioButtonList ID="InvSettingRadiobtnList" runat="server">
                    <asp:ListItem Selected="True" Value="1">Only Sell if Inventory Available (User can only add to cart if inventory is above 0)</asp:ListItem>
                    <asp:ListItem Value="2">Allow Back Order (Items can always be added to the cart. Inventory is reduced)</asp:ListItem>
                    <asp:ListItem Value="3">Don't Track Inventory (Items can always be added to the cart and inventory is not reduced)</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            
            <div class="FieldStyle">In Stock Message</div>
            <small>Enter a custom message that is displayed when items are in stock. If blank then no message will be displayed.</small>
            <div class="ValueStyle"><asp:TextBox ID="txtInStockMsg" runat="server"></asp:TextBox></div>
            
            <div class="FieldStyle">Out of Stock Message</div>
            <small>Enter a custom message to be displayed if this product is out of stock. If no message is entered then "Out of Stock" will be displayed.</small>
            <div class="ValueStyle"><asp:TextBox ID="txtOutofStock" runat="server">Out of Stock</asp:TextBox></div>
            
            <div class="FieldStyle">Back Order Message</div>
            <small>Enter a message to be displayed if an item is on back order. Leave blank to display nothing.</small>
            <div class="ValueStyle"><asp:TextBox ID="txtBackOrderMsg" runat="server"></asp:TextBox></div>
            
            <small>Check this box to indicate that this product is a drop ship item.</small>
            <div class="ValueStyle"><asp:CheckBox ID="chkDropShip" runat="server" Text="Drop Ship" /></div>
                    
            <h4>Shipping Settings</h4>

            <div class="FieldStyle">Select Shipping Type<span class="Asterix">*</span></div>
            <small>This setting determines the shipping rules that will be applied to this product. For ex: if you select "Flat Rate" then shipping will be calculated based on a flat rate per item.</small>
            <div class="ValueStyle"><asp:DropDownList ID="ShippingTypeList" runat="server"></asp:DropDownList></div>
            
            <div class="FieldStyle">Weight</div>
            <small>Leave blank if this does not apply. Note that the weight can be used to determine shipping cost. This is especially important for oversize items like furniture.</small>
            <div><asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtProductWeight" Type="Currency" Operator="DataTypeCheck" ErrorMessage="You must enter a valid product Weight(ex: 2.5)" CssClass="Error" Display="Dynamic" /></div>
            <div class="ValueStyle"><asp:TextBox ID="txtProductWeight" runat="server" Width="46px"></asp:TextBox> lbs</div>
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" CausesValidation="True" class="Button"
                OnClick="btnSubmit_Click" Text="SUBMIT" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" class="Button"
                OnClick="btnCancel_Click" Text="CANCEL" />
        </div>
    </div>
</asp:Content>

