using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Export Helper Function - Provides method to export the data from Dataset to CSV format.
    /// </summary>
    public class DataDownloadAdmin:ZNodeBusinessBase 
    {

        /// <summary>
        ///  Returns string for a Given Dataset Values
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="exportColumnHeadings"></param>
        public string Export(DataSet ds, bool exportColumnHeadings)
        {

            string header = string.Empty;

            string body = string.Empty;

            string record = string.Empty;

            // If you want column Heading  to be part of the CSV ...

            if (exportColumnHeadings)
            {
                foreach (DataColumn col in ds.Tables[0].Columns)
                {

                    header = header + col.ColumnName + ",";
                }

                header = header.Substring(0, header.Length - 1);
            }

            // Iterate into the rows

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                Object[] arr = row.ItemArray;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].ToString().IndexOf(",") > 0)
                    {
  
                        record = record + row[i].ToString();
                    }

                    else
                    {
                        record = record + row[i].ToString() + ",";
                    }

                }
                body = body + record.Substring(0, record.Length - 1) + Environment.NewLine;

                record = "";

            }

            if (exportColumnHeadings)
            {

                return (header + Environment.NewLine + body);

            }
            else
            {

                return body;
            }
        }
    }
}