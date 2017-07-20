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
								Encontra duas possibilidades de pesquisa: a pesquisa básica e a pesquisa 
								avançada. Se é a primeira vez que pretende consultar documentos neste Arquivo, 
								sugerimos que inicie a sua busca através da pesquisa básica.
							</p>
						</TD>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT1"><a name="PB">PESQUISA BÁSICA</a></td>
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
							<p>Pesquisa na informação que identifica pessoas, empresas, instituições e 
								serviços.
							</p>
							<P>Se pretender efectuar uma pesquisa por uma expressão exacta deve escrever essa 
								expressão entre aspas("e").
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
							<p>Pesquisa na informação específica referente a localidades ou endereços.
							</p>
							<P>Se pretender efectuar uma pesquisa por uma expressão exacta deve escrever essa 
								expressão entre aspas("e").
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
							<p>Pesquisa noutros conteúdos da descrição arquivística (biografia, história, 
								funções, etc.), incluindo referências a outras pessoas, instituições e locais.
							</p>
							<P>Se pretender efectuar uma pesquisa por uma expressão exacta deve escrever essa 
								expressão entre aspas("e").
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
									<I>Se colocar <b>Manuel&nbsp;António</b>&nbsp;no campo "Nomes", e&nbsp; <b>Porto&nbsp;</b>&nbsp;no 
										campo "Locais"&nbsp;obterá todos os registos que contenham&nbsp;os termos <B>Manuel</B>&nbsp;e
										<B>António</B> nos campos referentes a Nomes e o termo&nbsp;<B>Porto</B> nos 
										campos referentes a Locais.</I><br>
								<LI>
									<I>Se colocar "<B>Manuel&nbsp;António"</B>&nbsp;no campo "Nomes", e&nbsp;<B>Porto&nbsp;</B>&nbsp;no 
										campo "Locais"&nbsp;obterá todos os registos que contenham&nbsp;exactamente a 
										expressão&nbsp;"<B>Manuel&nbsp; António</B>" nos campos referentes a Nomes e o 
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
							<P>Recupera informação através de parâmetros cronológicos:</P>
							<UL type="disc">
								<LI>
									Se pretender uma <STRONG>data exacta</STRONG>, preencha todos os campos da data 
									inicial.<BR>
								<LI>
									Se indicar <B>apenas a data inicial incompleta </B>(sem o dia e/ou mês), o 
									motor de pesquisa irá recuperar todos os registos em que essa data se verifique 
									e os posteriores.<BR>
								<LI>
									Se indicar <B>apenas a data final</B>, o motor de pesquisa irá recuperar todos 
									os registos em que essa data se verifique e os anteriores.<BR>
								<LI>
									Se indicar a <B>data inicial e a data final</B> o motor de pesquisa irá 
									recuperar todos os registos que se situem entre essas datas.<br>
								<LI>
									Se indicar&nbsp;na <B>data inicial</B> (resp. <B>data final</B>) apenas o mês 
									e/ou dia irá recuperar todos os registos referentes à <B>data inicial</B> (resp.
									<B>data final</B>) desse mês e/ou dia.</LI>
							</UL>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT1"><a name="PA">PESQUISA AVANÇADA</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="ND">Níveis de descrição</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td>
							<P>Os níveis de descrição correspondem à estrutura da descrição arquivística que 
								parte do geral – o fundo – para o particular – as diversas componentes ou 
								partes que compõem o fundo.
							</P>
							<P>Consoante os níveis de descrição que seleccionar para a sua pesquisa, assim 
								encontrará registos referentes a esses níveis. Poderá encontrar os seguintes 
								níveis de descrição:
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
										<P>É o nível mais importante. Um fundo é um conjunto de documentos criados 
											organicamente e/ou acumulados e utilizados por uma pessoa individual ou 
											colectiva no exercício das suas funções e actividades.
										</P>
										<P>A determinação de um fundo deve respeitar o princípio da proveniência.
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
										<P>É um subnível do fundo. Correspondendo ao conjunto de documentos recebidos e 
											produzidos por uma unidade, orgânica ou funcional, da entidade produtora de um 
											fundo, e que detenha alguma autonomia para o exercício das suas funções e 
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
										<P>Correspondem a divisões de natureza orgânica – departamentos, serviços, pessoas 
											– ou de natureza funcional – funções, actividades.
										</P>
										<P class="Indent20">Ex.: <I>Mamposteiro-Mor: serviços;</I> <I>João de Figueiroa Pinto: 
												pessoas; Prisão dos Calcetas: serviços; Repartição de finanças: departamentos; 
												Gestão patrimonial: função; Operações técnicas: função;</I> <I>Gestão de 
												pessoal: função. </I>
										</P>
										<P>Estes níveis são “contentores” de documentação, ou seja, os documentos físicos 
											existentes são classificados sob estes níveis. São eles:</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Secção (SC)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Constitui uma subdivisão orgânico e/ou funcional do FUNDO. Por exemplo um 
											departamento ou função.
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Subsecção (SSC)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Corresponde a uma subdivisão orgânico e/ou funcional de uma SECÇÃO.
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Subsubsecção (SSSC)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>Corresponde a uma subdivisão orgânico e/ou funcional de uma SUBSECÇÃO.
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
											documentos tipologicamente idênticos) e como unidades individuais. Como 
											conjuntos documentais temos:
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Série (SR)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td><P>Corresponde a uma unidade arquivística constituída por um conjunto de documentos 
											simples ou compostos a que, originalmente, foi dada uma ordenação sequencial, 
											de acordo com um sistema de recuperação da informação. Em princípio, os 
											documentos de cada série deverão corresponder ao exercício de uma mesma função 
											ou actividade, dentro da mesma área de actuação.</P>
										<P class="Indent20">Ex.: <I>notas para escrituras diversas, registos de baptismo.</I>
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Subsérie (SSR)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td><P>É uma subdivisão da Série.</P>
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
										<P>Unidade organizada de documentos juntos, quer para utilização corrente pelo seu 
											produtor, quer no decurso da organização de um fundo, porque se referem a um 
											mesmo tema, actividade ou transacção, sujeito a tramitação própria, normalmente 
											regulamentada.
										</P>
										<P class="Indent20">Ex.: <I>processo judicial, processo de execução, anteprojecto.</I>
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
										<P>A mais pequena unidade arquivística intelectualmente indivisível.
										</P>
										<P class="Indent20">Ex.: <I>uma escritura notarial, um registo de baptismo, um 
												lançamento de conta corrente.</I></P>
										<P>Embora não sendo considerados níveis de descrição, podem existir, ainda, 
											unidades arquivísticas com funções primordiais de gestão, de entre as quais 
											destacamos:
										</P>
									</td>
								</tr>
								<tr>
									<td class="vertical_spacer3"></td>
								</tr>
								<tr>
									<td class="HelpT4">Unidade de instalação (UI)</td>
								</tr>
								<tr>
									<td class="vertical_spacer2"></td>
								</tr>
								<tr>
									<td>
										<P>É a unidade básica de cotação e instalação de um FUNDO e das respectivas partes 
											físicas, por ex. livro, caixa, pasta. No entanto, quando corresponde a 
											conjuntos de documentos da mesma série agrupados, é usada como um nível de 
											descrição, sendo o objectivo facilitar o acesso à documentação pelo utilizador.
										</P>
										<P class="Indent20">Ex.: <I>Livro: “Livro de notas”: contém várias escrituras (logo, 
												vários documentos) lavrados por um notário. </I>
										</P>
										<P class="Indent20">Ex.: <i>Maço: “Correspondência recebida”: agrupa os documentos 
												(cartas etc) recebidas de 1912 a 1913, no maço seguinte, de 1914 a 1915. </i>
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
						<td class="HelpT3"><a name="Referencia">Referência</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Este ponto pesquisa informação no campo do mesmo nome. A referência é um 
								conjunto de caracteres alfanuméricos que identifica de forma única e inequívoca 
								uma unidade de descrição. Caso saiba o código de referência do que pesquisa 
								este é o ponto de acesso mais eficaz. A referência pode ser&nbsp;completa ou 
								parcial.</P>
							<P class="Indent20">Ex. de referência completa:<br>
								<i>PT/ADPRT/NOT/CNPRT01/001/2025/00079 (recupera o Documento 00079 da unidade de 
									instalação 2025 da série 001 do Cartório Notarial do Porto, Primeiro Ofício).</i>
							</P>
							<P class="Indent20">Ex. de referência parcial:<br>
								<I>PT/ADPRT/NOT/CNPRT01 ou simplesmente NOT/CNPRT01 (recupera todos os registos do 
									fundo NOT/CNPRT01).</I>
							</P>
							<p>Se clicar na seta <IMG src="Images/expands.gif" name="imgUnitTitleBooleanSearch">
								abrir-se-á uma caixa que possibilita a introdução de um segmento ou parte da 
								referência. Assim serão recuperados todos os registos que contenham na sua 
								referência esse segmento.</p>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Título">Título</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Pesquisa no campo do mesmo nome um determinado título</P>
							<P class="Indent20">Ex.: <I>Registos de baptismos, Conta corrente, Décima. </I>
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
						<td><P>Recupera informação através de parâmetros cronológicos:</P>
							<UL type="disc">
								<LI>
									Se pretender uma <B>data exacta</B> preencha todos os campos da data inicial.
									<BR>
								<LI>
									Se indicar <B>apenas a data inicial incompleta </B>(sem o dia), o motor de 
									pesquisa irá recuperar todos os registos em que essa data se verifique e os 
									posteriores.
									<BR>
								<LI>
									Se indicar <B>apenas a data final</B>, o motor de pesquisa irá recuperar todos 
									os registos em que essa data se verifique e os anteriores.
									<BR>
								<LI>
									Se indicar a <B>data inicial e a data final</B> o motor de pesquisa irá 
									recuperar todos os registos que se situem entre essas datas.<br>
								<LI>
									Se indicar na <B>data inicial</B> (resp. <B>data final</B>) apenas o mês e/ou 
									dia irá recuperar todos os registos referentes à <B>data inicial</B> (resp. <B>data 
										final</B>) desse mês e/ou dia.
								</LI>
							</UL>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Autor_dest">Autor/destinatário</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Pesquisa informação nos campos autor e destinatário. Normalmente estes campos 
								apenas são preenchidos nos níveis de descrição unidade de instalação, documento 
								composto e documento simples.</P>
							<P class="Indent20">Ex.: <I><EM>João de Figueiroa Pinto, Eça de Queirós</EM></I></P>
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
						<td><P>Refere-se à localização geográfica onde foi produzido o documento ou onde o acto 
								que deu origem ao documento teve lugar.</P>
							<P class="Indent20">Ex.: <I>Porto, Barcelos, Sé.</I></P>
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
						<td><P>Pesquisa em vários campos da base de dados termos que não estejam contidos nos 
								campos acima indicados. Este é o melhor ponto de acesso para iniciar uma 
								pesquisa em que não se têm ideias bem definidas.
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3"><a name="Termos_indexacao">Termos de indexação</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Os termos de indexação são palavras ou expressões controladas que permitem um 
								acesso mais eficaz à informação. A partir da caixa de selecção poderá escolher 
								a área temática dos termos de indexação existentes. Esta escolha remete para 
								uma lista de termos existentes que se enquadram na categoria que escolheu. Ao 
								seleccionar um termo este é automaticamente colocado na caixa inicial 
								permitindo-lhe então iniciar a pesquisa.</P>
							<P>As categorias em que se inserem os termos de indexação são as seguintes:</P>
							<UL type="disc">
								<LI>
								actividades
								<LI>
								assuntos
								<LI>
								famílias
								<LI>
								funções
								<LI>
								localidades
								<LI>
								ocupações
								<LI>
								organizações
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
						<td class="HelpT2">Expressão exacta e operadores booleanos</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Expressão exacta: &lt;expressão exacta&gt;</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Se escolher esta opção, o motor de pesquisa procura registos em que se verifique 
								a existência da&nbsp;expressão exacta.
							</P>
							<P class="Indent20">Ex.: <I>Campo &lt;Autor/Destinatário&gt;</I></P>
							<P class="Indent20"><IMG alt="" src="Images/helpExPE.gif" align="middle"></P>
							<P class="Indent20"><I>O motor de pesquisa irá procurar registos onde apareçam estes 
									dois nomes simultaneamente. Retornará os registos onde aparece a expressão 
									exacta ”João Pereira”. </I>
							</P>
							<p>Para tornar a sua pesquisa mais eficaz, pode utilizar a pesquisa booleana que 
								associa de um modo específico os termos que escolher para a pesquisa.
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
						<td><P>Funciona por defeito, na pesquisa avançada, quando insere mais do que um termo 
								para pesquisa num campo.
							</P>
							<P>Pode inserir informação em mais do que um campo e em cada um deles (referência, 
								título, autor/destinatário, localidade e outros campos), pode colocar mais do 
								que um termo para pesquisar. Nestes casos, o motor de pesquisa assume que 
								pretende encontrar registos em que se verifiquem simultaneamente os dados 
								inseridos (como se os termos inseridos estivessem associados por E – não deve 
								inserir esta partícula).
							</P>
							<P class="Indent20">Ex.: <I>Se escolher no campo &lt;Título&gt; o valor Baptismos e no 
									campo &lt;data inicial&gt; o valor de 1834, o motor de pesquisa irá procurar 
									todos os registos que contenham a palavra Baptismos no ano de 1834 e seguintes. </I>
							</P>
							<P class="Indent20">Ex.: <I>Se colocar no campo &lt;Referência&gt; os valores CON e DIO 
									(ou PT/ADP/CON e PT/ADP/DIO) irá procurar todos os registos que contenham CON e 
									DIO na referência. </I>
							</P>
							<P>Para alargar a pesquisa booleana a outras opções, clique na seta <img src="Images/expands.gif" name="imgUnitTitleBooleanSearch">
								e insira os termos a pesquisar segundo as indicações de associação disponíveis. 
								É possível efectuar este tipo de pesquisa na maior parte dos campos.
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
						<td><P>Se escolher esta associação, o motor de pesquisa procura registos em que se 
								verifiquem qualquer um dos valores pretendidos.
							</P>
							<P class="Indent20">Ex.: <I>Campo &lt;Autor/Destinatário&gt;</I></P>
							<P class="Indent20"><IMG alt="" src="Images/HelpExOR.gif"></P>
							<P class="Indent20"><I>O motor de pesquisa irá procurar registos onde apareçam João ou 
									Pereira ou Maria ou da ou Silva. Se encontrar um registo em que apareça João 
									Pereira mas não a Maria da Silva, o resultado será de um registo; se encontrar 
									um registo em que apareça João Pereira e outro em que apareça Maria da Silva o 
									resultado será de dois registos, etc. </I>
							</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT3">Operador booleano NÃO: &lt;excluindo as palavras&gt;</td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P>Esta associação destina-se a excluir um determinado valor.
							</P>
							<P class="Indent20">Ex.: <I>Campo &lt;Autor/Destinatário&gt; escolher </I>
							</P>
							<P class="Indent20"><IMG alt="" src="Images/helpExNot.gif"></P>
							<P class="Indent20"><I>excluindo as palavras o motor de pesquisa irá procurar registos 
									onde apareça o nome de João Pereira e em que não apareça o nome de Maria da 
									Silva. Retornará todos os registos em que o autor/destinatário não possua Maria 
									nem Silva. Se encontrar um registo em que apareça João Pereira juntamente com a 
									Maria da Silva, o resultado será nulo. </I>
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
							<p class="Indent20">a <STRONG>data</STRONG>: critério cronológico em que os 
								registos são ordenados do mais antigo para o mais recente</p>
							<P class="Indent20"><IMG alt="Ordenar por data ascendentemente" src="Images/OBDateASC.gif">
								<IMG alt="Ordenar por título" src="Images/OBTitleInitial.gif"> <IMG alt="Ordenar por nível de descrição" src="Images/OBOtherLevelInitial.gif"></P>
							<P class="Indent20">ou do mais recente para o mais antigo:</P>
							<P class="Indent20"><IMG alt="Ordenar por data descendentemente" src="Images/OBDateDESC.gif">
								<IMG alt="Ordenar por título" src="Images/OBTitleInitial.gif"> <IMG alt="Ordenar por nível de descrição" src="Images/OBOtherLevelInitial.gif">
							<P class="Indent20">o <B>título:</B> em que os registos são ordenados 
								alfabeticamente a partir do título, ascendentemente:</P>
							<P class="Indent20"><IMG alt="Ordenar por data" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por título ascendentemente" src="Images/OBTitleASC.gif" hspace="0px">
								<IMG alt="Ordenar por nível" src="Images/OBOtherLevelInitial.gif"></P>
							<P class="Indent20">ou descendentemente:</P>
							<P class="Indent20"><IMG alt="Ordenar por nível" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por título descendemente" src="Images/OBTitleDESC.gif">
								<IMG alt="Ordenar por nével" src="Images/OBOtherLevelInitial.gif"></P>
							<P class="Indent20">o <B>nível: </B>os registos são ordenados do nível mais alto 
								para o mais baixo</P>
							<P class="Indent20">fundo -&gt; documento simples:</P>
							<P class="Indent20"><IMG alt="Ordenar por data" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por título" src="Images/OBTitleInitial.gif">
								<IMG alt="Ordenar por nível do F para D" src="Images/OBOtherLevelASC.gif"></P>
							<P class="Indent20">ou o inverso, documento simples –&gt; fundo:</P>
							<p class="Indent20"><IMG alt="Ordenar por data" src="Images/OBDateInitial.gif"> <IMG alt="Ordenar por título" src="Images/OBTitleInitial.gif">
								<IMG alt="Ordenar por nível do D para F" src="Images/OBOtherLevelDESC.gif"></p>
							<P><STRONG><FONT color="#990000">B. </FONT></STRONG>A listagem é numerada 
								sequencialmente. No topo da lista, indica-se quantos registos foram 
								encontrados.</P>
							<P><STRONG><FONT color="#990000">C. </FONT></STRONG>Para ter acesso à descrição 
								completa de cada registo, clique sobre o código de referência.
							</P>
							<P><STRONG><FONT color="#990000">D. </FONT></STRONG>No final, o número de páginas 
								ocupadas pelo resultado da pesquisa, permite navegar entre elas.</P>
						</td>
					</tr>
					<tr>
						<td class="vertical_spacer3"></td>
					</tr>
					<tr>
						<td class="HelpT1"><a name="DR">DESCRIÇÃO DO RESULTADO</a></td>
					</tr>
					<tr>
						<td class="vertical_spacer2"></td>
					</tr>
					<tr>
						<td><P><img src="Images/RegDesc.gif" Width="430" align="middle"></ASP:IMAGE></P>
							<P><STRONG><FONT color="#660000">A.&nbsp;</FONT></STRONG>Representação em "árvore" 
								do fundo onde se insere a informação, a partir da qual pode navegar nos 
								respectivos registos.</P>
							<P><STRONG><FONT color="#660000">B. </FONT></STRONG>Descrição do registo 
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
