<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/Login.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Site Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
<div class="Login">
    <h1>Storefront Admin Login</h1>
    <p>Use this page to login to the administration section of your storefront. Authorized personnel only.</p>
    <div class="Form">             
        <table border="0" cellpadding="0" cellspacing="5">                                           
            <tr class="Row">
                <td align="right" class="FieldStyle" nowrap>
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label></td>
                <td>
                    <asp:TextBox ID="UserName" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="uxLogin" Display="Dynamic" CssClass="Error">User Name is required.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Row">
                <td align="right" class="FieldStyle">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label></td>
                <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="uxLogin" Display="Dynamic" CssClass="Error">Password is required.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Row">
                <td align="center" colspan="2" style="color: red">
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            <tr class="Row">
                <td></td>
                <td align="left">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="uxLogin" CssClass="Button" OnClick="LoginButton_Click" />
                </td>
            </tr>
             <tr class="Row">
                <td colspan="2"><img src="~/images/clear.gif" width="1" height="100" /></td>
            </tr>
            
        </table> 
    </div>
</div> 
</asp:Content>

