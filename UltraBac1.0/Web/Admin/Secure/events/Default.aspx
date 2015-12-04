<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Secure_events_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">

<asp:Button runat="server" CssClass="Button" id="uxAddEvent" OnClick="uxAddEvent_Click" Text="Add new" />

<asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGrid_RowCommand" Width="100%" PageSize="25" OnRowDeleting="uxGrid_RowDeleting" AllowSorting="True" EmptyDataText="No events pages exist in the database.">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Title" ItemStyle-Width="370" HeaderText="Title" />
            <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:MMM %d, yyyy}" />
            <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:MMM %d, yyyy}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a class="Button" runat="server" target="_blank" href='<%# string.Format("~/event.aspx?event={0}", Eval("Id")) %>'>View</a>
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
</asp:Content>

