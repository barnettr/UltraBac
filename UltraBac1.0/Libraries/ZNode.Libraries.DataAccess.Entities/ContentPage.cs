#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace ZNode.Libraries.DataAccess.Entities
{	
	///<summary>
	/// An object representation of the 'ZNodeContentPage' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class ContentPage : ContentPageBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="ContentPage"/> instance.
		///</summary>
		public ContentPage():base(){ }
		#endregion

		/// <summary>
		/// Uses the Custom1 field of the ContentPageBase to store a short summary for a page, useful for
		/// databound controls
		/// </summary>
		public string Summary
		{
			get { return Custom1; }
			set { Custom1 = value; }
		}

		/// <summary>
		/// Specifies whether the content page has specified a RedirectPage
		/// </summary>
		public bool HasAutomaticRedirect
		{
			get { return !string.IsNullOrEmpty(Custom3) && "/Content/Redirect.master".Equals(TemplateName, StringComparison.InvariantCultureIgnoreCase); }
		}

		/// <summary>
		/// If specified, all visits to this content page will redirect to this page.
		/// </summary>
		public string RedirectPage
		{
			get { return Custom3; }
			set { base.Custom3 = value; }
		}

		/// <summary>
		/// If true, will require visitors to log in as Reseller to view a page
		/// </summary>
		public bool IsResellerProtectedPage
		{
			get { return "true".Equals(base.Custom2, StringComparison.InvariantCultureIgnoreCase); }
			set { base.Custom2 = value.ToString(); }
		}

		/// <summary>
		/// Form pages will submit emails to these comma separated email addresses
		/// </summary>
		public string FormEmailRecipient
		{
			get { return base.Custom3; }
			set { base.Custom3 = value; }
		}
	}
}
