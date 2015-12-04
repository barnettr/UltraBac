<%@ Page Language="C#"  MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="add_sku.aspx.cs" Inherits="Admin_Secure_catalog_product_add_sku" %>

<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
    <div class="Form">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h1>
                        <asp:Label ID="lblHeading" runat="server" />
                        <uc1:DemoMode id="DemoMode1" runat="server">
                        </uc1:DemoMode></h1>
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
        <div class="FieldStyle">
            SKU or Part#<span class="Asterix">*</span>
        </div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SKU"
                Display="Dynamic" ErrorMessage="* Enter a valid SKU" SetFocusOnError="True" CssClass="Error"></asp:RequiredFieldValidator>
        </div>
        <div class="ValueStyle">
            <asp:TextBox ID="SKU" runat="server" Columns="30" MaxLength="50"></asp:TextBox>
        </div>
        <div class="FieldStyle">
            Quantity On Hand<span class="Asterix">*</span>
        </div>
        <p>
            Quantity should be a number between 1-9999</p>
        <div>
            <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ControlToValidate="Quantity"
                Display="Dynamic" ErrorMessage="* Enter a valid Quantity" CssClass="Error"></asp:RequiredFieldValidator>
        </div>
        <div class="ValueStyle">
            <asp:TextBox ID="Quantity" runat="server" Columns="5" MaxLength="4">1</asp:TextBox>&nbsp;
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Quantity"
                Display="Dynamic" ErrorMessage="* Enter a number between 1-9999" MaximumValue="9999"
                MinimumValue="0" Type="Integer" CssClass="Error"></asp:RangeValidator>
        </div> 
        <div class="FieldStyle">ReOrder Level</div> 
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ReOrder" Display="Dynamic" ErrorMessage="* Enter a valid ReOrder level. Only numbers are allowed" SetFocusOnError="true" ValidationExpression="(^N/A$)|(^[-]?(\d+)(\.\d{0,3})?$)|(^[-]?(\d{1,3},(\d{3},)*\d{3}(\.\d{1,3})?|\d{1,3}(\.\d{1,3})?)$)" CssClass="Error"></asp:RegularExpressionValidator>      
        <div class="ValueStyle">
        <asp:TextBox ID="ReOrder" runat="server" Columns="5" MaxLength="3"></asp:TextBox>
        </div>
        <div class="FieldStyle">Additional Weight</div>   
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="WeightAdditional" Display="Dynamic" ErrorMessage="* Enter a valid Additonal Weight. Only numbers are allowed" SetFocusOnError="true" ValidationExpression="(^N/A$)|(^[-]?(\d+)(\.\d{0,3})?$)|(^[-]?(\d{1,3},(\d{3},)*\d{3}(\.\d{1,3})?|\d{1,3}(\.\d{1,3})?)$)" CssClass="Error"></asp:RegularExpressionValidator>           
        <div class="ValueStyle">
        <asp:TextBox ID="WeightAdditional" runat="server" Columns="5" MaxLength="3"></asp:TextBox>
        </div>
        <div class="FieldStyle">Additional Price (Retail)</div>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="RetailPrice" Display="Dynamic" ErrorMessage="* Enter a valid Additional Price. Only numbers are allowed" SetFocusOnError="true" ValidationExpression="(^N/A$)|(^[-]?(\d+)(\.\d{0,3})?$)|(^[-]?(\d{1,3},(\d{3},)*\d{3}(\.\d{1,3})?|\d{1,3}(\.\d{1,3})?)$)" CssClass="Error"></asp:RegularExpressionValidator>                   
        <div class="ValueStyle">
        <asp:TextBox ID="RetailPrice" runat="server" Columns="5" MaxLength="7"></asp:TextBox>
        </div>            
        <div class="FieldStyle">Enable Inventory</div>
	    <div class="ValueStyle"><asp:CheckBox ID='VisibleInd' runat='server' Checked="true" Text="Check this box to enable this inventory" ></asp:CheckBox></div>        
         <div class="FieldStyle" id="DivAttributes" runat="Server">
            Product Attributes<span class="Asterix">*</span>
        </div>
        <div class="ValueStyle">
            <asp:PlaceHolder id="ControlPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>        
        <div>
            <asp:Button ID="btnSubmit" runat="server" CausesValidation="True" class="Button"
                OnClick="btnSubmit_Click" Text="SUBMIT" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" class="Button"
                OnClick="btnCancel_Click" Text="CANCEL" />
        </div>
    </div>
</asp:Content>

