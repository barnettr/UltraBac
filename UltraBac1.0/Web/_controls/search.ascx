<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="_controls_search" %>

<asp:TextBox CssClass="searchBox" ID="txtSearchTerm" runat="server" ValidationGroup="GlobalSearch" />

<asp:Button ID="btnGo" runat="server" Text="Search" ValidationGroup="GlobalSearch" CausesValidation="true" />

<asp:RequiredFieldValidator ID="rfvSearchTerm" runat="server" Display="Dynamic" ForeColor=""
    ControlToValidate="txtSearchTerm" ValidationGroup="GlobalSearch" 
    ErrorMessage="Search term is required." />
