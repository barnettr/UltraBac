<%@ Control Language="C#" AutoEventWireup="true" CodeFile="requestLicense.ascx.cs" Inherits="_controls_forms_requestLicense" %>

<asp:PlaceHolder ID="plhContact" runat="server" Visible="true">
	<ZNode:Content runat="server" />
    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
    <p>Fields marked with <span style="color:Red;">*</span> are required.</p>
    <ol class="form">
        <li class="required">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail"><span style="color:Red;">*</span> Email:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="40" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfv" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ErrorMessage="Please enter Email." ToolTip="Please enter Email.">
			    Please enter Email.
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
			    Please enter a valid email address.
            </asp:RegularExpressionValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblCompanyName" runat="server" AssociatedControlID="txtCompanyName"><span style="color:Red;">*</span> Company Using the Software:</asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtCompanyName" ErrorMessage="Please enter Company."
                ToolTip="Please enter your Company name.">
			    Please enter your Company name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblCustomerNumber" runat="server" AssociatedControlID="txtCustomerNumber"><span style="color:Red;">*</span> Customer Number:</asp:Label>
            <asp:TextBox ID="txtCustomerNumber" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvCustomerNumber" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtCustomerNumber" ErrorMessage="Please enter Customer Number."
                ToolTip="Please enter Customer Number.">
			    Please enter Customer Number.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName"><span style="color:Red;">*</span> First Name:</asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="Please enter a First Name."
                ToolTip="Please enter a First Name.">
			    Please enter a First Name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName"><span style="color:Red;">*</span> Last Name:</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" Columns="30" MaxLength="30" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtLastName" ErrorMessage="Please enter a Last Name."
                ToolTip="Please enter a Last Name.">
			    Please enter a Last Name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone"><span style="color:Red;">*</span> Phone/Ext:</asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="revPhone" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtPhone" 
                ErrorMessage="Please enter Phone/Ext." ToolTip="Please enter Phone/Ext.">
			    Please enter Phone.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblPONumber" runat="server" AssociatedControlID="txtPONumber"><span style="color:Red;">*</span> P.O. Number:</asp:Label>
            <asp:TextBox ID="txtPONumber" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvPONumber" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtPONumber" ErrorMessage="Please enter P.O. Number."
                ToolTip="Please enter P.O. Number.">
			    Please enter P.O. Number.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblVersion" runat="server" AssociatedControlID="rblVersion"><span style="color:Red;">*</span> Version:</asp:Label>
            <pop:RadioList ID="rblVersion" runat="server" CssClass="text">
                <asp:ListItem Value="8.x" Text="8.x" />
                <asp:ListItem Value="7.x" Text="7.x" />
                <asp:ListItem Value="6.x" Text="6.x" />
                <asp:ListItem Value="5.x" Text="5.x" />
                <asp:ListItem Value="4.11" Text="4.11" />
                <asp:ListItem Value="4.1" Text="4.1" />
                <asp:ListItem Value="4.0" Text="4.0" />
                <asp:ListItem Value="2.4" Text="2.4" />
                <asp:ListItem Value="2.3" Text="2.3" />
                <asp:ListItem Value="2.1" Text="2.1" />
            </pop:RadioList>
            <asp:RequiredFieldValidator ID="rfvVersion" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="rblVersion" ErrorMessage="Please indicate version."
                ToolTip="Please indicate version.">
                Please indicate version.
            </asp:RequiredFieldValidator>
        </li>
        <li>
            <asp:Label ID="lblComputerName" runat="server" AssociatedControlID="txtComputerName">Computer Name:</asp:Label>
            <asp:TextBox ID="txtComputerName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
        </li>
        <li class="required">
            <asp:Label ID="lblLicenseType" runat="server" AssociatedControlID="rblLicenseType"><span style="color:Red;">*</span> License Type:</asp:Label>
            <pop:RadioList ID="rblLicenseType" runat="server" CssClass="text">
                <asp:ListItem Value="Evaluation Extension" Text="Evaluation Extension" />
                <asp:ListItem Value="Permanent" Text="Permanent" />
            </pop:RadioList>
            <asp:RequiredFieldValidator ID="rfvLicenseType" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="rblLicenseType" ErrorMessage="Please select a license type."
                ToolTip="Please select a license type.">
                Please select a license type.
            </asp:RequiredFieldValidator>
        </li>
        <li class="textarea">
            <asp:Label ID="lblComments" runat="server" AssociatedControlID="txtComments">
                Comments:
            </asp:Label>
            <asp:TextBox ID="txtComments" runat="server" Height="50px" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
        </li>
    </ol>

    <ol class="form">
        <li class="submit">
            <asp:Button ID="btnSubmit" runat="server" CssClass="submit marginCenter floatnone" OnClick="btnSubmit_Click" Text="Submit" />
        </li>
    </ol>

</asp:PlaceHolder>

<asp:PlaceHolder ID="plhThankYou" runat="server" Visible="false">
    <div>
        <p>Thank you for requesting a license. Someone will contact you soon.</p>
    </div>
</asp:PlaceHolder>
