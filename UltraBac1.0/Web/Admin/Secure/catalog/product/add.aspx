<%@ Page Language="C#" ValidateRequest="false"  MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="Admin_Secure_products_add" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>
<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
<div class="Form">
    <table cellpadding="0" cellspacing="0" width="100%">
      <tr>     
        <td valign="middle">
            <h1><asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </td>
        <td align="right">
            <asp:Button ID="btnSubmitTop" runat="server" CausesValidation="True" class="Button" OnClick="btnSubmit_Click" Text="SUBMIT" />
            <asp:Button ID="btnCancelTop" runat="server" CausesValidation="False" class="Button" OnClick="btnCancel_Click" Text="CANCEL" />
        </td>
      </tr>        
    </table>

    <div><asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" /></div>
    <div><asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label></div>
    <uc2:DemoMode id="DemoMode1" runat="server"></uc2:DemoMode>
    <div><uc1:spacer id="Spacer1" SpacerHeight="5" SpacerWidth="3" runat="server"></uc1:spacer></div>
    
    <div>
        <h4>Select a Product Category</h4>
        <small>Check one or more categories to which this product should be added. The product will be displayed when a user selects those categories from the menu.</small> 
        <div><asp:Label ID="lblCategoryError" runat="server" CssClass="Error" Text="Select at least one Category for this Product"  Visible="False" /></div>    
        <div class="ShoppingCartNavigation">
            <asp:TreeView ID="CategoryTreeView"  runat="server" ImageSet="Arrows" ShowCheckBoxes="All" CssClass="TreeView" ShowLines="True" ExpandDepth="0">
               <ParentNodeStyle CssClass="ParentNodeStyle" Font-Bold="False" />
                <HoverNodeStyle CssClass="HoverNodeStyle" Font-Underline="True" ForeColor="#5555DD" />
                <SelectedNodeStyle CssClass="SelectedNodeStyle" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                <RootNodeStyle CssClass="RootNodeStyle" />
                <LeafNodeStyle CssClass="LeafNodeStyle" />
                <NodeStyle CssClass="NodeStyle" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
            </asp:TreeView>
        </div>
       
        <h4>General Information</h4>
        
        <div class="FieldStyle">Product Name<span class="Asterix">*</span></div>
        <small>Enter a name for the Product (ex: "Ipod Nano")</small>
        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="Enter Product Name" CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator> </div>
        <div class="ValueStyle">
            <asp:TextBox ID="txtProductName" runat="server" Width="152px"></asp:TextBox>                       
        </div>

        <div class="FieldStyle">Product Number<span class="Asterix">*</span></div>
        <small>Enter your internal product number for this item</small>
        <div><asp:RequiredFieldValidator ID="ProductName" runat="server" ControlToValidate="txtProductNum" ErrorMessage="Enter Product Number" CssClass="Error" Display="dynamic"></asp:RequiredFieldValidator> </div>
        <div class="ValueStyle"><asp:TextBox ID="txtProductNum" runat="server" Width="152px"></asp:TextBox></div>
        
        <div class="FieldStyle">Product Type</div>
        <small>The product type will determine special product attributes. Leave at "Default" if unsure.</small>
        <div class="ValueStyle">
           <asp:DropDownList ID="ProductTypeList" runat="server" Width="152px" AutoPostBack="True" />
        </div>
        <div class="FieldStyle" id="DivAttributes" runat="Server">Product Attributes<span class="Asterix">*</span></div>
        <div class="ValueStyle">
            <asp:PlaceHolder id="ControlPlaceHolder" runat="server"></asp:PlaceHolder>
        </div> 
        
        <div class="FieldStyle">SKU or Part#<span class="Asterix">*</span></div>
        <small>If not applicable to your product then enter the product number instead</small>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtProductSKU" CssClass="Error" Display="Dynamic" ErrorMessage="Enter a Valid SKU or Part#"></asp:RequiredFieldValidator>
        </div>
        <div class="ValueStyle"><asp:TextBox ID="txtProductSKU" runat="server"></asp:TextBox></div>                                      

        <div class="FieldStyle">Retail Price<span class="Asterix">*</span></div>
        <small>The retail price will be displayed as the product price in the storefront.</small>
        <div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter a Retail Price for this Product" ControlToValidate="txtproductRetailPrice" CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtproductRetailPrice" Type="Currency" Operator="DataTypeCheck" ErrorMessage="You must enter a valid Retail Price (ex: 123.45)" CssClass="Error" Display="Dynamic" />                        
            <asp:RangeValidator runat="server" ControlToValidate="txtproductRetailPrice" ErrorMessage="You must enter a Retail Price value between $0 and $999,999.99" MaximumValue="99999999" Type="Currency" MinimumValue="0" Display="Dynamic" CssClass="Error"></asp:RangeValidator>
        </div>
        <div class="ValueStyle">$&nbsp;<asp:TextBox ID="txtproductRetailPrice" runat="server" MaxLength="10"></asp:TextBox></div>
                              
        
                     
        <asp:Panel ID="pnlquantity" runat="server">
            <div class="FieldStyle">Quantity On Hand<span class="Asterix">*</span></div>
            <small>This is the current inventory level for this product in your warehouse.</small>
            <div>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtProductQuantity" CssClass="Error" Display="Dynamic" ErrorMessage="Enter an inventory level number between -999999 and 999999" MaximumValue="999999" MinimumValue="-999999" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProductQuantity" CssClass="Error" Display="Dynamic" ErrorMessage="You Must Enter a Valid Product Quantity"></asp:RequiredFieldValidator>
            </div>
            <div class="ValueStyle"><asp:TextBox ID="txtProductQuantity" runat="server" Rows="3">1</asp:TextBox></div> 
        </asp:Panel>
        
        <h4>Product Image</h4>
        <small>Upload a suitable image for your product. Only JPG, GIF and PNG images are supported. The file size should be less than 1.5 Meg. Your image will automatically be scaled so it displays correctly in the catalog.</small>
        <table  id="tblShowImage" border="0" cellpadding="0" cellspacing="20" runat="server" visible="false">
            <tr>
                <td><asp:Image ID="Image1" runat="server" /></td>
                <td>
                    <div class="FieldStyle">Select an Option</div> 
                    <div class="ValueStyle">
                        <asp:RadioButton ID="RadioProductCurrentImage" Text="Keep Current Image" runat="server" GroupName="Product Image" AutoPostBack="True" OnCheckedChanged="RadioProductCurrentImage_CheckedChanged" Checked="True" />
                        <asp:RadioButton ID="RadioProductNewImage"  Text="Upload New Image" runat="server" GroupName="Product Image" AutoPostBack="True" OnCheckedChanged="RadioProductNewImage_CheckedChanged" />
                    </div>
                </td>
            </tr>
        </table>
        
        <table  id="tblProductDescription" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" visible="false">
            <tr>
                <td>
                   <div>
                        <asp:RequiredFieldValidator CssClass="Error" ID="RequiredFieldValidator4" runat="server" ControlToValidate="UploadProductImage" ErrorMessage="Select Product Image" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblProductImageError" runat="server" CssClass="Error" ForeColor="Red" Text="" Visible="False"></asp:Label>
                   </div>
                   <div class="ValueStyle">Select an Image:&nbsp;<asp:FileUpload ID="UploadProductImage" runat="server" Width="300px" BorderStyle="Inset" EnableViewState="true" />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="UploadProductImage" CssClass="Error" 
                        Display="dynamic" ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])" 
                        ErrorMessage="Please select a valid JPEG, JPG, PNG or GIF image"></asp:RegularExpressionValidator>
                   </div>
                </td> 
            </tr>
        </table>
        
        <div class="FieldStyle">
        Image File Name    
        <div class="ValueStyle">
        <asp:TextBox ID="txtimagename" runat="server" Visible="false"></asp:TextBox></div>
        </div>                   
                         
        
        <h4>Description</h4>    
        
        <div class="FieldStyle">
        Short Description</div>
        <small>Enter an optional short description (less than 100 characters) to be displayed in the product listing grid</small>
        <div class="ValueStyle">
        <asp:TextBox ID="txtshortdescription" runat="server" Width="300px" TextMode="MultiLine" Height="75px" MaxLength="100"></asp:TextBox>
        </div>   
        <div class="FieldStyle">Enter a Description<span class="Asterix">*</span></div>
        <small>You can enter rich text and images for the product description. Hint: To upload images to your description
        click on the image upload button.</small>
        <div class="ValueStyle"><uc1:HtmlTextBox id="ctrlHtmlText" runat="server"></uc1:HtmlTextBox></div>
        

        <h4>Product Properties</h4>	
        
        <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ProductTypeList" ErrorMessage="Select Product Type" CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator></div>
        <div class="FieldStyle">Select Product Manufacturer</div>     
        <div class="ValueStyle"><asp:DropDownList ID="ManufacturerList" runat="server" Width="152px"></asp:DropDownList></div>                                        
         
        <div class="FieldStyle">Sale Price</div>
        <small>Leave blank if product is not on sale. If specified, then it will be displayed as a sale price adjacent to the retail price.</small>
        <div><asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtproductSalePrice" Type="Currency" Operator="DataTypeCheck" ErrorMessage="You must enter a valid Sale price(ex: 123.45)" CssClass="Error"  Display="Dynamic" /></div>
        <div class="ValueStyle">$&nbsp;<asp:TextBox ID="txtproductSalePrice" runat="server" MaxLength="10"></asp:TextBox></div>
        
        <div class="FieldStyle">WholeSale Price</div>
        <small>Leave blank if product does not have a wholesale price.</small>
        <div><asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtProductWholeSalePrice" Type="Currency" Operator="DataTypeCheck" ErrorMessage="You must enter a valid Wholesale price(ex: 123.45)" CssClass="Error"  Display="Dynamic" /></div>
        <div class="ValueStyle">$&nbsp;<asp:TextBox ID="txtProductWholeSalePrice" runat="server" MaxLength="10"></asp:TextBox></div>
    </div>
    <div><uc1:spacer id="Spacer8" SpacerHeight="25" SpacerWidth="3" runat="server"></uc1:spacer></div>
    <div>
        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
    </div>	
</div>             
</asp:Content>

