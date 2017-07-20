<%@ Register TagPrefix="uc1" TagName="language" Src="language.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="header.ascx.vb" Inherits="WebSearch2.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td class="bgHeadL" width="15">&nbsp;</td>
		<td vAlign="middle" height="50" class="bgHeadC">
			<img src="Images/adp.png">&nbsp;
		</td>
		<td class="bgHeadC" vAlign="middle" align="right"><uc1:language id="Language1" runat="server"></uc1:language></td>
		<td class="bgHeadR" width="15">&nbsp;</td>
	</tr>
	<tr>
		<td colSpan="4" height="3"></td>
	</tr>
	<tr>
		<td class="tblHeadL" width="15">&nbsp;</td>
		<td colSpan="2">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="tblHeadC" height="25" width="390"><asp:Label Runat="server" ID="lblMsg" CssClass="txtBMsg"></asp:Label>&nbsp;<asp:Label Runat="server" ID="lblUserName" CssClass="txtMsg"></asp:Label></td>
					<td class="tblHeadC" align="right"><asp:HyperLink Runat="server" ID="hlnkInitialPage" CssClass="TopMenuNavigation">Início</asp:HyperLink>
						|
						<asp:HyperLink Runat="server" ID="hlnkClose" CssClass="TopMenuNavigation">Sair</asp:HyperLink></td>
				</tr>
			</table>
		</td>
		<td class="tblHeadR" width="15">&nbsp;</td>
	</tr>
</table>
