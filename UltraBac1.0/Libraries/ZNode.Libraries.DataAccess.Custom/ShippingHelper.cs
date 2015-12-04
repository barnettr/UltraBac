using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Manages the methods related to the Shipping options and their shipping rules
    /// </summary>
    public class ShippingHelper
    {
        /// <summary>
        /// Get all the shipping options for a portal
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public DataSet GetShippingOptionsByPortal(int PortalID)
        {
            // Create Instance of Connection  Object
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
						using ( SqlConnection MyConnection = new SqlConnection(ConnectionString) )
						{

							//Create Instance of Adapter  Object
							SqlDataAdapter MyDataAdapter = new SqlDataAdapter("ZNODE_GetShippingOptionsByPortal", MyConnection);

							//Mark as stored procedure
							MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

							// Add Parameters to Stored Procedure
							SqlParameter myParam = new SqlParameter("@PortalID", SqlDbType.Int);
							myParam.Value = PortalID;

							MyDataAdapter.SelectCommand.Parameters.Add(myParam);

							//Fill DataSet 
							DataSet MyDataSet = new DataSet();

							MyDataAdapter.Fill(MyDataSet);

							//Return DataSet
							return MyDataSet;
						}
        }

        /// <summary>
        /// Get the shipping rules for a shipping option
        /// </summary>
        /// <param name="ShippingID"></param>
        /// <returns></returns>
				public DataSet GetShippingRules(int ShippingID)
				{
					// Create Instance of Connection  Object
					string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
					using ( SqlConnection MyConnection = new SqlConnection(ConnectionString) )
					{

						//Create Instance of Adapter  Object
						SqlDataAdapter MyDataAdapter = new SqlDataAdapter("ZNODE_GetShippingRules", MyConnection);

						//Mark as stored procedure
						MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to Stored Procedure
						SqlParameter myParam = new SqlParameter("@ShippingID", SqlDbType.Int);
						myParam.Value = ShippingID;

						MyDataAdapter.SelectCommand.Parameters.Add(myParam);

						//Fill DataSet 
						DataSet MyDataSet = new DataSet();

						MyDataAdapter.Fill(MyDataSet);

						MyConnection.Close();

						//Return DataSet
						return MyDataSet;
					}
				}
    }
}
