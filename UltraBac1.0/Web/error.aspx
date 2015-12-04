<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/error.aspx.cs" MasterPageFile="~/Themes/Default/common/main.master" Inherits="error" %>
<%@ Register Src="~/_controls/error.ascx" TagPrefix="POP" TagName="Error" %>


<asp:Content ContentPlaceHolderID="TurnOffBreadcrumb" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
	
	<POP:NavLeftSidebar ID="uxNavLeftSidebar" runat="server" />
	
		<div id="Content">
			<POP:Error ID="uxError" runat="server" />
	
		<!-- /Content --></div>		
  
  <POP:RightSidebar ID="uxRightSidebar" runat="server" />
</asp:Content>

