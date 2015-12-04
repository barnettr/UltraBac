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
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.ECommerce.Business;


public partial class Admin_Secure_catalog_product_add_sku : System.Web.UI.Page
{

    # region Protected Member Variables
    protected int ItemID = 0;
    protected int skuID = 0;
    protected int productTypeID = 0;
    protected static int SKUAttributeID = 0;
    protected string viewLink = "~/admin/secure/catalog/product/view.aspx?itemid=";
    # endregion

    # region Page Load

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check License
        ZNodeLicenseManager lm = new ZNodeLicenseManager();
        if (!lm.AllowAttributes())
        {
            Server.Transfer("~/admin/secure/denied.aspx");
        }

        if (Request.Params["itemid"] != null)
        {
            ItemID = int.Parse(Request.Params["itemid"].ToString());
        }

        if (Request.Params["skuid"] != null)
        {
            skuID = int.Parse(Request.Params["skuid"].ToString());
        }

        if (Request.Params["typeid"] != null)
        {
            productTypeID = int.Parse(Request.Params["typeid"].ToString());
        }

        this.Bind();

        if (!Page.IsPostBack)
        {

            if ((ItemID > 0) && (skuID > 0))
            {
                lblHeading.Text = "Edit Product SKU";

                //Bind Sku Details
                this.BindDatas();

                //Bind Attributes
                this.BindAttributes();

            }
            else
            {
                lblHeading.Text = "Add Product SKU";
            }

        }
    }
    # endregion

    # region Bind SKU
    /// <summary>
    /// Bind control display based on properties set
    /// </summary>
    public void Bind()
    {

        ProductAdmin _adminAccess = new ProductAdmin();

        DataSet MyDataSet = _adminAccess.GetAttributeTypeByProductTypeID(productTypeID);

        //Repeats until Number of AttributeType for this Product
        foreach (DataRow dr in MyDataSet.Tables[0].Rows)
        {
            //Bind Attributes
            DataSet _AttributeDataSet = _adminAccess.GetByAttributeTypeID(int.Parse(dr["attributetypeid"].ToString()));

            System.Web.UI.WebControls.DropDownList lstControl = new DropDownList();
            lstControl.ID = "lstAttribute" + dr["AttributeTypeId"].ToString();

            ListItem li = new ListItem(dr["Name"].ToString(), "0");
            li.Selected = true;

            lstControl.DataSource = _AttributeDataSet;
            lstControl.DataTextField = "Name";
            lstControl.DataValueField = "AttributeId";
            lstControl.DataBind();
            lstControl.Items.Insert(0, li);

            if (!Convert.ToBoolean(dr["IsPrivate"]))
            {
                //Add Dynamic Attribute DropDownlist in the Placeholder
                ControlPlaceHolder.Controls.Add(lstControl);

                //Required Field validator to check SKU Attribute
                RequiredFieldValidator FieldValidator = new RequiredFieldValidator();
                FieldValidator.ID = "Validator" + dr["AttributeTypeId"].ToString();
                FieldValidator.ControlToValidate = "lstAttribute" + dr["AttributeTypeId"].ToString();
                FieldValidator.ErrorMessage = "Select " + dr["Name"].ToString();
                FieldValidator.Display = ValidatorDisplay.Dynamic;
                FieldValidator.CssClass = "Error";
                FieldValidator.InitialValue = "0";

                ControlPlaceHolder.Controls.Add(FieldValidator);
                Literal lit1 = new Literal();
                lit1.Text = "&nbsp;&nbsp;";
                ControlPlaceHolder.Controls.Add(lit1);
            }


        }

        //Hide the Product Attribute
        if (MyDataSet.Tables[0].Rows.Count == 0)
        {
            DivAttributes.Visible = false;
        }


    }


    /// <summary>
    /// Bind Edit Attributes
    /// </summary>
    private void BindAttributes()
    {
        SKUAdmin _adminSKU = new SKUAdmin();
        ProductAdmin _adminAccess = new ProductAdmin();

        DataSet SkuDataSet = _adminSKU.GetBySKUId(skuID);
        DataSet MyDataSet = _adminAccess.GetAttributeTypeByProductTypeID(productTypeID);


        foreach (DataRow dr in MyDataSet.Tables[0].Rows)
        {
            foreach (DataRow Dr in SkuDataSet.Tables[0].Rows)
            {
                System.Web.UI.WebControls.DropDownList lstControl = (System.Web.UI.WebControls.DropDownList)ControlPlaceHolder.FindControl("lstAttribute" + dr["AttributeTypeId"].ToString());

                if (lstControl != null)
                {
                    lstControl.SelectedValue = Dr["Attributeid"].ToString();
                }
            }
        }

    }

    /// <summary>
    /// Binds Edit SKU Datas
    /// </summary>
    private void BindDatas()
    {
        //Create Instance for SKU Admin and SKU entity
        SKUAdmin _adminSKU = new SKUAdmin();
        SKU _SKUList = _adminSKU.GetBySKUID(skuID);

        if (_SKUList != null)
        {
            SKU.Text = _SKUList.SKU;
            Quantity.Text = _SKUList.QuantityOnHand.ToString();
            ReOrder.Text = _SKUList.ReorderLevel.ToString();
            WeightAdditional.Text = _SKUList.WeightAdditional.ToString();
            if (_SKUList.RetailPriceAdditional != null)
            {
                RetailPrice.Text = String.Format("{0:0.00}", _SKUList.RetailPriceAdditional.Value);
            }
            VisibleInd.Checked = _SKUList.ActiveInd;  
        }

    }

    # endregion

    # region General Events

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        # region Declarations
        SKUAdmin _AdminAccess = new SKUAdmin();
        SKU _skuList = new SKU();
        SKUAttribute _skuAttribList = new SKUAttribute();
        ProductAdmin _adminAccess = new ProductAdmin();
        # endregion


        if (skuID > 0)
        {
            _skuList = _AdminAccess.GetBySKUID(skuID);

        }

        //Set Values to SKU
        _skuList.SKU = SKU.Text.Trim();
        _skuList.QuantityOnHand = int.Parse(Quantity.Text.Trim());
        if (ReOrder.Text.Trim().Length > 0)
        {
            _skuList.ReorderLevel = int.Parse(ReOrder.Text.Trim());
        }
        if (WeightAdditional.Text.Trim().Length > 0)
        {
            _skuList.WeightAdditional = Convert.ToDecimal(WeightAdditional.Text);
        }
        if (RetailPrice.Text.Trim().Length > 0)
        {
            _skuList.RetailPriceAdditional = Convert.ToDecimal(RetailPrice.Text);
        }
        _skuList.ProductID = ItemID;
        _skuList.ActiveInd = VisibleInd.Checked;


       
        // For Attribute value.
        string Attributes = String.Empty;

        DataSet MyAttributeTypeDataSet = _adminAccess.GetAttributeTypeByProductTypeID(productTypeID);

        foreach (DataRow MyDataRow in MyAttributeTypeDataSet.Tables[0].Rows)
        {
            System.Web.UI.WebControls.DropDownList lstControl = (System.Web.UI.WebControls.DropDownList)ControlPlaceHolder.FindControl("lstAttribute" + MyDataRow["AttributeTypeId"].ToString());

            int selValue = int.Parse(lstControl.SelectedValue);

            Attributes += selValue.ToString() + ",";
        }

        // Split the string
        string Attribute = Attributes.Substring(0,Attributes.Length - 1);


        // To check SKU combination is already exists.
        bool RetValue = _AdminAccess.CheckSKUAttributes(ItemID,skuID,Attribute);


        if (!RetValue)
        {
            bool Check = false;

            //Check For Edit SKu
            if (skuID > 0)
            {
                //Update Product SKU
                Check = _AdminAccess.Update(_skuList);

                //Delete SKUAttributes
                _AdminAccess.DeleteBySKUId(skuID);

            }
            else
            {
                //Add New Product SKU and SKUAttribute
                Check = _AdminAccess.Add(_skuList, out  skuID);
            }

            foreach (DataRow MyDataRow in MyAttributeTypeDataSet.Tables[0].Rows)
            {
                System.Web.UI.WebControls.DropDownList lstControl = (System.Web.UI.WebControls.DropDownList)ControlPlaceHolder.FindControl("lstAttribute" + MyDataRow["AttributeTypeId"].ToString());

                int selValue = int.Parse(lstControl.SelectedValue);

                if (selValue > 0)
                {
                    _skuAttribList.AttributeId = selValue;
                }

                _skuAttribList.SKUID = skuID;

                _AdminAccess.AddSKUAttribute(_skuAttribList);

            }

            if (Check)
            {
                //Redirect to View Page
                Response.Redirect(viewLink + ItemID + "&mode=inventory");
            }
            else
            {
                //Do nothing
            }
        }
        else
        {
            lblError.Text = "* This Attribute combination already exists for this product. Please select different combination.";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //Redirect to View Page
        Response.Redirect(viewLink + ItemID + "&mode=inventory");

    }

    # endregion  

}
