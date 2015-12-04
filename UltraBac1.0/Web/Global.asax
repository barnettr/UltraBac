<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        
        
    }

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {       
        string currentURL = Request.Path ;

        //This section rewrites product path
        if (currentURL.IndexOf("storeproduct", 0) > 0)
        {
            string fileName = System.IO.Path.GetFileName(Request.Path);

            string productId = fileName.Replace(".aspx", "");
            productId = productId.Replace("storeproduct", "");

            string replacePath = "~/product.aspx?pid=" + productId;

            // Rewrites the path
            HttpContext.Current.RewritePath(replacePath);
        }

        //This section rewrites category path
        if (currentURL.IndexOf("storecategory", 0) > 0)
        {
            string fileName = System.IO.Path.GetFileName(Request.Path);

            string categoryId = fileName.Replace(".aspx", "");
            categoryId = categoryId.Replace("storecategory", "");

            string replacePath = "~/category.aspx?cid=" + categoryId;

            // Rewrites the path
            HttpContext.Current.RewritePath(replacePath);
        }
  
    }
    
    void Application_End(object sender, EventArgs e) 
    {

    }

    void Application_Error(object sender, EventArgs e)
    {
#if !DEBUG
         Server.Transfer("~/error.aspx");
#endif
    }

    void Session_Start(object sender, EventArgs e) 
    {       
        //*************************************************************************************
        //Check licensing status - DO NOT REMOVE THIS SECTION. Removing this section will
        //cause unpredicatable behavior with this application
        //*************************************************************************************
        ZNode.Libraries.Framework.Business.ZNodeLicenseManager lm = new ZNode.Libraries.Framework.Business.ZNodeLicenseManager();
        ZNode.Libraries.Framework.Business.ZNodeLicenseType lt = lm.Validate();
        if (lt == ZNode.Libraries.Framework.Business.ZNodeLicenseType.Trial)
        {
        //    Server.Transfer("~/activate/continuetrial.aspx");
        }
    }

    void Session_End(object sender, EventArgs e) 
    {

    }
       
</script>
