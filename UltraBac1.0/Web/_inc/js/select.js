/**
 * Convert select menu to graphical equivalent
 * @source  http://old.easy-designs.net/articles/replaceSelect2/
*/

function selectReplacement(obj) {
	obj.className += ' hide';
	var ul = document.createElement('ul');
	ul.className = 'selectReplacement';
	var opts = obj.options;
	var selectedOpt = (!obj.selectedIndex) ? 0 : obj.selectedIndex;
	for (var i=0; i<opts.length; i++) {
		var li = document.createElement('li');
		var txt = document.createTextNode(opts[i].text);
		li.appendChild(txt);
		li.selIndex = i;
		li.selectID = obj.id;
		li.onclick = function() {
			selectMe(this);
		};
		if (i == selectedOpt) {
			li.className = 'selected';
			li.onclick = function() {
				this.parentNode.className += ' selectOpen';
				this.onclick = function() {
					selectMe(this);
				};
			};
		}
		if (window.attachEvent) {
			li.onmouseover = function() {
				this.className += ' hover';
			};
			li.onmouseout = function() {
				this.className = 
					this.className.replace(new RegExp(" hover\\b"), '');
			};
		}
		ul.appendChild(li);
	}
	obj.onfocus = function() {
		ul.className += ' selectFocused';
	};
		//	$Event.add(obj, 'blur', function(){ alert('blur'); } );
	
	obj.onblur = function() {
		ul.className = 'selectReplacement';
	};
	obj.onchange = function() {
		var idx = this.selectedIndex;
		selectMe(ul.childNodes[idx]);
	};
	obj.onkeypress = obj.onchange;
	obj.parentNode.insertBefore(ul,obj);
}
function selectMe(obj) {
	var lis = obj.parentNode.getElementsByTagName('li');
	for (var i=0; i<lis.length; i++) {
		if (lis[i] != obj) {
			lis[i].className='';
			lis[i].onclick = function() {
				selectMe(this);
			};
	 } else {
			selectSetVal(obj.selectID, obj.selIndex);
			obj.className='selected';
			obj.parentNode.className = 
				obj.parentNode.className.replace(new RegExp(" selectOpen\\b"), '');
			obj.onclick = function() {
				obj.parentNode.className += ' selectOpen';
				this.onclick = function() {
					selectMe(this);
				};
			};
		}
	}
}
function selectSetVal(objID,val) {
	var obj = document.getElementById(objID);
	obj.selectedIndex = val;
}
function selectSetForm() {
	var s = document.getElementsByTagName('select');
	for (var i=0; i<s.length; i++) {
		if (s[i].className == 'fancy') {
			selectReplacement(s[i]);
		}
	}
}

function selectInit() {
	if (!(document.all && !window.print)) { selectSetForm(); }
}

$Event.add(window, 'load', selectInit);
