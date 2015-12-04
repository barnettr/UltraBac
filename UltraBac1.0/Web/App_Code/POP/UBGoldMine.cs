using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace POP.UltraBac
{
	/// <summary>
	/// Contains static methods to make UltraBac GoldMine "API" calls
	/// </summary>
	public static class UBGoldMine
	{
		private static ConnectionHelper _dbConnection = new ConnectionHelper(Config.GoldMineConnectionString);

		/// <summary>
		/// Checks whether a customer exists in the GoldMine database
		/// </summary>
		/// <param name="emailAddress">Email address of customer to check</param>
		/// <returns>UBGoldMineResponse type enum</returns>
		public static bool CheckUpgradeEligibility(string emailAddress, ref Exception exception)
		{
			if (!Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"))
			{
				// don't even check if they submit invalid email characters to prevent sql injection
				return false;
			}
			try
			{
				GoldmineUserRecord record = GetGoldmineRecord(emailAddress);
				return true;
			}
			catch (GoldmineUserNotFoundException) { 
				// suppress user not found exceptions, as that's the only we are validating 
				// a user is eligible to download
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			return false;
		}

		public static GoldmineUserRecord GetGoldmineRecord(string emailAddress)
		{
			DataSet ds = _dbConnection.ExecuteStoredProcedure("sp_ResellerOrder",
				_dbConnection.GetParameter("@email", emailAddress));

			GoldmineUserRecord record = new GoldmineUserRecord(emailAddress, ds);			
			return record;
		}

		public static string GetGoldmineUserNotes(string emailAddress)
		{
			DataSet ds = _dbConnection.ExecuteStoredProcedure("sp_EmailCheckNews",
				_dbConnection.GetParameter("@email", emailAddress));

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0].Rows[0]["notes"] as string;
			}
			return null;
		}

		

		public static bool RecordDownload(string email, string productName, ref Exception exception)
		{
			try
			{
				DataSet ds = _dbConnection.ExecuteStoredProcedure("sp_UserDownloads",
					_dbConnection.GetParameter("@email", email),
					_dbConnection.GetParameter("@product", productName));
				return true;
			}
			catch (Exception ex)
			{
				exception = ex;
				return false;
			}
		}
	}
}