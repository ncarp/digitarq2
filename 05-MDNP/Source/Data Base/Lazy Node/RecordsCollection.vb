Imports System.Data.SqlClient ' SQL Server Data Provider

Public Class RecordsCollection


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
    'Public Sub New(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal ID As Integer, ByVal Capacity As Capacities)

    '    myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)
    '    myID = ID
    '    myCapacity = Capacity
    '    Download()
    'End Sub

    ''*************************************************************************
    'Public Sub New(ByVal strQuery As String, ByVal Capacity As Capacities)
    '    Dim hshDatabase As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")

    '    myServerAddress = hshDatabase("ServerAddress")
    '    myDatabase = hshDatabase("Database")
    '    myUsername = hshDatabase("Username")
    '    myPassword = hshDatabase("Password")

    '    myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
    '    myID = ID
    '    myCapacity = Capacity
    '    Download()
    'End Sub

    Public Sub New()
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = hshDatabase("ServerAddress")
        myDatabase = hshDatabase("Database")
        myUsername = hshDatabase("Username")
        myPassword = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
    End Sub

#End Region

    'Public Sub Download() ' Complete

    '    Select Case myCapacity
    '        'Case Capacities.Full : DownloadFull()
    '    Case Capacities.Minimum : DownloadMinimum()
    '        Case Capacities.Medium : DownloadMedium()

    '    End Select

    'End Sub

    Public Function DownloadRecordsCollection(ByVal strQuery As String) As DataSet
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        'Dim SQLCommand As New SqlCommand
        'SQLCommand.Connection = SQLConnection
        Dim SQLDataAdapter As SqlDataAdapter
        'SQLDataAdapter.Connection = SQLConnection
        Dim SQLDataSet As New DataSet

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            'Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            'SQLDataAdapter.Transaction = Transaction
            Dim CommandText As String = String.Format("SELECT ID,CompleteUnitID,UnitID,ParentID,OtherLevel,UnitTitle," & _
            " UnitDateInitial,UnitDateFinal,UnitDateFinalCertainty,UnitDateInitialCertainty,Visible,PhysLoc" & _
            " FROM Components WHERE {0}", strQuery)


            SQLDataAdapter = New SqlDataAdapter(CommandText, SQLConnection)
            SQLDataAdapter.Fill(SQLDataSet)

            Return SQLDataSet
            'Catch ex As SqlException
            'Transaction.Rollback()
            'MsgBoxSqlException(ex)
        Catch ex As Exception
            Dim erro As String = ex.ToString
            Dim a As String = "aaa"
            'MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Function

    'Private Sub DownloadMedium()
    '    Dim SQLConnection As SqlConnection = New SqlConnection
    '    SQLConnection.ConnectionString = myConnString

    '    Dim SQLCommand As New SqlCommand
    '    Dim DataReader As SqlDataReader
    '    SQLCommand.Connection = SQLConnection

    '    Dim Transaction As SqlTransaction
    '    Try
    '        SQLConnection.Open()
    '        Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
    '        SQLCommand.Transaction = Transaction
    '        SQLCommand.CommandText = String.Format("SELECT ID,UnitID,CompleteUnitId,UnitTitle," & _
    '            "UnitDateInitialCertainty,UnitDateInitial,UnitDateFinalCertainty,UnitDateFinal,OtherLevel," & _
    '            "PhysLoc,Visible FROM Components WHERE ID = '{0}'", myID)

    '        DataReader = SQLCommand.ExecuteReader()
    '        While DataReader.Read()
    '            UnitId = DBToStr(DataReader.Item("UnitId"))
    '            CompleteUnitId = DBToStr(DataReader.Item("CompleteUnitId"))
    '            UnitTitle = DBToStr(DataReader.Item("UnitTitle"))
    '            OtherLevel = DBToStr(DataReader.Item("OtherLevel"))
    '            PhysLoc = DBToStr(DataReader.Item("PhysLoc"))
    '            UnitDateFinalCertainty = DBToBool(DataReader.Item("UnitDateFinalCertainty"))
    '            UnitDateInitialCertainty = DBToBool(DataReader.Item("UnitDateInitialCertainty"))
    '            UnitDateInitial = DBToStr(DataReader.Item("UnitDateInitial"))
    '            UnitDateFinal = DBToStr(DataReader.Item("UnitDateFinal"))
    '            Visible = DBToBool(DataReader.Item("Visible"))
    '        End While
    '        DataReader.Close()
    '        Dim EacDescriptionExists As Boolean

    '        SQLCommand.CommandText = String.Format("SELECT COUNT(FondsID) FROM EAC WHERE FondsID = '{0}'", myID)
    '        EacDescriptionExists = CType(SQLCommand.ExecuteScalar, Integer) = 1
    '        EAC = EacDescriptionExists

    '        'Get DOGobject---> DaoGrp
    '        SQLCommand.CommandText = String.Format("SELECT ID_DigitalObject FROM DaoGrp WHERE ComponentID = '{0}'", myID)
    '        Dim drDaoGrp As SqlDataReader
    '        drDaoGrp = SQLCommand.ExecuteReader()
    '        DigitalObjectExists = drDaoGrp.HasRows()

    '        If Not DigitalObjectExists Then
    '            DigitalObjectID = CType(-1, Int64)
    '        End If

    '        While drDaoGrp.Read()
    '            DigitalObjectID = drDaoGrp.Item("ID_DigitalObject")
    '        End While
    '        drDaoGrp.Close()

    '        If DigitalObjectExists Then
    '            getNumImages()
    '        End If

    '        If (OtherLevel = "D" Or OtherLevel = "DC" Or OtherLevel = "UI") Then
    '            IsDSDCUI = True
    '        Else
    '            IsDSDCUI = False
    '        End If

    '        Transaction.Commit()
    '        'Debug.WriteLine("SQLLazynode: " & UnitId & " Downloaded from Database")

    '    Catch ex As SqlException
    '        Transaction.Rollback()
    '        'MsgBoxSqlException(ex)
    '    Catch ex As Exception
    '        'MsgBoxException(ex)
    '    Finally
    '        SQLConnection.Close()
    '        'SQLConnectionGOD.Close()
    '    End Try
    'End Sub




End Class
