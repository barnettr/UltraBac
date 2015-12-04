using System;

namespace ZNode.Libraries.DataAccess.Entities
{
	/// <summary>
	/// 
	/// </summary>
	/// <remark>this enumeration contains the items contained in the table ZNodePaymentType</remark>
	[Serializable]
	public enum PaymentTypeList
	{
		/// <summary> 
		/// Credit Card Payments
		/// </summary>
		[EnumTextValue("Credit Card Payments")]
		Credit_Card = 0, 

		/// <summary> 
		/// Purchase Order Payments
		/// </summary>
		[EnumTextValue("Purchase Order Payments")]
		Purchase_Order = 1, 

		/// <summary> 
		/// PayPal Payments
		/// </summary>
		[EnumTextValue("PayPal Payments")]
		PayPal = 2, 

		/// <summary> 
		/// Google Checkout
		/// </summary>
		[EnumTextValue("Google Checkout")]
		Google_Checkout = 5, 

		/// <summary> 
		/// Verisign Payflow Pro Express
		/// </summary>
		[EnumTextValue("Verisign Payflow Pro Express")]
		Verisign_Payflow_Pro_Express = 6

	}
}