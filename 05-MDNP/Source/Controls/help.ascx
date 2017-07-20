<%@ Control Language="vb" AutoEventWireup="false" Codebehind="help.ascx.vb" Inherits="WebSearch2.help" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="horizontalMenu" Src="../OtherControls/horizontalMenu.ascx" %>
<table width="750" cellpadding="0" cellspacing="0" border="0" align="center">
	<tr>
		<td class="vertical_spacer2" colSpan="3"></td>
	</tr>
	<TR>
		<TD width=300></TD>
		<TD width=20></TD>
		<TD width="430">
			<uc1:horizontalMenu id="HorizontalMenu1" runat="server"></uc1:horizontalMenu></TD>
	</TR>
	<tr>
		<td class="vertical_spacer2" colSpan="3"></td>
	</tr>
	<tr>
		<td width="300" align="left">
		</td>
		<td width="20"></td>
		<td width="430">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD class="HelpTitle">Auxiliar de pesquisa</TD>
					</TR>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<TR>
						<TD><a name="PAC"></a></TD>
					</TR>
					<TR>
						<TD><p>
								Encontra duas possibilidades de pesquisa: a pesquisa b�sica e a pesquisa 
								avan�ada. Se � a primeira vez que pretende consultar documentos neste Arquivo, 
								sugerimos que inicie a sua busca atrav�s da pesquisa b�sica.
							</p>
						</TD>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT1"><a name="PB">PESQUISA B�SICA</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="PB_Nomes">Nomes</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<p>Pesquisa na informa��o que identifica pessoas, empresas, institui��es e 
								servi�os.
							</p>
							<P>Se pretender efectuar uma pesquisa por uma express�o exacta deve escrever essa 
								express�o entre aspas("e").
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="PB_Locais">Locais</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<p>Pesquisa na informa��o espec�fica referente a localidades ou endere�os.
							</p>
							<P>Se pretender efectuar uma pesquisa por uma express�o exacta deve escrever essa 
								express�o entre aspas("e").
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="PB_Termos">Termos/palavras</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<p>Pesquisa noutros conte�dos da descri��o arquiv�stica (biografia, hist�ria, 
								fun��es, etc.), incluindo refer�ncias a outras pessoas, institui��es e locais.
							</p>
							<P>Se pretender efectuar uma pesquisa por uma express�o exacta deve escrever essa 
								express�o entre aspas("e").
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Exemplos</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<UL type="disc">
								<LI>
									<I>Se colocar <b>Manuel&nbsp;Ant�nio</b>&nbsp;no campo "Nomes", e&nbsp; <b>Porto&nbsp;</b>&nbsp;no 
										campo "Locais"&nbsp;obter� todos os registos que contenham&nbsp;os termos <B>Manuel</B>&nbsp;e
										<B>Ant�nio</B> nos campos referentes a Nomes e o termo&nbsp;<B>Porto</B> nos 
										campos referentes a Locais.</I><br>
								<LI>
									<I>Se colocar "<B>Manuel&nbsp;Ant�nio"</B>&nbsp;no campo "Nomes", e&nbsp;<B>Porto&nbsp;</B>&nbsp;no 
										campo "Locais"&nbsp;obter� todos os registos que contenham&nbsp;exactamente a 
										express�o&nbsp;"<B>Manuel&nbsp; Ant�nio</B>" nos campos referentes a Nomes e o 
										termo&nbsp;<B>Porto</B> nos campos referentes a Locais.</I>
								</LI>
							</UL>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="PB_Datas">Datas</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<P>Recupera informa��o atrav�s de par�metros cronol�gicos:</P>
							<UL type="disc">
								<LI>
									Se pretender uma <STRONG>data exacta</STRONG>, preencha todos os campos da data 
									inicial.<BR>
								<LI>
									Se indicar <B>apenas a data inicial incompleta </B>(sem o dia e/ou m�s), o 
									motor de pesquisa ir� recuperar todos os registos em que essa data se verifique 
									e os posteriores.<BR>
								<LI>
									Se indicar <B>apenas a data final</B>, o motor de pesquisa ir� recuperar todos 
									os registos em que essa data se verifique e os anteriores.<BR>
								<LI>
									Se indicar a <B>data inicial e a data final</B> o motor de pesquisa ir� 
									recuperar todos os registos que se situem entre essas datas.<br>
								<LI>
									Se indicar&nbsp;na <B>data inicial</B> (resp. <B>data final</B>) apenas o m�s 
									e/ou dia ir� recuperar todos os registos referentes � <B>data inicial</B> (resp.
									<B>data final</B>) desse m�s e/ou dia.</LI>
							</UL>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT1"><a name="PA">PESQUISA AVAN�ADA</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="ND">N�veis de descri��o</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<P>Os n�veis de descri��o correspondem � estrutura da descri��o arquiv�stica que 
								parte do geral � o fundo � para o particular � as diversas componentes ou 
								partes que comp�em o fundo.
							</P>
							<P>Consoante os n�veis de descri��o que seleccionar para a sua pesquisa, assim 
								encontrar� registos referentes a esses n�veis. Poder� encontrar os seguintes 
								n�veis de descri��o:
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td>
							<table cellpadding="0" cellspacing="0" border="0" class="Indent20">
								<tr>
									<td class="HelpT4">Fundo (F)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>� o n�vel mais importante. Um fundo � um conjunto de documentos criados 
											organicamente e/ou acumulados e utilizados por uma pessoa individual ou 
											colectiva no exerc�cio das suas fun��es e actividades.
										</P>
										<P>A determina��o de um fundo deve respeitar o princ�pio da proveni�ncia.
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Subfundo (SF)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>� um subn�vel do fundo. Correspondendo ao conjunto de documentos recebidos e 
											produzidos por uma unidade, org�nica ou funcional, da entidade produtora de um 
											fundo, e que detenha alguma autonomia para o exerc�cio das suas fun��es e 
											actividades.
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4"><u>Componentes de estrutura</u></td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Correspondem a divis�es de natureza org�nica � departamentos, servi�os, pessoas 
											� ou de natureza funcional � fun��es, actividades.
										</P>
										<P class="Indent20">Ex.: <I>Mamposteiro-Mor: servi�os;</I> <I>Jo�o de Figueiroa Pinto: 
												pessoas; Pris�o dos Calcetas: servi�os; Reparti��o de finan�as: departamentos; 
												Gest�o patrimonial: fun��o; Opera��es t�cnicas: fun��o;</I> <I>Gest�o de 
												pessoal: fun��o. </I>
										</P>
										<P>Estes n�veis s�o �contentores� de documenta��o, ou seja, os documentos f�sicos 
											existentes s�o classificados sob estes n�veis. S�o eles:</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Sec��o (SC)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Constitui uma subdivis�o org�nico e/ou funcional do FUNDO. Por exemplo um 
											departamento ou fun��o.
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Subsec��o (SSC)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Corresponde a uma subdivis�o org�nico e/ou funcional de uma SEC��O.
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Subsubsec��o (SSSC)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Corresponde a uma subdivis�o org�nico e/ou funcional de uma SUBSEC��O.
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4"><u>Componentes documentais</u></td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td><P>Estas componentes dizem directamente respeito aos documentos que integram um 
											fundo, tratando-os como classes ou agregados documentais (conjunto de 
											documentos tipologicamente id�nticos) e como unidades individuais. Como 
											conjuntos documentais temos:
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">S�rie (SR)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td><P>Corresponde a uma unidade arquiv�stica constitu�da por um conjunto de documentos 
											simples ou compostos a que, originalmente, foi dada uma ordena��o sequencial, 
											de acordo com um sistema de recupera��o da informa��o. Em princ�pio, os 
											documentos de cada s�rie dever�o corresponder ao exerc�cio de uma mesma fun��o 
											ou actividade, dentro da mesma �rea de actua��o.</P>
										<P class="Indent20">Ex.: <I>notas para escrituras diversas, registos de baptismo.</I>
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Subs�rie (SSR)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td><P>� uma subdivis�o da S�rie.</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td><P>Como <u><font class="HelpT4">unidades documentais</font></u> descritas temos:</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td class="HelpT4">Documento composto (DC)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Unidade organizada de documentos juntos, quer para utiliza��o corrente pelo seu 
											produtor, quer no decurso da organiza��o de um fundo, porque se referem a um 
											mesmo tema, actividade ou transac��o, sujeito a tramita��o pr�pria, normalmente 
											regulamentada.
										</P>
										<P class="Indent20">Ex.: <I>processo judicial, processo de execu��o, anteprojecto.</I>
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Documento simples (D)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>A mais pequena unidade arquiv�stica intelectualmente indivis�vel.
										</P>
										<P class="Indent20">Ex.: <I>uma escritura notarial, um registo de baptismo, um 
												lan�amento de conta corrente.</I></P>
										<P>Embora n�o sendo considerados n�veis de descri��o, podem existir, ainda, 
											unidades arquiv�sticas com fun��es primordiais de gest�o, de entre as quais 
											destacamos:
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Unidade de instala��o (UI)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>� a unidade b�sica de cota��o e instala��o de um FUNDO e das respectivas partes 
											f�sicas, por ex. livro, caixa, pasta. No entanto, quando corresponde a 
											conjuntos de documentos da mesma s�rie agrupados, � usada como um n�vel de 
											descri��o, sendo o objectivo facilitar o acesso � documenta��o pelo utilizador.
										</P>
										<P class="Indent20">Ex.: <I>Livro: �Livro de notas�: cont�m v�rias escrituras (logo, 
												v�rios documentos) lavrados por um not�rio. </I>
										</P>
										<P class="Indent20">Ex.: <i>Ma�o: �Correspond�ncia recebida�: agrupa os documentos 
												(cartas etc) recebidas de 1912 a 1913, no ma�o seguinte, de 1914 a 1915. </i>
										</P>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Referencia">Refer�ncia</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Este ponto pesquisa informa��o no campo do mesmo nome. A refer�ncia � um 
								conjunto de caracteres alfanum�ricos que identifica de forma �nica e inequ�voca 
								uma unidade de descri��o. Caso saiba o c�digo de refer�ncia do que pesquisa 
								este � o ponto de acesso mais eficaz. A refer�ncia pode ser&nbsp;completa ou 
								parcial.</P>
							<P class="Indent20">Ex. de refer�ncia completa:<br>
								<i>PT/ADPRT/NOT/CNPRT01/001/2025/00079 (recupera o Documento 00079 da unidade de 
									instala��o 2025 da s�rie 001 do Cart�rio Notarial do Porto, Primeiro Of�cio).</i>
							</P>
							<P class="Indent20">Ex. de refer�ncia parcial:<br>
								<I>PT/ADPRT/NOT/CNPRT01 ou simplesmente NOT/CNPRT01 (recupera todos os registos do 
									fundo NOT/CNPRT01).</I>
							</P>
							<p>Se clicar na seta <IMG src="Images/expands.gif" name="imgUnitTitleBooleanSearch">
								abrir-se-� uma caixa que possibilita a introdu��o de um segmento ou parte da 
								refer�ncia. Assim ser�o recuperados todos os registos que contenham na sua 
								refer�ncia esse segmento.</p>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="T�tulo">T�tulo</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Pesquisa no campo do mesmo nome um determinado t�tulo</P>
							<P class="Indent20">Ex.: <I>Registos de baptismos, Conta corrente, D�cima. </I>
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Datas">Datas</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Recupera informa��o atrav�s de par�metros cronol�gicos:</P>
							<UL type="disc">
								<LI>
									Se pretender uma <B>data exacta</B> preencha todos os campos da data inicial.
									<BR>
								<LI>
									Se indicar <B>apenas a data inicial incompleta </B>(sem o dia), o motor de 
									pesquisa ir� recuperar todos os registos em que essa data se verifique e os 
									posteriores.
									<BR>
								<LI>
									Se indicar <B>apenas a data final</B>, o motor de pesquisa ir� recuperar todos 
									os registos em que essa data se verifique e os anteriores.
									<BR>
								<LI>
									Se indicar a <B>data inicial e a data final</B> o motor de pesquisa ir� 
									recuperar todos os registos que se situem entre essas datas.<br>
								<LI>
									Se indicar na <B>data inicial</B> (resp. <B>data final</B>) apenas o m�s e/ou 
									dia ir� recuperar todos os registos referentes � <B>data inicial</B> (resp. <B>data 
										final</B>) desse m�s e/ou dia.
								</LI>
							</UL>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Autor_dest">Autor/destinat�rio</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Pesquisa informa��o nos campos autor e destinat�rio. Normalmente estes campos 
								apenas s�o preenchidos nos n�veis de descri��o unidade de instala��o, documento 
								composto e documento simples.</P>
							<P class="Indent20">Ex.: <I><EM>Jo�o de Figueiroa Pinto, E�a de Queir�s</EM></I></P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Localidade</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Refere-se � localiza��o geogr�fica onde foi produzido o documento ou onde o acto 
								que deu origem ao documento teve lugar.</P>
							<P class="Indent20">Ex.: <I>Porto, Barcelos, S�.</I></P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Outros_campos">Outros campos</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Pesquisa em v�rios campos da base de dados termos que n�o estejam contidos nos 
								campos acima indicados. Este � o melhor ponto de acesso para iniciar uma 
								pesquisa em que n�o se t�m ideias bem definidas.
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Termos_indexacao">Termos de indexa��o</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Os termos de indexa��o s�o palavras ou express�es controladas que permitem um 
								acesso mais eficaz � informa��o. A partir da caixa de selec��o poder� escolher 
								a �rea tem�tica dos termos de indexa��o existentes. Esta escolha remete para 
								uma lista de termos existentes que se enquadram na categoria que escolheu. Ao 
								seleccionar um termo este � automaticamente colocado na caixa inicial 
								permitindo-lhe ent�o iniciar a pesquisa.</P>
							<P>As categorias em que se inserem os termos de indexa��o s�o as seguintes:</P>
							<UL type="disc">
								<LI>
								actividades
								<LI>
								assuntos
								<LI>
								fam�lias
								<LI>
								fun��es
								<LI>
								localidades
								<LI>
								ocupa��es
								<LI>
								organiza��es
								<LI>
									pessoas
								</LI>
							</UL>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT2">Express�o exacta e operadores booleanos</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Express�o exacta: &lt;express�o exacta&gt;</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Se escolher esta op��o, o motor de pesquisa procura registos em que se verifique 
								a exist�ncia da&nbsp;express�o exacta.
							</P>
							<P class="Indent20">Ex.: <I>Campo &lt;Autor/Destinat�rio&gt;</I></P>
							<P class="Indent20"><IMG alt="" src="Images/helpExPE.gif" align="middle"></P>
							<P class="Indent20"><I>O motor de pesquisa ir� procurar registos onde apare�am estes 
									dois nomes simultaneamente. Retornar� os registos onde aparece a express�o 
									exacta �Jo�o Pereira�. </I>
							</P>
							<p>Para tornar a sua pesquisa mais eficaz, pode utilizar a pesquisa booleana que 
								associa de um modo espec�fico os termos que escolher para a pesquisa.
							</p>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Operador booleano E</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Funciona por defeito, na pesquisa avan�ada, quando insere mais do que um termo 
								para pesquisa num campo.
							</P>
							<P>Pode inserir informa��o em mais do que um campo e em cada um deles (refer�ncia, 
								t�tulo, autor/destinat�rio, localidade e outros campos), pode colocar mais do 
								que um termo para pesquisar. Nestes casos, o motor de pesquisa assume que 
								pretende encontrar registos em que se verifiquem simultaneamente os dados 
								inseridos (como se os termos inseridos estivessem associados por E � n�o deve 
								inserir esta part�cula).
							</P>
							<P class="Indent20">Ex.: <I>Se escolher no campo &lt;T�tulo&gt; o valor Baptismos e no 
									campo &lt;data inicial&gt; o valor de 1834, o motor de pesquisa ir� procurar 
									todos os registos que contenham a palavra Baptismos no ano de 1834 e seguintes. </I>
							</P>
							<P class="Indent20">Ex.: <I>Se colocar no campo &lt;Refer�ncia&gt; os valores CON e DIO 
									(ou PT/ADP/CON e PT/ADP/DIO) ir� procurar todos os registos que contenham CON e 
									DIO na refer�ncia. </I>
							</P>
							<P>Para alargar a pesquisa booleana a outras op��es, clique na seta <img src="Images/expands.gif" name="imgUnitTitleBooleanSearch">
								e insira os termos a pesquisar segundo as indica��es de associa��o dispon�veis. 
								� poss�vel efectuar este tipo de pesquisa na maior parte dos campos.
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Operador booleano OU : &lt;qualquer das palavras&gt;</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Se escolher esta associa��o, o motor de pesquisa procura registos em que se 
								verifiquem qualquer um dos valores pretendidos.
							</P>
							<P class="Indent20">Ex.: <I>Campo &lt;Autor/Destinat�rio&gt;</I></P>
							<P class="Indent20"><IMG alt="" src="Images/HelpExOR.gif"></P>
							<P class="Indent20"><I>O motor de pesquisa ir� procurar registos onde apare�am Jo�o ou 
									Pereira ou Maria ou da ou Silva. Se encontrar um registo em que apare�a Jo�o 
									Pereira mas n�o a Maria da Silva, o resultado ser� de um registo; se encontrar 
									um registo em que apare�a Jo�o Pereira e outro em que apare�a Maria da Silva o 
									resultado ser� de dois registos, etc. </I>
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Operador booleano N�O: &lt;excluindo as palavras&gt;</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Esta associa��o destina-se a excluir um determinado valor.
							</P>
							<P class="Indent20">Ex.: <I>Campo &lt;Autor/Destinat�rio&gt; escolher </I>
							</P>
							<P class="Indent20"><IMG alt="" src="Images/helpExNot.gif"></P>
							<P class="Indent20"><I>excluindo as palavras o motor de pesquisa ir� procurar registos 
									onde apare�a o nome de Jo�o Pereira e em que n�o apare�a o nome de Maria da 
									Silva. Retornar� todos os registos em que o autor/destinat�rio n�o possua Maria 
									nem Silva. Se encontrar um registo em que apare�a Jo�o Pereira juntamente com a 
									Maria da Silva, o resultado ser� nulo. </I>
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT1"><a name="RP">RESULTADOS DA PESQUISA</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<P class="HelpT1"><IMG alt="" src="Images/HelpItens.gif" width="430"></P>
							<P class="HelpT1"><IMG alt="" src="Images/HelpItensB.gif" width="430"></P>
							<P><STRONG><FONT color="#990000">A. </FONT></STRONG>Os resultados da pesquisa podem 
								ser ordenados de acordo com:</P>
							<p class="Indent20">a <STRONG>data</STRONG>: crit�rio cronol�gico em que os 
								registos s�o ordenados do mais antigo para o mais recente</p>
							<P class="Indent20"><IMG alt="Ordenar por data ascendentemente" src="Images/OBDateASC.gif">
								<IMG alt="Ordenar por t�tulo" src="Images/OBTitleInitial.gif"> <IMG alt="Ordenar por n�vel de descri��o" src="Images/OBOtherLevelInitial.gif"></P>
							<P class="Indent20">ou do mais recente para o mais antigo:</P>
							<P class="Indent20"><IMG alt="Ordenar por data descendentemente" src="Images/OBDateDESC.gif">
								<IMG alt="Ordenar por t�tulo" src="Images/OBTitleInitial.gif"> <IMG alt="Ordenar por n�vel de descri��o" src="Images/OBOtherLevelInitial.gif">
							<P class="Indent20">o <B>t�tulo:</B> em que os registos s�o ordenados 
								alfabeticamente a partir do t�tulo, ascendentemente:</P>
							<P class="Indent20"><IMG alt="Ordenar por data" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por t�tulo ascendentemente" src="Images/OBTitleASC.gif" hspace="0px">
								<IMG alt="Ordenar por n�vel" src="Images/OBOtherLevelInitial.gif"></P>
							<P class="Indent20">ou descendentemente:</P>
							<P class="Indent20"><IMG alt="Ordenar por n�vel" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por t�tulo descendemente" src="Images/OBTitleDESC.gif">
								<IMG alt="Ordenar por n�vel" src="Images/OBOtherLevelInitial.gif"></P>
							<P class="Indent20">o <B>n�vel: </B>os registos s�o ordenados do n�vel mais alto 
								para o mais baixo</P>
							<P class="Indent20">fundo -&gt; documento simples:</P>
							<P class="Indent20"><IMG alt="Ordenar por data" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por t�tulo" src="Images/OBTitleInitial.gif">
								<IMG alt="Ordenar por n�vel do F para D" src="Images/OBOtherLevelASC.gif"></P>
							<P class="Indent20">ou o inverso, documento simples �&gt; fundo:</P>
							<p class="Indent20"><IMG alt="Ordenar por data" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por t�tulo" src="Images/OBTitleInitial.gif">
								<IMG alt="Ordenar por n�vel do D para F" src="Images/OBOtherLevelDESC.gif"></p>
							<P><STRONG><FONT color="#990000">B. </FONT></STRONG>A listagem � numerada 
								sequencialmente. No topo da lista, indica-se quantos registos foram 
								encontrados.</P>
							<P><STRONG><FONT color="#990000">C. </FONT></STRONG>Para ter acesso � descri��o 
								completa de cada registo, clique sobre o c�digo de refer�ncia.
							</P>
							<P><STRONG><FONT color="#990000">D. </FONT></STRONG>No final, o n�mero de p�ginas 
								ocupadas pelo resultado da pesquisa, permite navegar entre elas.</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT1"><a name="DR">DESCRI��O DO RESULTADO</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P><img src="Images/RegDesc.gif" Width="430" align="middle"></ASP:IMAGE></P>
							<P><STRONG><FONT color="#660000">A.&nbsp;</FONT></STRONG>Representa��o em "�rvore" 
								do fundo onde se insere a informa��o, a partir da qual pode navegar nos 
								respectivos registos.</P>
							<P><STRONG><FONT color="#660000">B. </FONT></STRONG>Descri��o do registo 
								encontrado.</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
				</TBODY>
			</TABLE>
		</td>
	</tr>
	</TBODY>
</table>
