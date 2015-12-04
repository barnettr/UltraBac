<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Address.ascx.cs" Inherits="Controls_ShoppingCartCheckout_Address" %>


<div class="floatleft">
<h2>Billing Address</h2>

<p><strong>* Starred fields</strong> are required.</p>


<ol class="form">
		
	<li class="required">
		<label for="txtBillingFirstName">* First Name</label>
		<asp:textbox CssClass="text" id="txtBillingFirstName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="req1" ErrorMessage="Enter First Name" ControlToValidate="txtBillingFirstName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li class="required">
		<label for="txtBillingLastName">* Last Name</label>
		<asp:textbox CssClass="text" id="txtBillingLastName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator1" ErrorMessage="Enter Last Name" ControlToValidate="txtBillingLastName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li>
		<label for="txtBillingCompanyName">Company Name</label>
		<asp:textbox CssClass="text" id="txtBillingCompanyName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	</li>
		
	<li class="required">
		<label for="txtBillingPhoneNumber">* Phone Number</label>
		<asp:textbox CssClass="text" id="txtBillingPhoneNumber" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator2" ErrorMessage="Enter Phone Number" ControlToValidate="txtBillingPhoneNumber" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li class="required">
		<label for="txtBillingEmail">* Email Address</label>
		<asp:TextBox CssClass="text" ID="txtBillingEmail" runat="server"></asp:TextBox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator16" ErrorMessage="Enter a Email Address" ControlToValidate="txtBillingEmail"
			Runat="server" Display="Dynamic" ValidationGroup="1" CssClass="Error"></asp:requiredfieldvalidator>
		<asp:regularexpressionvalidator id="regemailID" runat="server" ControlToValidate="txtBillingEmail" ErrorMessage="*Please use a valid email address."
			Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" ValidationGroup="1" CssClass="Error"></asp:regularexpressionvalidator>
	</li>
		
	<li class="required">
		<label for="txtBillingStreet1">* Street1</label>
		<asp:textbox CssClass="text" id="txtBillingStreet1" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator3" ErrorMessage="Enter Street" ControlToValidate="txtBillingStreet1" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li>
		<label for="txtBillingStreet2">Street2</label>
		<asp:textbox CssClass="text" id="txtBillingStreet2" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	</li>
		
	<li class="required">
		<label for="txtBillingCity">* City</label>
		<asp:textbox CssClass="text" id="txtBillingCity" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator4" ErrorMessage="Enter City" ControlToValidate="txtBillingCity" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li class="required">
		<label for="txtBillingState">* State/Province</label>
		<asp:textbox CssClass="text" id="txtBillingState" runat="server" width="30" columns="10" MaxLength="2"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator6" ErrorMessage="Enter State" ControlToValidate="txtBillingState" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li class="required">
		<label for="txtBillingPostalCode">* Zip/Postal Code</label>
		<asp:textbox CssClass="text" id="txtBillingPostalCode" runat="server" width="130" columns="30" MaxLength="20"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator12" ErrorMessage="Enter Postal Code" ControlToValidate="txtBillingPostalCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li class="required">
		<label for="lstBillingCountryCode">* Country</label>
		<asp:DropDownList ID="lstBillingCountryCode" runat="server"></asp:DropDownList>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator13" ErrorMessage="Select Country Code" ControlToValidate="lstBillingCountryCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>
		
	<li>
		<asp:CheckBox CssClass="form-backward-checkbox" ID="chkSameAsBilling" runat="server" Text="Shipping Address is same as Billing" Checked="true" OnCheckedChanged="chkSameAsBilling_CheckedChanged" AutoPostBack="true" />
	</li>

</ol>
</div>
<div id="shoppingcart-shipping">
    <asp:Panel ID="pnlShipping" runat="server" Visible="false">
    	
	    <h2>Shipping Address</h2>

	    <ol class="form">
		    <li class="required">
			    <label for="txtShippingFirstName">* First Name</label>
			    <asp:textbox CssClass="text" id="txtShippingFirstName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator5" ErrorMessage="Enter First Name" ControlToValidate="txtShippingFirstName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    			
		    <li class="required">
			    <label for="txtShippingLastName">* Last Name</label>
			    <asp:textbox CssClass="text" id="txtShippingLastName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator7" ErrorMessage="Enter Last Name" ControlToValidate="txtShippingLastName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    			
		    <li>
			    <label for="txtShippingCompanyName">Company Name</label>
			    <asp:textbox CssClass="text" id="txtShippingCompanyName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		    </li>
    			
		    <li class="required">
			    <label for="txtShippingPhoneNumber">* Phone Number</label>
			    <asp:textbox CssClass="text" id="txtShippingPhoneNumber" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator8" ErrorMessage="Enter Phone Number" ControlToValidate="txtShippingPhoneNumber" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    			
		    <li class="required">
			    <label for="txtShippingEmail">* Email Address</label>
			    <asp:Textbox CssClass="text" ID="txtShippingEmail" runat="server"></asp:TextBox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator17" ErrorMessage="Enter a Email Address" ControlToValidate="txtShippingEmail" Runat="server" Display="Dynamic" ValidationGroup="1" CssClass="Error"></asp:requiredfieldvalidator>
			    <asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="txtShippingEmail" ErrorMessage="*Please use a valid email address." Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" ValidationGroup="1" CssClass="Error"></asp:regularexpressionvalidator>
		    </li>
    			
		    <li class="required">
			    <label for="txtShippingStreet1">* Street1</label>
			    <asp:textbox CssClass="text" id="txtShippingStreet1" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator9" ErrorMessage="Enter Street" ControlToValidate="txtShippingStreet1" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    			
		    <li>
			    <label for="txtShippingStreet2">Street2</label>
			    <asp:textbox CssClass="text" id="txtShippingStreet2" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		    </li>
    			
		    <li class="required">
			    <label for="txtShippingCity">* City</label>
			    <asp:textbox CssClass="text" id="txtShippingCity" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator10" ErrorMessage="Enter City" ControlToValidate="txtShippingCity" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    			
		    <li class="required">
			    <label for="txtShippingState">* State</label>
			    <asp:textbox CssClass="text" id="txtShippingState" runat="server" width="30" columns="10" MaxLength="2"></asp:textbox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator11" ErrorMessage="Enter State" ControlToValidate="txtShippingState" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    			
		    <li class="required">
			    <label for="txtShippingPostalCode">* Zip/Postal Code</label>
			    <asp:textbox CssClass="text" id="txtShippingPostalCode" runat="server" width="130" columns="30" MaxLength="20"></asp:textbox>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator14" ErrorMessage="Enter Postal Code" ControlToValidate="txtShippingPostalCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    			
		    <li class="required">
			    <label for="lstShippingCountryCode">* Country</label>
			    <asp:DropDownList ID="lstShippingCountryCode" runat="server"></asp:DropDownList>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator15" ErrorMessage="Select Country Code" ControlToValidate="lstShippingCountryCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>
    		
	    </ol>
    	
    </asp:Panel>

</div>

