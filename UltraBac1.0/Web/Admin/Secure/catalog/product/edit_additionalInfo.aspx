<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="edit_additionalInfo.aspx.cs" Inherits="Admin_Secure_catalog_product_edit_additionalInfo" %>
<%@ Register TagPrefix="ZNode" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="ZNode" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
    <div class="Form">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h1><asp:label ID="lblTitle" runat="server" Text="Edit Additional Info for" ></asp:label></h1>
                        <uc1:DemoMode id="DemoMode1" runat="server"></uc1:DemoMode>
                </td>
                <td align="right">
                    <asp:Button ID="btnSubmitTop" runat="server" CausesValidation="True" class="Button"
                        OnClick="btnSubmit_Click" Text="SUBMIT" />
                    <asp:Button ID="btnCancelTop" runat="server" CausesValidation="False" class="Button"
                        OnClick="btnCancel_Click" Text="CANCEL" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblError" CssClass= "Error" runat="server"></asp:Label>
        <div>
            <p>Use this page to edit product details for this product.</p>

            <h4>Enter Purchase Information</h4>
            <p class="HintStyle">Add a details about purchasing this product (required products, server requirements, etc)</p>
            <div class="ValueStyle"><ZNode:HtmlTextBox id="ctrlHtmlPurchaseInf" runat="server"></ZNode:HtmlTextBox></div>
        
            <h4>Enter Licensing Information</h4>
            <p class="HintStyle">Add licensing information here</p>
            <div class="ValueStyle"><ZNode:HtmlTextBox id="ctrlHtmlLicenseInf" runat="server"></ZNode:HtmlTextBox></div>
            
            <h4>Enter Upgrade Information</h4>
            <p class="HintStyle">Add Upgrade information for users of existing versions of this product</p>
            <div class="ValueStyle"><ZNode:HtmlTextBox id="CtrlHtmlUpgradeInf" runat="server"></ZNode:HtmlTextBox></div>
            
            <h4>Enter Maintenance Information</h4>
            <p class="HintStyle">Add information relavant to maintenance of this software</p>
            <div class="ValueStyle"><ZNode:HtmlTextBox id="ctrlHtmlMaintenanceInfo" runat="server"></ZNode:HtmlTextBox></div>
            
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" CausesValidation="True" class="Button"
                OnClick="btnSubmit_Click" Text="SUBMIT" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" class="Button"
                OnClick="btnCancel_Click" Text="CANCEL" />
        </div>
    </div>
</asp:Content>

