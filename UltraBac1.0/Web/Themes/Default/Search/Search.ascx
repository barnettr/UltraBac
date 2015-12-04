<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Themes_Default_Search_Search" %>
<%@ Register Src="../category/ProductList.ascx" TagName="ProductList" TagPrefix="ZNode" %>


<h1>Search Catalog</h1>

<p>Use the options below to search all products in this store.</p>

<asp:Panel ID="pnlSearchCatalog" runat="server" DefaultButton="btnSearch">
	
	<asp:Literal ID="FailureText" EnableViewState="false" runat="server"/>

	<ol class="form">
		<li>
			<label for="txtKeyword">Enter Keyword</label>
			<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
			<asp:DropDownList ID="lstSearchOption" runat="server"><asp:ListItem Selected="True" Value="0">Exact Match</asp:ListItem>
			    <asp:ListItem Value="1">Match Any Keyword</asp:ListItem>
			    <asp:ListItem Value="2">Match All Keywords</asp:ListItem>
			</asp:DropDownList>
		</li>	
			
		<li>
			<label for="lstCategories">Search In Categories</label>
			<asp:DropDownList ID="lstCategories" runat="server">
			    <asp:ListItem Selected="True" Value="0">All Categories</asp:ListItem>
			</asp:DropDownList>
		</li>	
		
		<li>	
			<label for="txtSKU"><abbr>SKU</abbr> or <abbr>UPC</abbr></label>
			<asp:TextBox ID="txtSKU" runat="server"></asp:TextBox>
		</li>
		
		<li>	
			<label for="txtProductNum">Product Number</label>
			<asp:TextBox ID="txtProductNum" runat="server"></asp:TextBox>
		</li>
		
		<li class="submit">
			<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Button" OnClick="btnSearch_Click" />
			<asp:Button ID=btnClear runat="server" Text="Clear Search" CssClass="Button" OnClick="btnClear_Click" />
		</li>	
	</ol>		

</asp:Panel>


 <div class="CategoryDetail">
     <ZNode:ProductList id="uxProductList" runat="server" CssClass="ProductList" Visible="true" Title="Search Results"></ZNode:ProductList>
 </div>

