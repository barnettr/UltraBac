<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationPrice.ascx.cs" Inherits="Controls_NavigationPrice" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>
<asp:Panel ID="pnlProductList" runat="server" Visible="true">
    <div class="SpecialsTreeView">
        <div class="Title"><uc1:CustomMessage ID="CustomMessage2" MessageKey="ShopByPriceTitle" runat="server" /></div>
        <div>
            <asp:TreeView ID="ctrlNavigation" runat="server" ExpandDepth="2" CssClass="TreeView" NodeIndent="14" ShowExpandCollapse="False">
                <ParentNodeStyle CssClass="ParentNodeStyle" />
                <HoverNodeStyle CssClass="HoverNodeStyle"/>
                <SelectedNodeStyle CssClass="SelectedNodeStyle" />
                <RootNodeStyle CssClass="RootNodeStyle"/>
                <LeafNodeStyle CssClass="LeafNodeStyle"/>
                <NodeStyle CssClass="NodeStyle" />
            </asp:TreeView>
        </div>
    </div>
</asp:Panel> 