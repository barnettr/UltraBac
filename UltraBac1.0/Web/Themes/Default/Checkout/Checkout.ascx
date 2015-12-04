<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Checkout.ascx.cs" Inherits="Themes_Default_Checkout_Checkout" %>
<%@ Register Src="StepTracker.ascx" TagName="StepTracker" TagPrefix="uc6" %>
<%@ Register Src="Confirm.ascx" TagName="Confirm" TagPrefix="uc7" %>
<%@ Register Src="Order.ascx" TagName="Order" TagPrefix="uc4" %>
<%@ Register Src="Payment.ascx" TagName="Payment" TagPrefix="uc5" %>
<%@ Register Src="Address.ascx" TagName="Address" TagPrefix="uc3" %>
<div id="purchase-wrap">
<div id="Content">
    <h1>Secure Checkout</h1>
    <div class="clear"></div>
    <div id="Checkout_Steps">
	    <uc6:StepTracker ID="uxStepTracker" runat="server" />
    </div>


    <asp:label class="Error" id="lblError" runat="server" EnableViewState="false"></asp:label>


    <asp:Wizard ID="uxWizard" runat="server" CancelButtonType="Image" DisplaySideBar="False" FinishCompleteButtonText="" FinishPreviousButtonText="Back" Font-Names="Verdana" Width="100%" StartNextButtonText="" StepNextButtonText="" OnNextButtonClick="OnNext" OnPreRender="OnWizardPreRender">

        <WizardSteps>
            <asp:WizardStep ID="step1" runat="server" Title="step2" StepType="Start">
                <div class="Overview">
				    Enter your billing and shipping addresses. For credit card payments enter the billing address on the credit card.
                </div>
                <uc3:Address ID="uxAddress" runat="server" />
            </asp:WizardStep>
    		
            <asp:WizardStep ID="step2" runat="server" Title="step3" StepType="Finish">
                <p>Please review your order and provide payment information</p>
            			    <div>
			        <uc5:Payment ID="uxPayment" runat="server" />
			    </div>
                <div>
				    <uc4:Order ID="uxOrder" runat="server" />
			    </div>
            </asp:WizardStep> 
    		
            <asp:WizardStep ID="step3" runat="server" Title="step4" StepType="Complete">
			    <div>
		   		    <uc7:Confirm ID="uxConfirm" runat="server" />
			    </div>
               
		       <a class="home_link" href="~/default.aspx" id="HomeLink" runat="server">Back to Home Page</a>
            </asp:WizardStep>                              
        </WizardSteps>
    	
        <StepNextButtonStyle CssClass="btn_next" />
        <StartNextButtonStyle CssClass="btn_next" />
        <StepPreviousButtonStyle CssClass="Button" />

        <FinishNavigationTemplate>
    	
		    <asp:Button ID="SubmitButton" runat="server" Text="" OnClick="OnSubmitOrder"  CssClass="btn_submitOrder" />
    		
        </FinishNavigationTemplate>

    </asp:Wizard>
</div>
</div>