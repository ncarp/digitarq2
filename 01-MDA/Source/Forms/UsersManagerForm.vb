Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration
Imports System.IO



Public Class UsersManagerForm
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
    Friend WithEvents FondsIcon As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnProperties As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ColumnHeaderUsername As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ListViewUsers As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderPassword As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderFirstName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderLastName As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UsersManagerForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnProperties = New System.Windows.Forms.Button
        Me.FondsIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListViewUsers = New System.Windows.Forms.ListView
        Me.ColumnHeaderUsername = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderFirstName = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderLastName = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderPassword = New System.Windows.Forms.ColumnHeader
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.btnProperties)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 191)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(418, 40)
        Me.Panel2.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(336, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = CType(configurationAppSettings.GetValue("UserManager.btnClose.Text", GetType(System.String)), String)
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.White
        Me.btnRemove.Enabled = False
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Location = New System.Drawing.Point(96, 8)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(80, 23)
        Me.btnRemove.TabIndex = 31
        Me.btnRemove.Text = CType(configurationAppSettings.GetValue("btnRemove.Text", GetType(System.String)), String)
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(8, 8)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 23)
        Me.btnAdd.TabIndex = 32
        Me.btnAdd.Text = CType(configurationAppSettings.GetValue("btnAdd.Text", GetType(System.String)), String)
        '
        'btnProperties
        '
        Me.btnProperties.BackColor = System.Drawing.Color.White
        Me.btnProperties.Enabled = False
        Me.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProperties.Location = New System.Drawing.Point(184, 8)
        Me.btnProperties.Name = "btnProperties"
        Me.btnProperties.Size = New System.Drawing.Size(80, 23)
        Me.btnProperties.TabIndex = 30
        Me.btnProperties.Text = CType(configurationAppSettings.GetValue("btnProperties.Text", GetType(System.String)), String)
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
        Me.Panel1.Controls.Add(Me.ListViewUsers)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(418, 191)
        Me.Panel1.TabIndex = 5
        '
        'ListViewUsers
        '
        Me.ListViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderUsername, Me.ColumnHeaderFirstName, Me.ColumnHeaderLastName, Me.ColumnHeaderPassword})
        Me.ListViewUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewUsers.FullRowSelect = True
        Me.ListViewUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewUsers.Location = New System.Drawing.Point(0, 0)
        Me.ListViewUsers.MultiSelect = False
        Me.ListViewUsers.Name = "ListViewUsers"
        Me.ListViewUsers.Size = New System.Drawing.Size(418, 191)
        Me.ListViewUsers.TabIndex = 26
        Me.ListViewUsers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderUsername
        '
        Me.ColumnHeaderUsername.Text = CType(configurationAppSettings.GetValue("ColumnHeaderUsername.Text", GetType(System.String)), String)
        Me.ColumnHeaderUsername.Width = 104
        '
        'ColumnHeaderFirstName
        '
        Me.ColumnHeaderFirstName.Text = CType(configurationAppSettings.GetValue("ColumnHeaderFullName.Text", GetType(System.String)), String)
        Me.ColumnHeaderFirstName.Width = 130
        '
        'ColumnHeaderLastName
        '
        Me.ColumnHeaderLastName.Text = "Último nome"
        Me.ColumnHeaderLastName.Width = 159
        '
        'ColumnHeaderPassword
        '
        Me.ColumnHeaderPassword.Text = CType(configurationAppSettings.GetValue("ColumnHeaderPassword.Text", GetType(System.String)), String)
        Me.ColumnHeaderPassword.Width = 0
        '
        'UsersManagerForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(418, 231)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 1024)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "UsersManagerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = CType(configurationAppSettings.GetValue("UsersManagerForm.Text", GetType(System.String)), String)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub LoadUsersList()
        Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Try
            Dim UsersList As UserCollection = Users.GetUsersList(SQLServerSettings.Item("ServerAddress"), _
                                                                 SQLServerSettings.Item("Database"), _
                                                                 SQLServerSettings.Item("Username"), _
                                                                 SQLServerSettings.Item("Password"))

            ListViewUsers.Items.Clear()
            Dim Item As UserItem
            For Each Item In UsersList
                Dim Username As New ListViewItem(Item.Username)
                Dim FirstName As New ListViewItem.ListViewSubItem(Username, Item.FirstName)
                Dim LastName As New ListViewItem.ListViewSubItem(Username, Item.LastName)
                Dim Password As New ListViewItem.ListViewSubItem(Username, Item.Password)
                Username.SubItems.Add(FirstName)
                Username.SubItems.Add(LastName)
                Username.SubItems.Add(Password)
                ListViewUsers.Items.Add(Username)
            Next

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try

    End Sub


    Private Sub UsersManagerForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadUsersList()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frmUserEdit As New UserEditForm
        If frmUserEdit.ShowDialog = DialogResult.OK Then
            Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
            Try
                Users.CreateNewUser(SQLServerSettings.Item("ServerAddress"), _
                                    SQLServerSettings.Item("Database"), _
                                    SQLServerSettings.Item("Username"), _
                                    SQLServerSettings.Item("Password"), _
                                    frmUserEdit.Username, _
                                    frmUserEdit.Password, _
                                    frmUserEdit.FirstName, _
                                    frmUserEdit.LastName)
                Me.LoadUsersList()

            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            End Try
        End If
    End Sub


    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If ListViewUsers.SelectedItems.Count <> 1 Then Exit Sub
        Dim Username As String = ListViewUsers.SelectedItems(0).SubItems(0).Text
        If Username.Equals("admin") Then
            MsgBox(InfoMessage("RemoveUser.CannotRemoveAdministrator"), MsgBoxStyle.Information Or MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If MsgBox(InfoMessage("RemoveUser.Confirm"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
            Try
                Users.RemoveUser(SQLServerSettings.Item("ServerAddress"), _
                                          SQLServerSettings.Item("Database"), _
                                          SQLServerSettings.Item("Username"), _
                                          SQLServerSettings.Item("Password"), _
                                          Username)
                Me.LoadUsersList()
            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)

            End Try

        End If
    End Sub

    Private Sub btnProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProperties.Click
        If ListViewUsers.SelectedItems.Count <> 1 Then Exit Sub
        Dim Username As String = ListViewUsers.SelectedItems(0).SubItems(0).Text
        Dim FirstName As String = ListViewUsers.SelectedItems(0).SubItems(1).Text
        Dim LastName As String = ListViewUsers.SelectedItems(0).SubItems(2).Text
        Dim Password As String = ListViewUsers.SelectedItems(0).SubItems(3).Text

        Dim frmUserEdit As New UserEditForm(Username, Password, FirstName, LastName)
        If frmUserEdit.ShowDialog = DialogResult.OK Then
            Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
            Try
                Users.UpdateUser(SQLServerSettings.Item("ServerAddress"), _
                                    SQLServerSettings.Item("Database"), _
                                    SQLServerSettings.Item("Username"), _
                                    SQLServerSettings.Item("Password"), _
                                    frmUserEdit.Username, _
                                    frmUserEdit.Password, _
                                    frmUserEdit.FirstName, _
                                    frmUserEdit.LastName)
                Me.LoadUsersList()

            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)


            End Try

        End If
    End Sub


    Private Sub ListViewItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewUsers.SelectedIndexChanged
        Me.btnProperties.Enabled = ListViewUsers.SelectedItems.Count = 1
        Me.btnRemove.Enabled = ListViewUsers.SelectedItems.Count = 1
    End Sub

    Private Sub ListViewUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewUsers.DoubleClick
        btnProperties_Click(Me, e)
    End Sub
End Class

