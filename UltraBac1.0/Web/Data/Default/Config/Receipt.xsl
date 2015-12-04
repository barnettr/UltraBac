<?xml version="1.0" encoding="iso-8859-1" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="Order">
<html>
<head>
    <title>Customer Receipt</title>
	  <STYLE type="text/css">
      .Head{background-color: #C5CADD; font-size: 1.5em; font-weight: bold; padding: .5em; border-bottom: solid 1px #B3B2B2; }
      .SubHead{color: #BC151B;font-weight: bold; font-size: 11px; padding-bottom:5px; }
      td{font-family: Verdana, Helvetica, sans-serif; color: #333333;font-size: 10px;}
      .Product table td {border:silver 1px solid;}
    </STYLE>
</head>
	<body>

    <div style="background:#efefef;width:935px;font-family: Arial, Helvetica; font-size: 10px; text-align: left; color: Black; border: solid 1px #B3B2B2;">
		<div class="Head"><xsl:value-of select="SiteName" />&#160;Customer Receipt</div>
        <div style="padding:10px;">
            <div style="padding: 0 0 1.5em 0">
                <xsl:value-of select="ReceiptText" />
            </div>

            <div class="hr"></div>
            <div class="margin_bottom" style="width: 600px;">
                <div class="floatleft">
                    <div class="SubHead">Order Information</div>

                    <strong>Order Number:</strong>

                    <xsl:value-of select="OrderId" />
                    <br />

                    <strong>Order Date:</strong >

                    <xsl:value-of select="OrderDate" />
                    <br />
                    <strong>Account Number:</strong>

                    <xsl:value-of select="AccountId" />
                    <br />
                    <strong>Payment Method:</strong>

                    <xsl:value-of select="PaymentName" />
                </div>
                <div class="floatright align_right">
                    <div class="SubHead">Customer Service</div>
                    <strong>Email:</strong>

                    <xsl:value-of select="CustomerServiceEmail" />
                    <br />
                    <strong>Phone:</strong>

                    <xsl:value-of select="CustomerServicePhoneNumber" />
                </div>
                <div class="clear"></div>
                <div class="hr"></div>
                <div class="floatleft">
                    <div class="SubHead">Billing Address</div>
                    <xsl:value-of select="BillingAddressFirstName" />&#160;<xsl:value-of select="BillingAddressLastName" />
                    <br />
                    <xsl:value-of select="BillingAddressStreet1" />&#160;<xsl:value-of select="BillingAddressStreet2" />
                    <br />
                    <xsl:value-of select="BillingAddressCity" />, <xsl:value-of select="BillingAddressStateCode" />&#160;<xsl:value-of select="BillingAddressPostalCode" />
                    <br />
                    <xsl:value-of select="BillingAddressCountryCode" />
                    <br />
                    Tel:&#160;<xsl:value-of select="BillingAddressPhoneNumber" />
                </div>
                <div class="floatright align_right">
                    <div class="SubHead">Shipping Address</div>
                    <xsl:value-of select="ShippingAddressFirstName" />&#160;<xsl:value-of select="ShippingAddressLastName" />
                    <br />
                    <xsl:value-of select="ShippingAddressStreet1" />&#160;<xsl:value-of select="ShippingAddressStreet2" />
                    <br />
                    <xsl:value-of select="ShippingAddressCity" />, <xsl:value-of select="ShippingAddressStateCode" />&#160;<xsl:value-of select="ShippingAddressPostalCode" />
                    <br />
                    <xsl:value-of select="ShippingAddressCountryCode" />
                    <br />
                    Tel:&#160;<xsl:value-of select="ShippingAddressPhoneNumber" />

                </div>
                <div class="clear"></div>

            </div>

          <table cellpadding="0" cellspacing="3" border="0" width="96%">
				    <tr>
					    <td colspan="5" class="Product">
						    <table cellpadding="3" cellspacing="0" width="100%">
							    <tr bgcolor="silver">
								    <td align="center">
									    <strong>Qty</strong>
								    </td>
								    <td>
									    <strong>SKU</strong>
								    </td>
                    <td align="left">
                      <strong>Style</strong>
                    </td>
                    <td align="left">
                      <strong>Description</strong>
                    </td>
								    <td align="left">
									    <strong>Price</strong>
								    </td>
								    <td align="left">
									    <strong>Ext.</strong>
								    </td>
							    </tr>
							    <xsl:for-each select="Items/Item">
								    <tr>
									    <td align="center" style="width:5px;">
                        <xsl:value-of select="Quantity" />
									    </td>
									    <td align="left" style="width:10px;">
										    <xsl:value-of select="SKU" />&#160;
									    </td>
									    <td align="left" style="width:180px;">
										    <xsl:value-of select="Name" />
									    </td>	
									    <td align="left" style="width:220px;">
										    <xsl:value-of disable-output-escaping="yes" select="Description" />                        					
                        <xsl:value-of disable-output-escaping="yes" select="OptionValueDescription"/>&#160;
									    </td>

									    <td align="right" style="width:15px;">
                        <xsl:value-of select="Price" />
                      </td>
                      <td align="right" style="width:50px;">
                        <xsl:value-of select="Extended" />                        
									    </td>
								    </tr>
							    </xsl:for-each >
                  <tr>
                    <td colspan="3" style="border:none;"></td>
                    <td colspan="2" style="border:none;" align="right">
                      <strong>Sub Total</strong>
                    </td>
                    <td align="right">
                      <xsl:value-of select="SubTotal" />
                    </td>
                  </tr>
                  <tr>                    
                    <td colspan="5" style="border:none;" align="right">
                      <strong>Discount</strong>
                    </td>
                    <td align="right">
                      <xsl:value-of select="DiscountAmount" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="5" style="border:none;" align="right">
                      <strong>Tax</strong>
                    </td>
                    <td align="right">
                      <xsl:value-of select="TaxCost" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="5" style="border:none;" align="right">
                      <strong>
                        Shipping (<xsl:value-of select="ShippingName" />)
                      </strong>
                    </td>
                    <td align="right">
                      <xsl:value-of select="ShippingCost" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="5" style="border:none;" align="right">
                      <div class="SubHead">Total</div>
                    </td>
                    <td align="right">
                      <strong>
                        <xsl:value-of select="TotalCost" />
                      </strong>
                    </td>                    
                  </tr>
                 </table>
              </td>
            </tr>
            <tr>
              <td colspan="5" align="left" nowrap="true">
                <div class="SubHead">Additional Instructions</div>
              </td>
            </tr>
            <tr>
              <td colspan="5">
                <div align="justify">
                  <xsl:value-of select="AdditionalInstructions"/>
                </div>
              </td>
            </tr>
          </table>            
      </div>
    </div>
</body>
</html>
</xsl:template>
</xsl:stylesheet>