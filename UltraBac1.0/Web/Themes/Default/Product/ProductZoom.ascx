<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductZoom.ascx.cs" Inherits="Themes_Default_Product_ProductZoom" %>

<h1><div align="center">&nbsp;<asp:Label ID="ProductTitle" runat="server"></asp:Label>&nbsp;</div></h1>
<asp:Panel ID="pnlPrevNext" runat="server" align="center">
    <asp:LinkButton ID="Previous" runat="server" OnClick="Previous_Click" Font-Overline="false" width="76">&laquo; Previous</asp:LinkButton>&nbsp;&nbsp;  
    <asp:LinkButton ID="Forward" runat="server" OnClick="Forward_Click" Font-Overline="false" width="91">Next &raquo;</asp:LinkButton> 
</asp:Panel>    
 
<asp:GridView ID="GridImage" AllowPaging="true" PageSize="1" runat="server" AutoGenerateColumns="False" BorderStyle="None" CellPadding="0"
    GridLines="None" OnPageIndexChanging="GridImage_PageIndexChanging" align="center">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>  
                <a href="javascript:self.close()"><asp:Image ID="CatalogItemImage" ImageURL='<%# ReturnPath(Eval("ImageFile").ToString()) %>'  AlternateText='<%# Eval("Name")%>'  runat="server" /></a>              
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerSettings Visible="False" />
</asp:GridView>

<div align ="center">
<a href="javascript:self.close()">close window</a>
</div>
