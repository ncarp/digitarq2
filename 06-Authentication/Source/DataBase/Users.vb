
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


Public Class Users

    ' COMPLETE
    Public Shared Sub CreateNewUser(ByVal ServerAddress As String, ByVal Database As String, _
                                    ByVal Username As String, ByVal Password As String, _
                                    ByVal NewUsername As String, ByVal NewPassword As String, _
                                    ByVal NewFirstName As String, ByVal NewLastName As String)

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection


        Dim NewID As Integer
        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("INSERT INTO Employees (Username, FirstName, Lastname, Password, Active) VALUES ('{0}', '{1}', '{2}', '{3}', 1)", NewUsername, NewFirstName, NewLastName, Cryptography.EncryptString(NewPassword))
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    'commented by lmferros
    Public Shared Sub UpdateUser(ByVal ServerAddress As String, ByVal Database As String, _
                                       ByVal Username As String, ByVal Password As String, _
                                       ByVal NewUsername As String, ByVal NewPassword As String, _
                                       ByVal NewFirstName As String, ByVal NewLastName As String)

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection


        Dim NewID As Integer
        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("UPDATE Employees SET Password = '{0}', FirstName = '{1}', LastName = '{2}' WHERE Username = '{3}'", Cryptography.EncryptString(NewPassword), NewFirstName, NewLastName, NewUsername)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Public Shared Function GetUsersList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, _
                                ByVal Password As String) As UserCollection

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim UserList As New UserCollection
        Dim DataReader As SqlDataReader

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT Username, FirstName, LastName FROM Employees ORDER BY Username"
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim uname As String = DBToStr(DataReader.Item("Username"))
                'Dim passwd As String = Cryptography.DecryptString(DBToStr(DataReader.Item("Password")))
                Dim fname As String = DBToStr(DataReader.Item("FirstName"))
                Dim lname As String = DBToStr(DataReader.Item("LastName"))
                UserList.Add(New UserItem(uname, "", fname, lname))
            End While

        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

        Return UserList
    End Function

    Public Shared Sub RemoveUser(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal UsernameToRemove As String)
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection


        Dim NewID As Integer
        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("DELETE FROM Employees WHERE Username= '{0}'", UsernameToRemove)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Public Shared Function CheckLogin(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, _
                                ByVal Password As String, ByVal CheckUsername As String, ByVal CheckPassword As String) As Boolean

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As Integer

        Try
            SQLConnection.Open()
            'SQLCommand.CommandText = String.Format("SELECT count(username) From Users WHERE Username = '{0}' and password = '{1}'", CheckUsername, Cryptography.EncryptString(CheckPassword))
            SQLCommand.CommandText = String.Format("SELECT count(username) From Employees WHERE Username = '{0}' and password = '{1}' and active=1", CheckUsername, Cryptography.EncryptString(CheckPassword))
            Result = CInt(SQLCommand.ExecuteScalar())
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

        Return Result = 1
    End Function

    Public Shared Function CreateAdmin() As Boolean
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Dim ServerAddress As String = SQLServerSettings.Item("ServerAddress")
        Dim Database As String = SQLServerSettings.Item("Database")
        Dim Username As String = SQLServerSettings.Item("Username")
        Dim Password As String = SQLServerSettings.Item("Password")

        'RemoveUser(ServerAddress, Database, Username, Password, "admin")
        CreateNewUser(ServerAddress, Database, Username, Password, "admin", "admin", "Administrador", "")
    End Function

    Public Shared Function AdministratorMissing() As Boolean
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Dim ServerAddress As String = SQLServerSettings.Item("ServerAddress")
        Dim Database As String = SQLServerSettings.Item("Database")
        Dim Username As String = SQLServerSettings.Item("Username")
        Dim Password As String = SQLServerSettings.Item("Password")

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As Integer

        Try
            SQLConnection.Open()
            'altered by lmferros
            'SQLCommand.CommandText = String.Format("SELECT count(username) From Users WHERE Username = 'admin'")
            SQLCommand.CommandText = String.Format("SELECT count(username) From Employees WHERE Username = 'admin'")
            Result = CInt(SQLCommand.ExecuteScalar())
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

        Return Result = 0
    End Function

End Class
