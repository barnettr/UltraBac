using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Collections;

public static class FormOutputUtils
{
	private static List<string> _ignorableFormFields = new List<string>();

	static FormOutputUtils()
	{
		_ignorableFormFields.Add("__VIEWSTATE");
		_ignorableFormFields.Add("__EVENTTARGET");
		_ignorableFormFields.Add("__EVENTARGUMENT");
		_ignorableFormFields.Add("__EVENTVALIDATION");
	}

	public static string GetFormattedFormValues(HttpRequest request)
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("Website user submitted a form with the following values:");
		sb.AppendLine(string.Format("Form submitted from: {0}", request.Url.OriginalString));

		foreach (string s in request.Form.AllKeys)
		{
			if (IsDesiredFormField(s) && !s.EndsWith("uxQuery") && !s.EndsWith("uxNewsletter"))
			{
				sb.AppendLine(string.Format("{0}:\t{1}", s, request.Form[s]));
			}
		}

		return sb.ToString();
	}

	private static bool IsDesiredFormField(string formName)
	{
		return !_ignorableFormFields.Contains(formName);
	}
}
