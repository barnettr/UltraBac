using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Product Related Helper Methods
    /// </summary>
    public class ProductHelper
    {
        #region Protected Member Variables
        protected SqlConnection MyConnection = null;
        protected SqlCommand MyCommand = null;
        protected SqlDataAdapter MyAdapter = null;
        
        #endregion

        #region Public Methods
        
        
	    /// <summary>
        /// Get All Product details for a product id
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public DataSet GetProductDetails(int ProductID)
        {
            string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( MyConnection = new SqlConnection(ConnectionStr) )
						{

							// Create Instance of Adapter Object
							MyAdapter = new SqlDataAdapter("ZNODE_GETPRODUCTDETAILS", MyConnection);

							// Mark the Command as a Stored Procedures
							MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

							//Declare parameters and Add to Command Object
							SqlParameter p1 = new SqlParameter("@PRODUCT_ID", SqlDbType.Int);
							p1.Value = ProductID;

							MyAdapter.SelectCommand.Parameters.Add(p1);

							//Fill DataSet
							DataSet ds = new DataSet();

							MyAdapter.Fill(ds);

							//Return Dataset
							return ds;
						}
        }

        /// <summary>
        /// Returns a category for a product 
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public DataSet Get_CategoryByProductID(int ProductID)
        {

            string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( MyConnection = new SqlConnection(ConnectionStr) )
						{

							//Create Instance of Adapter Object
							MyAdapter = new SqlDataAdapter("ZNODE_GETCATEGORYBYPRODUCTID", MyConnection);

							// Mark the Command as a Stored Procedure
							MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

							//Declare Parameters and Add to Command Object
							SqlParameter p1 = new SqlParameter("@PRODUCT_ID", SqlDbType.Int);
							p1.Value = ProductID;

							MyAdapter.SelectCommand.Parameters.Add(p1);

							//fill DataSet
							DataSet ds = new DataSet();

							MyAdapter.Fill(ds);

							//return DataSet

							return ds;
						}
        }
        /// <summary>
        /// Returns a category hierarchical path (upto 3 levels)
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="ParentCategoryName1"></param>
        /// <param name="ParentCategoryName2"></param>
        /// <returns></returns>
        public static string GetCategoryPath(string CategoryName, string ParentCategoryName1, string ParentCategoryName2)
        {
            System.Text.StringBuilder _path = new StringBuilder();
            if (ParentCategoryName2.Trim().Length > 0)
            {
                _path.Append(ParentCategoryName2);
                _path.Append(" > ");
            }
            if (ParentCategoryName1.Trim().Length > 0)
            {
                _path.Append(ParentCategoryName1);
                _path.Append(" > ");
            }
            _path.Append(CategoryName);
            return _path.ToString();
        }

        /// <summary>
        /// Search products and return Dataset
        /// </summary>
        /// <param name="portalID"></param>
        /// <param name="Keywords"></param>
        /// <returns></returns>
        public DataSet Search(int portalID, string Keywords )
        {

            string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( MyConnection = new SqlConnection(ConnectionStr) )
						{

							//Create Instance of Adapter Object
							MyAdapter = new SqlDataAdapter("ZNODE_SearchByParitalKeyword", MyConnection);

							// Mark the Command as a Stored Procedure
							MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

							//Declare Parameters and Add to Command Object
							SqlParameter p1 = new SqlParameter("@PORTALID", SqlDbType.Int);
							p1.Value = portalID;
							SqlParameter p2 = new SqlParameter("@KEYWORDS", SqlDbType.VarChar);
							p2.Value = Keywords;

							MyAdapter.SelectCommand.Parameters.Add(p1);
							MyAdapter.SelectCommand.Parameters.Add(p2);

							//Fill DataSet
							DataSet ds = new DataSet();

							MyAdapter.Fill(ds);

							// Return DataSet
							return ds;

						}
        }
        
        /// <summary>
        ///  Empty catalog data
        /// </summary>
        /// <returns>Boolean Value</returns>
        public bool EmptyCatalog()
        {
            System.Data.SqlClient.SqlTransaction _transaction = null;
            bool Status = false;
						string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( MyConnection = new SqlConnection(ConnectionStr) )
						{
							try
							{
								//Open Connection
								MyConnection.Open();

								// BeginTransaction() Requires Open Connection
								_transaction = MyConnection.BeginTransaction();

								//Create instance of Command Object
								MyCommand = new SqlCommand("ZNODE_EMPTYCATALOG", MyConnection);

								// Mark the Command as a Stored Procedure
								MyCommand.CommandType = CommandType.StoredProcedure;

								// Assign Transaction to Command
								MyCommand.Transaction = _transaction;

								//Execute Query
								MyCommand.ExecuteNonQuery();

								//Set Return values 
								Status = true;

								//If we reach here, all command succeeded, so commit the transaction
								_transaction.Commit();
							}
							catch ( Exception )
							{
								//Something went wrong, so rollback the transaction
								_transaction.Rollback();
								Status = false;
							}
							finally
							{
								if ( _transaction != null )
									_transaction.Dispose();

								if ( MyConnection != null )
								{
									//Finally, close the connection
									MyConnection.Close();

									//Release Resources
									MyConnection.Dispose();
								}
							}
						}
            //Return boolean value
            return Status;
        }

        /// <summary>
        ///  Delete the product 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="RelateProuductId"></param>
        /// <param name="portalId"></param>
        public void DeleteByProductId(int productId, int portalId)
        {

            string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( MyConnection = new SqlConnection(ConnectionStr) )
						{


							//Create instance of Command Object
							MyCommand = new SqlCommand("ZNODE_DeleteByProductID", MyConnection);

							// Mark the Command as a Stored Procedure
							MyCommand.CommandType = CommandType.StoredProcedure;

							//Delcare Parameters and Pass Values
							SqlParameter p1 = new SqlParameter("@PRODUCTID", SqlDbType.Int);
							p1.Value = productId;

							SqlParameter p2 = new SqlParameter("@PORTALID", SqlDbType.Int);
							p2.Value = portalId;

							//Add parameters
							MyCommand.Parameters.Add(p1);
							MyCommand.Parameters.Add(p2);

							//Open Connection
							MyConnection.Open();

							//Execute Query
							MyCommand.ExecuteNonQuery();

							//Close Connection
							MyConnection.Close();
						}

        }

        /// <summary>
        /// Get Last inserted Product ID
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public int GetProductID(int portalID)
        {
            //Local variables;
            int ReturnProdID = 0;

            //Create Instance for Connection and Command Objects
            using ( MyConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString)) {
							MyCommand = new SqlCommand("ZNODE_GETGENERATEDPRODUCTID", MyConnection);

							// Mark the Command as a SPROC
							MyCommand.CommandType = CommandType.StoredProcedure;


							SqlParameter p1 = new SqlParameter("@PORTALID", SqlDbType.Int);
							p1.Value = portalID;

							// Add Parameters to SPROC
							MyCommand.Parameters.Add(p1);


							//Open Connection
							MyConnection.Open();

							//Execute Query
							ReturnProdID = Convert.ToInt32(MyCommand.ExecuteScalar());

							//Close Connection
							MyConnection.Close();

						}
            //return Product ID
            return ReturnProdID;
        }

        /// <summary>
        /// get product data as XML for serialization
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="SiteId"></param>
        /// <returns></returns>
				public string GetProductXML(int productId, int portalId)
				{
					// Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetProductByProductId_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterPortalID = new SqlParameter("@PortalID", SqlDbType.Int, 4);
						parameterPortalID.Value = portalId;
						myCommand.Parameters.Add(parameterPortalID);

						SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
						parameterProductID.Value = productId;
						myCommand.Parameters.Add(parameterProductID);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						System.Text.StringBuilder xmlOut = new System.Text.StringBuilder();

						while ( reader.Read() )
						{
							xmlOut.Append(reader[0].ToString());
						}

						return xmlOut.ToString();
					}
				}


        /// <summary>
        /// Search products and return XML
        /// </summary>
        /// <param name="portalID"></param>
        /// <param name="keywords"></param>
        /// <param name="delimiter"></param>
        /// <param name="categoryId"></param>
        /// <param name="searchOption"></param>
        /// <param name="sKU"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public string SearchProductsXML(int portalID, string keywords, string delimiter, int categoryId, int searchOption, string sKU, string productNum)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetProductsBySearch_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterPortalID = new SqlParameter("@PortalID", SqlDbType.Int, 4);
						parameterPortalID.Value = portalID;
						myCommand.Parameters.Add(parameterPortalID);

						SqlParameter parameterKeywords = new SqlParameter("@Keywords", SqlDbType.VarChar, 4000);
						parameterKeywords.Value = keywords;
						myCommand.Parameters.Add(parameterKeywords);

						SqlParameter parameterDelimiter = new SqlParameter("@Delimiter", SqlDbType.VarChar, 10);
						parameterDelimiter.Value = delimiter;
						myCommand.Parameters.Add(parameterDelimiter);

						SqlParameter parameterCategoryId = new SqlParameter("@CategoryId", SqlDbType.Int, 4);
						parameterCategoryId.Value = categoryId;
						myCommand.Parameters.Add(parameterCategoryId);

						SqlParameter parameterSearchOption = new SqlParameter("@SearchOption", SqlDbType.Int, 4);
						parameterSearchOption.Value = searchOption;
						myCommand.Parameters.Add(parameterSearchOption);

						SqlParameter parameterSKU = new SqlParameter("@SKU", SqlDbType.VarChar, 50);
						parameterSKU.Value = sKU;
						myCommand.Parameters.Add(parameterSKU);

						SqlParameter parameterProductNum = new SqlParameter("@ProductNum", SqlDbType.VarChar, 50);
						parameterProductNum.Value = productNum;
						myCommand.Parameters.Add(parameterProductNum);


						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						string xmlOut = "";

						while ( reader.Read() )
						{
							xmlOut = xmlOut + reader[0].ToString();
						}

						xmlOut = "<ZNodeProductList>" + xmlOut + "</ZNodeProductList>";

						return xmlOut;
					}
        }

        /// <summary>
        /// Get the Home Page Specials as XML
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public string GetHomePageSpecialsXML(int portalId)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetHomePageSpecials_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterPortalID = new SqlParameter("@PortalID", SqlDbType.Int, 4);
						parameterPortalID.Value = portalId;
						myCommand.Parameters.Add(parameterPortalID);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						System.Text.StringBuilder xmlOut = new System.Text.StringBuilder();

						while ( reader.Read() )
						{
							xmlOut.Append(reader[0].ToString());
						}

						return xmlOut.ToString();
					}
        }

        /// <summary>
        /// Get the Products for a Brand
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
				public string GetProductsByBrandXML(int portalId, int manufacturerId)
				{
					// Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetProductsByBrand_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterPortalID = new SqlParameter("@PortalID", SqlDbType.Int, 4);
						parameterPortalID.Value = portalId;
						myCommand.Parameters.Add(parameterPortalID);

						SqlParameter parameterManufacturerID = new SqlParameter("@ManufacturerID", SqlDbType.Int, 4);
						parameterManufacturerID.Value = manufacturerId;
						myCommand.Parameters.Add(parameterManufacturerID);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						System.Text.StringBuilder xmlOut = new System.Text.StringBuilder();

						while ( reader.Read() )
						{
							xmlOut.Append(reader[0].ToString());
						}

						return xmlOut.ToString();
					}
				}

        /// <summary>
        /// Get the Products for a Price
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public string GetProductsByPriceXML(int portalId, decimal Minimum,decimal Maximum)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetProductsByPrice_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterPortalID = new SqlParameter("@PortalID", SqlDbType.Int, 4);
						parameterPortalID.Value = portalId;
						myCommand.Parameters.Add(parameterPortalID);

						SqlParameter parameterStartValue = new SqlParameter("@StartValue", SqlDbType.Decimal);
						parameterStartValue.Value = Minimum;
						myCommand.Parameters.Add(parameterStartValue);

						SqlParameter parameterEndValue = new SqlParameter("@EndValue", SqlDbType.Decimal);
						parameterEndValue.Value = Maximum;
						myCommand.Parameters.Add(parameterEndValue);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						System.Text.StringBuilder xmlOut = new System.Text.StringBuilder();

						while ( reader.Read() )
						{
							xmlOut.Append(reader[0].ToString());
						}

						return xmlOut.ToString();
					}
        }


        /// <summary>
        /// Gets a product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
				public string GetSKUByAttributes(int productId, string attributes)
				{
					// Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetSKUByAttributes_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
						parameterProductID.Value = productId;
						myCommand.Parameters.Add(parameterProductID);

						SqlParameter parameterAttributes = new SqlParameter("@Attributes", SqlDbType.VarChar, 8000);
						parameterAttributes.Value = attributes;
						myCommand.Parameters.Add(parameterAttributes);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						string xmlOut = "";

						while ( reader.Read() )
						{
							xmlOut = xmlOut + reader[0].ToString();
						}

						return xmlOut;
					}
				}

        /// <summary>
        /// Gets a product AddOns 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
				public string GetAddOnByValues(int productId, string SelectedValues)
				{
					// Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetAddOnsByAddOnValues_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
						parameterProductID.Value = productId;
						myCommand.Parameters.Add(parameterProductID);

						SqlParameter parameterAttributes = new SqlParameter("@AddOnValues", SqlDbType.VarChar, 8000);
						parameterAttributes.Value = SelectedValues;
						myCommand.Parameters.Add(parameterAttributes);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						string xmlOut = "";

						while ( reader.Read() )
						{
							xmlOut = xmlOut + reader[0].ToString();
						}

						xmlOut = "<ZNodeAddOnList>" + xmlOut + "</ZNodeAddOnList>";

						return xmlOut;
					}
				}

        /// <summary>
        /// Returns the SKU 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public string GetBySKU(string SKU)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetSKUBySKU_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterProductskuID = new SqlParameter("@SKU", SqlDbType.VarChar, 4000);
						parameterProductskuID.Value = SKU;
						myCommand.Parameters.Add(parameterProductskuID);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						string xmlOut = "";

						while ( reader.Read() )
						{
							xmlOut = xmlOut + reader[0].ToString();
						}
						//Return Value
						return xmlOut;
					}
        }

         /// <summary>
         /// Returns the default SKU for a product with NO attributes
         /// </summary>
         /// <param name="productId"></param>
         /// <returns></returns>
        public string GetDefaultSKU(int productId)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetDefaultSKUByProduct_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
						parameterProductID.Value = productId;
						myCommand.Parameters.Add(parameterProductID);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						string xmlOut = "";

						while ( reader.Read() )
						{
							xmlOut = xmlOut + reader[0].ToString();
						}

						return xmlOut;
					}
        }
        /// <summary>
        /// Get the manufactures as XML
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public string GetManufacturerXML(int ManufacturerID, int PortalID)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetManufacturerXML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterProdManufacturerID = new SqlParameter("@ManufacturerID", SqlDbType.Int, 4);
						parameterProdManufacturerID.Value = ManufacturerID;
						myCommand.Parameters.Add(parameterProdManufacturerID);

						SqlParameter parameterPortalID = new SqlParameter("@PortalID", SqlDbType.Int, 4);
						parameterPortalID.Value = PortalID;
						myCommand.Parameters.Add(parameterPortalID);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						string xmlOut = "";

						while ( reader.Read() )
						{
							xmlOut = xmlOut + reader[0].ToString();
						}

						return xmlOut;
					}
        }

        /// <summary>
        /// Gets a product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
         public int GetManufacturerName(string name)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNodeManufacturer_GetByName", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.VarChar, 4000);
						parameterName.Value = name;
						myCommand.Parameters.Add(parameterName);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
						int xmlOut = 0;

						//string xmlOut = "";

						while ( reader.Read() )
						{
							xmlOut = Convert.ToInt32(xmlOut + reader[0].ToString());
						}

						return xmlOut;
					}
        }


        /// <summary>
        /// Get the Product attribute type name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetAttributeTypeName(string name)
        {
					using ( SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand mycommand = new SqlCommand("ZNodeAttributeType_GetByName", myconnection);

						mycommand.CommandType = CommandType.StoredProcedure;

						SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.VarChar, 4000);
						parameterName.Value = name;
						mycommand.Parameters.Add(parameterName);

						myconnection.Open();
						SqlDataReader reader = mycommand.ExecuteReader(CommandBehavior.CloseConnection);
						int xmlOut = 0;

						while ( reader.Read() )
						{
							xmlOut = Convert.ToInt32(xmlOut + reader[0].ToString());
						}
						return xmlOut;
					}
        }


        /// <summary>
        /// Get the Product type name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
				public int GetProductTypeName(string name)
				{
					using ( SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand mycommand = new SqlCommand("ZNodeProductType_GetByName", myconnection);

						mycommand.CommandType = CommandType.StoredProcedure;

						SqlParameter parameterName = new SqlParameter("@Name", SqlDbType.VarChar, 4000);
						parameterName.Value = name;
						mycommand.Parameters.Add(parameterName);

						myconnection.Open();
						SqlDataReader reader = mycommand.ExecuteReader(CommandBehavior.CloseConnection);
						int xmlOut = 0;

						while ( reader.Read() )
						{
							xmlOut = Convert.ToInt32(xmlOut + reader[0].ToString());
						}
						return xmlOut;
					}
				}

        /// <summary>
        /// Returns the filtered Product DataSet
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Productnum"></param>
        /// <param name="sku"></param>
        /// <param name="manufacturerid"></param>
        /// <param name="producttypeid"></param>
        /// <param name="categoryid"></param>        
        /// <returns>DataSet</returns>
        public DataSet SearchProduct(string Name, string Productnum, string sku, string manufacturerid, string producttypeid, string categoryid)
        {

            string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( MyConnection = new SqlConnection(ConnectionStr) )
						{

							MyAdapter = new SqlDataAdapter("ZNODE_SEARCHPRODUCT", MyConnection);

							// Mark the Command as a Stored Procedure
							MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


							SqlParameter parametername = new SqlParameter("@Name", SqlDbType.VarChar, 4000);
							parametername.Value = Name;
							MyAdapter.SelectCommand.Parameters.Add(parametername);


							SqlParameter parameterproductnum = new SqlParameter("@Productnum", SqlDbType.VarChar, 4000);
							parameterproductnum.Value = Productnum;
							MyAdapter.SelectCommand.Parameters.Add(parameterproductnum);

							SqlParameter parametersku = new SqlParameter("@sku", SqlDbType.VarChar, 4000);
							parametersku.Value = sku;
							MyAdapter.SelectCommand.Parameters.Add(parametersku);

							SqlParameter parametermanufacturerid = new SqlParameter("@manufacturerid", SqlDbType.VarChar, 4000);
							parametermanufacturerid.Value = manufacturerid;
							MyAdapter.SelectCommand.Parameters.Add(parametermanufacturerid);

							SqlParameter parameterproducttypeid = new SqlParameter("@producttypeid", SqlDbType.VarChar, 4000);
							parameterproducttypeid.Value = producttypeid;
							MyAdapter.SelectCommand.Parameters.Add(parameterproducttypeid);

							SqlParameter parametercategoryid = new SqlParameter("@categoryid", SqlDbType.VarChar, 4000);
							parametercategoryid.Value = categoryid;
							MyAdapter.SelectCommand.Parameters.Add(parametercategoryid);


							DataSet ds = new DataSet();

							MyAdapter.Fill(ds);

							return ds;
						}
        }   
  


        #endregion

        #region Public Methods - Related to Product AddOn and Values
        /// <summary>
        /// Returns AddOns as dataset for the given name and product or sku
        /// </summary>
        /// <param name="Name"></param>
        ///	<param name="Title"></param>
        /// <param name="ProductSKU"></param>
        /// <returns></returns>
				public DataSet SearchAddOns(string Name, string Title, string ProductSKU)
				{
					string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
					using ( MyConnection = new SqlConnection(ConnectionStr) )
					{

						MyAdapter = new SqlDataAdapter("ZNODE_SEARCH_ADDONS", MyConnection);

						// Mark the Command as a Stored Procedure
						MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Declare Parameters and set pararmeters to SqlCommand object
						SqlParameter parametername = new SqlParameter("@Name", SqlDbType.VarChar);
						parametername.Value = Name;
						MyAdapter.SelectCommand.Parameters.Add(parametername);

						SqlParameter parameterTitle = new SqlParameter("@Title", SqlDbType.VarChar);
						parameterTitle.Value = Title;
						MyAdapter.SelectCommand.Parameters.Add(parameterTitle);

						SqlParameter parameterproductnum = new SqlParameter("@SKUPRODUCT", SqlDbType.VarChar);
						parameterproductnum.Value = ProductSKU;
						MyAdapter.SelectCommand.Parameters.Add(parameterproductnum);


						DataSet ds = new DataSet();

						MyAdapter.Fill(ds);

						return ds;
					}
				}
        #endregion
    }
}
