<%@ Control Language="C#" AutoEventWireup="true" CodeFile="updateResellerContactInfo.ascx.cs" Inherits="_controls_forms_updateResellerContactInfo" %>

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
            <asp:Label ID="lblPrimaryContact" runat="server" AssociatedControlID="txtPrimaryContact"><span style="color:Red;">*</span> Primary Contact:</asp:Label>
            <asp:TextBox ID="txtPrimaryContact" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvPrimaryContact" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtPrimaryContact" ErrorMessage="Please enter a Primary Contact."
                ToolTip="Please enter a Primary Contact." />
        </li>
        <li class="required">
            <asp:Label ID="lblCompanyName" runat="server" AssociatedControlID="txtCompanyName"><span style="color:Red;">*</span> Company Name:</asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtCompanyName" ErrorMessage="Please enter a Company name."
                ToolTip="Please enter a Company name." />
        </li>
		<li class="required">
			<asp:Label ID="lblAddress1" runat="server" AssociatedControlID="txtAddress1"><span style="color:Red;">*</span> Address 1:</asp:Label>
			<asp:TextBox ID="txtAddress1" runat="server" columns="30" MaxLength="50" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvAddress1" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtAddress1" SetFocusOnError="true"
			    ErrorMessage="Please enter Address 1." ToolTip="Please enter Address 1." />
		</li>	
		<li>
			<asp:Label ID="lblAddress2" runat="server" AssociatedControlID="txtAddress2">Address 2:</asp:Label>
			<asp:TextBox ID="txtAddress2" runat="server" columns="30" MaxLength="50" CssClass="text" />
		</li>	
		<li class="required">
			<asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity"><span style="color:Red;">*</span> City:</asp:Label>
			<asp:TextBox ID="txtCity" runat="server" columns="30" MaxLength="30" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvCity" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtCity" SetFocusOnError="true"
			    ErrorMessage="Please enter City." ToolTip="Please enter City." />
		</li>	
		<li class="required">
			<asp:Label ID="lblZip" runat="server" AssociatedControlID="txtZip"><span style="color:Red;">*</span> Zip:</asp:Label>
			<asp:TextBox ID="txtZip" runat="server" columns="30" MaxLength="20" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvZip" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtZip" SetFocusOnError="true"
			    ErrorMessage="Please enter Zip." ToolTip="Please enter Zip." />
		</li>
		<li class="required">
			<asp:Label ID="lblCountry" runat="server" AssociatedControlID="ddlCountry"><span style="color:Red;">*</span> Country:</asp:Label>
			<asp:DropDownList ID="ddlCountry" runat="server" AppendDataBoundItems="true">
			    <asp:ListItem Value="-1" Text="Select..." />
			</asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvCountry" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="ddlCountry" SetFocusOnError="true"
			    InitialValue="-1"
			    ErrorMessage="Please select a Country." ToolTip="Please select a Country." />
		</li>	
		<li class="required">
		    <label><span style="color:Red;">*</span> State/Province or Territory:</label>
		    <div id="divStateDDL" runat="server">
			    <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="true">
			        <asp:ListItem Value="-1" Text="Select..." />
			    </asp:DropDownList>
            </div>
            <div id="divStateTxt" runat="server">
			    <asp:TextBox ID="txtState" runat="server" columns="30" MaxLength="20" CssClass="text" />
            </div>
            <asp:CustomValidator ID="cvState" runat="server"
                ForeColor=" " CssClass="Error" Display="Dynamic" SetFocusOnError="true"
                OnServerValidate="cvState_ServerValidate"
                ErrorMessage="Please enter or select a State." ToolTip="Please enter or select a State." />
		</li>	
        <li class="required">
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone"><span style="color:Red;">*</span> Phone/Ext:</asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="revPhone" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtPhone" 
                ErrorMessage="Please enter Phone/Ext." ToolTip="Please enter Phone/Ext." />
        </li>
        <li class="required">
            <asp:Label ID="lblFax" runat="server" AssociatedControlID="txtFax"><span style="color:Red;">*</span> Fax:</asp:Label>
            <asp:TextBox ID="txtFax" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvFax" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtFax" 
                ErrorMessage="Please enter Fax." ToolTip="Please enter Fax." />
        </li>
    </ol>
    <div class="hr"></div>
    <div>
        <h2>Additional Contacts</h2>
        <asp:GridView ID="gvContacts" CssClass="tabular margin_bottom" runat="server" 
                OnRowCommand="gvContacts_RowCommand"
                OnRowDeleting="gvContacts_RowDeleting"
                AutoGenerateColumns="false" BorderStyle="none" BorderWidth="0" GridLines="None" >
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button" />
            </Columns>
        </asp:GridView>

        <div>
            Add a Contact:
            <br />
            <ol class="form">
                <li>
                    <asp:Label ID="lblContactName" runat="server" AssociatedControlID="txtContactName">Name:</asp:Label>
                    <asp:TextBox ID="txtContactName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
                </li>
                <li class="required">
                    <asp:Label ID="lblContactEmail" runat="server" AssociatedControlID="txtContactEmail"><span style="color:Red;">*</span> Email:</asp:Label>
                    <asp:TextBox ID="txtContactEmail" runat="server" Columns="30" MaxLength="100" CssClass="text" />
                    <asp:RequiredFieldValidator ID="rfvContactEmail" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtContactEmail" 
                        ErrorMessage="Please enter Email." ToolTip="Please enter Email."
                        ValidationGroup="Contacts" />
                    <asp:RegularExpressionValidator ID="revContactEmail" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtContactEmail" 
                        ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                        ErrorMessage="Please enter a valid Email Address." ToolTip="Please enter a valid email address."
                        ValidationGroup="Contacts" />
                </li>
                <li class="submit">
                    <label></label>
                    <asp:Button ID="btnSubmitContact" runat="server" OnClick="btnSubmitContact_Click" Text="Add" ValidationGroup="Contacts" CssClass="submit marginCenter floatnone" />
                </li>
            </ol>
        </div>
    </div>

    <ol class="form">
        <li class="submit">
            <label></label>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="submit marginCenter floatnone" />
        </li>
    </ol>

</asp:PlaceHolder>

<asp:PlaceHolder ID="plhThankYou" runat="server" Visible="false">
    <ZNode:CustomMessage runat="server" MessageKey="UpdateResellerAccountFormSubmitted" />
</asp:PlaceHolder>
