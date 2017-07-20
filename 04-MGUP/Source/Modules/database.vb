
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

Imports System.Data.SqlClient

Public Module database

    Private Function connectDB(ByVal connectionString As String) As SqlConnection
        Dim cn As New SqlConnection
        cn.ConnectionString = ConfigurationManager.AppSettings(connectionString)
        cn.Open()
        Return cn
    End Function


    Public Sub sqlNonQuery(ByVal myExecuteQuery As String, Optional ByVal connString As String = "ConnStringCRAV")
        Dim cn As SqlConnection = connectDB(connString)
        Dim cm As New SqlCommand
        Try
            cm.Connection = cn
            cm.CommandText = myExecuteQuery
            cm.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try

    End Sub


    Public Function sqlScalarQuery(ByVal myExecuteQuery As String, Optional ByVal connString As String = "ConnStringCRAV") As Object
        Dim cn As SqlConnection = connectDB(connString)
        Dim cm As New SqlCommand
        Try
            cm.Connection = cn
            cm.CommandText = myExecuteQuery
            Dim ret As Object = cm.ExecuteScalar()
            Return ret
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Function

    Public Sub sqlLoadDdl(ByVal ddl As DropDownList, ByVal code As String, ByVal name As String, ByVal table As String, _
                          Optional ByVal connString As String = "ConnStringCRAV", Optional ByVal startItem As String = "Selecionar")
        Dim cn As SqlConnection = connectDB(connString)
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader
        Try
            cm.Connection = cn
            cm.CommandText = "SELECT " & code & " AS code ," & name & " AS name FROM " & table & " ORDER BY name"
            dr = cm.ExecuteReader
            Dim lii As New ListItem
            lii.Value = "0"
            lii.Text = startItem
            ddl.Items.Add(lii)
            While dr.Read
                Dim li As New ListItem
                li.Value = dr.Item("code")
                li.Text = dr.Item("name")
                ddl.Items.Add(li)
            End While

        Catch ex As Exception
        Finally
            'cn.Close()
            'dr.Close()
        End Try
    End Sub

    Public Function sqlIdToRef(ByVal id As Int64, Optional ByVal connString As String = "ConnStringDigitarq") As Object
        Dim cn As SqlConnection = connectDB(connString)
        Dim cm As New SqlCommand
        Try
            cm.Connection = cn
            cm.CommandText = "SELECT CompleteUnitID from Components WHERE ID = " & id
            Dim ret As Object = cm.ExecuteScalar()
            Return ret
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Function

    Public Function sqlGetOtherLevel(ByVal ref As String, Optional ByVal connString As String = "ConnStringDigitarq") As String
        Dim cn As SqlConnection = connectDB(connString)
        Dim cm As New SqlCommand
        Try
            cm.Connection = cn
            cm.CommandText = "SELECT OtherLevel FROM Components WHERE CompleteUnitId = '" & ref & "'"
            Dim ret As String = cm.ExecuteScalar()
            Return ret
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Function

    Public Function sqlGetRequestType(ByVal requestID As Int64, Optional ByVal connString As String = "ConnStringCRAV") As Integer
        Dim cn As SqlConnection = connectDB(connString)
        Dim cm As New SqlCommand("sp_getRequestType", cn)
        cm.CommandType = CommandType.StoredProcedure
        Try
            cm.Parameters.AddWithValue("@RequestID", requestID)
            Dim ret As String = cm.ExecuteScalar
            Return ret
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Function

    Public Function sqlGetRequestSubType(ByVal requestID As Int64, Optional ByVal connString As String = "ConnStringCRAV") As Integer
        Dim cn As SqlConnection = connectDB(connString)
        Dim cm As New SqlCommand("sp_getRequestSubType", cn)
        cm.CommandType = CommandType.StoredProcedure
        Try
            cm.Parameters.AddWithValue("@RequestID", requestID)
            Dim ret As String = cm.ExecuteScalar
            Return ret
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Function

End Module

