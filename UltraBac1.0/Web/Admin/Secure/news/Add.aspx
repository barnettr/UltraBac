<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Secure_News_Add" Title="Untitled Page" %>
<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="uc1" %>

<asp:Content ContentPlaceHolderID="Head" runat="server">
<style type="text/css">

a.Button
{
    text-decoration:none;
}
</style>
</asp:Content>
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
    	
        <div class="FieldStyle">Enter a title for this newsletter</div>
        <div class="ValueStyle"><asp:TextBox ID="uxTitle" runat="server" MaxLength="64" Columns="50"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxTitle" Display="Dynamic" ErrorMessage="Enter a title for the newsletter" SetFocusOnError="True" CssClass="Error" ForeColor="" />        
        </div>
        
        <div class="FieldStyle">Enter a newsletter type</div>
        <div class="ValueStyle">
			<Pop:RadioList runat="server" ID="uxNewsletterType" >
				<asp:ListItem Text="Customer" Value="0" Selected="True" />
				<asp:ListItem Text="Reseller" Value="1" />
			</Pop:RadioList>        
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxNewsletterType" Display="Dynamic" ErrorMessage="Enter the newsletter type" SetFocusOnError="True" CssClass="Error" ForeColor="" />        
        </div>
        
        
        <div class="FieldStyle">Enter a sort order</div>
        <div class="ValueStyle"><asp:TextBox ID="uxSortOrder" runat="server" MaxLength="2" Columns="50"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxSortOrder" Display="Dynamic" ErrorMessage="Enter a sort order" SetFocusOnError="True" CssClass="Error" ForeColor="" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="uxSortOrder" Display="Dynamic" ErrorMessage="Sort order must be a number between 0 and 99" ValidationExpression="^[0-9]+$" SetFocusOnError="true" CssClass="Error" ForeColor="" />
        </div>

        <div class="FieldStyle">Enter a summary for this newsletter</div>        
        <div class="ValueStyle">
        <uc1:HtmlTextBox ID="uxSummary" runat="server" MaxLength="128" /></div>
        
        <div class="FieldStyle">Enter a date for this newsletter</div>
        <div class="ValueStyle"><asp:TextBox ID="uxPublishDate" runat="server" MaxLength="32" Columns="35"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxPublishDate" Display="Dynamic" ErrorMessage="Enter a date for the newsletter" SetFocusOnError="True" CssClass="Error" ForeColor=""/>
				</div>
	    <div>
	        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
	        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
	    </div>
	    
	    <asp:PlaceHolder runat="server" ID="uxArticleSection" Visible="false">
	    
	    <h2>Manage Articles</h2>
	    <a class="Button" href="article/add.aspx?parentId=<%= ItemId %>">Add Article</a>
	    <br /><br /><br />
	    <asp:GridView ID="uxArticles" 
	    CssClass="Grid" 
	    CellPadding="4" 
	    Width="600" 
	    ForeColor="#333333" 
	    OnRowCommand="GridArticle_Command" 
	    AutoGenerateColumns="false" 
	    GridLines="None" 
	    ShowFooter="false" 
	    ShowHeader="true" 
	    EmptyDataText="There are no articles."
	    runat="server">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Article ID" />
                <asp:BoundField DataField="SortOrder" HeaderText="Sort Order" />
                <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Width="500" HeaderImageUrl="Short Title" />
                
                <asp:ButtonField CommandName="EditArticle" Text="Edit" ButtonType="Button" >
                   <ControlStyle CssClass="Button" />
                </asp:ButtonField>                
                <asp:ButtonField CommandName="DeleteArticle" Text="Delete" ButtonType="Button" >
                   <ControlStyle CssClass="Button" />
                </asp:ButtonField>
            </Columns>
             <FooterStyle CssClass="FooterStyle"/>
            <RowStyle CssClass="RowStyle"/>                    
            <PagerStyle CssClass="PagerStyle" Font-Underline="True" />
            <HeaderStyle CssClass="HeaderStyle"/>
            <AlternatingRowStyle CssClass="AlternatingRowStyle"/>
        </asp:GridView>
        </asp:PlaceHolder>
	</div>
</asp:Content>

