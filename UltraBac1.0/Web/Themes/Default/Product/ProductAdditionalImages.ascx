<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAdditionalImages.ascx.cs" Inherits="Themes_Default_Product_ProductAdditionalImages" %>

<script language="JavaScript1.2" type="text/javascript">
/***********************************************
* Image Thumbnail Viewer Script- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for legal use.
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/
</script> 

<div class="ProductAdditionalImages">
    <asp:DataList ID="DataListAdditionalImages" runat="server" RepeatDirection="horizontal">                                                                        
        <ItemTemplate> 
            <div>           
                <div> 
                  <a href='<%# ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.LargeImagePath + DataBinder.Eval(Container.DataItem, "ImageFile").ToString() %>' runat="server" rel="thumbnail">
                     <img class="Image" src='<%# GetImagePath(ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.ThumbnailImagePath + DataBinder.Eval(Container.DataItem, "ImageFile").ToString()) %>' alt='<%# GetImageName(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>' title='<%# Eval("ProductImageID")%>' />                
                  </a>
                </div>             
                <div class="Name">                                                
                    <asp:Label ID="Name" Runat="server" Text='<%# GetImageName(DataBinder.Eval(Container.DataItem, "Name").ToString())%>' ></asp:Label>                               
                </div>   
            </div>                   
        </ItemTemplate>                                                                         
        <ItemStyle CssClass="ItemStyle" />
    </asp:DataList>               
</div>