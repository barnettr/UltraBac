using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    /// <summary>
    /// Represents a product in the catalog
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [Serializable()]
    [XmlRoot("ZNodeProduct")]
    public class ZNodeProduct : ZNodeBusinessBase
    {
        #region Private Variables
        private int _ProductID = 0;
        private int _PortalID = 0;
        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private string _FeaturesDesc = string.Empty;
        private string _ProductNum = string.Empty;
        private int _ProductTypeID;
        private decimal _RetailPrice;
        private decimal _WholesalePrice;
        private string _ImageFile;
        private decimal _Weight;
        private bool _IsActive;
        private int _DisplayOrder;
        private string _Custom1 = string.Empty;
        private string _Custom2 = string.Empty;
        private string _ShortDesc = string.Empty;
        private bool _CallForPricing;
        private string _CallMessage = string.Empty;
        private bool _HomepageSpecial;
        private bool _CategorySpecial;
        private bool _Hide;
        private int _InventoryDisplay;
        private string _Keywords = string.Empty;
        private int _ManufacturerID;
        private string _ManufacturerPartNum = string.Empty;
        private string _AdditionalInfoLink = string.Empty;
        private string _AdditionalInfoLinkLabel = string.Empty;
        private int? _ShippingRuleTypeID;
        private string _Specifications = string.Empty;
        private string _AdditionalInformation = string.Empty;
        private string _BackOrderMsg = string.Empty;
        private string _InStockMsg = string.Empty;
        private string _OutOfStockMsg = string.Empty;
        private decimal _SalePrice;
        private string _SEOTitle = string.Empty;
        private string _SEOKeywords = string.Empty;
        private string _SEODescription = string.Empty;
        private string _addOnDescription = string.Empty;
        private bool _TrackInventoryInd;
        private bool _AllowBackOrder;
        private int _QuantityOnHand;
        private string _sku = String.Empty;
        private const string _productPageFormat = "~/product.aspx?pid={0}";
        private static int _fileByFilePageID;
        private static int _bareMetalDisasterRecoveryPageID;
				private static int _fileByFileCategoryID;
				private static int _bareMetalDisasterRecoveryCategoryID;
        #endregion

        #region Private MemberObjects
        private ZNodeGenericCollection<ZNodeHighlight> _highlightCollection = new ZNodeGenericCollection<ZNodeHighlight>();
        private ZNodeGenericCollection<ZNodeCrossSellItem> _crossSellItemCollection = new ZNodeGenericCollection<ZNodeCrossSellItem>();
        private ZNodeGenericCollection<ZNodeAttributeType> _attributeTypeCollection = new ZNodeGenericCollection<ZNodeAttributeType>();
        private ZNodeGenericCollection<ZNodeAddOn> _addOnCollection = new ZNodeGenericCollection<ZNodeAddOn>();
        private ZNodeAddOnList _selectedAddOnCollection = new ZNodeAddOnList();
        private ZNodeSKU _selectedSKU = new ZNodeSKU() ;
        #endregion

        #region Public Properties
        
        /// <summary>
        /// Collection of product highlights related with this product
        /// </summary>
        [XmlElement("ZNodeHighlight")]
        public ZNodeGenericCollection<ZNodeHighlight> ZNodeHighlightCollection
        {
            get
            {
                return _highlightCollection;
            }
            set
            {
                _highlightCollection = value;
            }
        }

        /// <summary>
        /// Collection of related products contained for this product
        /// </summary>
        [XmlElement("ZNodeCrossSellItem")]
        public ZNodeGenericCollection<ZNodeCrossSellItem> ZNodeCrossSellItemCollection
        {
            get
            {
                return _crossSellItemCollection;
            }
            set
            {
                _crossSellItemCollection = value;
            }
        }

        /// <summary>
        /// Collection of product addons  for this product
        /// </summary>
        [XmlElement("ZNodeAddOn")]
        public ZNodeGenericCollection<ZNodeAddOn> ZNodeAddOnCollection
        {
            get
            {
                return _addOnCollection;
            }
            set
            {
                _addOnCollection = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product Add-on selected by the user for this product
        /// </summary>
        [XmlIgnore()]
        public ZNodeAddOnList SelectedAddOnItems
        {
            get
            {
                return _selectedAddOnCollection;
            }
            set
            {
                _selectedAddOnCollection = value;
            }
        }

        /// <summary>
        /// Collection of product attributetypes for this product
        /// </summary>
        [XmlElement("ZNodeAttributeType")]
        public ZNodeGenericCollection<ZNodeAttributeType> ZNodeAttributeTypeCollection
        {
            get
            {
                return _attributeTypeCollection;
            }
            set
            {
                _attributeTypeCollection = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product SKU selected by the user
        /// </summary>
        [XmlElement("ZNodeSKU")]
        public ZNodeSKU SelectedSKU
        {
            get
            {
                return _selectedSKU;
            }
            set
            {
                _selectedSKU = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the ProductID
        /// </summary>
        [XmlElement()]
        public int ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }

        /// <summary>
        /// Returns fully qualified link to product details page
        /// </summary>
				[XmlIgnore()]
				public string ViewProductLink
				{
					get
					{
						return string.Format(_productPageFormat, ProductID.ToString());
					}
				}

        /// <summary>
        /// Retrieves or sets the site portal id
        /// </summary>
        [XmlElement()]
        public int PortalID
        {
            get
            {
                return _PortalID;
            }
            set
            {
                _PortalID = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product Name
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product description
        /// </summary>
        [XmlElement()]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product features
        /// </summary>
        [XmlElement()]
        public string FeaturesDesc
        {
            get
            {
                return _FeaturesDesc;
            }
            set
            {
                _FeaturesDesc = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product code
        /// </summary>
        [XmlElement()]
        public string ProductNum
        {
            get
            {
                return _ProductNum;
            }
            set
            {
                _ProductNum = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product type id
        /// </summary>
        [XmlElement()]
        public int ProductTypeID
        {
            get
            {
                return _ProductTypeID;
            }
            set
            {
                _ProductTypeID = value;
            }
        }

        /// <summary>
        /// Returns the retail price. Will return the SKU override retail price if one exists.
        /// Also return the AddOn override retail price additional if one exists
        /// </summary>
        [XmlElement()]
        public decimal RetailPrice
        {
            get
            {
                decimal additionalAddOnRetailPrice = _selectedAddOnCollection.RetailPriceAdditional;
                decimal additionalSKURetailPrice = _selectedAddOnCollection.RetailPriceAdditional;

                //if a sku and Add-on(product options)override exists then use that price                
                return _RetailPrice + _selectedSKU.RetailPriceAdditional + additionalAddOnRetailPrice;
                
            }
            set
            {
                _RetailPrice = value;
            }
        }

        /// <summary>
        /// Returns the wholesale price. Will return the SKU override wholesale price if one exists.
        /// </summary>
        [XmlElement()]
        public decimal WholesalePrice
        {
            get
            {
                decimal additionalAddOnRetailPrice = _selectedAddOnCollection.RetailPriceAdditional;
                decimal additionalSKURetailPrice = _selectedAddOnCollection.RetailPriceAdditional;

                //if Addons and sku override exists then use that price                
                return _WholesalePrice + additionalSKURetailPrice + additionalAddOnRetailPrice;                
            }
            set
            {
                _WholesalePrice = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the product sale price as a decimal value
        /// </summary>
        [XmlElement()]
        public decimal SalePrice
        {
            get
            {
                decimal additionalRetailPrice = _selectedAddOnCollection.RetailPriceAdditional;
                decimal additionalSKURetailPrice = _selectedSKU.RetailPriceAdditional;

                //if Addons and sku override exists then use that price with Sale price
                return _SalePrice + additionalRetailPrice + additionalSKURetailPrice;
                
            }
            set
            {
                _SalePrice = value;
            }
        }

        /// <summary>
        /// Returns the final calculated price for a product
        /// </summary>
        [XmlIgnore()]
        public decimal FinalPrice
        {
            get
            {
                if (_SalePrice == 0)
                {                   
                    return RetailPrice;                 
                }
                else
                {
                    return SalePrice;
                }
            }
        }

        /// <summary>
        /// Returns the final calculated price for a product without add-ons additional price
        /// Return the SKU override addiotnal retail price if one exists
        /// </summary>
        [XmlIgnore()]
        public decimal ActualProductPrice
        {
            get
            {
                if (_SalePrice == 0)
                {
                                       
                    decimal additionalSKURetailPrice = _selectedSKU.RetailPriceAdditional;

                    //if a sku override exists then use that price
                    if (additionalSKURetailPrice > 0)
                    {
                        return _RetailPrice + additionalSKURetailPrice;
                    }

                    return _RetailPrice;
                    
                }
                else
                {
                    return _SalePrice + _selectedSKU.RetailPriceAdditional;
                }
            }
        }

        /// <summary>
        /// Returns the image file name for this product. Will return the SKU picture override if one exists.
        /// </summary>
        [XmlElement()]
        public string ImageFile
        {
            get
            {               
                //if a sku image override exists then use that image
                if (_selectedSKU.SKUPicturePath.Trim().Length > 0)
                {
                    return _selectedSKU.SKUPicturePath;
                }
                else
                {
                    return _ImageFile;
                }
            }
            set
            {
                _ImageFile = value;
            }
        }

        ///// <summary>
        ///// Returns fully qualified image file path
        ///// </summary>
        //[XmlIgnore()]
        //public string ImageFilePath
        //{
        //    get
        //    {
        //        System.Text.StringBuilder _catalogImagePath = new StringBuilder();
        //        _catalogImagePath.Append(ZNodeConfigManager.EnvironmentConfig.CatalogImagePath);
        //        _catalogImagePath.Append(ImageFile);

        //        return _catalogImagePath.ToString();
        //    }
        //}

        [XmlIgnore()]
        public string LargeImageFilePath
        {
            get
            {
                System.Text.StringBuilder _catalogImagePath = new StringBuilder();
                _catalogImagePath.Append(ZNodeConfigManager.EnvironmentConfig.LargeImagePath);
                _catalogImagePath.Append(ImageFile);

                return _catalogImagePath.ToString();
            }
        }
        [XmlIgnore()]
        public string MediumImageFilePath
        {
            get
            {
                System.Text.StringBuilder _catalogImagePath = new StringBuilder();
                _catalogImagePath.Append(ZNodeConfigManager.EnvironmentConfig.MediumImagePath);
                _catalogImagePath.Append(ImageFile);

                return _catalogImagePath.ToString();
            }
        }
        [XmlIgnore()]
        public string SmallImageFilePath
        {
            get
            {
                System.Text.StringBuilder _catalogImagePath = new StringBuilder();
                _catalogImagePath.Append(ZNodeConfigManager.EnvironmentConfig.SmallImagePath);
                _catalogImagePath.Append(ImageFile);

                return _catalogImagePath.ToString();
            }
        }
        [XmlIgnore()]
        public string ThumbnailImageFilePath
        {
            get
            {
                System.Text.StringBuilder _catalogImagePath = new StringBuilder();
                _catalogImagePath.Append(ZNodeConfigManager.EnvironmentConfig.ThumbnailImagePath);
                _catalogImagePath.Append(ImageFile);

                return _catalogImagePath.ToString();
            }
        }

        /// <summary>
        /// Stores metadata on this product (Addon selection values, etc)
        /// This metadata is displayed on the shopping cart list
        /// This property is set explicily by the UI and is not retrieved automatically
        /// </summary>
        [XmlIgnore()]
        public string AddOnDescription
        {
            get { return _addOnDescription; }
            set { _addOnDescription = value; }
        }

        /// <summary>
        /// Retrieves or sets the weight of this product 
        /// </summary>
        [XmlElement()]
        public decimal Weight
        {
            get
            {
                decimal additionalWeight = _selectedAddOnCollection.WeightAdditional;
                //if a Add-on(product options) override exists then use that weight
                if (additionalWeight > 0)
                {
                    return _Weight + additionalWeight;
                }
                else
                {
                    return _Weight;
                }
            }
            set
            {
                _Weight = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the Active property as a boolean value
        /// </summary>
        [XmlElement()]
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the display order for this product
        /// </summary>
        [XmlElement()]
        public int DisplayOrder
        {
            get
            {
                return _DisplayOrder;
            }
            set
            {
                _DisplayOrder = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the custom comments for this product
        /// </summary>
        [XmlElement()]
        public string Custom1
        {
            get
            {
                return _Custom1;
            }
            set
            {
                _Custom1 = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the custom comments for this product
        /// </summary>
        [XmlElement()]
        public string Custom2
        {
            get
            {
                return _Custom2;
            }
            set
            {
                _Custom2 = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the custom comments for this product
        /// </summary>
        [XmlElement()]
        public string ShortDescription
        {
            get
            {
                return _ShortDesc;
            }
            set
            {
                _ShortDesc = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the CallForPricing property for this product
        /// </summary>
        [XmlElement()]
        public bool CallForPricing
        {
            get
            {
                return _CallForPricing;
            }
            set
            {
                _CallForPricing = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the call for pricing text message
        /// </summary>
        public string CallMessage
        {
            get
            {
                return _CallMessage;
            }
            set
            {
                _CallMessage = value;
            }
        }

        /// <summary>
        /// Retrieves or sets to HomepageSpecial property
        /// </summary>
        [XmlElement()]
        public bool HomepageSpecial
        {
            get
            {
                return _HomepageSpecial;
            }
            set
            {
                _HomepageSpecial = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the CategorySpecial property
        /// </summary>
        [XmlElement()]
        public bool CategorySpecial
        {
            get
            {
                return _CategorySpecial;
            }
            set
            {
                _CategorySpecial = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the Hide option
        /// </summary>
        [XmlElement()]
        public bool Hide
        {
            get
            {
                return _Hide;
            }
            set
            {
                _Hide = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the inventory display value for this product
        /// </summary>
        [XmlElement()]
        public int InventoryDisplay
        {
            get
            {
                return _InventoryDisplay;
            }
            set
            {
                _InventoryDisplay = value;
            }
        }

        /// <summary>        
        /// Sets or retrieves the manufacturerid for this product        
        /// </summary>
        [XmlElement()]
        public int ManufacturerID
        {
            get
            {
                return _ManufacturerID;
            }
            set
            {
                _ManufacturerID = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the manufacturer part number for this product
        /// </summary>
        [XmlElement()]
        public string ManufacturerPartNum
        {
            get
            {
                return _ManufacturerPartNum;
            }
            set
            {
                _ManufacturerPartNum = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the additional information link for this product
        /// </summary>
        [XmlElement()]
        public string AdditionalInfoLink
        {
            get
            {
                return _AdditionalInfoLink;
            }
            set
            {
                _AdditionalInfoLink = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the additional link labale text for this product
        /// </summary>
        [XmlElement()]
        public string AdditionalInfoLinkLabel
        {
            get
            {
                return _AdditionalInfoLinkLabel;
            }
            set
            {
                _AdditionalInfoLinkLabel = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the ShippingRuleTypeID for this product
        /// </summary>
        [XmlElement()]
        public int? ShippingRuleTypeID
        {
            get
            {
                return _ShippingRuleTypeID;
            }
            set
            {
                _ShippingRuleTypeID = value;
            }
        }
        /// <summary>
        /// Sets or retrieves the SEO Keywords
        /// </summary>
        [XmlElement()]
        public string SEOKeywords
        {
            get
            {
                return _SEOKeywords;
            }
            set
            {
                _SEOKeywords = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the SEO Title
        /// </summary>
        [XmlElement()]
        public string SEOTitle
        {
            get
            {
                return _SEOTitle;
            }
            set
            {
                _SEOTitle = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the SEO Description
        /// </summary>
        [XmlElement()]
        public string SEODescription
        {
            get
            {
                return _SEODescription;
            }
            set
            {
                _SEODescription = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the Specification
        /// </summary>
        [XmlElement()]
        public string Specifications
        {
            get
            {
                return _Specifications;
            }
            set
            {
                _Specifications = value;
            }
        }


        /// <summary>
        /// Sets or retrieves the Additional Information
        /// </summary>
        [XmlElement()]
        public string AdditionalInformation
        {
            get
            {
                return _AdditionalInformation;
            }
            set
            {
                _AdditionalInformation = value;
            }
        }


        /// <summary>
        /// Retrieves or sets the BackOrder Message
        /// </summary>
        [XmlElement()]
        public string BackOrderMsg
        {
            get
            {
                return _BackOrderMsg;
            }
            set
            {
                _BackOrderMsg = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the InStock Message
        /// </summary>
        [XmlElement()]
        public string InStockMsg
        {
            get
            {
                return _InStockMsg;
            }
            set
            {
                _InStockMsg = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the OutOfStock Message
        /// </summary>
        [XmlElement()]
        public string OutOfStockMsg
        {
            get
            {
                return _OutOfStockMsg;
            }
            set
            {
                _OutOfStockMsg = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the TrackInventoryInd property for this product
        /// </summary>
        [XmlElement()]
        public bool TrackInventoryInd
        {
            get
            {
                return _TrackInventoryInd;
            }
            set
            {
                _TrackInventoryInd = value;
            }
        }

           /// <summary>
        /// Retrieves or sets the AllowBackOrder property for this product
        /// </summary>
        [XmlElement()]
        public bool AllowBackOrder
        {
            get
            {
                return _AllowBackOrder;
            }
            set
            {
                _AllowBackOrder = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the SKU for this product
        /// It will return the SKU override if one exists.
        /// </summary>
        [XmlElement()]
        public string SKU
        {
            get
            {
                if (_selectedSKU.SKUID > 0)
                {
                    return _selectedSKU.SKU;
                }
                else
                {
                    return _sku;
                }
            }
            set
            {
                _sku = value;
            }
        }

        /// <summary>
        /// Retrieves or sets the QuantityOnHand for this product
        /// It will return the SKU Quantity Available if one exists
        /// </summary>
        [XmlElement()]
        public int QuantityOnHand
        {
            get
            {
                if (_selectedSKU.SKUID > 0)
                {
                    return _selectedSKU.QuantityOnHand;
                }
                else
                {
                    return _QuantityOnHand;
                }
            }
            set
            {
                _QuantityOnHand = value;
            }
        }

				/// <summary>
				/// Use the FeaturesDesc field from the database to store Purchase information
				/// </summary>
				public string PurchaseInformation
				{
					get { return this.FeaturesDesc; }
					set { this.FeaturesDesc = value; }
				}

				/// <summary>
				/// Use the Specifications field from the database to store Licensing information
				/// </summary>
				public string LicensingInformation
				{
					get { return this.Specifications; }
					set { this.Specifications = value; }
				}

				/// <summary>
				/// Use the AdditionalInformation field from the database to store Upgrade information
				/// </summary>
				public string UpgradeInformation
				{
					get { return this.AdditionalInformation; }
					set { this.AdditionalInformation = value; }
				}

				/// <summary>
				/// Use the Custom1 field from the database to store maintenance information
				/// </summary>
				public string MaintenanceInformation
				{
					get { return this.Custom1; }
					set { this.Custom1 = value; }
				}

        #endregion

        #region Constructors

        static ZNodeProduct()
        {
            try
            {
                _fileByFilePageID = Convert.ToInt32(ConfigurationManager.AppSettings["FILE_BY_FILE_PAGE_ID"]);
            }
            catch
            {
                throw new ConfigurationErrorsException("Unable to retrieve the FILE_BY_FILE_PAGE_ID config value.");
            }

            try
            {
                _bareMetalDisasterRecoveryPageID = Convert.ToInt32(ConfigurationManager.AppSettings["BARE_METAL_DISASTER_RECOVERY_PAGE_ID"]);
            }
            catch
            {
                throw new ConfigurationErrorsException("Unable to retrieve the BARE_METAL_DISASTER_RECOVERY_PAGE_ID config value.");
            }
        
            try
            {
                _fileByFileCategoryID = Convert.ToInt32(ConfigurationManager.AppSettings["FILE_BY_FILE_CATEGORY_ID"]);
            }
            catch
            {
                throw new ConfigurationErrorsException("Unable to retrieve the FILE_BY_FILE_CATEGORY_ID config value.");
            }

            try
            {
                _bareMetalDisasterRecoveryCategoryID = Convert.ToInt32(ConfigurationManager.AppSettings["BARE_METAL_DISASTER_RECOVERY_CATEGORY_ID"]);
            }
            catch
            {
                throw new ConfigurationErrorsException("Unable to retrieve the BARE_METAL_DISASTER_RECOVERY_CATEGORY_ID config value.");
            }
        }

        #endregion

        #region Static Create

        /// <summary>
        /// This static method creates product object using XMLSerializer
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public static ZNodeProduct Create(int productId, int portalId)
        {
            ZNode.Libraries.DataAccess.Custom.ProductHelper productHelper = new ZNode.Libraries.DataAccess.Custom.ProductHelper();
            string xmlOut = productHelper.GetProductXML(productId, portalId);

            //serialize the object
            ZNodeSerializer ser = new ZNodeSerializer();
            return (ZNodeProduct)ser.GetContentFromString(xmlOut, typeof(ZNodeProduct));
        }

        #endregion

        /// <summary>
        /// Returns an indication whether the product is in the specified category.
        /// </summary>
        /// <param name="categoryID">The ID of the category to check.</param>
        /// <returns></returns>
        public bool IsInCategory(int categoryID)
        {
            ZNodeCategory category = ZNodeCategory.Create(categoryID, ZNodeConfigManager.SiteConfig.PortalID);
            if (category == null)
            {
                return false;
            }

            bool found = false;
            foreach (ZNodeProduct product in category.ZNodeProductCollection)
            {
                if (product.ProductID == ProductID)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                foreach (ZNodeCategory childCategory in category.ZNodeCategoryCollection)
                {
                    ZNodeCategory child = ZNodeCategory.Create(childCategory.CategoryID, ZNodeConfigManager.SiteConfig.PortalID);
                    found = IsInCategory(child.CategoryID);
                    if (found)
                    {
                        break;
                    }
                }
            }

            return found;
        }
    }      
}
