<%@ Control Language="vb" AutoEventWireup="false" Codebehind="aplicationsMenu2.ascx.vb" Inherits="GPU.aplicationsMenu2" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="550" align="left" border="0">
	<tbody>
		<tr>
			<td vAlign="top">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="txtB"><%=GetLabel("aplicationsMenu2.lblAplications")%></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td vAlign="top"><asp:datagrid id="dgAplications" Runat="server" cellpadding="5" CellSpacing="1" AllowPaging="False"
								GridLines="None" AutoGenerateColumns="False" DataKeyField="AplicationCode" BorderWidth="0" Width="100%">
								<Columns>
									<asp:buttoncolumn buttontype="LinkButton" commandname="Delete">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
									</asp:buttoncolumn>
									<asp:EditCommandColumn ButtonType="LinkButton">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
									</asp:EditCommandColumn>
									<asp:BoundColumn DataField="AplicationCode" ItemStyle-Width="100px" ReadOnly="True">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AplicationName" ItemStyle-Width="250px">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Version" ItemStyle-Width="100px">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="txt" align="center" width="100"><%=GetLabel("aplicationsMenu2.lblNewAplicationCode")%></td>
									<td class="txt" align="center" width="200"><%=GetLabel("aplicationsMenu2.lblNewAplication")%></td>
									<td class="txt" align="center" width="100"><%=GetLabel("aplicationsMenu2.lblNewVersion")%></td>
									<td></td>
								</tr>
								<tr>
									<td width="100"><asp:textbox id="txbNewAplicationCode" Runat="server" CssClass="txbNewAplicationCode"></asp:textbox></td>
									<td width="200"><asp:textbox id="txbNewAplication" Runat="server" CssClass="txbNewAplication"></asp:textbox></td>
									<td width="100"><asp:textbox id="txbNewVersion" Runat="server" CssClass="txbNewVersion"></asp:textbox></td>
									<td><asp:linkbutton id="lnkbSave" Runat="server" CssClass="Button_1" Height="20px" CausesValidation="True"></asp:linkbutton></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer3"></td>
		</tr>
	</tbody>
</table>
