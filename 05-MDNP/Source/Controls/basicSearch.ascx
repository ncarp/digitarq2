<%@ Register TagPrefix="uc2" TagName="horizontalMenu" Src="../OtherControls/horizontalMenu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="basicSearch.ascx.vb" Inherits="WebSearch2.uc_basicSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="tblMain" cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
	<tr>
		<td class="vertical_spacer2" colSpan="3"></td>
	</tr>
	<TR>
		<TD colSpan="2"></TD>
		<TD width="430"><uc2:horizontalmenu id="HorizontalMenu1" runat="server"></uc2:horizontalmenu></TD>
	</TR>
	<tr>
		<td class="vertical_spacer2" colSpan="3"></td>
	</tr>
	<TR>
		<td width="300"></td>
		<TD vAlign="top" width="20"></TD>
		<TD>
			<table cellSpacing="0" cellPadding="0" width="400" border="0">
				<tr>
					<td colSpan="2"><asp:validationsummary id="summary" CssClass="error03" Runat="server" DisplayMode="list" ShowSummary="True"></asp:validationsummary></td>
				</tr>
				<tr>
					<td colSpan="2"><asp:label id="lblAlertText" tabIndex="-2" runat="server" ForeColor="Red" Font-Bold="True"
							Font-Size="8pt" BackColor="Transparent" CssClass="Alert"></asp:label></td>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<td class="txtB02" colSpan="2"><STRONG><%=Getlabel("WS.BS.lblHeader")%></STRONG></td>
				</tr>
				<tr>
					<td class="vertical_spacer4" colSpan="2"></td>
				</tr>
				<tr>
					<TD class="txtB02" width="150"><span><%=Getlabel("WS.BS.lblNames")%>&nbsp;</span><A href="default.aspx?page=help#PB_Nomes"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A>
					</TD>
					<TD width="250"><span 
            title='<%=Getlabel("WS.BS.altNames")%>'><asp:textbox id="txtName" tabIndex="1" CssClass="txb02" Runat="server"></asp:textbox></span></TD>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<TR>
					<TD class="txtB02"><span><%=Getlabel("WS.BS.lblLocal")%></span>&nbsp;<A href="default.aspx?page=help#PB_Locais"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A>
					</TD>
					<TD><span 
            title='<%=Getlabel("WS.BS.altLocal")%>'><asp:textbox id="txtLocal" tabIndex="2" CssClass="txb02" Runat="server"></asp:textbox></span></TD>
				</TR>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<TR>
					<TD class="txtB02"><span><%=Getlabel("WS.BS.lblOtherTerms")%></span>&nbsp;<A href="default.aspx?page=help#PB_Termos"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A>
					</TD>
					<TD><span 
            title='<%=Getlabel("WS.BS.altOtherTerms")%>'><asp:textbox id="txtOtherTerms" tabIndex="3" CssClass="txb02" Runat="server"></asp:textbox></span></TD>
				</TR>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<TD class="txtB02"><span><%=Getlabel("WS.BS.lblDates")%></span>&nbsp;<A href="default.aspx?page=help#PB_Datas"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A></TD>
					<TD align="center">
						<TABLE cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<TD class="txtNavyACenter" width="62"><%=Getlabel("WS.lblYear")%></TD>
								<TD class="txtNavyACenter" width="120"><%=Getlabel("WS.lblMonth")%></TD>
								<TD class="txtNavyACenter" width="62"><%=Getlabel("WS.lblDay")%></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="txbYearInitial" CssClass="txbYear" Runat="server" MaxLength="4"></asp:textbox><asp:regularexpressionvalidator id="revYearInitial" Runat="server" Display="None" ValidationExpression="\d{0,4}"
										ControlToValidate="txbYearInitial"></asp:regularexpressionvalidator></TD>
								<TD><asp:dropdownlist id="ddlMonthInitial" CssClass="ddlMonth" Runat="server"></asp:dropdownlist></TD>
								<TD><asp:dropdownlist id="ddlDayInitial" CssClass="ddlDay" Runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="txtACenter" colSpan="3">a</TD>
							</TR>
							<TR>
								<TD class="txtNavyACenter"><%=Getlabel("WS.lblYear")%></TD>
								<TD class="txtNavyACenter"><%=Getlabel("WS.lblMonth")%></TD>
								<TD class="txtNavyACenter"><%=Getlabel("WS.lblDay")%></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="txbYearFinal" CssClass="txbYear" Runat="server" MaxLength="4"></asp:textbox><asp:regularexpressionvalidator id="revYearFinal" Runat="server" Display="None" ValidationExpression="\d{0,4}" ControlToValidate="txbYearFinal"></asp:regularexpressionvalidator></TD>
								<TD><asp:dropdownlist id="ddlMonthFinal" CssClass="ddlMonth" Runat="server"></asp:dropdownlist></TD>
								<TD><asp:dropdownlist id="ddlDayFinal" CssClass="ddlDay" Runat="server"></asp:dropdownlist><asp:customvalidator id="cvDate" Runat="server" Display="None" OnServerValidate="validateDate"></asp:customvalidator></TD>
							</TR>
						</TABLE>
					</TD>
				</tr>
				<tr>
					<td class="vertical_spacer4" colSpan="2"></td>
				</tr>
				<tr>
					<td align="center" colSpan="2" class="Invisible"><asp:button id="btnSearch" runat="server" CssClass="Invisible" Visible="True"></asp:button><asp:linkbutton id="lnkbSearch" CssClass="Button_1" Runat="server" Height="20px" CausesValidation="True"></asp:linkbutton></td>
				</tr>
				<tr>
					<td class="vertical_spacer3" colSpan="2"></td>
				</tr>
				<tr>
					<TD colSpan="2">
						<IMG alt="DigitArq" src="Images/DigitArq.png">
					</td>
				</tr>
				<tr>
					<TD colSpan="2">
						<b>© ADP</b>
					</td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
