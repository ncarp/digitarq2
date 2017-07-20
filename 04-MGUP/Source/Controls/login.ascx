<%@ Control Language="vb" AutoEventWireup="false" Codebehind="login.ascx.vb" Inherits="GPU.uc_login1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblLogin" cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="vertical_spacer4"></td>
		</tr>
		<tr height="20">
			<td width="120" class="txt01"><%=GetLabel("login.lblUserName")%></td>
			<td width="150"><asp:DropDownList id="ddlUserName" CssClass="ddl01" Runat="server"></asp:DropDownList></td>
			<td></td>
			<td width="180"></td>
		</tr>
		<tr>
			<td colSpan="4" class="vertical_spacer1"></td>
		</tr>
		<tr height="20">
			<td width="120" class="txt01"><%=GetLabel("login.lblPassword")%></td>
			<td width="150"><asp:textbox id="txtPassword" CssClass="txb01" Runat="server" TextMode="Password"></asp:textbox></td>
			<td><asp:RequiredFieldValidator Runat="server" ID="rfvTxtPassword" ControlToValidate="txtPassword" Display="Dynamic"
					ErrorMessage="!"></asp:RequiredFieldValidator></td>
			<td width="180"><asp:button id="btnSearch" runat="server" CssClass="Invisible" Visible="True"></asp:button><asp:LinkButton Runat="server" ID="lnkbSubmit" CssClass="Button_1" Height="20px"></asp:LinkButton></td>
		</tr>
		<tr>
			<td colSpan="4" class="vertical_spacer1"></td>
		</tr>
		<tr>
			<td></td>
			<td colspan="3"><asp:label id="lblError" CssClass="txtError01" Visible="False" Runat="server"></asp:label></td>
		</tr>
		<tr>
			<td colSpan="4" class="vertical_spacer2"></td>
		</tr>
	</tbody>
</table>
