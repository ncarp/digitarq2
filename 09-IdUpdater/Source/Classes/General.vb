Imports System.Configuration
Imports System.IO


Module General

    Dim LOG_FILENAME As String = Environment.CurrentDirectory & "\IpUpdater.log"


#Region "Globaly assigned variables"



#End Region

#Region "Configuration File APIs"

    Public Function Constant(ByVal key As String) As String
        Try
            Dim message As String = CType(ConfigurationManager.GetSection("constants"), Hashtable).Item(key)
            Return message
        Catch ex As Exception
            Return "Cannot Load Configuration File!"
        End Try
    End Function


    Public Function ErrorMessage(ByVal key As String) As String
        Try
            Dim message As String = CType(ConfigurationManager.GetSection("errMessages"), Hashtable).Item(key)
            Return message
        Catch ex As Exception
            Return "Cannot Load Configuration File!"
        End Try
    End Function


    Public Function InfoMessage(ByVal key As String) As String
        Try
            Dim message As String = CType(ConfigurationManager.GetSection("infoMessages"), Hashtable).Item(key)
            Return message
        Catch ex As Exception
            Return "Cannot Load Configuration File!"
        End Try
    End Function


    Public Function LogMessage(ByVal key As String) As String
        Try
            Dim message As String = CType(ConfigurationManager.GetSection("logMessages"), Hashtable).Item(key)
            Return message
        Catch ex As Exception
            Return "Cannot Load Configuration File!"
        End Try
    End Function



    Public Function ContextMenuLabel(ByVal key As String) As String
        Try
            Dim message As String = CType(ConfigurationManager.GetSection("contextMenu"), Hashtable).Item(key)
            Return message
        Catch ex As Exception
            Return "Cannot Load Configuration File!"
        End Try
    End Function

    Public Function VisualFieldLabel(ByVal key As String) As String
        Try
            Dim message As String = CType(ConfigurationManager.GetSection("visualFieldsLabelSettings"), Hashtable).Item(key)
            Return message
        Catch ex As Exception
            Return "Cannot Load Configuration File!"
        End Try
    End Function

#End Region

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
        If obj Is System.DBNull.Value Then Return 0 Else Return CInt(obj)
    End Function

    Public Function DBToDbl(ByVal obj As Object) As Double
        If obj Is System.DBNull.Value Then Return 0.0 Else Return Double.Parse(DBToStr(obj).Replace(".", ","))
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

    Public Function DblToStr(ByVal v As Double) As String
        Return v.ToString
    End Function

    Public Function BoolToStr(ByVal v As Boolean) As String
        Return v.ToString
    End Function


#End Region

#Region "Type to Database"

    Public Function BoolToDB(ByVal v As Boolean) As Integer
        If v Then Return 1 Else Return 0
    End Function


    Public Function DateToDB(ByVal v As Date) As String
        Return String.Format("{0}-{1}-{2}", (v.Year & "").PadLeft(4, "0"), (v.Month & "").PadLeft(2, "0"), (v.Day & "").PadLeft(2, "0"))
    End Function

    Public Function StrToDB(ByVal v As String) As String
        If v Is Nothing Then Return "" Else Return v.Replace("'", "''")
    End Function


    Public Function DblToDB(ByVal v As Double) As String
        Return v.ToString().Replace(",", ".")
    End Function


#End Region

#Region "String To Type"

    Public Function StrToDbl(ByVal v As String) As Double
        Try
            Dim i As Double = Double.Parse(v)
            Return i
        Catch ex As Exception
            Debug.WriteLine("StrToDbl Exception = " & v)
            Return 0.0
        End Try
    End Function



    Public Function StrToInt(ByVal v As String) As Integer
        Try
            Dim i As Integer = Integer.Parse(v)
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
        v = v.ToLower
        Return v = "1" OrElse v = "yes" OrElse v = "true"
    End Function


#End Region

#Region "Other functions"

    Public Function ICollectionToCollection(ByVal col As ICollection) As Collection
        Dim Result As New Collection

        Dim e As IEnumerator = col.GetEnumerator
        While e.MoveNext
            Result.Add(e.Current)
        End While
        Return Result
    End Function

    Public Function SortICollection(ByVal col As ICollection, ByVal SortPropertyName As String, Optional ByVal Ascending As Boolean = True) As ICollection
        Return SortCollection(ICollectionToCollection(col), SortPropertyName, Ascending)
    End Function

    Public Function SortCollection(ByVal col As Collection, ByVal psSortPropertyName As String, Optional ByVal pbAscending As Boolean = True, Optional ByVal psKeyPropertyName As String = "") As Collection

        ' The Objects were originally declared as Variants. VB.Net has 
        'eliminated the
        ' Variant type so they must be declared as type Object. 
        'Also Objects cannot be
        'used with the Set keyword, so I had to remove the set 
        'keyword. Other than that
        'I did not have to make hardly any changes.

        Dim obj As Object
        Dim i As Integer
        Dim j As Integer
        Dim iMinMaxIndex As Integer
        Dim vMinMax As Object
        Dim vValue As Object
        Dim bSortCondition As Boolean
        Dim bUseKey As Boolean
        Dim sKey As String

        bUseKey = (psKeyPropertyName <> "")

        For i = 1 To col.Count - 1
            obj = col(i)
            ' the vbGet can be replaced with a 
            'CallType.Get if you
            ' want. See VB Language reference for CallByName

            vMinMax = CallByName(obj, psSortPropertyName, vbGet)
            iMinMaxIndex = i

            For j = i + 1 To col.Count
                obj = col(j)
                vValue = CallByName(obj, _
                    psSortPropertyName, vbGet)

                If (pbAscending) Then
                    bSortCondition = (vValue < vMinMax)
                Else
                    bSortCondition = (vValue > vMinMax)
                End If

                If (bSortCondition) Then
                    vMinMax = vValue
                    iMinMaxIndex = j
                End If

                obj = Nothing
            Next j

            If (iMinMaxIndex <> i) Then
                obj = col(iMinMaxIndex)

                col.Remove(iMinMaxIndex)
                If (bUseKey) Then
                    sKey = CStr(CallByName(obj, _
                       psKeyPropertyName, vbGet))
                    col.Add(obj, sKey, i)
                Else
                    col.Add(obj, , i)
                End If

                obj = Nothing
            End If

            obj = Nothing
        Next i
        Return col
    End Function

    Public Function NormalizeDate(ByVal StrDate As String) As String
        If Validator.IsValidDate(StrDate) Then
            Return StrDate
        ElseIf Validator.IsReversedDate(StrDate) Then
            Return DateToStr(StrToDate(StrDate))
        ElseIf Validator.IsIncompleteDate(StrDate) Then
            Dim Components As String() = StrDate.Split("-")
            Try
                Dim Year As String = Components(0).PadLeft(4, "0")
                Dim Month As String = Components(1).PadLeft(2, "0")
                Dim Day As String = Components(2).PadLeft(2, "0")
                Return String.Format("{0}-{1}-{2}", Year, Month, Day)
            Catch ex As Exception
                Return "0000-00-00"
            End Try
        ElseIf Validator.IsJustYearDate(StrDate) Then
            Return String.Format("{0}-00-00", StrDate)
        Else
            Return "0000-00-00"
        End If
    End Function

#End Region

#Region "XML Functions"

    Function CreateTag(ByVal Name As String, ByVal Value As String)
        Return String.Format("<{0}>{1}</{0}>", Name, Value)
    End Function

    Function CreateTag(ByVal Name As String, ByVal Value As String, ByVal Attributes As String)
        Return String.Format("<{0} {2}>{1}</{0}>", Name, Value, Attributes)
    End Function

    Function CreateTag(ByVal Name As String, ByVal Value As String, ByVal Attributes As String())
        Return String.Format("<{0} {2}>{1}</{0}>", Name, Value, String.Join(" ", Attributes))
    End Function


#End Region

#Region "Text Files"

    Public Function ReadTextFile(ByVal filename As String) As String
        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader(filename, System.Text.Encoding.Default)
            Dim str As String = sr.ReadToEnd
            sr.Close()
            Return str
        Catch E As Exception
            Debug.WriteLine(E.Message & ControlChars.NewLine & E.StackTrace)
            Return ""
        End Try
    End Function

    Public Sub AppendToLog(ByVal Text As String)

        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamWriter = New StreamWriter(LOG_FILENAME, True, System.Text.Encoding.Default)
            sr.WriteLine(Text)
            sr.Close()
        Catch E As Exception
        End Try

    End Sub
#End Region



End Module
