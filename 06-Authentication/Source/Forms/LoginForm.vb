
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articulação com a Direcção-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordenação
'* informática da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Português.
'* ---------------------------------------------------
'*
'* A redistribuição e utilização deste produto sob a
'* forma de código-fonte ou programa compilado, com ou
'* sem modificações, é permitida desde que o seguinte
'* conjunto de condições seja cumprido:
'* 
'*	* Todas as redistribuições do código-fonte 
'*	  deste produto deverão ser acompanhadas do
'*	  texto que compõe esta licença, incluindo o 
'*	  texto inicial de atribuição de autoria,
'*	  esta lista de condições e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direcção-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto não deverão ser utilizados na 
'*	  promoção de produtos derivados deste 
'*	  sem que seja obtido consentimento prévio, por
'*	  escrito, por parte dos visados.

'*	* A utilização da designação DigitArq, seus 
'*	  logótipos e nomes institucionais associados
'*	  é apenas permitida em distribuições que sejam
'*	  cópias exactas da versão oficial deste produto
'*	  aprovada e/ou distribuída pela Direcção-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto é permitido desde que a designação 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais não sejam utilizados em todo e
'*	  qualquer tipo de distribuição e/ou promoção 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE É DISTRIBUIDO PELA DIRECÇÃO-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUNÇÃO DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS NÃO LIMITADO A, GARANTIAS ASSOCIADAS
'* A COMÉRCIO DE PRODUTOS OU DECLARAÇÃO DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNSTÂNCIA PODERÁ A DIRECÇÃO-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONSÁVEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZAÇÃO DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS NÃO LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FALÊNCIA, INDEVIDA PRESTAÇÃO DE SERVIÇOS
'* OU NEGLIGÊNCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORRÊNCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informação sobre este produto ou a sua 
'* licença, é favor consultar o endereço electrónico
'* http://www.digitarq.pt

#End Region

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports GPU.SQLDataBase

Public Class LoginForm
    Inherits System.Windows.Forms.Form

#Region "Private Properties"

    Private myProgramState As ProgramState
    Private myAplicationCode As String
    Private objI As New GPU.SQLDataBase

#End Region


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal AplicationCode As String)
        MyBase.New()
        InitializeComponent()
        myAplicationCode = AplicationCode
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
    Friend WithEvents lblAlert As System.Windows.Forms.Label
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
        Me.lblAlert = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCloseLoginForm)
        Me.Panel2.Controls.Add(Me.btnLogin)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 96)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(322, 40)
        Me.Panel2.TabIndex = 6
        '
        'btnCloseLoginForm
        '
        Me.btnCloseLoginForm.BackColor = System.Drawing.Color.White
        Me.btnCloseLoginForm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseLoginForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseLoginForm.Location = New System.Drawing.Point(240, 8)
        Me.btnCloseLoginForm.Name = "btnCloseLoginForm"
        Me.btnCloseLoginForm.TabIndex = 4
        Me.btnCloseLoginForm.Text = CType(configurationAppSettings.GetValue("btnCloseLoginForm.Text", GetType(System.String)), String)
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.White
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnLogin.Enabled = False
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
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
        Me.Panel1.Controls.Add(Me.lblAlert)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblPassword)
        Me.Panel1.Controls.Add(Me.lblUsername)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.txtUsername)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 96)
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
        Me.lblPassword.Size = New System.Drawing.Size(80, 20)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = CType(configurationAppSettings.GetValue("lblPassword.Text", GetType(System.String)), String)
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsername
        '
        Me.lblUsername.Location = New System.Drawing.Point(96, 24)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(80, 20)
        Me.lblUsername.TabIndex = 2
        Me.lblUsername.Text = CType(configurationAppSettings.GetValue("lblUsername.Text", GetType(System.String)), String)
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'lblAlert
        '
        Me.lblAlert.ForeColor = System.Drawing.Color.Red
        Me.lblAlert.Location = New System.Drawing.Point(96, 72)
        Me.lblAlert.Name = "lblAlert"
        Me.lblAlert.Size = New System.Drawing.Size(216, 20)
        Me.lblAlert.TabIndex = 6
        Me.lblAlert.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LoginForm
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCloseLoginForm
        Me.ClientSize = New System.Drawing.Size(322, 136)
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
        myProgramState = New ProgramState(myAplicationCode)
        txtUsername.Text = myProgramState.LastLoginUsername
        Select Case myAplicationCode
            Case "MDA"
                Me.Icon = New Icon(Me.GetType(), "mda.ico")
            Case "MGOD"
                Me.Icon = New Icon(Me.GetType(), "mgod.ico")
            Case "MPOD"
                Me.Icon = New Icon(Me.GetType(), "mpod.ico")
        End Select
    End Sub


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim eReturn As GPU.SQLInterface.eReturn
        Try
            eReturn = objI.validateEmployee(myAplicationCode, Username, Password)

            Select Case eReturn
                Case eReturn.Sucess
                    Me.DialogResult = DialogResult.OK
                    myProgramState.LastLoginUsername = txtUsername.Text
                    myProgramState.Save()
                    Close()
                Case eReturn.ErrorUsernamePass
                    txtPassword.Text = ""
                    txtUsername.Focus()
                    txtUsername.SelectAll()
                    Me.lblAlert.Text = InfoMessage("Login.ErrorUsernamePass")
                Case eReturn.ErrorNotProfile
                    txtPassword.Text = ""
                    txtUsername.Focus()
                    txtUsername.SelectAll()
                    Me.lblAlert.Text = InfoMessage("Login.ErrorNotProfile")
                Case eReturn.ErrorNotActive
                    txtPassword.Text = ""
                    txtUsername.Focus()
                    txtUsername.SelectAll()
                    Me.lblAlert.Text = InfoMessage("Login.ErrorNotActive")
                Case eReturn.AplicationAccessDenied
                    txtPassword.Text = ""
                    txtUsername.Focus()
                    txtUsername.SelectAll()
                    Me.lblAlert.Text = InfoMessage("Login.ErrorAplicationAccessDenied")
                Case Else
                    txtPassword.Text = ""
                    txtUsername.Focus()
                    txtUsername.SelectAll()
            End Select
        Catch ex As Exception
            Me.lblAlert.Text = InfoMessage("Login.Error")
            'Close()
        End Try
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged, txtPassword.TextChanged
        btnLogin.Enabled = (txtUsername.Text.Length > 0) AndAlso (txtPassword.Text.Length > 0)
    End Sub

    Public ReadOnly Property Username()
        Get
            Return txtUsername.Text
        End Get
    End Property

    Public ReadOnly Property Password()
        Get
            Return txtPassword.Text
        End Get
    End Property

End Class

