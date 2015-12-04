using System.Text;

namespace POP.UltraBac
{
	/// <summary>
	/// Collection of static methods to assist in generating client-side JavaScript
	/// </summary>
	public class ClientScriptUtils
	{

		/// <summary>
		/// Builds a javascript block that applies DHTML for changes in address location selection on forms
		/// </summary>
		/// <param name="stateDDLDivID">Client ID of the container of the state dropdownlist</param>
		/// <param name="stateTxtDivID">Client ID of the container of the state textbox</param>
		/// <param name="countryDDLID">Client ID of the country dropdownlist or empty string if n/a</param>
		/// <returns>string</returns>
		public static string BuildLocationSelectionDHTMLScript(string stateDDLDivID, string stateTxtDivID, string countryDDLID)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<script type='text/javascript' language='javascript'>");

			sb.AppendLine("function toggleStateControls(mode) {");
			sb.AppendLine("if (mode == 'US') {");
			sb.AppendFormat("document.getElementById('{0}').style.display = 'block';\n", stateDDLDivID);
			sb.AppendFormat("document.getElementById('{0}').style.display = 'none';\n", stateTxtDivID);
			if ( countryDDLID != string.Empty )
			{
				sb.AppendFormat("document.getElementById('{0}').value = 'US';\n", countryDDLID);
			}
			sb.AppendLine("} else {");
			sb.AppendFormat("document.getElementById('{0}').style.display = 'none';\n", stateDDLDivID);
			sb.AppendFormat("document.getElementById('{0}').style.display = 'block';\n", stateTxtDivID);
			if ( countryDDLID != string.Empty )
			{
				sb.AppendLine("if (mode == 'CA') {");
				sb.AppendFormat("document.getElementById('{0}').value = 'CA';\n", countryDDLID);
				sb.AppendLine("} else {");
				sb.AppendFormat("document.getElementById('{0}').value = '-1';\n", countryDDLID);
				sb.AppendLine("}");
			}
			sb.AppendLine("}");
			sb.AppendLine("}");

			sb.AppendLine("toggleStateControls('foreign');");

			sb.AppendLine("</script>");

			return sb.ToString();
		}

	}
}