<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master"  AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Admin_Secure_customers_view" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
 <div class="Form">
     <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <h1>
                     Account: <asp:Label ID="lblCustomerDetails" runat="server" Text="Label"></asp:Label>
                </h1>
                
            </td>
            <td align="right">
                                <asp:Button ID="CustomerList" runat="server" CssClass="Button" Text="< Back To Account List" Width="164px" OnClick="CustomerList_Click" />
                                <asp:Button ID="EditCustomer" runat="server" CssClass="Button" Text="Edit Account" Width="164px" OnClick="CustomerEdit_Click" />
            </td>
        </tr>
    </table>
       
    <h4>General Information</h4>
    
    <table border="0" cellpadding="0" cellspacing="0" class="ViewForm">
        <tr class="RowStyle">
            <td class="FieldStyle">Contact ID</td>
            <td class="ValueStyle">
                    <asp:Label ID="lblAccountID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="AlternatingRowStyle">
            <td style="width: 194px">
                            <div class="FieldStyle">Login Name</div>
                                                    
            </td>
            
            <td class="ValueStyle">                                                   
                            <asp:Label ID="lblLoginName" runat="server" Text="Label"></asp:Label>                          
            </td>
        </tr>                     
        
        <tr class="RowStyle">
            <td class="FieldStyle">Profile Type</td>
            <td class="ValueField">
                                   <asp:Label ID="lblProfileTypeName" runat="server" Text="Label"></asp:Label>                           
            </td>
        </tr> 
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Account Number</td>
            <td class="ValueStyle">
                                   <asp:Label ID="lblExternalAccNumber" runat="server" Text="Label" Width="98px"></asp:Label>                           
            </td>
        </tr> 
        
        <tr class="RowStyle">
            <td class="FieldStyle">Company Name</td>
            <td class="ValueStyle">         
                                   <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Description</td>
            
            <td class="ValueStyle">                                              
                            <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="RowStyle">
            <td class="FieldStyle">Contact Status</td>
            <td class="ValueStyle">         
                            <asp:Label ID="lblContactTemperature" runat="server"></asp:Label>
            </td>
        </tr> 
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Website</td>
            <td class="ValueStyle">         
                            <asp:Label ID="lblWebSite" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="RowStyle">
            <td class="FieldStyle">Source</td>
            
            <td class="ValueStyle">                                              
                            <asp:Label ID="lblSource" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Create Date</td>
            <td class="ValueStyle">         
                            <asp:Label ID="lblCreatedDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="RowStyle">
            <td class="FieldStyle">Create User</td>
            
            <td class="ValueStyle">                                              
                            <asp:Label ID="lblCreatedUser" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Update Date</td>
            <td class="ValueStyle">         
                            <asp:Label ID="lblUpdatedDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="RowStyle">
            <td class="FieldStyle">Update User</td>
            
            <td class="ValueStyle">                                              
                            <asp:Label ID="lblUpdatedUser" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        
        <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Custom1</td>
            <td class="ValueStyle">         
                            <asp:Label ID="lblCustom1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="RowStyle">
            <td class="FieldStyle">Custom2</td>
            
            <td class="ValueStyle">                                              
                            <asp:Label ID="lblCustom2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        
         <tr class="AlternatingRowStyle">
            <td class="FieldStyle">Custom3</td>
            <td class="ValueStyle">         
                            <asp:Label ID="lblCustom3" runat="server" Text="Label"></asp:Label>
            </td>
        </tr> 
        
        <tr class="RowStyle">
            <td colspan="2">&nbsp;</td>
        </tr>
  </table>  
  
    <h4>Address Information</h4>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="23%">
                            <div class="FieldStyle">Billing Address</div>
                            <div class="ValueStyle">
                            <asp:Label ID="lblBillingAddress" runat="server" Text="Label"></asp:Label></div> 
            </td>
            <td align="left" width="77%" valign="top">
                            <div class="FieldStyle">Shipping Address</div>
                            <div class="ValueStyle">
                            <asp:Label ID="lblShippingAddress" runat="server" Text="Label"></asp:Label>
                            </div>
            </td>
        </tr>     
  </table>  

<h4>
    Orders
</h4>

<asp:GridView ID="uxGrid" runat="server" AllowPaging="True"
        AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" CssClass="Grid"
        EmptyDataText="No Orders were found for this account." ForeColor="#333333" GridLines="None" Width="100%" OnPageIndexChanging="uxGrid_PageIndexChanging">
        
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="orderid" DataNavigateUrlFormatString="~/admin/secure/orders/view.aspx?itemid={0}"
                DataTextField="orderid" HeaderText="Order ID" SortExpression="orderid" />
            <asp:BoundField DataField="Orderdate" DataFormatString="{0:d}" HeaderText="Order Date"
                HtmlEncode="False" SortExpression="OrderDate" />
            <asp:TemplateField HeaderText="Order Amount" SortExpression="total">
                <ItemTemplate>
                   <asp:Label ID="TotalAmount" Text='<%# FormatPrice(Eval("total")) %>' runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order Status" SortExpression="OrderStateID">
                <ItemTemplate>
                 <asp:Label ID="OrderStatus" Text='<%# DisplayOrderStatus(Eval("OrderStateID")) %>' runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
    </asp:GridView>

    <uc1:spacer id="Spacer5" SpacerHeight="1" SpacerWidth="3" runat="server"></uc1:spacer>
        
    <h4>
         Notes
    </h4>
        
    <div style="text-align:right">
                           <asp:Button ID="AddNewNote" runat="server" CssClass="Button" Text="Add Note" Width="80px" OnClick="AddNewNote_Click"  />
    </div>
    
    <asp:Repeater ID="CustomerNotes" runat="server">
                       
           <ItemTemplate>
                           <asp:Label CssClass="ValueStyle" runat="Server" Text='<%# FormatCustomerNote(Eval("NoteTitle"),Eval("CreateUser"),Eval("CreateDte")) %>' />
                           <br />
                           <asp:Label ID="Label1" CssClass="ValueStyle" runat="Server" Text='<%# Eval("NoteBody") %>' />
                           <br /><br />                           
           </ItemTemplate>                                  
           
    </asp:Repeater>
    
    <uc1:spacer id="Spacer1" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
    
    

</div>
  
</asp:Content>


