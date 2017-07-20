Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class IntervalDates

    Private myInitialDate As String
    Private myFinalDate As String

    Private myInitialYear As String
    Private myInitialMonth As String
    Private myInitialDay As String

    Private myFinalYear As String
    Private myFinalMonth As String
    Private myFinalDay As String

    Private myInitialYearIsEmpty As Boolean
    Private myInitialMonthIsEmpty As Boolean
    Private myInitialDayIsEmpty As Boolean

    Private myFinalYearIsEmpty As Boolean
    Private myFinalMonthIsEmpty As Boolean
    Private myFinalDayIsEmpty As Boolean

    Public Sub New()
    End Sub

    Public Sub New(ByVal strInitialYear As String, ByVal strInitialMonth As String, ByVal strInitialDay As String, _
        ByVal strFinalYear As String, ByVal strFinalMonth As String, ByVal strFinalDay As String)
        InitialYear = strInitialYear
        InitialMonth = strInitialMonth
        InitialDay = strInitialDay

        FinalYear = strFinalYear
        FinalMonth = strFinalMonth
        FinalDay = strFinalDay
    End Sub

    Function InitialDate() As String
        Return myInitialYear & "-" & myInitialMonth & "-" & myInitialDay
    End Function

    Function FinalDate() As String
        Return myFinalYear & "-" & myFinalMonth & "-" & myFinalDay
    End Function

    Property InitialYear() As String
        Get
            Return myInitialYear
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                myInitialYear = "0000"
            Else
                myInitialYear = Value
            End If
        End Set
    End Property

    Property InitialMonth() As String
        Get
            Return myInitialMonth
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                myInitialMonth = "00"
            Else
                myInitialMonth = Value
            End If
        End Set
    End Property

    Property InitialDay() As String
        Get
            Return myInitialDay
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                myInitialDay = "00"
            Else
                myInitialDay = Value
            End If
        End Set
    End Property

    Property FinalYear() As String
        Get
            Return myFinalYear
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                myFinalYear = "9999"
            Else
                myFinalYear = Value
            End If
        End Set
    End Property

    Property FinalMonth() As String
        Get
            Return myFinalMonth
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                myFinalMonth = "13"
            Else
                myFinalMonth = Value
            End If
        End Set
    End Property

    Property FinalDay() As String
        Get
            Return myFinalDay
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                myFinalDay = "32"
            Else
                myFinalDay = Value
            End If
        End Set
    End Property

    Public Function InitialYearIsEmpty() As Boolean
        If myInitialYear = "0000" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function InitialMonthIsEmpty() As Boolean
        If myInitialMonth = "00" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function InitialDayIsEmpty() As Boolean
        If myInitialDay = "00" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FinalYearIsEmpty() As Boolean
        If myFinalYear = "9999" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FinalMonthIsEmpty() As Boolean
        If myFinalMonth = "13" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FinalDayIsEmpty() As Boolean
        If myFinalDay = "32" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function InitialDateIsEmpty() As Boolean
        If InitialYearIsEmpty() And InitialMonthIsEmpty() And InitialDayIsEmpty() Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FinalDateIsEmpty() As Boolean
        If FinalYearIsEmpty() And FinalMonthIsEmpty() And FinalDayIsEmpty() Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function sclQryDate(ByVal sclCurQry As StringCollection) As StringCollection
        If InitialDateIsEmpty() And FinalDateIsEmpty() Then
            Return sclCurQry
        ElseIf InitialDateIsEmpty() Then
            If FinalYearIsEmpty() And FinalMonthIsEmpty() Then
                sclCurQry.Add("(UnitDateFinal like '%-" & myFinalDay & "')")
            ElseIf FinalYearIsEmpty() And FinalDayIsEmpty() Then
                sclCurQry.Add("(UnitDateFinal like '%-" & myFinalMonth & "-%')")
            ElseIf FinalYearIsEmpty() Then
                sclCurQry.Add("(UnitDateFinal like '%-" & myFinalMonth & "-" & myFinalDay & "')")
            ElseIf FinalMonthIsEmpty() And FinalDayIsEmpty() Then
                sclCurQry.Add("(UnitDateFinal <= '" & FinalDate() & "'" & _
                " AND UnitDateInitial <= '" & FinalDate() & "')")
            ElseIf FinalMonthIsEmpty() Then
                sclCurQry.Add("(UnitDateFinal <= '" & FinalDate() & "'" & _
                " AND UnitDateInitial <= '" & FinalDate() & "')")
            ElseIf FinalDayIsEmpty() Then
                sclCurQry.Add("(UnitDateFinal <= '" & FinalDate() & "'" & _
                " AND UnitDateInitial <= '" & FinalDate() & "')")
            End If
        ElseIf FinalDateIsEmpty() Then
            If InitialYearIsEmpty() And InitialMonthIsEmpty() Then
                sclCurQry.Add("(UnitDateInitial like '%-" & myInitialDay & "')")
            ElseIf InitialYearIsEmpty() And InitialDayIsEmpty() Then
                sclCurQry.Add("(UnitDateInitial like '%-" & myInitialMonth & "-%')")
            ElseIf InitialYearIsEmpty() Then
                sclCurQry.Add("(UnitDateInitial like '%" & myInitialMonth & "-" & myInitialDay & "')")
            ElseIf InitialMonthIsEmpty() And InitialDayIsEmpty() Then
                sclCurQry.Add("(UnitDateInitial >= '" & InitialDate() & "')")
            ElseIf InitialMonthIsEmpty() Then
                sclCurQry.Add("(UnitDateInitial >= '" & InitialDate() & "')")
            ElseIf InitialDayIsEmpty() Then
                sclCurQry.Add("(UnitDateInitial >= '" & InitialDate() & "')")
            Else
                sclCurQry.Add("(UnitDateInitial = '" & InitialDate() & "' OR UnitDateFinal = '" & InitialDate() & "')")
            End If
        Else
            sclCurQry.Add("(UnitDateInitial >= '" & InitialDate() & "' AND UnitDateInitial <= '" & FinalDate() & "')" & _
            " OR (UnitDateFinal >= '" & InitialDate() & "' AND UnitDateFinal <= '" & FinalDate() & "')")
        End If
        Return sclCurQry
    End Function

End Class
