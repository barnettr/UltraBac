<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master"  AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Admin_Secure_orders_list" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
<div class="Form">
<table cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td><h1>Orders</h1></td>
			<td align="right"></td>
		</tr>
		<tr>
		    <td colspan="2">Use this page to search and download orders from your storefront.</td>
		</tr>
</table>
<h4>Search Orders</h4> 

<asp:Panel ID="Test" DefaultButton="btnSearch" runat="server" >  
        <table border="0" width="70%">
        <tr>                
        <td style="height: 45px">
        <div class="FieldStyle">Order ID</div>
        <div class="ValueStyle"><asp:TextBox ID="txtorderid" runat="server"></asp:TextBox></div>
        </td> 
                        
        <td style="height: 45px">
        <div class="FieldStyle">First Name</div>
        <div class="ValueStyle"><asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox></div>
        </td> 
           
        <td style="height: 45px">               
        <div class="FieldStyle">Last Name</div>
        <div class="ValueStyle"><asp:TextBox ID="txtlastname" runat="server"></asp:TextBox></div>
        </td>                         
        </tr>
        
        <tr>
         <td style="height: 45px">   
        <div class="FieldStyle">Company Name</div>  
        <div class="ValueStyle"><asp:TextBox ID="txtcompanyname" runat="server"></asp:TextBox></div>
        </td>      
           
        <td style="height: 45px">
        <div class="FieldStyle">Account Number</div>
        <div class="ValueStyle"><asp:TextBox ID="txtaccountnumber" runat="server"></asp:TextBox></div>
        </td>        
        
        <td>
        <div class="FieldStyle">Order Status</div>                           
        <div class="ValueStyle"><asp:DropDownList ID="ListOrderStatus" runat="server"></asp:DropDownList></div>        
        </td>
        </tr> 
        
        <tr>
        <td><div class="FieldStyle">Begin Date</div>
        <div class="ValueStyle">
               <input  type="text" id="txtStartDate"  readonly="ReadOnly" value="01/01/2007" runat="server" />
               <asp:image id="ImageDt1" runat="server"  style="cursor:pointer;  vertical-align:top" ImageUrl="~/images/icons/SmallCalendar.gif"></asp:image>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate"
                        CssClass="Error" Display="Dynamic" ErrorMessage="* Enter Valid Date in MM/DD/YYYY format"
                        ValidationExpression="((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))"></asp:RegularExpressionValidator>
        </div>
        </td>
        
        <td><div class="FieldStyle">End Date</div>
        <div class="ValueStyle">
          <input  type="text" id="txtEndDate"  readonly="ReadOnly" value="01/01/2007" runat="server" />
          <asp:image id="ImageDt2" runat="server"  style="cursor:pointer;  vertical-align:top" ImageUrl="~/images/icons/SmallCalendar.gif"></asp:image>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEndDate"
                CssClass="Error" Display="Dynamic" ErrorMessage="* Enter Valid Date in MM/DD/YYYY format"
                ValidationExpression="((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))"></asp:RegularExpressionValidator>
        </div>
        <div class="ValueStyle">
         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtStartDate"
            ControlToValidate="txtEndDate" CssClass="Error" Display="Dynamic" ErrorMessage=" End Date must be greater than Begin date"
            Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
        </div>
        </td>
        </tr>    
        
        <tr>            
        <td colspan="2">       
         <div class="ValueStyle">
         <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="Button" />
         <asp:Button ID="btnClearSearch" runat="server" OnClick="btnClearSearch_Click" Text="Clear Search" CssClass="Button" CausesValidation="False" />
         </div>        
        </td>
        
        <td>
        </td>
        </tr>        
      </table>  
   </asp:Panel>	             
    <h4> Order List </h4>  
    <div align="right">
        <asp:Button ID="ButDownload" runat="server" OnClick="ButDownload_Click" Text="Download Orders to Excel" CssClass="Button" />&nbsp;&nbsp;<asp:Button ID="ButOrderLineItems" runat="server" OnClick="ButOrderLineItemsDownload_Click" Text="Download Order Line Items to Excel" CssClass="Button" Width="250px" /><br /><br />
    </div>
    <asp:GridView ID="uxGrid" runat="server" CssClass="Grid" CaptionAlign="Left" AutoGenerateColumns="False" GridLines="None"  AllowPaging="True" PageSize="25" OnPageIndexChanging="uxGrid_PageIndexChanging" OnRowCommand="uxGrid_RowCommand" EmptyDataText="No Orders exist in the database." Width="100%" DataKeyNames="orderid" OnSorting="uxGrid_Sorting" CellPadding="4" AllowSorting="True">
        <Columns>
         <asp:HyperLinkField DataNavigateUrlFields="orderid" DataNavigateUrlFormatString="view.aspx?itemid={0}"
                DataTextField="orderid" HeaderText="Order ID" SortExpression="orderid" />
            <asp:TemplateField SortExpression="ShipFirstName">
            <HeaderTemplate>
             <asp:Label ID="headerTotal" text="Customer Name" runat="server"></asp:Label>
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label ID="CustomerName" Text='<%# ReturnName(Eval("BillingFirstName"),Eval("BillingLastName")) %>' runat="server" ></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Orderdate" HeaderText="Order Date" SortExpression="OrderDate" DataFormatString="{0:d}" HtmlEncode="False" />
            <asp:TemplateField SortExpression="total" HeaderText="Order Amount">
            <ItemTemplate>
                       <%# DataBinder.Eval(Container.DataItem, "total","{0:c}").ToString()%>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="OrderStateID" HeaderText="Order Status">
            <ItemTemplate>
            <asp:Label ID="OrderStatus" Text='<%# DisplayOrderStatus(Eval("OrderStateID")) %>' runat="server" ></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                    <asp:Button runat="server" CausesValidation="False" ID="ViewOrder" Text="View Order"  CssClass="Button" CommandArgument='<%# Eval("orderid") %>' CommandName="ViewOrder" />
            </ItemTemplate>
            </asp:TemplateField>           
                       
            <asp:TemplateField>
            <ItemTemplate>
                    <asp:Button runat="server" CausesValidation="false" ID="ChangeStatus" Text="Change Status"  CssClass="Button" CommandArgument='<%# Eval("orderid") %>' CommandName="Status" />
            </ItemTemplate>
            </asp:TemplateField>  
        </Columns>
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <AlternatingRowStyle CssClass="AlternatingRowStyle" />
        
     </asp:GridView> 
    
           
    
    </div>
</asp:Content>


