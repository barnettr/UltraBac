<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="add_Addonvalues.aspx.cs" Inherits="Admin_Secure_catalog_product_addons_add_Addonvalues" %>
<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
    <div class="Form">
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <h1><asp:Label ID="lblTitle" Runat="server"></asp:Label></h1> <uc2:DemoMode ID="DemoMode1" runat="server" />
                        <div><uc1:spacer id="Spacer3" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
                        <div><asp:Label ID="lblAddonValueMsg" CssClass="Error" EnableViewState="false" runat="server"></asp:Label></div>	    
    	            </td>
    	            <td>
    	                <div align="right">
                            <asp:button class="Button" ValidationGroup="grpAddOnValue" id="btnTopSubmit" CausesValidation="True" Text="Submit" Runat="server" onclick="btnAddOnValueSubmit_Click"></asp:button>				          
                            <asp:button class="Button" id="btnCancelTop" CausesValidation="False" Text="Cancel" Runat="server" onclick="btnCancel_Click"></asp:button>
                        </div>
    	            </td>
    	        </tr> 
	        </table>
    	                	                
            <h4>General Settings</h4>
             
            <div class="FieldStyle">Label<span class="Asterix">*</span></div>
            <small>Enter the label for this option value (Ex : "Fire engine red").</small>
            <div><asp:RequiredFieldValidator ValidationGroup="grpAddOnValue" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddOnValueName" ErrorMessage="Enter Product Name" CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator> </div>
            <div class="ValueStyle"><asp:TextBox ID="txtAddOnValueName" runat="server"></asp:TextBox></div>
             
            <div class="FieldStyle">Retail Price<span class="Asterix">*</span></div>
            <small>Enter the price for this product Add-On that should be charged in addition to the product price.</small>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="grpAddOnValue" runat="server" ErrorMessage="Enter a Retail Price for this Product" ControlToValidate="txtAddOnValueRetailPrice" CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" ValidationGroup="grpAddOnValue" runat="server" ControlToValidate="txtAddOnValueRetailPrice" Type="Currency" Operator="DataTypeCheck" ErrorMessage="You must enter a valid Retail Price (ex: 123.45)" CssClass="Error" Display="Dynamic" />                        
                <asp:RangeValidator ID="RangeValidator1" ValidationGroup="grpAddOnValue" runat="server" ControlToValidate="txtAddOnValueRetailPrice" ErrorMessage="Enter a price between 0-999999" MaximumValue="999999" MinimumValue="0" Type="Currency" Display="Dynamic"></asp:RangeValidator>
            </div>
            <div class="ValueStyle">$&nbsp;<asp:TextBox Text="0" ID="txtAddOnValueRetailPrice" runat="server" MaxLength="7"></asp:TextBox></div>
            
            <h4>Display Settings</h4>
            
            <div class="FieldStyle">DisplayOrder</div>
             <div>
                <asp:RequiredFieldValidator ValidationGroup="grpAddOnValue" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddonValueDispOrder" CssClass="Error" Display="Dynamic" ErrorMessage="Enter a Display Order for this product"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="grpAddOnValue" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAddonValueDispOrder"
                    CssClass="Error" Display="Dynamic" ErrorMessage="You Must Enter a Valid Display Order"
                    ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
            </div>
            <div class="ValueStyle"><asp:TextBox Text="500" MaxLength="6" ID="txtAddonValueDispOrder" runat="server"></asp:TextBox></div>
           
            <div>
            <asp:CheckBox ID="chkIsDefault" runat="server" Text="" />
            Check here to make this the default selected item in the list.
            </div>
            
            <h4>Inventory Settings</h4>

            <div class="FieldStyle">SKU or Part#</div>           
            <div class="ValueStyle"><asp:TextBox ID="txtAddOnValueSKU" runat="server"></asp:TextBox></div>                                      
            
            <div class="FieldStyle">Quantity On Hand<span class="Asterix">*</span></div>
            <div>
                <asp:RangeValidator ValidationGroup="grpAddOnValue" ID="RangeValidator2" runat="server" ControlToValidate="txtAddOnValueQuantity" CssClass="Error" Display="Dynamic" ErrorMessage="Enter a number between 0-999999" MaximumValue="999999" MinimumValue="0" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                <asp:RequiredFieldValidator ValidationGroup="grpAddOnValue" ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddOnValueQuantity" CssClass="Error" Display="Dynamic" ErrorMessage="You Must Enter a Valid Quantity"></asp:RequiredFieldValidator>
            </div>
            <div class="ValueStyle"><asp:TextBox ID="txtAddOnValueQuantity" runat="server" Rows="3">9999</asp:TextBox></div> 
            
            <div class="FieldStyle">Item Weight</div>
            <div><asp:CompareValidator ID="CompareValidator3" ValidationGroup="grpAddOnValue" runat="server" ControlToValidate="txtAddOnValueWeight" Type="Currency" Operator="DataTypeCheck" ErrorMessage="You must enter a valid Weight(ex: 2.5)" CssClass="Error" Display="Dynamic" /></div>
            <div class="ValueStyle"><asp:TextBox ID="txtAddOnValueWeight" runat="server" Width="46px"></asp:TextBox> lbs</div>
            
            <div><uc1:spacer id="Spacer2" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer></div>                    
            <p></p>
            <div>
                <asp:button class="Button" ValidationGroup="grpAddOnValue" id="btnBottomSubmit" CausesValidation="True" Text="Submit" Runat="server" onclick="btnAddOnValueSubmit_Click"></asp:button>
                <asp:button class="Button" id="btnCancelBottom" CausesValidation="False" Text="Cancel" Runat="server" onclick="btnCancel_Click"></asp:button>
            </div>           
	</div>
</asp:Content>


