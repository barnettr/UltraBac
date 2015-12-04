<%@ Page Language="C#"  MasterPageFile="~/Admin/Themes/Standard/edit.master"  AutoEventWireup="true" CodeFile="case_email.aspx.cs" Inherits="Admin_Secure_cases_case_email" %>

<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">

<div class="Form">
	    <table width="100%" cellSpacing="0" cellPadding="0" >
		    <tr>
			    <td><h1>Reply to Customer<uc2:DemoMode ID="DemoMode1" runat="server" />
                </h1></td>
			    <td align="right">
				    <asp:button class="Button" id="btnSubmitTop" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
				    <asp:button class="Button" id="btnCancelTop" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
			    </td>
		    </tr>
	    </table>

        <uc1:spacer id="Spacer8" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
        
        <table border="0">
                <tr>
                    <td class="FieldStyle">
                         Email Subject                
                    </td>
                    <td class="ValueStyle">
                        <asp:TextBox ID="txtEmailSubj" runat="server" />
                    </td>
               </tr> 
               <tr>
                    <td colspan="2">
                        <uc1:spacer id="Spacer2" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
                    </td>
               </tr>
               <tr>
                    <td valign="top" class="FieldStyle">
                         Email Message
                    </td>
                    <td class="ValueStyle">
                        <uc1:HtmlTextBox id="ctrlHtmlText" Mode="1" runat="server"></uc1:HtmlTextBox>
                    </td>
               </tr>               
        </table>
        
        <uc1:spacer id="Spacer1" SpacerHeight="15" SpacerWidth="3" runat="server"></uc1:spacer>    	   	  
        <asp:Label id="lblEmailid" runat="server"  Visible="false"/>
        <div>
	        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
	        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
	    </div>	
</div> 
</asp:Content>


