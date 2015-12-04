<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatabaseSetting.ascx.cs" Inherits="ZNodeInstallation_DatabaseSetting" %>
<div class="Form">
    <h1>Step2: Database Settings</h1>
    <br clear="all" />
    <div class="ValueStyle">
        Please provide the following connection settings to your SQL Server database
    </div>
    <br clear="all" />
    <div>
        <table>
            <tr>
                <td class="FieldStyle">
                    Server Name
                </td>
                <td>
                    <asp:TextBox ID="txtServerName" runat="server" Width="155px"></asp:TextBox></td>           
            </tr>
            <tr>
                <td class="FieldStyle">
                    Database Name
                </td>
                <td>
                    <asp:TextBox ID="txtDBName" runat="server" Width="155px"></asp:TextBox></td>            
            </tr>
            <tr>
                <td class="FieldStyle">
                    User ID
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Width="155px"></asp:TextBox></td>           
            </tr>
            <tr>
                <td class="FieldStyle">
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="155px"></asp:TextBox></td>           
            </tr>
        </table>
     </div>
     <asp:Literal ID="ErrorMsg" runat="server"></asp:Literal>
 </div>
