<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Address.ascx.cs" Inherits="Themes_Default_Account_Address" %>


<h1>Update your Address</h1>


<h2>Billing Address</h2>

<ol class="form">
	<li class="required">
		<label for="txtBillingFirstName">First Name</label>
		<asp:textbox id="txtBillingFirstName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="req1" ErrorMessage="Enter First Name" ControlToValidate="txtBillingFirstName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="txtBillingLastName">Last Name</label>
		<asp:textbox id="txtBillingLastName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator1" ErrorMessage="Enter Last Name" ControlToValidate="txtBillingLastName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li>
		<label for="txtBillingCompanyName">Company Name</label>
		<asp:textbox id="txtBillingCompanyName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	</li>

	<li class="required">
		<label for="txtBillingPhoneNumber">Phone Number</label>
		<asp:textbox id="txtBillingPhoneNumber" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator2" ErrorMessage="Enter Phone Number" ControlToValidate="txtBillingPhoneNumber" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="txtBillingEmail">Email Address</label>
		<asp:TextBox ID="txtBillingEmail" runat="server"></asp:TextBox>
		<asp:regularexpressionvalidator id="regemailID" runat="server" ControlToValidate="txtBillingEmail" ErrorMessage="*Please use a valid email address."
								                Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" CssClass="Error"></asp:regularexpressionvalidator>
	</li>

	<li class="required">
		<label for="txtBillingStreet1">Street 1</label>
		<asp:textbox id="txtBillingStreet1" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator3" ErrorMessage="Enter Street" ControlToValidate="txtBillingStreet1" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li>
		<label for="txtBillingStreet2">Street2</label>
		<asp:textbox id="txtBillingStreet2" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	</li>

	<li class="required">
		<label for="txtBillingCity">City</label>
		<asp:textbox id="txtBillingCity" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator4" ErrorMessage="Enter City" ControlToValidate="txtBillingCity" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="txtBillingState">State</label>
		<asp:textbox id="txtBillingState" runat="server" width="30" columns="10" MaxLength="2"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator6" ErrorMessage="Enter State" ControlToValidate="txtBillingState" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="txtBillingPostalCode">Postal Code</label>
		<asp:textbox id="txtBillingPostalCode" runat="server" width="130" columns="30" MaxLength="10"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator12" ErrorMessage="Enter Postal Code" ControlToValidate="txtBillingPostalCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="lstBillingCountryCode">Country</label>
		<asp:DropDownList ID="lstBillingCountryCode" Width="200" runat="server"></asp:DropDownList>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator13" ErrorMessage="Select Country Code" ControlToValidate="lstBillingCountryCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

		
	<li class="submit">
			<asp:Button ID="btnUpdate" runat="server" Text="Update Address" OnClick="btnUpdate_Click" CssClass="Button" />
	</li>


</ol>





<h3>Shipping Address</h3>

	<asp:CheckBox ID="chkSameAsBilling" runat="server" Text="Shipping Address is same as Billing" Checked="false" OnCheckedChanged="chkSameAsBilling_CheckedChanged" AutoPostBack="true" />

<asp:Panel ID="pnlShipping" runat="server" Visible="true">

<ol class="form">
	<li class="required">
		<label for="txtShippingFirstName">First Name</label>
		<asp:textbox id="txtShippingFirstName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator5" ErrorMessage="Enter First Name" ControlToValidate="txtShippingFirstName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="txtShippingLastName">Last Name</label>
		<asp:textbox id="txtShippingLastName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator7" ErrorMessage="Enter Last Name" ControlToValidate="txtShippingLastName" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li>
		<label for="txtShippingCompanyName">Company Name</label>
		<asp:textbox id="txtShippingCompanyName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	</li>

	<li class="required">
		<label for="txtShippingPhoneNumber">Phone Number</label>
		<asp:textbox id="txtShippingPhoneNumber" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator8" ErrorMessage="Enter Phone Number" ControlToValidate="txtShippingPhoneNumber" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="txtShippingEmail">Email Address</label>
		<asp:TextBox ID="txtShippingEmail" runat="server"></asp:TextBox>
		<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="txtShippingEmail" ErrorMessage="* Please use a valid email address."
			Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" CssClass="Error"></asp:regularexpressionvalidator>
	</li>

	<li class="required">
		<label for="txtShippingStreet1">Street1</label>
		<asp:textbox id="txtShippingStreet1" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator9" ErrorMessage="Enter Street" ControlToValidate="txtShippingStreet1" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li>
		<label for="txtShippingStreet2">Street2</label>
		<asp:textbox id="txtShippingStreet2" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	</li>

	<li class="required">
		<label for="txtShippingCity">City</label>
		<asp:textbox id="txtShippingCity" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator10" ErrorMessage="Enter City" ControlToValidate="txtShippingCity" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

		
	<li class="required">
		<label for="txtShippingState">State</label>
		<asp:textbox id="txtShippingState" runat="server" width="30" columns="10" MaxLength="2"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator11" ErrorMessage="Enter State" ControlToValidate="txtShippingState" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="txtShippingPostalCode">Postal Code</label>
		<asp:textbox id="txtShippingPostalCode" runat="server" width="130" columns="30" MaxLength="10"></asp:textbox>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator14" ErrorMessage="Enter Postal Code" ControlToValidate="txtShippingPostalCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>

	<li class="required">
		<label for="lstShippingCountryCode">Country</label>
		<asp:DropDownList ID="lstShippingCountryCode" Width="200" runat="server"></asp:DropDownList>
		<asp:requiredfieldvalidator id="Requiredfieldvalidator15" ErrorMessage="Select Country Code" ControlToValidate="lstShippingCountryCode" Runat="server" Display="Dynamic" CssClass="Error"></asp:requiredfieldvalidator>
	</li>


</ol>

</asp:Panel>


