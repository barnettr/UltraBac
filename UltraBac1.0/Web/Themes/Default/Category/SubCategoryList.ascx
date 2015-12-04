<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubCategoryList.ascx.cs" Inherits="Controls_ShoppingCartCategory_SubCategoryList" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>
 
 <asp:Panel ID="pnlSubCategoryList" runat="server" Visible="true">

 <div class="SubCategoryList">
     <div class="Title"><uc1:CustomMessage id ="FeaturedCategoryListTitle" MessageKey="FeaturedCategoryListTitle" runat="server"></uc1:CustomMessage></div> 

     <asp:DataList ID="DataListSubCategories" runat="server" RepeatDirection="Vertical" >
        <ItemTemplate>
            <div class="SubCategoryListItem">                  
                <div class="CategoryLink">
                   <a id="A1" href='<%# DataBinder.Eval(Container.DataItem, "ViewCategoryLink").ToString()%>' runat="server">
                   <img id="Img2" alt=" " runat="server" style="border:none"  src='<%# ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.SmallImagePath + DataBinder.Eval(Container.DataItem, "ImageFile").ToString()%>'/>               
                   </a>
                </div>                
                <div class="CategoryLink">
                    <img id="Img1" alt="" runat="server" src="../images/Right_arrow.gif" /><a id="A3" runat="server" href='<%# DataBinder.Eval(Container.DataItem, "ViewCategoryLink").ToString()%>' >
                     <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>' ></asp:Label>
                    </a>                    
                </div>  
                <div class="ShortDescription">
                   <asp:Label ID="lblShortDecription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ShortDescription")%>'></asp:Label>                
               </div>                                                                    
            </div>                    
        </ItemTemplate>                  
    </asp:DataList>
    
    
    <asp:DataList ID="DataListParentCategory" runat="server" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="SubCategoryListItem">                  
                <div class="CategoryLink">
                <a href= '<%# "~/category.aspx?cid=" + DataBinder.Eval(Container.DataItem, "CategoryId") %>' runat="server">
                    <img id="Img2" runat="server" src='<%# ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.SmallImagePath + DataBinder.Eval(Container.DataItem, "ImageFile").ToString()%>'/>                               
                </a>
                </div>                
                <div class="CategoryLink">
                     <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>' ></asp:Label>
                </div>  
                <div class="ShortDescription">
                   <asp:Label ID="lblShortDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ShortDescription")%>'></asp:Label>
               </div>                                                     
            </div>                    
        </ItemTemplate>                  
    </asp:DataList>
 </div>
</asp:Panel> 
  