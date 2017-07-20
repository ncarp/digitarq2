
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

Imports GPU

Public Class FindDOForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intProjectID As Int64)
        MyBase.New()

        myProjectID = intProjectID
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
    Friend WithEvents lblTM2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cbbEmployees As System.Windows.Forms.ComboBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents CbbDates As System.Windows.Forms.ComboBox
    Friend WithEvents txtDate1 As MGOD.DateTextBox
    Friend WithEvents txtDate2 As MGOD.DateTextBox
    Friend WithEvents txtDOName As MGOD.ColorTextBox
    Friend WithEvents lblAlert As System.Windows.Forms.Label
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FindDOForm))
        Me.txtDate1 = New MGOD.DateTextBox
        Me.lblTM2 = New System.Windows.Forms.Label
        Me.txtDate2 = New MGOD.DateTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbbEmployees = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDOName = New MGOD.ColorTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblAlert = New System.Windows.Forms.Label
        Me.btnFind = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CbbDates = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDate1
        '
        Me.txtDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate1.Location = New System.Drawing.Point(184, 14)
        Me.txtDate1.Mask = "####-##-##"
        Me.txtDate1.MaxLength = 10
        Me.txtDate1.Name = "txtDate1"
        Me.txtDate1.Size = New System.Drawing.Size(64, 20)
        Me.txtDate1.TabIndex = 128
        Me.txtDate1.Text = ""
        '
        'lblTM2
        '
        Me.lblTM2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM2.Location = New System.Drawing.Point(96, 14)
        Me.lblTM2.Name = "lblTM2"
        Me.lblTM2.Size = New System.Drawing.Size(88, 20)
        Me.lblTM2.TabIndex = 129
        Me.lblTM2.Text = "Data de criação"
        Me.lblTM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDate2
        '
        Me.txtDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate2.Location = New System.Drawing.Point(272, 14)
        Me.txtDate2.Mask = "####-##-##"
        Me.txtDate2.MaxLength = 10
        Me.txtDate2.Name = "txtDate2"
        Me.txtDate2.Size = New System.Drawing.Size(64, 20)
        Me.txtDate2.TabIndex = 130
        Me.txtDate2.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(256, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 20)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "a"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Funcionário"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbbEmployees
        '
        Me.cbbEmployees.Location = New System.Drawing.Point(184, 44)
        Me.cbbEmployees.Name = "cbbEmployees"
        Me.cbbEmployees.Size = New System.Drawing.Size(248, 21)
        Me.cbbEmployees.TabIndex = 133
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Nome OD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDOName
        '
        Me.txtDOName.BackColor = System.Drawing.Color.White
        Me.txtDOName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDOName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOName.Location = New System.Drawing.Point(184, 75)
        Me.txtDOName.Name = "txtDOName"
        Me.txtDOName.Size = New System.Drawing.Size(248, 20)
        Me.txtDOName.TabIndex = 135
        Me.txtDOName.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.GroupBox1.Controls.Add(Me.lblAlert)
        Me.GroupBox1.Controls.Add(Me.btnFind)
        Me.GroupBox1.Location = New System.Drawing.Point(-40, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 112)
        Me.GroupBox1.TabIndex = 136
        Me.GroupBox1.TabStop = False
        '
        'lblAlert
        '
        Me.lblAlert.ForeColor = System.Drawing.Color.Red
        Me.lblAlert.Location = New System.Drawing.Point(136, 15)
        Me.lblAlert.Name = "lblAlert"
        Me.lblAlert.Size = New System.Drawing.Size(216, 24)
        Me.lblAlert.TabIndex = 24
        Me.lblAlert.Text = "Nenhum registo encontrado."
        Me.lblAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.White
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.ImageIndex = 7
        Me.btnFind.ImageList = Me.imglButtons
        Me.btnFind.Location = New System.Drawing.Point(384, 15)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(88, 25)
        Me.btnFind.TabIndex = 23
        Me.btnFind.Text = "Pesquisar"
        Me.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 137
        Me.PictureBox1.TabStop = False
        '
        'CbbDates
        '
        Me.CbbDates.Location = New System.Drawing.Point(352, 14)
        Me.CbbDates.Name = "CbbDates"
        Me.CbbDates.Size = New System.Drawing.Size(80, 21)
        Me.CbbDates.TabIndex = 138
        '
        'FindDOForm
        '
        Me.AcceptButton = Me.btnFind
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(448, 151)
        Me.Controls.Add(Me.CbbDates)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDOName)
        Me.Controls.Add(Me.txtDate2)
        Me.Controls.Add(Me.txtDate1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbbEmployees)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTM2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FindDOForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisar objectos digitais"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private database1 As New SQLDataBase
    Private database2 As New SqlCommands
    Private myProjectID As Int64

    Private Sub FindDOForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillEmployees()
        FillCbbdates()
        Me.lblAlert.Visible = False
    End Sub

    Private Sub FillCbbdates()
        Dim li As New ComboBox.ObjectCollection(Me.CbbDates)

        Me.CbbDates.Items.Add("A partir de ?")
        Me.CbbDates.Items.Add("Até ?")
        Me.CbbDates.Items.Add("Entre ? e ?")
        Me.CbbDates.Items.Add("Exacta")
        Me.CbbDates.SelectedIndex = 0
    End Sub

    Private Sub FillEmployees()
        Dim ds As DataSet = database1.loadFullEmployees
        Dim myData As DataTable = ds.Tables(0)
        Me.cbbEmployees.DataSource = myData
        Me.cbbEmployees.ValueMember = "UserName"
        Me.cbbEmployees.DisplayMember = "UserName"
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim strCommand As String
        Dim ds As DataSet
        Select Case Me.CbbDates.SelectedIndex
            Case 0
                strCommand = String.Format("SELECT * FROM DigitalObjects " & _
                                "WHERE CreationDateTime >= '{0}' " & _
                                "AND UserName LIKE '%{1}%' " & _
                                "AND Name LIKE '%{2}%' " & _
                                "AND ProjectID = {3}" & _
                                "ORDER BY DigitalObjectID DESC", _
                                Me.txtDate1.Text, Me.cbbEmployees.SelectedValue, Me.txtDOName.Text, myProjectID)
            Case 1
                strCommand = String.Format("SELECT * FROM DigitalObjects " & _
                                "WHERE CreationDateTime <= '{0}' " & _
                                "AND UserName LIKE '%{1}%' " & _
                                "AND Name LIKE '%{2}%' " & _
                                "AND ProjectID = {3}" & _
                                "ORDER BY DigitalObjectID DESC", _
                                Me.txtDate2.Text, Me.cbbEmployees.SelectedValue, Me.txtDOName.Text, myProjectID)
            Case 2
                strCommand = String.Format("SELECT * FROM DigitalObjects " & _
                                "WHERE CreationDateTime >= '{0}' AND CreationDateTime <= '{1}'" & _
                                "AND UserName LIKE '%{1}%' " & _
                                "AND Name LIKE '%{3}%' " & _
                                "AND ProjectID = {4}" & _
                                "ORDER BY DigitalObjectID DESC", _
                                Me.txtDate1.Text, Me.txtDate2.Text, Me.cbbEmployees.SelectedValue, Me.txtDOName.Text, myProjectID)
            Case 3
                strCommand = String.Format("SELECT * FROM DigitalObjects " & _
                                "WHERE CreationDateTime LIKE '%{0}%' " & _
                                "AND UserName LIKE '%{1}%' " & _
                                "AND Name LIKE '%{2}%' " & _
                                "AND ProjectID = {3}" & _
                                "ORDER BY DigitalObjectID DESC", _
                                Me.txtDate1.Text, Me.cbbEmployees.SelectedValue, Me.txtDOName.Text, myProjectID)
        End Select
        ds = database2.SelectByCommand(strCommand)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim DOForm As DigitalObjectsForm = Me.Owner
            DOForm.LoadData(0, ds)
            Me.lblAlert.Visible = False
            Me.Close()
        Else
            Me.lblAlert.Visible = True
        End If
    End Sub

    Private Sub CbbDates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbbDates.SelectedIndexChanged
        Select Case Me.CbbDates.SelectedIndex
            Case 0
                Me.txtDate1.Enabled = True
                Me.txtDate2.Enabled = False
            Case 1
                Me.txtDate1.Enabled = False
                Me.txtDate2.Enabled = True
            Case 2
                Me.txtDate1.Enabled = True
                Me.txtDate2.Enabled = True
            Case 3
                Me.txtDate1.Enabled = True
                Me.txtDate2.Enabled = False
        End Select
    End Sub

End Class
