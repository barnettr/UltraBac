using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Manages the customer Cases 
    /// </summary>
    public class CaseHelper
    {
        /// <summary>
        /// Searches cases for caseid,firstname,lastname,companyname,title and case status
        /// </summary>
        /// <param name="caseid"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="companyname"></param>
        /// <param name="title"></param>
        /// <param name="casestatus"></param>
        /// <returns>Returns Cases as as DataSet</returns>
        public DataSet SearchCase(int casestatus, string caseid, string firstname, string lastname, string companyname, string title)
        {
            // Create Instance of Connection and Command Object
           using( SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString))
					 {
            SqlDataAdapter mySqlAdapter = new SqlDataAdapter("ZNODE_SEARCHCASE", myConnection);

            // Mark the Command as a SPROC
            mySqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameter1 = new SqlParameter("@caseid", SqlDbType.VarChar);
            parameter1.Value = caseid;
            mySqlAdapter.SelectCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter("@firstname", SqlDbType.VarChar);
            parameter2.Value = firstname;
            mySqlAdapter.SelectCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter("@lastname", SqlDbType.VarChar);
            parameter3.Value = lastname;
            mySqlAdapter.SelectCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter("@companyname", SqlDbType.VarChar);
            parameter4.Value = companyname;
            mySqlAdapter.SelectCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter("@title", SqlDbType.VarChar);
            parameter5.Value = title;
            mySqlAdapter.SelectCommand.Parameters.Add(parameter5);

            SqlParameter parametercaseStatus = new SqlParameter("@CASESTATUS", SqlDbType.Int);
            parametercaseStatus.Value = casestatus;
            mySqlAdapter.SelectCommand.Parameters.Add(parametercaseStatus);

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
