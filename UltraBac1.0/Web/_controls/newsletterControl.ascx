<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newsletterControl.ascx.cs" Inherits="_controls_newsletterControl" %>
<%@ Register Src="~/_controls/newsletterMenu.ascx" TagPrefix="uc1" TagName="NewsletterMenu" %>

<style type="text/css" media="screen">
			a:hover {
				text-decoration: underline !important;
			}
		</style>
<table style="padding: 15px 0;" align="center" border="0" cellspacing="0" cellpadding="0" width="626">
  <tr>
    <!-- Left Column -->
    <td width="208" valign="top">
      <table align="left" border="0" cellspacing="0" cellpadding="0" width="208">
        <!-- header -->
        <tr>
          <td colspan="4" width="208">
            <table align="left" border="0" cellspacing="0" cellpadding="0" width="208">
              <tr>
                <td colspan="5"><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/header_bar_thin.gif") %>' width="208" height="11" style="display: block;"></td>
              </tr>
              <tr>
                <td width="1" bgcolor="#b3b2b2">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
                </td>
                <td width="17" bgcolor="#e4e4e4">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="17" style="display: block;">
                </td>
                <td width="172" bgcolor="#e4e4e4" valign="top" height="31">
                  <font style="font-family: Arial, sans-serif; font-size: 20px; color:#484848;">
                  In This Issue</font>
                </td>	
                <td width="17" bgcolor="#e4e4e4">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="17" style="display: block;">
                </td>
                <td width="1" bgcolor="#b3b2b2">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
                </td>								
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <!-- left border -->
          <td width="1" bgcolor="#b3b2b2">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
          </td>
          <td width="18">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="18" style="display: block;">
          </td>
          <!-- content -->
          <td width="188">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="188" height="10" style="display: block;">
            <font style="font-family: Arial, sans-serif; color: #9a9a9a; font-size: 11px; line-height: 14px;">
              <%= Summary %>
            </font>
          </td>
          <!-- right border -->
          <td width="1" bgcolor="#b3b2b2">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
          </td>								
        </tr>
        <tr>
          <!-- left border -->
          <td width="1" bgcolor="#b3b2b2">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
          </td>							
          <td colspan="2">
          
          <uc1:NewsletterMenu runat="server" ID="uxMenu" />
                                
          </td>
          <!-- right border -->
          <td width="1" bgcolor="#b3b2b2">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
          </td>							
        </tr>
        <!-- bottom graphic -->
        <tr><td colspan="4">
          <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/left_column_footer.gif") %>' width="208" height="15" style="display: block;">
        </td></tr>
      </table>
    </td>
    <!-- Space Between Columns -->
    <td width="22">
      <img src=<%= UrlHelper.GetFullUrl("_img/s.gif") %> width="22" height="1">
    </td>
    <!-- Right Column -->
    <td width="396" valign="top">
      <table align="left" border="0" cellspacing="0" cellpadding="0" width="396">
        <tr>
          <!-- header -->
          <td width="396" valign="top" colspan="5">
            <table border="0" cellspacing="0" cellpadding="0" width="396">
              <tr>
                <td colspan="6"><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/header_bar_wide.gif") %>' width="396" height="11" style="display: block;"></td>
              </tr>						
              <tr>
                <td width="1" bgcolor="#b3b2b2">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
                </td>
                <td width="17" bgcolor="#e4e4e4">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="17" style="display: block;">
                </td>
                <td width="250" bgcolor="#e4e4e4" valign="top" height="31">
                  <font style="font-family: Arial, sans-serif; font-size: 20px; color:#484848;">
                    <%= Newsletter.NewsletterType %> NewsWire
                  </font>
                </td>
                <td align="right" width="110" bgcolor="#e4e4e4" valign="top">
                  
                </td>
                <td width="17" bgcolor="#e4e4e4">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="17" style="display: block;">
                </td>	
                <td width="1" bgcolor="#b3b2b2">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" style="display: block;">
                </td>										
              </tr>
              <tr>
                <td width="18" colspan="2" bgcolor="#bc151b">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1">
                </td>
                <td width="250" bgcolor="#bc151b" height="18">
                  <font style="font-family: Arial, sans-serif; font-size: 10px; color:#ffffff; font-weight: bold; line-height: 18px;">
                    Published by UltraBac Software
                  </font>
                </td>
                <td width="110" bgcolor="#bc151b" align="right">
                  <font style="font-family: Arial, sans-serif; font-size: 10px; color:#ffffff; font-weight: bold; line-height: 18px;">
                    <%= NewsletterDate %>
                  </font>
                </td>										
                <td width="18" colspan="2" bgcolor="#bc151b">
                  <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1">
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <!-- content -->
        <tr>
          <td width="1" bgcolor="#b3b2b2">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1">
          </td>
          <td width="394">
			<table width="394" border="0" cellspacing="0" cellpadding="0">					
				<asp:Repeater runat="server" ID="uxArticleList">
					<ItemTemplate>
						<tr>
							<td width="17" bgcolor="#ffffff"><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1"></td>
							<td width="360">
								<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="360" height="10">
								<font style="color: #3f5d91; font-weight: bold; font-size: 14px; font-family: Arial, sans-serif; text-transform: uppercase;">
									<%# Eval("Title") %>
								</font>
								<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="360" height="5">
								<font style="font-family: Arial, sans-serif; font-size: 11px; line-height: 14px;">
									<%# Eval("Summary") %><br />
									<a style="color: #bc151b; line-height: 14px; font-family: Arial, sans-serif; font-size: 11px; font-weight: bold; text-decoration: none;" href='<%# UrlHelper.GetFullUrl(string.Format("/newsarticle.aspx?article={0}", Eval("Id"))) %>'>Read More</a>
								</font>
								<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="360" height="5">								
							</td>
							<td width="17" bgcolor="#ffffff"><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1"></td>
						</tr>
						<tr><td colspan="3" height="1" width="360" style='background: #ffffff url(<%= UrlHelper.GetFullUrl("/_img/hr.gif") %>) repeat-x top left;'><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="394" height="1"></td></tr>
					</ItemTemplate>
					<AlternatingItemTemplate>
						<tr>
							<td width="17" bgcolor="#f7f7f7"><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1"></td>
							<td width="360" bgcolor="#f7f7f7">
								<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="360" height="10">
								<font style="color: #3f5d91; font-weight: bold; font-size: 14px; font-family: Arial, sans-serif; text-transform: uppercase;">
									<%# Eval("Title") %>
								</font>
								<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="360" height="5">
								<font style="font-family: Arial, sans-serif; font-size: 11px; line-height: 14px;">
									<%# Eval("Summary") %><br />
									<a style="color: #bc151b; line-height: 14px; font-family: Arial, sans-serif; font-size: 11px; font-weight: bold; text-decoration: none;" href='<%# UrlHelper.GetFullUrl(string.Format("/newsarticle.aspx?article={0}", Eval("Id"))) %>'>Read More</a>
								</font>
								<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="360" height="5">
							</td>
							<td width="17" bgcolor="#f7f7f7"><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1"></td>
						</tr>
						<tr><td colspan="3" height="1" width="360" style='background: #ffffff url(<%= UrlHelper.GetFullUrl("/_img/hr.gif") %>) repeat-x top left;'><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="394" height="1"></td></tr>
					</AlternatingItemTemplate>
				</asp:Repeater>
			</table>
          </td>
          <td width="1" bgcolor="#b3b2b2">
            <img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/s.gif") %>' width="1" height="1">
          </td>							
        </tr>
        <!-- bottom graphic -->
        <tr><td colspan="5"><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/right_column_footer.gif") %>' width="396" height="21"></td></tr>
        </tr>																		
      </table>
    </td>
  </tr>		

</table>
