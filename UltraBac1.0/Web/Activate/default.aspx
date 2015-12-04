<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Admin_Activate" Title="Activate your Znode Storefront" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <div class="License">
        <!-- ACTIVATE LICENSE -->
        <asp:Panel ID="pnlLicenseActivate" runat="server" Visible="true">
            <h1>Activate your Storefront</h1>
            <!--<p>You should activate your Znode Storefront license or trial before proceeding. An internet connection is required for activation.</p>-->
            <div><img src="~/images/clear.gif" width="1" height="10" alt=""/></div> 
            <p><b>Note:</b> You should have Read+Write+Modify permissions for the ASPNET account (Win XP) or the Network Service account (Win 2003) on the <b>Data</b> folder before activating.</p>

            <div><img src="~/images/clear.gif" width="1" height="10" alt=""/></div>    
            <div><asp:Label ID="lblError" runat="server" CssClass="Error"></asp:Label></div>
            <div><img src="~/images/clear.gif" width="1" height="10" alt=""/></div> 

            <table>
                <tr class="Row">
                    <td class="FieldLabel" valign="top">Select License</td>
                    <td valign="top">
                        <div><asp:RadioButton ID="chkFreeTrial" GroupName="lic" Checked="false" Text="30 Day Free Trial" runat="server" OnCheckedChanged="chkFreeTrial_CheckedChanged" AutoPostBack="true" /></div>
                        <!--<div><asp:RadioButton ID="chkExpress" GroupName="lic" Checked="false" Text="Express Edition" runat="server" OnCheckedChanged="chkFreeTrial_CheckedChanged" AutoPostBack="true" /></div> -->                     
                        <div><asp:RadioButton ID="chkStandard" GroupName="lic" Checked="false" Text="Standard Edition" runat="server" OnCheckedChanged="chkFreeTrial_CheckedChanged" AutoPostBack="true"  /></div>
                        <div><asp:RadioButton ID="chkProfessional" GroupName="lic" Checked="false" Text="Professional Edition" runat="server" OnCheckedChanged="chkFreeTrial_CheckedChanged" AutoPostBack="true"  /></div>  
                        <div><asp:RadioButton ID="chkServer" GroupName="lic" Checked="false" Text="Single Server Edition" runat="server" OnCheckedChanged="chkFreeTrial_CheckedChanged" AutoPostBack="true"  /></div>              
                    </td>
                </tr>
                <tr>
                    <td><img src="~/images/clear.gif" width="1" height="10" alt=""/></td>
                </tr>
                <asp:Panel ID="pnlSerial" runat="server" Visible="false">
                    <tr class="Row">
                        <td class="FieldLabel">Serial Number</td>
                        <td><asp:TextBox ID="txtSerialNumber" runat="server" Width="300" CausesValidation="true"></asp:TextBox>
                        <div><asp:RequiredFieldValidator ID="SerialReqd" runat="server" ControlToValidate="txtSerialNumber" ErrorMessage="Serial number is required." ToolTip="Serial number is required." Display="Dynamic" CssClass="Error">Serial number is required.</asp:RequiredFieldValidator></div>                        
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td><img src="~/images/clear.gif" width="1" height="20" alt=""/></td>
                </tr>
                <tr>
                    <td colspan="2"><hr /></td>
                </tr>
                <tr>
                    <td><img src="~/images/clear.gif" width="1" height="20" alt=""/></td>
                </tr>
                <tr>
                    <td colspan="2">Please enter your contact information to get customer support. We value your privacy and will not share this information with third parties.</td>
                </tr>
                  <tr class="Row">
                    <td><img src="~/images/clear.gif" width="1" height="10" alt=""/></td>
                    <td></td>
                </tr>
                <tr class="Row">
                    <td class="FieldLabel">Full Name</td>
                    <td><asp:TextBox ID="txtName" runat="server" Width="200" CausesValidation="true"></asp:TextBox>
                    <div><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Full name is required." Display="Dynamic" CssClass="Error">Full name is required.</asp:RequiredFieldValidator></div>  
                    </td>
                </tr>
                <tr class="Row">
                    <td class="FieldLabel">Email Address</td>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="200" CausesValidation="true"></asp:TextBox>
                    <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." Display="Dynamic" CssClass="Error">Email is required.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                        CssClass="Error" ErrorMessage="Enter Valid Email Address" ToolTip="Enter Valid Email Address."
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>   
                    </div>  
                    </td>
                </tr>
                <tr class="Row">
                    <td><img src="~/images/clear.gif" width="1" height="20" alt=""/></td>
                    <td></td>
                </tr>
                <tr class="Row">
                    <td></td>
                    <td><asp:CheckBox ID="chkEULA" runat="server" Text="I have read and agreed to the " /><a href="~/activate/eula.htm" target="_blank" runat="server">software license agreement (EULA)</a></td>
                </tr>
                <tr>
                    <td><img src="~/images/clear.gif" width="1" height="20" alt=""/></td>
                </tr>
                <tr class="Row">
                    <td></td>
                    <td><asp:Button ID="btnActivateLicense" runat="server" Text="Click to Activate Storefront" CausesValidation="true" OnClick="btnActivateLicense_Click" /></td>
                </tr>
                 <tr>
                    <td><img src="~/images/clear.gif" width="1" height="10" alt=""/></td>
                </tr>
            </table> 
        </asp:Panel>    
     
      <!-- CONFIRM -->
        <asp:Panel ID="pnlConfirm" runat="server" Visible="false">
            <h1>Confirmation</h1>  
            <p><asp:Label ID="lblConfirm" runat="server"></asp:Label></p>
            <div><img src="~/images/clear.gif" width="1" height="20" alt=""/></div>      
            <a id="A1" href="~/default.aspx" runat="server">Go to Storefront >></a>  
            <div><img src="~/images/clear.gif" width="1" height="20" alt=""/></div>
        </asp:Panel>    
    </div>    
</asp:Content>

