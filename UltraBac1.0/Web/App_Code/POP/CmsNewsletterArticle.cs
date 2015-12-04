using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using ZNode.Libraries.DataAccess.Data.SqlClient;
using System.Data.SqlClient;

public class CmsNewsletterArticle
{
	private int _id;
	private string _title;
	private string _shortTitle;
	private string _summary;
	private string _body;
	private CmsNewsletter _newsletter;
	private int _sortOrder;

	public int Id
	{
		get { return _id; }
		set { _id = value; }
	}

	public string Title
	{
		get { return _title; }
		set { _title = value; }
	}

	public string ShortTitle
	{
		get { return _shortTitle; }
		set { _shortTitle = value; }
	}

	public string Summary
	{
		get { return _summary; }
		set { _summary = value; }
	}

	public string Body
	{
		get { return _body; }
		set { _body = value; }
	}

	public CmsNewsletter Newsletter
	{
		get { return _newsletter; }
		set { _newsletter = value; }
	}

	public int SortOrder
	{
		get { return _sortOrder; }
		set { _sortOrder = value; }
	}

	public CmsNewsletterArticle() { }

	public CmsNewsletterArticle(DataRow row, CmsNewsletter parent)
	{
		Load(row, parent);
	}

	public CmsNewsletterArticle(int articleId)
	{
		DataSet ds = ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsArticle_Get", 
			new SqlParameter("@ArticleId", articleId));
		if (ds == null ||
			ds.Tables.Count <= 0 ||
			ds.Tables[0].Rows.Count <= 0)
		{
			throw new Exception(string.Format("Could not get article {0} from database", articleId));
		}
		Load(ds.Tables[0].Rows[0], null);
	}

	private void Load(DataRow row, CmsNewsletter parent)
	{
		Id = (int)row["ArticleId"];
		Title = (string)row["Title"];
		ShortTitle = (string)row["ShortTitle"];
		Summary = (string)row["Summary"];
		Body = (string)row["Body"];
		if (parent == null)
		{
			_newsletter = new CmsNewsletter((int)row["NewsletterID"]);
		}
		else
		{
			_newsletter = parent;
		}
		this.SortOrder = (int)row["SortOrder"];

	}

	public void Update()
	{
		ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsArticle_Update",
			new SqlParameter("@articleId", Id),
			new SqlParameter("@Title", Title),
			new SqlParameter("@ShortTitle", ShortTitle),
			new SqlParameter("@Summary", Summary),
			new SqlParameter("@Body", Body),
			new SqlParameter("@NewsletterId", Newsletter.Id),
			new SqlParameter("@SortOrder", this.SortOrder));
	}

	public void Delete()
	{
		CmsNewsletterArticle.Delete(Id);
	}

	public static CmsNewsletterArticle Create(string title, string shortTitle, string summary, string body, int newsletterId, int sortOrder)
	{
		object id = ConnectionHelper.ZNodeConnection.ExecuteScalar("POP_CmsNewsArticle_Insert",
			new SqlParameter("@Title", title),
			new SqlParameter("@ShortTitle", shortTitle),
			new SqlParameter("@Summary", summary),
			new SqlParameter("@Body", body),
			new SqlParameter("@NewsletterId", newsletterId),
			new SqlParameter("@SortOrder", sortOrder));


		CmsNewsletterArticle newArticle = new CmsNewsletterArticle();
		newArticle.Id = (int)id;
		newArticle.Title = title;
		newArticle.ShortTitle = shortTitle;
		newArticle.Summary = summary;
		newArticle.SortOrder = sortOrder;

		return newArticle;
	}

	public static void Delete(int articleId)
	{
		ConnectionHelper.ZNodeConnection.ExecuteStoredProcedure("POP_CmsNewsArticle_Delete",
			new SqlParameter("@articleId", articleId));
	}
}
