
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articulação com a Direcção-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordenação
'* informática da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Português.
'* ---------------------------------------------------
'*
'* A redistribuição e utilização deste produto sob a
'* forma de código-fonte ou programa compilado, com ou
'* sem modificações, é permitida desde que o seguinte
'* conjunto de condições seja cumprido:
'* 
'*	* Todas as redistribuições do código-fonte 
'*	  deste produto deverão ser acompanhadas do
'*	  texto que compõe esta licença, incluindo o 
'*	  texto inicial de atribuição de autoria,
'*	  esta lista de condições e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direcção-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto não deverão ser utilizados na 
'*	  promoção de produtos derivados deste 
'*	  sem que seja obtido consentimento prévio, por
'*	  escrito, por parte dos visados.

'*	* A utilização da designação DigitArq, seus 
'*	  logótipos e nomes institucionais associados
'*	  é apenas permitida em distribuições que sejam
'*	  cópias exactas da versão oficial deste produto
'*	  aprovada e/ou distribuída pela Direcção-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto é permitido desde que a designação 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais não sejam utilizados em todo e
'*	  qualquer tipo de distribuição e/ou promoção 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE É DISTRIBUIDO PELA DIRECÇÃO-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUNÇÃO DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS NÃO LIMITADO A, GARANTIAS ASSOCIADAS
'* A COMÉRCIO DE PRODUTOS OU DECLARAÇÃO DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNSTÂNCIA PODERÁ A DIRECÇÃO-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONSÁVEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZAÇÃO DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS NÃO LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FALÊNCIA, INDEVIDA PRESTAÇÃO DE SERVIÇOS
'* OU NEGLIGÊNCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORRÊNCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informação sobre este produto ou a sua 
'* licença, é favor consultar o endereço electrónico
'* http://www.digitarq.pt

#End Region

Imports System.Collections
Imports System.Collections.Specialized
Imports System.Web
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Runtime.Remoting
'Imports CRAVDataBaseAccess

Public Module mShowItems

    Private objI As New SQLDataBase
    Private configReader As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    '*************************************************************************************************
    ' Function: strWriteTextLine
    ' Purpose:  It returns the Html tags which shows, on a line, the description of a db field and 
    '           filed database respective value.
    '           It is used to make the matriz image Metadata description page (used in ImageGOD.aspx)
    '***************************************************************************************************
    Public Function strWriteTextLine(ByVal strDescription As String, ByVal strSqlValue As String, ByVal strDimension As String) As String

        If strSqlValue.Trim = "" Then Return ""
        If strSqlValue = "0" Then Return ""
        strSqlValue = strSqlValue.Replace(ControlChars.NewLine, "</br>")
        Return "<font face=""Verdana, Arial, Helvetica, sans-serif"" color=""#000066"" size=""1"" >" & strDescription & ":  </font>" & _
               "<font face=""Verdana, Arial, Helvetica, sans-serif"" color=""#6666666"" size=""1"">" & strSqlValue & " " & strDimension & " </font></br>"
    End Function

    '*************************************************************************************************
    ' Function: strDraw3ColumnRow
    ' Purpose:  It returns the Html tags that draws a row with 3 columns.It is used for to list the search 
    '           results information.
    '           It is used in : ListShow.aspx; OrderByDate.aspx; OderByOtherLevel.aspx; OrderByTitle.aspx
    '***************************************************************************************************
    Public Function strDraw3ColumnRow(ByVal strExtra As String, ByVal strDescription As String, ByVal strSqlValue As String) As String
        If strSqlValue.Trim = "" Then Return ""
        Return "<tr width='450px'><td valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1'><strong> " & strExtra & "</strong></font></td>" & _
               "<td align='left'width='140px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1' >" & strDescription & "</font></td>" & _
               "<td align='left' colspan='3'valign=center><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>" & strSqlValue & "</font></td></tr>"
    End Function

    Public Function strDraw3ColumnRowTitles(ByVal strExtra As String, ByVal strDescription As String, ByVal strSqlValue As String) As String
        If strSqlValue Is Nothing Or strSqlValue = "" Then Return ""
        Return "<tr>" & _
                    "<td valign=top width='20px'><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1'><strong>" & strExtra & "</strong></font></td>" & _
                    "<td align='left'width='170px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1' >" & strDescription & "</font></td>" & _
                    "<td align='left' width='260px' valign=center><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>" & strSqlValue & "</font></td>" & _
               "</tr>"
    End Function

    Public Function strDraw3ColumnRowTitles(ByVal strDescription As String, ByVal strSqlValue As String) As String
        If strSqlValue Is Nothing Then Return ""
        Return "<tr>" & _
                    "<td valign=top width='30px'></td>" & _
                    "<td align='left'width='170px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1' >" & strDescription & "</font></td>" & _
                    "<td align='left' width='250px' valign=center><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>" & strSqlValue & "</font></td>" & _
               "</tr>"
    End Function

    Public Function strSeparator(ByVal strSqlValue As String) As String
        If strSqlValue Is Nothing Then Return ""
        Return "<TR>" & _
                    "<TD class='whiteSpace10' colSpan='3'></TD>" & _
               "</TR>"
    End Function

    Public Function strHeaderTable() As String
        Return "<table width=100% CellPadding=0 CellSpacing=0 border=0>"
    End Function

    Public Function strFooterTable() As String
        Return "</table>"
    End Function

    Public Function strCloseLine() As String
        Return "</td></tr>"
    End Function

    '*************************************************************************************************
    ' Function: strDraw3ColumnRowForRA
    ' Purpose:  It returns the Html tag that draws a row with 3 columns. It is used for to add the 
    '           authority register link to the registers that have it.
    '           It is used in : ListShow.aspx; OrderByDate.aspx; OderByOtherLevel.aspx; OrderByTitle.aspx
    '***************************************************************************************************
    Public Function strDraw3ColumnRowForRA(ByVal strLink As String, ByVal blnEac As Boolean) As String
        If blnEac Then
            Return "<tr width='450px'><td valign=top></td>" & _
               "<td align='left'width='140px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>" & strLink & "</font></td>" & _
               "<td align='left' colspan='3'valign=center></td></tr>"
        End If
        Return ""
    End Function

    Public Function strDraw3ColumnRowForRA(ByVal strDescription As String, ByVal strLink As String, ByVal blnEac As Boolean) As String
        If blnEac Then
            Return "<tr width='450px'><td valign=top></td>" & _
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
    Public Function strDraw2ColumnRow(ByVal description As String, ByVal value As String) As String

        If value.Trim = "" Then Return ""
        If value = "0" Then Return ""
        value = value.Replace(ControlChars.NewLine, "</br>")
        Return "<tr width='450px'><td  width='140px' align='left' valign=top width='148'><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1' >" & description & "</font></td>" & _
               "<td align='left'><p align='justify'> <font face='Verdana, Arial, Helvetica, sans-serif' color='#6666666' size='1'>" & value & "</font></p></td></tr>"
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
        Return "<tr width='450px'><td align='left' colspan='2' valign='bottom'><font class='TextBlueBottom' >" & strDescription & "</font></td></tr>" & _
               "<tr width='450px'><td align='left' colspan='2' valign='top'><p align='justify'><font class='TextGrayTop'>" & strSqlValue & "<br></font></p></td></tr>"
    End Function

    '*************************************************************************************************
    ' Function: strAlert
    ' Purpose:  It returns the Html tag that draws a row with 3 columns. It is used for to show the
    '           image alert and description. 
    '           It is used in : RegShow.aspx
    '***************************************************************************************************
    Public Function strAlert(ByVal strImageTag As String, ByVal blnValid As Boolean) As String

        If blnValid Then Return ""
        Return "<tr width='450px'><td colspan='2' align='left' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1' >" & strImageTag & "</font>" & _
               " <font face='Verdana, Arial, Helvetica, sans-serif' color='#cc3300' size='1'>Informação não tratada arquivisticamente</font></td></tr>"
    End Function

    Public Function strMsgError(ByVal strImageTag As String, ByVal blnValid As Boolean) As String

        If Not blnValid Then Return ""
        Return "<tr width='450px'><td colspan='3' align='center' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='red' size='1' >" & strImageTag & "</font></td></tr>"
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
            Return "<tr width='450px'><td  width='140px' align='left' valign=top width='148'><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1' >" & strDescription & "</font></td>" & _
                   "<td align='left'><p align='justify'> <font face='Verdana, Arial, Helvetica, sans-serif' color='#6666666' size='1'>" & strSqlValue & "</font></p></td></tr>"
        Else : Return ""
        End If

    End Function


    Public Function strProfiles(ByVal colProfiles As Collection) As String
        Dim strRet As System.Text.StringBuilder
        strRet.Append("<table width=100%>")
        For i As Integer = 0 To colProfiles.Count - 1
            strRet.Append("<tr>")
            strRet.Append("<td width=20%><asp:</td>")
        Next
    End Function

    Public Function getProfile(ByVal strSqlValue As String) As String
        If strSqlValue Is Nothing Then Return "<i>Não atribuido</i>"
        Return strSqlValue
    End Function

    '*****************************************************************************************************
    ' Function: strAllFunctionsProfiles
    ' Purpose:  It returns the Html tag that draws a list of the all functions in the backoffice
    '           It is used in : 
    '*****************************************************************************************************

    Public Function strAllProfileFunctions(ByVal strAplicationCode As String, Optional ByVal profileID As Integer = 0) As String

        Dim functionCode As String
        Dim functionName As String
        Dim bool As Boolean

        Dim strRet As New System.Text.StringBuilder

        Dim FunctionCollection As New FunctionCollection
        FunctionCollection = objI.getAllProfileFunctions(strAplicationCode, profileID, "null")

        If FunctionCollection.Count = 0 Then
            Return ""
        End If

        strRet.Append("<ul Class=""ontology"">")
        For i As Integer = 0 To FunctionCollection.Count - 1
            functionCode = FunctionCollection(i).FunctionCode
            functionName = FunctionCollection(i).FunctionName
            bool = FunctionCollection(i).IsInProfile
            If bool Then
                strRet.Append("<li>")
                strRet.Append("<input type=""checkbox"" name=""functions"" checked value=""" & functionCode & """ Class=""PFSelected"" onClick=""ec(this);"">" & functionName)
                strRet.Append("<ul class=""ontologyS"">")
            Else
                strRet.Append("<li>")
                strRet.Append("<input type=""checkbox"" name=""functions"" value=""" & functionCode & """ Class=""PFUnselected"" onClick=""ec(this);"">" & functionName)
                strRet.Append("<ul class=""ontologySU"">")
            End If

            Dim SubFunctionCollection As New FunctionCollection
            SubFunctionCollection = objI.getAllProfileFunctions(strAplicationCode, profileID, functionCode)
            For ii As Integer = 0 To SubFunctionCollection.Count - 1
                functionCode = SubFunctionCollection(ii).FunctionCode
                functionName = SubFunctionCollection(ii).FunctionName
                bool = SubFunctionCollection(ii).IsInProfile
                If bool Then
                    strRet.Append("<li>")
                    strRet.Append("<input type=""checkbox"" name=""subFunctions"" checked value=""" & functionCode & """ Class=""PFSelected"" onClick=""ec(this);"">" & functionName)
                    strRet.Append("<ul class=""ontologyS"">")
                Else
                    strRet.Append("<li>")
                    strRet.Append("<input type=""checkbox"" name=""subFunctions"" value=""" & functionCode & """ Class=""PFUnselected"" onClick=""ec(this);"">" & functionName)
                    strRet.Append("<ul class=""ontologySU"">")
                End If
                Dim SubSubFunctionCollection As New FunctionCollection
                SubSubFunctionCollection = objI.getAllProfileFunctions(strAplicationCode, profileID, functionCode)
                For iii As Integer = 0 To SubSubFunctionCollection.Count - 1
                    functionCode = SubSubFunctionCollection(iii).FunctionCode
                    functionName = SubSubFunctionCollection(iii).FunctionName
                    bool = SubSubFunctionCollection(iii).IsInProfile
                    strRet.Append("<li>")
                    If bool Then
                        strRet.Append("<input type=""checkbox"" name=""subSubFunctions"" checked value=""" & functionCode & """ Class=""PSFSelected"">" & functionName)
                    Else
                        strRet.Append("<input type=""checkbox"" name=""subSubFunctions"" value=""" & functionCode & """ Class=""PSFUnselected"">" & functionName)
                    End If
                    strRet.Append("</li>")
                Next
                strRet.Append("</ul>")
                strRet.Append("</li>")
            Next
            strRet.Append("</ul>")
            strRet.Append("</li>")
        Next
        strRet.Append("</ul>")
        Dim strReturn As String = strRet.ToString
        Return strReturn
    End Function

    Public Function strAplicationFunctions(ByVal strAplicationCode As String, ByVal functionCodeSelected As String) As String
        Dim FunctionsCollection As New FunctionCollection
        FunctionsCollection = objI.getAplicationFunctions(strAplicationCode, "null")

        Dim pageUrl As String = configReader.GetValue("urlAplicationFunctions", GetType(String))
        Dim strRet As New System.Text.StringBuilder
        Dim functionCode As String
        Dim functionName As String


        Dim objAplication As Aplication = objI.loadAplication(strAplicationCode)

        strRet.Append("<ul Class=""ontology"">")
        strRet.Append("<li>")
        If functionCodeSelected = "null" Then
            strRet.Append("<a href=" & pageUrl & "&fid=null&aid=" & strAplicationCode & " class=""selected"">" & objAplication.AplicationName & "</a>")
        Else
            strRet.Append("<a href=" & pageUrl & "&fid=null&aid=" & strAplicationCode & ">" & objAplication.AplicationName & "</a>")
        End If
        strRet.Append("</li>")
        strRet.Append("<ul Class=""ontology"">")
        For i As Integer = 0 To FunctionsCollection.Count - 1
            functionCode = FunctionsCollection.Item(i).FunctionCode
            functionName = FunctionsCollection.Item(i).FunctionName

            strRet.Append("<li>")
            If functionCode = functionCodeSelected Then
                strRet.Append("<a href=" & pageUrl & "&fid=" & functionCode & "&aid=" & strAplicationCode & " class=""selected"">" & "[" & functionCode & "] " & functionName & "</a>")
            Else
                strRet.Append("<a href=" & pageUrl & "&fid=" & functionCode & "&aid=" & strAplicationCode & ">" & "[" & functionCode & "] " & functionName & "</a>")
            End If
            strRet.Append("<ul class=""ontology"">")

            Dim SubFunctionsCollection As New FunctionCollection
            SubFunctionsCollection = objI.getAplicationFunctions(strAplicationCode, functionCode)

            For ii As Integer = 0 To SubFunctionsCollection.Count - 1
                functionCode = SubFunctionsCollection.Item(ii).FunctionCode
                functionName = SubFunctionsCollection.Item(ii).FunctionName

                strRet.Append("<li>")
                If functionCode = functionCodeSelected Then
                    strRet.Append("<a href=" & pageUrl & "&fid=" & functionCode & "&aid=" & strAplicationCode & " class=""selected"">" & "[" & functionCode & "] " & functionName & "</a>")
                Else
                    strRet.Append("<a href=" & pageUrl & "&fid=" & functionCode & "&aid=" & strAplicationCode & ">" & "[" & functionCode & "] " & functionName & "</a>")
                End If
                strRet.Append("<ul class=""ontology"">")

                Dim SubSubFunctionsCollection As New FunctionCollection
                SubSubFunctionsCollection = objI.getAplicationFunctions(strAplicationCode, functionCode)
                For iii As Integer = 0 To SubSubFunctionsCollection.Count - 1
                    functionCode = SubSubFunctionsCollection.Item(iii).FunctionCode
                    functionName = SubSubFunctionsCollection.Item(iii).FunctionName

                    strRet.Append("<li>")
                    If functionCode = functionCodeSelected Then
                        strRet.Append("<a href=" & pageUrl & "&fid=" & functionCode & "&aid=" & strAplicationCode & "&level=last class=""selected"">" & "[" & functionCode & "] " & functionName & "</a>")
                    Else
                        strRet.Append("<a href=" & pageUrl & "&fid=" & functionCode & "&aid=" & strAplicationCode & "&level=last>" & "[" & functionCode & "] " & functionName & "</a>")
                    End If
                    strRet.Append("</li>")
                Next
                strRet.Append("</ul>")
                strRet.Append("</li>")
            Next
            strRet.Append("</ul>")
            strRet.Append("</li>")
        Next
        strRet.Append("</ul>")
        strRet.Append("</ul>")
        Dim strReturn As String = strRet.ToString
        Return strReturn
    End Function


    '*****************************************************************************************************
    ' Function: strFunctionsMenu
    ' Purpose:  It returns the Html tag that draws a menu with the functions of the one profile
    '           It is used in : 
    '*****************************************************************************************************

    Public Function strFunctionsMenu(Optional ByVal profileID As Integer = 0) As String

        Dim FunctionCollection As New FunctionCollection

        Dim functionCode As String
        Dim functionName As String

        FunctionCollection = objI.getProfileFunctions(profileID, "null")

        Dim strRet As New System.Text.StringBuilder
        Dim top As Boolean = True
        Try
            For i As Integer = 0 To FunctionCollection.Count - 1
                functionCode = FunctionCollection(i).FunctionCode
                functionName = FunctionCollection(i).FunctionName
                If top Then
                    strRet.Append("<span class=""title"" id=""top"">")
                Else
                    strRet.Append("<span class=""title"">")
                End If
                strRet.Append("<img src=""Images/expanded.gif"" class=""arrow"" alt=""-"">")
                strRet.Append(functionName)
                strRet.Append("</span>")
                strRet.Append("<div class=""submenu"">")

                Dim SubFunctionCollection As New FunctionCollection
                SubFunctionCollection = objI.getProfileFunctions(profileID, functionCode)

                'Dim hshReference As Hashtable = ConfigurationSettings.GetConfig("references")

                For ii As Integer = 0 To SubFunctionCollection.Count - 1
                    functionCode = SubFunctionCollection(ii).FunctionCode
                    functionName = SubFunctionCollection(ii).FunctionName
                    If functionCode = "registerRequest" Then
                        strRet.Append("<a href=")
                        Dim FrontOfficeServerPath As String = ConfigurationManager.AppSettings("FrontOfficeServerPath")
                        strRet.Append(FrontOfficeServerPath & "defaultIn.aspx?" & "&area=admin")
                        strRet.Append(" target=_blank")
                        strRet.Append(">")
                        strRet.Append(functionName)
                        strRet.Append("</a>")
                        strRet.Append(" ")
                    Else
                        strRet.Append("<a href=")
                        strRet.Append("defaultIn.aspx?page=" & functionCode)
                        strRet.Append(">")
                        strRet.Append(functionName)
                        strRet.Append("</a>")
                        strRet.Append(" ")
                    End If
                Next
                strRet.Append("</div>")
                top = False
            Next
            Return strRet.ToString
        Catch ex As Exception
            Dim erro As String = ex.ToString
            Dim aa As String = "aa"
        Finally

        End Try
    End Function


    Public Function strFunctionsHorizontalMenu(ByVal intProfileID As Integer, ByVal FunctionCollection As FunctionCollection, ByVal qsSelect As String) As String

        Dim functionCode As String
        Dim functionName As String


        If FunctionCollection.Count <= 1 Then
            Return ""
        End If

        Dim strRet As New System.Text.StringBuilder

        'Dim hshReference As Hashtable = ConfigurationSettings.GetConfig("references")
        Dim hshReference As Hashtable = ConfigurationManager.GetSection("references")

        Try
            strRet.Append("<ul class=""basictab"">")
            For i As Integer = 0 To FunctionCollection.Count - 1
                functionCode = FunctionCollection(i).FunctionCode
                functionName = FunctionCollection(i).FunctionName

                If functionCode = qsSelect Then
                    strRet.Append("<li class=""selected"">")
                Else
                    strRet.Append("<li>")
                End If
                strRet.Append("<a href=")
                strRet.Append(hshReference(functionCode))
                strRet.Append(">")
                strRet.Append(functionName)
                strRet.Append("</a>")
                strRet.Append("</li>")
            Next
            Return strRet.ToString
        Catch ex As Exception
        Finally
        End Try

    End Function

    Public Function strCorrespondencePath(ByVal array As ArrayList) As String
        Dim strRet As New System.Text.StringBuilder
        strRet.Append("<p class=""breadcrumb"">")
        For i As Integer = 0 To array.Count - 2
            strRet.Append("<a href=""")
            strRet.Append("../OtherWindows/windowDetails.aspx")
            strRet.Append("?page=correspondence")
            strRet.Append(array(i)(1))
            strRet.Append("&ID=")
            strRet.Append(array(i)(0))
            strRet.Append(""">")
            strRet.Append(array(i)(0))
            strRet.Append("</a>")
            strRet.Append(" ")
        Next
        strRet.Append(array(array.Count - 1)(0))
        strRet.Append("</p>")

        Return strRet.ToString
    End Function

    'Public Function strAplicationsList()
    '    Dim strRet As New System.Text.StringBuilder
    '    Dim hash As Hashtable = objI.getAllAplications
    '    'strRet.Append("<ul class=""aplications"">")
    '    For Each key As Int16 In hash.Keys
    '        'strRet.Append("<li class=""aplications"">")
    '        strRet.Append("<input type=""checkbox"" name=""aplications"" value=""" & key & """ class=""aplications"">" & hash(key))
    '        strRet.Append("<br>")
    '        'strRet.Append("</li>")
    '    Next
    '    'strRet.Append("</ul>")
    '    Return strRet.ToString
    'End Function


    Public Function BitToStr(ByVal v As Boolean) As String
        If v Then Return "True" Else Return "False"
    End Function

End Module
