<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Admin_Secure_settings_storesettings" Title="Untitled Page" validateRequest="false"   %>
<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
<div class="Form">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="middle">
                    <h1>Global Settings<uc1:DemoMode ID="DemoMode1" runat="server" />
                    </h1>
                </td>
                <td align="right">
                    <asp:Button ID="btnSubmitTop" runat="server" CausesValidation="True" class="Button"
                        OnClick="btnSubmit_Click" Text="SUBMIT" />
                    <asp:Button ID="btnCancelTop" runat="server" CausesValidation="False" class="Button"
                        OnClick="btnCancel_Click" Text="CANCEL" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div><asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label></div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    ForeColor=""
                     DisplayMode="List" ShowMessageBox="True" ShowSummary="False" />    
                </td>
            </tr>
        </table>
    </div> 
    
    <h4>Storefront Identity</h4>
    <div class="FieldStyle">Domain Name<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtDomainName" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDomainName" ErrorMessage="* Enter Domain Name" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator></div>
    
    <div class="FieldStyle">Company Name<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtCompanyName" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="* Enter Company Name" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator></div>

    <div class="FieldStyle">Store Name<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtStoreName" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStoreName" ErrorMessage="* Enter Store Name" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator></div>

    <h4>Upload a Logo</h4>
    <table id="tblShowImage" border="0" cellpadding="0" cellspacing="10" runat="server" visible="true">
        <tr>
            <td><asp:Image ID="imgLogo" runat="server" /></td>
            <td>
                <div class="FieldStyle">Select an Option</div> 
                &nbsp;
                <asp:RadioButton ID="radCurrentImage" Text="Keep Current Image" runat="server" GroupName="LogoImage" AutoPostBack="True" OnCheckedChanged="radCurrentImage_CheckedChanged" Checked="True" />
                <asp:RadioButton ID="radNewImage"  Text="Upload New Image" runat="server" GroupName="LogoImage" AutoPostBack="True" OnCheckedChanged="radNewImage_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table  id="tblLogoUpload" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server" visible="false">
        <tr>
            <td style="height: 41px">
                <div class="HintStyle">Select a Logo Image</div>
                <div class="ValueStyle">
                    <asp:FileUpload ID="UploadImage" runat="server" Width="300px" /><asp:RequiredFieldValidator CssClass="Error" ID="RequiredFieldValidator14" runat="server" ControlToValidate="UploadImage" ErrorMessage="* Select an Image to Upload" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblImageError" runat="server" CssClass="Error" ForeColor="Red" Text="Select Valid Product Image (JPEG or PNG or GIF)" Visible="False"></asp:Label>
                </div>      
            </td> 
        </tr>
    </table>
    
    <h4>Security Setting</h4>
    <p>Check the box below if you want to use a Secure Certificate (SSL) for checkout. <b>Important:</b> Your storefront
    will fail to function if a valid certificate is not installed. Contact your administrator if you have doubts about this setting.<br /><br />
    </p>
    <div class="FieldStyle"><asp:CheckBox ID="chkEnableSSL" runat="server" Text="Enable SSL?" /></div>
    
    <h4>Storefront Contact Information</h4>
    <p>
    The contact information is displayed in different areas and is also used for sending email notifications.
    </p>
     
    <div class="FieldStyle">Administrator's Email<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtAdminEmail" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminEmail" ErrorMessage="* Enter Admin Email" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="valRegEx" runat="server" ControlToValidate="txtAdminEmail" ValidationExpression="[a-z|A-Z0-9_-]+(\.[a-z|A-Z0-9_-]+)*@[a-z|A-Z0-9_-]+(\.[a-z|A-Z0-9_-]+)+" ErrorMessage="* Enter a valid email address." display="dynamic" CssClass="Error"></asp:RegularExpressionValidator></div>

    <div class="FieldStyle">Sales Department Email<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtSalesEmail" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSalesEmail" ErrorMessage="* Enter Sales Email" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtSalesEmail" ValidationExpression="[a-z|A-Z0-9_-]+(\.[a-z|A-Z0-9_-]+)*@[a-z|A-Z0-9_-]+(\.[a-z|A-Z0-9_-]+)+"  ErrorMessage="* Enter a valid email address." CssClass="Error" display="dynamic"></asp:RegularExpressionValidator></div>

    <div class="FieldStyle">Customer Service Email<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtCustomerServiceEmail" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCustomerServiceEmail" ErrorMessage="* Enter Customer Service Email" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtCustomerServiceEmail" ValidationExpression="[a-z|A-Z0-9_-]+(\.[a-z|A-Z0-9_-]+)*@[a-z|A-Z0-9_-]+(\.[a-z|A-Z0-9_-]+)+"  ErrorMessage="* Enter a valid email address." display="dynamic" CssClass="Error"></asp:RegularExpressionValidator></div>

    <div class="FieldStyle">Sales Department Phone Number<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtSalesPhoneNumber" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSalesPhoneNumber" ErrorMessage="* Enter Sales Phone Number" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator></div>

    <div class="FieldStyle">Customer Service Phone Number<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtCustomerServicePhoneNumber" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCustomerServicePhoneNumber" ErrorMessage="* Enter Customer Service Phone Number" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator></div>

    <h4>Grid Display Settings</h4>
     
    <div class="FieldStyle">Maximum Catalog Display Columns<span class="Asterix">*</span></div>
    <div class="HintStyle">Enter the maximum number of columns to display in the catalog listing (ex: 4)</div>
    <div class="ValueStyle"><asp:TextBox ID="txtMaxCatalogDisplayColumns" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMaxCatalogDisplayColumns" ErrorMessage="* Enter Max Catalog Display Columns" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtMaxCatalogDisplayColumns"
                            CssClass="Error" Display="Dynamic" ErrorMessage="* Enter a number between 1-10"
                            MaximumValue="10" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>
    
    <div class="FieldStyle">Maximum Catalog Items to Display Per Page<span class="Asterix">*</span></div>
    <div class="ValueStyle"><asp:TextBox ID="txtMaxCatalogDisplayItems" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtMaxCatalogDisplayItems" ErrorMessage="* Enter Max Catalog Display Items" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtMaxCatalogDisplayItems"
                            CssClass="Error" Display="Dynamic" ErrorMessage="* Enter a number between 1-1000"
                            MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>
                            
     
                            
    <h4>Image Settings</h4>

    <div class="FieldStyle">Maximum Large Image Width<span class="Asterix">*</span></div>
    <div class="HintStyle">Enter the maximum width in pixels a product picture will display when the user clicks on the Larger Image link (ex: 450).</div>
    <div class="ValueStyle"><asp:TextBox ID="txtMaxCatalogItemLargeWidth" runat="server" Width="152px"></asp:TextBox>&nbsp;pixels&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtMaxCatalogItemLargeWidth" ErrorMessage="* Enter Max Large Image Width" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtMaxCatalogItemLargeWidth"
                            CssClass="Error" Display="Dynamic" ErrorMessage="* Enter a number between 1-1000"
                            MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>

    <div class="FieldStyle">Maximum Medium Image Width<span class="Asterix">*</span></div>
    <div class="HintStyle">Enter the maximum width in pixels a product picture will display on the Product Page (ex: 249).</div>
    <div class="ValueStyle"><asp:TextBox ID="txtMaxCatalogItemMediumWidth" runat="server" Width="152px"></asp:TextBox>&nbsp;pixels&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMaxCatalogItemMediumWidth" ErrorMessage="* Enter Max Medium Image Width" CssClass="Error" display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtMaxCatalogItemMediumWidth"
                            CssClass="Error" Display="Dynamic" ErrorMessage="* Enter a number between 1-1000"
                            MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>

                            
    <div class="FieldStyle">Maximum Small Image Width<span class="Asterix">*</span></div>  
    <div class="HintStyle">Enter the maximum width in pixels a product picture will display on the Category Page (ex: 150).</div>                              
    <div class="ValueStyle"><asp:TextBox ID="txtMaxCatalogItemSmallWidth" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtMaxCatalogItemSmallWidth" ErrorMessage="* Enter Max Small Image Width" CssClass="Error" Display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtMaxCatalogItemSmallWidth"
                            CssClass="Error" Display="dynamic" ErrorMessage="*Enter a number between 1-1000"
                            MaximumValue="1000" MinimumValue="1" SetFocusOnError="true" Type="Integer"></asp:RangeValidator></div>
                            
    <div class="FieldStyle">Maximum Thumbnail Image Width<span class="Asterix">*</span></div> 
    <div class="HintStyle">Enter the maxiumum width in pixels a product picture will display the thumbnails on the Product Page (ex: 50).</div>                               
    <div class="ValueStyle"><asp:TextBox ID="txtMaxCatalogItemThumbnailWidth" runat="server" Width="152px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtMaxCatalogItemThumbnailWidth" ErrorMessage="* Enter Max Thumbnail Image Width" CssClass="Error" Display="dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtMaxCatalogItemThumbnailWidth"
                            CssClass="Error" Display="dynamic" ErrorMessage="*Enter a number between 1-1000"
                            MaximumValue="1000" MinimumValue="1" SetFocusOnError="true" Type="Integer"></asp:RangeValidator></div>
                           
 
 
    <h4>Shop By Price</h4>
    <p>
        The following settings control the "Shop by Price" search functionality. Based on the value entered below, a price range will be displayed for the user to select.<br /><br />
    </p>
    
    <div class="FieldStyle">Price Range Minimum<span class="Asterix">*</span></div>
    <div class="ValueStyle">$<asp:TextBox ID="txtShopByPriceMin" runat="server" Width="152px">0</asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtShopByPriceMin" ErrorMessage="* Enter Minimum Price" CssClass="Error" Display="dynamic"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtShopByPriceMin" CssClass="Error" Display="dynamic" ErrorMessage="*Enter a number between 0-10000" MaximumValue="10000" MinimumValue="0" SetFocusOnError="true" Type="Integer"></asp:RangeValidator></div> 
    
    <div class="FieldStyle">Price Range Maximum<span class="Asterix">*</span></div>
    <div class="ValueStyle">$<asp:TextBox ID="txtShopByPriceMax" runat="server" Width="152px">100</asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtShopByPriceMax" ErrorMessage="* Enter Maximum Price" CssClass="Error" Display="dynamic"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txtShopByPriceMax" CssClass="Error" Display="dynamic" ErrorMessage="*Enter a number between 1-10000" MaximumValue="10000" MinimumValue="1" SetFocusOnError="true" Type="Integer"></asp:RangeValidator></div> 
    
    <div class="FieldStyle">Price Increment<span class="Asterix">*</span></div>
    <div class="ValueStyle">$<asp:TextBox ID="txtShopByPriceIncrement" runat="server" Width="152px">20</asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtShopByPriceIncrement" ErrorMessage="* Enter Incremental Price" CssClass="Error" Display="dynamic"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txtShopByPriceIncrement" CssClass="Error" Display="dynamic" ErrorMessage="*Enter a number between 1-1000" MaximumValue="1000" MinimumValue="1" SetFocusOnError="true" Type="Integer"></asp:RangeValidator></div> 
    
  
    
    <h4>SMTP Mail Server Settings</h4>
    <p>
        The following settings are required to send email receipts and notifications from your storefront.<br /><br />
    </p>
    
    <div class="FieldStyle">SMTP Server</div>
    <div class="ValueStyle"><asp:TextBox ID="txtSMTPServer" runat="server" Width="152px"></asp:TextBox></div>

    <div class="FieldStyle">SMTP Server UserName</div>
    <div class="ValueStyle"><asp:TextBox ID="txtSMTPUserName" runat="server" Width="152px"></asp:TextBox></div>

    <div class="FieldStyle">SMTP Server Password</div>
    <div class="ValueStyle"><asp:TextBox ID="txtSMTPPassword" runat="server" Width="152px"></asp:TextBox></div>
    
    <h4>UPS Settings</h4>
    <p>
        Required to retrieve UPS shipping rates. You would need to signup for an API account with UPS.<br /><br />
    </p>
    
    <div class="FieldStyle">UPS User Name</div>
    <div class="ValueStyle"><asp:TextBox ID="txtUPSUserName" runat="server" Width="152px"></asp:TextBox></div>
 
    <div class="FieldStyle">UPS Password</div>
    <div class="ValueStyle"><asp:TextBox ID="txtUPSPassword" runat="server" Width="152px"></asp:TextBox></div>
    
    <div class="FieldStyle">UPS Access key</div>
    <div class="ValueStyle"><asp:TextBox ID="txtUPSKey" runat="server" Width="152px"></asp:TextBox></div>   
    
       
    <h4>FedEx Settings</h4>
    <p>
        Required to retrieve FedEx shipping rates. You would need to signup for an API account with FedEx.<br /><br />
    </p>
    
    <div class="FieldStyle">FedEx Account Number</div>
    <div class="ValueStyle"><asp:TextBox ID="txtAccountNum" runat="server" Width="152px"></asp:TextBox></div>
 
    <div class="FieldStyle">FedEx Meter Number</div>
    <div class="ValueStyle"><asp:TextBox ID="txtMeterNum" runat="server" Width="152px"></asp:TextBox></div>
    
    <div class="FieldStyle">FedEx Production key</div>
    <div class="ValueStyle"><asp:TextBox ID="txtProductionAccessKey" runat="server" Width="152px"></asp:TextBox></div>
    
    <div class="FieldStyle">FedEx Security Code</div>
    <div class="ValueStyle"><asp:TextBox ID="txtSecurityCode" runat="server" Width="152px"></asp:TextBox></div>
    
    <h4>Shipping Origin Settings</h4>
    
    <div class="FieldStyle">Shipping Origin Zip Code</div>
    <div class="ValueStyle"><asp:TextBox ID="txtShippingZipCode" runat="server" Width="152px"></asp:TextBox></div>
    
    <div class="FieldStyle">Shipping Origin State Code</div>
    <div class="ValueStyle"><asp:TextBox ID="txtShippingStateCode" runat="server" Width="152px"></asp:TextBox></div>
    
    <div class="FieldStyle">Shipping Origin Country Code</div>
    <div class="ValueStyle"><asp:TextBox ID="txtShippingCountryCode" runat="server" Width="152px"></asp:TextBox></div>
    
    <h4>Google Analytics Code</h4>
    <div class="FieldStyle">Enter the Google analytics code to insert into each page</div>
    <div class="ValueStyle"><asp:TextBox ID="txtgoogleanalytics" runat="server" Width="450px" TextMode="MultiLine" Height="150px"></asp:TextBox><br />
        &nbsp;</div>

    
    <div>
        <asp:button class="Button" id="btnSubmit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click"></asp:button>
        <asp:button class="Button" id="btnCancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
    </div>	
</div> 
</asp:Content>

