using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Odbc;
using System.Data.Common;

namespace ZNode.Libraries.DataAccess.Data.SqlClient
{
	/// <summary>
	/// This class provides static methods to assist database connections
	/// </summary>
	public class ConnectionHelper
	{
		private static ConnectionHelper _ZNodeConnection;

		private bool _isOdbc;

		/// <summary>
		/// Specifies whether the Odbc connection is used for execution.
		/// </summary>
		public bool IsOdbc
		{
			get { return _isOdbc; }
			set { _isOdbc = value; }
		}

		/// <summary>
		/// The default connection to the ZNode ECommerce db
		/// </summary>
		public static ConnectionHelper ZNodeConnection
		{
			get
			{
				if ( _ZNodeConnection == null )
				{
					_ZNodeConnection = new ConnectionHelper(ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString);
				}
				return _ZNodeConnection;
			}
		}

		private ConnectionStringSettings _connectionString;

		/// <summary>
		/// Constructor which accepts a connection string
		/// </summary>
		/// <param name="connectionString">The connection string for the ado.net connection</param>
		public ConnectionHelper(string connectionString)
		{
			_connectionString = new ConnectionStringSettings();
			_connectionString.ConnectionString = connectionString;
		}

		/// <summary>
		/// This executes a stored procedure and returns a dataset
		/// </summary>
		/// <param name="connectionString">Connection string settings. Use this constructor if the provider
		/// name is not the default provider.
		/// </param>
		public ConnectionHelper(ConnectionStringSettings connectionString)
		{
			_connectionString = connectionString;
			_isOdbc = "System.Data.Odbc".Equals(connectionString.ProviderName, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// This executes a stored procedure and returns a dataset
		/// </summary>
		/// <param name="commandName">The stored procedure to execute</param>
		/// <param name="dbParameters">The list of parameters</param>
		/// <returns>A dataset</returns>
		public DataSet ExecuteStoredProcedure(string commandName, params DbParameter[] dbParameters)
		{
			using ( DbConnection conn = GetConnection() )
			{
				conn.Open();
				DbDataAdapter myAdapter = GetDataAdapter(commandName, conn);
				myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

				foreach ( DbParameter param in dbParameters )
				{
					myAdapter.SelectCommand.Parameters.Add(param);
				}
				DataSet ds = new DataSet();
				myAdapter.Fill(ds);

				return ds;
			}
		}

		/// <summary>
		/// This executes a stored procedure and returns a scalar
		/// </summary>
		/// <param name="commandName">The stored procedure to execute</param>
		/// <param name="dbParameters">The list of parameters</param>
		/// <returns>an object</returns>
		public object ExecuteScalar(string commandName, params DbParameter[] dbParameters)
		{
			object retVal = null;
			using ( DbConnection conn = GetConnection() )
			{
				conn.Open();
				DbDataAdapter myAdapter = GetDataAdapter(commandName, conn);

				myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

				foreach ( DbParameter param in dbParameters )
				{
					myAdapter.SelectCommand.Parameters.Add(param);
				}

				retVal = myAdapter.SelectCommand.ExecuteScalar();
			}
			return retVal;
		}

		/// <summary>
		/// Excecute a parameterized sql command
		/// </summary>
		/// <param name="commandName">A plaintext SQL command</param>
		/// <param name="dbParameters">The list of parameters</param>
		/// <returns>Dataset</returns>
		public DataSet ExecuteCommand(string commandName, params DbParameter[] dbParameters)
		{
			using ( DbConnection conn = GetConnection() )
			{
				conn.Open();
				DbDataAdapter myAdapter = GetDataAdapter(commandName, conn);
				myAdapter.SelectCommand.CommandType = CommandType.Text;

				foreach ( DbParameter param in dbParameters )
				{
					myAdapter.SelectCommand.Parameters.Add(param);
				}
				DataSet ds = new DataSet();
				myAdapter.Fill(ds);

				return ds;
			}
		}

		/// <summary>
		/// Gets a parameter of the correct type, based on the 
		/// </summary>
		/// <returns>OdbcParameter or SqlParameter depending on connection type</returns>
		public DbParameter GetParameter()
		{
			if ( _isOdbc )
			{
				return new OdbcParameter();
			}
			return new SqlParameter();
		}

		/// <summary>
		/// Gets a parameter of the correct type, based on the 
		/// </summary>		
		/// <param name="parameterName"></param>
		/// <param name="value"></param>
		/// <returns>OdbcParameter or SqlParameter depending on connection type</returns>
		public DbParameter GetParameter(string parameterName, string value)
		{
			DbParameter dp = GetParameter();
			dp.ParameterName = parameterName;
			dp.Value = value;
			return dp;
		}

		private DbDataAdapter GetDataAdapter(string commandName, DbConnection conn)
		{
			if ( _isOdbc )
			{
				return new OdbcDataAdapter(commandName, conn as OdbcConnection);
			}
			return new SqlDataAdapter(commandName, conn as SqlConnection);
		}

		private DbConnection GetConnection()
		{
			if ( _isOdbc )
			{
				return new OdbcConnection(_connectionString.ConnectionString);
			}
			return new SqlConnection(_connectionString.ConnectionString);
		}
	}
}
