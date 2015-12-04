<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Order.ascx.cs" Inherits="Themes_Default_Account_Order" %>


<h1>Order# <%=OrderNumber%></h1>

<table class="order_history">
	<tr>
		<th scope="row">Order Date:</th>
		<td><%=OrderDate%></td>
	</tr>
	<tr>
		<th scope="row">Order Total:</th>
		<td><%=OrderTotal%></td>
	</tr>
	<tr>
		<th scope="row">Bill To:</th>
		<td><%=BillingAddress%></td>
	</tr>
	<tr>
		<th scope="row">Ship To:</th>
		<td><%=ShippingAddress%></td>
	</tr>
</table>


<asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CaptionAlign="Left"  Width="100%" EnableSortingAndPagingCallbacks="False" PageSize="15" >
    <Columns>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />                    
        <asp:BoundField DataField="Name" HeaderText="Product Name" />  
          
        <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "Description") %>
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Price">
            <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>
            </ItemTemplate>                          
        </asp:TemplateField>
    </Columns>
    <FooterStyle CssClass="FooterStyle"/>
    <RowStyle CssClass="RowStyle"/>                    
    <PagerStyle CssClass="PagerStyle" />
    <HeaderStyle CssClass="HeaderStyle"/>
    <AlternatingRowStyle CssClass="AlternatingRowStyle"/>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
</asp:GridView>


<p><a id="A1" href="~/account.aspx" runat="server">&#60; back to Account Information</a></p>



