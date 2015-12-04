<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteMap.ascx.cs" Inherits="Themes_Default_SiteMap_SiteMap" %>
<%@ Register Src="../category/NavigationCategories.ascx" TagName="NavigationCategories" TagPrefix="ZNode" %>


<h1>Site Map</h1>
<div id="sitemap">
	<h3>Pages</h3>
	<asp:Repeater ID="uxRep" runat="server">
		<HeaderTemplate>
			<ul id="pages">
		</HeaderTemplate>
		<ItemTemplate>
			<li class="<%# GetDepth(Container.DataItem) %>"><a runat="server" href='<%# string.Format("~/content.aspx?page={0}", Eval("Name")) %>'>
			<%# Eval("Title") %></a> </li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
	<h3>Products</h3>
	<asp:Repeater runat="server" ID="uxProds">
		<HeaderTemplate>
			<ul id="products">
		</HeaderTemplate>
		<ItemTemplate>
			<li><a runat="server" href='<%# Eval("ViewProductLink") %>'><%# Eval("Name") %></a></li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
	<%--<asp:GridView runat="server" ID="uxProds" AutoGenerateColumns="true" />--%>
</div>