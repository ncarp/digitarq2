<%@ Import Namespace ="GPU.mShowItems" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="aplications.ascx.vb" Inherits="GPU.aplications" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="550" align="center" border="0">
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
				<asp:Panel Runat="server" ID="pnlAplications"></asp:Panel>
			</td>
		</tr>
	</tbody>
</table>
