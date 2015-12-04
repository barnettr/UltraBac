using System;
using System.Collections.Generic;
using System.Web;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Framework.Business;

public partial class Themes_Default_Common_main : ZNode.Libraries.Framework.Business.ZNodeTemplate
{
	private const string _mailListPage = "~/content.aspx?page=news-signup";
	public const string MailSessionKey = "mailListSession";
	private const string PageTitleFormat = "{0} | UltraBac Software";
	private CmsContext _context = new CmsContext();

	public string PageMetaDescriptionOrEmpty
	{
		get { return _context.CurrentPage != null ? _context.CurrentPage.SEOMetaDescription : ""; }
	}

	public string PageMetaKeywordsOrEmpty
	{
		get { return _context.CurrentPage != null ? _context.CurrentPage.SEOMetaKeywords : ""; }
	}

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		SetPageTitle();
		SetMeta();
		liLogin.Visible = !Page.User.Identity.IsAuthenticated;
		liLogout.Visible = Page.User.Identity.IsAuthenticated;
	}

	private void SetPageTitle()
	{
		string name = string.Empty;

		if (_context.CurrentPage != null)
		{
			if (!string.IsNullOrEmpty(_context.CurrentPage.SEOTitle))
			{
				name = _context.CurrentPage.SEOTitle;
			}
			else if (!string.IsNullOrEmpty(_context.CurrentPage.Title))
			{
				name = _context.CurrentPage.Title;
			}
		}
		else if (_context.CurrentProduct != null)
		{
			if (!string.IsNullOrEmpty(_context.CurrentProduct.SEOTitle))
			{
				name = _context.CurrentProduct.SEOTitle;
			}
			else if (!string.IsNullOrEmpty(_context.CurrentProduct.Name))
			{
				name = _context.CurrentProduct.Name;
			}
		}
		else if (_context.CurrentCategory != null)
		{
			if (!string.IsNullOrEmpty(_context.CurrentCategory.SEOTitle))
			{
				name = _context.CurrentCategory.SEOTitle;
			}
			else if (!string.IsNullOrEmpty(_context.CurrentCategory.Title))
			{
				name = _context.CurrentCategory.Title;
			}
		}
		if (!string.IsNullOrEmpty(name))
		{
			Page.Title = string.Format(PageTitleFormat, name);
		}
	}

	private void SetMeta()
	{
		if (_context.CurrentPage != null)
		{
			uxMetaDescription.Content = _context.CurrentPage.SEOMetaDescription;
			uxMetaKeywords.Content = _context.CurrentPage.SEOMetaKeywords;
		}
		else if (_context.CurrentProduct != null)
		{
			uxMetaDescription.Content = _context.CurrentProduct.SEODescription;
			uxMetaKeywords.Content = _context.CurrentProduct.SEOKeywords;
		}
		else if (_context.CurrentCategory != null)
		{
			uxMetaDescription.Content = _context.CurrentCategory.SEODescription;
			uxMetaKeywords.Content = _context.CurrentCategory.SEOKeywords;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack && 
			uxNewsletter != null && 
			!string.IsNullOrEmpty(uxNewsletter.Text) &&
			uxNewsletter.Text != uxLabel.Text
			)
		{
			// store the address in the session to be retrieved on next pageload
			Session[MailSessionKey] = uxNewsletter.Text;
			Response.Redirect(_mailListPage);
		}
	}
}