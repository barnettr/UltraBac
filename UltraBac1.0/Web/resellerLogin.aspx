<%@ Page Title="" Language="C#" MasterPageFile="~/Themes/Default/ThreeColumn.master" AutoEventWireup="true" CodeFile="resellerLogin.aspx.cs" Inherits="resellerLogin" %>

<asp:Content ContentPlaceHolderID="MainContent" Runat="Server">
<div class="Error">
<asp:Literal runat="server" ID="uxError" Visible="false">
<p>Unable to authenticate user.</p>
</asp:Literal>
</div>
<div class="formBox-content" id="reseller-login-form">
    <ZNode:CustomMessage runat="server" MessageKey="ResellerLogin" />
    <ol class="form">
        <li>
            <asp:Label AssociatedControlID="uxEmail" runat="server" ><span style="color:Red;">*</span> Email address:</asp:Label>
            <asp:TextBox runat="server" ID="uxEmail" class="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="uxEmail" ErrorMessage="Please enter your email address."
                ValidationGroup="login"
                ToolTip="Please enter your email address." />
        </li>
        <li>
            <asp:Label runat="server" AssociatedControlID="uxPassword" ><span style="color:Red;">*</span> Password:</asp:Label>
            <asp:TextBox runat="server" TextMode="Password" ID="uxPassword" class="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="uxPassword" ErrorMessage="Please enter a password."
                ValidationGroup="login"
                ToolTip="Please enter a password." />
        </li>
        <li>
            <label></label>    
            <asp:Button runat="server" ID="uxSubmit" ValidationGroup="login" Text="Login" OnClick="uxSubmit_Click" CssClass="submit marginCenter floatnone"/>
        </li>

    </ol>
    <div class="clear"></div>
        <p>Forgot login? <a href="mailto:support@ultrabac.com?subject=Forgot Reseller Login">Contact Support</a></p>
        <p>Don't have a login? <a id="A1" runat="server" href="~/content.aspx?page=resellers-benefits">Become a reseller</a></p>
</div>
</asp:Content>