<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navSidebar.ascx.cs" Inherits="_controls_navSidebar" %>
<%@ OutputCache Duration="120" VaryByParam="*" %>
		<div id="Nav_Sub">
			<div class="wrapper" runat="server" id="navWrapper">
			<asp:PlaceHolder runat="server" ID="uxOuterWrapper">
				<img runat="server" src="~/_img/leftnav/leftnav_border_top-trans.png" width="197" height="7" alt="" class="top" />
				<asp:PlaceHolder ID="plhNav" runat="server" />
				<img runat="server" src="~/_img/leftnav/leftnav_border_bottom-trans.png" width="197" height="7" alt="" class="bottom" />
		    </asp:PlaceHolder>
			<!-- wrapper --></div>
		<!-- /Nav_Sub --></div>
				