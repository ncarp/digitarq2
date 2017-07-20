
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
        If (v = "" Or v Is Nothing) Then Return "<i>(Campo não preenchido)</i>" Else Return v
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
