<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Secure_settings_ship_Add" Title="Untitled Page" %>

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
        
    	<div class="FieldStyle">Select a shipping type<span class="Asterix">*</span></div>
        <div class="ValueStyle"><asp:DropDownList ID="lstShippingType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstShippingType_SelectedIndexChanged"></asp:DropDownList></div> 
        
        <asp:Panel ID="pnlShippingServiceCodes" runat="server" Visible="false" >
            <div class="FieldStyle">Select a UPS Service code<span class="Asterix">*</span></div>
            <div class="ValueStyle"><asp:DropDownList ID="lstShippingServiceCodes" runat="server" AutoPostBack="false"></asp:DropDownList></div> 
        </asp:Panel>
        
        <asp:Panel ID="pnlShippingOptions" runat="server">        
            <div class="FieldStyle">Shipping option display name (ex: Federal Express Overnight)<span class="Asterix">*</span></div>
            <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" Display="Dynamic" ErrorMessage="Enter shipping option name" SetFocusOnError="True"></asp:RequiredFieldValidator></div> 
            <div class="ValueStyle"><asp:TextBox ID="txtDescription" runat="server" MaxLength="50" Columns="50"></asp:TextBox></div>

            <div class="FieldStyle">Enter your internal shipping code (ex: "FDX_OVNT")<span class="Asterix">*</span></div>
            <div><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtShippingCode" Display="Dynamic" ErrorMessage="Enter shipping code" SetFocusOnError="True"></asp:RequiredFieldValidator></div> 
            <div class="ValueStyle"><asp:TextBox ID="txtShippingCode" runat="server" MaxLength="10" Columns="23"></asp:TextBox></div>
        </asp:Panel>
        
 	    <div class="FieldStyle">Handling Charge (Optional)</div>
 	    <div><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHandlingCharge" Display="Dynamic" ErrorMessage="Enter a handling charge" SetFocusOnError="True"></asp:RequiredFieldValidator></div> 
 	    <div><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtHandlingCharge" Type="Currency" Operator="DataTypeCheck" ErrorMessage="You must enter a valid handling charge (ex: 123.45)" /> </div>
        <div class="ValueStyle"><span class="DollarSymbol">$ </span><asp:TextBox ID="txtHandlingCharge" runat="server">0.00</asp:TextBox></div>
        
        <asp:Panel ID="pnlDestinationCountry" runat="server">
        <div class="FieldStyle">Destination Country (Optional)</div>
        <div class="HintStyle">Select a country if you want to restrict this shipping option to a specific country</div>
        <div class="ValueStyle"><asp:DropDownList ID="lstCountries" runat="server"></asp:DropDownList></div> 
        </asp:Panel>
        
        <h4>Display Settings</h4>
        
        <div class="FieldStyle">Check the box below to enable this shipping option</div>
        <div class="ValueStyle"><asp:CheckBox ID="chkActiveInd" runat="server" Checked="true" Text="Enable" /></div>
 
	    <div class="FieldStyle">Display Order<span class="Asterix">*</span></div>
        <div class="HintStyle">Enter a number between 1-99. This is the order in which it will be displayed to the customer</div>
        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDisplayOrder" Display="Dynamic" ErrorMessage="Enter display order" SetFocusOnError="True"></asp:RequiredFieldValidator></div>
        <div><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDisplayOrder" CssClass="Error" Display="Dynamic" ErrorMessage="Enter a number between 1-99" MaximumValue="99" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>
        <div class="ValueStyle"><asp:TextBox ID="txtDisplayOrder" runat="server" MaxLength="2" Columns="5">1</asp:TextBox></div>
        
	    <div>
	        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
	        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
	    </div>	
	</div>
</asp:Content>

