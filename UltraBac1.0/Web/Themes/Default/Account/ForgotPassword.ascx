<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.ascx.cs" Inherits="Themes_Default_Account_ForgotPassword" %>

<div id="Content">
<h1>Reset Your Password</h1>


<asp:PasswordRecovery ID="PasswordRecovery1" runat="server" MembershipProvider="ZNodeMembershipProvider" CssClass="ForgetPassword" UserNameTitleText="" OnSendingMail="PasswordRecovery1_SendingMail" >

        <MailDefinition Subject="Your Account" />
		
		<InstructionTextStyle CssClass="InstructionTextStyle" />
        <SuccessTextStyle CssClass="SucessTextStyle"/>
        <TextBoxStyle CssClass="TextBoxStyle"/>
		
		
		<UserNameTemplate>
          <asp:Panel id="Panel1" DefaultButton="SubmitButton" runat="server">
			
			<asp:Label ID="FailureText" CssClass="Error" runat="server" EnableViewState="false" />
			<asp:Literal ID="Message" runat="server" EnableViewState="False"></asp:Literal>
			
			<p>Enter your User Name to receive your password.</p>
			<ol class="form">
				<li>
					<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
					<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
		 			 <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
					ErrorMessage="User Name is required" ToolTip="User Name is required" ValidationGroup="PasswordRecovery1" Display="Dynamic">*</asp:RequiredFieldValidator>
					</li>
				<li>
				    <label></label>
					<asp:Button ID="SubmitButton" runat="server" CssClass="submit" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" />
				</li>
			</ol>
          </asp:Panel> 
        </UserNameTemplate>
		
		
		<QuestionTemplate>
          <asp:Panel id="QuestionPanel" DefaultButton="SubmitButton" runat="server">
		  
		  	<asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
		  
		  	<p>Please answer the following secret question to receive your new password by email.</p>
			<ol class="form">
			<li>
				<span class="label">User Name: </span>
				<asp:Literal ID="UserName" runat="server"></asp:Literal>
			</li>
			<li>
				<span class="label">Secret Question: </span>
				<asp:Literal ID="Question" runat="server"></asp:Literal>
			</li>
			<li class="required">
				<asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Secret Answer</asp:Label>
				<asp:TextBox ID="Answer" runat="server"></asp:TextBox>
				<asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
					ErrorMessage="Secret Answer is required" ToolTip="Secret Answer is required" ValidationGroup="PasswordRecovery1" Display="Dynamic">*</asp:RequiredFieldValidator>
			</li>
			<li class="submit">
			    <label>&nbsp;</label>
				<asp:Button ID="SubmitButton" runat="server" CssClass="submit" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" />
			</li>
</ol>
      </asp:Panel>
   </QuestionTemplate>
    
	
	<TitleTextStyle CssClass="TitleTextStyle" />
    <SubmitButtonStyle  CssClass="SubmitButtonStyle" />   


</asp:PasswordRecovery>  

</div>