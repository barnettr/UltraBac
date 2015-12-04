using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ZNode.Libraries.DataAccess.Custom
{
    /// <summary>
    /// Order related Helper Functions
    /// </summary>
    public class OrderHelper
    {
        # region Protected Member variables

        protected SqlConnection MyConnection = null;
        protected SqlDataAdapter MyDataAdapter = null;

        # endregion

        # region Public methods
        
        /// <summary>
        ///  Search the Order for billingfirstname,lastname,companyname,accountid,orderid or orderstateid
        /// </summary>
        /// <param name="billingfirstname"></param>
        /// <param name="lastname"></param>
        /// <param name="companyname"></param>
        /// <param name="orderid"></param>
        /// <param name="accountid"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="orderstateID"></param>
        /// <param name="portalID"></param>
        /// <returns></returns> 
				public DataSet SearchOrder(string orderid, string billingfirstname, string billinglastname, string billingcompanyname, string accountid, string startdate, string enddate, int orderstateid, int portalID)
				{
					//Create Instance for Connection and Adapter Objects
					using ( MyConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{

						MyDataAdapter = new SqlDataAdapter("ZNODE_SEARCHORDER", MyConnection);

						//Mark the Select command as Stored procedure
						MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Declare Parameters
						SqlParameter Myparam2 = new SqlParameter("@orderid", SqlDbType.VarChar);
						Myparam2.Value = orderid;
						SqlParameter Myparam3 = new SqlParameter("@billingfirstname", SqlDbType.VarChar);
						Myparam3.Value = billingfirstname;
						SqlParameter Myparam4 = new SqlParameter("@billinglastname", SqlDbType.VarChar);
						Myparam4.Value = billinglastname;
						SqlParameter Myparam5 = new SqlParameter("@billingcompanyname", SqlDbType.VarChar);
						Myparam5.Value = billingcompanyname;
						SqlParameter Myparam6 = new SqlParameter("@accountid", SqlDbType.VarChar);
						Myparam6.Value = accountid;
						SqlParameter Myparam7 = new SqlParameter("@startdate", SqlDbType.VarChar);
						Myparam7.Value = startdate;
						SqlParameter Myparam8 = new SqlParameter("@enddate", SqlDbType.VarChar);
						Myparam8.Value = enddate;
						SqlParameter Myparam9 = new SqlParameter("@orderstateid", SqlDbType.Int);
						Myparam9.Value = orderstateid;
						SqlParameter Myparam10 = new SqlParameter("@portalid", SqlDbType.Int);
						Myparam10.Value = portalID;


						//Add Paramters into Command
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam2);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam3);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam4);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam5);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam6);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam7);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam8);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam9);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam10);


						//Fill Dataset
						DataSet MyDataSet = new DataSet();
						MyDataAdapter.Fill(MyDataSet);

						//return DataSet
						return MyDataSet;

					}
				}

       /// <summary>
        /// Returns Order Line items for orders
       /// </summary>
       /// <param name="orderid"></param>
       /// <param name="billingfirstname"></param>
       /// <param name="billinglastname"></param>
       /// <param name="billinglastname"></param>
       /// <param name="accountid"></param>
       /// <param name="startdate"></param>
       /// <param name="enddate"></param>
       /// <param name="orderstateID"></param>
       /// <param name="portalID"></param>
       /// <returns></returns>
       public DataSet GetOrderLineItems(string orderid, string billingfirstname, string billinglastname, string billingcompanyname, string accountid, string startdate, string enddate, int orderstateID, int portalID)
        {
            //Create Instance for Connection and Adapter Objects
					using ( MyConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
					{

						MyDataAdapter = new SqlDataAdapter("ZNODE_GetOrderLineItems", MyConnection);

						//Mark the Select command as Stored procedure
						MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

						//Declare Parameters
						SqlParameter Myparam1 = new SqlParameter("@orderid", SqlDbType.VarChar);
						Myparam1.Value = orderid;
						SqlParameter Myparam3 = new SqlParameter("@billingfirstname", SqlDbType.VarChar);
						Myparam3.Value = billingfirstname;
						SqlParameter Myparam4 = new SqlParameter("@billinglastname", SqlDbType.VarChar);
						Myparam4.Value = billinglastname;
						SqlParameter Myparam5 = new SqlParameter("@billingcompanyname", SqlDbType.VarChar);
						Myparam5.Value = billingcompanyname;
						SqlParameter Myparam6 = new SqlParameter("@accountid", SqlDbType.VarChar);
						Myparam6.Value = accountid;
						SqlParameter Myparam7 = new SqlParameter("@startdate", SqlDbType.VarChar);
						Myparam7.Value = startdate;
						SqlParameter Myparam8 = new SqlParameter("@enddate", SqlDbType.VarChar);
						Myparam8.Value = enddate;
						SqlParameter Myparam9 = new SqlParameter("@orderstateid", SqlDbType.Int);
						Myparam9.Value = orderstateID;
						SqlParameter Myparam10 = new SqlParameter("@portalid", SqlDbType.Int);
						Myparam10.Value = portalID;

						//Add Paramters into Command
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam1);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam3);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam4);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam5);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam6);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam7);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam8);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam9);
						MyDataAdapter.SelectCommand.Parameters.Add(Myparam10);


						//Fill Dataset
						DataSet MyDataSet = new DataSet();
						MyDataAdapter.Fill(MyDataSet);

						//return DataSet
						return MyDataSet;
					}
        }


        /// <summary>
        /// Returns Order for a Account id and Portal id
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="portalID"></param>
        /// <returns></returns>
			 public DataSet GetByAccountID(int AccountID, int portalID)
			 {
				 //Create Instance for Connection Object
				 using ( MyConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString) )
				 {

					 //Create Instance of Adapter Object
					 MyDataAdapter = new SqlDataAdapter("ZNODE_GETORDERBYACCOUNTID", MyConnection);

					 //Mark the Select command as Stored procedure
					 MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

					 //Declare Parameters
					 SqlParameter Myparam1 = new SqlParameter("@ACCOUNTID", SqlDbType.Int);
					 Myparam1.Value = AccountID;
					 SqlParameter Myparam2 = new SqlParameter("@PORTALID", SqlDbType.Int);
					 Myparam2.Value = portalID;

					 //Add Parameters to Sql Command
					 MyDataAdapter.SelectCommand.Parameters.Add(Myparam1);
					 MyDataAdapter.SelectCommand.Parameters.Add(Myparam2);

					 //Fill DataSet
					 DataSet MyDataSet = new DataSet();
					 MyDataAdapter.Fill(MyDataSet);

					 //Return DataSet
					 return MyDataSet;

				 }
			 }
        # endregion
    }
}
