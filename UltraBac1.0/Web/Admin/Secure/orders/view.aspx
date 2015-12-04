<%@ Page Language="C#"  MasterPageFile="~/Admin/Themes/Standard/edit.master"  AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Admin_Secure_orders_view" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
<div class="Form">
    <table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Order# <asp:Label ID="lblOrderHeader" runat="server" Text="Label" /></h1></td>
			<td align="right">
			      <input type="button" onclick="Back();" class="Button" value="< Go Back"  style="width:100"/>
			      <asp:Button ID="ChangeStatus" CssClass="Button" runat="server" text="Change Order Status" OnClick="ChangeStatus_Click" />
            </td>
		</tr>
	</table>
	
    
        
    <h4>Order Information</h4>
    <table cellpadding="3" border="0" cellspacing="0" class="ViewForm">
        <tr class="RowStyle">
            <td class="FieldStyle">Order ID</td>
            <td class="ValueStyle">
                <asp:Label ID="lblOrderID" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Order Date</td>
            <td class="ValueField">
                <asp:Label ID="lblOrderDate" runat="server"/>
            </td>
        </tr>
        
        <tr class="RowStyle"> 
            <td class="FieldStyle">Order Status</td>
            <td class="ValueStyle">
                <asp:Label ID="lblOrderStatus" runat="server"/>
            </td>
        </tr>
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Order Amount</td>
            <td class="ValueStyle">
                    <asp:Label ID="lblOrderAmount" runat="server" />
            </td>
        </tr>
        
        <tr class="RowStyle">
            <td class="FieldStyle">Shipping Amount</td>
            <td class="ValueStyle">
                <asp:Label ID="lblShipAmount" runat="server" />
            </td>
        </tr>
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Tax Amount</td>
            <td class="ValueStyle">
                                    <asp:Label ID="lblTaxAmount" runat="server" />
            </td>
        </tr>
        
        <tr class="RowStyle">
            <td class="FieldStyle">Discount Amount</td>
            <td class="ValueStyle"><asp:Label ID="lblDiscountAmt" runat="server" /></td>
        </tr>
        
        <tr class="AlternatingRowStyle">
               <td class="FieldStyle">Coupon Code</td>
               <td class="ValueStyle"><asp:Label ID="lblCouponCode" runat="server" /></td>
        </tr>
        
        <tr class="RowStyle">
               <td class="FieldStyle">Payment Method</td>
               <td class="ValueStyle"><asp:Label ID="lblPaymentType" runat="server" /></td>
        </tr>
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Shipping Method</td>
            <td class="ValueStyle"><asp:Label ID="lblShippingMethod" runat="server" /></td>
        </tr>
    </table>
    
    <h4>Customer Information</h4>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td width="23%">
            <div class="FieldStyle">Billing Address</div>
            <div class="ValueStyle">
                    <asp:Label ID="lblBillingAddress" runat="server" Text="Label"></asp:Label></div> 
        </td>
        <td align="left" width="77%">
            <div class="FieldStyle">Shipping Address</div>
            <div class="ValueStyle">
                        <asp:Label ID="lblShippingAddress" runat="server" Text="Label"></asp:Label>
            </div>
        </td>
    </tr>     
    </table>  
         
    <h4>Order Items</h4>
    <asp:GridView ID="uxGrid" ShowFooter="true"  ShowHeader="true" CaptionAlign="Left" runat="server" ForeColor="Black" CellPadding="4"  AutoGenerateColumns="False" CssClass="Grid" Width="100%" GridLines="None" EmptyDataText="No orderline items found" AllowPaging="True" OnPageIndexChanging="uxGrid_PageIndexChanging" PageSize="5" >
        <Columns>
        <asp:BoundField DataField="Name" HeaderText="Product Name" />
        <asp:BoundField DataField="ProductNum" HeaderText="Product Code" />
        <asp:BoundField DataField="SKU" HeaderText="SKU" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:TemplateField HeaderText="Price">
        <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "price","{0:c}").ToString()%>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No orderline items found
         </EmptyDataTemplate>
           <RowStyle CssClass="RowStyle" />
           <HeaderStyle CssClass="HeaderStyle" />
           <AlternatingRowStyle CssClass="AlternatingRowStyle" />
      <FooterStyle CssClass="FooterStyle" />
        <PagerStyle CssClass="PagerStyle" />
    </asp:GridView>
    
    <h4>Additional Instructions</h4>
    <div align="justify"><asp:Label ID="lblAdditionalInstructions" runat="server"></asp:Label></div>
    
</div>
</asp:Content>

