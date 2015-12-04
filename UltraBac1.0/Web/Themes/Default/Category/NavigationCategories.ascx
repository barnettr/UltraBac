<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationCategories.ascx.cs" Inherits="Controls_NavigationCategories" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>
<div class="CategoryTreeView">
    <div class="Title"><uc1:CustomMessage ID="CustomMessage2" MessageKey="NavigationTitle" runat="server" /></div>
    <div>
        <asp:TreeView ID="ctrlNavigation" runat="server" ExpandDepth="0" CssClass="TreeView" NodeIndent="15" ShowExpandCollapse="False" >
            <ParentNodeStyle CssClass="ParentNodeStyle" />
            <HoverNodeStyle CssClass="HoverNodeStyle" />
            <SelectedNodeStyle CssClass="SelectedNodeStyle" />
            <RootNodeStyle CssClass="RootNodeStyle" />
            <LeafNodeStyle CssClass="LeafNodeStyle" />
            <NodeStyle CssClass="NodeStyle" />
        </asp:TreeView>
    </div>
</div>