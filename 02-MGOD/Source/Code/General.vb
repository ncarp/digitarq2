
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

Imports System.Configuration
Imports System.IO


Module General

#Region "Globaly assigned variables"

    Public STATECONFIG_FILENAME As String = Application.UserAppDataPath & "\" & "MGOD.config"
    Public DATABASE_SQL_FILENAME As String = Application.StartupPath & "\sql\" & "Database.sql"
    'Public MANUAL_FILENAME As String = Application.StartupPath & "\manual\index.htm"


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

    Public Function IntToDB(ByVal v As Integer) As Object
        If (v = 0 Or v = -1) Then Return "NULL" Else Return v
    End Function

    Public Function Int64ToDB(ByVal v As Int64) As Object
        If (v = 0 Or v = -1) Then Return System.DBNull.Value Else Return v
    End Function

    Public Function StrToDB(ByVal v As String) As Object
        If (v = "" Or v Is Nothing) Then Return "" Else Return v
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

    Public Function GetFormTitle(ByVal Title As String) As String
        Return GetStandardFormTitle() & " " & Title
    End Function

    Private Function GetStandardFormTitle() As String
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Return String.Format(CStr(configurationAppSettings.GetValue("Application.FullName", GetType(System.String))), CStr(configurationAppSettings.GetValue("Application.Version", GetType(System.String))))
    End Function

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


#End Region

End Module
