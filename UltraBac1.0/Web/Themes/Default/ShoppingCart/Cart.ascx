<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cart.ascx.cs" Inherits="Themes_Default_ShoppingCart_Cart" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="ZNode" %>
<%@ Register Src="ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="ZNode" %>

<div id="shoppingcart-wrapper">
<div id="Content">
    <h1>Shopping Cart</h1>
    <div class="clear"></div>
    <asp:Label ID="uxMsg" CssClass="error" runat="server"></asp:Label>

    <asp:Panel ID="pnlShoppingCart" runat="server" Visible="true">       

	    <div class="cart_custom_message">
		    <ZNode:CustomMessage ID="CustomMessage1" MessageKey="CheckoutCustomerService" runat="server" />
	    </div>
    	
	    <div class="checkout_buttons">
		    <div class="floatleft">
			    <asp:ImageButton ID="ContinueShopping" runat="server" AlternateText="Continue Shopping" OnClick="ContinueShopping1_Click" />
		    </div>
		    <div class="floatright">
			    <asp:ImageButton ID="Checkout" runat="server" AlternateText="Check Out" OnClick="Checkout_Click" />
		    </div>
		    <div class="clear"></div>
	    </div>

	    <ZNode:ShoppingCart ID="uxCart" runat="server"/>
    	
	    <div class="clear"></div>
        <div class="checkout_buttons">
		    <div class="floatleft">
			    <asp:ImageButton ID="ContinueShopping1" runat="server" AlternateText="Continue Shopping" OnClick="ContinueShopping1_Click"  />
		    </div>
		    <div class="floatright">
			    <asp:ImageButton ID="Checkout1" runat="server" AlternateText="Check Out" OnClick="Checkout_Click"  />
		    </div>
		    <div class="clear"></div>
	    </div>
        
	    <p class="cart_footer"><ZNode:CustomMessage ID="CustomMessage2" MessageKey="ShoppingCartFooter" runat="server" /></p>

    </asp:Panel>
</div>
</div><!-- end of shopping cart wrapper -->
