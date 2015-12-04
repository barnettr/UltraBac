<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Secure_settings_tax_Default" Title="Untitled Page" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
	<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Tax Settings</h1></td>
			<td align="right"><asp:button CssClass="Button" id="btnAdd" CausesValidation="False" Text="Add Tax Rule"
					Runat="server" onclick="btnAdd_Click"></asp:button></td>
		</tr>
	</table>
    <p>
    Tax Rules are applied in the order of precedence. <b>For Example</b>, to implement a tax rule <br />to apply 5% tax 
    to residents of Alaska and 6.5% for all other US States do the following:<br />
    <li>Add a rule with Country=US, State=AK, Tax=5%, Precedence=1</li>
    <li>Add a second rule with Country=US, State=ALL States, Tax=6.5%, Precedence=2</li> 
    </p>
    <br /><br />
	<h4>Tax Settings List</h4>    
    <asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGrid_RowCommand" Width="100%" PageSize="25" OnRowDeleting="uxGrid_RowDeleting" AllowSorting="True" EmptyDataText="No tax rules exist in the database.">
        <Columns>
            <asp:BoundField DataField="TaxRuleID" HeaderText="ID" />         
            <asp:TemplateField HeaderText="Tax Rate">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "TaxRate").ToString()%>%
                </ItemTemplate>                          
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Country Code">
                <ItemTemplate>
                    <%# GetDefaultRegionCode(DataBinder.Eval(Container.DataItem, "DestinationCountryCode"))%>
                </ItemTemplate>                          
            </asp:TemplateField>
            <asp:TemplateField HeaderText="State Code">
                <ItemTemplate>
                    <%# GetDefaultRegionCode(DataBinder.Eval(Container.DataItem, "DestinationStateCode"))%>
                </ItemTemplate>                          
            </asp:TemplateField>

            <asp:BoundField DataField="Precedence" HeaderText="Precedence" />
                        
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


