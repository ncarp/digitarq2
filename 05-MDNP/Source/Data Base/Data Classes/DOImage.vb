Imports System.Data.SqlClient

Public Class DOImage
    Inherits DOImagesItem


#Region "Internal Properties (private)"
    '*************************************************************************
    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
    Private myConnString As String

    Private myDigitalObjectID As Int64
    Private myDOImages As DOImages
    Private myID As Int64
    Private myImageType As ImageType
    Private myCapacity As Capacities
    Private myDoItem As DOImages

    Public Enum Capacities
        Image
        Description
        Tree
    End Enum

    Public Enum ImageType
        Derivative
        Thumb
    End Enum

#End Region

#Region "Public properties"
    Property AllDOImages() As DOImages
        Get
            Return myDOImages
        End Get
        Set(ByVal Value As DOImages)
            myDOImages = Value
        End Set
    End Property
#End Region

    Public Sub New(ByVal DigitalObjectID As Int64, ByVal ID As Int64, ByVal capacity As Capacities, Optional ByVal imageType As ImageType = ImageType.Derivative)
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = hshDatabase("ServerAddress")
        myDatabase = hshDatabase("Database")
        myUsername = hshDatabase("Username")
        myPassword = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
        myDigitalObjectID = DigitalObjectID
        myID = ID
        myImageType = imageType
        myCapacity = capacity

        Download()

    End Sub

    Public Sub New(ByVal DigitalObjectID As Int64)
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = hshDatabase("ServerAddress")
        myDatabase = hshDatabase("Database")
        myUsername = hshDatabase("Username")
        myPassword = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", myServerAddress, myDatabase, myUsername, myPassword)
        myDigitalObjectID = DigitalObjectID
        myCapacity = Capacities.Tree
        Download()
    End Sub

    Public Sub Download() ' Complete

        Select Case myCapacity
            Case Capacities.Description : DownloadDesc()
            Case Capacities.Image : DownloadImage()
        End Select
    End Sub

    Private Sub DownloadDesc()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT * FROM DOFiles WHERE DigitalObjectID = '{0}' and FileID='{1}'", myDigitalObjectID, myID)
            Dim DataReader As SqlDataReader

            DataReader = SQLCommand.ExecuteReader()
            While DataReader.Read()

                Me.FileID = DBToInt(DataReader.Item("FileID"))

                Me.FileName = DBToStr(DataReader.Item("Name"))
                Me.Resolution = DBToStr(DataReader.Item("Resolution"))
                Me.ImageWidth = DBToStr(DataReader.Item("ImageWidth"))
                Me.ImageHeight = DBToStr(DataReader.Item("ImageHeight"))
                Me.ImageSize = DBToStr(DataReader.Item("ImageSize"))
                Me.ColorSpace = DBToStr(DataReader.Item("ColorSpace"))
                Me.BitDepth = DBToStr(DataReader.Item("BitDepth"))
            End While

            DataReader.Close()
        Catch ex As SqlException
        Catch ex As Exception
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Private Sub DownloadImage()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            Dim DataReader As SqlDataReader

            Select Case myImageType
                Case ImageType.Derivative
                    SQLCommand.CommandText = String.Format("SELECT FileID, Name, Image FROM DOFiles WHERE DigitalObjectID = '{0}' and FileID='{1}'", myDigitalObjectID, myID)
                    DataReader = SQLCommand.ExecuteReader()
                    While DataReader.Read()
                        Me.FileID = DBToInt(DataReader.Item("FileID"))
                        Me.FileName = DBToStr(DataReader.Item("Name"))
                        Me.Image = DBToByte(DataReader.Item("Image"))
                    End While
                Case ImageType.Thumb
                    SQLCommand.CommandText = String.Format("SELECT FileID, Name, Thumb FROM DOFiles WHERE DigitalObjectID = '{0}' and FileID='{1}'", myDigitalObjectID, myID)
                    DataReader = SQLCommand.ExecuteReader()
                    While DataReader.Read()
                        Me.FileID = DBToInt(DataReader.Item("FileID"))
                        Me.FileName = DBToStr(DataReader.Item("Name"))
                        Me.Image = DBToByte(DataReader.Item("Thumb"))
                    End While
            End Select

            DataReader.Close()
        Catch ex As SqlException
        Catch ex As Exception
        Finally
            SQLConnection.Close()
        End Try
    End Sub

End Class
