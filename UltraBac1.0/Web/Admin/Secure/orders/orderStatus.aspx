<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="orderStatus.aspx.cs" Inherits="Admin_Secure_orders_orderStatus" %>

<%@ Register Src="../../../Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
    <div class="Form">
      <h1>Order# <asp:Label ID="lblOrderHeader" runat="server" />
          <uc2:DemoMode ID="DemoMode1" runat="server" />
      </h1>
      
      <h4>Change Order Status</h4>

      <p>Change the order status as per your current internal process. Set it to "Shipped" when the order is fulfilled.</p>
      
      <br /><br />
      
      <div class="FieldStyle">
                             <asp:DropDownList ID="ListOrderStatus" runat="server" />
      </div>
      <br /><br />
     
      
      <div class="ValueField">
                              <asp:Button ID="UpdateOrderStatus" runat="Server" CssClass="Button" Text="Update" OnClick="UpdateOrderStatus_Click" />
                              <asp:Button ID="Cancel" runat="Server" CssClass="Button" Text="Cancel" OnClick="CancelStatus_Click" />
      </div>

      <uc1:spacer id="LongSpace" SpacerHeight="20" SpacerWidth="3" runat="server"></uc1:spacer>
        
    </div> 
    
    <uc1:spacer id="Spacer2" SpacerHeight="200" SpacerWidth="3" runat="server"></uc1:spacer>
</asp:Content>


