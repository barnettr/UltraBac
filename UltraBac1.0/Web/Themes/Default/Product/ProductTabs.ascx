<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductTabs.ascx.cs" Inherits="Controls_ProductTabs" %>
<%@ Register Src="ProductRelated.ascx" TagName="ProductRelated" TagPrefix="uc8" %>
<%@ Register Src="ProductAdditionalImages.ascx" TagName="ProductAdditionalImages" TagPrefix="uc9" %>
<div id="Tab">
    <asp:ScriptManager id="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePnlProductDetails" runat="server" UpdateMode="Conditional">
            <ContentTemplate>     
                <ajaxToolKit:TabContainer runat="server" id="ProductTabs" CssClass="CustomTabStyle">
                       
                <ajaxToolKit:TabPanel ID="pnlFeatures" runat="server" HeaderText="Features">                                                  
                <ContentTemplate> 
                    <table> 
                        <tr>                           
                            <td>                 
                                <div class="Features">                     
                                    <asp:Label ID="ProductFeatureDesc" runat="server"></asp:Label>                                                   
                                </div>                              
                            </td>
                        </tr>   
                    </table> 
                </ContentTemplate>             
                </ajaxToolKit:TabPanel>

                <ajaxToolKit:TabPanel ID="pnlSpecifications" runat="server" HeaderText="Specifications">               
                <ContentTemplate>              
                    <table>
                        <tr>
                            <td>
                                <div class="Specifications">                     
                                    <asp:Label ID="ProductSpecification" runat="server"></asp:Label>                       
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                </ajaxToolKit:TabPanel>

                <%-- <ajaxToolKit:TabPanel ID="pnlAdditionalImages" runat="server" HeaderText="Photos" >                 
                <ContentTemplate>
                    <table id="AlternateImages">
                        <tr>
                            <td>                                           
                                 <uc9:ProductAdditionalImages ID="ProductAdditionalImages1" IncludeProductImage="true" runat="server" Visible="true" />
                           </td>
                        </tr>
                    </table>
                </ContentTemplate>
                </ajaxToolKit:TabPanel>--%>

                <ajaxToolKit:TabPanel ID="pnlRelatedProducts" runat="server" HeaderText="Related Items">               
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <div class="Related">
                                    <uc8:ProductRelated ID="uxProductRelated" runat="server" CssClass="CrossSell" Visible="true" />
                                </div> 
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                </ajaxToolKit:TabPanel>

                <ajaxToolKit:TabPanel ID="pnlAdditionalInformation" runat="server" HeaderText="Shipping Information">              
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <div class="AdditionalInformation">                 
                                <asp:Label ID="ProductAdditionalInformation" runat="server"></asp:Label>                    
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                </ajaxToolKit:TabPanel>                                           
            </ajaxToolKit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
 