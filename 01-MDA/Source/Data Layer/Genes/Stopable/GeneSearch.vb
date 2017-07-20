
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