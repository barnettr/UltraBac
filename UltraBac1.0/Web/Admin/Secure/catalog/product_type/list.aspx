<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Admin_Secure_ProductTypes_search" Title="Untitled Page" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
	<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Product Types</h1></td>
			<td align="right"><asp:button CssClass="Button" id="btnAddProductType" CausesValidation="False" Text="Add New Product Type"
					Runat="server" onclick="btnAddProductType_Click"></asp:button></td>
		</tr>
	</table>
    <p>Use this page to manage Product Types (ex: Clothes, Shoes, etc). Product types are internal classifications used to
    create logical product groupings and apply attributes. Types are not displayed in the catalog.</p>
	<h4>
        Product Type List</h4>    
    <asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGrid_RowCommand" Width="100%" PageSize="25" OnRowDeleting="uxGrid_RowDeleting" AllowSorting="True" EmptyDataText="No Product Type exist in the database.">
        <Columns>
            <asp:BoundField DataField="producttypeid" HeaderText="ID" />
            <asp:TemplateField HeaderText="Product Type">
                <ItemTemplate>
                    <a href='add.aspx?itemid=<%# DataBinder.Eval(Container.DataItem, "ProductTypeId").ToString()%>'><%# DataBinder.Eval(Container.DataItem, "Name").ToString()%></a>
                </ItemTemplate>                          
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" />
            <asp:ButtonField CommandName="View" Text="Attributes" ButtonType="Button">
                <ControlStyle CssClass="Button" />
            </asp:ButtonField>   
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

