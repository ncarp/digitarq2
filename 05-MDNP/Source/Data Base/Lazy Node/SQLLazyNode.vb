Imports System.Data.SqlClient ' SQL Server Data Provider


Public Class SQLLazyNode
    Inherits LazyNode

#Region "Internal Properties (private)"
    '*************************************************************************
    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
    Private myConnString As String

    Private myID As Integer
    Private myParentID As Integer
    Private myCapacity As Integer

    Public Enum Capacities
        Full
        Medium
        Minimum
    End Enum

    '*************************************************************************
#End Region

#Region "Initializations"
    '*************************************************************************
    Public Sub New(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ID As Integer, ByVal Capacity As Capacities)
       
        myconnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)
        myID = ID
        myCapacity = Capacity
        Download()
    End Sub

    '*************************************************************************
    Public Sub New(ByVal ID As Integer, ByVal Capacity As Capacities)
        'Dim hshDatabase As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = hshDatabase("ServerAddress")
        myDatabase = hshDatabase("Database")
        myUsername = hshDatabase("Username")
        myPassword = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
        myID = ID
        myCapacity = Capacity
        Download()
    End Sub

    Public Sub New()
        'Dim hshDatabase As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = hshDatabase("ServerAddress")
        myDatabase = hshDatabase("Database")
        myUsername = hshDatabase("Username")
        myPassword = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
    End Sub

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
            ''MsgBoxSqlException(ex)
            Throw ex
        Catch ex As Exception
            'MsgBoxException(ex)
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
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)
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
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)
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
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub


    ' COMPLETE
    Public Shared Function GetControlAccessTypeList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String) As colCtlAccessType
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim TypesList As New colCtlAccessType


        Try

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT ID, Type FROM ControlAccessTypes ORDER BY TYPE"
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim Type As String = DBToStr(DataReader.Item("Type"))

                Dim Item As New ControlAccessType(ID, Type)
                TypesList.Add(Item)
            End While


        Catch ex As Exception

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
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)

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
            'MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub



    ' COMPLETE
    Public Shared Function GetControlAccessItemListInFonds(ByVal ServerAddress As String, _
                                ByVal Database As String, ByVal Username As String, _
                                ByVal Password As String, ByVal FondsID As Integer) _
                                As colCtlAccessItem


        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New colCtlAccessItem


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
            'MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return ItemsList
    End Function


    Public Shared Function GetControlAccessItemListNotInFonds(ByVal ServerAddress As String, _
                               ByVal Database As String, ByVal Username As String, _
                               ByVal Password As String, ByVal FondsID As Integer) _
                               As colCtlAccessItem


        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New colCtlAccessItem


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
            'MsgBoxException(ex)

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
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)

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
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub


    ' COMPLETE
    Public Shared Function GetControlAccessItemList(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String) As colCtlAccessItem
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim ItemsList As New colCtlAccessItem


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
                'Debug.WriteLine("GetControlAccessItemList:" & Item)
            End While

        Catch ex As Exception
            'MsgBoxException(ex)

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
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Public Sub loadControlAccessTypes(ByVal ddl As DropDownList, Optional ByVal strStartItem As String = "")
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT DISTINCT CAT.ID, CAT.Type " & _
                                     "FROM ControlAccess CA " & _
                                     "INNER JOIN ControlAccessItems CAI ON CA.ItemID=CAI.ID " & _
                                     "INNER JOIN ControlAccessTypes CAT ON CAI.TypeID=CAT.ID"

            ddl.DataTextField = "Type"
            ddl.DataValueField = "ID"

            ddl.DataSource = SQLCommand.ExecuteReader
            ddl.DataBind()
            Dim si As New ListItem
            si.Value = "0"
            si.Text = strStartItem
            ddl.Items.Insert(0, si)
        Catch ex As Exception
            Dim erro As String = ex.ToString
            Dim aa As String = "aa"
        Finally
            SQLCommand = Nothing
            SQLConnection.Close()
            SQLConnection.Dispose()
        End Try
    End Sub


    Public Sub loadControlAccessItems(ByVal ddl As DropDownList, ByVal intTypeID As Integer)
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT DISTINCT ControlAccessItems.ID,ControlAccessItems.TypeID,ControlAccessItems.Item " & _
            " FROM ControlAccessItems, ControlAccess WHERE TypeID='{0}' AND ControlAccess.ItemID=ControlAccessItems.ID", intTypeID)

            ddl.DataTextField = "Item"
            ddl.DataValueField = "ID"

            ddl.DataSource = SQLCommand.ExecuteReader
            ddl.DataBind()
        Catch ex As Exception

        Finally
            SQLCommand = Nothing
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






    ' COMPLETE



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
                Dim UnitDateInitial As String = DBToDate(DataReader.Item("UnitDateInitial"))
                Dim UnitDateFinal As String = DBToDate(DataReader.Item("UnitDateFinal"))
                Dim Visible As Boolean = DBToBool(DataReader.Item("Visible"))

                Dim Item As New FondsListItem(ID, UnitId, UnitTitle, UnitDateInitial, UnitDateFinal, Visible)
                FondsList.Add(Item)
            End While


        Catch ex As Exception
            'MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try


        Return FondsList
    End Function


#End Region


#Region "LazyNode Methods"
    '*************************************************************************

    Public Overrides Sub Download() ' Complete

        Select Case myCapacity
            Case Capacities.Full : DownloadFull()
            Case Capacities.Medium : DownloadMedium()
            Case Capacities.Minimum : DownloadMinimum()

        End Select

    End Sub

    Private Sub DownloadMinimum()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("SELECT ID,CompleteUnitID,UnitID,ParentID,OtherLevel,UnitTitle,UnitTitleType," & _
            " UnitDateInitial,UnitDateFinal,UnitDateFinalCertainty,UnitDateInitialCertainty,Visible" & _
            " FROM Components WHERE ID = '{0}'", myID)
            Dim DataReader As SqlDataReader

            DataReader = SQLCommand.ExecuteReader()
            While DataReader.Read()
                CompleteUnitId = DBToStr(DataReader.Item("CompleteUnitId"))
                UnitId = DBToStr(DataReader.Item("UnitId"))
                ParentID = DBToInt(DataReader.Item("ParentID"))
                OtherLevel = DBToStr(DataReader.Item("OtherLevel"))
                UnitTitle = DBToStr(DataReader.Item("UnitTitle"))
                UnitTitleType = DBToStr(DataReader.Item("UnitTitleType"))
                UnitDateInitial = DBToStr(DataReader.Item("UnitDateInitial"))
                UnitDateFinal = DBToStr(DataReader.Item("UnitDateFinal"))
                UnitDateFinalCertainty = DBToBool(DataReader.Item("UnitDateFinalCertainty"))
                UnitDateInitialCertainty = DBToBool(DataReader.Item("UnitDateInitialCertainty"))
                Visible = DBToBool(DataReader.Item("Visible"))
            End While
            'myParentID = ParentID
            DataReader.Close()

            Transaction.Commit()
            'Debug.WriteLine("SQLLazynode: " & UnitId & " Downloaded from Database")

        Catch ex As SqlException
            Transaction.Rollback()
        Catch ex As Exception

        Finally
            SQLConnection.Close()
            SQLConnection.Dispose()
        End Try
    End Sub

    Private Sub DownloadMedium()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        Dim DataReader As SqlDataReader
        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("SELECT ID, CountryCode + '/' + RepositoryCode + '/' + CompleteUnitId AS Reference, UnitTitle, UnitTitleType, " & _
                "UnitDateInitialCertainty, UnitDateInitial, UnitDateFinalCertainty, UnitDateFinal, OtherLevel," & _
                "PhysLoc, Visible FROM Components WHERE ID = '{0}'", myID)

            DataReader = SQLCommand.ExecuteReader()
            While DataReader.Read()
                CompleteUnitId = DBToStr(DataReader.Item("Reference")).ToUpper
                UnitTitle = DBToStr(DataReader.Item("UnitTitle"))
                UnitTitleType = DBToStr(DataReader.Item("UnitTitleType"))
                OtherLevel = DBToStr(DataReader.Item("OtherLevel"))
                PhysLoc = DBToStr(DataReader.Item("PhysLoc"))
                UnitDateFinalCertainty = DBToBool(DataReader.Item("UnitDateFinalCertainty"))
                UnitDateInitialCertainty = DBToBool(DataReader.Item("UnitDateInitialCertainty"))
                UnitDateInitial = DBToStr(DataReader.Item("UnitDateInitial"))
                UnitDateFinal = DBToStr(DataReader.Item("UnitDateFinal"))
                Visible = DBToBool(DataReader.Item("Visible"))
            End While
            DataReader.Close()
            Dim EacDescriptionExists As Boolean

            SQLCommand.CommandText = String.Format("SELECT COUNT(FondsID) FROM EAC WHERE FondsID = '{0}'", myID)
            EacDescriptionExists = CType(SQLCommand.ExecuteScalar, Integer) = 1
            Eac = EacDescriptionExists

            'Get DO ---> DaoGrp
            SQLCommand.CommandText = String.Format("SELECT DISTINCT DG.ComponentID, DG.DigitalObjectID, DG.FileID, DG.Type, " & _
                                        "DO.Name AS DOName, DO.ArchiveID, DO.TopographicalQuota, DO.Active, DOF.Name AS DOFileName " & _
                                        "FROM DaoGrp DG " & _
                                        "INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                        "INNER JOIN DOFiles DOF ON DOF.FileID=DG.FileID " & _
                                        "WHERE DG.ComponentID = {0} AND DG.Type = 1 " & _
                                        "UNION " & _
                                        "SELECT DISTINCT DG.ComponentID, DG.DigitalObjectID, DG.FileID, DG.Type, " & _
                                        "DO.Name AS DOName, DO.ArchiveID, DO.TopographicalQuota, DO.Active, '' " & _
                                        "FROM DaoGrp DG " & _
                                        "INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                        "WHERE DG.ComponentID={0} AND DG.Type=0", ID)
            Dim drDaoGrp As SqlDataReader
            drDaoGrp = SQLCommand.ExecuteReader()
            DigitalObjectExists = drDaoGrp.HasRows()

            If Not DigitalObjectExists Then
                DigitalObjectID = CType(-1, Int64)
            End If

            While drDaoGrp.Read()
                If drDaoGrp.Item("Active") Then
                    Dim DaoGrpItem As New DaoGrp
                    DaoGrpItem.ComponentID = drDaoGrp.Item("ComponentID")
                    DaoGrpItem.DigitalObjectID = drDaoGrp.Item("DigitalObjectID")
                    DaoGrpItem.DigitalObjectName = drDaoGrp.Item("DOName")
                    DaoGrpItem.FileID = drDaoGrp.Item("FileID")
                    DaoGrpItem.FileName = drDaoGrp.Item("DOFileName")
                    DaoGrpItem.Type = drDaoGrp.Item("Type")
                    DaoGrpItem.ArchiveID = drDaoGrp.Item("ArchiveID")
                    DaoGrpItem.TopographicalQuota = drDaoGrp.Item("TopographicalQuota")

                    If CInt(drDaoGrp.Item("Type")) = 0 Then
                        DaoGrpItem.NumImages = GetNumImages(drDaoGrp.Item("DigitalObjectID"))
                    Else
                        DaoGrpItem.NumImages = 1
                    End If
                    DaoGrp.Add(DaoGrpItem)
                End If
            End While
            drDaoGrp.Close()

            If (OtherLevel = "D" Or OtherLevel = "DC" Or OtherLevel = "UI") Then
                IsDSDCUI = True
            Else
                IsDSDCUI = False
            End If

            Transaction.Commit()
            'Debug.WriteLine("SQLLazynode: " & UnitId & " Downloaded from Database")

        Catch ex As SqlException
            Transaction.Rollback()
            'MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)
        Finally
            DataReader.Close()
            SQLCommand.Dispose()
            SQLConnection.Close()
            SQLConnection.Dispose()
        End Try
    End Sub

    Private Function GetNumImages(ByVal intDigitalObjectID As Int64) As Integer
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString
        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT COUNT(FileID) as NumberImages FROM DOFiles" & _
            " WHERE Image IS NOT NULL AND DigitalObjectID='{0}'", intDigitalObjectID)

            Return SQLCommand.ExecuteScalar
        Catch ex As Exception
            DigitalObjectExists = False
            DOImageGOD = True
        Finally
            SQLCommand.Dispose()
            SQLConnection.Close()
            SQLConnection.Dispose()
        End Try
    End Function


    Private Sub DownloadFull()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim DataReader As SqlDataReader

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("SELECT CountryCode + '/' + RepositoryCode + '/' + CompleteUnitId AS Reference, * FROM Components WHERE ID = '{0}'", myID)

            DataReader = SQLCommand.ExecuteReader()
            While DataReader.Read()
                ParentID = DBToInt(DataReader.Item("ParentID"))
                UnitId = DBToStr(DataReader.Item("UnitId"))
                CompleteUnitId = DBToStr(DataReader.Item("Reference")).ToUpper
                UnitTitle = DBToStr(DataReader.Item("UnitTitle"))
                UnitTitleType = DBToStr(DataReader.Item("UnitTitleType"))
                Visible = DBToBool(DataReader.Item("Visible"))
                Valid = DBToBool(DataReader.Item("Valid"))
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
                ExtentMl = DBToInt(DataReader.Item("ExtentMl"))
                ExtentRoll = DBToInt(DataReader.Item("ExtentRoll"))
                ExtentEnvelope = DBToInt(DataReader.Item("ExtentEnvelope"))
                ExtentAlbum = DBToInt(DataReader.Item("ExtentAlbum"))

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

            End While

            DataReader.Close()

            'Get DO ---> DaoGrp
            SQLCommand.CommandText = String.Format("SELECT DISTINCT DG.ComponentID, DG.DigitalObjectID, DG.FileID, " & _
                                        "DG.Type, DO.Name AS DOName, DO.ArchiveID, DO.TopographicalQuota, DO.Active , DOF.Name AS DOFileName " & _
                                        "FROM DaoGrp DG " & _
                                        "INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                        "INNER JOIN DOFiles DOF ON DOF.FileID=DG.FileID " & _
                                        "WHERE DG.ComponentID = {0} AND DG.Type = 1 " & _
                                        "UNION " & _
                                        "SELECT DISTINCT DG.ComponentID, DG.DigitalObjectID, DG.FileID, Type, DO.Name AS DOName, " & _
                                        "DO.ArchiveID, DO.TopographicalQuota, DO.Active, '' " & _
                                        "FROM DaoGrp DG " & _
                                        "INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                        "WHERE DG.ComponentID={0} AND DG.Type=0", ID)
            Dim drDaoGrp As SqlDataReader
            drDaoGrp = SQLCommand.ExecuteReader()
            DigitalObjectExists = drDaoGrp.HasRows()

            If Not DigitalObjectExists Then
                DigitalObjectID = CType(-1, Int64)
            End If

            While drDaoGrp.Read()
                If drDaoGrp.Item("Active") Then
                    Dim DaoGrpItem As New DaoGrp
                    DaoGrpItem.ComponentID = drDaoGrp.Item("ComponentID")
                    DaoGrpItem.DigitalObjectID = drDaoGrp.Item("DigitalObjectID")
                    DaoGrpItem.DigitalObjectName = drDaoGrp.Item("DOName")
                    DaoGrpItem.FileID = drDaoGrp.Item("FileID")
                    DaoGrpItem.FileName = drDaoGrp.Item("DOFileName")
                    DaoGrpItem.Type = drDaoGrp.Item("Type")
                    DaoGrpItem.ArchiveID = drDaoGrp.Item("ArchiveID")
                    DaoGrpItem.TopographicalQuota = drDaoGrp.Item("TopographicalQuota")

                    If CInt(drDaoGrp.Item("Type")) = 0 Then
                        DaoGrpItem.NumImages = GetNumImages(drDaoGrp.Item("DigitalObjectID"))
                    Else
                        DaoGrpItem.NumImages = 1
                    End If
                    DaoGrp.Add(DaoGrpItem)
                End If
            End While
            drDaoGrp.Close()

            If (OtherLevel = "D" Or OtherLevel = "DC" Or OtherLevel = "UI") Then
                IsDSDCUI = True
            Else
                IsDSDCUI = False
            End If

            Dim EacDescriptionExists As Boolean

            SQLCommand.CommandText = String.Format("SELECT count(FondsID) FROM EAC WHERE FondsID = '{0}'", myID)
            EacDescriptionExists = CType(SQLCommand.ExecuteScalar, Integer) = 1
            Eac = EacDescriptionExists

            Transaction.Commit()
            'Debug.WriteLine("SQLLazynode: " & UnitId & " Downloaded from Database")

        Catch ex As SqlException
            Transaction.Rollback()
            'MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)
        Finally
            Transaction.Dispose()
            DataReader.Close()
            SQLCommand.Dispose()
            SQLConnection.Close()
            SQLConnection.Dispose()
        End Try
    End Sub



    Public Overrides Function Children() As LazyNodeCollection   ' COMPLETE

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Dim NodeCollection As New LazyNodeCollection

        Try
            SQLConnection.Open()

            Select Case SortBy
                Case LazyNode.SortingStyles.ByUnitDateInitial
                    SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY UnitDateInitial, UnitID", myID)
                Case LazyNode.SortingStyles.ByUnitID
                    SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY UnitID, UnitDateInitial", myID)
                Case LazyNode.SortingStyles.ByOtherLevel
                    SQLCommand.CommandText = String.Format("SELECT ID FROM Components WHERE ParentID = '{0}' ORDER BY OtherLevel, UnitID, UnitDateInitial", myID)
                Case Else
                    SQLCommand.CommandText = String.Format("SELECT ID, UnitTitle, UnitdateInitial, UnitdateFinal FROM Components WHERE ParentID = '{0}'", myID)
            End Select

            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))
                Dim Node As New SQLLazyNode(ID, Capacities.Minimum)
                'Node.SortBy = Me.SortBy
                NodeCollection.Add(Node)
            End While

        Catch ex As Exception
            'MsgBoxException(ex)
        Finally
            SQLCommand.Dispose()
            DataReader.Close()
            SQLConnection.Close()
            SQLConnection.Dispose()
        End Try
        Return NodeCollection
    End Function


    ' COMPLETE  -  falta testar... cuidado com o elementos complexos... se calhar é necessário fazer clones...


    Public Overrides ReadOnly Property HasChildren() As Boolean  ' COMPLETE
        Get
            Dim SQLConnection As SqlConnection = New SqlConnection
            SQLConnection.ConnectionString = myConnString

            Dim SQLCommand As New SqlCommand
            SQLCommand.Connection = SQLConnection

            Dim ChildrenAvailable As Boolean

            Try
                SQLConnection.Open()
                SQLCommand.CommandText = String.Format("SELECT HasChildren FROM Components WHERE ID = '{0}'", myID)
                ChildrenAvailable = DBToBool(SQLCommand.ExecuteScalar)
            Catch ex As Exception
                'MsgBoxException(ex)
            Finally
                SQLCommand.Dispose()
                SQLConnection.Close()
                SQLConnection.Dispose()
            End Try
            Return ChildrenAvailable
        End Get
    End Property


    Public Overrides Function colParentsToNItself() As LazyNodeCollection
        Dim NodeCollection As New LazyNodeCollection
        Dim ID As Integer = DBToInt(myID)
        While ID <> -1
            Dim Node As New SQLLazyNode(ID, Capacities.Minimum)
            NodeCollection.Add(Node)
            ID = DBToInt(Node.ParentID)
        End While
        Return NodeCollection
    End Function

    Public Overloads Overrides Function strFullPath() As String
        Return strFullPath(colParentsToNItself())
    End Function


    Public Overloads Overrides Function strFullPath(ByVal colParentsToNItself As LazyNodeCollection) As String
        Dim Path As String

        Dim iFirst As Integer = colParentsToNItself.Count - 1
        Dim iLast As Integer = 0
        While iFirst >= iLast
            If iFirst = 0 Then
                Path &= colParentsToNItself.Item(iFirst).UnitId
            Else
                If colParentsToNItself.Item(iFirst).OtherLevel = colParentsToNItself.Item(iFirst - 1).OtherLevel.Remove(0, 1) Then
                    Path &= colParentsToNItself.Item(iFirst).UnitId & "-"
                Else
                    Path &= colParentsToNItself.Item(iFirst).UnitId & "/"
                End If
            End If

            iFirst = iFirst - 1
        End While

        Return Path
    End Function




    '*************************************************************************************
    ' Function: objQryRecs
    ' Purpose: It returns all the Rec(ord)s ID's derived from the 
    '          sql Q(ue)ry(- gotten for the entrance of text,
    '          given for the user in textboxes, that it is related with the columns of the 
    '          components table)
    '*************************************************************************************
    Public Function objQryRecs(ByVal strQry As String, ByVal strSortBy As String, _
        ByVal strOrder As String) As RecordsIDCollection

        Dim RecordsIDCollection As New RecordsIDCollection
        Dim strCmdText As String ' Com(an)d Text, sqlQuery

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim DataReader As SqlDataReader
        Select Case strSortBy
            Case "date"
                strCmdText = String.Format("{0} ORDER BY UnitDateInitial {1}", strQry, strOrder)
            Case "title"
                strCmdText = String.Format("{0} ORDER BY UnitTitle {1}", strQry, strOrder)
            Case "level"
                strCmdText = String.Format("{0} ORDER BY 1 {1}", strOrderByOtherLevelQry(strQry), strOrder)
            Case Else
                strCmdText = String.Format("{0} ORDER BY CompleteUnitID ASC", strQry)
        End Select
        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format(strCmdText)
            DataReader = SQLCommand.ExecuteReader()
            While DataReader.Read()
                RecordsIDCollection.Add(DataReader.Item("ID"))
            End While
        Catch ex As Exception
            Dim erro As String = ex.ToString
            Dim erro1 As String = ex.ToString
        Finally
            SQLCommand.Dispose()
            DataReader.Close()
            SQLConnection.Close()
        End Try
        Return RecordsIDCollection
    End Function

    '*************************************************************************************
    ' Function: sdrOrderByOtherLevelASCQry
    ' Purpose: It returns a String commandText query for order the results from OtherLevel='F'
    '     OtherLevel='D'. I call it ascendant way.
    '*************************************************************************************
    Private Function strOrderByOtherLevelQry(ByVal strSubQry As String) As String
        Dim strOtherLevelAscOrder() As String = {"D", "DC", "UI", "SSR", "SR", "SSSC", "SSC", "SC", "SF", "F"}
        Dim strVariables() As String = {"x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8", "x9", "x10"}
        Dim i As Integer
        Dim strOtherLevelASCQry As String

        For i = 1 To 10
            strOtherLevelASCQry &= "(SELECT " & i & " AS Col1," & strVariables(i - 1) & ".ID," & strVariables(i - 1) & ".OtherLevel" & _
                " FROM (" & strSubQry & ") AS " & strVariables(i - 1) & _
                " WHERE OtherLevel='" & strOtherLevelAscOrder(i - 1) & "')UNION"
        Next
        strOtherLevelASCQry = strOtherLevelASCQry.TrimEnd(CStr("UNION").ToCharArray)
        Return strOtherLevelASCQry
    End Function
#End Region

End Class


