
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

Imports System.Text.RegularExpressions


Public Class GeneSearch
    Inherits StopableGene


    Private myProgressDialog As ProgressDialog
    Private myFieldName As String
    Private mySearchString As String
    Private myReplaceBy As String
    Private myRegExp As Boolean
    Private myCaseSensitive As Boolean
    Private CONTROLACCESS_FIELD_NAME As String = "ControlAccess"


    Public Sub New(ByVal ProgressDialog As ProgressDialog, ByVal FieldName As String, ByVal SearchString As String, ByVal CaseSensitive As Boolean, ByVal RegExp As Boolean)
        myProgressDialog = ProgressDialog
        myFieldName = FieldName
        mySearchString = SearchString
        myRegExp = RegExp
        myCaseSensitive = CaseSensitive
    End Sub


    Public Overrides Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Collection) As Object
        Dim Ret As New LazyNodeCollection

        For Each col As LazyNodeCollection In ChildrenResults
            For Each Node As LazyNode In col
                Ret.Add(Node)
            Next
        Next

        If Me.StopCatamorfism Then Return Ret

        If Not myProgressDialog Is Nothing Then
            myProgressDialog.Message = String.Format(InfoMessage("Search.Progression"), obj.UnitId)
            myProgressDialog.Increment()
            Me.StopCatamorfism = myProgressDialog.Cancel
        End If

        'updated by lmferros
        If myFieldName = CONTROLACCESS_FIELD_NAME Then
            For Each cai As ControlAccessItem In obj.ControlAccess
                If isMatch(mySearchString, cai.Item, Not myCaseSensitive, myRegExp) Then
                    Ret.Add(obj)
                End If
            Next
        Else
            Dim SearchIn As String = CallByName(obj, myFieldName, CallType.Get)
            If isMatch(mySearchString, SearchIn, Not myCaseSensitive, myRegExp) Then
                Ret.Add(obj)
            End If
        End If

        Return Ret
    End Function


    Private Function isMatch(ByVal WhatToSearch As String, ByVal SearchIn As String, Optional ByVal IgnoreCase As Boolean = False, Optional ByVal RegExp As Boolean = False) As Boolean
        Dim myRegOptions As RegexOptions = RegexOptions.Multiline

        If IgnoreCase Then myRegOptions = myRegOptions Or RegexOptions.IgnoreCase
        If Not RegExp Then WhatToSearch = Regex.Escape(WhatToSearch)

        Return Regex.IsMatch(SearchIn, WhatToSearch, myRegOptions)
    End Function


End Class