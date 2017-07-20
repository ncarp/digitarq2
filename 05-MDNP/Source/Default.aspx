<%@ Register TagPrefix="uc2" TagName="menuLeft" Src="OtherControls/menuLeft.ascx" %>
<%@ Register TagPrefix="uc2" TagName="footer" Src="OtherControls/footer.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="WebSearch2.WSDefault" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>
			<asp:Literal Runat="server" ID="ltlTitle"></asp:Literal></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="Styles/Styles.css" type="text/css" rel="stylesheet">
		<LINK href="Styles/menu.css" type="text/css" rel="stylesheet">
		<SCRIPT src="JScripts/utils.js" type="text/javascript"></SCRIPT>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="550" cellSpacing="0" cellPadding="0" width="770" align="left" border="0">
				<tr>
					<td colSpan="3" height="7"></td>
				</tr>
				<tr>
					<td vAlign="top" width="770">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<TD width="10"></TD>
											<TD class="bgCenter"><SPAN id="LblTitle"><asp:Label Runat="server" ID="lblTitleBody"></asp:Label></SPAN></TD>
											<TD width="10"></TD>
										</tr>
										<tr>
											<TD width="10"></TD>
											<TD class="line"></TD>
											<TD width="10"></TD>
										</tr>
									</table>
								</td>
							</TR>
							<TR>
								<td>
									<!--BODY-->
									<asp:panel id="pnlBody" Runat="server" Visible="True"></asp:panel>
									<!--BODY-->
								</td>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colSpan="3" height="7"></td>
				</tr>
				<tr>
					<td colSpan="3">
						<!--FOOTER-->
						<uc2:footer id="Footer1" runat="server"></uc2:footer>
						<!--FOOTER-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
