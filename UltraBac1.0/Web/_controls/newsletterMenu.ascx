<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newsletterMenu.ascx.cs" Inherits="_controls_newsletterMenu" %>

<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/seperator.gif") %>' width="206" height="10" style="display: block;">
<ul style="list-style: none; margin: 0; padding-top: 3px; padding-bottom: 0; padding-left: 0; padding-right: 0; font-family: Arial, sans-serif; font-size: 12px; line-height: 18px; font-weight: bold; color: #3e5d8e;">								
  <asp:Repeater runat="server" ID="uxArticleNav">
  <ItemTemplate>
      <li <%# IsActive(Container.DataItem) ? "style=\"color: #ffffff; background: #bc151b;\"" : "" %>>&nbsp;
      <a style="margin-left: 18px; color:<%# IsActive(Container.DataItem) ? "#ffffff" : "#3e5d8e" %>; text-decoration: none;" href='<%# UrlHelper.GetFullUrl(string.Format("/newsarticle.aspx?article={0}",Eval("Id"))) %>'><%# Eval("ShortTitle") %></a></li>
  </ItemTemplate>													
  </asp:Repeater>									
  </ul><img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/seperator.gif") %>' width="206" height="10" style="padding-bottom: 7px;">
<img src='<%= UrlHelper.GetFullUrl("/_img/newsletter/arrow_red_left.gif") %>'>&nbsp;<a style="color: #bc151b; line-height: 14px; font-family: Arial, sans-serif; font-size: 11px; font-weight: bold; text-decoration: none;" href="<%= ResolveUrl("~/") %>">Back to Home</a>