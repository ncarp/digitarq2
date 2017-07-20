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
							Os dados que indicar na interface (formul�rio) ser�o procurados nessa base e 
							ser-lhe-�o apresentados.
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
								Caso os termos que indicou n�o existam, na sua forma exacta, n�o ser� 
								recuperado qualquer registo.
								<BR>
								Exemplos:
							</LI>
						</OL>
						<BLOCKQUOTE>
							<UL>
								<LI>
									Se escrever o termo <I>paroquial</I> encontrar� apenas alguns registos 
									referentes �s par�quias, mas se escrever o termo <I>par�quia</I> a sua pesquisa 
									retornar� TODOS os n�cleos documentais paroquiais.
								</LI>
							</UL>
							<UL>
								<LI>
									Se escrever o termo <I>not�rio</I>, provavelmente os resultados ser�o nulos, 
									mas se escrever <I>notarial</I> recuperar� todos os registos relativos a 
									cart�rios notariais
								</LI>
							</UL>
						</BLOCKQUOTE>
						<OL>
							<LI value="2">
								<P>Se pretender uma pesquisa de um termo ou conjunto de termos exactos, dever� 
									assinalar essa op��o na caixa "Com a frase exacta", que � mostrada quando se 
									clica na seta<IMG alt="Expandir" src="Images/expands.gif">&nbsp;que se encontra 
									� frente de cada campo de pesquisa.<BR>
									Exemplo:
								</P>
							</LI>
						</OL>
						<UL>
							<UL>
								<LI>
									Se pretender recuperar o nome <I>Jo�o da Silva</I> e n�o qualquer nome que 
									contenha <I>Jo�o</I> ou <I>Silva</I>&nbsp;
								</LI>
							</UL>
						</UL>
						<OL>
							<LI value="3">
								� obrigat�rio assinalar o(s) n�vel(is) de descri��o onde pretende que seja 
								efectuada a pesquisa. Caso tenha d�vidas sobre o n�vel que pretende escolha a 
								op��o "Todos".</LI></OL>
					</TD>
				</TR>
				<TR>
					<TD class="TextBlue">Para mais informa��es consulte o
						<asp:hyperlink id="HyperLink1" NavigateUrl="../default.aspx?page=help&searchMode=hlp" runat="server">auxiliar de pesquisa</asp:hyperlink>.<BR>
						</FONT></TD>
				</TR>
				<tr>
					<td class="vertical_spacer3"></td>
				</tr>
				<TR>
					<TD>
						<P><B><SPAN style="COLOR: red">AVISO IMPORTANTE</SPAN></B></P>
						<P>Nesta base de dados as descri��es que <b>n�o foram ainda submetidas a controlo e 
						tratamento t�cnico arquiv�stico</b> est�o assinalados com o s�mbolo <IMG alt="Alerta" src="Images/Alert.gif">. Significa 
						que, embora a informa��o esteja dispon�vel, � poss�vel que, em 
						alguns casos, apresente eventuais inexactid�es, omiss�es ou erros. Trata-se de 
						informa��o n�o validada pelos t�cnicos de arquivo.
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
						<IMG alt="Direc��o-Geral de Arquivos" src="Images/DigitArq.png"><b>&nbsp;&nbsp;� Arquivo Distrital do Porto</b>
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
