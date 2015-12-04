using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Product Type related Helper  methods
    /// </summary>
    public class ProductTypeHelper
    {
        # region Protected Member Variables
        protected SqlConnection myConn = null;
        protected SqlDataAdapter MyAdapter = null;
        protected SqlCommand myCmd = null;
        protected DataSet MydataSet = null;
        # endregion

        # region Public Methods
           
        /// <summary>
        /// Returns Number of Product Types for this Attribute type
        /// </summary>
        /// <param name="attributeTypeID"></param>
        /// <returns></returns>
         public int GetProductTypeCount(int attributeTypeID)
         {
            int RetVal = 0;

            // Create Instance of Connection and Command Object
						using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
						{
							SqlCommand myCommand = new SqlCommand("ZNODE_GETPRODUCTTYPECOUNT", myConnection);

							// Mark the Command as a SPROC
							myCommand.CommandType = CommandType.StoredProcedure;

							//Add parameters to Command Object
							SqlParameter parameterattributetype = new SqlParameter("@AttributeTypeId", SqlDbType.Int);
							parameterattributetype.Value = attributeTypeID;
							myCommand.Parameters.Add(parameterattributetype);


							// execute the Command
							myConnection.Open();
							RetVal = int.Parse(myCommand.ExecuteScalar().ToString());
							myConnection.Close();

							//Release Resources
							myCommand.Dispose();
							myConnection.Dispose();


							//Return value
							return RetVal;
						}
        }
       
        /// <summary>
        /// Returns all product types for  a portal
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns>DataSet</returns>
				 public DataSet GetAllProductType(int PortalID)
				 {

					 // Create Instance of Connection Object
					 string ConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ToString();
					 using ( myConn = new SqlConnection(ConnectionStr) )
					 {


						 //CREATE INSTANCE OF SQLDATA ADAPTER
						 MyAdapter = new SqlDataAdapter("ZNODE_GETALLPRODUCTTYPE", myConn);

						 // Add Parameters to SPROC
						 MyAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
						 SqlParameter myparam1 = new SqlParameter("@PORTALID", SqlDbType.Int);
						 myparam1.Value = PortalID;

						 MyAdapter.SelectCommand.Parameters.Add(myparam1);

						 //Fill DataSet
						 DataSet MyDataset = new DataSet();
						 MyAdapter.Fill(MyDataset);

						 //Release Resources
						 MyAdapter.Dispose();
						 myConn.Dispose();

						 //return dataset
						 return MyDataset;

					 }
				 }
        # endregion
    }
}
