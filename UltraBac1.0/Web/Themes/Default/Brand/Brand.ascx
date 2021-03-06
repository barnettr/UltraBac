<%@ control language="C#" autoeventwireup="true" CodeFile="Brand.ascx.cs" inherits="Controls_Brand" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>

 <div class="Brand">     
     <div class="Title"><uc1:CustomMessage id="CustomMessage1" MessageKey="ShopByBrandTitle" runat="server"></uc1:CustomMessage> : <asp:Label ID="lblBrandName" runat="server"></asp:Label></div>
     
     <asp:DataList ID="DataListProducts" runat="server"  RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="BrandItem">
                <div class="Image">
                    <a id="A1" href='<%# DataBinder.Eval(Container.DataItem, "ViewProductLink").ToString()%>' runat="server">
                        <img id="Img1" border='0' src='<%# DataBinder.Eval(Container.DataItem, "SmallImageFilePath")%>' runat="server" />
                    </a>
                </div>
                <div class="DetailLink">
                    <asp:HyperLink ID="hlName" Runat="server" CssClass='DetailLink' Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString()%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ViewProductLink").ToString()%>'></asp:HyperLink>
                </div>
                <div><asp:Label ID="uxCallForPricing" runat="server" Text='<%# CheckForCallForPricing(DataBinder.Eval(Container.DataItem, "CallForPricing")) %>' CssClass="Price"  /></div>
                <div><asp:Label ID="Price" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RetailPrice", "{0:c}") %>' CssClass='Price' Visible='<%# !ShowSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) && !(bool)DataBinder.Eval(Container.DataItem, "CallForPricing")%>'></asp:Label></div>
                <div><asp:Label ID="RegularPrice" runat="server" Text='<%# GetRegularPrice(DataBinder.Eval(Container.DataItem, "RetailPrice")) %>' CssClass='RegularPrice' Visible='<%# ShowSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) && !(bool)DataBinder.Eval(Container.DataItem, "CallForPricing")%>'></asp:Label>
                   <asp:Label ID="SalePrice" runat="server" Text='<%# GetSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) %>' CssClass='SalePrice' Visible='<%# ShowSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) && !(bool)DataBinder.Eval(Container.DataItem, "CallForPricing") %>'></asp:Label></div>
             </div>                    
        </ItemTemplate>                  
    </asp:DataList>
    
    <div><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
 </div>
