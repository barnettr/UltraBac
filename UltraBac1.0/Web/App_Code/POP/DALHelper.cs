using System.Configuration;
using ZNode.Libraries.DataAccess.Data.SqlClient;

namespace POP.UltraBac
{
    /// <summary>
    /// A few helper methods to build NETTier DAL objects
    /// </summary>
    public class DALHelper
    {

        /// <summary>
        /// Returns a SqlNetTiersProvider instance populated with connection string and provider
        /// </summary>
		/// <returns>SqlNetTiersProvider object instance</returns>
        public static SqlNetTiersProvider BuildNetTiersProvider()
        {
            SqlNetTiersProvider sqlNTProvider = new SqlNetTiersProvider();
            sqlNTProvider.ConnectionString = ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
            sqlNTProvider.ProviderInvariantName = "System.Data.SqlClient";
            return sqlNTProvider;
        }

    }
}