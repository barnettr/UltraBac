﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="resellersOrder.ascx.cs" Inherits="_controls_forms_resellersOrder" %>

<script type="text/javascript">
    function shippingBillingClone() {
     var billing = {
            company: $$(".bill-company").first().value,
            name: $$(".bill-name").first().value,
            email: $$(".bill-email").first().value,
            phone: $$(".bill-phone").first().value,
            address: $$(".bill-address").first().value,
            suite: $$(".bill-suite").first().value,
            city: $$(".bill-city").first().value,
            postal: $$(".bill-postal").first().value,
            country: $$(".bill-country").first().value
        }

        $$("#shippingRadioList input").first().observe("focus", function(e) {
            setShippingFromBilling();  
        });        
        
        $$("#shippingRadioList input").last().observe("focus", function(e) {
            clearBilling();
        });            
        
        function setShippingFromBilling() {
            $$(".ship-company").first().value = billing.company;
            $$(".ship-name").first().value = billing.name;
            $$(".ship-city").first().value = billing.city;
            $$(".ship-email").first().value = billing.email;
            $$(".ship-phone").first().value = billing.phone;
            $$(".ship-address").first().value = billing.address;
            $$(".ship-suite").first().value = billing.suite;
            $$(".ship-postal").first().value = billing.postal;
            $$(".ship-country").first().value = billing.country;
        }
        
        function clearBilling() {
            $$("#shippingForm input").each(function(el, i) {
                el.value="";
            });
        };
        
    }
    
    document.observe("dom:loaded", function() {
        shippingBillingClone();
    });
</script>

<asp:PlaceHolder runat="server" ID="uxForm">
<ZNode:Content runat="server" />
<ZNode:CustomMessage ID="uxMessage" runat="server" MessageKey="ResellersOrderFormSubmitted" Visible="false" />
<p runat="server" id="uxInstructions">Fields marked with <span style="color:Red;">*</span> are required.</p>

<h2>Bill To:</h2>
<ol class=form>
  <li>
    <asp:Label runat="server" AssociatedControlId=customerNumberInput>Customer (R/RR) Number:</asp:Label>
    <input runat="server" class=text id=customerNumberInput name="Customer Number"/>
    <%--<asp:RequiredFieldValidator runat="server" ValidationGroup="ubform"
		SetFocusOnError="true"
		ControlToValidate="customerNumberInput" CssClass="Error" ForeColor="" Display="Static" ErrorMessage="Customer Number is required." />--%> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=companyInput>Company: <span>*</span></asp:Label>
    <input runat="server" class="text bill-company" id=companyInput name=Company>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="companyInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Company is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=nameInput>Name: <span>*</span></asp:Label>
    <input runat="server" class="text bill-name" id=nameInput name=Name>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="nameInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Name is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=emailInput>Email Address: <span>*</span></asp:Label>
    <input runat="server" class="text bill-email" id=emailInput name="Email Address"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="emailInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Email is required." /> 
    <asp:RegularExpressionValidator runat="server" ForeColor="" CssClass="Error"
      Display="Static" ControlToValidate="emailInput" 
      ValidationGroup="ubform"
      ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
      ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
      Please enter a valid email address.
    </asp:RegularExpressionValidator>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=phoneInput>Phone number: <span>*</span></asp:Label>
    <input runat="server" class="text bill-phone" id=phoneInput name="Phone Number"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="phoneInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Phone is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=addressInput>Address: <span>*</span></asp:Label>
    <input runat="server" class="text bill-address" id=addressInput name=Address>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="addressInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Address is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=suiteInput>Suite:</asp:Label>
    <input runat="server" class="text bill-suite" id=suiteInput name=Suite>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=cityInput>City: <span>*</span></asp:Label>
    <input runat="server" class="text bill-city" id=cityInput name=City>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="cityInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="City is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=postalcodeInput>Postal Code: <span>*</span></asp:Label>
    <input runat="server" class="text bill-postal" id=postalcodeInput name="Postal Code"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="postalcodeInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Postal Code is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=countryInput>Country: <span>*</span></asp:Label>
    <input runat="server" class="text bill-country" id=countryInput name=Country>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="countryInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Country is required." /> 
  </li>
  </ol>
  <h2>Ship To:<span class="required">*</span></h2>
  <ol class=form>
  <li id="shippingRadioList">  
	<Pop:RadioList ID="shipAddress" CssClass="radio" runat="server">
		<asp:ListItem Text="Same as billing address" Value="Same as billing address" />
		<asp:ListItem Text="Address listed below" Value="Address listed below" />
		<asp:ListItem Text="Download--do not ship!" Value="Download Only, No ship"  Selected />
	</Pop:RadioList>
	<asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="shipAddress" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Ship To is required." /> 
  </li>
  <li>
    <p>
    <strong>If product is being shipped, please add $29 for shipping within the US.<br />For international shipping and handling, please add $70.</strong>
    <br />
    <br />
    </p>
  </li>
   </ol>
  <ol id="shippingForm" class="form">
  <li>
	<Pop:RadioList ID="shippingType" CssClass="radio" runat="server">
		<asp:ListItem Text="Shipping" Value="Pre-Paid" />
		<asp:ListItem Text="Pre-Paid" Value="Your Account" />
	</Pop:RadioList>
  </li>

  <li>
    <asp:Label runat="server" AssociatedControlId=shippaymentAcctInput>Your Account</asp:Label>
    <input runat="server" class=text id=shippaymentAcctInput name="Account Number"/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipCompanyInput>Company:</asp:Label>
    <input runat="server" class="text ship-company" id=shipCompanyInput name=Company/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipNameInput>Name:</asp:Label>
    <input runat="server" class="text ship-name" id=shipNameInput name=Name/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipEmailInput>Email Address:</asp:Label>
    <input runat="server" class="text ship-email" id=shipEmailInput name="Email Address"/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipPhoneInput>Phone number:</asp:Label>
    <input runat="server" class="text ship-phone" id=shipPhoneInput name="Phone Number"/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipAddressInput>Address:</asp:Label>
    <input runat="server" class="text ship-address" id=shipAddressInput name=Address/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipSuiteInput>Suite:</asp:Label>
    <input runat="server" class="text ship-suite" id=shipSuiteInput name=Suite/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipCityInput>City:</asp:Label>
    <input runat="server" class="text ship-city" id=shipCityInput name=City/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipPostalcodeInput>Postal Code:</asp:Label>
    <input runat="server" class="text ship-postal" id=shipPostalcodeInput name="Postal Code"/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=shipCountryInput>Country:</asp:Label>
    <input runat="server" class="text ship-country" id=shipCountryInput name=Country/>
  </li>
  </ol>
  <h2>Payment Info:<span class="required">*</span></h2>
  <ol class=form>
  <li>
	<Pop:RadioList runat="server" ID="paymentType" CssClass="radio">
		<asp:ListItem Text="Credit Card" Value="Credit Card"/>
		<asp:ListItem Text="Check" Value="Check"/>
		<asp:ListItem Text="Wire Transfer" Value="Wire Transfer"/>
	</Pop:RadioList>    
	<asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="paymentType" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Please select payment method." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=poInput>P.O.#:</asp:Label>
    <input runat="server" class=text id=poInput name="P.O. #"/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=dateInput>Date: <span>*</span></asp:Label>
    <input runat="server" class=text id=dateInput name=Date>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="dateInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Date is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=versionInput>Version: <span>*</span></asp:Label>
    <select runat="server" id=versionInput>
      <option value=9.x selected>9.x</option>
      <option>8.x</option>
      <option>7.x</option>
      <option>6.x</option>
    </select>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="versionInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Version is required." /> 
  </li>
 </ol>
 <asp:Repeater runat="server" ID="ProductQuantityTable" OnItemDataBound="ProductQuantityTable_ItemDataBound">
 <HeaderTemplate>	 
	 <table class="threeColumn form" summary="Order Form">
	  <thead>
		<tr>
		  <th>Quantity</th>
		  <th>Description</th>
		  <th>Net Price ($US) (Less Reseller Discount)</th>
		</tr>
	  </thead>
	  <tbody>
 </HeaderTemplate>
 <FooterTemplate>    
  </tbody>
</table>
 </FooterTemplate>
 <ItemTemplate>
	<tr>
		<td><input runat="server" class=text id="Quantity"/></td>
		<td><input runat="server" class=text id="Description"/></td>
		<td><input runat="server" class=text id="Price"/></td>
    </tr>
 </ItemTemplate>
 </asp:Repeater>
 
  
   
 
<h2>End User:</h2>
<ol class=form>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserCompanyInput>End User's Company: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserCompanyInput name="End User's Company"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserCompanyInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="User's Company is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserNameInput>Contact Name: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserNameInput name="End User's Contact Name"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserNameInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Contact Name is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserEmailInput>Email Address: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserEmailInput name="End User's Email"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserEmailInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Email Address is required." /> 
    <asp:RegularExpressionValidator runat="server" ForeColor="" CssClass="Error"
      Display="Static" ControlToValidate="enduserEmailInput" 
      ValidationGroup="ubform"
      ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
      ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
      Please enter a valid email address.
    </asp:RegularExpressionValidator>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserPhoneInput>Phone Number: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserPhoneInput name="End User's Phone number"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserPhoneInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Phone is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserAddressInput>Address: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserAddressInput name="End User's Address"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserAddressInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Address is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserCityInput>City: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserCityInput name="End User's City"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserCityInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="City is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserPostalcodeInput>Postal Code: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserPostalcodeInput name="End User's Postal Code"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserPostalcodeInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Postal Code is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserCountryInput>Country: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserCountryInput name="End User's Country"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserCountryInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Country is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserLicenseserverInput>License Server Name: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserLicenseserverInput name="End User's License Server Name"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserLicenseserverInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Server Name is required." /> 
    <span id="nospaces">(No Spaces)</span>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId=enduserLicenseemailInput>License Email Address: <span>*</span></asp:Label>
    <input runat="server" class=text id=enduserLicenseemailInput name="End User's License Email Address"/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubform" SetFocusOnError="true" ControlToValidate="enduserLicenseemailInput" CssClass="Error" ForeColor="" Display="Static" ErrorMessage="Email is required." /> 
    <asp:RegularExpressionValidator runat="server" ForeColor="" CssClass="Error"
      Display="Static" ControlToValidate="enduserLicenseemailInput" 
      ValidationGroup="ubform"
      SetFocusOnError="true"
      ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
      ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
      Please enter a valid email address.
    </asp:RegularExpressionValidator>
  </li>
</ol>
<ol class=form>
  <li>
    <asp:Label runat="server" AssociatedControlId=commentsInput>Comments:</asp:Label>
    <textarea runat="server" id=commentsInput name=Comments rows=5 cols=40 />
  </li>
  <li>
    <p>When you have entered all the information above, please press the SUBMIT button.<br />
    <br />
    </p>
  </li>
  <li>
    <asp:Button runat="server" ValidationGroup="ubform" OnClick="Submit_Click" CssClass="submit marginCenter floatnone" Text="Submit" />
  </li>
</ol>
</asp:PlaceHolder>
