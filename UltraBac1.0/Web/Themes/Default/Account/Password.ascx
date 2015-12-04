<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Password.ascx.cs" Inherits="Themes_Default_Account_Password" %>


<h1>Change Your Password</h1>


<asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/account.aspx"
    ContinueDestinationPageUrl="~/account.aspx" DisplayUserName="False" ChangePasswordTitleText="" OnChangePasswordError="ChangePassword1_ChangePasswordError" >
    
<SuccessTemplate>
<asp:Panel ID="pnlConfirm" runat="server">    
           <asp:Label ID="lblMessage" CssClass="message" Text="Your password has been changed!" runat="server"></asp:Label>
           <p><asp:Button ID="ContinuePushButton" runat="server" CssClass="Button" CausesValidation="False" CommandName="Continue" Text="Continue" /></p>
        </asp:Panel>
    </SuccessTemplate>


    <ChangePasswordTemplate>

		<asp:CompareValidator ID="NewPasswordCompare" runat="server" 
			ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" 
			ErrorMessage="The Confirm New Password must match the New Password entry."
			ValidationGroup="ChangePassword1" CssClass="Error"></asp:CompareValidator>
		
		<asp:Literal ID="PasswordFailureText" runat="server" EnableViewState="False"></asp:Literal>


		<ol class="form">
			<li>
				<asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Current Password</asp:Label>
				<asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
					ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1" CssClass="Error" Display="Dynamic">Password is required.</asp:RequiredFieldValidator>
			</li>
				
			<li>
				<asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password</asp:Label>
				<asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
					ErrorMessage="New Password is required." ToolTip="New Password is required."
				ValidationGroup="ChangePassword1" CssClass="Error" Display="Dynamic">New Password is required.</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NewPassword"
					Display="Dynamic" ErrorMessage="New Password length should be minimum 5" SetFocusOnError="True"
					ToolTip="New Password length should be minimum 5" ValidationExpression="[A-Za-z0-9\S*]{5,}"
					ValidationGroup="ChangePassword1" CssClass="Error">New Password length should be minimum 5</asp:RegularExpressionValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NewPassword"
					Display="Dynamic" ErrorMessage="New Password should contain only alphanumeric values"
					ValidationExpression="^[a-zA-Z0-9]+$" ValidationGroup="ChangePassword1" CssClass="Error"></asp:RegularExpressionValidator>
			</li>
				
			<li>
				<asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password</asp:Label>
				<asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
					ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
					ValidationGroup="ChangePassword1" CssClass="Error" Display="Dynamic">Confirm New Password is required.</asp:RequiredFieldValidator>
			</li>
				
			<li>
				<asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Change Password" ValidationGroup="ChangePassword1" CssClass="Button" />
				<asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="Button"  />
			</li>
		
		</ol>

	</ChangePasswordTemplate>
</asp:ChangePassword>

