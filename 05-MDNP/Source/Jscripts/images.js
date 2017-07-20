

function zoomIn() {
	document.getElementById('imgDO').height *= 0.8;
}

function zoomOut() {
	document.getElementById('imgDO').height *= 1.2;
}

function zoomDefault() {
    document.getElementById('imgDO').height = 1000;
}
        
     
var num = 0;
        
function rotateRight() {
        
	num += 1;
	if (num==4)
	num = 0;
				 						
	var div = document.getElementById('divImage');
	var str = 'progid:DXImageTransform.Microsoft.BasicImage(rotation=' + num + ')';
	div.style.filter = str;
}
        
function rotateLeft() {
        
	num -= 1;
	if (num==-1)
	num = 3;
				 						
	var div = document.getElementById('divImage');
	var str = 'progid:DXImageTransform.Microsoft.BasicImage(rotation=' + num + ')';
	div.style.filter = str;
				
}

function janelaPopUp(destino,wt,ht,rs)
{
	if( document.all && window.showModalDialog){ //internet explorer browser
			// set dialog args and properties
			var dialogProperties = "status:no; resizable:yes; center:yes; minimize:no; maximize:yes; help:no; scroll:yes; border:thin; dialogHide:true; dialogWidth:" + document.getElementById('imgDO').width + "px; dialogHeight:" + document.getElementById('imgDO').height + "px"
			var dialogArgs = new Object();
			// show modal dialog box and collect its return value
			var rtext = window.showModalDialog(destino, dialogArgs, dialogProperties);
	}else{	//other browsers
		 var dialogArgs = new Object();
         var dialogProperties = "status=no, scrollbars=yes, width="+ document.getElementById('imgDO').width +", height=" + document.getElementById('imgDO').height +",resizable="+ rs + ",modal=yes";
         var ref = window.open(destino,null,dialogProperties);
         ref.focus();
	}
}

function novajanela(destino,wt,ht,rs)
{
		 var dialogArgs = new Object();
         var dialogProperties = "status:no; center:yes; minimize:yes; maximize:yes; help:no; scroll:yes; border:thin; dialogHide:true; dialogWidth:"+ wt +"px; dialogHeight:" + ht +"px;resizable:"+ rs;
         novaJanela = window.showModalDialog(destino,dialogArgs,dialogProperties);
}
