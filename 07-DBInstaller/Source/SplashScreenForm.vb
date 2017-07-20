Imports System.IO
Imports System.Threading
Imports System.Configuration
Imports System.Data.SqlClient ' SQL Server Data Provider



Public Class SplashScreenForm
    Inherits System.Windows.Forms.Form

    Declare Function HideCaret Lib "user32.dll" (ByVal hwnd As Long) As Long


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal ServerAddress As String, ByVal Database As String, ByVal InstallationType As Integer)
        MyBase.New()

        myServerAddress = ServerAddress
        myDatabase = Database
        myInstallationType = InstallationType

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LinkClose As System.Windows.Forms.LinkLabel
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SplashScreenForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.LinkClose = New System.Windows.Forms.LinkLabel
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox.Image = CType(resources.GetObject("PictureBox.Image"), System.Drawing.Image)
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(474, 312)
        Me.PictureBox.TabIndex = 30
        Me.PictureBox.TabStop = False
        '
        'LinkClose
        '
        Me.LinkClose.AutoSize = True
        Me.LinkClose.BackColor = System.Drawing.Color.White
        Me.LinkClose.Location = New System.Drawing.Point(385, 290)
        Me.LinkClose.Name = "LinkClose"
        Me.LinkClose.Size = New System.Drawing.Size(39, 16)
        Me.LinkClose.TabIndex = 33
        Me.LinkClose.TabStop = True
        Me.LinkClose.Text = CType(configurationAppSettings.GetValue("LinkClose.Text", GetType(System.String)), String)
        Me.LinkClose.Visible = False
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.Color.White
        Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutput.Location = New System.Drawing.Point(35, 136)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(384, 112)
        Me.txtOutput.TabIndex = 34
        Me.txtOutput.TabStop = False
        Me.txtOutput.Text = ""
        '
        'SplashScreenForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(454, 312)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.LinkClose)
        Me.Controls.Add(Me.PictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreenForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Properties "
    Private myFailedTests As Integer
    Private myServerAddress As String
    Private myDatabase As String
    Private myInstallationType As Integer

    Public ReadOnly Property FailedTests() As Integer
        Get
            Return myFailedTests
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub SplashScreenForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        CheckPrerequisites()
    End Sub

    Private Sub AppendToOutput(ByVal Line As String)
        txtOutput.Select(0, 0)
        txtOutput.AppendText(Line)
        txtOutput.ScrollToCaret()
        'txtOutput.SelectionStart = txtOutput.Text.Length
    End Sub


    Private Sub LinkClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkClose.LinkClicked
        Close()
        Dispose()
    End Sub

#End Region

#Region "System Tests"

    Public Function CheckPrerequisites() As Boolean
        Dim t As New Thread(AddressOf TestPrerequisites)
        t.Start()
        While t.IsAlive
            Application.DoEvents()
        End While

        If myFailedTests = 0 Then
            Thread.Sleep(1500)
        Else
            LinkClose.Visible = True
            txtOutput.ScrollBars = ScrollBars.Vertical
            txtOutput.ScrollToCaret()
        End If
        Return Me.myFailedTests = 0
    End Function




    Private Sub TestPrerequisites()
        myFailedTests = 0
        AppendToOutput(InfoMessage("Prerequisites.InitializingTest") & ControlChars.NewLine & ControlChars.NewLine)

        If myFailedTests = 0 Then CreateDatabase()
        'If myFailedTests = 0 Then TestExistenceOfEacXslt()
        'If myFailedTests = 0 Then TestExistenceOfCnfXslt()
        'If myFailedTests = 0 Then TestExistenceOfDatabaseSQL()
        'If myFailedTests = 0 Then TestDatabase()
        If myFailedTests = 0 Then CreateTables()
        'If myFailedTests = 0 Then TestVersionOfAplication()
        If myFailedTests = 0 Then
            AppendToOutput(ControlChars.NewLine & InfoMessage("Prerequisites.OpeningDigitArq"))
        Else
            AppendToOutput(ControlChars.NewLine & InfoMessage("Prerequisites.PrerequisitesFailed"))
        End If
    End Sub

    Private Sub TestAdminUsername()
        'AppendToOutput(InfoMessage("Prerequisites.AdministratorMissing"))
        'If Users.AdministratorMissing Then
        '    Users.CreateAdmin()
        '    AppendToOutput(InfoMessage("Prerequisites.Recovered"))
        'Else
        '    AppendToOutput(InfoMessage("Prerequisites.Ok"))
        'End If
        'AppendToOutput(ControlChars.NewLine)
    End Sub

    Private Function CreateDatabase() As Boolean
        Dim Success As Boolean = False

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI; Persist Security Info=False;", myServerAddress, "Master")

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            SQLCommand.CommandText = String.Format("CREATE DATABASE {0}", myDatabase)
            SQLCommand.ExecuteNonQuery()

            Success = True
        Catch ex As Exception
            MsgBox("Erro a criar base dados: ServerAddress: " & myServerAddress & " Database: " & myDatabase)
            Success = False
        Finally
            SQLConnection.Close()
        End Try
        Return Success
    End Function


    Private Function CreateTables() As Boolean
        Dim Success As Boolean = False

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI; Persist Security Info=False;", myServerAddress, myDatabase)

        Try
            SQLConnection.Open()
            Dim SQLCommand As New SqlCommand
            SQLCommand.Connection = SQLConnection

            Dim Asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(Asm.Location)
            Dim DirLocation As String = FileInfo.DirectoryName()

            SQLCommand.CommandText = ReadFile(Application.StartupPath + "\..\Resources\database.sql")
            SQLCommand.ExecuteNonQuery()

            Success = True
        Catch ex As Exception
            MsgBox("Erro a criar tabelas: " & ex.ToString)
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
            MsgBox(E.ToString)
            Return ""
        End Try
    End Function

#End Region

End Class
