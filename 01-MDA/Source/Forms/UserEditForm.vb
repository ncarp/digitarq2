Public Class UserEditForm
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblPasswordConfirm As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPasswordConfirm As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UserEditForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblPasswordConfirm = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtPasswordConfirm = New System.Windows.Forms.TextBox
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.lblLastName = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnOk)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 151)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(298, 40)
        Me.Panel2.TabIndex = 7
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.White
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Enabled = False
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Location = New System.Drawing.Point(136, 8)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(216, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancelar"
        '
        'lblUsername
        '
        Me.lblUsername.Location = New System.Drawing.Point(16, 16)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(104, 20)
        Me.lblUsername.TabIndex = 26
        Me.lblUsername.Text = "Utilizador:"
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(16, 40)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(88, 20)
        Me.lblFirstName.TabIndex = 27
        Me.lblFirstName.Text = CType(configurationAppSettings.GetValue("lblFullName.Text", GetType(System.String)), String)
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(16, 96)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(88, 20)
        Me.lblPassword.TabIndex = 28
        Me.lblPassword.Text = "Palavra-chave:"
        '
        'lblPasswordConfirm
        '
        Me.lblPasswordConfirm.Location = New System.Drawing.Point(16, 120)
        Me.lblPasswordConfirm.Name = "lblPasswordConfirm"
        Me.lblPasswordConfirm.Size = New System.Drawing.Size(88, 20)
        Me.lblPasswordConfirm.TabIndex = 29
        Me.lblPasswordConfirm.Text = "Confirmação:"
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsername.Location = New System.Drawing.Point(120, 16)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(168, 20)
        Me.txtUsername.TabIndex = 1
        Me.txtUsername.Text = ""
        '
        'txtFirstName
        '
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.Location = New System.Drawing.Point(120, 40)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(168, 20)
        Me.txtFirstName.TabIndex = 2
        Me.txtFirstName.Text = ""
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(120, 96)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(168, 20)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.Text = ""
        '
        'txtPasswordConfirm
        '
        Me.txtPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordConfirm.Location = New System.Drawing.Point(120, 120)
        Me.txtPasswordConfirm.Name = "txtPasswordConfirm"
        Me.txtPasswordConfirm.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordConfirm.Size = New System.Drawing.Size(168, 20)
        Me.txtPasswordConfirm.TabIndex = 5
        Me.txtPasswordConfirm.Text = ""
        '
        'txtLastName
        '
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.Location = New System.Drawing.Point(120, 64)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(168, 20)
        Me.txtLastName.TabIndex = 3
        Me.txtLastName.Text = ""
        '
        'lblLastName
        '
        Me.lblLastName.Location = New System.Drawing.Point(16, 64)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(88, 20)
        Me.lblLastName.TabIndex = 31
        Me.lblLastName.Text = "Último nome:"
        '
        'UserEditForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(298, 191)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.txtPasswordConfirm)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPasswordConfirm)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Propriedades de utilizador..."
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Username As String, ByVal Password As String, ByVal FirstName As String, ByVal LastName As String)
        Me.New()
        Me.txtUsername.Text = Username
        Me.txtUsername.Enabled = False
        Me.txtPassword.Text = Password
        Me.txtPasswordConfirm.Text = Password
        Me.txtFirstName.Text = FirstName
        Me.txtLastName.Text = LastName
    End Sub


    Private Sub EnableOkButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged, txtPassword.TextChanged, txtPasswordConfirm.TextChanged, txtFirstName.TextChanged, txtLastName.TextChanged
        btnOk.Enabled = Username.Length > 0 And FirstName.Length > 0 And _
                        Password.Length > 0 And txtPasswordConfirm.Text.Equals(Password)
    End Sub


    Public ReadOnly Property Username() As String
        Get
            Return txtUsername.Text
        End Get
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return txtPassword.Text
        End Get
    End Property

    Public ReadOnly Property FirstName() As String
        Get
            Return txtFirstName.Text
        End Get
    End Property

    Public ReadOnly Property LastName() As String
        Get
            Return txtLastName.Text
        End Get
    End Property

End Class
