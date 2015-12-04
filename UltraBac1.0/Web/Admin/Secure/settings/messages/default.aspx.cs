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
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using System.Data.SqlClient;


public partial class Admin_Secure_settings_msg_Add : System.Web.UI.Page
{

    #region Protected Variables
    protected int ItemId;
    protected string AddLink = "Editmessage.aspx?itemid=";
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    #endregion
  
    #region grid event
   
    protected void uxGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
        }
        else
        {            
            string key = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Response.Redirect(AddLink + key);
            }
        }
    }
    #endregion 
}
