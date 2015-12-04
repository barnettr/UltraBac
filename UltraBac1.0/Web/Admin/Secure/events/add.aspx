<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Themes/Standard/content.master" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="Admin_Secure_events_add" %>
<%@ Register Src="~/Controls/HtmlTextBox.ascx" TagName="HtmlTextBox" TagPrefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadPlaceholder">
    <link rel="Stylesheet" type="text/css" href="<%= ResolveUrl("~/_inc/css/_main.css") %>"> </link>
    <script type="text/javascript" language="javascript" src="<%=ResolveUrl("~/_inc/js/prototype.js") %>"></script>
    <script type="text/javascript" language="javascript" src="<%=ResolveUrl("~/_inc/js/prototype-date-extensions.js") %>"></script>
    <script type="text/javascript" language="javascript" src="<%=ResolveUrl("~/_inc/js/datepicker.js") %>"></script>
    <script type="text/javascript" language="javascript">
        Event.observe(window, "load", function() {
            var startDate = new Control.DatePicker('<%= uxStartDate.ClientID %>', { dateFormat: "M/d/y" });
            var endDate = new Control.DatePicker('<%= uxEndDate.ClientID %>', { dateFormat: "M/d/y" });
           });

           function ValidateDates(source, clientside_arguments) {
           	var begStr = $('<%= uxStartDate.ClientID %>').value;
           	var endStr = $('<%= uxEndDate.ClientID %>').value;
           	var begin = Date.parse(begStr, "M-d-y");
           	var end = Date.parse(endStr, "M-d-y");           	
           	clientside_arguments.IsValid = begin <= end;
           }
    </script>
    <!-- Because the website form styles were not designed for the admin tool so we have to change a couple of things for the admin tool add event page -->
    <style type="text/css">
        ol.form {
            width: 80%;
        }
        ol.form li label {
            width: 56px;
            text-align: left;
        }
        .Error
        {
        	margin-left:5px;        	
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="uxMainContent" Runat="Server">
<h1><asp:Literal runat="server" ID="lblTitle" /></h1>
<ol class="form">
<li>
<asp:Label runat="server" AssociatedControlID="uxTitle" Text="Title" />
<asp:TextBox runat="server" ID="uxTitle" CssClass="text" />
<asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="uxTitle" ErrorMessage="Please enter a title" ForeColor="" CssClass="Error" />
</li><li>
<asp:Label runat="server" AssociatedControlID="uxStartDate" Text="Start Date"  />
<asp:TextBox runat="server" ID="uxStartDate" CssClass="pickDate text" />
<asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="uxStartDate" ErrorMessage="Please enter a start date" ForeColor="" CssClass="Error" />
<asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="uxStartDate" ErrorMessage="Start date not valid" ForeColor="" CssClass="Error" ValidationExpression="^(?:(?:(?:0?[13578]|1[02])(\/|-)31)|(?:(?:0?[1,3-9]|1[0-2])(\/|-)(?:29|30)))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:0?[1-9]|1[0-2])(\/|-)(?:0?[1-9]|1\d|2[0-8]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(0?2(\/|-)29)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
</li><li>
<asp:Label runat="server" AssociatedControlID="uxEndDate" Text="End Date" />
<asp:TextBox runat="server" ID="uxEndDate" CssClass="pickDate text" />
<asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="uxEndDate" ErrorMessage="Please enter an end date" ForeColor="" CssClass="Error" />
<asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="uxEndDate" ErrorMessage="End date not valid" ForeColor="" CssClass="Error" ValidationExpression="^(?:(?:(?:0?[13578]|1[02])(\/|-)31)|(?:(?:0?[1,3-9]|1[0-2])(\/|-)(?:29|30)))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:0?[1-9]|1[0-2])(\/|-)(?:0?[1-9]|1\d|2[0-8]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(0?2(\/|-)29)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
<asp:CustomValidator runat="server" Display="Dynamic" ControlToValidate="uxEndDate" OnServerValidate="dates_ServerValidate" ClientValidationFunction="ValidateDates" ErrorMessage="End date cannot be before start date" ForeColor="" CssClass="Error" />
</li><li>
<asp:Label runat="server" AssociatedControlID="uxLocation" Text="Location" />
<asp:TextBox runat="server" ID="uxLocation" CssClass="text"  />
<asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="uxLocation" ErrorMessage="Please enter a location" ForeColor="" CssClass="Error" />
</li><li>
<asp:Label runat="server" AssociatedControlID="uxBooth" Text="Booth" />
<asp:TextBox runat="server" ID="uxBooth" CssClass="text" />
</li><li>
<asp:Label runat="server" AssociatedControlID="uxLink" Text="Link" />
<asp:TextBox runat="server" ID="uxLink" CssClass="text" />
</li>
<li runat="server" visible="false">
<asp:Label runat="server" AssociatedControlID="uxShortDescription" Text="Short Description" />
<asp:TextBox runat="server" ID="uxShortDescription" CssClass="text" />
<asp:RequiredFieldValidator Enabled="false" runat="server" Display="Dynamic" ControlToValidate="uxShortDescription" ErrorMessage="Please enter a short description" ForeColor="" CssClass="Error" />
</li>

<li>
<asp:Label runat="server" AssociatedControlID="uxDetail" Text="Detail" />
<uc1:HtmlTextBox id="uxDetail" runat="server"></uc1:HtmlTextBox>
</li><li>
<label></label>
<asp:Button runat="server" ID="uxSubmit" CssClass="submit Button" OnClick="uxSubmit_Click" Text="Add event" /> 
</li><li>
<label></label>
<asp:Button runat="server" ID="uxCancel" ValidationGroup="none" CssClass="Button submit" OnClick="uxCancel_Click" Text="Cancel" /> 
</li>
</ol>
</asp:Content>
