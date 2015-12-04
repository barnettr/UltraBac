using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    #region ZNodeCategory
    /// <summary>
    /// Represents the properties and methods of a ZNodeCategory.
    /// </summary>
    [Serializable()]
    [XmlRoot()]
    public class ZNodeCategory : ZNodeBusinessBase
    {
        #region Private Member Variables
        protected int _categoryID;
        protected int _portalID;
        protected int _categoryTemplateID;
        protected string _name = String.Empty;
        protected string _description = String.Empty;
        protected string _shortdescription = String.Empty;
        protected int _parentCategoryID;
        protected string _parentCategoryName = string.Empty;
        protected int _displayOrder;
        protected string _imageFile = String.Empty;
        protected bool _visibleInd;

        protected string _title = String.Empty;
        protected bool _subCategoryGridVisibleInd;
        protected string _seoTitle = String.Empty;
        protected string _seoKeywords = String.Empty;
        protected string _seoDescription = String.Empty;
        #endregion

        #region Private Member Objects
        private ZNodeGenericCollection<ZNodeProduct> _productCollection = new ZNodeGenericCollection<ZNodeProduct>();
        private ZNodeGenericCollection<ZNodeCategory> _categoryCollection = new ZNodeGenericCollection<ZNodeCategory>();
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ZNodeCategory(){}
        #endregion

        #region Public Properties
        
        /// <summary>
        /// Collection of products contained within this category
        /// </summary>
        [XmlElement("ZNodeProduct")]
        public ZNodeGenericCollection<ZNodeProduct> ZNodeProductCollection
        {
            get
            {
                return _productCollection;
            }
            set
            {
                _productCollection = value;
            }
        }

        /// <summary>
        /// Collection of sub categories contained within this category
        /// </summary>
        [XmlElement("ZNodeSubCategory")]
        public ZNodeGenericCollection<ZNodeCategory> ZNodeCategoryCollection
        {
            get
            {
                return _categoryCollection;
            }
            set
            {
                _categoryCollection = value;
            }
        }

        /// <summary>
        /// Sets or retrieves the category UniqueID
        /// </summary>
        [XmlElement()]
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        /// <summary>
        /// Returns fully qualified link to category details page
        /// </summary>
        [XmlIgnore()]
        public string ViewCategoryLink
        {
            get
            {
                System.Text.StringBuilder _link = new StringBuilder();

                //get the url object
                ZNodeUrl url = new ZNodeUrl();

                //get different urls
                _link.Append("~/storecategory");
                _link.Append(CategoryID.ToString());
                _link.Append(".aspx");

                return _link.ToString();
            }
        }

        /// <summary>
        /// Sets or retrieves the site portalID
        /// </summary>
        [XmlElement()]
        public int PortalID
        {
            get { return _portalID; }
            set { _portalID = value; }
        }

        /// <summary>
        /// Sets or retrieves the category templateID
        /// </summary>
        [XmlElement()]
        public int CategoryTemplateID
        {
            get { return _categoryTemplateID; }
            set { _categoryTemplateID = value; }
        }

        /// <summary>
        /// Sets or retrieves the category Name
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Sets or retrieves the category description
        /// </summary>
        [XmlElement()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Sets or retrieves the category short description
        /// </summary>
        [XmlElement()]
        public string ShortDescription
        {
            get { return _shortdescription; }
            set { _shortdescription = value; }
        }

        /// <summary>
        /// Sets or retrieves the parent categoryId for this category
        /// </summary>
        [XmlElement()]
        public int ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }

        /// <summary>
        /// Sets or retrieves the parent category Name
        /// </summary>
        [XmlElement()]
        public string ParentCategoryName
        {
            get { return _parentCategoryName; }
            set { _parentCategoryName = value; }
        }

        /// <summary>
        /// Sets or retrieves the display order number
        /// </summary>
        [XmlElement()]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// <summary>
        /// Sets or retrieves the image file name
        /// </summary>
        [XmlElement()]
        public string ImageFile
        {
            get { return _imageFile; }
            set { _imageFile = value; }
        }

        /// <summary>
        /// Returns fully qualified image file path
        /// </summary>
        [XmlIgnore()]
        public string ImageFilePath
        {
            get
            {
                System.Text.StringBuilder _ImagePath = new StringBuilder();
                _ImagePath.Append(ZNodeConfigManager.EnvironmentConfig.LargeImagePath);
                _ImagePath.Append(ImageFile);

                return _ImagePath.ToString();
            }
        }

        /// <summary>
        /// Sets or retrieves the VisibleInd property as a boolean value
        /// </summary>
        [XmlElement()]
        public bool VisibleInd
        {
            get { return _visibleInd; }
            set { _visibleInd = value; }
        }

        //This section added on Jan 02, 2005
        /// <summary>
        /// Sets or retrieves the subcategory visibleInd property as a boolean value
        /// </summary>
        [XmlElement()]
        public bool SubCategoryGridVisibleInd
        {
            get { return _subCategoryGridVisibleInd ; }
            set { _subCategoryGridVisibleInd = value; }
        }
        /// <summary>
        /// Sets or retrieves the Category Title
        /// </summary>
        [XmlElement()]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Sets or retrieves the SEO Description
        /// </summary>
        [XmlElement()]
        public string SEODescription
        {
            get { return _seoDescription; }
            set { _seoDescription = value; }
        }

        /// <summary>
        /// Sets or retrieves the SEO Keywords
        /// </summary>
        [XmlElement()]
        public string SEOKeywords
        {
            get { return _seoKeywords; }
            set { _seoKeywords = value; }
        }

        /// <summary>
        /// Sets or retrieves the SEO Title
        /// </summary>
        [XmlElement()]
        public string SEOTitle
        {
            get { return _seoTitle ; }
            set { _seoTitle = value; }
        }
        #endregion

        #region Static Create

        /// <summary>
        /// This static method creates category using XMLSerializer
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public static ZNodeCategory Create(int categoryId, int portalId)
        {
            ZNode.Libraries.DataAccess.Custom.CategoryHelper categoryHelper = new ZNode.Libraries.DataAccess.Custom.CategoryHelper();
            string xmlOut = categoryHelper.GetCategoryXML(categoryId, portalId);

            //serialize the object
            ZNodeSerializer ser = new ZNodeSerializer();
            return (ZNodeCategory)ser.GetContentFromString(xmlOut, typeof(ZNodeCategory));
        }

        #endregion

				public bool IsInCategory(int categoryID)
				{
					if (categoryID == this.CategoryID)
					{
						return true;
					}
					else if (categoryID == ParentCategoryID)
					{
						return true;
					}
					else if (ParentCategoryID > 0)
					{
						ZNodeCategory parent = ZNodeCategory.Create(ParentCategoryID, ZNodeConfigManager.SiteConfig.PortalID);
						return parent.IsInCategory(categoryID);
					}
					return false;
				}
				public override string ToString()
				{
					return string.Format("{0}:{1}", CategoryID, Name);
				}				
    }
    #endregion

}
