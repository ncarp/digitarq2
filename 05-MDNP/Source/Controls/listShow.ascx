<%@ Register TagPrefix="uc2" TagName="horizontalMenu" Src="../OtherControls/horizontalMenu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="listShow.ascx.vb" Inherits="WebSearch2.listShow" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace ='WebSearch2.mShowItems'%>
<table cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
	<tr>
		<td class="vertical_spacer1" colSpan="3"></td>
	</tr>
	<TR>
		<td colSpan="2"></td>
		<TD width="430"><uc2:horizontalmenu id="HorizontalMenu1" runat="server"></uc2:horizontalmenu></TD>
	<tr>
	<tr>
		<td width="300"></td>
		<td width="20"></td>
		<td width="430" colSpan="3">
			<asp:panel id="pnlWithResults" Runat="server" Visible="False">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="TextTitle" width="430"><%=getlabel("WS.listShow.lblResultsSearch")%></TD>
					</TR>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<TR>
						<TD><SPAN><%=getlabel("WS.listShow.lblMessage1")%></SPAN><BR>
							<SPAN>
								<%=getlabel("WS.listShow.lblMessage2")%>
							</SPAN>
						</TD>
					</TR>
					<TR>
						<TD class="vertical_spacer3"></TD>
					</TR>
					<TR>
						<TD>
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><SPAN><B><%=getlabel("WS.listShow.lblOrderBy")%></B></SPAN></TD>
								</TR>
								<TR>
									<TD class="vertical_spacer1"></TD>
								</TR>
								<TR>
									<TD>
										<UL id="ulOrder" runat="server">
											<LI id="liOrderByDate" runat="server">
												<SPAN><A 
                    href="default.aspx?page=listShow&amp;searchMode=<%=mySearchMode%>&amp;sort=date&amp;order=<%=myOrder%>">
														<%=getlabel("WS.listShow.lblOrderByDate")%>
													</A></SPAN>
											</li>
											<LI id="liOrderByTitle" runat="server">
												<SPAN><A 
                    href="default.aspx?page=listShow&amp;searchMode=<%=mySearchMode%>&amp;sort=title&amp;order=<%=myOrder%>">
														<%=getlabel("WS.listShow.lblOrderByTitle")%>
													</A></SPAN>
											</li>
											<LI id="liOrderByLevel" runat="server">
												<SPAN><A 
                    href="default.aspx?page=listShow&amp;searchMode=<%=mySearchMode%>&amp;sort=level&amp;order=<%=myOrder%>">
														<%=getlabel("WS.listShow.lblOrderByLevel")%>
													</A></SPAN>
												<BR>
												<TABLE class="listNumberOfRegisters" cellPadding="0">
													<TR>
														<TD align="right">
															<asp:label id="lblNumberOfRegisters" runat="server" ForeColor="#ffffff"></asp:label></TD>
													</TR>
												</TABLE>
											</LI>
										</UL>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="vertical_spacer1"></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="430">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="bottom">
									<TD align="center">
										<TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
											<TR vAlign="bottom">
												<TD>
													<asp:repeater id="repFooterPageMenu1" runat="server">
														<HeaderTemplate>
															<%# strHeaderTable %>
														</HeaderTemplate>
														<ItemTemplate>
															<asp:hyperlink runat="server" CssClass='<%# DataBinder.Eval(Container.DataItem, "className")%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url")%>' ID="Hyperlink2">
																<%# DataBinder.Eval(Container.DataItem, "Text")%>
															</asp:hyperlink>
														</ItemTemplate>
														<FooterTemplate>
															<%# strFooterTable %>
														</FooterTemplate>
													</asp:repeater></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="vertical_spacer2"></TD>
								</TR>
								<TR>
									<TD class="line"></TD>
								</TR>
								<TR>
									<TD class="vertical_spacer2"></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="left">
										<asp:repeater id="repShowRecordList" runat="server">
											<HeaderTemplate>
												<%# strHeaderTable %>
											</HeaderTemplate>
											<ItemTemplate>
												<%# strDraw3ColumnRow(intGetRecordNumber() & strGetHTMLTagAlertImg(DataBinder.Eval(Container, "DataItem.Visible")) ,GetLabel("WS.listShow.lblOtherLevel"),"<img  align ='middle' src='" & strGetImgPth(DataBinder.Eval(Container,"DataItem.OtherLevel"))&"'/>" & strLevelName(DataBinder.Eval(Container,"DataItem.OtherLevel")))%>
												<%# strDraw3ColumnRow("",GetLabel("WS.listShow.lblCompleteUnitID"),"<a href='default.aspx?page=regShow&searchMode="& mySearchMode &"&ID=" & DataBinder.Eval(Container,"DataItem.ID")&"'>" & DataBinder.Eval(Container, "DataItem.CompleteUnitID")& "</a>" )%>
												<%# strDraw3ColumnRow("",GetLabel("WS.listShow.lblUnitTitle"), DataBinder.Eval(Container,"DataItem.UnitTitle") )%>
												<%#	strDraw3ColumnRow("",GetLabel("WS.listShow.lblDates"),strWriteDate(DataBinder.Eval(container,"DataItem.UnitDateInitialCertainty"),DataBinder.Eval(Container,"DataItem.UnitDateInitial"),DataBinder.Eval(Container,"DataItem.UnitDateFinalCertainty"),DataBinder.Eval(Container,"DataItem.UnitDateFinal")))%>
												<%#	strDraw3ColumnRow("",GetLabel("WS.listShow.lblPhysLoc"),DataBinder.Eval(Container,"DataItem.PhysLoc")) %>
												<%#	strDraw3ColumnRowForRA("<a href= 'default.aspx?page=authorityRecord&ID=" & DataBinder.Eval(Container,"DataItem.ID")&"'>" & getlabel("WS.listShow.lblAuthorityRecord") & "</a>",DataBinder.Eval(Container,"DataItem.Eac")) %>
												<%# strDrawListDocs("<a href='default.aspx?page=listShow&searchMode="& mySearchMode & "&sort=" & mySortBy & "&order=" & Me.Request.QueryString("order") & "&offset=" & myPageCurrent & "&addDocID=" & DataBinder.Eval(Container,"DataItem.ID") & "'><img src='Images/bloconotas.GIF'></a>",DataBinder.Eval(Container,"DataItem.IsDSDCUI")) %>
												<asp:Repeater ID="repDaoGrp" Runat="server">
													<HeaderTemplate>
														<%# strDraw3ColumnRowForRA(GetLabel("WS.listShow.lblDigitalDoc"),"",1) %>
														<%# strHeaderDigitalObjects %>
													</HeaderTemplate>
													<ItemTemplate>
														<td>
															<table>
																<tr>
																	<td>
																		<%#	String.Format("<a name=""a{0}"" href=""#a{0}"" onClick=onTop(""" & strGetDigitalObjectURL(DataBinder.Eval(Container,"DataItem.DigitalObjectID"), DataBinder.Eval(Container,"DataItem.FileID")) & """,""img_window"")>Imagens ({2})</a>",intLinkCount+1, DataBinder.Eval(Container, "DataItem.DigitalObjectID"),DataBinder.Eval(Container, "DataItem.NumImages")) %>
																	</td>
																</tr>
																<tr>
																	<td class="imgBorder">
																		<%# String.Format("<a name=""a{0}"" href=""#a{0}"" onClick=onTop(""" & strGetDigitalObjectURL(DataBinder.Eval(Container,"DataItem.DigitalObjectID"), DataBinder.Eval(Container,"DataItem.FileID")) & """,""img_window"")><img width=""100px"" src=""" & strGetImageURL(DataBinder.Eval(Container,"DataItem.DigitalObjectID"), DataBinder.Eval(Container,"DataItem.FileID")) & """/></a>", intLinkCount+1, DataBinder.Eval(Container, "DataItem.DigitalObjectID"), DataBinder.Eval(Container, "DataItem.FileID")) %>
																	</td>
																</tr>
															</table>
														</td>
													</ItemTemplate>
													<FooterTemplate>
														<%# strFooterDigitalObjects %>
													</FooterTemplate>
												</asp:Repeater>
											</ItemTemplate>
											<SeparatorTemplate>
												<%# strSeparator(4) %>
											</SeparatorTemplate>
											<FooterTemplate>
												<%# strFooterTable %>
											</FooterTemplate>
										</asp:repeater></TD>
								</TR>
								<TR>
									<TD class="vertical_spacer2"></TD>
								</TR>
								<TR>
									<TD class="line"></TD>
								</TR>
								<TR>
									<TD class="vertical_spacer2"></TD>
								</TR>
								<TR vAlign="bottom">
									<TD align="center">
										<TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
											<TR vAlign="bottom">
												<TD>
													<asp:repeater id="repFooterPageMenu2" runat="server">
														<HeaderTemplate>
															<%# strHeaderTable %>
														</HeaderTemplate>
														<ItemTemplate>
															<asp:hyperlink runat="server" CssClass='<%# DataBinder.Eval(Container.DataItem, "className")%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url")%>' ID="Hyperlink1">
																<%# DataBinder.Eval(Container.DataItem, "Text")%>
															</asp:hyperlink>
														</ItemTemplate>
														<FooterTemplate>
															<%# strFooterTable %>
														</FooterTemplate>
													</asp:repeater></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="vertical_spacer3" colSpan="2"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel></td>
	</tr>
	<tr>
		<td colSpan="3">
			<asp:panel id="pnlWithoutResults" Runat="server" Visible="False">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="300"></TD>
						<TD width="20"></TD>
						<TD align="center" width="430">
							<P style="TEXT-ALIGN: center">
								<asp:label CssClass=Alert id="lblTextAlert" runat="server"></asp:label></P>
							<P style="TEXT-ALIGN: center">
								<asp:label id="lblInformationMessage" runat="server"></asp:label></P>
							<p style="TEXT-ALIGN: center">
								<asp:HyperLink id="hlnkBack" Runat="server" Height="20px" CssClass="Button_1"></asp:HyperLink>
							</p>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
		</td>
	</tr>
</table>
