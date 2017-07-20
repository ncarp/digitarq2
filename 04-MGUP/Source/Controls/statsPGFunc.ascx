<%@ Control language="vb" AutoEventWireup="false" Codebehind="statsPGFunc.ascx.vb" Inherits="GPU.statsPGFunc" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
						<td class="txtB"><%=GetLabel("statsPGFunc.lblEmployees")%></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="txt"><asp:dropdownlist id="ddlFunc" runat="server" CssClass="txt"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td class="line" width="180"></td>
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
					<tr>
						<td></td>
					</tr>
				</table>
			</td>
			<td width="20"></td>
			<td vAlign="top" align="center" width="410">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
						<tr>
							<td class="line" colspan=2></td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td class="txt"><asp:label id="lblFrom" CssClass="txtB" runat="server" Width="30px"></asp:label></td>
							<td class="txt"><asp:label id="lblYea" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlYear" CssClass="txt" runat="server" Width="50px"></asp:dropdownlist><asp:label id="lblMon" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlMonth" CssClass="txt" AutoPostBack="True" runat="server" Width="70px"></asp:dropdownlist><asp:label id="lblDay" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlDay" CssClass="txt" AutoPostBack="True" runat="server" Width="40px"></asp:dropdownlist><asp:linkbutton id="lnkbExecuta" CssClass="Button_1L" Runat="server" CausesValidation="True" Height="20px"></asp:linkbutton></td>
						</tr>
						<tr>
							<td class="txt"><asp:label id="lblTo" CssClass="txtB" runat="server" Width="30px"></asp:label></td>
							<td class="txt"><asp:label id="lblYea2" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlYear2" CssClass="txt" runat="server" Width="50px"></asp:dropdownlist><asp:label id="lblMon2" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlMonth2" CssClass="txt" AutoPostBack="True" runat="server" Width="70px"></asp:dropdownlist><asp:label id="lblDay2" CssClass="txtB" runat="server"></asp:label><asp:dropdownlist id="ddlDay2" CssClass="txt" AutoPostBack="True" runat="server" Width="40px"></asp:dropdownlist></td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td class="line" colspan=2></td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2><asp:Label ID="lblEmployee" Runat="server" CssClass="txtB"></asp:Label></td>
						</tr>
						<tr>
							<td colspan=2><asp:Label ID="lblTypeOp" Runat="server" CssClass="txtB"></asp:Label></td>
						</tr>
						<tr>
							<td colspan=2><asp:Label ID="lblDate1" Runat="server" CssClass="txtB"></asp:Label></td>
						</tr>
						<tr>
							<td colspan=2><asp:label id="lblDateTo" CssClass="txtB" Runat="server"></asp:label></td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table1" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td align="right" colspan=2>
								<asp:linkbutton id="lnkbExport" Height="20px" CausesValidation="True" CssClass="Button_1L" Runat="server"
									Visible="false"></asp:linkbutton>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate2" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table2" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>						</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate3" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table3" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate4" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table4" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate5" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table5" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate6" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table6" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>	
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate7" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table7" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate8" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table8" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate9" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table9" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate10" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table10" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate11" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table11" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer1" colspan=2></td>
						</tr>
						<tr>
							<td colspan=2>
								<asp:Label ID="lblDate12" Runat="server" CssClass="txtB"></asp:Label>
							</td>
						</tr>
						<tr>
							<td align="center" colspan=2>
								<asp:table id="Table12" runat="server" CssClass="tablesSt" GridLines="Both" CellPadding="3"></asp:table>
							</td>
						</tr>
					</TBODY>
				</table>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer2"></td>
		</tr>
	</tbody>
</table>
