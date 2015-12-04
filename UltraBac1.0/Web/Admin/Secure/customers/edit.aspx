<%@ Page Language="C#" MasterPageFile="~/Admin/Themes/Standard/edit.master"  AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="Admin_Secure_customers_edit" %>

<%@ Register Src="~/Controls/DemoMode.ascx" TagName="DemoMode" TagPrefix="uc2" %>
<%@ Register TagPrefix="uc1" TagName="Spacer" Src="~/Controls/Spacer.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="uxMainContent">
<div class="Form">
        <table width="100%" cellSpacing="0" cellPadding="0">
		    <tr>
			    <td>
			        <h1>Edit Contact Information</h1>
                    <uc2:DemoMode ID="DemoMode1" runat="server" />			        
			    </td>
			    <td align="right">
				    <asp:button class="Button" id="btnSubmitTop" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click" ValidationGroup="EditContact"></asp:button>
				    <asp:button class="Button" id="btnCancelTop" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
			    </td>
		    </tr>
	    </table>
		 
	    <div>
	            <uc1:spacer id="Spacer8" SpacerHeight="2" SpacerWidth="3" runat="server"></uc1:spacer>
	    </div>
       
        <h4>
            General Information
        </h4>
       
        <div class="FieldStyle">Select Profile</div>
        <div class="HintStyle">Select a profile to which this customer belongs. For example if you select "Dealer" then the
        customer will see dealer specific promotions and options on the catalog when he signs in.</div>   
        <div class="ValueStyle">
                                <asp:DropDownList ID="ListProfileType" runat="server" Width="100px" />
        </div>  
        <div class="FieldStyle">Account Number</div> 
                    <div class="HintStyle">This is the account number in your internal accounting system that corresponds to this customer. Leave blank if you dont have one.</div>                              
                    <div class="ValueStyle">
                                <asp:TextBox ID="txtExternalAccNumber" runat="server" />
        </div>
        <table width="100%" border="0">
            <tr>
                <td>
                    <div  class="FieldStyle">Company Name</div>                        
                    <div class="ValueStyle">
                                <asp:TextBox ID="txtCompanyName" runat="server" />
                    </div>
                </td>
                <td>
                    <div  class="FieldStyle">Website</div>                        
                    <div class="ValueStyle">
                                <asp:TextBox ID="txtWebSite" runat="server" />
                    </div>                    
                </td>        
            </tr>
            
            <tr>
                <td>
                    <div  class="FieldStyle">Source</div>  
                    <div class="ValueStyle">
                                <asp:TextBox ID="txtSource" runat="server" />
                    </div>
                </td>
                <td>
                    <div  class="FieldStyle">Select Contact Status</div>  
                    <div class="ValueStyle">
                                <asp:DropDownList ID="ListContactStatus" runat="server" Width="100px" />
                    </div>
                </td>
            </tr>            
        </table>
              
        <uc1:spacer id="Spacer1" SpacerHeight="1" SpacerWidth="3" runat="server"></uc1:spacer>
        
        <table border="0" width="100%">
            <tr>
                <td>
                    <h4>Billing Address</h4>
    
                    <div class="FieldStyle">First Name<span class="Asterix">*</span></div>
                    <div class="ValueStyle">
	                                        <asp:textbox id="txtBillingFirstName" runat="server" width="130" columns="30" MaxLength="100" />
	                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Enter BillingFirstName" ControlToValidate="txtBillingFirstName" CssClass="Error" Display="Dynamic" ValidationGroup="EditContact"></asp:RequiredFieldValidator>
	                </div>
                    
                    <div class="FieldStyle">Last Name<span class="Asterix">*</span></div>
                    <div class="ValueStyle">
	                                        <asp:textbox id="txtBillingLastName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Enter Billing LastName" ControlToValidate="txtBillingLastName" CssClass="Error" Display="Dynamic" ValidationGroup="EditContact"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Error" DisplayMode="List" ForeColor=""
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="EditContact" />
	                </div>
                    
                    <div class="FieldStyle">Company Name</div>
                    <div class="ValueStyle">
	                                        <asp:textbox id="txtBillingCompanyName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	                </div>
            	    
                    <div class="FieldStyle">Phone Number<span class="Asterix">*</span></div>
                    <div class="ValueStyle">
	                                        <asp:textbox id="txtBillingPhoneNumber" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
	                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Enter Billing Phone Number" ControlToValidate="txtBillingPhoneNumber" CssClass="Error" Display="Dynamic" ValidationGroup="EditContact"></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="FieldStyle">Email Address<span class="Asterix">*</span></div>
                    <div class="ValueStyle">
                                            <asp:TextBox ID="txtBillingEmail" runat="server"></asp:TextBox>
                                            <asp:regularexpressionvalidator id="regemailID" runat="server" ControlToValidate="txtBillingEmail" ErrorMessage="*Please use a valid email address."
					                                Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" ValidationGroup="EditContact" CssClass="Error"></asp:regularexpressionvalidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Enter Email ID" ControlToValidate="txtBillingEmail" CssClass="Error" Display="Dynamic" ValidationGroup="EditContact"></asp:RequiredFieldValidator>
                    </div>
            		
	                <div class="FieldStyle">Street1</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtBillingStreet1" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
            	   
                    <div class="FieldStyle">Street2</div>
                    <div class="ValueStyle">
                                          <asp:textbox id="txtBillingStreet2" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                     </div>	               
                    
                    <div class="FieldStyle">City</div>
                    <div class="ValueStyle">
                                          <asp:textbox id="txtBillingCity" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
            	  
                    <div class="FieldStyle">State</div>
                    <div class="ValueStyle">
	                                      <asp:textbox id="txtBillingState" runat="server" width="30" columns="10" MaxLength="2"></asp:textbox>
                    </div>
                    <div class="FieldStyle">Postal Code</div>
                    <div class="ValueStyle">
                                         <asp:textbox id="txtBillingPostalCode" runat="server" width="130" columns="30" MaxLength="20"></asp:textbox>
                    </div>
            	  
                    <div class="FieldStyle">Country</div>
                    <div class="ValueStyle">
                                          <asp:DropDownList ID="lstBillingCountryCode" runat="server"></asp:DropDownList>
                    </div>                                 
                </td>
                
                <td>
                    <h4>Shipping Address</h4>
      
                    <div class="FieldStyle">First Name</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtShippingFirstName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div> 
                	  
                    <div class="FieldStyle">Last Name</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtShippingLastName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
                        
                    <div class="FieldStyle">Company Name</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtShippingCompanyName" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
                	  
                    <div class="FieldStyle">Phone Number</div>
                    <div class="ValueStyle">
                                           <asp:textbox id="txtShippingPhoneNumber" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
                	  
                    <div class="FieldStyle">Email Address</div>
                    <div class="ValueStyle">
                                           <asp:TextBox ID="txtShippingEmail" runat="server"></asp:TextBox>
                                           <asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="txtShippingEmail" ErrorMessage="*Please use a valid email address."
					                                            Display="Dynamic" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" ValidationGroup="EditContact" CssClass="Error"></asp:regularexpressionvalidator>
                    </div>	                      
                	       
                    <div class="FieldStyle">Street1</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtShippingStreet1" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
                	  
                    <div class="FieldStyle">Street2</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtShippingStreet2" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
                	  
                    <div class="FieldStyle">City</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtShippingCity" runat="server" width="130" columns="30" MaxLength="100"></asp:textbox>
                    </div>
                	  
                    <div class="FieldStyle">State</div>
                    <div class="ValueStyle">
	                                        <asp:textbox id="txtShippingState" runat="server" width="30" columns="10" MaxLength="2"></asp:textbox>
                    </div>
                	
                    <div class="FieldStyle">Postal Code</div>
                    <div class="ValueStyle">
                                            <asp:textbox id="txtShippingPostalCode" runat="server" width="130" columns="30" MaxLength="20"></asp:textbox>
                    </div>
                	  
                    <div class="FieldStyle">Country</div>
                    <div class="ValueStyle">
                                            <asp:DropDownList ID="lstShippingCountryCode" runat="server"></asp:DropDownList>
                    </div>
                </td>            
            </tr>
        </table>
         
	  
      <uc1:spacer id="Spacer2" SpacerHeight="1" SpacerWidth="3" runat="server"></uc1:spacer>
        
      
     
      <uc1:spacer id="Spacer5" SpacerHeight="1" SpacerWidth="3" runat="server"></uc1:spacer>
      
      <h4>Custom Information</h4>
      
      <div class="FieldStyle">Custom1</div>
      <div class="ValueStyle">
		                      <asp:textbox id="txtCustom1" runat="server" TextMode="MultiLine"  width="400" height="100" MaxLength="2"></asp:textbox>
      </div>
      <div class="FieldStyle">Custom2</div>
      <div class="ValueStyle">
		                      <asp:textbox id="txtCustom2" runat="server" TextMode="MultiLine"  width="400" height="100" MaxLength="2"></asp:textbox>
      </div>
      <div class="FieldStyle">Custom3</div>
      <div class="ValueStyle">
		                      <asp:textbox id="txtCustom3" runat="server" TextMode="MultiLine"  width="400" height="100" MaxLength="2"></asp:textbox>
      </div>
      
      <uc1:spacer id="Spacer4" SpacerHeight="1" SpacerWidth="3" runat="server"></uc1:spacer>
        
      <h4>Description</h4>
        
      <div class="FieldStyle">
                              <asp:textbox id="txtDescription" runat="server" TextMode="MultiLine"  width="400" height="200" MaxLength="2" />
      </div>
                      
       <uc1:spacer id="Spacer3" SpacerHeight="10" SpacerWidth="3" runat="server"></uc1:spacer>
        
       <table>
                <tr>
                     <td align="right">
				                         <asp:button class="Button" id="Submit" CausesValidation="True" Text="SUBMIT" Runat="server" onclick="btnSubmit_Click" ValidationGroup="EditContact"></asp:button>
				                         <asp:button class="Button" id="Cancel" CausesValidation="False" Text="CANCEL" Runat="server" onclick="btnCancel_Click"></asp:button>
			         </td>
                </tr>
       </table>
         
</div> 
</asp:Content>


