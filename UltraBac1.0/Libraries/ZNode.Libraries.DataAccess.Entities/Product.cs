#region Using directives

using System;

#endregion

namespace ZNode.Libraries.DataAccess.Entities
{	
	///<summary>
	/// An object representation of the 'ZNodeProduct' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Product : ProductBase
	{
		#region Constructors

		///<summary>
		/// Creates a new <see cref="Product"/> instance.
		///</summary>
		public Product() : base() { }
		#endregion

		private new string FeaturesDesc;
		private new string Specifications;
		private new string AdditionalInformation;
		private new string Custom1;

		/// <summary>
		/// Use the FeaturesDesc field from the database to store Purchase information
		/// </summary>
		public string PurchaseInformation
		{
			get { return base.FeaturesDesc; }
			set { base.FeaturesDesc = value; }
		}

		/// <summary>
		/// Use the Specifications field from the database to store Licensing information
		/// </summary>
		public string LicensingInformation
		{
			get { return base.Specifications; }
			set { base.Specifications = value; }
		}

		/// <summary>
		/// Use the AdditionalInformation field from the database to store Upgrade information
		/// </summary>
		public string UpgradeInformation
		{
			get { return base.AdditionalInformation; }
			set { base.AdditionalInformation = value; }
		}

		/// <summary>
		/// Use the Custom1 field from the database to store maintenance information
		/// </summary>
		public string MaintenanceInformation
		{
			get { return base.Custom1; }
			set { base.Custom1 = value; }
		}
	}
}
