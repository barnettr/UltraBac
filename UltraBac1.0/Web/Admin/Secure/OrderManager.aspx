<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="OrderManager.aspx.cs" Inherits="Admin_OrderManager" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <h1>Manage Sales</h1>
    <p>Use the links in this section to manage your accounts, orders and service requests.</p>
    
    <div class="LandingPage">
        <hr />
        
        <div class="Shortcut"><a id="A2" href="~/admin/secure/orders/list.aspx" runat="server">Orders</a></div>
        <p>Search orders using various criteria. You can then view details of each order and change it's status.</p>
        
        <div class="Shortcut"><a id="A4" href="~/admin/secure/customers/list.aspx" runat="server">Accounts</a></div>
        <p>Search through accounts (customer, dealers, vendors, etc). You can also view the order history and add customer service notes for each account.</p>
        
        <div class="Shortcut"><a id="A1" href="~/admin/secure/cases/list.aspx" runat="server">Service Requests</a></div>
        <p>Service Requests are support requests submitted by your customers using the Contact-Us form on your website. You 
        can search through customer service requests and respond to them directly using the admin.</p>        

    </div>
</asp:Content>

