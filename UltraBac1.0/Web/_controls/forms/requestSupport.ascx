<%@ Control Language="C#" AutoEventWireup="true" CodeFile="requestSupport.ascx.cs" Inherits="_controls_forms_requestSupport" %>

<asp:PlaceHolder ID="plhContact" runat="server" Visible="true">
	<ZNode:Content runat="server" />
    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
    <p>Fields marked with <span style="color:Red;">*</span> are required.</p>
    <ol class="form">
        <li class="required">
            <asp:Label ID="lblCompanyName" runat="server" AssociatedControlID="txtCompanyName"><span style="color:Red;">*</span> Company:</asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtCompanyName" ErrorMessage="Please enter Company name."
                ToolTip="Please enter Company name." />
        </li>
        <li class="required">
            <asp:Label ID="lblCustomerNumber" runat="server" AssociatedControlID="txtCustomerNumber"><span style="color:Red;">*</span> Customer Number:</asp:Label>
            <asp:TextBox ID="txtCustomerNumber" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvCustomerNumber" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtCustomerNumber" ErrorMessage="Please enter Customer Number."
                ToolTip="Please enter Customer Number." />
        </li>
        <li class="required">
            <asp:Label ID="lblContactName" runat="server" AssociatedControlID="txtContactName"><span style="color:Red;">*</span> Contact Name:</asp:Label>
            <asp:TextBox ID="txtContactName" runat="server" Columns="30" MaxLength="40" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtContactName" ErrorMessage="Please enter a Contact Name."
                ToolTip="Please enter a First Name." />
        </li>
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
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone"><span style="color:Red;">*</span> Phone Number:</asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="revPhone" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtPhone" 
                ErrorMessage="Please enter Phone Number." ToolTip="Please enter Phone Number." />
        </li>
        <li class="required">
            <asp:Label ID="lblVersion" runat="server" AssociatedControlID="txtVersion"><span style="color:Red;">*</span> UltraBac Version Number:</asp:Label>
            <asp:TextBox ID="txtVersion" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvVersion" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtVersion" ErrorMessage="Please indicate version."
                ToolTip="Please indicate version." />
        </li>
        <li class="required">
            <asp:Label ID="lblBuildDate" runat="server" AssociatedControlID="txtBuildDate"><span style="color:Red;">*</span> UltraBac Build Date:</asp:Label>
            <asp:TextBox ID="txtBuildDate" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvBuildDate" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtBuildDate" ErrorMessage="Please enter the build date."
                ToolTip="Please enter the build date." />
        </li>
        <li class="required">
            <asp:Label ID="lblOperatingSystem" runat="server" AssociatedControlID="ddlOperatingSystem"><span style="color:Red;">*</span> Operating System:</asp:Label>
            <asp:DropDownList ID="ddlOperatingSystem" runat="server">
                <asp:ListItem Value="-1" Text="select..." />
                <asp:ListItem Value="Windows Vista" Text="Windows Vista" />
                <asp:ListItem Value="Windows 2003" Text="Windows 2003" />
                <asp:ListItem Value="Windows 2000" Text="Windows 2000" />
                <asp:ListItem Value="Windows XP" Text="Windows XP" />
                <asp:ListItem Value="Windows NT" Text="Windows NT" />
                <asp:ListItem Value="Windows ME" Text="Windows ME" />
                <asp:ListItem Value="Windows 98 SE" Text="Windows 98 SE" />
                <asp:ListItem Value="Windows 98" Text="Windows 98" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvOperatingSystem" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="ddlOperatingSystem" 
                InitialValue="-1"
                ErrorMessage="Please select an Operating System."
                ToolTip="Please select an Operating System." />
        </li>
        <li class="required">
            <asp:Label ID="lblServicePacks" runat="server" AssociatedControlID="txtServicePacks"><span style="color:Red;">*</span> Service Packs:</asp:Label>
            <asp:TextBox ID="txtServicePacks" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvServicePacks" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtServicePacks" ErrorMessage="Please indicate Service Packs."
                ToolTip="Please indicate Service Packs." />
        </li>
        <li class="required">
            <asp:Label ID="lblTapeDrive" runat="server" AssociatedControlID="txtTapeDrive"><span style="color:Red;">*</span> Tape Drive:</asp:Label>
            <asp:TextBox ID="txtTapeDrive" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvTapeDrive" runat="server" ForeColor=" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="txtTapeDrive" ErrorMessage="Please enter Tape Drive."
                ToolTip="Please enter Tape Drive." />
        </li>
        <li>
            <asp:Label ID="lblShortDescription" runat="server" AssociatedControlID="txtShortDescription">Short Description:</asp:Label>
            <asp:TextBox ID="txtShortDescription" runat="server" Columns="30" MaxLength="50" CssClass="text" />
        </li>
        <li class="textarea">
            <asp:Label ID="lblProblem" runat="server" AssociatedControlID="txtProblem">Problem or Question:</asp:Label>
            <asp:TextBox ID="txtProblem" runat="server" Height="50px" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
        </li>
    </ol>

    <ol class="form">
        <li class="submit">
            <asp:Button ID="btnSubmit" runat="server" CssClass="submit marginCenter floatnone" OnClick="btnSubmit_Click" Text="Send" />
        </li>
    </ol>

</asp:PlaceHolder>

<asp:PlaceHolder ID="plhThankYou" runat="server" Visible="false">
    <div>
        <p>Thank you for submitting your technical support request. Someone will contact you soon.</p>
    </div>
</asp:PlaceHolder>
