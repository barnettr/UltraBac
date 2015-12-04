using System;
using System.Collections.Generic;
using System.Web;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;

namespace POP.UltraBac
{
	public class CmsEventCollection : List<CmsEvent>
	{
		private DateTime _startDate;
		private DateTime _endDate;

		public CmsEventCollection(DateTime startDate, DateTime endDate)
		{
			_startDate = startDate;
			_endDate = endDate;
		}

		public void Load()
		{
			DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsEvent_GetEventsInRange",
				new SqlParameter("@StartDate", _startDate),
				new SqlParameter("@EndDate", _endDate));
			if (ds == null || ds.Tables.Count <= 0)
			{
				throw new Exception("Could not get events in date range");
			}

			foreach (DataRow row in ds.Tables[0].Rows)
			{
				this.Add(new CmsEvent(row));
			}
		}
	}
}