Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Configuration

<RunInstaller(True)> Public Class DigitarqInstaller
    Inherits System.Configuration.Install.Installer

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Installer overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region

    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)

        MyBase.Install(stateSaver)

        Dim ServerAddress As String = Me.Context.Parameters.Item("ServerAddress")
        Dim DataBase As String = Me.Context.Parameters.Item("DataBase")

        If CreateDatabase(ServerAddress, DataBase) Then
            CreateTables(ServerAddress, DataBase)
        End If

    End Sub


    Private Function CreateDatabase(ByVal ServerAddress As String, ByVal DataBase As String) As Boolean

        Dim Success As Boolean = False

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI; Persist Security Info=False;", ServerAddress, "Master")

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            SQLCommand.CommandText = String.Format("CREATE DATABASE {0}", DataBase)
            SQLCommand.ExecuteNonQuery()

            Success = True
        Catch ex As Exception
            Throw New InstallException("Erro a criar base dados: ServerAddress: " & ServerAddress & " Database: " & DataBase)
            Success = False
        Finally
            SQLConnection.Close()
        End Try
        Return Success
    End Function


    Private Function CreateTables(ByVal ServerAddress As String, ByVal DataBase As String) As Boolean
        Dim Success As Boolean = False

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI; Persist Security Info=False;", ServerAddress, DataBase)

        Try
            SQLConnection.Open()
            Dim SQLCommand As New SqlCommand
            SQLCommand.Connection = SQLConnection

            Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(Asm.Location)
            Dim DirLocation As String = FileInfo.DirectoryName()

            SQLCommand.CommandText = ReadFile(DirLocation + "\database.sql")
            SQLCommand.ExecuteNonQuery()

            Success = True
        Catch ex As Exception
            Throw New InstallException("Erro a criar tabelas: " & ex.ToString)
            Success = False
        Finally
            SQLConnection.Close()
        End Try
        Return Success
    End Function


    Private Function ReadFile(ByVal filename As String) As String
        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader(filename, System.Text.Encoding.Default)
            Dim str As String = sr.ReadToEnd
            sr.Close()
            Return str
        Catch E As Exception
            Throw New InstallException(E.ToString)
            Return ""
        End Try
    End Function

End Class
