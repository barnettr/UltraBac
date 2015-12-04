<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Themes/Standard/edit.master" CodeFile="addrelateditems.aspx.cs" Inherits="Admin_Secure_catalog_product_addrelateditems" %>

<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
    <div class="Form">
        <h1>Add a Related Item<uc1:DemoMode id="DemoMode1" runat="server"></uc1:DemoMode></h1>
        <p>Use this page to add related items to the product. The related items will show up on the Related Items Tab.</p>
        
        <div class="FieldStyle">Select related product to add</div>
        <div class="HintStyle"></div>
        <div class="ValueStyle"><asp:DropDownList ID="Listproducts" runat="server" Width="141px"></asp:DropDownList></div>
        <div>
            <asp:Label ID="lblError" runat="server" Text="Label" Visible="false"  CssClass="Error" ForeColor="red"></asp:Label>            
        </div>
        <p></p>
        <div>
            <asp:Button ID="butAddNew" CssClass="Button" Width="68" Text="Update" OnClick="Update_Click" runat="server" />
            <asp:Button ID="Cancel" CssClass="Button" Width="68" Text="Cancel" OnClick="Cancel_Click" runat="server" />
         </div>
         <br /><br /><br /><br />
    </div>
</asp:Content>


