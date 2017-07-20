
function setVariables() {
	if (navigator.appName == "Netscape") {
		v=".top=";
		dS="document.";
		sD="";
		y="window.pageYOffset";
	}
	else {
		v=".pixelTop=";
		dS="";
		sD=".style";
		y="document.body.scrollTop";
	}
}


function checkLocation() {
	object="object1"
	yy=eval(y);
	eval(dS+object+sD+v+yy);
	setTimeout("checkLocation()",10);
}


function MM_swapImgRestore() { //v3.0
	var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}


function MM_preloadImages() { //v3.0
	var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}


function MM_findObj(n, d) { //v4.01
	var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
	if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
	for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
	if(!x && d.getElementById) x=d.getElementById(n); return x;
}


function MM_swapImage() { //v3.0
	var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
	if ((x=MM_findObj(a[i]))!=null){
		document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];
	}
}


var gAutoPrint = true;             
function PrintThisPage() { 
	var sOption="toolbar=yes,location=no,directories=yes,menubar=yes,"; 
	sOption+="scrollbars=yes,width=750,height=600,left=100,top=25"; 
	var sWinHTML='<HTML>\n<HEAD>\n';	
	var headTags = document.getElementsByTagName("head");
	if (headTags.length > 0)
		sWinHTML += headTags[0].innerHTML;
		sWinHTML += '\n</HE' + 'AD>\n<BODY >\n';
		sWinHTML += document.getElementById('contentstart').innerHTML; 
		sWinHTML += '\n</BO' + 'DY>\n</HT' + 'ML>';
	var winprint=window.open("","PrintThisPage",sOption); 
	winprint.document.open();  
	winprint.document.write(sWinHTML);          
	winprint.document.close();
	if (gAutoPrint)
		winprint.print();   
} 


function onTop(url,w){
	win1=open(url,w,"resizable,scrollbars");
	win1.focus();
}      


function ShowPanel(div,img){
    if(document.getElementById(img).className == "c")
    {
		document.getElementById(img).className = "e";
        document.getElementById(img).src = "Images/collapse.gif";
        document.getElementById(div).style.display = "block";
    }
    else
    {
		document.getElementById(img).className = "c";
        document.getElementById(img).src = "Images/expands.gif";
        document.getElementById(div).style.display = "none";
    }
}

function selectAll() {
 
    form1 = document.getElementById('Form1');
	if (form1.Todos.checked == true) {
		for (i=0; i < form1.ckbList.length; i++) {
			// Percorre todas as checks e vai por todas como true
			form1.ckbList[i].checked = true;
		}
	}
	
	if (form1.Todos.checked == false) {
		for (i=0; i < form1.ckbList.length; i++) {
			form1.ckbList[i].checked = false;
		}
	}
}

function selectOne() {
 
    form1 = document.getElementById('Form1');
    varAux = true;
	for (i=0; i < form1.ckbList.length; i++) {
		if (form1.ckbList[i].checked == false){
			varAux = false;
		}
	}
	
	if (varAux == false) {
		form1.Todos.checked = false;
	}
	else {
		form1.Todos.checked = true;
	}
}


function ckbListValidation(source, args) { 
	form1 = document.all('Form1');
    varAux = false;
	for (i=0; i < form1.ckbList.length; i++) {
		if (form1.ckbList[i].checked == true){
			varAux = true;
		}
	}
    args.IsValid = varAux; 
} 


function NewWindow(mypage,myname,w,h,scroll,pos){
var win=null;
if(pos=="random"){LeftPosition=(screen.width)?Math.floor(Math.random()*(screen.width-w)):100;TopPosition=(screen.height)?Math.floor(Math.random()*((screen.height-h)-75)):100;}
if(pos=="center"){LeftPosition=(screen.width)?(screen.width-w)/2:100;TopPosition=(screen.height)?(screen.height-h)/2:100;}
else if((pos!="center" && pos!="random") || pos==null){LeftPosition=0;TopPosition=20}
settings='width='+w+',height='+h+',top='+TopPosition+',left='+LeftPosition+',scrollbars='+scroll+',location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
win=window.open(mypage,myname,settings);
}

