<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Secure_settings_payment_Add" Title="Untitled Page" %>

<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <div class="Form">
	    <table width="100%" cellspacing="0" cellpadding="0" >
		    <tr>
			    <td><h1><asp:Label ID="lblTitle" Runat="server"></asp:Label>
                    <uc2:DemoMode ID="DemoMode1" runat="server" />
                </h1></td>
			    <td align="right">
				    <asp:button class="Button" id="btnSubmitTop" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
				    <asp:button class="Button" id="btnCancelTop" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
			    </td>
		    </tr>
	    </table>
			    
	    <div><uc1:spacer id="Spacer8" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
    	<div><asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label></div>
    	<div><uc1:spacer id="Spacer1" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
    	
    	<h4>General Settings</h4>
    	
    	<div class="FieldStyle">Select a profile to which this setting should be applied<span class="Asterix">*</span></div>
        <div class="ValueStyle"><asp:DropDownList ID="lstProfile" runat="server"></asp:DropDownList></div> 
        
    	<div class="FieldStyle">Select a payment type<span class="Asterix">*</span></div>
        <div class="ValueStyle"><asp:DropDownList ID="lstPaymentType" runat="server" OnSelectedIndexChanged="lstPaymentType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></div> 
        
         <div class="FieldStyle">Check the box below to enable this payment option</div>
         <div class="ValueStyle"><asp:CheckBox ID="chkActiveInd" runat="server" Checked="true" Text="Enable" /></div>
 
	    <div class="FieldStyle">Display Order<span class="Asterix">*</span></div>
        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDisplayOrder" Display="Dynamic" ErrorMessage="* Enter merchant account login name" SetFocusOnError="True"></asp:RequiredFieldValidator>
             <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDisplayOrder"
                            CssClass="Error" Display="Dynamic" ErrorMessage="* Enter a number between 1-10"
                            MaximumValue="10" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>
        <div class="ValueStyle"><asp:TextBox ID="txtDisplayOrder" runat="server" MaxLength="2" Columns="5"></asp:TextBox></div>
        
        <asp:Panel ID="pnlCreditCard" runat="server" Visible="false">
    	    <h4>Merchant Gateway Settings</h4>
    	    
        	<asp:Panel ID="pnlGatewayList" runat="server" Visible="true"> 
    	    <div class="FieldStyle">Select a gateway<span class="Asterix">*</span></div>
            <div class="ValueStyle"><asp:DropDownList ID="lstGateway" runat="server" OnSelectedIndexChanged="lstGateway_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></div>         
        	</asp:Panel> 
        	
    	    <div class="FieldStyle">Merchant account login<span class="Asterix">*</span></div>
            <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGatewayUserName" Display="Dynamic" ErrorMessage="* Enter merchant account login name" SetFocusOnError="True"></asp:RequiredFieldValidator></div>
            <div class="ValueStyle"><asp:TextBox ID="txtGatewayUserName" runat="server" MaxLength="50" Columns="50"></asp:TextBox></div>
    	        
    	    <asp:Panel ID="pnlPassword" runat="server" Visible="true">    
      	        <div class="FieldStyle">Merchant account password<span class="Asterix">*</span></div>                        
                <div><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGatewayPassword" Display="Dynamic" ErrorMessage="* Enter merchant account password" SetFocusOnError="True"></asp:RequiredFieldValidator></div>
                <div class="ValueStyle"><asp:TextBox ID="txtGatewayPassword" runat="server" MaxLength="50" Columns="50" TextMode="Password"></asp:TextBox></div>
      	    </asp:Panel> 
      	    
      	    <asp:Panel ID="pnlAuthorizeNet" runat="server" Visible="false">
       	        <div class="FieldStyle"><asp:Label ID="lblTransactionKey" runat="server">Transaction key (Authorize.Net only)</asp:Label></div>
                <div class="ValueStyle"><asp:TextBox ID="txtTransactionKey" runat="server" MaxLength="70" Columns="50"></asp:TextBox></div>
           	</asp:Panel>
           	            
           	<div class="FieldStyle">Check the box below to enable the Gateway TEST mode</div>
            <div class="ValueStyle"><asp:CheckBox ID="chkTestMode" runat="server" Checked="false" Text="Enable Test Mode" /></div>

       	         
           
            <asp:Panel ID="pnlCreditCardOptions" runat="server">
            <div class="FieldStyle">Select the credit cards that will be accepted</div>
            <div class="ValueStyle"><asp:CheckBox ID="chkEnableVisa" runat="server" Checked="true" Text="Visa" />&nbsp;&nbsp;<asp:CheckBox ID="chkEnableMasterCard" runat="server" Checked="true" Text="MasterCard" />&nbsp;&nbsp;<asp:CheckBox ID="chkEnableAmex" runat="server" Checked="true" Text="American Express" />&nbsp;&nbsp;<asp:CheckBox ID="chkEnableDiscover" runat="server" Checked="true" Text="Discover" /></div>
            
            <div class="FieldStyle">Check the box below to enable offline mode</div>
            <div class="ValueStyle"><asp:CheckBox ID="ChkEnableOfflinemode" runat="server" Checked="false" Text="Offline Mode" /></div>
            
            <div class="FieldStyle">Check the box below to store customer's credit card info in the database</div>
            <div class="ValueStyle"><asp:CheckBox ID="ChkEnableCreditCard" runat="server" Checked="true" Text="Save Credit Card" /></div>
            </asp:Panel>
            
	    </asp:Panel>
	    
	    <div>
	        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
	        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
	    </div>	
	</div>
</asp:Content>

