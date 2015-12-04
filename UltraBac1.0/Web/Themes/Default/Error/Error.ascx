<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Error.ascx.cs" Inherits="Themes_Default_Error_Error" %>
<div id="ErrorContainer">
    <h1>An Error Occurred</h1>
    <p>Sorry. Due to an error, we could not complete your request at this time. We apologize for the inconvenience.</p>
    
	<div class="error_description"><asp:Label ID="lblError" runat="server"></asp:Label></div>
	
    <p><a id="A1" href="~/default.aspx" runat="server">&#60; Back to site</a></p>
</div>