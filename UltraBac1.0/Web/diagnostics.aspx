<%@ Page Language="C#"  AutoEventWireup="true" Inherits="DiagnosticsPageBase" CodeFile="DiagnosticsPageBase.cs" %>
<%@ Register Src="~/Controls/spacer.ascx" TagName="spacer" TagPrefix="ZNode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Znode Storefront Diagnostics</title>
</head>
<body class="Body">
    <form id="form1" runat="server">
    <center>
        <div align="center" style="background-color:#ffffff; text-align:left; padding:20px; margin:20px;" id="Container">
            <h1>Znode Storefront Diagnostics <%= GetProductVersion()%></h1>
            <div>
                Here are the results of diagnostic tests that were run on your storefront installation
            </div>          
             <p><asp:Label ID="lblDatabaseStatus" runat="server" ></asp:Label></p>
             <p><asp:Label ID="lblPublicPermissions" runat="server" ></asp:Label></p>             
             <p><asp:Label ID="lblLicenseStatus" runat="server"></asp:Label></p>
             <p><asp:Label ID="lblSMTPAccountStatus" runat="server"></asp:Label></p>
             <asp:Panel ID="PnlExceptionSummary" runat="server" Visible= "false">
             <h4>Exception Log</h4>
             <div><asp:Literal EnableViewState="false" ID="lblMsg" runat="server" ></asp:Literal></div>
             </asp:Panel>
             <div><img src="~/images/clear.gif" width="1" height="150" alt=""/></div>     
        </div>
        <hr />
        <div align="center" style="background-color:#ffffff; text-align:left; padding:20px; margin:20px;" id="Div1">
            <h1>POP-Added Diagnostics</h1>
            <div>
                <strong>Test Error Handling</strong>
                <br />
                <asp:Button ID="btnTestError" runat="server" Text="THROW ERROR" OnClick="btnTestError_Click" />
            </div>
            &nbsp;
            <div>
                <strong>Test Email Messaging</strong>
                <br />
                <asp:Label ID="lblTestEmailResult" runat="server" EnableViewState="false" ForeColor="red" />
                <table>
                    <tr>
                        <td>from:</td>
                        <td><asp:TextBox ID="txtTestEmailFrom" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>to:</td>
                        <td><asp:TextBox ID="txtTestEmailTo" runat="server" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnTestEmail" runat="server" Text="SEND TEST MESSAGE" OnClick="btnTestEmail_Click" /></td>
                    </tr>
                </table>
            </div>
            &nbsp;
            <div>
                <strong>Test Dropped Session Condition</strong>
                <br />
                <asp:Button ID="btnTestSessionAbandon" runat="server" Text="ABANDON SESSION" OnClick="btnTestSessionAbandon_Click" />
                <br />
                <asp:Label ID="lblSessionAbandon" runat="server" />
            </div>
        </div>
        </center>
    </form>
</body>
</html>
