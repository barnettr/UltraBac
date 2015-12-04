<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Account.ascx.cs" Inherits="Themes_Default_Account_Account" %>


    <h1>Account Information</h1>
    
	<p>Use this page to edit your profile and view order history.</p>
    

	<h2>Your Login</h2>
	
<asp:LoginName ID="LoginName1" runat="server" FormatString="You are Logged in as <b>{0}</b>" />
<asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="Button" OnClick="btnChangePassword_Click" />


<h3>Contact Information</h3>

<asp:Button ID="btnEditAddress" runat="server" Text="Edit Contact Information" CssClass="Button" OnClick="btnEditAddress_Click" />

<div class="columns_2">

	<div class="column1">
		<h4>Billing Address:</h4>
		<%= BillingAddress %>
	</div>
	
	<div class="column2">
		<h4>Shipping Address:</h4>
		<%= ShippingAddress %>
	</div>	
	
	<div class="clear"></div>
<!-- /columns_2 --></div>

<div class="hr"></div>
	
	
<h3>Order History</h3>

<asp:GridView Width="100%" ID="uxGrid" runat="server" AutoGenerateColumns="False" EmptyDataText="No orders to show" GridLines="None" CellPadding="4" EnableViewState="true" OnRowCommand="uxGrid_RowCommand" CssClass="Grid">
    <Columns> 
        <asp:BoundField DataField="OrderID" HeaderText="Order#" />
        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />

        <asp:TemplateField HeaderText="Status">               
            <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "OrderStateIDSource.OrderStateName")%>
            </ItemTemplate>                   
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Customer's Name">
            <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "BillingFirstName").ToString() + " " + DataBinder.Eval(Container.DataItem, "BillingLastName").ToString()%>
            </ItemTemplate>                          
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Cost">               
            <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "Total", "{0:c}")%>
            </ItemTemplate>                   
        </asp:TemplateField> 
         <asp:ButtonField CommandName="View" Text="View" ButtonType="Button" >
            <ControlStyle CssClass="Button" />
        </asp:ButtonField>                        
    </Columns>
    <FooterStyle CssClass="FooterStyle"/>
    <RowStyle CssClass="RowStyle"/>                    
    <PagerStyle CssClass="PagerStyle" />
    <HeaderStyle CssClass="HeaderStyle"/>
    <AlternatingRowStyle CssClass="AlternatingRowStyle"/>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />            
</asp:GridView>


