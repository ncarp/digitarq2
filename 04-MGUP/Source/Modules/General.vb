
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

'************************************************************************************************
' Module: General
' Purpose: This code general functions that are used in a DB access and in AEC class
'          This is a copy of general from digitarq application with some changes.
' The Notation isn't used here.
'***************************************************************************************************
Imports System.Configuration

Public Module General

#Region "Database to interface"

    Public Function StrToInterface(ByVal v As String) As String
        If (v = "" Or v Is Nothing) Then Return "<i>(Campo n�o preenchido)</i>" Else Return v
    End Function

    Public Function DateToInterface(ByVal di As String, ByVal df As String, ByVal sep As String) As String
        If (df = "" Or df Is Nothing) Then Return di Else Return di + " " + sep + " " + df
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
        If obj Is System.DBNull.Value Then Return -1 Else Return CInt(obj)
    End Function

    Public Function DBToStr(ByVal obj As Object) As String
        If obj Is System.DBNull.Value Then Return "" Else Return obj
    End Function

    Public Function DBToBool(ByVal obj As Object) As Boolean
        If obj Is System.DBNull.Value Then Return False Else Return CBool(obj)
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

    Public Function BitToStr(ByVal v As Boolean) As String
        If v Then Return "True" Else Return "False"
    End Function

    Public Function DBToInt64(ByVal obj As Object) As Int64
        If obj Is System.DBNull.Value Then Return -1 Else Return CType(obj, Int64)
    End Function

#End Region

#Region "Type to Database"

    Public Function IntToDB(ByVal v As Integer) As Object
        If v = 0 Then Return System.DBNull.Value Else Return v
    End Function

    Public Function Int64ToDB(ByVal v As Int64) As Object
        If v = 0 Then Return System.DBNull.Value Else Return v
    End Function

    Public Function StrToDB(ByVal v As String) As Object
        If (v = "" Or v Is Nothing) Then Return System.DBNull.Value Else Return v
    End Function

    Public Function StrToDate(ByVal v As String) As Object
        If (v = "" Or v Is Nothing) Then Return System.DBNull.Value Else Return Date.Parse(v)
    End Function


    'Public Function DateToDB(ByVal v As Date) As String
    '    Return String.Format("{0}-{1}-{2}", (v.Year & "").PadLeft(4, "0"), (v.Month & "").PadLeft(2, "0"), (v.Day & "").PadLeft(2, "0"))
    'End Function

    'Public Function StrToDB(ByVal v As String) As String
    '    If v Is Nothing Then Return "" Else Return v.Replace("'", "")
    'End Function

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


    'Public Function StrToDate(ByVal v As String) As Date
    '    Try
    '        Dim d As Date = Date.Parse(v)
    '        Return d
    '    Catch ex As Exception
    '        Return Date.Parse("0001-01-01")
    '    End Try
    'End Function


    Public Function StrToBool(ByVal v As String) As Boolean
        Return v = "1" Or v = "yes"
    End Function

#End Region

#Region "Create  Html Tag"
    Public Function CreateTag(ByVal desc As String, ByVal value As String) As String
        Select Case value
            Case "" : Return ""
            Case Else : Return "<p> <font class='TextBlueBottom'>" & desc & "</font> <font class='TextGrayTop'> " & value & " </font> </p>"
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
