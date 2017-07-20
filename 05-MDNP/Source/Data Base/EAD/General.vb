'*************************************************************************************************
' Module: General
' Purpose: This code general functions that are used in a DB access and in AEC class
'          This is a copy of general from digitarq application with some changes.
' The Notation isn't used here.
'***************************************************************************************************

Imports System.Configuration
Module General

    '#Region "Configuration File APIs"
    '    Public Function ErrorMessage(ByVal key As String) As String
    '        Try
    '            Dim message As String = CType(ConfigurationSettings.GetConfig("errMessages"), Hashtable).Item(key)
    '            Return message
    '        Catch ex As Exception
    '            Return "Cannot Load Configuration File!"
    '        End Try
    '    End Function


    '    Public Function InfoMessage(ByVal key As String) As String
    '        Try
    '            Dim message As String = CType(ConfigurationSettings.GetConfig("infoMessages"), Hashtable).Item(key)
    '            Return message
    '        Catch ex As Exception
    '            Return "Cannot Load Configuration File!"
    '        End Try
    '    End Function


    '    Public Function VisualFieldLabel(ByVal key As String) As String
    '        Try
    '            Dim message As String = CType(ConfigurationSettings.GetConfig("visualFieldsLabelSettings"), Hashtable).Item(key)
    '            Return message
    '        Catch ex As Exception
    '            Return "Cannot Load Configuration File!"
    '        End Try
    '    End Function

    '#End Region

#Region "Database to Type"

    Public Function DBToDate(ByVal obj As Object) As Date
        If obj Is Nothing OrElse obj Is System.DBNull.Value Then
            Return Date.Parse("0001-01-01")
        Else
            Try
                Dim d As Date = CDate(obj)
                Return d
            Catch ex As Exception
                Return Date.Parse("0001-01-01")
            End Try
        End If
    End Function


    Public Function DBToInt(ByVal obj As Object) As Integer
        If obj Is System.DBNull.Value Then Return -1 Else Return CInt(obj)
    End Function


    Public Function DBToStr(ByVal obj As Object) As String
        If obj Is System.DBNull.Value Then Return "" Else Return obj
    End Function

    Public Function DBToBool(ByVal obj As Object) As Boolean
        If obj Is System.DBNull.Value Then Return False Else Return CBool(obj)
    End Function
#End Region

#Region "Type to String"
    Public Function DateToStr(ByVal v As Date) As String
        Return String.Format("{0}-{1}-{2}", (v.Year & "").PadLeft(4, "0"), (v.Month & "").PadLeft(2, "0"), (v.Day & "").PadLeft(2, "0"))
    End Function

    Public Function IntToStr(ByVal v As Integer) As String
        Return CStr(v)
    End Function

    Public Function DblToStr(ByVal v As Integer) As String
        Return CDbl(v)
    End Function

#End Region

#Region "Type to Database"
    Public Function DBToInt64(ByVal obj As Object) As Int64
        If obj Is System.DBNull.Value Then Return -1 Else Return CType(obj, Int64)
    End Function

    Public Function DBToByte(ByVal obj As Object) As Byte()

        If obj Is System.DBNull.Value Then

            Dim bytDataNull(0) As Byte

            bytDataNull(0) = CType(0, Byte)

            Return bytDataNull
        Else
            Dim DataByte() As Byte = CType(obj, Byte())



            Return DataByte
        End If

    End Function

    Public Function BoolToDB(ByVal v As Boolean) As Integer
        If v Then Return 1 Else Return 0
    End Function


    Public Function DateToDB(ByVal v As Date) As String
        Return String.Format("{0}-{1}-{2}", (v.Year & "").PadLeft(4, "0"), (v.Month & "").PadLeft(2, "0"), (v.Day & "").PadLeft(2, "0"))
    End Function

    Public Function StrToDB(ByVal v As String) As String
        If v Is Nothing Then Return "" Else Return v.Replace("'", "")
    End Function

#End Region

#Region "String To Type"

    Public Function StrToDbl(ByVal v As String) As Double
        Try
            Dim i As Double = Double.Parse(v)
            Return i
        Catch ex As Exception
            Return 0.0
        End Try
    End Function



    Public Function StrToInt(ByVal v As String) As Integer
        Try
            Dim i As Integer = CInt(v)
            Return i
        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Function StrToDate(ByVal v As String) As Date
        Try
            Dim d As Date = Date.Parse(v)
            Return d
        Catch ex As Exception
            Return Date.Parse("0001-01-01")
        End Try
    End Function


    Public Function StrToBool(ByVal v As String) As Boolean
        Return v = "1" Or v = "yes"
    End Function

#End Region

#Region "Create  Html Tag"
    Public Function CreateTag(ByVal desc As String, ByVal value As String) As String
        Select Case value
            Case "" : Return ""
            Case Else : Return "<p class='Indent20'><font class='TextNavy'>" & desc & " " & "</font><font class='TextGray'>" & value & "</font></p>"
        End Select
    End Function
#End Region

#Region " Write in Html the description and the BD value if the value exists"
    Public Function WriteIfNotEmpty(ByVal desc As String, ByVal value As String) As String

        If value <> "" Then
            Return desc & value
        End If
        Return ""
    End Function
#End Region

End Module
