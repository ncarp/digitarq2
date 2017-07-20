
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

Public Class SQLLazyNode
    Inherits LazyNode


#Region "Internal Properties (private)"
    '*************************************************************************
    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
    Private myID As Integer
    Private myParentFondsId As Integer

    'Private myParentId As Integer
    '*************************************************************************
#End Region


#Region "Initializations"
    '*************************************************************************
    ' downloads a specific node by ID
    Public Sub New(ByVal ServerAddress As String, ByVal Database As String, _
                   ByVal Username As String, ByVal Password As String, _
                   ByVal ID As Integer)
        myServerAddress = ServerAddress
        myDatabase = Database
        myUsername = Username
        myPassword = Password
        myID = ID
        Download()
    End Sub

    Private Sub New(ByVal ServerAddress As String, ByVal Database As String, _
                    ByVal Username As String, ByVal Password As String)

        myServerAddress = ServerAddress
        myDatabase = Database
        myUsername = Username
        myPassword = Password
    End Sub
    '*************************************************************************
#End Region


#Region "Specific methods"
    '*************************************************************************

    Public Overrides ReadOnly Property ID() As Object
        Get
            Return myID
        End Get
    End Property

    Public Shared Sub RemoveNode(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ID As Integer)
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction

        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction


            '' ChronList
            'SQLCommand.CommandText = String.Format("DELETE FROM ChronList WHERE ComponentID = '{0}'", ID)
            'SQLCommand.ExecuteNonQuery()

            '' Bibliography
            'SQLCommand.CommandText = String.Format("DELETE FROM Bibliography WHERE ComponentID = '{0}'", ID)
            'SQLCommand.ExecuteNonQuery()

            '' DaoGrp
            'SQLCommand.CommandText = String.Format("DELETE FROM DaoGrp WHERE ComponentID = '{0}'", ID)
            'SQLCommand.ExecuteNonQuery()

            '' ControlAccess
            'SQLCommand.CommandText = String.Format("DELETE FROM ControlAccess WHERE ComponentID = '{0}'", ID)
            'SQLCommand.ExecuteNonQuery()

            'SQLCommand.CommandText = String.Format("DELETE FROM ControlAccessItemsFonds WHERE ComponentID = '{0}'", ID)
            'SQLCommand.ExecuteNonQuery()

            SQLCommand.CommandText = String.Format("DELETE FROM Components WHERE ID = '{0}'", ID)
            SQLCommand.ExecuteNonQuery()

            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
            Throw ex
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


#End Region


#Region "ControlAccess Types Creation, Listing and Removal"


    Public Shared Sub RemoveControlAccessType(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ID As Integer)
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
            SQLCommand.CommandText = String.Format("DELETE FROM ControlAccessTypes WHERE ID = {0}", ID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub



    ' COMPLETE
    Public Shared Sub UpdateControlAccessType(ByVal ServerAddress As String, ByVal Database As String, _
                                        ByVal Username As String, ByVal Password As String, ByVal TypeID As Integer, ByVal Type As String)

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
            SQLCommand.CommandText = String.Format("UPDATE ControlAccessTypes SET Type = '{0}' WHERE ID = {1}", Type, TypeID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


    ' COMPLETE
    Public Shared Sub CreateNewControlAccessType(ByVal ServerAddress As String, ByVal Database As String, _
                                        ByVal Username As String, ByVal Password As String, ByVal Type As String)

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
            SQLCommand.CommandText = String.Format("INSERT INTO ControlAccessTypes (Type) VALUES ('{0}')", Type)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub


    ' COMPLETE
    Public Shared Function GetControlAccessTypeList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String) As ControlAccessTypeCollection
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim TypesList As New ControlAccessTypeCollection


        Try

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT ID, Type FROM ControlAccessTypes ORDER BY TYPE"
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim Type As String = DBToStr(DataReader.Item("Type"))

                Dim Item As New ControlAccessTypeItem(ID, Type)
                TypesList.Add(Item)
            End While


        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return TypesList
    End Function



#End Region


#Region "ControlAccess Fonds/Items Association, Deassociation"


    Public Shared Sub AssociateItemToFonds(ByVal ServerAddress As String, _
                                ByVal Database As String, _
                                ByVal Username As String, ByVal Password As String, _
                                ByVal FondsID As Integer, ByVal ItemID As Integer)

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
            SQLCommand.CommandText = String.Format("INSERT INTO ControlAccessItemsFonds (ComponentID, ItemID) VALUES ({0}, {1})", FondsID, ItemID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub



    Public Shared Sub DeassociateItemFromFonds(ByVal ServerAddress As String, _
                                ByVal Database As String, ByVal Username As String, _
                                ByVal Password As String, ByVal FondsID As Integer, _
                                ByVal ItemID As Integer)
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
            SQLCommand.CommandText = String.Format("DELETE FROM ControlAccessItemsFonds WHERE ComponentID = {0} AND ItemID = {1}", FondsID, ItemID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub



    ' COMPLETE
    Public Shared Function GetControlAccessItemListInFonds(ByVal ServerAddress As String, _
                                ByVal Database As String, ByVal Username As String, _
                                ByVal Password As String, ByVal FondsID As Integer) _
                                As ControlAccessItemCollection


        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New ControlAccessItemCollection


        Try

            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT ControlAccessItems.ID, ControlAccessItems.TypeID, ControlAccessTypes.Type, ControlAccessItems.Item FROM ControlAccessItems, ControlAccessTypes, ControlAccessItemsFonds WHERE TypeID = ControlAccessTypes.ID AND ControlAccessItems.ID = ControlAccessItemsFonds.ItemID  AND ControlAccessItemsFonds.ComponentID = {0} ORDER BY ControlAccessItems.Item, ControlAccessTypes.Type", FondsID)
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim TypeID As Integer = DBToInt(DataReader.Item("TypeID"))
                Dim Type As String = DBToStr(DataReader.Item("Type"))
                Dim Item As String = DBToStr(DataReader.Item("Item"))

                ItemsList.Add(ID, TypeID, Type, Item)
            End While


        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return ItemsList
    End Function


    Public Shared Function GetControlAccessItemListNotInFonds(ByVal ServerAddress As String, _
                               ByVal Database As String, ByVal Username As String, _
                               ByVal Password As String, ByVal FondsID As Integer) _
                               As ControlAccessItemCollection


        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New ControlAccessItemCollection


        Try

            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT ControlAccessItems.ID, ControlAccessItems.TypeID, ControlAccessTypes.Type, ControlAccessItems.Item FROM ControlAccessItems, ControlAccessTypes WHERE TypeID = ControlAccessTypes.ID AND NOT ControlAccessItems.ID IN  (SELECT ControlAccessItems.ID FROM ControlAccessItems, ControlAccessItemsFonds WHERE ControlAccessItems.ID = ControlAccessItemsFonds.ItemID  AND  ControlAccessItemsFonds.ComponentID = {0}) ORDER BY ControlAccessItems.Item, ControlAccessTypes.Type", FondsID)
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim TypeID As Integer = DBToInt(DataReader.Item("TypeID"))
                Dim Type As String = DBToStr(DataReader.Item("Type"))
                Dim Item As String = DBToStr(DataReader.Item("Item"))

                ItemsList.Add(ID, TypeID, Type, Item)
            End While
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return ItemsList
    End Function

#End Region


#Region "ControlAccess Items Creation, Listing and Removal"


    Public Shared Sub UpdateControlAccessItem(ByVal ServerAddress As String, ByVal Database As String, _
                                        ByVal Username As String, ByVal Password As String, ByVal ItemID As Integer, ByVal TypeID As Integer, ByVal Item As String)

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
            SQLCommand.CommandText = String.Format("UPDATE ControlAccessItems SET TypeID = '{0}', Item= '{1}' WHERE ID = {2}", TypeID, Item, ItemID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub


    Public Shared Sub RemoveControlAccessItem(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ID As Integer)
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
            SQLCommand.CommandText = String.Format("DELETE FROM ControlAccessItems WHERE ID = {0}", ID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub


    ' COMPLETE
    Public Shared Function GetControlAccessItemList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String) As ControlAccessItemCollection
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New ControlAccessItemCollection


        Try

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT ControlAccessItems.ID, ControlAccessItems.TypeID, ControlAccessTypes.Type, ControlAccessItems.Item FROM ControlAccessItems, ControlAccessTypes WHERE TypeID = ControlAccessTypes.ID ORDER BY ControlAccessTypes.Type, ControlAccessItems.Item"
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim TypeID As Integer = DBToInt(DataReader.Item("TypeID"))
                Dim Type As String = DBToStr(DataReader.Item("Type"))
                Dim Item As String = DBToStr(DataReader.Item("Item"))

                ItemsList.Add(ID, TypeID, Type, Item)
                Debug.WriteLine("GetControlAccessItemList:" & Item)
            End While

        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return ItemsList
    End Function



    Public Shared Function GetControlAccessItemList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal TypeID As Integer) As ControlAccessItemCollection
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New ControlAccessItemCollection


        Try

            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT ControlAccessItems.ID, ControlAccessItems.TypeID, ControlAccessTypes.Type, ControlAccessItems.Item FROM ControlAccessItems, ControlAccessTypes WHERE TypeID = ControlAccessTypes.ID AND ControlAccessItems.TypeID = {0} ORDER BY ControlAccessItems.Item", TypeID)
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim ItemTypeID As Integer = DBToInt(DataReader.Item("TypeID"))
                Dim Type As String = DBToStr(DataReader.Item("Type"))
                Dim Item As String = DBToStr(DataReader.Item("Item"))

                ItemsList.Add(ID, ItemTypeID, Type, Item)
                Debug.WriteLine("GetControlAccessItemList:" & Item)
            End While

        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return ItemsList
    End Function


    ' COMPLETE
    Public Shared Sub CreateNewControlAccessItem(ByVal ServerAddress As String, ByVal Database As String, _
                                        ByVal Username As String, ByVal Password As String, ByVal TypeID As Integer, ByVal Item As String)

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
            SQLCommand.CommandText = String.Format("INSERT INTO ControlAccessItems (TypeID, Item) VALUES ({0}, '{1}')", TypeID, Item)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub

#End Region


#Region "Fonds Creation, Listing and Removal"


    'Public Shared Sub RemoveFonds(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ID As Integer)
    '    Dim SQLNode As New SQLLazyNode(ServerAddress, Database, Username, Password, ID)
    '    Dim SQLChildNode As SQLLazyNode

    '    For Each SQLChildNode In SQLNode.Children
    '        SQLNode.RemoveChild(SQLChildNode)
    '    Next
    '    RemoveNode(ServerAddress, Database, Username, Password, ID)
    'End Sub


    Public Shared Sub RemoveFonds(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ID As Integer)
        Dim SQLNode As LazyNode = New SQLLazyNode(ServerAddress, Database, Username, Password, ID)
        Dim Erasor As New Erasor(ServerAddress, Database, Username, Password, SQLNode)
        Erasor.StartErasing()
    End Sub




    ' COMPLETE
    Public Shared Function CreateNewFonds(ByVal ServerAddress As String, ByVal Database As String, _
                                        ByVal Username As String, ByVal Password As String, _
                                        ByVal UnitId As String, ByVal UnitTitle As String, ByVal ProcessInfoName As String) As LazyNode

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
            SQLCommand.CommandText = String.Format("INSERT INTO Components (Valid, Visible, Haschildren, Otherlevel) VALUES (0, 0, 0, '{0}')", OTHERLEVEL_FONDS)
            SQLCommand.ExecuteNonQuery()
            SQLCommand.CommandText = "SELECT SCOPE_IDENTITY() AS ID"
            NewID = CInt(SQLCommand.ExecuteScalar().ToString)

            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

        Dim Node As New SQLLazyNode(ServerAddress, Database, Username, Password, NewID)
        Node.UnitId = UnitId
        Node.UnitTitle = UnitTitle
        Node.OtherLevel = OTHERLEVEL_FONDS
        Node.Visible = False
        Node.Valid = False
        Node.ProcessInfoDate = DateToDB(Date.Now)
        Node.ProcessInfoName = ProcessInfoName
        Node.CountryCode = VisualFieldLabel("CountryCode.DefaultValue")
        Node.RepositoryCode = VisualFieldLabel("RepositoryCode.DefaultValue")
        Node.Repository = VisualFieldLabel("Repository.DefaultValue")
        Node.LangMaterial = VisualFieldLabel("LangMaterial.DefaultValue")
        Node.AllowExtentsInference = True
        Node.AllowUnitDatesInference = True
        Node.ParentFondsId = NewID
        Node.Upload()

        Return Node
    End Function


    ' COMPLETE
    Public Shared Function GetFondsList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String) As FondsListCollection
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim FondsList As New FondsListCollection


        Try

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT ID, UnitId, UnitTitle, UnitdateInitial, UnitDateFinal, Visible FROM Components WHERE OtherLevel = 'F' ORDER BY UnitID, Visible, ProcessInfoDate"
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim UnitId As String = DBToStr(DataReader.Item("UnitId"))
                Dim UnitTitle As String = DBToStr(DataReader.Item("UnitTitle"))
                Dim UnitDateInitial As String = DBToStr(DataReader.Item("UnitDateInitial"))
                Dim UnitDateFinal As String = DBToStr(DataReader.Item("UnitDateFinal"))
                Dim Visible As Boolean = DBToBool(DataReader.Item("Visible"))

                Dim Item As New FondsListItem(ID, UnitId, UnitTitle, UnitDateInitial, UnitDateFinal, Visible)
                FondsList.Add(Item)
            End While


        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return FondsList
    End Function


#End Region


#Region "LazyNode Methods"
    '*************************************************************************


    Public Overrides Function Parent() As LazyNode
        If myParentId = 0 Then
            Return Nothing
        Else
            Return New SQLLazyNode(myServerAddress, myDatabase, myUsername, myPassword, myParentId)
        End If
    End Function


    Public Overrides Sub Download() ' Complete
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection



        'Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            'Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            'SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("SELECT * FROM Components WHERE ID = '{0}'", myID)
            Dim DataReader As SqlDataReader

            DataReader = SQLCommand.ExecuteReader()
            While DataReader.Read()
                UnitId = DBToStr(DataReader.Item("UnitId"))
                UnitTitle = DBToStr(DataReader.Item("UnitTitle"))
                Visible = DBToBool(DataReader.Item("Visible"))
                Valid = DBToBool(DataReader.Item("Valid"))
                Available = DBToBool(DataReader.Item("Available"))
                TakenBy = DBToStr(DataReader.Item("TakenBy"))

                OtherLevel = DBToStr(DataReader.Item("OtherLevel"))
                CountryCode = DBToStr(DataReader.Item("CountryCode"))
                RepositoryCode = DBToStr(DataReader.Item("RepositoryCode"))
                Abstract = DBToStr(DataReader.Item("Abstract"))
                AccessRestrict = DBToStr(DataReader.Item("AccessRestrict"))
                Accruals = DBToStr(DataReader.Item("Accruals"))
                AcqInfo = DBToStr(DataReader.Item("AcqInfo"))
                AltFormAvail = DBToStr(DataReader.Item("AltFormAvail"))
                Appraisal = DBToStr(DataReader.Item("Appraisal"))
                Arrangement = DBToStr(DataReader.Item("Arrangement"))
                BiogHist = DBToStr(DataReader.Item("BiogHist"))

                CustodHist = DBToStr(DataReader.Item("CustodHist"))
                Dimensions = DBToStr(DataReader.Item("Dimensions"))

                ExtentBook = DBToInt(DataReader.Item("ExtentBook"))
                ExtentBox = DBToInt(DataReader.Item("ExtentBox"))
                ExtentCapilha = DBToInt(DataReader.Item("ExtentCapilha"))
                ExtentFolder = DBToInt(DataReader.Item("ExtentFolder"))
                ExtentMacete = DBToInt(DataReader.Item("ExtentMacete"))
                ExtentMaco = DBToInt(DataReader.Item("ExtentMaco"))
                ExtentMl = DBToDbl(DataReader.Item("ExtentMl"))
                ExtentRoll = DBToInt(DataReader.Item("ExtentRoll"))
                ExtentAlbum = DBToInt(DataReader.Item("ExtentAlbum"))
                ExtentEnvelope = DBToInt(DataReader.Item("ExtentEnvelope"))

                GenreForm = DBToStr(DataReader.Item("GenreForm"))
                GeogName = DBToStr(DataReader.Item("GeogName"))
                LangMaterial = DBToStr(DataReader.Item("LangMaterial"))
                LegalStatus = DBToStr(DataReader.Item("LegalStatus"))
                MaterialSpec = DBToStr(DataReader.Item("MaterialSpec"))
                Note = DBToStr(DataReader.Item("Note"))
                OriginalNumbering = DBToStr(DataReader.Item("OriginalNumbering"))
                OriginalsLoc = DBToStr(DataReader.Item("OriginalsLoc"))
                OriginationAuthor = DBToStr(DataReader.Item("OriginationAuthor"))
                OriginationAuthorAddress = DBToStr(DataReader.Item("OriginationAuthorAddress"))
                OriginationDestination = DBToStr(DataReader.Item("OriginationDestination"))
                OriginationDestinationAddress = DBToStr(DataReader.Item("OriginationDestinationAddress"))
                OriginationNotary = DBToStr(DataReader.Item("OriginationNotary"))
                OriginationNotary = DBToStr(DataReader.Item("OriginationNotary"))
                OriginationScrivener = DBToStr(DataReader.Item("OriginationScrivener"))
                OtherFindAid = DBToStr(DataReader.Item("OtherFindAid"))
                PhysFacet = DBToStr(DataReader.Item("PhysFacet"))
                PhysLoc = DBToStr(DataReader.Item("PhysLoc"))
                PhysTech = DBToStr(DataReader.Item("PhysTech"))
                PreferCite = DBToStr(DataReader.Item("PreferCite"))

                ProcessInfoDate = DBToStr(DataReader.Item("ProcessInfoDate"))
                ProcessInfoName = DBToStr(DataReader.Item("ProcessInfoName"))
                ProcessInfo = DBToStr(DataReader.Item("ProcessInfo"))
                DescRules = DBToStr(DataReader.Item("DescRules"))

                RelatedMaterial = DBToStr(DataReader.Item("RelatedMaterial"))
                Repository = DBToStr(DataReader.Item("Repository"))
                ScopeContent = DBToStr(DataReader.Item("ScopeContent"))
                SeparatedMaterial = DBToStr(DataReader.Item("SeparatedMaterial"))
                UnitDateInitial = DBToStr(DataReader.Item("UnitDateInitial"))
                UnitDateFinal = DBToStr(DataReader.Item("UnitDateFinal"))
                UnitDateFinalCertainty = DBToBool(DataReader.Item("UnitDateFinalCertainty"))
                UnitDateInitialCertainty = DBToBool(DataReader.Item("UnitDateInitialCertainty"))
                UseRestrict = DBToStr(DataReader.Item("UseRestrict"))
                FilePlan = DBToStr(DataReader.Item("FilePlan"))

                UnitTitleType = DBToStr(DataReader.Item("UnitTitleType"))
                ExtentPage = DBToInt(DataReader.Item("ExtentPage"))
                ExtentLeaf = DBToInt(DataReader.Item("ExtentLeaf"))
                ExtentOther = DBToInt(DataReader.Item("ExtentOther"))

                UnitDateBulk = DBToStr(DataReader.Item("UnitDateBulk"))

                ContainerType = DBToStr(DataReader.Item("ContainerType"))
                ContainerCustomType = DBToStr(DataReader.Item("ContainerCustomType"))
                CompleteUnitId = DBToStr(DataReader.Item("CompleteUnitId"))
                myParentId = DBToInt(DataReader.Item("ParentID"))

                AllowUnitDatesInference = DBToBool(DataReader.Item("AllowUnitDatesInference"))
                AllowExtentsInference = DBToBool(DataReader.Item("AllowExtentsInference"))
                ParentFondsId = DBToInt(DataReader.Item("ParentFondsID"))


            End While
            DataReader.Close()

            '' Get ChronList
            'SQLCommand.CommandText = String.Format("SELECT ID,[Date],Event FROM ChronList WHERE ComponentID = '{0}'", myID)
            'Dim ChronListDataReader As SqlDataReader
            'ChronListDataReader = SQLCommand.ExecuteReader()
            'Dim clist As New ChronList
            'While ChronListDataReader.Read()
            '    clist.Add(DBToInt(ChronListDataReader.Item("ID")), DBToStr(ChronListDataReader.Item("Date")), DBToStr(ChronListDataReader.Item("Event")))
            'End While
            'ChronList = clist
            'ChronListDataReader.Close()



            '' Get Bibliography
            'SQLCommand.CommandText = String.Format("SELECT ID, BibRef FROM Bibliography WHERE ComponentID = '{0}'", myID)
            'Dim BibliographyDataReader As SqlDataReader
            'BibliographyDataReader = SQLCommand.ExecuteReader()
            'Dim bibList As New Bibliography
            'While BibliographyDataReader.Read()
            '    bibList.Add(DBToInt(BibliographyDataReader.Item("ID")), DBToStr(BibliographyDataReader.Item("BibRef")))
            'End While
            'Bibliography = bibList
            'BibliographyDataReader.Close()


            '' Get ControlAccess
            'SQLCommand.CommandText = String.Format("SELECT ControlAccess.ItemID AS ID, ControlAccessTypes.Type AS Type, ControlAccessItems.Item AS Item FROM ControlAccess, ControlAccessTypes, ControlAccessItems WHERE ControlAccess.ComponentID = {0} And ControlAccess.ItemID = ControlAccessItems.ID And ControlAccessItems.TypeID = ControlAccessTypes.ID;", myID)
            'Dim ControlAccessDataReader As SqlDataReader
            'ControlAccessDataReader = SQLCommand.ExecuteReader()
            'Dim caList As New ControlAccess
            'While ControlAccessDataReader.Read()
            '    caList.Add(DBToInt(ControlAccessDataReader.Item("ID")), DBToStr(ControlAccessDataReader.Item("Type")), DBToStr(ControlAccessDataReader.Item("Item")))
            'End While
            'ControlAccess = caList
            'ControlAccessDataReader.Close()



            ' *********** Cut Here ***********
            ' Get DaoGrp
            'SQLCommand.CommandText = String.Format("SELECT ID, Title, Href FROM DaoGrp WHERE ComponentID = '{0}'", myID)
            'Dim DaoGrpDataReader As SqlDataReader
            'DaoGrpDataReader = SQLCommand.ExecuteReader()

            'Dim dgList As New DaoGrp
            'While DaoGrpDataReader.Read()
            '  dgList.Add(DBToInt(DaoGrpDataReader.Item("ID")), DBToStr(DaoGrpDataReader.Item("Title")), DBToStr(DaoGrpDataReader.Item("Href")))
            'End While
            'DaoGrp = dgList
            'DaoGrpDataReader.Close()
            ' *********** Cut Here ***********



            'Transaction.Commit()
            Debug.WriteLine("SQLLazynode: " & UnitId & " Downloaded from Database")

        Catch ex As SqlException
            'Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try


    End Sub



    Private Sub DownloadChronList()
        Dim SQLCommand As New SqlCommand
        Dim SQLConnection As New SqlConnection
        Dim ChronListDataReader As SqlDataReader

        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT ID,[Date],Event FROM ChronList WHERE ComponentID = '{0}'", myID)
            ChronListDataReader = SQLCommand.ExecuteReader()
            Dim clist As New ChronList
            While ChronListDataReader.Read()
                clist.Add(DBToInt(ChronListDataReader.Item("ID")), DBToStr(ChronListDataReader.Item("Date")), DBToStr(ChronListDataReader.Item("Event")))
            End While
            ChronList = clist
            ChronListDataReader.Close()
            'Transaction.Commit()

        Catch ex As SqlException
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


    Private Sub DownloadControlAccess()
        Dim SQLConnection As New SqlConnection
        Dim SQLCommand As New SqlCommand
        Dim ControlAccessDataReader As SqlDataReader

        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT ControlAccess.ItemID AS ID, ControlAccessTypes.Type AS Type, ControlAccessItems.Item AS Item FROM ControlAccess, ControlAccessTypes, ControlAccessItems WHERE ControlAccess.ComponentID = {0} And ControlAccess.ItemID = ControlAccessItems.ID And ControlAccessItems.TypeID = ControlAccessTypes.ID;", myID)
            ControlAccessDataReader = SQLCommand.ExecuteReader()
            Dim caList As New ControlAccess
            While ControlAccessDataReader.Read()
                caList.Add(DBToInt(ControlAccessDataReader.Item("ID")), DBToStr(ControlAccessDataReader.Item("Type")), DBToStr(ControlAccessDataReader.Item("Item")))
            End While
            ControlAccess = caList
            ControlAccessDataReader.Close()
        Catch ex As SqlException
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


    Private Sub DownloadBibliography()
        ' Get ChronList

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT ID, BibRef FROM Bibliography WHERE ComponentID = '{0}'", myID)
            Dim BibliographyDataReader As SqlDataReader
            BibliographyDataReader = SQLCommand.ExecuteReader()
            Dim bibList As New Bibliography
            While BibliographyDataReader.Read()
                bibList.Add(DBToInt(BibliographyDataReader.Item("ID")), DBToStr(BibliographyDataReader.Item("BibRef")))
            End While
            Bibliography = bibList
            BibliographyDataReader.Close()

        Catch ex As SqlException
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


    Private Sub LoadProperties(ByRef Node As SQLLazyNode, _
                               ByRef DataReader As SqlDataReader) ' Complete

        Node.UnitId = DBToStr(DataReader.Item("UnitId"))
        Node.UnitTitle = DBToStr(DataReader.Item("UnitTitle"))
        Node.Visible = DBToBool(DataReader.Item("Visible"))
        Node.Valid = DBToBool(DataReader.Item("Valid"))
        Node.Available = DBToBool(DataReader.Item("Available"))

        Node.TakenBy = DBToStr(DataReader.Item("TakenBy"))

        Node.OtherLevel = DBToStr(DataReader.Item("OtherLevel"))
        Node.CountryCode = DBToStr(DataReader.Item("CountryCode"))
        Node.RepositoryCode = DBToStr(DataReader.Item("RepositoryCode"))
        Node.Abstract = DBToStr(DataReader.Item("Abstract"))
        Node.AccessRestrict = DBToStr(DataReader.Item("AccessRestrict"))
        Node.Accruals = DBToStr(DataReader.Item("Accruals"))
        Node.AcqInfo = DBToStr(DataReader.Item("AcqInfo"))
        Node.AltFormAvail = DBToStr(DataReader.Item("AltFormAvail"))
        Node.Appraisal = DBToStr(DataReader.Item("Appraisal"))
        Node.Arrangement = DBToStr(DataReader.Item("Arrangement"))
        Node.BiogHist = DBToStr(DataReader.Item("BiogHist"))

        Node.CustodHist = DBToStr(DataReader.Item("CustodHist"))
        Node.Dimensions = DBToStr(DataReader.Item("Dimensions"))

        Node.ExtentBook = DBToInt(DataReader.Item("ExtentBook"))
        Node.ExtentBox = DBToInt(DataReader.Item("ExtentBox"))
        Node.ExtentCapilha = DBToInt(DataReader.Item("ExtentCapilha"))
        Node.ExtentFolder = DBToInt(DataReader.Item("ExtentFolder"))
        Node.ExtentMacete = DBToInt(DataReader.Item("ExtentMacete"))
        Node.ExtentMaco = DBToInt(DataReader.Item("ExtentMaco"))
        Node.ExtentMl = DBToDbl(DataReader.Item("ExtentMl"))
        Node.ExtentRoll = DBToInt(DataReader.Item("ExtentRoll"))
        Node.ExtentAlbum = DBToInt(DataReader.Item("ExtentAlbum"))
        Node.ExtentEnvelope = DBToInt(DataReader.Item("ExtentEnvelope"))

        Node.GenreForm = DBToStr(DataReader.Item("GenreForm"))
        Node.GeogName = DBToStr(DataReader.Item("GeogName"))
        Node.LangMaterial = DBToStr(DataReader.Item("LangMaterial"))
        Node.LegalStatus = DBToStr(DataReader.Item("LegalStatus"))
        Node.MaterialSpec = DBToStr(DataReader.Item("MaterialSpec"))
        Node.Note = DBToStr(DataReader.Item("Note"))
        Node.OriginalNumbering = DBToStr(DataReader.Item("OriginalNumbering"))
        Node.OriginalsLoc = DBToStr(DataReader.Item("OriginalsLoc"))
        Node.OriginationAuthor = DBToStr(DataReader.Item("OriginationAuthor"))
        Node.OriginationAuthorAddress = DBToStr(DataReader.Item("OriginationAuthorAddress"))
        Node.OriginationDestination = DBToStr(DataReader.Item("OriginationDestination"))
        Node.OriginationDestinationAddress = DBToStr(DataReader.Item("OriginationDestinationAddress"))
        Node.OriginationNotary = DBToStr(DataReader.Item("OriginationNotary"))
        Node.OriginationNotary = DBToStr(DataReader.Item("OriginationNotary"))
        Node.OriginationScrivener = DBToStr(DataReader.Item("OriginationScrivener"))
        Node.OtherFindAid = DBToStr(DataReader.Item("OtherFindAid"))
        Node.PhysFacet = DBToStr(DataReader.Item("PhysFacet"))
        Node.PhysLoc = DBToStr(DataReader.Item("PhysLoc"))
        Node.PhysTech = DBToStr(DataReader.Item("PhysTech"))
        Node.PreferCite = DBToStr(DataReader.Item("PreferCite"))

        Node.ProcessInfoDate = DBToStr(DataReader.Item("ProcessInfoDate"))
        Node.ProcessInfoName = DBToStr(DataReader.Item("ProcessInfoName"))
        Node.ProcessInfo = DBToStr(DataReader.Item("ProcessInfo"))
        Node.DescRules = DBToStr(DataReader.Item("DescRules"))

        Node.RelatedMaterial = DBToStr(DataReader.Item("RelatedMaterial"))
        Node.Repository = DBToStr(DataReader.Item("Repository"))
        Node.ScopeContent = DBToStr(DataReader.Item("ScopeContent"))
        Node.SeparatedMaterial = DBToStr(DataReader.Item("SeparatedMaterial"))
        Node.UnitDateInitial = DBToStr(DataReader.Item("UnitDateInitial"))
        Node.UnitDateFinal = DBToStr(DataReader.Item("UnitDateFinal"))
        Node.UnitDateFinalCertainty = DBToBool(DataReader.Item("UnitDateFinalCertainty"))
        Node.UnitDateInitialCertainty = DBToBool(DataReader.Item("UnitDateInitialCertainty"))
        Node.UseRestrict = DBToStr(DataReader.Item("UseRestrict"))
        Node.FilePlan = DBToStr(DataReader.Item("FilePlan"))

        Node.UnitTitleType = DBToStr(DataReader.Item("UnitTitleType"))
        Node.ExtentPage = DBToInt(DataReader.Item("ExtentPage"))
        Node.ExtentLeaf = DBToInt(DataReader.Item("ExtentLeaf"))
        Node.ExtentOther = DBToInt(DataReader.Item("ExtentOther"))

        Node.UnitDateBulk = DBToStr(DataReader.Item("UnitDateBulk"))

        Node.ContainerType = DBToStr(DataReader.Item("ContainerType"))
        Node.ContainerCustomType = DBToStr(DataReader.Item("ContainerCustomType"))
        Node.CompleteUnitId = DBToStr(DataReader.Item("CompleteUnitId"))
        Node.myParentId = DBToInt(DataReader.Item("ParentID"))
        Node.myParentFondsId = DBToInt(DataReader.Item("ParentFondsID"))

        Node.myAllowExtentsInference = DBToBool(DataReader.Item("AllowExtentsInference"))
        Node.myAllowUnitDatesInference = DBToBool(DataReader.Item("AllowUnitDatesInference"))

    End Sub



    Public Overrides Sub Upload() ' Complete
        Dim SQLConnection As SqlConnection = New SqlConnection
        Dim SQLCommand As New SqlCommand
        Dim Transaction As SqlTransaction

        ' hack to avoid queries in the middle of the transaction
        Dim bib As Bibliography = Me.Bibliography
        Dim cl As ChronList = Me.ChronList
        Dim ca As ControlAccess = Me.ControlAccess()
        ' by mferreira





        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)
        SQLCommand.Connection = SQLConnection


        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction

            SQLCommand.CommandText = String.Format("UPDATE Components SET " & _
                                        "HasChildren='{1}', " & _
                                        "Visible='{2}', " & _
                                        "Valid='{3}', " & _
                                        "OtherLevel='{4}', " & _
                                        "UnitId='{5}', " & _
                                        "CountryCode='{6}', " & _
                                        "RepositoryCode='{7}', " & _
                                        "UnitTitle='{8}', " & _
                                        "Abstract = '{9}', " & _
                                        "AccessRestrict = '{10}'," & _
                                        "Accruals = '{11}'," & _
                                        "AcqInfo = '{12}'," & _
                                        "AltFormAvail = '{13}'," & _
                                        "Appraisal = '{14}'," & _
                                        "Arrangement = '{15}'," & _
                                        "BiogHist = '{16}'," & _
                                        "CustodHist = '{17}'," & _
                                        "Dimensions = '{18}'," & _
                                        "ExtentBook = '{19}'," & _
                                        "ExtentBox = '{20}'," & _
                                        "ExtentCapilha = '{21}'," & _
                                        "ExtentFolder = '{22}'," & _
                                        "ExtentMacete = '{23}'," & _
                                        "ExtentMaco = '{24}'," & _
                                        "ExtentMl = '{25}'," & _
                                        "ExtentRoll = '{26}'," & _
                                        "ExtentAlbum = '{27}'," & _
                                        "ExtentEnvelope = '{28}'," & _
                                        "GenreForm = '{29}'," & _
                                        "GeogName = '{30}'," & _
                                        "LangMaterial = '{31}'," & _
                                        "LegalStatus = '{32}'," & _
                                        "MaterialSpec = '{33}'," & _
                                        "Note = '{34}'," & _
                                        "OriginalNumbering = '{35}'," & _
                                        "OriginalsLoc = '{36}'," & _
                                        "OriginationAuthor = '{37}'," & _
                                        "OriginationAuthorAddress = '{38}'," & _
                                        "OriginationDestination = '{39}'," & _
                                        "OriginationDestinationAddress = '{40}'," & _
                                        "OriginationNotary = '{41}'," & _
                                        "OriginationScrivener = '{42}'," & _
                                        "OtherFindAid = '{43}'," & _
                                        "PhysFacet = '{44}'," & _
                                        "PhysLoc = '{45}'," & _
                                        "PhysTech = '{46}'," & _
                                        "PreferCite = '{47}'," & _
                                        "ProcessInfoDate = '{48}'," & _
                                        "ProcessInfoName = '{49}'," & _
                                        "ProcessInfo = '{50}'," & _
                                        "DescRules = '{51}'," & _
                                        "RelatedMaterial = '{52}'," & _
                                        "Repository = '{53}'," & _
                                        "ScopeContent = '{54}'," & _
                                        "SeparatedMaterial = '{55}'," & _
                                        "UnitDateFinal = '{56}'," & _
                                        "UnitDateFinalCertainty = '{57}'," & _
                                        "UnitDateInitial = '{58}'," & _
                                        "UnitDateInitialCertainty = '{59}'," & _
                                        "UseRestrict = '{60}'," & _
                                        "FilePlan = '{61}'," & _
                                        "ExtentCover = '{62}'," & _
                                        "UnitTitleType = '{63}'," & _
                                        "ExtentPage = '{64}'," & _
                                        "ExtentOther = '{65}'," & _
                                        "ExtentLeaf = '{66}'," & _
                                        "UnitDateBulk = '{67}'," & _
                                        "ContainerType = '{68}'," & _
                                        "ContainerCustomType = '{69}'," & _
                                        "CompleteUnitId = '{70}', " & _
                                        "AllowUnitDatesInference = '{71}', " & _
                                        "AllowExtentsInference = '{72}', " & _
                                        "ParentFondsID = '{73}', " & _
                                        "TakenBy = '{74}', " & _
                                        "Available = '{75}'" & _
                                        "WHERE ID={0}", myID, _
                                            BoolToDB(HasChildren), _
                                            BoolToDB(Visible), _
                                            BoolToDB(Valid), _
                                            OtherLevel, _
                                            StrToDB(UnitId), _
                                            StrToDB(CountryCode), _
                                            StrToDB(RepositoryCode), _
                                            StrToDB(UnitTitle), _
                                            StrToDB(Abstract), _
                                            StrToDB(AccessRestrict), _
                                            StrToDB(Accruals), _
                                            StrToDB(AcqInfo), _
                                            StrToDB(AltFormAvail), _
                                            StrToDB(Appraisal), _
                                            StrToDB(Arrangement), _
                                            StrToDB(BiogHist), _
                                            StrToDB(CustodHist), _
                                            StrToDB(Dimensions), _
                                            ExtentBook, _
                                            ExtentBox, _
                                            ExtentCapilha, _
                                            ExtentFolder, _
                                            ExtentMacete, _
                                            ExtentMaco, _
                                            DblToDB(ExtentMl), _
                                            ExtentRoll, _
                                            ExtentAlbum, _
                                            ExtentEnvelope, _
                                            StrToDB(GenreForm), _
                                            StrToDB(GeogName), _
                                            StrToDB(LangMaterial), _
                                            StrToDB(LegalStatus), _
                                            StrToDB(MaterialSpec), _
                                            StrToDB(Note), _
                                            StrToDB(OriginalNumbering), _
                                            StrToDB(OriginalsLoc), _
                                            StrToDB(OriginationAuthor), _
                                            StrToDB(OriginationAuthorAddress), _
                                            StrToDB(OriginationDestination), _
                                            StrToDB(OriginationDestinationAddress), _
                                            StrToDB(OriginationNotary), _
                                            StrToDB(OriginationScrivener), _
                                            StrToDB(OtherFindAid), _
                                            StrToDB(PhysFacet), _
                                            StrToDB(PhysLoc), _
                                            StrToDB(PhysTech), _
                                            StrToDB(PreferCite), _
                                            StrToDB(ProcessInfoDate), _
                                            StrToDB(ProcessInfoName), _
                                            StrToDB(ProcessInfo), _
                                            StrToDB(DescRules), _
                                            StrToDB(RelatedMaterial), _
                                            StrToDB(Repository), _
                                            StrToDB(ScopeContent), _
                                            StrToDB(SeparatedMaterial), _
                                            StrToDB(UnitDateFinal), _
                                            BoolToDB(UnitDateFinalCertainty), _
                                            StrToDB(UnitDateInitial), _
                                            BoolToDB(UnitDateInitialCertainty), _
                                            StrToDB(UseRestrict), _
                                            StrToDB(FilePlan), _
                                            ExtentCover, _
                                            StrToDB(UnitTitleType), _
                                            ExtentPage, _
                                            ExtentOther, _
                                            ExtentLeaf, _
                                            StrToDB(UnitDateBulk), _
                                            StrToDB(ContainerType), _
                                            StrToDB(ContainerCustomType), _
                                            StrToDB(CompleteUnitId), _
                                            BoolToDB(AllowUnitDatesInference), _
                                            BoolToDB(AllowExtentsInference), _
                                            ParentFondsId, _
                                            StrToDB(TakenBy), _
                                            BoolToDB(Available) _
                                        )
            SQLCommand.ExecuteNonQuery()


            ' ChronList            ' if we need to optmize updates... maybe testing if the object was altered. If not... dont update...
            SQLCommand.CommandText = String.Format("DELETE FROM ChronList WHERE ComponentID = '{0}'", myID)
            SQLCommand.ExecuteNonQuery()
            Dim clItem As ChronListItem
            For Each clItem In ChronList
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO ChronList (ComponentID, [Date], Event) VALUES ({0}, '{1}', '{2}')", _
                        myID, StrToDB(clItem.EventDate), StrToDB(clItem.EventDescription))
                SQLCommand.ExecuteNonQuery()
            Next


            ' Bibliography
            ' if we need to optmize updates... maybe testing if the object was altered. If not... dont update...
            SQLCommand.CommandText = String.Format("DELETE FROM Bibliography WHERE ComponentID = '{0}'", myID)
            SQLCommand.ExecuteNonQuery()
            Dim bibItem As BibRefItem
            For Each bibItem In Bibliography
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO Bibliography (ComponentID, BibRef) VALUES ({0}, '{1}')", _
                        myID, StrToDB(bibItem.BibRef))
                SQLCommand.ExecuteNonQuery()
            Next



            ' *********** Cut Here ***********
            ' DaoGrp
            ' if we need to optmize updates... maybe testing if the object was altered. If not... dont update...
            'SQLCommand.CommandText = String.Format("DELETE FROM DaoGrp WHERE ComponentID = '{0}'", myID)
            'SQLCommand.ExecuteNonQuery()
            'Dim daoItem As DaoLocItem
            'For Each daoItem In DaoGrp
            '    SQLCommand.CommandText = _
            '        String.Format("INSERT INTO DaoGrp (ComponentID, Title, Href) VALUES ({0}, '{1}', '{2}')", myID, StrToDB(daoItem.Title), StrToDB(daoItem.HRef))
            '    SQLCommand.ExecuteNonQuery()
            'Next
            ' *********** Cut Here ***********


            ' ControlAccess
            ' if we need to optmize updates... maybe testing if the object was altered. If not... dont update...
            SQLCommand.CommandText = String.Format("DELETE FROM ControlAccess WHERE ComponentID = '{0}'", myID)
            SQLCommand.ExecuteNonQuery()
            Dim caItem As ControlAccessItem
            For Each caItem In ControlAccess
                SQLCommand.CommandText = String.Format("INSERT INTO ControlAccess (ComponentID, ItemID) VALUES ({0}, {1})", myID, StrToDB(caItem.ID))
                SQLCommand.ExecuteNonQuery()
            Next

            Transaction.Commit()
            Debug.WriteLine("SQLLazynode: Uploaded To Database")

        Catch ex As SqlException
            If Not ex.Number = 8152 Then
                Transaction.Rollback()
                MsgBoxSqlException(ex)
            End If
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

    End Sub




    ' Optimizar esta funcao, trazendo toda a a informacao duma vez
    ' e criando todos os nodos aqui mesmo
    'Public Overrides Function Children() As LazyNodeCollection   ' COMPLETE

    '    Dim SQLConnection As SqlConnection = New SqlConnection
    '    SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

    '    Dim SQLCommand As New SqlCommand
    '    SQLCommand.Connection = SQLConnection


    '    Dim DataReader As SqlDataReader
    '    Dim NodeCollection As New LazyNodeCollection


    '    Try
    '        SQLConnection.Open()

    '        Select Case SortBy
    '            Case LazyNode.SortingStyles.ByUnitDateInitial
    '                SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY UnitDateInitial, UnitID", myID)
    '            Case LazyNode.SortingStyles.ByUnitID
    '                SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY UnitID, UnitDateInitial", myID)
    '            Case LazyNode.SortingStyles.ByOtherLevel
    '                SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY OtherLevel, UnitID, UnitDateInitial", myID)
    '            Case LazyNode.SortingStyles.ByProcessInfoDate
    '                SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY ProcessInfoDate, UnitID, UnitDateInitial, OtherLevel", myID)
    '            Case LazyNode.SortingStyles.ByUnitTitle
    '                SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY UnitTitle, UnitDateInitial, UnitId", myID)
    '            Case Else
    '                SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}'", myID)
    '        End Select

    '        DataReader = SQLCommand.ExecuteReader()
    '        While (DataReader.Read)
    '            Dim ID As Integer = DBToInt(DataReader.Item("ID"))
    '            Dim Node As New SQLLazyNode(myServerAddress, myDatabase, myUsername, myPassword, ID)
    '            Node.SortBy = Me.SortBy
    '            NodeCollection.Add(Node)
    '        End While

    '    Catch ex As Exception
    '        MsgBoxException(ex)
    '    Finally
    '        SQLConnection.Close()
    '    End Try

    '    Return NodeCollection
    'End Function




    Public Overrides Function Children() As LazyNodeCollection   ' COMPLETE

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection


        Dim DataReader As SqlDataReader
        Dim NodeCollection As New LazyNodeCollection


        Try
            SQLConnection.Open()

            Select Case SortBy
                Case LazyNode.SortingStyles.ByUnitDateInitial
                    SQLCommand.CommandText = String.Format("SELECT * FROM Components WHERE ParentID = '{0}' ORDER BY UnitDateInitial, UnitID", myID)
                Case LazyNode.SortingStyles.ByUnitID
                    SQLCommand.CommandText = String.Format("SELECT * FROM Components WHERE ParentID = '{0}' ORDER BY UnitID, UnitDateInitial", myID)
                Case LazyNode.SortingStyles.ByOtherLevel
                    SQLCommand.CommandText = String.Format("SELECT * FROM Components WHERE ParentID = '{0}' ORDER BY OtherLevel, UnitID, UnitDateInitial", myID)
                Case LazyNode.SortingStyles.ByProcessInfoDate
                    SQLCommand.CommandText = String.Format("SELECT * FROM Components WHERE ParentID = '{0}' ORDER BY ProcessInfoDate, UnitID, UnitDateInitial, OtherLevel", myID)
                Case LazyNode.SortingStyles.ByUnitTitle
                    SQLCommand.CommandText = String.Format("SELECT * FROM Components WHERE ParentID = '{0}' ORDER BY UnitTitle, UnitDateInitial, UnitId", myID)
                Case Else
                    SQLCommand.CommandText = String.Format("SELECT * FROM Components WHERE ParentID = '{0}'", myID)
            End Select

            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim Node As New SQLLazyNode(myServerAddress, myDatabase, myUsername, myPassword)
                Node.myID = ID
                Node.SortBy = Me.SortBy
                LoadProperties(Node, DataReader)
                Node.myBibliography = Nothing
                Node.myChronList = Nothing
                Node.myControlAccess = Nothing
                NodeCollection.Add(Node)
            End While
            DataReader.Close()

        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

        Return NodeCollection
    End Function



    Public Overrides Property Bibliography() As Bibliography
        Get
            If myBibliography Is Nothing Then
                DownloadBibliography()
            End If
            Return myBibliography
        End Get
        Set(ByVal Value As Bibliography)
            myBibliography = Value
        End Set
    End Property

    Public Overrides Property ChronList() As ChronList
        Get
            If myChronList Is Nothing Then
                DownloadChronList()
            End If
            Return myChronList
        End Get
        Set(ByVal Value As ChronList)
            myChronList = Value
        End Set
    End Property


    Public Overrides Property ControlAccess() As ControlAccess
        Get
            If myControlAccess Is Nothing Then
                DownloadControlAccess()
            End If
            Return myControlAccess
        End Get
        Set(ByVal Value As ControlAccess)
            myControlAccess = Value
        End Set
    End Property


    ' COMPLETE  -  falta testar... cuidado com o elementos complexos... se calhar é necessário fazer clones...
    Public Overrides Function Clone() As LazyNode
        Dim NewNode As LazyNode = CreateNode()
        NewNode.ImportFields(Me)
        NewNode.Upload()

        Dim Child As LazyNode
        For Each Child In Children()
            Dim NewChild As LazyNode = Child.Clone
            NewNode.AppendChild(NewChild)
        Next
        Return NewNode
    End Function



    Public Overrides Function CreateNode() As LazyNode ' COMPLETE
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection


        Dim NewID As Integer
        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("INSERT INTO Components (Valid, Visible, Haschildren, Otherlevel) VALUES (0, 0, 0, '{0}')", OTHERLEVEL_DOCUMENT)
            SQLCommand.ExecuteNonQuery()
            SQLCommand.CommandText = "SELECT SCOPE_IDENTITY() AS ID"
            NewID = CInt(SQLCommand.ExecuteScalar().ToString)

            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

        Dim Node As New SQLLazyNode(myServerAddress, myDatabase, myUsername, myPassword, NewID)
        Node.UnitId = UnitId
        Node.UnitTitle = UnitTitle
        Node.UnitTitleType = VisualFieldLabel("UnitTitleType.Original")
        Node.UnitDateFinalCertainty = True
        Node.UnitDateInitialCertainty = True
        Node.CountryCode = VisualFieldLabel("CountryCode.DefaultValue")
        Node.RepositoryCode = VisualFieldLabel("RepositoryCode.DefaultValue")
        Node.Repository = VisualFieldLabel("Repository.DefaultValue")
        Node.OtherLevel = OTHERLEVEL_DOCUMENT
        Node.LangMaterial = VisualFieldLabel("LangMaterial.DefaultValue")
        Node.UnitTitleType = VisualFieldLabel("UnitTitleType.Original")
        Node.Visible = False
        Node.Valid = False
        Node.Available = True
        Node.AllowUnitDatesInference = True
        Node.AllowExtentsInference = True
        Node.ParentFondsId = Me.ParentFondsId
        Return Node
    End Function



    Public Overrides Sub AppendChild(ByVal Child As LazyNode) ' COMPLETE
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction
        Dim DataReader As SqlDataReader

        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            Dim ChildID As Integer = CType(Child, SQLLazyNode).ID
            SQLCommand.CommandText = String.Format( _
                        "UPDATE Components SET ParentID='{0}' WHERE ID={1}", Me.myID, ChildID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
            If Not HasChildren Then UpdateHasChildren(True)
            '********** Cut here to remove update complete Unit id ***************
            'Child.ParentId = ID
            'Child.StopableCatamorphism(New GeneUpdateCompleteUnitId)
            'Child.Upload()
            '********** Cut here ***************
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

    End Sub



    Public Overrides ReadOnly Property HasChildren() As Boolean  ' COMPLETE
        Get
            Dim SQLConnection As SqlConnection = New SqlConnection
            SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

            Dim SQLCommand As New SqlCommand
            SQLCommand.Connection = SQLConnection

            Dim ChildrenAvailable As Boolean

            Try
                SQLConnection.Open()
                SQLCommand.CommandText = String.Format("SELECT HasChildren FROM Components WHERE ID = '{0}'", myID)
                ChildrenAvailable = DBToBool(SQLCommand.ExecuteScalar)
            Catch ex As Exception
                MsgBoxException(ex)
            Finally
                SQLConnection.Close()
            End Try
            Return ChildrenAvailable
        End Get
    End Property


    Private Sub UpdateHasChildren(ByVal Value As Boolean)
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format( _
                "Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", _
                myServerAddress, myDatabase, myUsername, myPassword)

        Dim Transaction As SqlTransaction
        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("UPDATE Components SET HasChildren='{1}' WHERE ID={0}", myID, BoolToDB(Value))
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    ' Recursively erases child nodes
    Public Overrides Sub RemoveChild(ByVal Child As LazyNode) ' COMPLETE - Falta testar... Isto 
        If Not TypeOf Child Is SQLLazyNode Then Exit Sub
        Dim Node As LazyNode

        For Each Node In Child.Children
            RemoveChild(Node)
        Next

        Dim SQLChildNode As SQLLazyNode = CType(Child, SQLLazyNode)
        RemoveNode(myServerAddress, myDatabase, myUsername, myPassword, SQLChildNode.ID)

        If Children.Count = 0 Then
            UpdateHasChildren(False)
        End If
    End Sub




    Public Overrides Property ParentId() As Object
        Get
            Return myParentId
        End Get
        Set(ByVal Value As Object)
            myParentId = CInt(Value)
        End Set
    End Property



    Public Property ParentFondsId() As Object
        Get
            Return myParentFondsId
        End Get
        Set(ByVal Value As Object)
            myParentFondsId = CInt(Value)
        End Set
    End Property



#End Region


#Region "Archivist Notes"

    Public Shared Function GetArchivistNotesList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ComponentID As Int64) As ArchivistNotes
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New ArchivistNotes

        Try

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT * FROM ArchivistNotes WHERE ComponentID = " & ComponentID
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ArchivistNotesItem As New ArchivistNotesItem
                ArchivistNotesItem.NoteID = DBToInt(DataReader.Item("NoteID"))
                ArchivistNotesItem.NoteTitle = DBToStr(DataReader.Item("NoteTitle"))
                ArchivistNotesItem.Note = DBToStr(DataReader.Item("Note"))
                ArchivistNotesItem.NoteDate = DBToStr(DataReader.Item("NoteDate"))
                ArchivistNotesItem.Username = DBToStr(DataReader.Item("Username"))

                ItemsList.Add(ArchivistNotesItem)
            End While

        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
        Return ItemsList
    End Function


    Public Shared Function GetArchivistNote(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal NoteID As Int64) As ArchivistNotesItem
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ArchivistNote As New ArchivistNotesItem

        Try

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT * FROM ArchivistNotes WHERE NoteID = " & NoteID
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                ArchivistNote.NoteID = DBToInt(DataReader.Item("NoteID"))
                ArchivistNote.NoteTitle = DBToStr(DataReader.Item("NoteTitle"))
                ArchivistNote.Note = DBToStr(DataReader.Item("Note"))
                ArchivistNote.NoteDate = DBToStr(DataReader.Item("NoteDate"))
                ArchivistNote.Username = DBToStr(DataReader.Item("Username"))
            End While

        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
        Return ArchivistNote
    End Function


    Public Shared Sub AddArchivistNote(ByVal ServerAddress As String, ByVal Database As String, _
                                       ByVal Username As String, ByVal Password As String, _
                                       ByVal ArchivistNote As ArchivistNotesItem)

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
            SQLCommand.CommandText = String.Format("INSERT INTO ArchivistNotes (NoteTitle, Note, NoteDate, ComponentID, Username) " & _
                                        "VALUES ('{0}','{1}','{2}','{3}','{4}')", _
                                        ArchivistNote.NoteTitle, ArchivistNote.Note, ArchivistNote.NoteDate, _
                                        ArchivistNote.ComponentID, ArchivistNote.Username)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

    End Sub

    Public Shared Sub RemoveArchivistNote(ByVal ServerAddress As String, ByVal Database As String, _
                                          ByVal Username As String, ByVal Password As String, _
                                          ByVal ArchivistNoteID As Int64)

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
            SQLCommand.CommandText = "DELETE FROM ArchivistNotes WHERE NoteID = " & ArchivistNoteID
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

    End Sub

    Public Shared Sub UpdateArchivistNote(ByVal ServerAddress As String, ByVal Database As String, _
                                          ByVal Username As String, ByVal Password As String, _
                                          ByVal ArchivistNote As ArchivistNotesItem)

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
            SQLCommand.CommandText = String.Format("UPDATE ArchivistNotes " & _
                                                   "SET NoteTitle='{0}', Note='{1}', NoteDate='{2}' " & _
                                                   "WHERE NoteID = {3}", _
                                                   ArchivistNote.NoteTitle, ArchivistNote.Note, _
                                                   ArchivistNote.NoteDate, ArchivistNote.NoteID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

    End Sub

#End Region


#Region "Get Associations"

    Public Shared Function GetAssociations(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ComponentID As Int64) As DataSet
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim myCommand As String

        Try
            myCommand = String.Format("SELECT DISTINCT DG.ComponentID, DO.Name AS DOName, DO.ArchiveID, DO.TopographicalQuota, DOF.Name AS DOFileName " & _
                                      "FROM DaoGrp DG " & _
                                      "INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                      "INNER JOIN DOFiles DOF ON DOF.FileID=DG.FileID " & _
                                      "WHERE DG.ComponentID = {0} AND DG.Type = 1 " & _
                                      "UNION " & _
                                      "SELECT DG.ComponentID, DO.Name, DO.ArchiveID, DO.TopographicalQuota, '' " & _
                                      "FROM DaoGrp DG " & _
                                      "INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                      "WHERE DG.ComponentID={0} AND DG.Type=0", ComponentID)

            myReader = New SqlDataAdapter(myCommand, SQLConnection.ConnectionString)
            myReader.Fill(myData)

        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
        Return myData
    End Function

#End Region


#Region "Set/Get node TakenBy"

    Public Shared Sub SetTaken(ByVal ServerAddress As String, ByVal Database As String, _
                                    ByVal Username As String, ByVal Password As String, _
                                    ByVal ComponentID As Int64, ByVal TakenBy As String)

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("UPDATE Components " & _
                                                   "SET TakenBy='{0}' " & _
                                                   "WHERE ID = {1}", _
                                                   StrToDB(TakenBy), ComponentID)
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

    End Sub

    Public Shared Function GetTaken(ByVal ServerAddress As String, ByVal Database As String, _
                                        ByVal Username As String, ByVal Password As String, _
                                        ByVal ComponentID As Int64) As String
        Dim TakenBy As String
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("SELECT TakenBy FROM Components " & _
                                                   "WHERE ID='{0}';", ComponentID)
            TakenBy = DBToStr(SQLCommand.ExecuteScalar)
            Transaction.Commit()
        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
        Return TakenBy
    End Function

#End Region


#Region "Get DigitArq version type"

    Public Shared Function IsStandalone(ByVal ServerAddress As String, ByVal Database As String, _
                                              ByVal Username As String, ByVal Password As String) As Boolean

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand

        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT Standalone FROM Aplications WHERE AplicationName='Digitarq'"

            Return SQLCommand.ExecuteScalar

        Catch ex As SqlException
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

    End Function

#End Region


End Class


