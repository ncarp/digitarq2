 /*Global variables*/
 goToWin=null;

 /** Function**/
 function Enter()
 {
 if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13))
    {document.forms["Form1"].btnSearch.Click();return false;} 
    else return true;
 }
 function goToUrl(oSelect)
{
	

	
	var opt = oSelect.options[oSelect.selectedIndex], ID = opt.value;
	if (ID!='0'){
	var urlfinal='ChildWebForm.aspx?textbox=txtControlAccessItems&ID='+ID+'&Hidden=ItemID' ; 

		var popwidth = 300 ; //adjust
		var popheight = 225 ; //adjust
		var  popleft=(screen.width-popwidth)/2;
		var poptop=(screen.height-popheight)/2;
		var features = /*' menubar,location,status,*/',scrollbars=yes'; //adjust
		var w = 'width=' + popwidth + 'px ,';
		var h = 'height=' + popheight + 'px ,';
		var l = 'left=' + popleft + ',';
		var t = 'top=' + poptop;
		
	 goToWin =window.open(urlfinal,'goToWin',w+h+l+t+features);
		if (goToWin && !goToWin.closed)
			goToWin.focus();
	} else document.getElementById("txtControlAccessItems").value="";
return false;
}


function Non(){
if(goToWin && goToWin.open && !goToWin.closed){goToWin.close();goToWin=null;}
else goToWin=null;
}
 