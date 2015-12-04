using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZNode.Libraries.DataAccess.Custom
{
    public class SKUAttributeHelper
    {

        # region Protected Member Variables
        protected SqlConnection MySqlConnection = null;
        protected SqlDataAdapter MySqlDataAdapter = null;
        # endregion


        #region Public Methods

        /// <summary>
        /// Returns Sku attributes for this SKUID
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public DataSet GetSKUAttribuesBySKUID(int SKUid)
        {

            //Connection String
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;

            //Establish Connection
            MySqlConnection = new SqlConnection(ConnectionString);


            //Create Instance of DataAdapter Object
            MySqlDataAdapter = new SqlDataAdapter("ZNode_GetSKUAttribuesBySKUID", MySqlConnection);

            // Mark  Command as Stored Procedure
            MySqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //Add parameter to Command Object
            SqlParameter Myparam1 = new SqlParameter("@SKUID", SqlDbType.Int);
            Myparam1.Value = SKUid;

            MySqlDataAdapter.SelectCommand.Parameters.Add(Myparam1);

            //Fill DataSet
            DataSet MyDataSet = new DataSet();

            MySqlDataAdapter.Fill(MyDataSet);

            //return Dataset
            return MyDataSet;

        }
        #endregion
    }
}
