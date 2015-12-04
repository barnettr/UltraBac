<%@ Page Language="C#" MasterPageFile="~/Themes/default/form/Form.master" AutoEventWireup="true" CodeFile="styleguide.aspx.cs" Inherits="_DND_styleguide" Title="Untitled Page" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadPlaceHolder">

<script type="text/javascript" language="javascript">
//<![CDATA[
//Tab Switcher
document.observe("dom:loaded", function(){
	// without options
	//ts = new TabSwitcher("ul#tabs li a", "div.tab_content div[id^=tab_]");

	// with options
	ts = new TabSwitcher("ul.tabs li a", "div.tab_content div[id^=tab_]", {
		initialTabIndex: 2,
		tabOnClassName: 'on',
		tabOffClassName: 'off',
		bodyOnStyles: {
			display: 'block'
		},
		bodyOffStyles: {
			display: 'none'
		}
	}
	);
});
//]]>
</script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server" >
<h1>header 1</h1>

<h2>header 2</h2>

<h3>header 3</h3>

<h4>header 4</h4>

<p>normal paragraph</p>

<div class="hr"></div>

<a href="NEEDURL">link</a>

<a class="arrowLink" href="NEEDURL">arrow link</a>

<p>normal paragraph<br />
<a class="arrowLink" href="NEEDURL">with an arrow link</a></p>

<ul class="bullet">
	<li>red bullet list</li>
	<li>red bullet list</li>
</ul>

<ul class="bullet bulletFlush">
	<li>red bullet flushed left list</li>
	<li>red bullet flushed left list</li>
</ul>

<ul class="plain flush">
	<li><a href="NEEDURL">link list</a></li>
	<li><a href="NEEDURL">link list</a></li>
</ul>	

<img class="borderedImage" src="NEEDURL" alt="NEEDALT" />

<div class="flexBucket">
    <div class="flexBucket-top">
	    <div class="flexBucket-top-left"><h2>with an h2</h2></div>
	    <div class="clear"></div>
    </div>

    <div class="flexBucket-mid">
        <div class="flexBucket-content">
        </div>
        <div class="clear"></div>
    </div>

    <div class="flexBucket-bot">
	    <div class="flexBucket-bot-left"></div>
    </div>
</div><!-- end of flex box -->

<div class="flexBucket" id="specificExampleBox">
    <div class="flexBucket-top">
	    <div class="flexBucket-top-left"><h3>with an h3</h3></div>
	    <div class="clear"></div>
    </div>

    <div class="flexBucket-mid">
        <div class="flexBucket-content">
        </div>
        <div class="clear"></div>
    </div>

    <div class="flexBucket-bot">
	    <div class="flexBucket-bot-left"></div>
    </div>
</div><!-- end of flex box -->
<!-- forms go here -->

<ul class="tabs">
	<li>
	    <div class="tab-right">
	        <div class="tab-left">
	            <a href="#tab_1">Tab 1 fds </a>
	        </div>
	    </div>
	</li>
	<li>
	    <div class="tab-right">
            <div class="tab-left">
                <a href="#tab_2">Tab 2 fdsa </a>
            </div>
        </div>
    </li>
	<li>			    
	    <div class="tab-right">
            <div class="tab-left">
                <a href="#tab_3">Tab 3</a>
            </div>
        </div>
    </li>
</ul>
<div class="clear"></div>
<div class="tab_content">
	<div id="tab_1" class="tab-items">
		<div class="inner">
			<div class="lt whiteCorner"></div>
			<div class="rt whiteCorner"></div>
			<div class="tabBody">
				hi 1
			</div>
			<div class="lb whiteCorner"></div>
			<div class="rb whiteCorner"></div>
		</div>
		<div class="leftBottom redCorner"></div>
		<div class="rightBottom redCorner"></div>      
    </div>
    <div id="tab_2" class="tab-items">
		<div class="inner">
			<div class="lt whiteCorner"></div>
			<div class="rt whiteCorner"></div>
			<div class="tabBody">
				hi 2
			</div>
			<div class="lb whiteCorner"></div>
			<div class="rb whiteCorner"></div>   
		</div>
		<div class="leftBottom redCorner"></div>
		<div class="rightBottom redCorner"></div>        
    </div>
    <div id="tab_3" class="tab-items">
		<div class="inner">
			<div class="lt whiteCorner"></div>
			<div class="rt whiteCorner"></div>
			<div class="tabBody">
				<a class="actionButton" href="NEEDURL">
					<span class="actionButton-right actionButtons-tabs">
						<span class="actionButton-left">
							This is for a tab one
						</span>
					</span>
				</a>
				<div class="clear"></div>
			</div>
			<div class="lb whiteCorner"></div>
			<div class="rb whiteCorner"></div>
		</div>
		<div class="leftBottom redCorner"></div>
		<div class="rightBottom redCorner"></div>
    </div>
	<div class="clear"></div>
</div>


<a class="actionButton" href="NEEDURL">
    <span class="actionButton-right actionButtons-long">
        <span class="actionButton-left">
            This is for a long one
        </span>
    </span>
</a>
<div class="clear"></div>
<a class="actionButton" href="NEEDURL">
    <span class="actionButton-right actionButtons-short">
        <span class="actionButton-left">
            This is for a short one
        </span>
    </span>
</a>
<div class="clear"></div>

<div class="formBox">
    <div class="lt formCorner"></div>
    <div class="rt formCorner"></div>
    <div class="formBox-content">
        albah blahfdskfjlmasdfjksl
    </div>
    <div class="lb formCorner"></div>
    <div class="rb formCorner"></div>
</div>

<dl class="lists">
    <dt>OS:</dt>
    <dd>Windows Vista - all patches<br />Windows 2003 Server/XP Professional  - SP2 and all patches<br />Windows 2000 Server/Professional - SP4 and all patches<br />NT4 Server/Workstation - SP6a and all patches<br />
    </dd>
    <dt>Memory:</dt>
    <dd>Minimum OS requirement is acceptable</dd>
    <dt>Disk space:</dt>
    <dd>Minimum 40 MB free space, 1 GB recommended.</dd>
</dl>
<div class="clear"></div>
<div class="hr"></div>
<table summary="Current Press Releases" class="tabular">
    <thead>
        <tr>
            <th>Date</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><a href="#NEED_URL#" title="Download the 09/10/07 newsletter">09/10/07</a></td>
            <td>UltraBac Software Announces VMware Technology Alliance Partnership</td>
        </tr>
        <tr>
            <td><a href="#NEED_URL#" title="Download the 06/05/07 newsletter">06/05/07</a></td>
            <td>UltraBac Software’s UBDR Gold Version 3.5 Expands on Dissimilar Hardware Capabilities</td>
        </tr>
    </tbody>
</table>

<ol class="form">
    <li>
        <label>Name</label>
        <input class="text" type="text" />
    </li>
    <li>
        <label>Phone</label>
        <input class="text" type="text" />
    </li>
    <li>
        <label>Radio</label>
        <input class="radio" type="radio" />
    </li>
    <li>
        <label>Checkbox</label>
        <input class="checkbox" type="checkbox" />
    </li>    
    <li>
        <label>Textbox</label>
        <textarea class="text"></textarea>
    </li>     
    <li>
        <label>Select</label>
        <select>
            <option>option A</option>
            <option>option B</option>
        </select>
    </li>  
    <li>
        <label></label>
        <input class="submit" type="submit" value="submit" />
    </li>        
</ol>
	

</asp:Content>
