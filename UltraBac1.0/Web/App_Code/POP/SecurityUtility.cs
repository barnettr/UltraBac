using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for SecurityUtility
/// </summary>
public static class SecurityUtility
{
	public static void EnsureSecure(HttpRequest request, HttpResponse response)
	{
		if (!request.IsSecureConnection)
		{
			Uri secureUrl = Pop.Web.HttpExtensions.GetSecure(request.Url);
			response.Redirect(secureUrl.OriginalString);
		}
	}

	public static void EnsureInsecure(HttpRequest request, HttpResponse response)
	{
		if (request.IsSecureConnection)
		{
			Uri insecureUrl = Pop.Web.HttpExtensions.GetInsecure(request.Url);
			response.Redirect(insecureUrl.OriginalString);
		}
	}
}
