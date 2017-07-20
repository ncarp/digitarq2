<%@ Control Language="vb" AutoEventWireup="false" Codebehind="authorityRecord.ascx.vb" Inherits="WebSearch2.authorityRecord" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table width="700" cellpadding="0" cellspacing="0" align="center" border="0">
	<TBODY>
		<TR>
			<td class="vertical_spacer3"></td>
		</TR>
		<tr>
			<td>
				<table width="100%" cellpadding="0" cellspacing="0" border="0">
					<tr>
						<td align="right">
							<a href="javascript:PrintThisPage();"><img src="Images/printWB.gif" alt='<%=getlabel("WS.authorityRecord.altPrint")%>'></a>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="line"></td>
		</tr>
		<tr>
			<td class="vertical_spacer3"></td>
		</tr>
		<tr>
			<td>
				<DIV id="contentstart">
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<td align="center" class="Title07"><%=getlabel("WS.authorityRecord")%></font>
							</td>
						</TR>
						<TR>
							<td class="vertical_spacer3"></td>
						</TR>
						<tr>
							<TD><asp:label id="lblContent" runat="server"></asp:label></TD>
						</tr>
					</TABLE>
				</DIV>
			</td>
		</tr>
		<tr>
			<td class="vertival_spacer3"></td>
		</tr>
		<tr>
			<td align="center">
				<asp:HyperLink id="hlnkBackFooter" Runat="server" CssClass="Button_1" Height="20px" Visible="True"></asp:HyperLink>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer3"></td>
		</tr>
	</TBODY>
</table>
