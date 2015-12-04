<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuickSearch.ascx.cs" Inherits="ContentBlocks_ECommerce_QuickSearch" %>
<div class="ProductQuickSearch">
    <div id="QuickSearch">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td><span class="Title"><asp:Label ID="lblTitle" runat="server"></asp:Label></span></td>
                <td><asp:TextBox ID="txtKeyword" runat="server" MaxLength="15" Rows="5" CssClass="TextBox"></asp:TextBox></td>
                <td><asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="Button" /></td>
            </tr>
        </table>
    </div>
</div>