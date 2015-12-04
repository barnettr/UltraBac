using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// This Class Manages Product Attribute Type functionalities
    /// </summary>
    public class AttributeTypeHelper
    {

        # region Protected Member Variables
        protected SqlConnection myConn = null;
        protected SqlDataAdapter MyAdapter = null;
        protected SqlCommand myCmd = null;
        protected DataSet MydataSet = null;
        # endregion

        ///<summary>
        ///Returns the attribute type for this product type
        ///</summary>
        /// <param name="ProductTypeID"></param>
        /// <returns></returns>
        public DataSet GetByProductTypeID(int ProductTypeID, int portalID)
        {

            // Create Instance of Connection Object
            string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ToString();
						using ( myConn = new SqlConnection(ConnectionStr) )
						{


							// Create Instance of SqlCommand Object
							MyAdapter = new SqlDataAdapter("ZNode_GetByProductTypeID", myConn);
							MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

							// Add Parameters to SPROC
							SqlParameter myparam1 = new SqlParameter("@PRODUCTTYPEID", SqlDbType.Int);
							myparam1.Value = ProductTypeID;
							MyAdapter.SelectCommand.Parameters.Add(myparam1);

							SqlParameter myparam2 = new SqlParameter("@PORTALID", SqlDbType.Int);
							myparam2.Value = portalID;
							MyAdapter.SelectCommand.Parameters.Add(myparam2);

							// Execute the Query
							MydataSet = new DataSet();
							MyAdapter.Fill(MydataSet);

							myConn.Close();

							//return the Value
							return MydataSet;
						}

        }

        ///<summary>
        ///Returns the attribute Types for this product type
        ///</summary>
        /// <param name="ProductTypeID"></param>
        /// <returns></returns>
				public DataSet GetAttributeTypesByProductTypeID(int ProductTypeID)
				{

					// Create Instance of Connection Object
					string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ToString();
					using ( myConn = new SqlConnection(ConnectionStr) )
					{


						// Create Instance of SqlCommand Object
						MyAdapter = new SqlDataAdapter("ZNode_GetAttribuetypesByProductType", myConn);
						MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter myparam1 = new SqlParameter("@PRODUCTTYPEID", SqlDbType.Int);
						myparam1.Value = ProductTypeID;
						MyAdapter.SelectCommand.Parameters.Add(myparam1);


						// Execute the Query
						MydataSet = new DataSet();
						MyAdapter.Fill(MydataSet);
						myConn.Close();
						//return the Value
						return MydataSet;

					}
				}
        
        ///<summary>
        ///Returns the attributes for this product type
        ///</summary>
        /// <param name="ProductTypeID"></param>
        /// <returns></returns>
				public DataSet GetAttributesByProductTypeID(int ProductTypeID)
				{

					// Create Instance of Connection Object
					string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ToString();
					using ( myConn = new SqlConnection(ConnectionStr) )
					{


						// Create Instance of SqlCommand Object
						MyAdapter = new SqlDataAdapter("ZNode_GetAttribuesByProductType", myConn);
						MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter myparam1 = new SqlParameter("@PRODUCTTYPEID", SqlDbType.Int);
						myparam1.Value = ProductTypeID;
						MyAdapter.SelectCommand.Parameters.Add(myparam1);


						// Execute the Query
						MydataSet = new DataSet();
						MyAdapter.Fill(MydataSet);
						myConn.Close();
						//return the Value
						return MydataSet;

					}
				}
               
    }
}
