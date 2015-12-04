<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="SettingsManager.aspx.cs" Inherits="Admin_SettingsManager" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <h1>Manage Settings</h1>
    <p>Use the links in this section to manage global storefront settings</p>
    
    <div class="LandingPage">
        <hr />
        
        <div class="Shortcut"><span class="Icon"><a id="A1" href="~/admin/secure/settings/general/default.aspx" runat="server">Global Settings</a></div>
        <p>Use the global settings to manage settings like store contact information, SMTP settings, catalog display settings, etc</p>
        

        <div class="Shortcut"><span class="Icon"><a id="A4" href="~/admin/secure/settings/payment/default.aspx" runat="server">Payment Options</a></div>
        <p>Add and configure payment options such as credit cards, purchase orders and PayPal. </p>
        

        <div class="Shortcut"><span class="Icon"><a id="A6" href="~/admin/secure/settings/shipping/default.aspx" runat="server">Shipping Options</a></div>
        <p>Add custom shipping options and rules to your storefront. You can also configure these options to retrieve shipping rates from UPS.</p>
        

        <div class="Shortcut"><span class="Icon"><a id="A7" href="~/admin/secure/settings/taxes/default.aspx" runat="server">Tax Options</a></div>
        <p>Configure tax settings & rules based on the customer's destination country and state.</p>
        
        <%--<div class="Shortcut"><a id="A11" href="~/admin/secure/catalog/coupons/list.aspx" runat="server">Coupons</a></div>
        <p>Use coupons to create product promotions and apply discounts during checkout.</p>--%>

    </div>
</asp:Content>

