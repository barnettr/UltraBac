using System;
using System.Collections.Generic;
using System.Text;

namespace POP.UltraBac
{
	/// <summary>
	/// Represents an exception thrown when in the checkout path.
	/// </summary>
	public class CheckoutException : System.Exception
	{
		/// <summary>
		/// Represents a checkout path exception 
		/// </summary>
		/// <param name="message"></param>
		public CheckoutException(string message)
			: base(message)
		{
		}

	}
}
