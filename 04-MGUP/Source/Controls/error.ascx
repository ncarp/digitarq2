<%@ Control Language="vb" AutoEventWireup="false" Codebehind="error.ascx.vb" Inherits="GPU._error" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="main" cellSpacing="0" cellPadding="0" width="550" align="center" border="0">
	<tr>
		<td class="vertical_spacer3"></td>
	</tr>
	<TR>
		<TD align="center" class="alert"><h4><asp:label id="lblError" Runat="server" ForeColor="red"></asp:label></h4>
		</TD>
	</TR>
	<TR>
		<TD class="vertical_spacer2"></TD>
	</TR>
	<tr>
		<td>
			<asp:Panel Runat="server" ID="pnlErrorDetails">
				<TABLE cellSpacing="0" cellPadding="0">
					<TR>
						<TD class="line"></TD>
					</TR>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<TR>
						<TD borderColor="red">
							<DIV style="OVERFLOW-Y: auto; OVERFLOW-X: auto; WIDTH: 550px; HEIGHT: 100px">
								<asp:label id="lblErrorDetails" Runat="server"></asp:label></DIV>
						</TD>
					</TR>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<TR>
						<TD class="line"></TD>
					</TR>
					<TR>
						<TD class="vertical_spacer2"></TD>
					</TR>
					<TR>
						<TD align="right">
							<asp:linkbutton id="lnkbSendError" Runat="server" Height="20px" CssClass="Button_1" CausesValidation="False"></asp:linkbutton></TD>
					</TR>
					<TR>
						<TD class="vertical_spacer2"></TD>
					</TR>
					<TR>
						<TD align="center">
							<SCRIPT type="text/javascript">
								var bar2= createBar(320,15,'white',1,'black','gray',85,7,2,"");
								bar2.hideBar();
							</SCRIPT>
						</TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</td>
	</tr>
</TABLE>
