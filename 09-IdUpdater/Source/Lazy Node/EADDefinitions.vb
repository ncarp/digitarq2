
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articula��o com a Direc��o-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordena��o
'* inform�tica da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Portugu�s.
'* ---------------------------------------------------
'*
'* A redistribui��o e utiliza��o deste produto sob a
'* forma de c�digo-fonte ou programa compilado, com ou
'* sem modifica��es, � permitida desde que o seguinte
'* conjunto de condi��es seja cumprido:
'* 
'*	* Todas as redistribui��es do c�digo-fonte 
'*	  deste produto dever�o ser acompanhadas do
'*	  texto que comp�e esta licen�a, incluindo o 
'*	  texto inicial de atribui��o de autoria,
'*	  esta lista de condi��es e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direc��o-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto n�o dever�o ser utilizados na 
'*	  promo��o de produtos derivados deste 
'*	  sem que seja obtido consentimento pr�vio, por
'*	  escrito, por parte dos visados.

'*	* A utiliza��o da designa��o DigitArq, seus 
'*	  log�tipos e nomes institucionais associados
'*	  � apenas permitida em distribui��es que sejam
'*	  c�pias exactas da vers�o oficial deste produto
'*	  aprovada e/ou distribu�da pela Direc��o-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto � permitido desde que a designa��o 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais n�o sejam utilizados em todo e
'*	  qualquer tipo de distribui��o e/ou promo��o 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE � DISTRIBUIDO PELA DIREC��O-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUN��O DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS N�O LIMITADO A, GARANTIAS ASSOCIADAS
'* A COM�RCIO DE PRODUTOS OU DECLARA��O DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNST�NCIA PODER� A DIREC��O-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONS�VEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZA��O DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS N�O LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FAL�NCIA, INDEVIDA PRESTA��O DE SERVI�OS
'* OU NEGLIG�NCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORR�NCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informa��o sobre este produto ou a sua 
'* licen�a, � favor consultar o endere�o electr�nico
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
        "<publisher>Arquivo Distrital do Porto</publisher> <date>� 2003</date> </publicationstmt> </filedesc> <profiledesc> " & _
        "<langusage>A descri��o deste fundo encontra-se em <language>portugu�s</language>.</langusage>" & _
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
