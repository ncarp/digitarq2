
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
Imports System.Threading
'Imports LEAD

Public Class AssociationForm
    Inherits System.Windows.Forms.Form

    Private MyThread As Thread

    Private database As New database
    Private CTree As New CTreeView
    Private dsDigitalObjects As DataSet

    Private myUsername As String
    Private myProjectID As Int64
    Private myProjectName As String
    Private myDigitalObjectID As Int64

    Private tnSearched As New ListViewItem
    Private Stoped As Boolean = False

    Private CountDOChecked As Integer
    Private CountTreeNodesChecked As Integer
    Private NumOfChildNodes As Integer

    Private pb As New System.Windows.Forms.PictureBox

    Private Enum AssociationType
        DigitalObject
        DOFiles
    End Enum


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal strUsername As String, ByVal intProjectID As Int64, ByVal strProjectName As String)
        MyBase.New()
        Constants.UserLogon = strUsername
        myProjectID = intProjectID
        myProjectName = strProjectName

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal strUsername As String, ByVal intProjectID As Int64, ByVal strProjectName As String, ByVal intDigitalObjectID As Int64)
        MyBase.New()
        Constants.UserLogon = strUsername
        myProjectID = intProjectID
        myProjectName = strProjectName
        myDigitalObjectID = intDigitalObjectID

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents pBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblNumberChecked As System.Windows.Forms.Label
    Friend WithEvents lblNumberSelected As System.Windows.Forms.Label
    Friend WithEvents ImageListTVDigitarq As System.Windows.Forms.ImageList
    Friend WithEvents tvwSelectedFond As System.Windows.Forms.TreeView
    Friend WithEvents gbxAssociate As System.Windows.Forms.GroupBox
    Friend WithEvents gbxPbar As System.Windows.Forms.GroupBox
    Friend WithEvents btnOpenOriginalNames As System.Windows.Forms.Button
    Friend WithEvents lvwDigitalObjects As System.Windows.Forms.ListView
    Friend WithEvents lblAssociationType As System.Windows.Forms.Label
    Friend WithEvents cmTvw As System.Windows.Forms.ContextMenu
    Friend WithEvents miCheckChild As System.Windows.Forms.MenuItem
    Friend WithEvents miViewAssociations As System.Windows.Forms.MenuItem
    Friend WithEvents ttGeneral As System.Windows.Forms.ToolTip
    Friend WithEvents btnOpenDO As System.Windows.Forms.Button
    Friend WithEvents miUIDigitalization As System.Windows.Forms.MenuItem
    Friend WithEvents miDigitarqOD As System.Windows.Forms.MenuItem
    Friend WithEvents tvwDO As System.Windows.Forms.TreeView
    Friend WithEvents cmDO As System.Windows.Forms.ContextMenu
    Friend WithEvents ImageListTVImages As System.Windows.Forms.ImageList
    Friend WithEvents cmDOFile As System.Windows.Forms.ContextMenu
    Friend WithEvents miDOFileAssociations As System.Windows.Forms.MenuItem
    Friend WithEvents miDOFileBackDOList As System.Windows.Forms.MenuItem
    Friend WithEvents miDOAssociations As System.Windows.Forms.MenuItem
    Friend WithEvents miDOViewStructure As System.Windows.Forms.MenuItem
    Friend WithEvents miClose As System.Windows.Forms.MenuItem
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lvwFonds As System.Windows.Forms.ListView
    Friend WithEvents gbxFonds As System.Windows.Forms.GroupBox
    Friend WithEvents btnBack As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnViewDescAssociations As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnCheckAll As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnCollapse As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnAssociate As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnViewDOAssociations As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnSelectAll As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnImages As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnBackDO As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents miProjects As System.Windows.Forms.MenuItem
    Friend WithEvents miOpenProjects As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents miView As System.Windows.Forms.MenuItem
    Friend WithEvents miReports As System.Windows.Forms.MenuItem
    Friend WithEvents miHelp As System.Windows.Forms.MenuItem
    Friend WithEvents miAssociationDODesc As System.Windows.Forms.MenuItem
    Friend WithEvents miAssociationDescDO As System.Windows.Forms.MenuItem
    Friend WithEvents miAboutMPOD As System.Windows.Forms.MenuItem
    Friend WithEvents gbxDigitalObjects As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssociationForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.ImageListTVDigitarq = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxFonds = New System.Windows.Forms.GroupBox
        Me.btnCollapse = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnCheckAll = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnViewDescAssociations = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnBack = New mkccontrols.windows.forms.control.mkc_Button
        Me.lvwFonds = New System.Windows.Forms.ListView
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblNumberChecked = New System.Windows.Forms.Label
        Me.tvwSelectedFond = New System.Windows.Forms.TreeView
        Me.cmTvw = New System.Windows.Forms.ContextMenu
        Me.miCheckChild = New System.Windows.Forms.MenuItem
        Me.miViewAssociations = New System.Windows.Forms.MenuItem
        Me.btnAssociate = New mkccontrols.windows.forms.control.mkc_Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.miProjects = New System.Windows.Forms.MenuItem
        Me.miOpenProjects = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.miClose = New System.Windows.Forms.MenuItem
        Me.miView = New System.Windows.Forms.MenuItem
        Me.miAssociationDODesc = New System.Windows.Forms.MenuItem
        Me.miAssociationDescDO = New System.Windows.Forms.MenuItem
        Me.miReports = New System.Windows.Forms.MenuItem
        Me.miUIDigitalization = New System.Windows.Forms.MenuItem
        Me.miDigitarqOD = New System.Windows.Forms.MenuItem
        Me.miHelp = New System.Windows.Forms.MenuItem
        Me.miAboutMPOD = New System.Windows.Forms.MenuItem
        Me.gbxAssociate = New System.Windows.Forms.GroupBox
        Me.lblAssociationType = New System.Windows.Forms.Label
        Me.gbxPbar = New System.Windows.Forms.GroupBox
        Me.pBar1 = New System.Windows.Forms.ProgressBar
        Me.gbxDigitalObjects = New System.Windows.Forms.GroupBox
        Me.btnBackDO = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnImages = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnSelectAll = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnViewDOAssociations = New mkccontrols.windows.forms.control.mkc_Button
        Me.tvwDO = New System.Windows.Forms.TreeView
        Me.cmDOFile = New System.Windows.Forms.ContextMenu
        Me.miDOFileAssociations = New System.Windows.Forms.MenuItem
        Me.miDOFileBackDOList = New System.Windows.Forms.MenuItem
        Me.ImageListTVImages = New System.Windows.Forms.ImageList(Me.components)
        Me.btnOpenDO = New System.Windows.Forms.Button
        Me.lvwDigitalObjects = New System.Windows.Forms.ListView
        Me.cmDO = New System.Windows.Forms.ContextMenu
        Me.miDOAssociations = New System.Windows.Forms.MenuItem
        Me.miDOViewStructure = New System.Windows.Forms.MenuItem
        Me.btnOpenOriginalNames = New System.Windows.Forms.Button
        Me.lblNumberSelected = New System.Windows.Forms.Label
        Me.ttGeneral = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbxFonds.SuspendLayout()
        Me.gbxAssociate.SuspendLayout()
        Me.gbxPbar.SuspendLayout()
        Me.gbxDigitalObjects.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageListTVDigitarq
        '
        Me.ImageListTVDigitarq.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListTVDigitarq.ImageStream = CType(resources.GetObject("ImageListTVDigitarq.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTVDigitarq.TransparentColor = System.Drawing.Color.Transparent
        '
        'gbxFonds
        '
        Me.gbxFonds.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxFonds.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxFonds.Controls.Add(Me.btnCollapse)
        Me.gbxFonds.Controls.Add(Me.btnCheckAll)
        Me.gbxFonds.Controls.Add(Me.btnViewDescAssociations)
        Me.gbxFonds.Controls.Add(Me.btnBack)
        Me.gbxFonds.Controls.Add(Me.lvwFonds)
        Me.gbxFonds.Controls.Add(Me.txtSearch)
        Me.gbxFonds.Controls.Add(Me.lblNumberChecked)
        Me.gbxFonds.Controls.Add(Me.tvwSelectedFond)
        Me.gbxFonds.Location = New System.Drawing.Point(16, 16)
        Me.gbxFonds.Name = "gbxFonds"
        Me.gbxFonds.Size = New System.Drawing.Size(384, 565)
        Me.gbxFonds.TabIndex = 9
        Me.gbxFonds.TabStop = False
        Me.gbxFonds.Text = "Lista de fundos"
        '
        'btnCollapse
        '
        Me.btnCollapse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCollapse.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnCollapse.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCollapse.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCollapse.ButtonImage = CType(resources.GetObject("btnCollapse.ButtonImage"), System.Drawing.Image)
        Me.btnCollapse.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnCollapse.ButtonShowShadow = True
        Me.btnCollapse.ButtonText = "Expandir"
        Me.btnCollapse.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCollapse.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnCollapse.Enabled = False
        Me.btnCollapse.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnCollapse.Location = New System.Drawing.Point(183, 504)
        Me.btnCollapse.Name = "btnCollapse"
        Me.btnCollapse.Size = New System.Drawing.Size(57, 56)
        Me.btnCollapse.TabIndex = 101
        Me.ttGeneral.SetToolTip(Me.btnCollapse, "Expandir tudo")
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckAll.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnCheckAll.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckAll.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCheckAll.ButtonImage = CType(resources.GetObject("btnCheckAll.ButtonImage"), System.Drawing.Image)
        Me.btnCheckAll.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnCheckAll.ButtonShowShadow = True
        Me.btnCheckAll.ButtonText = "Seleccionar"
        Me.btnCheckAll.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCheckAll.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnCheckAll.Enabled = False
        Me.btnCheckAll.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnCheckAll.Location = New System.Drawing.Point(240, 504)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(72, 56)
        Me.btnCheckAll.TabIndex = 100
        Me.ttGeneral.SetToolTip(Me.btnCheckAll, "Seleccionar tudo")
        '
        'btnViewDescAssociations
        '
        Me.btnViewDescAssociations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewDescAssociations.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnViewDescAssociations.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewDescAssociations.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnViewDescAssociations.ButtonImage = CType(resources.GetObject("btnViewDescAssociations.ButtonImage"), System.Drawing.Image)
        Me.btnViewDescAssociations.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnViewDescAssociations.ButtonShowShadow = True
        Me.btnViewDescAssociations.ButtonText = "Associações"
        Me.btnViewDescAssociations.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnViewDescAssociations.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnViewDescAssociations.Enabled = False
        Me.btnViewDescAssociations.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnViewDescAssociations.Location = New System.Drawing.Point(312, 504)
        Me.btnViewDescAssociations.Name = "btnViewDescAssociations"
        Me.btnViewDescAssociations.Size = New System.Drawing.Size(57, 56)
        Me.btnViewDescAssociations.TabIndex = 99
        Me.ttGeneral.SetToolTip(Me.btnViewDescAssociations, "Ver associações desta descrição")
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnBack.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBack.ButtonImage = CType(resources.GetObject("btnBack.ButtonImage"), System.Drawing.Image)
        Me.btnBack.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnBack.ButtonShowShadow = True
        Me.btnBack.ButtonText = "Voltar"
        Me.btnBack.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBack.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnBack.Enabled = False
        Me.btnBack.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnBack.Location = New System.Drawing.Point(16, 504)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(57, 56)
        Me.btnBack.TabIndex = 98
        Me.ttGeneral.SetToolTip(Me.btnBack, "Voltar à lista de fundos")
        '
        'lvwFonds
        '
        Me.lvwFonds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFonds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwFonds.HideSelection = False
        Me.lvwFonds.Location = New System.Drawing.Point(16, 49)
        Me.lvwFonds.Name = "lvwFonds"
        Me.lvwFonds.Size = New System.Drawing.Size(352, 455)
        Me.lvwFonds.SmallImageList = Me.ImageListTVDigitarq
        Me.lvwFonds.TabIndex = 91
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Location = New System.Drawing.Point(16, 24)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(352, 20)
        Me.txtSearch.TabIndex = 90
        Me.txtSearch.Text = ""
        '
        'lblNumberChecked
        '
        Me.lblNumberChecked.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumberChecked.Location = New System.Drawing.Point(16, 24)
        Me.lblNumberChecked.Name = "lblNumberChecked"
        Me.lblNumberChecked.Size = New System.Drawing.Size(352, 20)
        Me.lblNumberChecked.TabIndex = 87
        Me.lblNumberChecked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tvwSelectedFond
        '
        Me.tvwSelectedFond.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwSelectedFond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwSelectedFond.CheckBoxes = True
        Me.tvwSelectedFond.ContextMenu = Me.cmTvw
        Me.tvwSelectedFond.ImageList = Me.ImageListTVDigitarq
        Me.tvwSelectedFond.Location = New System.Drawing.Point(16, 49)
        Me.tvwSelectedFond.Name = "tvwSelectedFond"
        Me.tvwSelectedFond.Size = New System.Drawing.Size(352, 455)
        Me.tvwSelectedFond.TabIndex = 16
        '
        'cmTvw
        '
        Me.cmTvw.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miCheckChild, Me.miViewAssociations})
        '
        'miCheckChild
        '
        Me.miCheckChild.Index = 0
        Me.miCheckChild.Text = "(Des)seleccionar filhos"
        '
        'miViewAssociations
        '
        Me.miViewAssociations.Index = 1
        Me.miViewAssociations.Text = "Ver associações"
        '
        'btnAssociate
        '
        Me.btnAssociate.BorderColor = System.Drawing.Color.White
        Me.btnAssociate.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssociate.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAssociate.ButtonImage = CType(resources.GetObject("btnAssociate.ButtonImage"), System.Drawing.Image)
        Me.btnAssociate.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnAssociate.ButtonShowShadow = True
        Me.btnAssociate.ButtonText = "Associar"
        Me.btnAssociate.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAssociate.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAssociate.Enabled = False
        Me.btnAssociate.HighlightBackgroundColor = System.Drawing.Color.White
        Me.btnAssociate.Location = New System.Drawing.Point(400, 248)
        Me.btnAssociate.Name = "btnAssociate"
        Me.btnAssociate.Size = New System.Drawing.Size(45, 56)
        Me.btnAssociate.TabIndex = 98
        Me.ttGeneral.SetToolTip(Me.btnAssociate, "Associar objecto digital a descrição")
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miProjects, Me.miView, Me.miReports, Me.miHelp})
        '
        'miProjects
        '
        Me.miProjects.Index = 0
        Me.miProjects.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miOpenProjects, Me.MenuItem5, Me.miClose})
        Me.miProjects.Text = "&Projectos"
        '
        'miOpenProjects
        '
        Me.miOpenProjects.Index = 0
        Me.miOpenProjects.Text = "&Listar projectos..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.Text = "-"
        '
        'miClose
        '
        Me.miClose.Index = 2
        Me.miClose.Text = "&Sair"
        '
        'miView
        '
        Me.miView.Index = 1
        Me.miView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miAssociationDODesc, Me.miAssociationDescDO})
        Me.miView.Text = "&Ver"
        '
        'miAssociationDODesc
        '
        Me.miAssociationDODesc.Index = 0
        Me.miAssociationDODesc.Text = "Associações OD - Descrição"
        '
        'miAssociationDescDO
        '
        Me.miAssociationDescDO.Index = 1
        Me.miAssociationDescDO.Text = "Associação Descrição - OD"
        '
        'miReports
        '
        Me.miReports.Index = 2
        Me.miReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miUIDigitalization, Me.miDigitarqOD})
        Me.miReports.Text = "&Relatórios"
        '
        'miUIDigitalization
        '
        Me.miUIDigitalization.Index = 0
        Me.miUIDigitalization.Text = "UI digitalizadas"
        '
        'miDigitarqOD
        '
        Me.miDigitarqOD.Index = 1
        Me.miDigitarqOD.Text = "OD associados a uma referência"
        '
        'miHelp
        '
        Me.miHelp.Index = 3
        Me.miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miAboutMPOD})
        Me.miHelp.Text = "&Ajuda"
        Me.miHelp.Visible = False
        '
        'miAboutMPOD
        '
        Me.miAboutMPOD.Index = 0
        Me.miAboutMPOD.Text = "MPOD"
        '
        'gbxAssociate
        '
        Me.gbxAssociate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxAssociate.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxAssociate.Controls.Add(Me.lblAssociationType)
        Me.gbxAssociate.Controls.Add(Me.gbxPbar)
        Me.gbxAssociate.Location = New System.Drawing.Point(16, 581)
        Me.gbxAssociate.Name = "gbxAssociate"
        Me.gbxAssociate.Size = New System.Drawing.Size(709, 80)
        Me.gbxAssociate.TabIndex = 86
        Me.gbxAssociate.TabStop = False
        '
        'lblAssociationType
        '
        Me.lblAssociationType.Location = New System.Drawing.Point(16, 16)
        Me.lblAssociationType.Name = "lblAssociationType"
        Me.lblAssociationType.Size = New System.Drawing.Size(677, 20)
        Me.lblAssociationType.TabIndex = 85
        '
        'gbxPbar
        '
        Me.gbxPbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxPbar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxPbar.Controls.Add(Me.pBar1)
        Me.gbxPbar.Location = New System.Drawing.Point(16, 40)
        Me.gbxPbar.Name = "gbxPbar"
        Me.gbxPbar.Size = New System.Drawing.Size(677, 32)
        Me.gbxPbar.TabIndex = 84
        Me.gbxPbar.TabStop = False
        '
        'pBar1
        '
        Me.pBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pBar1.Location = New System.Drawing.Point(8, 14)
        Me.pBar1.Name = "pBar1"
        Me.pBar1.Size = New System.Drawing.Size(661, 10)
        Me.pBar1.TabIndex = 73
        '
        'gbxDigitalObjects
        '
        Me.gbxDigitalObjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxDigitalObjects.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxDigitalObjects.Controls.Add(Me.btnBackDO)
        Me.gbxDigitalObjects.Controls.Add(Me.btnImages)
        Me.gbxDigitalObjects.Controls.Add(Me.btnSelectAll)
        Me.gbxDigitalObjects.Controls.Add(Me.btnViewDOAssociations)
        Me.gbxDigitalObjects.Controls.Add(Me.tvwDO)
        Me.gbxDigitalObjects.Controls.Add(Me.btnOpenDO)
        Me.gbxDigitalObjects.Controls.Add(Me.lvwDigitalObjects)
        Me.gbxDigitalObjects.Controls.Add(Me.btnOpenOriginalNames)
        Me.gbxDigitalObjects.Controls.Add(Me.lblNumberSelected)
        Me.gbxDigitalObjects.Location = New System.Drawing.Point(445, 16)
        Me.gbxDigitalObjects.Name = "gbxDigitalObjects"
        Me.gbxDigitalObjects.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbxDigitalObjects.Size = New System.Drawing.Size(280, 565)
        Me.gbxDigitalObjects.TabIndex = 85
        Me.gbxDigitalObjects.TabStop = False
        Me.gbxDigitalObjects.Text = "Objectos digitais"
        '
        'btnBackDO
        '
        Me.btnBackDO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBackDO.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnBackDO.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackDO.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBackDO.ButtonImage = CType(resources.GetObject("btnBackDO.ButtonImage"), System.Drawing.Image)
        Me.btnBackDO.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnBackDO.ButtonShowShadow = True
        Me.btnBackDO.ButtonText = "Voltar"
        Me.btnBackDO.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBackDO.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnBackDO.Enabled = False
        Me.btnBackDO.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnBackDO.Location = New System.Drawing.Point(5, 504)
        Me.btnBackDO.Name = "btnBackDO"
        Me.btnBackDO.Size = New System.Drawing.Size(57, 56)
        Me.btnBackDO.TabIndex = 106
        Me.ttGeneral.SetToolTip(Me.btnBackDO, "Voltar à lista de objectos digitais")
        '
        'btnImages
        '
        Me.btnImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImages.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnImages.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImages.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImages.ButtonImage = CType(resources.GetObject("btnImages.ButtonImage"), System.Drawing.Image)
        Me.btnImages.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnImages.ButtonShowShadow = True
        Me.btnImages.ButtonText = "Visualizar"
        Me.btnImages.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImages.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnImages.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnImages.Location = New System.Drawing.Point(215, 504)
        Me.btnImages.Name = "btnImages"
        Me.btnImages.Size = New System.Drawing.Size(57, 56)
        Me.btnImages.TabIndex = 105
        Me.ttGeneral.SetToolTip(Me.btnImages, "Visualizar objecto digital")
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnSelectAll.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSelectAll.ButtonImage = CType(resources.GetObject("btnSelectAll.ButtonImage"), System.Drawing.Image)
        Me.btnSelectAll.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnSelectAll.ButtonShowShadow = True
        Me.btnSelectAll.ButtonText = "Seleccionar"
        Me.btnSelectAll.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSelectAll.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnSelectAll.Location = New System.Drawing.Point(86, 504)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(72, 56)
        Me.btnSelectAll.TabIndex = 104
        Me.ttGeneral.SetToolTip(Me.btnSelectAll, "Seleccionar tudo")
        '
        'btnViewDOAssociations
        '
        Me.btnViewDOAssociations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewDOAssociations.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnViewDOAssociations.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewDOAssociations.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnViewDOAssociations.ButtonImage = CType(resources.GetObject("btnViewDOAssociations.ButtonImage"), System.Drawing.Image)
        Me.btnViewDOAssociations.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnViewDOAssociations.ButtonShowShadow = True
        Me.btnViewDOAssociations.ButtonText = "Associações"
        Me.btnViewDOAssociations.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnViewDOAssociations.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnViewDOAssociations.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnViewDOAssociations.Location = New System.Drawing.Point(156, 504)
        Me.btnViewDOAssociations.Name = "btnViewDOAssociations"
        Me.btnViewDOAssociations.Size = New System.Drawing.Size(57, 56)
        Me.btnViewDOAssociations.TabIndex = 103
        Me.ttGeneral.SetToolTip(Me.btnViewDOAssociations, "Ver associações deste objecto digital")
        '
        'tvwDO
        '
        Me.tvwDO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwDO.CheckBoxes = True
        Me.tvwDO.ContextMenu = Me.cmDOFile
        Me.tvwDO.ImageList = Me.ImageListTVImages
        Me.tvwDO.Location = New System.Drawing.Point(16, 49)
        Me.tvwDO.Name = "tvwDO"
        Me.tvwDO.Size = New System.Drawing.Size(248, 455)
        Me.tvwDO.TabIndex = 95
        '
        'cmDOFile
        '
        Me.cmDOFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miDOFileAssociations, Me.miDOFileBackDOList})
        '
        'miDOFileAssociations
        '
        Me.miDOFileAssociations.Index = 0
        Me.miDOFileAssociations.Text = "Ver associações"
        '
        'miDOFileBackDOList
        '
        Me.miDOFileBackDOList.Index = 1
        Me.miDOFileBackDOList.Text = "Voltar à lista de OD"
        '
        'ImageListTVImages
        '
        Me.ImageListTVImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListTVImages.ImageStream = CType(resources.GetObject("ImageListTVImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTVImages.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnOpenDO
        '
        Me.btnOpenDO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenDO.BackColor = System.Drawing.Color.White
        Me.btnOpenDO.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOpenDO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenDO.Image = CType(resources.GetObject("btnOpenDO.Image"), System.Drawing.Image)
        Me.btnOpenDO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpenDO.Location = New System.Drawing.Point(224, 7)
        Me.btnOpenDO.Name = "btnOpenDO"
        Me.btnOpenDO.Size = New System.Drawing.Size(40, 20)
        Me.btnOpenDO.TabIndex = 94
        Me.btnOpenDO.Text = " >"
        Me.btnOpenDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lvwDigitalObjects
        '
        Me.lvwDigitalObjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwDigitalObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwDigitalObjects.CheckBoxes = True
        Me.lvwDigitalObjects.ContextMenu = Me.cmDO
        Me.lvwDigitalObjects.GridLines = True
        Me.lvwDigitalObjects.HideSelection = False
        Me.lvwDigitalObjects.Location = New System.Drawing.Point(16, 49)
        Me.lvwDigitalObjects.Name = "lvwDigitalObjects"
        Me.lvwDigitalObjects.Size = New System.Drawing.Size(248, 455)
        Me.lvwDigitalObjects.TabIndex = 93
        '
        'cmDO
        '
        Me.cmDO.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miDOAssociations, Me.miDOViewStructure})
        '
        'miDOAssociations
        '
        Me.miDOAssociations.Index = 0
        Me.miDOAssociations.Text = "Ver associações"
        '
        'miDOViewStructure
        '
        Me.miDOViewStructure.Index = 1
        Me.miDOViewStructure.Text = "Ver estrutura do OD"
        '
        'btnOpenOriginalNames
        '
        Me.btnOpenOriginalNames.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenOriginalNames.BackColor = System.Drawing.Color.White
        Me.btnOpenOriginalNames.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOpenOriginalNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenOriginalNames.Image = CType(resources.GetObject("btnOpenOriginalNames.Image"), System.Drawing.Image)
        Me.btnOpenOriginalNames.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpenOriginalNames.Location = New System.Drawing.Point(224, 28)
        Me.btnOpenOriginalNames.Name = "btnOpenOriginalNames"
        Me.btnOpenOriginalNames.Size = New System.Drawing.Size(40, 20)
        Me.btnOpenOriginalNames.TabIndex = 92
        Me.btnOpenOriginalNames.Text = " >"
        Me.btnOpenOriginalNames.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumberSelected
        '
        Me.lblNumberSelected.Location = New System.Drawing.Point(16, 24)
        Me.lblNumberSelected.Name = "lblNumberSelected"
        Me.lblNumberSelected.Size = New System.Drawing.Size(176, 20)
        Me.lblNumberSelected.TabIndex = 89
        Me.lblNumberSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AssociationForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(744, 665)
        Me.Controls.Add(Me.gbxAssociate)
        Me.Controls.Add(Me.gbxDigitalObjects)
        Me.Controls.Add(Me.gbxFonds)
        Me.Controls.Add(Me.btnAssociate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.Name = "AssociationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = CType(configurationAppSettings.GetValue("Application.Version", GetType(System.String)), String)
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbxFonds.ResumeLayout(False)
        Me.gbxAssociate.ResumeLayout(False)
        Me.gbxPbar.ResumeLayout(False)
        Me.gbxDigitalObjects.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Load"

    Private Sub AssociationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetMDIContainerBackColor(System.Drawing.Color.White)
        Me.Text = GetFormTitle("[" & Constants.UserLogon & "]")

        LoadLvwFonds()
        CreateLvwDigitalObjects()
        Dim index As Integer = LoadDigitalObjects()
        If Me.lvwDigitalObjects.Items.Count > 0 Then
            Me.lvwDigitalObjects.Items(index).Selected = True
        Else
            Dim frmChooseProject As New ChooseProjectForm
            frmChooseProject.ShowDialog()
            myProjectID = frmChooseProject.ProjectID
            myProjectName = frmChooseProject.ProjectName
            LoadDigitalObjects()
        End If

        Me.btnSelectAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\select.png")
        Me.btnSelectAll.Tag = "Unselect"

        Me.btnBackDO.Tag = "ViewStructure"

        Me.btnOpenDO.Tag = "Closed"
        Me.btnOpenOriginalNames.Tag = "Closed"
        btnOpenDO_Click(Me, e)
    End Sub

    Private Sub SetMDIContainerBackColor(ByVal color As System.Drawing.Color)
        Dim ctl As Control
        ' Loop through all of the form's controls looking
        ' for the control of type MdiClient.
        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                If TypeOf ctl Is MdiClient Then

                    ' Set the BackColor of the MdiClient control.
                    ctl.BackColor = color

                End If

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next
    End Sub

    Private Sub CreateLvwDigitalObjects()

        Me.lvwDigitalObjects.View = View.Details
        Me.lvwDigitalObjects.LabelEdit = False
        Me.lvwDigitalObjects.AllowColumnReorder = False
        Me.lvwDigitalObjects.FullRowSelect = True
        Me.lvwDigitalObjects.MultiSelect = False
        Me.lvwDigitalObjects.CheckBoxes = True

        Me.lvwDigitalObjects.Columns.Add("Nome do objecto digital", Me.lvwDigitalObjects.Width, HorizontalAlignment.Left)
        Me.lvwDigitalObjects.Columns.Add("Nome original do objecto digital", 0, HorizontalAlignment.Left)
    End Sub

    Private Function LoadDigitalObjects() As Integer
        Dim index As Integer = 0
        dsDigitalObjects = database.SelectDigitalObjects(myProjectID)
        Dim myTable As DataTable = dsDigitalObjects.Tables(0)

        'Clear the ListView control
        Me.lvwDigitalObjects.BringToFront()
        Me.lvwDigitalObjects.Items.Clear()

        'Display items in the ListView control
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            'Only row that have not been deleted


            Dim lvi As ListViewItem = New ListViewItem(myRow.Item("Name").ToString())
            lvi.SubItems.Add(myRow.Item("OriginalName").ToString())
            lvi.Tag = myRow.Item("DigitalObjectID")
            If Not myRow.Item("DaoGrpDOID") Is System.DBNull.Value Then
                lvi.ForeColor = Color.Blue
            Else
                lvi.ForeColor = Color.Black
            End If
            If lvi.Tag = myDigitalObjectID Then
                index = i
            End If
            Me.lvwDigitalObjects.Items.Add(lvi)

        Next
        Me.CountDOChecked = 0
        WriteNumberDO()
        Return index
    End Function

    Private Sub WriteNumberDO()
        Me.gbxDigitalObjects.Text = String.Format(InfoMessage("Association.gbxDigitalObjects1"), Me.lvwDigitalObjects.Items.Count.ToString)
    End Sub

    Private Sub WriteNumberDOFiles()
        Me.gbxDigitalObjects.Text = String.Format(InfoMessage("Association.gbxDigitalObjects2"), CStr(NumOfChildNodes))
    End Sub

    Private Sub LoadLvwFonds()
        Dim tnNew As TreeNode
        Dim myData As New DataSet
        Dim count As Integer

        myData = database.SelectAllFonds()
        Dim myTable As DataTable = myData.Tables(0)

        Me.lvwFonds.View = View.Details
        Me.lvwFonds.LabelEdit = False
        Me.lvwFonds.FullRowSelect = True

        ' Create columns for the items and subitems.
        Me.lvwFonds.Columns.Add("Fundos", Me.lvwFonds.Width - 20, HorizontalAlignment.Left)

        Me.lvwFonds.Items.Clear()
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            Dim lvi As ListViewItem = New ListViewItem(myRow.Item("UnitID").ToString())
            lvi.Tag = myRow.Item("ID")
            lvi.ImageIndex = 0
            Me.lvwFonds.Items.Add(lvi)
        Next
        'Me.gbFonds.Text = String.Format(InfoMessage("Association.gbFonds"), myTable.Rows.Count.ToString)
    End Sub

#End Region

#Region "Form"

    Private Sub Association_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub

        Dim Item As ListViewItem
        Dim ItemToSelect As ListViewItem = Nothing
        For Each Item In Me.lvwFonds.Items
            If Item.Text.ToUpper.IndexOf(Me.txtSearch.Text.ToUpper) >= 0 Then
                ItemToSelect = Item
                Exit For
            End If
        Next

        If Not ItemToSelect Is Nothing Then
            lvwFonds.Focus()
            lvwFonds.MultiSelect = False
            ItemToSelect.Selected = True
            ItemToSelect.Focused = True
            ItemToSelect.EnsureVisible()
            lvwFonds.MultiSelect = True
        End If
    End Sub

#End Region

#Region "Menus"

    'Menu Item Reports
    Private Sub miOpenProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOpenProjects.Click
        Dim frmChooseProject As New ChooseProjectForm
        frmChooseProject.ShowDialog()
        myProjectID = frmChooseProject.ProjectID
        myProjectName = frmChooseProject.ProjectName
        LoadDigitalObjects()
    End Sub

    Private Sub miClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClose.Click
        Me.Close()
    End Sub

    'Menu Item View
    Private Sub miAssociationDODesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAssociationDODesc.Click
        AssociationDODescr()
    End Sub

    Private Sub miAssociationDescDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAssociationDescDO.Click
        AssociationDescrDO()
    End Sub

    'Menu Item Reports
    Private Sub miUIDigitalization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miUIDigitalization.Click
        If Me.lvwFonds.SelectedItems.Count = 0 Then
            MsgBox("Tem que seleccionar pelo menos um Fundo!", MsgBoxStyle.Information)
        Else
            Dim RepDSBuilder As New ReportDataSetBuilder
            Dim ReportDataSet As UIDigitalizationData = RepDSBuilder.GenerateUIDigitalizationReportData(Me.lvwFonds.SelectedItems)

            Dim Report As New UIDigitalizationReport
            Report.SetDataSource(ReportDataSet)
            Dim viewReport As New ReportPreviewForm(Report)
            viewReport.Show()
        End If
    End Sub

    Private Sub miDigitarqOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDigitarqOD.Click
        If Me.lvwFonds.SelectedItems.Count = 0 Then
            MsgBox("Tem que seleccionar um Fundo!", MsgBoxStyle.Information)
        Else
            Dim RepDSBuilder As New ReportDataSetBuilder
            Dim ReportDataSet As DigitarqODData = RepDSBuilder.GenerateDigitarqDOReportData(Me.lvwFonds.SelectedItems(0).Tag)

            Dim Report As New DigitarqDOReport
            Report.SetDataSource(ReportDataSet)
            Dim viewReport As New ReportPreviewForm(Report)
            viewReport.Show()
        End If
    End Sub

    'Menu Item Help
    Private Sub miAboutMPOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAboutMPOD.Click
        MsgBox(InfoMessage("Relations"), MsgBoxStyle.Exclamation)
    End Sub

#End Region

#Region "All Fonds listview"

    Private Sub lvwFonds_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwFonds.DoubleClick
        LoadTvwSelectedFond()
    End Sub

    Private Sub LoadTvwSelectedFond()
        If Me.lvwFonds.SelectedItems.Count > 0 Then
            Me.tvwSelectedFond.BringToFront()
            Me.lblNumberChecked.BringToFront()
            'Me.btnBack.Image = Image.FromFile(Application.StartupPath + "\..\Images\lvw.png")
            Me.btnCollapse.Enabled = True
            Me.btnCheckAll.Enabled = True
            Me.btnViewDescAssociations.Enabled = True
            Me.btnBack.Enabled = True
            Me.btnBack.Enabled = True
            Me.btnBack.Tag = "ViewFondList"



            tvwSelectedFond.Nodes.Clear()

            Dim FondID As Int64 = Me.lvwFonds.SelectedItems(0).Tag
            CTree.PopulateDigitarqTree(tvwSelectedFond, FondID)
            tvwSelectedFond.Nodes(0).Expand()

            Me.btnCollapse.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\m.png")
            Me.btnCollapse.Tag = "Expand"

            Me.btnCheckAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\select.png")
            Me.btnCheckAll.Tag = "Uncheck"

            Me.gbxFonds.Text = String.Format(InfoMessage("Association.gbxFondTree"))
            Me.tvwSelectedFond.Nodes(0).EnsureVisible()
            Me.CountTreeNodesChecked = 0
            WriteNumberTreeNodesChecked()
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        If Me.btnBack.Tag = "ViewFondList" Then
            ViewFondList()
        ElseIf Me.btnBack.Tag = "ViewStructure" Then
            LoadTvwSelectedFond()
        End If
    End Sub

    Private Sub ViewFondList()
        Me.lvwFonds.BringToFront()
        Me.txtSearch.BringToFront()

        'Me.btnBack.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\tvw.png")
        Me.btnCollapse.Enabled = False
        Me.btnCheckAll.Enabled = False
        Me.btnViewDescAssociations.Enabled = False
        Me.btnBack.Enabled = False
        Me.btnBack.Tag = "ViewStructure"
        Me.gbxFonds.Text = String.Format(InfoMessage("Association.gbxFonds"), Me.lvwFonds.Items.Count)
    End Sub



#End Region

#Region "Association"

    Private Sub btnAssociate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssociate.Click
        Dim alDescriptions As New ArrayList
        Dim alDO As New ArrayList
        Dim type As AssociationType
        Dim count As Integer

        If CountTreeNodesChecked = 0 And CountDOChecked = 0 Then
            Return
        End If

        If tvwSelectedFond.Nodes(0).Checked Then
            alDescriptions.Add(Me.tvwSelectedFond.Nodes(0).Tag)
        End If
        GetTreeNodesChecked(Me.tvwSelectedFond.Nodes(0), alDescriptions)

        If Me.btnBackDO.Tag = "ViewStructure" Then
            type = AssociationType.DigitalObject
            For Each item As ListViewItem In Me.lvwDigitalObjects.CheckedItems
                alDO.Add(item.Tag)
            Next
            count = MakeAssociationDrescriptionDO(alDescriptions, alDO, type)
            UpdateLvw(Me.lvwDigitalObjects, alDO)
        ElseIf Me.btnBackDO.Tag = "ViewDOList" Then
            type = AssociationType.DOFiles
            If tvwSelectedFond.Nodes(0).Checked Then
                alDO.Add(tvwDO.Nodes(0).Tag)
            End If
            GetTreeNodesChecked(tvwDO.Nodes(0), alDO)
            count = MakeAssociationDrescriptionDOFile(alDescriptions, alDO, type)
            UpdateTvw(Me.tvwDO.Nodes(0), alDO)
        End If

        UpdateTvw(Me.tvwSelectedFond.Nodes(0), alDescriptions)
        Me.lblAssociationType.Text = "Foram efectuadas " & count & " associações."
        Me.lblAssociationType.ForeColor = Color.Green
        'MsgBox("Foram efectuadas " & count & " associações.", MsgBoxStyle.Information)
    End Sub


    Private Function MakeAssociationDrescriptionDO(ByVal alDescriptions As ArrayList, ByVal alDO As ArrayList, ByVal type As AssociationType) As Integer
        Dim DigitalObjectID, ComponentID As Int64
        Dim index As Integer
        Dim res As Boolean
        Dim numAssociations As Integer = 0
        Dim FileID As Integer = -1

        pBar1.Visible = True
        pBar1.Minimum = 0
        pBar1.Maximum = max(CountTreeNodesChecked, CountDOChecked)
        pBar1.Value = 1
        pBar1.Step = 1

        '// if the number of digital objects then we match the first digitalObject with
        '// the first component selected, and so on, until we have all selected items processed
        If (CountTreeNodesChecked = CountDOChecked) Then
            For i As Integer = 0 To alDescriptions.Count - 1
                ComponentID = CType(alDescriptions(i), Int64)
                DigitalObjectID = Me.lvwDigitalObjects.CheckedItems(i).Tag
                res = database.InsertDaoGrp(ComponentID, DigitalObjectID, FileID, type)
                If res Then
                    numAssociations = numAssociations + 1
                End If
                pBar1.PerformStep()
            Next

            '// the second case is when we select just one DO and n found/serie
        ElseIf CountTreeNodesChecked > 1 And CountDOChecked = 1 Then
            DigitalObjectID = CType(alDO(0), Int64)
            For i As Integer = 0 To alDescriptions.Count - 1
                ComponentID = CType(alDescriptions(i), Int64)
                res = database.InsertDaoGrp(ComponentID, DigitalObjectID, FileID, type)
                If res Then
                    numAssociations = numAssociations + 1
                End If
                pBar1.PerformStep()
            Next

            '// the third case is when we select n DO and just one DO
        ElseIf CountTreeNodesChecked = 1 And CountDOChecked > 1 Then
            ComponentID = CType(alDescriptions(0), Int64)
            For i As Integer = 0 To alDO.Count - 1
                DigitalObjectID = CType(alDO(i), Int64)
                res = database.InsertDaoGrp(ComponentID, DigitalObjectID, FileID, type)
                If res Then
                    numAssociations = numAssociations + 1
                End If
                pBar1.PerformStep()
            Next
            '// we don't allow any other choices
        Else
            MsgBox(InfoMessage("Fail"), MsgBoxStyle.Exclamation)
        End If

        pBar1.Value = 0

        Return numAssociations
    End Function

    Private Function MakeAssociationDrescriptionDOFile(ByVal alDescriptions As ArrayList, ByVal alDOFiles As ArrayList, ByVal type As AssociationType) As Integer
        Dim ComponentID, DOFileID As Int64
        Dim DigitalObjectID As Integer = Me.tvwDO.Tag
        Dim res As Boolean
        Dim numAssociations As Integer = 0

        pBar1.Visible = True
        pBar1.Minimum = 0
        pBar1.Maximum = max(CountTreeNodesChecked, CountDOChecked)
        pBar1.Value = 1
        pBar1.Step = 1

        '// if the number of digital objects then we match the first digitalObject with
        '// the first component selected, and so on, until we have all selected items processed
        If (CountTreeNodesChecked = CountDOChecked) Then
            For i As Integer = 0 To alDescriptions.Count - 1
                ComponentID = CType(alDescriptions(i), Int64)
                DOFileID = CType(alDOFiles(i), Int64)

                res = database.InsertDaoGrp(ComponentID, DigitalObjectID, DOFileID, type)
                If res Then
                    numAssociations = numAssociations + 1
                End If
                pBar1.PerformStep()
            Next

            '// the second case is when we select just one DO and n found/serie
        ElseIf CountTreeNodesChecked > 1 And CountDOChecked = 1 Then
            DOFileID = CType(alDOFiles(0), Int64)
            For i As Integer = 0 To alDescriptions.Count - 1
                ComponentID = CType(alDescriptions(i), Int64)
                res = database.InsertDaoGrp(ComponentID, DigitalObjectID, DOFileID, type)
                If res Then
                    numAssociations = numAssociations + 1
                End If
                pBar1.PerformStep()
            Next

            '// the third case is when we select n DO and just one DO
        ElseIf CountTreeNodesChecked = 1 And CountDOChecked > 1 Then
            ComponentID = CType(alDescriptions(0), Int64)
            For i As Integer = 0 To alDOFiles.Count - 1
                DOFileID = CType(alDOFiles(i), Int64)
                res = database.InsertDaoGrp(ComponentID, DigitalObjectID, DOFileID, type)
                If res Then
                    numAssociations = numAssociations + 1
                End If
                pBar1.PerformStep()
            Next

            '// we don't allow any other choices
        Else
            MsgBox(InfoMessage("Fail"), MsgBoxStyle.Exclamation)
        End If

        pBar1.Value = 0

        Return numAssociations
    End Function

    Private Sub UpdateTvw(ByVal tn As TreeNode, ByVal al As ArrayList, Optional ByVal count As Integer = 0)
        Try
            For Each node As TreeNode In tn.Nodes
                If al.Contains(node.Tag) Then
                    node.ForeColor = Color.Blue
                    count += 1
                    node.Checked = False
                End If

                If count = al.Count Then
                    Return
                End If

                If node.GetNodeCount(False) > 0 Then
                    UpdateTvw(node, al)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub UpdateLvw(ByVal lvw As ListView, ByVal al As ArrayList, Optional ByVal count As Integer = 0)
        Try
            For Each lvi As ListViewItem In lvw.Items
                If al.Contains(lvi.Tag) Then
                    lvi.ForeColor = Color.Blue
                    count += 1
                    lvi.Checked = False
                End If

                If count = al.Count Then
                    Return
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function max(ByVal fst As Integer, ByVal snd As Integer) As Integer
        Dim res As Integer
        If fst >= snd Then
            res = fst
        Else
            res = snd
        End If
        Return res
    End Function

    Public Sub GetTreeNodesChecked(ByVal tnParent As TreeNode, ByVal al As ArrayList)
        Try
            For Each node As TreeNode In tnParent.Nodes
                If node.Checked Then
                    al.Add(node.Tag)
                End If

                If node.GetNodeCount(False) > 0 Then
                    GetTreeNodesChecked(node, al)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region "Descriptions->DO"

    Private Sub AssociationDescrDO()
        If Not tvwSelectedFond.SelectedNode Is Nothing Then
            Dim node As TreeNode = tvwSelectedFond.SelectedNode
            Dim form As New AssocComponentForm(node.Text, node.Tag)
            form.ShowDialog()

            If form.DeletedItem Then
                GetChildren(node.Parent)
                LoadDigitalObjects()
            End If
        End If
    End Sub

    Private Sub btnViewDescAssociations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDescAssociations.Click
        AssociationDescrDO()
    End Sub

    Private Sub FondTree_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvwSelectedFond.DoubleClick
        AssociationDescrDO()
    End Sub

#End Region

#Region "DO->Descriptions"

    Private Sub AssociationDODescr()
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            Dim DOName As String = Me.lvwDigitalObjects.SelectedItems(0).Text
            Dim DOID As Int64 = Me.lvwDigitalObjects.SelectedItems(0).Tag
            Dim FileID As Int64
            Dim FileName As String
            If Me.btnBackDO.Tag = "ViewStructure" Then
                FileID = -1
                Dim form As New AssocDOForm(DOName, DOID, FileName, FileID)
                form.ShowDialog()
                If form.DeletedItem Then
                    LoadDigitalObjects()
                End If
            ElseIf Me.btnBackDO.Tag = "ViewDOList" Then
                If Me.tvwDO.SelectedNode Is Nothing Then
                    Return
                Else
                    FileID = Me.tvwDO.SelectedNode.Tag
                    FileName = Me.tvwDO.SelectedNode.Text
                    Dim form As New AssocDOForm(DOName, DOID, FileName, FileID)
                    form.ShowDialog()
                    If form.DeletedItem Then
                        LoadDigitalObjects()
                        ViewStructure(DOID)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnViewDOAssociations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDOAssociations.Click
        AssociationDODescr()
    End Sub



    Private Sub lvwDigitalObjects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwDigitalObjects.DoubleClick
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            ViewStructure(Me.lvwDigitalObjects.SelectedItems(0).Tag)
        End If
    End Sub

#End Region

#Region "Select DO"

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If Me.btnBackDO.Tag = "ViewStructure" Then
            If Me.btnSelectAll.Tag = "Select" Then
                For i As Integer = 0 To Me.lvwDigitalObjects.Items.Count - 1
                    Me.lvwDigitalObjects.Items(i).Checked = False
                Next
                CountDOChecked = 0
            ElseIf Me.btnSelectAll.Tag = "Unselect" Then
                For i As Integer = 0 To Me.lvwDigitalObjects.Items.Count - 1
                    Me.lvwDigitalObjects.Items(i).Checked = True
                Next
            End If
        ElseIf Me.btnBackDO.Tag = "ViewDOList" Then
            If Me.tvwDO.GetNodeCount(False) > 0 Then
                If Me.btnSelectAll.Tag = "Select" Then
                    If Me.tvwDO.Nodes(0).Checked = True Then
                        Me.tvwDO.Nodes(0).Checked = False
                    End If
                    CheckTreeNodes(Me.tvwDO.Nodes(0), False)
                ElseIf Me.btnSelectAll.Tag = "Unselect" Then
                    If Me.tvwDO.Nodes(0).Checked = False Then
                        Me.tvwDO.Nodes(0).Checked = True
                    End If
                    CheckTreeNodes(Me.tvwDO.Nodes(0), True)
                End If
            End If
        End If
    End Sub

    Private Sub lvwDigitalObjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDigitalObjects.SelectedIndexChanged

        If Me.btnOpenDO.Tag = "Opened" And Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            Dim intDigitalObjectID As Int64 = Me.lvwDigitalObjects.SelectedItems(0).Tag
            Dim FirstImageName As String = database.SelectFirstFileName(intDigitalObjectID)
            LoadDOImage(FirstImageName, intDigitalObjectID)
        End If
    End Sub

    Private Sub lvwDigitalObjects_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvwDigitalObjects.ItemCheck

        If e.CurrentValue = CheckState.Checked Then
            CountDOChecked = CountDOChecked - 1
        ElseIf e.CurrentValue = CheckState.Unchecked Then
            CountDOChecked = CountDOChecked + 1
        End If
        WriteNumberDOChecked()
        WriteAssociationType()

        If CountDOChecked = Me.lvwDigitalObjects.Items.Count Then
            Me.btnSelectAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\unselect.png")
            Me.btnSelectAll.Tag = "Select"
            Me.btnSelectAll.ButtonText = "Desseleccionar"

        ElseIf CountDOChecked <= Me.lvwDigitalObjects.Items.Count Then
            Me.btnSelectAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\select.png")
            Me.btnSelectAll.Tag = "Unselect"
            Me.btnSelectAll.ButtonText = "Seleccionar"
        End If
    End Sub

    Private Sub WriteNumberDOChecked()
        Me.lblNumberSelected.Text = String.Format(InfoMessage("Association.lblNumberSelected"), CStr(CountDOChecked))
    End Sub

    Private Sub WriteAssociationType()

        If CountTreeNodesChecked = 0 And CountDOChecked = 0 Then
            Me.lblAssociationType.Text = ""
            Me.btnAssociate.Enabled = False
        ElseIf CountTreeNodesChecked = CountDOChecked Then
            Me.lblAssociationType.Text = String.Format(InfoMessage("AssociationType1"), CStr(CountDOChecked))
            Me.lblAssociationType.ForeColor = Color.Blue
            Me.btnAssociate.Enabled = True
        ElseIf CountTreeNodesChecked = 1 And CountDOChecked > 1 Then
            Me.lblAssociationType.Text = String.Format(InfoMessage("AssociationType2"), CStr(CountDOChecked))
            Me.lblAssociationType.ForeColor = Color.Blue
            Me.btnAssociate.Enabled = True
        ElseIf CountTreeNodesChecked > 1 And CountDOChecked = 1 Then
            Me.lblAssociationType.Text = String.Format(InfoMessage("AssociationType3"), CStr(CountTreeNodesChecked))
            Me.lblAssociationType.ForeColor = Color.Blue
            Me.btnAssociate.Enabled = True
        Else
            Me.lblAssociationType.Text = InfoMessage("AssociationType4")
            Me.lblAssociationType.ForeColor = Color.Red
            Me.btnAssociate.Enabled = False
        End If
    End Sub

    Private Sub lvwDigitalObjects_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwDigitalObjects.Click
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = Me.lvwDigitalObjects.SelectedItems(0)
            Dim color As Color = item.ForeColor
            If color.Equals(color.Black) Then
                Me.btnViewDOAssociations.Enabled = False
            Else
                Me.btnViewDOAssociations.Enabled = True
            End If
        End If
    End Sub

#End Region

#Region "Check, select and collapse fond tree"

    Private Sub tvwSelectedFond_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwSelectedFond.AfterCheck
        If e.Node.Checked Then
            CountTreeNodesChecked = CountTreeNodesChecked + 1
        Else
            CountTreeNodesChecked = CountTreeNodesChecked - 1
        End If
        If CountTreeNodesChecked = tvwSelectedFond.GetNodeCount(True) Then
            Me.btnCheckAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\unselect.png")
            Me.btnCheckAll.Tag = "Check"
            Me.btnCheckAll.ButtonText = "Desseleccionar"

        ElseIf CountTreeNodesChecked <= tvwSelectedFond.GetNodeCount(True) Then
            Me.btnCheckAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\select.png")
            Me.btnCheckAll.Tag = "Uncheck"
            Me.btnCheckAll.ButtonText = "Seleccionar"

        End If
        WriteNumberTreeNodesChecked()
        WriteAssociationType()
    End Sub

    Private Sub btnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAll.Click
        If tvwSelectedFond.GetNodeCount(False) > 0 Then
            If Me.btnCheckAll.Tag = "Check" Then
                If tvwSelectedFond.Nodes(0).Checked = True Then
                    tvwSelectedFond.Nodes(0).Checked = False
                End If
                CheckTreeNodes(Me.tvwSelectedFond.Nodes(0), False)
                CountTreeNodesChecked = 0
            ElseIf Me.btnCheckAll.Tag = "Uncheck" Then
                Me.tvwSelectedFond.ExpandAll()
                If tvwSelectedFond.Nodes(0).Checked = False Then
                    tvwSelectedFond.Nodes(0).Checked = True
                End If
                CheckTreeNodes(Me.tvwSelectedFond.Nodes(0), True)
            End If
        End If
        WriteNumberTreeNodesChecked()
    End Sub

    Private Sub CheckTreeNodes(ByVal tnParent As TreeNode, ByVal check As Boolean)
        Try
            For Each node As TreeNode In tnParent.Nodes
                If check <> node.Checked Then
                    node.Checked = check
                End If
                If node.GetNodeCount(False) > 0 Then
                    CheckTreeNodes(node, check)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function WriteNumberTreeNodesChecked() As Integer
        Me.lblNumberChecked.Text = String.Format(InfoMessage("Association.lblNumberChecked"), CStr(CountTreeNodesChecked))
    End Function

    Private Sub btnCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollapse.Click
        If Me.btnCollapse.Tag = "Expand" Then
            Me.tvwSelectedFond.CollapseAll()
        ElseIf Me.btnCollapse.Tag = "Collapse" Then
            Me.tvwSelectedFond.ExpandAll()
        End If
    End Sub

    Private Sub FondTree_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwSelectedFond.AfterCollapse
        If e.Node Is tvwSelectedFond.Nodes(0) And Me.btnCollapse.Tag = "Expand" Then
            Me.btnCollapse.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\p.png")
            Me.btnCollapse.Tag = "Collapse"
            Me.btnCollapse.ButtonText = "Expandir"
        End If
    End Sub

    Private Sub FondTree_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwSelectedFond.AfterExpand
        If e.Node Is tvwSelectedFond.Nodes(0) And Me.btnCollapse.Tag = "Collapse" Then
            Me.btnCollapse.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\m.png")
            Me.btnCollapse.Tag = "Expand"
            Me.btnCollapse.ButtonText = "Colapsar"
        End If
        GetChildren(e.Node)
    End Sub

    Private Sub GetChildren(ByVal tn As TreeNode)
        tn.Nodes.Clear()
        CTree.GetChildren(tn)
        tn.Expand()
    End Sub

    Private Sub tvwSelectedFond_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvwSelectedFond.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim tn As TreeNode = Me.tvwSelectedFond.GetNodeAt(e.X, e.Y)
            If Not tn Is Nothing Then
                Me.tvwSelectedFond.SelectedNode = tn
            End If
        End If
    End Sub

    Private Sub tvwSelectedFond_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwSelectedFond.AfterSelect
        If Not tvwSelectedFond.SelectedNode Is Nothing Then
            Dim node As TreeNode = tvwSelectedFond.SelectedNode
            Dim color As Color = node.ForeColor
            If color.Equals(color.Black) Then
                Me.btnViewDescAssociations.Enabled = False
            Else
                Me.btnViewDescAssociations.Enabled = True
            End If
        End If
    End Sub

#End Region

#Region "DO viewer"

    Private Sub btnImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImages.Click
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            Dim tv As New DOStructureForm(Me.lvwDigitalObjects.SelectedItems(0).Tag, Me.lvwDigitalObjects.SelectedItems(0).Text, False)
            Cursor.Current = System.Windows.Forms.Cursors.AppStarting
            tv.Text = "Estrutura Objecto Digital"
            tv.ShowDialog(Me)
        End If
    End Sub

#End Region

#Region "Context menu Selected fond"

    Private Sub miCheckChild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCheckChild.Click
        Dim check As Boolean = True
        For Each tn As TreeNode In Me.tvwSelectedFond.SelectedNode.Nodes
            If tn.Checked = True Then
                check = False
                Exit For
            End If
        Next
        For Each tn As TreeNode In Me.tvwSelectedFond.SelectedNode.Nodes
            If check <> tn.Checked Then
                tn.Checked = check
            End If
        Next
    End Sub

    Private Sub miViewAssociations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miViewAssociations.Click
        AssociationDescrDO()
    End Sub

#End Region

#Region "View original names"

    Private Sub btnOpenOriginalNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenOriginalNames.Click
        If Me.btnOpenOriginalNames.Tag = "Closed" Then
            OpenOriginalNames()
        ElseIf Me.btnOpenOriginalNames.Tag = "Opened" Then
            CloseOriginalNames()
        End If
    End Sub

    Private Sub OpenOriginalNames()
        Me.gbxDigitalObjects.Width = Me.gbxDigitalObjects.Width + 300
        Me.lvwDigitalObjects.Width = Me.lvwDigitalObjects.Width + 300
        Me.lvwDigitalObjects.Columns(1).Width = 300
        Me.Width = Me.Width + 300
        Me.btnOpenOriginalNames.Text = "<"
        Me.btnOpenOriginalNames.Tag = "Opened"
        Me.gbxAssociate.Width = Me.gbxAssociate.Width + 300
        If Me.Location.X - 150 > 0 Then
            Me.Location = New Point(Me.Location.X - 150, Me.Location.Y)
        End If
        Me.btnOpenDO.Visible = False
    End Sub

    Private Sub CloseOriginalNames()
        Me.gbxDigitalObjects.Width = Me.gbxDigitalObjects.Width - 300
        Me.lvwDigitalObjects.Width = Me.lvwDigitalObjects.Width - 300
        Me.gbxAssociate.Width = Me.gbxAssociate.Width - 300
        Me.lvwDigitalObjects.Columns(1).Width = 0
        Me.Width = Me.Width - 300
        Me.btnOpenOriginalNames.Text = ">"
        Me.btnOpenOriginalNames.Tag = "Closed"
        Me.btnOpenDO.Visible = True
    End Sub

#End Region

#Region "View DOFile"

    Private Sub btnOpenDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenDO.Click
        If Me.btnOpenDO.Tag = "Closed" Then
            OpenDOImage()
        ElseIf Me.btnOpenDO.Tag = "Opened" Then
            CloseDOImage()
        End If
    End Sub

    Private Sub OpenDOImage()
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            pb.Location = New Point(Me.lvwDigitalObjects.Location.X + Me.lvwDigitalObjects.Width + 10, Me.lvwDigitalObjects.Location.Y)
            pb.BorderStyle = BorderStyle.FixedSingle

            Me.gbxDigitalObjects.Controls.Add(pb)
            If Me.btnBackDO.Tag = "ViewStructure" Then
                Dim intDigitalObjectID As Int64 = Me.lvwDigitalObjects.SelectedItems(0).Tag
                Dim FirstImageName As String = database.SelectFirstFileName(intDigitalObjectID)
                LoadDOImage(FirstImageName, intDigitalObjectID)
            ElseIf Me.btnBackDO.Tag = "ViewDOList" Then
                If Not Me.tvwDO.SelectedNode Is Nothing Then
                    Dim intDigitalObjectID As Int64 = Me.lvwDigitalObjects.SelectedItems(0).Tag
                    Dim strImageName As String = Me.tvwDO.SelectedNode.Text
                    LoadDOImage(strImageName, intDigitalObjectID)
                End If
            End If


            Me.gbxDigitalObjects.Width = Me.gbxDigitalObjects.Width + 300
            Me.gbxAssociate.Width = Me.gbxAssociate.Width + 300
            Me.Width = Me.Width + 300
            Me.btnOpenDO.Text = "<"
            Me.btnOpenDO.Tag = "Opened"
            If Me.Location.X - 150 > 0 Then
                Me.Location = New Point(Me.Location.X - 150, Me.Location.Y)
            End If
            Me.btnOpenOriginalNames.Visible = False
        End If
    End Sub

    Private Sub CloseDOImage()
        Me.gbxDigitalObjects.Width = Me.gbxDigitalObjects.Width - 300
        Me.gbxAssociate.Width = Me.gbxAssociate.Width - 300
        pb.Width = 0
        Me.Width = Me.Width - 300
        Me.btnOpenDO.Text = ">"
        Me.btnOpenDO.Tag = "Closed"
        Me.btnOpenOriginalNames.Visible = True
    End Sub

    Private Sub LoadDOImage(ByVal strImageName As String, ByVal intDigitalObjectID As Int64)
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then

            'pb.Image = database.getImage(strImageName, intDigitalObjectID)
            Dim image As System.Drawing.Image = database.getImage(strImageName, intDigitalObjectID)
            If Not image Is Nothing Then
                Dim imgHeigth As Integer = image.Height
                Dim imgWidth As Integer = image.Width
                image = image.GetThumbnailImage(285, ((285 * imgHeigth) / imgWidth), Nothing, IntPtr.Zero)
                pb.Image = image

                'pb.Image.Width = 285
                'pb.Image.Height = (285 * imgHeigth) / imgWidth

                pb.Visible = True
                pb.Width = pb.Image.Width + 5
                pb.Height = pb.Image.Height + 5
            Else
                pb.Visible = False
            End If
        End If
    End Sub

#End Region

#Region "DO <-> DOFiles"

    Private Sub miDOViewStructure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDOViewStructure.Click
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            ViewStructure(Me.lvwDigitalObjects.SelectedItems(0).Tag)
        End If
    End Sub

    Private Sub miDOFileBackDOList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDOFileBackDOList.Click
        ViewDOList()
    End Sub

    Private Sub bttnDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.btnBackDO.Tag = "ViewDOList" Then
            ViewDOList()
        ElseIf Me.btnBackDO.Tag = "ViewStructure" Then
            If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
                ViewStructure(Me.lvwDigitalObjects.SelectedItems(0).Tag)
            End If
        End If
    End Sub

    Private Sub btnBackDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackDO.Click
        If Me.btnBackDO.Tag = "ViewDOList" Then
            ViewDOList()
        ElseIf Me.btnBackDO.Tag = "ViewStructure" Then
            If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
                ViewStructure(Me.lvwDigitalObjects.SelectedItems(0).Tag)
            End If
        End If
    End Sub

    Private Sub ViewStructure(ByVal DigitalObjectID As Int64)

        Me.lvwDigitalObjects.SendToBack()
        Me.tvwDO.BringToFront()

        Dim DOTv As New DOTreeView(Me.tvwDO, DigitalObjectID)
        DOTv.LoadTreeDO()
        Me.tvwDO.Tag = DigitalObjectID
        Me.tvwDO.Nodes(0).EnsureVisible()

        'Me.btnBackDO.Image = Image.FromFile(Application.StartupPath + "\..\Images\lvw.png")
        Me.btnBackDO.Enabled = True
        Me.btnBackDO.Tag = "ViewDOList"

        NumOfChildNodes = CountChildNodes(Me.tvwDO.Nodes(0))
        CountDOChecked = 0
        WriteNumberDOChecked()
        WriteNumberDOFiles()
        WriteAssociationType()
    End Sub

    Private Sub ViewDOList()
        Me.lvwDigitalObjects.BringToFront()
        Me.tvwDO.SendToBack()

        'Me.btnBackDO.Image = Image.FromFile(Application.StartupPath + "\..\Images\tvw.png")
        Me.btnBackDO.Enabled = False
        Me.btnBackDO.Tag = "ViewStructure"

        For i As Integer = 0 To Me.lvwDigitalObjects.Items.Count - 1
            Me.lvwDigitalObjects.Items(i).Checked = False
        Next
        CountDOChecked = 0
        WriteNumberDOChecked()
        WriteNumberDO()
        WriteAssociationType()
    End Sub

    Private Sub miDOFileAssociations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDOFileAssociations.Click
        AssociationDODescr()
    End Sub

    Private Sub miDOAssociations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDOAssociations.Click
        AssociationDODescr()
    End Sub

    Private Sub lvwDigitalObjects_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwDigitalObjects.MouseUp
        If e.Button = MouseButtons.Right Or e.Button = MouseButtons.Left Then
            Dim lvi As ListViewItem = Me.lvwDigitalObjects.GetItemAt(e.X, e.Y)
            If Not lvi Is Nothing Then
                Me.lvwDigitalObjects.Items(lvi.Index).Selected = True
            End If
        End If
    End Sub

    Private Sub tvwDO_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvwDO.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim tn As TreeNode = Me.tvwDO.GetNodeAt(e.X, e.Y)
            If Not tn Is Nothing Then
                Me.tvwDO.SelectedNode = tn
            End If
        End If
    End Sub

    Private Sub tvwDO_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDO.AfterSelect
        e.Node.SelectedImageIndex = e.Node.ImageIndex
        If Me.btnOpenDO.Tag = "Opened" Then
            Dim intDigitalObjectID As Int64 = Me.tvwDO.Tag
            Dim strImageName As String = Me.tvwDO.SelectedNode.Text
            LoadDOImage(strImageName, intDigitalObjectID)
        End If
        Dim color As Color = e.Node.ForeColor
        If color.Equals(color.Blue) Then
            Me.btnViewDOAssociations.Enabled = True
        Else
            Me.btnViewDOAssociations.Enabled = False
        End If
    End Sub

    Private Sub tvwDO_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDO.AfterCheck

        If e.Node.Checked Then
            CountDOChecked = CountDOChecked + 1
        ElseIf Not e.Node.Checked Then
            CountDOChecked = CountDOChecked - 1
        End If
        WriteNumberDOChecked()
        WriteAssociationType()

        If CountDOChecked = NumOfChildNodes Then
            Me.btnSelectAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\unselect.png")
            Me.btnSelectAll.Tag = "Select"
            Me.btnSelectAll.ButtonText = "Desseleccionar"

        ElseIf CountDOChecked <= Me.tvwDO.GetNodeCount(True) Then
            Me.btnSelectAll.ButtonImage = Image.FromFile(Application.StartupPath + "\..\Images\select.png")
            Me.btnSelectAll.Tag = "Unselect"
            Me.btnSelectAll.ButtonText = "Seleccionar"
        End If
    End Sub

    Private Sub tvwDO_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwDO.BeforeCheck
        If e.Node.Tag Is Nothing Then
            e.Cancel = True
        End If
    End Sub

    Private Function CountChildNodes(ByVal tnParent As TreeNode, Optional ByVal count As Integer = 0) As Integer
        Dim NumOfChildNodes As Integer = 0
        For Each tn As TreeNode In tnParent.Nodes
            If Not tn.Tag Is Nothing Then
                NumOfChildNodes += 1
            End If
            If tn.GetNodeCount(False) > 0 Then
                NumOfChildNodes += CountChildNodes(tn, NumOfChildNodes)
            End If
        Next
        Return NumOfChildNodes
    End Function

#End Region

#Region "ToolTips"

    Private Sub btnCollapse_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollapse.MouseHover
        If Me.btnCollapse.Tag = "Expand" Then
            Me.ttGeneral.SetToolTip(Me.btnCollapse, InfoMessage("Association.ttCollapseAll"))
        Else
            Me.ttGeneral.SetToolTip(Me.btnCollapse, InfoMessage("Association.ttExpandAll"))
        End If
    End Sub

    Private Sub btnAssociate_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssociate.MouseHover
        Me.ttGeneral.SetToolTip(Me.btnAssociate, InfoMessage("Association.ttAssociate"))
    End Sub

    Private Sub btnOpenDO_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpenDO.MouseHover
        Me.ttGeneral.SetToolTip(Me.btnOpenDO, InfoMessage("Association.ttOpenDO"))
    End Sub

    Private Sub btnOpenOriginalNames_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpenOriginalNames.MouseHover
        Me.ttGeneral.SetToolTip(Me.btnOpenOriginalNames, InfoMessage("Association.ttOriginalNames"))
    End Sub

    Private Sub bttnCheckAll_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAll.MouseHover
        If Me.btnCheckAll.Tag = "Check" Then
            Me.ttGeneral.SetToolTip(Me.btnCheckAll, InfoMessage("Association.ttUnSelectAll"))
        Else
            Me.ttGeneral.SetToolTip(Me.btnCheckAll, InfoMessage("Association.ttSelectAll"))
        End If
    End Sub

    Private Sub bttnSelectAll_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.MouseHover
        If Me.btnSelectAll.Tag = "Select" Then
            Me.ttGeneral.SetToolTip(Me.btnSelectAll, InfoMessage("Association.ttUnSelectAll"))
        Else
            Me.ttGeneral.SetToolTip(Me.btnSelectAll, InfoMessage("Association.ttSelectAll"))
        End If
    End Sub

    Private Sub btnViewDescAssociations_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDescAssociations.MouseHover
        Me.ttGeneral.SetToolTip(Me.btnViewDescAssociations, InfoMessage("Association.ttAssociations"))
    End Sub

    Private Sub btnViewDOAssociations_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDOAssociations.MouseHover
        Me.ttGeneral.SetToolTip(Me.btnViewDOAssociations, InfoMessage("Association.ttAssociations"))
    End Sub

    Private Sub btnBackDO_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackDO.MouseHover
        If Me.btnBackDO.Tag = "ViewStructure" Then
            Me.ttGeneral.SetToolTip(Me.btnBackDO, InfoMessage("Association.ttViewStructure"))
        Else
            Me.ttGeneral.SetToolTip(Me.btnBackDO, InfoMessage("Association.ttViewDOList"))
        End If
    End Sub

    Private Sub btnImages_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImages.MouseHover
        Me.ttGeneral.SetToolTip(Me.btnImages, InfoMessage("Association.ttViewDO"))
    End Sub

#End Region


End Class
