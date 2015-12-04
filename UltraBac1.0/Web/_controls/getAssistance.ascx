<%@ Control Language="C#" AutoEventWireup="true" CodeFile="getAssistance.ascx.cs" Inherits="_controls_getAssistance" %>

<h3>Get Assistance With...</h3>

<div id="nav_topics">
	<ul>
		<li>
			<a id="toggle_select_1" class="toggle_select" href="#">- - Select a Topic - -</a>
			<ul id="toggle_items_1" class="toggle_select_items">
				<li class="first">
					<a href="<%= ResolveUrl("~/content.aspx?page=purchase") %>">Purchasing</a>
				</li>
				<li>
					<a href="<%= ResolveUrl("~/content.aspx?page=licensing") %>">Licensing</a>
				</li>				
			    <li class="last">
					<a href="<%= ResolveUrl("~/content.aspx?page=upgrade") %>">Upgrading</a>
				</li>				
			</ul>
		</li>
	</ul>
	<div class="bottom"></div>
</div>