<%@ Page Language="C#" MasterPageFile="~/Themes/Default/Common/main.master" %>
<%@ Register Src="~/_controls/search.ascx" TagPrefix="POP" TagName="Search" %>
<%@ Register Src="~/_controls/searchResults.ascx" TagPrefix="POP" TagName="SearchResults" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div id="Content" class="Home_Content">
    <h1>Search Results</h1>    
    <POP:Search ID="uxSearch" runat="server" />
    <POP:SearchResults ID="uxSearchResults" runat="server" />
    
</div>

  <POP:RightSidebar ID="uxRightSidebar" runat="server" ShowSearch="false" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="TurnOffBreadcrumb" />