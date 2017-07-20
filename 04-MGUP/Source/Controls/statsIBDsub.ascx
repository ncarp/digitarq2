<%@ Register TagPrefix="blong" Namespace="blong.WebControls" Assembly="blong" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="statsIBDsub.ascx.vb" Inherits="GPU.statsIBDsub" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
						<td class="txtB"><%=GetLabel("statsPGFunc.lblOp")%></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td><asp:radiobuttonlist id="rblChoice" runat="server" AutoPostBack="True" CssClass="txt"></asp:radiobuttonlist></td>
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
						<td><asp:Label ID="lblTypeOp1" Runat="server" CssClass="txtB"></asp:Label></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="center"><asp:table id="Tabl1" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td><asp:Label ID="lblWarn" ForeColor="#ff0033" Runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="center">
							<blong:WebChart id="chart1" runat="server" Copyright="Copyright © DigitArq"></blong:WebChart>
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
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><asp:Label ID="lblTypeOp2" Runat="server" CssClass="txtB"></asp:Label></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="center"><asp:table id="Tabl2" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="center">
							<blong:WebChart id="chart2" runat="server" Copyright="Copyright © DigitArq"></blong:WebChart>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><asp:Label ID="lblTypeOp3" Runat="server" CssClass="txtB"></asp:Label></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="center"><asp:table id="Tabl3" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td align="center">
							<blong:WebChart id="chart3" runat="server" Copyright="Copyright © DigitArq"></blong:WebChart>
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
