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
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;
using System.Text;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Entities;
using POP.UltraBac;
using Pop.Web;

public partial class Public_Templates_Professional_product_Product : System.Web.UI.UserControl
{
	#region Private Variables
	private ZNodeProduct _product;
	protected int _productId;
	protected int _productimageid;
	protected CmsContext _context = new CmsContext();
	private const int _fileByFilePageID = 65; // Backup and Data Protection Software page
	private const int _bareMetalDisasterRecoveryPageID = 66; // Image Backup and Bare Metal Disaster Recovery page
	private const string _downloadDemo = "~/_img/buttons/download_demo.png";
	private const string _requestDemo = "~/_img/buttons/request_demo.png";
	public int ProductId { get { return _product.ProductID; } }
	#endregion

	private string _defaultPurchaseInformation = null;
	private string _defaultLicensingInformation = null;
	private string _defaultUpgradeInformation = null;
	private string _defaultMaintenanceInformation = null;

	public string DefaultMaintenanceInformation
	{
		get
		{
			if (string.IsNullOrEmpty(_defaultMaintenanceInformation))
			{
				_defaultMaintenanceInformation = ContentHelper.ResolveRelativeUrls(ZNodeConfigManager.MessageConfig.GetMessage("ProductDefaultInfoMaintenance"));
			}
			return _defaultMaintenanceInformation;
		}
		
	}
	public string DefaultUpgradeInformation
	{
		get
		{
			if (string.IsNullOrEmpty(_defaultUpgradeInformation))
			{
				_defaultUpgradeInformation = ContentHelper.ResolveRelativeUrls(ZNodeConfigManager.MessageConfig.GetMessage("ProductDefaultInfoUpgrade"));
			}
			return _defaultUpgradeInformation;
		}
		
	}
	public string DefaultLicensingInformation
	{
		get
		{
			if (string.IsNullOrEmpty(_defaultLicensingInformation))
			{
				_defaultLicensingInformation = ContentHelper.ResolveRelativeUrls(ZNodeConfigManager.MessageConfig.GetMessage("ProductDefaultInfoLicense"));
			}
			return _defaultLicensingInformation;
		}
		
	}
	public string DefaultPurchaseInformation
	{
		get
		{
			if (string.IsNullOrEmpty(_defaultPurchaseInformation))
			{
				_defaultPurchaseInformation = ContentHelper.ResolveRelativeUrls(ZNodeConfigManager.MessageConfig.GetMessage("ProductDefaultInfoPurchase"));
			}
			return _defaultPurchaseInformation;
		}
	}

	#region Page Load
	/// <summary>
	/// Page Load Event
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		//get product id from querystring  
		if (Request.Params["pid"] != null)
		{
			_productId = int.Parse(Request.Params["pid"]);
		}
		else
		{
			throw (new ApplicationException("Invalid Product Id"));
		}

		//retrieve product object from HttpContext (set previously in the page_preinit event of the page)
		_product = (ZNodeProduct)HttpContext.Current.Items["Product"];
		uxRelated.Product = _product;
		uxRelated.Bind();
		//run object through pricing configurator
		ZNodePricingConfigurator pricingConfig = new ZNodePricingConfigurator();
		pricingConfig.ConfigureProductPricing(_product);

		//check if add to cart action was requested from a different page
		if (Request.Params["action"] != null)
		{
			// QuantityOnHand <= 0 not available for sale online
			if (Request.Params["action"].Equals("addtocart") &&
					_product.QuantityOnHand > 0)
			{
				if (!Page.IsPostBack)
				{
					AddtoCart();
				}
			}
		}

		//bind all controls
		Bind();

		ContentPage contentPage = new CmsContext().CurrentPage;
	}
	#endregion

	#region bind method
	/// <summary>
	/// Bind all the controls to the data
	/// </summary>
	private void Bind()
	{
		//set image
		if (_product.ImageFile.Trim().Length > 0)
		{
			//string ImageFilePath = ZNodeConfigManager.EnvironmentConfig.MediumImagePath + _product.ImageFile;
            string ImageFilePath = "http://staging.pop.us/ultrabac//Data/Default/Images/Catalog/Medium/" + _product.ImageFile;
			uxCatalogItemImage.ImageUrl = ImageFilePath;
		}
		else
		{
			uxCatalogItemImage.ImageUrl = ZNodeConfigManager.SiteConfig.ImageNotAvailablePath;
		}

		// available for purchase online
		if (_product.CallForPricing)
		{
			uxCallForPrice.Visible = true;
			uxProductAvailable.Visible = false;
			uxProductUnavailable.Visible = false;

		}
		else if (_product.QuantityOnHand > 0)
		{
			uxProductUnavailable.Visible = false;
			uxDownloadDemo.HRef += ProductId;
			uxRequestDemo.Visible = false;
		}
		else
		{
			uxProductAvailable.Visible = false;
			uxRequestDemo.HRef += ProductId;
			uxDownloadDemo.Visible = false;
		}

		if (_context.CurrentProduct.IsInCategory(Config.IsUpgradeableCategoryID))
		{
			uxDownloadUpgrade.HRef += ProductId;
		}
		else
		{
			uxDownloadUpgrade.Visible = false;
		}

		if (!_context.CurrentProduct.IsInCategory(Config.IsDownloadableCategoryID))
		{
			uxDownloadDemo.Visible = false;
			uxRequestDemo.Visible = false;
		}

		//set product properties  
		uxProductTitle.Text = _product.Name;
		uxProductDescription.Text = _product.Description;
		uxLicenseInfo.Text = string.IsNullOrEmpty(_product.LicensingInformation) ? DefaultLicensingInformation : _product.LicensingInformation;
		uxMaintenanceInfo.Text = string.IsNullOrEmpty(_product.MaintenanceInformation) ? DefaultMaintenanceInformation : _product.MaintenanceInformation;
		uxPurchaseInfo.Text = string.IsNullOrEmpty(_product.PurchaseInformation) ? DefaultPurchaseInformation : _product.PurchaseInformation;
		uxUpgradeInfo.Text = string.IsNullOrEmpty(_product.UpgradeInformation) ? DefaultUpgradeInformation : _product.UpgradeInformation;
	}

	#endregion

	#region General Events
	/// <summary>
	/// Add to cart button click event
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void uxAddToCart_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			AddtoCart();
		}
	}

	private void AddtoCart()
	{
		int quantity = 0;
		int.TryParse(uxQuantity.Text, out quantity);

		if (quantity > 0)
		{
			bool result = PopProductHelper.AddToCart(_product.ProductID, quantity);
			if (result)
			{
				Response.Redirect("~/shoppingcart.aspx");
			}
		}
	}

	#endregion
}