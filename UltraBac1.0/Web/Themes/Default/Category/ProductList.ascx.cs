using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZNode.Libraries.ECommerce.Business;
using ZNode.Libraries.Framework.Business;

public partial class Controls_ProductList : System.Web.UI.UserControl
{
    #region Private Variables
    private ZNodeCategory _category;
    private int _categoryId;
    protected string _viewProductLink = string.Empty ;
    protected string _addToCartLink = string.Empty;
    private ZNodeProductList _productList;
    protected string _noRecordsText = string.Empty;
    private ZNodeProduct _product;
    string link = "~/shoppingcart.aspx";
    string attributeslink = "~/product.aspx?pid=";
    private int CurrentPage = 0;
    #endregion

    # region Protected Static Member Variables
    public static int TotalRecords = 0;
    public static int nRecCount = 0;
    public static int nCurrentIndex =0;
    public static int ncurrentpage =0;
    public string BuyImage = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/images/buynow.gif";
    # endregion

    #region Public Properties  
    /// <summary>
    /// Sets the title for this control
    /// </summary>
    public string NoRecordsText
    {
        get
        {
            return _noRecordsText;
        }
        set
        {
            _noRecordsText = value;
        }
    }

    /// <summary>
    /// A product list passed in from the search page
    /// </summary>
    public ZNodeProductList ProductList
    {
        get
        {
            return _productList;
        }
        set
        {
            _productList = value;
        }
    }

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["cid"] != null)
        {
            _categoryId = int.Parse(Request.Params["cid"]);
        }      

        //get the url object
        ZNodeUrl url = new ZNodeUrl();

        //get different urls
        _viewProductLink = "~/product.aspx";

        if (_categoryId > 0)
        {
            //Retrieve category data from httpContext (set previously in the page_preinit event)
            _category = (ZNodeCategory)HttpContext.Current.Items["Category"];

            //Bind data to page
            BindCategory();
        }
      
        
    }
    #endregion

    #region Bind Data

    /// <summary>
    /// Bind control display based on category object passed in
    /// </summary>
    public void BindCategory()
    {
        if (Visible)
        {
            if (_category.ZNodeProductCollection.Count == 0)
            {
                pnlProductList.Visible = false;
                ErrorMsg.Visible = true;
                ErrorMsg.Text = "";
            }
            else
            {
                ProductListTitle.Text = _category.Title ;
                pnlProductList.Visible = true;
                ErrorMsg.Visible = false;              
            }                     
            
                        
            if (!Page.IsPostBack)
            {                
                DataSet ds = this.BindProductList(_category.ZNodeProductCollection);

                if (ds.Tables[0].Rows.Count > 0)
                {            
                    //Set Viewstate object with data set object
                    ViewState["ProductList"] = ds;
                    //set initial page value
                    ViewState["CurrentPage"] = 0; 
                    BindDataListPagedDataSource();                    
                }                
           }
        }
    }


    /// <summary>
    /// Bind display based on a product list
    /// </summary>
    public void BindProducts()
    {
        if (Visible)
        {
            if (_productList.ZNodeProductCollection.Count == 0)
            {
                pnlProductList.Visible = false;
                ErrorMsg.Visible = true;
                ErrorMsg.Text = "No matching records were found. Please refine your search and try again.";
            }
            else
            {
                //ProductListTitle.Text = Title;
                pnlProductList.Visible = true;
                ErrorMsg.Visible = false;
            }


            DataSet ds = this.BindProductList(_productList.ZNodeProductCollection);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //Set Dataset object to Viewstate
                ViewState["ProductList"] = ds;
                //set initial page value
                ViewState["CurrentPage"] = 0;
                BindDataListPagedDataSource();
            }


        }
    }

    public bool Check(Object value)
    {
        if (Convert.ToBoolean(value))
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
    
    
    #endregion

    # region DataList Paging Methods & Events

    /// <summary>
    /// Generate Dataset from ZNodeGeneric product Collection
    /// </summary>
    /// <param name="ProductList"></param>
    /// <returns></returns>
    private DataSet BindProductList(ZNodeGenericCollection<ZNodeProduct> ProductList)
    {
        //Get list of products for particular category
        ZNodeGenericCollection<ZNodeProduct> list = ProductList;       
        IEnumerator enumerator = list.GetEnumerator();

        //Create Data table
        DataTable dt = new DataTable();
        DataColumn col1 = new DataColumn("ID", System.Type.GetType("System.Int32"));
        DataColumn col2 = new DataColumn("ProductID");
        DataColumn col3 = new DataColumn("ImageSmallFilePath");
        DataColumn col4 = new DataColumn("ViewProductLink");
        DataColumn col5 = new DataColumn("Name");
        DataColumn col6 = new DataColumn("CallForPricing", System.Type.GetType("System.Boolean"));
        DataColumn col7 = new DataColumn("RetailPrice", System.Type.GetType("System.Decimal"));
        DataColumn col8 = new DataColumn("SalePrice", System.Type.GetType("System.Decimal"));

        //Add Columns into Data table
        dt.Columns.Add(col1);
        dt.Columns.Add(col2);
        dt.Columns.Add(col3);
        dt.Columns.Add(col4);
        dt.Columns.Add(col5);
        dt.Columns.Add(col6);
        dt.Columns.Add(col7);
        dt.Columns.Add(col8);
        int i = 1;

        //Loop through the product list
        while (enumerator.MoveNext())
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = ((ZNodeProduct)(enumerator.Current)).ProductID.ToString();
            dr[2] = ((ZNodeProduct)(enumerator.Current)).SmallImageFilePath;
            dr[3] = ((ZNodeProduct)(enumerator.Current)).ViewProductLink;
            dr[4] = ((ZNodeProduct)(enumerator.Current)).Name;
            dr[5] = ((ZNodeProduct)(enumerator.Current)).CallForPricing;
            dr[6] = ((ZNodeProduct)(enumerator.Current)).RetailPrice;
            dr[7] = ((ZNodeProduct)(enumerator.Current)).SalePrice;
            i++;
            dt.Rows.Add(dr);
        }

        DataSet ds = new DataSet();
        //Add data table into Dataset
        ds.Tables.Add(dt);

        //Set Repeat columns to the product Data list
        DataListProducts.RepeatColumns = ZNodeConfigManager.SiteConfig.MaxCatalogDisplayColumns;

        //Return DataSet
        return ds;
    }    

    /// <summary>
    /// Previous Link Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void PrevRecord(Object sender, EventArgs e)
    {       
        CurrentPage = int.Parse(ViewState["CurrentPage"].ToString());
        ViewState["CurrentPage"] = CurrentPage -= 1;

        BindDataListPagedDataSource();        
    }

    /// <summary>
    /// Next Link Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void NextRecord(Object sender, EventArgs e)
    {       
            
        CurrentPage = int.Parse(ViewState["CurrentPage"].ToString());
        ViewState["CurrentPage"] = CurrentPage += 1;
               
        BindDataListPagedDataSource();
       
    }

    /// <summary>
    /// Bind Datalist using Paged DataSource object
    /// </summary>
    private void BindDataListPagedDataSource()
    {
        //Declare dataset
        DataSet ds = new DataSet();

        //retrieve dataset from Viewstate
        if (ViewState["ProductList"] != null)
        {
            ds = (DataSet)ViewState["ProductList"];
        }

        DataView dv = new DataView();
        dv.Table = ds.Tables[0];

        //Filter products by Price range
        if (lstFilter.SelectedValue.Equals("1"))
        {
            dv.Sort = "RetailPrice asc";
        }
        else if (lstFilter.SelectedValue.Equals("2"))
        {
            dv.Sort = "RetailPrice desc";
        }
        else if (lstFilter.SelectedValue.Equals("0"))
        {
            //no sorting
        }


        //Creating an object for the 'PagedDataSource' for holding the data.
        PagedDataSource objPage = new PagedDataSource();

        //Assigning the datasource to the 'objPage' object.
        objPage.DataSource = dv;

        //Enable paging
        objPage.AllowPaging = true;

        objPage.PageSize = ZNodeConfigManager.SiteConfig.MaxCatalogDisplayItems;

        //"CurrentPage" is public static variable to hold the current page index value declared in the global section.
        objPage.CurrentPageIndex = int.Parse(ViewState["CurrentPage"].ToString());

        //Checking for enabling/disabling next/prev buttons.
        //Next/prev buton will be disabled when is the last/first page of the pageobject.
        BotNextLink.Enabled = !objPage.IsLastPage;
        TopNextLink.Enabled = !objPage.IsLastPage;
        TopPrevLink.Enabled = !objPage.IsFirstPage;
        BotPrevLink.Enabled = !objPage.IsFirstPage;

        //set current page index
        ncurrentpage = objPage.CurrentPageIndex + 1;
        nRecCount = objPage.PageCount;
        TotalRecords = objPage.DataSourceCount;

        //Assigning Datasource to the DataList.
        DataListProducts.DataSource = objPage;
        DataListProducts.DataBind();

    }
    # endregion

    #region Helper Functions

    public bool ShowSalePrice(object salePrice)
    {        
        decimal decPrice = decimal.Parse(salePrice.ToString());

        if (decPrice > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string CheckForCallForPricing(object FieldValue)
    {
        
        bool Status = bool.Parse(FieldValue.ToString());        
        
        if (Status)
        {
            return ZNodeConfigManager.MessageConfig.GetMessage("CallForPricing");
        }
        else
        {
            return "";
        }
    }
    public string GetSalePrice(object salePrice)
    {
        if (salePrice == null) { return ""; }
        decimal decPrice = decimal.Parse(salePrice.ToString());
        return decPrice.ToString("c");
    }

    public string GetRegularPrice(object retailPrice)
    {        
        if (retailPrice == null) { return ""; }
        decimal decPrice = decimal.Parse(retailPrice.ToString());
        return decPrice.ToString("c");
   
    }
    #endregion

    #region general events

    protected void buy_Click(object sender, ImageClickEventArgs e)
    {
        //Getting ProductID from the image button
        ImageButton but_buy = (sender) as ImageButton;
        
        _product = ZNodeProduct.Create(Convert.ToInt32(but_buy.CommandArgument), ZNodeConfigManager.SiteConfig.PortalID);       

        if (_product.ZNodeAttributeTypeCollection.Count > 0 || _product.CallForPricing == true )
        {
            Response.Redirect(attributeslink + but_buy.CommandArgument);
        } 

        //Check if product has attributes     
                 
            ZNodeSKU SKU = new ZNodeSKU();
        
            SKU = ZNodeSKU.CreateByProductDefault(_product.ProductID);
            SKU.AttributesDescription = ""; 

            if (SKU.QuantityOnHand == 0)
            {
                Response.Redirect(attributeslink + _product.ProductID);             
            }       
            _product.SelectedSKU = SKU;

            ZNodeShoppingCartItem item = new ZNodeShoppingCartItem();
            item.Product = _product;
            item.Quantity = 1;
            
           
            ZNodeShoppingCart shoppingCart = ZNodeShoppingCart.CurrentShoppingCart();
            
            if (shoppingCart == null)
            {
                shoppingCart = new ZNodeShoppingCart();
                shoppingCart.AddToSession(ZNodeSessionKeyType.ShoppingCart);
            }
           
            shoppingCart.AddToCart(item);
            

            Response.Redirect(link);        
    }

    protected void lstFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDataListPagedDataSource();
    }
    #endregion
    
}
