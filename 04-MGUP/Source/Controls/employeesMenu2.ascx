<%@ Control Language="vb" AutoEventWireup="false" Codebehind="employeesMenu2.ascx.vb" Inherits="GPU.employeesMenu2" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
	<tbody>
		<tr>
			<td colSpan="3"><asp:validationsummary id="resumo" Runat="server" DisplayMode="List" ShowMessageBox="False" ShowSummary="True"
					CssClass="validationSummary"></asp:validationsummary></td>
		</tr>
		<TR>
			<TD class="headerSeccion" colSpan="3"><%=GetLabel("employeesMenu2.lblPersonalDatas")%></TD>
		</TR>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<TR>
			<td class="star">*</td>
			<TD class="fieldsTitle"><%=GetLabel("employeesMenu2.lblFirstName")%></TD>
			<TD><asp:textbox id="txtFirstName" CssClass="bigTxb" runat="server"></asp:textbox><asp:requiredfieldvalidator id="rfvTxtFirstName" runat="server" ControlToValidate="txtFirstName" Display="Dynamic"> !</asp:requiredfieldvalidator></TD>
		</TR>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<TR>
			<td class="star">*</td>
			<TD class="fieldsTitle"><%=GetLabel("employeesMenu2.lblLastName")%></TD>
			<TD><asp:textbox id="txtLastName" CssClass="bigTxb" runat="server"></asp:textbox><asp:requiredfieldvalidator id="rfvTxtLastName" runat="server" ControlToValidate="txtLastName" Display="Dynamic"> !</asp:requiredfieldvalidator></TD>
		</TR>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<TR>
			<td class="star"></td>
			<TD class="fieldsTitle"><%=GetLabel("employeesMenu2.lblObs")%></TD>
			<TD><asp:textbox id="txtObs" CssClass="bigTxb" runat="server"></asp:textbox></TD>
		</TR>
		<tr>
			<td class="vertical_spacer2" colSpan="3"></td>
		</tr>
		<TR>
			<TD class="headerSeccion" colSpan="3"><%=GetLabel("employeesMenu2.lblAccessKey")%></TD>
		</TR>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<TR>
			<TD class="star">*</TD>
			<TD class="fieldsTitle"><%=GetLabel("employeesMenu2.lblUserName")%></TD>
			<TD><asp:textbox id="txtUserName" CssClass="mediumTxb" runat="server"></asp:textbox><asp:requiredfieldvalidator id="rfvTxtUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic"> !</asp:requiredfieldvalidator></TD>
		</TR>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<TR>
			<TD class="star">*</TD>
			<TD class="fieldsTitle"><%=GetLabel("employeesMenu2.lblPassword")%></TD>
			<TD><asp:textbox id="txtPassword" CssClass="mediumTxb" runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="rfvTxtPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic"> !</asp:requiredfieldvalidator></TD>
		</TR>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<TR>
			<TD class="star">*</TD>
			<TD class="fieldsTitle"><%=GetLabel("employeesMenu2.lblPassword1")%></TD>
			<TD><asp:textbox id="txtPassword1" CssClass="mediumTxb" runat="server" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="rfvTxtPassword1" runat="server" ControlToValidate="txtPassword1" Display="Dynamic"> !</asp:requiredfieldvalidator><asp:comparevalidator id="cvPassword" Runat="server" ControlToValidate="txtPassword1" Display="Dynamic"
					ControlToCompare="txtPassword"> !</asp:comparevalidator></TD>
		</TR>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<tr>
			<TD class="star">*</TD>
			<TD class="fieldsTitle"><%=GetLabel("employeesMenu2.lblAplications")%></TD>
			<td class="aplications">
				<asp:CheckBoxList Runat="server" ID="cblAplications"></asp:CheckBoxList>
				<asp:CustomValidator ID="cvAplications" Runat="server" OnServerValidate="validateCheckBoxList" ErrorMessage="Selecione pelo menos um checkbox Pesquisa/Reprodução"
					Display="None"></asp:CustomValidator>
			</td>
		</tr>
		<tr>
			<td class="vertical_spacer2" colSpan="3"></td>
		</tr>
		<tr>
			<td align="right" colSpan="3"><asp:linkbutton id="lnkbDelete" Runat="server" CssClass="Button_1" Height="20px" CausesValidation="False"></asp:linkbutton><asp:linkbutton id="lnkbSubmit" Runat="server" CssClass="Button_1" Height="20px" CausesValidation="True"></asp:linkbutton></td>
		</tr>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<tr>
			<td class="fieldsTitle" colSpan="3">* Campos obrigatórios</td>
		</tr>
		<tr>
			<td colspan="3" class="vertical_spacer3"></td>
		</tr>
	</tbody>
</table>
