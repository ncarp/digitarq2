<%@ Import Namespace ="GPU.utils" %>
<%@ Register TagPrefix="blong" Namespace="blong.WebControls" Assembly="blong" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="statsArchiveGPGOD.ascx.vb" Inherits="GPU.statsArchiveGPGOD" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="680" align="center" border="0">
	<tbody>
		<tr>
			<td class="vertical_spacer3" colSpan="3"></td>
		</tr>
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
			<td vAlign="top" align="center" width="440">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td>Ano:
							<asp:dropdownlist id="ddlYears" AutoPostBack="True" Runat="server"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td>
							<asp:datagrid id="dgArchive" Runat="server" Width="300px" cellpadding="5" CellSpacing="1" AllowPaging="False"
								GridLines="None" AutoGenerateColumns="False" DataKeyField="DateMonth" BorderWidth="0">
								<Columns>
									<asp:TemplateColumn ItemStyle-Width="150px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										<ItemTemplate>
											<%# GetMonthName(DataBinder.Eval(Container.DataItem,"DateMonth")) %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="TotalMonth" ReadOnly="True" ItemStyle-Width="70px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AvgMonth" ReadOnly="True" ItemStyle-Width="70px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td><asp:datagrid id="dgEmployees" Runat="server" Width="440px" cellpadding="5" CellSpacing="1" AllowPaging="False"
								GridLines="None" AutoGenerateColumns="False" DataKeyField="Username" BorderWidth="0">
								<Columns>
									<asp:BoundColumn DataField="Username" ReadOnly="True" ItemStyle-Width="150px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Total" ReadOnly="True" ItemStyle-Width="70px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn ItemStyle-Width="70px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										<ItemTemplate>
											<%# CalcAvgEmployee(DataBinder.Eval(Container.DataItem,"Total")) %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="70px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										<ItemTemplate>
											<%# CalcMonthlyAvgEmployee(DataBinder.Eval(Container.DataItem,"Total")) %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="70px">
										<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										<ItemTemplate>
											<%# CalcDaylyAvgEmployee(DataBinder.Eval(Container.DataItem,"Total")) %>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></td>
					</tr>
					<tr width="100%">
						<td><asp:panel id="pnlTotalArchive" Runat="server" Visible="True">
								<TABLE cellSpacing=1 cellPadding=2 
              width="<%=me.dgArchive.width%>">
									<TR>
										<TD class="line" colSpan="2"></TD>
									</TR>
									<TR>
										<TD align="right" width="140">Total:</TD>
										<TD>
											<asp:Label id="lblTotalArchive" Runat="server"></asp:Label></TD>
									</TR>
									<TR>
										<TD align="right" width="140"><%=GetLabel("statsArchiveGPGOD.lblMonthlyAvgArchive")%></TD>
										<TD><%= CalcMonthlyAvgArchive(me.lblTotalArchive.text) %></TD>
									</TR>
									<TR>
										<TD align="right" width="140"><%=GetLabel("statsArchiveGPGOD.lblDaylyAvgArchive")%></TD>
										<TD><%= CalcDaylyAvgArchive(me.lblTotalArchive.text) %></TD>
									</TR>
									<TR>
										<TD class="line" colSpan="2"></TD>
									</TR>
								</TABLE>
							</asp:panel></td>
					</tr>
					<tr width="100%">
						<td><asp:panel id="pnlTotalEmployees" Runat="server" Visible="True">
								<TABLE cellSpacing=1 cellPadding=2 
width="<%=me.dgEmployees.width%>">
									<TR>
										<TD class="line" colSpan="2"></TD>
									</TR>
									<TR>
										<TD align="right" width="140"><%=GetLabel("statsArchiveGPGOD.lblTotalEmployees")%></TD>
										<TD>
											<asp:Label id="lblTotalEmployees" Runat="server"></asp:Label></TD>
									</TR>
									<TR>
										<TD class="line" colSpan="2"></TD>
									</TR>
								</TABLE>
							</asp:panel></td>
					</tr>
					<tr>
						<td align="center"><asp:panel id="pnlChart1" Runat="server">
								<blong:webchart id="chart1" runat="server" visible="true" Copyright="Copyright © DigitArq"></blong:webchart>
							</asp:panel></td>
					</tr>
					<tr>
						<td align="center"><asp:panel id="pnlChart2" Runat="server">
								<blong:webchart id="chart2" runat="server" visible="true" Copyright="Copyright © DigitArq"></blong:webchart>
							</asp:panel></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer2"></td>
		</tr>
	</tbody>
</table>
