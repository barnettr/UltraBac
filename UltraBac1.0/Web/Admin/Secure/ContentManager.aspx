<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="ContentManager.aspx.cs" Inherits="Admin_ContentManager" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <h1>Manage Storefront Design</h1>
    <p>Use the links in this section to manage your storefront design and content</p>
    
    <div class="LandingPage">
        <hr />
         <div class="Shortcut"><a id="A1" href="~/admin/secure/template/sitetheme.aspx" runat="server">Site Theme</a></div>
        <p>The website theme controls the overall layout and color schemes of your storefront.</p> 
        
        <div class="Shortcut"><a id="A4" href="~/admin/secure/settings/messages/default.aspx" runat="server">Edit Storefront Messages</a></div>
        <p>Your storefront has several customizable message sections (ex: "Home page welcome message"). You can use a WYSIWYG editor to add rich content to these message sections.</p>
        
        
        <div class="Shortcut"><a id="A2" href="~/admin/secure/pages/default.aspx" runat="server">Manage Pages</a></div>
        <p>You can add or remove static content pages (ex: "About Us") from your storefront easily using the page manager. You can also add rich text, images, flash and other content
        to these pages using a built-in WYSIWYG editor.</p>
        
                 
        <div class="Shortcut"><a id="A5" href="~/admin/secure/template/CSSEditor.aspx" runat="server">Edit CSS</a></div>
        <p>This is for advanced users who are familiar with cascading style sheets. Use this function to edit the storefront's style sheet.</p>       
        
    </div>
</asp:Content>

