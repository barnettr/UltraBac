if (typeof(RadControlsNamespace)=="\165ndefi\x6e\x65d"){RadControlsNamespace= {} ; }if (typeof(RadControlsNamespace.DialogOpener)=="\x75ndefined" || typeof(RadControlsNamespace.DialogOpener.Version)==null || RadControlsNamespace.DialogOpener.Version<1){RadControlsNamespace.DialogOpener= function (t){ this.Id=t[0]; this.S=t[1]; this.DialogDefinitions=t[2]; this.AdditionalQueryString=t[3]; this.UseClassicDialogs=t[4]; this.DialogParametersMode=t[5]; this.UseEmbeddedScripts=t[6]; this.PageGuid=t[7]; this.Language=t[8]; this.Skin=t[9]; GetEditorRadWindowManager().SetOverImage(this.Id+"\x5fOverImg"); } ; RadControlsNamespace.DialogOpener.prototype= {Open:function (R,r,Q,P,N){if (!P){P=this.GetDialogDefinition(R); }var n= {DialogParameters:P.Parameters,CommonParameters: this.GetCommonParameters(),CustomArguments:r } ; var M=this.CreateRadWindowInfo(R,n,Q,P,N); return GetEditorRadWindowManager().ShowModalWindow(M); } ,GetDialogDefinition:function (R){return this.DialogDefinitions[R]; } ,GetCommonParameters:function (){return this.DialogDefinitions["Commo\x6eParamete\x72\x73"]; } ,CreateRadWindowInfo:function (R,n,Q,P,N){var M=new RadWindowInfo(); M.Url=this.GetFullHandlerUrl(R); M.Width=P.Width; M.Height=P.Height; M.Caption=P.Title; M.IsVisible= true; M.Argument=n; M.OnLoadFunc=null; M.Param=N; M.Resizable=P.Resizable; M.Movable=P.Movable; M.UseClassicDialogs=this.UseClassicDialogs; M.CallbackFunc=Q; return M; } ,GetFullHandlerUrl:function (R){var m=this.S.indexOf("?")<0?"\x3f": "&"; var L=this.S+m+"D\x69\x61logName\x3d"+R+"\x26UseEmbedd\x65\x64Scr\x69\x70t\x73\075"+this.UseEmbeddedScripts+"&Lan\x67\x75age="+this.Language+"\x26Skin="+this.Skin+"&Mode="+this.DialogParametersMode+""; if (this.DialogParametersMode!=0){L+="&\x50\x61geGuid="+this.PageGuid+"\x26ControlID="+this.Id; }return L; }};RadControlsNamespace.DialogOpener.Version=1; } ;
if (typeof(Sys) != "undefined"){if (Sys.Application != null && Sys.Application.notifyScriptLoaded != null){Sys.Application.notifyScriptLoaded();}}
