using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.ECommerce.Business
{
    #region ZNodeHighlight
    /// <summary>
    /// Represents the properties and methods of a product Highlights.
    /// </summary>
    [Serializable()]
    [XmlRoot("ZNodeHighlight")]
    public class ZNodeHighlight : ZNodeBusinessBase
    {
        #region Private Member Variables
        protected int _highlightID;
        protected int _portalID;
        protected string _imageFile = String.Empty;
        protected string _name = String.Empty;
        protected string _description = String.Empty;
        protected bool _displayPopup;
        #endregion

        #region Constructor
        public ZNodeHighlight()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Retrieves or sets the product highlight id
        /// </summary>
        [XmlElement()]
        public int HighlightID
        {
            get { return _highlightID; }
            set { _highlightID = value; }
        }

        /// <summary>
        /// Retrieves or sets the site portal id
        /// </summary>
        [XmlElement()]
        public int PortalID
        {
            get { return _portalID; }
            set { _portalID = value; }
        }

        /// <summary>
        /// Retrieves or sets the image file name for this product highlight.
        /// </summary>
        [XmlElement()]
        public string ImageFile
        {
            get { return _imageFile; }
            set { _imageFile = value; }
        }
        /// <summary>
        /// Retrieves or sets the name for this product highlight
        /// </summary>
        [XmlElement()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Retrieves or sets the description for this product highlight
        /// </summary>
        [XmlElement()]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Retrieves or sets the display popup value
        /// </summary>
        [XmlElement()]
        public bool DisplayPopup
        {
            get { return _displayPopup; }
            set { _displayPopup = value; }
        }
        #endregion

    }
    #endregion
}
