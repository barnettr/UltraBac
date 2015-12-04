<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsletter.aspx.cs" Inherits="newsletter" MasterPageFile="~/Themes/Default/Common/main.master" %>
<%@ MasterType VirtualPath="~/Themes/Default/Common/main.master" %>
<%@ Register Src="~/_controls/newsletterControl.ascx" TagPrefix="uc1" TagName="NewsletterControl" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
	
	
<div id="two-column-wrapper">
		<div id="Content">
			
	 	 <uc1:NewsletterControl runat="server" id="uxNews" />
			
	<!-- /Content --></div>	
  </div>
  <POP:RightSidebar ID="uxRightSidebar" runat="server" />
  
<%--  <li style="color: #ffffff; background: #bc151b;">&nbsp;<a style="margin-left: 18px; color:#ffffff; text-decoration: none;" href="#NEED_URL#">Direct Write to VMDK</a></li>--%>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="TurnOffBreadcrumb" />