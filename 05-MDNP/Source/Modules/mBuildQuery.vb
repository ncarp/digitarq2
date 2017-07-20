Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data.SqlClient


Module mBuildQuery


    '******************************************************************************
    ' Function: strBdyQry
    ' Purpose: Returns the Str(ing) B(o)dy Q(ue)ry a part of the db query
    '******************************************************************************
    Public Function strBdyQryBS(ByVal objBS As BasicSearch) As String

        Dim strQry As String

        Dim sclCurQry As New StringCollection 'S(tring) C(o)l(lection) to Cur(rent) Q(ue)ry
        Dim strCtlAccessSubQry As String = "" ' Initial value for the sub query to the control access table
        Dim strName, strLocal, strOtherTerms As String

        strName = objBS.Name
        strLocal = objBS.Local
        strOtherTerms = objBS.OtherTerms

        sclCurQry = objBS.IntervalDates.sclQryDate(sclCurQry)

        sclCurQry = sclKeyWordBasicSearch(sclCurQry, strName, strLocal, strOtherTerms)

        Dim strWhereQry As String

        Dim myArrayTemp(sclCurQry.Count - 1) As String
        sclCurQry.CopyTo(myArrayTemp, 0)
        strWhereQry = Join(myArrayTemp, " AND ")
        If strWhereQry <> "" Then
            strQry = String.Format("SELECT DISTINCT ID, UnitDateInitial, UnitTitle, OtherLevel, CompleteUnitID FROM Components WHERE Visible='1' AND {0}", strWhereQry)
        End If

        Return strQry
    End Function


    '*************************************************************************************
    ' Function: sclkeyWordBasicSearch
    ' Purpose: Returns s(tringcollecton element that is the query to the components table,
    '          for a basic search page (only one textbox for input - KeyWordBasicSearch)
    '*************************************************************************************
    Private Function sclKeyWordBasicSearch(ByVal sclQry As StringCollection, ByVal strName As String, ByVal strLocal As String, ByVal strOtherTerms As String) As StringCollection

        Dim strAName() As String
        Dim strALocal() As String
        Dim strAOtherTerms() As String

        Dim strNameFields() As String = {"OriginationAuthor", "OriginationDestination", "OriginationNotary", "UnitTitle"}
        Dim strLocalFields() As String = {"UnitTitle", "GeogName", "OriginationAuthorAddress", "OriginationDestinationAddress"}
        Dim strOtherTermsFields() As String = {"BiogHist", "UnitTitle", "ScopeContent"}

        Dim strCurName, strCurLocal, strCurOtherTerms As String

        Dim i As Integer

        If (strName.Trim().StartsWith(Chr(34)) And strName.Trim().EndsWith(Chr(34))) Then
            sclQry.Add(strExactSearchCondition(strName.Trim(Chr(34)), strNameFields))
        Else
            strAName = strRemoveWords(strName.Trim())  ' Array of substrings from textbox input string
            If strName <> "" And strAName.Length > 0 Then
                sclQry.Add(strBoolSearchCondition(strAName, strNameFields, " and "))
            End If
        End If

        If (strLocal.Trim().StartsWith(Chr(34)) And strLocal.Trim().EndsWith(Chr(34))) Then
            sclQry.Add(strExactSearchCondition(strLocal.Trim(Chr(34)), strLocalFields))
        Else
            strALocal = strRemoveWords(strLocal.Trim())  ' Array of substrings from textbox input string
            If strLocal <> "" And strALocal.Length > 0 Then
                sclQry.Add(strBoolSearchCondition(strALocal, strLocalFields, " and "))
            End If
        End If

        If (strOtherTerms.Trim().StartsWith(Chr(34)) And strOtherTerms.Trim().EndsWith(Chr(34))) Then
            sclQry.Add(strExactSearchCondition(strOtherTerms.Trim(Chr(34)), strOtherTermsFields))
        Else
            strAOtherTerms = strRemoveWords(strOtherTerms.Trim())  ' Array of substrings from textbox input string
            If strOtherTerms <> "" And strAOtherTerms.Length > 0 Then
                sclQry.Add(strBoolSearchCondition(strAOtherTerms, strOtherTermsFields, " and "))
            End If
        End If

        Return sclQry
    End Function


    '******************************************************************************
    ' Function: strBdyQry
    ' Purpose: Returns the Str(ing) B(o)dy Q(ue)ry a part of the db query
    '******************************************************************************
    Public Function strBdyQryAS(ByVal objAS As AdvancedSearch) As String

        Dim strQry As String

        Dim sclCurQry As New StringCollection 'S(tring) C(o)l(lection) to Cur(rent) Q(ue)ry


        sclCurQry = sclOtherLevel(objAS.OtherLevel, sclCurQry)

        If Not objAS.UnitTitle.IsEmpty Then
            Dim FieldName() As String = {"UnitTitle"}
            sclCurQry = strByColnSearchCondition(sclCurQry, objAS.UnitTitle, FieldName)
        End If
        If Not objAS.AuthorDestination.IsEmpty Then
            Dim FieldName() As String = {"OriginationAuthor", "OriginationDestination", "OriginationScrivener", "OriginationNotary"}
            sclCurQry = strByColnSearchCondition(sclCurQry, objAS.AuthorDestination, FieldName)
        End If
        If Not objAS.GeogLocal.IsEmpty Then
            Dim FieldName() As String = {"OriginationAuthorAddress", "OriginationDestinationAddress", "GeogName", "OriginalsLoc", "ScopeContent", "BiogHist"}
            sclCurQry = strByColnSearchCondition(sclCurQry, objAS.GeogLocal, FieldName)
        End If
        If Not objAS.KeyWord.IsEmpty Then
            Dim FieldName() As String = {"ScopeContent", "BiogHist", "Note", "Abstract"}
            sclCurQry = strByColnSearchCondition(sclCurQry, objAS.KeyWord, FieldName)
        End If
        If Not objAS.CompleteUnitID.Equals("") Then
            sclCurQry = sclCompleteUnitId(sclCurQry, objAS.CompleteUnitID, "CountryCode + '/' + RepositoryCode + '/' + CompleteUnitId", "")
        End If
        If Not objAS.PartUnitID.Equals("") Then
            sclCurQry = sclCompleteUnitId(sclCurQry, objAS.PartUnitID, "CountryCode + '/' + RepositoryCode + '/' + CompleteUnitId", "%")
        End If

        sclCurQry = objAS.IntervalDates.sclQryDate(sclCurQry)


        Dim strWhereQry As String

        Dim myArr2(sclCurQry.Count - 1) As String
        sclCurQry.CopyTo(myArr2, 0)
        strWhereQry = Join(myArr2, " AND ")

        If Not objAS.ControlAccessItem.IsEmpty And objAS.SearchImages Then
            strQry = String.Format("SELECT DISTINCT ID, UnitDateInitial, UnitTitle, OtherLevel, CompleteUnitID FROM Components C" & _
                " INNER JOIN ControlAccess CA ON C.ID=CA.ComponentID" & _
                " INNER JOIN DaoGrp DG ON C.ID=DG.ComponentID" & _
                " WHERE {0} AND CA.ItemID={1} AND Visible=1", strWhereQry, objAS.ControlAccessItem.ID)
        ElseIf Not objAS.ControlAccessItem.IsEmpty Then
            strQry = String.Format("SELECT DISTINCT ID, UnitDateInitial, UnitTitle, OtherLevel, CompleteUnitID FROM Components C" & _
                " INNER JOIN ControlAccess CA ON C.ID=CA.ComponentID" & _
                " WHERE {0} AND CA.ItemID={1} AND Visible=1", strWhereQry, objAS.ControlAccessItem.ID)
        ElseIf objAS.SearchImages Then
            strQry = String.Format("SELECT DISTINCT ID, UnitDateInitial, UnitTitle, OtherLevel, CompleteUnitID FROM Components C" & _
                " INNER JOIN DaoGrp DG ON C.ID=DG.ComponentID" & _
                " WHERE {0} AND Visible=1", strWhereQry)
        Else
            strQry = String.Format("SELECT DISTINCT ID, UnitDateInitial, UnitTitle, OtherLevel, CompleteUnitID FROM Components" & _
                " WHERE {0} AND Visible=1", strWhereQry)
        End If

        Return strQry
    End Function


    '**************************************************************************************
    ' Function: strCompleteUnitId
    ' Purpose: Returns the Str(ing) Complete unit id condition search data asked by 
    '       the user for the complete unit id components db field 
    '       This function is necessary once i have to put in the completeUnit Id the
    '       "PT/ADPRT/" when I show it, because the CompleteUnitId db Field doesn't have it
    '       but it can be avoid if the missing string (PT/ADPRT/)will be introduced on the 
    '       completeUnitId create (update) action for each unit.
    '       So if "PT/ADPRT" was in the Complete Unit ID i wouldn't need this function.
    '***************************************************************************************
    Private Function sclCompleteUnitId(ByVal sclCurQry As StringCollection, ByVal strRef As String, ByVal strField As String, ByVal strPref As String) As StringCollection
        Dim strTemp As String
        If strPref = "" Then
            strTemp = (strField & " LIKE '" & strRef & "%'")
        Else
            strTemp = (strField & " LIKE '" & strPref & strRef & "%'")
        End If
        sclCurQry.Add("(" & strTemp & ")")
        Return sclCurQry
    End Function


    '*************************************************************************************
    ' Function: strByColnSearchCondition
    ' Purpose: Returns the Str(ing) by col(um)n Search Condition For an array of a given
    ' Column Names (filedsName parameter).
    '*************************************************************************************
    Private Function strByColnSearchCondition(ByVal sclCurQry As StringCollection, ByVal Obj As BlnSearchFields, ByVal ParamArray strFieldName() As String) As StringCollection

        Dim strSearchCondition As String = ""

        If Obj.AndField.Trim <> "" Then
            Dim strAnd() As String = strRemoveWords(Obj.AndField)
            If strAnd.Length > 0 Then
                strSearchCondition &= "(" & strBoolSearchCondition(strAnd, strFieldName, " AND ") & ")" & " AND "
            End If
        End If
        If Obj.OrField.Trim <> "" Then
            Dim strOr() As String = strRemoveWords(Obj.OrField)
            If strOr.Length > 0 Then
                strSearchCondition &= "(" & strBoolSearchCondition(strOr, strFieldName, " OR ") & ")" & " AND "
            End If
        End If
        If Obj.NotField.Trim <> "" Then
            Dim strNot() As String = strRemoveWords(Obj.NotField)
            If strNot.Length > 0 Then
                strSearchCondition &= "(" & strNotSearchCondition(strNot, strFieldName) & ")" & " AND "
            End If
        End If

        If Obj.ExactPhraseField.Trim <> "" Then
            Dim strExactPhrase As String = Obj.ExactPhraseField
            strSearchCondition &= "(" & strExactSearchCondition(strExactPhrase, strFieldName) & ")" & " AND "
        End If
        If strSearchCondition <> "" Then
            strSearchCondition = strSearchCondition.TrimEnd(" AND ".ToCharArray)
            sclCurQry.Add("(" & strSearchCondition & ")")
        End If
        Return sclCurQry
    End Function


    '*************************************************************************************
    ' Function: strOrSearchCondition
    ' Purpose: Returns the Str(ing) for Or Search Condition that compose the db query for
    ' a Column Names (fields  parameter). The Search condition string is build word by
    ' word from all words that are inputed by the user in the or textbox.
    '*************************************************************************************
    Public Function strBoolSearchCondition(ByVal str() As String, ByVal strFields() As String, ByVal Bool As String) As String
        Dim strWord As String
        Dim strBoolStatment As String = ""
        Dim i As Integer
        Dim strTemp(strFields.Length - 1) As String

        For i = 0 To strFields.Length - 1
            For Each strWord In str
                strWord.Trim()
                strTemp(i) &= (" CONTAINS(" & strFields(i) & ", '" & strWord & "')" & Bool)
            Next
            strTemp(i) = "(" & strTemp(i).TrimEnd(Bool.ToCharArray) & ")"
        Next
        strBoolStatment &= ("(" & Join(strTemp, " OR ").TrimEnd(" OR ".ToCharArray) & ")")

        Return strBoolStatment
    End Function


    '*************************************************************************************
    ' Function: strNotSearchCondition
    ' Purpose: Returns the Str(ing) for Not Search Condition that compose the db query for
    ' a Column Names (fields  parameter). The Search condition string is build word by
    ' word from all words that are inputed by the user in the given Not textbox.
    '*************************************************************************************
    Public Function strNotSearchCondition(ByVal str() As String, ByVal strFields() As String) As String
        Dim strWord, strNotStatment, strTemp As String
        Dim i As Integer

        For i = 0 To strFields.Length - 1
            For Each strWord In str
                strWord.Trim()
                If Not strWord.Equals("") Then
                    strTemp &= (" NOT CONTAINS(" & strFields(i) & ", '" & strWord & "') AND ")
                End If
            Next
        Next

        strNotStatment = ("(" & strTemp.TrimEnd(" AND ".ToCharArray) & ")")

        Return strNotStatment
    End Function


    '*********************************************************************************************
    ' Function: strExactPhraseSearchCondition
    ' Purpose: Returns the Str(ing) for ExactPhrase Search Condition that compose the db query for
    ' a Column Names (fields  parameter). The Search condition string is build 
    ' with the exact phrase  inputed by the user in the given ExactPhrase textbox.
    '**********************************************************************************************
    Public Function strExactSearchCondition(ByVal strExactPhrase As String, ByVal strFields() As String) As String
        Dim strExactPhraseCondition As String

        For i As Integer = 0 To strFields.Length - 1
            strExactPhraseCondition &= (" CONTAINS(" & strFields(i) & ", '""" & strExactPhrase & """') OR ")
        Next
        strExactPhraseCondition = strExactPhraseCondition.TrimEnd(" OR ".ToCharArray)
        Return strExactPhraseCondition
    End Function


    '*************************************************************************************
    ' Function: strExactPhraseUnitId
    ' Purpose: Returns the Str(ing) for ExactPhrase Unit Id Search Condition 
    '          that compose the db query for a Column Names (fields  parameter). 
    '          The Search condition string is build with the exact phrase  inputed by the 
    '          user in the given ExactPhrase in the UnitId textbox.
    '       This function is dependent of strCompleteUnitId function existence.  
    '*************************************************************************************
    Private Function strExactPhraseUnitId(ByVal str As String, ByVal strFields() As String) As String
        Dim strExactPhrase As String
        Dim i As Integer

        For i = 0 To strFields.Length - 1
            strExactPhrase &= ("" & strFields(i) & " LIKE '" & str & "') OR ")
        Next
        strExactPhrase = strExactPhrase.TrimEnd(" OR ".ToCharArray)
        Return strExactPhrase
    End Function



    '*************************************************************************************
    ' Function: sclOtherLevel
    ' Purpose: Returns s(tringcollecton element that is the query to the OtherLevel 
    '          column of components table.
    '*************************************************************************************
    Private Function sclOtherLevel(ByVal strSubStrInpCkb As ArrayList, ByVal sclQry As StringCollection) As StringCollection
        Dim strTempQry As String
        Dim i As Integer

        For i = 0 To (strSubStrInpCkb.Count - 1)
            If i <> 0 Then
                strTempQry &= " or "
            End If

            If strSubStrInpCkb(i) = "F" Then
                strTempQry &= "OtherLevel = 'F' or  OtherLevel = 'SF'"

            ElseIf strSubStrInpCkb(i) = "SC" Then
                strTempQry &= "OtherLevel = 'SC' or OtherLevel = 'SSC' or OtherLevel = 'SSSC'"

            ElseIf strSubStrInpCkb(i) = "SR" Then
                strTempQry &= "OtherLevel = 'SR' or OtherLevel = 'SSR'"

            Else
                strTempQry &= "OtherLevel = '" & strSubStrInpCkb(i) & "'"
            End If
        Next

        sclQry.Add("(" & strTempQry & ")")
        Return sclQry
    End Function


    '*************************************************************************************
    ' Function: strRemoveText
    ' Purpose: It returns a String with all the removed inconvenient characters.
    '*************************************************************************************
    Public Function strRemoveText(ByVal Text As String) As String

        Text = Text.Replace("<", "")
        Text = Text.Replace(">", "")
        Text = Text.Replace("&", "")
        Text = Text.Replace("%", "")
        Text = Text.Replace("(", "")
        Text = Text.Replace(")", "")
        Text = Text.Replace("[", "")
        Text = Text.Replace("]", "")
        Text = Text.Replace(";", "")
        Text = Text.Replace("'", "")
        Text = Text.Replace("#", "")
        Return Text.ToUpper

    End Function


    '*************************************************************************************
    ' Function: strReadInputText
    ' Purpose: It returns a String with all the removed inconvenient characters and all "\"
    '          characters replaced by "/". It is only necessary for the completeUnitId.
    '*************************************************************************************
    Public Function strReadReference(ByVal strInputText As String) As String

        'If strInputText.StartsWith(strPrefixRef) Then
        '    strInputText = strInputText.Replace(strPrefixRef, "")
        'End If
        strInputText = strInputText.Replace("\", "/")
        strInputText = strRemoveText(strInputText)

        Return strInputText
    End Function


    '*************************************************************************************
    ' Function: strGetTextFromTxt
    ' Purpose: It gets text from a txtbox control.
    '*************************************************************************************
    Public Function strGetTextFromTxt(ByVal txtControl As System.Web.UI.Control) As String
        Dim text As String
        If TypeOf txtControl Is TextBox Then
            Dim textbox As TextBox = CType(txtControl, TextBox)
            text = textbox.Text
        End If
        Return text
    End Function


    '*************************************************************************************
    ' Function: strRemoveWords
    ' Purpose: It removes all usual short words like 'para', etc. 
    '          This words are unwanted for the or condition in a query.
    '*************************************************************************************
    Public Function strRemoveWords(ByVal strInpText As String) As String()

        Dim sclAllQryWords As New StringCollection

        Dim strTemp() As String
        Dim i, j As Integer
        j = 0
        strInpText.Trim()

        If strInpText.Equals("") Then
            Return New String() {""}
        End If

        strTemp = Split(strInpText)
        For i = 0 To strTemp.Length - 1
            If strTemp(i).Length > 1 Then
                Select Case strTemp(i).ToLower
                    Case ""
                        Exit Select
                    Case "de"
                        Exit Select
                    Case "do"
                        Exit Select
                    Case "da"
                        Exit Select
                    Case "dos"
                        Exit Select
                    Case "das"
                        Exit Select
                    Case "os"
                        Exit Select
                    Case "as"
                        Exit Select
                    Case "ou"
                        Exit Select
                    Case "que"
                        Exit Select
                    Case "pela"
                        Exit Select
                    Case "pelo"
                        Exit Select
                    Case "com"
                        Exit Select
                    Case "sem"
                        Exit Select
                    Case "um"
                        Exit Select
                    Case "uns"
                        Exit Select
                    Case "uma"
                        Exit Select
                    Case "umas"
                        Exit Select
                    Case "seu"
                        Exit Select
                    Case "sua"
                        Exit Select
                    Case "mais"
                        Exit Select
                    Case "mas"
                        Exit Select
                    Case "menos"
                        Exit Select
                    Case "pelas"
                        Exit Select
                    Case "pelos"
                        Exit Select
                    Case "em"
                        Exit Select
                    Case "por"
                        Exit Select
                    Case "in"
                        Exit Select
                    Case "no"
                        Exit Select
                    Case "nos"
                        Exit Select
                    Case "na"
                        Exit Select
                    Case "nas"
                        Exit Select
                    Case "outros"
                        Exit Select
                    Case "como"
                        Exit Select
                    Case "só"
                        Exit Select
                    Case "nº"
                        Exit Select
                    Case "1º"
                        Exit Select
                    Case "2º"
                        Exit Select
                    Case "3º"
                        Exit Select
                    Case "4º"
                        Exit Select
                    Case "5º"
                        Exit Select
                    Case "6º"
                        Exit Select
                    Case "7º"
                        Exit Select
                    Case "8º"
                        Exit Select
                    Case "9º"
                        Exit Select
                    Case "10º"
                        Exit Select
                    Case "1ª"
                        Exit Select
                    Case "2ª"
                        Exit Select
                    Case "3ª"
                        Exit Select
                    Case "4ª"
                        Exit Select
                    Case "5ª"
                        Exit Select
                    Case "6ª"
                        Exit Select
                    Case "7ª"
                        Exit Select
                    Case "8ª"
                        Exit Select
                    Case "9ª"
                        Exit Select
                    Case "10ª"
                        Exit Select
                    Case "mês"
                        Exit Select
                    Case "i"
                        Exit Select
                    Case "ii"
                        Exit Select
                    Case "iii"
                        Exit Select
                    Case "iv"
                        Exit Select
                    Case "v"
                        Exit Select
                    Case "vi"
                        Exit Select
                    Case "vii"
                        Exit Select
                    Case "viii"
                        Exit Select
                    Case "xix"
                        Exit Select
                    Case "x"
                        Exit Select
                    Case "xi"
                        Exit Select
                    Case "xii"
                        Exit Select
                    Case "xiii"
                        Exit Select
                    Case "xiv"
                        Exit Select
                    Case "xv"
                        Exit Select
                    Case strTemp(i).StartsWith("xv")
                        Exit Select
                    Case strTemp(i).StartsWith("xx")
                        Exit Select
                    Case "se"
                        Exit Select
                    Case Else
                        sclAllQryWords.Add(strTemp(i))
                End Select
            End If
        Next
        Dim strAllQryWords(sclAllQryWords.Count - 1) As String
        sclAllQryWords.CopyTo(strAllQryWords, 0)
        Return strAllQryWords
    End Function

End Module
