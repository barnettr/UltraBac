<%@ Page Language="C#"  MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="Admin_Secure_catalog_coupons_add" %>

<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/spacer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
    <div class="Form">
	    <table width="100%" cellspacing="0" cellpadding="0" >
		    <tr>
			    <td><h1><asp:Label ID="lblTitle" Runat="server"></asp:Label>
                    <uc2:DemoMode ID="DemoMode1" runat="server" />
                </h1></td>
			    <td align="right">
				    <asp:button class="Button" id="btnSubmitTop" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"  ></asp:button>
				    <asp:button class="Button" id="btnCancelTop" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
			    </td>
		    </tr>
	   </table>
	   
	    <div>
	        <uc1:spacer id="Spacer8" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
	    </div>    
	    <div class="FieldStyle">Select the target to which the Discount should be applied</div>
        <div class="ValueStyle">
        <asp:DropDownList ID="DiscountTarget" runat="server" Width="186px"></asp:DropDownList>
        </div>         
	    <div class="FieldStyle">Enter Coupon Code<span class="Asterix">*</span></div>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CouponCode" Display="Dynamic" ErrorMessage="* Enter a Coupon Code" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
        <div class="ValueStyle">
            <asp:TextBox ID="CouponCode" runat="server" MaxLength="15" Columns="25" ></asp:TextBox>
        </div>       
        <div class="FieldStyle">Select Discount Type</div>
        <div class="ValueStyle">
        <asp:DropDownList ID="DiscountType" runat="server" Width="186px" ></asp:DropDownList>
        </div>       
        <div class="FieldStyle">Enter Discount<span class="Asterix">*</span></div>
        <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Discount" Display="Dynamic" ErrorMessage="* Enter Discount" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
        <div>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Discount" Display="Dynamic" ErrorMessage="* Enter a valid Discount amount. Only numbers are allowed" SetFocusOnError="true" ValidationExpression="(^N/A$)|(^[-]?(\d+)(\.\d{0,3})?$)|(^[-]?(\d{1,3},(\d{3},)*\d{3}(\.\d{1,3})?|\d{1,3}(\.\d{1,3})?)$)"></asp:RegularExpressionValidator>
        </div>
        <div class="Error"><asp:Label ID="lblerror1" runat="server"></asp:Label></div> 
        <div class="ValueStyle">
        <asp:TextBox ID="Discount" runat="server" MaxLength="25" Columns="25"></asp:TextBox>
        </div> 
        <div class="FieldStyle">Enter an effective date for the Coupon (MM/DD/YY)<span class="Asterix">*</span></div>        
        <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="StartDate" Display="Dynamic" ErrorMessage="* Enter a valid start Date" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>        
        <div class="ValueStyle">
        <input  type="text" id="StartDate"  readonly="ReadOnly" runat="server" />
        <asp:image id="ImageDt1" runat="server"  style="cursor:pointer;  vertical-align:top" ImageUrl="~/images/icons/SmallCalendar.gif"></asp:image>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="StartDate"
            CssClass="Error" Display="Dynamic" ErrorMessage="* Enter Valid Start Date"
            ValidationExpression="((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))"></asp:RegularExpressionValidator>
        </div>
        <div class="FieldStyle">Enter an expiration date for the Coupon (MM/DD/YY)<span class="Asterix">*</span></div>
        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ExpDate" Display="Dynamic" ErrorMessage="* Enter a valid Exp Date" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareEndDate" runat="server" ControlToCompare="StartDate" ControlToValidate="ExpDate" CssClass="Error" ErrorMessage="The Expiration date must be later than the Start Date"  Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator></div>      
        <div class="ValueStyle">
            <input  type="text" id="ExpDate"  readonly="ReadOnly" runat="server" />
            <asp:image id="ImageDt2" runat="server"  style="cursor:pointer;  vertical-align:top" ImageUrl="~/images/icons/SmallCalendar.gif"></asp:image>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ExpDate"
            CssClass="Error" Display="Dynamic" ErrorMessage="* Enter Valid Date in MM/DD/YYYY format"
            ValidationExpression="((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))"></asp:RegularExpressionValidator>
        </div> 
        <div class="FieldStyle">Enter Available Quantity<span class="Asterix">*</span></div>
        <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Quantity" Display="Dynamic" ErrorMessage="* Enter Quantity" SetFocusOnError="True"></asp:RequiredFieldValidator></div> 
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Quantity"
            Display="Dynamic" ErrorMessage="* Enter a valid quantity. Enter a number between 0-999" MaximumValue="999"
            MinimumValue="0" Type="Integer"></asp:RangeValidator>
        <div class="ValueStyle">
        <asp:TextBox ID="Quantity" runat="server" MaxLength="4" Columns="25" Width="173px">99</asp:TextBox>
        </div>
         
        <div class="FieldStyle">Enter Order Minimum Amount<span class="Asterix">*</span></div>
        <small>This is the minimum amount the customer needs to order to avail this coupon. </small>
        <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="OrderMinimum" Display="Dynamic" ErrorMessage="* Order Minimum is required" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="OrderMinimum" Display="Dynamic" ErrorMessage="* Enter a valid Order Minimum Amount" SetFocusOnError="true" ValidationExpression="(^N/A$)|(^[-]?(\d+)(\.\d{0,3})?$)|(^[-]?(\d{1,3},(\d{3},)*\d{3}(\.\d{1,3})?|\d{1,3}(\.\d{1,3})?)$)"></asp:RegularExpressionValidator>
        </div>
        <div class="ValueStyle">$&nbsp;<asp:TextBox ID="OrderMinimum" runat="server" MaxLength="25" Columns="25" Width="170px">0</asp:TextBox></div>       
        <div><asp:Label ID="lblError" runat="server" Visible="true"></asp:Label></div>
  </div>
        <p></p>
        <asp:button class="Button" id="SubmitButton" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click" ></asp:button>
	    <asp:button class="Button" id="CancelButton" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>          
</asp:Content>