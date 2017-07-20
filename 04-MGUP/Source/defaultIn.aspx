<%@ Register TagPrefix="uc1" TagName="headerBO" Src="Controls/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footerBO" Src="Controls/footer.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="defaultIn.aspx.vb" Inherits="GPU.defaultIn" %>
<%@ Register TagPrefix="uc1" TagName="menuLeft" Src="Controls/menuLeft.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>
			<%=ConfigurationSettings.AppSettings("HEAD.Title")%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="Styles/BStyle.css" type="text/css" rel="stylesheet">
		<LINK href="Styles/menu.css" type="text/css" rel="stylesheet">
		<SCRIPT src="JScripts/menu.js" type="text/javascript"></SCRIPT>
		<SCRIPT src="JScripts/print.js" type="text/javascript"></SCRIPT>
		<SCRIPT src="JScripts/utils.js" type="text/javascript"></SCRIPT>
		<SCRIPT src="JScripts/ontology.js" type="text/javascript"></SCRIPT>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="550" cellSpacing="0" cellPadding="0" width="990" align="center" border="0">
				<tr>
					<td colSpan="3" height="7"></td>
				</tr>
				<tr>
					<td vAlign="top" colSpan="3" height="78">
						<!--HEADER-->
						<uc1:headerBO id="HeaderBO1" runat="server"></uc1:headerBO>
						<!--HEADER--></td>
				</tr>
				<tr>
					<td colSpan="3" height="7"></td>
				</tr>
				<tr>
					<td class="tblMain" vAlign="top" width="220" height="80%">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="bgCenterSpc"></TD>
											<TD class="bgCenter"><SPAN><%=GetLabel("lblTitleMenuLeftB.Title")%></SPAN></TD>
											<TD class="bgCenterSpc"></TD>
										</TR>
									</table>
								</td>
							</TR>
							<tr>
								<td colSpan="3" height="20">
							</tr>
							<tr align="center">
								<td colSpan="3">
									<!--MENUFEFT-->
									<uc1:menuLeft id="MenuLeft1" runat="server"></uc1:menuLeft>
									<!--MENULEFT-->
								</td>
							</tr>
							<tr>
								<td colSpan="3" height="20"></td>
							</tr>
						</TABLE>
					</td>
					<td width="7"></td>
					<td class="tblMain" vAlign="top" width="770">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="bgCenterSpc"></TD>
											<TD class="bgCenter"><SPAN id="LblTitle"><asp:Label Runat="server" ID="lblTitleBody"></asp:Label></SPAN></TD>
											<TD class="bgCenterSpc"></TD>
										</TR>
									</table>
								</td>
							</TR>
							<TR>
								<td>
									<!--BODY-->
									<asp:panel id="pnlBody" Visible="True" Runat="server"></asp:panel>
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
						<uc1:footerBO id="FooterBO1" runat="server"></uc1:footerBO>
						<!--FOOTER-->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
