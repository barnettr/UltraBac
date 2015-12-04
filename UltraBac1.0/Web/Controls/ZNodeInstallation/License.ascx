<%@ Control Language="C#" AutoEventWireup="true" CodeFile="License.ascx.cs" Inherits="ZNodeInstallation_License" %>
<div class="Form">
<h1>Step1: Enter a valid license</h1>
<div class="FieldStyle">
Enter a valid license key for your storefront. You should have received this license in your
email.
</div><br /><br  clear="all"/>
    
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <table>
        <tr>
            <td>License Key
            </td>
            <td>
                <asp:TextBox ID="txtLicenseKey" runat="server"></asp:TextBox>
            </td>  
           
        </tr>
        <tr>
            <td>Domain Name
            </td>
            <td>
                <asp:TextBox ID="txtDomainName" runat="server" Text="localhost"></asp:TextBox>
            </td>            
        </tr>
       
    </table>
</div>