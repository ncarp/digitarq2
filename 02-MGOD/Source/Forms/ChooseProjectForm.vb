
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

Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ChooseProjectForm
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
    Friend WithEvents fileChooser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuRelatorios As System.Windows.Forms.MenuItem
    Friend WithEvents miReportDigProjects As System.Windows.Forms.MenuItem
    Friend WithEvents lblLastUpdateDateTime As System.Windows.Forms.Label
    Friend WithEvents lblCreationDateTime As System.Windows.Forms.Label
    Friend WithEvents lblEmployee As System.Windows.Forms.Label
    Friend WithEvents txtName As MGOD.ColorTextBox
    Friend WithEvents txtDescription As MGOD.ColorTextBox
    Friend WithEvents btnLocalization As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents gbxProjects As System.Windows.Forms.GroupBox
    Friend WithEvents lvwProjects As System.Windows.Forms.ListView
    Friend WithEvents txtLocation As MGOD.ColorTextBox
    Friend WithEvents ttpGeneral As System.Windows.Forms.ToolTip
    Friend WithEvents imglProjects As System.Windows.Forms.ImageList
    Friend WithEvents gbxInfo As MGOD.ColorGroupBox
    Friend WithEvents lblEmployee_ As System.Windows.Forms.Label
    Friend WithEvents lblName_ As System.Windows.Forms.Label
    Friend WithEvents lblLocation_ As System.Windows.Forms.Label
    Friend WithEvents lblDescription_ As System.Windows.Forms.Label
    Friend WithEvents lblCreationDateTime_ As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdateDateTime_ As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDeleteProject As System.Windows.Forms.Button
    Friend WithEvents btnViewDO As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents miDOOperators As System.Windows.Forms.MenuItem
    Friend WithEvents bttnFind As mkccontrols.windows.forms.control.mkc_Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChooseProjectForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.gbxInfo = New MGOD.ColorGroupBox
        Me.txtLocation = New MGOD.ColorTextBox
        Me.lblLastUpdateDateTime = New System.Windows.Forms.Label
        Me.lblCreationDateTime = New System.Windows.Forms.Label
        Me.lblEmployee = New System.Windows.Forms.Label
        Me.lblDescription_ = New System.Windows.Forms.Label
        Me.lblEmployee_ = New System.Windows.Forms.Label
        Me.txtName = New MGOD.ColorTextBox
        Me.lblName_ = New System.Windows.Forms.Label
        Me.lblLocation_ = New System.Windows.Forms.Label
        Me.lblCreationDateTime_ = New System.Windows.Forms.Label
        Me.lblLastUpdateDateTime_ = New System.Windows.Forms.Label
        Me.txtDescription = New MGOD.ColorTextBox
        Me.btnLocalization = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.fileChooser = New System.Windows.Forms.FolderBrowserDialog
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuRelatorios = New System.Windows.Forms.MenuItem
        Me.miReportDigProjects = New System.Windows.Forms.MenuItem
        Me.miDOOperators = New System.Windows.Forms.MenuItem
        Me.gbxProjects = New System.Windows.Forms.GroupBox
        Me.lblWarning = New System.Windows.Forms.Label
        Me.lvwProjects = New System.Windows.Forms.ListView
        Me.imglProjects = New System.Windows.Forms.ImageList(Me.components)
        Me.ttpGeneral = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnDeleteProject = New System.Windows.Forms.Button
        Me.btnViewDO = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.bttnFind = New mkccontrols.windows.forms.control.mkc_Button
        Me.gbxInfo.SuspendLayout()
        Me.gbxProjects.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxInfo
        '
        Me.gbxInfo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxInfo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxInfo.Controls.Add(Me.txtLocation)
        Me.gbxInfo.Controls.Add(Me.lblLastUpdateDateTime)
        Me.gbxInfo.Controls.Add(Me.lblCreationDateTime)
        Me.gbxInfo.Controls.Add(Me.lblEmployee)
        Me.gbxInfo.Controls.Add(Me.lblDescription_)
        Me.gbxInfo.Controls.Add(Me.lblEmployee_)
        Me.gbxInfo.Controls.Add(Me.txtName)
        Me.gbxInfo.Controls.Add(Me.lblName_)
        Me.gbxInfo.Controls.Add(Me.lblLocation_)
        Me.gbxInfo.Controls.Add(Me.lblCreationDateTime_)
        Me.gbxInfo.Controls.Add(Me.lblLastUpdateDateTime_)
        Me.gbxInfo.Controls.Add(Me.txtDescription)
        Me.gbxInfo.Controls.Add(Me.btnLocalization)
        Me.gbxInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxInfo.ForeColor = System.Drawing.Color.Black
        Me.gbxInfo.Location = New System.Drawing.Point(8, 6)
        Me.gbxInfo.Name = "gbxInfo"
        Me.gbxInfo.Size = New System.Drawing.Size(552, 256)
        Me.gbxInfo.TabIndex = 13
        Me.gbxInfo.TabStop = False
        Me.gbxInfo.Text = "Informação Geral"
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.White
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(128, 64)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(351, 20)
        Me.txtLocation.TabIndex = 79
        Me.txtLocation.Text = ""
        '
        'lblLastUpdateDateTime
        '
        Me.lblLastUpdateDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastUpdateDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUpdateDateTime.Location = New System.Drawing.Point(421, 128)
        Me.lblLastUpdateDateTime.Name = "lblLastUpdateDateTime"
        Me.lblLastUpdateDateTime.Size = New System.Drawing.Size(90, 20)
        Me.lblLastUpdateDateTime.TabIndex = 8
        Me.lblLastUpdateDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreationDateTime
        '
        Me.lblCreationDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreationDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreationDateTime.Location = New System.Drawing.Point(128, 128)
        Me.lblCreationDateTime.Name = "lblCreationDateTime"
        Me.lblCreationDateTime.Size = New System.Drawing.Size(90, 20)
        Me.lblCreationDateTime.TabIndex = 7
        Me.lblCreationDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployee
        '
        Me.lblEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployee.Location = New System.Drawing.Point(128, 96)
        Me.lblEmployee.Name = "lblEmployee"
        Me.lblEmployee.Size = New System.Drawing.Size(383, 20)
        Me.lblEmployee.TabIndex = 6
        Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription_
        '
        Me.lblDescription_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription_.Location = New System.Drawing.Point(40, 160)
        Me.lblDescription_.Name = "lblDescription_"
        Me.lblDescription_.Size = New System.Drawing.Size(83, 19)
        Me.lblDescription_.TabIndex = 65
        Me.lblDescription_.Text = "Descrição"
        Me.lblDescription_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployee_
        '
        Me.lblEmployee_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployee_.Location = New System.Drawing.Point(40, 96)
        Me.lblEmployee_.Name = "lblEmployee_"
        Me.lblEmployee_.Size = New System.Drawing.Size(83, 19)
        Me.lblEmployee_.TabIndex = 63
        Me.lblEmployee_.Text = "Responsável"
        Me.lblEmployee_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(128, 32)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(383, 20)
        Me.txtName.TabIndex = 5
        Me.txtName.Text = ""
        Me.ttpGeneral.SetToolTip(Me.txtName, "E.g. DGARQ2008P-SGU")
        '
        'lblName_
        '
        Me.lblName_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName_.ForeColor = System.Drawing.Color.Red
        Me.lblName_.Location = New System.Drawing.Point(40, 32)
        Me.lblName_.Name = "lblName_"
        Me.lblName_.Size = New System.Drawing.Size(83, 19)
        Me.lblName_.TabIndex = 2
        Me.lblName_.Text = "Designação"
        Me.lblName_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLocation_
        '
        Me.lblLocation_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation_.ForeColor = System.Drawing.Color.Red
        Me.lblLocation_.Location = New System.Drawing.Point(40, 64)
        Me.lblLocation_.Name = "lblLocation_"
        Me.lblLocation_.Size = New System.Drawing.Size(83, 19)
        Me.lblLocation_.TabIndex = 3
        Me.lblLocation_.Text = "Localização"
        Me.lblLocation_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreationDateTime_
        '
        Me.lblCreationDateTime_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreationDateTime_.Location = New System.Drawing.Point(40, 128)
        Me.lblCreationDateTime_.Name = "lblCreationDateTime_"
        Me.lblCreationDateTime_.Size = New System.Drawing.Size(83, 19)
        Me.lblCreationDateTime_.TabIndex = 4
        Me.lblCreationDateTime_.Text = "Data criação"
        Me.lblCreationDateTime_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastUpdateDateTime_
        '
        Me.lblLastUpdateDateTime_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUpdateDateTime_.Location = New System.Drawing.Point(328, 128)
        Me.lblLastUpdateDateTime_.Name = "lblLastUpdateDateTime_"
        Me.lblLastUpdateDateTime_.Size = New System.Drawing.Size(96, 16)
        Me.lblLastUpdateDateTime_.TabIndex = 5
        Me.lblLastUpdateDateTime_.Text = "Última alteração"
        Me.lblLastUpdateDateTime_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(128, 160)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(383, 48)
        Me.txtDescription.TabIndex = 7
        Me.txtDescription.Text = ""
        '
        'btnLocalization
        '
        Me.btnLocalization.BackColor = System.Drawing.Color.White
        Me.btnLocalization.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLocalization.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocalization.Location = New System.Drawing.Point(488, 64)
        Me.btnLocalization.Name = "btnLocalization"
        Me.btnLocalization.Size = New System.Drawing.Size(24, 20)
        Me.btnLocalization.TabIndex = 5
        Me.btnLocalization.Text = "..."
        Me.ttpGeneral.SetToolTip(Me.btnLocalization, "Localizar")
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'fileChooser
        '
        Me.fileChooser.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuRelatorios})
        '
        'MenuRelatorios
        '
        Me.MenuRelatorios.Index = 0
        Me.MenuRelatorios.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miReportDigProjects, Me.miDOOperators})
        Me.MenuRelatorios.Text = "&Relatórios"
        '
        'miReportDigProjects
        '
        Me.miReportDigProjects.Index = 0
        Me.miReportDigProjects.Text = "Projectos de digitalização"
        '
        'miDOOperators
        '
        Me.miDOOperators.Index = 1
        Me.miDOOperators.Text = "Objectos digitais por operador"
        '
        'gbxProjects
        '
        Me.gbxProjects.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxProjects.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxProjects.Controls.Add(Me.lblWarning)
        Me.gbxProjects.Controls.Add(Me.lvwProjects)
        Me.gbxProjects.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxProjects.Location = New System.Drawing.Point(8, 6)
        Me.gbxProjects.Name = "gbxProjects"
        Me.gbxProjects.Size = New System.Drawing.Size(552, 256)
        Me.gbxProjects.TabIndex = 1
        Me.gbxProjects.TabStop = False
        Me.gbxProjects.Text = "Projectos"
        '
        'lblWarning
        '
        Me.lblWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.Image = CType(resources.GetObject("lblWarning.Image"), System.Drawing.Image)
        Me.lblWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarning.Location = New System.Drawing.Point(16, 228)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(317, 20)
        Me.lblWarning.TabIndex = 107
        Me.lblWarning.Text = "Projectos com objectos digitais que precisam de revisão."
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWarning.Visible = False
        '
        'lvwProjects
        '
        Me.lvwProjects.BackColor = System.Drawing.Color.White
        Me.lvwProjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwProjects.HideSelection = False
        Me.lvwProjects.Location = New System.Drawing.Point(16, 24)
        Me.lvwProjects.MultiSelect = False
        Me.lvwProjects.Name = "lvwProjects"
        Me.lvwProjects.Size = New System.Drawing.Size(520, 200)
        Me.lvwProjects.SmallImageList = Me.imglProjects
        Me.lvwProjects.StateImageList = Me.imglProjects
        Me.lvwProjects.TabIndex = 106
        '
        'imglProjects
        '
        Me.imglProjects.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglProjects.ImageStream = CType(resources.GetObject("imglProjects.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglProjects.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.BackColor = System.Drawing.Color.White
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.ImageIndex = 0
        Me.btnNew.ImageList = Me.imglButtons
        Me.btnNew.Location = New System.Drawing.Point(16, 14)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 25)
        Me.btnNew.TabIndex = 79
        Me.btnNew.Text = CType(configurationAppSettings.GetValue("btnNewProject.Text", GetType(System.String)), String)
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttpGeneral.SetToolTip(Me.btnNew, "Novo projecto")
        '
        'btnDeleteProject
        '
        Me.btnDeleteProject.BackColor = System.Drawing.Color.White
        Me.btnDeleteProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteProject.ImageIndex = 1
        Me.btnDeleteProject.ImageList = Me.imglButtons
        Me.btnDeleteProject.Location = New System.Drawing.Point(87, 14)
        Me.btnDeleteProject.Name = "btnDeleteProject"
        Me.btnDeleteProject.Size = New System.Drawing.Size(80, 25)
        Me.btnDeleteProject.TabIndex = 83
        Me.btnDeleteProject.Text = CType(configurationAppSettings.GetValue("btnDeleteProject.Text", GetType(System.String)), String)
        Me.btnDeleteProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttpGeneral.SetToolTip(Me.btnDeleteProject, "Eliminar projecto")
        '
        'btnViewDO
        '
        Me.btnViewDO.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(255, Byte), CType(230, Byte))
        Me.btnViewDO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewDO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewDO.ImageIndex = 6
        Me.btnViewDO.ImageList = Me.imglButtons
        Me.btnViewDO.Location = New System.Drawing.Point(305, 14)
        Me.btnViewDO.Name = "btnViewDO"
        Me.btnViewDO.Size = New System.Drawing.Size(64, 25)
        Me.btnViewDO.TabIndex = 80
        Me.btnViewDO.Text = CType(configurationAppSettings.GetValue("btnViewDO.Text", GetType(System.String)), String)
        Me.btnViewDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttpGeneral.SetToolTip(Me.btnViewDO, "Ver Objectos Digitais")
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.Black
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 3
        Me.btnEdit.ImageList = Me.imglButtons
        Me.btnEdit.Location = New System.Drawing.Point(375, 14)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 25)
        Me.btnEdit.TabIndex = 81
        Me.btnEdit.Text = CType(configurationAppSettings.GetValue("btnEdit.Text", GetType(System.String)), String)
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttpGeneral.SetToolTip(Me.btnEdit, "Editar")
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Enabled = False
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.ImageList = Me.imglButtons
        Me.btnCancel.Location = New System.Drawing.Point(453, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 25)
        Me.btnCancel.TabIndex = 82
        Me.btnCancel.Text = CType(configurationAppSettings.GetValue("btnCancel.Text", GetType(System.String)), String)
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttpGeneral.SetToolTip(Me.btnCancel, "Cancelar")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.bttnFind)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnDeleteProject)
        Me.GroupBox1.Controls.Add(Me.btnViewDO)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 263)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 48)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        '
        'bttnFind
        '
        Me.bttnFind.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.bttnFind.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnFind.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.bttnFind.ButtonImage = CType(resources.GetObject("bttnFind.ButtonImage"), System.Drawing.Image)
        Me.bttnFind.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.bttnFind.ButtonShowShadow = True
        Me.bttnFind.ButtonText = ""
        Me.bttnFind.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.bttnFind.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.bttnFind.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.bttnFind.Location = New System.Drawing.Point(176, 14)
        Me.bttnFind.Name = "bttnFind"
        Me.bttnFind.Size = New System.Drawing.Size(24, 24)
        Me.bttnFind.TabIndex = 84
        '
        'ChooseProjectForm
        '
        Me.AcceptButton = Me.btnViewDO
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(570, 323)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbxProjects)
        Me.Controls.Add(Me.gbxInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.Name = "ChooseProjectForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxInfo.ResumeLayout(False)
        Me.gbxProjects.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myProjectID As Int64
    Private myProjectName As String
    Private myLocation As String
    Private myCreatedNewDO As Boolean = False

    Private SqlCommands As New SqlCommands
    Private myData As DataSet
    Private newProject As Boolean
    Public Shared configReader As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

#Region "Form"

    Private Sub ChooseProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = GetFormTitle("[" & Constants.UserLogon & "]")
            DisableEdition()

            CreateLvwProjects()
            LoadData()

        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub

#End Region

#Region "Menus"

#Region "miFile"

    Private Sub SairM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

#End Region

#Region "miEdit"

    Private Sub EditPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formDP As New DigitalizationProfilesForm
        formDP.ShowDialog(Me)
    End Sub

    Private Sub EditPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formTP As New TechnologicalPlataformForm
        formTP.ShowDialog(Me)
    End Sub

    Private Sub EditLT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formLP As New LampTypeForm
        formLP.ShowDialog(Me)
    End Sub

    Private Sub EditIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As New RevisionIntervalForm
        form.ShowDialog(Me)
    End Sub

    Private Sub EditMeteringModes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As New MeteringModesForm
        form.ShowDialog(Me)
    End Sub

    Private Sub EditAutoFocus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As New AutoFocusForm
        form.ShowDialog(Me)
    End Sub

#End Region

#Region "miReports"


    'Private Sub miReportDigitalizationProfiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim RepDSBuilder As New ReportDataSetBuilder
    '    Dim ReportDataSet As DigitalizationProfilesData = RepDSBuilder.GenerateDPReportData

    '    Dim Report As New DigitalizationProfilesReport
    '    Report.SetDataSource(ReportDataSet)
    '    Dim viewReport As New ReportPreviewForm(Report)
    '    viewReport.Show()
    'End Sub

    'Private Sub miReportPreservationGD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim RepDSBuilder As New ReportDataSetBuilder
    '    Dim ReportDataSet As ReformattingNormsData = RepDSBuilder.GenerateReformattingNormsReportData

    '    Dim Report As New ReformattingNormsReport
    '    Report.SetDataSource(ReportDataSet)
    '    Dim viewReport As New ReportPreviewForm(Report)
    '    viewReport.Show()
    'End Sub

    'Private Sub miReportReformattingMethods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim RepDSBuilder As New ReportDataSetBuilder
    '    Dim ReportDataSet As ReformattingMethodsData = RepDSBuilder.GenerateReformattingMethodsReportData

    '    Dim Report As New ReformattingMethodsReport
    '    Report.SetDataSource(ReportDataSet)
    '    Dim viewReport As New ReportPreviewForm(Report)
    '    viewReport.Show()
    'End Sub

    Private Sub miReportDigProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportDigProjects.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As ProjectsData = RepDSBuilder.GenerateDigitalizationProjectsReportData(Me.lvwProjects.Items)

        Dim Report As New ProjectsReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub


    Private Sub miDOOperators_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDOOperators.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As DOOperatorsData = RepDSBuilder.GenerateDOOperatorsReportData(Me.lvwProjects.Items)

        Dim Report As New OperatorsReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

#End Region

#Region "miHelp"

    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As New AboutForm
        form.ShowDialog(Me)
    End Sub

#End Region


#End Region

#Region "View DO"

    Private Sub btnViewDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDO.Click
        ViewDO(sender, e)
    End Sub

    Private Sub ViewDO(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.lvwProjects.SelectedItems.Count > 0 Then
            'Dim DOForm As New DigitalObjectsForm(Me.lvwProjects.SelectedItems(0).Tag, Me.lvwProjects.SelectedItems(0).Text)
            Try
                If Me.btnViewDO.Tag = "CreatedNew" Then
                    'DOForm.NewDO_Click(sender, e)
                    Me.CreatedNewDO = True
                End If
                'DOForm.ShowDialog(Me)
                Me.ProjectID = Me.lvwProjects.SelectedItems(0).Tag
                Me.ProjectName = Me.lvwProjects.SelectedItems(0).Text
                Me.Close()
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            End Try
        End If
    End Sub

#End Region

#Region "Find"

    Private Sub bttnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnFind.Click
        Dim FindDOForm As New FindProjectForm
        FindDOForm.ShowDialog(Me)
    End Sub

#End Region

#Region "New/Edit/Save"

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearFields()
        EnableEdition()

        Me.txtName.Text = InfoMessage("Entity.Name") & Now.Year & "P"
        Me.lblCreationDateTime.Text = DateToDB(Now)
        Me.lblLastUpdateDateTime.Text = DateToDB(Now)
        Me.lblEmployee.Text = Constants.UserLogon
        Me.btnEdit.Tag = "New"
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text.Equals(configReader.GetValue("btnEdit.Text", GetType(String))) Then
            EnableEdition()

            Me.lblLastUpdateDateTime.Text = DateToDB(Now)
            Me.btnEdit.Tag = "Update"
            Me.txtName.Tag = Me.txtName.Text
            Me.txtLocation.Tag = Me.txtLocation.Text.TrimEnd("\") + "\" + Me.txtName.Text

        ElseIf btnEdit.Text.Equals(configReader.GetValue("btnSave.Text", GetType(String))) Then
            Select Case Me.btnEdit.Tag
                Case "New"
                    SaveNew()
                    Me.btnViewDO.Tag = "CreatedNew"
                Case "Update"
                    SaveChanges()
            End Select
        End If
    End Sub

    Private Sub SaveNew()
        Dim strProjectPath, insertProject, strProjectName, Username As String
        Dim strProjectDirectory As Directory
        Dim positionN As Integer
        Dim c As New Color
        c = Color.AliceBlue

        Dim strPrefixProject As String = InfoMessage("Entity.Name") & Now.Year & "P"

        '// first case: empty name
        '// second case: project name strictly equal to identifier (p.e. ADP2006P)
        '// third case: project name don't start with correct identitifer
        If (txtName.Text.Length = 0) Or (txtName.Text.Equals(strPrefixProject)) Or Not (txtName.Text.StartsWith(strPrefixProject)) Then
            txtName.Text = strPrefixProject
            MsgBox(InfoMessage("Projects.InvalidName"), MsgBoxStyle.Information)
            txtName.Focus()
            Exit Sub
        ElseIf (txtLocation.Text.Length = 0) Then
            MsgBox(InfoMessage("Projects.InvalidLocation"), MsgBoxStyle.Information)
            btnLocalization.Select()
            Exit Sub
        End If


        strProjectName = txtName.Text
        strProjectPath = txtLocation.Text & "\" & strProjectName

        If Directory.Exists(strProjectPath) Then
            MsgBox(InfoMessage("Projects.NameAlreadyExists"), MsgBoxStyle.Exclamation)
            txtName.Focus()
            Exit Sub
        End If

        Try
            strProjectDirectory.CreateDirectory(strProjectPath)
            SqlCommands.InsertProject(strProjectName, Me.txtLocation.Text, Me.txtDescription.Text.Replace("'", "''"), _
                    Me.lblCreationDateTime.Text, Me.lblLastUpdateDateTime.Text, Me.lblEmployee.Text)

            DisableEdition()
            LoadData()

            Log.Append(Constants.UserLogon, Log.AppendNode, "Project " & strProjectName & " was created!")
            'MsgBox(CType(Constants.InfoMessages("Projects.New"), String), MsgBoxStyle.Information)

        Catch exS As SqlException
            strProjectDirectory.Delete(strProjectPath)
            MessageBoxes.MsgBoxSqlException(exS)
        Catch ex As Exception
            strProjectDirectory.Delete(strProjectPath)
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub

    Private Sub SaveChanges()
        Dim strProjectDirectory As Directory
        Dim strSourceProjectName = Me.txtName.Tag
        Dim strSourceProjectDir, strTargetProjectDir, strPrefixProject As String

        strPrefixProject = InfoMessage("Entity.Name") & Now.Year & "P"

        '// first case: empty name
        '// second case: project name strictly equal to identifier (p.e. ADP2006P)
        '// third case: project name don't start with correct identitifer
        If (txtName.Text.Length = 0) Or (txtName.Text.Equals(strPrefixProject)) Then
            txtName.Text = strSourceProjectName
            MsgBox(InfoMessage("Projects.InvalidName"), MsgBoxStyle.Information)
            txtName.Focus()
            Exit Sub
        End If

        If Not Directory.Exists(Me.txtLocation.Text) Then
            MsgBox(InfoMessage("Projects.InvalidLocation"), MsgBoxStyle.Exclamation)
            btnLocalization.Select()
            Exit Sub
        End If

        strSourceProjectDir = Me.txtLocation.Tag
        strTargetProjectDir = Me.txtLocation.Text.TrimEnd("\") + "\" + Me.txtName.Text

        Try
            If Not strSourceProjectDir.Equals(strTargetProjectDir) Then
                Directory.Move(strSourceProjectDir, strTargetProjectDir)
                MsgBox(String.Format(InfoMessage("Projects.MovedDirectory"), strSourceProjectDir, strTargetProjectDir), MsgBoxStyle.Information)
            End If

            SqlCommands.UpdateProject(Me.lvwProjects.SelectedItems(0).Tag, Me.txtName.Text, _
                    Me.txtLocation.Text, Me.txtDescription.Text.Replace("'", "''"), Me.lblLastUpdateDateTime.Text)

            DisableEdition()
            LoadData(Me.lvwProjects.SelectedIndices(0))

            Log.Append(Constants.UserLogon, Log.EditNode, "Project " & strSourceProjectName & " was edited!")
            'MsgBox(CType(Constants.InfoMessages("Projects.Changed"), String), MsgBoxStyle.Information)

        Catch exS As SqlException
            MessageBoxes.MsgBoxException(exS)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub

#End Region

#Region "Cancel"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnCancel.Text.Equals(configReader.GetValue("btnCancel.Text", GetType(String))) Then
            DisableEdition()
        ElseIf Me.btnCancel.Text.Equals(configReader.GetValue("btnClose.Text", GetType(String))) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Delete"

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteProject.Click
        If MsgBox(InfoMessage("DigitalObjects.DeleteProject"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SqlCommands.DeleteProject(Me.lvwProjects.SelectedItems(0).Tag)
            LoadData()
            'MsgBox(InfoMessage("DigitalObjects.DeletedProject"), MsgBoxStyle.Information)
        End If
    End Sub

#End Region

#Region "Localization"

    Private Sub btnLocalization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalization.Click
        If fileChooser.ShowDialog() = DialogResult.OK Then
            Dim strPath As String = fileChooser.SelectedPath.ToString
            txtLocation.Text = strPath
        End If
    End Sub

#End Region

#Region "Listview Projects"

    Private Sub CreateLvwProjects()
        Me.lvwProjects.View = View.Details
        Me.lvwProjects.LabelEdit = False
        Me.lvwProjects.FullRowSelect = True
        Me.lvwProjects.MultiSelect = False

        ' Create columns for the items and subitems.
        Me.lvwProjects.Columns.Add("Designação", 150, HorizontalAlignment.Left)
        Me.lvwProjects.Columns.Add("", 30, HorizontalAlignment.Right)
        Me.lvwProjects.Columns.Add("Responsável", 120, HorizontalAlignment.Left)
        Me.lvwProjects.Columns.Add("Data criação", 100, HorizontalAlignment.Left)
        Me.lvwProjects.Columns.Add("Última alteração", 100, HorizontalAlignment.Left)
    End Sub

    Private Sub lvwProjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwProjects.SelectedIndexChanged
        If Me.lvwProjects.SelectedItems.Count > 0 Then
            Me.BindingContext(myData, myData.Tables(0).ToString).Position = Me.lvwProjects.SelectedIndices(0)
        End If
    End Sub

    Private Sub lvwProjects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwProjects.DoubleClick
        ViewDO(sender, e)
    End Sub

#End Region


#Region "Load data"

    Public Sub LoadData(Optional ByVal intIndex As Integer = 0, Optional ByVal ds As DataSet = Nothing)

        If ds Is Nothing Then
            myData = SqlCommands.SelectAllProjects()
        Else
            myData = ds
        End If
        txtName.DataBindings.Clear()
        txtLocation.DataBindings.Clear()
        lblEmployee.DataBindings.Clear()
        lblCreationDateTime.DataBindings.Clear()
        lblLastUpdateDateTime.DataBindings.Clear()
        txtDescription.DataBindings.Clear()

        FillListView(myData)
        If Me.lvwProjects.Items.Count > 0 Then
            Me.lvwProjects.Items(intIndex).Selected = True
            Me.btnEdit.Enabled = True
            Me.btnDeleteProject.Enabled = True
            Me.btnViewDO.Enabled = True
        Else
            Me.btnEdit.Enabled = False
            Me.btnDeleteProject.Enabled = False
            Me.btnViewDO.Enabled = False
        End If

        If myData.Tables.Count <> 0 Then
            txtName.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".Name"))
            txtLocation.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".Location"))
            lblEmployee.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".Username"))
            lblCreationDateTime.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".CreationDateTime"))
            lblLastUpdateDateTime.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".LastUpdateDateTime"))
            txtDescription.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".Description"))
        End If

    End Sub

    Private Sub FillListView(ByVal myData As DataSet)

        Dim array As ArrayList = SqlCommands.SelectProjectsToCheck
        Dim DOtoCheck As Boolean = False
        Dim myTable As DataTable = myData.Tables(0)

        Me.lvwProjects.Items.Clear()
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            If (myRow.RowState <> DataRowState.Deleted) Then
                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("Name").ToString())
                lvi.SubItems.Add(myRow.Item("DOCount").ToString())
                lvi.SubItems.Add(myRow.Item("Username").ToString())
                lvi.SubItems.Add(myRow.Item("CreationDateTime").ToString())
                lvi.SubItems.Add(myRow.Item("LastUpdateDateTime").ToString())

                lvi.Tag = myRow.Item("ProjectID")
                Me.lvwProjects.Items.Add(lvi)
                If array.Contains(myRow.Item("ProjectID")) Then
                    lvi.ImageIndex = 0
                    DOtoCheck = True
                End If
            End If
        Next
        Me.gbxProjects.Text = "Projectos [" & Me.lvwProjects.Items.Count & "]"
        If DOtoCheck Then
            Me.lblWarning.Visible = True
        Else
            Me.lblWarning.Visible = False
        End If
    End Sub

#End Region

#Region "ClearFields"

    Private Sub ClearFields()
        txtName.Clear()
        txtLocation.Clear()
        'lblLocation.Text = ""
        lblEmployee.Text = ""
        lblCreationDateTime.Text = ""
        lblLastUpdateDateTime.Text = ""
        txtDescription.Clear()
    End Sub

#End Region

#Region "Enable/Disable edition"

    Private Sub EnableEdition()
        Me.btnCancel.Enabled = True
        Me.btnCancel.Text = configReader.GetValue("btnCancel.Text", GetType(String))
        Me.btnNew.Enabled = False
        Me.btnViewDO.Enabled = False
        Me.btnDeleteProject.Enabled = False
        Me.btnEdit.Text = configReader.GetValue("btnSave.Text", GetType(String))
        Me.btnEdit.Enabled = True
        Me.btnEdit.ImageIndex = 2
        Me.gbxInfo.BringToFront()
    End Sub

    Private Sub DisableEdition()
        Me.btnCancel.Enabled = True
        Me.btnCancel.Text = configReader.GetValue("btnClose.Text", GetType(String))
        Me.btnNew.Enabled = True
        Me.btnViewDO.Enabled = True
        Me.btnDeleteProject.Enabled = True
        Me.btnEdit.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        Me.btnEdit.Enabled = True
        btnEdit.ImageIndex = 3
        Me.gbxProjects.BringToFront()
    End Sub

#End Region

#Region "Verify the connection"

    Private Function tryconnection() As Boolean
        Dim res As Boolean

        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = Constants.DigitArqConnectionString
            cn.Open()
            res = True
        Catch ex As Exception
            res = False
        End Try
        Return res
    End Function

#End Region


#Region "Properties"

    Public Property ProjectID() As Int64
        Get
            Return myProjectID
        End Get
        Set(ByVal Value As Int64)
            myProjectID = Value
        End Set
    End Property

    Public Property ProjectName() As String
        Get
            Return myProjectName
        End Get
        Set(ByVal Value As String)
            myProjectName = Value
        End Set
    End Property

    Public Property CreatedNewDO() As Boolean
        Get
            Return myCreatedNewDO
        End Get
        Set(ByVal Value As Boolean)
            myCreatedNewDO = Value
        End Set
    End Property

#End Region


End Class
