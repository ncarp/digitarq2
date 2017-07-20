Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.IO
Imports System.Threading
Imports System.Configuration
Imports SQLDMO

Public Class Main
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblServerAddress As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txbDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txbServerAddress As System.Windows.Forms.TextBox
    Friend WithEvents pbxSplash As System.Windows.Forms.PictureBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents LinkClose As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Main))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblServerAddress = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDatabase = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.txbDatabase = New System.Windows.Forms.TextBox
        Me.txbServerAddress = New System.Windows.Forms.TextBox
        Me.pbxSplash = New System.Windows.Forms.PictureBox
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.LinkClose = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-40, -8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(497, 68)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblServerAddress
        '
        Me.lblServerAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerAddress.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.lblServerAddress.Location = New System.Drawing.Point(56, 120)
        Me.lblServerAddress.Name = "lblServerAddress"
        Me.lblServerAddress.Size = New System.Drawing.Size(136, 21)
        Me.lblServerAddress.TabIndex = 2
        Me.lblServerAddress.Text = CType(configurationAppSettings.GetValue("lblServerAddress.Text", GetType(System.String)), String)
        Me.lblServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(-8, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 8)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'lblDatabase
        '
        Me.lblDatabase.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabase.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.lblDatabase.Location = New System.Drawing.Point(56, 168)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(136, 21)
        Me.lblDatabase.TabIndex = 7
        Me.lblDatabase.Text = CType(configurationAppSettings.GetValue("lblDatabase.Text", GetType(System.String)), String)
        Me.lblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(32, 72)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(232, 21)
        Me.lblTitle.TabIndex = 8
        Me.lblTitle.Text = CType(configurationAppSettings.GetValue("lblTitle.Text", GetType(System.String)), String)
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(280, 272)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = CType(configurationAppSettings.GetValue("btnCancel.Text", GetType(System.String)), String)
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.White
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Location = New System.Drawing.Point(365, 272)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = CType(configurationAppSettings.GetValue("btnNext.Text", GetType(System.String)), String)
        '
        'txbDatabase
        '
        Me.txbDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txbDatabase.Location = New System.Drawing.Point(200, 168)
        Me.txbDatabase.Name = "txbDatabase"
        Me.txbDatabase.Size = New System.Drawing.Size(240, 20)
        Me.txbDatabase.TabIndex = 1
        Me.txbDatabase.Text = CType(configurationAppSettings.GetValue("txbDatabase.Text", GetType(System.String)), String)
        '
        'txbServerAddress
        '
        Me.txbServerAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txbServerAddress.Location = New System.Drawing.Point(200, 120)
        Me.txbServerAddress.Name = "txbServerAddress"
        Me.txbServerAddress.Size = New System.Drawing.Size(240, 20)
        Me.txbServerAddress.TabIndex = 1
        Me.txbServerAddress.Text = CType(configurationAppSettings.GetValue("txbServerAddress.Text", GetType(System.String)), String)
        '
        'pbxSplash
        '
        Me.pbxSplash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxSplash.Cursor = System.Windows.Forms.Cursors.Default
        Me.pbxSplash.Image = CType(resources.GetObject("pbxSplash.Image"), System.Drawing.Image)
        Me.pbxSplash.Location = New System.Drawing.Point(-2, -2)
        Me.pbxSplash.Name = "pbxSplash"
        Me.pbxSplash.Size = New System.Drawing.Size(454, 312)
        Me.pbxSplash.TabIndex = 46
        Me.pbxSplash.TabStop = False
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.Color.White
        Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutput.Location = New System.Drawing.Point(34, 136)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(384, 112)
        Me.txtOutput.TabIndex = 47
        Me.txtOutput.TabStop = False
        Me.txtOutput.Text = ""
        '
        'LinkClose
        '
        Me.LinkClose.AutoSize = True
        Me.LinkClose.BackColor = System.Drawing.Color.White
        Me.LinkClose.Location = New System.Drawing.Point(384, 288)
        Me.LinkClose.Name = "LinkClose"
        Me.LinkClose.Size = New System.Drawing.Size(39, 16)
        Me.LinkClose.TabIndex = 48
        Me.LinkClose.TabStop = True
        Me.LinkClose.Text = CType(configurationAppSettings.GetValue("LinkClose.Text", GetType(System.String)), String)
        Me.LinkClose.Visible = False
        '
        'Main
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(452, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.LinkClose)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.pbxSplash)
        Me.Controls.Add(Me.txbServerAddress)
        Me.Controls.Add(Me.txbDatabase)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblServerAddress)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties "
    Private myFailedTests As Integer
    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Dim hshDatabase As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")

    Public ReadOnly Property FailedTests() As Integer
        Get
            Return myFailedTests
        End Get
    End Property

    Public ReadOnly Property ServerAddress()
        Get
            Return Me.txbServerAddress.Text
        End Get
    End Property

    Public ReadOnly Property DataBase()
        Get
            Return Me.txbDatabase.Text
        End Get
    End Property

    Public ReadOnly Property Username()
        Get
            Return hshDatabase("Username")
        End Get
    End Property

    Public ReadOnly Property Password()
        Get
            Return hshDatabase("Password")
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.pbxSplash.Visible = False
        Me.txtOutput.Visible = False
        Me.Show()
        If CType(configurationAppSettings.GetValue("Standalone", GetType(System.String)), String).Equals("true") Then
            btnNext_Click(sender, e)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Me.pbxSplash.Visible = True
        Me.txtOutput.Visible = True
        ConfigureDatabase()
        Me.LinkClose.Visible = True
    End Sub

    Private Sub AppendToOutput(ByVal Line As String)
        txtOutput.Select(0, 0)
        txtOutput.AppendText(Line)
        txtOutput.ScrollToCaret()
    End Sub

    Private Sub LinkClose_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkClose.LinkClicked
        Close()
        Dispose()
    End Sub

#End Region

#Region "Database configuration"

    Public Function ConfigureDatabase() As Boolean
        Dim t As New Thread(AddressOf TestPrerequisites)
        t.Start()
        While t.IsAlive
            System.Windows.Forms.Application.DoEvents()
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
        AppendToOutput(InfoMessage("Database.Initializing") & ControlChars.NewLine & ControlChars.NewLine)

        If myFailedTests = 0 Then CreateDatabase()
        If myFailedTests = 0 Then CreateTables()
        If myFailedTests = 0 Then InsertRecords()
        If myFailedTests = 0 Then CreateProcedures()
        If myFailedTests = 0 Then CreateLogins()
        If Not CType(configurationAppSettings.GetValue("Standalone", GetType(System.String)), String).Equals("true") Then
            If myFailedTests = 0 Then CreateFullText()
        End If

        If myFailedTests = 0 Then
            AppendToOutput(ControlChars.NewLine & InfoMessage("Database.Success"))
        Else
            AppendToOutput(ControlChars.NewLine & InfoMessage("Database.Failed"))
        End If
    End Sub


    Private Function CreateDatabase() As Boolean

        AppendToOutput(String.Format(InfoMessage("Database.CreateDatabase"), DataBase))

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
            AppendToOutput(InfoMessage("Process.Ok"))
        Catch ex As Exception
            AppendToOutput(InfoMessage("Process.Failed"))
            myFailedTests += 1
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
        Return Success
    End Function


    Private Function CreateTables() As Boolean
        AppendToOutput(InfoMessage("Database.CreateTables"))
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

            If CType(configurationAppSettings.GetValue("SQLServer", GetType(System.String)), String).Equals("2005") Then
                SQLCommand.CommandText = ReadFile(System.Windows.Forms.Application.StartupPath + "\..\Resources\createTables_2005.sql")
            ElseIf CType(configurationAppSettings.GetValue("SQLServer", GetType(System.String)), String).Equals("2000") Then
                SQLCommand.CommandText = ReadFile(System.Windows.Forms.Application.StartupPath + "\..\Resources\createTables_2000.sql")
            End If
            SQLCommand.ExecuteNonQuery()

            Success = True
            AppendToOutput(InfoMessage("Process.Ok"))
        Catch ex As Exception
            AppendToOutput(ex.ToString)
            AppendToOutput(InfoMessage("Process.Failed"))
            myFailedTests += 1
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
        Return Success
    End Function


    Private Function InsertRecords() As Boolean
        AppendToOutput(InfoMessage("Database.InsertRecords"))
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

            SQLCommand.CommandText = ReadFile(System.Windows.Forms.Application.StartupPath + "\..\Resources\insertRecords.sql")
            SQLCommand.ExecuteNonQuery()

            Success = True
            AppendToOutput(InfoMessage("Process.Ok"))
        Catch ex As Exception
            AppendToOutput(ex.ToString)
            AppendToOutput(InfoMessage("Process.Failed"))
            myFailedTests += 1
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
        Return Success
    End Function

    Private Function CreateProcedures() As Boolean
        AppendToOutput(InfoMessage("Database.CreateProcedures"))
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

            If CType(configurationAppSettings.GetValue("SQLServer", GetType(System.String)), String).Equals("2005") Then
                SQLCommand.CommandText = ReadFile(System.Windows.Forms.Application.StartupPath + "\..\Resources\storedProcedures_2005.sql")
            ElseIf CType(configurationAppSettings.GetValue("SQLServer", GetType(System.String)), String).Equals("2000") Then
                SQLCommand.CommandText = ReadFile(System.Windows.Forms.Application.StartupPath + "\..\Resources\storedProcedures_2000.sql")
            End If
            SQLCommand.ExecuteNonQuery()

            Success = True
            AppendToOutput(InfoMessage("Process.Ok"))
        Catch ex As Exception
            MsgBox(ex.ToString)
            AppendToOutput(InfoMessage("Process.Failed"))
            myFailedTests += 1
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
        Return Success
    End Function

    Private Function CreateFullText() As Boolean
        AppendToOutput(InfoMessage("Database.CreateFullTextIndex"))
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

            SQLCommand.CommandText = ReadFile(System.Windows.Forms.Application.StartupPath + "\..\Resources\fulltext.sql")
            SQLCommand.ExecuteNonQuery()

            Success = True
            AppendToOutput(InfoMessage("Process.Ok"))
        Catch ex As Exception
            AppendToOutput(InfoMessage("Process.Failed"))
            myFailedTests += 1
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
        Return Success
    End Function

    Private Function CreateLogins() As Boolean
        AppendToOutput(InfoMessage("Database.CreateLogins"))
        Dim Success As Boolean = False

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI;", ServerAddress, DataBase)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            Try
                SQLCommand.CommandText = String.Format("USE {2}; EXEC sp_addlogin '{0}','{1}','{2}','Portuguese'", Username, Password, DataBase)
                SQLCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Throw New InstallException("Erro1: " & ex.ToString)
            End Try

            Try
                SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_grantdbaccess '{1}';", DataBase, Username)
                SQLCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Throw New InstallException("Erro1: " & ex.ToString)
            End Try

            Try
                SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_addrolemember 'db_owner', '{1}';", DataBase, Username)
                SQLCommand.ExecuteNonQuery()
            Catch ex As Exception
                'Throw New InstallException("Erro1: " & ex.ToString)
            End Try

            Success = True
            AppendToOutput(InfoMessage("Process.Ok"))
        Catch ex As Exception
            AppendToOutput(InfoMessage("Process.Failed"))
            myFailedTests += 1
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
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
