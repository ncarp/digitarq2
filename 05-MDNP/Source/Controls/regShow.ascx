<%@ Register TagPrefix="uc2" TagName="horizontalMenu" Src="../OtherControls/horizontalMenu.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="regShow.ascx.vb" Inherits="WebSearch2.regShow" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Import Namespace ="WebSearch2.mShowItems" %>
<TABLE cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
	<TBODY>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<TR>
			<td width=300></td>
			<td width=20></td>
			<TD width="430"><uc2:horizontalmenu id="HorizontalMenu1" runat="server"></uc2:horizontalmenu></TD>
		<tr>
		<tr>
			<td class="vertical_spacer1" colSpan="3"></td>
		</tr>
		<tr>
			<td colSpan="3">
				<table width="100%">
					<TBODY>
						<tr>
							<td align="right"><asp:imagebutton id="ibtnAuthorityRecord" ImageUrl="../Images/AuthorityRecord.gif" Visible="False"
									Runat="server" CssClass="imgBarRegShow"></asp:imagebutton><A href="javascript:PrintThisPage();"><IMG class=imgBarRegShow alt='<%=getlabel("WS.regShow.altPrint")%>' src="Images/printWB.gif" ></A>
							</td>
						</tr>
					</TBODY>
				</table>
			</td>
		</tr>
		<tr>
			<td class="line" colSpan="3"></td>
		</tr>
		<tr>
			<td class="vertical_spacer3" colSpan="3"></td>
		</tr>
		<tr>
			<td vAlign="top" align="left" width="300">
				<div style="OVERFLOW-Y: auto; OVERFLOW-X: auto; WIDTH: 300px; HEIGHT: 500px">
					<iewc:treeview id="tvRecordParentsAndChildren" runat="server" CssClass="TreeNode" align="left"
						AutoPostBack="True" SystemImagesPath="/webctrl_client/1_0/treeimages/" Indent="15" Width="550px"></iewc:treeview>
				</div>
			</td>
			<TD width="20"></TD>
			<td vAlign="top" width="430">
				<TABLE width=100% cellpadding=0 cellspacing=0 border=0>
					<TBODY>
						<tr>
							<td><span>
									<%=getlabel("WS.regShow.lblMessage1")%>
								</span>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer2"></td>
						</tr>
						<tr>
							<TD vAlign="top" bgColor="#ffffff">
								<asp:panel id="pnlContents" Runat="server">
									<DIV id="contentstart">
										<asp:repeater id="repRecordUnitProprieties" runat="server">
											<HeaderTemplate>
												<%# strHeaderTable %>
											</HeaderTemplate>
											<ItemTemplate>
												<%# strAlert(strGetHTMLTagAlertImg(DataBinder.Eval(Container,"DataItem.Visible")),DataBinder.Eval(Container,"DataItem.Visible") )%>
												<!Zona de identificação>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.CompleteUnitID"), DataBinder.Eval(Container,"DataItem.CompleteUnitId") )%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.Repository"), DataBinder.Eval(Container,"DataItem.Repository") )%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.UnitTitle"), strWriteTitle(DataBinder.Eval(Container,"DataItem.UnitTitle"),DataBinder.Eval(Container,"DataItem.UnitTitleType")) )%>
												<%#	strDraw2ColumnRow(getlabel("WS.regShow.Dates"), strWriteDate(DataBinder.Eval(container,"DataItem.UnitDateInitialCertainty"),DataBinder.Eval(Container,"DataItem.UnitDateInitial"),DataBinder.Eval(Container,"DataItem.UnitDateFinalCertainty"),DataBinder.Eval(Container,"DataItem.UnitDateFinal")))%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.UnitDateBulk"), DataBinder.Eval(Container,"DataItem.UnitDateBulk"))%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.OtherLevel"), "<img  align ='middle' src='" & strGetImgPth(DataBinder.Eval(Container,"DataItem.OtherLevel"))&"'/>" & strLevelName(DataBinder.Eval(Container,"DataItem.OtherLevel")))%>
												<%# strExtent(DataBinder.Eval(Container,"DataItem.OtherLevel"), DataBinder.Eval(Container,"DataItem.ExtentLeaf"),DataBinder.Eval(Container,"DataItem.ExtentPage"),DataBinder.Eval(Container,"DataItem.ExtentBook"), _
												    DataBinder.Eval(Container,"DataItem.ExtentMaco"), DataBinder.Eval(Container,"DataItem.ExtentMacete"),DataBinder.Eval(Container,"DataItem.ExtentFolder"),DataBinder.Eval(Container,"DataItem.ExtentCover"), _
													DataBinder.Eval(Container,"DataItem.Extentcapilha"), DataBinder.Eval(Container,"DataItem.ExtentRoll"),DataBinder.Eval(Container,"DataItem.ExtentBox"), _
													DataBinder.Eval(Container,"DataItem.ExtentEnvelope"),DataBinder.Eval(Container,"DataItem.ExtentAlbum"),DataBinder.Eval(Container,"DataItem.ExtentOther"))%>
												<%# strDraw2ColumnRow("m/l", DataBinder.Eval(Container,"DataItem.ExtentMl"))%>
												<%# strDimensions(DataBinder.Eval(Container,"DataItem.OtherLevel"),getlabel("WS.regShow.Dimensions"), DataBinder.Eval(Container,"DataItem.Dimensions"))%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.GenreForm"), DataBinder.Eval(Container,"DataItem.GenreForm"))%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.GeogName"), DataBinder.Eval(Container,"DataItem.GeogName"))%>
												<!Zona de contexto>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.OriginationAuthor"), DataBinder.Eval(Container,"DataItem.OriginationAuthor") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.OriginationAuthorAddress"), DataBinder.Eval(Container,"DataItem.OriginationAuthorAddress") )%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.OriginationDestination"), DataBinder.Eval(Container,"DataItem.OriginationDestination") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.OriginationDestinationAddress"), DataBinder.Eval(Container,"DataItem.OriginationDestinationAddress") )%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.OriginationScrivener"), DataBinder.Eval(Container,"DataItem.OriginationScrivener") )%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.OriginationNotary"), DataBinder.Eval(Container,"DataItem.OriginationNotary") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.BiogHist"), DataBinder.Eval(Container,"DataItem.BiogHist") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.CustodHist"), DataBinder.Eval(Container,"DataItem.CustodHist") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.AcqInfo"), DataBinder.Eval(Container,"DataItem.AcqInfo") )%>
												<! Zona de conteúdo e estrutura >
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.ScopeContent"), DataBinder.Eval(Container,"DataItem.ScopeContent") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.Arrangement"), DataBinder.Eval(Container,"DataItem.Arrangement") )%>
												<! Zona de condições de acesso e utilização>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.PhysLoc"), DataBinder.Eval(Container,"DataItem.PhysLoc") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.PhysFacet"), DataBinder.Eval(Container,"DataItem.PhysFacet") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.MaterialSpec"), DataBinder.Eval(Container,"DataItem.MaterialSpec") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.PhysTech"), DataBinder.Eval(Container,"DataItem.PhysTech") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.OtherFindAid"), DataBinder.Eval(Container,"DataItem.OtherFindAid") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.AccessRestrict"), DataBinder.Eval(Container,"DataItem.AccessRestrict") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.UseRestrict"), DataBinder.Eval(Container,"DataItem.UseRestrict") )%>
												<%# strDraw2ColumnRow(getlabel("WS.regShow.LangMaterial"), DataBinder.Eval(Container,"DataItem.LangMaterial") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.LegalStatus"), DataBinder.Eval(Container,"DataItem.LegalStatus") )%>
												<! Zona de documentos associados >
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.OriginalsLoc"), DataBinder.Eval(Container,"DataItem.OriginalsLoc") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.AltFormAvail"), DataBinder.Eval(Container,"DataItem.AltFormAvail") )%>
												<asp:Repeater ID="repDigitalObjectLoc" Runat="server">
													<HeaderTemplate>
														<%# strHeaderDigitalObjectsLoc %>
														<%# strDraw2ColumnRowTitle(getlabel("WS.regShow.ObjectDigital")) %>
													</HeaderTemplate>
													<ItemTemplate>
														<tr>
															<td><%# DataBinder.Eval(Container,"DataItem.DigitalObjectName") & " @ " & DataBinder.Eval(Container,"DataItem.FileName") & " @ " & DataBinder.Eval(Container,"DataItem.ArchiveID") & " @ " & DataBinder.Eval(Container,"DataItem.TopographicalQuota") %></td>
														</tr>
													</ItemTemplate>
													<FooterTemplate>
														<%# strFooterDigitalObjectsLoc %>
													</FooterTemplate>
												</asp:Repeater>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.RelatedMaterial"), DataBinder.Eval(Container,"DataItem.RelatedMaterial") )%>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.SeparatedMaterial"), DataBinder.Eval(Container,"DataItem.SeparatedMaterial") )%>
												<!Zona de notas>
												<%# strDraw2ColumnRowChangeLine(getlabel("WS.regShow.Note"), DataBinder.Eval(Container,"DataItem.Note") )%>
												<! Zona de controlo e descrição>
												<%# strDraw2ColumnRowChangeLine("URL ", "<span title='" & getlabel("WS.regShow.altURL") & "'>" & Request.Url.ToString().Replace("?", "?<br>") & "</span>" )%>
												<asp:Repeater ID="repDaoGrp" Runat="server">
													<HeaderTemplate>
														<tr>
															<td colspan="3" height="10px"></td>
														</tr>
														<tr class="lineLight">
															<td colspan="3"></td>
														</tr>
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
											<FooterTemplate>
												<%# strFooterTable %>
											</FooterTemplate>
										</asp:repeater>
									</DIV>
								</asp:panel>
							</TD>
						</tr>
						<tr align=center>
							<td>
								<asp:panel width=430px id="pnlAlert" Visible="False" Runat="server">
									<asp:Label id="lblAlert" CssClass="Alert" Runat="server"></asp:Label>
								</asp:panel>
							</td>
						</tr>
						<tr>
							<td class="vertical_spacer3"></td>
						</tr>
						<tr>
							<td align="center"><asp:hyperlink id="hlnkBack" Visible="True" Runat="server" CssClass="Button_1" Height="20px"></asp:hyperlink></td>
						</tr>
						<tr>
							<td class="vertical_spacer3"></td>
						</tr>
					</TBODY>
				</TABLE>
			</td>
		</tr>
	</TBODY>
</TABLE>
