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


    Private Shared Function IsValidContainerType(ByVal v As String) As Boolean
        Return v.Length > 0
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



End Class

