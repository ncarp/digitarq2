
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
Imports System.Threading

Public Class Validator

#Region "Properties definition"

    Public Enum ExtremeDateTypes
        Initial
        Final
    End Enum

    Private Const IncompleteDate As String = "^\d*-\d*-\d*$"
    Private Const DayMonthYear As String = "^\d\d-\d\d-\d\d\d\d$"
    Private Const YearMonthDay As String = "^\d\d\d\d-\d\d-\d\d$"
    Private Const YearMonth As String = "^\d\d\d\d-\d\d-$"
    Private Const YearDay As String = "^\d\d\d\d--\d\d$"
    Private Const Year As String = "^\d\d\d\d--$"
    Private Const JustYear As String = "^\d\d\d\d$"

    'Private Const UnkownNothing As String = "^\d\d\d[1-9]-\d[1-9]-\d[1-9]$"
    'Private Const UnkownDay As String = "^\d\d\d[1-9]-\d[1-9]-00$"
    'Private Const UnkownMonth As String = "^\d\d\d[1-9]-00-\d[1-9]$"
    'Private Const UnkownMonthDay As String = "^\d\d\d[1-9]-00-00$"
    'Private Const UnkownYear As String = "^0000-\d[1-9]-\d[1-9]$"
    'Private Const UnkownYearDay As String = "^0000-\d[1-9]-00$"
    'Private Const UnkownYearMonth As String = "^0000-00-\d[1-9]$"
    'Private Const UnkownYearMonthDay As String = "^0000-00-00$"



    Private myProgressDialog As ProgressDialog
    Private myRootLazyNode As LazyNode
    Private myValidationResults As ValidationErrorCollection = Nothing
    Private myLazyTree As LazyTree


#End Region

#Region "General Shared Functions"

    Public Shared Function Matches(ByVal str As String, ByVal regexp As String) As Boolean
        Return Regex.IsMatch(str, regexp)
    End Function

    Public Shared Function IsFondsReference(ByVal v As String) As Boolean
        Return Matches(v, "^\w+\/\w+$")
    End Function

    Public Shared Function IsSubFondsReference(ByVal v As String) As Boolean
        Return Matches(v, "^\w+$")
    End Function

    Public Shared Function IsSectionReference(ByVal v As String) As Boolean
        Return Matches(v, "^\w+$")
    End Function

    Public Shared Function IsSeriesReference(ByVal v As String) As Boolean
        Return Matches(v, "^\d\d\d$")
    End Function

    Public Shared Function IsInstalationUnitReference(ByVal v As String) As Boolean
        Return Matches(v, "^\d+([\.\:]\d+)*[A-Z]?$")
    End Function

    Public Shared Function IsComposedDocumentReference(ByVal v As String) As Boolean
        Return Matches(v, "^\d+([\.\:]\d+)*[A-Z]?$")
    End Function


    Public Shared Function IsDocumentReference(ByVal v As String) As Boolean
        Return Matches(v, "^\d+([\.\:]\d+)*[A-Z]?$")
    End Function

    Public Shared Function IsFloat(ByVal v As String) As Boolean
        Return Matches(v, "^\d+(,\d+)?$")
    End Function

    Public Shared Function IsNotEmpty(ByVal v As String) As Boolean
        Return (Not v Is Nothing) AndAlso (v.Length > 0)
    End Function

    Public Shared Function IsInteger(ByVal v As String) As Boolean
        Return Matches(v, "^\d+$")
    End Function


    Public Shared Function GetCompleteDate(ByVal d As String, ByVal DateType As ExtremeDateTypes) As String
        If d Is Nothing OrElse d = "" Then Return "0000-00-00"

        If DateType = ExtremeDateTypes.Initial Then
            If Matches(d, YearMonthDay) Then
                Return d
            ElseIf Matches(d, YearMonth) Then
                Return d & "01"
            ElseIf Matches(d, YearDay) Then
                Return d.Substring(0, 5) & "01" & d.Substring(5, 3)
            ElseIf Matches(d, Year) Then
                Return d.Substring(0, 5) & "01-01"
            End If
        Else ' Final date
            If Matches(d, YearMonthDay) Then
                Return d
            ElseIf Matches(d, YearMonth) Then
                Dim month As String = d.Substring(5, 2)
                Dim day As String
                Select Case month
                    Case "01", "03", "05", "07", "08", "10", "12" : day = "31"
                    Case "02" : day = "28"
                    Case Else : day = "30"
                End Select
                Return d & day
            ElseIf Matches(d, YearDay) Then
                Return d.Substring(0, 5) & "12" & d.Substring(5, 3)
            ElseIf Matches(d, Year) Then
                Return d.Substring(0, 5) & "12-31"
            End If
        End If
        Return d
    End Function


    Public Shared Function FixUnkownDate(ByVal d As String, ByVal DateType As ExtremeDateTypes) As String
        Dim components As String() = d.Split("-")
        Dim year As String = components(0)
        Dim month As String = components(1)
        Dim day As String = components(2)

        If DateType = ExtremeDateTypes.Initial Then
            If year = "0000" Then year = "0001"
            If month = "00" Then month = "01"
            If day = "00" Then day = "01"
        Else
            If year = "0000" Then year = "9999"
            If month = "00" Then month = 12
            If day = "00" Then
                Select Case month
                    Case "01", "03", "05", "07", "08", "10", "12" : day = "31"
                    Case "02" : day = "28"
                    Case Else : day = "30"
                End Select
            End If
        End If
        Return String.Format("{0}-{1}-{2}", year, month, day)
    End Function


    Public Shared Function AreExtremeDatesValid(ByRef InitialDate As String, ByRef FinalDate As String) As Boolean

        If Matches(InitialDate, YearMonthDay) AndAlso Matches(FinalDate, YearMonthDay) Then
            Dim FixedInitialDate As String = FixUnkownDate(InitialDate, ExtremeDateTypes.Initial)
            Dim FixedFinalDate As String = FixUnkownDate(FinalDate, ExtremeDateTypes.Final)
            Debug.WriteLine("FixedInitialDate=" & FixedInitialDate)
            Debug.WriteLine("FixedFinalDate=" & FixedFinalDate)
            Return FixedInitialDate.CompareTo(FixedFinalDate) <= 0
        Else
            Return False
        End If
    End Function


    Public Shared Function IsValidContainerType(ByVal v As String) As Boolean
        Return v = VisualFieldLabel("ContainerType.Book") OrElse _
               v = VisualFieldLabel("ContainerType.Box") OrElse _
               v = VisualFieldLabel("ContainerType.Maco") OrElse _
               v = VisualFieldLabel("ContainerType.Macete") OrElse _
               v = VisualFieldLabel("ContainerType.Folder") OrElse _
               v = VisualFieldLabel("ContainerType.Cover") OrElse _
               v = VisualFieldLabel("ContainerType.Capilha") OrElse _
               v = VisualFieldLabel("ContainerType.Roll") OrElse _
               v = VisualFieldLabel("ContainerType.Envelope") OrElse _
               v = VisualFieldLabel("ContainerType.Album") OrElse _
               v = VisualFieldLabel("ContainerType.Other")
        ' v.length > 0 
    End Function


    Public Shared Function IsValidOtherLevel(ByRef v As String) As Boolean
        Select Case v
            Case EADDefinitions.OTHERLEVEL_FONDS, _
                 EADDefinitions.OTHERLEVEL_SUBFONDS, _
                 EADDefinitions.OTHERLEVEL_SECTION, _
                 EADDefinitions.OTHERLEVEL_SUBSECTION, _
                 EADDefinitions.OTHERLEVEL_SUBSUBSECTION, _
                 EADDefinitions.OTHERLEVEL_SERIES, _
                 EADDefinitions.OTHERLEVEL_SUBSERIES, _
                 EADDefinitions.OTHERLEVEL_INSTALATIONUNIT, _
                 EADDefinitions.OTHERLEVEL_COMPOSEDDOCUMENT, _
                 EADDefinitions.OTHERLEVEL_DOCUMENT
                Return True
            Case Else
                Return False

        End Select
    End Function



    Public Shared Function IsReferenceValid(ByRef v As String, ByVal OtherLevel As String) As Boolean
        Select Case OtherLevel
            Case EADDefinitions.OTHERLEVEL_FONDS : Return IsFondsReference(v)
            Case EADDefinitions.OTHERLEVEL_SUBFONDS : Return IsSubFondsReference(v)
            Case EADDefinitions.OTHERLEVEL_SECTION, _
                 EADDefinitions.OTHERLEVEL_SUBSECTION, _
                 EADDefinitions.OTHERLEVEL_SUBSUBSECTION : Return IsSectionReference(v)
            Case EADDefinitions.OTHERLEVEL_SERIES, _
                 EADDefinitions.OTHERLEVEL_SUBSERIES : Return IsSeriesReference(v)
            Case EADDefinitions.OTHERLEVEL_INSTALATIONUNIT : Return IsInstalationUnitReference(v)
            Case EADDefinitions.OTHERLEVEL_COMPOSEDDOCUMENT : Return IsComposedDocumentReference(v)
            Case EADDefinitions.OTHERLEVEL_DOCUMENT : Return IsDocumentReference(v)
        End Select
    End Function

    Public Shared Function IsValidDate(ByVal v As String) As Boolean
        Return Matches(v, YearMonthDay)
    End Function

    Public Shared Function IsReversedDate(ByVal v As String) As Boolean
        Return Matches(v, DayMonthYear)
    End Function

    Public Shared Function IsIncompleteDate(ByVal v As String) As Boolean
        Return Matches(v, IncompleteDate)
    End Function

    Public Shared Function IsJustYearDate(ByVal v As String) As Boolean
        Return Matches(v, JustYear)
    End Function


#End Region

#Region "Validation Algorithms"




    Public Sub New(ByVal RootLazyNode As LazyNode, ByVal LazyTree As LazyTree)
        myRootLazyNode = RootLazyNode
        myLazyTree = LazyTree
    End Sub



    Public Function Validate(ByVal ShowResultsWindow As Boolean) As Boolean
        Cursor.Current = Cursors.WaitCursor
        Dim startTime As Date = Date.Now

        myProgressDialog = New ProgressDialog(True)
        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.Text = String.Format(InfoMessage("Validator.Title"), myRootLazyNode.UnitTitle)
        '"A importar " & Path.GetFileName(myFilename) & "..."
        myProgressDialog.Show()


        Dim t As Thread = New Thread(New ThreadStart(AddressOf ValidateLazyNode))
        t.Start()

        While t.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While


        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()

        Dim finishTime As Date = Date.Now
        Dim timeSpan As TimeSpan = finishTime.Subtract(startTime)

        If ShowResultsWindow Then
            OpenValidationResults()
        ElseIf myValidationResults.Count > 0 Then
            OpenValidationResults()
        End If


        Cursor.Current = Cursors.Default
        Return myValidationResults.Count = 0
    End Function


    Public Function InferenceValidation(ByVal ShowResultsWindow As Boolean) As Boolean
        Cursor.Current = Cursors.WaitCursor
        Dim startTime As Date = Date.Now

        myProgressDialog = New ProgressDialog(True)
        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.Text = String.Format(InfoMessage("Validator.Title"), myRootLazyNode.UnitTitle)
        '"A importar " & Path.GetFileName(myFilename) & "..."
        myProgressDialog.Show()


        Dim t As Thread = New Thread(New ThreadStart(AddressOf InferenceValidateLazyNode))
        t.Start()

        While t.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While


        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()

        Dim finishTime As Date = Date.Now
        Dim timeSpan As TimeSpan = finishTime.Subtract(startTime)

        If ShowResultsWindow Then
            OpenValidationResults()
        ElseIf myValidationResults.Count > 0 Then
            OpenValidationResults()
        End If


        Cursor.Current = Cursors.Default
        Return myValidationResults.Count = 0
    End Function


    Private Sub OpenValidationResults()
        If myValidationResults Is Nothing Then Exit Sub
        Dim frmValidationResults As New ValidationResultsForm(myValidationResults, myLazyTree)
        'frmValidationResults.TopMost = True
        frmValidationResults.Show()
    End Sub


    Private Sub ValidateLazyNode()
        myValidationResults = myRootLazyNode.StopableCatamorphism(New GeneValidator(myProgressDialog))
    End Sub


    Private Sub InferenceValidateLazyNode()
        myValidationResults = myRootLazyNode.StopableCatamorphism(New GeneInferenceValidator(myProgressDialog))
    End Sub




    Public Shared Function GetLazyNodeErrors(ByVal Node As LazyNode) As ValidationErrorCollection
        Dim Errors As New ValidationErrorCollection

        If Not Validator.IsReferenceValid(Node.UnitId, Node.OtherLevel) Then
            Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.InvalidReference")))
        End If

        If (Node.isLeaf) AndAlso Not Validator.AreExtremeDatesValid(Node.UnitDateInitial, Node.UnitDateFinal) Then
            Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.MissingDatesInLeaf")))
        End If

        If Node.OtherLevel = OTHERLEVEL_INSTALATIONUNIT Then
            If Not IsValidContainerType(Node.ContainerType) Then
                Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.ContainerTypeNotDefined")))
            End If

            If Node.ContainerType = VisualFieldLabel("ContainerType.Other") AndAlso Node.ContainerCustomType.Length = 0 Then
                Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.ContainerTypeNotDefined")))
            End If

            If Node.PhysLoc.Length = 0 Then
                Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.PhysLocNotDefined")))
            End If

        End If



        If Node.UnitTitle.Length = 0 Then
            Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.UnitTitleNotDefined")))
        End If

        If (Not Node.Parent Is Nothing) Then
            If Node.Parent.OtherLevelIndex >= Node.OtherLevelIndex Then Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.HierarquicalInconsistency")))
        End If


        Return Errors
    End Function


    Public Shared Function GetLazyNodeInferenceErrors(ByVal Node As LazyNode) As ValidationErrorCollection
        Dim Errors As New ValidationErrorCollection

        If (Node.isLeaf) AndAlso Not Validator.AreExtremeDatesValid(Node.UnitDateInitial, Node.UnitDateFinal) Then
            Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.MissingDatesInLeaf")))
        End If

        If Node.OtherLevel = OTHERLEVEL_INSTALATIONUNIT AndAlso Not IsValidContainerType(Node.ContainerType) Then
            Errors.Add(New ValidationError(Node, General.ErrorMessage("Validation.ContainerTypeNotDefined")))
        End If

        Return Errors
    End Function


#End Region


End Class

