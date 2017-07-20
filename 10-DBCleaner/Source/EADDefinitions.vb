
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articulação com a Direcção-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordenação
'* informática da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Português.
'* ---------------------------------------------------
'*
'* A redistribuição e utilização deste produto sob a
'* forma de código-fonte ou programa compilado, com ou
'* sem modificações, é permitida desde que o seguinte
'* conjunto de condições seja cumprido:
'* 
'*	* Todas as redistribuições do código-fonte 
'*	  deste produto deverão ser acompanhadas do
'*	  texto que compõe esta licença, incluindo o 
'*	  texto inicial de atribuição de autoria,
'*	  esta lista de condições e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direcção-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto não deverão ser utilizados na 
'*	  promoção de produtos derivados deste 
'*	  sem que seja obtido consentimento prévio, por
'*	  escrito, por parte dos visados.

'*	* A utilização da designação DigitArq, seus 
'*	  logótipos e nomes institucionais associados
'*	  é apenas permitida em distribuições que sejam
'*	  cópias exactas da versão oficial deste produto
'*	  aprovada e/ou distribuída pela Direcção-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto é permitido desde que a designação 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais não sejam utilizados em todo e
'*	  qualquer tipo de distribuição e/ou promoção 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE É DISTRIBUIDO PELA DIRECÇÃO-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUNÇÃO DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS NÃO LIMITADO A, GARANTIAS ASSOCIADAS
'* A COMÉRCIO DE PRODUTOS OU DECLARAÇÃO DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNSTÂNCIA PODERÁ A DIRECÇÃO-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONSÁVEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZAÇÃO DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS NÃO LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FALÊNCIA, INDEVIDA PRESTAÇÃO DE SERVIÇOS
'* OU NEGLIGÊNCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORRÊNCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informação sobre este produto ou a sua 
'* licença, é favor consultar o endereço electrónico
'* http://www.digitarq.pt

#End Region

Module EADDefinitions
    Public Const OTHERLEVEL_FONDS As String = "F"
    Public Const OTHERLEVEL_SUBFONDS As String = "SF"
    Public Const OTHERLEVEL_SECTION As String = "SC"
    Public Const OTHERLEVEL_SUBSECTION As String = "SSC"
    Public Const OTHERLEVEL_SUBSUBSECTION As String = "SSSC"
    Public Const OTHERLEVEL_SERIES As String = "SR"
    Public Const OTHERLEVEL_SUBSERIES As String = "SSR"
    Public Const OTHERLEVEL_INSTALATIONUNIT As String = "UI"
    Public Const OTHERLEVEL_COMPOSEDDOCUMENT As String = "DC"
    Public Const OTHERLEVEL_DOCUMENT As String = "D"

    Public Const UNITID_NEW As String = "[novo]"

    Public Const XML_EADHEADER As String = "<eadheader> <eadid countrycode='pt' mainagencycode='adprt' url='http://www.adporto.org'/>" & _
        "<filedesc> <titlestmt> <titleproper/> <author>Arquivo Distrital do Porto</author> </titlestmt> <publicationstmt> " & _
        "<publisher>Arquivo Distrital do Porto</publisher> <date>© 2003</date> </publicationstmt> </filedesc> <profiledesc> " & _
        "<langusage>A descrição deste fundo encontra-se em <language>português</language>.</langusage>" & _
        "</profiledesc> </eadheader>"

    Public Const XML_EAD_NEW As String = "<ead>" & XML_EADHEADER & "<archdesc/> </ead>"


    Public Function GetOtherLevelIndex(ByVal OtherLevel As String) As Integer
        Select Case OtherLevel
            Case OTHERLEVEL_FONDS : Return 1
            Case OTHERLEVEL_SUBFONDS : Return 2
            Case OTHERLEVEL_SECTION : Return 3
            Case OTHERLEVEL_SUBSECTION : Return 4
            Case OTHERLEVEL_SUBSUBSECTION : Return 5
            Case OTHERLEVEL_SERIES : Return 6
            Case OTHERLEVEL_SUBSERIES : Return 7
            Case OTHERLEVEL_INSTALATIONUNIT : Return 8
            Case OTHERLEVEL_COMPOSEDDOCUMENT : Return 9
            Case OTHERLEVEL_DOCUMENT : Return 10
            Case Else : Return 0
        End Select
    End Function

    Public Function OtherLevelIndexToOtherLevel(ByVal OtherLevelIndex As Integer) As String
        Select Case OtherLevelIndex
            Case 1 : Return OTHERLEVEL_FONDS
            Case 2 : Return OTHERLEVEL_SUBFONDS
            Case 3 : Return OTHERLEVEL_SECTION
            Case 4 : Return OTHERLEVEL_SUBSECTION
            Case 5 : Return OTHERLEVEL_SUBSUBSECTION
            Case 6 : Return OTHERLEVEL_SERIES
            Case 7 : Return OTHERLEVEL_SUBSERIES
            Case 8 : Return OTHERLEVEL_INSTALATIONUNIT
            Case 9 : Return OTHERLEVEL_COMPOSEDDOCUMENT
            Case 10 : Return OTHERLEVEL_DOCUMENT
            Case Else : Return "Unknown"
        End Select
    End Function

End Module
