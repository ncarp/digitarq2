<%@ Control Language="vb" AutoEventWireup="false" Codebehind="profilesMenu2.ascx.vb" Inherits="GPU.profilesMenu2" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="550" align="left" border="0">
	<tbody>
		<tr>
			<td width="180" valign="top">
				<table width="100%" cellpadding="0" cellspacing="0" border="0">
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="txtB"><%=GetLabel("profilesMenu2.lblAplications")%></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td class="txt"><asp:RadioButtonList ID="rblAplications" Runat="server" AutoPostBack="True"></asp:RadioButtonList></td>
					</tr>
				</table>
			</td>
			<td width="20">
			</td>
			<td width="350" valign="top">
				<table width="100%" cellpadding="0" cellspacing="0" border="0">
					<tr>
						<td class="line"></td>
					</tr>
					<tr>
						<td class="vertical_spacer1"></td>
					</tr>
					<tr>
						<td class="txtB"><%=GetLabel("profilesMenu2.lblProfiles")+ " (" + me.rblAplications.SelectedItem.Text + "):" %></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td vAlign="top">
							<asp:datagrid id="dgProfiles" Runat="server" Width="100%" BorderWidth="0" DataKeyField="ProfileID"
								AutoGenerateColumns="False" GridLines="None" AllowPaging="False" CellSpacing="1" cellpadding="5">
								<Columns>
									<asp:buttoncolumn buttontype="LinkButton" commandname="Delete">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
									</asp:buttoncolumn>
									<asp:EditCommandColumn ButtonType="LinkButton">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textCenter"></ItemStyle>
									</asp:EditCommandColumn>
									<asp:BoundColumn DataField="Profile" ItemStyle-Width="250px">
										<HeaderStyle CssClass="bgDgHeader"></HeaderStyle>
										<ItemStyle CssClass="itemStyle_textLeft"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<table width="100%" cellpadding="0" cellspacing="0" border="0">
								<tr>
									<td class="txt" width="70"><%=GetLabel("profilesMenu2.lblNewProfile")%></td>
									<td width="180">
										<asp:TextBox ID="txbNewProfile" Runat="server" CssClass="txb"></asp:TextBox>
									</td>
									<td width="100">
										<asp:linkbutton id="lnkbSave" Runat="server" CssClass="Button_1" CausesValidation="True" Height="20px"></asp:linkbutton>
									</td>
								</tr>
							</table>
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
