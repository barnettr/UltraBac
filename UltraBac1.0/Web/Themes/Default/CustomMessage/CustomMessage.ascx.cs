using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.Framework.Business ;
using ZNode.Libraries.ECommerce.Business;

public partial class Controls_CustomMessage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string MessageKey
    {
        set
        {
            string key = value;
            string msg = ZNodeConfigManager.MessageConfig.GetMessage(key);

            if (msg != null)
            {
							lblMsg.Text = ContentHelper.ResolveRelativeUrls(msg);
            }
        }
    }

}
