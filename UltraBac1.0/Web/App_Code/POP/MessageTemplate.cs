using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.XPath;

namespace POP.UltraBac
{
	/// <summary>
	/// Summary description for MessageTemplate
	/// </summary>
	public class MessageTemplate
	{

		private const string filePath = "~/App_Data/MessageTemplates.xml";

		private XPathExpression xPathExp
		{
			get
			{
				return XPathExpression.Compile(string.Format("//messages/message[@key='{0}']", _key));
			}
		}

		private string _key;
		private string _subject;
		private string _body;

		public string Subject
		{
			get { return _subject; }
		}

		public string Body
		{
			get { return _body; }
		}

		public MessageTemplate(string messageKey)
		{
			_key = messageKey;
			XmlDocument xDoc = new XmlDocument();
			xDoc.Load(HttpContext.Current.Server.MapPath(filePath));
			XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode(xPathExp);
			_subject = xNav.GetAttribute("subject",string.Empty);
			_body = xNav.InnerXml;
		}

	}
}