<%@ Control Language="vb" AutoEventWireup="false" Codebehind="introduction.ascx.vb" Inherits="WebSearch2.introduction" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
	<tr valign="top">
		<td width="300">
			<DIV id="object1" style="Z-INDEX: 2; POSITION: absolute">
				<table cellSpacing="0" cellPadding="0" width="250" border="0">
					<tr>
						<td><A onmouseover="MM_swapImage('imglink','','Images/Shearch2.gif',1)" tabIndex="-1" onmouseout="MM_swapImgRestore()"
								href="default.aspx?page=basicSearch&searchMode=bs"><IMG src="Images/Shearch.gif" name="imglink"></A>
						</td>
					</tr>
				</table>
			</DIV>
		</td>
		<td width="20"></td>
		<td width="430">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD>
						<P>A pesquisa que pretende efectuar vai ser feita numa base de dados centralizada. 
							Os dados que indicar na interface (formulário) serão procurados nessa base e 
							ser-lhe-ão apresentados.
						</P>
					</TD>
				</TR>
				<tr>
					<td class="vertical_spacer3"></td>
				</tr>
				<TR>
					<TD class="Title">Note que</TD>
				</TR>
				<TR>
					<TD>
						<OL>
							<LI>
								Caso os termos que indicou não existam, na sua forma exacta, não será 
								recuperado qualquer registo.
								<BR>
								Exemplos:
							</LI>
						</OL>
						<BLOCKQUOTE>
							<UL>
								<LI>
									Se escrever o termo <I>paroquial</I> encontrará apenas alguns registos 
									referentes às paróquias, mas se escrever o termo <I>paróquia</I> a sua pesquisa 
									retornará TODOS os núcleos documentais paroquiais.
								</LI>
							</UL>
							<UL>
								<LI>
									Se escrever o termo <I>notário</I>, provavelmente os resultados serão nulos, 
									mas se escrever <I>notarial</I> recuperará todos os registos relativos a 
									cartórios notariais
								</LI>
							</UL>
						</BLOCKQUOTE>
						<OL>
							<LI value="2">
								<P>Se pretender uma pesquisa de um termo ou conjunto de termos exactos, deverá 
									assinalar essa opção na caixa "Com a frase exacta", que é mostrada quando se 
									clica na seta<IMG alt="Expandir" src="Images/expands.gif">&nbsp;que se encontra 
									à frente de cada campo de pesquisa.<BR>
									Exemplo:
								</P>
							</LI>
						</OL>
						<UL>
							<UL>
								<LI>
									Se pretender recuperar o nome <I>João da Silva</I> e não qualquer nome que 
									contenha <I>João</I> ou <I>Silva</I>&nbsp;
								</LI>
							</UL>
						</UL>
						<OL>
							<LI value="3">
								É obrigatório assinalar o(s) nível(is) de descrição onde pretende que seja 
								efectuada a pesquisa. Caso tenha dúvidas sobre o nível que pretende escolha a 
								opção "Todos".</LI></OL>
					</TD>
				</TR>
				<TR>
					<TD class="TextBlue">Para mais informações consulte o
						<asp:hyperlink id="HyperLink1" NavigateUrl="../default.aspx?page=help&searchMode=hlp" runat="server">auxiliar de pesquisa</asp:hyperlink>.<BR>
						</FONT></TD>
				</TR>
				<tr>
					<td class="vertical_spacer3"></td>
				</tr>
				<TR>
					<TD>
						<P><B><SPAN style="COLOR: red">AVISO IMPORTANTE</SPAN></B></P>
						<P>Nesta base de dados as descrições que <b>não foram ainda submetidas a controlo e 
						tratamento técnico arquivístico</b> estão assinalados com o símbolo <IMG alt="Alerta" src="Images/Alert.gif">. Significa 
						que, embora a informação esteja disponível, é possível que, em 
						alguns casos, apresente eventuais inexactidões, omissões ou erros. Trata-se de 
						informação não validada pelos técnicos de arquivo.
					</TD>
				</TR>
				<tr>
					<td class="vertical_spacer2"></td>
				</tr>
				<tr>
					<td class="line"></td>
				</tr>
				<tr>
					<td class="vertical_spacer2"></td>
				</tr>
				<TR>
					<TD class=Center>
						<IMG alt="Direcção-Geral de Arquivos" src="Images/DigitArq.png"><b>&nbsp;&nbsp;© Arquivo Distrital do Porto</b>
					</td>
				</tr>
				<tr>
					<td class="vertical_spacer2"></td>
				</tr>
				<tr>
					<td class=Center><b>Desenvolvido com financiamento de:</b></td>
				</tr>
				<tr>
					<td class=Center><IMG alt="" src="Images/sponsors.png"></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
