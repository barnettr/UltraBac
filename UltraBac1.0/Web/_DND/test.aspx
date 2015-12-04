<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    void Page_Load(object sender, EventArgs e)
    {
        result.Text = text.Text + pattern.Text;
        if (Regex.Match(text.Text, pattern.Text).Success)
        {
             result.Text += "yes";
        } else
        {
            result.Text += "no";
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label AssociatedControlID="text">Text</asp:Label>
    <asp:TextBox runat="server" ID="text" Text="333.333.3333"/>
    
    <asp:Label AssociatedControlID="pattern">Pattern</asp:Label>
    <asp:TextBox runat="server" ID="pattern" Text="^\(?[\d]{3}(\) ?)?[\.-]?[\d]{3}[\.-][\d]{4}$" />
    
    <asp:Button runat="server" Text="submit" />
    <asp:Literal runat="server" ID="result" />
    </div>
    </form>
</body>
</html>
