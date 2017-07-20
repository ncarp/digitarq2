<%@ Register TagPrefix="uc2" TagName="horizontalMenu" Src="../OtherControls/horizontalMenu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="advancedSearch.ascx.vb" Inherits="WebSearch2.uc_advancedSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblMain" cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
	<tr>
		<td class="vertical_spacer2" colSpan="3"></td>
	</tr>
	<TR>
		<td colspan="2"></td>
		<TD width="430">
			<uc2:horizontalMenu id="HorizontalMenu1" runat="server"></uc2:horizontalMenu></TD>
	</TR>
	<tr>
		<TD colspan="2"></TD>
		<TD class="txt03"><span><%=getlabel("WS.AS.lblMessageHeader")%></span></TD>
	</tr>
	<tr>
		<td class="vertical_spacer2" colSpan="3"></td>
	</tr>
	<tr>
		<td width="300"></td>
		<td vAlign="top" width="20"></td>
		<td>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:validationsummary id="summary" CssClass="error03" ShowSummary="True" Runat="server" DisplayMode="list"></asp:validationsummary></td>
				</tr>
				<tr>
					<td colSpan="2"><asp:label id="lblAlertText" runat="server" CssClass="error03"></asp:label></td>
				</tr>
				<tr>
					<td class="vertical_spacer1" colSpan="2"></td>
				</tr>
				<tr>
					<td class="txtB03"><STRONG><%=getlabel("WS.AS.lblSelectOtherLevel")%>&nbsp;</STRONG><A href="default.aspx?page=help#ND"><IMG alt="Informação de ajuda" src="Images/info.gif"></A>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<TABLE class="tblCkb" cellSpacing="0" cellPadding="0" width="430" align="center" border="0">
							<TR>
								<TD class="txt03" align="right" width="165"><IMG alt='<%=getlabel("WS.OtherLevel.F")%>' src="Images/f.jpg" align=bottom>&nbsp;<span><%=getlabel("WS.OtherLevel.F")%></span></TD>
								<TD width="50"><input onclick="selectOne()" type="checkbox" CHECKED value="F" name="ckbList"></TD>
								<TD class="txt03" align="right" width="165"><IMG alt='<%=getlabel("WS.OtherLevel.UI")%>' src="Images/ui.jpg" >&nbsp;<span><%=getlabel("WS.OtherLevel.UI")%></span></TD>
								<TD width="50"><input onclick="selectOne()" type="checkbox" CHECKED value="UI" name="ckbList"></TD>
							</TR>
							<TR>
								<TD class="txt03" align="right"><IMG alt='<%=getlabel("WS.OtherLevel.SC")%>' src="Images/sc.jpg" >&nbsp;<span><%=getlabel("WS.OtherLevel.SC")%></span></TD>
								<TD><input onclick="selectOne()" type="checkbox" CHECKED value="SC" name="ckbList"></TD>
								<TD class="txt03" align="right"><IMG alt='<%=getlabel("WS.OtherLevel.DC")%>' src="Images/dc.jpg" >&nbsp;<span><%=getlabel("WS.OtherLevel.DC")%></span></FONT></TD>
								<TD><input onclick="selectOne()" type="checkbox" CHECKED value="DC" name="ckbList"></TD>
							</TR>
							<TR>
								<TD class="txt03" align="right"><IMG alt='<%=getlabel("WS.OtherLevel.SR")%>' src="Images/sr.jpg" >&nbsp;<span><%=getlabel("WS.OtherLevel.SR")%></span></TD>
								<TD><input onclick="selectOne()" type="checkbox" CHECKED value="SR" name="ckbList"></TD>
								<TD class="txt03" align="right"><IMG alt='<%=getlabel("WS.OtherLevel.D")%>' src="Images/d.jpg" >&nbsp;<span><%=getlabel("WS.OtherLevel.D")%></span></TD>
								<TD><input onclick="selectOne()" type="checkbox" CHECKED value="D" name="ckbList"></TD>
							</TR>
							<TR>
								<TD class="txtB03" align="right"><span><%=getlabel("WS.OtherLevel.All")%></span></TD>
								<TD><input onclick="selectAll()" type="checkbox" CHECKED value="Todos" name="Todos"></TD>
								<TD><asp:customvalidator id="cvCkbList" runat="server" ClientValidationFunction="ckbListValidation" Display="None"></asp:customvalidator></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="txtB03" vAlign="middle"><STRONG><%=getlabel("WS.AS.lblSearchImagesOnly")%></STRONG><asp:checkbox id="Img" runat="server"></asp:checkbox></TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer3" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="txtB03" width="175"><span><%=getlabel("WS.AS.lblCompleteUnitID")%></span>&nbsp;<A href="default.aspx?page=help#Referencia"><IMG alt="Informação de ajuda" src="Images/info.gif"></A></TD>
								<TD width="250"><asp:textbox id="txbCompleteUnitId" runat="server" CssClass="txbBgGrey03"></asp:textbox></TD>
								<TD width="15"><IMG class="c" id="imgUnitIdBooleanSearch" style="CURSOR: hand" onclick='ShowPanel("pnlCompletUnitId","imgUnitIdBooleanSearch")'
										src="Images/expands.gif" align="right"></TD>
							</tr>
							<TR>
								<td colSpan="3">
									<div id="pnlCompletUnitId" style="DISPLAY: none">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25"><IMG id="ImgTreeRef" src="Images/L.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblPartUnitID")%></span>&nbsp;</TD>
												<TD width="250"><asp:textbox id="txbPartUnitId" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
										</TABLE>
										<div></div>
									</div>
								</td>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="txtB03" width="165"><span><%=getlabel("WS.AS.lblUnitTitle")%></span>&nbsp;<A href="default.aspx?page=help#Título"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A></TD>
								<TD width="250"><asp:textbox id="txbAndUnitTitle" runat="server" CssClass="txbBgGrey03"></asp:textbox></TD>
								<TD width="15"><IMG class="c" id="imgUnitTitleBooleanSearch" style="CURSOR: hand" onclick='ShowPanel("pnlUnitTitle","imgUnitTitleBooleanSearch")'
										src="Images/expands.gif" align="right"></TD>
							</tr>
							<TR>
								<td colSpan="3">
									<div id="pnlUnitTitle" style="DISPLAY: none">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblExactPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbExactPhraseUnitTitle" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblOrPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbOrUnitTitle" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/L.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblNotPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbNotUnitTitle" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
										</TABLE>
										<div></div>
									</div>
								</td>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="txtB03" width="175"><span><%=getlabel("WS.AS.lblAuthorDestination")%></span>&nbsp;<A href="default.aspx?page=help#Autor_dest">
										<IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A></TD>
								<TD width="250"><asp:textbox id="txbAndAuthorDestination" runat="server" CssClass="txbBgGrey03"></asp:textbox></TD>
								<TD width="15"><IMG class="c" id="imgAuthorDestination" style="CURSOR: hand" onclick='ShowPanel("pnlAuthorDestination","imgAuthorDestination")'
										src="Images/expands.gif" align="right"></TD>
							</tr>
							<TR>
								<td colSpan="3">
									<div id="pnlAuthorDestination" style="DISPLAY: none">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblExactPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbExactPhraseAuthorDestination" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblOrPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbOrAuthorDestination" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/L.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblNotPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbNotAuthorDestination" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
										</TABLE>
										<div></div>
									</div>
								</td>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="txtB03" width="175"><span><%=getlabel("WS.AS.lblGeogLocal")%></span>&nbsp;<A href="default.aspx?page=help#Localidade"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A></TD>
								<TD width="250"><asp:textbox id="txbAndGeogLocal" runat="server" CssClass="txbBgGrey03"></asp:textbox></TD>
								<TD width="15"><IMG class="c" id="imgGeogLocal" style="CURSOR: hand" onclick='ShowPanel("pnlGeogLocal","imgGeogLocal")'
										src="Images/expands.gif" align="right"></TD>
							</tr>
							<TR>
								<td colSpan="3">
									<div id="pnlGeogLocal" style="DISPLAY: none">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblExactPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbExactPhraseGeogLocal" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblOrPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbOrGeogLocal" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/L.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblNotPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbNotGeogLocal" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
										</TABLE>
										<div></div>
									</div>
								</td>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer2" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="txtB03" width="175"><span><%=getlabel("WS.AS.lblKeyWord")%></span>&nbsp;<A href="default.aspx?page=help#Outros_campos">
										<IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A></TD>
								<TD width="250"><asp:textbox id="txbAndKeyWord" runat="server" CssClass="txbBgGrey03"></asp:textbox></TD>
								<TD width="15"><IMG class="c" id="imgKeyWord" style="CURSOR: hand" onclick='ShowPanel("pnlKeyWord","imgKeyWord")'
										src="Images/expands.gif" align="right"></TD>
							</tr>
							<TR>
								<td colSpan="3">
									<div id="pnlKeyWord" style="DISPLAY: none">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblExactPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbExactPhraseKeyWord" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/T.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblOrPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbOrKeyWord" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
											<TR>
												<TD width="25"><IMG src="Images/L.gif" align="left"></TD>
												<TD class="txt03" width="140"><span><%=getlabel("WS.AS.lblNotPhrase")%></span></TD>
												<TD width="250"><asp:textbox id="txbNotKeyWord" runat="server" CssClass="txb03"></asp:textbox></TD>
												<TD width="15"></TD>
											</TR>
										</TABLE>
									</div>
								</td>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer3" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="txtB02" width="165"><span><%=Getlabel("WS.AS.lblDates")%></span>&nbsp;<A href="default.aspx?page=help#PB_Datas"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A></TD>
								<TD align="center">
									<TABLE cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD class="txtNavyACenter" width="62"><%=Getlabel("WS.lblYear")%></TD>
											<TD class="txtNavyACenter" width="120"><%=Getlabel("WS.lblMonth")%></TD>
											<TD class="txtNavyACenter" width="62"><%=Getlabel("WS.lblDay")%></TD>
											<td width="15"></td>
										</TR>
										<TR>
											<TD><asp:textbox id="txbYearInitial" CssClass="txbYear" Runat="server" MaxLength="4"></asp:textbox><asp:regularexpressionvalidator id="revYearInitial" Runat="server" Display="None" ValidationExpression="\d{0,4}"
													ControlToValidate="txbYearInitial"></asp:regularexpressionvalidator></TD>
											<TD><asp:dropdownlist id="ddlMonthInitial" CssClass="ddlMonth" Runat="server"></asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="ddlDayInitial" CssClass="ddlDay" Runat="server"></asp:dropdownlist></TD>
											<td></td>
										</TR>
										<TR>
											<TD class="txtACenter" colSpan="4"><%=Getlabel("WS.AS.lblWord.To")%></TD>
										</TR>
										<TR>
											<TD class="txtNavyACenter"><%=Getlabel("WS.lblYear")%></TD>
											<TD class="txtNavyACenter"><%=Getlabel("WS.lblMonth")%></TD>
											<TD class="txtNavyACenter"><%=Getlabel("WS.lblDay")%></TD>
											<td></td>
										</TR>
										<TR>
											<TD><asp:textbox id="txbYearFinal" CssClass="txbYear" Runat="server" MaxLength="4"></asp:textbox><asp:regularexpressionvalidator id="revYearFinal" Runat="server" Display="None" ValidationExpression="\d{0,4}" ControlToValidate="txbYearFinal"></asp:regularexpressionvalidator></TD>
											<TD><asp:dropdownlist id="ddlMonthFinal" CssClass="ddlMonth" Runat="server"></asp:dropdownlist></TD>
											<TD><asp:dropdownlist id="ddlDayFinal" CssClass="ddlDay" Runat="server"></asp:dropdownlist></TD>
											<td><asp:customvalidator id="cvDate" Runat="server" Display="None" OnServerValidate="validateDate"></asp:customvalidator></td>
										</TR>
									</TABLE>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer3" colSpan="2"></td>
				</tr>
				<tr>
					<td>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="txtB03" width="165"><span><%=Getlabel("WS.AS.lblControlAccessTypes")%>&nbsp;<A href="default.aspx?page=help#Termos_indexacao"><IMG alt='<%=getlabel("WS.altHelp")%>' src="Images/info.gif" ></A></span></TD>
								<TD><asp:dropdownlist id="ddlControlAccessTypes" runat="server" CssClass="ddl03" AutoPostBack="True"></asp:dropdownlist></TD>
							<tr>
								<td class="vertical_spacer1" colSpan="2"></td>
							</tr>
							<tr>
								<td></td>
								<TD><asp:dropdownlist id="ddlControlAccessItems" runat="server" CssClass="ddl03"></asp:dropdownlist></TD>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer3" colSpan="2"></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:button id="btnSearch" CssClass="Invisible" Runat="server" Visible="True"></asp:button><asp:linkbutton id="lnkbSearch" CssClass="Button_1" Runat="server" Height="20px" CausesValidation="True"></asp:linkbutton></td>
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
		</td>
	</tr>
</table>
