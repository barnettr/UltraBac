using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Product SKU helper related functions
    /// </summary>
    public class SKUHelper
    {
        # region Protected Member Variables
        protected SqlConnection MySqlConnection = null;
        protected SqlDataAdapter MySqlAdaptor= null;        
        # endregion


        #region Public Methods


				public bool GetSKUAttributes(int ProductId, int SkuId, string SelectAttributes)
				{

					//Connection String
					string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;

					//Establish Connection
					using ( MySqlConnection = new SqlConnection(ConnectionString) )
					{


						//Create Instance of DataAdapter Object
						MySqlAdaptor = new SqlDataAdapter("ZNODE_GETSKUATTRIBUTECOMBO_BYPRODUCTID", MySqlConnection);

						DataSet MyDataset = new DataSet();

						// Mark  Command as Stored Procedure
						MySqlAdaptor.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Add parameter to Command Object
						SqlParameter Myparam;

						Myparam = new SqlParameter("@PRODUCTID", SqlDbType.Int);
						Myparam.Value = ProductId;
						MySqlAdaptor.SelectCommand.Parameters.Add(Myparam);

						Myparam = new SqlParameter("@ATTRIBUTES", SqlDbType.NVarChar);
						Myparam.Value = SelectAttributes;
						MySqlAdaptor.SelectCommand.Parameters.Add(Myparam);

						// Fills the data.
						MySqlAdaptor.Fill(MyDataset);
						MySqlConnection.Close();
						// Row count
						if ( MyDataset.Tables[0].Rows.Count > 0 )
						{
							if ( SkuId > 0 )
							{
								int value = (int)MyDataset.Tables[0].Rows[0]["SKUID"];
								if ( SkuId == value )
								{
									return false;
								}
								else
								{
									return true;
								}
							}
							return true;
						}
					}
					return false;

				}
        #endregion
    }
}
