<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Admin_Secure_catalog_product_Attribute_Types_list" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Product Attributes</h1></td>
			<td align="right"><asp:button CssClass="Button" id="btnAddAttributeTypes" CausesValidation="False" Text="Add Attribute Type"
					Runat="server" onclick="btnAdd_Click"></asp:button></td>
		</tr>
	</table>
    <p>Use this page to manage product attributes (ex: Color, Size, etc). You must first create an attribute (ex: Color) and then add multiple values
    to that attribute (for example: "red", "blue", etc). You can then associate that attribute with a specific product.</p>
	<h4>Attribute List</h4>    
    
    <asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGrid_RowCommand" Width="100%" EnableSortingAndPagingCallbacks="False" PageSize="25" AllowSorting="True" EmptyDataText="No Product Attributes exist in the database.">
        <Columns>
            <asp:BoundField DataField="AttributeTypeId" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Attribute" />
            <asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" />            
            <asp:ButtonField CommandName="View" Text="View Values" ButtonType="Button">
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


