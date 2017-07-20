
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

Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Collections.Specialized
Imports MDA.Log
Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports SHDocVw
Imports Authentication

Public Class MainForm
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Private Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        Initialize()
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
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemFile As System.Windows.Forms.MenuItem
    Friend WithEvents TreeView As LazyTree
    Friend WithEvents RightPanel As System.Windows.Forms.Panel

    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents ButtonIcons As System.Windows.Forms.ImageList
    Friend WithEvents MenuItemExit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCollapseAll As System.Windows.Forms.MenuItem
    Friend WithEvents OtherFindAidIcons As System.Windows.Forms.ImageList
    Friend WithEvents MenuItemExpandAll As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCopy As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemPaste As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCut As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemTools As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAbout As System.Windows.Forms.MenuItem
    Friend WithEvents PrintReportMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents IncorporationResumeMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents FondsListingMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents IncorporationTransportationUnitsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents GenreFormIcons As System.Windows.Forms.ImageList
    Friend WithEvents LegalStatusMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemValidate As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemManual As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents tpIndentityArea As System.Windows.Forms.TabPage
    Friend WithEvents tpContextArea As System.Windows.Forms.TabPage
    Friend WithEvents tpContentStructureArea As System.Windows.Forms.TabPage
    Friend WithEvents tpConditionsAccessUseArea As System.Windows.Forms.TabPage
    Friend WithEvents tpAlliedMaterialArea As System.Windows.Forms.TabPage
    Friend WithEvents tpNoteArea As System.Windows.Forms.TabPage
    Friend WithEvents tpAllArea As System.Windows.Forms.TabPage
    Friend WithEvents OtherLevelIcons As System.Windows.Forms.ImageList
    Friend WithEvents MenuItemFondsManager As System.Windows.Forms.MenuItem
    Friend WithEvents tpDescriptionControl As System.Windows.Forms.TabPage
    Friend WithEvents UpDownArrowButtons As System.Windows.Forms.ImageList
    Friend WithEvents MenuItemAdministration As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemControlAccess As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemRemove As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemUserManagement As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSortBy As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSortByUnitID As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSortByUnitDateInitial As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSortByOtherLevel As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemStatistics As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemView As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAllFields As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMandatoryFields As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMostFrequentFields As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemTree As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemReplace As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFindReplace As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFind As System.Windows.Forms.MenuItem
    Friend WithEvents ViewModeIcons As System.Windows.Forms.ImageList
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAutoCoding As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemEdit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemHelp As System.Windows.Forms.MenuItem
    Friend WithEvents ContainerTypeIcons As System.Windows.Forms.ImageList
    Friend WithEvents MenuItemLogin As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemVisibility As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemValidation As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMakeValid As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMakeVisible As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMakeInvisible As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMakeInvalid As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemInference As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSortByProcessInfoDate As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAuthority As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemInventoryReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemIUInventoryReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCatalogReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemIUListReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSeriesListReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemClassificationPlanReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAllControlAccessReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemControlAccessReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemReports As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemImport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemImportEAD As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExportEAD As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExportCALM As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemClearLog As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemNodeCounterPro As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemImportFonds As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAskBeforeSave As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFondsGuide As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemInstalationUnitsBySeriesReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemWebSearch As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemLog As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemLogViewer As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemGlobalStats As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMonthlyStats As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemWebStats As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemImportTabSeparatedText As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemNormaliseCoding As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSortByUnitTitle As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAuthorsListReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemWebSeparator As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemPhyslocReport As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFileSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFileSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents AltFormAvailIcons As System.Windows.Forms.ImageList
    Private configurationAppSettings As New System.Configuration.AppSettingsReader
    Friend WithEvents MenuItemNewFonds As System.Windows.Forms.MenuItem
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
        Me.OtherLevelIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusBar = New System.Windows.Forms.StatusBar()
        Me.PrintReportMenu = New System.Windows.Forms.ContextMenu()
        Me.IncorporationResumeMenuItem = New System.Windows.Forms.MenuItem()
        Me.FondsListingMenuItem = New System.Windows.Forms.MenuItem()
        Me.IncorporationTransportationUnitsMenuItem = New System.Windows.Forms.MenuItem()
        Me.LegalStatusMenuItem = New System.Windows.Forms.MenuItem()
        Me.ButtonIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.RightPanel = New System.Windows.Forms.Panel()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.tpIndentityArea = New System.Windows.Forms.TabPage()
        Me.tpContextArea = New System.Windows.Forms.TabPage()
        Me.tpContentStructureArea = New System.Windows.Forms.TabPage()
        Me.tpConditionsAccessUseArea = New System.Windows.Forms.TabPage()
        Me.tpAlliedMaterialArea = New System.Windows.Forms.TabPage()
        Me.tpNoteArea = New System.Windows.Forms.TabPage()
        Me.tpDescriptionControl = New System.Windows.Forms.TabPage()
        Me.tpAllArea = New System.Windows.Forms.TabPage()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.MainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItemFile = New System.Windows.Forms.MenuItem()
        Me.MenuItemNewFonds = New System.Windows.Forms.MenuItem()
        Me.MenuItemFondsManager = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItemImport = New System.Windows.Forms.MenuItem()
        Me.MenuItemImportEAD = New System.Windows.Forms.MenuItem()
        Me.MenuItemImportFonds = New System.Windows.Forms.MenuItem()
        Me.MenuItemImportTabSeparatedText = New System.Windows.Forms.MenuItem()
        Me.MenuItemExport = New System.Windows.Forms.MenuItem()
        Me.MenuItemExportEAD = New System.Windows.Forms.MenuItem()
        Me.MenuItemExportCALM = New System.Windows.Forms.MenuItem()
        Me.MenuItemFileSeparator1 = New System.Windows.Forms.MenuItem()
        Me.MenuItemLogin = New System.Windows.Forms.MenuItem()
        Me.MenuItemFileSeparator2 = New System.Windows.Forms.MenuItem()
        Me.MenuItemExit = New System.Windows.Forms.MenuItem()
        Me.MenuItemEdit = New System.Windows.Forms.MenuItem()
        Me.MenuItemCut = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopy = New System.Windows.Forms.MenuItem()
        Me.MenuItemPaste = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItemRemove = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItemFindReplace = New System.Windows.Forms.MenuItem()
        Me.MenuItemFind = New System.Windows.Forms.MenuItem()
        Me.MenuItemReplace = New System.Windows.Forms.MenuItem()
        Me.MenuItemWebSearch = New System.Windows.Forms.MenuItem()
        Me.MenuItemView = New System.Windows.Forms.MenuItem()
        Me.MenuItemAllFields = New System.Windows.Forms.MenuItem()
        Me.MenuItemMostFrequentFields = New System.Windows.Forms.MenuItem()
        Me.MenuItemMandatoryFields = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItemTree = New System.Windows.Forms.MenuItem()
        Me.MenuItemExpandAll = New System.Windows.Forms.MenuItem()
        Me.MenuItemCollapseAll = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItemSortBy = New System.Windows.Forms.MenuItem()
        Me.MenuItemSortByUnitDateInitial = New System.Windows.Forms.MenuItem()
        Me.MenuItemSortByUnitID = New System.Windows.Forms.MenuItem()
        Me.MenuItemSortByUnitTitle = New System.Windows.Forms.MenuItem()
        Me.MenuItemSortByOtherLevel = New System.Windows.Forms.MenuItem()
        Me.MenuItemSortByProcessInfoDate = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItemAskBeforeSave = New System.Windows.Forms.MenuItem()
        Me.MenuItemTools = New System.Windows.Forms.MenuItem()
        Me.MenuItemValidate = New System.Windows.Forms.MenuItem()
        Me.MenuItemInference = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItemNormaliseCoding = New System.Windows.Forms.MenuItem()
        Me.MenuItemAutoCoding = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItemStatistics = New System.Windows.Forms.MenuItem()
        Me.MenuItemNodeCounterPro = New System.Windows.Forms.MenuItem()
        Me.MenuItemAdministration = New System.Windows.Forms.MenuItem()
        Me.MenuItemControlAccess = New System.Windows.Forms.MenuItem()
        Me.MenuItemUserManagement = New System.Windows.Forms.MenuItem()
        Me.MenuItemAuthority = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItemValidation = New System.Windows.Forms.MenuItem()
        Me.MenuItemMakeValid = New System.Windows.Forms.MenuItem()
        Me.MenuItemMakeInvalid = New System.Windows.Forms.MenuItem()
        Me.MenuItemVisibility = New System.Windows.Forms.MenuItem()
        Me.MenuItemMakeVisible = New System.Windows.Forms.MenuItem()
        Me.MenuItemMakeInvisible = New System.Windows.Forms.MenuItem()
        Me.MenuItemWebSeparator = New System.Windows.Forms.MenuItem()
        Me.MenuItemLog = New System.Windows.Forms.MenuItem()
        Me.MenuItemLogViewer = New System.Windows.Forms.MenuItem()
        Me.MenuItemClearLog = New System.Windows.Forms.MenuItem()
        Me.MenuItemWebStats = New System.Windows.Forms.MenuItem()
        Me.MenuItemGlobalStats = New System.Windows.Forms.MenuItem()
        Me.MenuItemMonthlyStats = New System.Windows.Forms.MenuItem()
        Me.MenuItemReports = New System.Windows.Forms.MenuItem()
        Me.MenuItemFondsGuide = New System.Windows.Forms.MenuItem()
        Me.MenuItemInventoryReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemIUInventoryReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemCatalogReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemInstalationUnitsBySeriesReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemIUListReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemSeriesListReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemClassificationPlanReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemControlAccessReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemAllControlAccessReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemPhyslocReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemAuthorsListReport = New System.Windows.Forms.MenuItem()
        Me.MenuItemHelp = New System.Windows.Forms.MenuItem()
        Me.MenuItemManual = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItemAbout = New System.Windows.Forms.MenuItem()
        Me.OtherFindAidIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.GenreFormIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.ViewModeIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.UpDownArrowButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.ContainerTypeIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.AltFormAvailIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.TreeView = New MDA.LazyTree()
        Me.RightPanel.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'OtherLevelIcons
        '
        Me.OtherLevelIcons.ImageStream = CType(resources.GetObject("OtherLevelIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.OtherLevelIcons.TransparentColor = System.Drawing.Color.OldLace
        Me.OtherLevelIcons.Images.SetKeyName(0, "")
        Me.OtherLevelIcons.Images.SetKeyName(1, "")
        Me.OtherLevelIcons.Images.SetKeyName(2, "")
        Me.OtherLevelIcons.Images.SetKeyName(3, "")
        Me.OtherLevelIcons.Images.SetKeyName(4, "")
        Me.OtherLevelIcons.Images.SetKeyName(5, "")
        Me.OtherLevelIcons.Images.SetKeyName(6, "")
        Me.OtherLevelIcons.Images.SetKeyName(7, "")
        Me.OtherLevelIcons.Images.SetKeyName(8, "")
        Me.OtherLevelIcons.Images.SetKeyName(9, "")
        Me.OtherLevelIcons.Images.SetKeyName(10, "")
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 403)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(898, 22)
        Me.StatusBar.TabIndex = 0
        '
        'PrintReportMenu
        '
        Me.PrintReportMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.IncorporationResumeMenuItem, Me.FondsListingMenuItem, Me.IncorporationTransportationUnitsMenuItem, Me.LegalStatusMenuItem})
        '
        'IncorporationResumeMenuItem
        '
        Me.IncorporationResumeMenuItem.Index = 0
        Me.IncorporationResumeMenuItem.RadioCheck = True
        Me.IncorporationResumeMenuItem.Text = "Resumo..."
        '
        'FondsListingMenuItem
        '
        Me.FondsListingMenuItem.Checked = True
        Me.FondsListingMenuItem.Index = 1
        Me.FondsListingMenuItem.RadioCheck = True
        Me.FondsListingMenuItem.Text = "Listagem..."
        '
        'IncorporationTransportationUnitsMenuItem
        '
        Me.IncorporationTransportationUnitsMenuItem.Index = 2
        Me.IncorporationTransportationUnitsMenuItem.RadioCheck = True
        Me.IncorporationTransportationUnitsMenuItem.Text = "Unidades de Transporte..."
        '
        'LegalStatusMenuItem
        '
        Me.LegalStatusMenuItem.Index = 3
        Me.LegalStatusMenuItem.RadioCheck = True
        Me.LegalStatusMenuItem.Text = "Auto de Entrega"
        '
        'ButtonIcons
        '
        Me.ButtonIcons.ImageStream = CType(resources.GetObject("ButtonIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ButtonIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ButtonIcons.Images.SetKeyName(0, "")
        Me.ButtonIcons.Images.SetKeyName(1, "")
        Me.ButtonIcons.Images.SetKeyName(2, "")
        Me.ButtonIcons.Images.SetKeyName(3, "")
        '
        'RightPanel
        '
        Me.RightPanel.Controls.Add(Me.TabControl)
        Me.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightPanel.Location = New System.Drawing.Point(203, 30)
        Me.RightPanel.Name = "RightPanel"
        Me.RightPanel.Size = New System.Drawing.Size(695, 373)
        Me.RightPanel.TabIndex = 8
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.tpIndentityArea)
        Me.TabControl.Controls.Add(Me.tpContextArea)
        Me.TabControl.Controls.Add(Me.tpContentStructureArea)
        Me.TabControl.Controls.Add(Me.tpConditionsAccessUseArea)
        Me.TabControl.Controls.Add(Me.tpAlliedMaterialArea)
        Me.TabControl.Controls.Add(Me.tpNoteArea)
        Me.TabControl.Controls.Add(Me.tpDescriptionControl)
        Me.TabControl.Controls.Add(Me.tpAllArea)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl.ItemSize = New System.Drawing.Size(79, 18)
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Multiline = True
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.ShowToolTips = True
        Me.TabControl.Size = New System.Drawing.Size(695, 373)
        Me.TabControl.TabIndex = 7
        Me.TabControl.TabStop = False
        '
        'tpIndentityArea
        '
        Me.tpIndentityArea.BackColor = System.Drawing.Color.White
        Me.tpIndentityArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpIndentityArea.Location = New System.Drawing.Point(4, 22)
        Me.tpIndentityArea.Name = "tpIndentityArea"
        Me.tpIndentityArea.Size = New System.Drawing.Size(687, 347)
        Me.tpIndentityArea.TabIndex = 0
        Me.tpIndentityArea.Tag = ""
        Me.tpIndentityArea.Text = CType(configurationAppSettings.GetValue("tpIndentityArea.Text", GetType(String)), String)
        '
        'tpContextArea
        '
        Me.tpContextArea.BackColor = System.Drawing.Color.White
        Me.tpContextArea.Location = New System.Drawing.Point(4, 22)
        Me.tpContextArea.Name = "tpContextArea"
        Me.tpContextArea.Size = New System.Drawing.Size(687, 368)
        Me.tpContextArea.TabIndex = 1
        Me.tpContextArea.Tag = ""
        Me.tpContextArea.Text = CType(configurationAppSettings.GetValue("tpContextArea.Text", GetType(String)), String)
        '
        'tpContentStructureArea
        '
        Me.tpContentStructureArea.BackColor = System.Drawing.Color.White
        Me.tpContentStructureArea.Location = New System.Drawing.Point(4, 22)
        Me.tpContentStructureArea.Name = "tpContentStructureArea"
        Me.tpContentStructureArea.Size = New System.Drawing.Size(687, 368)
        Me.tpContentStructureArea.TabIndex = 2
        Me.tpContentStructureArea.Text = CType(configurationAppSettings.GetValue("tpContentStructure.Text", GetType(String)), String)
        '
        'tpConditionsAccessUseArea
        '
        Me.tpConditionsAccessUseArea.BackColor = System.Drawing.Color.White
        Me.tpConditionsAccessUseArea.Location = New System.Drawing.Point(4, 22)
        Me.tpConditionsAccessUseArea.Name = "tpConditionsAccessUseArea"
        Me.tpConditionsAccessUseArea.Size = New System.Drawing.Size(687, 368)
        Me.tpConditionsAccessUseArea.TabIndex = 3
        Me.tpConditionsAccessUseArea.Text = CType(configurationAppSettings.GetValue("tpConditionsAccessUseArea.Text", GetType(String)), String)
        '
        'tpAlliedMaterialArea
        '
        Me.tpAlliedMaterialArea.BackColor = System.Drawing.Color.White
        Me.tpAlliedMaterialArea.Location = New System.Drawing.Point(4, 22)
        Me.tpAlliedMaterialArea.Name = "tpAlliedMaterialArea"
        Me.tpAlliedMaterialArea.Size = New System.Drawing.Size(687, 368)
        Me.tpAlliedMaterialArea.TabIndex = 4
        Me.tpAlliedMaterialArea.Text = CType(configurationAppSettings.GetValue("tpAlliedMaterialArea.Text", GetType(String)), String)
        '
        'tpNoteArea
        '
        Me.tpNoteArea.BackColor = System.Drawing.Color.White
        Me.tpNoteArea.Location = New System.Drawing.Point(4, 22)
        Me.tpNoteArea.Name = "tpNoteArea"
        Me.tpNoteArea.Size = New System.Drawing.Size(687, 368)
        Me.tpNoteArea.TabIndex = 5
        Me.tpNoteArea.Text = CType(configurationAppSettings.GetValue("tpNoteArea.Text", GetType(String)), String)
        '
        'tpDescriptionControl
        '
        Me.tpDescriptionControl.BackColor = System.Drawing.Color.White
        Me.tpDescriptionControl.Location = New System.Drawing.Point(4, 22)
        Me.tpDescriptionControl.Name = "tpDescriptionControl"
        Me.tpDescriptionControl.Size = New System.Drawing.Size(687, 368)
        Me.tpDescriptionControl.TabIndex = 7
        Me.tpDescriptionControl.Text = CType(configurationAppSettings.GetValue("TabPage1.Text", GetType(String)), String)
        '
        'tpAllArea
        '
        Me.tpAllArea.BackColor = System.Drawing.Color.White
        Me.tpAllArea.Location = New System.Drawing.Point(4, 22)
        Me.tpAllArea.Name = "tpAllArea"
        Me.tpAllArea.Size = New System.Drawing.Size(687, 368)
        Me.tpAllArea.TabIndex = 6
        Me.tpAllArea.Text = CType(configurationAppSettings.GetValue("tpAllArea.Text", GetType(String)), String)
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(200, 30)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 373)
        Me.Splitter1.TabIndex = 7
        Me.Splitter1.TabStop = False
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFile, Me.MenuItemEdit, Me.MenuItemView, Me.MenuItemTools, Me.MenuItemAdministration, Me.MenuItemReports, Me.MenuItemHelp})
        '
        'MenuItemFile
        '
        Me.MenuItemFile.Index = 0
        Me.MenuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemNewFonds, Me.MenuItemFondsManager, Me.MenuItem1, Me.MenuItemImport, Me.MenuItemExport, Me.MenuItemFileSeparator1, Me.MenuItemLogin, Me.MenuItemFileSeparator2, Me.MenuItemExit})
        Me.MenuItemFile.Text = "&Fundos"
        '
        'MenuItemNewFonds
        '
        Me.MenuItemNewFonds.Index = 0
        Me.MenuItemNewFonds.Text = "Novo fundo..."
        '
        'MenuItemFondsManager
        '
        Me.MenuItemFondsManager.Index = 1
        Me.MenuItemFondsManager.Text = CType(configurationAppSettings.GetValue("mnuItemFondsManager.Text", GetType(String)), String)
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 2
        Me.MenuItem1.Text = "-"
        '
        'MenuItemImport
        '
        Me.MenuItemImport.Index = 3
        Me.MenuItemImport.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemImportEAD, Me.MenuItemImportFonds, Me.MenuItemImportTabSeparatedText})
        Me.MenuItemImport.Text = CType(configurationAppSettings.GetValue("MenuItemImport.Text", GetType(String)), String)
        Me.MenuItemImport.Visible = False
        '
        'MenuItemImportEAD
        '
        Me.MenuItemImportEAD.Index = 0
        Me.MenuItemImportEAD.Text = CType(configurationAppSettings.GetValue("MenuItemImportEAD.Text", GetType(String)), String)
        '
        'MenuItemImportFonds
        '
        Me.MenuItemImportFonds.Index = 1
        Me.MenuItemImportFonds.Text = CType(configurationAppSettings.GetValue("MenuItemImportFonds.Text", GetType(String)), String)
        '
        'MenuItemImportTabSeparatedText
        '
        Me.MenuItemImportTabSeparatedText.Index = 2
        Me.MenuItemImportTabSeparatedText.Text = CType(configurationAppSettings.GetValue("MenuItemImportTabSeparatedText.Text", GetType(String)), String)
        '
        'MenuItemExport
        '
        Me.MenuItemExport.Index = 4
        Me.MenuItemExport.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemExportEAD, Me.MenuItemExportCALM})
        Me.MenuItemExport.Text = CType(configurationAppSettings.GetValue("MenuItemExport.Text", GetType(String)), String)
        Me.MenuItemExport.Visible = False
        '
        'MenuItemExportEAD
        '
        Me.MenuItemExportEAD.Index = 0
        Me.MenuItemExportEAD.Text = CType(configurationAppSettings.GetValue("MenuItemExportEAD.Text", GetType(String)), String)
        '
        'MenuItemExportCALM
        '
        Me.MenuItemExportCALM.Index = 1
        Me.MenuItemExportCALM.Text = CType(configurationAppSettings.GetValue("MenuItemExportCALM.Text", GetType(String)), String)
        '
        'MenuItemFileSeparator1
        '
        Me.MenuItemFileSeparator1.Index = 5
        Me.MenuItemFileSeparator1.Text = "-"
        '
        'MenuItemLogin
        '
        Me.MenuItemLogin.Index = 6
        Me.MenuItemLogin.Text = CType(configurationAppSettings.GetValue("MenuItemLogin.Text", GetType(String)), String)
        '
        'MenuItemFileSeparator2
        '
        Me.MenuItemFileSeparator2.Index = 7
        Me.MenuItemFileSeparator2.Text = "-"
        Me.MenuItemFileSeparator2.Visible = False
        '
        'MenuItemExit
        '
        Me.MenuItemExit.Index = 8
        Me.MenuItemExit.Text = "Sai&r"
        '
        'MenuItemEdit
        '
        Me.MenuItemEdit.Index = 1
        Me.MenuItemEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemCut, Me.MenuItemCopy, Me.MenuItemPaste, Me.MenuItem9, Me.MenuItemRemove, Me.MenuItem6, Me.MenuItemFindReplace})
        Me.MenuItemEdit.Text = CType(configurationAppSettings.GetValue("MenuItemEdit.Text", GetType(String)), String)
        Me.MenuItemEdit.Visible = False
        '
        'MenuItemCut
        '
        Me.MenuItemCut.Index = 0
        Me.MenuItemCut.Text = "Cor&tar"
        '
        'MenuItemCopy
        '
        Me.MenuItemCopy.Index = 1
        Me.MenuItemCopy.Text = "&Copiar"
        '
        'MenuItemPaste
        '
        Me.MenuItemPaste.Enabled = False
        Me.MenuItemPaste.Index = 2
        Me.MenuItemPaste.Text = "C&olar"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 3
        Me.MenuItem9.Text = "-"
        '
        'MenuItemRemove
        '
        Me.MenuItemRemove.Index = 4
        Me.MenuItemRemove.Text = CType(configurationAppSettings.GetValue("MenuItemRemove.Text", GetType(String)), String)
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5
        Me.MenuItem6.Text = "-"
        '
        'MenuItemFindReplace
        '
        Me.MenuItemFindReplace.Index = 6
        Me.MenuItemFindReplace.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFind, Me.MenuItemReplace, Me.MenuItemWebSearch})
        Me.MenuItemFindReplace.Text = CType(configurationAppSettings.GetValue("MenuItemFindReplace.Text", GetType(String)), String)
        '
        'MenuItemFind
        '
        Me.MenuItemFind.Index = 0
        Me.MenuItemFind.Text = CType(configurationAppSettings.GetValue("MenuItemFind.Text", GetType(String)), String)
        '
        'MenuItemReplace
        '
        Me.MenuItemReplace.Index = 1
        Me.MenuItemReplace.Text = CType(configurationAppSettings.GetValue("MenuItemReplace.Text", GetType(String)), String)
        '
        'MenuItemWebSearch
        '
        Me.MenuItemWebSearch.Index = 2
        Me.MenuItemWebSearch.Text = CType(configurationAppSettings.GetValue("MenuItemWebSearch.Text", GetType(String)), String)
        '
        'MenuItemView
        '
        Me.MenuItemView.Index = 2
        Me.MenuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemAllFields, Me.MenuItemMostFrequentFields, Me.MenuItemMandatoryFields, Me.MenuItem11, Me.MenuItemTree, Me.MenuItem10, Me.MenuItemSortBy, Me.MenuItem4, Me.MenuItemAskBeforeSave})
        Me.MenuItemView.Text = CType(configurationAppSettings.GetValue("MenuItemView.Text", GetType(String)), String)
        Me.MenuItemView.Visible = False
        '
        'MenuItemAllFields
        '
        Me.MenuItemAllFields.Checked = True
        Me.MenuItemAllFields.Index = 0
        Me.MenuItemAllFields.RadioCheck = True
        Me.MenuItemAllFields.Text = CType(configurationAppSettings.GetValue("MenuItemAllFields.Text", GetType(String)), String)
        '
        'MenuItemMostFrequentFields
        '
        Me.MenuItemMostFrequentFields.Index = 1
        Me.MenuItemMostFrequentFields.RadioCheck = True
        Me.MenuItemMostFrequentFields.Text = CType(configurationAppSettings.GetValue("MenuItemMostFrequentFields.Text", GetType(String)), String)
        '
        'MenuItemMandatoryFields
        '
        Me.MenuItemMandatoryFields.Index = 2
        Me.MenuItemMandatoryFields.RadioCheck = True
        Me.MenuItemMandatoryFields.Text = CType(configurationAppSettings.GetValue("MenuItemMandatoryFields.Text", GetType(String)), String)
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 3
        Me.MenuItem11.Text = "-"
        '
        'MenuItemTree
        '
        Me.MenuItemTree.Index = 4
        Me.MenuItemTree.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemExpandAll, Me.MenuItemCollapseAll})
        Me.MenuItemTree.Text = CType(configurationAppSettings.GetValue("MenuItemTree.Text", GetType(String)), String)
        '
        'MenuItemExpandAll
        '
        Me.MenuItemExpandAll.Index = 0
        Me.MenuItemExpandAll.Text = "&Expandir"
        '
        'MenuItemCollapseAll
        '
        Me.MenuItemCollapseAll.Index = 1
        Me.MenuItemCollapseAll.Text = "&Colapsar"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 5
        Me.MenuItem10.Text = "-"
        '
        'MenuItemSortBy
        '
        Me.MenuItemSortBy.Index = 6
        Me.MenuItemSortBy.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemSortByUnitDateInitial, Me.MenuItemSortByUnitID, Me.MenuItemSortByUnitTitle, Me.MenuItemSortByOtherLevel, Me.MenuItemSortByProcessInfoDate})
        Me.MenuItemSortBy.Text = CType(configurationAppSettings.GetValue("MenuItemSortBy.Text", GetType(String)), String)
        '
        'MenuItemSortByUnitDateInitial
        '
        Me.MenuItemSortByUnitDateInitial.Checked = True
        Me.MenuItemSortByUnitDateInitial.Index = 0
        Me.MenuItemSortByUnitDateInitial.RadioCheck = True
        Me.MenuItemSortByUnitDateInitial.Text = CType(configurationAppSettings.GetValue("MenuItemSortByUnitDateInitial.Text", GetType(String)), String)
        '
        'MenuItemSortByUnitID
        '
        Me.MenuItemSortByUnitID.Index = 1
        Me.MenuItemSortByUnitID.RadioCheck = True
        Me.MenuItemSortByUnitID.Text = CType(configurationAppSettings.GetValue("MenuItemSortByUnitID.Text", GetType(String)), String)
        '
        'MenuItemSortByUnitTitle
        '
        Me.MenuItemSortByUnitTitle.Index = 2
        Me.MenuItemSortByUnitTitle.RadioCheck = True
        Me.MenuItemSortByUnitTitle.Text = CType(configurationAppSettings.GetValue("MenuItemSortByUnitTitle.Text", GetType(String)), String)
        '
        'MenuItemSortByOtherLevel
        '
        Me.MenuItemSortByOtherLevel.Index = 3
        Me.MenuItemSortByOtherLevel.RadioCheck = True
        Me.MenuItemSortByOtherLevel.Text = CType(configurationAppSettings.GetValue("MenuItemSortByOtherLevel.Text", GetType(String)), String)
        '
        'MenuItemSortByProcessInfoDate
        '
        Me.MenuItemSortByProcessInfoDate.Index = 4
        Me.MenuItemSortByProcessInfoDate.RadioCheck = True
        Me.MenuItemSortByProcessInfoDate.Text = CType(configurationAppSettings.GetValue("MenuItemSortByProcessInfoDate.Text", GetType(String)), String)
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 7
        Me.MenuItem4.Text = "-"
        '
        'MenuItemAskBeforeSave
        '
        Me.MenuItemAskBeforeSave.Checked = True
        Me.MenuItemAskBeforeSave.Index = 8
        Me.MenuItemAskBeforeSave.Text = CType(configurationAppSettings.GetValue("MenuItemAskBeforeSave.Text", GetType(String)), String)
        '
        'MenuItemTools
        '
        Me.MenuItemTools.Index = 3
        Me.MenuItemTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemValidate, Me.MenuItemInference, Me.MenuItem7, Me.MenuItem2, Me.MenuItemStatistics})
        Me.MenuItemTools.Text = "Ferra&mentas"
        Me.MenuItemTools.Visible = False
        '
        'MenuItemValidate
        '
        Me.MenuItemValidate.Index = 0
        Me.MenuItemValidate.Text = CType(configurationAppSettings.GetValue("MenuItemValidate.Text", GetType(String)), String)
        '
        'MenuItemInference
        '
        Me.MenuItemInference.Index = 1
        Me.MenuItemInference.Text = CType(configurationAppSettings.GetValue("MenuItemInference.Text", GetType(String)), String)
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 2
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemNormaliseCoding, Me.MenuItemAutoCoding})
        Me.MenuItem7.Text = "Referências..."
        '
        'MenuItemNormaliseCoding
        '
        Me.MenuItemNormaliseCoding.Index = 0
        Me.MenuItemNormaliseCoding.Text = CType(configurationAppSettings.GetValue("MenuItemNormaliseCoding.Text", GetType(String)), String)
        '
        'MenuItemAutoCoding
        '
        Me.MenuItemAutoCoding.Index = 1
        Me.MenuItemAutoCoding.Text = CType(configurationAppSettings.GetValue("MenuItemAutoCoding.Text", GetType(String)), String)
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.Text = "-"
        '
        'MenuItemStatistics
        '
        Me.MenuItemStatistics.Index = 4
        Me.MenuItemStatistics.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemNodeCounterPro})
        Me.MenuItemStatistics.Text = CType(configurationAppSettings.GetValue("MenuItemStatistics.Text", GetType(String)), String)
        '
        'MenuItemNodeCounterPro
        '
        Me.MenuItemNodeCounterPro.Index = 0
        Me.MenuItemNodeCounterPro.Text = CType(configurationAppSettings.GetValue("MenuItemNodeCounterPro.Text", GetType(String)), String)
        '
        'MenuItemAdministration
        '
        Me.MenuItemAdministration.Index = 4
        Me.MenuItemAdministration.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemControlAccess, Me.MenuItemUserManagement, Me.MenuItemAuthority, Me.MenuItem13, Me.MenuItemValidation, Me.MenuItemVisibility, Me.MenuItemWebSeparator, Me.MenuItemLog, Me.MenuItemWebStats})
        Me.MenuItemAdministration.Text = CType(configurationAppSettings.GetValue("MenuItemAdministration.Text", GetType(String)), String)
        Me.MenuItemAdministration.Visible = False
        '
        'MenuItemControlAccess
        '
        Me.MenuItemControlAccess.Index = 0
        Me.MenuItemControlAccess.Text = CType(configurationAppSettings.GetValue("MenuItemControlAccess.Text", GetType(String)), String)
        '
        'MenuItemUserManagement
        '
        Me.MenuItemUserManagement.Index = 1
        Me.MenuItemUserManagement.Text = CType(configurationAppSettings.GetValue("MenuItemUserManagement.Text", GetType(String)), String)
        Me.MenuItemUserManagement.Visible = False
        '
        'MenuItemAuthority
        '
        Me.MenuItemAuthority.Enabled = False
        Me.MenuItemAuthority.Index = 2
        Me.MenuItemAuthority.Text = CType(configurationAppSettings.GetValue("MenuItemAuthority.Text", GetType(String)), String)
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 3
        Me.MenuItem13.Text = "-"
        '
        'MenuItemValidation
        '
        Me.MenuItemValidation.Index = 4
        Me.MenuItemValidation.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemMakeValid, Me.MenuItemMakeInvalid})
        Me.MenuItemValidation.Text = CType(configurationAppSettings.GetValue("MenuItemValidation.Text", GetType(String)), String)
        '
        'MenuItemMakeValid
        '
        Me.MenuItemMakeValid.Index = 0
        Me.MenuItemMakeValid.Text = CType(configurationAppSettings.GetValue("MenuItemMakeValid.Text", GetType(String)), String)
        '
        'MenuItemMakeInvalid
        '
        Me.MenuItemMakeInvalid.Index = 1
        Me.MenuItemMakeInvalid.Text = CType(configurationAppSettings.GetValue("MenuItemMakeInvalid.Text", GetType(String)), String)
        '
        'MenuItemVisibility
        '
        Me.MenuItemVisibility.Index = 5
        Me.MenuItemVisibility.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemMakeVisible, Me.MenuItemMakeInvisible})
        Me.MenuItemVisibility.Text = CType(configurationAppSettings.GetValue("MenuItemVisibility.Text", GetType(String)), String)
        '
        'MenuItemMakeVisible
        '
        Me.MenuItemMakeVisible.Index = 0
        Me.MenuItemMakeVisible.Text = CType(configurationAppSettings.GetValue("MenuItemMakeVisible.Text", GetType(String)), String)
        '
        'MenuItemMakeInvisible
        '
        Me.MenuItemMakeInvisible.Index = 1
        Me.MenuItemMakeInvisible.Text = CType(configurationAppSettings.GetValue("MenuItemMakeInvisible.Text", GetType(String)), String)
        '
        'MenuItemWebSeparator
        '
        Me.MenuItemWebSeparator.Index = 6
        Me.MenuItemWebSeparator.Text = "-"
        Me.MenuItemWebSeparator.Visible = False
        '
        'MenuItemLog
        '
        Me.MenuItemLog.Index = 7
        Me.MenuItemLog.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemLogViewer, Me.MenuItemClearLog})
        Me.MenuItemLog.Text = CType(configurationAppSettings.GetValue("MenuItemLog.Text", GetType(String)), String)
        Me.MenuItemLog.Visible = False
        '
        'MenuItemLogViewer
        '
        Me.MenuItemLogViewer.Index = 0
        Me.MenuItemLogViewer.Text = CType(configurationAppSettings.GetValue("MenuItemLogViewer.Text", GetType(String)), String)
        '
        'MenuItemClearLog
        '
        Me.MenuItemClearLog.Index = 1
        Me.MenuItemClearLog.Text = CType(configurationAppSettings.GetValue("MenuItemClearLog.Text", GetType(String)), String)
        '
        'MenuItemWebStats
        '
        Me.MenuItemWebStats.Index = 8
        Me.MenuItemWebStats.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemGlobalStats, Me.MenuItemMonthlyStats})
        Me.MenuItemWebStats.Text = CType(configurationAppSettings.GetValue("MenuItemWebStats.Text", GetType(String)), String)
        Me.MenuItemWebStats.Visible = False
        '
        'MenuItemGlobalStats
        '
        Me.MenuItemGlobalStats.Index = 0
        Me.MenuItemGlobalStats.Text = CType(configurationAppSettings.GetValue("MenuItemGlobalStats.Text", GetType(String)), String)
        '
        'MenuItemMonthlyStats
        '
        Me.MenuItemMonthlyStats.Index = 1
        Me.MenuItemMonthlyStats.Text = CType(configurationAppSettings.GetValue("MenuItemMonthlyStats.Text", GetType(String)), String)
        '
        'MenuItemReports
        '
        Me.MenuItemReports.Index = 5
        Me.MenuItemReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFondsGuide, Me.MenuItemInventoryReport, Me.MenuItemIUInventoryReport, Me.MenuItemCatalogReport, Me.MenuItemInstalationUnitsBySeriesReport, Me.MenuItemIUListReport, Me.MenuItemSeriesListReport, Me.MenuItemClassificationPlanReport, Me.MenuItemControlAccessReport, Me.MenuItemAllControlAccessReport, Me.MenuItemPhyslocReport, Me.MenuItemAuthorsListReport})
        Me.MenuItemReports.Text = CType(configurationAppSettings.GetValue("MenuItemReports.Text", GetType(String)), String)
        Me.MenuItemReports.Visible = False
        '
        'MenuItemFondsGuide
        '
        Me.MenuItemFondsGuide.Index = 0
        Me.MenuItemFondsGuide.Text = CType(configurationAppSettings.GetValue("MainForm.MenuItemFondsGuide.Text", GetType(String)), String)
        '
        'MenuItemInventoryReport
        '
        Me.MenuItemInventoryReport.Index = 1
        Me.MenuItemInventoryReport.Text = CType(configurationAppSettings.GetValue("MenuItemInventoryReport.Text", GetType(String)), String)
        '
        'MenuItemIUInventoryReport
        '
        Me.MenuItemIUInventoryReport.Index = 2
        Me.MenuItemIUInventoryReport.Text = CType(configurationAppSettings.GetValue("MenuItemIUInventoryReport.Text", GetType(String)), String)
        '
        'MenuItemCatalogReport
        '
        Me.MenuItemCatalogReport.Index = 3
        Me.MenuItemCatalogReport.Text = CType(configurationAppSettings.GetValue("MenuItemCatalogReport.Text", GetType(String)), String)
        '
        'MenuItemInstalationUnitsBySeriesReport
        '
        Me.MenuItemInstalationUnitsBySeriesReport.Index = 4
        Me.MenuItemInstalationUnitsBySeriesReport.Text = CType(configurationAppSettings.GetValue("MainForm.MenuItemInstalationUnitsBySeriesReport.Text", GetType(String)), String)
        '
        'MenuItemIUListReport
        '
        Me.MenuItemIUListReport.Index = 5
        Me.MenuItemIUListReport.Text = CType(configurationAppSettings.GetValue("MenuItemIUListReport.Text", GetType(String)), String)
        '
        'MenuItemSeriesListReport
        '
        Me.MenuItemSeriesListReport.Index = 6
        Me.MenuItemSeriesListReport.Text = CType(configurationAppSettings.GetValue("MenuItemSeriesListReport.Text", GetType(String)), String)
        '
        'MenuItemClassificationPlanReport
        '
        Me.MenuItemClassificationPlanReport.Index = 7
        Me.MenuItemClassificationPlanReport.Text = CType(configurationAppSettings.GetValue("MenuItemClassificationPlanReport.Text", GetType(String)), String)
        '
        'MenuItemControlAccessReport
        '
        Me.MenuItemControlAccessReport.Index = 8
        Me.MenuItemControlAccessReport.Text = CType(configurationAppSettings.GetValue("MainFormMenuItemControlAccessReport.Text", GetType(String)), String)
        '
        'MenuItemAllControlAccessReport
        '
        Me.MenuItemAllControlAccessReport.Index = 9
        Me.MenuItemAllControlAccessReport.Text = CType(configurationAppSettings.GetValue("MenuItemAllControlAccessReport.Text", GetType(String)), String)
        '
        'MenuItemPhyslocReport
        '
        Me.MenuItemPhyslocReport.Index = 10
        Me.MenuItemPhyslocReport.Text = "Relatório de localização..."
        '
        'MenuItemAuthorsListReport
        '
        Me.MenuItemAuthorsListReport.Index = 11
        Me.MenuItemAuthorsListReport.Text = CType(configurationAppSettings.GetValue("MenuItemAuthorsListReport.Text", GetType(String)), String)
        '
        'MenuItemHelp
        '
        Me.MenuItemHelp.Index = 6
        Me.MenuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemManual, Me.MenuItem8, Me.MenuItemAbout})
        Me.MenuItemHelp.Text = CType(configurationAppSettings.GetValue("MenuItemHelp.Text", GetType(String)), String)
        Me.MenuItemHelp.Visible = False
        '
        'MenuItemManual
        '
        Me.MenuItemManual.Index = 0
        Me.MenuItemManual.Text = CType(configurationAppSettings.GetValue("MenuItemManual.Text", GetType(String)), String)
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 1
        Me.MenuItem8.Text = "-"
        '
        'MenuItemAbout
        '
        Me.MenuItemAbout.Index = 2
        Me.MenuItemAbout.Text = CType(configurationAppSettings.GetValue("MenuItemAbout.Text", GetType(String)), String)
        '
        'OtherFindAidIcons
        '
        Me.OtherFindAidIcons.ImageStream = CType(resources.GetObject("OtherFindAidIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.OtherFindAidIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.OtherFindAidIcons.Images.SetKeyName(0, "")
        Me.OtherFindAidIcons.Images.SetKeyName(1, "")
        Me.OtherFindAidIcons.Images.SetKeyName(2, "")
        Me.OtherFindAidIcons.Images.SetKeyName(3, "")
        '
        'GenreFormIcons
        '
        Me.GenreFormIcons.ImageStream = CType(resources.GetObject("GenreFormIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.GenreFormIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.GenreFormIcons.Images.SetKeyName(0, "")
        Me.GenreFormIcons.Images.SetKeyName(1, "")
        Me.GenreFormIcons.Images.SetKeyName(2, "")
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.ButtonSize = New System.Drawing.Size(24, 24)
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.ImageList = Me.ViewModeIcons
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(898, 30)
        Me.ToolBar.TabIndex = 1
        '
        'ViewModeIcons
        '
        Me.ViewModeIcons.ImageStream = CType(resources.GetObject("ViewModeIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ViewModeIcons.TransparentColor = System.Drawing.Color.White
        Me.ViewModeIcons.Images.SetKeyName(0, "")
        Me.ViewModeIcons.Images.SetKeyName(1, "")
        Me.ViewModeIcons.Images.SetKeyName(2, "")
        '
        'UpDownArrowButtons
        '
        Me.UpDownArrowButtons.ImageStream = CType(resources.GetObject("UpDownArrowButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.UpDownArrowButtons.TransparentColor = System.Drawing.Color.Transparent
        Me.UpDownArrowButtons.Images.SetKeyName(0, "")
        Me.UpDownArrowButtons.Images.SetKeyName(1, "")
        Me.UpDownArrowButtons.Images.SetKeyName(2, "")
        '
        'ContainerTypeIcons
        '
        Me.ContainerTypeIcons.ImageStream = CType(resources.GetObject("ContainerTypeIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ContainerTypeIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ContainerTypeIcons.Images.SetKeyName(0, "")
        Me.ContainerTypeIcons.Images.SetKeyName(1, "")
        Me.ContainerTypeIcons.Images.SetKeyName(2, "")
        Me.ContainerTypeIcons.Images.SetKeyName(3, "")
        Me.ContainerTypeIcons.Images.SetKeyName(4, "")
        Me.ContainerTypeIcons.Images.SetKeyName(5, "")
        Me.ContainerTypeIcons.Images.SetKeyName(6, "")
        Me.ContainerTypeIcons.Images.SetKeyName(7, "")
        Me.ContainerTypeIcons.Images.SetKeyName(8, "")
        '
        'AltFormAvailIcons
        '
        Me.AltFormAvailIcons.ImageStream = CType(resources.GetObject("AltFormAvailIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.AltFormAvailIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.AltFormAvailIcons.Images.SetKeyName(0, "")
        '
        'imglButtons
        '
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        Me.imglButtons.Images.SetKeyName(0, "")
        Me.imglButtons.Images.SetKeyName(1, "")
        Me.imglButtons.Images.SetKeyName(2, "")
        '
        'TreeView
        '
        Me.TreeView.AllowDrop = True
        Me.TreeView.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView.ImageIndex = 10
        Me.TreeView.ImageList = Me.OtherLevelIcons
        Me.TreeView.ItemHeight = 16
        Me.TreeView.Location = New System.Drawing.Point(0, 30)
        Me.TreeView.Name = "TreeView"
        Me.TreeView.PathSeparator = "/"
        Me.TreeView.ProcessInfoName = Nothing
        Me.TreeView.RootLazyNode = Nothing
        Me.TreeView.SelectedImageIndex = 10
        Me.TreeView.SelectedLazyNode = Nothing
        Me.TreeView.SelectedNodes = CType(resources.GetObject("TreeView.SelectedNodes"), System.Collections.ArrayList)
        Me.TreeView.Size = New System.Drawing.Size(200, 373)
        Me.TreeView.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(898, 425)
        Me.Controls.Add(Me.RightPanel)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TreeView)
        Me.Controls.Add(Me.ToolBar)
        Me.Controls.Add(Me.StatusBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu
        Me.MinimumSize = New System.Drawing.Size(816, 0)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.RightPanel.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region "Properties definition"

    Private FieldPresentationMode As ViewMode
    Private myProcessInfoName As String
    Private LazyNodeDataChanged As Boolean
    Private myProgramState As ProgramState
    Private vfFooterButtons As VisualFieldFooterButtons
    Private count As Integer = 0
    Private WasTaken As Boolean

    Private Enum ViewMode
        All
        Frequent
        Mandatory
    End Enum

    Private Enum AplicationType
        Client
        Standalone
        MiniDigitArq
    End Enum

#End Region


#Region "Form Events"

    Public Sub New(ByVal ProcessInfoName As String)
        Me.New()
        myProcessInfoName = ProcessInfoName
        myProgramState = New ProgramState
        TreeView.ProcessInfoName = myProcessInfoName
        MenuItemAdministration.Visible = myProcessInfoName.Equals("admin")
        MenuItemImport.Enabled = myProcessInfoName.Equals("admin")
        MenuItemWebSearch.Visible = Constant("AdvancedWebSearchURL").Length > 0
        MenuItemWebStats.Visible = Constant("MonthlyStatsURL").Length > 0 And Constant("GlobalStatsURL").Length > 0
        MenuItemLog.Visible = Constant("LogViewerURL").Length > 0
        MenuItemWebSeparator.Visible = MenuItemWebStats.Visible OrElse MenuItemLog.Visible
        SetFormTitle("[" & myProcessInfoName & "]")
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        FieldPresentationMode = ViewMode.All
        LazyNodeDataChanged = False
        Me.MenuItemAskBeforeSave.Checked = myProgramState.AskBeforeSave



        'OpenLogin(True)

        '** Cut here
        'myProcessInfoName = "admin" ' Para nao ter que fazer login
        'TreeView.myProcessInfoName = myProcessInfoName ' Para nao ter que fazer login
        'MenuItemAdministration.Visible = myProcessInfoName.Equals("admin") ' Para nao ter que fazer login
        '** Cut here

        OpenFonds()
    End Sub

    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        UploadSelectedLazyNode()
        SaveProgramState()
        Log.Append(myProcessInfoName, Log.LogActions.CloseApplication, LogMessage("Log.ClosedApplication"))
    End Sub


#End Region


#Region "Program and Component Initializations"

    Private Sub Initialize()
        VScrollBar = New VScrollBar
        VScrollBar.Dock = DockStyle.Right
        VScrollBar.SmallChange = 50
        VScrollBar.LargeChange = 200
    End Sub

#End Region


#Region "Methods that display external forms"


    Private Sub OpenFonds()
        Dim FondsToOpen As LazyNode
        Dim ID As Integer = myProgramState.LastOpenedFonds
        Dim LastUsedNode As LazyNode

        If ID <> 0 Then ' Load Last Opened Fonds
            Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
            Try
                Dim RootNode As LazyNode = New SQLLazyNode(SQLServerSettings.Item("ServerAddress"), _
                                                           SQLServerSettings.Item("Database"), _
                                                           SQLServerSettings.Item("Username"), _
                                                           SQLServerSettings.Item("Password"), _
                                                           ID)
                If myProgramState.LastUsedNode <> 0 Then
                    LastUsedNode = New SQLLazyNode(SQLServerSettings.Item("ServerAddress"), _
                                                               SQLServerSettings.Item("Database"), _
                                                               SQLServerSettings.Item("Username"), _
                                                               SQLServerSettings.Item("Password"), _
                                                               myProgramState.LastUsedNode)
                Else
                    LastUsedNode = RootNode
                End If
                FondsToOpen = RootNode
            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            End Try
            TreeView.RootLazyNode = FondsToOpen
            TreeView.RootLazyNode.SortBy = GetSelectedSortStyle()
            Log.Append(myProcessInfoName, LogActions.OpenFonds, String.Format(LogMessage("Log.OpenFonds"), FondsToOpen.UnitId & ":" & FondsToOpen.UnitTitle))
            EnableMenus(True)
            TreeView.SelectedNode = TreeView.RootTreeNode
            TreeView_AfterSelect(Me, Nothing)

            If MsgBox(InfoMessage("OpenFonds.GotoLastUsedNode"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                TreeView.SelectedLazyNode = LastUsedNode
            End If
        Else ' Open Fonds Manager
            OpenFondsManager()
        End If
    End Sub

    Private Sub OpenFondsManager()
        Cursor.Current = Cursors.WaitCursor
        Dim FondsToOpen As LazyNode
        Dim frmFondsManager As New FondsManagerForm(myProcessInfoName, False, myProgramState)
        If frmFondsManager.ShowDialog() = DialogResult.OK Then
            ' get fonds name and open it
            FondsToOpen = frmFondsManager.SelectedFonds

            TreeView.RootLazyNode = FondsToOpen
            TreeView.RootLazyNode.SortBy = GetSelectedSortStyle()
            Log.Append(myProcessInfoName, LogActions.OpenFonds, String.Format(LogMessage("Log.OpenFonds"), FondsToOpen.UnitId & ":" & FondsToOpen.UnitTitle))
            EnableMenus(True)
            TreeView.SelectedNode = TreeView.RootTreeNode
            TreeView_AfterSelect(Me, Nothing)
        End If
        frmFondsManager.Dispose()
    End Sub

    Private Sub OpenControlAccess()
        Cursor.Current = Cursors.WaitCursor
        Dim frmControlAccess As ControlAccessForm

        If TreeView.RootTreeNode Is Nothing Then
            frmControlAccess = New ControlAccessForm
        Else
            frmControlAccess = New ControlAccessForm(CType(TreeView.RootLazyNode, SQLLazyNode).ID)
        End If
        frmControlAccess.ShowDialog()
    End Sub

    Private Sub OpenLogin()
        Dim frmLogin As New Authentication.LoginForm

        If frmLogin.ShowDialog() = DialogResult.OK Then
            myProcessInfoName = frmLogin.Username
            TreeView.ProcessInfoName = myProcessInfoName
            Log.Append(myProcessInfoName, LogActions.Login, String.Format(LogMessage("Log.Login"), myProcessInfoName, Date.Now.ToString))
            MenuItemAdministration.Visible = myProcessInfoName.Equals("admin")
            MenuItemImport.Enabled = myProcessInfoName.Equals("admin")
        End If
        SetFormTitle("[" & myProcessInfoName & "]")
    End Sub

    'Private Sub OpenLogin(ByVal ExitApplicationOnCancel As Boolean)
    '    Dim frmLogin As New LoginForm

    '    If frmLogin.ShowDialog() = DialogResult.Cancel Then
    '        If ExitApplicationOnCancel Then
    '            ExitApplication()
    '            MsgBox("Devia ter fechado")
    '        End If
    '    Else
    '        myProcessInfoName = frmLogin.Username
    '        TreeView.ProcessInfoName = myProcessInfoName
    '        Log.Append(myProcessInfoName, LogActions.Login, String.Format(LogMessage("Log.Login"), myProcessInfoName, Date.Now.ToString))
    '        MenuItemAdministration.Visible = myProcessInfoName.Equals("admin")
    '        MenuItemImport.Enabled = myProcessInfoName.Equals("admin")
    '    End If
    '    Me.Text &= " " & myProcessInfoName
    'End Sub

    'Private Sub OpenUsersManager()
    '    Dim frmUsersManager As New UsersManagerForm
    '    frmUsersManager.ShowDialog()
    'End Sub

    Private Sub OpenAuthority()
        If Not (TreeView.SelectedLazyNode.OtherLevel = EADDefinitions.OTHERLEVEL_FONDS Or _
                TreeView.SelectedLazyNode.OtherLevel = EADDefinitions.OTHERLEVEL_SUBFONDS) Then
            Exit Sub
        End If
        Dim frmAuthority As New AuthoritiesForm(TreeView.SelectedLazyNode)
        frmAuthority.ShowDialog()
    End Sub

#End Region


#Region "Visual Fields Drawing"

    Private Sub RedrawVisualFields()
        Dim AplicationType As AplicationType = GetAplicationType()
        DisableControls(AplicationType)
        DisplayNumberFieldsInTabPages(TreeView.SelectedLazyNode, AplicationType)
        DrawVisualFields(TreeView.SelectedLazyNode, AplicationType)
        StatusBar.Text = VisualFieldLabel("FullPathUnitId") & " " & GetFullPath(TreeView.SelectedNode)
    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect
        Dim AplicationType As AplicationType = GetAplicationType()
        DisableControls(AplicationType)
        TreeView.SelectedLazyNode.Download()
        DisplayNumberFieldsInTabPages(TreeView.SelectedLazyNode, AplicationType)
        DrawVisualFields(TreeView.SelectedLazyNode, AplicationType)
        StatusBar.Text = VisualFieldLabel("FullPathUnitId") & " " & GetFullPath(TreeView.SelectedNode)
        EnableDisableMenuItems()
    End Sub

    Private Sub TreeView_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView.BeforeSelect
        UploadSelectedLazyNode()
    End Sub


    Private Function CountVisualFields(ByVal ConfigurationGroup As String, ByVal LazyNode As LazyNode, ByVal AplicationType As AplicationType) As Integer
        Dim AreaFields As NameValueCollection
        Dim ViewMode As String
        Select Case AplicationType
            Case AplicationType.Client
                ViewMode = ViewModeToConfigSection(Me.FieldPresentationMode)
            Case AplicationType.Standalone
                ViewMode = ViewModeToConfigSection(Me.FieldPresentationMode)
            Case AplicationType.MiniDigitArq
                ViewMode = "miniDigitArqFields"
        End Select

        'AreaFields = CType(ConfigurationSettings.GetConfig(ViewMode & "/" & ConfigurationGroup & "/" & LazyNode.OtherLevel), NameValueCollection)
        AreaFields = CType(ConfigurationManager.GetSection(ViewMode & "/" & ConfigurationGroup & "/" & LazyNode.OtherLevel), NameValueCollection)
        If AreaFields Is Nothing Then Return 0
        Return AreaFields.Keys().Count
    End Function


    Private Sub DisplayNumberFieldsInTabPage(ByVal TabPage As TabPage, ByVal NumberFields As Integer)
        Dim endIndex As Integer = TabPage.Text.LastIndexOf("[") - 1
        If endIndex < 0 Then endIndex = TabPage.Text.Length
        Dim TabName As String = TabPage.Text.Substring(0, endIndex)
        TabPage.Text = String.Format("{0} [{1}]", TabName, NumberFields)
    End Sub

    Private Sub DisableControls(ByVal AplicationType As AplicationType)
        Select Case AplicationType
            Case AplicationType.MiniDigitArq
                Me.MenuItemImport.Visible = False
                Me.MenuItemAllFields.Visible = False
                Me.MenuItemMostFrequentFields.Visible = False
                Me.MenuItemMandatoryFields.Visible = False
                Me.MenuItemStatistics.Visible = False
                Me.MenuItemControlAccess.Visible = False
                Me.MenuItemValidation.Visible = False
                Me.MenuItemLog.Visible = False
                Me.MenuItemWebStats.Visible = False
                Me.MenuItemReports.Visible = False
                Me.MenuItemUserManagement.Visible = True

                Me.tpAllArea.Text = CType(configurationAppSettings.GetValue("tpDescriptionArea.Text", GetType(System.String)), String)
                Me.TabControl.Controls.Remove(tpAlliedMaterialArea)
                Me.TabControl.Controls.Remove(tpConditionsAccessUseArea)
                Me.TabControl.Controls.Remove(tpContentStructureArea)
                Me.TabControl.Controls.Remove(tpContextArea)
                Me.TabControl.Controls.Remove(tpDescriptionControl)
                Me.TabControl.Controls.Remove(tpIndentityArea)
                Me.TabControl.Controls.Remove(tpNoteArea)
            Case AplicationType.Standalone
                Me.MenuItemUserManagement.Visible = True
        End Select
    End Sub

    Private Sub DisplayNumberFieldsInTabPages(ByVal LazyNode As LazyNode, ByVal AplicationType As AplicationType)
        Select Case AplicationType
            Case AplicationType.Client
                DisplayNumberFieldsInTabPage(Me.tpIndentityArea, CountVisualFields("identityArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpContextArea, CountVisualFields("contextArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpContentStructureArea, CountVisualFields("contentStructureArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpConditionsAccessUseArea, CountVisualFields("useAccessArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpAlliedMaterialArea, CountVisualFields("alliedMaterialArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpNoteArea, CountVisualFields("noteArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpDescriptionControl, CountVisualFields("descriptionControlArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpAllArea, CountVisualFields("allFieldsArea", LazyNode, AplicationType))
            Case AplicationType.Standalone
                DisplayNumberFieldsInTabPage(Me.tpIndentityArea, CountVisualFields("identityArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpContextArea, CountVisualFields("contextArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpContentStructureArea, CountVisualFields("contentStructureArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpConditionsAccessUseArea, CountVisualFields("useAccessArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpAlliedMaterialArea, CountVisualFields("alliedMaterialArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpNoteArea, CountVisualFields("noteArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpDescriptionControl, CountVisualFields("descriptionControlArea", LazyNode, AplicationType))
                DisplayNumberFieldsInTabPage(Me.tpAllArea, CountVisualFields("allFieldsArea", LazyNode, AplicationType))
            Case AplicationType.MiniDigitArq
                DisplayNumberFieldsInTabPage(Me.tpAllArea, CountVisualFields("descriptionArea", LazyNode, AplicationType))
        End Select
    End Sub


    Private Sub DrawVisualFields(ByVal LazyNode As LazyNode, ByVal AplicationType As AplicationType)
        If LazyNode Is Nothing Then Exit Sub
        If Me.TabControl.SelectedTab Is Nothing Then Exit Sub
        Me.TabControl.SelectedTab.Controls.Clear()

        Select Case AplicationType
            Case AplicationType.Client
                If Me.TabControl.SelectedTab Is Me.tpIndentityArea Then
                    DrawVisualFieldsByArea(LazyNode, "identityArea", tpIndentityArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpContextArea Then
                    DrawVisualFieldsByArea(LazyNode, "contextArea", tpContextArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpContentStructureArea Then
                    DrawVisualFieldsByArea(LazyNode, "contentStructureArea", tpContentStructureArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpConditionsAccessUseArea Then
                    DrawVisualFieldsByArea(LazyNode, "useAccessArea", tpConditionsAccessUseArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpAlliedMaterialArea Then
                    DrawVisualFieldsByArea(LazyNode, "alliedMaterialArea", tpAlliedMaterialArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpNoteArea Then
                    DrawVisualFieldsByArea(LazyNode, "noteArea", tpNoteArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpDescriptionControl Then
                    DrawVisualFieldsByArea(LazyNode, "descriptionControlArea", tpDescriptionControl, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpAllArea Then
                    DrawVisualFieldsByArea(LazyNode, "allFieldsArea", tpAllArea, AplicationType)
                End If
            Case AplicationType.Standalone
                If Me.TabControl.SelectedTab Is Me.tpIndentityArea Then
                    DrawVisualFieldsByArea(LazyNode, "identityArea", tpIndentityArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpContextArea Then
                    DrawVisualFieldsByArea(LazyNode, "contextArea", tpContextArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpContentStructureArea Then
                    DrawVisualFieldsByArea(LazyNode, "contentStructureArea", tpContentStructureArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpConditionsAccessUseArea Then
                    DrawVisualFieldsByArea(LazyNode, "useAccessArea", tpConditionsAccessUseArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpAlliedMaterialArea Then
                    DrawVisualFieldsByArea(LazyNode, "alliedMaterialArea", tpAlliedMaterialArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpNoteArea Then
                    DrawVisualFieldsByArea(LazyNode, "noteArea", tpNoteArea, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpDescriptionControl Then
                    DrawVisualFieldsByArea(LazyNode, "descriptionControlArea", tpDescriptionControl, AplicationType)
                ElseIf Me.TabControl.SelectedTab Is Me.tpAllArea Then
                    DrawVisualFieldsByArea(LazyNode, "allFieldsArea", tpAllArea, AplicationType)
                End If
            Case AplicationType.MiniDigitArq
                DrawVisualFieldsByArea(LazyNode, "descriptionArea", tpAllArea, AplicationType)
        End Select

        UpdateVScrollBar(Me.TabControl.SelectedTab)
        Me.TabControl.SelectedTab.Controls.Add(VScrollBar)

    End Sub


    Private Sub DrawVisualFieldsByArea(ByVal LazyNode As LazyNode, ByVal ConfigurationGroup As String, ByVal TabPage As TabPage, ByVal AplicationType As AplicationType)
        Dim AreaFields As NameValueCollection
        Dim ViewMode As String
        Select Case AplicationType
            Case AplicationType.Client
                ViewMode = ViewModeToConfigSection(Me.FieldPresentationMode)
            Case AplicationType.Standalone
                ViewMode = ViewModeToConfigSection(Me.FieldPresentationMode)
            Case AplicationType.MiniDigitArq
                ViewMode = "miniDigitArqFields"
        End Select

        AreaFields = CType(ConfigurationManager.GetSection(ViewMode & "/" & ConfigurationGroup & "/" & LazyNode.OtherLevel), NameValueCollection)
        If AreaFields Is Nothing Then Exit Sub

        Dim GroupName As String
        For Each GroupName In AreaFields.Keys()
            DrawVisualFieldGroup(GroupName, AreaFields.GetValues(GroupName), LazyNode, TabPage)
        Next
    End Sub

    Private Sub DrawVisualFieldGroup(ByVal GroupName As String, ByVal VisualFieldNames() As String, ByVal LazyNode As LazyNode, ByVal TabPage As TabPage)
        If VisualFieldNames Is Nothing Then Exit Sub
        Dim VisualFieldName As String

        Dim GroupBox As New GroupBox
        GroupBox.Name = GroupName
        GroupBox.Size = New Size(520, 1)
        GroupBox.BackColor = Color.FromArgb(255, 240, 240, 240)

        Dim PositionY As Integer = 15
        Dim PositionX As Integer = 15

        For Each VisualFieldName In VisualFieldNames
            Dim VisualField As VisualField = VisualFieldByName(VisualFieldName, LazyNode)
            If TypeOf (VisualField) Is VisualFieldFooterButtons Then GroupBox.BackColor = Color.FromArgb(255, 255, 250, 250)
            AddHandler VisualField.DataChanged, AddressOf SetLazyNodeDataChanged
            If Not VisualField Is Nothing Then
                VisualField.Location = New Point(PositionX, PositionY)
                PositionY = VisualField.Location.Y + VisualField.Height + 5
                GroupBox.Size = New Size(GroupBox.Width, GroupBox.Height + VisualField.Height + 5)
                GroupBox.Controls.Add(VisualField)
            End If
        Next
        GroupBox.Size = New Size(GroupBox.Width, GroupBox.Height + 20)

        Dim LastFieldGroup As GroupBox
        If TabPage.Controls.Count = 0 Then
            GroupBox.Location = New Point(15, 15)
        Else
            LastFieldGroup = TabPage.Controls.Item(TabPage.Controls.Count - 1)
            GroupBox.Location = New Point(LastFieldGroup.Location.X, LastFieldGroup.Location.Y + LastFieldGroup.Height + 5)
        End If
        TabPage.Controls.Add(GroupBox)
    End Sub


    Private Sub SetLazyNodeDataChanged(ByVal Sender As Object, ByVal Value As Object)
        Dim TakenBy As String = GetNodeTaken(TreeView.SelectedLazyNode.ID)
        If TakenBy.Equals("") Or TakenBy = myProcessInfoName Then
            If WasTaken Then
                TreeView.SelectedLazyNode.Download()
                'DisplayNumberFieldsInTabPages(TreeView.SelectedLazyNode, AplicationType)
                DrawVisualFields(TreeView.SelectedLazyNode, GetAplicationType())
                WasTaken = False
            End If
            SetNodeTaken(TreeView.SelectedLazyNode.ID, myProcessInfoName)
            LazyNodeDataChanged = True
            vfFooterButtons.EnableSaveButton(True)
        Else
            MsgBox(String.Format(ErrorMessage("RegisterTaken"), """" & TakenBy & """"), MsgBoxStyle.Exclamation, InfoMessage("TakenWarning.Title"))
            vfFooterButtons.EnableSaveButton(False)
            WasTaken = True
        End If
    End Sub


    Private Function GetNodeTaken(ByVal ComponentID As Int64) As String
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Return SQLLazyNode.GetTaken(SQLServerSettings.Item("ServerAddress"), _
                                    SQLServerSettings.Item("Database"), _
                                    SQLServerSettings.Item("Username"), _
                                    SQLServerSettings.Item("Password"), _
                                    ComponentID)
    End Function

    Private Sub SetNodeTaken(ByVal ComponentID As Int64, ByVal TakenBy As String)
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        SQLLazyNode.SetTaken(SQLServerSettings.Item("ServerAddress"), _
                                    SQLServerSettings.Item("Database"), _
                                    SQLServerSettings.Item("Username"), _
                                    SQLServerSettings.Item("Password"), _
                                    ComponentID, TakenBy)
    End Sub


    Private Function VisualFieldByName(ByVal FieldName As String, ByVal LazyNode As LazyNode)
        Select Case FieldName
            Case "UnitId" : Return New VisualFieldUnitId(LazyNode)
            Case "UnitTitle" : Return New VisualFieldUnitTitle(LazyNode, Me.OtherLevelIcons)
            Case "UnitDates"
                Dim VisualFieldUnitDates As New VisualFieldUnitDates(LazyNode)
                AddHandler VisualFieldUnitDates.InferenceButtonClicked, AddressOf Me.RedrawVisualFields
                Return VisualFieldUnitDates
            Case "OtherLevel" : Return New VisualFieldOtherLevel(LazyNode, Me.OtherLevelIcons, TopOtherLevelIndex, BottomOtherLevelIndex)
            Case "Separator" : Return New VisualFieldSeparator ' Do some kind of separator
            Case "Extents"
                Dim VisualFieldExtents As New VisualFieldExtents(LazyNode)
                AddHandler VisualFieldExtents.InferenceButtonClicked, AddressOf Me.RedrawVisualFields
                Return VisualFieldExtents
            Case "ContainerExtents" : Return New VisualFieldContainerExtents(LazyNode)
            Case "Dimensions" : Return New VisualFieldDimensions(LazyNode)
            Case "Repository" : Return New VisualFieldRepository(LazyNode)
            Case "Abstract" : Return New VisualFieldAbstract(LazyNode)
            Case "GenreForm" : Return New VisualFieldGenreForm(LazyNode)
            Case "ContainerType" : Return New VisualFieldContainerType(LazyNode, ContainerTypeIcons)

            Case "Author" : Return New VisualFieldAuthor(LazyNode)
            Case "AuthorAddress" : Return New VisualFieldAuthorAddress(LazyNode)
            Case "Destination" : Return New VisualFieldDestination(LazyNode)
            Case "DestinationAddress" : Return New VisualFieldDestinationAddress(LazyNode)
            Case "Notary" : Return New VisualFieldNotary(LazyNode)
            Case "Scrivener" : Return New VisualFieldScrivener(LazyNode)

            Case "BiogHist" : Return New VisualFieldBiogHist(LazyNode)
            Case "CustodHist" : Return New VisualFieldCustodHist(LazyNode)
            Case "AcqInfo" : Return New VisualFieldAcqInfo(LazyNode)
            Case "OtherFindAid" : Return New VisualFieldOtherFindAid(LazyNode)
            Case "ScopeContent" : Return New VisualFieldScopeContent(LazyNode)
            Case "Appraisal" : Return New VisualFieldAppraisal(LazyNode)
            Case "Accruals" : Return New VisualFieldAccruals(LazyNode)
            Case "Arrangement" : Return New VisualFieldArrangement(LazyNode)
            Case "FilePlan" : Return New VisualFieldFilePlan(LazyNode)
            Case "AccessRestrict" : Return New VisualFieldAccessRestrict(LazyNode)
            Case "UseRestrict" : Return New VisualFieldUseRestrict(LazyNode)
            Case "LangMaterial" : Return New VisualFieldLangMaterial(LazyNode)
            Case "PhysTech" : Return New VisualFieldPhysTech(LazyNode)
            Case "MaterialSpec" : Return New VisualFieldMaterialSpec(LazyNode)
            Case "PhysFacet" : Return New VisualFieldPhysFacet(LazyNode)
            Case "PhysLoc" : Return New VisualFieldPhysLoc(LazyNode)
            Case "OriginalsLoc" : Return New VisualFieldOriginalsLoc(LazyNode)
            Case "RelatedMaterial" : Return New VisualFieldRelatedMaterial(LazyNode)
            Case "SeparatedMaterial" : Return New VisualFieldSeparatedMaterial(LazyNode)
            Case "Note" : Return New VisualFieldNote(LazyNode)
            Case "ProcessInfo" : Return New VisualFieldProcessInfo(LazyNode)
            Case "PreferCite" : Return New VisualFieldPreferCite(LazyNode)
            Case "AltFormAvail" : Return New VisualFieldAltFormAvail(LazyNode, AltFormAvailIcons)
            Case "OriginalNumbering" : Return New VisualFieldOriginalNumbering(LazyNode)
            Case "LegalStatus" : Return New VisualFieldLegalStatus(LazyNode)
            Case "GeogName" : Return New VisualFieldGeogName(LazyNode)
            Case "Bibliography" : Return New VisualFieldBibliography(LazyNode, UpDownArrowButtons)
            Case "ChronList" : Return New VisualFieldChronList(LazyNode, UpDownArrowButtons)
            Case "ControlAccess" : Return New VisualFieldControlAccess(LazyNode, UpDownArrowButtons, TreeView.RootLazyNode.ID)
            Case "ArchivistNotes" : Return New VisualFieldArchivistNotes(LazyNode, UpDownArrowButtons, myProcessInfoName)
            Case "FooterButtons"
                vfFooterButtons = New VisualFieldFooterButtons(LazyNode, Me.imglButtons)
                AddHandler vfFooterButtons.NewNode, AddressOf Me.NewNodeButton_Clicked
                AddHandler vfFooterButtons.ReplicateNode, AddressOf Me.ReplicateNodeButton_Clicked
                AddHandler vfFooterButtons.SaveNode, AddressOf Me.SaveNodeButton_Clicked
                vfFooterButtons.EnableSaveButton(False)
                Return vfFooterButtons
            Case Else
                MsgBox("Unknown Field: " & FieldName)
                Return Nothing
        End Select
    End Function


    ' Draws controls whenever we change tabs... only updates the selected tab
    Private Sub TabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                                Handles TabControl.SelectedIndexChanged
        Dim AplicationType As String = GetAplicationType()
        DrawVisualFields(TreeView.SelectedLazyNode, AplicationType)

    End Sub

#End Region


#Region "Footer Button events"

    Private Sub NewNodeButton_Clicked()
        If Not TreeView.SelectedNode Is Nothing Then
            TreeView.AppendNewChild(TreeView.SelectedNode.Parent, TreeView.SelectedLazyNode.OtherLevel)
        End If
    End Sub

    Private Sub ReplicateNodeButton_Clicked()
        If Not TreeView.SelectedNode Is Nothing Then
            TreeView.CopyNode(TreeView.SelectedNode)
            TreeView.PasteNodes(TreeView.SelectedNode.Parent, True)
        End If
    End Sub

    Private Sub SaveNodeButton_Clicked()
        If Not TreeView.SelectedNode Is Nothing Then
            UploadSelectedLazyNode()
            RedrawVisualFields()
        End If
    End Sub


#End Region


#Region "Some auxiliary functions"

    Private Sub OpenInternetExplorer(ByVal URL As String)
        Dim ie As New SHDocVw.InternetExplorerClass
        Dim wb As IWebBrowserApp = CType(ie, IWebBrowserApp)
        wb.Visible = True
        wb.Navigate(URL, Nothing, Nothing, Nothing, Nothing)
    End Sub


    Private Sub SetFormTitle(ByVal Title As String)
        Me.Text = GetStandardFormTitle() & " " & Title
    End Sub

    Private Function GetStandardFormTitle() As String
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Return String.Format(CStr(configurationAppSettings.GetValue("MainForm.Text", GetType(System.String))), CStr(configurationAppSettings.GetValue("Application.Version", GetType(System.String))))
    End Function

    Private Sub UploadSelectedLazyNode()
        Dim LazyNode As LazyNode = TreeView.SelectedLazyNode

        If Not LazyNode Is Nothing AndAlso LazyNodeDataChanged Then
            If Me.MenuItemAskBeforeSave.Checked AndAlso MsgBox(InfoMessage("MainForm.AskBeforeSave"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton1) = MsgBoxResult.No Then
                LazyNode.Download()
                LazyNodeDataChanged = False
                Exit Sub
            End If
            LazyNode.UpdateProcessInfo(myProcessInfoName)
            LazyNode.Valid = False
            LazyNode.Visible = False
            LazyNode.TakenBy = ""
            LazyNode.Upload()
            TreeView.UpdateTreeNode(TreeView.SelectedNode)
            LazyNodeDataChanged = False
            Log.Append(myProcessInfoName, Log.LogActions.EditNode, String.Format(LogMessage("Log.EditNode"), LazyNode.OtherLevel, LazyNode.UnitId))
        End If
    End Sub

    Private Sub EnableDisableMenuItems()
        If TreeView.SelectedLazyNode Is Nothing Then Exit Sub

        Me.MenuItemMakeInvalid.Visible = TreeView.SelectedLazyNode.Valid
        Me.MenuItemMakeValid.Visible = Not Me.MenuItemMakeInvalid.Visible
        Me.MenuItemMakeInvisible.Visible = TreeView.SelectedLazyNode.Visible
        Me.MenuItemMakeVisible.Visible = Not MenuItemMakeInvisible.Visible
        'Me.MenuItemVisibility.Visible = TreeView.SelectedLazyNode.Valid
        Me.MenuItemVisibility.Visible = True
        Me.MenuItemAuthority.Enabled = TreeView.SelectedLazyNode.OtherLevel = EADDefinitions.OTHERLEVEL_FONDS Or TreeView.SelectedLazyNode.OtherLevel = EADDefinitions.OTHERLEVEL_SUBFONDS
    End Sub

    Private Sub AutoCoding(ByVal StartNumber As Integer, ByVal SelectedNodes As ArrayList)
        Dim Node As TreeNode
        Dim LazyNode As LazyNode
        Dim NewCode As String

        Dim Code As Integer = StartNumber
        Cursor.Current = Cursors.WaitCursor
        For Each Node In SelectedNodes
            LazyNode = LazyTree.GetLazyNode(Node)
            NewCode = FormatNumericCode(Code, LazyNode.OtherLevel)
            LazyNode.UnitId = NewCode
            Node.Text = NewCode
            LazyNode.Upload()
            Code += 1
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub NormaliseCoding(ByVal SelectedNodes As ArrayList)
        Dim Node As TreeNode
        Dim LazyNode As LazyNode
        Dim NewCode As String

        Dim Code As Integer
        Cursor.Current = Cursors.WaitCursor
        For Each Node In SelectedNodes
            Code = StrToInt(LazyTree.GetLazyNode(Node).UnitId)
            If Code <> 0 Then
                LazyNode = LazyTree.GetLazyNode(Node)
                NewCode = FormatNumericCode(Code, LazyNode.OtherLevel)
                LazyNode.UnitId = NewCode
                Node.Text = NewCode
                LazyNode.Upload()
            End If
        Next
        Cursor.Current = Cursors.Default
    End Sub


    Private Function FormatNumericCode(ByVal Code As Integer, ByVal OtherLevel As String) As String
        If OtherLevel = EADDefinitions.OTHERLEVEL_SERIES OrElse _
               OtherLevel = EADDefinitions.OTHERLEVEL_SUBSERIES Then
            Return String.Format("{0:000}", Code)
        ElseIf OtherLevel = OTHERLEVEL_INSTALATIONUNIT Then
            Return String.Format("{0:0000}", Code)
        ElseIf OtherLevel = OTHERLEVEL_COMPOSEDDOCUMENT OrElse _
               OtherLevel = OTHERLEVEL_DOCUMENT Then
            Return String.Format("{0:00000}", Code)
        Else
            Dim ret As String = Chr(Code)
            Return ret.ToUpper
        End If
    End Function

    Private Function GetSelectedSortStyle() As LazyNode.SortingStyles
        If MenuItemSortByUnitID.Checked Then
            Return LazyNode.SortingStyles.ByUnitID
        ElseIf MenuItemSortByUnitDateInitial.Checked Then
            Return LazyNode.SortingStyles.ByUnitDateInitial
        Else
            Return LazyNode.SortingStyles.ByOtherLevel
        End If
    End Function

    Private Function TopOtherLevelIndex() As Integer
        If TreeView.SelectedNode Is TreeView.RootTreeNode Then
            Return 1
        Else
            Return TreeView.SelectedNode.Parent.SelectedImageIndex + 1
        End If
    End Function

    Private Function BottomOtherLevelIndex() As Integer
        If TreeView.SelectedNode Is TreeView.RootTreeNode Then Return 1

        Dim elem As LazyNode
        Dim LazyNode As LazyNode = TreeView.SelectedLazyNode
        Dim min As Integer = EADDefinitions.GetOtherLevelIndex(OTHERLEVEL_DOCUMENT) + 1

        If LazyNode Is Nothing Then Return min

        For Each elem In LazyNode.Children
            min = Math.Min(min, elem.OtherLevelIndex)
            Debug.WriteLine("Comparing node  indexes (" & elem.UnitId & "): " & min & " <> " & LazyNode.OtherLevelIndex)
            If min = LazyNode.OtherLevelIndex + 1 Then
                Debug.WriteLine("Got to the end of BottomOtherLevelIndex")
                Return min - 1
            End If
        Next
        Debug.WriteLine("Min = " & min - 1)
        Return min - 1
    End Function

    Private Function ViewModeToConfigSection(ByVal mode As ViewMode) As String
        Select Case FieldPresentationMode
            Case ViewMode.All : Return "allFields"
            Case ViewMode.Frequent : Return "frequentFields"
            Case ViewMode.Mandatory : Return "mandatoryFields"
        End Select
    End Function

    Private Function GetFullPath(ByVal Node As TreeNode) As String
        If Node Is Nothing Then
            Return ""
        ElseIf Node.Parent Is Nothing Then
            Dim LazyNode As LazyNode = CType(Node.Tag, LazyNode)
            Dim CountryCode As String = LazyNode.CountryCode
            Dim RepositoryCode As String = LazyNode.RepositoryCode
            If Not CountryCode Is Nothing And Not RepositoryCode Is Nothing Then
                Return CountryCode.ToUpper & "/" & RepositoryCode.ToUpper & "/" & _
                                CType(Node.Tag, LazyNode).UnitId
            End If
        ElseIf Node.ImageIndex = GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBFONDS) OrElse _
               Node.ImageIndex = GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSECTION) OrElse _
               Node.ImageIndex = GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSERIES) OrElse _
               Node.ImageIndex = GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSUBSECTION) Then
            Return GetFullPath(Node.Parent) & "-" & CType(Node.Tag, LazyNode).UnitId
        Else
            Return GetFullPath(Node.Parent) & "/" & CType(Node.Tag, LazyNode).UnitId
        End If

    End Function

    Private Sub EnableMenus(ByVal State As Boolean)
        Me.MenuItemEdit.Visible = State
        Me.MenuItemView.Visible = State
        Me.MenuItemTools.Visible = State
        Me.MenuItemReports.Visible = State
        Me.MenuItemImport.Visible = State
        Me.MenuItemExport.Visible = State
        Me.MenuItemFileSeparator1.Visible = State
        Me.MenuItemFileSeparator2.Visible = State
    End Sub

    Private Sub ExitApplication()
        Application.DoEvents()
        Application.Exit()
        Application.DoEvents()
    End Sub

    Private Function GetAplicationType() As AplicationType
        Dim Constants As Hashtable = ConfigurationManager.GetSection("constants")

        Return CType(Constants.Item("AplicationType"), AplicationType)
    End Function

#End Region


#Region "TabPages Scrolling"
    Private WithEvents VScrollBar As VScrollBar
    Private OldScrollPosition As Integer

    Sub UpdateVScrollBar(ByVal TabPage As TabPage)
        Dim iTabPageHeight As Integer
        Dim iDisplayHeight As Integer
        OldScrollPosition = 0
        iTabPageHeight = getFullTabPageHeight(TabPage)
        iDisplayHeight = TabPage.Height

        'Me.Height = iDisplayHeight
        With VScrollBar
            .Minimum = 0
            .Maximum = Math.Max(iTabPageHeight - iDisplayHeight, 0)
        End With
    End Sub


    Private Function getFullTabPageHeight(ByVal tabPage As TabPage) As Integer
        Dim ctl As Control
        Dim maxHeight As Integer = 0

        For Each ctl In tabPage.Controls
            If (TypeOf ctl Is GroupBox) Then
                maxHeight = Math.Max(ctl.Location.Y + ctl.Height, maxHeight)
            End If
        Next
        Return maxHeight + 220
    End Function


    Private Sub ScrollTabPage(ByVal TabPage As TabPage)
        Dim ctl As Control
        For Each ctl In TabPage.Controls
            If (TypeOf ctl Is GroupBox) Then
                ctl.Top = ctl.Top + OldScrollPosition - VScrollBar.Value
            End If
        Next
        OldScrollPosition = VScrollBar.Value
    End Sub

    Private Sub VScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar.Scroll
        ScrollTabPage(Me.TabControl.SelectedTab)
    End Sub


    Private Sub VScrollBar_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar.ValueChanged
        ScrollTabPage(Me.TabControl.SelectedTab)
    End Sub

    Private Sub MainForm_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        UpdateVScrollBar(Me.TabControl.SelectedTab)
    End Sub
#End Region


#Region "Menu Events"

    Private Sub MenuItemLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemLogin.Click
        UploadSelectedLazyNode()
        OpenLogin()
    End Sub

    Private Sub MenuItemCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCopy.Click
        UploadSelectedLazyNode()
        TreeView.CopyNodes(TreeView.SelectedNodes())
        MenuItemPaste.Enabled = True
    End Sub

    Private Sub MenuItemCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCut.Click
        UploadSelectedLazyNode()
        TreeView.CutNodes(TreeView.SelectedNodes())
        MenuItemPaste.Enabled = True
    End Sub

    Private Sub MenuItemPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemPaste.Click
        UploadSelectedLazyNode()
        TreeView.PasteNodes(TreeView.SelectedNode, False)
        If TreeView.EditOperation = LazyTree.EditOperations.Cut Then
            MenuItemPaste.Enabled = False
        End If
    End Sub

    Private Sub MenuItemRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRemove.Click
        UploadSelectedLazyNode()
        If TreeView.SelectedNodes.Count > 0 Then
            TreeView.RemoveNodes(TreeView.SelectedNodes.Clone)
        End If

    End Sub

    'Private Sub MenuItemUserManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemUserManagement.Click
    '    UploadSelectedLazyNode()
    '    OpenUsersManager()
    'End Sub

    Private Sub MenuItemFondsManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFondsManager.Click
        UploadSelectedLazyNode()
        OpenFondsManager()
    End Sub

    Private Sub MenuItemNewFonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemNewFonds.Click
        UploadSelectedLazyNode()

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


                TreeView.RootLazyNode = Node
                TreeView.RootLazyNode.SortBy = GetSelectedSortStyle()
                Log.Append(myProcessInfoName, LogActions.OpenFonds, String.Format(LogMessage("Log.OpenFonds"), Node.UnitId & ":" & Node.UnitTitle))
                EnableMenus(True)
                TreeView.SelectedNode = TreeView.RootTreeNode
                TreeView_AfterSelect(Me, Nothing)


            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)

            End Try
        End If
    End Sub

    Private Sub MenuItemExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemExit.Click
        UploadSelectedLazyNode()
        Close()
    End Sub

    Private Sub MenuItemControlAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemControlAccess.Click
        UploadSelectedLazyNode()
        OpenControlAccess()
    End Sub

    Private Sub MenuItemSortByUnitDateInitial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSortByUnitDateInitial.Click
        UploadSelectedLazyNode()
        MenuItemSortByUnitID.Checked = False
        MenuItemSortByUnitDateInitial.Checked = True
        MenuItemSortByOtherLevel.Checked = False
        MenuItemSortByProcessInfoDate.Checked = False
        MenuItemSortByUnitTitle.Checked = False

        If Not TreeView.RootLazyNode Is Nothing Then
            TreeView.RootLazyNode.SortBy = LazyNode.SortingStyles.ByUnitDateInitial
            TreeView.CollapseAll()
        End If
    End Sub

    Private Sub MenuItemSortByUnitID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSortByUnitID.Click
        UploadSelectedLazyNode()
        MenuItemSortByUnitID.Checked = True
        MenuItemSortByUnitDateInitial.Checked = False
        MenuItemSortByOtherLevel.Checked = False
        MenuItemSortByProcessInfoDate.Checked = False
        MenuItemSortByUnitTitle.Checked = False

        If Not TreeView.RootLazyNode Is Nothing Then
            TreeView.RootLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            TreeView.CollapseAll()
        End If
    End Sub


    Private Sub MenuItemSortByUnitTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSortByUnitTitle.Click
        UploadSelectedLazyNode()
        MenuItemSortByUnitID.Checked = False
        MenuItemSortByUnitDateInitial.Checked = False
        MenuItemSortByOtherLevel.Checked = False
        MenuItemSortByProcessInfoDate.Checked = False
        MenuItemSortByUnitTitle.Checked = True


        If Not TreeView.RootLazyNode Is Nothing Then
            TreeView.RootLazyNode.SortBy = LazyNode.SortingStyles.ByUnitTitle
            TreeView.CollapseAll()
        End If

    End Sub

    Private Sub MenuItemSortByOtherLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSortByOtherLevel.Click
        UploadSelectedLazyNode()
        MenuItemSortByUnitID.Checked = False
        MenuItemSortByUnitDateInitial.Checked = False
        MenuItemSortByOtherLevel.Checked = True
        MenuItemSortByProcessInfoDate.Checked = False
        MenuItemSortByUnitTitle.Checked = False

        If Not TreeView.RootLazyNode Is Nothing Then
            TreeView.RootLazyNode.SortBy = LazyNode.SortingStyles.ByOtherLevel
            TreeView.CollapseAll()
        End If
    End Sub

    Private Sub MenuItemSortByProcessInfoDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSortByProcessInfoDate.Click
        UploadSelectedLazyNode()
        MenuItemSortByUnitID.Checked = False
        MenuItemSortByUnitDateInitial.Checked = False
        MenuItemSortByOtherLevel.Checked = False
        MenuItemSortByProcessInfoDate.Checked = True
        MenuItemSortByUnitTitle.Checked = False

        If Not TreeView.RootLazyNode Is Nothing Then
            TreeView.RootLazyNode.SortBy = LazyNode.SortingStyles.ByProcessInfoDate
            TreeView.CollapseAll()
        End If
    End Sub



    Private Sub MenuItemNodeCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UploadSelectedLazyNode()
        If Not TreeView.RootLazyNode Is Nothing Then
            Dim NodeCounter As New NodeCounter(TreeView.RootLazyNode)
            NodeCounter.CountNodes()
        End If
    End Sub

    Private Sub MenuItemMostFrequentFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMostFrequentFields.Click
        UploadSelectedLazyNode()
        MenuItemMostFrequentFields.Checked = True
        MenuItemAllFields.Checked = False
        MenuItemMandatoryFields.Checked = False

        Me.FieldPresentationMode = ViewMode.Frequent
        TreeView_AfterSelect(Nothing, Nothing)
    End Sub

    Private Sub MenuItemAllFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAllFields.Click
        UploadSelectedLazyNode()
        MenuItemMostFrequentFields.Checked = False
        MenuItemAllFields.Checked = True
        MenuItemMandatoryFields.Checked = False
        Me.FieldPresentationMode = ViewMode.All
        TreeView_AfterSelect(Nothing, Nothing)
    End Sub

    Private Sub MenuItemMandatoryFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMandatoryFields.Click
        UploadSelectedLazyNode()
        MenuItemMostFrequentFields.Checked = False
        MenuItemAllFields.Checked = False
        MenuItemMandatoryFields.Checked = True
        Me.FieldPresentationMode = ViewMode.Mandatory
        TreeView_AfterSelect(Nothing, Nothing)
    End Sub

    Private Sub MenuItemAutoCoding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAutoCoding.Click
        UploadSelectedLazyNode()
        If TreeView.SelectedNodes.Count > 0 Then
            Dim TreeNode As TreeNode
            For Each TreeNode In TreeView.SelectedNodes
                If LazyTree.GetLazyNode(TreeNode).OtherLevelIndex < EADDefinitions.GetOtherLevelIndex(OTHERLEVEL_SERIES) Then
                    MsgBox(InfoMessage("AutoCoding.WrongLevelType"), MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next


            Dim frmAutoCondingStartNumber As AutoCodingStartNumberForm = New AutoCodingStartNumberForm
            If frmAutoCondingStartNumber.ShowDialog = DialogResult.OK Then
                AutoCoding(frmAutoCondingStartNumber.Value, TreeView.SelectedNodes)
            End If
        End If
    End Sub

    Private Sub MenuItemNormaliseCoding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemNormaliseCoding.Click
        UploadSelectedLazyNode()

        If TreeView.SelectedNodes.Count > 0 Then
            For Each TreeNode As TreeNode In TreeView.SelectedNodes
                If LazyTree.GetLazyNode(TreeNode).OtherLevelIndex < EADDefinitions.GetOtherLevelIndex(OTHERLEVEL_SERIES) Then
                    MsgBox(InfoMessage("NormaliseCoding.WrongLevelType"), MsgBoxStyle.Information)
                    Exit Sub
                End If
            Next
        Else
            Exit Sub
        End If

        If MsgBox(InfoMessage("NormaliseCoding.Confirm"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

        NormaliseCoding(TreeView.SelectedNodes)
    End Sub



    Private Sub MenuItemValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemValidate.Click
        If TreeView.SelectedNode Is Nothing Then Exit Sub

        UploadSelectedLazyNode()

        Dim result As MsgBoxResult
        If Not TreeView.RootLazyNode Is TreeView.SelectedLazyNode Then
            result = MsgBox(InfoMessage("Validation.StartFromRoot"), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2)
        Else
            result = MsgBoxResult.Yes
        End If

        If result = MsgBoxResult.Cancel Then
            Exit Sub
        ElseIf result = MsgBoxResult.No Then
            Dim Validator As New Validator(TreeView.SelectedLazyNode, TreeView)
            Me.Enabled = False
            Validator.Validate(True)
            Me.Enabled = True
        Else
            Dim Validator As New Validator(TreeView.RootLazyNode, TreeView)
            Me.Enabled = False
            Validator.Validate(True)
            Me.Enabled = True
        End If

    End Sub

    Private Sub MenuItemInfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemInference.Click
        If MsgBox(InfoMessage("Inference.MakeSure"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1) = MsgBoxResult.No Then Exit Sub
        UploadSelectedLazyNode()
        Dim Validator As New Validator(TreeView.RootLazyNode, TreeView)
        Me.Enabled = False
        Dim isValid As Boolean = Validator.InferenceValidation(False)
        Me.Enabled = True

        If Not isValid Then
            Exit Sub
        End If

        Dim Inference As New Inference(TreeView.RootLazyNode)
        Me.Enabled = False
        Inference.Infer()
        Me.Enabled = True
        TreeView.CollapseAll()
        TreeView.SelectedNode = TreeView.RootTreeNode
        TreeView_AfterSelect(sender, Nothing)
    End Sub

    Private Sub MenuItemExpandAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemExpandAll.Click
        UploadSelectedLazyNode()
        TreeView.ExpandAll()
    End Sub

    Private Sub MenuItemCollapseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCollapseAll.Click
        UploadSelectedLazyNode()
        TreeView.CollapseAll()
    End Sub

    Private Sub MenuItemBranchNodeCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UploadSelectedLazyNode()
        If Not TreeView.SelectedLazyNode Is Nothing Then
            Dim NodeCounter As New NodeCounter(TreeView.SelectedLazyNode)
            NodeCounter.CountNodes()
        Else
            MsgBox(InfoMessage("BranchNodeCount.ElementNotSelected"), MsgBoxStyle.Information Or MsgBoxStyle.OKOnly)
        End If

    End Sub

    Private Sub MenuItemMakeValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMakeValid.Click
        If TreeView.SelectedLazyNode Is Nothing Then Exit Sub
        UploadSelectedLazyNode()
        TreeView.MakeValid(Me, Nothing)
        EnableDisableMenuItems()
    End Sub

    Private Sub MenuItemMakeInvalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMakeInvalid.Click
        If TreeView.SelectedLazyNode Is Nothing Then Exit Sub
        UploadSelectedLazyNode()
        TreeView.MakeInvalid(Me, Nothing)
        EnableDisableMenuItems()
    End Sub

    Private Sub MenuItemMakeVisible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMakeVisible.Click
        If TreeView.SelectedLazyNode Is Nothing Then Exit Sub
        TreeView.MakeVisible(Me, Nothing)
        EnableDisableMenuItems()
    End Sub

    Private Sub MenuItemMakeInvisible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMakeInvisible.Click
        If TreeView.SelectedLazyNode Is Nothing Then Exit Sub
        UploadSelectedLazyNode()
        TreeView.MakeInvisible(Me, Nothing)
        EnableDisableMenuItems()
    End Sub

    Private Sub MenuItemAuthority_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAuthority.Click
        UploadSelectedLazyNode()
        OpenAuthority()
    End Sub

    Private Sub MenuItemClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemClearLog.Click
        Dim aMonth As New TimeSpan(31, 0, 0, 0)
        Dim DeleteUntil As Date = Date.Now.Subtract(aMonth)
        If MsgBox(String.Format(InfoMessage("Log.ClearLog"), DateToStr(DeleteUntil)), MsgBoxStyle.Critical Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Log.Clear(DateToStr(DeleteUntil))
        End If
    End Sub

    Private Sub MenuItemNodeCounterPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemNodeCounterPro.Click
        UploadSelectedLazyNode()

        Dim Result As DialogResult
        If Not TreeView.RootLazyNode Is TreeView.SelectedLazyNode Then
            Result = MsgBox(InfoMessage("CountNodes.StartFromRoot"), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2)
        Else
            Result = MsgBoxResult.Yes
        End If

        Dim StartNode As LazyNode = Nothing

        If Result = MsgBoxResult.Cancel Then
            Exit Sub
        ElseIf Result = DialogResult.Yes Then
            StartNode = TreeView.RootLazyNode
        Else
            StartNode = TreeView.SelectedLazyNode
        End If


        If Not StartNode Is Nothing Then
            Dim startTime As Date = Date.Now

            Dim iterator As New Iterator(StartNode)
            Dim Res As Hashtable = iterator.Start(iterator.Action.CountNodesByOtherLevel)
            Dim msg As String = ""
            Dim total As Integer = 0
            ' added by lmferros
            Dim keys() As String = {"F", "SF", "SC", "SSC", "SSSC", "SR", "SSR", "UI", "DC", "D"}
            For i As Integer = 0 To keys.Length - 1
                If Res.ContainsKey(keys(i)) Then
                    msg &= VisualFieldLabel(keys(i)) & ": " & Res(keys(i)) & Chr(13)
                    total += Res(keys(i))
                End If
            Next
            'For Each key As String In Res.Keys
            '    msg &= VisualFieldLabel(key) & ": " & Res(key) & Chr(13)
            '    total += Res(key)
            'Next
            Dim finishTime As Date = Date.Now
            Dim timeSpan As TimeSpan = finishTime.Subtract(startTime)
            Dim timeStr As String = timeSpan.Minutes.ToString.PadLeft(2, "0") & "m" & timeSpan.Seconds.ToString.PadLeft(2, "0") & "s"
            msg &= Chr(13) & "Total: " & total & " [" & timeStr & "]"
            MsgBox(msg)

        End If

    End Sub

    Private Sub MenuItemReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemReplace.Click
        UploadSelectedLazyNode()
        If TreeView.RootLazyNode Is Nothing Then Exit Sub

        Dim StartNode As LazyNode
        If TreeView.RootLazyNode Is TreeView.SelectedLazyNode Then
            StartNode = TreeView.RootLazyNode
        Else
            Dim Result As DialogResult = MsgBox(InfoMessage("SearchReplace.StartFromRootNode"), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2)
            If Result = MsgBoxResult.Yes Then
                StartNode = TreeView.RootLazyNode
            ElseIf Result = DialogResult.No Then
                StartNode = TreeView.SelectedLazyNode
            Else
                Exit Sub
            End If
        End If

        Dim frmReplace As New SearchReplaceForm(StartNode, TreeView)
        frmReplace.TopMost = True
        frmReplace.Show()
        TreeView.CollapseAll()
        TreeView.SelectedNode = TreeView.RootTreeNode
    End Sub




    Private Sub MenuItemFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFind.Click
        UploadSelectedLazyNode()
        If TreeView.RootLazyNode Is Nothing Then Exit Sub

        Dim StartNode As LazyNode
        If TreeView.RootLazyNode Is TreeView.SelectedLazyNode Then
            StartNode = TreeView.RootLazyNode
        Else
            Dim Result As DialogResult = MsgBox(InfoMessage("SearchReplace.StartFromRootNode"), MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2)
            If Result = MsgBoxResult.Yes Then
                StartNode = TreeView.RootLazyNode
            ElseIf Result = DialogResult.No Then
                StartNode = TreeView.SelectedLazyNode
            Else
                Exit Sub
            End If
        End If

        Dim frmSearch As New SearchReplaceForm(StartNode, TreeView, False)
        frmSearch.TopMost = True
        frmSearch.Show()
    End Sub

    Private Sub MenuItemAskBeforeSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAskBeforeSave.Click
        MenuItemAskBeforeSave.Checked = Not MenuItemAskBeforeSave.Checked
    End Sub


    Private Sub MenuItemWebSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemWebSearch.Click
        OpenInternetExplorer(Constant("AdvancedWebSearchURL"))

    End Sub

    Private Sub MenuItemLogViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemLogViewer.Click
        OpenInternetExplorer(Constant("LogViewerURL"))
    End Sub

    Private Sub MenuItemGlobalStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemGlobalStats.Click
        OpenInternetExplorer(Constant("GlobalStatsURL"))

    End Sub

    Private Sub MenuItemMonthlyStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemMonthlyStats.Click
        OpenInternetExplorer(Constant("MonthlyStatsURL"))
    End Sub

#End Region


#Region "Reports"
    Private Sub MenuItemInventoryReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemInventoryReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As InventoryDataSet = ReportDataSetBuilder.GenerateInventoryReportData(SelectedLazyNodes)

        Dim Report As New InventoryReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemIUInventoryReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemIUInventoryReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As CatalogDataSet = ReportDataSetBuilder.GenerateIUInventoryReportData(SelectedLazyNodes)

        Dim Report As New IUInventoryReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemCatalogReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCatalogReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As CatalogDataSet = ReportDataSetBuilder.GenerateCatalogReportData(SelectedLazyNodes)

        Dim Report As New CatalogReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemIUListReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemIUListReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateInstalationUnitsListData(SelectedLazyNodes)

        Dim Report As New IUListReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemSeriesListReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemSeriesListReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateSeriesListData(SelectedLazyNodes)

        Dim Report As New SeriesListReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemClassificationPlanReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemClassificationPlanReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As InventoryDataSet = ReportDataSetBuilder.GenerateClassificationPlanData(SelectedLazyNodes)

        Dim Report As New ClassificationPlanReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemControlAccessReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemControlAccessReport.Click
        Cursor.Current = Cursors.WaitCursor
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As ControlAccessDataSet = ReportDataSetBuilder.GenerateControlAccessData(SelectedLazyNodes)

        Dim Report As New ControlAccessReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor.Current = Cursors.Default
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemAllControlAccessReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAllControlAccessReport.Click
        Cursor.Current = Cursors.WaitCursor
        Dim ReportDataSet As ControlAccessDataSet = ReportDataSetBuilder.GenerateAllControlAccessData()

        Dim Report As New AllControlAccessReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor.Current = Cursors.Default
        frmReportPreview.Show()
    End Sub


    Private Sub MenuItemFondsGuide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFondsGuide.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As FondsGuideDataSet = ReportDataSetBuilder.GenerateFondsGuideReportData(SelectedLazyNodes)

        Dim Report As New FondsGuideReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()

    End Sub


    Private Sub MenuItemInstalationUnitsBySeriesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemInstalationUnitsBySeriesReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateInstalationUnitsBySeriesListData(SelectedLazyNodes)

        Dim Report As New IUBySeriesReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        frmReportPreview.Show()
    End Sub


    Private Sub MenuItemAuthorsListReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAuthorsListReport.Click
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)
        Cursor = Cursors.WaitCursor
        Dim ReportDataSet As ListDataSet = ReportDataSetBuilder.GenerateAuthorsListData(SelectedLazyNodes)

        Dim Report As New AuthorsListReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor = Cursors.Default
        frmReportPreview.Show()
    End Sub

    Private Sub MenuItemPhyslocReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemPhyslocReport.Click
        Cursor.Current = Cursors.WaitCursor
        Dim SelectedLazyNodes As New LazyNodeCollection
        SelectedLazyNodes.Add(TreeView.RootLazyNode)

        Dim ReportDataSet As PhysLocDataSet = ReportDataSetBuilder.GeneratePhysLocData(SelectedLazyNodes)

        Dim Report As New PhysLocReport
        Report.SetDataSource(ReportDataSet)
        Dim frmReportPreview As New ReportPreviewForm(Report)
        Cursor.Current = Cursors.Default
        frmReportPreview.Show()

    End Sub



#End Region


#Region "Import / Export"

    Private Sub MenuItemImportEAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemImportEAD.Click
        If TreeView.RootLazyNode Is Nothing Then Exit Sub

        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Multiselect = False
        'OpenFileDialog.InitialDirectory() = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        OpenFileDialog.Filter = "Ficheiros EAD (*.ead)|*.ead"
        OpenFileDialog.Title = InfoMessage("OpenFileDialog.Title.ExternalEAD")


        Try
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Dim Filename As String = OpenFileDialog.FileName
                Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
                Dim SourceFonds As LazyNode = New EADLazyNode(Filename)
                Dim DestinationFonds As LazyNode = TreeView.RootLazyNode
                Dim Importer As New Importer(DestinationFonds, SourceFonds)
                Importer.Import()
                TreeView.CollapseAll()
                TreeView.RefreshRootNode()
                Cursor.Current = Cursors.Default
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



    Private Sub MenuItemImportTabSeparatedText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemImportTabSeparatedText.Click
        If TreeView.RootLazyNode Is Nothing Then Exit Sub

        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.Multiselect = False
        'OpenFileDialog.InitialDirectory() = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        OpenFileDialog.Filter = "Texto (separado p/ tabulações) (*.txt)|*.txt"
        OpenFileDialog.Title = InfoMessage("OpenFileDialog.Title.TabSeparatedFile")


        Try
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Dim Filename As String = OpenFileDialog.FileName
                Dim DestinationFonds As LazyNode = TreeView.RootLazyNode
                Dim Importer As New Importer(DestinationFonds, Filename, myProcessInfoName)
                Importer.Import()
                TreeView.CollapseAll()
                TreeView.RefreshRootNode()
                Cursor.Current = Cursors.Default
                If Importer.ErrorCount > 0 Then
                    MsgBox(String.Format(InfoMessage("Import.TabSeparatedFile.ErrorsOccoured"), Importer.ErrorCount, Path.GetFileName(Filename)))
                Else
                    MsgBox(InfoMessage("Import.TabSeparatedFile.Success"))
                End If
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



    Private Sub MenuItemImportFonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemImportFonds.Click
        Cursor.Current = Cursors.WaitCursor
        If TreeView.RootLazyNode Is Nothing Then Exit Sub
        Dim frmFondsManager As New FondsManagerForm("admin", True, myProgramState)
        Dim SourceFonds As LazyNode
        Dim DestinationFonds As LazyNode = TreeView.RootLazyNode

        If frmFondsManager.ShowDialog() <> DialogResult.OK Then Exit Sub
        SourceFonds = frmFondsManager.SelectedFonds()
        Dim Importer As New Importer(DestinationFonds, SourceFonds)
        Importer.Import()
        TreeView.CollapseAll()
        TreeView.RefreshRootNode()
        Cursor.Current = Cursors.Default
    End Sub




    Private Sub MenuItemExportEAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemExportEAD.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "Ficheiros EAD (*.ead)|*.ead"
        SaveFileDialog.Title = InfoMessage("SaveFileDialog.Title.EAD")


        Try
            SaveFileDialog.FileName = TreeView.RootLazyNode.UnitId.Replace("/", "-")
            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim Filename As String = SaveFileDialog.FileName
                Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
                Dim ID As Integer = TreeView.RootLazyNode.ID
                Dim Exporter As New Exporter(SQLServerSettings.Item("ServerAddress"), _
                                             SQLServerSettings.Item("Database"), _
                                             SQLServerSettings.Item("Username"), _
                                             SQLServerSettings.Item("Password"), Filename, _
                                             ID)
                Me.Enabled = False
                Exporter.Export()
            End If
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    Private Sub MenuItemExportCALM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemExportCALM.Click
        Dim SaveFileDialog As New SaveFileDialog
        'OpenFileDialog.Multiselect = True
        'OpenFileDialog.InitialDirectory() = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        SaveFileDialog.Filter = "CALM Natural Format (*.txt)|*.txt"
        SaveFileDialog.Title = InfoMessage("Exportar CALM...")


        Try
            SaveFileDialog.FileName = TreeView.RootLazyNode.UnitId.Replace("/", "-")
            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim Filename As String = SaveFileDialog.FileName
                Dim EADFilename As String = Path.GetFileNameWithoutExtension(Filename) & ".ead"
                Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
                Dim ID As Integer = TreeView.RootLazyNode.ID
                Dim Exporter As New Exporter(SQLServerSettings.Item("ServerAddress"), _
                                             SQLServerSettings.Item("Database"), _
                                             SQLServerSettings.Item("Username"), _
                                             SQLServerSettings.Item("Password"), EADFilename, _
                                             ID)
                Me.Enabled = False
                Exporter.Export()

                If Not Exporter.OperationCancelled Then
                    Dim xslt As XslTransform = New XslTransform
                    xslt.Load(EAD2CNF_XSLT_FILENAME)

                    Dim resolver As XmlUrlResolver = New XmlUrlResolver
                    resolver.Credentials = System.Net.CredentialCache.DefaultCredentials
                    xslt.Transform(EADFilename, Filename, resolver)
                    xslt = Nothing
                End If

            End If
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            Me.Enabled = True
        End Try

    End Sub


#End Region


#Region "Saving Program State"

    Private Sub SaveProgramState()
        myProgramState.LastLoginUsername = myProcessInfoName
        myProgramState.AskBeforeSave = Me.MenuItemAskBeforeSave.Checked
        If Not TreeView.RootLazyNode Is Nothing Then
            myProgramState.LastOpenedFonds = TreeView.RootLazyNode.ID
            If Not TreeView.SelectedLazyNode Is Nothing Then
                myProgramState.LastUsedNode = TreeView.SelectedLazyNode.ID
            Else
                myProgramState.LastUsedNode = TreeView.RootLazyNode.ID
            End If
        End If
        myProgramState.Save()
    End Sub

#End Region


#Region "Help Menu"

    Private Sub MenuItemManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemManual.Click
        Dim frmManual As New ManualForm
        frmManual.Show()
    End Sub


    Private Sub MenuItemAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAbout.Click
        Dim frmAbout As New AboutForm
        frmAbout.ShowDialog()
    End Sub


#End Region


End Class