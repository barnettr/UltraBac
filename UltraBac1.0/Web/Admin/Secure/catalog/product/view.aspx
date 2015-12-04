<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Admin_Secure_products_view" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">    
    <div><h1>Product Details - <%= lblProdName.Text.Trim() %></h1></div>
    <div><uc1:spacer id="Spacer8" SpacerHeight="15" SpacerWidth="3" runat="server"></uc1:spacer></div>
    
    <asp:ScriptManager id="ScriptManager" runat="server"></asp:ScriptManager>
    <ajaxToolKit:TabContainer ID="tabProductDetails" runat="server">
        <ajaxToolKit:TabPanel ID="pnlGeneral" runat="server">        
        <HeaderTemplate>Product Information</HeaderTemplate>
        <ContentTemplate>
            <div><uc1:spacer id="Spacer7" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer></div>
            <div align="right"><asp:Button ID="EditProduct" runat="server" CssClass="Button" OnClick="EditProduct_Click" Text="Edit Information" /></div>
	        <h4>General Information</h4>	
	        <table cellspacing="0" cellpadding="0" class="ViewForm" width="100%">
	            <tr class="RowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
		                Product Name
	                </td>
	                <td class="ValueStyle" width="100%">
	                    <asp:Label ID="lblProdName" runat="server"></asp:Label>
	                </td>
	            </tr>
	            <tr class="AlternatingRowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
		                Product Code
	                </td>
	                <td class="ValueStyle">
	                    <asp:Label ID="lblProdNum" runat="server"></asp:Label>
	                </td>
	            </tr>
	            <tr class="RowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
		                SKU or Part#
	                </td>
	                <td class="ValueStyle">
	                    <asp:Label ID="lblProductSKU" runat="server"></asp:Label>
	                </td>
	            </tr>
	            <tr class="AlternatingRowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
		                Quantity on Hand
	                </td>
	                <td class="ValueStyle">
	                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
	                </td>
	            </tr>
	            <tr class="RowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
	                    Product Type
	                </td>
	                <td valign="top" class="ValueStyle">
	                    <asp:Label ID="lblProdType" runat="server"></asp:Label>
                    </td>
	            </tr>
	            <tr class="AlternatingRowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
	                    Manufacturer Name
	                </td>
	                <td valign="top" class="ValueStyle">
	                    <asp:Label ID="lblManufacturerName" runat="server"></asp:Label>
                    </td>
	            </tr>
	        </table>

	        <h4>Product Image</h4>
	        <div class="Image"><asp:Image ID="ItemImage"  runat="server" /></div> 

	        <h4>Product Description</span></h4>
        	
	        <div class="Description">
	             <asp:Label ID="lblProductDescription" runat="server"></asp:Label>
	        </div>	        

	        <h4>Product Properties</h4>
        	
	        <table border="0" cellpadding="0" cellspacing="0" class="ViewForm">
	            <tr class="RowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
	                    Retail Price
	                </td>
	                <td valign="top" class="ValueStyle" width="100%">
	                    <asp:Label ID="lblRetailPrice" runat="server"></asp:Label>
	                </td>
	           </tr>
	           <tr class="AlternatingRowStyle">
	                <td class="FieldStyle" nowrap="nowrap">
	                    Sale Price
	                </td>
	                <td valign="top" class="ValueStyle">
	                    <asp:Label ID="lblSalePrice" runat="server"></asp:Label>
	                </td>
	           </tr>
	           <tr class="RowStyle">
	               <td class="FieldStyle" nowrap="nowrap">
		                WholeSale Price
	               </td>
	               <td valign="top" class="ValueStyle">
	                    <asp:Label ID="lblWholeSalePrice" runat="server" CssClass="Price"></asp:Label>
	               </td>
	           </tr>	           
               <tr class="AlternatingRowStyle">
                    <td class="FieldStyle" valign="top" nowrap="nowrap">
	                    Product Categories
                    </td>
                    <td>
                        <asp:Label ID="lblProductCategories" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
	        </table>
	        
	        <div><uc1:spacer id="Spacer2" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
	        
	    </ContentTemplate>
    </ajaxToolKit:TabPanel>
    
    <ajaxToolKit:TabPanel ID="pnlAdvancedSettings" runat="server">        
        <HeaderTemplate>Advanced Settings</HeaderTemplate>
        <ContentTemplate>
            <div><uc1:spacer id="Spacer9" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer></div>
            <div align="right"><asp:Button ID="Button2" runat="server" CssClass="Button" OnClick="EditAdvancedSettings_Click" Text="Edit Advanced Settings" /></div>
            <h4>Display Settings</h4>
	        <table border="0" cellpadding="0" cellspacing="0" class="ViewForm">
	            <%--<tr class="AlternatingRowStyle">
	                <td class="FieldStyle" valign="top" nowrap="nowrap">
		                Product Categories
	                </td>
	                <td>
                        <asp:Label ID="lblProductCategories" runat="server" Text="Label"></asp:Label>
                    </td>
	           </tr>--%>
	           <tr class="RowStyle">
	               <td class="FieldStyle" nowrap="nowrap">
    	                Enabled?
	               </td>
	               <td valign="top" class="ValueStyle" width="100%">
	                    <img id="chkProductEnabled" runat="server" alt="" src=""/>
	               </td>
	          </tr>
	          <tr class="AlternatingRowStyle">
	              <td class="FieldStyle" nowrap="nowrap">
		              Display Order
	              </td>
	              <td valign="top" class="ValueStyle">
	                  <asp:Label ID="lblProdDisplayOrder" runat="server"></asp:Label>
	              </td>
	         </tr>
	         <tr class="RowStyle">
	             <td class="FieldStyle" nowrap="nowrap">
	                 Home Page Special
                 </td>
                 <td valign="top" class="ValueStyle">
                    <img id="chkIsSpecialProduct" runat="server" alt="" src=""/>
                 </td>
	        </tr>
	        <tr class="AlternatingRowStyle">
                <td class="FieldStyle" nowrap="nowrap">
	                Call For Pricing
                </td>
                <td valign="top" class="ValueStyle">
                    <img id="chkProductPricing" runat="server" alt="" src=""/>
                </td>
            </tr>
	        <tr class="RowStyle">
                <td class="FieldStyle" nowrap="nowrap">
	                Display Inventory
                </td>
    	        <td valign="top" class="ValueStyle">
	                <img id="chkproductInventory" runat="server" alt="" src="" />
	            </td>
	        </tr>
	        </table>
	        
	        
	        <h4>Inventory Settings</h4>
            <table cellspacing="0" cellpadding="0" class="ViewForm" width="100%">
                    <tr class="RowStyle">
                        <td class="FieldStyle" nowrap="nowrap"><img id="chkCartInventoryEnabled" runat="server" alt="" src=''/></td>
                        <td class="ValueStyle" width="100%">
                           Only Sell if Inventory Available (User can only add to cart if inventory is above 0)
                        </td>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td class="FieldStyle" nowrap="nowrap"><img id="chkIsBackOrderEnabled" runat="server" alt="" src=''/></td>
                        <td class="ValueStyle">Allow Back Order (items can always be added to the cart. Inventory is reduced)</td>
                    </tr>
                    <tr class="RowStyle">
                        <td class="FieldStyle" nowrap="nowrap"><img id="chkIstrackInvEnabled" runat="server" alt="" src="" /></td>
                        <td class="ValueStyle">Don't Track Inventory (items can always be added to the cart and inventory is not reduced)</td>
                    </tr>
            </table>
            <table cellspacing="0" cellpadding="0" class="ViewForm" width="100%">         
                    <tr class="AlternatingRowStyle">
                        <td class="FieldStyle" nowrap="nowrap">In Stock Message</td> 
                        <td class="ValueStyle" width="100%"><asp:Label ID="lblInStockMsg" runat="server" ></asp:Label></td>	                
                    </tr> 
                    <tr class="RowStyle">
                        <td class="FieldStyle" nowrap="nowrap">Out Of Stock Message</td>
                        <td class="ValueStyle"><asp:Label ID="lblOutofStock" runat="server" ></asp:Label></td>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td class="FieldStyle" nowrap="nowrap">Back Order Message</td> 
                        <td class="ValueStyle"><asp:Label ID="lblBackOrderMsg" runat="server" ></asp:Label></td>	                
                    </tr>
                    <tr class="RowStyle">
                        <td class="FieldStyle" nowrap="nowrap">Drop Ship</td>
                        <td class="ValueStyle"><img id="IsDropShipEnabled" runat="server" alt="" src=''/></td>
                    </tr>
            </table>
            
            <h4>Shipping Settings</h4>
            
            <table border="0" cellpadding="0" cellspacing="0" class="ViewForm">
                <tr class="RowStyle">
	                   <td class="FieldStyle" nowrap="nowrap">
	                        Shipping Rule Type Name
	                   </td>
	                   <td valign="top" class="ValueStyle">
	                       <asp:Label ID="lblShippingRuleTypeName" runat="server"></asp:Label>
	                   </td>
                </tr> 
                <tr class="AlternatingRowStyle">
	               <td class="FieldStyle" nowrap="nowrap">
	                    Weight
	               </td>
	               <td valign="top" class="ValueStyle">
	                   <asp:Label ID="lblWeight" runat="server"></asp:Label>
	               </td>
                </tr>            
            </table>
            
        </ContentTemplate>
    </ajaxToolKit:TabPanel>
    <ajaxToolKit:TabPanel ID="pnlRelatedItems" runat="server">
        <HeaderTemplate>Related Items</HeaderTemplate>
        <ContentTemplate>
            <p></p>                
	        <h4>Related Items</h4>
        	
            <table border="0" cellpadding="0" cellspacing="0"width="100%">
                <tr>
                    <td style="height: 24px"><p>This is the list of related products currently associated with this product.</p></td>
	                <td align="right" valign="middle" style="height: 24px">
                    <asp:Button CssClass="Button" ID="AddRelatedItems" Text="Add Related items" runat="server" OnClick="AddRelatedItems_Click" /> 
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <uc1:spacer id="Spacer5" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
                    </td>
                </tr>
	            <tr>
	                <td colspan="2" valign="middle">
	                    <!-- Update Panel for grid paging that are used to avoid the postbacks -->
	                    <asp:UpdatePanel ID="updPnlRealtedGrid" runat="server" UpdateMode="Conditional">
	                        <ContentTemplate>	                    
                                <asp:GridView ID="uxGrid" ShowFooter="true"  ShowHeader="true" CaptionAlign="Left" runat="server" ForeColor="Black" CellPadding="4"  AutoGenerateColumns="False" CssClass="Grid" Width="100%" GridLines="None" OnRowCommand="uxGrid_RowCommand" AllowPaging="True" OnPageIndexChanging="uxGrid_PageIndexChanging" PageSize="5" >
                                    <Columns>
                                        <asp:BoundField DataField="productid" HeaderText="Product ID" />
                                        <asp:BoundField DataField="name" HeaderText="Product Name" />                      
                                        <asp:TemplateField>
                                        <ItemTemplate> <asp:Button Id="Delete" Text="Remove"  CommandArgument='<%# Eval("productid") %>' CommandName="RemoveItem" CssClass="Button"  runat="server" />
                                        </ItemTemplate>                  
                                        </asp:TemplateField>                        
                                        </Columns>
                                        <EmptyDataTemplate>
                                                        No related items found
                                        </EmptyDataTemplate>
                                        
                                       <RowStyle CssClass="RowStyle" />
                                       <HeaderStyle CssClass="HeaderStyle" />
                                       <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                                  <FooterStyle CssClass="FooterStyle" />
                                </asp:GridView>
                            </ContentTemplate>
	                    </asp:UpdatePanel> 
	                </td>
	            </tr>	    
	        </table>
        </ContentTemplate>
        </ajaxToolKit:TabPanel>
        
        <ajaxToolKit:TabPanel ID="pnlAlternateImages" runat="server">
            <HeaderTemplate>Alternate Images</HeaderTemplate>
            <ContentTemplate>
                <p></p>
	            <h4>Alternate Product Images</h4>
	             <table border="0" cellpadding="0" cellspacing="0"width="100%"> 
	             <tr>
                        <td style="height: 24px"><p>These are alternate images of the product that the customer can select on the product page from a thumbnail.</p></td>
	                    <td align="right" valign="middle" style="height: 24px">
                        <asp:Button CssClass="Button" ID="Button1" Text="Add Product Image" runat="server" OnClick="AddProductView_Click" /> 
                        </td>
                    </tr>      
                    <tr>
                        <td colspan="2">
                            <uc1:spacer id="Spacer1" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
                        </td>
                    </tr>	
	                <tr>
	                    <td colspan="2" valign="middle">
	                        <!-- Update Panel for grid paging that are used to avoid the postbacks -->
	                        <asp:UpdatePanel ID="updPnlGridThumb" runat="server" UpdateMode="Conditional">
	                            <ContentTemplate>
                                    <asp:GridView ID="GridThumb" ShowFooter="true"  ShowHeader="true" CaptionAlign="Left" runat="server" ForeColor="Black" CellPadding="4"  AutoGenerateColumns="False" CssClass="Grid" Width="100%" GridLines="None" OnRowCommand="GridThumb_RowCommand" AllowPaging="True" OnPageIndexChanging="GridThumb_PageIndexChanging"  OnRowDeleting="GridThumb_RowDeleting"  PageSize="5" >
                                      <Columns>                    
                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                             <img id="SwapImage" alt="" src='<%# ZNode.Libraries.Framework.Business.ZNodeConfigManager.EnvironmentConfig.ThumbnailImagePath + DataBinder.Eval(Container.DataItem, "ImageFile").ToString()%>' runat="server" />         
                                            </ItemTemplate>
                                        </asp:TemplateField>                      
                                        <asp:BoundField DataField="Name" HeaderText="Name" />                   
                                        <asp:TemplateField HeaderText="Is Active">
                                            <ItemTemplate>                        
                                                <img id="Img1" alt="" src='<%# ZNode.Libraries.Framework.Business.ZNodeHelper.GetCheckMark(bool.Parse(DataBinder.Eval(Container.DataItem, "ActiveInd").ToString()))%>' runat="server" />                    
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                    <%--                    <asp:TemplateField HeaderText="Thumbnail Width">
                                            <ItemTemplate>
                                                <%= ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemThumbnailWidth.ToString() %>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="No Of Thumbnails per column">
                                            <ItemTemplate>
                                                <%= ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.MaxCatalogItemThumbnailColumns.ToString()%>                                                        
                                            </ItemTemplate>
                                        </asp:TemplateField>                                         
                    --%>                    <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button CssClass="Button" ID="EditProductView" Text="Edit" CommandArgument='<%# Eval("productimageid") %>' CommandName="Edit" runat="Server" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button Id="Delete" Text="Delete"  CommandArgument='<%# Eval("productimageid") %>' CommandName="RemoveItem" CssClass="Button"  runat="server" />
                                            </ItemTemplate>                  
                                        </asp:TemplateField>                                                                
                                     </Columns>
                                        <EmptyDataTemplate>
                                            No alternate product image found
                                        </EmptyDataTemplate>
                                            
                                        <RowStyle CssClass="RowStyle" />
                                        <HeaderStyle CssClass="HeaderStyle" />
                                        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                                        <FooterStyle CssClass="FooterStyle" />
                                  </asp:GridView>
                              </ContentTemplate>
                          </asp:UpdatePanel> 
	                    </td>
	                </tr>
	             </table>
            
            </ContentTemplate>
        </ajaxToolKit:TabPanel>
        
        <ajaxToolKit:TabPanel ID="pnlProductOptions" runat="server">
            <HeaderTemplate>Product Add-Ons</HeaderTemplate>                  
            <ContentTemplate>             
                <p></p>
	            <h4>Add-Ons for this product</h4>
	            <table border="0" cellpadding="0" cellspacing="0"width="100%"> 
	                 <tr>
                        <td><p>These are add-ons of the product that the customer can select on the product page from a drop downlist.</p></td>
	                    <td align="right" valign="middle">
                        <div align="right"><asp:Button ID="btnAddNewAddOn" runat="server" CssClass="Button" Text="Add a Product Add-On" OnClick="btnAddNewAddOn_Click" /></div>
                        </td>
                    </tr>      
                    <tr>
                        <td colspan="2">
                            <uc1:spacer id="Spacer3" SpacerHeight="15" SpacerWidth="3" runat="server"></uc1:spacer>
                        </td>
                    </tr>
                </table>
                <!-- Update Panel for grid paging that are used to avoid the postbacks -->
                <asp:UpdatePanel ID="updPnlProductAddOnsGrid" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView OnRowDataBound="uxGridProductAddOns_RowDataBound" ID="uxGridProductAddOns" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="uxGridProductAddOns_PageIndexChanging" CaptionAlign="Left" OnRowCommand="uxGridProductAddOns_RowCommand" Width="100%" EnableSortingAndPagingCallbacks="False" PageSize="15" AllowSorting="True" EmptyDataText="No Add-Ons associated with this Product.">
                            <Columns>
                                <asp:BoundField DataField="ProductAddOnId" HeaderText="ID" />                                   
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate><%# GetAddOnName(Eval("AddonId")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate><%# GetAddOnTitle(Eval("AddonId")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button CommandName="Remove" CausesValidation="false" ID="btnDelete"  runat="server" Text="Remove" CssClass="Button" />
                                        </ItemTemplate>
                                </asp:TemplateField>
                            </Columns> 
                            <FooterStyle CssClass="FooterStyle"/>
                            <RowStyle CssClass="RowStyle"/>                    
                            <PagerStyle CssClass="PagerStyle" Font-Underline="True" />
                            <HeaderStyle CssClass="HeaderStyle"/>
                            <AlternatingRowStyle CssClass="AlternatingRowStyle"/>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
             
            </ContentTemplate>            
        </ajaxToolKit:TabPanel>       
        
        <ajaxToolKit:TabPanel ID="pnlManageinventory" runat="server">
            <HeaderTemplate>Manage SKUs</HeaderTemplate>        
            <ContentTemplate>            
                <div align="right">
                    <asp:Button CssClass="Button" ID="butAddNewSKU" Text="Add SKU or Part#" runat="server" OnClick="btnAddSKU_Click" />
                </div>
                <h4>Current Inventory</h4>
                <asp:UpdatePanel ID="updPnlInventoryDisplayGrid" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="uxGridInventoryDisplay" Width="100%" CssClass="Grid" CellPadding="4" CaptionAlign="Left" GridLines="None" runat="server" AutoGenerateColumns="False" AllowPaging="True" ForeColor="Black" OnPageIndexChanging="uxGridInventoryDisplay_PageIndexChanging" OnRowCommand="uxGridInventoryDisplay_RowCommand" OnRowDeleting="uxGridInventoryDisplay_RowDeleting" PageSize="25">
                           <FooterStyle CssClass="FooterStyle" />
                           <Columns>
                               <asp:BoundField DataField="sku" HeaderText="SKU or Part#" />
                               <asp:BoundField DataField="skuid" HeaderText="ID" />
                               <asp:BoundField DataField="quantityonhand" HeaderText="QuantityOnHand" />
                               <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="Test" runat="server" >
                                                <asp:Button CssClass="Button" ID="EditSKU" Text="Edit" CommandArgument='<%# Eval("skuid") %>' CommandName="Edit" runat="Server" />
                                            </div>
                                        </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField>
                                        <ItemTemplate>
                                                <asp:Button ID="RemoveSKU"  CssClass="Button" Text="Remove" CommandArgument='<%# Eval("skuid") %>' CommandName="Delete" runat="Server" />
                                        </ItemTemplate>
                               </asp:TemplateField>
                           </Columns>
                           <RowStyle CssClass="RowStyle" />
                           <EditRowStyle CssClass="EditRowStyle" />
                           <PagerStyle CssClass="PagerStyle" />
                           <HeaderStyle CssClass="HeaderStyle" />
                           <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolKit:TabPanel>
       
        <ajaxToolKit:TabPanel ID="tabpnlAdditionalInfo" runat="server">
            <HeaderTemplate>Additional Info</HeaderTemplate>      
            <ContentTemplate>
                <div><uc1:spacer id="Spacer6" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer></div>
                <div align="right"><asp:Button ID="btnEditAddtionalInfo" runat="server" CssClass="Button" OnClick="EditAdditionalInfo_Click" Text="Edit Additional Info" /></div>
                <h4>Purchase Information</h4>
	            <div class="Features">
                     <asp:Label ID="lblpurchaseinfo" runat="server"></asp:Label>
                </div>
                
                <h4>Licensing Information</h4>
                <div class="Features">
                     <asp:Label ID="lbllicenseinfo" runat="server"></asp:Label>
                </div>
                
                <h4>Upgrade Information</h4>
                <div class="Features">
                     <asp:Label ID="lblupgradeinfo" runat="server"></asp:Label>
                </div> 
                
                <h4>Maintenance Information</h4>
                <div class="Features">
                     <asp:Label ID="lblmaintenanceinfo" runat="server"></asp:Label>
                </div> 
            </ContentTemplate>
        </ajaxToolKit:TabPanel>
        
        <ajaxToolKit:TabPanel ID="tabpnlSEO" runat="server">
            <HeaderTemplate>SEO</HeaderTemplate>        
            <ContentTemplate>                
                <h4>SEO Settings</h4>
                <div align="right"><asp:Button ID="btnEditSEO" runat="server" CssClass="Button" OnClick="EditSEOSettings_Click" Text="Edit SEO" /></div>
                <uc1:spacer id="Spacer4" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
	            <table border="0" cellpadding="0" cellspacing="0" class="ViewForm">
	                <tr class="RowStyle">
	                    <td class="FieldStyle" nowrap="nowrap">
	                    Search Engine Title
	                    </td>
	                    <td valign="top" class="ValueStyle" width="100%">
	                    <asp:Label ID="lblSEOTitle" runat="server"></asp:Label>
	                    </td>
	                </tr>
	                <tr class="AlternatingRowStyle">
	                    <td class="FieldStyle" nowrap="nowrap">
		                    Search Engine Keywords
	                    </td>
	                    <td valign="top" class="ValueStyle">
	                    <asp:Label ID="lblSEOKeywords" runat="server" CssClass="Price"></asp:Label>
	                    </td>
	                </tr>
	                <tr class="RowStyle">
                        <td class="FieldStyle" nowrap="nowrap">
                            Search Engine Description
                        </td>
                        <td valign="top" class="ValueStyle">
                        <asp:Label ID="lblSEODescription" runat="server"></asp:Label>
	                    </td>
	                </tr>
	            </table>            
            </ContentTemplate>
        </ajaxToolKit:TabPanel>
        
    </ajaxToolKit:TabContainer>
    
</asp:Content>


