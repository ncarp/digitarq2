Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration
Imports System.IO



Public Class LoginForm
    Inherits System.Windows.Forms.Form

#Region "Private Properties"

    Private myProgramState As ProgramState

#End Region


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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents FondsIcon As System.Windows.Forms.ImageList
    Friend WithEvents btnCloseLoginForm As System.Windows.Forms.Button
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LoginForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnCloseLoginForm = New System.Windows.Forms.Button
        Me.btnLogin = New System.Windows.Forms.Button
        Me.FondsIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCloseLoginForm)
        Me.Panel2.Controls.Add(Me.btnLogin)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(322, 40)
        Me.Panel2.TabIndex = 6
        '
        'btnCloseLoginForm
        '
        Me.btnCloseLoginForm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseLoginForm.Location = New System.Drawing.Point(240, 8)
        Me.btnCloseLoginForm.Name = "btnCloseLoginForm"
        Me.btnCloseLoginForm.TabIndex = 4
        Me.btnCloseLoginForm.Text = CType(configurationAppSettings.GetValue("btnCloseLoginForm.Text", GetType(System.String)), String)
        '
        'btnLogin
        '
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnLogin.Enabled = False
        Me.btnLogin.Location = New System.Drawing.Point(160, 8)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = CType(configurationAppSettings.GetValue("btnLogin.Text", GetType(System.String)), String)
        '
        'FondsIcon
        '
        Me.FondsIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.FondsIcon.ImageSize = New System.Drawing.Size(16, 16)
        Me.FondsIcon.ImageStream = CType(resources.GetObject("FondsIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.FondsIcon.TransparentColor = System.Drawing.Color.White
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblPassword)
        Me.Panel1.Controls.Add(Me.lblUsername)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.txtUsername)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 87)
        Me.Panel1.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(96, 48)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(80, 16)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = CType(configurationAppSettings.GetValue("lblPassword.Text", GetType(System.String)), String)
        '
        'lblUsername
        '
        Me.lblUsername.Location = New System.Drawing.Point(96, 24)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(56, 16)
        Me.lblUsername.TabIndex = 2
        Me.lblUsername.Text = CType(configurationAppSettings.GetValue("lblUsername.Text", GetType(System.String)), String)
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(184, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(128, 20)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = ""
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsername.Location = New System.Drawing.Point(184, 24)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(128, 20)
        Me.txtUsername.TabIndex = 1
        Me.txtUsername.Text = ""
        '
        'LoginForm
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCloseLoginForm
        Me.ClientSize = New System.Drawing.Size(322, 127)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = CType(configurationAppSettings.GetValue("LoginForm.Text", GetType(System.String)), String)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myProgramState = New ProgramState
        txtUsername.Text = myProgramState.LastLoginUsername
    End Sub


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim Result As Boolean
        Try
            Result = Users.CheckLogin(SQLServerSettings.Item("ServerAddress"), _
                                                       SQLServerSettings.Item("Database"), _
                                                       SQLServerSettings.Item("Username"), _
                                                       SQLServerSettings.Item("Password"), _
                                                       txtUsername.Text, txtPassword.Text)
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try

        If Result Then
            Me.DialogResult = DialogResult.OK
            txtPassword.Text = ""
            Close()
        Else
            'lblErrorMessage.Text = ErrorMessage("Login.InvalidLogin")
            txtPassword.Text = ""
            txtUsername.Focus()
            txtUsername.SelectAll()
        End If

    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged, txtPassword.TextChanged
        btnLogin.Enabled = (txtUsername.Text.Length > 0) AndAlso (txtPassword.Text.Length > 0)
    End Sub

    Public ReadOnly Property Username()
        Get
            Return txtUsername.Text
        End Get
    End Property

    'Private Sub btnCloseLoginForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseLoginForm.Click
    '    Me.DialogResult = DialogResult.Cancel
    '    Close()
    'End Sub
End Class

