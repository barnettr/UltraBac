<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Secure_News_Default" Title="Untitled Page" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
	<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Manage Newswire</h1></td>
			<td align="right"><asp:button CssClass="Button" id="btnAdd" CausesValidation="False" Text="Add Newsletter" Runat="server" onclick="btnAdd_Click"></asp:button></td>
		</tr>
	</table>
    <p>
    Using this section you can manage your newswire. You can add unlimited newsletters and news articles.
    </p>

	<h4>Newsletter List</h4>
    <asp:GridView ID="uxNewsletterGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxNewsletterGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxNewsletterGrid_RowCommand" Width="100%" PageSize="25" OnRowDeleting="uxNewsletterGrid_RowDeleting" AllowSorting="True" EmptyDataText="No newsletters exist in the database.">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Title" ItemStyle-Width="220" HeaderText="Title" />
            <asp:BoundField DataField="SortOrder" HeaderText="Sort Order" />
            <asp:TemplateField HeaderText="# Articles">
                <ItemTemplate>            
                <%# GetArticleCount(Eval("Articles")) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            <a class="Button" target="_blank" runat="server" href='<%# string.Format("~/newsletteremail.aspx?news={0}", Eval("ID")) %>'>View for email</a>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            <a class="Button" target="_blank" runat="server" href='<%# string.Format("~/newsletter.aspx?news={0}", Eval("ID")) %>'>View</a>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="AddArticle" Text="Add Article" ButtonType="Button">
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


