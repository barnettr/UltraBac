using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using ZNode.Libraries.Framework.Business;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.Security;


namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to verify database connection and permissions during Installation
    /// </summary>
    public class InstallAdmin:ZNodeBusinessBase 
    {

        /// <summary>
        /// Check the DataBase connection provided by the User
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DataBaseName"></param>
        /// <param name="UID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CheckDataBaseSettings(string ServerName,string DataBaseName,string UID, string Password)
        {
            SqlConnection Connection = null;
            bool Status = false;

            try
            {
                string ConnectionString = "Data Source=" + ServerName + "\\SQLEXPRESS;Initial Catalog=" + DataBaseName + ";user id=" + UID  + ";password=" + Password;
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                Status = true;
            }
            catch { }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return Status;
        }


        /// <summary>
        /// Validates the web.config for write permission
        /// </summary>
        /// <returns></returns>
        public bool ValidatePermissions()
        {
            //Get Application Path
            string ApplicationPath = ZNodeConfigManager.EnvironmentConfig.ApplicationPath;

            // Create a new FileInfo object.
            FileInfo f = new FileInfo(HttpContext.Current.Server.MapPath(ApplicationPath + "/web.config"));
            
            //Check for Read Only
            if (f.IsReadOnly)
            {
                return false; // If it is readyonly then return false
            }
            else
            {
                return true;
            }
                        
        }

        /// <summary>
        /// Validates the Public folder for Read/write permission
        /// </summary>
        /// <returns></returns>
        public bool ValidateDirectoryPermission()
        {
            //Get Application Path
            string ApplicationPath = ZNodeConfigManager.EnvironmentConfig.DataPath;
            bool CheckPermissions = false;

            try
            {           
                String newDir = "TestDir";
                Directory.CreateDirectory(ApplicationPath + "/" + newDir);
                Directory.Delete(ApplicationPath + "/" + newDir);
                CheckPermissions = true;
            }
            catch
            {              
            }

            return CheckPermissions;       

        }

        /// <summary>
        /// Creates and confiure the database 
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DataBaseName"></param>
        /// <param name="UID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool ConfigureDataBase(string ServerName, string DataBaseName, string UID, string Password)
        {
            SqlConnection Connection = null;
            bool Status = false;

            try
            {
                string ConnectionString = "Data Source=" + ServerName + "\\SQLEXPRESS;Initial Catalog=" + DataBaseName  + ";user id=" + UID + ";password=" + Password;
                Connection = new SqlConnection(ConnectionString);

                //Get Application Path
                string ApplicationPath = ZNodeConfigManager.EnvironmentConfig.ApplicationPath;

                String SQLFilePath = HttpContext.Current.Server.MapPath(ApplicationPath + "/admin/install/install.sql");
                StreamReader reader = new StreamReader(SQLFilePath);
                
                string CmdQuery = string.Empty;
                StringBuilder builder = new StringBuilder(reader.ReadToEnd());
                
                string[] SqlLine;
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^GO",RegexOptions.IgnoreCase |RegexOptions.Multiline);

                string txtSQL = builder.ToString();
                SqlLine = regex.Split(txtSQL);

                SqlCommand cmd = Connection.CreateCommand();
                cmd.Connection = Connection;
                Connection.Open();
                foreach(string line in SqlLine)
                {
                  if(line.Length>0)
                  {
                     cmd.CommandText = line;
                     cmd.CommandType = CommandType.Text;
                     try
                     {
                        cmd.ExecuteNonQuery();
                     }
                     catch(SqlException){ }
                  }
                }          
                Status = true;
               
            }
            catch {}
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return Status;
        
        }

        /// <summary>
        /// Method replace the old connection string with the new connection string giben by the user
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DataBaseName"></param>
        /// <param name="UID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool SetupConfiugarationFile(string ServerName, string DataBaseName, string UID, string Password)
        {
            bool Status = true;
            try
            {           
                //New Connection String              
                string _ConnectionString = "Data Source=" + ServerName + "\\SQLEXPRESS;Initial Catalog=" + DataBaseName + ";user id=" + UID + ";password=" + Password;
                             
                //Get Application Path
                string webPath = ZNodeConfigManager.EnvironmentConfig.ApplicationPath;

                //Get Configuaration object of the cureent web request using web path
                Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(webPath);
                
                //Remove the old connection string
                config.ConnectionStrings.ConnectionStrings.Remove("ZNodeECommerceDB");
                
                //Create ne connection string
                ConnectionStringSettings Settings = new ConnectionStringSettings("ZNodeECommerceDB", _ConnectionString);

                //Add connection string to the collection
                config.ConnectionStrings.ConnectionStrings.Add(Settings);

                //Save the changes
                config.Save();                
                
                //Create Admin User
                //CreateAdminUser();
            }
            catch
            {
                Status =  false;
            }

            return Status;
        }

        /// <summary>
        /// Create Admin User
        /// </summary>
        private void CreateAdminUser()
        {
            
                //create user membership
                MembershipCreateStatus memStatus;
                MembershipUser user = Membership.CreateUser("admin", "admin","hariharan@znode.com", "what is your pet name", "admin",true, out memStatus);
                
                //create the user account
                ZNodeUserAccount newUserAccount = new ZNodeUserAccount();
                newUserAccount.PortalID = ZNodeConfigManager.SiteConfig.PortalID;
                newUserAccount.UserID = (Guid)user.ProviderUserKey;


                //copy info to billing
                ZNodeAddress billingAddress = new ZNodeAddress();
                billingAddress.EmailId = "hariharan@znode.com";
                newUserAccount.BillingAddress = billingAddress;

                //copy info to shipping
                ZNodeAddress shippingAddress = new ZNodeAddress();
                shippingAddress.EmailId = "hariharan@znode.com";
                newUserAccount.ShippingAddress = shippingAddress;

                //register account
                newUserAccount.AddUserAccount();
                
        }
    }
}
