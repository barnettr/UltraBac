using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Category related helper functions
    /// </summary>
    public class CategoryHelper
    {
        /// <summary>
        /// Get Category as XML
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public string GetCategoryXML(int categoryId, int portalId)
        {
            // Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetCategoryById_XML", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterPortalID = new SqlParameter("@PortalID", SqlDbType.Int, 4);
						parameterPortalID.Value = portalId;
						myCommand.Parameters.Add(parameterPortalID);

						SqlParameter parametercategoryId = new SqlParameter("@categoryId", SqlDbType.Int, 4);
						parametercategoryId.Value = categoryId;
						myCommand.Parameters.Add(parametercategoryId);

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
        /// Returns navigation items for a portal
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public DataSet GetNavigationItems(int portalId)
        {
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{

						SqlDataAdapter myCommand = new SqlDataAdapter("ZNODE_GetShoppingCartNavigationItems", myConnection);

						// Mark the Command as a SPROC
						myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterportalId = new SqlParameter("@portalId", SqlDbType.Int, 4);
						parameterportalId.Value = portalId;
						myCommand.SelectCommand.Parameters.Add(parameterportalId);

						// Create and Fill the DataSet
						DataSet myDataSet = new DataSet();
						myCommand.Fill(myDataSet);

						//close connection
						myConnection.Close();

						//Return DataSet
						return myDataSet;
					}
        }

        /// <summary>
        /// Get Root Categories
        /// </summary>
        /// <param name="SiteId"></param>
        /// <returns></returns>
        public DataSet GetRootCategoryItems(int portalId)
        {
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{

						SqlDataAdapter myCommand = new SqlDataAdapter("ZNODE_GetCategoryRootItems", myConnection);

						// Mark the Command as a SPROC
						myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

						// Add Parameters to SPROC
						SqlParameter parameterportalId = new SqlParameter("@portalId", SqlDbType.Int, 4);
						parameterportalId.Value = portalId;
						myCommand.SelectCommand.Parameters.Add(parameterportalId);

						// Create and Fill the DataSet
						DataSet myDataSet = new DataSet();
						myCommand.Fill(myDataSet);

						//close connection
						myConnection.Close();

						//return DataSet
						return myDataSet;
					}
        }


        /// <summary>
        /// Returns navigation items for a portal
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
				public string GetCategoryPathByCategoryId(int categoryId)
				{
					// Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetCategoryPathByCategoryID", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						SqlParameter parametercategoryId = new SqlParameter("@categoryId", SqlDbType.Int, 4);
						parametercategoryId.Value = categoryId;
						myCommand.Parameters.Add(parametercategoryId);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						System.Text.StringBuilder strOut = new System.Text.StringBuilder();

						while ( reader.Read() )
						{
							strOut.Append(reader[0].ToString());
						}
						myConnection.Close();
						return strOut.ToString();
					}
				}

        /// <summary>
        /// Returns navigation items for a portal
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
				public string GetCategoryPathByProductId(int productId)
				{
					// Create Instance of Connection and Command Object
					using ( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{
						SqlCommand myCommand = new SqlCommand("ZNODE_GetCategoryPathByProductID", myConnection);

						// Mark the Command as a SPROC
						myCommand.CommandType = CommandType.StoredProcedure;

						SqlParameter parameterproductId = new SqlParameter("@productId", SqlDbType.Int, 4);
						parameterproductId.Value = productId;
						myCommand.Parameters.Add(parameterproductId);

						// Execute the command
						myConnection.Open();
						SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

						System.Text.StringBuilder strOut = new System.Text.StringBuilder();

						while ( reader.Read() )
						{
							strOut.Append(reader[0].ToString());
						}
						myConnection.Close();
						return strOut.ToString();
					}
				}

	
	/// <summary>
        /// Get the list of categories to display in a list box
        /// </summary>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public DataSet GetCategoryHierarchy(int portalId)
        {
            // Create Instance of Connection and Command Object
           using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString)) {
            SqlDataAdapter myCommand = new SqlDataAdapter("ZNODE_GetCategories", myConnection);

            // Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterportalId = new SqlParameter("@portalId", SqlDbType.Int, 4);
            parameterportalId.Value = portalId;
            myCommand.SelectCommand.Parameters.Add(parameterportalId);

            // Create and Fill the DataSet
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet);
						myConnection.Close();
            //Return DataSet
            return myDataSet;
				}
        }
    }


}
