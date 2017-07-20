<%@ Import Namespace ="GPU.mShowItems" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="statsIS.ascx.vb" Inherits="GPU.statsIS" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="630" align="center" border="0">
	<tbody>
		<tr>
			<td class="vertical_spacer2"></td>
		</tr>
		<tr>
			<td>
				<asp:Literal Runat="server" ID="ltlHorizontalMenu" Visible="True"></asp:Literal>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer3"></td>
		</tr>
		<tr>
			<td>
				<asp:Panel Runat="server" ID="pnlStats"></asp:Panel>
			</td>
		</tr>
	</tbody>
</table>
