<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Product.ascx.cs" Inherits="Public_Templates_Professional_product_Product" %>
<%@ Register Src="ProductPrice.ascx" TagName="ProductPrice" TagPrefix="ZNode" %>
<%@ Register Src="ProductTabs.ascx" TagName="ProductTabs" TagPrefix="ZNode" %>
<%@ Register Src="~/Themes/Default/Product/ProductRelated.ascx" TagName="RelatedProducts" TagPrefix="ZNode" %>
<script language="JavaScript1.2" type="text/javascript">
/***********************************************
* Image Thumbnail Viewer Script- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for legal use.
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/
</script>  
 <script type="text/javascript" language="javascript">
     //<![CDATA[
     //Tab Switcher
     document.observe("dom:loaded", function() {
         // without options
         //ts = new TabSwitcher("ul#tabs li a", "div.tab_content div[id^=tab_]");

         // with options
         ts = new TabSwitcher("ul.tabs li a", "div.tab_content div[id^=tab_]", {
             initialTabIndex: 0,
             tabOnClassName: 'on',
             tabOffClassName: 'off',
             bodyOnStyles: {
                 display: 'block'
             },
             bodyOffStyles: {
                 display: 'none'
             }
         }
	);
     });
     //]]>
     
</script>
<div class="product-detail">
    <h1><asp:Label ID="uxProductTitle" runat="server"></asp:Label></h1>
    <asp:Image ID="uxCatalogItemImage" runat="server" CssClass="left" />
    <asp:Label ID="uxProductDescription" runat="server"></asp:Label>
    <div class="clear"></div>

    <ZNode:CustomMessage ID="uxSystemRequirements" runat="server" MessageKey="SystemRequirements" />
    
    <div class="hr"></div>
    <div>
       <znode:RelatedProducts runat="server" id="uxRelated"/>
    </div>
    <div>
        <a runat="server" id="uxDownloadDemo" href="~/content.aspx?page=download-trial&pid=" class="btn_demo"><img runat="server"  src="~/_img/buttons/download_demo.png" alt="download demo" /></a>
        <a runat="server" id="uxRequestDemo" href="~/content.aspx?page=demo-request&pid=" class="btn_demo"><img runat="server" src="~/_img/buttons/request_demo.png" alt="request demo" /></a>
        <a runat="server" id="uxDownloadUpgrade" href="~/content.aspx?page=download-upgrade&pid=" class="btn_upgrade"><img runat="server" src="~/_img/buttons/download_upgrade.png" alt="download upgrade" /></a>
    </div>
        <h2>Purchase</h2>
            <div class="formBox">
                <div class="lt formCorner"></div>
                <div class="rt formCorner"></div>
                <div class="formBox-content">
                    <asp:Panel ID="uxProductAvailable" runat="server" DefaultButton="uxAddToCart">
                        <div id="product-purchase">
                            <div class="floatleft">
                                <asp:TextBox CssClass="product-quantity" MaxLength="2" ID="uxQuantity" runat="server"></asp:TextBox> @ 
                                <ZNode:ProductPrice ID="uxProductPrice" runat="server" /> ea.
                            </div>
                            <asp:ImageButton CssClass="floatright" ImageUrl="~/_img/buttons/add_to_cart.png" ID="uxAddToCart" runat="server" OnClick="uxAddToCart_Click" ValidationGroup="quantity" /><br />
                            <asp:RequiredFieldValidator runat="server" ForeColor="" ErrorMessage="Invalid Quantity" ControlToValidate="uxQuantity" Display="Dynamic" ValidationGroup="quantity" />
                            <asp:RegularExpressionValidator runat="server" ForeColor="" ErrorMessage="Invalid Quantity" ControlToValidate="uxQuantity" Display="Dynamic" ValidationGroup="quantity" ValidationExpression="^0*[1-9][0-9]*$" />
                            </div>
                        <p id="purchaseOverX"><Znode:CustomMessage ID="uxOrdersOverX" runat="server" MessageKey="OrdersOverX" /></p>
                    </asp:Panel>
                    <asp:Panel ID="uxCallForPrice" runat="server" Visible="false">
                     <div id="product-call">
						<ZNode:CustomMessage runat="server" MessageKey="CallForPricing" />
						</div>
                    </asp:Panel>
                    <asp:Panel ID="uxProductUnavailable" runat="server">
                        <Znode:CustomMessage ID="uxNotAvailable" runat="server" MessageKey="UnavailableSelectionMessage" />
                    </asp:Panel>
                </div>
                <div class="lb formCorner"></div>
                <div class="rb formCorner"></div>
            </div>
            <div class="clear"></div>
            <ul class="tabs">
	            <li>
	                <div class="tab-right">
	                    <div class="tab-left">
	                        <a href="#tab_purchase">Purchase Info</a>
	                    </div>

	                </div>
	            </li>
	            <li>
	                <div class="tab-right">
                        <div class="tab-left">
                            <a href="#tab_licensing">Licensing</a>
                        </div>
                    </div>

                </li>
	            <li>			    
	                <div class="tab-right">
                        <div class="tab-left">
                            <a href="#tab_upgrades">Upgrades</a>
                        </div>
                    </div>
                </li>
                <li>			    
	                <div class="tab-right">
                        <div class="tab-left">
                            <a href="#tab_maintenance">Maintenance</a>
                        </div>
                    </div>
                </li>
            </ul>

            <div class="clear"></div>
            <div class="tab_content">
	            <div id="tab_purchase" class="tab-items">
		            <div id="purchase-inner" class="inner">
			            <div class="lt whiteCorner"></div>
			            <div class="rt whiteCorner"></div>
			            <div class="tabBody">
				            <asp:Literal runat="server" ID="uxPurchaseInfo" />
			            </div>

			            <div class="lb whiteCorner"></div>
			            <div class="rb whiteCorner"></div>
		            </div>
		            <div class="leftBottom redCorner"></div>
		            <div class="rightBottom redCorner"></div>      
                </div>
                <div id="tab_licensing" class="tab-items">
		            <div class="inner">
			            <div class="lt whiteCorner"></div>

			            <div class="rt whiteCorner"></div>
			            <div class="tabBody">
				            <asp:Literal runat="server" ID="uxLicenseInfo" />
			            </div>
			            <div class="lb whiteCorner"></div>
			            <div class="rb whiteCorner"></div>   
		            </div>
		            <div class="leftBottom redCorner"></div>
		            <div class="rightBottom redCorner"></div>        
                </div>

                <div id="tab_upgrades" class="tab-items">
		            <div class="inner">
			            <div class="lt whiteCorner"></div>
			            <div class="rt whiteCorner"></div>
			            <div class="tabBody">
				            <asp:Literal runat="server" ID="uxUpgradeInfo" />
			            </div>
			            <div class="lb whiteCorner"></div>
			            <div class="rb whiteCorner"></div>
		            </div>
		            <div class="leftBottom redCorner"></div>
		            <div class="rightBottom redCorner"></div>

                </div>
                <div id="tab_maintenance" class="tab-items">
		            <div class="inner">
			            <div class="lt whiteCorner"></div>
			            <div class="rt whiteCorner"></div>
			            <div class="tabBody">
				           <asp:Literal runat="server" ID="uxMaintenanceInfo" />
			            </div>
			            <div class="lb whiteCorner"></div>
			            <div class="rb whiteCorner"></div>
		            </div>
		            <div class="leftBottom redCorner"></div>
		            <div class="rightBottom redCorner"></div>

                </div>
	            <div class="clear"></div>
            </div>

</div>