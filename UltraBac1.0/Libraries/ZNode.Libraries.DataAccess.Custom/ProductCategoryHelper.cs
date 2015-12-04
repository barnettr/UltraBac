using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ZNode.Libraries.DataAccess.Custom
{

    /// <summary>
    /// Product Category related helper functions
    /// </summary>
    public class ProductCategoryHelper
    {

        #region Protected Member Variables
        protected SqlConnection MyConnection = null;
        protected SqlDataAdapter MyDataAdapter = null;
        protected DataSet MyDataSet = null;
        #endregion


        #region Public Methods
        
        /// <summary>
        /// Returns category items for a productid
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns>DataSet</returns>
        public DataSet GetByProductID(int ProductID)
        {

            // Create Instance of Connection  Object
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( MyConnection = new SqlConnection(ConnectionString) )
						{

							//Create Instance of Adapter  Object
							MyDataAdapter = new SqlDataAdapter("ZNODE_GetProductCategoryByProductID", MyConnection);

							// Mark the Command as a SPROC
							MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

							// Add Parameters to SPROC
							SqlParameter myParam = new SqlParameter("@PRODUCTID", SqlDbType.Int);
							myParam.Value = ProductID;


							MyDataAdapter.SelectCommand.Parameters.Add(myParam);

							//Fill DataSet 
							MyDataSet = new DataSet();

							MyDataAdapter.Fill(MyDataSet);

							//Return DataSet
							return MyDataSet;
						}
        }

        /// <summary>
        /// Returns items for the Particular Product and Category Id
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="categoryID"></param>
        /// <returns>DataSet</returns>
				public DataSet GetByCategoryID(int ProductID, int categoryID)
				{

					// Create Instance of Connection  Object
					string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
					using ( MyConnection = new SqlConnection(ConnectionString) )
					{

						//Create Instance of Adapter  Object
						MyDataAdapter = new SqlDataAdapter("ZNODE_GetProductCategoryByCategoryID", MyConnection);

						//Mark as 
						MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to Stored Procedure
						SqlParameter myParam = new SqlParameter("@PRODUCTID", SqlDbType.Int);
						myParam.Value = ProductID;

						SqlParameter myParam1 = new SqlParameter("@CATEGORYID", SqlDbType.Int);
						myParam1.Value = categoryID;


						MyDataAdapter.SelectCommand.Parameters.Add(myParam);
						MyDataAdapter.SelectCommand.Parameters.Add(myParam1);

						//Fill DataSet 
						MyDataSet = new DataSet();

						MyDataAdapter.Fill(MyDataSet);

						MyConnection.Close();

						//Return DataSet
						return MyDataSet;

					}
				}
        #endregion
    }
}
