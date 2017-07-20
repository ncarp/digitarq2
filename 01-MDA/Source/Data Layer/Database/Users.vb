
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
