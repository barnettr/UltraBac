<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsletteremail.aspx.cs" Inherits="newsletteremail" %>
<%@ Register Src="~/_controls/newsletterControl.ascx" TagPrefix="uc1" TagName="NewsletterControl" %>

<table align="center" border="0" cellspacing="0" cellpadding="0" width="626">
<tr> <td colspan="3">
	<asp:PlaceHolder id="uxCustomerBanner" runat="server">
		<img src="<%= UrlHelper.GetFullUrl("/_img/newsletter/banner.jpg") %>" />
	</asp:PlaceHolder>
	<asp:PlaceHolder id="uxResellerBanner" runat="server">
		<img src="<%= UrlHelper.GetFullUrl("/_img/newsletter/banner-reseller.jpg") %>" />
	</asp:PlaceHolder>
</td></tr>
  </table>
<uc1:NewsletterControl runat="server" id="uxNews" />