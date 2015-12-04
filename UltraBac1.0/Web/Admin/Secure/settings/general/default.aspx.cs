using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Admin;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Entities;


public partial class Admin_Secure_settings_storesettings : System.Web.UI.Page
{
    #region Bind Data
    /// <summary>
    /// Bind data to form fields
    /// </summary>
    private void BindData()
    {
        StoreSettingsAdmin storeAdmin = new StoreSettingsAdmin();
        Portal portal = storeAdmin.GetByPortalId(ZNodeConfigManager.SiteConfig.PortalID);

        txtDomainName.Text = portal.DomainName;
        txtCompanyName.Text = portal.CompanyName;
        txtStoreName.Text = portal.StoreName;
        chkEnableSSL.Checked = portal.UseSSL;
        txtAdminEmail.Text = portal.AdminEmail;
        txtSalesEmail.Text = portal.SalesEmail;
        txtCustomerServiceEmail.Text = portal.CustomerServiceEmail;
        txtSalesPhoneNumber.Text = portal.SalesPhoneNumber;
        txtCustomerServicePhoneNumber.Text = portal.CustomerServicePhoneNumber;
        txtMaxCatalogDisplayColumns.Text = portal.MaxCatalogDisplayColumns.ToString();
        txtMaxCatalogDisplayItems.Text = portal.MaxCatalogDisplayItems.ToString();

        txtMaxCatalogItemLargeWidth.Text = portal.MaxCatalogItemLargeWidth.ToString();
        txtMaxCatalogItemMediumWidth.Text = portal.MaxCatalogItemMediumWidth.ToString();
        txtMaxCatalogItemSmallWidth.Text = portal.MaxCatalogItemSmallWidth.ToString();
        txtMaxCatalogItemThumbnailWidth.Text = portal.MaxCatalogItemThumbnailWidth.ToString();

        txtShopByPriceMax.Text = portal.ShopByPriceMax.ToString();
        txtShopByPriceMin.Text = portal.ShopByPriceMin.ToString();
        txtShopByPriceIncrement.Text = portal.ShopByPriceIncrement.ToString();


        if (portal.BottomScriptBlock != null)
        {
            txtgoogleanalytics.Text = portal.BottomScriptBlock.ToString();
        }

        ZNodeEncryption encrypt = new ZNodeEncryption();

        if (portal.SMTPServer != null)
        {
            txtSMTPServer.Text = portal.SMTPServer;
        }
        if (portal.SMTPUserName != null)
        {
            txtSMTPUserName.Text = encrypt.DecryptData(portal.SMTPUserName);
        }
        if (portal.SMTPPassword != null)
        {
            txtSMTPPassword.Text = encrypt.DecryptData(portal.SMTPPassword);
        }

        //Set UPS Account details
        if (portal.UPSUserName != null)
        {
            txtUPSUserName.Text = encrypt.DecryptData(portal.UPSUserName);
        }
        if (portal.UPSPassword != null)
        {
            txtUPSPassword.Text = encrypt.DecryptData(portal.UPSPassword);
        }
        if (portal.UPSKey != null)
        {
            txtUPSKey.Text = encrypt.DecryptData(portal.UPSKey);
        }
        txtShippingZipCode.Text = portal.ShippingOriginZipCode;
        txtShippingStateCode.Text = portal.ShippingOriginStateCode;
        txtShippingCountryCode.Text = portal.ShippingOriginCountryCode;


        //Bind FedEx Account details
        if(portal.FedExAccountNumber !=null)
            txtAccountNum.Text = encrypt.DecryptData(portal.FedExAccountNumber);
        if (portal.FedExMeterNumber != null)
            txtMeterNum.Text = encrypt.DecryptData(portal.FedExMeterNumber);
        if (portal.FedExProductionKey != null)
            txtProductionAccessKey.Text = encrypt.DecryptData(portal.FedExProductionKey);
        if (portal.FedExSecurityCode != null)
            txtSecurityCode.Text = encrypt.DecryptData(portal.FedExSecurityCode);

        //set logo image
        imgLogo.ImageUrl = portal.LogoPath;
    }
    #endregion
    
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    /// <summary>
    /// Submit button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        StoreSettingsAdmin storeAdmin = new StoreSettingsAdmin();
        Portal portal = storeAdmin.GetByPortalId(ZNodeConfigManager.SiteConfig.PortalID);

        //portal.DomainName = txtDomainName.Text;
        portal.AdminEmail = txtAdminEmail.Text;
        portal.CompanyName = txtCompanyName.Text;
        portal.CustomerServiceEmail = txtCustomerServiceEmail.Text;
        portal.CustomerServicePhoneNumber = txtCustomerServicePhoneNumber.Text;
        portal.DomainName = txtDomainName.Text;
        portal.MaxCatalogDisplayColumns = byte.Parse(txtMaxCatalogDisplayColumns.Text);
        portal.MaxCatalogDisplayItems = int.Parse(txtMaxCatalogDisplayItems.Text);

        portal.MaxCatalogItemThumbnailWidth = int.Parse(txtMaxCatalogItemThumbnailWidth.Text);       
        portal.BottomScriptBlock = txtgoogleanalytics.Text;

        portal.MaxCatalogItemLargeWidth = int.Parse(txtMaxCatalogItemLargeWidth.Text);
        portal.MaxCatalogItemMediumWidth = int.Parse(txtMaxCatalogItemMediumWidth.Text);
        portal.MaxCatalogItemSmallWidth = int.Parse(txtMaxCatalogItemSmallWidth.Text);
        portal.MaxCatalogItemThumbnailWidth = int.Parse(txtMaxCatalogItemThumbnailWidth.Text);

        portal.ShopByPriceMin = int.Parse(txtShopByPriceMin.Text);
        portal.ShopByPriceMax = int.Parse(txtShopByPriceMax.Text);
        portal.ShopByPriceIncrement = int.Parse(txtShopByPriceIncrement.Text);

        portal.SalesEmail = txtSalesEmail.Text;
        portal.SalesPhoneNumber = txtSalesPhoneNumber.Text;
        portal.StoreName = txtStoreName.Text;
        portal.UseSSL = chkEnableSSL.Checked;

        ZNodeEncryption encrypt = new ZNodeEncryption();

        //SMTP Server Settings
        portal.SMTPServer = txtSMTPServer.Text;
        portal.SMTPUserName = encrypt.EncryptData(txtSMTPUserName.Text);
        portal.SMTPPassword = encrypt.EncryptData(txtSMTPPassword.Text);
        
        //UPS Shipping Settings
        portal.UPSUserName = encrypt.EncryptData(txtUPSUserName.Text.Trim());
        portal.UPSPassword = encrypt.EncryptData(txtUPSPassword.Text.Trim());
        portal.UPSKey = encrypt.EncryptData(txtUPSKey.Text.Trim());
        
        //FedEx Shipping Settings
        portal.FedExAccountNumber = encrypt.EncryptData(txtAccountNum.Text.Trim());
        portal.FedExMeterNumber = encrypt.EncryptData(txtMeterNum.Text.Trim());
        portal.FedExProductionKey = encrypt.EncryptData(txtProductionAccessKey.Text.Trim());
        portal.FedExSecurityCode = encrypt.EncryptData(txtSecurityCode.Text.Trim());

        //Shipping origin Settings
        portal.ShippingOriginZipCode = txtShippingZipCode.Text.Trim();
        portal.ShippingOriginStateCode = txtShippingStateCode.Text.Trim();
        portal.ShippingOriginCountryCode = txtShippingCountryCode.Text.Trim();

        //set logo path
        System.IO.FileInfo _FileInfo = null;
        
        if (radNewImage.Checked == true)
        {
            //Check for Product Image
            _FileInfo = new System.IO.FileInfo(UploadImage.PostedFile.FileName);

            if (_FileInfo != null)
            {
                if ((_FileInfo.Extension == ".jpeg") || (_FileInfo.Extension.Equals(".jpg")) || (_FileInfo.Extension.Equals(".png")) || (_FileInfo.Extension.Equals(".gif")))
                {
                    portal.LogoPath = ZNodeConfigManager.EnvironmentConfig.ContentPath + _FileInfo.Name;
                    UploadImage.SaveAs(Server.MapPath(ZNodeConfigManager.EnvironmentConfig.ContentPath + _FileInfo.Name));
                }
                else
                {
                    lblImageError.Text = "Select a valid jpg, gif or png image.";
                    return;
                }
            }
        }

        bool ret = storeAdmin.Update(portal);

        //remove the siteconfig from session
        ZNodeConfigManager.SiteConfig = null;

        if (!ret)
        {
            lblMsg.Text = "An error ocurred while updating the store settings. Please try again.";
        }
        else
        {
            Response.Redirect("~/admin/secure/default.aspx");
        }
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/secure/default.aspx");
    }

    protected void radCurrentImage_CheckedChanged(object sender, EventArgs e)
    {
        tblLogoUpload.Visible = false;
    }

    protected void radNewImage_CheckedChanged(object sender, EventArgs e)
    {
        tblLogoUpload.Visible = true;
    }
    #endregion
}
