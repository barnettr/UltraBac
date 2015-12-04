<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master"  AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Admin_Secure_catalog_product_manufacturer_list" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Manufacturers</h1></td>
			<td align="right" style="width: 371px"><asp:button CssClass="Button" id="btnAddManufacturer" CausesValidation="False" Text="Add Manufacturer"
					Runat="server" onclick="btnAddManufacturer_Click"></asp:button></td>
		</tr>
	</table>
	<p>Use this page to manage the different brands in your database. You can then associate products with a particular brand.</p>
<h4>
        Manufacturers List</h4>  
         <asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGrid_RowCommand" Width="100%" PageSize="25" OnRowDeleting="uxGrid_RowDeleting" AllowSorting="True" EmptyDataText="No Product Type exist in the database.">
        <Columns>
            <asp:BoundField DataField="manufacturerid" HeaderText="ID" />
            
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <a href='add.aspx?itemid=<%# DataBinder.Eval(Container.DataItem, "Manufacturerid").ToString()%>'><%# DataBinder.Eval(Container.DataItem, "Name").ToString()%></a>
                </ItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Is Active?">
                  <ItemTemplate>                                
                    <img id="Img1" alt="" src='<%# ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse(DataBinder.Eval(Container.DataItem, "ActiveInd").ToString()))%>' runat="server" />
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
	 <asp:Label ID="lblError" runat="server" CssClass="Error"></asp:Label> 
</asp:Content>


