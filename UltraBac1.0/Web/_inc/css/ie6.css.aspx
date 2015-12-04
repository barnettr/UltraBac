<%@ Page Language="C#" ContentType="text/css" %>
<%@ OutputCache VaryByParam="None" Duration="86400000" %>
/**
 * ie6.css
 * Custom styles applied specifically to Internet Explorer v.6 or earlier.  See also ie.css.
*/
/*
<!--<%= ResolveUrl("~/img/blah.gif") %>-->
*/

#Header_Top { overflow: hidden; } /* because IE 6 won't honor the explicit height on this div */
	
	/* linked transparent PNGs need a little UI help */
	.logo h2 a,
	.nav ul li.home a,
	.nav ul li.contact a,
	.nav ul li.events a,
	.nav ul li.kanji a,
	.nav ul li.cart a,
	.nav ul li.login a,
	.nav ul li.logout a
	{
		cursor: hand;
	}
	
	#Header_Stuff .menus div#nav_topics ul {
        background-image: url("../../_img/header/nav-header-top.gif");
	}
	#Header_Stuff .menus div#nav_topics div.bottom {
        background-image: url("../../_img/header/nav-header-bottom.gif");
	}
	
	#Header_Stuff .input_rounded .inner input {
		font-size: 11px;
	}
	
#Nav_Sub li { display: inline-block; }
	#Nav_Sub a { max-width: 197px; }
	#Nav_Sub ul {  }
	#Nav_Sub img.bottom { bottom: 1px; } /* some weird offset */

#Content { margin-right: 32px; } /* s/b 33px total - mysterious phantom pixel */

	/* forced IE6 to actually observe the box model - cuz "square" is SO hard! */
	#Content div.h1 { zoom: 1; }
	
	#Content .callout .tl { background-image: url("../../_img/box_tl_ie6.gif"); }
	#Content .callout .tr { background-image: url("../../_img/box_tr_ie6.gif"); }
	#Content .outline { position: relative; z-index: 1; }
		#Content .outline .tl,
		#Content .outline .tr,
		#Content .outline .bl, 
		#Content .outline .br { 
			position: relative; z-index: 100; 
		}
		#Content .outline .bl { margin-bottom: -2px; }

.actionButton-tabs {width: 200px;}
.actionButtons-long {width: 366px;}
.actionButtons-short {width: 204px;}

div.tabBody {
   zoom: 1;
}
div.tab_content {
   zoom: 1;
}
div.tab_content div.tab-items div.inner {
   zoom: 1;
}
div.tab_content div.tab-items div {
   zoom: 1;
}
#Nav_Site ul li a.products {
	background-image: url("../../_img/nav/products.gif");
}
#Nav_Site ul li a.support {
	background-image: url("../../_img/nav/support.gif");
}
#Nav_Site ul li a.partners {
	background-image: url("../../_img/nav/partners.gif");
}
#Nav_Site ul li a.news {
	background-image: url("../../_img/nav/news.gif");
}
#Nav_Site ul li a.company{
	background-image: url("../../_img/nav/about_us.gif");
} 
#Nav_Site ul li ul li {
	width: 200px;
}
#Nav_Site ul li ul li a {
	width: 200px;
}
#Header_Stuff .menus div#nav_topics {
    background: transparent url("../../_img/header/nav-header-arrow.gif") no-repeat top right;
}
#Header_Stuff .menus div#nav_topics {
	
}
#Header_Stuff .menus div#nav_topics ul {
	
}
#Sidebar {
    padding-left: 10px !important;
}
#Content {
    margin-right:20px !important;
}
#admin-query {
    width: 400px !important;
}
#Sidebar .input_rounded div.bottom {
	
}
#Header_Stuff .menus div#nav_topics ul li ul,
#Sidebar div#nav_products ul li ul {
	left: auto;
	/*margin-left: -252px;*/
	margin-top: -16px;
	position: static;
}
#Header_Stuff .menus div#nav_topics ul li ul li.first,
#Sidebar div#nav_products ul li ul li.first {
	padding-top: 16px;
}
#Sidebar .input_rounded .inner input {
	padding: 0.25em 0 0;
}
div.formBox div.formBox-content {
	height: 32px;
}
ul#headerBackgroundChooser {
	zoom:1;
	top:135px;
}

div#two-column-wrapper {width: 600px;}

.radio li input {margin-right: 3px;}

div.tab_content {zoom: 1;}

ul#faq-list {
    margin-left: 25px !important;
}
#Content ul.bullet {
    margin-left: 15px !important;
}
#Content ul.bullet li { 
    background:transparent !important;
    list-style-type:disc;
    color:red;
}
#Content ul.bullet li span.bulletFontColor {
	color:#4F4F4F;
}
div.tab_content div.leftBottom {
    background-position: 0 24px !important;
    left: 0;
}
div.tab_content div.rightBottom {
    background-position:right 24px !important;
    right:0;
}
ol.form li input.text {
    width:260px !important;
}

#tab_1 {
    width: 600px;
    height: 208px;
}
div#tab_purchase {
    
    background-color: #bc151b !important;
    height: 222px !important;
}
div#purchase-inner {
    height:212px !important;
    background-color: #ffffff !important;
}
