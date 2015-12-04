<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.ascx.cs" Inherits="Controls_ShoppingCart" %>

<%--Coupons are disabled with this version--%>
<div class="formBox shoppingcart-apply" runat="server" visible="false">
    <div class="lt formCorner"></div>
    <div class="rt formCorner"></div>
    <div class="formBox-content" >
	    <label for="ecoupon">Apply Coupon</label> 
	    <asp:TextBox CssClass="text" ID="ecoupon" runat="server" MaxLength="15" Width="70px"></asp:TextBox>
	    <asp:ImageButton ID="ApplyCouponGo" CssClass="gobutton" ImageUrl="~/_img/buttons/btn-sidebar-go.gif" runat="server" AlternateText="Apply" OnClick="btnapply_click" />
    </div>
    <div class="lb formCorner"></div>
    <div class="rb formCorner"></div> 
</div>   
<div class="shoppingcart-update">
    <asp:ImageButton ID="UpdateTotal" runat="server" AlternateText="Update Total" OnClick="Update_Click" />
</div>
<div class="clear"></div>
<div id="shoppingcart-wrap">
<asp:GridView class="shoppingcartTable tabular" ID="uxCart" runat="server" AutoGenerateColumns="False" EmptyDataText="Shopping Cart Empty" GridLines="None" EnableViewState="true" OnRowCommand="Cart_RowCommand" >
    <Columns> 
        <asp:TemplateField HeaderText="Quantity">  
            <ItemStyle CssClass="shoppingcart-quantity" />             
            <ItemTemplate>
                
                <asp:TextBox ID="uxQty" runat="server" Enabled="true" MaxLength="5" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity").ToString() %>' Columns="1" CssClass="Quantity text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="req1" ControlToValidate="uxQty" ErrorMessage="*required" runat="server" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationExpression="^\d+$" ID="val1" ControlToValidate="uxQty" ErrorMessage="*invalid" runat="server" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                    
                <asp:RangeValidator ID="RangeValidator1" MinimumValue="0" ControlToValidate="uxQty" ErrorMessage="*OutofStock" MaximumValue='<%# CheckInventory(DataBinder.Eval(Container.DataItem, "GUID").ToString()) %>' Display="Dynamic" Enabled='<%# EnableStockValidator(DataBinder.Eval(Container.DataItem, "GUID").ToString()) %>' SetFocusOnError="true" runat="server" Type="Integer"></asp:RangeValidator>
                <asp:HiddenField ID="GUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GUID").ToString() %>' />
            </ItemTemplate>                   
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Remove">
            <ItemTemplate>                    
                <asp:LinkButton ID="lnkDelete" runat="server" Text="Remove this Item" CommandName="remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "GUID").ToString() %>'></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Wrap="True" />
        </asp:TemplateField>   
        
        <asp:TemplateField>
            <ItemTemplate>                    
                <a id="A1" href='<%# DataBinder.Eval(Container.DataItem, "Product.ViewProductLink").ToString()%>' runat="server"><img id="Img1" alt="IMG1" src='<%# DataBinder.Eval(Container.DataItem, "Product.ThumbnailImageFilePath")%>' runat="server" /></a> 
            </ItemTemplate>
        </asp:TemplateField>                 
        <asp:TemplateField HeaderText="Item">
            <ItemStyle CssClass="shoppingcart-description" />
            <ItemTemplate>                    
                <div><a id="A2" href='<%# DataBinder.Eval(Container.DataItem, "Product.ViewProductLink").ToString()%>' runat="server"><%# DataBinder.Eval(Container.DataItem, "Product.Name").ToString()%></a></div>
                <div>
					Item# <%# DataBinder.Eval(Container.DataItem, "Product.ProductNum").ToString()%>
					<br />
					<%# DataBinder.Eval(Container.DataItem, "Product.SelectedSKU.AttributesDescription").ToString()%><%# DataBinder.Eval(Container.DataItem, "Product.AddOnDescription").ToString()%>
					</div>                     
            </ItemTemplate>
        </asp:TemplateField>                                 
        <asp:TemplateField HeaderText="Price">
            <ItemTemplate>                    
                <%# DataBinder.Eval(Container.DataItem, "Product.FinalPrice", "{0:c}")%>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Total">
            <ItemTemplate>                    
                <%# (double.Parse(DataBinder.Eval(Container.DataItem, "Quantity").ToString()) * double.Parse(DataBinder.Eval(Container.DataItem, "Product.FinalPrice").ToString())).ToString("c")%>
            </ItemTemplate>
             <ItemStyle HorizontalAlign="Right" />
             <HeaderStyle HorizontalAlign="Right" CssClass="shoppingcart-total"/>
        </asp:TemplateField>
    </Columns>
    <FooterStyle CssClass="Footer" />
    <RowStyle CssClass="Row" />
    <HeaderStyle CssClass="Header" />
    <AlternatingRowStyle CssClass="AlternatingRow" />            
</asp:GridView>
<div class="cart_total">
    <table class="tabular">
        <tr>
            <th scope="row" class="cart-total-header">Subtotal</th>
            <td><asp:Label ID="SubTotal" runat="server"></asp:Label></td> 
        </tr>
        <tr runat="server" visible="false">
            <th scope="row" class="cart-total-header">Discount</th>
            <td><asp:Label ID="DiscountDisplay" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th scope="row" class="cart-total-header">* Tax</th>
            <td><asp:Label ID="Tax" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th scope="row" class="cart-total-header">* Shipping</th>
            <td><asp:Label ID="Shipping" runat="server"></asp:Label></td>
        </tr>
        <tr class="total">
            <th scope="row" class="cart-total-header">Total</th>
            <td><asp:Label ID="Total" runat="server"></asp:Label></td>
        </tr>          
    </table>
</div>
<div class="clear"></div>
</div><!-- shopping cart wrap -->





<div>
	<asp:Label ID="lblerror" CssClass="Error" runat="server"></asp:Label>
</div>

