using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;

/// <summary>
/// Summary description for FormManager
/// </summary>
public class FormManager : NameValueSectionHandler
{
	protected override string KeyAttributeName
	{
		get
		{
			return "page";
		}
	}

	protected override string ValueAttributeName
	{
		get
		{
			return "formPath";
		}
	}

	private static NameValueCollection _default;

	public static NameValueCollection Default
	{
		get { return (NameValueCollection)System.Configuration.ConfigurationSettings.GetConfig("customForms"); }
	}

}