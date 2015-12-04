<%@ Control Language="C#" AutoEventWireup="true" CodeFile="jpDownloadForm.ascx.cs" Inherits="_controls_forms_jpDownloadForm" %>

<asp:PlaceHolder runat="server" ID="uxForm">
<ZNode:Content runat="server" />
<p><span class="red">*</span> = 必須項目</p>
<h2>お客様情報:</h2>


<ol class="form">
    <li>
        <asp:label runat="server" associatedcontrolid="uxiam" ><span class="likeheader3red" style="color: red;">*</span> お客様は、以下のどれに属しますか?:</asp:label>
        <Pop:RadioList runat="server" ID="uxiam" ContainerTag="Ol" CssClass="radio">
            <asp:ListItem Value="V1" Text="リセラー" />
            <asp:ListItem Value="V2" Text="エンドユーザー" />
            <asp:ListItem Selected="True" Value="V3" Text="その他." />
        </Pop:RadioList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="uxiam" ErrorMessage=" is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""   Display="Dynamic" />
        
    </li>
    <li>
        <asp:label runat="server" associatedcontrolid="firstname" ><span class="likeheader3red">*</span> 名:</asp:label>
        <input size="18" runat="server" id="firstname" class="text" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="firstname" ErrorMessage="First Name is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="Dynamic" />
    </li>
    <li>
        <asp:label runat="server" associatedcontrolid="lastname" ><td class="likeheader3"><span class="likeheader3red">*</span> 姓:</asp:label>
        <input size="18" runat="server" id="lastname" class="text" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="lastname" ErrorMessage="Last Name is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="Dynamic" />
    </li>
    <li>
        <asp:label runat="server" associatedcontrolid="organization" ><span class="likeheader3red">*</span> 所属法人名:（または会社名:）</asp:label>
        <input size="52" runat="server" id="organization" class="text" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="organization" ErrorMessage="Organization is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="static" />
    <li>
        <asp:label runat="server" associatedcontrolid="phone" ><span class="likeheader3red">*</span> 電話/内線:</asp:label>
        <input maxlength="25" size="18" runat="server" id="phone" class="text" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="phone" ErrorMessage="Phone is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="Dynamic" />
    </li>
    <li>
        <asp:label runat="server" associatedcontrolid="fax" >Fax:</asp:label>
        <input maxlength="25" size="18" runat="server" id="fax" class="text" />
       
    </li>
    <li>
        <asp:label runat="server" associatedcontrolid="email" ><span class="likeheader3red">*</span> E-mail:</asp:label>
        <input size="52" runat="server" id="email" class="text" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="email" ErrorMessage="Email is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="Dynamic" />
        <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ForeColor=" " CssClass="Error"
				ValidationGroup="jp"
                Display="Dynamic" ControlToValidate="email" 
               ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                ErrorMessage="Please enter a valid email address." ToolTip="Please enter a valid email address." />
    </li>
 </ol>
<h3>ライセンスキーの受信するため、有効なEメールアドレスを入力してください。<br />それができない場合、UltraBacの評価ができなくなります。</h3>
<p>
ライセンスキーファイルは上記アドレスに自動的に送信されます。 
バックアップ機能を使用するには有効なライセンスキーをインポートする必要があります。 
ライセンスキーファイルを受け取れなかった場合は、評価プロセスが続けられなくなる可能性があります。ご注意ください。 ライセンスに関するお問い合わせは <a title="mailto:licensing@ultrabac.com?subject=Licensing Issues" style="color: blue; text-decoration: underline;" href="mailto:licensing@ultrabac.com?subject=Licensing%20Issues">japansales@ultrabac.com 
(英語の場合はlicensing@ultrabac.com)</a>
</p>
<p>までご連絡ください。</p>

<h2>連絡先:</h2>
<ol class="form">
<li>   
    <asp:label runat="server" associatedcontrolid="address_1" >住所1:</asp:label>
    <input size="52" runat="server" id="address_1" class="text" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="address_2" >住所2:</asp:label>
    <input size="52" runat="server" id="address_2" class="text" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="city" >区/市:</asp:label>
    <input size="18" runat="server" id="city" class="text" />
    <div class="clear"></div>
</li> 
<li>
    <asp:label runat="server" associatedcontrolid="zip" >郵便番号:</asp:label>
    <input size="18" runat="server" id="zip" class="text" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="uxiaml" ><span class="likeheader3red">*</span> 居住地:</asp:label>
    
    <Pop:RadioList runat="server" ID="uxiaml" CssClass="radio" ContainerTag="Ol">
        <asp:ListItem Value="V1" Text="日本" />
        <asp:ListItem Value="V2" Text="北米" />
        <asp:ListItem Value="V3" Text="欧州 " />
        <asp:ListItem Value="V4" Text="その他" />
    </Pop:RadioList>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="uxiaml" ErrorMessage="Please select" CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="Dynamic" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="stateselect" ><span class="likeheader3red">*</span> 州/地方/自治区:<br />選択してください （US/カナダ）</asp:label>
    <select size="1" runat="server" id="stateselect">
      <option value="" selected="selected"></option>
      <option value=" INTERNATIONAL&nbsp;&nbsp;---&gt;">INTERNATIONAL&nbsp;&nbsp;---&gt;</option>
      <option value=" "></option>
      <option value=" - Select a STATE -">- Select a STATE -</option>
      <option value="Alabama">Alabama</option>
      <option value="Alaska">Alaska</option>
      <option value="Arizona">Arizona</option>
      <option value="Arkansas">Arkansas</option>
      <option value="California">California</option> 
      <option value="Colorado">Colorado</option>
      <option value="Connecticut">Connecticut</option>
      <option value="Delaware">Delaware</option> 
      <option value="Florida">Florida</option>
      <option value="Georgia">Georgia</option> 
      <option value="Hawaii">Hawaii</option>
      <option value="Idaho">Idaho</option>
      <option value="Illinois">Illinois</option>
      <option value="Indiana">Indiana</option>
      <option value="Iowa">Iowa</option>
      <option value="Kansas">Kansas</option>
      <option value="Kentucky">Kentucky</option>
      <option value="Louisiana">Louisiana</option> 
      <option value="Maine">Maine</option>
      <option value="Maryland">Maryland</option> 
      <option value="Massachusetts">Massachusetts</option>
      <option value="Michigan">Michigan</option>
      <option value="Minnesota">Minnesota</option> 
      <option value="Mississippi">Mississippi</option>
      <option value="Missouri">Missouri</option>
      <option value="Montana">Montana</option>
      <option value="North Carolina">North Carolina</option>
      <option value="North Dakota">North Dakota</option>
      <option value="Nebraska">Nebraska</option>
      <option value="Nevada">Nevada</option>
      <option value="New Hampshire">New Hampshire</option>
      <option value="New Jersey">New Jersey</option>
      <option value="New Mexico">New Mexico</option>
      <option value="New York">New York</option>
      <option value="Ohio">Ohio</option>
      <option value="Oklahoma">Oklahoma</option>
      <option value="Oregon">Oregon</option>
      <option value="Pennsylvania">Pennsylvania</option>
      <option value="Rhode Island">Rhode Island</option>
      <option value="South Carolina">South Carolina</option>
      <option value="South Dakota">South Dakota</option>
      <option value="Tennessee">Tennessee</option>
      <option value="Texas">Texas</option>
      <option value="Utah">Utah</option>
      <option value="Vermont">Vermont</option>
      <option value="Virginia">Virginia</option>
      <option value="Washington">Washington</option> 
      <option value="Washington D.C.">Washington D.C.</option>
      <option value="Wisconsin">Wisconsin</option>
      <option value="West Virginia">West Virginia</option>
      <option value="Wyoming">Wyoming</option>
      <option value="  "></option>
      <option value=" - Select a PROVINCE -">- Select a PROVINCE -</option>
      <option value="Alberta">Alberta</option>
      <option value="British Columbia">British Columbia</option>
      <option value="Manitoba">Manitoba</option>
      <option value="New Brunswick">New Brunswick</option>
      <option value="Newfoundland">Newfoundland</option>
      <option value="Nova Scotia">Nova Scotia</option>
      <option value="Ontario">Ontario</option> 
      <option value="Prince Edward Island">Prince Edward Island</option>
      <option value="Quebec">Quebec</option>
      <option value="Saskatchewan">Saskatchewan</option> 
      <option value=""></option>
      <option value=" - Select a TERRITORY -">- Select a TERRITORY -</option>
      <option value="American Samoa">American Samoa</option> 
      <option value="Guam">Guam</option>
      <option value="Northern Mariana Islands">Northern Mariana Islands</option>
      <option value="Puerto Rico">Puerto Rico</option>
      <option value="Virgin Islands">Virgin Islands</option>
    </select>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="stateselect" ErrorMessage="State/Province is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="static" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="countryselect" ><span class="likeheader3red">*</span> 国名:<br />選択してください</asp:label>
        
    <select size="1" runat="server" id="countryselect">
      <option value="">- Select a COUNTRY -</option>
      <option value=" NOT IN LIST --&gt;   ">NOT IN LIST --&gt;</option> 
      <option value="Argentina">Argentina</option>
      <option value="Australia">Australia</option>
      <option value="Austria">Austria</option> 
      <option value="Belarus">Belarus</option>
      <option value="Belgium">Belgium</option> 
      <option value="Bermuda">Bermuda</option>
      <option value="Bolivia">Bolivia</option> 
      <option value="Botswana">Botswana</option>
      <option value="Brazil">Brazil</option> 
      <option value="British West Indies">British West Indies</option>
      <option value="Bulgaria">Bulgaria</option>
      <option value="Canada">Canada</option>
      <option value="Chile">Chile</option>
      <option value="China">China</option>
      <option value="Columbia">Columbia</option>
      <option value="Croatia">Croatia</option>
      <option value="Czech Republic">Czech Republic</option>
      <option value="Denmark">Denmark</option>
      <option value="Egypt">Egypt</option>
      <option value="Finland">Finland</option>
      <option value="France">France</option>
      <option value="Germany">Germany</option>
      <option value="Greece">Greece</option>
      <option value="Guatemala">Guatemala</option>
      <option value="Hong Kong">Hong Kong</option> 
      <option value="Hungary">Hungary</option>
      <option value="Iceland">Iceland</option> 
      <option value="India">India</option>
      <option value="Indonesia">Indonesia</option> 
      <option value="Ireland">Ireland</option>
      <option value="Israel">Israel</option> 
      <option value="Italy">Italy</option>
      <option value="Japan">Japan</option>
      <option value="Latvia">Latvia</option>
      <option value="Lithuania">Lithuania</option>
      <option value="Malaysia">Malaysia</option>
      <option value="Mauritus">Mauritus</option> 
      <option value="Mexico">Mexico</option>
      <option value="Mozambique">Mozambique</option>
      <option value="The Netherlands">Netherlands</option>
      <option value="New Zealand">New Zealand</option>
      <option value="Nigeria">Nigeria</option>
      <option value="Norway">Norway</option>
      <option value="Pakistan">Pakistan</option>
      <option value="Panama">Panama</option>
      <option value="Peru">Peru</option>
      <option value="Philippines">Philippines</option>
      <option value="Poland">Poland</option> 
      <option value="Portugal">Portugal</option>
      <option value="Romania">Romania</option> 
      <option value="Russia">Russia</option>
      <option value="Saudi Arabia">Saudi Arabia</option>
      <option value="Singapore">Singapore</option>
      <option value="Slovenija">Slovenija</option>
      <option value="South Africa">South Africa</option>
      <option value="Spain">Spain</option>
      <option value="Sweden">Sweden</option>
      <option value="Switzerland">Switzerland</option> 
      <option value="Taiwan">Taiwan</option>
      <option value="Tasmania">Tasmania</option> 
      <option value="Thailand">Thailand</option>
      <option value="The Netherlands">The Netherlands</option>
      <option value="Trinidad, W.I.">Trinidad, W.I.</option> 
      <option value="Turkey">Turkey</option>
      <option value="United Arab Emirates">UAE</option>
      <option value="UK">UK</option>
      <option value="Ukraine">Ukraine</option>
      <option value="United Arab Emirates ">United Arab Emirates</option>
      <option value="United Kingdom">United Kingdom</option>
      <option value="U.S.A.">U.S.A.</option>
      <option value="Vietnam">Vietnam</option>
      <option value="Venezuela">Venezuela</option>
      <option value="Zimbabwe">Zimbabwe</option>
    </select>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="countryselect" ErrorMessage="Country is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="static" />
    <div class="clear"></div>
</li>
</ol>
<h2>アンケートにご協力ください:</h2>
<ol class="form">

<li>
    <asp:label runat="server" associatedcontrolid="ntserver1" ><span class="likeheader3red">*</span> Windowsサーバーの台数をご記入ください?</asp:label>
    <input size="5" runat="server" id="ntserver1" class="text" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="ntserver1" ErrorMessage="Server is required." CssClass="Error" SetFocusOnError="true" ValidationGroup="jp" ForeColor=""  Display="static" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="prios" >プライマリサーバーOSの種類をご記入ください。（NT4.0、Win2000、Win2003、など）:</asp:label>
    <input size="5" runat="server" id="prios" class="text" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="ntserver2" >Windowsサーバーを何台バックアップに使用していますか?</asp:label>
    <input size="5" runat="server" id="ntserver2" class="text" />
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="uxcb" >現在ご利用のバックアップ製品は次のうちどれですか?<br />（複数回答可）</asp:label>
    <Pop:CheckList runat="server" ID="uxcb" CssClass="radio" ContainerTag="Ol">
        <asp:ListItem Value="native_nt" Text="Native NT Backup Utility　（Ｍｉｃｒｏｓｏｆｔ）" />
        <asp:ListItem Value="backupexec" Text="BackupExec (Ｓｙｍａｎｔｅｃ)" />
        <asp:ListItem Value="arcserve" Text="ARCserve　（ＣＡ）" />
        <asp:ListItem Value="buother" Text="その他 " />
	</Pop:CheckList>
	<asp:label runat="server" associatedcontrolid="buother1" >その他： </asp:label>
	<input runat="server" id="buother1" class="text" type="text" />
</li>
<li>
    <asp:label runat="server" associatedcontrolid="uxdisaster_rec" >貴社では、ディザスタ 
リカバリは通常のバックアップソリューションとは別の課題と捉えていますか?</asp:label>
    <Pop:RadioList runat="server" ID="uxdisaster_rec" CssClass="radio" ContainerTag="Ol">
        <asp:ListItem Value="1" Text="はい " />
        <asp:ListItem Value="2" Text="いいえ" />
    </Pop:RadioList>
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="uxreliability" >現在ご使用されているWindows用バックアップソフトウェアのバックアップや復元に関しては十分に信頼できていますか?</asp:label>
    <Pop:RadioList runat="server" ID="uxreliability" CssClass="radio" ContainerTag="Ol">
        <asp:ListItem Value="2" Text="いいえ" />
        <asp:ListItem Value="1" Text="はい" />
    </Pop:RadioList>
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="tech_support" >現在ご使用中のバックアップソフトウェアに関して、サポートには満足されていますか?</asp:label>
    <select size="1" runat="server" id="tech_support">
      <option value="Unspecified" selected="selected">Select a Value</option>
      <option value="Excellent">Excellent</option>
      <option value="Good">Good</option>
      <option value="Average">Average</option>
      <option value="Poor">Poor</option>
      <option value="Couldn't Be Worse">Couldn't be worse</option>
    </select>
    <div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="problems" >その他に、バックアップに関する深刻な問題がありましたらご記入ください。</asp:label>
    <textarea runat="server" id="problems" rows="3" cols="60">
</textarea>
<div class="clear"></div>
</li>
<li>
    <asp:label runat="server" associatedcontrolid="foundvia" >弊社製品をどこで知りましたか?</asp:label>
    <select size="1" runat="server" id="foundvia">
      <option value="Unspecified" selected="selected">Select a Value</option>
      <option value="Google">Google</option>
      <option value="Other Search Engine">Other Search Engine</option>
      <option value="Internet News Group">Internet News Group</option> 
      <option value="Windows &amp; .NET  Magazine">Windows &amp; .NET Magazine</option>
      <option value="SQL Server Magazine">SQL Server Magazine</option>
      <option value="InfoStor">InfoStor</option>
      <option value="Storage Management Solutions">Storage Management Solutions</option> 
      <option value="Computer Technology Review">Computer Technology Review</option> 
      <option value="HP World">HP World</option>
      <option value="Information Week">Information Week</option>
      <option value="MCP">MCP</option>
      <option value="Windows Email Newsletter">Windows Email Newsletter</option>
      <option value="SQL Email Newsletter">SQL Email Newsletter</option>
      <option value="UltraBac Software Email Newsletter">UltraBac Software Email Newsletter</option>
      <option value="UltraBac Software Email">UltraBac Software Email</option>
      <option value="UltraBac Postcard">UltraBac Postcard</option>
      <option value="Other">Other</option>
    </select>
    <div class="clear"></div>
</li>
<li>
    <label></label>
    <asp:Button runat="server" CssClass="submit marginCenter floatnone" Text="Submit" ValidationGroup="jp" OnClick="Submit_Click" />
    <div class="clear"></div>
</li>
</ol>
<p>「送信してダウンロードページへ」ボタンをクリックしたら、ダウンロードページが表示されるまで15秒ほどお待ちください。<br />
<a href="javascript:history.go(0);">表示されない場合はこのページを更新してください。</a></p>
<p><strong>更新しても問題が解決しない場合は技術サポート｢英語では</strong><br />
<a href="../techsupport/40tech-support-form">または日本語ではjapansales@ultrabac.com</a>
</p>
</asp:PlaceHolder>

<ZNode:CustomMessage ID="uxMessage" runat="server" MessageKey="JapaneseDownloadFormSubmitted" Visible="false" />