<%@ Control Language="vb" AutoEventWireup="false" Codebehind="employeesMenu1.ascx.vb" Inherits="GPU.employeesMenu1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="550" align="center" border="0">
	<tbody>
		<tr>
			<td>
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td width="150"><asp:dropdownlist id="ddlAplication" Runat="server" AutoPostBack="True" CssClass="txbDg"></asp:dropdownlist></td>
						<td width="20"></td>
						<td width="150"><asp:dropdownlist id="ddlListType" Runat="server" AutoPostBack="True" CssClass="txbDg">
								<asp:ListItem Selected="True" Value="0"></asp:ListItem>
								<asp:ListItem Value="1"></asp:ListItem>
								<asp:ListItem Value="2"></asp:ListItem>
							</asp:dropdownlist></td>
						<td width="230"></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer2" colSpan="3"></td>
		</tr>
		<tr>
			<td vAlign="top" colSpan="3"><asp:datagrid id="dgProfiles" Runat="server" cellpadding="5" CellSpacing="1" AllowPaging="False"
					GridLines="None" AutoGenerateColumns="False" DataKeyField="UserName" BorderWidth="0" Width="100%">
					<Columns>
						<asp:HyperLinkColumn DataNavigateUrlField="UserName" DataNavigateUrlFormatString="../defaultIn.aspx?page=gpu-1.1&select=gpu-1.1.2&eid={0}">
							<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
						</asp:HyperLinkColumn>
						<asp:EditCommandColumn ButtonType="LinkButton">
							<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
						</asp:EditCommandColumn>
						<asp:BoundColumn DataField="UserName" ReadOnly="True" ItemStyle-Width="100px">
							<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FullName" ReadOnly="True" ItemStyle-Width="200px">
							<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn ItemStyle-Width="150px">
							<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem,"Profile") %>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList CssClass="txbDg" id="ddlProfile" Runat="server"></asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn ItemStyle-Width="25px">
							<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
							<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
							<ItemTemplate>
								<asp:CheckBox ID="ckbActive" Checked='<%# Container.DataItem("Active") %>' Runat="server" Enabled=False/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:CheckBox ID=ckbActiveE Checked='<%# Container.DataItem("Active") %>' Runat="server" Enabled=True/>
							</EditItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid></td>
		</tr>
		<TR>
			<TD class="vertical_spacer3" colSpan="3"></TD>
		</TR>
	</tbody>
</table>
