<%@ Control Language="C#" AutoEventWireup="true" CodeFile="searchResults.ascx.cs" Inherits="_controls_searchResults" %>

<div>
    <asp:Label ID="lblError" runat="server" Visible="false" />
</div>

<div>
    <asp:Label ID="lblSearchTerm" runat="server" />
</div>

<div>
	<asp:PlaceHolder runat="server" ID="uxSearchError" Visible="false">
	<ZNode:CustomMessage runat="server" MessageKey="SearchError" />
	</asp:PlaceHolder>
	
    <asp:Repeater ID="repSearchResults" runat="server" OnItemDataBound="repSearchResults_ItemDataBound">
    <HeaderTemplate>
        Your search returned <strong><%# TotalSearchResults %></strong> results.
    </HeaderTemplate>
        <ItemTemplate>        
        <h2><a runat="server" id="uxSearchLink"></a></h2>
        <p><asp:Literal runat="server" ID="uxSearchText" /></p>        
       
        </ItemTemplate>
    </asp:Repeater>
    <asp:PlaceHolder runat="server" Visible="false" ID="uxNoResults">
        <p>No results found.</p>
    </asp:PlaceHolder>
    <asp:Repeater runat="server" ID="uxPages" OnItemDataBound="uxPages_ItemDataBound">
    <HeaderTemplate>
        <ul id="searchResults" class="plain">
    </HeaderTemplate>    
    <ItemTemplate>
        <li runat="server" id="li">
            <asp:PlaceHolder runat="server" ID="pageContents">
            
            </asp:PlaceHolder>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
    </asp:Repeater>
</div>