<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ShowFile.aspx.vb" Inherits="WebSearch2.ShowFile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>showImage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT src="JScripts/images.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<img src='<%= myImageURL %>' width=100% style="position: absolute;" border="0">
		</form>
	</body>
</HTML>
