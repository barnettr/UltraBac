using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.DataAccess.Custom;
using ZNode.Libraries.Framework.Business;
using ZNode.Libraries.DataAccess.Data;
using ZNode.Libraries.DataAccess.Entities;
using System.Web;
using System.Text.RegularExpressions;
using System.Xml;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage templating system and style sheets
    /// </summary>
    public class TemplateAdmin:ZNodeBusinessBase 
    {
        # region Public Methods
        

        

        /// <summary>
        /// Returns the Style sheet content(CSS)
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public string GetTemplateStyle()
        {
            string templatePath = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/common/";

            DirectoryInfo di = new DirectoryInfo(HttpContext.Current.Server.MapPath(templatePath));
            FileInfo info = new FileInfo(di.FullName + "style.css");
            TextReader tr = null;
            if (info.Exists)
            {
                tr = new StreamReader(info.FullName);
            }

            try
            {
                string html = tr.ReadToEnd();
                tr.Close();

                return html;
            }
            catch
            {
                if (tr != null)
                {
                    tr.Close();
                }

                return String.Empty;
            }
        }

        /// <summary>
        /// Creates or updates an HTML Styles file 
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="htmlText"></param>
        public bool UpdateTemplateStyleFile(string css)
        {
            string templatePath = "~/themes/" + ZNodeConfigManager.SiteConfig.Theme + "/common/"; ;

            DirectoryInfo di = new DirectoryInfo(HttpContext.Current.Server.MapPath(templatePath));
            FileInfo info = new FileInfo(di.FullName + "style.css");
            TextWriter tw = new StreamWriter(info.FullName);

            try
            {
                tw.Write(css);
                tw.Close();

                return true;

            }
            catch
            {
                if (tw != null)
                {
                    tw.Close();
                }

                return false; //Return false
            }
        }

        # endregion
       
        # region Helper Methods

        # region Method to Replace Placeholders with UserControl
        /// <summary>
        /// Update the Placeholders with the User Control code
        /// </summary>
        /// <param name="TemplateContent"></param>
        /// <returns></returns>
        public string FormatMasterPageContent(String TemplateContent)
        {
            StringBuilder build = new StringBuilder(TemplateContent);

            // Create a new XmlTextReader instance
            XmlTextReader xmlreader = null;

            try
            {
                // load the file from the URL
                xmlreader = new XmlTextReader(HttpContext.Current.Server.MapPath(ZNodeConfigManager.EnvironmentConfig.ConfigPath + "/templateconfig.xml"));
                xmlreader.WhitespaceHandling = WhitespaceHandling.None;

                string searchString = String.Empty;
                string ReplaceString = String.Empty;
                string Output = String.Empty;

                //Read from XML File
                while (xmlreader.Read())
                {
                    switch (xmlreader.NodeType)
                    {
                        case XmlNodeType.CDATA:
                            //Get UserControl Code from CDATA
                            ReplaceString = xmlreader.Value;
                            if (searchString.Length > 0)
                            {
                                //Replace placeholders with the Usercontrol                                                    
                                Output = String.Empty;
                                Output = Regex.Replace(build.ToString(), searchString, ReplaceString, RegexOptions.IgnoreCase);
                                build.Remove(0, build.Length);
                                build.Append(Output);
                            }
                            break;
                        case XmlNodeType.Element:
                            if (xmlreader.HasAttributes)
                            {
                                xmlreader.MoveToNextAttribute();
                                //Get PlaceHolders Key value
                                searchString = xmlreader.Value;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                if (xmlreader != null)
                {
                    xmlreader.Close();
                }
            }                      
            
            String Content = String.Empty;

            //Add Header Section with the Body Content
            Content = AddTemplateHeaders(build);
            build.Remove(0, build.Length);
            build.Append(Content);

            //Add Footer Secton with the Body content
            Content = AddTemplateFooters(build);
            build.Remove(0, build.Length);
            build.Append(Content);

            // Return Template Content
            return build.ToString();
        }
        # endregion

        # region Template Header Section
        /// <summary>
        /// Template Header Section
        /// </summary>
        /// <param name="build"></param>
        /// <returns></returns>
        private string AddTemplateHeaders(StringBuilder build)
        {
            # region Local Member Variables
            StringBuilder builder = new StringBuilder();
            string HeaderContent = String.Empty;
            MatchCollection mCollection = null;            
            string OriginalTag = string.Empty;
            # endregion


            builder.Append("<%@ Master Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"ZNode.Libraries.Framework.Business.ZNodeTemplate\" %>" + "\n");

            // Create a new XmlTextReader instance
            XmlTextReader xmlreader = null;

            // load the file from the URL
            xmlreader = new XmlTextReader(HttpContext.Current.Server.MapPath(ZNodeConfigManager.EnvironmentConfig.ConfigPath + "/templateconfig.xml"));
            xmlreader.WhitespaceHandling = WhitespaceHandling.None;

            string searchString =String.Empty;
            string RegistertagString = string.Empty;

            //Read from XML File          
            while (xmlreader.Read())
            {
                switch (xmlreader.NodeType)
                {
                    case XmlNodeType.CDATA:
                        RegistertagString = xmlreader.Value;
                        //Get UserControl Code from CDATA
                        if (searchString.Equals("#Register_UserControls#"))
                        {
                            //Replace placeholders with the Usercontrol                                                    
                            builder.Append(RegistertagString + Environment.NewLine);
                        }
                        break;
                    case XmlNodeType.Element:
                        if (xmlreader.HasAttributes)
                        {
                            xmlreader.MoveToNextAttribute();
                            //Get PlaceHolders Key value
                            searchString = xmlreader.Value;
                        }
                        break;

                    default:
                        break;
                }
            }
            if (xmlreader != null)
            {
                xmlreader.Close();
            }
            builder.Append(Environment.NewLine);
            //Check for <Html> tag
            mCollection = Regex.Matches(build.ToString(), "<!DOCTYPE\\s*[^><]*>", RegexOptions.IgnoreCase|RegexOptions.IgnorePatternWhitespace);
            if (mCollection.Count == 0)
            {
                builder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" + "\n\n");
            }
            else
            {
                build.Replace(mCollection[0].Value, String.Empty);
                builder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" + "\n\n");
            }

            //Check for <Html> tag
            mCollection = Regex.Matches(build.ToString(), "<html(.*?)>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            if (mCollection.Count == 0)
            {
                //Not Exists ,Explicitly add into this section
                builder.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">" + Environment.NewLine);

            }
            else
            {   //If Already exists ,add to the Header section
                build.Replace(mCollection[0].Value, "");
                string HTMLTag = mCollection[0].Value;
                builder.Append(HTMLTag + Environment.NewLine);
            }

            //Check for <Head> tag
            mCollection = Regex.Matches(build.ToString(), "<head\\s*[^><]*>", RegexOptions.IgnoreCase);
            if (mCollection.Count == 0)
            {
                //Not Exists ,Explicitly add into this section
                builder.Append("<head id=\"Head\" runat=\"server\">" + Environment.NewLine);
            }
            else
            {
                build.Replace(mCollection[0].Value, String.Empty);
                build.Replace("</head>", "");
                string HeaderTag = "<head id=\"Head\" runat=\"server\">";
                builder.Append(HeaderTag + Environment.NewLine);
            }

            //Check for <Title> tag
            mCollection = Regex.Matches(build.ToString(), "<title>\\s*[^>]*</title>", RegexOptions.IgnoreCase|RegexOptions.IgnorePatternWhitespace);
            if (mCollection.Count > 0)
            {
                build.Replace(mCollection[0].Value, "");
                build.Replace("</title>", "");
                string TitleTag = mCollection[0].Value;
                builder.Append(TitleTag + Environment.NewLine);
            }

            //Check for <link> tag
            mCollection = Regex.Matches(build.ToString(), "<link\\s*[^><]*>", RegexOptions.IgnoreCase);
            if (mCollection.Count == 0)
            {
                builder.Append("<link id=\"stylesheet\" href=\"style.css\" type=\"text/css\" rel=\"stylesheet\" runat=\"server\" />");

            }
            else
            {
                foreach (Match m in mCollection)
                {                    
                    Match _match = Regex.Match(m.Value, "runat=\"server\"", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                    if (!_match.Success)
                    {
                        build.Replace(m.Value, "");
                        string TagValue = Regex.Replace(m.Value, "/>|>|</link>", String.Empty, RegexOptions.IgnoreCase);
                        string LinkTag = Regex.Replace(m.Value, "<link (.*?)>", TagValue + " runat=\"server\" />", RegexOptions.IgnoreCase);  //.Replace("\"", String.Empty);
                        builder.Append(Environment.NewLine + LinkTag);
                    }
                    else
                    {
                        build.Replace(m.Value, String.Empty);
                        build.Replace("</link>", String.Empty);
                        string LinkTag = m.Value;
                        builder.Append(Environment.NewLine + LinkTag);
                    }
                }
            }
           
            //Check for <meta> tag
            mCollection = Regex.Matches(build.ToString(), "<meta\\s*[^><]*>", RegexOptions.IgnoreCase);
            foreach (Match m in mCollection)
            {
                builder.Append(Environment.NewLine + m.Value);
                build.Replace(m.Value, "");
            }

            //Add closing head tag
            build.Replace("</head>", "");
            builder.Append(Environment.NewLine + "</head>");


            //Check for <form> tag
            mCollection = Regex.Matches(build.ToString(), "<form\\s*[^><]*>", RegexOptions.IgnoreCase);
            if (mCollection.Count != 0)
            {
                build.Replace(mCollection[0].Value, String.Empty);
                build.Replace("</form>", String.Empty);
            }

            //Check for <Body> tag
            mCollection = Regex.Matches(build.ToString(), "<body(.*?)>", RegexOptions.IgnoreCase);
            if (mCollection.Count == 0)
            {
                // There is no <body> tag. Add one.
                builder.Append("<body>");
            }
            else
            {
                //Save the original <body> tag so we can restore it properly in the next step.
                OriginalTag = mCollection[0].Value;
            }

            //Merge Template Header Contents(Master,Register tags) with the Body content
            build.Insert(0, builder.ToString());
            

            // Add the <form> tag right after our <body> tag.
            HeaderContent = Regex.Replace(build.ToString(), OriginalTag, OriginalTag + Environment.NewLine + "<form id=\"form1\" runat=\"server\">", RegexOptions.IgnoreCase);
                        
            build.Remove(0, build.Length);
            build.Append(HeaderContent.Trim());
                               
            //Check for <a> anchor tag runat server attribute
            string Content = CheckRunatServer("a", build);
            build.Remove(0, build.Length);
            build.Append(Content);

            //Check for <a> anchor tag runat server attribute
            Content = CheckRunatServer("img", build);
            build.Remove(0, build.Length);
            build.Append(Content);
           

            //Return TemplateContent
            return build.ToString();
        }

        private string CheckRunatServer(string tagname,StringBuilder build)
        {
            MatchCollection mCollection = null;           

            mCollection = Regex.Matches(build.ToString(), "<"+ tagname +"\\s*[^><]*>", RegexOptions.IgnoreCase);
          
            foreach (Match m in mCollection)
            {
                Match match = Regex.Match(m.Value, "runat=\"server\"", RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    if (tagname.Equals("a"))
                    {
                        string TagValue = Regex.Replace(m.Value, "/>|>", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                        build.Replace(m.Value, TagValue + " runat=\"server\">");
                    }
                    
                }
                else
                {
                    if (tagname.Equals("img"))
                    {
                        Match _match = Regex.Match(m.Value,"(=|\")\\d{1,3}(px|%)(\"|)",RegexOptions.IgnoreCase|RegexOptions.IgnorePatternWhitespace);
                        if (_match.Success)
                        {
                            string TagAttrib = Regex.Replace(m.Value, "runat=\"server\"", "", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
                            build.Replace(m.Value, TagAttrib);
                        }
                    }
                }

            }
                      
            return build.ToString();
        }

        # endregion
        
        # region Template Footer Section

        /// <summary>
        /// Template Footer Section
        /// </summary>
        /// <param name="build"></param>
        /// <returns></returns>
        private string AddTemplateFooters(StringBuilder build)
        {
            StringBuilder builder1 = null;
            MatchCollection mCollection = null;
            string FooterContent = string.Empty;

            //Adding Footer Section to New Template
            builder1 = new StringBuilder();

            //Add Form Closing Tag</form> before the body closing tag
            mCollection = Regex.Matches(build.ToString(), "</body>", RegexOptions.IgnoreCase);
            if (mCollection.Count == 0)
            {
                builder1.Append("</body>"+ Environment.NewLine);
            }

            //Check for <Html> tag
            mCollection = Regex.Matches(build.ToString(), "</html>", RegexOptions.IgnoreCase);
            if (mCollection.Count == 0)
            {
                builder1.Append("</html>");

            }

            //Remove <html> tag
            build.Append(builder1.ToString());
            FooterContent = Regex.Replace(build.ToString(), "</html>", String.Empty, RegexOptions.IgnoreCase);
            build.Remove(0, build.Length);
            build.Append(FooterContent.Trim());

            //Add Html Tag
            FooterContent = Regex.Replace(build.ToString(), "</body>", "</form>" + Environment.NewLine + "</body>" + Environment.NewLine + "</html>", RegexOptions.IgnoreCase);
            build.Remove(0, build.Length);
            build.Append(FooterContent.Trim());

            return build.ToString();
        }
        # endregion

        # endregion

        # region HTML Validation Helper Methods
               
        /// <summary>
        /// Method to vlidate html,head,title,body tag count
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        private bool ParseTag(string tag,StringBuilder builder)
        {
            MatchCollection mCollection = null;
            MatchCollection MCollection = null;
            bool CheckTags = true;

            //Validate Tags
            mCollection = Regex.Matches(builder.ToString(), "<" + tag + "\\s*[^><]*>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            MCollection = Regex.Matches(builder.ToString(), "</" + tag + ">", RegexOptions.IgnoreCase);
            if (MCollection.Count != mCollection.Count)
            {
                CheckTags = false;
                 
            }
            else
            {
                if ((mCollection.Count > 1) || (MCollection.Count > 1))
                {
                    CheckTags = false;
                
                }
            }
            
            return CheckTags; //Return Boolean Value
        }

        /// <summary>
        /// Validate other tags
        /// </summary>
        /// <param name="tag">Check the tags(Ex: p ,div,table,etc)</param>
        /// <param name="CheckTag">Check Related Tags like param tag related to tag p</param>
        /// <param name="builder"></param>
        /// <returns></returns>
        private bool ValidateHTMLTag(string tag,string CheckTag,StringBuilder builder)
        {
            MatchCollection mCollection = null;
            MatchCollection MCollection = null;
            bool CheckTags = true;
            //Validate <html> tag
            mCollection = Regex.Matches(builder.ToString(), "<" + tag + "\\s*[^><]*>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            MCollection = Regex.Matches(builder.ToString(), "</" + tag + ">", RegexOptions.IgnoreCase);

            int OpeningTagCount = mCollection.Count;
            int ClosingTagCount =MCollection.Count;

            if (CheckTag.Trim().Length > 0)
            {
               MatchCollection _Collection = Regex.Matches(builder.ToString(), "<" + CheckTag + "\\s*[^><]*>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
               OpeningTagCount -= _Collection.Count; 
            }

            if (OpeningTagCount != ClosingTagCount)
            {       
                    CheckTags = false;               
            }           

            return CheckTags; //Return Boolean Value
        }

        /// <summary>
        /// Validate HTML File - Using Regex Expressions
        /// </summary>
        /// <param name="builder"></param>
        public bool ValidateHTMLFile(StringBuilder builder)
        {
            MatchCollection mCollection = null;
            MatchCollection MCollection = null;
            bool CheckTags = true;

            //Validate <html> tag
            if (!ParseTag("html", builder))
            {
                return false;
            }
            //Validate <head> tag
            if (!ParseTag("head", builder))
            {
                return false;
            }
            //Validate <title> tag
            if (!ParseTag("title", builder))
            {
                return false;
            }
            //Validate <body> tag
            if (!ParseTag("body", builder))
            {
                return false;
            }
            //Validate <form> tag
            if (!ParseTag("form", builder))
            {
                return false;
            }

            if (!ValidateHTMLTag("a", String.Empty, builder))
            {
                return false;
            }
            if (!ValidateHTMLTag("p","param", builder))
            {
                return false;
            }
            if (!ValidateHTMLTag("div", String.Empty, builder))
            {
                return false;
            }
            if (!ValidateHTMLTag("span", String.Empty, builder))
            {
                return false;
            }
            if (!ValidateHTMLTag("table", String.Empty, builder))
            {
                return false;
            }
            if (!ValidateHTMLTag("tr", String.Empty, builder))
            {
                return false;
            }
            if (!ValidateHTMLTag("td", String.Empty, builder))
            {
                return false;
            }
            if (!ValidateHTMLTag("object", String.Empty, builder))
            {
                return false;
            }          
            
            //Validate <strong> tag
            mCollection = Regex.Matches(builder.ToString(), "<strong>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            MCollection = Regex.Matches(builder.ToString(), "</strong>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            if (MCollection.Count != mCollection.Count)
            {
                CheckTags = false;
                return CheckTags;
            }

            //Validate bold <b> tag
            mCollection = Regex.Matches(builder.ToString(), "<b>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            MCollection = Regex.Matches(builder.ToString(), "</b>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            if (MCollection.Count != mCollection.Count)
            {
                CheckTags = false;
                return CheckTags;
            }

            //Validate </html> tag appears end of the file or not
            if (!Regex.IsMatch(builder.ToString(), "(</body(.*?)>)([.\\s\n]*</html(.*?)>$)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
            {
                return false;
            }
            
            //return Validate HTML boolean
            return CheckTags;

        }
        # endregion

    }
}
