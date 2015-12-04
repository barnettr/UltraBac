<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationBrand.ascx.cs" Inherits="Controls_BrandNavigation" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>

<div class="SpecialsTreeView">
    <div class="Title"><uc1:CustomMessage ID="CustomMessage2" MessageKey="ShopByBrandTitle" runat="server" /></div>
    <div>
        <asp:TreeView ID="ctrlNavigation" runat="server" ExpandDepth="2" CssClass="TreeView" NodeIndent="14" ShowExpandCollapse="False">
             <ParentNodeStyle CssClass="ParentNodeStyle" />
             <HoverNodeStyle CssClass="HoverNodeStyle"/>
             <SelectedNodeStyle CssClass="SelectedNodeStyle" />
             <RootNodeStyle CssClass="RootNodeStyle"/>
             <LeafNodeStyle CssClass="LeafNodeStyle"/>
             <NodeStyle CssClass="NodeStyle" />
        </asp:TreeView>
        <div class="Title"><asp:Label ID="lblTitle" runat="server" Visible="false"></asp:Label></div>
    </div>
</div>
