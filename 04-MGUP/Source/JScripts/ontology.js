//*************************************************
//* Functions used by ontology.jsp and keywordsearch.jsp
//*************************************************

function expandCollapse(node) {
	node = node.parentNode;
	var childNode  = (node.getElementsByTagName("ul"))[0];

	if(!childNode) return false;

	//var image = node.getElementsByTagName("img")[0];
	var checkbox = node.getElementsByTagName("input")[0];
	
	if(childNode.style.display != "block") {
		childNode.style.display  = "block";
		//image.src = "../Images/m.gif";
		checkbox.checked = true;
	} else {
		childNode.style.display  = "none";
		//image.src = "../Images/p.gif";
		checkbox.checked = false;
	}
	
	return false;
}


function getAnchorText(ahref) {
 	if(isMicrosoft()) return ahref.childNodes.item(0).nodeValue;
	else return ahref.text;
}

function getTextValue(node) {
 	if(node.nodeName == "A") {
 		return getAnchorText(node);
 	} else {
 		return "";
 	}
 	
}


function getParentTextNode(node) {
	var parentNode = node.parentNode.parentNode.parentNode;
	var children = parentNode.childNodes;
	var textNode;
	for(var i=0; i< children.length; i++) {
		var child = children.item(i);
		if(child.className == "value") {
			return child;
		}
	}
	return null;
}

function ec(node) {
	expandCollapse(node);
	return false;
}


function getCode(node) {
	node = node.parentNode;
	var childNode  = (node.getElementsByTagName("ul"))[0];

	if(!childNode) return false;

	//var image = node.getElementsByTagName("img")[0];
	var image = node.getElementsByTagName("image")[0];

	var txb = getElementsByID("txbFunctionCode");
	
	txb.value=image.value;
}

/*
function sp(node) {
	var parentNode = node.parentNode.parentNode.parentNode;
	var children = parentNode.childNodes;
	var textNode;
	for(var i=0; i< children.length; i++) {
		var child = children.item(i);
		if(child.className == "ontology") {
			child.checked=true;
		}
	}
	return null;
}
*/

function i(node) {
	//alert(node.nodeName);
	return sendBackToParentWindow(node);
}


//*************************************************
//* 
//*************************************************



function getChildrenByTagName(rootNode, tagName) {
	var children = rootNode.childNodes;
	var result = new Array(0);
	if(children == null) return result;
	for(var i=0; i<children.length; i++) {
		if(children[i].tagName == tagName) {
			var elementArray = new Array(1);
			elementArray[0] = children[i];
			result = result.concat(elementArray);
		}
	}
	return result;
}

function popUp(URL) {
	var page;
	page = window.open(URL, 'ontology', 'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=650,height=450');
}


function isNetscape(v) {
		  return isBrowser("Netscape", v);
}
	
function isMicrosoft(v) {
		  return isBrowser("Microsoft", v);
}

function isMicrosoft() {
		  return isBrowser("Microsoft", 0);
}


function isBrowser(b,v) {
		  browserOk = false;
		  versionOk = false;

		  browserOk = (navigator.appName.indexOf(b) != -1);
		  if (v == 0) versionOk = true;
		  else  versionOk = (v <= parseInt(navigator.appVersion));
		  return browserOk && versionOk;
}

