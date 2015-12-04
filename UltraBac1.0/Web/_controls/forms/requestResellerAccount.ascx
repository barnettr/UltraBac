<%@ Control Language="C#" AutoEventWireup="true" CodeFile="requestResellerAccount.ascx.cs"
    Inherits="_controls_forms_requestResellerAccount" %>

<script type="text/javascript">
//<![CDATA[
	var operatingCheckboxes;
	var operatingText;

	var vehicleCheckboxes;
	var vehicleText;

	var hearCheckboxes;
	var hearText;

	var serviceCheckboxes;
	
    document.observe("dom:loaded", function() {
        operatingCheckboxes = $$("#fstOperatingSystems input[type='checkbox']");
        operatingText = $$("#fstOperatingSystems input[type='text']").reduce();
        //operatingCheckboxes.invoke("observe", "blur", validateOperating);
        //operatingText.observe("blur", validateOperating);
        

        vehicleCheckboxes = $$("#fstMarketingVehicles input[type='checkbox']");
        vehicleText = $$("#fstMarketingVehicles input[type='text']").reduce();
        //vehicleCheckboxes.invoke("observe", "blur", validateVehicle);
        //vehicleText.observe("blur", validateVehicle);
        

        hearCheckboxes = $$("#fstHowHeard input[type='checkbox']");
        hearText = $$("#fstHowHeard input[type='text']").reduce();
        //hearCheckboxes.invoke("observe", "blur", validateHear);
        //hearText.observe("blur", validateHear);   
             

        serviceCheckboxes = $$("#fstServices input");
        //serviceCheckboxes.invoke("observe", "blur", validateService);

    });
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

        function validateService(errorEl, args) {
    	    args.IsValid = false;
            var inputLength = serviceCheckboxes.length;
            for(var i = 0; i < inputLength; i++) {
                if(serviceCheckboxes[i].checked) {
            	    args.IsValid = true;
            	    return;
                }
            }
        }
        
        function validateOperating(errorEl, args) {
            args.IsValid = getValidationBoolean(operatingCheckboxes, operatingText);
        }
        
        function validateVehicle(errorEl, args) {
            args.IsValid = getValidationBoolean(vehicleCheckboxes, vehicleText);
        }
        
        function validateHear(errorEl, args) {
            args.IsValid = getValidationBoolean(hearCheckboxes, hearText);
        }

        function getValidationBoolean(inputs, inputText) {
    	    if (inputText.value.length > 0) return true;
    	    var inputLength = inputs.length;
    	    for (var i = 0; i < inputLength; i++) {
    		    if (inputs[i].checked)
    			    return true;
    	    }
		    return false;
        }
      

//]]>
</script>


<asp:PlaceHolder ID="plhContact" runat="server" Visible="true">
	<ZNode:Content runat="server" />
    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
	
    <p>Fields marked with <span style="color:Red;">*</span> are required.</p>

	<h2>Contact Information</h2>
	
    <ol class="form">
        <li class="required">
            <asp:Label runat="server" AssociatedControlID="txtCompanyName"><span style="color:Red;">*</span> Company Name:</asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server" Columns="30" MaxLength="50" CssClass="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error"
				SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtCompanyName" 
                ErrorMessage="Please enter a Company name."
                ToolTip="Please enter a Company name.">
			    Please enter a Company name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label runat="server" AssociatedControlID="txtFirstName"><span style="color:Red;">*</span> First Name:</asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error"
				SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="Please enter a First Name."
                ToolTip="Please enter a First Name.">
			    Please enter a First Name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label runat="server" AssociatedControlID="txtLastName"><span style="color:Red;">*</span> Last Name:</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" Columns="30" MaxLength="30" CssClass="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error"
				SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtLastName" ErrorMessage="Please enter a Last Name."
                ToolTip="Please enter a Last Name.">
			    Please enter a Last Name.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label runat="server" AssociatedControlID="txtTitle"><span style="color:Red;">*</span> Title:</asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Columns="30" MaxLength="30" CssClass="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error"
				SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtTitle" ErrorMessage="Please enter a Title."
                ToolTip="Please enter a Title.">
			    Please enter a Title.
            </asp:RequiredFieldValidator>
        </li>
        <li class="required">
            <asp:Label runat="server" AssociatedControlID="txtPhone"><span style="color:Red;">*</span> Phone/Ext:</asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" Columns="30" MaxLength="20" CssClass="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error"
				SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtPhone" 
                ErrorMessage="Please enter Phone/Ext." ToolTip="Please enter Phone/Ext.">
			    Please enter Phone/Ext.
            </asp:RequiredFieldValidator>
        </li>
        <li>
            <asp:Label runat="server" AssociatedControlID="txtFax">Fax:</asp:Label>
            <asp:TextBox ID="txtFax" runat="server" Columns="30" MaxLength="20" CssClass="text" />
        </li>
        <li class="required">
            <asp:Label runat="server" AssociatedControlID="txtEmail"><span style="color:Red;">*</span> Email:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Columns="30" MaxLength="40" CssClass="text" />
            <asp:RequiredFieldValidator runat="server" ForeColor=" " CssClass="Error"
				SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ErrorMessage="Please enter Email." ToolTip="Please enter Email.">
			    Please enter Email.
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ForeColor=" " CssClass="Error"
				SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="txtEmail" 
                ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address.">
			    Please enter a valid email address.
            </asp:RegularExpressionValidator>
        </li>
        <li class="required">
            <asp:Label runat="server" AssociatedControlID="txtURL">Company URL:</asp:Label>
            <asp:TextBox ID="txtURL" runat="server" Columns="30" MaxLength="40" CssClass="text" />
        </li>
    </ol>

	<h2>Location</h2>

    <ol class="form">
		<li class="required">
			<asp:Label runat="server" AssociatedControlID="txtAddress1"><span style="color:Red;">*</span> Address 1:</asp:Label>
			<asp:TextBox ID="txtAddress1" runat="server" columns="30" MaxLength="50" CssClass="text" />
			<asp:RequiredFieldValidator runat="server" 
				SetFocusOnError="true"
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtAddress1" 
			    ErrorMessage="Please enter Address 1." ToolTip="Please enter Address 1.">
			    Please enter Address 1.
			</asp:RequiredFieldValidator>
		</li>	
		<li>
			<asp:Label runat="server" AssociatedControlID="txtAddress2">Address 2:</asp:Label>
			<asp:TextBox ID="txtAddress2" runat="server" columns="30" MaxLength="50" CssClass="text" />
		</li>	
		<li class="required">
			<asp:Label runat="server" AssociatedControlID="txtCity"><span style="color:Red;">*</span> City:</asp:Label>
			<asp:TextBox ID="txtCity" runat="server" columns="30" MaxLength="30" CssClass="text" />
			<asp:RequiredFieldValidator runat="server" 
				SetFocusOnError="true"
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtCity" 
			    ErrorMessage="Please enter City." ToolTip="Please enter City.">
			    Please enter City.
			</asp:RequiredFieldValidator>
		</li>	
		<li class="required">
			<asp:Label runat="server" AssociatedControlID="txtZip"><span style="color:Red;">*</span> Zip:</asp:Label>
			<asp:TextBox ID="txtZip" runat="server" columns="30" MaxLength="20" CssClass="text" />
			<asp:RequiredFieldValidator runat="server" 
				SetFocusOnError="true"
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtZip" 
			    ErrorMessage="Please enter Zip." ToolTip="Please enter Zip.">
			    Please enter Zip.
			</asp:RequiredFieldValidator>
		</li>
		<li class="required">
			<asp:Label runat="server" AssociatedControlID="ddlCountry"><span style="color:Red;">*</span> Country:</asp:Label>
			<asp:DropDownList ID="ddlCountry" runat="server" AppendDataBoundItems="true">
			    <asp:ListItem Value="-1" Text="Select..." />
			</asp:DropDownList>
			<asp:RequiredFieldValidator runat="server" 
				SetFocusOnError="true"
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="ddlCountry" 
			    InitialValue="-1"
			    ErrorMessage="Please select a Country." ToolTip="Please select a Country.">
			    Please select a Country.
			</asp:RequiredFieldValidator>
		</li>	
		<li class="required">
		    <label><span class="red">*</span> State/Province or Territory:</label>
		    <div id="divStateDDL" runat="server">
			    <asp:DropDownList ID="ddlState" AppendDataBoundItems="true" runat="server">
			        <asp:ListItem Value="-1" Text="Select..." />
			    </asp:DropDownList>
            </div>
            <div id="divStateTxt" runat="server">
			    <asp:TextBox ID="txtState" runat="server" columns="30" MaxLength="20" CssClass="text" />
            </div>
            <asp:CustomValidator runat="server"
                ForeColor=" " CssClass="Error" Display="Dynamic"
                OnServerValidate="cvState_ServerValidate"
                ErrorMessage="Please enter or select a State." ToolTip="Please enter or select a State." />
		</li>	
    </ol>
    <div class="clear"></div>
	
	<h2>Survey</h2>

    <ol class="form" style="margin-bottom: 0px;">
		<li class="required">
			<asp:Label runat="server" AssociatedControlID="txtAnnualRevenue">
			    <span style="color:Red;">*</span> Annual Revenue:</asp:Label>
			<asp:TextBox ID="txtAnnualRevenue" runat="server" columns="30" MaxLength="20" CssClass="text" />
			<asp:RequiredFieldValidator runat="server" 
				SetFocusOnError="true"
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtAnnualRevenue" 
			    ErrorMessage="Please enter Annual Revenue." ToolTip="Please enter Annual Revenue.">
			    Please enter Annual Revenue.
			</asp:RequiredFieldValidator>
		</li>
		<li class="required">
			<asp:Label runat="server" AssociatedControlID="txtNumberOfLocations">
			    <span style="color:Red;">*</span> Number of Locations:</asp:Label>
			<asp:TextBox ID="txtNumberOfLocations" runat="server" columns="30" MaxLength="10" CssClass="text" />
			<asp:RequiredFieldValidator runat="server" Display="Dynamic" ForeColor=""
				SetFocusOnError="true"
				ControlToValidate="txtNumberOfLocations" 
				ErrorMessage="Please enter number of locations." CssClass="Error" />
			<asp:RegularExpressionValidator ID="revNumberOfLocations" runat="server" 
				SetFocusOnError="true"
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtNumberOfLocations" 
			    ValidationExpression="^\d{1,10}$"
			    ErrorMessage="Please enter a number." ToolTip="Please enter a number.">
			    Please enter a number.
			</asp:RegularExpressionValidator>
		</li>	
		<li class="required">
			<asp:Label runat="server" AssociatedControlID="txtNumberOfEmployees">
			    <span style="color:Red;">*</span> Number of Employees at Your Location:</asp:Label>
			<asp:TextBox ID="txtNumberOfEmployees" runat="server" columns="30" MaxLength="10" CssClass="text" />
			<asp:RequiredFieldValidator runat="server" 
				SetFocusOnError="true"
				Display="static" ControlToValidate="txtNumberOfEmployees" 
				ErrorMessage="Please enter number of employees." 
				ForeColor="" CssClass="Error" />
			<asp:RegularExpressionValidator ID="revNumberOfEmployees" runat="server" 
				SetFocusOnError="true"
			    ForeColor=" " CssClass="Error" Display="Dynamic" ControlToValidate="txtNumberOfEmployees" 
			    ValidationExpression="^\d{1,10}$"
			    ErrorMessage="Please enter a number." ToolTip="Please enter a number.">
			    Please enter a number.
			</asp:RegularExpressionValidator>
		</li>	
		<li class="required">
			<asp:Label CssClass="labelLong" runat="server" AssociatedControlID="rblCoverage">
			    <span style="color:Red;">*</span> Geographic Coverage:
			</asp:Label>
            <pop:RadioList ID="rblCoverage" runat="server" CssClass="goofy">
                <asp:ListItem Value="Local" Text="Local" />
                <asp:ListItem Value="Regional" Text="Regional" />
                <asp:ListItem Value="National" Text="National" />
                <asp:ListItem Value="International" Text="International" />
            </pop:RadioList>
            <asp:RequiredFieldValidator runat="server" 
				SetFocusOnError="true"
				ForeColor=" " CssClass="Error"
                Display="Dynamic" ControlToValidate="rblCoverage" ErrorMessage="Please select coverage."
                ToolTip="Please select coverage." />            
		</li>			
        <li class="required checkboxes">
            <label for="fstServices" class="labelLong">
                <span style="color:Red;">*</span> What sales / service efforts generate your major customer revenue?
            </label>
            <div class="clear"></div>
            <fieldset id="fstServices">
                <pop:CheckList ID="cblServices" runat="server" CssClass="goofy">
                    <asp:ListItem Value="Consulting" Text="Consulting" />
                    <asp:ListItem Value="Software Sales" Text="Software Sales" />
                    <asp:ListItem Value="Hardware Sales" Text="Hardware Sales" />
                    <asp:ListItem Value="Tech Support Training" Text="Tech Support Training" />
                    <asp:ListItem Value="Software Development" Text="Software Development" />
                    <asp:ListItem Value="Networks" Text="Networks" />
                    <asp:ListItem Value="Web Design" Text="Web Design" />
                </pop:CheckList>
            </fieldset>
            <asp:CustomValidator ClientValidationFunction="validateService" runat="server"
                ForeColor=" " CssClass="Error" Display="Dynamic"
                OnServerValidate="cvServices_ServerValidate"
                ErrorMessage="Please make a selection." ToolTip="Please make a selection." />
            <div class="clear">
            </div>
        </li>
        <li class="required checkboxes">
            <label for="fstOperatingSystems" class="labelLong">
                <span style="color:Red;">*</span> Operating Systems:</label>
            <div class="clear"></div>
            <fieldset id="fstOperatingSystems">
                <pop:CheckList ID="cblOperatingSystems" runat="server" CssClass="goofy">
                    <asp:ListItem Value="95/98/2000/XP/Vista" Text="Windows 95 / 98 / 2000 / XP / Vista" />
                    <asp:ListItem Value="Windows NT" Text="Windows NT" />
                    <asp:ListItem Value="UNIX" Text="UNIX" />
                </pop:CheckList>
                <asp:Label AssociatedControlID="txtOperatingSystemsOther" runat="server" Text="Other (please specify)" />
                <asp:TextBox ID="txtOperatingSystemsOther" ToolTip="Enter 'Other' operating systems"
                    runat="server" MaxLength="30" CssClass="text otherCheck"></asp:TextBox>
            </fieldset>
            <asp:CustomValidator ClientValidationFunction="validateOperating" runat="server"
                ForeColor=" " CssClass="Error" Display="dynamic"
                OnServerValidate="cvOperatingSystems_ServerValidate"
                ErrorMessage="Please specify the Operating System/s." ToolTip="Please specify the Operating System/s." />
            <div class="clear">
            </div>
        </li>
        <li class="required checkboxes">
            <label for="fstMarketingVehicles" class="labelLong">
                <span style="color:Red;">*</span> What types of marketing vehicles does your company use to promote products to your customers?
            </label>
            <div class="clear"></div>
            <fieldset id="fstMarketingVehicles">
                <pop:CheckList ID="cblMarketingVehicles" runat="server" CssClass="goofy">
                    <asp:ListItem Value="Seminars" Text="Seminars" />
                    <asp:ListItem Value="Ads" Text="Ads" />
                    <asp:ListItem Value="Direct Mail" Text="Direct Mail" />
                    <asp:ListItem Value="Web Site" Text="Web Site" />
                    <asp:ListItem Value="Trade Shows" Text="Trade Shows" />
                </pop:CheckList>
                <asp:Label AssociatedControlID="txtMarketingVehiclesOther" runat="server" Text="Other (please specify)" />
                <asp:TextBox ID="txtMarketingVehiclesOther" ToolTip="Enter 'Other' marketing vehicles"
                    runat="server" MaxLength="30" CssClass="text otherCheck"></asp:TextBox>
            </fieldset>
            <asp:CustomValidator ClientValidationFunction="validateVehicle" runat="server"
                ForeColor=" " CssClass="Error" Display="Dynamic"
                OnServerValidate="cvMarketingVehicles_ServerValidate"
                ErrorMessage="Please specify a Marketing Vehicle." ToolTip="Please specify a Marketing Vehicle." />
            <div class="clear">
            </div>
        </li>
        <li class="required checkboxes">
            <label for="fstHowHeard" class="labelLong">
                <span style="color:Red;">*</span> How did you hear about the UltraBac Solution Provider Program?
            </label>
            <div class="clear"></div>
            <fieldset id="fstHowHeard">
                <pop:CheckList ID="cblHowHeard" runat="server" CssClass="goofy">
                    <asp:ListItem Value="Trade Show" Text="Trade Show" />
                    <asp:ListItem Value="Ad" Text="Ad" />
                    <asp:ListItem Value="Press" Text="Press" />
                    <asp:ListItem Value="Mailing" Text="Mailing" />
                    <asp:ListItem Value="Word of Mouth" Text="Word of Mouth" />
                </pop:CheckList>
                <asp:Label AssociatedControlID="txtHowHeardOther" runat="server" Text="Other (please specify)" />
                <asp:TextBox ID="txtHowHeardOther" ToolTip="Enter 'Other' sources"
                    runat="server" MaxLength="30" CssClass="text otherCheck"></asp:TextBox>
            </fieldset>
            <asp:CustomValidator ClientValidationFunction="validateHear" runat="server"
                ForeColor=" " CssClass="Error" Display="Dynamic"
                OnServerValidate="cvHowHeard_ServerValidate"
                ErrorMessage="Please specify how you heard about the program." ToolTip="Please specify how you heard about the program." />
            <div class="clear">
            </div>
        </li>
        <li class="textarea">
            <ol class="form" style="margin-bottom: 0px;">
                <li>
                    <asp:Label runat="server" AssociatedControlID="txtFeedback" CssClass="labelLong">
                        Our success depends on your success and your input is important to us. What would you like to see included in our Solution Provider Program to make it more meaningful to you?
                    </asp:Label>
                </li>
                <li>
                    
                    <asp:TextBox CssClass="width100" ID="txtFeedback" runat="server" Height="50px" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                </li>
            </ol>
        </li>
        <li>            
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="submit marginCenter floatnone" />
        </li>
    </ol>
    

</asp:PlaceHolder>

<asp:PlaceHolder ID="plhThankYou" runat="server" Visible="false">
<ZNode:CustomMessage runat="server" MessageKey="RequestResellerAccountConfirmation" />
</asp:PlaceHolder>
