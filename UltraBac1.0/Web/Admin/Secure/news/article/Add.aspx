<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Secure_News_Article_Add" Title="Untitled Page" %>
<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <div class="Form">
	    <table width="100%" cellspacing="0" cellpadding="0" >
		    <tr>
			    <td><h1><asp:Label ID="lblTitle" Runat="server"></asp:Label>
                    <uc2:DemoMode ID="DemoMode1" runat="server" />
                </h1></td>
		    </tr>
	    </table>
			    
	    <div><uc1:spacer id="Spacer8" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
    	<div><asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label></div>
    	<div><uc1:spacer id="Spacer1" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
    	
        <div class="FieldStyle">Enter a title for this article</div>
        <div class="ValueStyle"><asp:TextBox ID="uxTitle" runat="server" MaxLength="64" Columns="50"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxTitle" Display="Dynamic" ErrorMessage="Enter a title for the article" SetFocusOnError="True" CssClass="Error" ForeColor="" />
        </div>

        <div class="FieldStyle">Enter a short title for this article (Used in left menu)</div>
        <div class="ValueStyle"><asp:TextBox ID="uxShortTitle" runat="server" MaxLength="64" Columns="50"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxShortTitle" Display="Dynamic" ErrorMessage="Enter a short title for the article" SetFocusOnError="True" CssClass="Error" ForeColor="" />
        </div>

        <div class="FieldStyle">Enter a summary for this article</div>
        <div class="ValueStyle"><asp:TextBox ID="uxSummary" runat="server" MaxLength="128" Columns="50" TextMode="MultiLine" Rows="3"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxSummary" Display="Dynamic" ErrorMessage="Enter a summary for the article" SetFocusOnError="True" CssClass="Error" ForeColor="" />
        </div>

        <div class="FieldStyle">Enter a sort order</div>
        <div class="ValueStyle"><asp:TextBox ID="uxSortOrder" runat="server" MaxLength="2" Columns="50"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxSortOrder" Display="Dynamic" ErrorMessage="Enter a sort order" SetFocusOnError="True" CssClass="Error" ForeColor="" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="uxSortOrder" Display="Dynamic" ErrorMessage="Sort order must be a number between 0 and 99" ValidationExpression="^[0-9]+$" SetFocusOnError="true" CssClass="Error" ForeColor="" />
        </div>

	    <div class="FieldStyle">Enter a body for this article</div>
        <div class="ValueStyle"><uc1:HtmlTextBox id="uxBody" runat="server"></uc1:HtmlTextBox></div>
	    
	    <div>
	        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
	        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
	    </div>	
	</div>
</asp:Content>

