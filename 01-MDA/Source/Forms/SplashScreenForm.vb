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
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents LinkClose As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SplashScreenForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.LinkClose = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox.Image = CType(resources.GetObject("PictureBox.Image"), System.Drawing.Image)
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(474, 250)
        Me.PictureBox.TabIndex = 30
        Me.PictureBox.TabStop = False
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.Color.White
        Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutput.Location = New System.Drawing.Point(104, 160)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(288, 72)
        Me.txtOutput.TabIndex = 32
        Me.txtOutput.TabStop = False
        Me.txtOutput.Text = ""
        '
        'LinkClose
        '
        Me.LinkClose.AutoSize = True
        Me.LinkClose.BackColor = System.Drawing.Color.White
        Me.LinkClose.Location = New System.Drawing.Point(432, 224)
        Me.LinkClose.Name = "LinkClose"
        Me.LinkClose.Size = New System.Drawing.Size(39, 16)
        Me.LinkClose.TabIndex = 33
        Me.LinkClose.TabStop = True
        Me.LinkClose.Text = CType(configurationAppSettings.GetValue("LinkClose.Text", GetType(System.String)), String)
        Me.LinkClose.Visible = False
        '
        'SplashScreenForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(474, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.LinkClose)
        Me.Controls.Add(Me.txtOutput)
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

    Public ReadOnly Property FailedTests() As Integer
        Get
            Return myFailedTests
        End Get
    End Property

#End Region

#Region "Events"
    Private Sub SplashScreenForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
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

        If myFailedTests = 0 Then TestOperatingSystem()
        If myFailedTests = 0 Then TestExistenceOfEacXslt()
        If myFailedTests = 0 Then TestExistenceOfCnfXslt()
        If myFailedTests = 0 Then TestExistenceOfDatabaseSQL()
        'If myFailedTests = 0 Then TestDatabase()
        If myFailedTests = 0 Then TestAdminUsername()
        If myFailedTests = 0 Then TestVersionOfAplication()
        If myFailedTests = 0 Then
            AppendToOutput(ControlChars.NewLine & InfoMessage("Prerequisites.OpeningDigitArq"))
        Else
            AppendToOutput(ControlChars.NewLine & InfoMessage("Prerequisites.PrerequisitesFailed"))
        End If
    End Sub

    Private Sub TestAdminUsername()
        AppendToOutput(InfoMessage("Prerequisites.AdministratorMissing"))
        If Users.AdministratorMissing Then
            Users.CreateAdmin()
            AppendToOutput(InfoMessage("Prerequisites.Recovered"))
        Else
            AppendToOutput(InfoMessage("Prerequisites.Ok"))
        End If
        AppendToOutput(ControlChars.NewLine)
    End Sub

    Private Sub TestDatabase()

        AppendToOutput(InfoMessage("Prerequisites.Database"))

        Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")

        Dim myUsername As String = SQLServerSettings("Username")
        Dim myDatabase As String = SQLServerSettings("Database")
        Dim myServerAddress As String = SQLServerSettings("ServerAddress")
        Dim myPassword As String = SQLServerSettings("Password")

        Dim SQLConnection As SqlConnection = New SqlConnection


        Dim Transaction As SqlTransaction
        Try
            SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

            Dim SQLCommand As New SqlCommand
            SQLCommand.Connection = SQLConnection

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT count(name) FROM sysobjects WHERE " & _
            "name = 'Components' OR " & _
            "name = 'DaoGrp' OR " & _
            "name = 'Bibliography' OR " & _
            "name = 'ChronList' OR " & _
            "name = 'ControlAccessTypes' OR " & _
            "name = 'ControlAccessItems' OR " & _
            "name = 'ControlAccessItemsFonds' OR " & _
            "name = 'ControlAccess' OR " & _
            "name = 'EacRelationships' OR " & _
            "name = 'EAC' OR " & _
            "name = 'EacResourceRelationships' OR " & _
            "name = 'EacMaintenanceHistory' OR " & _
            "name = 'EacLanguageDecl' OR " & _
            "name = 'EacArchRelationships' OR " & _
            "name = 'EacIdentity' OR " & _
            "name = 'Users' OR " & _
            "name = 'Log'"

            If CInt(SQLCommand.ExecuteScalar()) <> 17 Then
                AppendToOutput(InfoMessage("Prerequisites.Failed"))
                myFailedTests += 1
            Else
                AppendToOutput(InfoMessage("Prerequisites.Ok"))
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)

            If TryToBuildDatabase() Then ' try to recover
                AppendToOutput(InfoMessage("Prerequisites.Recovered"))
            Else
                AppendToOutput(InfoMessage("Prerequisites.Failed"))
                myFailedTests += 1
            End If
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
    End Sub


    Private Function CreateDatabase() As Boolean
        Dim Success As Boolean = False
        Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")


        Dim mySA_Username As String = SQLServerSettings("SA_Username")
        Dim mySA_Password As String = SQLServerSettings("SA_Password")
        Dim myUsername As String = SQLServerSettings("Username")
        Dim myPassword As String = SQLServerSettings("Password")
        Dim WebUsername As String = SQLServerSettings("WebUsername")
        Dim WebPassword As String = SQLServerSettings("WebPassword")

        Dim myDatabase As String = SQLServerSettings("Database")
        Dim myServerAddress As String = SQLServerSettings("ServerAddress")

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, "Master", mySA_Username, mySA_Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection


        Debug.WriteLine("Creating DB")

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            SQLCommand.Transaction = Transaction

            AppendToOutput(InfoMessage("Prerequisites.CreatedDatabase"))
            SQLCommand.CommandText = String.Format("CREATE DATABASE {0};", myDatabase)
            Debug.WriteLine(SQLCommand.CommandText) ' debug
            SQLCommand.ExecuteNonQuery()

            AppendToOutput(InfoMessage("Prerequisites.CreatedUser"))
            SQLCommand.CommandText = String.Format("EXEC sp_addlogin '{0}','{1}','{2}','Portuguese';", _
                                                    myUsername, myPassword, myDatabase)
            Debug.WriteLine(SQLCommand.CommandText)
            SQLCommand.ExecuteNonQuery()

            SQLCommand.CommandText = String.Format("EXEC sp_addlogin '{0}','{1}','{2}','Portuguese';", _
                                                    WebUsername, WebPassword, myDatabase)
            Debug.WriteLine(SQLCommand.CommandText)
            SQLCommand.ExecuteNonQuery()


            SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_grantdbaccess '{1}';", _
                            myDatabase, myUsername)
            Debug.WriteLine(SQLCommand.CommandText)
            SQLCommand.ExecuteNonQuery()


            SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_grantdbaccess '{1}';", _
                                   myDatabase, WebUsername)
            Debug.WriteLine(SQLCommand.CommandText)
            SQLCommand.ExecuteNonQuery()



            SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_addrolemember 'db_datareader','{1}';", _
                                                    myDatabase, WebUsername)
            Debug.WriteLine(SQLCommand.CommandText)
            SQLCommand.ExecuteNonQuery()


            SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_addrolemember 'db_owner','{1}';", _
                                                        myDatabase, myUsername)
            Debug.WriteLine(SQLCommand.CommandText)
            SQLCommand.ExecuteNonQuery()

            'AppendToOutput(InfoMessage("Prerequisites.ChangedOwnership"))
            'SQLCommand.CommandText = String.Format("USE {0}; EXEC sp_changedbowner '{1}';", myDatabase, myUsername)
            'Debug.WriteLine(SQLCommand.CommandText) ' debug
            'SQLCommand.ExecuteNonQuery()


            Success = True
        Catch ex As Exception
            Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)
            Success = False
        Finally
            SQLConnection.Close()
        End Try
        Thread.Sleep(5000)
        Return Success
    End Function


    Private Function CreateTables() As Boolean
        Dim Success As Boolean = False
        Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")

        Dim mySA_Username As String = SQLServerSettings("SA_Username")
        Dim mySA_Password As String = SQLServerSettings("SA_Password")
        Dim myUsername As String = SQLServerSettings("Username")
        Dim myPassword As String = SQLServerSettings("Password")
        Dim myDatabase As String = SQLServerSettings("Database")
        Dim myServerAddress As String = SQLServerSettings("ServerAddress")


        Debug.WriteLine("Creating Tables")
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, mySA_Username, mySA_Password)

        ' Dim Transaction As SqlTransaction

        Try
            SQLConnection.Open()

            Dim SQLCommand As New SqlCommand
            SQLCommand.Connection = SQLConnection

            'Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            'SQLCommand.Transaction = Transaction

            AppendToOutput(InfoMessage("Prerequisites.CreateTables"))
            SQLCommand.CommandText = ReadTextFile(DATABASE_SQL_FILENAME)
            SQLCommand.ExecuteNonQuery()


            'Transaction.Commit()
            Success = True
        Catch ex As Exception
            Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)
            AppendToOutput(ex.Message & ControlChars.NewLine & ex.StackTrace)
            'Transaction.Rollback()
            Success = False
        Finally
            SQLConnection.Close()
        End Try
        Return Success
    End Function

    Private Function TryToBuildDatabase() As Boolean
        If CreateDatabase() Then
            Return CreateTables()
        Else
            Return False
        End If
    End Function

    Private Sub TestExistenceOfDatabaseSQL()
        AppendToOutput(InfoMessage("Prerequisites.DatabaseSQL"))
        If File.Exists(DATABASE_SQL_FILENAME) Then
            AppendToOutput(InfoMessage("Prerequisites.Ok"))
        Else
            AppendToOutput(InfoMessage("Prerequisites.Failed"))
            myFailedTests += 1
        End If
        AppendToOutput(ControlChars.NewLine)
    End Sub


    Private Sub TestExistenceOfCnfXslt()
        AppendToOutput(InfoMessage("Prerequisites.ExistenceOfCnfXslt"))
        If File.Exists(EAD2CNF_XSLT_FILENAME) Then
            AppendToOutput(InfoMessage("Prerequisites.Ok"))
        Else
            AppendToOutput(InfoMessage("Prerequisites.Failed"))
            myFailedTests += 1
        End If
        AppendToOutput(ControlChars.NewLine)
    End Sub


    Private Sub TestExistenceOfEacXslt()
        AppendToOutput(InfoMessage("Prerequisites.ExistenceOfEacXslt"))
        If File.Exists(EAC_XSLT_Filename) Then
            AppendToOutput(InfoMessage("Prerequisites.Ok"))
        Else
            AppendToOutput(InfoMessage("Prerequisites.Failed"))
            myFailedTests += 1
        End If
        AppendToOutput(ControlChars.NewLine)
    End Sub


    Private Sub TestOperatingSystem()
        AppendToOutput(String.Format(InfoMessage("Prerequisites.OperatingSystem"), Environment.OSVersion.ToString))
        If Environment.OSVersion.Platform = PlatformID.Win32NT Then
            AppendToOutput(InfoMessage("Prerequisites.Ok"))
        Else
            AppendToOutput(InfoMessage("Prerequisites.Failed"))
            'myFailedTests += 1
        End If
        AppendToOutput(ControlChars.NewLine)
    End Sub

    Private Sub TestVersionOfAplication()

        AppendToOutput(InfoMessage("Prerequisites.VersionOfAplication"))

        Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")

        Dim myUsername As String = SQLServerSettings("Username")
        Dim myDatabase As String = SQLServerSettings("Database")
        Dim myServerAddress As String = SQLServerSettings("ServerAddress")
        Dim myPassword As String = SQLServerSettings("Password")

        Dim SQLConnection As SqlConnection = New SqlConnection


        Dim Transaction As SqlTransaction
        Try
            SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

            Dim SQLCommand As New SqlCommand
            SQLCommand.Connection = SQLConnection

            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT Version FROM Aplications WHERE AplicationName='DigitArq'"

            If CStr(SQLCommand.ExecuteScalar()) <> ConfigurationSettings.AppSettings("lblVersion.Text") Then
                AppendToOutput(InfoMessage("Prerequisites.Failed"))
                myFailedTests += 1
            Else
                AppendToOutput(InfoMessage("Prerequisites.Ok"))
            End If

        Catch ex As Exception
            Dim erro As String
            erro = ex.ToString
            erro = ex.ToString
        Finally
            SQLConnection.Close()
        End Try
        AppendToOutput(ControlChars.NewLine)
    End Sub

#End Region


End Class
