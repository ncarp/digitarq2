<%@ Control Language="vb" AutoEventWireup="false" Codebehind="aplicationsMenu1.ascx.vb" Inherits="GPU.aplicationsMenu1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="550" align="center" border="0">
	<tbody>
		<tr>
			<td vAlign="top" width="130">
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
				</table>
			</td>
			<td width="20"></td>
			<td width="400" align="left" valign="top">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
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
							<TD align="left"><asp:Literal Runat="server" ID="ltlAplFunctions" Visible="True"></asp:Literal></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer2"></TD>
						</TR>
						<TR>
							<TD class="line"></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer1"></TD>
						</TR>
						<TR>
							<TD align="left">
								<asp:linkbutton id="lnkbNewFunction" Runat="server" CssClass="Button_1L" CausesValidation="True"
									Height="20px"></asp:linkbutton><asp:linkbutton id="lnkbDeleteFunction" Runat="server" CssClass="Button_1L" CausesValidation="True"
									Height="20px"></asp:linkbutton>
							</TD>
						</TR>
						<TR>
							<TD class="vertical_spacer2"></TD>
						</TR>
						<TR>
							<TD align="left">
								<asp:Panel ID="pnlNewFunction" Runat="server" Visible="False">
									<TABLE cellSpacing="0" cellPadding="0" width="0" border="0">
										<TR>
											<TD class="txt" align="center" width="100">Cód. operação</TD>
											<TD class="txt" align="center" width="200">Nome função</TD>
											<TD></TD>
										</TR>
										<TR>
											<TD width="100">
												<asp:TextBox id="txbNewFunctionCode" Runat="server" CssClass="txbFunctionCode"></asp:TextBox></TD>
											<TD width="200">
												<asp:TextBox id="txbNewFunctionName" Runat="server" CssClass="txbFunctionName"></asp:TextBox></TD>
											<TD align="right">
												<asp:linkbutton id="lnkbSaveNewFunction" Runat="server" CssClass="Button_1" Height="20px" CausesValidation="True"></asp:linkbutton></TD>
										</TR>
									</TABLE>
								</asp:Panel>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer3"></td>
		</tr>
	</tbody>
</table>
