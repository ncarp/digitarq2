// JavaScript Document
function popupWindow(sURL, iWidth, iHeight)
{
	var xPos = (screen.availWidth - iWidth) / 2;
	var yPos = (screen.availHeight - iHeight) / 2;
	var isIE = (navigator.userAgent.toLowerCase().indexOf('msie') != -1);
	var sFeatures = ',height=' + iHeight + ',width=' + iWidth + ',status=yes,resizable=yes,toolbar=no,menubar=no,location=no,scrollbars=yes';
	if(isIE) {
		sFeatures = 'top=' + yPos + ',left=' + xPos + sFeatures;
	} else {
		sFeatures = 'screenY=' + yPos + ',screenX=' + xPos + sFeatures;
	}
	window.open(sURL, 'UMIntranetPortal', sFeatures);
}

function popupWindowBlank(sURL, iWidth, iHeight)
{
	var xPos = (screen.availWidth - iWidth) / 2;
	var yPos = (screen.availHeight - iHeight) / 2;
	var isIE = (navigator.userAgent.toLowerCase().indexOf('msie') != -1);
	var sFeatures = ',height=' + iHeight + ',width=' + iWidth + ',status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes';
	if(isIE) {
		sFeatures = 'top=' + yPos + ',left=' + xPos + sFeatures;
	} else {
		sFeatures = 'screenY=' + yPos + ',screenX=' + xPos + sFeatures;
	}
	window.open(sURL, '_blank', sFeatures);
}

