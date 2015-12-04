<%@ Control Language="C#" AutoEventWireup="true" CodeFile="recentNews.ascx.cs" Inherits="_controls_recentNews" %>
<div class="item">
	<h3>Recent News</h3>
	<asp:Repeater runat="server" ID="uxNews">
	<ItemTemplate>
	<p><%# (Container.DataItem as POP.UltraBac.ContentPageNode).ContentPage.Summary %><br />
	<a class="arrowLink" href="<%# ResolveUrl(Eval("LinkPath").ToString()) %>">Read More</a>
	</p>
	</ItemTemplate>
	</asp:Repeater>	
</div>