<%@ Page Title="" Language="C#" MasterPageFile="~/Themes/Default/Common/main.master" AutoEventWireup="true" CodeFile="event.aspx.cs" Inherits="event2" %>
<%@ MasterType VirtualPath="~/Themes/Default/Common/main.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
	
<div id="two-column-wrapper">
	
		<div id="Content">
			
	 
	    <h1>Event Details: <asp:literal runat="server" id="uxTitle" /></h1>
	    
	    <% if (HasLocation) { %>
	    <h2><asp:literal runat="server" id="uxLocation" /></h2>
	    <% } %>    
	    
	    <em><asp:literal runat="server" id="uxDates" /></em>	    
	    
	    <% if (HasBooth) { %>
	    <dl class="marginTop_none margin_bottom">
	        <dt class="floatleft">Booth:</dt>
	        <dd><asp:literal runat="server" id="uxBooth" /></dd>
	    </dl> 
	    <div class="clear"></div>
        <% } %>
        
	    <p><asp:literal runat="server" id="uxDetails" /></p>
	    <asp:HyperLink runat="server" ID="uxLink" />
	<!-- /Content --></div>	
	</div>
  
  <POP:RightSidebar ID="uxRightSidebar" runat="server" />
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="TurnOffBreadcrumb" />