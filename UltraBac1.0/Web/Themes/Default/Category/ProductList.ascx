<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductList.ascx.cs" Inherits="Controls_ProductList" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>

 <asp:Panel ID="pnlProductList" runat="server" Visible="false">
 <div class="ProductList">     
     <!--<h4><asp:Label ID="ProductListTitle" runat="server" Visible="true"></asp:Label></h4>-->
     <h4><uc1:CustomMessage id ="ProductCatergoryTitle" MessageKey="CategoryProductListTitle" runat="server"></uc1:CustomMessage></h4>
     <asp:Label ID="ErrorMsg" runat="server" Visible="true" CssClass="Error"></asp:Label>

       <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="middle">
                <div class="Sorting">
                    <span class="Label">Sort</span><asp:DropDownList ID="lstFilter" runat="server" OnSelectedIndexChanged="lstFilter_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="0">Popular Items</asp:ListItem>
                    <asp:ListItem Value="1">Price Low to High</asp:ListItem>
                    <asp:ListItem Value="2">Price High to Low</asp:ListItem>
                
                    </asp:DropDownList>
               </div>
            </td>
            <td>
                <div id="Div1" runat="server" class="Paging">
                     <asp:LinkButton ID="TopPrevLink"  Text="&laquo; Prev" runat="server" OnClick="PrevRecord"></asp:LinkButton>
                      | Page <%= ncurrentpage.ToString() %> of <%= nRecCount.ToString() %>
                        ( Total <%=TotalRecords.ToString() %> Items ) |                   
                     <asp:LinkButton ID="TopNextLink" Text="Next &raquo;" OnClick="NextRecord" runat="server"></asp:LinkButton>                    
               </div>         
            </td>
        </tr>
       </table>
       
     <asp:DataList ID="DataListProducts" runat="server"  RepeatDirection="Horizontal" >
        <ItemTemplate>
            <div class="ProductListItem">
                <div class="Image">
                    <a href='<%# DataBinder.Eval(Container.DataItem, "ViewProductLink").ToString()%>' runat="server">
                        <img id="Img1" border='0' src='<%# DataBinder.Eval(Container.DataItem, "ImageSmallFilePath")%>' runat="server" alt=""/>
                    </a>
                </div>
                <span class="DetailLink">
                    <asp:HyperLink ID="hlName" Runat="server" CssClass='DetailLink' Text='<%# DataBinder.Eval(Container.DataItem, "Name").ToString()%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ViewProductLink").ToString()%>'></asp:HyperLink>
                </span>                 
                <span><asp:Label ID="uxCallForPricing" runat="server" Text='<%# CheckForCallForPricing(DataBinder.Eval(Container.DataItem, "CallForPricing")) %>' CssClass="Price"  /></span>
                <span><asp:Label ID="Price" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RetailPrice", "{0:c}") %>' CssClass='Price' Visible='<%# !ShowSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) && !(bool)DataBinder.Eval(Container.DataItem, "CallForPricing")%>'></asp:Label></span>
                <span><asp:Label ID="RegularPrice" runat="server" Text='<%# GetRegularPrice(DataBinder.Eval(Container.DataItem, "RetailPrice")) %>' CssClass='RegularPrice' Visible='<%# ShowSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) && !(bool)DataBinder.Eval(Container.DataItem, "CallForPricing")%>'></asp:Label>
                    <asp:Label ID="SalePrice" runat="server" Text='<%# GetSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) %>' CssClass='SalePrice' Visible='<%# ShowSalePrice(DataBinder.Eval(Container.DataItem, "SalePrice")) && !(bool)DataBinder.Eval(Container.DataItem, "CallForPricing") %>'></asp:Label></span> 
                
                <div><asp:ImageButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID")%>' ID="btnbuy" runat="server" ImageUrl='<%# BuyImage %>' OnClick="buy_Click" Visible='<%# Check(Eval("CallForPricing")) %>'/></div>
                <div class="Error"> 
                    <asp:Label ID="status" EnableViewState="true" runat="server"></asp:Label>                  
                </div> 
            </div>                    
        </ItemTemplate>
        <FooterTemplate>                
        </FooterTemplate>                
    </asp:DataList>  
  </div>
  <center>   
      <div runat="server" class="NavigationStyle">  
          <asp:LinkButton ID="BotPrevLink" runat="server" OnClick="PrevRecord">&laquo; Prev</asp:LinkButton>
           | Page <%= ncurrentpage.ToString() %> of <%= nRecCount.ToString() %>
           ( Total <%=TotalRecords.ToString() %> Items ) |     
          <asp:LinkButton ID="BotNextLink" OnClick="NextRecord" runat="server">Next &raquo;</asp:LinkButton>     
      </div>
  </center>
 </asp:Panel>

 
 
                                           
 
