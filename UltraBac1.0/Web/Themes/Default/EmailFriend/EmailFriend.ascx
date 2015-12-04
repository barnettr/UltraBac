<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmailFriend.ascx.cs" Inherits="Themes_Default_EmailFriend_EmailFriend" %>
<%@ Register Src="~/Controls/spacer.ascx" TagName="Spacer" TagPrefix="ZNode" %>

<h1>Email a Friend</h1>

<asp:Panel ID="pnlEmailFriend" runat="server">
	<ol class="form">
		<li>
			<span class="label">Product</span>
			<%= GetProductName() %>
		</li>
			
			
		<li class="required">
			<asp:Label ID="FromEmailLabel" runat="server" AssociatedControlID="FromEmailID">Your Email</asp:Label>
			<asp:TextBox ID="FromEmailID" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FromEmailID" 
				ErrorMessage="Your Email is required." ToolTip="Email is required." CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FromEmailID"
				ErrorMessage="Enter Valid Email address." ToolTip="Enter Valid Email address." CssClass="Error" 
				ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>                    
		</li>	
			
			
		<li class="required">
			<asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Friend's Email</asp:Label>
			<asp:TextBox ID="Email" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="Friend's Email is required."
				ToolTip="Friend's Email is required." CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
				ErrorMessage="Enter valid email address" ToolTip="Enter valid email address" CssClass="Error" 
				ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
		</li>
		
		<li class="submit">
			<asp:Button ID="but_Send" runat="server" CssClass="Button" OnClick="but_Send_Click" Text="Send" />
		</li>
	</ol>
</asp:Panel>


<asp:Panel ID="pnlConfirm" runat="server" Visible="false">
	
	<div class="message">
    	<asp:Label ID="lblMessage" runat="server"></asp:Label>         

    	<p><asp:LinkButton ID="BackLink" CssClass="BackLink" runat="server" OnClick="Back_Click" CausesValidation="false">&#60; Back to Product</asp:LinkButton></p>
	</div>

</asp:Panel>                






