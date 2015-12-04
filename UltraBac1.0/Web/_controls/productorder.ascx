<%@ Control Language="C#" AutoEventWireup="true" CodeFile="productorder.ascx.cs" Inherits="_controls_productorder" %>

<tr>
<td>
<%= Product.SKU %>
</td>
<td>
<asp:RegularExpressionValidator SetFocusOnError="true" ID="RegularExpressionValidator1" runat="server" 
    ForeColor=" " CssClass="Error" Display="dynamic" ControlToValidate="uxQuantity" 
    ValidationExpression="^\d{0,3}$"
    ErrorMessage="Please enter a number." ToolTip="Please enter a number." />
<h3><a href='<%= ResolveUrl(Product.ViewProductLink) %>'><%= Product.Name %></a></h3>
<p><%= Product.ShortDescription %></p>
</td>

<td><%= Product.RetailPrice.ToString("C2") %></td>
<td>
<asp:TextBox runat="server" ID="uxProductId" Visible="false" />
<asp:TextBox runat="server" MaxLength="2" ID="uxQuantity" />
</td>
</tr>