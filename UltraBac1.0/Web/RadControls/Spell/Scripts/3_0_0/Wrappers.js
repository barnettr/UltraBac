if (typeof(window.RadSpellNamespace)=="undefin\x65\x64"){window.RadSpellNamespace=new Object(); }window.RadSpellWrappers=new Object(); RadSpellNamespace.ir= function (text){var od=text.replace(/\x0a/gi,"\x3c\x74eleri\x6b\x63r />"); od=od.replace(/\x0d/gi,"\x3cteleriklf /\x3e"); return od; } ; RadSpellNamespace.Ir= function (text){var od=text.replace(/\x3c\x74\x65\x6c\x65\x72\x69\x6b\x63\x72\s*\x2f\x3e/gi,"\x0a"); var od=od.replace(/\x3c\x74\x65\x6c\x65\x72\x69\x6b\x6c\x66\s*\x2f\x3e/gi,"\x0d"); return od; } ; function HtmlElement(T,ownerDocument){ this.V=T; if (ownerDocument==null){ownerDocument=document; } ; this.ownerDocument=ownerDocument; } ; HtmlElement.prototype.os= function (){return (this.V.disabled!= true); } ; HtmlElement.prototype.Os= function (ls){var k=(ls== true)?"enable": "disable"; this[k](); } ; HtmlElement.prototype.is= function (){return ""; } ; HtmlElement.prototype.Is= function (){return ""; } ; HtmlElement.prototype.enable= function (){ this.V.disabled= false; if (this.Is()!=""){ this.V.className=this.Is(); } ; } ; HtmlElement.prototype.ot= function (){ this.V.disabled= true; if (this.is()!=""){ this.V.className=this.is(); } ; } ; HtmlElement.prototype.Ot= function (){return this.V.style.visibility!="hi\x64den"; } ; HtmlElement.prototype.hide= function (){ this.V.style.visibility="\x68\x69dden"; } ; HtmlElement.prototype.lt= function (){return this.V.style.display; } ; HtmlElement.prototype.it= function (It){ this.V.style.display=It; } ; HtmlElement.prototype.show= function (){ this.V.style.visibility="\x76isible"; } ; HtmlElement.ou= function (Ou,lu){if (lu==null){lu=document; } ; if (lu.all!=null){return lu.all[Ou]; } ; return lu.getElementById(Ou); } ; function iu(){var Iu= function (V,ownerDocument){ this.base=HtmlElement; this.base(V,ownerDocument); } ; Iu.prototype=new HtmlElement(); Iu.ov= function (Ou,lu){var Ov=HtmlElement.ou(Ou,lu); if (Ov==null){return null; }else {return new Iu(Ov,lu); } ; } ; return Iu; } ; RadSpellWrappers.Div=iu(); RadSpellWrappers.Div.prototype.getText= function (){return this.V.innerHTML; } ; RadSpellWrappers.Div.prototype.setText= function (caption){ this.V.innerHTML=caption; } ; RadSpellWrappers.Div.prototype.lv= function (c){ this.V.onclick=c; };RadSpellWrappers.HtmlSelect=iu(); RadSpellWrappers.HtmlSelect.prototype.iv= function (){return this.V.options.length; } ; RadSpellWrappers.HtmlSelect.prototype.addOption= function (Iv,ow){var Ow=new Option(Iv,ow); if (this.V.options.add!=null){ this.V.options.add(Ow); }else { this.V.options[this.iv()]=Ow; }} ; RadSpellWrappers.HtmlSelect.prototype.lw= function (){ this.V.options.length=0; } ; RadSpellWrappers.HtmlSelect.prototype.iw= function (){return this.V.selectedIndex; } ; RadSpellWrappers.HtmlSelect.prototype.Iw= function (selected){ this.V.selectedIndex=selected; } ; RadSpellWrappers.HtmlSelect.prototype.getItem= function (index){return this.V.options[index]; } ; RadSpellWrappers.TextArea=iu(); RadSpellWrappers.TextArea.prototype.getText= function (){return this.V.value; } ; RadSpellWrappers.TextArea.prototype.setText= function (text){ this.V.value=text; } ; RadSpellWrappers.IFrame=iu(); RadSpellWrappers.IFrame.prototype.getText= function (){var html=this.ox().innerHTML; return html!=null?html: ""; } ; RadSpellWrappers.IFrame.prototype.setText= function (text){ this.ox().innerHTML=text; } ; RadSpellWrappers.IFrame.prototype.o1= function (){var Ox=this.V.id; var iframe=null; if (this.ownerDocument.frames!=null && this.ownerDocument.frames[Ox]!=null){iframe=this.ownerDocument.frames[Ox]; } ; if (iframe==null){iframe=HtmlElement.ou(Ox,this.ownerDocument); } ; if (iframe.document!=null){return iframe.document; }else {return iframe.contentWindow.document; } ; } ; RadSpellWrappers.IFrame.prototype.ox= function (){return this.o1().body; } ; RadSpellWrappers.IFrame.prototype.lx= function (){var Ox=this.V.id; var iframe=null; if (this.ownerDocument.frames!=null && this.ownerDocument.frames[Ox]!=null){return this.ownerDocument.frames[Ox]; } ; if (iframe==null){var frame=HtmlElement.ou(Ox,this.ownerDocument); return frame.contentWindow; } ; return null; } ; RadSpellWrappers.IFrame.prototype.ix= function (){return typeof(this.ox().contentEditable)!="\165ndefined"; } ; RadSpellWrappers.IFrame.prototype.Ix= function (oy){if (this.ix()){ this.ox().contentEditable=oy; } ; } ; RadSpellWrappers.IFrame.prototype.Oy= function (){if (!this.ix()){return false; }else {return this.ox().contentEditable=="\x74rue" || this.ox().contentEditable== true; } ; } ; RadSpellWrappers.Button=iu(); RadSpellWrappers.Button.prototype.is= function (){return "But\x74\x6fnDisa\x62\x6ced"; } ; RadSpellWrappers.Button.prototype.Is= function (){return "\x42utton"; } ; RadSpellWrappers.Button.prototype.ly= function (){return this.V.innerHTML; } ; RadSpellWrappers.Button.prototype.iy= function (caption){ this.V.innerHTML=caption; } ;
if (typeof(Sys) != "undefined"){if (Sys.Application != null && Sys.Application.notifyScriptLoaded != null){Sys.Application.notifyScriptLoaded();}}