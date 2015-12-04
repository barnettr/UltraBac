using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace POP.UltraBac
{
	/// <summary>
	/// Collection of static methods to assist in processing form input data
	/// </summary>
	public class FormInputUtils
	{
		/// <summary>
		/// Returns ListControl selection values as a delimited string
		/// </summary>
		/// <param name="listCtl">ListControl to enumerate</param>
		/// <param name="otherChoiceValue">If an Other choice is offered, the other value</param>
		/// <param name="delim">Delimiter to use</param>
		/// <returns>string</returns>
		public static string GetMultiSelectChoices(ListControl listCtl, string otherChoiceValue, string delim)
		{
			StringBuilder sb = new StringBuilder();
			foreach (ListItem itm in listCtl.Items)
			{
				if (itm.Selected)
				{
					sb.Append(itm.Value + delim);
				}
			} 
			if (!string.IsNullOrEmpty(otherChoiceValue))
			{
				sb.AppendFormat("Other: {0}",otherChoiceValue);
			}
			return sb.ToString();
		}

		/// <summary>
		/// Evaluates whether the user has made a required selection in a ListControl
		/// </summary>
		/// <param name="listCtl">ListControl to enumerate</param>
		/// <param name="otherChoiceValue">If an Other choice is offered and its value is required, the other value, otherwise, pass an empty string.</param>
		/// <returns>boolean, true if user has selected at least one item or a string input field</returns>
		public static bool EvaluateRequiredMultiSelect(ListControl listCtl, string otherChoiceValue)
		{
			foreach ( ListItem itm in listCtl.Items )
			{
				if ( itm.Selected )
				{
					return true;
				}
			}
			return !string.IsNullOrEmpty(otherChoiceValue);
		}
	}
}