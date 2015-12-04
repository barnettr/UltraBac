<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Themes_Default_Account_Login" %>

<div id="Content">

	<h1>Log In</h1>

<div class="clear"></div>
	<asp:Login ID="uxLogin" runat="server" MembershipProvider="ZNodeMembershipProvider" PasswordRecoveryText="Forgot Password?" PasswordRecoveryUrl="~/forgotpassword.aspx" OnAuthenticate="uxLogin_Authenticate" DisplayRememberMe="False" Width="100%">
		<LayoutTemplate>
			<asp:Panel ID="CheckoutPanel" DefaultButton="Loginbutton" runat="server">
			
				<h2>Already a User?</h2>
				
				<asp:ValidationSummary runat="server" CssClass="Error" ForeColor="" ValidationGroup="uxLogin" />
				<div class="Error">
				<asp:literal ID="FailureText" runat="server" EnableViewState="False" />
				</div>
				<ol class="form">
					<li class="required">
						<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
						<asp:TextBox ID="UserName" runat="server" CssClass="text"></asp:TextBox>
						<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ForeColor=""
							ErrorMessage="User Name is required." ToolTip="User Name is required." 
							ValidationGroup="uxLogin" Display="None" CssClass="Error">User Name is required.</asp:RequiredFieldValidator>
					</li>
					
					<li class="required">
						<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
						<asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
						<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ForeColor=""
							ErrorMessage="Password is required." ToolTip="Password is required." 
							ValidationGroup="uxLogin" Display="None" CssClass="Error">Password is required.</asp:RequiredFieldValidator>

						<div class="forgot">
							<label></label>
							<asp:LinkButton ID="ForgotPassword" runat="Server" Text="Forgot Password" OnClick="ForgotPassword_Click" CssClass="submit"></asp:LinkButton>
							<!-- 
								<asp:HyperLink ID="PasswordRecoveryLink" runat="server" 
									NavigateUrl="~/ForgotPassword.aspx">Forgot Password?</asp:HyperLink> 
							-->
						</div>
					</li>
					
					<li class="submit">
						<label></label>
						<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="uxLogin" CssClass="submit" />
					</li>

				</ol>


			</asp:Panel>
		</LayoutTemplate>
	</asp:Login>




	<h2>New User?</h2>

	<asp:ValidationSummary runat="server" CssClass="Error" ForeColor="" ValidationGroup="uxCreateUserWizard" />

		<asp:Label ID="ErrorMessage" CssClass="Error" runat="server" EnableViewState="False"></asp:Label>
	
	<asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ForeColor=""
		ControlToValidate="ConfirmPassword" ErrorMessage="The Password and Confirmation Password must match."
		ValidationGroup="uxCreateUserWizard" CssClass="Error" Display="None"></asp:CompareValidator>
		

	<ol class="form">
		<li class="required">
			<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
			<asp:TextBox ID="UserName" runat="server" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ForeColor=""
				ErrorMessage="User Name is required." ToolTip="User Name is required." 
				ValidationGroup="uxCreateUserWizard" CssClass="Error" Display="None">User Name is required.</asp:RequiredFieldValidator>
		</li>
			
		<li class="required">
			<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
			<asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ForeColor=""
				ErrorMessage="Password is required." ToolTip="Password is required." 
				ValidationGroup="uxCreateUserWizard" CssClass="Error" Display="None">Password is required.</asp:RequiredFieldValidator>
		</li>
			
		<li class="required">
			<asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password</asp:Label>
			<asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ForeColor=""
				ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
				ValidationGroup="uxCreateUserWizard" CssClass="Error" Display="None">Confirm Password is required.</asp:RequiredFieldValidator>
		</li>
		
		<li class="required">
			<asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email</asp:Label>
			<asp:TextBox ID="Email" runat="server" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ForeColor=""
				ErrorMessage="Email is required." ToolTip="E-mail is required." 
				ValidationGroup="uxCreateUserWizard" CssClass="Error" Display="None">Email is required.</asp:RequiredFieldValidator>
		</li>
		
		<li class="required">
			<asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question</asp:Label>
			<asp:TextBox ID="Question" runat="server" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ForeColor=""
				ErrorMessage="Security question is required." ToolTip="Security question is required."
				ValidationGroup="uxCreateUserWizard" CssClass="Error" Display="None">Security question is required.</asp:RequiredFieldValidator>
		</li>
		
		<li class="required">
			<asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer</asp:Label>
			<asp:TextBox ID="Answer" runat="server" CssClass="text"></asp:TextBox>
			<asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ForeColor=""
				ErrorMessage="Security answer is required." ToolTip="Security answer is required."
				ValidationGroup="uxCreateUserWizard" CssClass="Error" Display="None">Security answer is required.</asp:RequiredFieldValidator>
		</li>

		<li class="submit">
			<label></label>
			<asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="submit" CausesValidation="true" ValidationGroup="uxCreateUserWizard" OnClick="btnRegister_Click" />
		</li>

	</ol>

</div>

