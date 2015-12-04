<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Secure_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    
    <h1>Storefront Dashboard <%=GetProductVersion()%></h1>
    
    <div class="Dashboard">
        <!--<div class="Status">
            <% =dashAdmin.StatusMessage %>
        </div>-->
        <div><img src="~/images/clear.gif" runat="server" width="10" height="15" alt="" /></div>
        <table cellpadding="5" cellspacing="0">
            <tr>
                <td align="center"><a href="~/admin/secure/catalogmanager.aspx" runat="server" style="text-decoration:none;"><img src="~/images/icons/large/catalog.gif" runat="server" border="0" alt=""/><br /><span style="text-decoration:underline;">Catalog</span></a></td>
                <td align="center"><a id="A11" href="~/admin/secure/ordermanager.aspx" runat="server" style="text-decoration:none;"><img id="Img11" src="~/images/icons/large/orders.gif" runat="server" border="0" alt=""/><span style="text-decoration:underline;"><br />Sales</span></a></td>
                <td align="center"><a id="A12" href="~/admin/secure/contentmanager.aspx" runat="server" style="text-decoration:none;"><img id="Img13" src="~/images/icons/large/content.gif" runat="server" border="0" alt=""/><span style="text-decoration:underline;"><br />Design</span></a></td>
                <td align="center"><a id="A13" href="~/admin/secure/settingsmanager.aspx" runat="server" style="text-decoration:none;"><img id="Img14" src="~/images/icons/large/settings.gif" runat="server" border="0" alt=""/><span style="text-decoration:underline;"><br />Settings</span></a></td>
                <td align="center"><a id="A14" href="http://www.znode.com/support/" target="_blank" style="text-decoration:none;"><img id="Img15" src="~/images/icons/large/help.gif" runat="server" border="0" alt="" /><span style="text-decoration:underline;"><br />Help</span></a></td>
            </tr>
        </table>
        <div><img id="Img16" src="~/images/clear.gif" runat="server" width="10" height="20" alt="" /></div>
        <table>
            <tr>
                <td valign="top">
                   <div class="Box">
                        <div class="Title"><span class="Caption">Storefront Metrics</span></div>
                        <div class="Inner">
                            
                            <div class="SubTitle">Sales & Accounts</div>        
                            <div class="Metric"><span class="MetricLabel">YTD Revenue:</span><span class="MetricValue"><% =dashAdmin.YTDRevenue.ToString("c")%></span></div>
                            
                            <div class="Metric"><span class="MetricLabel">New Orders (last 10 days):</span><span class="MetricValue"><% =dashAdmin.TotalNewOrders.ToString()%></span></div>
                            <div class="Metric"><span class="MetricLabel">Payment Pending Orders:</span><span class="MetricValue"><% =dashAdmin.TotalPaymentPendingOrders.ToString()%></span></div>
                            <div class="Metric"><span class="MetricLabel">Submitted Orders:</span><span class="MetricValue"><% =dashAdmin.TotalSubmittedOrders.ToString()%></span></div>
                            <div class="Metric"><span class="MetricLabel">Shipped Orders:</span><span class="MetricValue"><% =dashAdmin.TotalShippedOrders.ToString()%></span></div>
                            <div class="Metric"><span class="MetricLabel">Total Accounts:</span><span class="MetricValue"><% =dashAdmin.TotalAccounts.ToString()%></span></div>        
                            <div><img id="Img19" src="~/images/clear.gif" runat="server" width="10" height="10" alt="" /></div>
                            
                            <div class="SubTitle">Catalog</div> 
                            <div class="Metric"><span class="MetricLabel">Number of Products:</span><span class="MetricValue"><% =dashAdmin.TotalProducts.ToString()%></span></div>
                            <div class="Metric"><span class="MetricLabel">Number of Categories:</span><span class="MetricValue"><% =dashAdmin.TotalCategories.ToString()%></span></div>                            
                        </div>
                    </div> 
                </td>
                <td valign="top">
                    <div class="Box">
                        <div class="Title"><span class="Caption">Most Used Links</span></div>
                        
                        <div class="Inner">
                            <div class="SubTitle">Catalog Management</div>
                            <div class="Shortcut"><span class="Icon"><img id="Img6" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt="" /></span><a id="A3" href="~/admin/secure/catalog/product/list.aspx" runat="server">Products</a></div>
                            <div class="Shortcut"><span class="Icon"><img id="Img10" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A15" href="~/admin/secure/catalog/product_category/list.aspx" runat="server">Categories</a></div>
                            <div><img id="Img2" src="~/images/clear.gif" runat="server" width="10" height="10" /></div>                
                            <div class="SubTitle">Customer Management</div>
                            <div class="Shortcut"><span class="Icon"><img id="Img7" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A4" href="~/admin/secure/orders/list.aspx" runat="server">Orders</a></div>
                            <div class="Shortcut"><span class="Icon"><img id="Img8" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A5" href="~/admin/secure/customers/list.aspx" runat="server">Accounts</a></div>
                            <div><img id="Img3" src="~/images/clear.gif" runat="server" width="10" height="10" /></div>
                            <div class="SubTitle">Settings</div>
                            <div class="Shortcut"><span class="Icon"><img id="Img1" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A6" href="~/admin/secure/settings/general/default.aspx" runat="server">Global Settings</a></div>
                            <div class="Shortcut"><span class="Icon"><img id="Img9" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A7" href="~/admin/secure/settings/payment/default.aspx" runat="server">Payment Options</a></div>
                                    
                        </div>
                    </div> 
                </td>
                <td valign="top">
                    <div class="Box">
                        <div class="Title"><span class="Caption">Help & Support</span></div>
                        <div class="Inner">
                            <div class="SubTitle">Help</div>
                            <div class="Shortcut"><span class="Icon"><img id="Img21" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A2" href="http://www.znode.com/support/" target="_blank" runat="server">Online Help</a></div>  
                            <div class="Shortcut"><span class="Icon"><img id="Img23" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A17" href="http://www.znode.com/support/techsupport.aspx" target="_blank" runat="server">Contact Znode Support</a></div>                            
                            <div class="Shortcut"><span class="Icon"><img id="Img4" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A1" href="http://www.znode.com/support/releasenotes.aspx" target="_blank" runat="server">Release Notes</a></div>                            
                            <div class="Shortcut"><span class="Icon"><img id="Img5" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A8" href="http://www.znode.com/support/roadmap.aspx" target="_blank" runat="server">Znode Storefront Roadmap</a></div> 
                            <div><img id="Img25" src="~/images/clear.gif" runat="server" width="10" height="10" /></div>
                                    
                            <div class="SubTitle">Tools & Resources</div>
                            <div class="Shortcut"><span class="Icon"><img id="Img22" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A16" href="~/diagnostics.aspx" target="_blank" runat="server">Run Diagnostics</a></div>                        
                            <div class="Shortcut"><span class="Icon"><img id="Img26" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A20" href="https://www.google.com/analytics/" target="_blank" runat="server">Google Analytics</a></div>
                            <div class="Shortcut"><span class="Icon"><img id="Img12" src="~/images/icons/arrow.gif" runat="server" align="absmiddle" alt=""/></span><a id="A9" href="http://www.znode.com/support/resources.aspx" target="_blank" runat="server">E-Commerce Resources</a></div> 
                        </div>
                    </div> 
                </td>                 
            </tr>    
        </table>
        <div class="Status"><% =dashAdmin.StatusMessage %></div>
        <div><img id="Img17" src="~/images/icons/arrow.gif" runat="server" border="0" align="absmiddle" alt=""/>Get updated product information and documentation at <a href="http://www.znode.com" target="_blank">www.znode.com</a></div>
     </div>
</asp:Content>

