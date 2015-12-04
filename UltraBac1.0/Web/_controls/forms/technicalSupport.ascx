<%@ Control Language="C#" AutoEventWireup="true" CodeFile="technicalSupport.ascx.cs"
    Inherits="_controls_forms_technicalSupport" %>
<%@ Reference VirtualPath="~/Themes/Default/Form/form.master" %>

<asp:PlaceHolder runat="server" ID="uxForm">
<ZNode:Content runat="server" />
<h2>Customer Information</h2>
<ol class="form">
    <li>
        <asp:label runat="server" AssociatedControlID="companyInput"><span>*</span> Company Name: </asp:label>
        <input runat="server" type="text" class="text" name="Company Name" id="companyInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="companyInput" Display="Dynamic" ErrorMessage="Required"  ForeColor="" CssClass="Error"  />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="customerNumberInput"><span>*</span> Customer Number: </asp:label>
        <input runat="server" type="text" class="text" name="Customer Number" id="customerNumberInput" /><asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="customerNumberInput" Display="Dynamic" ErrorMessage="Required"  ForeColor="" CssClass="Error" />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="contactInput"><span>*</span> Contact Name:</asp:label>
        <input runat="server" type="text" class="text" name="Contact Name" id="contactInput" /><asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="contactInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="emailInput"><span>*</span> Email:</asp:label>        
        <input runat="server" type="text" class="text" name="Email" id="emailInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="emailInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
        <asp:RegularExpressionValidator runat="server" ValidationGroup="tech" ControlToValidate="emailInput" Display="Dynamic" ErrorMessage="Invalid Email" ForeColor="" CssClass="Error"  ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="phoneInput"><span>*</span> Phone Number:</asp:label>
        <input runat="server" type="text" class="text" name="Phone Number" id="phoneInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="phoneInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
        <asp:RegularExpressionValidator runat="server" ValidationGroup="tech" ControlToValidate="phoneInput" Display="Dynamic" ErrorMessage="Invalid Phone" ForeColor="" CssClass="Error"  ValidationExpression="^\(?[\d]{3}(\) ?)?[\.-]?[\d]{3}[\.-]?[\d]{4}$" />
    </li>
</ol>
<h2>System Information</h2>
<ol class="form">
    <li>
        <asp:label runat="server" AssociatedControlID="buildDateInput"><span>*</span> UltraBac Build Date:</asp:label>
        <input runat="server" type="text" class="text" name="UltraBac Build Date" id="buildDateInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="buildDateInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="osInput"><span>*</span> OS:</asp:label>
        <input runat="server" type="text" class="text" name="OS" id="osInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="osInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="servicePacksInput"><span>*</span> Service Packs:</asp:label>
        <input runat="server" type="text" class="text" name="Service Packs" id="servicePacksInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="servicePacksInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="tapeDriveInput"><span>*</span> Backup Device:</asp:label>
        <input runat="server" type="text" class="text" name="Tape Drive" id="tapeDriveInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="tapeDriveInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="versionNumberInput"><span>*</span> UltraBac Version Number: </asp:label>
        <input runat="server" type="text" class="text" name="Version Number" id="versionNumberInput" />
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="versionNumberInput" Display="Static" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
    </li>    
</ol>
<h2>Problem</h2>
<ol class="form">
    <li>
        <asp:label runat="server" AssociatedControlID="shortDescriptionInput"><span>*</span> Short Description:</asp:label>
        <input runat="server" type="text" class="text" name="Short Description" id="shortDescriptionInput" /><asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="shortDescriptionInput" Display="Dynamic" ErrorMessage="Required" ForeColor="" CssClass="Error" />
    </li>
    <li>
        <asp:label runat="server" AssociatedControlID="problemInput"><span>*</span> Problem or Question:</asp:label>
        <asp:TextBox runat="server" name="Problem or Question" CssClass="text" id="problemInput" TextMode="MultiLine"/>
        <asp:RequiredFieldValidator runat="server" ValidationGroup="tech" ControlToValidate="problemInput" Display="Static" ErrorMessage="Required" ForeColor="" CssClass="Error"  />
    </li>
    <li>
        <input runat="server" validationgroup="tech" type="submit" class="submit marginCenter floatnone" value="Submit" />
    </li>
</ol>
</asp:PlaceHolder>

<asp:PlaceHolder runat="server" ID="uxConfirmation" Visible="false">
    <ZNode:CustomMessage runat="server" MessageKey="TechSupportSubmission" />
</asp:PlaceHolder>
