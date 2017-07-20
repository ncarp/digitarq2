/**	fullJS.js														**/
/** V2_6_33_28_WS_3_25_4 + - 5/Julho/06 (...)  						**/
/**	- solved problem with deleteOptions (Campanhas +Valor)			**/
/**																	**/
/** V2_6_33_28_WS_3_25_4 - 5/Julho/06 (...)  						**/
/**																	**/


/* popup.js *******************************************************************/

/* ALERT POPUP */ 

var focusedObj = null;
var kb = null;
var actionCode = null;

window.onBeforeOnload = closeSession();

function closeSession(){

	//alert('close session');
}

function showAlert(message, object) {
  kb = document.getElementById("keyboard");
  if (kb) {
    kb.style.display = 'none';
  }

    if (object) {
        focusedObj = object;
        if (object.blur) object.blur();
    } else {
        focusedObj = null;
    }

    document.getElementById("alertMessage").innerHTML=message;

    showOnTopDIV("fullTransparentDIV");
    showDIV("alertDIV");
}

function showAlertForDiv(message, object) {
  kb = document.getElementById("keyboard");
  if (kb) {
    kb.style.display = 'none';
  }

    focusedObj = null;
    document.getElementById("alertMessage").innerHTML=message;

    showOnTopDIV("fullTransparentDIV");
    showDIV("alertDIV");
}

function showActionAlert(message, _actionCode) {
  actionCode = _actionCode;
  kb = document.getElementById("keyboard");
  if (kb) {
    kb.style.display = 'none';
  }


    document.getElementById("alertMessage").innerHTML=message;

    showOnTopDIV("fullTransparentDIV");
    showDIV("alertDIV");
}

/* END - ALERT POPUP */



/* QUESTION POPUP */

function askQuestion(message,yesCode,noCode) {
    // Place the validation errors
  document.getElementById("questionMessage").innerHTML=message;
    document.getElementById("questionYes").onclick = function(){
    hideDIV('questionDIV');
    eval(yesCode);
    //askQuestion= function(){return;}
  };
  if (noCode) {
    document.getElementById("questionNo").onclick = function(){
      hideOnTopDIV('fullTransparentDIV');
      hideDIV('questionDIV');
      eval(noCode);
      };
  } else {
    document.getElementById("questionNo").onclick = function(){
      hideOnTopDIV('fullTransparentDIV');
      hideDIV('questionDIV');
    };
  }

  // Show the div with the confirmation
  showOnTopDIV("fullTransparentDIV");
  showDIV("questionDIV");
}

function showOneButtonAlert(message,buttonCode) {
  // Place the validation errors
  document.getElementById("questionMessage").innerHTML=message;
  document.getElementById("questionYes").innerHTML='Cancelar';
  document.getElementById("questionYes").onclick = function() {
        hideDIV('questionDIV');
        eval(buttonCode);
    };
    document.getElementById("questionNo").style.display = 'none';
    // Show the div with the confirmation
    showOnTopDIV("fullTransparentDIV");
    showDIV("questionDIV");
}

/* END QUESTION POPUP */

/* WAIT POPUP */
function showWaitMessage() {
    showOnTopDIV("fullTransparentDIV");
    showDIV("waitPopupDIV");
    if (document.getElementById('keyboard')) {
      document.getElementById('keyboard').style.display = 'none';
    }
}
function hideWaitPopupDIV(){
hideDIV("waitPopupDIV");

}



/* VALIDATOR POPUP */
var kb = null;
function showValidator(messages) {
    kb = document.getElementById("keyboard");
    if (kb) {
        kb.style.display = 'none';
    }
    // Place the validation errors
    document.getElementById("messages").innerHTML=messages;
    // Show the div with the confirmation
    showOnTopDIV("fullTransparentDIV");
    showDIV("validatorDIV");
}


/* used with the writeValidatorWADiv.jsp div and VgnJavascriptValidatorTag@showMessageMethodJS method 	*/
/* in international transfers (overides normal validator messages display) 								*/
function showValidatorDIV(messages) {
    kb = document.getElementById("keyboard");
    if (kb) {
        kb.style.display = 'none';
    }
    // Place the validation errors
    document.getElementById("messagesDIV2").innerHTML=messages;
    // Show the div with the confirmation
    showOnTopDIV("fullTransparentDIV");
    showDIV("validatorDIV2");
}

/* fieldTypes.js **************************************************************/
function numbersOnly(myfield, e, dec)
{
var key;
var keychar;

if (window.event)
   key = window.event.keyCode;
else if (e)
   key = e.which;
else
   return true;
keychar = String.fromCharCode(key);

// control keys
if ((key==null) || (key==0) || (key==8) ||
    (key==9) || (key==13) || (key==27) )
   return true;

// numbers
else if ((("0123456789").indexOf(keychar) > -1))
   return true;

// decimal point jump
/*
else if (dec && (keychar == "."))
   {
   myfield.form.elements[dec].focus();
   return false;
   }
*/
else if ((keychar == ".") && dec && (dec==true))
   {
   return true;
   }
else
   return false;
}
// -----------------------------------------------------------------------------
function justNumberOnly(e){
var key;
var keychar;

if (window.event)
   key = window.event.keyCode;
else if (e)
   key = e.which;
else
   return true;
keychar = String.fromCharCode(key);
keychar = keychar.toLowerCase();

// control keys
if ((key==null) || (key==0) || (key==8) || (key==9) || (key==13) || (key==27) )  return false;

//keypad keys
//0 ... 9
if ((key >= 96) && (key <= 105))  return true;

// numbers
else if ((("0123456789").indexOf(keychar) > -1))
   return true;
else
   return false;
}
//-----------------------------------------------------------------------------
function pasteNumberOnly(dec){

  if (window.clipboardData) {
 var clipChar = window.clipboardData.getData("Text");
 var ValidChars = "0123456789."
 var Char ;
 var IsNumber=false;

  if ((clipChar == null) || (clipChar == ""))
    return true;

 for (i = 0; (i < clipChar.length)  && (IsNumber == false); i++)    {
     Char =  clipChar.charAt(i);
     if (ValidChars.indexOf(Char)== -1){
             IsNumber = true;
     }
  }

 if(IsNumber){
   window.clipboardData.setData("Text","");
 }
  }

return IsNumber;
}


function alphaOnly(e)
{
var key;
var keychar;

if (window.event)
   key = window.event.keyCode;
else if (e)
   key = e.which;
else
   return true;
keychar = String.fromCharCode(key);
keychar = keychar.toLowerCase();

// control keys
if ((key==null) || (key==0) || (key==8) ||
    (key==9) || (key==13) || (key==27) )
   return true;

// alphas and numbers
else if ((("abcdefghijklmnopqrstuvwxyz0123456789").indexOf(keychar) > -1))
   return true;
else
   return false;
}


// -----------------------------------------------------------------------------

function alphaToUpperCase(e)
{
var key;
var keychar;

if (window.event)
   key = window.event.keyCode;
else if (e)
   key = e.which;
else
   return true;
keychar = String.fromCharCode(key);
keychar = keychar.toUpperCase();
e
// control keys
if ((key==null) || (key==0) || (key==8) ||
    (key==9) || (key==13) || (key==27) )
   return true;

// alphas and numbers
else if ((("ABCDEFGHIJKLMNOPQRSTUVWXYZ ").indexOf(keychar) > -1))
   return true;
else
   return false;
}

// -----------------------------------------------------------------------------
function lettersOnly(e)
{
var key;
var keychar;



if (window.event && window.event.keyCode)
   key = window.event.keyCode;
else if (e)
   key = e.which;
else {
    return true;
}

keychar = String.fromCharCode(key);
keychar = keychar.toLowerCase();

// control keys
if ((key==null) || (key==0) || (key==8) ||
    (key==9) || (key==13) || (key==27) )
return true;

// alphas
else if ((("abcdefghijklmnopqrstuvwxyz ").indexOf(keychar) > -1))
   return true;
else
   return false;
}
// -----------------------------------------------------------------------------
function pasteLetterOnly(){
 var IsLetter = false;
 if (window.clipboardData) {
     var clipChar = window.clipboardData.getData("Text");
     var Char ;
     var ValidChars = "abcdefghijklmnopqrstuvwxyz";


    if ( clipChar == null || clipChar == "" )
      return IsLetter;

     for (i = 0; i < clipChar.length  && IsLetter  == false; i++)    {
         Char =  clipChar.charAt(i);
         if (ValidChars.indexOf(Char) == -1)   {
              IsLetter = true;
           }
      }
     if(IsLetter ){
       window.clipboardData.setData("Text","");
     }
 }
 return IsLetter;

}


function pasteThisCharsetOnly( charset, caseSensitive){
 var IsOK = false;
 if (window.clipboardData) {
     var clipChar = window.clipboardData.getData("Text");
     var Char ;

      if ( clipChar == null || clipChar == "" )
          return IsOK;

     if (caseSensitive && (caseSensitive == true)) {
            clipChar = clipChar.toLowerCase();
     }



     for (i = 0; i < clipChar.length  && IsOK  == false; i++)    {
         Char =  clipChar.charAt(i);
         if (charset.indexOf(Char) == -1)   {
              IsOK = true;
           }
      }
     if(IsOK ){
       window.clipboardData.setData("Text","");
     }
 }
 return IsOK;

}
//----------------------------------------------------
//-----------------------------------------------------------------------------
function thisCharsetOnly(e,charset,caseSensitive)
{
var key;
var keychar;

if (window.event)
   key = window.event.keyCode;
else if (e)
   key = e.which;
else
   return true;
keychar = String.fromCharCode(key);
if (caseSensitive && (caseSensitive == true)) {
    keychar = keychar.toLowerCase();
}

// control keys
if ((key==null) || (key==0) || (key==8) ||
    (key==9) || (key==13) || (key==27) )
   return true;

// alphas and numbers
else if (((charset).indexOf(keychar) > -1))
   return true;
else
   return false;
}
//----------------------------------------------------
function submitEnter(myfield,e)
{
var keycode;
if (window.event) keycode = window.event.keyCode;
else if (e) keycode = e.which;
else return true;

if (keycode == 13)
   {
   myfield.form.submit();
   myfield.onkeypress=function(){ showAlert('Operação em curso...'); return true;};
   return false;
   }
else
   return true;
}

/* div_script.js **************************************************************/
var ez_strictHTML=0;
var ez_usefx=0;
var ez_isMac=(navigator.appVersion.indexOf("Mac")!=-1);
var ez_NN4=document.layers?1:0;
var ez_IE4=document.getElementById?0:1;
var ez_OPR=(navigator.userAgent.indexOf("Opera")!=-1)?1:0;
var ez_OPR7=0;
var ez_isIE=(navigator.appVersion.indexOf("MSIE")>-1)?1:0;
var ez_NS6=(document.getElementById&&!document.all&&!ez_OPR)?1:0;
if(ez_OPR){
temp=navigator.userAgent.split("Opera");
if(temp[1].substring(0,1)=="/"){temp=temp[1].split("/");}
ver=parseFloat(temp[1]);
if(ver>=7)ez_OPR7=1;
if(ver<7)ez_strictHTML=0;
}
var ez_MOZ=0;
ez_MOZ=(navigator.userAgent.indexOf("ozilla")!=-1)?1:0;
ez_SAF=(navigator.userAgent.indexOf("Safari")!=-1)?1:0;
var aspnm_hideSelectElems=true;
var aspnm_restoreSelectElems=true;
var aspnm_mac=false;
aspnm_hideSelectElems=aspnm_restoreSelectElems=(ez_isIE&&!ez_OPR7);

//hide selected elements for the divs (yes, ie big unresolved problem :-///)
function aspnm_hideSelectElements(group){

	if(aspnm_hideSelectElems&&document.getElementsByTagName){

		var arrElements=document.getElementsByTagName('select');
		
		for(var i=0;i<arrElements.length;i++){
		
			if(aspnm_objectsOverlapping(document.all[group],arrElements[i])){
				arrElements[i].style.visibility='hidden';
			}
		}
	}
}

//show selected elements (cause the divs)
function aspnm_restoreSomeSelectElements(group)
{

	if(aspnm_restoreSelectElems&&document.getElementsByTagName){
	
		var arrElements=document.getElementsByTagName('select');

		for(var i=0;i<arrElements.length;i++){
		
			if(aspnm_objectsOverlapping(document.all[group],arrElements[i])){
				arrElements[i].style.visibility='visible';
			}
		}
	}
}

//show all selected elements
function aspnm_restoreSelectElements(){

	if(aspnm_restoreSelectElems&&document.getElementsByTagName){

		var arrElements=document.getElementsByTagName('select');

		for(var i=0;i<arrElements.length;i++){
			arrElements[i].style.visibility='visible';
		}
	}
}

function aspnm_objectsOverlapping(obj1,obj2)
{
var result=true;
var obj1Left=aspnm_pageX(obj1)-window.document.body.scrollLeft;
var obj1Top=aspnm_pageY(obj1)-window.document.body.scrollTop;
var obj1Right=obj1Left+obj1.offsetWidth;
var obj1Bottom=obj1Top+obj1.offsetHeight;
var obj2Left=aspnm_pageX(obj2)-window.document.body.scrollLeft;
var obj2Top=aspnm_pageY(obj2)-window.document.body.scrollTop;
var obj2Right=obj2Left+obj2.offsetWidth;
var obj2Bottom=obj2Top+obj2.offsetHeight;
if(obj1Right<=obj2Left||obj1Bottom<=obj2Top||
obj1Left>=obj2Right||obj1Top>=obj2Bottom)
result=false;
return result;
}
function aspnm_pageX(o)
{
return(aspnm_mac?aspnm_macX(o):aspnm_winX(o));
}
function aspnm_winX(o)
{
var x=0;
while(o!=document.body)
{
x+=o.offsetLeft;
o=o.offsetParent;
}
return x;
}
function aspnm_macX(o)
{
var x=0;
while(o.offsetParent!=document.body)
{
if((o.tagName=="TABLE")&&(o.offsetParent.tagName=="TD"))
x+=o.clientLeft;
else
x+=o.offsetLeft;
o=o.offsetParent;
}
x+=(o.offsetLeft+aspnm_pgMrgX());
return x;
}
function aspnm_pgMrgX()
{
if(!aspnm_marginX)
{
if(!document.all["aspnm_pgMrgMsr"])
aspnm_createPgMrgMsr();
aspnm_marginX=-document.all["aspnm_pgMrgMsr"].offsetLeft;
}
return aspnm_marginX;
}
function aspnm_pageY(o)
{
return(aspnm_mac?aspnm_macY(o):aspnm_winY(o));
}
function aspnm_winY(o)
{
var y=0;
while(o!=document.body)
{
y+=o.offsetTop;
o=o.offsetParent;
}
return y;
}
function aspnm_macY(o)
{
var y=0;
while(o.offsetParent!=document.body)
{
if((o.tagName=="TABLE")&&(o.offsetParent.tagName=="TD"))
y+=o.clientTop;
else
y+=(o.tagName!="TD")?o.offsetTop:o.parentElement.offsetTop;
o=o.offsetParent;
}
y+=(o.offsetTop+aspnm_pgMrgY());
return y;
}
function aspnm_pgMrgY()
{
if(!aspnm_marginY)
{
if(!document.all["aspnm_pgMrgMsr"])
aspnm_createPgMrgMsr();
aspnm_marginY=-document.all["aspnm_pgMrgMsr"].offsetTop;
}
return aspnm_marginY;
}
function aspnm_createPgMrgMsr()
{
document.body.insertAdjacentHTML('beforeEnd',
'<div id="aspnm_pgMrgMsr" style="position:absolute;left:0;top:0;z-index:-1000;visibility:hidden">*</div>');
}

/* AUTO JUMP CODE *************************************************************/
var downStrokeField;
function autojump(fieldName,nextFieldName,fakeMaxLength)
{
var myForm=document.forms[document.forms.length-1];
var myField=myForm.elements[fieldName];
myField.nextField=myForm.elements[nextFieldName];
if(myField.maxLength==null)
myField.maxLength=fakeMaxLength;
myField.onkeydown=autojump_keyDown;
myField.onkeyup=autojump_keyUp;
}
function autojump_keyDown()
{
this.beforeLength=this.value.length;
downStrokeField=this;
}
function autojump_keyUp()
{
if(
(this==downStrokeField)&&
(this.value.length>this.beforeLength)&&
(this.value.length>=this.maxLength)
)
this.nextField.focus();
downStrokeField=null;
}
function jumpToDecimal(field,myfield,e,dec){
var key;
var keychar;
if(window.event){key=window.event.keyCode;}
else if(e){key=e.which;}
else{return true;}
if(key==44||key==46){
document.getElementById(field+'Dec').focus();
return false;
}else{
return numbersOnly(myfield,e,dec);
}
}
function dontJump(field,myfield,e,dec){
var key;
var keychar;
if(window.event){key=window.event.keyCode;}
else if(e){key=e.which;}
else{return true;}
if(key==44||key==46){
return false;
}else{
return numbersOnly(myfield,e,dec);
}
}
/* AUTO JUMP CODE END *********************************************************/


/* popups.js ******************************************************************/
function getYSize(){
var myWidth=0,myHeight=0;
if(typeof(window.innerWidth)=='number'){
myWidth=window.innerWidth;
myHeight=window.innerHeight;
}else if(document.documentElement&&
(document.documentElement.clientWidth||document.documentElement.clientHeight)){
myWidth=document.documentElement.clientWidth;
myHeight=document.documentElement.clientHeight;
}else if(document.body&&(document.body.clientWidth||document.body.clientHeight)){
myWidth=document.body.clientWidth;
myHeight=document.body.clientHeight;
}
return myHeight;
}
function getScrollY(){
var scrOfX=0,scrOfY=0;
if(typeof(window.pageYOffset)=='number'){
scrOfY=window.pageYOffset;
scrOfX=window.pageXOffset;
}else if(document.body&&(document.body.scrollLeft||document.body.scrollTop)){
scrOfY=document.body.scrollTop;
scrOfX=document.body.scrollLeft;
}else if(document.documentElement&&
(document.documentElement.scrollLeft||document.documentElement.scrollTop)){
scrOfY=document.documentElement.scrollTop;
scrOfX=document.documentElement.scrollLeft;
}
return scrOfY;
}
function getScrollXY() {
var x,y;
var test1 = document.body.scrollHeight;
var test2 = document.body.offsetHeight
if (test1 > test2) // all but Explorer Mac
{
	x = document.body.scrollWidth;
	y = document.body.scrollHeight;
}
else // Explorer Mac;
     //would also work in Explorer 6 Strict, Mozilla and Safari
{
	x = document.body.offsetWidth;
	y = document.body.offsetHeight;
}

return [x,y];
}

function showOnTopDIV(divId){

	styleObj=document.getElementById(divId).style;

	var scrollY=getScrollY();
	var ySize=getYSize();
	var newHeight= getScrollXY()[1];//scrollY+ySize;

	styleObj.height=newHeight+'px';

	if(ez_OPR||ez_SAF){
		styleObj.background="url('web/images/back.png')";

		if(ez_MOZ&&ez_isMac){}
		
	}else{
		styleObj.backgroundColor="#ffffff";
	}

	scroll(0,0);
	showDIV(divId);
	
	aspnm_hideSelectElements(divId);
}
function hideOnTopDIV(divId){
	aspnm_restoreSomeSelectElements(divId);
	hideDIV(divId);
}

function hideDIV(divId){
	document.getElementById(divId).style.display="none";
}

function showDIV(divId){
	document.getElementById(divId).style.display="inline";
}

function openPopup(url,title,attrs){
var w=400;
var h=510;
var x=(window.screen.width/2)-((w/2)+10);
var y=(window.screen.height/2)-((h/2)+50);
var _attrs='dependent=yes, toolbar=no, location=no, directories=no, status=no, menubar=0, scrollbars=yes, resizable=no, copyhistory=yes, width='+w+', height='+h+' ,left='+x+',top='+y+'';
var _title="";
if(attrs){
_attrs=attrs;
}
if(title){
_title=title;
}
if(!url)return;
url+=((url.indexOf('?')>0)?'&':'?')+"popup=1";
var win=window.open(url,_title,_attrs);
win.focus();
return win;
}
/* multiple.js ****************************************************************/
function MM_swapImgRestore(){
var i,x,a=document.MM_sr;for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++)x.src=x.oSrc;
}
function MM_preloadImages(){
var d=document;if(d.images){if(!d.MM_p)d.MM_p=new Array();
var i,j=d.MM_p.length,a=MM_preloadImages.arguments;for(i=0;i<a.length;i++)
if(a[i].indexOf("#")!=0){d.MM_p[j]=new Image;d.MM_p[j++].src=a[i];}}
}
function MM_findObj(n,d){
var p,i,x;if(!d)d=document;if((p=n.indexOf("?"))>0&&parent.frames.length){
d=parent.frames[n.substring(p+1)].document;n=n.substring(0,p);}
if(!(x=d[n])&&d.all)x=d.all[n];for(i=0;!x&&i<d.forms.length;i++)x=d.forms[i][n];
for(i=0;!x&&d.layers&&i<d.layers.length;i++)x=MM_findObj(n,d.layers[i].document);
if(!x&&d.getElementById)x=d.getElementById(n);return x;
}
function MM_swapImage(){
var i,j=0,x,a=MM_swapImage.arguments;document.MM_sr=new Array;for(i=0;i<(a.length-2);i+=3)
if((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x;if(!x.oSrc)x.oSrc=x.src;x.src=a[i+2];}
}
function openWindow(url,y,x)
{
mypopupWin=window.open(url,'exemplo','width='+x+',height='+y+',left=0,top=0,scrollbars=0,resizable=no');
mypopupWin.resizeTo(x+10,y+28);
mypopupWin.focus();
}
var lastOne;
function change(tt){
lastOne=tt.parentNode.parentNode.className;
if(tt.parentNode.parentNode.className==lastOne)
tt.parentNode.parentNode.className="table_tr_03";
}
function change1(tt){
if(tt.parentNode.parentNode.className!=lastOne)
tt.parentNode.parentNode.className=lastOne;
}
function change3a(element){
var currentRowElement=element.parentNode.parentNode;
var tableElement=element.parentNode.parentNode.parentNode.parentNode;
var _element=element.parentNode.parentNode.parentNode;
var tableRows=_element.childNodes;
for(var i=0;i<tableRows.length;i++){
if((tableRows.item(i).nodeType==1)&&(tableRows.item(i)==currentRowElement)){
tableRows.item(i).className="table_tr_03";
if(tableRows.item(i+1)){
for(var next=1;tableRows.item(i+next).nodeType!=1;next++);
tableRows.item(i+next).className=tableRows.item(i).className;
}
}
}
}
function change3b(element,previousStyle){
var currentRowElement=element.parentNode.parentNode;
var tableElement=element.parentNode.parentNode.parentNode.parentNode;
var _element=element.parentNode.parentNode.parentNode;
var tableRows=_element.childNodes;
for(var i=0;i<tableRows.length;i++){
if((tableRows.item(i).nodeType==1)&&(tableRows.item(i)==currentRowElement)){
tableRows.item(i).className=previousStyle;
if(tableRows.item(i+1)){
for(var next=1;tableRows.item(i+next).nodeType!=1;next++);
tableRows.item(i+next).className=tableRows.item(i).className;
}
}
}
}
function getFormGroup(name){
return document.getElementsByName(name);
}
function getRadio(name){
elements=getFormGroup(name);
if(elements){
for(i=0;i<elements.length;i++)
if(elements[i].checked)
return elements[i];
return null;
}
}
function getRadioValue(name){
element=getRadio(name);
if(element)
return element.value;
return'';
}
function go(link){
var previousLink=document.forms[0].action;
document.forms[0].action=link;
document.forms[0].submit();
document.forms[0].action=previousLink;
}
function goWithForm(link,formName){
form=document.getElementById(formName);
var previousLink=form.action;
form.action=link;
form.submit();
form.action=previousLink;
}

function refreshPage(){
	document.forms[0].submit();
}


function cpArray(orgArray,dstArray,len){
for(var i=0;i<len;i++)
dstArray[i]=orgArray[i];
}
function qtdClick(id){
if(parseInt(document.getElementById(id).value)==0)
document.getElementById(id).value="";
}
function qtdChange(id){
if(document.getElementById(id).value=="")
document.getElementById(id).value="0";
}


function minClick(name){
if(parseInt(document.getElementById(name).value)=='0')
document.getElementById(name).value='';
}
function minChange(name){
obj=document.getElementById(name);
if(obj.value==""){
obj.value='00';
}else{
if(obj.value.length==1){obj.value=obj.value+'0';}
}
}


function cleanLeftZeros(str){
var aux="";
found=false;
if(str==null)return null;
if(str=="")return"";
for(i=0;i<str.length;i++){
if(found){
aux+=str.charAt(i);
}else{
if(str.charAt(i)!='0'){
aux+=str.charAt(i);
found=true;
}
}
}
return aux;
}


function jsFillDate(dateArrayName,date){
eval(dateArrayName)[kDAY]=date.getDate();
eval(dateArrayName)[kMONTH]=date.getMonth()+1;
eval(dateArrayName)[kYEAR]=date.getFullYear();
}
function jsFillDateArray(dateArrayName,dateArrayName2){
eval(dateArrayName)[kDAY]=eval(dateArrayName2)[kDAY];
eval(dateArrayName)[kMONTH]=eval(dateArrayName2)[kMONTH]
eval(dateArrayName)[kYEAR]=eval(dateArrayName2)[kYEAR]
}
function jsShowDate(dateArrayName){
alert(dateArrayName+" "+eval(dateArrayName)[kDAY]+" / "+eval(dateArrayName)[kMONTH]+" / "+eval(dateArrayName)[kYEAR]);
}
function parseAmountValue(xpto){
str=""+xpto;
newXpto=str.replace(".",",");
if(!gotCharStr(newXpto,","))
newXpto+=",00";
return newXpto;
}
function gotCharStr(str,c){
if(str=="")return false;
for(i=0;i<str.length;i++){
if(str.charAt(i)==c)
return true;
}
return false;
}

/** Drop Downs functions **/
/*** take to full JS ***/
function getSelectedValueFromDD(id){
	obj=document.getElementById(id);

	if(obj==null)
		return;
	else
		return obj.options[obj.selectedIndex].value
}

function setOptions(dropDownBox,optionsArray){
	dropDownBox.options.length = 0;
	for(i = 0; i < optionsArray.length; i++){
		if (optionsArray [i] != null){	
			dropDownBox.options [dropDownBox.options.length] = optionsArray [i];
		}
 	}
}

function getOption(dropDownBox,optionValue){
	for(i = 0; i < dropDownBox.options.length; i++){
		if (dropDownBox.options [i] != null){	
			if(dropDownBox.options [i].value == optionValue){
				return i;
			}
		}
 	}
 	return -1;
}

function getOptionByIndex(dropDownBox,index){

	return dropDownBox.options [index];
}



function deleteOptions(dropDownBox){

	
	var optionsArray = dropDownBox.options
	
	for(i = 0; i < optionsArray.length; i++){
		if (optionsArray [i] != null){	
			optionsArray[i] = null;
		}
 	}
}

function filterDefaultOption(dropDownBox){
	// default options has index 0
	if (dropDownBox.selectedIndex == 0 && dropDownBox.options.length > 1 ){
		dropDownBox.selectedIndex = 1;
	}
}

function hideHtmlElement(e){
	if (e) e.style.display='none';
}

function showHtmlElement(e){
	if (e) e.style.display='inline';
}

function setHtmlElementValue(e,value){
	if (e) {
		e.value = value;
	}
}
function setInnerHtml(e,value){
	if (e) {
		e.innerHTML = value;
	}
}


/* TOP MENU JS (top_menu.js)****************************************************************/
function jsDownload_JS(linkObj, actionName){
    //actionName = actionName.substring(actionName.lastIndexOf("/"));
    //actionName = actionName.substring(0, actionName.indexOf("."));
    //actionName = actionName.substring(1);
    var downloadFile = actionName;
    var url = actionName+".do?download="+downloadFile+".tsv";
    // linkObj.href = url;
    go(url);
    return true;
}

function jsPrint_JS(linkObj, actionName, queryString){
    //actionName = actionName.substring(actionName.lastIndexOf("/"));
    //actionName = actionName.substring(0, actionName.indexOf("."));
    //actionName = actionName.substring(1);
    var downloadFile = actionName;
    var qStr="";
    var ELE;

    if (document.forms[0] != null) {
        for(i=0; i<document.forms[0].elements.length; i++) {
            var element =document.forms[0].elements[i];
            if (element.type!="undefined") {
                if ( (element.type == "hidden" || element.type == "text" || element.type == "textarea" || element.type == "select-one")
                        || ((element.type == "checkbox" || element.type == "radio") && (element.checked)) ) {
                    qStr +="&"+element.name+"="+element.value;
                }
            }
        }
    } //if

    if (queryString != "") {
        if (qStr != "") {
            qStr = qStr+"&";
        } else {
            qStr = "&"+qStr;
        }
        qStr= qStr+queryString;
    }
    var url = actionName+".do?popup=1&print=1"+qStr;
    w = 620;
      h = 566;
    x = (window.screen.width/2) - ((w/2) + 10);
    y = (window.screen.height/2) - ((h/2) + 50);
    var win = window.open(url,'Impressao','dependent=yes, toolbar=no, location=no, directories=no, status=no, menubar=0, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+' ,left='+x+',top='+y+'');
      // We can also try something like this:
    // document.forms[0].target = "new windows....";
    win.focus();
    return true;
}

function openWindow() {
    var f = document.forms[0];
    f.target = 'foo';
    var win =window.open('',f.target,'dependent=yes, toolbar=no, location=no, directories=no, status=no, menubar=0, scrollbars=yes, resizable=no, copyhistory=no, width=650');
    win.focus();
    f.submit();
    return false;
}
/* TOP MENU JS END ************************************************************/


/** DIV (div_script.js) **/
function writeAlertDiv(okButtonLabel,left) {
    var doc = document;
    if (!left) left = 186;
    doc.writeln('<div id="alertDIV" style="display: none; left: '+left+'px; top: 164px; Z-INDEX: 1001; POSITION: absolute;">');
    doc.writeln('<table border="0" cellspacing="0" cellpadding="0" class="popup_table">');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('<tr>');
    doc.writeln('	<td id="alertMessage" class="popup_msg2" colspan="2"></td>');
    doc.writeln('</tr>');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="34" border="0"></td></tr>');
    doc.writeln('<tr>');
    doc.writeln('	<td width="1"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td>');
    doc.writeln('	<td class="popup_msg1" width="399">');
    doc.writeln('		<a onclick="javascript: if (actionCode) { eval(actionCode); };');
    doc.writeln('					if (focusedObj) {if (focusedObj.focus) focusedObj.focus();}');
    doc.writeln('					hideOnTopDIV(\'fullTransparentDIV\');');
    doc.writeln('					hideDIV(\'alertDIV\'); ');
    doc.writeln('					if (kb) { kb.style.display = \'inline\';}"');
    doc.writeln('					href="#" class="Button_1">' + okButtonLabel + '</a>');
    doc.writeln('	</td>');
    doc.writeln('</tr>');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('</table>');
    doc.writeln('</div>');
}
function writeValidatorWADiv(okButtonLabel,left) {
    var doc = document;
    if (!left) left = 186;
    doc.writeln('<div id="validatorDIV" style="display: none; left: '+left+'px; top: 164px; Z-INDEX: 1001; POSITION: absolute;">');
    doc.writeln('<table border="0" cellspacing="0" cellpadding="0" class="popup_table">');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('<tr>');
    doc.writeln('	<td id="messages" class="popup_msg2" colspan="2"></td>');
    doc.writeln('</tr>');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="34" border="0"></td></tr>');
    doc.writeln('<tr>');
    doc.writeln('	<td width="1"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td>');
    doc.writeln('	<td class="popup_msg1" width="399">');
    doc.writeln('		<a onclick="hideOnTopDIV(\'fullTransparentDIV\'); ');
    doc.writeln('					hideDIV(\'validatorDIV\'); ');
    doc.writeln('					if (fieldToFocus) { fieldToFocus.focus(); }; ');
    doc.writeln('					if (kb) { kb.style.display = \'inline\'; }" ');
    doc.writeln('					href="#" class="Button_1">'+okButtonLabel+'</a>');
    doc.writeln('	</td>');
    doc.writeln('</tr>');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('</table>');
    doc.writeln('</div>');
}
function writeQuestionDiv(yesButtonLabel, noButtonLabel, left) {
    var doc = document;
    if (!left) left = 186;
    doc.writeln('<div id="questionDIV" style="display: none; left: '+left+'px; top: 164px; Z-INDEX: 1001; POSITION: absolute;">');
    doc.writeln('<table border="0" cellspacing="0" cellpadding="0" class="popup_table">');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('<tr>');
    doc.writeln('	<td id="questionMessage" class="popup_msg2" colspan="2"></td>');
    doc.writeln('</tr>');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="34" border="0"></td></tr>');
    doc.writeln('<tr>');
    doc.writeln('	<td width="1"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td>');
    doc.writeln('	<td class="popup_msg1" width="399">');
    doc.writeln('		<a id="questionYes" href="#" class="Button_1">'+yesButtonLabel+'</a>');
    doc.writeln('		<a id="questionNo" href="#" class="Button_1">'+noButtonLabel+'</a>');
    doc.writeln('	</td>');
    doc.writeln('</tr>');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('</table>');
    doc.writeln('</div>');
}
function writeWaitDiv(waitMessage, left) {
    var doc = document;
    if (!left) left = 186;
    doc.writeln('<div id="waitPopupDIV" style="display: none; left: '+left+'px; top: 164px; Z-INDEX: 1001; POSITION: absolute;">');
    doc.writeln('<table border="0" cellspacing="0" cellpadding="0" class="popup_table">');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('<tr><td class="popup_msg2" colspan="2">'+waitMessage+'</td></tr>');
    doc.writeln('<tr><td colspan="2"><img src="web/images/px.gif" alt="" width="1" height="24" border="0"></td></tr>');
    doc.writeln('</table>');
    doc.writeln('</div>');
}
function writeFullTransparentDiv(width) {
    var doc = document;
    if (!width) width = 760;
    doc.writeln('<div id="fullTransparentDIV" style="opacity: .5; DISPLAY: none; Z-INDEX: 1000; FILTER: alpha(opacity=70); VISIBILITY: visible; POSITION: absolute; -moz-opacity: .6; width: '+width+'px; height: 100%; left: 0px; top: 0px;"></div>');
	
}

/* VIRTUAL KEYBOARD (virtualKey.js) ***********************************************************/
var vKeyActiveField=null;
var vKeyActiveFieldIndex=0;
var vKeyNextFieldId=null;
//identificadores dos campos de input
var inputs;
//tamanhos maximos dos campos de input
var inputsMaxLength;
//contentor dos valores dos campos de input
var inputValues;
//indicador do tipo de campo de input (password=true, text=false)
var inputTypes;
var inputStyle='Input_Login';
var inputStyleActive='Input_Login2';
var initialPageName = null;
var browserCompromisedMsg;
function initKeyboard(inputsArray,inputsMaxLengthArray, inValues, inTypes, _inputStyle,_inputStyleActive, _vKeyNextFieldId){
    inputs=inputsArray;
    inputsMaxLength=inputsMaxLengthArray;
    inputValues = inValues;
    inputTypes = inTypes;
    if(_inputStyle){
        inputStyle=_inputStyle;
    }
    if(_inputStyleActive){
        inputStyleActive=_inputStyleActive;
    }
    if(!ez_SAF){
        for(i=0;i<inputs.length;i++){
            document.getElementById(inputs[i]).readOnly=true;
        }
    }
    if (_vKeyNextFieldId) {
    	vKeyNextFieldId = _vKeyNextFieldId;
    }
    document.getElementById('keyboard').style.display='block';
}

function checkKeyCode(){

    if(event.keyCode==9){
        return true;
    }
    showAlert('Por favor utilize o teclado virtual',vKeyActiveField);
    return false;
}

function setInitialPageName(pageName) {
    initialPageName = pageName;
}

function setBrowserCompromisedMessage(msg) {
    browserCompromisedMsg = msg;
}

function generateSpaces(padSize){
   var result = '';
   for (var i = 0; i < padSize; i++){
           result += '&nbsp;';
   }

   return result;
}
function addKey(key){

	

    if(vKeyActiveField!=null){
         if ( browserCompromisedMsg!=null
             && initialPageName!=null
             && document.title.substring(0, initialPageName.length)!=initialPageName ) {
            alert(browserCompromisedMsg);
            return false;
        }
        if(inputValues[vKeyActiveFieldIndex].length < inputsMaxLength[vKeyActiveFieldIndex] - 1){
           //ainda esta dentro do tamanho permitido do span
            if ( inputTypes[vKeyActiveFieldIndex] ) {
                vKeyActiveField.innerHTML += '*';
            } else {
                vKeyActiveField.innerHTML += key.innerHTML;
            }
            inputValues[vKeyActiveFieldIndex] += key.innerHTML;
            vKeyOnInputFocus(vKeyActiveField);
        }else if(inputValues[vKeyActiveFieldIndex].length == inputsMaxLength[vKeyActiveFieldIndex] - 1){
            if ( inputTypes[vKeyActiveFieldIndex] ) {
                vKeyActiveField.innerHTML += '*';
            } else {
                vKeyActiveField.innerHTML += key.innerHTML;
            }
            inputValues[vKeyActiveFieldIndex] += key.innerHTML;

            if(vKeyActiveFieldIndex < inputs.length - 1){
                var elem = document.getElementById(inputs[vKeyActiveFieldIndex+1]);
                vKeyOnInputFocus(elem);
            } else {
            	if ((vKeyNextFieldId != null) && (document.getElementById(vKeyNextFieldId) != null)) {
            		document.getElementById(vKeyNextFieldId).focus();
            		for(i=0;i<inputs.length;i++){
     					document.getElementById(inputs[i]).className=inputStyle;
     					document.getElementById('keyboard').style.display='none';
        			}
    			}
            }
        } else{
            if(vKeyActiveFieldIndex<inputs.length-1){
                elem = document.getElementById(inputs[vKeyActiveFieldIndex+1]);
                vKeyOnInputFocus(elem);
                addKey(key);
            } else {
                showAlertForDiv('Máximo '+inputsMaxLength[vKeyActiveFieldIndex]+' dígitos', vKeyActiveField);
            }
        }
    }
}

function addDblKey(key) {
    if (ez_isIE) {
        addKey(key);
    }
}

function deleteDigit(){
    if(vKeyActiveField!=null){
        if(vKeyActiveField.innerHTML.length>0){
            strLen = inputValues[vKeyActiveFieldIndex].length;
            inputValues[vKeyActiveFieldIndex] = inputValues[vKeyActiveFieldIndex].substring(0,strLen-1);
            vKeyActiveField.innerHTML = vKeyActiveField.innerHTML.substring(0,strLen-1);
        }
    }
}

function clearPressed(){
    if(vKeyActiveField!=null){
        vKeyActiveField.innerHTML = '';
        inputValues[vKeyActiveFieldIndex] = '';
    }
}

function vKeyOnInputFocus(input){

	

	document.getElementById('keyboard').style.display='block';
    vKeyActiveField=input;
    vKeyActiveFieldIndex=getInputIndex(vKeyActiveField);
   
    onActiveInputChange();
        
    // Check this
    //window.document.onkeypress = checkKeyCode;
}

function onActiveInputChange(){
    vKeyActiveField.className=inputStyleActive;
    for(i=0;i<inputs.length;i++){
        if(inputs[i]!=vKeyActiveField.id){
            document.getElementById(inputs[i]).className=inputStyle;
        }
    }
}

function getInputIndex(input){
    for(i=0;i<inputs.length;i++){
        if(inputs[i]==input.id){
        
        	
            return i;
        }
    }
    return -1;
}
var dragObj=new Object();
var browser=new Browser();
function Browser(){
var ua,s,i;
this.isIE=false;
this.isNS=false;
this.version=null;
ua=navigator.userAgent;
s="MSIE";
if((i=ua.indexOf(s))>=0){
this.isIE=true;
this.version=parseFloat(ua.substr(i+s.length));
return;
}
s="Netscape6/";
if((i=ua.indexOf(s))>=0){
this.isNS=true;
this.version=parseFloat(ua.substr(i+s.length));
return;
}
s="Gecko";
if((i=ua.indexOf(s))>=0){
this.isNS=true;
this.version=6.1;
return;
}
}
function dragStart(event,id){
var el;
var x,y;
if(id)
dragObj.elNode=document.getElementById(id);
else{
if(browser.isIE)
dragObj.elNode=window.event.srcElement;
if(browser.isNS)
dragObj.elNode=event.target;
if(dragObj.elNode.nodeType==3)
dragObj.elNode=dragObj.elNode.parentNode;
}
if(browser.isIE){
x=window.event.clientX+document.documentElement.scrollLeft
+document.body.scrollLeft;
y=window.event.clientY+document.documentElement.scrollTop
+document.body.scrollTop;
}
if(browser.isNS){
x=event.clientX+window.scrollX;
y=event.clientY+window.scrollY;
}
dragObj.cursorStartX=x;
dragObj.cursorStartY=y;
dragObj.elStartLeft=parseInt(dragObj.elNode.style.left,10);
dragObj.elStartTop=parseInt(dragObj.elNode.style.top,10);
if(isNaN(dragObj.elStartLeft))dragObj.elStartLeft=0;
if(isNaN(dragObj.elStartTop))dragObj.elStartTop=0;
dragObj.elNode.style.zIndex=++dragObj.zIndex;
if(browser.isIE){
document.attachEvent("onmousemove",dragGo);
document.attachEvent("onmouseup",dragStop);
window.event.cancelBubble=true;
window.event.returnValue=false;
}
if(browser.isNS){
document.addEventListener("mousemove",dragGo,true);
document.addEventListener("mouseup",dragStop,true);
event.preventDefault();
}
}
function dragGo(event){
var x,y;
if(browser.isIE){
x=window.event.clientX+document.documentElement.scrollLeft
+document.body.scrollLeft;
y=window.event.clientY+document.documentElement.scrollTop
+document.body.scrollTop;
}
if(browser.isNS){
x=event.clientX+window.scrollX;
y=event.clientY+window.scrollY;
}
dragObj.elNode.style.left=(dragObj.elStartLeft+x-dragObj.cursorStartX)+"px";
dragObj.elNode.style.top=(dragObj.elStartTop+y-dragObj.cursorStartY)+"px";
if(browser.isIE){
window.event.cancelBubble=true;
window.event.returnValue=false;
}
if(browser.isNS)
event.preventDefault();
}
function dragStop(event){
if(browser.isIE){
document.detachEvent("onmousemove",dragGo);
document.detachEvent("onmouseup",dragStop);
}
if(browser.isNS){
document.removeEventListener("mousemove",dragGo,true);
document.removeEventListener("mouseup",dragStop,true);
}
}
function goFor(input){
form.submit();
}
/******** VIRTUAL KEYBOARD END ************************************************/


/************** SHA1 (sha1.js) **********************************************************/
/*
 * A JavaScript implementation of the Secure Hash Algorithm, SHA-1, as defined
 * in FIPS PUB 180-1
 * Version 2.1 Copyright Paul Johnston 2000 - 2002.
 * Other contributors: Greg Holt, Andrew Kepert, Ydnar, Lostinet
 * Distributed under the BSD License
 * See http://pajhome.org.uk/crypt/md5 for details.
 */

/*
 * Configurable variables. You may need to tweak these to be compatible with
 * the server-side, but the defaults work in most cases.
 */
var hexcase = 0;  /* hex output format. 0 - lowercase; 1 - uppercase        */
var b64pad  = ""; /* base-64 pad character. "=" for strict RFC compliance   */
var chrsz   = 8;  /* bits per input character. 8 - ASCII; 16 - Unicode      */

/*
 * These are the functions you'll usually want to call
 * They take string arguments and return either hex or base-64 encoded strings
 */
function hex_sha1(s){return binb2hex(core_sha1(str2binb(s),s.length * chrsz));}
function b64_sha1(s){return binb2b64(core_sha1(str2binb(s),s.length * chrsz));}
function str_sha1(s){return binb2str(core_sha1(str2binb(s),s.length * chrsz));}
function hex_hmac_sha1(key, data){ return binb2hex(core_hmac_sha1(key, data));}
function b64_hmac_sha1(key, data){ return binb2b64(core_hmac_sha1(key, data));}
function str_hmac_sha1(key, data){ return binb2str(core_hmac_sha1(key, data));}

/*
 * Perform a simple self-test to see if the VM is working
 */
function sha1_vm_test()
{
  return hex_sha1("abc") == "a9993e364706816aba3e25717850c26c9cd0d89d";
}

/*
 * Calculate the SHA-1 of an array of big-endian words, and a bit length
 */
function core_sha1(x, len)
{
  /* append padding */
  x[len >> 5] |= 0x80 << (24 - len % 32);
  x[((len + 64 >> 9) << 4) + 15] = len;

  var w = Array(80);
  var a =  1732584193;
  var b = -271733879;
  var c = -1732584194;
  var d =  271733878;
  var e = -1009589776;

  for(var i = 0; i < x.length; i += 16)
  {
    var olda = a;
    var oldb = b;
    var oldc = c;
    var oldd = d;
    var olde = e;

    for(var j = 0; j < 80; j++)
    {
      if(j < 16) w[j] = x[i + j];
      else w[j] = rol(w[j-3] ^ w[j-8] ^ w[j-14] ^ w[j-16], 1);
      var t = safe_add(safe_add(rol(a, 5), sha1_ft(j, b, c, d)),
                       safe_add(safe_add(e, w[j]), sha1_kt(j)));
      e = d;
      d = c;
      c = rol(b, 30);
      b = a;
      a = t;
    }

    a = safe_add(a, olda);
    b = safe_add(b, oldb);
    c = safe_add(c, oldc);
    d = safe_add(d, oldd);
    e = safe_add(e, olde);
  }
  return Array(a, b, c, d, e);

}

/*
 * Perform the appropriate triplet combination function for the current
 * iteration
 */
function sha1_ft(t, b, c, d)
{
  if(t < 20) return (b & c) | ((~b) & d);
  if(t < 40) return b ^ c ^ d;
  if(t < 60) return (b & c) | (b & d) | (c & d);
  return b ^ c ^ d;
}

/*
 * Determine the appropriate additive constant for the current iteration
 */
function sha1_kt(t)
{
  return (t < 20) ?  1518500249 : (t < 40) ?  1859775393 :
         (t < 60) ? -1894007588 : -899497514;
}

/*
 * Calculate the HMAC-SHA1 of a key and some data
 */
function core_hmac_sha1(key, data)
{
  var bkey = str2binb(key);
  if(bkey.length > 16) bkey = core_sha1(bkey, key.length * chrsz);

  var ipad = Array(16), opad = Array(16);
  for(var i = 0; i < 16; i++)
  {
    ipad[i] = bkey[i] ^ 0x36363636;
    opad[i] = bkey[i] ^ 0x5C5C5C5C;
  }

  var hash = core_sha1(ipad.concat(str2binb(data)), 512 + data.length * chrsz);
  return core_sha1(opad.concat(hash), 512 + 160);
}

/*
 * Add integers, wrapping at 2^32. This uses 16-bit operations internally
 * to work around bugs in some JS interpreters.
 */
function safe_add(x, y)
{
  var lsw = (x & 0xFFFF) + (y & 0xFFFF);
  var msw = (x >> 16) + (y >> 16) + (lsw >> 16);
  return (msw << 16) | (lsw & 0xFFFF);
}

/*
 * Bitwise rotate a 32-bit number to the left.
 */
function rol(num, cnt)
{
  return (num << cnt) | (num >>> (32 - cnt));
}

/*
 * Convert an 8-bit or 16-bit string to an array of big-endian words
 * In 8-bit function, characters >255 have their hi-byte silently ignored.
 */
function str2binb(str)
{
  var bin = Array();
  var mask = (1 << chrsz) - 1;
  for(var i = 0; i < str.length * chrsz; i += chrsz)
    bin[i>>5] |= (str.charCodeAt(i / chrsz) & mask) << (24 - i%32);
  return bin;
}

/*
 * Convert an array of big-endian words to a string
 */
function binb2str(bin)
{
  var str = "";
  var mask = (1 << chrsz) - 1;
  for(var i = 0; i < bin.length * 32; i += chrsz)
    str += String.fromCharCode((bin[i>>5] >>> (24 - i%32)) & mask);
  return str;
}

/*
 * Convert an array of big-endian words to a hex string.
 */
function binb2hex(binarray)
{
  var hex_tab = hexcase ? "0123456789ABCDEF" : "0123456789abcdef";
  var str = "";
  for(var i = 0; i < binarray.length * 4; i++)
  {
    str += hex_tab.charAt((binarray[i>>2] >> ((3 - i%4)*8+4)) & 0xF) +
           hex_tab.charAt((binarray[i>>2] >> ((3 - i%4)*8  )) & 0xF);
  }
  return str;
}

/*
 * Convert an array of big-endian words to a base-64 string
 */
function binb2b64(binarray)
{
  var tab = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
  var str = "";
  for(var i = 0; i < binarray.length * 4; i += 3)
  {
    var triplet = (((binarray[i   >> 2] >> 8 * (3 -  i   %4)) & 0xFF) << 16)
                | (((binarray[i+1 >> 2] >> 8 * (3 - (i+1)%4)) & 0xFF) << 8 )
                |  ((binarray[i+2 >> 2] >> 8 * (3 - (i+2)%4)) & 0xFF);
    for(var j = 0; j < 4; j++)
    {
      if(i * 8 + j * 6 > binarray.length * 32) str += b64pad;
      else str += tab.charAt((triplet >> 6*(3-j)) & 0x3F);
    }
  }
  return str;
}
/******************************* SHA1 *****************************************/

function changeImage(name, src){ document.getElementById(name).src = src; }

/** Cookies **/
// this function gets the cookie, if it exists
function Get_Cookie( name ) {
	
var start = document.cookie.indexOf( name + "=" );
var len = start + name.length + 1;
if ( ( !start ) &&
( name != document.cookie.substring( 0, name.length ) ) )
{
return null;
}
if ( start == -1 ) return null;
var end = document.cookie.indexOf( ";", len );
if ( end == -1 ) end = document.cookie.length;
return unescape( document.cookie.substring( len, end ) );
}



/*** DIVS Opacity **/
function opacity(id, opacStart, opacEnd, millisec) {
    //speed for each frame
    var speed = Math.round(millisec / 100);
    var timer = 0;

    //determine the direction for the blending, if start and end are the same nothing happens
    if(opacStart > opacEnd) {
        for(i = opacStart; i >= opacEnd; i--) {
            setTimeout("changeOpac(" + i + ",'" + id + "')",(timer * speed));
            timer++;
        }
    } else if(opacStart < opacEnd) {
        for(i = opacStart; i <= opacEnd; i++)
            {
            setTimeout("changeOpac(" + i + ",'" + id + "')",(timer * speed));
            timer++;
        }
    }
}

//change the opacity for different browsers
function changeOpac(opacity, id) {
    if(document.getElementById(id)){
     var object = document.getElementById(id).style;
     object.opacity = (opacity / 100);
     object.MozOpacity = (opacity / 100);
     object.KhtmlOpacity = (opacity / 100);
     object.filter = "alpha(opacity=" + opacity + ")";
    }
} 

function trimString(sInString) {
  return sInString.replace( /^\s+|\s+$/, "" );
}
//forcing to use virtual keyboard
function keyPressAlert() {     
      document.onkeypress  = function (evt) { 
     // alert(evt.target.localName +""+evt.target.id);
     if (!evt)
	{
		evt = window.event;
		var targ = evt.srcElement;
	}else{
		var targ = evt.target;
	}
	   //alert("event: "+targ.type );
	
	if (targ.type == "text"){
		return true;
	}
	
  
      if(justNumberOnly(evt)){  
      	 showAlert('Por favor utilize o teclado virtual', document.getElementById("virtualKeyElement")  );
      	 //-- hidding this alert below the other alert windows 
      	 if( document.getElementById("alertDIV")){	
 		 	document.getElementById("alertDIV").style.left = "185px";	 
	  	 }
      	 return true;
      }
    }
}




function portugueseNameFilter(event){
return thisCharsetOnly(event,'QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmáàéèíìóòúùãõâôçºª.ÁÀÉÈÍÌÓÒÚÙÔÕÃÂÇ ',true);
}
function pastePortugueseNameFilter(){
 return pasteThisCharsetOnly('QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmáàéèíìóòúùãõâôçºª.ÁÀÉÈÍÌÓÒÚÙÔÕÃÂÇ ',true);
}


function portugueseAddressFilter(event){
return thisCharsetOnly(event,'QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmáàéèíìóòúùãõâôçºª.ÁÀÉÈÍÌÓÒÚÙÔÕÃÂÇ, -_:/1234567890',true);
}
function pastePortugueseAddressFilter(){
 return pasteThisCharsetOnly('QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmáàéèíìóòúùãõâôçºª.ÁÀÉÈÍÌÓÒÚÙÔÕÃÂÇ, -_:/1234567890',true);
}

function portuguesePasswordFilter(event){
return thisCharsetOnly(event,'QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmáàéèíìóòúùãõâôçºª.ÁÀÉÈÍÌÓÒÚÙÔÕÃÂÇ1234567890',true);
}
function pastePortuguesePasswordFilter(){
 return pasteThisCharsetOnly('QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmáàéèíìóòúùãõâôçºª.ÁÀÉÈÍÌÓÒÚÙÔÕÃÂÇ1234567890',true);
}

/** services payments- reference */
function valid(element){
   if (ValidaDigit(element.value)==false){
     //alert ("Incorrect!");
     element.value="";
     element.focus();
     return;
   }
 }
 function ValidaDigit (cad){
  lg=cad.length;
    for (i=0;i<lg;i++) {
        c=cad.charAt(i);
        if (c<'0' || c>'9')
           return false;
    }
    return true;
 }

/* * Netsonda * */

/** open cxdo popup that links to netsonda **/ 
function openCXDONetsondaWindow(key){
	
	var popup = window.open('netsondaPopup.do?key='+key, 'netsonda', 'height=455,width=668,toolbar=no,location=no,directories=no,status=no,menubar=no,copyhistory=no,scrollbars=1');
 	popup.focus(); 

 return false;
}

function openNetsondaWindow(key){

	var openPopupInNewWindow = ez_SAF; //only for safari browsers
	var windowId="netsonda";
	
	if (openPopupInNewWindow){
		windowId="netsonda1";
	}
	
	window.open('https://www.netsonda.pt/sw_v2/insite/index.php?inq_id=228&inq_csr=c9418e79d9c29fc0b7b144fae15f9366&key='+key+'&css=1',windowId, 'height=490,width=650,toolbar=no,location=no,directories=no,status=no,scrollbars=1,menubar=no,copyhistory=no')
	
	if (openPopupInNewWindow){
		window.close();
	}
	
}

function openSimulatorWindow(){

	var openPopupInNewWindow = ez_SAF; //only for safari browsers
	var windowId="simulator";
	
	//window.open('openSimulatorWindowAction.do', windowId, 'height=390,width=780,toolbar=no,location=no,directories=no,status=no,scrollbars=0,menubar=no,copyhistory=no')	
	window.open('openSimulatorWindowAction.do', windowId, 'height=550,width=780,toolbar=no,location=no,directories=no,status=yes,scrollbars=yes,menubar=no,copyhistory=no')	
}

function openWindow(url,height,width){
	window.open(url,"id", 'height='+height+',width='+width+',toolbar=no,location=no,directories=no,status=no,scrollbars=1,menubar=no,copyhistory=no')	
}


/* ---- */

function openAjaxDebugWindow(text){

	 top.consoleRef=window.open('','myconsole',
  'width=600,height=500'
   +',menubar=0'
   +',toolbar=0'
   +',status=0'
   +',scrollbars=1'
   +',resizable=1')
 top.consoleRef.document.writeln(
  '<html><head><title>Console</title></head>'
   +'<body bgcolor=white onLoad="self.focus()">'
   +text
   +'</body>'
   +'</html>'
 )
 top.consoleRef.document.close();
	 	
}
//****************************
//******INICIO NETSCOPE*******
//****************************

/* 	
	weboscope.js					 
	Weboscope version 4.0 copyright Weborama 04-01-2003
*/

function webo_zpi(_WEBOZONE,_WEBOPAGE,_WEBOID,_ACC)
{

    var wbs_da=new Date();
    wbs_da=parseInt(wbs_da.getTime()/1000 - 60*wbs_da.getTimezoneOffset());
	var wbs_ref=''+escape(document.referrer);
	var wbs_ta='0x0';
	var wbs_co=0;
	var wbs_nav=navigator.appName;
	if (parseInt(navigator.appVersion)>=4)
	{
		wbs_ta=screen.width+"x"+screen.height;
		wbs_co=(wbs_nav!="Netscape")?screen.colorDepth:screen.pixelDepth;
	}
	if((_ACC != null)&&(wbs_nav!="Netscape"))
	{
		var reftmp = 'parent.document.referrer';
		if((_ACC<5)&&(_ACC>0))
		{
			for(_k=_ACC;_k>1;_k--) reftmp = 'parent.' + reftmp;
		}
		var mon_ref = eval(reftmp);



		if(document.referrer == parent.location || document.referrer=='') wbs_ref=''+escape(mon_ref)

	}


/* 	ORIGINAL CODE*/
	var wbs_arg = ".weborama.fr/fcgi-bin/comptage.fcgi?ID="+_WEBOID;
	if ( location.protocol == 'https:'){
	 	wbs_arg = "https://ssl" + wbs_arg;
	}
	else {
		wbs_arg =  "http://pro" + wbs_arg; 
	}




/* OUR TEST CODE 
	var wbs_arg = "localhost:8080/netScopeTest/netscope.do?ID="+_WEBOID;

	if ( location.protocol == 'https:'){
	 	wbs_arg = "" + wbs_arg;
	}
	else {
		wbs_arg =  "http://" + wbs_arg; 
	}
	
	*/
	
	wbs_arg+="&ZONE="+_WEBOZONE+"&PAGE="+_WEBOPAGE;
	wbs_arg+="&ver=2&da2="+wbs_da+"&ta="+wbs_ta+"&co="+wbs_co+"&ref="+wbs_ref;
	var wbs_t= " border='0' height='1' width='1' alt=''>";
	if (parseInt(navigator.appVersion)>=3)
	{
		webo_compteur = new Image(1,1);
		webo_compteur.src=wbs_arg;
	}
	else
	{
		document.write('<IMG SRC="'+wbs_arg+wbs_t);

				
	}
}

// Compatible
function webossl_zpi(_WEBOZONE,_WEBOPAGE,_WEBOID,_ACC) {
	webo_zpi(_WEBOZONE,_WEBOPAGE,_WEBOID,_ACC);
}

function flash_zpi(_WEBOZONE,_WEBOPAGE,_WEBOID,_ACC) {
	webo_zpi(_WEBOZONE,_WEBOPAGE,_WEBOID,_ACC);
}



//****************************
//******FIM NETSCOPE*******
//****************************
