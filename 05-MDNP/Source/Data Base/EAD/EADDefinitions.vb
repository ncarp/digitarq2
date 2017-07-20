
Module EADDefinitions
    Public Const OTHERLEVEL_FONDS As String = "F"
    Public Const OTHERLEVEL_SUBFONDS As String = "SF"
    Public Const OTHERLEVEL_SECTION As String = "SC"
    Public Const OTHERLEVEL_SUBSECTION As String = "SSC"
    Public Const OTHERLEVEL_SUBSUBSECTION As String = "SSSC"
    Public Const OTHERLEVEL_SERIES As String = "SR"
    Public Const OTHERLEVEL_SUBSERIES As String = "SSR"
    Public Const OTHERLEVEL_INSTALATIONUNIT As String = "UI"
    Public Const OTHERLEVEL_COMPOSEDDOCUMENT As String = "DC"
    Public Const OTHERLEVEL_DOCUMENT As String = "D"

    Public Const UNITID_NEW As String = "[novo]"

    Public Const XML_EADHEADER As String = "<eadheader> <eadid countrycode='pt' mainagencycode='adprt' url='http://www.adporto.org'/>" & _
        "<filedesc> <titlestmt> <titleproper/> <author>Arquivo Distrital do Porto</author> </titlestmt> <publicationstmt> " & _
        "<publisher>Arquivo Distrital do Porto</publisher> <date>© 2003</date> </publicationstmt> </filedesc> <profiledesc> " & _
        "<langusage>A descrição deste fundo encontra-se em <language>português</language>.</langusage>" & _
        "</profiledesc> </eadheader>"

    Public Const XML_EAD_NEW As String = "<ead>" & XML_EADHEADER & "<archdesc/> </ead>"


    Public Function GetOtherLevelIndex(ByVal OtherLevel As String) As Integer
        Select Case OtherLevel
            Case OTHERLEVEL_FONDS : Return 1
            Case OTHERLEVEL_SUBFONDS : Return 2
            Case OTHERLEVEL_SECTION : Return 3
            Case OTHERLEVEL_SUBSECTION : Return 4
            Case OTHERLEVEL_SUBSUBSECTION : Return 5
            Case OTHERLEVEL_SERIES : Return 6
            Case OTHERLEVEL_SUBSERIES : Return 7
            Case OTHERLEVEL_INSTALATIONUNIT : Return 8
            Case OTHERLEVEL_COMPOSEDDOCUMENT : Return 9
            Case OTHERLEVEL_DOCUMENT : Return 10
            Case Else : Return 0
        End Select
    End Function

    Public Function OtherLevelIndexToOtherLevel(ByVal OtherLevelIndex As Integer) As String
        Select Case OtherLevelIndex
            Case 1 : Return OTHERLEVEL_FONDS
            Case 2 : Return OTHERLEVEL_SUBFONDS
            Case 3 : Return OTHERLEVEL_SECTION
            Case 4 : Return OTHERLEVEL_SUBSECTION
            Case 5 : Return OTHERLEVEL_SUBSUBSECTION
            Case 6 : Return OTHERLEVEL_SERIES
            Case 7 : Return OTHERLEVEL_SUBSERIES
            Case 8 : Return OTHERLEVEL_INSTALATIONUNIT
            Case 9 : Return OTHERLEVEL_COMPOSEDDOCUMENT
            Case 10 : Return OTHERLEVEL_DOCUMENT
            Case Else : Return "Unknown"
        End Select
    End Function

End Module
