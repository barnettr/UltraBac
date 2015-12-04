<%@ Control Language="C#" AutoEventWireup="true" CodeFile="licensingForm.ascx.cs"
	Inherits="_controls_forms_licensingForm" %>

<asp:PlaceHolder runat="server" ID="uxForm">
<ZNode:Content runat="server" />
<fieldset>
	<h2>Contact Information</h2>
	<ol class="form">
		<li>
			<asp:Label runat="server" AssociatedControlID="emailInput"><span style="color:Red;">*</span> Email Address:</asp:Label>
			<input runat="server" runat="server" id="emailInput" name="Email Address" class="text" />
			<a style="text-decoration: none" href="#Email"><b>?</b></a> 
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="emailInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Dynamic" ErrorMessage="Email is required." /> 
			<asp:RegularExpressionValidator runat="server" ForeColor="" SetFocusOnError="true"  CssClass="Error"
                Display="Static" ControlToValidate="emailInput" 
                ValidationGroup="license"
                ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
			    Please enter a valid email address.
            </asp:RegularExpressionValidator>
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="companyInput"><span style="color:Red;">*</span> Name of Company Using the Software:</asp:Label>
			<input runat="server" id="companyInput" class="text" name="Name of Company Using the Software" />
			<a style="text-decoration: none" href="#company"><b>?</b></a> 
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="companyInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Static" ErrorMessage="Company is required." /> 
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="customernumberInput">Customer Number:</asp:Label>
			<input runat="server" id="customernumberInput" class="text" name="Customer Number" />
			<a style="text-decoration: none" href="#customernumber"><b>?</b></a> 
		
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="lastnameInput"><span style="color:Red;">*</span> Last Name:</asp:Label>
			<input runat="server" id="lastnameInput" name="Last Name" class="text" />
			<a style="text-decoration: none" href="#lastfirstname"><b>?</b></a> 
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="lastnameInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Dynamic" ErrorMessage="Last Name is required." /> 
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="firstnameInput"><span style="color:Red;">*</span> First Name:</asp:Label>
			<input runat="server" id="firstnameInput" name="First Name" class="text" />
			<a style="text-decoration: none" href="#lastfirstname"><b>?</b></a> 
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="firstnameInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Dynamic" ErrorMessage="First Name is required." /> 
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="phoneInput"><span style="color:Red;">*</span> Phone Number:</asp:Label>
			<input runat="server" id="phoneInput" name="Phone Number" class="text" />
			<a style="text-decoration: none" href="#phone"><b>?</b></a> 
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="phoneInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Dynamic" ErrorMessage="Phone is required." /> 
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="ponumberInput">P.O. Number:</asp:Label>
			<input runat="server" id="ponumberInput" name="P.O. Number" class="text" />
			<a style="text-decoration: none" href="#ponumber"><b>?</b></a> 
			
		</li>
	</ol>
</fieldset>
<fieldset>
	<h2>
		UltraBac Information</h2>
	<ol class="form">
		<li>
			<asp:Label runat="server" AssociatedControlID="versionInput"><span style="color:Red;">*</span> UltraBac Version:</asp:Label>
			<asp:DropDownList id="versionInput" runat="server">
				<asp:ListItem value="9.x" Selected="True" />
				<asp:ListItem value="8.x" />
				<asp:ListItem value="7.x" />
			</asp:DropDownList>
			<a style="text-decoration: none" href="#version"><b>?</b></a> 
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="versionInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Dynamic" ErrorMessage="Version Number is required." /> 
		</li>			
		<li>
			<asp:Label runat="server" AssociatedControlID="computernameInput"><span style="color:Red;">*</span> Computer Name:</asp:Label>
			<input runat="server" id="computernameInput" class="text" name="Computer Name" />
			<a style="text-decoration: none" href="#computername"><b>?</b></a> 
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="computernameInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Dynamic" ErrorMessage="Computer Name is required." /> 
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="licenseInput">Licensing Type:</asp:Label>
			<select runat="server" id="licenseInput" name="Licensing Type">
				<option value="Permanent" selected>Permanent</option>
				<option value="Evaluation Extension">Evaluation Extension</option>
			</select>
			<a style="text-decoration: none" href="#license"><b>?</b></a>
			<asp:RequiredFieldValidator runat="server" ValidationGroup="license" ControlToValidate="licenseInput" CssClass="Error" ForeColor="" SetFocusOnError="true"  Display="Dynamic" ErrorMessage="License Type is required." /> 
		</li>
		<li>
			<asp:Label runat="server" AssociatedControlID="commentsInput">Comments:</asp:Label>
			<textarea runat="server" id="commentsInput" name="Comments" rows="5" cols="40"></textarea>
		
		</li>
	</ol>
</fieldset>
<div>
	<p class="aligncenter">
		<strong>When you have entered all information above,<br />
			please press the SUBMIT button.</strong><br />
		<asp:Button ValidationGroup="license" CssClass="submit marginCenter floatnone" runat="server" type="submit" Text="Submit" OnClick="Submit_Click" />
	</p>
</div>
<p>
	&nbsp;</p>
<p>
	<a name="Email"><b>Email Address:</b></a>&nbsp;&nbsp;(<a href="#top" name="Back To Top">Back
		to Top</a>)
	<br />
	This is the email address where your licensing information will be sent. Please
	fill it out carefully.</p>
<p>
	<a name="company"></a><b>Company Name:</b>&nbsp;&nbsp;(<a href="#top">Back to Top</a>)
	<br />
	Name of the company that will use the software.</p>
<p>
	<a name="customernumber"></a><b>Customer Number:</b>&nbsp;&nbsp;(<a href="#top">Back
		to Top</a>)
	<br />
	If you have purchased products from UltraBac, you should have a customer number,
	which is usually located in the Help/About/Licensing section of your licensed copy
	of UltraBac. If you don't know your customer number, please leave it blank. Maximum
	10 characters.</p>
<p>
	<a name="lastfirstname"></a><b>Last Name and First Name:</b>&nbsp;&nbsp;(<a href="#top">Back
		to Top</a>)
	<br />
	Please enter the name of the person responsible for system backups.</p>
<p>
	<a name="phone"></a><b>Phone Number:</b>&nbsp;&nbsp;(<a href="#top">Back to Top</a>)
	<br />
	Please enter a phone number where someone who can answer questions about this licensing
	request may be reached.</p>
<p>
	<a name="ponumber"></a><b>P.O. Number:</b>&nbsp;&nbsp;(<a href="#top">Back to Top</a>)
	<br />
	Purchase order number for this license. (Optional)</p>
<p>
	<a name="version"></a><b>Version:</b>&nbsp;&nbsp;(<a href="#top">Back to Top</a>)
	<br />
	Select the version of UltraBac that appears on your UltraBac display. This is the
	version that you are licensing.</p>
<p>
	<a name="computername"></a><b>Computer Name:</b>&nbsp;&nbsp;(<a href="#top">Back to
		Top</a>)
	<br />
	Within UltraBac, go to Help/About/Licensing. Select the computer name from the drop-down
	menu. This should be ALL CAPS.</p>
<p>
	<a name="license"></a><b>Licensing Type:</b>&nbsp;&nbsp;(<a href="#top">Back to Top</a>)
	<br />
	Select either "Evaluation Extension" or "Permanent." A Permanent License is available
	only if you have received and paid an invoice.
</p>
<p>
	If you have further questions, please contact the licensing department at 425.644.6000
	or <a title="licensing@ultrabac.com" href="mailto:licensing@ultrabac.com?subject=Online Inquiry">
		licensing@ultrabac.com</a>.</p>
</asp:PlaceHolder>

<ZNode:CustomMessage ID="uxMessage" runat="server" MessageKey="LicensingFormSubmitted" Visible="false" />