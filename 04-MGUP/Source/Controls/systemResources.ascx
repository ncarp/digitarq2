<%@ Control Language="vb" AutoEventWireup="false" Codebehind="systemResources.ascx.vb" Inherits="GPU.systemResources" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="blong" Namespace="blong.WebControls" Assembly="blong" %>
<%@ Import Namespace ="GPU.utils" %>
<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
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
			<td vAlign="top" align="center" width="480"><asp:panel id="pnlCountLogs" Visible="False" Runat="server">
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD class="line" colSpan="3"></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer1" colSpan="3"></TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<asp:datagrid id="dgCountLogsByYear" Runat="server" Width="150px" cellpadding="5" CellSpacing="1"
									AllowPaging="False" GridLines="None" AutoGenerateColumns="False" DataKeyField="LogYear" BorderWidth="0">
									<Columns>
										<asp:BoundColumn DataField="LogYear" ReadOnly="True" HeaderStyle-Width="80px" ItemStyle-Width="80px">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LogCount" ReadOnly="True" HeaderStyle-Width="70px" ItemStyle-Width="70px">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></TD>
							<TD vAlign="top">
								<blong:webchart id="chartCountLogsByYear" runat="server" visible="true" Copyright="Copyright © DigitArq"></blong:webchart></TD>
						</TR>
						<TR vAlign="top">
							<TD class="line" colSpan="2"></TD>
							<TD></TD>
						</TR>
						<TR vAlign="top">
							<TD align="right" width="80"><%= GetLabel("systemResources.lblTotal") %></TD>
							<TD align="right" width="70">
								<asp:Label id="lblTotalLogsCount1" Runat="server"></asp:Label></TD>
							<TD></TD>
						</TR>
						<TR vAlign="top">
							<TD class="line" colSpan="2"></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer1" colSpan="3"></TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<asp:datagrid id="dgCountLogsByUsername" Runat="server" Width="150px" cellpadding="5" CellSpacing="1"
									AllowPaging="False" GridLines="None" AutoGenerateColumns="False" DataKeyField="Username" BorderWidth="0">
									<Columns>
										<asp:BoundColumn DataField="Username" ReadOnly="True" HeaderStyle-Width="80px" ItemStyle-Width="80px">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LogCount" ReadOnly="True" HeaderStyle-Width="70px" ItemStyle-Width="70px">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></TD>
							<TD vAlign="top">
								<blong:webchart id="chartCountLogsByUsername" runat="server" visible="true" Copyright="Copyright © DigitArq"
									Color1="204, 0, 0" Color2="204, 0, 255"></blong:webchart></TD>
						</TR>
						<TR>
							<TD class="line" colSpan="2"></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD align="right" width="80"><%= GetLabel("systemResources.lblTotal") %></TD>
							<TD align="right" width="70">
								<asp:Label id="lblTotalLogsCount2" Runat="server"></asp:Label></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD class="line" colSpan="2"></TD>
							<TD></TD>
						</TR>
					</TABLE>
				</asp:panel><asp:panel id="pnlBackups" Visible="False" Runat="server">
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD class="line"></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer1"></TD>
						</TR>
						<TR>
							<TD>
								<asp:datagrid id="dgBackups" Runat="server" cellpadding="5" CellSpacing="1" AllowPaging="False"
									GridLines="None" AutoGenerateColumns="False" DataKeyField="FileName" BorderWidth="0">
									<Columns>
										<asp:BoundColumn DataField="FileName" ReadOnly="True">
											<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FileLength" ReadOnly="True">
											<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FileCreationTime" ReadOnly="True">
											<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
					</TABLE>
				</asp:panel><asp:panel id="pnlDBSize" Visible="False" Runat="server">
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD class="line"></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer1"></TD>
						</TR>
						<TR>
							<TD colSpan="2"><B><%= GetLabel("systemResources.lblDBLocation") %></B>
								<asp:Label id="lblDBLocation" Runat="server"></asp:Label></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer1"></TD>
						</TR>
						<TR>
							<TD>
								<asp:datagrid id="dgDBSize" Runat="server" cellpadding="5" CellSpacing="1" AllowPaging="False"
									GridLines="None" AutoGenerateColumns="False" DataKeyField="SpaceTitle" BorderWidth="0">
									<Columns>
										<asp:BoundColumn DataField="SpaceTitle" ReadOnly="True">
											<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Size" ReadOnly="True">
											<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Percent" ReadOnly="True">
											<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD vAlign="top">
								<blong:webchart id="chartDBSize" runat="server" visible="true" Copyright="Copyright © DigitArq"></blong:webchart></TD>
						</TR>
					</TABLE>
				</asp:panel><asp:panel id="pnlDiskSize" Visible="False" Runat="server">
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD class="line"></TD>
						</TR>
						<TR>
							<TD class="vertical_spacer1"></TD>
						</TR>
						<TR>
							<TD>
								<asp:datagrid id="dgDiskSize" Runat="server" cellpadding="5" CellSpacing="1" AllowPaging="False"
									GridLines="None" AutoGenerateColumns="False" DataKeyField="DriveName" BorderWidth="0">
									<Columns>
										<asp:BoundColumn DataField="DriveName" ReadOnly="True">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Size" ReadOnly="True">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRight"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BusySpace" ReadOnly="True">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRightRed"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PercentBusySpace" ReadOnly="True" HeaderStyle-Width="50px">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRightRed"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FreeSpace" ReadOnly="True">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRightGreen"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PercentFreeSpace" ReadOnly="True" HeaderStyle-Width="50px">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textRightGreen"></ItemStyle>
										</asp:BoundColumn>
										<asp:HyperLinkColumn DataNavigateUrlField="DriveName" DataNavigateUrlFormatString="./defaultIn.aspx?page=gpu-3.3&op=diskSize&deviceID={0}"
											Text="<img src='Images/icon_chart.gif' alt='Gráfico' border='0'>">
											<HeaderStyle CssClass="bgHighDgHeader"></HeaderStyle>
											<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
										</asp:HyperLinkColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD vAlign="top">
								<blong:webchart id="chartDrive" runat="server" visible="true" Copyright="Copyright © DigitArq" Color1="246, 198, 196"
									Color2="215, 254, 160"></blong:webchart></TD>
						</TR>
					</TABLE>
				</asp:panel></td>
		</tr>
		<tr>
			<td class="vertical_spacer2"></td>
		</tr>
	</tbody>
</table>
