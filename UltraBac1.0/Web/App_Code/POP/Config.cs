using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace POP.UltraBac
{

  /// <summary>
  /// Collection of static Web.Config appSetting value properties
  /// </summary>
  public class Config
  {

    public static string ContentPageFormat
    {
      get { return "~/content.aspx?page={0}"; }
    }

    public static string ProductPageFormat
    {
      get { return "~/product.aspx?pid={0}"; }
    }

    public static string CategoryPageFormat
    {
      get { return "~/category.aspx?cid={0}"; }
    }

    public static int WhitePapersPageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["WHITE_PAPERS_PAGE_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the WHITE_PAPERS_PAGE_ID config value.");
        }
      }
    }

    public static int ProductNewsPageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["PRODUCT_NEWS_PAGE_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the PRODUCT_NEWS_PAGE_ID config value.");
        }
      }
    }

    public static int FileByFilePageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["FILE_BY_FILE_PAGE_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the FILE_BY_FILE_PAGE_ID config value.");
        }
      }
    }

    public static int BareMetalDisasterRecoveryPageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["BARE_METAL_DISASTER_RECOVERY_PAGE_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the BARE_METAL_DISASTER_RECOVERY_PAGE_ID config value.");
        }
      }
    }

    public static int SmallBusinessPageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["SMALL_BUSINESS_SOLUTIONS_PAGE_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the SMALL_BUSINESS_SOLUTIONS_PAGE_ID config value.");
        }
      }
    }

    public static int MediumBusinessPageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["MEDIUM_BUSINESS_SOLUTIONS_PAGE_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the MEDIUM_BUSINESS_SOLUTIONS_PAGE_ID config value.");
        }
      }
    }
    public static int EnterprisePageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["ENTERPRISE_BUSINESS_SOLUTIONS_PAGE_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the ENTERPRISE_BUSINESS_SOLUTIONS_PAGE_ID config value.");
        }
      }
    }

    public static int FeaturedProductCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["FEATURED_PRODUCT_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the FEATURED_PRODUCT_CATEGORY_ID config value.");
        }
      }
    }

    public static int FileByFileCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["FILE_BY_FILE_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the FILE_BY_FILE_CATEGORY_ID config value.");
        }
      }

    }

    public static int BareMetalDisasterRecoveryCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["BARE_METAL_DISASTER_RECOVERY_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the BARE_METAL_DISASTER_RECOVERY_CATEGORY_ID config value.");
        }
      }
    }

    public static int SmallBusinessCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["SMALL_BUSINESS_SOLUTIONS_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the SMALL_BUSINESS_SOLUTIONS_CATEGORY_ID config value.");
        }
      }
    }

    public static int MediumBusinessCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["MEDIUM_BUSINESS_SOLUTIONS_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the MEDIUM_BUSINESS_SOLUTIONS_CATEGORY_ID config value.");
        }
      }
    }

    public static int EnterpriseCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["ENTERPRISE_SOLUTIONS_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the ENTERPRISE_SOLUTIONS_CATEGORY_ID config value.");
        }
      }
    }

    public static int IsDownloadableCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["IS_DOWNLOADABLE_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the IS_DOWNLOADABLE_CATEGORY_ID config value.");
        }
      }
    }

    public static int IsUpgradeableCategoryID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["IS_UPGRADEABLE_CATEGORY_ID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the IS_UPGRADEABLE_CATEGORY_ID config value.");
        }
      }
    }

    private const string trialLicenseKeyFileName = "~/App_Data/TrialLicenseKey.txt";

    public static string GoogleCSEAccountID
    {
      get
      {
        try
        {
          return ConfigurationManager.AppSettings["GOOGLE_CSE_ACCOUNT_ID"];
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the GOOGLE_CSE_ACCOUNT_ID config value.");
        }
      }
    }

    public static string GoogleCseUrl
    {
      get
      {
        try
        {
          return ConfigurationManager.AppSettings["GOOGLE_CSE_URL"];
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the GOOGLE_CSE_URL config value.");
        }
      }
    }

		public static ConnectionStringSettings ResellerConnectionString
    {
      get
      {
        try
        {
					return ConfigurationManager.ConnectionStrings["RESELLER_DB_CONNECTION_STRING"];
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the RESELLER_DB_CONNECTION_STRING config value.");
        }
      }
    }

		public static ConnectionStringSettings GoldMineConnectionString
    {
      get
      {
        try
        {
					return ConfigurationManager.ConnectionStrings["GoldmineDB"];
        }
        catch
        {
					throw new ConfigurationErrorsException("Unable to retrieve the GoldmineDB connection string.");
        }
      }
    }

    public static string TrialLicenseKey
    {
      get
      {
        try
        {
          if (HttpContext.Current.Cache["TRIAL_LICENSE_KEY"] == null)
          {
            string licenseKey = File.ReadAllText(HttpContext.Current.Server.MapPath(trialLicenseKeyFileName));
            CacheDependency cacheDep = new CacheDependency(HttpContext.Current.Server.MapPath(trialLicenseKeyFileName));
            HttpContext.Current.Cache.Insert("TRIAL_LICENSE_KEY", licenseKey, cacheDep);
          }
          return HttpContext.Current.Cache["TRIAL_LICENSE_KEY"].ToString();
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to read the contents of the TrialLicenseKey.txt file.");
        }
      }
    }

    public static int RootContentPageID
    {
      get
      {
        try
        {
          return Convert.ToInt32(ConfigurationManager.AppSettings["ROOT_CONTENTPAGEID"]);
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the ROOT_CONTENTPAGEID config value.");
        }
      }
    }

    public static string TrialDownloadFileName
    {
      get
      {
        try
        {
          return ConfigurationManager.AppSettings["TRIAL_DOWNLOAD_FILENAME"];
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the TRIAL_DOWNLOAD_FILENAME config value.");
        }
      }
    }

    public static string UpgradeDownloadFileName
    {
      get
      {
        try
        {
          return ConfigurationManager.AppSettings["UPGRADE_DOWNLOAD_FILENAME"];
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the UPGRADE_DOWNLOAD_FILENAME config value.");
        }
      }
    }

    public static string ResellerPassword
    {
      get
      {
        try
        {
          return ConfigurationManager.AppSettings["RESELLER_PASSWORD"];
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the RESELLER_PASSWORD config value.");
        }
      }
    }

    public static string ResellerLoginUrl
    {
      get
      {
        try
        {
          return ConfigurationManager.AppSettings["RESELLER_LOGIN_URL"];
        }
        catch
        {
          throw new ConfigurationErrorsException("Unable to retrieve the RESELLER_LOGIN_URL config value.");
        }
      }
    }
  }
}
