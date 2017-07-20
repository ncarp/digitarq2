Imports System.Collections
Imports System.Collections.Specialized

'********************************************************************************
' Module: mShowItems
' Purpose: This module treats all data in order to present all items (records)
'           given by the sql query constructed in the mDataBaseModule
'*********************************************************************************
Public Module mShowItems

    '********************************************************************************
    ' Purpose: This Enum saves the type of search to be able to show to the user the 
    '          correct page menu Header.
    '*********************************************************************************
    Public Enum SearchMode
        Basics
        Advanceds
    End Enum


    '********************************************************************************
    ' Function: strGetHTMLTagAlertImg
    ' Purpose: It returns the HMTL Tag For the Image Alert show, for the untreated
    '           Units.
    '*********************************************************************************

    Public Function strGetHTMLTagAlertImg(ByVal blnValid As Boolean) As String
        If Not blnValid Then
            Return "<img alt='Informação não tratada arquivisticamente' align ='top' src='Images/Alert.gif'/>"
        End If
    End Function


    '**********************************************************************************
    ' Function: strGetImgPth
    ' Purpose:  it returns link corresponding to the read value from the OtherLevel field
    '***********************************************************************************

    Public Function strGetImgPth(ByVal strLevel As String) As String
        strLevel = strLevel.ToLower.Trim
        Return "Images/" & strLevel & ".jpg"
    End Function


    Public Function strGetImageURL(ByVal DOID As Int64, ByVal FileID As Int64) As String
        Dim strImageUrl As String
        Dim DigitalObject As New DigitalObject
        If FileID = -1 Then
            FileID = DigitalObject.GetFirstImage(DOID)
        End If

        strImageUrl = String.Format("./ShowFile.aspx?DOId={0}&FileId={1}&imageType=1", DOID, FileID)
        Return strImageUrl
    End Function

    Public Function strGetDigitalObjectURL(ByVal DOID As Int64, ByVal FileID As Int64) As String
        Dim strURL As String
        Dim DigitalObject As New DigitalObject
        If FileID = -1 Then
            FileID = DigitalObject.GetFirstImage(DOID)
        End If

        strURL = String.Format("./ODDisplay.aspx?DOId={0}&NodeID=_{1}&imageType=1", DOID, FileID)
        Return strURL
    End Function


    '*********************************************************************************
    ' Function: strWriteDate
    ' Purpose:  It returns the complete date (final to Initial) in the correct way
    '*********************************************************************************

    Public Function strWriteDate(ByVal blnCAInitial As Boolean, ByVal strDateInitial As String, ByVal blnCAFinal As Boolean, ByVal strDateFinal As String) As String

        'For date Initial and Final
        strDateInitial = strGetDate(strDateInitial)
        strDateFinal = strGetDate(strDateFinal)

        If strDateInitial = strDateInitial.Empty And strDateFinal = strDateFinal.Empty Then
            Return ""
        End If

        If strDateInitial = strDateInitial.Empty Then
            If Not blnCAFinal Then
                Return "c.a." & strDateFinal
            Else
                Return strDateFinal
            End If
        End If

        If strDateFinal = strDateFinal.Empty Then
            If Not blnCAInitial Then
                Return "c.a." & strDateInitial
            Else
                Return strDateInitial
            End If
        End If

        If strDateInitial = strDateFinal Then
            If Not blnCAInitial And Not blnCAFinal Then
                Return "c.a." & strDateInitial
            Else
                Return strDateInitial
            End If
        End If

        If Not blnCAInitial And Not blnCAFinal Then
            Return "c.a. " & strDateInitial & "/" & " c.a. " & strDateFinal

        ElseIf Not blnCAFinal Then
            Return strDateInitial & "/" & " c.a. " & strDateFinal

        ElseIf Not blnCAInitial Then
            Return "c.a. " & strDateInitial & " a " & strDateFinal

        End If
        Return strDateInitial & "/" & strDateFinal
    End Function


    '*************************************************************************************************
    ' Function: strGetDate
    ' Purpose:  It returns the date, final or initial, in a correct way. It is year, day , 
    '           month if have a valid value. If the register have only year and all others with 0, 
    '           day- 00, month- 00, the user then only see year data, otherwise 
    '           it will return the date with "?" instead of "0" (db value for an inexistence information).
    '***************************************************************************************************

    Public Function strGetDate(ByVal strDate As String) As String
        Dim strDateParts() As String = strDate.Split("-")
        Dim i As Integer

        For i = 0 To strDateParts.Length - 1
            Select Case strDateParts(i)
                Case "0000"
                    strDateParts(i) = ""
                Case "00"
                    strDateParts(i) = ""
            End Select
        Next

        If strDateParts(0) = "" Then
            Return strDate.Empty
        End If

        strDate = Join(strDateParts, "-")

        'If we have only the year
        If strDate.EndsWith("--") Then
            strDate = strDate.TrimEnd("-")
        End If

        'If we have the year and month
        If strDate.EndsWith("-") Then
            strDate &= "??"
        End If

        ' If we have year and day
        strDate = strDate.Replace("--", "-??-")

        Return strDate
    End Function

    Public Function strWriteTreeNodeName(ByVal strUnitID As String, ByVal strUnitTitle As String, ByVal strUnitTitleType As String, Optional ByVal strDate As String = "")
        Dim strUnitTitleTrunc As String
        If strUnitTitle.Length > 35 Then
            strUnitTitleTrunc = strUnitTitle.Substring(0, 35)
            strUnitTitleTrunc = strUnitTitleTrunc & "..."
        Else
            strUnitTitleTrunc = strUnitTitle
        End If
        strUnitTitleTrunc = strWriteTitle(strUnitTitleTrunc, strUnitTitleType)
        Return "<span title='" & strUnitTitle & "'>" & _
                "<font size='1'>" & _
                "<nobr><b>" & strUnitID & "</b> " & strUnitTitleTrunc & " <font color='orange'>" & strDate & "</font></nobr>" & _
                "</font>" & _
                "</span>"
    End Function

    Public Function strWriteTitle(ByVal strUnitTitle As String, ByVal strUnitTitleType As String) As String
        If strUnitTitleType = ConfigurationManager.AppSettings("UnitTitleType2") Then
            Return "[" & strUnitTitle & "]"
        Else
            Return strUnitTitle
        End If
    End Function

    Public Function strHeaderDigitalObjects() As String
        Return "<tr><td colspan=5>" & _
                    "<table cellpadding=0 cellspacing=5 border=0 align=center>" & _
               "<tr valign=top align=center>"
    End Function

    Public Function strFooterDigitalObjects() As String
        Return "</tr>" & _
               "</table>" & _
               "</td></tr>"
    End Function

    Public Function strHeaderDigitalObjectsLoc() As String
        Return "<tr><td colspan=3>" & _
                    "<table cellpadding=0 cellspacing=0 border=0 align=left>" & _
               "<tr valign=top align=center>"
    End Function

    Public Function strFooterDigitalObjectsLoc() As String
        Return "</tr>" & _
               "</table>" & _
               "</td></tr>"
    End Function

    Public Function strHeaderTable() As String
        Return "<table width=100% CellPadding=0 CellSpacing=0 border=0>"
    End Function

    Public Function strFooterTable() As String
        Return "</table>"
    End Function

    Public Function strSeparator(ByVal intColspan As Integer)
        Return "<tr width=430px>" & _
                    "<td align='left' colspan='" & intColspan & "'><br/></td>" & _
                "</tr>"
    End Function


    '*************************************************************************************************
    ' Function: strWriteTextLine
    ' Purpose:  It returns the Html tags which shows, on a line, the description of a db field and 
    '           filed database respective value.
    '           It is used to make the matriz image Metadata description page (used in ImageGOD.aspx)
    '***************************************************************************************************

    Public Function strWriteTextLine(ByVal strDescription As String, ByVal strSqlValue As String, ByVal strDimension As String) As String
        If strSqlValue.Trim = "" Or strSqlValue = "=" Then Return ""
        strSqlValue = strSqlValue.Replace(ControlChars.NewLine, "</br>")
        Return "<font class='TextNavy'>" & strDescription & ": </font>" & _
               "<font class='TextGray'>" & strSqlValue & " " & strDimension & " </font></br>"
    End Function


    '*************************************************************************************************
    ' Function: strDraw3ColumnRow
    ' Purpose:  It returns the Html tags that draws a row with 3 columns.It is used for to list the search 
    '           results information.
    '           It is used in : ListShow.aspx; OrderByDate.aspx; OderByOtherLevel.aspx; OrderByTitle.aspx
    '***************************************************************************************************

    Public Function strDraw3ColumnRow(ByVal strExtra As String, ByVal strDescription As String, ByVal strSqlValue As String) As String
        If strSqlValue.Trim = "" Then Return ""
        Return "<tr width='430px'><td valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1'><strong> " & strExtra & "</strong></font></td>" & _
               "<td align='left'width='140px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1' >" & strDescription & "</font></td>" & _
               "<td align='left' colspan='3'valign=center><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>" & strSqlValue & "</font></td></tr>"
    End Function


    '*************************************************************************************************
    ' Function: strDraw3ColumnRowForRA
    ' Purpose:  It returns the Html tag that draws a row with 3 columns. It is used for to add the 
    '           authority register link to the registers that have it.
    '           It is used in : ListShow.aspx; OrderByDate.aspx; OderByOtherLevel.aspx; OrderByTitle.aspx
    '***************************************************************************************************

    Public Function strDraw3ColumnRowForRA(ByVal strLink As String, ByVal blnEac As Boolean) As String
        If blnEac Then
            Return "<tr width='430px'><td valign=top></td>" & _
               "<td align='left'width='140px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>" & strLink & "</font></td>" & _
               "<td align='left' colspan='3'valign=center></td></tr>"
        End If
        Return ""
    End Function

    Public Function strDraw3ColumnRowForRA(ByVal strDescription As String, ByVal strLink As String, ByVal blnEac As Boolean) As String
        If blnEac Then
            Return "<tr width='430px'><td valign=top></td>" & _
               "<td align='left'width='140px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1'>" & strDescription & "</font></td>" & _
               "<td align='left' colspan='3'valign=center><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>" & strLink & "</font></td></tr>"
        End If
        Return ""
    End Function


    '*************************************************************************************************
    ' Function: strDraw2ColumnRow
    ' Purpose:  It returns the Html tag that draws a row with 2 columns. It is used for to show all 
    '           the information related with the chosen register (unit).
    '           It is used in : RegShow.aspx
    '***************************************************************************************************

    Public Function strDraw2ColumnRow(ByVal strDescription As String, ByVal strValue As String) As String
        If strValue.Trim = "" Or strValue = "0" Then Return ""
        strValue = strValue.Replace(ControlChars.NewLine, "</br>")
        Return "<tr width='430px'><td  width='140px' align='left' valign=top class='TextNavy'>" & strDescription & "</td>" & _
               "<td align='left'><p align='justify' class=TextGray>" & strValue & "</p></td></tr>"
    End Function

    Public Function strDraw2ColumnRowTitle(ByVal strDescription As String) As String
        Return "<tr width='430px'><td  width='140px' align='left' valign=top class='TextNavy'>" & strDescription & "</td>" & _
               "<td align='left'></td></tr>"
    End Function


    '*************************************************************************************************
    ' Function: strDraw2ColumnRowChangeLine
    ' Purpose:  It returns the Html 2 tags that draws a row with 2 columns each. It is used for to show
    '           the description and the bd value in separated lines.
    '           It is used in : RegShow.aspx
    '***************************************************************************************************

    Public Function strDraw2ColumnRowChangeLine(ByVal strDescription As String, ByVal strSqlValue As String) As String
        If strSqlValue.Trim = "" Then Return ""
        If strSqlValue = "0" Then Return ""
        strSqlValue = strSqlValue.Replace(ControlChars.NewLine, "</br>")
        Return "<tr width='430px'><td align='left' colspan='2' valign='bottom' class='TextNavy'>" & strDescription & "</td></tr>" & _
               "<tr width='430px'><td align='left' colspan='2' valign='top'><p align='justify' class='TextGray'>" & strSqlValue & "<br></p></td></tr>"
    End Function


    '*************************************************************************************************
    ' Function: strAlert
    ' Purpose:  It returns the Html tag that draws a row with 3 columns. It is used for to show the
    '           image alert and description. 
    '           It is used in : RegShow.aspx
    '***************************************************************************************************

    Public Function strAlert(ByVal strImageTag As String, ByVal blnValid As Boolean) As String
        If blnValid Then Return ""
        Return "<tr width='430px'><td colspan='2' align='left' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1'>" & strImageTag & "</font>" & _
               " <font face='Verdana, Arial, Helvetica, sans-serif' color='#cc3300' size='1'>Informação não tratada arquivisticamente</font></td></tr>"
    End Function


    '*************************************************************************************************
    ' Function: strDimensions
    ' Purpose:  It returns the Html tag that draws a row with 2 columns. It is used to show the deminsions
    '           db value only for registers that are UI, D, DC. In other Levels this unit characteristics  
    '           doesn´t make sence.
    '           It is used in : RegShow.aspx
    '***************************************************************************************************

    Public Function strDimensions(ByVal strOtherLevel As String, ByVal strDescription As String, ByVal strSqlValue As String) As String

        If strSqlValue.Trim = "" Then Return ""
        If strSqlValue = "0" Then Return ""
        If strOtherLevel.Equals("UI") Or strOtherLevel.Equals("D") Or strOtherLevel.Equals("DC") Then
            strSqlValue = strSqlValue.Replace(ControlChars.NewLine, "</br>")
            Return "<tr width='430px'>" & _
                   "<td  width='140px' align='left' valign='top'>" & _
                   "<font class='TextNavy' size='1' >" & strDescription & "</font></td>" & _
                   "<td align='left'><p align='justify'><font class='TextGray' size='1'>" & strSqlValue & "</font></p></td></tr>"
        Else : Return ""
        End If

    End Function


    '*************************************************************************************************
    ' Function: strExtent
    ' Purpose:  It returns the Html tag that draws a row with 2 columns. It is used to show the extension 
    '           deminsion db value. 
    '           It is used in : RegShow.aspx
    '***************************************************************************************************

    Public Function strExtent(ByVal OtherLevel As String, ByVal ExtentLeaf As Integer, ByVal ExtentPage As Integer, _
        ByVal ExtentBook As Integer, ByVal ExtentMaco As Integer, ByVal ExtentMacete As Integer, ByVal ExtentFolder As Integer, _
        ByVal ExtentCover As Integer, ByVal Extentcapilha As Integer, ByVal ExtentRoll As Integer, _
        ByVal ExtentBox As Integer, ByVal ExtentEnvelope As Integer, ByVal ExtentAlbum As Integer, ByVal ExtentOther As Integer) As String
        ' in this function i didn't use the Notation for the function parameter once they are named like in the db.
        ' It was more easier to construct the function

        Dim sclOutput As New StringCollection

        If (OtherLevel = "D" Or OtherLevel = "DC" Or OtherLevel = "UI") Then
            If (ExtentLeaf <> 0 And ExtentLeaf <> -1) Then
                If ExtentLeaf = 1 Then
                    sclOutput.Add(ExtentLeaf & " folha")
                Else
                    sclOutput.Add(ExtentLeaf & " folhas")
                End If
            End If
            If (ExtentPage <> 0 And ExtentPage <> -1) Then
                If ExtentPage = 1 Then
                    sclOutput.Add(ExtentPage & " página")
                Else
                    sclOutput.Add(ExtentPage & " páginas")
                End If

            End If
        End If
        If ExtentBook <> 0 And ExtentBook <> -1 Then
            If ExtentBook = 1 Then
                sclOutput.Add(ExtentBook & " livro")
            Else
                sclOutput.Add(ExtentBook & " livros")
            End If

        End If
        If ExtentMaco <> 0 And ExtentMaco <> -1 Then
            If ExtentMaco = 1 Then
                sclOutput.Add(ExtentMaco & " maço")
            Else
                sclOutput.Add(ExtentMaco & " maços")
            End If

        End If
        If ExtentMacete <> 0 And ExtentMacete <> -1 Then
            If ExtentMacete = 1 Then
                sclOutput.Add(ExtentMacete & " macete")
            Else
                sclOutput.Add(ExtentMacete & " macetes")
            End If

        End If
        If ExtentFolder <> 0 And ExtentFolder <> -1 Then

            If ExtentFolder = 1 Then
                sclOutput.Add(ExtentFolder & " pasta")
            Else
                sclOutput.Add(ExtentFolder & " pastas")
            End If
        End If
        If ExtentCover <> 0 And ExtentCover <> -1 Then

            If ExtentCover = 1 Then
                sclOutput.Add(ExtentCover & " capa")
            Else
                sclOutput.Add(ExtentCover & " capas")
            End If
        End If
        If Extentcapilha <> 0 And Extentcapilha <> -1 Then
            If Extentcapilha = 1 Then
                sclOutput.Add(Extentcapilha & " capilha")
            Else
                sclOutput.Add(Extentcapilha & " capilhas")
            End If

        End If

        If ExtentRoll <> 0 And ExtentRoll <> -1 Then
            If ExtentRoll = 1 Then
                sclOutput.Add(ExtentRoll & " rolo")
            Else
                sclOutput.Add(ExtentRoll & " rolos")
            End If

        End If
        If ExtentBox <> 0 And ExtentBox <> -1 Then
            If ExtentBox = 1 Then
                sclOutput.Add(ExtentBox & " caixa")
            Else
                sclOutput.Add(ExtentBox & " caixas")
            End If

        End If
        If ExtentEnvelope <> 0 And ExtentEnvelope <> -1 Then
            If ExtentEnvelope = 1 Then
                sclOutput.Add(ExtentEnvelope & " envelope")
            Else
                sclOutput.Add(ExtentEnvelope & " envelopes")
            End If

        End If
        If ExtentAlbum <> 0 And ExtentAlbum <> -1 Then
            If ExtentAlbum = 1 Then
                sclOutput.Add(ExtentAlbum & " álbum")
            Else
                sclOutput.Add(ExtentAlbum & " álbuns")
            End If

        End If
        If ExtentOther <> 0 And ExtentOther <> -1 Then
            If ExtentOther = 1 Then
                sclOutput.Add(ExtentOther & " outro ")
            Else
                sclOutput.Add(ExtentOther & " outros ")
            End If

        End If

        If sclOutput.Count <> 0 Then
            Dim strReturns As String
            Dim strTempArr(sclOutput.Count - 1) As String

            sclOutput.CopyTo(strTempArr, 0)
            strReturns = Join(strTempArr, "; ")
            Return "<tr width='430px'>" & _
                "<td  width='140px' align='left' valign='bottom'>" & _
                "<font class='TextNavy' size='1'>Dimensão </font>" & _
                "</td>" & _
                "<td align='left' valign='bottom'>" & _
                "<font class='TextGray' size='1'>" & strReturns & "</font>" & _
                "</td>" & _
                "</tr>"
        Else : Return ""
        End If
    End Function


    '*************************************************************************************************
    ' Function: strLevelName
    ' Purpose:  It returns the level name according to de db OtherLevel read from the table components.
    '           It is used in : RegShow.aspx, ListShow.aspx, OrderByDate.aspx, OrderByTitle.aspx
    '           and OrderByOtherLevel.aspx
    '***************************************************************************************************

    Public Function strLevelName(ByVal strOtherLevel As String) As String
        Select Case strOtherLevel
            Case "F"
                Return "Fundo"
            Case "SF"
                Return "Subfundo"
            Case "SC"
                Return "Secção"
            Case "SSC"
                Return "Subsecção"
            Case "SSSC"
                Return "Subsubsecção"
            Case "SR"
                Return "Série"
            Case "SSR"
                Return "Subsérie"
            Case "UI"
                Return "Unidade de instalação"
            Case "D"
                Return "Documento simples"
            Case "DC"
                Return "Documento composto"
        End Select
    End Function

End Module
