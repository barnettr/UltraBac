<%@ Control Language="C#" AutoEventWireup="true" CodeFile="downloadUpgrade.ascx.cs"
    Inherits="_controls_forms_downloadUpgrade" %>

<asp:PlaceHolder ID="plhContact" runat="server" Visible="true">
	<ZNode:Content runat="server" />
    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
    <p>Fields marked with <span style="color:Red;">*</span> are required.</p>
    <%--<h2>Select your current product version</h2>
    <ol class="form">
        <li class="required">
            <asp:Label ID="lblVersion" runat="server" AssociatedControlID="rblVersion" CssClass="labelLong"><span style="color:Red;">*</span> Version</asp:Label>
            <pop:RadioList ID="rblVersion" runat="server" CssClass="goofy">
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
            <asp:RequiredFieldValidator ena ID="rfvVersion" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="rblVersion" ErrorMessage="Please select a version."
                ToolTip="Please select a version." />
        </li>
    </ol>--%>
    <h2>Contact Information</h2>
    <ol class="form">
        <li class="required">
            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName">First Name:</asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator Enabled="false" ID="rfvFirstName" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="Please enter a First Name."
                ToolTip="Please enter a First Name." />
        </li>
        <li class="required">
            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName">Last Name:</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" Columns="30" MaxLength="30" CssClass="text" />
            <asp:RequiredFieldValidator Enabled="false" ID="rfvLastName" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtLastName" ErrorMessage="Please enter a Last Name."
                ToolTip="Please enter a Last Name." />
        </li>
        <li class="required">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail"><span style="color:Red;">*</span> Email:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="40" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfv" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ErrorMessage="Please enter Email." ToolTip="Please enter Email." />
            <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address." />
        </li>
        <li class="submit">
            <label></label>
            <asp:Button ID="btnSubmit" CssClass="submit marginCenter floatnone" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </li>
    </ol>

</asp:PlaceHolder>

<asp:PlaceHolder ID="plhCustomerNotFound" runat="server" Visible="false">
    <div>
        <p><asp:Label ID="lblNotFoundMsg" runat="server" /></p>
        <p>To download a trial version <asp:LinkButton ID="btnGoToTrialDownload" runat="server" OnClick="btnGoToTrialDownload_Click">click here</asp:LinkButton>.</p>
    </div>
</asp:PlaceHolder>

<asp:PlaceHolder ID="plhDownloadLink" runat="server" Visible="false">
    <div>
        <ZNode:CustomMessage id="DownloadMessage" MessageKey="UpgradeDownloadFormSubmitted" runat="server" />
        <asp:Label ID="lblDownloadErrorPh" runat="server" Visible="false">
			<p>The server is unable to initiate your download. For assistance, please contact UltraBac directly.</p>
        </asp:Label>
        <asp:LinkButton ID="btnDownloadNow" runat="server" OnClick="btnDownloadNow_Click" CausesValidation="false">Download Now</asp:LinkButton>
    </div>
</asp:PlaceHolder>