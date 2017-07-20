<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ImageFullScreen.aspx.vb" Inherits="WebSearch2.ImageFullScreen" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Visualização da imagem</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0" align=center>
				<tr>
					<td vAlign="top" align="center">
						<div style="OVERFLOW-Y: auto; OVERFLOW-X: auto">
							<DIV id="divImage" align="center" ondblclick="javascript:window.close();"><asp:image id="img" runat="server" Visible="true" ImageAlign="Middle"></asp:image></DIV>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
