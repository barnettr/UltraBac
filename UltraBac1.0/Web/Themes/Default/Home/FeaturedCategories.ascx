<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeaturedCategories.ascx.cs" Inherits="Themes_Default_Home_FeaturedCategories" %>
<%@ Register Src="../CustomMessage/CustomMessage.ascx" TagName="CustomMessage" TagPrefix="uc1" %>

<div class="HomeFeaturedCategories">
    <div class="Title"><uc1:CustomMessage id="CustomMessage1" MessageKey="FeaturedCategoryListTitle" runat="server"></uc1:CustomMessage></div>
    <asp:DataList ID="uxdatalist" runat="server"  RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="SubCategoryListItem">                  
                <div class='CategoryLink'>
                <a id="A1" href= '<%# "~/category.aspx?cid=" + DataBinder.Eval(Container.DataItem, "CategoryId") %>' runat="server">
                    <img id="Img2" alt=" " runat="server" style="border:none"  src='<%# ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.SmallImagePath + DataBinder.Eval(Container.DataItem, "ImageFile").ToString()%>'/>                               
                </a>
                </div>                 
                <div class="CategoryLink">
                     <img id="Img1" alt="" runat="server" src='../images/Right_arrow.gif' /><a id="A2" href= '<%# "~/category.aspx?cid=" + DataBinder.Eval(Container.DataItem, "CategoryId") %>' runat="server">
                     <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>' ></asp:Label>
                    </a> 
                </div>                                                                    
            </div>                    
        </ItemTemplate>                  
    </asp:DataList>
</div>