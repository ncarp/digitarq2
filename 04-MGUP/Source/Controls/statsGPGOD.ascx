<%@ Register TagPrefix="blong" Namespace="blong.WebControls" Assembly="blong" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="statsGPGOD.ascx.vb" Inherits="GPU.statsGPGOD" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="550" align="center" border="0">
	<tbody>
		<tr>
			<td class="vertical_spacer3" colspan="2"></td>
		</tr>
		<tr>
			<td colspan="2">
				<table cellpadding="0" cellspacing="5" border="0">
					<tr>
						<td><%= GetLabel("statsGPGOD.lblTotalProjects") %>
						</td>
						<td><asp:Label Runat="server" ID="lblTotalProjects"></asp:Label></td>
					</tr>
					<tr>
						<td><%= GetLabel("statsGPGOD.lblTotalDigitalObjects") %>
						</td>
						<td><asp:Label Runat="server" ID="lblTotalOD"></asp:Label></td>
					</tr>
					<tr>
						<td><%= GetLabel("statsGPGOD.lblTotalImages") %>
						</td>
						<td><asp:Label Runat="server" ID="lblTotalImages"></asp:Label></td>
					</tr>
					<tr>
						<td><%= GetLabel("statsGPGOD.lblTotalLineImages") %>
						</td>
						<td><asp:Label Runat="server" ID="lblTotalDerivatives"></asp:Label></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer2" colSpan="2"></td>
		</tr>
		<tr>
			<td vAlign="top">
				<asp:datagrid id="dgImages" Runat="server" BorderWidth="0" DataKeyField="Otherlevel" AutoGenerateColumns="False"
					GridLines="None" AllowPaging="False" CellSpacing="1" cellpadding="5">
					<Columns>
						<asp:BoundColumn DataField="OtherLevel" ReadOnly="True" ItemStyle-Width="70px">
							<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="TotalImages" ReadOnly="True" ItemStyle-Width="70px">
							<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</td>
			<td align="right">
				<blong:webchart id="chart1" runat="server" Copyright="Copyright © DigitArq"></blong:webchart>
			</td>
		</tr>
		<TR>
			<TD class="vertical_spacer3" colSpan="2"></TD>
		</TR>
	</tbody>
</table>
