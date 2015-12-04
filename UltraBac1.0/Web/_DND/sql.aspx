<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

	private void Page_Load()
	{
		if (IsPostBack && !string.IsNullOrEmpty(uxText.Text))
		{
			try
			{
				string sqlCommand = uxText.Text;

				results.InnerText = String.Format("{0} records affected.", ExecuteSql(sqlCommand));
			}
			catch (Exception ex)
			{
				results.InnerText = Server.HtmlEncode(ex.ToString());
			}
		}
	}

    private int ExecuteSql(string sqlCommand)
    {
        int retVal = -1;

        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ZNodeECommerceDB"].ConnectionString;
            conn.Open();
            System.Data.SqlClient.SqlDataAdapter myAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommand, conn);
            myAdapter.SelectCommand.CommandType = System.Data.CommandType.Text;

            retVal = myAdapter.SelectCommand.ExecuteNonQuery();
        }
        return retVal;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox TextMode=MultiLine runat="server" ID="uxText" Height=400 Width=600/><br />
    
    <asp:Button runat="server" Text="execute" />
    
    <div runat="server" id="results">
    
    </div>    
    </div>
    </form>
</body>
</html>
