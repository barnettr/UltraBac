using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Customer Related Helper Methods
    /// </summary>
    public class CustomerHelper
    {
        # region Protected Member Variables
        protected SqlConnection MySqlConnection = null;
        protected SqlDataAdapter MySqlAdapter = null;
        protected DataSet MyDataSet = null;
        #endregion

        # region Public Methods
        /// <summary>
        /// Returns the filtered customer DataSet
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="CompanyName"></param>
        /// <param name="LoginName"></param>
        /// <param name="ExternalAccountNum"></param>
        /// <param name="ContactID"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="EmailID"></param>
        /// <param name="ProfileID"></param>
        /// <returns>DataSet</returns>
        public DataSet SearchCustomer(string FirstName,string LastName,string CompanyName,string LoginName,string ExternalAccountNum,string ContactID,string startdate, string enddate ,string PhoneNumber,string EmailID, string ProfileID)
        {
            //Create Instance for Sql Connection Object
					using ( MySqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{

						//Create Instance for SqlDataAdapter Object
						MySqlAdapter = new SqlDataAdapter("ZNODE_SEARCHCUSTOMER", MySqlConnection);

						//Mark Select Command as Stored Procedure
						MySqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Declare and Pass values to the Parameters
						SqlParameter Myparam1 = new SqlParameter("@FIRSTNAME", SqlDbType.VarChar);
						Myparam1.Value = FirstName;
						SqlParameter Myparam2 = new SqlParameter("@LASTNAME", SqlDbType.VarChar);
						Myparam2.Value = LastName;
						SqlParameter Myparam3 = new SqlParameter("@COMPANYNAME", SqlDbType.VarChar);
						Myparam3.Value = CompanyName;
						SqlParameter Myparam4 = new SqlParameter("@PROFILEID", SqlDbType.VarChar);
						Myparam4.Value = ProfileID;
						SqlParameter Myparam5 = new SqlParameter("@STARTDATE", SqlDbType.VarChar);
						Myparam5.Value = startdate;
						SqlParameter Myparam6 = new SqlParameter("@ENDDATE", SqlDbType.VarChar);
						Myparam6.Value = enddate;
						SqlParameter Myparam7 = new SqlParameter("@LOGINNAME", SqlDbType.VarChar);
						Myparam7.Value = LoginName;
						SqlParameter Myparam8 = new SqlParameter("@ACCOUNTID", SqlDbType.VarChar);
						Myparam8.Value = ContactID;
						SqlParameter Myparam9 = new SqlParameter("@EXTERNALACCOUNTNUM", SqlDbType.VarChar);
						Myparam9.Value = ExternalAccountNum;
						SqlParameter Myparam10 = new SqlParameter("@PHONENUM", SqlDbType.VarChar);
						Myparam10.Value = PhoneNumber;
						SqlParameter Myparam11 = new SqlParameter("@EMAILID", SqlDbType.VarChar);
						Myparam11.Value = EmailID;

						//Add parameters to the Sql Select Command
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam1);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam2);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam3);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam4);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam5);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam6);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam7);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam8);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam9);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam10);
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam11);

						//Fill DataSet
						MyDataSet = new DataSet();
						MySqlAdapter.Fill(MyDataSet);

						//return DataSet
						return MyDataSet;
					}
        }

        /// <summary>
        /// Returns a Login Name for a User id
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
				public string GetByUserID(int UserID)
				{

					//Create Instance for Sql Connection Object
					using ( MySqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{

						//Create Instance for SqlDataAdapter Object
						MySqlAdapter = new SqlDataAdapter("ZNODE_GetByUserID", MySqlConnection);

						//Mark Select Command as Stored Procedure
						MySqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Declare and Pass values to the Parameters
						SqlParameter Myparam1 = new SqlParameter("@ACCOUNTID", SqlDbType.Int);
						Myparam1.Value = UserID;

						//Add Parameter to Select Command
						MySqlAdapter.SelectCommand.Parameters.Add(Myparam1);

						//Execute Query
						MySqlConnection.Open();
						string LoginName = Convert.ToString(MySqlAdapter.SelectCommand.ExecuteScalar());
						MySqlConnection.Close();

						//return string Value
						return LoginName;

					}
				}
        # endregion
    }

}
