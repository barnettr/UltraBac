<%@ Page Language="C#" MasterPageFile="~/themes/default/Content/Content.master" AutoEventWireup="true" CodeFile="buttons.aspx.cs" Inherits="_DND_styleguide" Title="Untitled Page" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadPlaceHolder">


</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server" >

        <a class="actionButton" href="NEEDURL">
		    <span class="actionButton-right actionButtons-long">
	            <span class="actionButton-left">
	                This is for a long one
	            </span>
	        </span>
	    </a>
	    
	    <a class="actionButton" href="NEEDURL">
		    <span class="actionButton-right actionButtons-short">
	            <span class="actionButton-left">
	                This is for a long one
	            </span>
	        </span>
	    </a>

</asp:Content>
