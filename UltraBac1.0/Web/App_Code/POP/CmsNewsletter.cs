using System;
using System.Collections.Generic;
using System.Web;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;

public class CmsNewsletter
{
	private int _id;
	private int _sortOrder;
	private string _title;
	private string _summary;
	private string _publishDate;
	private NewsletterType _newsletterType;

	public NewsletterType NewsletterType
	{
		get { return _newsletterType; }
		set { _newsletterType = value; }
	}
	
	public int Id
	{
		get { return _id; }
		set { _id = value; }
	}

	public int SortOrder
	{
		get { return _sortOrder; }
		set { _sortOrder = value; }
	}

	public string Title
	{
		get { return _title; }
		set { _title = value; }
	}

	public string Summary
	{
		get { return _summary; }
		set { _summary = value; }
	}

	public string PublishDate
	{
		get { return _publishDate; }
		set { _publishDate = value; }
	}

	private List<CmsNewsletterArticle> _articles;
	public List<CmsNewsletterArticle> Articles
	{
		get { return _articles; }		
	}

	public CmsNewsletter ()	{	}
		
	public CmsNewsletter(DataRow row)
		{
			Load(row);
		}

		public CmsNewsletter(int newsletterId)
		{
			DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsletter_Get", 
				new SqlParameter("@NewsletterId", newsletterId));
			if (ds == null || 
				ds.Tables.Count <= 0 ||
				ds.Tables[0].Rows.Count <= 0)
			{
				throw new Exception(string.Format("Could not get newsletter {0} from database", newsletterId));
			}
			Load(ds.Tables[0].Rows[0]);
		}

		private void Load(DataRow row)
		{
			Id = (int)row["NewsletterId"];
			Title = (string)row["Title"];
			Summary = (string)row["Summary"];
			PublishDate = (string)row["PublishDate"];
			SortOrder = (int)row["SortOrder"];
			try
			{
				NewsletterType = (NewsletterType)row["NewsletterType"];
			}
			catch (InvalidCastException){ }

			_articles = new List<CmsNewsletterArticle>();
			DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsletter_GetArticles",
				new SqlParameter("@NewsletterId", Id));
			if (ds != null && ds.Tables.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Articles.Add(new CmsNewsletterArticle(dr, this));
				}
			}
		}

		public void Update()
		{
			ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsletter_Update",
				new SqlParameter("@NewsletterId", Id),
				new SqlParameter("@Title", Title),
				new SqlParameter("@Summary",Summary),
				new SqlParameter("@PublishDate",PublishDate),
				new SqlParameter("@SortOrder",SortOrder),
				new SqlParameter("@NewsletterType", (int)NewsletterType));
		}

		public void Delete()
		{
			CmsNewsletter.Delete(Id);
		}

		public static CmsNewsletter Create(string title, string summary, string publishDate, int sortOrder, NewsletterType newsletterType)
		{
			object id = ConnectionHelper.ZNodeConnection.ExecuteScalar("POP_CmsNewsletter_Insert",
				new SqlParameter("@Title", title),
				new SqlParameter("@Summary",summary),
				new SqlParameter("@PublishDate",publishDate),
				new SqlParameter("@SortOrder", sortOrder), 
				new SqlParameter("@NewsletterType", (int) newsletterType));
			

			CmsNewsletter newNewsletter = new CmsNewsletter();
			newNewsletter.Id = (int) id;
			newNewsletter.Title = title;
			newNewsletter.Summary = summary;
			newNewsletter.PublishDate = publishDate;
			newNewsletter.SortOrder = sortOrder;

			return newNewsletter;
		}

		public static void Delete(int newsletterId)
		{
			ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsletter_Delete",
				new SqlParameter("@NewsletterId", newsletterId));
		}

		public static List<CmsNewsletter> GetAll()
		{
			List<CmsNewsletter> list = new List<CmsNewsletter>();
			DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsletter_GetAll", new SqlParameter[]{});
			if (ds != null && ds.Tables.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					list.Add(new CmsNewsletter(dr));
				}
			}
			return list;
		}
}

public enum NewsletterType { Customer = 0, Reseller = 1 }