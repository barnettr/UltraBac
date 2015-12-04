<%@ Control Language="C#" AutoEventWireup="true" CodeFile="downloadTrialProduct.ascx.cs"
    Inherits="_controls_forms_downloadTrialProduct" %>

<script type="text/javascript">
//<![CDATA[
    function setCountryOption(elem) {
        if (elem.checked && (elem.value == 'USA' || elem.value == 'US Territory')) {
            toggleStateControls('US');
        } else {
            if (elem.checked && elem.value == 'Canada') {
                toggleStateControls('CA');
            } else {
                toggleStateControls('foreign');
            }
        }
    }
//]]>
</script>

<asp:PlaceHolder ID="plhContact" runat="server" Visible="true">
	<ZNode:Content runat="server" />
	<ZNode:CustomMessage runat="server" Visible="false" ID="upgradeRedirectMessage" MessageKey="UpgradeNotEligible" />
    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
    
	<p>Fields marked with <span style="color:Red;">*</span> are required.</p>
    
	
	<h3>Contact Information</h3>
	
    <ol class="form">
        <li class="required">
            <asp:Label ID="lblOrgType" runat="server" AssociatedControlID="rblOrgType" CssClass="labelLong"><span style="color:Red;">*</span> Please tell us whether you are:</asp:Label>
            <pop:RadioList ID="rblOrgType" runat="server" CssClass="goofy">
                <asp:ListItem Value="Reseller" Text="Reseller" />
                <asp:ListItem Value="Government/Military" Text="Government / Military" />
                <asp:ListItem Value="Neither" Text="Neither" />
            </pop:RadioList>
            <asp:RequiredFieldValidator ID="rfvOrgType" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="rblOrgType" ErrorMessage="Please make a selection."
                ToolTip="Please make a selection.">
                Please make a selection.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName"><span style="color:Red;">*</span> First Name:</asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="Please enter a First Name."
                ToolTip="Please enter a First Name.">
			    Please enter a First Name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName"><span style="color:Red;">*</span> Last Name:</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" Columns="30" MaxLength="30" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtLastName" ErrorMessage="Please enter a Last Name."
                ToolTip="Please enter a Last Name.">
			    Please enter a Last Name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblCompanyName" runat="server" AssociatedControlID="txtCompanyName"><span style="color:Red;">*</span> Company:</asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtCompanyName" ErrorMessage="Please enter a Company name."
                ToolTip="Please enter a Company name.">
			    Please enter a Company name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone"><span style="color:Red;">*</span> Phone / <abbr title="Extension">Ext.</abbr>:</asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="revPhone" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtPhone" 
                ErrorMessage="Please enter Phone/Ext." ToolTip="Please enter Phone/Ext.">
			    Please enter Phone/Ext.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblFax" runat="server" AssociatedControlID="txtFax"><span style="color:Red;">*</span> Fax:</asp:Label>
            <asp:TextBox ID="txtFax" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator ID="revFax" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtFax" 
                ErrorMessage="Please enter Fax." ToolTip="Please enter Fax.">
			    Please enter Fax.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail"><span style="color:Red;">*</span> Email Address:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="40" CssClass="text" />
            <asp:RequiredFieldValidator ID="rfv" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ErrorMessage="Please enter Email." ToolTip="Please enter Email.">
			    Please enter your Email Address.
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ForeColor=" " CssClass="Error" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid Email Address." ToolTip="Please enter a valid email address.">
			    Please enter a valid Email Address.
            </asp:RegularExpressionValidator>
        </li>
    </ol>

	<h3>Location</h3>

    <ol class="form">
		<li class="required">
			<asp:Label ID="lblAddress1" runat="server" AssociatedControlID="txtAddress1"><span style="color:Red;">*</span> Address 1:</asp:Label>
			<asp:TextBox ID="txtAddress1" runat="server" columns="30" MaxLength="50" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvAddress1" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtAddress1"  SetFocusOnError="true"
			    ErrorMessage="Please enter an Address." ToolTip="Please enter an Address.">
			    Please enter an Address.
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
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtCity"  SetFocusOnError="true"
			    ErrorMessage="Please enter your City." ToolTip="Please enter your City.">
			    Please enter your City.
			</asp:RequiredFieldValidator>
		</li>	
		<li class="required">
			<asp:Label ID="lblZip" runat="server" AssociatedControlID="txtZip"><span style="color:Red;">*</span> Zip Code:</asp:Label>
			<asp:TextBox ID="txtZip" runat="server" columns="30" MaxLength="20" CssClass="text" />
			<asp:RequiredFieldValidator ID="rfvZip" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtZip"  SetFocusOnError="true"
			    ErrorMessage="Please enter your Zip Code." ToolTip="Please enter your Zip Code.">
			    Please enter your Zip Code.
			</asp:RequiredFieldValidator>
		</li>
		<li class="required">
			<asp:Label ID="lblLocatedIn" runat="server" AssociatedControlID="rblLocatedIn" CssClass="labelLong"><span style="color:Red;">*</span> I am located in:</asp:Label>
			<pop:RadioList ID="rblLocatedIn" runat="server" CssClass="goofy">
                <asp:ListItem Value="USA" Text="USA" />
                <asp:ListItem Value="Canada" Text="Canada" />
                <asp:ListItem Value="US Territory" Text="US Territory" />
                <asp:ListItem Value="Other Country" Text="Other Country" />
            </pop:RadioList>
			<asp:RequiredFieldValidator ID="rfvLocatedIn" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="rblLocatedIn"  SetFocusOnError="true"
			    ErrorMessage="Please select your Location." ToolTip="Please select your Location.">
			    Please select your Location.
			</asp:RequiredFieldValidator>
		</li>			
		<li class="required">
			<asp:Label ID="lblCountry" runat="server" AssociatedControlID="ddlCountry"><span style="color:Red;">*</span> Country:</asp:Label>
			<asp:DropDownList ID="ddlCountry" runat="server" AppendDataBoundItems="true">
			    <asp:ListItem Value="-1" Text="Select..." />
			</asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvCountry" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="ddlCountry"  SetFocusOnError="true"
			    InitialValue="-1"
			    ErrorMessage="Please select your Country." ToolTip="Please select your Country.">
			    Please select your Country.
			</asp:RequiredFieldValidator>
		</li>	
		<li class="required">
			<label for="state_province"><span style="color:Red;">*</span> State/Province or Territory</label>
			<fieldset id="state_province">
			    <div id="divStateDDL" runat="server">
				    <asp:DropDownList ID="ddlState" runat="server">
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
			</fieldset>
		</li>	
    </ol>

	<h3>Survey</h3>

    <ol class="form">
		<li class="required">
			<asp:Label ID="lblHowManyServers" runat="server" AssociatedControlID="txtHowManyServers">
			    <span style="color:Red;">*</span> Number of Windows-based servers you have:
			</asp:Label>
			<asp:TextBox ID="txtHowManyServers" runat="server" columns="30" MaxLength="10" CssClass="text" />
			<asp:RegularExpressionValidator ID="revHowManyServers" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtHowManyServers"  SetFocusOnError="true"
			    ValidationExpression="^\d{1,10}$"
			    ErrorMessage="Please enter a number." ToolTip="Please enter a number of Windows-based servers.">
			    Please enter a number of Windows-based servers.
			</asp:RegularExpressionValidator>
		</li>
		<li>
			<asp:Label ID="lblPrimaryServerOS" runat="server" AssociatedControlID="txtPrimaryServerOS">
			    Primary Server OS (NT4.0, Win2000, Win2003):
			</asp:Label>
			<asp:TextBox ID="txtPrimaryServerOS" runat="server" columns="30" MaxLength="30" CssClass="text" />
		</li>	
		<li>
			<asp:Label ID="lblHowManyBackupServers" runat="server" AssociatedControlID="txtHowManyBackupServers">
			    Number of Windows-based servers used for backup:
			</asp:Label>
			<asp:TextBox ID="txtHowManyBackupServers" runat="server" columns="30" MaxLength="10" CssClass="text" />
			<asp:RegularExpressionValidator ID="revHowManyBackupServers" runat="server" 
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtHowManyBackupServers"  SetFocusOnError="true"
			    ValidationExpression="^\d{0,10}$"
			    ErrorMessage="Please enter a number." ToolTip="Please enter a number.">
			    Please enter a number.
			</asp:RegularExpressionValidator>
		</li>	
        <li class="checkboxes">
            <label for="fstBackupProducts" class="labelLong">
                Product(s) currently used for backup (Check all that apply):
            </label>
            <fieldset id="fstBackupProducts" class="clear">
                <pop:CheckList ID="cblBackupProducts" runat="server" CssClass="goofy">
                    <asp:ListItem Value="NT Backup" Text="NT Backup" />
                    <asp:ListItem Value="Backup Exec" Text="Backup Exec" />
                    <asp:ListItem Value="ARCserve" Text="ARCserve" />
                </pop:CheckList>
                <asp:Label AssociatedControlID="txtBackupProductsOther" runat="server" Text="Other (please specify)" />
                <asp:TextBox ID="txtBackupProductsOther" ToolTip="Enter 'Other' backup products"
                    runat="server" MaxLength="30" CssClass="text otherCheck"></asp:TextBox>
                <div class="clear">
                </div>
                
            </fieldset>
            <div class="clear">
            </div>
        </li>
		<li>
			<asp:Label ID="lblIsDisasterRecoveryIssue" runat="server" AssociatedControlID="rblIsDisasterRecoveryIssue" CssClass="labelLong">
			    Is disaster recovery an issue for your company, separate from your regular backup solution?
			</asp:Label>
            <pop:RadioList ID="rblIsDisasterRecoveryIssue" runat="server" CssClass="goofy">
                <asp:ListItem Value="Yes" Text="Yes" />
                <asp:ListItem Value="No" Text="No" />
            </pop:RadioList>
		</li>			
		<li>
			<asp:Label ID="lblHaveReliabilityProblems" runat="server" AssociatedControlID="rblHaveReliabilityProblems" CssClass="labelLong">
			    Does your current Windows-based backup software have any backup or restore reliability problems?
			</asp:Label>
            <pop:RadioList ID="rblHaveReliabilityProblems" runat="server" CssClass="goofy">
                <asp:ListItem Value="Yes" Text="Yes" />
                <asp:ListItem Value="No" Text="No" />
            </pop:RadioList>
		</li>			
		<li>
			<asp:Label ID="lblTechSupportRating" runat="server" AssociatedControlID="ddlTechSupportRating">
			    Please rate the quality of your current backup software's tech support:
			</asp:Label>
			<asp:DropDownList ID="ddlTechSupportRating" runat="server">
			    <asp:ListItem Value="-1" Text="Select..." />
			    <asp:ListItem Value="Excellent" Text="Excellent" />
			    <asp:ListItem Value="Good" Text="Good" />
			    <asp:ListItem Value="Average" Text="Average" />
			    <asp:ListItem Value="Poor" Text="Poor" />
			    <asp:ListItem Value="Could not be worse" Text="Could not be worse" />
			</asp:DropDownList>
		</li>	
        <li class="textarea">
            <asp:Label ID="lblOtherProblems" runat="server" AssociatedControlID="txtOtherProblems">
                Is your company experiencing any other significant backup problems? Please explain:
            </asp:Label>
            <asp:TextBox ID="txtOtherProblems" runat="server" Height="50px" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
        </li>
		<li>
			<asp:Label ID="lblFoundUltraBacVia" runat="server" AssociatedControlID="ddlFoundUltraBacVia">
			    I found UltraBac via:
			</asp:Label>
			<asp:DropDownList ID="ddlFoundUltraBacVia" runat="server" 
			        AppendDataBoundItems="true"
			        DataTextField="source_Text" DataValueField="source_Text">
			    <asp:ListItem Value="-1" Text="Select..." />
			</asp:DropDownList>
		</li>	
		<li>
		    <label></label>
            <asp:Button ID="btnSubmit" runat="server" CssClass="submit marginCenter floatnone" OnClick="btnSubmit_Click" Text="Submit" />
        </li>
    </ol>

</asp:PlaceHolder>

<asp:PlaceHolder ID="plhDownloadLink" runat="server" Visible="false">
	<ZNode:CustomMessage runat="server" MessageKey="DownloadTrialFormSubmitted" />
    <p runat="server" visible="false"><strong>License Key:</strong>  <asp:Label ID="lblTrialKey" runat="server" /></p>
    <p><asp:Label ID="lblDownloadError" runat="server" Visible="false" /></p>
    <p><asp:LinkButton ID="btnDownloadNow" runat="server" OnClick="btnDownloadNow_Click" CausesValidation="false">Download Now</asp:LinkButton></p>

</asp:PlaceHolder>