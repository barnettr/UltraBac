<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ubdrRequest.ascx.cs" Inherits="_controls_forms_ubdrRequest" %>


<asp:PlaceHolder runat="server" ID="uxForm">
<ZNode:Content runat="server" />
<ol class=form>
  <li>
  <asp:Label runat="server" AssociatedControlID="ubdrProductType"><span style="color: Red;">*</span> Product:</asp:Label>
  <Pop:RadioList runat="server" ID="ubdrProductType" CssClass="radio">
	  <asp:ListItem Text="UBDR Gold" Value="UBDR Gold" />
	  <asp:ListItem Text="UBDR Pro" Value="UBDR Pro" />
  </Pop:RadioList>
  <asp:RequiredFieldValidator runat="server" ValidationGroup="ubdr" ControlToValidate="ubdrProductType" CssClass="Error" ForeColor=" " SetFocusOnError="true" Display="Dynamic" ErrorMessage="Version is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=nameInput><span style="color: Red;">*</span> Name:</asp:Label>
    <input runat="server" class=text id=nameInput name=Name>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubdr" ControlToValidate="nameInput" CssClass="Error" ForeColor=" " SetFocusOnError="true" Display="Dynamic" ErrorMessage="Name is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=titleInput>Title:</asp:Label>
    <input runat="server" class=text id=titleInput name=Title/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=companyInput>Company:</asp:Label>
    <input runat="server" class=text id=companyInput name=Company/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=address1Input>Address:</asp:Label>
    <input runat="server" class=text id=address1Input name=Address/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=address2Input>Address 2:</asp:Label>
    <input runat="server" class=text id=address2Input name=Address2/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=cityInput>City:</asp:Label>
    <input runat="server" class=text id=cityInput name=City/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=stateInput>State/Province:</asp:Label>
    <input runat="server" class=text id=stateInput name="State/Province"/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=zipInput>Zip/Mail Code:</asp:Label>
    <input runat="server" class=text id=zipInput name="Zip/Mail Code"/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=countryInput>Country:</asp:Label>
    <input runat="server" class=text id=countryInput name=Country/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=phoneInput>Phone:</asp:Label>
    <input runat="server" class=text id=phoneInput name=Phone/>

  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=extensionInput>Extension:</asp:Label>
    <input runat="server" class=text id=extensionInput name=Extension/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedcontrolId=emailInput><span style="color: Red;">*</span> Email:</asp:Label>
    <input runat="server" class=text id=emailInput name=Email>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="ubdr" ControlToValidate="emailInput" CssClass="Error" ForeColor=" " SetFocusOnError="true" Display="Dynamic" ErrorMessage="Email is required." /> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
          Display="Static" ControlToValidate="emailInput" 
          ValidationGroup="ubdr"
          ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
          ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
          Please enter a valid email address.
    </asp:RegularExpressionValidator>
  </li>
  <li class="submit">
            <asp:Button ValidationGroup="ubdr" OnClick="Submit_Click" runat="server" CssClass="submit marginCenter floatnone" Text=Submit/>
        </li>
</ol>
<div class="clear"></div>
<p>An UltraBac Software representative will be contacting you to discuss your UBDR requirements.</p>
</asp:PlaceHolder>

<ZNode:CustomMessage ID="uxMessage" runat="server" MessageKey="UbdrRequestFormSubmitted" Visible="false" />