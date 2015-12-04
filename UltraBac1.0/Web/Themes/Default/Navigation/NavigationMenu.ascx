
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationMenu.ascx.cs" Inherits="Controls_NavigationMenu" %>
<div>	
    <asp:Menu ID="ctrlMenu" runat="server" DynamicHorizontalOffset="20" EnableTheming="False" Orientation="Horizontal" StaticSubMenuIndent="0px" CssClass="Menu" StaticEnableDefaultPopOutImage="False" MaximumDynamicDisplayLevels="1">
        <StaticMenuStyle CssClass="StaticMenuStyle" />
        <StaticMenuItemStyle CssClass="StaticMenuItemStyle" />       
        <StaticSelectedStyle CssClass="StaticSelectedStyle" />
        <StaticHoverStyle CssClass="StaticHoverStyle" />
        <DynamicHoverStyle CssClass="DynamicHoverStyle" />
        <DynamicMenuStyle CssClass="DynamicMenuStyle" />
        <DynamicSelectedStyle CssClass="DynamicSelectedStyle" />
        <DynamicMenuItemStyle CssClass="DynamicMenuItemStyle" />
    </asp:Menu>
    <div class="MenuBottomLine"></div>
</div>

