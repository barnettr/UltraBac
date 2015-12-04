<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Order.ascx.cs" Inherits="Controls_ShoppingCartCheckout_Order" %>

<div class="clear"></div>
<h2>Order Information</h2>


<asp:GridView ID="uxCart" runat="server" AutoGenerateColumns="False" EmptyDataText="Shopping Cart Empty" GridLines="None" EnableViewState="true" CssClass="shoppingcartTable">
    <Columns> 
        <asp:TemplateField HeaderText="Qty">
            <ItemStyle CssClass="shoppingcart-quantity" />
            <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "Quantity").ToString() %>
            </ItemTemplate>                   
        </asp:TemplateField>
                <asp:TemplateField>
            <ItemTemplate>                    
                <a id="A1" href='<%# DataBinder.Eval(Container.DataItem, "Product.ViewProductLink").ToString()%>' runat="server"><img id="Img1" alt="IMG1" src='<%# DataBinder.Eval(Container.DataItem, "Product.ThumbnailImageFilePath")%>' runat="server" /></a> 
            </ItemTemplate>
        </asp:TemplateField>                    
        <asp:TemplateField HeaderText="Item">
            <ItemStyle CssClass="shoppingcart-description" />
            <ItemTemplate>
                <strong class="product_name"><%# DataBinder.Eval(Container.DataItem, "Product.Name").ToString()%></strong>
                <div class="Description">
					Item# <%# DataBinder.Eval(Container.DataItem, "Product.ProductID").ToString()%> 
                	<%# DataBinder.Eval(Container.DataItem, "Product.SelectedSKU.AttributesDescription").ToString()%>
                	<%# DataBinder.Eval(Container.DataItem, "Product.AddOnDescription").ToString()%>
				</div>
            </ItemTemplate>
        </asp:TemplateField>                      
        <asp:TemplateField HeaderText="Price">
            <ItemTemplate>                    
                <%# DataBinder.Eval(Container.DataItem, "Product.FinalPrice", "{0:c}")%>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Total" HeaderStyle-CssClass="shoppingcart-total">
            <ItemStyle CssClass="shoppingcart-total" />
            <ItemTemplate>                    
                <%# (double.Parse(DataBinder.Eval(Container.DataItem, "Quantity").ToString()) * double.Parse(DataBinder.Eval(Container.DataItem, "Product.FinalPrice").ToString())).ToString("c")%>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle CssClass="Footer" />
    <HeaderStyle CssClass="Header" />
    <AlternatingRowStyle CssClass="AlternatingRow" />
</asp:GridView>

<div class="cart_total">
    <table>
	    <tr>
		    <th class="cart-total-header" scope="row">Subtotal</th>
		    <td class="shoppingcart-total"><asp:Label ID="SubTotal" runat="server" EnableViewState="false" CssClass="alignLeft"></asp:Label></td>
	    </tr>
	    <tr runat="server" visible="false">
		    <th class="cart-total-header" scope="row">Discount</th>
		    <td><asp:Label ID="Discount" runat="server" EnableViewState="false"></asp:Label></td>
	    </tr>
	    <tr>
		    <th class="cart-total-header" scope="row">Tax <asp:Label ID="TaxPct" runat="server" EnableViewState="false"></asp:Label></th>
		    <td><asp:Label ID="Tax" runat="server" EnableViewState="false"></asp:Label></td>
	    </tr>
	    <tr>
		    <th class="cart-total-header" scope="row">Shipping</th>
		    <td><asp:Label ID="Shipping" runat="server" EnableViewState="false"></asp:Label></td>
	    </tr>
	    <tr class="total">
		    <th class="cart-total-header" scope="row">Total</th>
		    <td><asp:Label ID="Total" runat="server" EnableViewState="false"></asp:Label></td>
	    </tr>                
    </table>
</div>
<div class="clear"></div>
<div class="cart_shipping_options">
	<label for="lstShipping">Shipping Option:</label> 
	<asp:DropDownList ID="lstShipping" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstShipping_SelectedIndexChanged"></asp:DropDownList>
	<asp:Literal ID="uxErrorMsg" EnableViewState="false" runat="server"></asp:Literal>
</div>

