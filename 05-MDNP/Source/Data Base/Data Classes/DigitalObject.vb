Imports System.Data.SqlClient

Public Class DigitalObject

#Region "Properties"
    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
    Private myConnString As String

    Private myDigitalObjectID As Int64
    Private myProjectID As Int64
    Private myName As String
    Private myArchiveID As String
    Private myArchivingProfile As String
    Private myCaptureEntityCorporate As String
    Private myResponsabilityEntity As String
    Private myCreationDateTime As String
    Private myArchiveDateTime As String
    Private myDepositeDateTime As String
    Private myRevisionDateTime As String
    Private myExternalDescriptiveInformation As String
    Private myPreservationOriginalInformation As String
    Private myQuantityOfTerminalObjects As Integer
    Private myTopographicalQuota As String
    Private myStructure As String
    Private myDOUsername As String
    Private myActive As Integer
#End Region

    Public Sub New()
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = hshDatabase("ServerAddress")
        myDatabase = hshDatabase("Database")
        myUsername = hshDatabase("Username")
        myPassword = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
    End Sub

    Public Sub New(ByVal DigitalObjectID As Int64)
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = hshDatabase("ServerAddress")
        myDatabase = hshDatabase("Database")
        myUsername = hshDatabase("Username")
        myPassword = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
        myDigitalObjectID = DigitalObjectID
        Download()

    End Sub

#Region "Gets and Sets of Public Properties"

    Public Property DigitalObjectID() As Int64
        Get
            Return myDigitalObjectID
        End Get
        Set(ByVal Value As Int64)
            myDigitalObjectID = Value
        End Set
    End Property

    Public Property ProjectID() As Int64
        Get
            Return myProjectID
        End Get
        Set(ByVal Value As Int64)
            myProjectID = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Public Property ArchiveID() As String
        Get
            Return myArchiveID
        End Get
        Set(ByVal Value As String)
            myArchiveID = Value
        End Set
    End Property

    Public Property ArchivingProfile() As String
        Get
            Return myArchivingProfile
        End Get
        Set(ByVal Value As String)
            myArchivingProfile = Value
        End Set
    End Property

    Public Property CaptureEntityCorporate() As String
        Get
            Return myCaptureEntityCorporate
        End Get
        Set(ByVal Value As String)
            myCaptureEntityCorporate = Value
        End Set
    End Property

    Public Property ResponsabilityEntity() As String
        Get
            Return myResponsabilityEntity
        End Get
        Set(ByVal Value As String)
            myResponsabilityEntity = Value
        End Set
    End Property

    Public Property CreationDateTime() As String
        Get
            Return myCreationDateTime
        End Get
        Set(ByVal Value As String)
            myCreationDateTime = Value
        End Set
    End Property

    Public Property ArchiveDateTime() As String
        Get
            Return myArchiveDateTime
        End Get
        Set(ByVal Value As String)
            myArchiveDateTime = Value
        End Set
    End Property

    Public Property DepositeDateTime() As String
        Get
            Return myDepositeDateTime
        End Get
        Set(ByVal Value As String)
            myDepositeDateTime = Value
        End Set
    End Property

    Public Property RevisionDateTime() As String
        Get
            Return myRevisionDateTime
        End Get
        Set(ByVal Value As String)
            myRevisionDateTime = Value
        End Set
    End Property

    Public Property ExternalDescriptiveInformation() As String
        Get
            Return myExternalDescriptiveInformation
        End Get
        Set(ByVal Value As String)
            myExternalDescriptiveInformation = Value
        End Set
    End Property

    Public Property PreservationOriginalInformation() As String
        Get
            Return myPreservationOriginalInformation
        End Get
        Set(ByVal Value As String)
            myPreservationOriginalInformation = Value
        End Set
    End Property

    Public Property QuantityOfTerminalObjects() As Integer
        Get
            Return myQuantityOfTerminalObjects
        End Get
        Set(ByVal Value As Integer)
            myQuantityOfTerminalObjects = Value
        End Set
    End Property

    Public Property TopographicalQuota() As String
        Get
            Return myTopographicalQuota
        End Get
        Set(ByVal Value As String)
            myTopographicalQuota = Value
        End Set
    End Property

    Public Property DOStructure() As String
        Get
            Return myStructure
        End Get
        Set(ByVal Value As String)
            myStructure = Value
        End Set
    End Property

    Public Property Username() As String
        Get
            Return myDOUsername
        End Get
        Set(ByVal Value As String)
            myDOUsername = Value
        End Set
    End Property

#End Region


    Private Sub Download()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try


            SQLConnection.Open()
            'Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            'SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("SELECT DigitalObjectID, Name, Structure FROM DigitalObjects WHERE DigitalObjectID = '{0}'", myDigitalObjectID)
            Dim DataReader As SqlDataReader

            DataReader = SQLCommand.ExecuteReader()
            DataReader.Read()

            Me.DigitalObjectID = DBToInt64(DataReader.Item("DigitalObjectID"))
            Me.Name = DBToStr(DataReader.Item("Name"))
            Me.DOStructure = DBToStr(DataReader.Item("Structure"))

            DataReader.Close()


        Catch ex As SqlException
            'Transaction.Rollback()
            ''MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


    Public Function GetFirstImage(ByVal DigitalObjectID As Int64) As Integer
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try


            SQLConnection.Open()

            SQLCommand.CommandText = String.Format("SELECT TOP 1 FileID FROM DOfiles " & _
                                                   "WHERE DigitalObjectID={0} " & _
                                                   "ORDER BY FileID ASC", DigitalObjectID)
            Return SQLCommand.ExecuteScalar

        Catch ex As SqlException
            Dim str As String = ex.ToString
        Catch ex As Exception
            Dim str As String = ex.ToString
            Dim str1 As String = ex.ToString
        Finally
            SQLConnection.Close()
        End Try
    End Function


End Class
