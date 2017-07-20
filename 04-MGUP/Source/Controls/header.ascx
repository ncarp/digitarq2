<%@ Control Language="vb" AutoEventWireup="false" Codebehind="header.ascx.vb" Inherits="GPU.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td colspan="3">
			<div id="Geral">
				<div id="logo_ADP"><a href='<%=ConfigurationSettings.AppSettings("Institution.URL")%>' target=_blank><IMG height="112" alt='<%=ConfigurationSettings.AppSettings("Institution.Name")%>' src="Images/logotipo_adp.png" width="110" border=0></a></div>
				<div id="InstitutionName"><%=ConfigurationSettings.AppSettings("Institution.Name")%></div>
			</div>
		</td>
	</tr>
	<tr>
		<td colSpan="3" height="3"></td>
	</tr>
	<tr>
		<td class="tblHeadL" width="15">&nbsp;</td>
		<td>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="tblHeadC" height="25" width="390"><asp:Label Runat="server" ID="lblMsg" CssClass="txtBMsg"></asp:Label>&nbsp;<asp:Label Runat="server" ID="lblUserName" CssClass="txtMsg"></asp:Label></td>
					<td class="tblHeadC" align="right"><asp:HyperLink Runat="server" ID="hlnkInitialPage" CssClass="generalLink"></asp:HyperLink><asp:Label Runat="server" ID="lblSeparator" Visible="False"> | </asp:Label>
						<asp:HyperLink Runat="server" ID="hlnkClose" CssClass="generalLink"></asp:HyperLink></td>
				</tr>
			</table>
		</td>
		<td class="tblHeadR" width="15">&nbsp;</td>
	</tr>
</table>
