<%@ Control language="vb" AutoEventWireup="false" Codebehind="statsPGArq.ascx.vb" Inherits="GPU.statsPGArq" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="blong" Namespace="blong.WebControls" Assembly="blong" %>
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
						<td><asp:radiobuttonlist id="rblChoice" CssClass="txt" AutoPostBack="True" runat="server"></asp:radiobuttonlist></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td></td>
					</tr>
				</table>
			</td>
			<td width="20"></td>
			<td vAlign="top" align="center" width="410">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="line" colspan="2"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td class="txt"><asp:label id="lblFrom" CssClass="txtB" runat="server" Width="30px"></asp:label></td>
						<td class="txt"><asp:label id="lblYea" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlYear" CssClass="txt" runat="server" Width="60px"></asp:dropdownlist><asp:label id="lblMon" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlMonth" CssClass="txt" AutoPostBack="True" runat="server" Width="80px"></asp:dropdownlist><asp:label id="lblDay" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlDay" CssClass="txt" AutoPostBack="True" runat="server" Width="40px"></asp:dropdownlist><asp:linkbutton id="lnkbExecuta" CssClass="Button_1L" Runat="server" CausesValidation="True" Height="20px"></asp:linkbutton></td>
					</tr>
					<tr>
						<td class="txt"><asp:label id="lblTo" CssClass="txtB" runat="server" Width="30px"></asp:label></td>
						<td class="txt"><asp:label id="lblYea2" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlYear2" CssClass="txt" runat="server" Width="60px"></asp:dropdownlist><asp:label id="lblMon2" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlMonth2" CssClass="txt" AutoPostBack="True" runat="server" Width="80px"></asp:dropdownlist><asp:label id="lblDay2" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlDay2" CssClass="txt" AutoPostBack="True" runat="server" Width="40px"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td class="line" colspan="2"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblTypeOp" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate1" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDateTo" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><asp:table id="Table1" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td align="right" colspan="2">
							<asp:linkbutton id="lnkbExport" CssClass="Button_1L" Runat="server" CausesValidation="True" Height="20px"
								Visible="false"></asp:linkbutton>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate2" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><blong:webchart id="chart1" runat="server" Copyright="Copyright © DigitArq"></blong:webchart><asp:table id="Table2" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate3" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><blong:webchart id="chart2" runat="server" Copyright="Copyright © DigitArq"></blong:webchart><asp:table id="Table3" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate4" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><blong:webchart id="chart3" runat="server" Copyright="Copyright © DigitArq"></blong:webchart><asp:table id="Table4" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate5" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><asp:table id="Table5" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate6" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><asp:table id="Table6" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate7" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><asp:table id="Table7" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate8" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><asp:table id="Table8" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate9" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><asp:table id="Table9" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate10" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2"><asp:table id="Table10" CssClass="tablesSt" runat="server" CellPadding="3" GridLines="Both"></asp:table></td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label id="lblDate11" CssClass="txtB" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<td align="center" colspan="2">
							<asp:table id="Table11" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer1" colspan="2"></td>
					</tr>
					<tr>
						<td colspan="2">
							<asp:Label ID="lblDate12" Runat="server" CssClass="txtB"></asp:Label>
						</td>
					</tr>
					<tr>
						<td align="center" colspan="2">
							<asp:table id="Table12" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
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
