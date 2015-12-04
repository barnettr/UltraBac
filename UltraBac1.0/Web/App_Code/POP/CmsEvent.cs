using System;
using System.Collections.Generic;
using System.Web;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;

namespace POP.UltraBac
{
	public class CmsEvent
	{
		private int _id;		
		private DateTime _startDate;
		private DateTime _endDate;
		private string _title;
		private string _location;
		private string _booth;
		private string _shortDescription;
		private string _detail;
		private string _externalLink;
		
		public int Id
		{
			get { return _id; }
			private set { _id = value; }
		}
		
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		
		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}
		
		public DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}		

		public string ShortDescription
		{
			get { return _shortDescription; }
			set { _shortDescription = value; }
		}		

		public string Detail
		{
			get { return _detail; }
			set { _detail = value; }
		}	

		public string ExternalLink
		{
			get { return _externalLink; }
			set { _externalLink = value; }
		}	

		public string Location
		{
			get { return _location; }
			set { _location = value; }
		}

		public string Booth
		{
			get { return _booth; }
			set { _booth = value; }
		}

		private CmsEvent()
		{
		}

		public CmsEvent(DataRow row)
		{
			Load(row);
		}

		public CmsEvent(int eventId)
		{
			DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsEvent_Get", new SqlParameter("@Id", eventId));
			if (ds == null || 
				ds.Tables.Count <= 0 ||
				ds.Tables[0].Rows.Count <= 0)
			{
				throw new Exception(string.Format("Could not get event {0} from database", eventId));
			}
			Load(ds.Tables[0].Rows[0]);
		}

		private void Load(DataRow row)
		{
			Id = (int)row["Id"];
			Title = (string)row["Title"];
			StartDate = (DateTime)row["StartDate"];
			EndDate = (DateTime)row["EndDate"];
			Location = (string)row["Location"];
			Booth = (string)row["Booth"];
			ExternalLink = (string)row["ExternalLink"];
			ShortDescription = (string)row["ShortDescription"];
			Detail = (string)row["Detail"];
		}

		public void Update()
		{
			ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsEvent_Update",
				new SqlParameter("@Id", Id),
				new SqlParameter("@Title", Title),
				new SqlParameter("@StartDate", StartDate),
				new SqlParameter("@EndDate", EndDate),
				new SqlParameter("@Location", Location),
				new SqlParameter("@Booth", Booth),
				new SqlParameter("@ExternalLink", ExternalLink),
				new SqlParameter("@ShortDescription", ShortDescription),
				new SqlParameter("@Detail", Detail));
		}

		public void Delete()
		{
			CmsEvent.Delete(Id);
		}

		public static CmsEvent Create(DateTime startDate, DateTime endDate, string title, string location, string booth, string shortDescription, string detail, string externalLink)
		{
			object id = ConnectionHelper.ZNodeConnection.ExecuteScalar("POP_CmsEvent_Insert",
				new SqlParameter("@Title", title),
				new SqlParameter("@StartDate", startDate),
				new SqlParameter("@EndDate", endDate),
				new SqlParameter("@Location", location),
				new SqlParameter("@Booth", booth),
				new SqlParameter("@ExternalLink", externalLink),
				new SqlParameter("@ShortDescription", shortDescription),
				new SqlParameter("@Detail", detail));
			

			CmsEvent newEvent = new CmsEvent();
			newEvent.Id = (int) id;
			newEvent.Title = title;
			newEvent.StartDate = startDate;
			newEvent.EndDate = endDate;
			newEvent.Location = location;
			newEvent.Booth = booth;
			newEvent.ExternalLink = externalLink;
			newEvent.ShortDescription = shortDescription;
			newEvent.Detail = detail;

			return newEvent;
		}

		public string DisplayDate
		{
			get { return StartDate == EndDate ? StartDate.ToString("MMM %d, yyyy") : string.Format("{0:MMM %d} - {1:MMM %d, yyyy}", StartDate, EndDate); }
		}

		public static void Delete(int eventId)
		{
			ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsEvent_Delete",
				new SqlParameter("@Id", eventId));
		}
	}
}