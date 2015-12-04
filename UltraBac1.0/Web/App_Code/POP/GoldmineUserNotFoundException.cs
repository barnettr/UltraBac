using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for GoldmineUserNotFoundException
/// </summary>
public class GoldmineUserNotFoundException: Exception
{
	private string _email;
	public GoldmineUserNotFoundException(string email)
	{
		_email = email;
	}
	public override string ToString()
	{
		return string.Format("Could not find user with email: {0}",_email);
	}
}
