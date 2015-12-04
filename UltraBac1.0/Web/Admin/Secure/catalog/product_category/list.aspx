<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Admin_Secure_categories_search" Title="Untitled Page" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
	<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Product Categories</h1></td>
			<td align="right"><asp:button CssClass="Button" id="btnAddCategory" CausesValidation="False" Text="Add New Category"
					Runat="server" onclick="btnAddCategory_Click"></asp:button></td>
		</tr>
	</table>
    <p>Use this page to manage your product categories (ex: Gifts, Clothing, Jewellery, etc). Categories allow you to create hierarchical groupings of products so customers can
    easily find what they are looking for.</p>
	<h4>Category List</h4>    
    <asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGrid_RowCommand" Width="100%" EnableSortingAndPagingCallbacks="False" PageSize="25" OnRowDeleting="uxGrid_RowDeleting" AllowSorting="True" EmptyDataText="No categories exist in the database.">
        <Columns>
            <asp:BoundField DataField="CategoryID" HeaderText="ID" />
            <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                    <a href='add.aspx?itemid=<%# DataBinder.Eval(Container.DataItem, "CategoryId").ToString()%>'><%# GetRootCategory(DataBinder.Eval(Container.DataItem, "categoryid")) %></a>
                </ItemTemplate>                          
            </asp:TemplateField>
            <asp:BoundField DataField="DisplayOrder" HeaderText="DisplayOrder" /> 
               <asp:TemplateField HeaderText="Enabled">
                <ItemTemplate>                                
                    <img id="Img1" src='<%# ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse(DataBinder.Eval(Container.DataItem, "VisibleInd").ToString()))%>' runat="server" />
                </ItemTemplate>                          
            </asp:TemplateField>                         
            <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Button">
                <ControlStyle CssClass="Button" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button">
                <ControlStyle CssClass="Button" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle CssClass="FooterStyle"/>
        <RowStyle CssClass="RowStyle"/>                    
        <PagerStyle CssClass="PagerStyle" Font-Underline="True" />
        <HeaderStyle CssClass="HeaderStyle"/>
        <AlternatingRowStyle CssClass="AlternatingRowStyle"/>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
    </asp:GridView>	    
	<div><uc1:spacer id="Spacer2" SpacerHeight="10" SpacerWidth="10" runat="server"></uc1:spacer></div>
</asp:Content>

