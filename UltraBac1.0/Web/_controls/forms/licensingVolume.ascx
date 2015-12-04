<%@ Control Language="C#" AutoEventWireup="true" CodeFile="licensingVolume.ascx.cs" Inherits="_controls_forms_licensingVolume" %>

<asp:PlaceHolder runat="server" ID="uxForm">
<ZNode:Content runat="server" />
<ol class=form>
  <li>
    <asp:Label runat="server" AssociatedControlId="nameInput"><span style="color:Red">*</span> Name:</asp:Label>
    <input runat="server" id="nameInput" name=Name/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="nameInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Name is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="titleInput">Title:</asp:Label>
    <input runat="server" id="titleInput" name=Title/>
    <%--<asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="titleInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Title is required." /> --%>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="companyInput"><span style="color:Red">*</span> Company:</asp:Label>
    <input runat="server" id="companyInput" name=Company/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="companyInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Company is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="addressInput">Address:</asp:Label>
    <input runat="server" id="addressInput" name=Address/>
    <%--<asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="addressInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Address is required." /> --%>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="address2Input">Address 2:</asp:Label>
    <input runat="server" id="address2Input" name=Address2/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="stateprovinceInput"><span style="color:Red">*</span> State/Province:</asp:Label>
    <input runat="server" id="stateprovinceInput" name="State/Province" />
    <asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="stateprovinceInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="State/Province is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="zippostalcodeInput">Zip/Postal Code:</asp:Label>
    <input runat="server" id="zippostalcodeInput" name="Zip/Postal Code"/>
    <%--<asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="zippostalcodeInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Postal code is required." /> --%>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="countryInput"><span style="color:Red">*</span> Country:</asp:Label>
    <input runat="server" id="countryInput" name=Country/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="countryInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Country is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="phoneInput"><span style="color:Red">*</span> Phone:</asp:Label>
    <input runat="server" id="phoneInput" name=Phone/>
    <asp:RequiredFieldValidator Runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="phoneInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Phone is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="extensionInput">Extension:</asp:Label>
    <input runat="server" id="extensionInput" name=Extension/>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="emailInput"><span style="color:Red">*</span> Email:</asp:Label>
    <input runat="server" id="emailInput" name=Email/>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="emailInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="Email is required." /> 
    <asp:RegularExpressionValidator runat="server" ForeColor="" CssClass="Error"
                Display="Static" ControlToValidate="emailInput" 
                ValidationGroup="volume" SetFocusOnError="true"
                ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
			    Please enter a valid email address.
    </asp:RegularExpressionValidator>
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="serversInput"><span style="color:Red">*</span> No. of Servers:</asp:Label>
    <select runat="server" id="serversInput" name="Number of Servers"> 
      <option selected value="">Select One:</option> 
      <option value=25-50>25-50</option> 
      <option value=51-100>51-100</option> 
      <option value=101-150>101-150</option> 
      <option value=151-200>151-200</option> 
      <option value=201-300>201-300</option> 
      <option value=301-400>301-400</option> 
      <option value=401-500>401-500</option> 
      <option value=501andabove>501 and above</option>
    </select>
    <asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="serversInput" CssClass="Error" ForeColor="" Display="Dynamic" ErrorMessage="No. Servers is required." /> 
  </li>
  <li>
    <asp:Label runat="server" AssociatedControlId="commentsInput">Comments:</asp:Label>
    <textarea runat="server" id="commentsInput" rows=5 cols=40 name=Comments></textarea>
    <%--<asp:RequiredFieldValidator runat="server" ValidationGroup="volume" SetFocusOnError="true" ControlToValidate="commentsInput" CssClass="Error" ForeColor="" Display="Static" ErrorMessage="Comments are required." /> --%>
  </li>
</ol>
<div>
  <p align=center><strong>When you have entered all information above,<br />please press the SUBMIT button.</strong><br />
  <asp:Button runat="server" ValidationGroup="volume" CssClass="submit marginCenter floatnone" Text="Submit" OnClick="Submit_Click" /></p>
</div>


<h3 align=center>An UltraBac Software representative will be contacting you to discuss your Volume License requirements.<br />Thank you.</h3></strong>

</asp:PlaceHolder>

<ZNode:CustomMessage ID="uxMessage" runat="server" MessageKey="LicensingVolumeFormSubmitted" Visible="false" />