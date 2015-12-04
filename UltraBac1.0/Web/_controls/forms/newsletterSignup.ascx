<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newsletterSignup.ascx.cs" Inherits="_controls_forms_newsletterSignup" %>
	
	<script type="text/javascript">
	    Event.observe(window, 'load', CheckboxInit);
	    
	    var checkboxes;
	    function CheckboxInit(e)
	    {
	     checkboxes = $('chklist').select('[type="checkbox"]');
            checkboxes.each(function(s, index) {
            s.observe('click', HandleCheck);
        });
	    }
	
	    function HandleCheck(e) {
	        if (e.target.value == 'Unsubscribe' && e.target.checked) {
	            checkboxes.each(function(s, index) {
	                if (s.value != e.target.value)
	                    s.checked = false;
	            });
	        } else if (e.target.checked) {
	            checkboxes.each(function(s, index) {
	                if (s.value == 'Unsubscribe')
	                    s.checked = false;
	            });
	        }
	    }

	    function ValidateCheckbox(source, clientside_arguments) {

	        var unsubscribeChecked = false;
	        var otherOneChecked = false;
	        checkboxes.each(function(s, index) {
	            if (s.value == 'Unsubscribe' && s.checked) {
	                unsubscribeChecked = true;
	            } else if (s.checked) {
	                otherOneChecked = true;
	            }
	        });
	        if (
            (unsubscribeChecked && !otherOneChecked) ||
            (otherOneChecked && !unsubscribeChecked)
            ) {
	            clientside_arguments.IsValid = true;
	        } else if (unsubscribeChecked && otherOneChecked) {
	            clientside_arguments.IsValid = false;
	        } else {
	            clientside_arguments.IsValid = false;
	        }
	    }

	    document.observe("dom:loaded", function() {
	        $$(".submitMailingList").reduce().up("form").observe("submit", function(e) {
	            if ($$(".unsubscribe input").reduce().checked) {
	                e.stop();
                    var agree=confirm("Warning:  You will not be notified of any product updates.  Do you still wish to be removed?");
                    if (agree) {
                        $$(".submitMailingList").reduce().up("form").submit();
                    } else {
                        return false ;
                    }
                }
	        });
	    });
	    
	</script>	
	<asp:PlaceHolder runat="server" ID="uxForm">
	<ZNode:Content runat="server" />	
	<p><span style="color:Red;">*</span> = required</p>
	<fieldset>
		<ol class="form">
			<li>
				<asp:Label AssociatedControlID="uxEmailAddress" runat="server"><span style="color:Red;">*</span> Enter Address:</asp:Label>
				<asp:TextBox CssClass="text" runat="server" ID="uxEmailAddress" ValidationGroup="NewsletterSignup" />
				<asp:RegularExpressionValidator runat="server" ForeColor="" ControlToValidate="uxEmailAddress" SetFocusOnError="true" CssClass="Error"
						ErrorMessage="Email address is not recognized" Display="Dynamic" ValidationExpression="^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$"
						ValidationGroup="NewsletterSignup" />
				<asp:RequiredFieldValidator runat="server" ForeColor="" ControlToValidate="uxEmailAddress" SetFocusOnError="true" CssClass="Error"
						ErrorMessage="Email address is not recognized" Display="Dynamic" ValidationGroup="NewsletterSignup"></asp:RequiredFieldValidator>
				</li>
			<li>
				<asp:Label AssociatedControlID="uxContactName" runat="server" Text="Contact Name:" />
				<asp:TextBox runat="server" ID="uxContactName" CssClass="text" />
			</li>
			<li>
				<asp:Label AssociatedControlID="uxCompanyName" runat="server" Text="Company Name:" />
				<asp:TextBox runat="server" ID="uxCompanyName" CssClass="text" />
			</li>
			<li>
				<asp:Label AssociatedControlID="uxAddress1" runat="server" Text="Street Address:" />
				<asp:TextBox runat="server" ID="uxAddress1" CssClass="text" />
			</li>
			<li>
				<asp:Label AssociatedControlID="uxAddress2" runat="server" Text="Street Address 2:" />
				<asp:TextBox runat="server" ID="uxAddress2" CssClass="text" />
			</li>
			<li>
				<asp:Label AssociatedControlID="uxCity" runat="server" Text="City:" />
				<asp:TextBox runat="server" ID="uxCity" CssClass="text" />
			</li>
			<li>
				<asp:Label AssociatedControlID="uxState" runat="server" Text="State/Province:" />
				<asp:TextBox runat="server" ID="uxState" CssClass="text" />
			</li>
			<li>
				<asp:Label AssociatedControlID="uxPostal" runat="server" Text="Zip/Postal Code:" />
				<asp:TextBox runat="server" ID="uxPostal" CssClass="text" />
				<asp:RegularExpressionValidator runat="server" ForeColor="" ControlToValidate="uxPostal"
						CssClass="Error" SetFocusOnError="true"
						ErrorMessage="Postal Code Not Recognized" Display="Dynamic" ValidationExpression="^[0-9\-]+$"
						ValidationGroup="NewsletterSignup" />
				</li>
			<li>
				<asp:Label AssociatedControlID="uxCountry" runat="server" Text="Country:" />
				<asp:TextBox runat="server" ID="uxCountry" CssClass="text" />
			</li>
			<li>
				<asp:Label AssociatedControlID="uxPhone" runat="server" Text="Phone:" />
				<asp:TextBox runat="server" ID="uxPhone" CssClass="text" />
				<asp:RegularExpressionValidator runat="server" ForeColor="" ControlToValidate="uxPhone" SetFocusOnError="true" CssClass="Error"
						ErrorMessage="Phone Not Recognized" Display="Dynamic" ValidationExpression="^[0-9\-\.\s\(\)]+$"
						ValidationGroup="NewsletterSignup" />
				</li>
		</ol>
        <h3>Email list preferences:</h3>
        <Pop:RadioList runat='server' CssClass='plain flush' ID="uxEmailPrefs">
            <asp:ListItem Selected="True" Text="I prefer my emails in TEXT format" Value="TEXT"></asp:ListItem>
            <asp:ListItem Text="I prefer my emails in HTML format" Value="HTML"></asp:ListItem>
        </Pop:RadioList>
        
        <h3>Please check all that apply:</h3>        
        <span class="error-message">
            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                ClientValidationFunction="ValidateCheckbox" 
                OnServerValidate="ValidateCheckbox" 
                Display="Dynamic" 
                ForeColor=""
                ErrorMessage="Please select your subscription/unsubscription options."
                ValidationGroup="NewsletterSignup"></asp:CustomValidator>
        </span>
        <div id="chklist">
        <Pop:CheckList ID="uxAction" runat="server" CssClass="plain flush" >
            <asp:ListItem Selected="True" Text="Please send email about sales promotions." Value="Sales Promotions"></asp:ListItem>
            <asp:ListItem Selected="True" Text="Please send email about quarterly newsletters." Value="Quarterly Newsletters"></asp:ListItem>
            <asp:ListItem Selected="True" Text="Please send notification when there are upgrades and bug fixes released." Value="Software Updates"></asp:ListItem>
            <asp:ListItem class="unsubscribe" Text="Please remove me from all email lists." Value="Unsubscribe" />
        </Pop:CheckList>
        </div>
        <asp:Button runat="server" ValidationGroup="NewsletterSignup" Text="Submit" CssClass="submit marginCenter floatnone"  />
       
	</fieldset>
	
	<ZNode:CustomMessage MessageKey="MailListUsage" runat="server" />
	</asp:PlaceHolder>
		
	<asp:Literal runat="server" ID="uxSubscriptionConfirmation" Visible="false" />
	
	<asp:Literal runat="server" ID="uxUnsubConfirmation" Visible="false" />
		
	
