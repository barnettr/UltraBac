<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="Themes_Default_Contact_Contact" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>

<asp:Panel ID="pnlContact" runat="server" Visible="true">


    <h1>Contact Us</h1>
    
	
	<asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
    
	<p>
        <uc1:custommessage id="CustomMessage1" runat="server" messagekey="ContactUsIntro"></uc1:custommessage>
    </p>
	
	
	<ol class="form">
	    <li class="required">
			<asp:Label ID="lblName" runat="server" AssociatedControlID="FirstName">First Name</asp:Label>
			<asp:TextBox ID="FirstName" runat="server" MaxLength="100" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="FirstName"
				CssClass="Error" Display="Dynamic" ErrorMessage="First Name is required." ToolTip="First Name is required.">First Name is required.</asp:RequiredFieldValidator>
		</li>
		
		<li class="required">
			<asp:Label ID="Label1" runat="server" AssociatedControlID="LastName">Last Name</asp:Label>
			<asp:TextBox ID="LastName" runat="server" MaxLength="100" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LastName"
				CssClass="Error" Display="Dynamic" ErrorMessage="Last Name is required." ToolTip="Last Name is required.">Last Name is required.</asp:RequiredFieldValidator>
		</li>
		
		<li>
			<asp:Label ID="lblCompanyName" runat="server" AssociatedControlID="CompanyName">Company Name</asp:Label>
			<asp:TextBox ID="CompanyName" runat="server" MaxLength="100" CssClass="text"></asp:TextBox>
		</li>
		
		<li class="required">
			<asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email Address</asp:Label>
			<asp:TextBox ID="Email" runat="server" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
				CssClass="Error" Display="Dynamic" ErrorMessage="Email is required." ToolTip="Email is required.">Email is required.</asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
				CssClass="Error" Display="Dynamic" ErrorMessage="Enter Valid Email Id" ToolTip="Enter Valid Email Id."
				ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
		</li>
		
		<li>
			<asp:Label ID="PhoneNumberLabel" runat="server" AssociatedControlID="PhoneNumber">Phone Number</asp:Label>
			<asp:TextBox ID="PhoneNumber" runat="server" MaxLength="20" CssClass="text"></asp:TextBox>
		</li>
		
		<li class="required">
			<asp:Label ID="CommentsLabel" runat="server" AssociatedControlID="Comments">Comments</asp:Label>
			<asp:TextBox ID="Comments" runat="server"  TextMode="MultiLine"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Comments"
				CssClass="Error" Display="Dynamic" ErrorMessage="Comments is required." ToolTip="Comments is required."
				ValidationGroup="uxCreateUserWizard">Comments is required.</asp:RequiredFieldValidator>
		</li>		
		
		<li class="submit">	
		    <label></label>
			<asp:Button ID="btnSubmit" runat="server" CssClass="submit" OnClick="btnSubmit_Click" Text="Submit" />
		</li>
	
</ol>

</asp:Panel>

<asp:Panel ID="pnlConfirm" runat="server" Visible="false" CssClass="SuccessMsg">
    <div class="message">
		<p>We have received your information and will be contacting you soon. Thank you.</p>
	</div>
</asp:Panel>


