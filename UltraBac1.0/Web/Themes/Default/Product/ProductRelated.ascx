<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRelated.ascx.cs" Inherits="Controls_ShoppingCartProduct_ProductRelated" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>
<asp:Panel ID="pnlRelated" runat="server" Visible="true">
<span class="Label"><uc1:CustomMessage ID ="RelatedProductTitle" MessageKey="RelatedProductsTitle" runat="server"></uc1:CustomMessage></span>
<asp:DataList ID="DataListRelated" runat="server"  RepeatDirection="Horizontal" BackColor="White" BorderStyle="None" CellPadding="10" ForeColor="Black" RepeatColumns="4" >
    <ItemTemplate>
        <div align="center"> <%--ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.ThumbnailImagePath--%>
            <a id="A1" href='<%# "~/product.aspx?pid=" + DataBinder.Eval(Container.DataItem, "ProductId").ToString()%>' runat="server"><img runat="server" alt="" src='<%# "http://staging.pop.us/ultrabac/Data/Default/Images/Catalog/Thumbnail/"  + DataBinder.Eval(Container.DataItem, "ImageFile").ToString()%>' border="0" /></a><br />
            <a href='<%# "~/product.aspx?pid=" + DataBinder.Eval(Container.DataItem, "ProductId").ToString()%>' runat="server" style="color:#333399;"><asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString()%>'></asp:Label></a>
        </div> 
                        
    </ItemTemplate>                                     
</asp:DataList>                
</asp:Panel>
<div class="hr"></div>  
