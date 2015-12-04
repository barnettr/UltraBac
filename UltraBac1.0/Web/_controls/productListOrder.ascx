<%@ Control Language="C#" AutoEventWireup="true" CodeFile="productListOrder.ascx.cs" Inherits="_controls_productListOrder" %>
<%@ Register Src="~/_controls/productorder.ascx" TagName="ProductOrder" TagPrefix="pop" %>
<%@ Import Namespace="ZNode.Libraries.ECommerce.Business" %>
<asp:Repeater runat="server" ID="uxProducts" >
<HeaderTemplate>
<h2><%# Category.Title %></h2>
		<table class="product-order-form" class="tabular" summary="<%# Category.Title %>">
			<thead>
			<tr>
				<th class="sku">SKU</th>
				<th class="item">Item Name</th>
				<th class="pricing">Pricing</th>
				<th class="quantity">Quantity</th>
			</tr>
			</thead>
			<tbody>
</HeaderTemplate>
<FooterTemplate>
			</tbody>
		</table>		
</FooterTemplate>
	<ItemTemplate>
		<pop:ProductOrder Product='<%# Container.DataItem as ZNodeProduct %>' runat="server" />
	</ItemTemplate>
</asp:Repeater>