
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

Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions


Public Class Users

    Public Shared DigitArqConnectionString, DataBase As String

    Public Shared Sub setDigitarqConnectionString(ByVal DigitArqConnectionString1 As String)
        DigitArqConnectionString = DigitArqConnectionString1
    End Sub

    Public Shared Sub setDigitarqDatabase(ByVal DigitarqDatabase1 As String)
        DataBase = DigitarqDatabase1
    End Sub

    ' COMPLETE
    Public Shared Sub CreateNewUser(ByVal ServerAddress As String, ByVal Database As String, _
                                    ByVal Username As String, ByVal Password As String, _
                                    ByVal NewUsername As String, ByVal NewPassword As String, _
                                    ByVal NewFullName As String)

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = DigitArqConnectionString
        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim NewID As Integer
        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("INSERT INTO Employees (Username, FirstName, LastName, Password, Obs, Active) " & _
            " VALUES ('{0}', '{1}', '{2}', '{3}', '','1')", NewUsername, NewFullName, NewFullName, Cryptography.EncryptString(NewPassword))
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Public Shared Sub UpdateUser(ByVal ServerAddress As String, ByVal Database As String, _
                                       ByVal Username As String, ByVal Password As String, _
                                       ByVal NewUsername As String, ByVal NewPassword As String, _
                                       ByVal NewFullName As String)

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = DigitArqConnectionString

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection


        Dim NewID As Integer
        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("UPDATE Employees SET Password = '{0}', FirstName = '{1}' WHERE Username = '{2}'", Cryptography.EncryptString(NewPassword), NewFullName, NewUsername)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


    Public Shared Function GenerateHash(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Shared Function CheckLogin(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, _
                                ByVal Password As String, ByVal CheckUsername As String, ByVal CheckPassword As String) As Boolean

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = DigitArqConnectionString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As Integer

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT count(username) From Employees WHERE Username = '{0}' and password = '{1}'", CheckUsername, GenerateHash(CheckPassword))
            'Cryptography.EncryptString(CheckPassword))
            Result = CInt(SQLCommand.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            SQLConnection.Close()
        End Try

        Return Result = 1
    End Function


    Public Shared Function AdministratorMissing() As Boolean
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = DigitArqConnectionString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As Integer

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT count(username) From Employees WHERE Username = 'admin'")
            Result = CInt(SQLCommand.ExecuteScalar())
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            SQLConnection.Close()
        End Try

        Return Result = 0


    End Function

End Class
