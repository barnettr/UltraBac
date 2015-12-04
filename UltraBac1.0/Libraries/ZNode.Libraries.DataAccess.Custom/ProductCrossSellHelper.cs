using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{

    /// <summary>
    /// Product CrossSell related Helper methods
    /// </summary>
    public class ProductCrossSellHelper
    {
        #region Protected Member Variables
        protected SqlConnection MySqlConnection = null;
        protected SqlCommand MySqlCommand = null;
        protected SqlDataAdapter MySqlAdapter = null;
        #endregion


        #region Public Methods
               
        /// <summary>
        /// returns related product items for a product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns>DataSet</returns>
				public DataSet GetByProductID(int ProductID)
				{

					// Create Instance of Connection Object
					string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ToString();
					using ( MySqlConnection = new SqlConnection(ConnectionString) )
					{

						// Create Instance of Adapter Object
						MySqlAdapter = new SqlDataAdapter("ZNODE_GetRelatedProductByProductID", MySqlConnection);

						//Mark the Command as a SPROC
						MySqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Declare parameters and Add Parameters to SPROC

						SqlParameter MyParam = new SqlParameter("@Product_id", SqlDbType.Int);
						MyParam.Value = ProductID;

						MySqlAdapter.SelectCommand.Parameters.Add(MyParam);

						//Fill DatatSet
						DataSet MyDataSet = new DataSet();

						MySqlAdapter.Fill(MyDataSet);

						//return dataset
						return MyDataSet;


					}
				}
        /// <summary>
        ///  Add a new product crossSell item
        /// </summary>
        /// <param name="PortalID"></param>
        /// <param name="ProductID"></param>
        /// <param name="RelatedProductID"></param>
        public bool Insert(int PortalID, int ProductID, int RelatedProductID)
        {

            bool returnBool = false;
            try
            {
                // Create Instance of Connection Object
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ToString();
								using ( MySqlConnection = new SqlConnection(ConnectionString) )
								{

									// Create Instance of  Command Object
									MySqlCommand = new SqlCommand("ZNODE_INSERTRELATEDPRODUCT", MySqlConnection);

									//Mark the Command as Stored Procedure
									MySqlCommand.CommandType = CommandType.StoredProcedure;

									//Declare parameters and Pass Values
									SqlParameter MyParam1 = new SqlParameter("@portalID", SqlDbType.Int);
									MyParam1.Value = PortalID;

									SqlParameter MyParam2 = new SqlParameter("@productID", SqlDbType.Int);
									MyParam2.Value = ProductID;

									SqlParameter MyParam3 = new SqlParameter("@RelatedProductId", SqlDbType.Int);
									MyParam3.Value = RelatedProductID;

									//Add parameters to Command Object
									MySqlCommand.Parameters.Add(MyParam1);
									MySqlCommand.Parameters.Add(MyParam2);
									MySqlCommand.Parameters.Add(MyParam3);

									//Execute the Query 
									MySqlConnection.Open();
									MySqlCommand.ExecuteNonQuery();
									MySqlConnection.Close();

									returnBool = true;
								}
            }
            catch { } 
         
            return returnBool;
        }
                     
        /// <summary>
        /// Delete a product cross sell item   
        /// </summary>
        /// <param name="RelatedProductID"></param>
        /// <param name="productID"></param>
        /// <param name="PortalID"></param>
        /// <returns>Boolean</returns>
        public bool RemoveProduct(int RelatedProductID,int productID,int PortalID)
        {
            bool ReturnBool = false;

            try
            {
                // Create Instance of Connection Object
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ToString();
								using ( MySqlConnection = new SqlConnection(ConnectionString) )
								{

									// Create Instance of  Command Object
									MySqlCommand = new SqlCommand("ZNODE_DELETERELATEDPRODUCT", MySqlConnection);

									//Mark the Command as Stored Procedure
									MySqlCommand.CommandType = CommandType.StoredProcedure;

									//Declare parameters 
									SqlParameter MyParam1 = new SqlParameter("@portalID", SqlDbType.Int);
									MyParam1.Value = PortalID;

									SqlParameter MyParam2 = new SqlParameter("@productID", SqlDbType.Int);
									MyParam2.Value = productID;

									SqlParameter MyParam3 = new SqlParameter("@RelatedProductId", SqlDbType.Int);
									MyParam3.Value = RelatedProductID;

									//Add parameters to Command Object
									MySqlCommand.Parameters.Add(MyParam1);
									MySqlCommand.Parameters.Add(MyParam2);
									MySqlCommand.Parameters.Add(MyParam3);

									//Execute the Query 
									MySqlConnection.Open();
									MySqlCommand.ExecuteNonQuery();
									MySqlConnection.Close();

									ReturnBool = true;
								}
            }
            catch { }

            //return Boolean
            return ReturnBool;
        }

        #endregion
    }
}
