<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master"  AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Admin_Secure_catalog_coupons_list" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Coupons</h1></td>
			<td align="right" style="width: 371px"><asp:button CssClass="Button" id="btnAddCoupon" CausesValidation="False" Text="Add Coupon"
					Runat="server" onclick="btnAddCoupon_Click"></asp:button></td>
		</tr>
	</table>
	<p>Use this page to create & manage promotional coupons for your storefront </p>
	   <asp:GridView ID="uxGrid" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGrid_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGrid_RowCommand" Width="100%" AllowSorting="True" EmptyDataText="No Coupon available to display.">
        <Columns>
            <asp:BoundField DataField="CouponID" HeaderText="ID" />
            
            <asp:TemplateField HeaderText="CouponCode">
                <ItemTemplate>
                    <a href='add.aspx?ItemID=<%# DataBinder.Eval(Container.DataItem, "CouponID").ToString()%>'><%# DataBinder.Eval(Container.DataItem, "CouponCode").ToString()%></a>
                </ItemTemplate> 
                </asp:TemplateField>                 
                <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start date" HtmlEncode="False"/>
            <asp:BoundField DataField="ExpDate" DataFormatString="{0:d}" HeaderText="Expiry Date" HtmlEncode="False"/>
            <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Button">
                <ControlStyle CssClass="Button" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button">
                <ControlStyle CssClass="Button" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle CssClass="FooterStyle"/>
        <RowStyle CssClass="RowStyle"/>                    
        <PagerStyle CssClass="PagerStyle" Font-Underline="True" />
        <HeaderStyle CssClass="HeaderStyle"/>
        <AlternatingRowStyle CssClass="AlternatingRowStyle"/>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
    </asp:GridView>
    	<div><uc1:spacer id="Spacer2" SpacerHeight="10" SpacerWidth="10" runat="server"></uc1:spacer></div>
   	</asp:Content>