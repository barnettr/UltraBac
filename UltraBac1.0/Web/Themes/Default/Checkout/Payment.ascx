<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Payment.ascx.cs" Inherits="Controls_ShoppingCartCheckout_Payment" %>
<div class="floatleft checkout-step-2-address">
    <h2>Billing Address</h2>
    <asp:Label ID="lblBillingAddress" runat="server"></asp:Label>
    <asp:LinkButton ID="lnkEditBilling" runat="server" Text="edit" OnClick="lnkEditAddress_Click" CausesValidation="false"></asp:LinkButton>
	<div class="clear"> </div>
</div>
<div class="floatleft checkout-step-2-address">
	<h2>Shipping Address</h2>
    <asp:Label ID="lblShippingAddress" runat="server"></asp:Label>
    <asp:LinkButton ID="lnkEditShipping" runat="server" Text="edit" OnClick="lnkEditAddress_Click" CausesValidation="false"></asp:LinkButton>
	<div class="clear"> </div>	
</div>
<div class="clear"> </div>
    <div id="shoppingcart-creditcard">
        <h2>Credit Card Information</h2>
    <asp:Panel ID="pnlCreditCard" runat="server">
	    <ol class="form">
	        <li>
	            <label for="lstPaymentType">Select Payment Option</label>
                <asp:DropDownList ID="lstPaymentType" runat="server" OnSelectedIndexChanged="lstPaymentType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </li>
		    <li class="credit_cards_accepted">
			    <label for="txtCreditCardNumber">* Card Number</label>
			    <asp:textbox id="txtCreditCardNumber" runat="server" width="130" columns="30" MaxLength="20" class="text"></asp:textbox>
			    <div>
				    <img id="imgVisa" src="~/images/shopping_cart/card_visa.gif" runat="server" alt="VISA" align="absmiddle" />
				    <img id="imgMastercard" src="~/images/shopping_cart/card_mastercard.gif" runat="server" alt="MasterCard" align="absmiddle" />
				    <img id="imgAmex" src="~/images/shopping_cart/card_amex.gif" align="absmiddle" alt="American Express" runat="server" />
				    <img id="imgDiscover" src="~/images/shopping_cart/card_discover.gif" align="absmiddle" alt="Discover" runat="server" />
			    </div>
			    <asp:requiredfieldvalidator id="req1" ErrorMessage="Enter Credit Card Number" ControlToValidate="txtCreditCardNumber" Runat="server" Display="Static" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>	
    		
		    <li class="credit_card_expire">	
			    <label for="credit_card_expiry">* Expiration Date</label>
			    <fieldset id="credit_card_expiry">
				    <asp:DropDownList ID="lstMonth" runat="server">
				        <asp:ListItem Value="">-- Month --</asp:ListItem>    
				        <asp:ListItem Value="01">Jan</asp:ListItem>
				        <asp:ListItem Value="02">Feb</asp:ListItem>
				        <asp:ListItem Value="03">Mar</asp:ListItem>
				        <asp:ListItem Value="04">Apr</asp:ListItem>
				        <asp:ListItem Value="05">May</asp:ListItem>
				        <asp:ListItem Value="06">Jun</asp:ListItem>
				        <asp:ListItem Value="07">Jul</asp:ListItem>
				        <asp:ListItem Value="08">Aug</asp:ListItem>
				        <asp:ListItem Value="09">Sep</asp:ListItem>
				        <asp:ListItem Value="10">Oct</asp:ListItem>
				        <asp:ListItem Value="11">Nov</asp:ListItem>
				        <asp:ListItem Value="12">Dec</asp:ListItem>
				    </asp:DropDownList>
				    <asp:DropDownList ID="lstYear" runat="server"></asp:DropDownList>
			    </fieldset>
		    </li>
    		
		    <li class="credit_card_security_code">
			    <label for="txtCVV">* Security Code</label>
			    <asp:textbox id="txtCVV" runat="server" width="30" columns="30" MaxLength="4" class="text"></asp:textbox>
			    <a href="cvv.html" class="lightwindow">what is this?</a>
			    <asp:requiredfieldvalidator id="Requiredfieldvalidator2" ErrorMessage="Enter Credit Card Security Code" ControlToValidate="txtCVV" Runat="server" Display="Static" CssClass="Error"></asp:requiredfieldvalidator>
		    </li>

	    </ol>	


    </asp:Panel>



    <p>
	    <label for="txtAdditionalInstructions">Special instructions or comments about your order</label>
	    <asp:TextBox Columns="45" Rows="5" ID="txtAdditionalInstructions" runat="server" TextMode="SingleLine"></asp:TextBox>
    </p>
</div>