<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Head.ascx.cs" Inherits="_controls_template_Head" %>

	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta http-equiv="Content-Language" content="en-us" />
	<meta http-equiv="imagetoolbar" content="false" />
	<meta name="MSSmartTagsPreventParsing" content="true" />
	<link rel="shortcut icon" type="image/x-icon" href="<%= ResolveUrl("~/favicon.ico") %>" />

	<link href="<%= ResolveUrl("~/_inc/css/_main.css") %>" rel="stylesheet" type="text/css" media="screen,projection,tv" />
	<!--[if IE]>
		<link href="<%= ResolveUrl("~/_inc/css/ie.css") %>" rel="stylesheet" type="text/css" media="screen,projection,tv" />
	<![endif]-->
	<!--[if lt IE 7]>
		<script src="<%= ResolveUrl("~/_inc/js/IE7_0_9/ie7-standard-p.js") %>" type="text/javascript"></script>
		<link href="<%= ResolveUrl("~/_inc/css/ie6.css.aspx") %>" rel="stylesheet" type="text/css" media="screen,projection,tv" />
	<![endif]-->
	<!--[if IE 7]>
		<link href="<%= ResolveUrl("~/_inc/css/ie7.css") %>" rel="stylesheet" type="text/css" media="screen,projection,tv" />	
	<![endif]-->
	<!--[if IE 8]>
		<link href="<%= ResolveUrl("~/_inc/css/ie8.css") %>" rel="stylesheet" type="text/css" media="screen,projection,tv" />	
	<![endif]-->
	
	
	<link href="<%= ResolveUrl("~/_inc/css/print.css") %>" rel="stylesheet" type="text/css" media="print" />


	<script type="text/javascript">
    //<![CDATA[
    	var rootVirtual = '<%= ResolveUrl("~") %>';
    //]]>
    </script>
	<script type="text/javascript" src="<%= ResolveUrl("~/_inc/js/global_prototype_min.js") %>"></script>
	<script type="text/javascript" src="<%= ResolveUrl("~/_inc/js/scriptaculous/global_effects_min.js") %>"></script>
	<script type="text/javascript" src="<%= ResolveUrl("~/_inc/js/js.js") %>"></script>
