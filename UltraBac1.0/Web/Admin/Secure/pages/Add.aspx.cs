using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using POP.UltraBac;
using ZNode.Libraries.Admin;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.Framework.Business;

public partial class Admin_Secure_Page_Add : System.Web.UI.Page
{
    protected int ItemId;
    protected string AddLink = "~/admin/secure/pages/add.aspx";
    protected string CancelLink = "~/admin/secure/pages/default.aspx";
    protected string ListLink = "~/admin/secure/pages/default.aspx";
    protected string NextLink = "~/admin/secure/pages/default.aspx";
		ContentPageAdmin _pageAdmin = new ContentPageAdmin();

		private bool _isExistingItem = false;

		protected void Page_Load(object sender, EventArgs e)
		{
			// Get ItemId from querystring        
			if (Request.Params["itemid"] != null)
			{
				ItemId = int.Parse(Request.Params["itemid"]);
			}
			else
			{
				ItemId = 0;
			}

			_isExistingItem = ItemId > 0;

			if (!IsPostBack)
			{
				// Bind content tree dropdownlist
				BindContentNodeTreeDDL();

				//Bind data to the fields on the page
				if (_isExistingItem)
				{
					BindData();
				}
			}

			plhFormSetting.Visible = uxTemplate.SelectedValue.Equals("/Form/Form.master", StringComparison.InvariantCultureIgnoreCase);
			plhRedirectSettings.Visible = uxTemplate.SelectedValue.Equals("/Content/Redirect.master", StringComparison.InvariantCultureIgnoreCase);	
		}

		protected void BindData()
		{
			lblTitle.Text = "Edit Page";
			ContentPageNode contentPageNode = new ContentPageNode(ItemId);
			ContentPage contentPage = contentPageNode.ContentPage;

			txtName.Enabled = !contentPageNode.IsLocked;

			//set fields          
			txtName.Text = contentPage.Name.Trim();
			txtSEOMetaDescription.Text = contentPage.SEOMetaDescription;
			txtSEOMetaKeywords.Text = contentPage.SEOMetaKeywords;
			txtSEOTitle.Text = contentPage.SEOTitle;
			txtTitle.Text = contentPage.Title;
			uxTemplate.ClearSelection();
			ListItem current = uxTemplate.Items.FindByValue(contentPage.TemplateName);
			if (current != null)
			{
				current.Selected = true;
			}
			else
			{
				txtTemplate.Text = contentPage.TemplateName;
				txtTemplate.Visible = true;
				uxTemplate.Visible = false;
			}
			uxResellerPage.Checked = contentPage.IsResellerProtectedPage;
			txtSummary.Text = contentPage.Summary;
			txtRedirectAddress.Text = contentPage.RedirectPage;
			txtFromRecipient.Text = contentPage.FormEmailRecipient;

			txtLinkText.Text = contentPageNode.LinkText;
			txtSortIndex.Text = contentPageNode.SortIndex.ToString();
			if (contentPageNode.ParentContentPageID == Config.RootContentPageID)
			{
				ListItem li = new ListItem();
				li.Text = "Root";
				li.Value = Config.RootContentPageID.ToString();
				li.Selected = true;
				ddlParentContentPage.Items.Add(li);
				ddlParentContentPage.Enabled = false;
			}
			else
			{
				ddlParentContentPage.SelectedValue = contentPageNode.ParentContentPageID.ToString();
			}
			chkActiveInd.Checked = contentPage.ActiveInd;

			// hide content location input controls if the node can't be changed
			if (contentPageNode.IsLocked)
			{
				ddlParentContentPage.Enabled = false;
				lblSettingsLocked.Visible = true;
			}

			// +++++++ CODE REVIEW END +++++++++ 

			//get content

			ctrlHtmlText.Html = _pageAdmin.GetPageHTMLByName(contentPage.Name);
		}

// +++++++ CODE REVIEW BEGIN +++++++ 

	private void BindContentNodeTreeDDL()
	{
		// Add list items to dropdownlist recursively, starting with the home page children
		AddNodesToDDL(Config.RootContentPageID);
		recursionLevel = -1;
		AddNodesToDDL(-1);
	}

	private static int recursionLevel = -1;
	private void AddNodesToDDL(int contentPageID)
	{
		// increment recursion level
		recursionLevel++;

		// get children nodes of current ContentPage
		ContentPageNodeCollection nodes = new ContentPageNodeCollection();
		nodes.LoadChildrenNodes(contentPageID);
		
		if ( nodes != null && nodes.Count > 0 )
		{
			foreach ( ContentPageNode node in nodes )
			{
				if ( node.ContentPage != null && node.ContentPage.ActiveInd && node.CanHaveChildren )
				{
					StringBuilder linkText = new StringBuilder();
					// use recursion level to determine indentation of page name
					linkText.Append(new string(Convert.ToChar("-"), recursionLevel * 2));
					linkText.AppendFormat(" {0}", recursionLevel == 1 ? node.LinkText.ToUpper() : node.LinkText );
					ListItem listItem = new ListItem(linkText.ToString(), node.ContentPageID.ToString());
					
					// add the listitem to the dropdownlist
					ddlParentContentPage.Items.Add(listItem);

					// add children of this node to the dropdownlist
					AddNodesToDDL(node.ContentPageID);
				}
			}
		}

		// decrement recursion level
		recursionLevel--;
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			ContentPage contentPage;
			ContentPageNode pageNode;

			//If edit mode then retrieve data first
			if (_isExistingItem)
			{
				pageNode = new ContentPageNode(ItemId);
				contentPage = pageNode.ContentPage;
			}
			else
			{
				pageNode = new ContentPageNode();
				contentPage = new ContentPage();
			}

			string submissionError = string.Empty;
			if (ValidateSubmission(pageNode, contentPage, ref submissionError))
			{
				SaveUpdatePage(pageNode, contentPage);
			}
			else
			{
				lblMsg.Text = submissionError;
			}
		}
		catch (Exception ex)
		{
			lblMsg.Text = string.Format("Unspecified error: {0}", ex.Message);
		}
	}

	public void SaveUpdatePage(		ContentPageNode pageNode,		ContentPage contentPage)
	{
		string oldName = contentPage.Name;
		FillPage(contentPage, pageNode);
		
		// check to see if we're renaming the page, if the old name and new name
		// are the same, then we don't want to initiate a rename.
		if (string.Equals(oldName, contentPage.Name, StringComparison.InvariantCultureIgnoreCase))
		{
			oldName = null;
		}
		
		bool retval = false;

		// update or insert ContentPage entity
		if (_isExistingItem)
		{			
			// update
			retval = _pageAdmin.UpdatePage(contentPage, ctrlHtmlText.Html, oldName, HttpContext.Current.User.Identity.Name);
		}
		else
		{
			// insert
			retval = _pageAdmin.AddPage(contentPage, ctrlHtmlText.Html, HttpContext.Current.User.Identity.Name);
		}

		// if ContentPage update or insert is successful, update or insert ContentPageNode and redirect
		if (retval)
		{
			UpdateContentPageNode(pageNode, contentPage);
			
			// Redirect to previous page
			Response.Redirect(NextLink);

		}
		else
		{
			// Display error message
			lblMsg.Text = string.Format("Failed to update page. Please verify that the files under /data/default/content/ are not read only and try again.<br />Exception detail: {0}", _pageAdmin.LastError);
		}
	}

	private void FillPage(ContentPage contentPage, ContentPageNode pageNode)
	{
		// set ContentPage entity values
		if (!pageNode.IsLocked)
		{
			contentPage.ActiveInd = chkActiveInd.Checked;
			contentPage.Name = txtName.Text.Trim();
		}
		
		contentPage.PortalID = ZNodeConfigManager.SiteConfig.PortalID;
		contentPage.SEOMetaDescription = txtSEOMetaDescription.Text;
		contentPage.SEOMetaKeywords = txtSEOMetaKeywords.Text;
		contentPage.SEOTitle = txtSEOTitle.Text;
		contentPage.Title = txtTitle.Text;
		if (txtTemplate.Visible)
		{
			contentPage.TemplateName = txtTemplate.Text;
		}
		else
		{
			contentPage.TemplateName = uxTemplate.SelectedValue;
		}

		contentPage.Summary = txtSummary.Text;
		contentPage.IsResellerProtectedPage = uxResellerPage.Checked;
		contentPage.RedirectPage = txtRedirectAddress.Text;
		contentPage.FormEmailRecipient = txtFromRecipient.Text;

		if (!_isExistingItem)
		{
			contentPage.AllowDelete = true;
		}
	}

	private bool ValidateSubmission(ContentPageNode pageNode, ContentPage contentPage, ref string pageError)
	{
		if (_isExistingItem)
		{
			bool isRename = !string.Equals(contentPage.Name, txtName.Text.Trim(), StringComparison.InvariantCultureIgnoreCase);
			if (isRename &&
				!_pageAdmin.IsNameAvailable(txtName.Text.Trim()))				
			{
				pageError = "Cannot rename page, the target name is already in use. Please enter a different name.";
				return false;
			}
		}
		else
		{
			if (!_pageAdmin.IsNameAvailable(txtName.Text.Trim()))
			{
				pageError = "A page with this name already exists in the database. Please enter a different name.";
				return false;
			}
		}
		return true;
	}

	private void UpdateContentPageNode(ContentPageNode pageNode, ContentPage contentPage)
	{
		// set ContentPageNode entity values
		pageNode.ParentContentPageID = Convert.ToInt32(ddlParentContentPage.SelectedValue);
		string navLinkText = txtLinkText.Text.Trim();
		if ( navLinkText != string.Empty )
		{
			pageNode.LinkText = Server.HtmlEncode(navLinkText);
		}
		else
		{
			pageNode.LinkText = Server.HtmlEncode(txtTitle.Text);
		}
				
		int sort = 0;
		Int32.TryParse(txtSortIndex.Text, out sort);		
		pageNode.SortIndex = sort;

		// update or insert ContentPageNode entity
		if (_isExistingItem)
		{
			pageNode.Update();
		}
		else
		{
			pageNode.Insert(contentPage.ContentPageID);
		}
	}

// +++++++ CODE REVIEW END +++++++++ 

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(CancelLink);
    }

}
