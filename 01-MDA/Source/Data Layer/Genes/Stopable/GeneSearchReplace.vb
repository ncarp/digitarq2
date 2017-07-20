
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


Public Class GeneSearchReplace
    Inherits StopableGene


    Private myProgressDialog As ProgressDialog
    Private myFieldName As String
    Private mySearchString As String
    Private myReplaceBy As String
    Private myRegExp As Boolean
    Private myCaseSensitive As Boolean
    Private myYesToAll As Boolean
    Private myProcessInfoName As String
    Private Const WindowSize As Integer = 5


    Public Sub New(ByVal ProgressDialog As ProgressDialog, ByVal FieldName As String, ByVal SearchString As String, ByVal ReplaceBy As String, ByVal CaseSensitive As Boolean, ByVal RegExp As Boolean, ByVal ProcessInfoName As String)
        myProgressDialog = ProgressDialog
        myFieldName = FieldName
        mySearchString = SearchString
        myReplaceBy = ReplaceBy
        myRegExp = RegExp
        myCaseSensitive = CaseSensitive
        myProcessInfoName = ProcessInfoName
        myYesToAll = False
    End Sub


    Public Overrides Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Collection) As Object
        Dim Ret As Integer = 0

        For Each ChildResult As Integer In ChildrenResults
            Ret += ChildResult
        Next

        If Me.StopCatamorfism Then Return Ret


        Dim SearchIn As String = CallByName(obj, myFieldName, CallType.Get)
        If isMatch(mySearchString, SearchIn, Not myCaseSensitive, myRegExp) Then
            Dim ReplacedString As String = Substitute(mySearchString, SearchIn, myReplaceBy, Not myCaseSensitive, myRegExp)

            If Not myYesToAll Then
                Dim Question As String = PrepareQuestion(mySearchString, SearchIn, myReplaceBy, ReplacedString, Not myCaseSensitive, myRegExp)
                Dim SearchReplaceQuestionDialog As New SearchReplaceQuestionForm(Question)
                Dim result As DialogResult = SearchReplaceQuestionDialog.ShowDialog()


                Select Case result
                    Case DialogResult.Cancel
                        Me.StopCatamorfism = True
                    Case DialogResult.Yes ' Yes to this Record
                        CallByName(obj, myFieldName, CallType.Set, ReplacedString)
                        obj.UpdateProcessInfo(myProcessInfoName)
                        obj.Upload()
                        Ret += 1
                    Case DialogResult.No
                        ' Do nothing
                    Case DialogResult.OK ' Yes to All
                        CallByName(obj, myFieldName, CallType.Set, ReplacedString)
                        obj.UpdateProcessInfo(myProcessInfoName)
                        obj.Upload()
                        myYesToAll = True
                End Select
            Else ' don't ask, just apply
                CallByName(obj, myFieldName, CallType.Set, ReplacedString)
                obj.UpdateProcessInfo(myProcessInfoName)
                obj.Upload()
                Ret += 1
            End If

        End If

        If Not myProgressDialog Is Nothing Then
            myProgressDialog.Message = String.Format(InfoMessage("SearchReplace.Progression"), obj.UnitId)
            myProgressDialog.Increment()
            If Not Me.StopCatamorfism Then Me.StopCatamorfism = myProgressDialog.Cancel
        End If

        Return Ret
    End Function


    Private Function Substitute(ByVal WhatToSearch As String, ByVal SearchIn As String, ByVal ReplaceBy As String, Optional ByVal IgnoreCase As Boolean = False, Optional ByVal RegExp As Boolean = False) As String
        Dim myRegOptions As RegexOptions = RegexOptions.Multiline Or RegexOptions.Compiled
        If IgnoreCase Then myRegOptions = myRegOptions Or RegexOptions.IgnoreCase
        If Not RegExp Then WhatToSearch = Regex.Escape(WhatToSearch)
        Return Regex.Replace(SearchIn, WhatToSearch, ReplaceBy, myRegOptions)
    End Function


    Private Function isMatch(ByVal WhatToSearch As String, ByVal SearchIn As String, Optional ByVal IgnoreCase As Boolean = False, Optional ByVal RegExp As Boolean = False) As Boolean
        Dim myRegOptions As RegexOptions = RegexOptions.Multiline Or RegexOptions.Compiled

        If IgnoreCase Then myRegOptions = myRegOptions Or RegexOptions.IgnoreCase
        If Not RegExp Then WhatToSearch = Regex.Escape(WhatToSearch)

        Return Regex.IsMatch(SearchIn, WhatToSearch, myRegOptions)
    End Function


    Private Function PrepareQuestion(ByVal WhatToSearch As String, ByVal SearchIn As String, ByVal ReplaceBy As String, ByVal ReplacedString As String, Optional ByVal IgnoreCase As Boolean = False, Optional ByVal RegExp As Boolean = False) As String

        Dim myRegOptions As RegexOptions = RegexOptions.Multiline
        If IgnoreCase Then myRegOptions = myRegOptions Or RegexOptions.IgnoreCase
        If Not RegExp Then WhatToSearch = Regex.Escape(WhatToSearch)

        Dim OldString As String = "..."
        Dim NewString As String = "..."
        Dim PreviousSubstitutionIncrement As Integer = 0
        Dim SubstitutionIncrement As Integer = 0

        Dim Match As Match = Regex.Match(SearchIn, WhatToSearch, myRegOptions)

        While (Match.Success)
            Dim startIndex As Integer = Math.Max(SearchIn.Substring(0, Math.Max(Match.Index - WindowSize, 0)).LastIndexOf(" "), 0)
            Dim windowStart As Integer = Match.Index + Match.Value.Length + WindowSize
            If windowStart >= SearchIn.Length Then windowStart = Match.Index + Match.Value.Length
            Dim endIndex As Integer = SearchIn.IndexOf(" ", windowStart)
            If endIndex < 0 Then endIndex = SearchIn.Length
            Dim length As Integer = endIndex - startIndex

            OldString &= SearchIn.Substring(startIndex, length) & "..."
            SubstitutionIncrement = Match.Result(ReplaceBy).Length - Match.Value.Length
            Dim NewStringStartIndex As Integer = Math.Max(0, startIndex + PreviousSubstitutionIncrement)
            Dim NewStringLength As Integer = Math.Min(length + SubstitutionIncrement, ReplacedString.Length - NewStringStartIndex)
            NewString &= ReplacedString.Substring(NewStringStartIndex, NewStringLength) & "..."
            PreviousSubstitutionIncrement = SubstitutionIncrement
            Match = Match.NextMatch()
        End While

        Return String.Format(InfoMessage("SearchReplace.Question"), OldString, NewString)
    End Function


End Class