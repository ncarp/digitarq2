Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.IO
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Xml
Imports System.Reflection.Assembly
Imports System.Configuration.ConfigurationSettings
Imports System.DirectoryServices

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

        Dim FoundItServerAddress As Boolean = False
        Dim FoundItDatabase As Boolean = False
        'Dim FoundItUsername As Boolean = False
        'Dim FoundItPassword As Boolean = False

        Dim ConfigFullName As String

        Try
            Dim AplicationName As String
            Dim ServerAddress As String = Me.Context.Parameters.Item("ServerAddress")
            Dim Database As String = Me.Context.Parameters.Item("Database")
            'Dim Username As String = Me.Context.Parameters.Item("Username")
            'Dim Password As String = Me.Context.Parameters.Item("Password")
            Dim AssemblyPath As String = Me.Context.Parameters("assemblypath")
            Dim MainDirectory As String = AssemblyPath.Substring(0, AssemblyPath.LastIndexOf("\bin"))
            ConfigFullName = MainDirectory + "\Web.config"
            Dim XmlDocument As New System.Xml.XmlDocument
            XmlDocument.Load(ConfigFullName)

            ' Throw New InstallException(XmlDocument.OuterXml)
            ' Finds the right node and change it to the new value.
            Dim Node As System.Xml.XmlNode

            For Each Node In XmlDocument.Item("configuration").Item("sqlServerSettings")
                If Node.Name = "add" Then ' skip any comments
                    Select Case Node.Attributes.GetNamedItem("key").Value
                        Case "ServerAddress"
                            Node.Attributes.GetNamedItem("value").Value = ServerAddress
                            FoundItServerAddress = True
                        Case "Database"
                            Node.Attributes.GetNamedItem("value").Value = Database
                            FoundItDatabase = True
                            'Case "Username"
                            '    Node.Attributes.GetNamedItem("value").Value = Username
                            '    FoundItUsername = True
                            'Case "Password"
                            '    Node.Attributes.GetNamedItem("value").Value = Password
                            '    FoundItPassword = True
                    End Select
                End If
            Next Node

            For Each Node In XmlDocument.Item("configuration").Item("appSettings")
                If Node.Name = "add" Then ' skip any comments
                    Select Case Node.Attributes.GetNamedItem("key").Value
                        Case "Aplication.Name"
                            AplicationName = Node.Attributes.GetNamedItem("value").Value
                    End Select
                End If
            Next

            If Not FoundItServerAddress Then
                Throw New InstallException("Config file did not contain a ServerName section.")
            End If

            If Not FoundItDatabase Then
                Throw New InstallException("Config file did not contain a DatabaseName section.")
            End If

            'If Not FoundItPassword Then
            '    Throw New InstallException("Config file did not contain a Password section.")
            'End If


            XmlDocument.Save(ConfigFullName)

            CreateVirtualDirectory("localhost", AplicationName, MainDirectory)

            'AddLogin(ServerAddress, Database, Username, Password)

        Catch ex As Exception
            Throw New InstallException(ConfigFullName)
        End Try
    End Sub


    Private Function AddLogin(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String) As Boolean
        Dim Success As Boolean = False

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI; Persist Security Info=False;", ServerAddress, Database)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            Try
                SQLCommand.CommandText = String.Format("USE {2}; EXEC sp_addlogin '{0}','{1}','{2}','Portuguese';", Username, Password, Database)
                SQLCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Throw New InstallException("Erro1: " & ex.ToString)
            End Try

            Try
                SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_grantdbaccess '{1}';", Database, Username)
                SQLCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Throw New InstallException("Erro1: " & ex.ToString)
            End Try

            Try
                SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_addrolemember 'db_owner', '{1}';", Database, Username)
                SQLCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Throw New InstallException("Erro1: " & ex.ToString)
            End Try

            Success = True
        Catch ex As Exception
            Throw New InstallException("Erro a criar utilizador da BD: " & ex.ToString)
            Success = False
        Finally
            SQLConnection.Close()
        End Try
        Return Success
    End Function


    Private Sub CreateVirtualDirectory(ByVal WebSite As String, ByVal AppName As String, ByVal Path As String)

        Dim IISSchema As New System.DirectoryServices.DirectoryEntry("IIS://" & WebSite & "/Schema/AppIsolated")
        Dim CanCreate As Boolean = Not IISSchema.Properties("Syntax").Value.ToString.ToUpper() = "BOOLEAN"
        IISSchema.Dispose()
        If CanCreate Then
            Dim PathCreated As Boolean

            Try
                Dim IISAdmin As New System.DirectoryServices.DirectoryEntry("IIS://" & WebSite & "/W3SVC/1/Root")
                If Not System.IO.Directory.Exists(Path) Then
                    System.IO.Directory.CreateDirectory(Path)
                    PathCreated = True
                End If

                For Each VD As System.DirectoryServices.DirectoryEntry In IISAdmin.Children
                    If VD.Name = AppName Then
                        IISAdmin.Invoke("Delete", New String() {VD.SchemaClassName, AppName})
                        IISAdmin.CommitChanges()
                        Exit For
                    End If
                Next VD

                'Create and setup new virtual directory
                Dim VDir As System.DirectoryServices.DirectoryEntry = IISAdmin.Children.Add(AppName, "IIsWebVirtualDir")
                VDir.Properties("Path").Item(0) = Path
                VDir.Properties("AppFriendlyName").Item(0) = AppName
                VDir.Properties("EnableDirBrowsing").Item(0) = False
                VDir.Properties("AccessRead").Item(0) = True
                VDir.Properties("AccessExecute").Item(0) = True
                VDir.Properties("AccessWrite").Item(0) = False
                VDir.Properties("AccessScript").Item(0) = True
                VDir.Properties("AuthNTLM").Item(0) = True
                VDir.Properties("EnableDefaultDoc").Item(0) = True
                VDir.Properties("DefaultDoc").Item(0) = "default.htm,default.aspx,default.asp"
                VDir.Properties("AspEnableParentPaths").Item(0) = True
                VDir.CommitChanges()

                'the following are acceptable params
                'INPROC = 0
                'OUTPROC = 1
                'POOLED = 2
                VDir.Invoke("AppCreate", 1)

            Catch Ex As Exception
                If PathCreated Then
                    System.IO.Directory.Delete(Path)
                End If
                'Throw New InstallException(WebSite + "#" + AppName + "#" + Path)
            End Try
        End If
    End Sub



End Class
