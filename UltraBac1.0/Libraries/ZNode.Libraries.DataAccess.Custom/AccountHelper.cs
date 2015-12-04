using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{

    /// <summary>
    /// This Class manages Customer Account 
    /// </summary>
    public class AccountHelper
    {
        /// <summary>
        /// Returns a Customer List for this portal
        /// </summary>
        /// <param name="portalID"></param>
        /// <returns></returns>
        public DataSet GetAll(int portalID)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlDataAdapter mySqlAdapter = new SqlDataAdapter("ZNODE_GetAllCustomers", myConnection);

						// Mark the Command as a SPROC
						mySqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Add parameters to Command Object
						SqlParameter parameterportalID = new SqlParameter("@PORTALID", SqlDbType.Int);
						parameterportalID.Value = portalID;
						mySqlAdapter.SelectCommand.Parameters.Add(parameterportalID);

						// Create and Fill the DataSet
						DataSet myDataSet = new DataSet();
						mySqlAdapter.Fill(myDataSet);

						//Release Resources
						mySqlAdapter.Dispose();
						myConnection.Dispose();

						//Return DataSet
						return myDataSet;
					}
        }
    }
}
