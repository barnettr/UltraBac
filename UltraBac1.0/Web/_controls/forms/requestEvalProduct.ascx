<%@ Control Language="C#" AutoEventWireup="true" CodeFile="requestEvalProduct.ascx.cs"
    Inherits="_controls_forms_requestEvalProduct" %>

<script type="text/javascript">
//<![CDATA[
    function setCountryOption(elem) {
        switch (elem.value)
        {
            case 'US':
                toggleStateControls('US');
                break;
            case 'CA':
                toggleStateControls('CA');
                break;
            default:
                toggleStateControls('foreign');
                break;
        }
    }
//]]>
</script>


<asp:PlaceHolder ID="plhContact" runat="server" Visible="true">
	<ZNode:Content runat="server" />
    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
    
    <p>Fields marked with <span style="color:Red;">*</span> are required.</p>
    <ol class="form">
        <li class="required">
            <asp:Label ID="lblVersion" runat="server" AssociatedControlID="rblVersion"><span style="color:Red;">*</span> Version:</asp:Label>
            <pop:RadioList ID="rblVersion" runat="server" CssClass="radio">
                <asp:ListItem Value="UBR Gold" Text="UBR Gold" Selected="true" />
                <asp:ListItem Value="UBR Pro" Text="UBR Pro" />
            </pop:RadioList>
            <asp:RequiredFieldValidator ID="rfvVersion" runat="server" ForeColor=" " SetFocusOnError="true" " SetFocusOnError="true" CssClass="Error"
                Display="Dynamic" ControlToValidate="rblVersion" ErrorMessage="Please make a selection."
                ToolTip="Please make a selection.">
                Please make a selection.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName"><span style="color:Red;">*</span> Name:</asp:Label>
            <asp:TextBox ID="txtName" runat="server" Columns="30" MaxLength="30" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ForeColor=" " SetFocusOnError="true" " CssClass="Error"
                Display="Dynamic" ControlToValidate="txtName" ErrorMessage="Please enter your Name."
                ToolTip="Please enter your Name.">
			    Please enter your Name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblTitle" runat="server" AssociatedControlID="txtTitle"><span style="color:Red;">*</span> Title:</asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Columns="30" MaxLength="30" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ForeColor=" " SetFocusOnError="true" " CssClass="Error"
                Display="Dynamic" ControlToValidate="txtTitle" ErrorMessage="Please enter your Title."
                ToolTip="Please enter your Title.">
			    Please enter your Title.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblCompanyName" runat="server" AssociatedControlID="txtCompanyName"><span style="color:Red;">*</span> Company:</asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor=" " SetFocusOnError="true" " CssClass="Error"
                Display="Dynamic" ControlToValidate="txtCompanyName" ErrorMessage="Please enter your Company name."
                ToolTip="Please enter your Company name.">
			    Please enter your Company name.
            </asp:RequiredFieldValidator>
        </li>
		<li class="required">
			<asp:Label ID="lblAddress1" runat="server" AssociatedControlID="txtAddress1"><span style="color:Red;">*</span> Address 1:</asp:Label>
			<asp:TextBox ID="txtAddress1" runat="server" columns="30" MaxLength="50" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvAddress1" runat="server" 
			    ForeColor=" " SetFocusOnError="true" " CssClass="Error" Display="Dynamic" ControlToValidate="txtAddress1" 
			    ErrorMessage="Please enter Address 1." ToolTip="Please enter Address 1.">
			    Please enter Address 1.
			</asp:RequiredFieldValidator>
		</li>	
		<li>
			<asp:Label ID="lblAddress2" runat="server" AssociatedControlID="txtAddress2">Address 2:</asp:Label>
			<asp:TextBox ID="txtAddress2" runat="server" columns="30" MaxLength="50" CssClass="text" />
		</li>	
		<li class="required">
			<asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity"><span style="color:Red;">*</span> City:</asp:Label>
			<asp:TextBox ID="txtCity" runat="server" columns="30" MaxLength="30" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvCity" runat="server" 
			    ForeColor=" " SetFocusOnError="true" " CssClass="Error" Display="Dynamic" ControlToValidate="txtCity" 
			    ErrorMessage="Please enter City." ToolTip="Please enter City.">
			    Please enter City.
			</asp:RequiredFieldValidator>
		</li>	
		<li class="required">
			<asp:Label ID="lblZip" runat="server" AssociatedControlID="txtZip"><span style="color:Red;">*</span> Zip:</asp:Label>
			<asp:TextBox ID="txtZip" runat="server" columns="30" MaxLength="20" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvZip" runat="server" 
			    ForeColor=" " SetFocusOnError="true" " CssClass="Error" Display="Dynamic" ControlToValidate="txtZip" 
			    ErrorMessage="Please enter Zip." ToolTip="Please enter Zip.">
			    Please enter Zip.
			</asp:RequiredFieldValidator>
		</li>
		<li class="required">
			<asp:Label ID="lblCountry" runat="server" AssociatedControlID="ddlCountry"><span style="color:Red;">*</span> Country:</asp:Label>
			<asp:DropDownList ID="ddlCountry" runat="server" DataTextField="Name" DataValueField="Code" AppendDataBoundItems="true">
			    <asp:ListItem Value="-1" Text="Select..." />
			</asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvCountry" runat="server" 
			    ForeColor=" " SetFocusOnError="true" " CssClass="Error" Display="Dynamic" ControlToValidate="ddlCountry" 
			    InitialValue="-1"
			    ErrorMessage="Please select a Country." ToolTip="Please select a Country.">
			    Please select a Country.
			</asp:RequiredFieldValidator>
		</li>	
		<li class="required">
		    <label><span style="color:Red;">*</span> State/Province or Territory</label>
		    <div id="divStateDDL" runat="server">
			    <asp:DropDownList ID="ddlState" DataTextField="Name" DataValueField="Code" runat="server">
			        <asp:ListItem Value="-1" Text="Select..." />
			    </asp:DropDownList>
            </div>
            <div id="divStateTxt" runat="server">
			    <asp:TextBox ID="txtState" runat="server" columns="30" MaxLength="20" CssClass="text" />
            </div>
            <asp:CustomValidator ID="cvState" runat="server"
                ForeColor=" " SetFocusOnError="true" " CssClass="Error" Display="Dynamic"
                OnServerValidate="cvState_ServerValidate"
                ErrorMessage="Please enter or select a State." ToolTip="Please enter or select a State." />
		</li>	
        <li class="required">
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone"><span style="color:Red;">*</span> Phone:</asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="revPhone" runat="server" ForeColor=" " SetFocusOnError="true" " CssClass="Error"
                Display="Dynamic" ControlToValidate="txtPhone" 
                ErrorMessage="Please enter Phone/Ext." ToolTip="Please enter Phone/Ext.">
			    Please enter Phone.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblExt" runat="server" AssociatedControlID="txtExt">Ext:</asp:Label>
            <asp:TextBox ID="txtExt" runat="server" Columns="30" MaxLength="6" CssClass="text" />
        </li>
        <li class="required">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail"><span style="color:Red;">*</span> Email:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="40" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfv" runat="server" ForeColor=" " SetFocusOnError="true" " CssClass="Error"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ErrorMessage="Please enter Email." ToolTip="Please enter Email.">
			    Please enter Email.
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ForeColor=" " SetFocusOnError="true" " CssClass="Error"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
			    Please enter a valid email address.
            </asp:RegularExpressionValidator>
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
        <p>Thank you for requesting an evaluation of UltraBac software. Someone will contact you soon.</p>
    </div>
</asp:PlaceHolder>
