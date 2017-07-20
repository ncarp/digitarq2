<%@ Control Language="vb" AutoEventWireup="false" Codebehind="statsIBDGerRel.ascx.vb" Inherits="GPU.statsIBDGerRelD" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="630" align="left" border="0">
	<tbody>
		<tr>
			<td vAlign="top" width="200">
				<table cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="txtB"><%=GetLabel("statsIBDGerRel.lblNivDesc")%></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td><asp:radiobuttonlist id="rblChoice" runat="server" AutoPostBack="True" CssClass="txt"></asp:radiobuttonlist></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
				</table>
			</td>
			<td width="20"></td>
			<td vAlign="top" align="center" width="410">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td><asp:Label ID="lblTypeOp" Runat="server" CssClass="txtB"></asp:Label></td>
					</tr>
					<tr>
						<td><asp:Label ID="lblInfo" Runat="server" CssClass="txtB" ForeColor="#ff0033"></asp:Label></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="center">
							<asp:datagrid id="dgRel" cellpadding="5" CellSpacing="1" AllowPaging="true" GridLines="None" AutoGenerateColumns="False"
								DataKeyField="UnitID" BorderWidth="0" Width="100%" Runat="server" PageSize="10" PagerStyle-CssClass="pagerStyle">
								<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
								<Columns>
									<asp:BoundColumn DataField="UnitID" ReadOnly="True" HeaderText="Código">
										<HeaderStyle CssClass="headerStyle"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UnitTitle" ReadOnly="True" HeaderText="Designação">
										<HeaderStyle CssClass="headerStyle"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages" HorizontalAlign="Center" PageButtonCount="10" Font-Bold="True"
									CssClass="pagerStyle" ForeColor="White" BackColor="#cccccc" NextPageText="Próxima >> " PrevPageText=" << Anterior"
									Width="450px"></PagerStyle>
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="right">
							<asp:linkbutton id="lnkbExport" Height="20px" CausesValidation="True" CssClass="Button_1L" Runat="server"
								Visible="false"></asp:linkbutton>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer2"></td>
		</tr>
	</tbody>
</table>
