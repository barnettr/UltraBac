<%@ Control Language="C#"  AutoEventWireup="true" CodeFile="Installation.ascx.cs" Inherits="ZNodeInstallation_Installation" %>
<div style="vertical-align:top;">
<asp:Panel ID="PnlInstallation" runat="server">
<div>
<br />
<h1>Installation in Progress, Please Wait...</h1>
<div id="HintStyle">
This installation can take several minutes to complete. Please do not hit the refresh button
Or interrupt this installation.
</div><br />
<div>
<asp:Literal ID="ErrorMsg" runat="server" />
</div>
</div>
</asp:Panel>
</div>