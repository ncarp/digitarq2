<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ODDisplay.aspx.vb" Inherits="WebSearch2.ODDisplay" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Visualização do Objecto Digital</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Styles1.css" type="text/css" rel="stylesheet">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<SCRIPT src="JScripts/images.js" type="text/javascript"></SCRIPT>
		<SCRIPT src="JScripts/prototype.js" type="text/javascript"></SCRIPT>
		<script type="text/javascript" language="javascript">
		<!--
			function confirmShoutDelete(url, message) {
				if (confirm(message)) {
				self.location=url;
				}
			}

		var userImageTimer;
		var mouseX, mouseY;

		document.onmousemove = function(event) {
			var event = event || window.event;
			mouseX = event.clientX;
			mouseY = event.clientY;
		}

		function latentShowFriendInfo(imageURL) {
			//new Ajax.Updater("friend_info", imageURL);
			var scrollTop = window.pageYOffset ? window.pageYOffset : (document.documentElement ? document.documentElement.scrollTop : document.body.scrollTop);
			$("friend_info").style.visibility = "visible";
			$("friend_info").style.left = mouseX + 20 + "px";
			$("friend_info").style.top = mouseY + scrollTop + 20 + "px";
			$("friend_info").innerHTML = "<img src='" + imageURL + "' style='position: absolute; width:100px; height:auto;' border='0'>";
		}

		function showFriendInfo(event,imageURL) {
			document.getElementById("friend_info").innerHTML = "A carregar imagem...";
			clearTimeout(userImageTimer);		
			userImageTimer = setTimeout("latentShowFriendInfo('" + imageURL + "')", 500);	
			//var scrollTop = window.pageYOffset ? window.pageYOffset : (document.documentElement ? document.documentElement.scrollTop : document.body.scrollTop);
			//$("friend_info").style.visibility = "visible";
			//$("friend_info").style.left = mouseX + 20 + "px";
			//$("friend_info").style.top = mouseY + scrollTop + 20 + "px";
			//$("friend_info").innerHTML = "<img id='img' src='" + imageURL + "' style='position:absolute; width:auto; height:auto;' border='0'>";
			//$("friend_info").height = document.getElementById("img").height;
			
		}

		function hideFriendInfo(event) {
			clearTimeout(userImageTimer);
			document.getElementById("friend_info").style.visibility = "hidden";
		}
		-->
		</script>
		<script language="JavaScript" type="text/javascript">
		<!--
			var ClickMessage="Opção não disponível!"; 
			function clickIE4(){ 
				if (event.button==2){ 
					alert(ClickMessage); 
					return false; 
				} 
			} 
			function clickNS4(e){ 
				if (document.layers||document.getElementById&&!document.all){ 
					if (e.which==2||e.which==3){ 
						alert(ClickMessage); 
						return false; 
					} 
				} 
			} 
			if (document.layers){ 
				document.captureEvents(Event.MOUSEDOWN); 
				document.onmousedown=clickNS4; 
			} 
			else if (document.all&&!document.getElementById){ 
				document.onmousedown=clickIE4; 
			} 
			document.oncontextmenu=new Function("alert(ClickMessage);return false")
		-->
		</script>
	</HEAD>
	<body background="Images/tabpage_bkgrd3.jpg"  scroll="yes">
		<div id="friend_info" style="CLEAR:both; BORDER-RIGHT:gray 1px solid; BORDER-TOP:gray 1px solid; BACKGROUND:#eeeeee; VISIBILITY:hidden; BORDER-LEFT:gray 1px solid; BORDER-BOTTOM:gray 1px solid; POSITION:absolute"></div>
		<form id="Form1" method="post" runat="server">
			<table>
				<tr height="10">
					<td></td>
				</tr>
			</table>
			<table class="tblODDisplay" cellPadding="0" align="center" bgColor="#ffffff">
				<tr>
					<td>
						<table height="700" width="1080" border="0">
							<tr vAlign="top">
								<td width="230" height="700">
									<table height="700" cellSpacing="0" cellPadding="0" width="230" border="0">
										<tr vAlign="top" height="500">
											<td>
												<div style="OVERFLOW-Y: auto; OVERFLOW-X: auto; WIDTH: 230px; HEIGHT: 500px"><iewc:treeview class="tree" id="tvDOImages" runat="server" AutoPostBack="True" ExpandedImageUrl="Images/Open Folder_ico_2.ico"
														ImageUrl="Images/Closed Folder_ico_1.ico" SelectExpands="True" AutoSelect="True"></iewc:treeview><INPUT id="hihHeight" type="hidden" name="hidNodeID" runat="server">
												</div>
											</td>
										</tr>
										<tr vAlign="middle" height="200">
											<td><asp:panel id="pnlMetadata" Visible="false" Runat="server"><SPAN class="metaImage">Metainformação 
														da imagem matriz:</SPAN>
													<BR>
													<BR>
													<TABLE class="metaImage" id="tblMeta" cellSpacing="1" cellPadding="1" align="left" border="0">
														<TR>
															<TD>Esquema de Cor:
															</TD>
															<TD width="10"></TD>
															<TD>
																<asp:label id="lblColor" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD>
															Resolução Espacial:
															<TD width="10"></TD>
															<TD>
																<asp:label id="lblResolution" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD>Profundidade Bits:
															</TD>
															<TD width="10"></TD>
															<TD>
																<asp:label id="lblBitDepth" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD>Largura:
															</TD>
															<TD width="10"></TD>
															<TD>
																<asp:label id="lblWidth" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD>Altura:
															</TD>
															<TD width="10"></TD>
															<TD>
																<asp:label id="lblHeight" Runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD>Tamanho:
															</TD>
															<TD width="10"></TD>
															<TD>
																<asp:label id="lblSize" Runat="server"></asp:label></TD>
														</TR>
													</TABLE>
												</asp:panel></td>
										</tr>
									</table>
								</td>
								<td width="750" height="700">
									<table cellSpacing="0" cellPadding="0" width="750" height=700 border="0">
										<tr height="35">
											<td vAlign="middle">
												<div class="tblODButtons">
													<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
														<tr>
															<td align="right" width="30%"><asp:imagebutton id="rotateLeft" Runat="server" Imageurl="Images/rotateLeft.PNG" AlternateText="Rodar esquerda"
																	cssclass="btnDO"></asp:imagebutton><asp:imagebutton id="rotateRight" Runat="server" Imageurl="Images/rotateRight.PNG" AlternateText="Rodar direita"
																	cssclass="btnDO"></asp:imagebutton></td>
															<td align="center" width="40%"><A class="btnDO" href="JavaScript:zoomOut();"><IMG class="buttonNavigation" alt="Aumentar imagem" src="Images/zoomOut.PNG" border="0"></A>
																<A class="btnDO" href="JavaScript:zoomDefault();"><IMG class="buttonNavigation" alt="Imagem a 100%" src="Images/umPorUm.PNG" border="0"></A>
																<A class="btnDO" href="JavaScript:zoomIn();"><IMG class="buttonNavigation" alt="Diminuir imagem" src="Images/zoomIn.PNG" border="0"></A>
															</td>
															<td align="left" width="30%"><asp:imagebutton id="ibtPrevious" runat="server" ImageUrl="Images/previous.PNG" Visible="False" cssclass="btnDO"></asp:imagebutton><asp:imagebutton id="ibtNext" ImageUrl="Images/next.PNG" Visible="False" Runat="server" cssclass="btnDO"></asp:imagebutton></td>
															<td><A href='<%= "javascript:janelaPopUp(""ImageFullScreen.aspx?DOId=" & Me.Request.QueryString("DOId") & "&FileID=" + Me.tvDOImages.GetNodeFromIndex(index).ID.trimstart("_") & """,""800"",""500"",""no"");"%>'><img src=Images/fullscreen.PNG border=0></A></td>
														</tr>
													</table>
												</div>
												<input id="Hidden2" type="hidden" name="hihHeight" runat="server">
											</td>
										</tr>
										<tr><td height=5px></td></tr>
										<tr valign=top>
											<td vAlign="top" width="750" height=660px>
												<div style="OVERFLOW-Y: auto; OVERFLOW-X: auto; WIDTH: 750px; height=660px">
													<DIV id="divImage" align=center ondblclick='<%= "javascript:janelaPopUp(""ImageFullScreen.aspx?DOId=" & Me.Request.QueryString("DOId") & "&FileID=" + Me.tvDOImages.GetNodeFromIndex(index).ID.trimstart("_") & ""","""","""",""no"");"%>'><asp:image id="imgDO" runat="server" Visible="False" ImageAlign=Top></asp:image></DIV>
												</div>
											</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle">
									<table align="center" cellpadding=0 cellspacing=5 border=0>
										<tr>
											<td align="center"><asp:imagebutton id="imgPrevious" Visible="false" Runat="server" CssClass="SmallImage"></asp:imagebutton></td>
										</tr>
										<tr>
											<td align="center" class="BorderRedImage"><asp:image id="imgCurrent" Visible="false" Runat="server" Width="100px"></asp:image></td>
										</tr>
										<tr>
											<td align="center"><asp:imagebutton id="imgNext" Visible="false" Runat="server" Width="100px" CssClass="SmallImage"></asp:imagebutton></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
