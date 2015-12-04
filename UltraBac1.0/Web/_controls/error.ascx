<%@ Control Language="C#" AutoEventWireup="true" CodeFile="error.ascx.cs" Inherits="_controls_error" %>


<ZNode:CustomMessage runat="server" MessageKey="GeneralErrorMessage" />

<asp:PlaceHolder ID="plhCheckoutError" EnableViewState="false" Visible="false" runat="server">
	<div class="error_description">
		As a result of the error your shopping cart has been emptied. Before you proceed
		through checkout, please log in and add your selections back into your cart.
	</div>
	<p>
		<a href="~/login.aspx" runat="server"><strong>&#60; Go to login</strong></a></p>
</asp:PlaceHolder>
<asp:PlaceHolder ID="plhGeneralError" EnableViewState="false" Visible="false" runat="server">

	<script type="text/javascript">
    //<![CDATA[
        document.write('<p><a href="javascript:history.go(-1);"><strong>&#60; Go back</strong></a></p>');
    //]]>
    </script>

</asp:PlaceHolder>
<p>
	<a href="~/" runat="server">Go to home page</a></p>
