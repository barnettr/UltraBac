<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Secure_settings_tax_Add" Title="Untitled Page" %>

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
    	
    	<h4>Tax Region</h4>
    	
        <div class="FieldStyle">Select a destination Country to apply this tax rule</div>
        <div class="ValueStyle"><asp:DropDownList ID="lstCountries" runat="server"></asp:DropDownList></div> 
             
        <div class="FieldStyle">Enter a destination State </div>
        <div class="ValueStyle">
            <asp:DropDownList ID="lstStateOption" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstStateOption_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Apply to ALL States</asp:ListItem>
                <asp:ListItem Value="1">Enter a Specific State</asp:ListItem>
            </asp:DropDownList>
            <br /><br />
            <asp:Panel ID="pnlState" runat="server" Visible="false">
                <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDestinationStateCode" Display="Dynamic" ErrorMessage="Enter State Code" SetFocusOnError="True"></asp:RequiredFieldValidator></div> 
                <div class="FieldStyle">2-Character State Code: <asp:TextBox ID="txtDestinationStateCode" runat="server" MaxLength="2" Columns="5"></asp:TextBox></div>
            </asp:Panel>
        </div>
        
        <h4>Tax Rate</h4>
                 
        <div class="FieldStyle">Tax Rate</div>
        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTaxRate" Display="Dynamic" ErrorMessage="Enter a Tax Rate" SetFocusOnError="True"></asp:RequiredFieldValidator></div> 
        <div><asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtTaxRate" CssClass="Error" Display="Dynamic" ErrorMessage="Enter a valid Tax Rate" MaximumValue="50" MinimumValue="0" SetFocusOnError="True" Type="Double"></asp:RangeValidator></div>
        <div class="ValueStyle">% <asp:TextBox ID="txtTaxRate" runat="server" Columns="6" MaxLength="5">0.00</asp:TextBox></div>

	    <div class="FieldStyle">Precedence<span class="Asterix">*</span></div>
        <p>Enter a number between 1-99. This is the order in which this tax rule will be processed.</p>
        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrecedence" Display="Dynamic" ErrorMessage="Enter precedence" SetFocusOnError="True"></asp:RequiredFieldValidator></div>
        <div><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrecedence" CssClass="Error" Display="Dynamic" ErrorMessage="Enter a number between 1-99" MaximumValue="99" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>
        <div class="ValueStyle"><asp:TextBox ID="txtPrecedence" runat="server" MaxLength="2" Columns="5">1</asp:TextBox></div>
        
	    <div>
	        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
	        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
	    </div>	
	</div>
</asp:Content>

