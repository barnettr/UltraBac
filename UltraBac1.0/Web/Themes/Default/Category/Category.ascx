<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Category.ascx.cs" Inherits="Themes_Default_Category_Category" %>
<%@ Register Src="ProductList.ascx" TagName="CategoryProductList" TagPrefix="ZNode" %>
<%@ Register Src="SubCategoryList.ascx" TagName="SubCategoryList" TagPrefix="ZNode" %>

 <div class="CategoryDetail">
    <div class="Title"><asp:Label ID="CategoryTitle" runat="server"></asp:Label></div> 
    <div class="Description"><asp:Label ID="CategoryDescription" runat="server"></asp:Label></div> 
    <ZNode:CategoryProductList id="uxCategoryProductList" runat="server" CssClass="ProductList" Visible="true" Title="Products"></ZNode:CategoryProductList>
    <ZNode:SubCategoryList id="uxSubCategoryList" runat="server" CssClass="SubCategoryList" Visible="true" Title="Categories"></ZNode:SubCategoryList>       
</div> 