<%@ Import Namespace ="GPU.mShowItems" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="profilesMenu1.ascx.vb" Inherits="GPU.profilesMenu1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="550" align="left" border="0">
	<tbody>
		<tr>
			<td vAlign="top" width="180">
				<table width="100%" cellpadding="0" cellspacing="0">
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="txtB"><%=GetLabel("profilesMenu1.lblAplications")%></td>
					</tr>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<tr>
						<td class="txt">
							<asp:RadioButtonList id="rblAplications" CssClass="txt" Width="100%" Runat="server" AutoPostBack="True"></asp:RadioButtonList>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="txtB"><%=GetLabel("profilesMenu1.lblProfiles")%></td>
					</tr>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<tr>
						<td>
							<asp:RadioButtonList id="rblProfiles" CssClass="txt" Width="100%" Runat="server" AutoPostBack="True"></asp:RadioButtonList>
						</td>
					</tr>
				</table>
			</td>
			<td width="20"></td>
			<td width="350" align="left" valign="top">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="line"></TD>
					</TR>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<TR>
						<TD class="txtB"><%=GetLabel("profilesMenu1.lblFunctions")%></TD>
					</TR>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<TR>
						<TD align="left"><asp:Literal Runat="server" ID="ltlAllProfileFunctions" Visible="True"></asp:Literal></TD>
					</TR>
					<TR>
						<TD class="vertical_spacer2"></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Panel Runat="server" ID="pnlFunctions" Width="100%">
								<asp:linkbutton id="lnkbSave" Runat="server" CssClass="Button_1L" Height="20px" CausesValidation="True"></asp:linkbutton>
							</asp:Panel>
						</TD>
					</TR>
				</TABLE>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer3"></td>
		</tr>
	</tbody>
</table>
