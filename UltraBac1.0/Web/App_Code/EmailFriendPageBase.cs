using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Framework.Business;

/// <summary>
/// Summary description for EmailFriendPageBase.cs
/// </summary>
public class EmailFriendPageBase : ZNodePageBase
{
	protected virtual void Page_PreInit(object sender, EventArgs e)
	{
		if ( ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig == null )
		{
			throw new NullReferenceException("Could not retrieve SiteConfig settings. Please verify the connection to the ZNode database via the ZNodeECommerceDB connectionString");
		}

		this.MasterPageFile = string.Format("~/themes/{0}{1}", ZNode.Libraries.Framework.Business.ZNodeConfigManager.SiteConfig.Theme, "/emailfriend/emailfriend.master");
	}
}
