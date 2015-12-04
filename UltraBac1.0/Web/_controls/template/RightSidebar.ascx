<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightSidebar.ascx.cs" Inherits="_controls_template_RightSidebar" %>
<%@ Import Namespace="ZNode.Libraries.Framework.Business" %>
		<%@ Register src="../recentNews.ascx" tagname="recentNews" tagprefix="uc1" %>


		<div id="Sidebar">
			<div class="item">
				<asp:Panel id="uxSearchPanel" runat="server" DefaultButton="uxSearch">
				<fieldset>
					<h3>Search:</h3>
					<div class="clear"></div>
					<asp:Label ID="label" runat="server" AssociatedControlID="uxQuery" CssClass="inside">- - Search the Site - -</asp:Label>
					<div class="input_rounded">
						<div class="inner">
						    <asp:TextBox ID="uxQuery" runat="server" ValidationGroup="search" MaxLength="2048"></asp:TextBox>
						</div>
						<div class="bottom"></div>
					</div>
					<asp:ImageButton ID="uxSearch" ValidationGroup="search" runat="server" ImageUrl="~/_img/buttons/btn-sidebar-go.gif" AlternateText="Go" />
					<div class="clear"></div>
				</fieldset>	
				</asp:Panel>
			</div>
			<div id="Sidebar_Find_A_Product" class="item">
				<h3>Find a product:</h3>
				<div id="nav_products">
					<asp:Repeater runat="server" ID="uxProducts" OnItemDataBound="uxProducts_ItemDataBound">
					<HeaderTemplate>
					<ul>
						<li class="toggle_select_parent">
							<a class="toggle_select" href="#">- - Select A Product - -</a>
							<ul class="toggle_select_items">							
					</HeaderTemplate>
					<ItemTemplate>
								<li runat="server" id="li" >
									<a runat="server" id="a" href="link">Topic 1</a>
								</li>
					</ItemTemplate>
					<FooterTemplate>
					        </ul>
						</li>
					</ul>
					</FooterTemplate>
					</asp:Repeater>
					<div class="bottom"></div>
				</div>
			</div>
			<div class="item">
				<h3>Solutions For Any Size</h3>
				<p>
					<ZNode:CustomMessage runat="server" MessageKey="SolutionsAnySize" />
					<div class="clear"></div>
					<a runat="server" href="~/content.aspx?page=products" class="read_more">Read more</a><br /><br />
				</p>
				<p><a runat="server" href="~/content.aspx?page=smallbusiness"><img src="<%= ResolveUrl("~/_img/right_sidebar/small_business_solutions.png") %>" width="254" height="31" alt="Small Business Solutions" /></a></p>
				<p><a runat="server" href="~/content.aspx?page=midsize"><img src="<%= ResolveUrl("~/_img/right_sidebar/medium_business_solutions.png") %>" width="254" height="31" alt="Medium Business Solutions" /></a></p>
				<p><a runat="server" href="~/content.aspx?page=enterprise"><img src="<%= ResolveUrl("~/_img/right_sidebar/enterprise_solutions.png") %>" width="254" height="31" alt="Enterprise Business Solution" /></a></p>
			</div>
			<asp:PlaceHolder runat="server" ID="uxSupportArea">
				<div class="item">
					<ZNode:CustomMessage runat="server" MessageKey="SidebarLinks" />
				</div>
			</asp:PlaceHolder>
			<asp:PlaceHolder runat="server" ID="uxResources">
				<div class="item">
				    <ZNode:CustomMessage runat="server" MessageKey="Resources"/>					
				</div>
			</asp:PlaceHolder>
			<uc1:recentNews ID="uxNewsArea" runat="server" Visible="false" />
			<div runat="server" id="uxCertifications" visible="false" class="item">
				<ZNode:CustomMessage runat="server" MessageKey="HomepageCertifications" />
			</div>
		<!-- /Sidebar --></div>
