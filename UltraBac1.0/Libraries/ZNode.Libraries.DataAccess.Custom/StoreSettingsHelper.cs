using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Contains data access functions for store settings
    /// </summary>
    public class StoreSettingsHelper
    {

        /// <summary>
        /// Get all the payment settings for a portal
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public DataSet GetPaymentSettingsByPortal(int PortalID)
        {
            // Create Instance of Connection  Object
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;

					using( SqlConnection MyConnection = new SqlConnection(ConnectionString))
					{

            //Create Instance of Adapter  Object
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("ZNODE_GetPaymentSettingsByPortal", MyConnection);

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

    }
}
