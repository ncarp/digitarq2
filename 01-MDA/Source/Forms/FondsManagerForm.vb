
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

Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration
Imports System.IO
Imports System.Xml.Xsl
Imports System.Xml
Imports System.Xml.XPath


Public Class FondsManagerForm
    Inherits System.Windows.Forms.Form

#Region "Private Properties"
    Private mySelectedFonds As LazyNode = Nothing
    Private myProcessInfoName As String = "admin"
    Private myHideButtons As Boolean = False
    Private myProgramState As ProgramState



    ReadOnly Property SelectedFonds() As LazyNode
        Get
            Return mySelectedFonds
        End Get
    End Property

#End Region


#Region " Windows Form Designer generated code "

    Private Sub New(ByVal ProcessInfoName As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        myProcessInfoName = ProcessInfoName
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
    Friend WithEvents btnCloseFondsManagerForm As System.Windows.Forms.Button
    Friend WithEvents btnOpenFonds As System.Windows.Forms.Button
    Friend WithEvents btnNewFonds As System.Windows.Forms.Button
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents chUnitId As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUnitTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUnitDateInitial As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUnitDateFinal As System.Windows.Forms.ColumnHeader
    Friend WithEvents chOtherLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents FondsIcon As System.Windows.Forms.ImageList
    Friend WithEvents chVisible As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRemoveFonds As System.Windows.Forms.Button
    Friend WithEvents MainMenuFonds As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemReports As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFondsGuide As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemInventory As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemUIInventory As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCatalogue As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemUIList As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSeriesList As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemImportExport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemImportEAD As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExportEAD As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExportCALM As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemImport As System.Windows.Forms.MenuItem
    Friend WithEvents txtFindFonds As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents MenuItemClassificationPlanReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemPhysLocReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemControlAccessReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAllControlAccess As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemTools As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemUpdateCompleteUnitId As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemInstalationUnitsBySeriesReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAuthorsList As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemElementCounter As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCountElements As System.Windows.Forms.MenuItem
    Friend WithEvents btnFindFonds As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FondsManagerForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnFindFonds = New mkccontrols.windows.forms.control.mkc_Button
        Me.lblSearch = New System.Windows.Forms.Label
        Me.txtFindFonds = New System.Windows.Forms.TextBox
        Me.btnRemoveFonds = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCloseFondsManagerForm = New System.Windows.Forms.Button
        Me.btnOpenFonds = New System.Windows.Forms.Button
        Me.btnNewFonds = New System.Windows.Forms.Button
        Me.ListView = New System.Windows.Forms.ListView
        Me.chOtherLevel = New System.Windows.Forms.ColumnHeader
        Me.chUnitId = New System.Windows.Forms.ColumnHeader
        Me.chUnitTitle = New System.Windows.Forms.ColumnHeader
        Me.chUnitDateInitial = New System.Windows.Forms.ColumnHeader
        Me.chUnitDateFinal = New System.Windows.Forms.ColumnHeader
        Me.chVisible = New System.Windows.Forms.ColumnHeader
        Me.FondsIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.MainMenuFonds = New System.Windows.Forms.MainMenu
        Me.MenuItemImportExport = New System.Windows.Forms.MenuItem
        Me.MenuItemImport = New System.Windows.Forms.MenuItem
        Me.MenuItemImportEAD = New System.Windows.Forms.MenuItem
        Me.MenuItemExport = New System.Windows.Forms.MenuItem
        Me.MenuItemExportEAD = New System.Windows.Forms.MenuItem
        Me.MenuItemExportCALM = New System.Windows.Forms.MenuItem
        Me.MenuItemTools = New System.Windows.Forms.MenuItem
        Me.MenuItemUpdateCompleteUnitId = New System.Windows.Forms.MenuItem
        Me.MenuItemElementCounter = New System.Windows.Forms.MenuItem
        Me.MenuItemReports = New System.Windows.Forms.MenuItem
        Me.MenuItemFondsGuide = New System.Windows.Forms.MenuItem
        Me.MenuItemInventory = New System.Windows.Forms.MenuItem
        Me.MenuItemUIInventory = New System.Windows.Forms.MenuItem
        Me.MenuItemCatalogue = New System.Windows.Forms.MenuItem
        Me.MenuItemInstalationUnitsBySeriesReport = New System.Windows.Forms.MenuItem
        Me.MenuItemUIList = New System.Windows.Forms.MenuItem
        Me.MenuItemSeriesList = New System.Windows.Forms.MenuItem
        Me.MenuItemClassificationPlanReport = New System.Windows.Forms.MenuItem
        Me.MenuItemControlAccessReport = New System.Windows.Forms.MenuItem
        Me.MenuItemAllControlAccess = New System.Windows.Forms.MenuItem
        Me.MenuItemPhysLocReport = New System.Windows.Forms.MenuItem
        Me.MenuItemAuthorsList = New System.Windows.Forms.MenuItem
        Me.MenuItemCountElements = New System.Windows.Forms.MenuItem
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnFindFonds)
        Me.Panel2.Controls.Add(Me.lblSearch)
        Me.Panel2.Controls.Add(Me.txtFindFonds)
        Me.Panel2.Controls.Add(Me.btnRemoveFonds)
        Me.Panel2.Controls.Add(Me.btnCloseFondsManagerForm)
        Me.Panel2.Controls.Add(Me.btnOpenFonds)
        Me.Panel2.Controls.Add(Me.btnNewFonds)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 249)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(672, 40)
        Me.Panel2.TabIndex = 4
        '
        'btnFindFonds
        '
        Me.btnFindFonds.BorderColor = System.Drawing.SystemColors.Control
        Me.btnFindFonds.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindFonds.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFindFonds.ButtonImage = CType(resources.GetObject("btnFindFonds.ButtonImage"), System.Drawing.Image)
        Me.btnFindFonds.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnFindFonds.ButtonShowShadow = True
        Me.btnFindFonds.ButtonText = ""
        Me.btnFindFonds.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFindFonds.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnFindFonds.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnFindFonds.Location = New System.Drawing.Point(424, 9)
        Me.btnFindFonds.Name = "btnFindFonds"
        Me.btnFindFonds.Size = New System.Drawing.Size(22, 22)
        Me.btnFindFonds.TabIndex = 9
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(200, 10)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(62, 20)
        Me.lblSearch.TabIndex = 8
        Me.lblSearch.Text = CType(configurationAppSettings.GetValue("FondsManager.lblSearch.Text", GetType(System.String)), String)
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFindFonds
        '
        Me.txtFindFonds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFindFonds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFindFonds.Location = New System.Drawing.Point(264, 10)
        Me.txtFindFonds.Name = "txtFindFonds"
        Me.txtFindFonds.Size = New System.Drawing.Size(152, 20)
        Me.txtFindFonds.TabIndex = 1
        Me.txtFindFonds.Text = ""
        '
        'btnRemoveFonds
        '
        Me.btnRemoveFonds.BackColor = System.Drawing.Color.White
        Me.btnRemoveFonds.Enabled = False
        Me.btnRemoveFonds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveFonds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveFonds.ImageIndex = 1
        Me.btnRemoveFonds.ImageList = Me.imglButtons
        Me.btnRemoveFonds.Location = New System.Drawing.Point(95, 8)
        Me.btnRemoveFonds.Name = "btnRemoveFonds"
        Me.btnRemoveFonds.Size = New System.Drawing.Size(80, 25)
        Me.btnRemoveFonds.TabIndex = 3
        Me.btnRemoveFonds.Text = CType(configurationAppSettings.GetValue("btnRemoveFonds.Text", GetType(System.String)), String)
        Me.btnRemoveFonds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCloseFondsManagerForm
        '
        Me.btnCloseFondsManagerForm.BackColor = System.Drawing.Color.White
        Me.btnCloseFondsManagerForm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseFondsManagerForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseFondsManagerForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCloseFondsManagerForm.ImageIndex = 5
        Me.btnCloseFondsManagerForm.ImageList = Me.imglButtons
        Me.btnCloseFondsManagerForm.Location = New System.Drawing.Point(584, 8)
        Me.btnCloseFondsManagerForm.Name = "btnCloseFondsManagerForm"
        Me.btnCloseFondsManagerForm.Size = New System.Drawing.Size(75, 25)
        Me.btnCloseFondsManagerForm.TabIndex = 5
        Me.btnCloseFondsManagerForm.Text = CType(configurationAppSettings.GetValue("btnCloseFondsManagerForm.Text", GetType(System.String)), String)
        Me.btnCloseFondsManagerForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOpenFonds
        '
        Me.btnOpenFonds.BackColor = System.Drawing.Color.White
        Me.btnOpenFonds.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOpenFonds.Enabled = False
        Me.btnOpenFonds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenFonds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpenFonds.ImageIndex = 7
        Me.btnOpenFonds.ImageList = Me.imglButtons
        Me.btnOpenFonds.Location = New System.Drawing.Point(502, 8)
        Me.btnOpenFonds.Name = "btnOpenFonds"
        Me.btnOpenFonds.Size = New System.Drawing.Size(75, 25)
        Me.btnOpenFonds.TabIndex = 4
        Me.btnOpenFonds.Text = CType(configurationAppSettings.GetValue("btnOpenFonds.Text", GetType(System.String)), String)
        Me.btnOpenFonds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNewFonds
        '
        Me.btnNewFonds.BackColor = System.Drawing.Color.White
        Me.btnNewFonds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewFonds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewFonds.ImageIndex = 0
        Me.btnNewFonds.ImageList = Me.imglButtons
        Me.btnNewFonds.Location = New System.Drawing.Point(8, 8)
        Me.btnNewFonds.Name = "btnNewFonds"
        Me.btnNewFonds.Size = New System.Drawing.Size(80, 25)
        Me.btnNewFonds.TabIndex = 2
        Me.btnNewFonds.Text = CType(configurationAppSettings.GetValue("btnNewFonds.Text", GetType(System.String)), String)
        Me.btnNewFonds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ListView
        '
        Me.ListView.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.ListView.AllowColumnReorder = True
        Me.ListView.AutoArrange = False
        Me.ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chOtherLevel, Me.chUnitId, Me.chUnitTitle, Me.chUnitDateInitial, Me.chUnitDateFinal, Me.chVisible})
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.FullRowSelect = True
        Me.ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView.LabelWrap = False
        Me.ListView.Location = New System.Drawing.Point(0, 0)
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(672, 249)
        Me.ListView.SmallImageList = Me.FondsIcon
        Me.ListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView.TabIndex = 0
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'chOtherLevel
        '
        Me.chOtherLevel.Text = ""
        Me.chOtherLevel.Width = 20
        '
        'chUnitId
        '
        Me.chUnitId.Text = "Referência"
        Me.chUnitId.Width = 127
        '
        'chUnitTitle
        '
        Me.chUnitTitle.Text = "Título"
        Me.chUnitTitle.Width = 280
        '
        'chUnitDateInitial
        '
        Me.chUnitDateInitial.Text = "Data Inicial"
        Me.chUnitDateInitial.Width = 87
        '
        'chUnitDateFinal
        '
        Me.chUnitDateFinal.Text = "Data Final"
        Me.chUnitDateFinal.Width = 84
        '
        'chVisible
        '
        Me.chVisible.Text = "Visível"
        Me.chVisible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chVisible.Width = 50
        '
        'FondsIcon
        '
        Me.FondsIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.FondsIcon.ImageSize = New System.Drawing.Size(16, 16)
        Me.FondsIcon.ImageStream = CType(resources.GetObject("FondsIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.FondsIcon.TransparentColor = System.Drawing.Color.White
        '
        'MainMenuFonds
        '
        Me.MainMenuFonds.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemImportExport, Me.MenuItemTools, Me.MenuItemReports})
        '
        'MenuItemImportExport
        '
        Me.MenuItemImportExport.Index = 0
        Me.MenuItemImportExport.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemImport, Me.MenuItemExport})
        Me.MenuItemImportExport.Text = CType(configurationAppSettings.GetValue("MenuItemImportExport.Text", GetType(System.String)), String)
        '
        'MenuItemImport
        '
        Me.MenuItemImport.Index = 0
        Me.MenuItemImport.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemImportEAD})
        Me.MenuItemImport.Text = CType(configurationAppSettings.GetValue("MenuItemImport.Text", GetType(System.String)), String)
        '
        'MenuItemImportEAD
        '
        Me.MenuItemImportEAD.Index = 0
        Me.MenuItemImportEAD.Text = CType(configurationAppSettings.GetValue("MenuItemImportEAD.Text", GetType(System.String)), String)
        '
        'MenuItemExport
        '
        Me.MenuItemExport.Enabled = False
        Me.MenuItemExport.Index = 1
        Me.MenuItemExport.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemExportEAD, Me.MenuItemExportCALM})
        Me.MenuItemExport.Text = CType(configurationAppSettings.GetValue("MenuItemExport.Text", GetType(System.String)), String)
        '
        'MenuItemExportEAD
        '
        Me.MenuItemExportEAD.Index = 0
        Me.MenuItemExportEAD.Text = CType(configurationAppSettings.GetValue("MenuItemExportEAD.Text", GetType(System.String)), String)
        '
        'MenuItemExportCALM
        '
        Me.MenuItemExportCALM.Index = 1
        Me.MenuItemExportCALM.Text = CType(configurationAppSettings.GetValue("MenuItemExportCALM.Text", GetType(System.String)), String)
        '
        'MenuItemTools
        '
        Me.MenuItemTools.Index = 1
        Me.MenuItemTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemUpdateCompleteUnitId, Me.MenuItemElementCounter})
        Me.MenuItemTools.Text = CType(configurationAppSettings.GetValue("FondsManagerMenuItemTools.Text", GetType(System.String)), String)
        '
        'MenuItemUpdateCompleteUnitId
        '
        Me.MenuItemUpdateCompleteUnitId.Index = 0
        Me.MenuItemUpdateCompleteUnitId.Text = CType(configurationAppSettings.GetValue("MenuItemUpdateCompleteUnitId.Text", GetType(System.String)), String)
        '
        'MenuItemElementCounter
        '
        Me.MenuItemElementCounter.Index = 1
        Me.MenuItemElementCounter.Text = CType(configurationAppSettings.GetValue("MenuItemElementCounter.Text", GetType(System.String)), String)
        '
        'MenuItemReports
        '
        Me.MenuItemReports.Enabled = False
        Me.MenuItemReports.Index = 2
        Me.MenuItemReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFondsGuide, Me.MenuItemInventory, Me.MenuItemUIInventory, Me.MenuItemCatalogue, Me.MenuItemInstalationUnitsBySeriesReport, Me.MenuItemUIList, Me.MenuItemSeriesList, Me.MenuItemClassificationPlanReport, Me.MenuItemControlAccessReport, Me.MenuItemAllControlAccess, Me.MenuItemPhysLocReport, Me.MenuItemAuthorsList, Me.MenuItemCountElements})
        Me.MenuItemReports.Text = CType(configurationAppSettings.GetValue("MenuItemReports.Text", GetType(System.String)), String)
        '
        'MenuItemFondsGuide
        '
        Me.MenuItemFondsGuide.Index = 0
        Me.MenuItemFondsGuide.Text = CType(configurationAppSettings.GetValue("MenuItemFondsGuide.Text", GetType(System.String)), String)
        '
        'MenuItemInventory
        '
        Me.MenuItemInventory.Index = 1
        Me.MenuItemInventory.Text = CType(configurationAppSettings.GetValue("MenuItemInventory.Text", GetType(System.String)), String)
        '
        'MenuItemUIInventory
        '
        Me.MenuItemUIInventory.Index = 2
        Me.MenuItemUIInventory.Text = CType(configurationAppSettings.GetValue("MenuItemUIInventory.Text", GetType(System.String)), String)
        '
        'MenuItemCatalogue
        '
        Me.MenuItemCatalogue.Index = 3
        Me.MenuItemCatalogue.Text = CType(configurationAppSettings.GetValue("MenuItemCatalogue.Text", GetType(System.String)), String)
        '
        'MenuItemInstalationUnitsBySeriesReport
        '
        Me.MenuItemInstalationUnitsBySeriesReport.Index = 4
        Me.MenuItemInstalationUnitsBySeriesReport.Text = CType(configurationAppSettings.GetValue("MenuItemInstalationUnitsBySeriesReport.Text", GetType(System.String)), String)
        '
        'MenuItemUIList
        '
        Me.MenuItemUIList.Index = 5
        Me.MenuItemUIList.Text = CType(configurationAppSettings.GetValue("MenuItemUIList.Text", GetType(System.String)), String)
        '
        'MenuItemSeriesList
        '
        Me.MenuItemSeriesList.Index = 6
        Me.MenuItemSeriesList.Text = CType(configurationAppSettings.GetValue("MenuItemSeriesList.Text", GetType(System.String)), String)
        '
        'MenuItemClassificationPlanReport
        '
        Me.MenuItemClassificationPlanReport.Index = 7
        Me.MenuItemClassificationPlanReport.Text = CType(configurationAppSettings.GetValue("MenuItemClassificationPlanReport.Text", GetType(System.String)), String)
        '
        'MenuItemControlAccessReport
        '
        Me.MenuItemControlAccessReport.Index = 8
        Me.MenuItemControlAccessReport.Text = CType(configurationAppSettings.GetValue("MenuItemControlAccessReport.Text", GetType(System.String)), String)
        '
        'MenuItemAllControlAccess
        '
        Me.MenuItemAllControlAccess.Index = 9
        Me.MenuItemAllControlAccess.Text = CType(configurationAppSettings.GetValue("MenuItemAllControlAccess.Text", GetType(System.String)), String)
        '
        'MenuItemPhysLocReport
        '
        Me.MenuItemPhysLocReport.Index = 10
        Me.MenuItemPhysLocReport.Text = CType(configurationAppSettings.GetValue("MenuItemPhysLocReport.Text", GetType(System.String)), String)
        '
        'MenuItemAuthorsList
        '
        Me.MenuItemAuthorsList.Index = 11
        Me.MenuItemAuthorsList.Text = CType(configurationAppSettings.GetValue("MenuItemAuthorsList.Text", GetType(System.String)), String)
        '
        'MenuItemCountElements
        '
        Me.MenuItemCountElements.Index = 12
        Me.MenuItemCountElements.Text = "Nº total de elementos..."
        '
        'FondsManagerForm
        '
        Me.AcceptButton = Me.btnOpenFonds
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCloseFondsManagerForm
        Me.ClientSize = New System.Drawing.Size(672, 289)
        Me.Controls.Add(Me.ListView)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1600, 1024)
        Me.Menu = Me.MainMenuFonds
        Me.MinimumSize = New System.Drawing.Size(608, 200)
        Me.Name = "FondsManagerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = CType(configurationAppSettings.GetValue("FondsManagerForm.Text", GetType(System.String)), String)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Sub New(ByVal ProcessInfoName As String, ByVal HideButtons As Boolean, ByRef ProgramState As ProgramState)
        Me.New(ProcessInfoName)
        myHideButtons = HideButtons
        myProgramState = ProgramState
        If HideButtons Then
            btnNewFonds.Visible = False
            btnRemoveFonds.Visible = False
            MenuItemReports.Visible = False
            MenuItemImportExport.Visible = False
            MenuItemTools.Visible = False
        End If
    End Sub


    Private Sub FondsManagerForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnRemoveFonds.Visible = myProcessInfoName = "admin" And Not myHideButtons
        Me.MenuItemImport.Visible = myProcessInfoName = "admin"
        Me.MenuItemTools.Visible = myProcessInfoName = "admin"
        If Not myProgramState Is Nothing Then Me.txtFindFonds.Text = myProgramState.LastFondsSearched
        LoadFondsList()
    End Sub


#Region "Auxiliary Functions "

    Private Sub LoadFondsList()
        Dim Item As FondsListItem

        Cursor.Current = Cursors.WaitCursor
        ListView.Items.Clear()

        Try
            Dim LanguageSettings As Hashtable = ConfigurationManager.GetSection("langSettings")
            Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
            Dim FondsList As FondsListCollection = SQLLazyNode.GetFondsList( _
                                                        SQLServerSettings.Item("ServerAddress"), _
                                                        SQLServerSettings.Item("Database"), _
                                                        SQLServerSettings.Item("Username"), _
                                                        SQLServerSettings.Item("Password") _
                                                    )
            For Each Item In FondsList
                Dim Row As New ListViewItem("", 0)
                Row.UseItemStyleForSubItems = False
                Dim Icon As New ListViewItem.ListViewSubItem(Row, "")
                Dim UnitId As New ListViewItem.ListViewSubItem(Row, Item.UnitId)
                Dim UnitTitle As New ListViewItem.ListViewSubItem(Row, Item.UnitTitle)
                Dim UnitDateInitial As New ListViewItem.ListViewSubItem(Row, Item.UnitDateInitial)
                Dim UnitDateFinal As New ListViewItem.ListViewSubItem(Row, Item.UnitDateFinal)
                Dim Visible As New ListViewItem.ListViewSubItem

                If Item.Visible Then
                    Visible.ForeColor = Color.Green
                    Visible.Text = LanguageSettings.Item("yes")
                Else
                    Visible.ForeColor = Color.Red
                    Visible.Text = LanguageSettings.Item("no")
                End If

                Dim ID As New ListViewItem.ListViewSubItem(Row, IntToStr(Item.ID))

                Row.SubItems.Add(UnitId)
                Row.SubItems.Add(UnitTitle)
                Row.SubItems.Add(UnitDateInitial)
                Row.SubItems.Add(UnitDateFinal)
                Row.SubItems.Add(Visible)
                Row.SubItems.Add(ID)

                ListView.Items.Add(Row)
            Next

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView.SelectedIndexChanged
        Me.btnOpenFonds.Enabled = (ListView.SelectedItems.Count = 1)
        Me.btnRemoveFonds.Enabled = (ListView.SelectedItems.Count > 0)
        Me.MenuItemExport.Enabled = (ListView.SelectedItems.Count > 0)
        Me.MenuItemReports.Enabled = (ListView.SelectedItems.Count > 0)
        Me.MenuItemTools.Enabled = (ListView.SelectedItems.Count > 0)
    End Sub

#End Region


#Region "Button Event Handlers"

    Private Sub btnFindFonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindFonds.Click
        Dim Item As ListViewItem
        Dim ItemToSelect As ListViewItem = Nothing
        For Each Item In ListView.Items
            If Item.SubItems(1).Text.ToUpper.IndexOf(txtFindFonds.Text.ToUpper) >= 0 Then
                ItemToSelect = Item
                Exit For
            End If
        Next

        If Not ItemToSelect Is Nothing Then
            ListView.Focus()
            ListView.MultiSelect = False
            ItemToSelect.Selected = True
            ItemToSelect.Focused = True
            ItemToSelect.EnsureVisible()
            ListView.MultiSelect = True

            If Not myProgramState Is Nothing Then myProgramState.LastFondsSearched = txtFindFonds.Text
        End If
    End Sub

    'Private Sub txtFindFonds_KeyPress(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles txtFindFonds.KeyDown
    '    If e.KeyCode <> Keys.Enter Then Exit Sub

    '    Dim Item As ListViewItem
    '    Dim ItemToSelect As ListViewItem = Nothing
    '    For Each Item In ListView.Items
    '        If Item.SubItems(1).Text.ToUpper.IndexOf(txtFindFonds.Text.ToUpper) >= 0 Then
    '            ItemToSelect = Item
    '            Exit For
    '        End If
    '    Next

    '    If Not ItemToSelect Is Nothing Then
    '        ListView.Focus()
    '        ListView.MultiSelect = False
    '        ItemToSelect.Selected = True
    '        ItemToSelect.Focused = True
    '        ItemToSelect.EnsureVisible()
    '        ListView.MultiSelect = True

    '        If Not myProgramState Is Nothing Then myProgramState.LastFondsSearched = txtFindFonds.Text
    '    End If
    'End Sub

    Private Sub btnNewFonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFonds.Click
        Dim frmNewFonds As New NewFondsForm


        If frmNewFonds.ShowDialog() = DialogResult.OK Then
            Try
                Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
                Dim Node As LazyNode = SQLLazyNode.CreateNewFonds( _
                                                            SQLServerSettings.Item("ServerAddress"), _
                                                            SQLServerSettings.Item("Database"), _
                                                            SQLServerSettings.Item("Username"), _
                                                            SQLServerSettings.Item("Password"), _
                                                            frmNewFonds.GetUnitId(), _
                                                            frmNewFonds.GetUnitTitle(), _
                                                            myProcessInfoName _
                                                        )
                Node.CountryCode = frmNewFonds.GetCountryCode()
                Node.RepositoryCode = frmNewFonds.GetRepositoryCode()
                Node.Upload()
                LoadFondsList()
            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)

            End Try
        End If



    End Sub

    Private Sub btnOpenFonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFonds.Click
        If ListView.SelectedItems.Count <> 1 Then Exit Sub
        Dim ID As Integer = StrToInt(ListView.SelectedItems(0).SubItems(6).Text)

        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Try
            Dim RootNode As LazyNode = New SQLLazyNode(SQLServerSettings.Item("ServerAddress"), _
                                                       SQLServerSettings.Item("Database"), _
                                                       SQLServerSettings.Item("Username"), _
                                                       SQLServerSettings.Item("Password"), _
                                                       ID)

            mySelectedFonds = RootNode
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
            mySelectedFonds = Nothing
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
            mySelectedFonds = Nothing
        End Try
        DialogResult = DialogResult.OK
        'Debug.WriteLine(RootNode.Catamorphism(New GeneNodeCounter))
    End Sub

    Private Sub ListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.DoubleClick
        btnOpenFonds_Click(Me, e)
    End Sub

    Private Sub btnRemoveFonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFonds.Click
        If ListView.SelectedItems.Count = 0 Then Exit Sub


        If MessageBox.Show(InfoMessage("RemoveSelectedFonds.Confirm"), InfoMessage("RemoveFonds.ConfirmTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        Dim Row As ListViewItem
        For Each Row In ListView.SelectedItems
            Dim ID As Integer = StrToInt(Row.SubItems(6).Text)
            Dim UnitID As String = Row.SubItems(1).Text
            Dim UnitTitle As String = Row.SubItems(2).Text


            ' confimar para cada fundo
            If MessageBox.Show(String.Format(InfoMessage("RemoveFonds.Confirm"), UnitID, UnitTitle), InfoMessage("RemoveFonds.ConfirmTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False
                Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
                Try
                    SQLLazyNode.RemoveFonds(SQLServerSettings.Item("ServerAddress"), _
                                            SQLServerSettings.Item("Database"), _
                                            SQLServerSettings.Item("Username"), _
                                            SQLServerSettings.Item("Password"), _
                                            ID)
                    Log.Append(myProcessInfoName, Log.LogActions.RemoveFonds, String.Format(LogMessage("Log.RemoveFonds"), UnitID))
                Catch ex As SqlException
                    ' a message is printed in the low-level method
                Catch ex As Exception
                    MessageBoxes.MsgBoxSqlException(ex)
                End Try
                Me.Enabled = True
                LoadFondsList()
            End If
        Next


        ListView_SelectedIndexChanged(sender, Nothing) ' disable buttons if necessary
        Cursor.Current = Cursors.Default
    End Sub
#End Region


#Region "Menu Event Handlers"

    Private Sub MenuItemImportEAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemImportEAD.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Multiselect = True
        'OpenFileDialog.InitialDirectory() = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        OpenFileDialog.Filter = "EAD files (*.ead)|*.ead"
        OpenFileDialog.Title = InfoMessage("OpenFileDialog.Title.ExternalEAD")


        Try
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                Dim Filename As String
                Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

                For Each Filename In OpenFileDialog.FileNames
                    Dim Importer As New Importer(SQLServerSettings.Item("ServerAddress"), _
                                                 SQLServerSettings.Item("Database"), _
                                                 SQLServerSettings.Item("Username"), _
                                                 SQLServerSettings.Item("Password"), Filename, _
                                                 myProcessInfoName)
                    Me.Enabled = False
                    Importer.Import()
                    Me.Enabled = True
                    LoadFondsList()
                Next
            End If
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            If ex.Message = "" Then
                MsgBox(ErrorMessage("OpenFileDialog.TooManyFilesSelected"), MsgBoxStyle.Exclamation)
            Else
                MessageBoxes.MsgBoxException(ex)
            End If
        End Try
    End Sub

    Private Sub MenuItemExportEAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemExportEAD.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "EAD files (*.ead)|*.ead"
        SaveFileDialog.Title = InfoMessage("SaveFileDialog.Title.EAD")


        Try
            Dim Row As ListViewItem
            For Each Row In ListView.SelectedItems
                SaveFileDialog.FileName = Row.SubItems(1).Text.Replace("/", "-")
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim Filename As String = SaveFileDialog.FileName
                    Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
                    Dim ID As Integer = StrToInt(Row.SubItems(6).Text)
                    Dim Exporter As New Exporter(SQLServerSettings.Item("ServerAddress"), _
                                                 SQLServerSettings.Item("Database"), _
                                                 SQLServerSettings.Item("Username"), _
                                                 SQLServerSettings.Item("Password"), Filename, _
                                                 ID)
                    Me.Enabled = False
                    Exporter.Export()
                End If
            Next
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            Me.Enabled = True
        End Try
    End Sub



    Private Sub MenuItemUpdateCompleteUnitId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemUpdateCompleteUnitId.Click
        Dim Row As ListViewItem
        For Each Row In ListView.SelectedItems
            Dim ID As Integer = StrToInt(Row.SubItems(6).Text)
            Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
            Try
                Dim RootNode As LazyNode = New SQLLazyNode(SQLServerSettings.Item("ServerAddress"), _
                                                           SQLServerSettings.Item("Database"), _
                                                           SQLServerSettings.Item("Username"), _
                                                           SQLServerSettings.Item("Password"), _
                                                           ID)
                Dim iterator As New Iterator(RootNode)
                Me.Enabled = False
                iterator.Start(iterator.Action.UpdateCompleteUnitId)
            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
                mySelectedFonds = Nothing
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
                mySelectedFonds = Nothing
            End Try
            Me.Enabled = True
        Next
    End Sub

    Private Function GetSelectedLazyNodes()
        Dim Row As ListViewItem
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Dim LazyNodes As New LazyNodeCollection
        For Each Row In ListView.SelectedItems
            Dim ID As Integer = StrToInt(Row.SubItems(6).Text)
            Try
                Dim SQLLazyNode As LazyNode = New SQLLazyNode(SQLServerSettings.Item("ServerAddress"), SQLServerSettings.Item("Database"), _
                                                              SQLServerSettings.Item("Username"), SQLServerSettings.Item("Password"), ID)
                LazyNodes.Add(SQLLazyNode)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            End Try
        Next
        Return LazyNodes
    End Function


    Private Sub MenuItemExportCALM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemExportCALM.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "CALM Natural Format (*.txt)|*.txt"
        SaveFileDialog.Title = InfoMessage("SaveFileDialog.Title.CALM")


        Try
            Dim Row As ListViewItem
            For Each Row In ListView.SelectedItems
                SaveFileDialog.FileName = Row.SubItems(1).Text.Replace("/", "-")
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim Filename As String = SaveFileDialog.FileName
                    Dim EADFilename As String = Path.GetFileNameWithoutExtension(Filename) & ".ead"
                    Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
                    Dim ID As Integer = StrToInt(Row.SubItems(6).Text)
                    Dim Exporter As New Exporter(SQLServerSettings.Item("ServerAddress"), _
                                                 SQLServerSettings.Item("Database"), _
                                                 SQLServerSettings.Item("Username"), _
                                                 SQLServerSettings.Item("Password"), EADFilename, _
                                                 ID)
                    Me.Enabled = False
                    Exporter.Export()

                    Dim xslt As XslTransform = New XslTransform
                    xslt.Load(EAD2CNF_XSLT_FILENAME)

                    Dim resolver As XmlUrlResolver = New XmlUrlResolver
                    resolver.Credentials = System.Net.CredentialCache.DefaultCredentials
                    xslt.Transform(EADFilename, Filename, resolver)
                    xslt = Nothing
                End If
            Next
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            Me.Enabled = True
        End Try
    End Sub



#End Region


#Region "Reporting Stuff"

    Private Sub MenuItemFondsGuide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFondsGuide.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As FondsGuideDataSet = ReportDataSetBuilder.GenerateFondsGuideReportData(SelectedLazyNodes)

        Dim Report As New FondsGuideReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemInventory.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As InventoryDataSet = ReportDataSetBuilder.GenerateInventoryReportData(SelectedLazyNodes)

        Dim Report As New InventoryReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemUIInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemUIInventory.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As CatalogDataSet = ReportDataSetBuilder.GenerateIUInventoryReportData(SelectedLazyNodes)

        Dim Report As New IUInventoryReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub



    Private Sub MenuItemCatalogue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCatalogue.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As CatalogDataSet = ReportDataSetBuilder.GenerateCatalogReportData(SelectedLazyNodes)

        Dim Report As New CatalogReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemSeriesList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSeriesList.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateSeriesListData(SelectedLazyNodes)

        Dim Report As New SeriesListReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()

    End Sub

    Private Sub MenuItemUIList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemUIList.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateInstalationUnitsListData(SelectedLazyNodes)

        Dim Report As New IUListReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub



    Private Sub MenuItemClassificationPlanReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemClassificationPlanReport.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As InventoryDataSet = ReportDataSetBuilder.GenerateClassificationPlanData(SelectedLazyNodes)

        Dim Report As New ClassificationPlanReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub


    Private Sub MenuItemPhysLocReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemPhysLocReport.Click
        Cursor.Current = Cursors.WaitCursor
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As PhysLocDataSet = ReportDataSetBuilder.GeneratePhysLocData(SelectedLazyNodes)

        Dim Report As New PhysLocReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor.Current = Cursors.Default
        frmReportPreview.Show()
    End Sub


    Private Sub MenuItemControlAccessReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemControlAccessReport.Click
        Cursor.Current = Cursors.WaitCursor
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As ControlAccessDataSet = ReportDataSetBuilder.GenerateControlAccessData(SelectedLazyNodes)

        Dim Report As New ControlAccessReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor.Current = Cursors.Default
        frmReportPreview.Show()
    End Sub


    Private Sub MenuItemAllControlAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAllControlAccess.Click
        Cursor.Current = Cursors.WaitCursor
        Dim ReportDataSet As ControlAccessDataSet = ReportDataSetBuilder.GenerateAllControlAccessData()

        Dim Report As New AllControlAccessReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor.Current = Cursors.Default
        frmReportPreview.Show()

    End Sub

    Private Sub MenuItemInstalationUnitsBySeriesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemInstalationUnitsBySeriesReport.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateInstalationUnitsBySeriesListData(SelectedLazyNodes)

        Dim Report As New IUBySeriesReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()

    End Sub

    Private Sub MenuItemAuthorsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAuthorsList.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Cursor = Cursors.WaitCursor
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateAuthorsListData(SelectedLazyNodes)

        Dim Report As New AuthorsListReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor = Cursors.Default
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemCountElements_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCountElements.Click
        Dim SelectedLazyNodes As LazyNodeCollection = GetSelectedLazyNodes()
        Cursor = Cursors.WaitCursor
        Dim ReportDataSet As CountElements = ReportDataSetBuilder.GenerateCountElementsData(SelectedLazyNodes)

        Dim Report As New CountElementsReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor = Cursors.Default
        frmReportPreview.Show()
    End Sub


#End Region

    Private Sub MenuItemElementCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemElementCounter.Click
        Dim Row As ListViewItem
        Dim result As New Hashtable

        Dim startTime As Date = Date.Now

        For Each Row In ListView.SelectedItems
            Dim ID As Integer = StrToInt(Row.SubItems(6).Text)
            Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
            Try
                Dim RootNode As LazyNode = New SQLLazyNode(SQLServerSettings.Item("ServerAddress"), _
                                                           SQLServerSettings.Item("Database"), _
                                                           SQLServerSettings.Item("Username"), _
                                                           SQLServerSettings.Item("Password"), _
                                                           ID)
                Dim iterator As New Iterator(RootNode)
                Me.Enabled = False
                'Dim res = iterator.Start(iterator.Action.UpdateCompleteUnitId)
                Dim res = iterator.Start(iterator.Action.CountNodesByOtherLevel)
                result = GeneNodeCounterPro.AddResults(result, res)
            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
                mySelectedFonds = Nothing
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
                mySelectedFonds = Nothing
            End Try
            Me.Enabled = True
        Next


        Dim msg As String = ""
        Dim total As Integer = 0

        ' added by lmferros
        Dim keys() As String = {"F", "SF", "SC", "SSC", "SSSC", "SR", "SSR", "UI", "DC", "D"}
        For i As Integer = 0 To keys.Length - 1
            If result.ContainsKey(keys(i)) Then
                msg &= VisualFieldLabel(keys(i)) & ": " & result(keys(i)) & Chr(13)
                total += result(keys(i))
            End If
        Next

        'For Each key As String In result.Keys
        '    msg &= VisualFieldLabel(key) & ": " & result(key) & Chr(13)
        '    total += result(key)
        'Next

        Dim finishTime As Date = Date.Now
        Dim timeSpan As TimeSpan = finishTime.Subtract(startTime)
        Dim timeStr As String = timeSpan.Minutes.ToString.PadLeft(2, "0") & "m" & timeSpan.Seconds.ToString.PadLeft(2, "0") & "s"
        msg &= ControlChars.NewLine & "Total: " & total & ControlChars.NewLine & ControlChars.NewLine
        msg &= "[Tempo: " & timeStr & "]"
        MsgBox(msg)

    End Sub


End Class

