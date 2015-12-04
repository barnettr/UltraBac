<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Secure_Page_Add" Title="Untitled Page" %>
<%@ Register Src="../../../Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <div class="Form">
	    <table width="100%" cellspacing="0" cellpadding="0" >
		    <tr>
			    <td><h1><asp:Label ID="lblTitle" Text="Add a Page" Runat="server"></asp:Label>
                    <uc2:DemoMode ID="DemoMode1" runat="server" />
                </h1></td>
			    <td align="right">
				    <asp:button class="Button" id="btnSubmitTop" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
				    <asp:button class="Button" id="btnCancelTop" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
			    </td>
		    </tr>
	    </table>
			    
	    <div><uc1:spacer id="Spacer8" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
    	<div><asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label></div>
    	<div><uc1:spacer id="Spacer1" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
    	
    	<h4>General Settings</h4>

        <div class="FieldStyle">Enter a  descriptive name for this page (ex: AboutUs)<span class="Asterix">*</span></div>
        <div><asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Enter a name for the page" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ErrorMessage="The page name can only contain letters, numbers, '_' and '-'." ControlToValidate="txtName" ValidationExpression="^[a-zA-Z0-9_-]+$"></asp:RegularExpressionValidator></div>
        <div class="ValueStyle"><asp:TextBox ID="txtName" runat="server" MaxLength="50" Columns="50"></asp:TextBox></div>        
        
        <div class="FieldStyle">Enter a title for this page (ex: "Welcome to my site")</div>
        <div class="ValueStyle"><asp:TextBox ID="txtTitle" runat="server" MaxLength="500" Columns="50"></asp:TextBox></div>
        
        <div class="FieldStyle">Choose a Template for this page</div>
        <div class="ValueStyle">
        
        <asp:DropDownList runat="server" ID="uxTemplate" AutoPostBack="true">
            <asp:ListItem Text="Standard Content" Value="/Content/Content.master" />
            <asp:ListItem Text="One Column" Value="/Content/OneColumn.master" />
            <asp:ListItem Text="Two Column" Value="/Content/TwoColumn.master" />
            <asp:ListItem Text="Redirect Page" Value="/Content/Redirect.master" />
            <asp:ListItem Text="Event Pages" Value="/Events/Event.master" />
            <asp:ListItem Text="Form Entry (secure)" Value="/Form/Form.master" />
            <asp:ListItem Text="Newsletter List" Value="/MailList/MailList.master" />
            <asp:ListItem Text="Category Page" Value="/Product/Category.master" />
            <asp:ListItem Text="Business Solution" Value="/Product/Solution.master" />
            <asp:ListItem Text="Homepage" Value="/Home/Home.master" />
            <asp:ListItem Text="Bulk Order" Value="/Product/OneStop.master" />
            <asp:ListItem Text="Reseller Protected Page" Value="/Reseller/Reseller.master" />
            <asp:ListItem Text="Reseller Search" Value="/Reseller/Search.master" />
        </asp:DropDownList>
        <asp:TextBox ID="txtTemplate" runat="server" MaxLength="500" Columns="50" Visible="false" />
        </div>
        
        <asp:PlaceHolder ID="plhRedirectSettings" runat="server" Visible="false">
        <h4>Redirect Behavior</h4>
            <div class="FieldStyle">Enter a url (with http) for automatic redirect. Leave blank for no redirect.</div>
            <div class="ValueStyle"><asp:TextBox ID="txtRedirectAddress" runat="server" MaxLength="500" Columns="50"></asp:TextBox></div>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="plhFormSetting" Visible="false">
        <h4>Form Settings</h4>
            <div class="FieldStyle">Which email address will receive this form (comma separated)?<span class="Asterix">*</span></div>
            <div><asp:RequiredFieldValidator runat="server" ControlToValidate="txtFromRecipient" Display="Dynamic" ErrorMessage="Enter comma separated email addresses that will receive this form" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ErrorMessage="Enter comma separated email addresses that will receive this form" ControlToValidate="txtFromRecipient" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}(,\s*[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$"></asp:RegularExpressionValidator></div>
            <div class="ValueStyle"><asp:TextBox ID="txtFromRecipient" runat="server" MaxLength="300" Columns="50"></asp:TextBox></div>        
        </asp:PlaceHolder>        
           	
    	
        <h4>Reseller Settings</h4>
        <div class="ValueStyle">        
        <asp:CheckBox id="uxResellerPage" Text="Reseller Page (Resellers must login to view this page)" runat="server" />
        </div>
        
        <h4>Menu Settings</h4>
        <asp:PlaceHolder ID="plhMenuSettings" runat="server">
        
        <asp:Label ID="lblSettingsLocked" CssClass="Error" runat="server" Visible="false">
            Note: Reserved pages cannot change location.
        </asp:Label>
        
            <div class="FieldStyle">Choose the location for this page</div>
            <div class="ValueStyle">
                <asp:DropDownList ID="ddlParentContentPage" runat="server"
                        AppendDataBoundItems="true">
                    <asp:ListItem Text="select..." Value="-1" />
                </asp:DropDownList>
            </div>
            
            <div class="FieldStyle">Enter a menu title for this page (ex: "Welcome")</div>
            <div class="ValueStyle"><asp:TextBox ID="txtLinkText" runat="server" MaxLength="75" Columns="50"></asp:TextBox></div>
            
            <div class="FieldStyle">Enter the menu position for this page</div>
            <div>
                <asp:RegularExpressionValidator ID="revSortIndex" runat="server" Display="Dynamic" ErrorMessage="Enter a number between 0 and 99." ControlToValidate="txtSortIndex" ValidationExpression="^\d{1,2}$"></asp:RegularExpressionValidator>
            </div>
            <div class="ValueStyle"><asp:TextBox ID="txtSortIndex" runat="server" MaxLength="2" Columns="50"></asp:TextBox></div>
        
            <div class="FieldStyle">Check the box below to publish this page</div>
            <div class="ValueStyle"><asp:CheckBox ID="chkActiveInd" Text="Publish this page" runat="server" Checked="true" /></div>
           
        </asp:PlaceHolder>       
        
        <h4>SEO Settings</h4>
        
        <div class="FieldStyle">Enter a SEO title for the page</div>
        <div class="ValueStyle"><asp:TextBox ID="txtSEOTitle" runat="server" MaxLength="500" Columns="50"></asp:TextBox></div>
  
        <div class="FieldStyle">Enter Meta Keywords</div>
        <div class="ValueStyle"><asp:TextBox ID="txtSEOMetaKeywords" runat="server" MaxLength="500" Columns="50"></asp:TextBox></div>
  
        <div class="FieldStyle">Enter Meta Description</div>
        <div class="ValueStyle"><asp:TextBox ID="txtSEOMetaDescription" runat="server" MaxLength="500" Columns="50"></asp:TextBox></div>
         
        <h4>Page Content</h4>
        <div class="FieldStyle">Enter a Short Summary (this will be visible on certain callouts)</div>
        <div class="ValueStyle"><asp:TextBox ID="txtSummary" runat="server" MaxLength="500" Columns="50"></asp:TextBox></div>
        
        <div class="FieldStyle">Enter Page Content</div>
        <div class="ValueStyle"><uc1:HtmlTextBox id="ctrlHtmlText" runat="server"></uc1:HtmlTextBox></div>
	    
	    <div>
	        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
	        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
	    </div>	
	</div>
</asp:Content>

