
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

Imports System.Management
Imports System.io
Imports System.Xml

Public Class DigitalObjectsForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intProjectID As Integer, ByVal strProjectName As String)
        MyBase.New()
        myProjectName = strProjectName
        myProjectID = intProjectID

        InitializeComponent()
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
    Friend WithEvents lblNumImg As System.Windows.Forms.Label
    Friend WithEvents tabOD As System.Windows.Forms.TabControl
    Friend WithEvents groupLstProjects As System.Windows.Forms.GroupBox
    Friend WithEvents lblProfile As System.Windows.Forms.Label
    Friend WithEvents lblCompression As System.Windows.Forms.Label
    Friend WithEvents lblBitDepth As System.Windows.Forms.Label
    Friend WithEvents groupEntities As System.Windows.Forms.GroupBox
    Friend WithEvents groupDates As System.Windows.Forms.GroupBox
    Friend WithEvents groupInfoPreservation As System.Windows.Forms.GroupBox
    Friend WithEvents btnEditDO As MGOD.ColorButton
    Friend WithEvents lblProfundidade As System.Windows.Forms.Label
    Friend WithEvents lblTamanho As System.Windows.Forms.Label
    Friend WithEvents lblCores As System.Windows.Forms.Label
    Friend WithEvents lblResolucao As System.Windows.Forms.Label
    Friend WithEvents lblLargura As System.Windows.Forms.Label
    Friend WithEvents lblAltura As System.Windows.Forms.Label
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents lblCompressao As System.Windows.Forms.Label
    Friend WithEvents lblTipoMIME As System.Windows.Forms.Label
    Friend WithEvents groupInfoGeral As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtResponsabilityEntity As MGOD.ColorTextBox
    Friend WithEvents txtCaptureEntityCorporate As MGOD.ColorTextBox
    Friend WithEvents txtTopographicalQuota As MGOD.ColorTextBox
    Friend WithEvents txtArchiveID As MGOD.ColorTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageListTree As System.Windows.Forms.ImageList
    Friend WithEvents lblScanner1 As System.Windows.Forms.Label
    Friend WithEvents lblLampType As System.Windows.Forms.Label
    Friend WithEvents lblLampType1 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteOD As System.Windows.Forms.Button
    Friend WithEvents txtPreservationOriginalInformation As MGOD.ColorTextBox
    Friend WithEvents txtExternalDescriptiveInfo As MGOD.ColorTextBox
    Friend WithEvents txtArchivingProfile As MGOD.ColorTextBox
    Friend WithEvents txtCreationDateTime As MGOD.DateTextBox
    Friend WithEvents txtArchiveDateTime As MGOD.DateTextBox
    Friend WithEvents txtDepositDateTime As MGOD.DateTextBox
    Friend WithEvents btnNewDO As System.Windows.Forms.Button
    Friend WithEvents btnDeleteDO As System.Windows.Forms.Button
    Friend WithEvents tabMetaInfoStruct As System.Windows.Forms.TabPage
    Friend WithEvents tabMetaInfoTec As System.Windows.Forms.TabPage
    Friend WithEvents tabMetaInfoPreserv As System.Windows.Forms.TabPage
    Friend WithEvents grpBxEsrtuturaReformatacao As System.Windows.Forms.GroupBox
    Friend WithEvents lblTransformerObject As System.Windows.Forms.Label
    Friend WithEvents lblInputFormat As System.Windows.Forms.Label
    Friend WithEvents lblRenderEngine As System.Windows.Forms.Label
    Friend WithEvents lblParameters As System.Windows.Forms.Label
    Friend WithEvents lblPlatform As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnChooseReformattingMethod As System.Windows.Forms.Button
    Friend WithEvents btnChooseReformattingNorms As System.Windows.Forms.Button
    Friend WithEvents lbxReformattingNormsChoosen As System.Windows.Forms.ListBox
    Friend WithEvents txtReformattingMethod As MGOD.ColorTextBox
    Friend WithEvents btnSavePreservationInfo As System.Windows.Forms.Button
    Friend WithEvents txtParameters As MGOD.ColorTextBox
    Friend WithEvents txtInputFormat As MGOD.ColorTextBox
    Friend WithEvents txtRenderEngine As MGOD.ColorTextBox
    Friend WithEvents txtPlatform As MGOD.ColorTextBox
    Friend WithEvents txtTransformer As MGOD.ColorTextBox
    Friend WithEvents btnHistorical As System.Windows.Forms.Button
    Friend WithEvents lblTM4 As System.Windows.Forms.Label
    Friend WithEvents lblTM1 As System.Windows.Forms.Label
    Friend WithEvents lblTM2 As System.Windows.Forms.Label
    Friend WithEvents lblTM3 As System.Windows.Forms.Label
    Friend WithEvents lblTM14 As System.Windows.Forms.Label
    Friend WithEvents lblTM13 As System.Windows.Forms.Label
    Friend WithEvents lblTM15 As System.Windows.Forms.Label
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents lblTM5 As System.Windows.Forms.Label
    Friend WithEvents lblRevisionDateTime As System.Windows.Forms.Label
    Friend WithEvents lblTM10 As System.Windows.Forms.Label
    Friend WithEvents lblTM8 As System.Windows.Forms.Label
    Friend WithEvents lblTM6 As System.Windows.Forms.Label
    Friend WithEvents lblTM7 As System.Windows.Forms.Label
    Friend WithEvents lblTM11 As System.Windows.Forms.Label
    Friend WithEvents lblTM12 As System.Windows.Forms.Label
    Friend WithEvents lblArchiveID As System.Windows.Forms.Label
    Friend WithEvents lblTopographicalQuota As System.Windows.Forms.Label
    Friend WithEvents lblCreationDateTime As System.Windows.Forms.Label
    Friend WithEvents lblDepositDateTime As System.Windows.Forms.Label
    Friend WithEvents lblArchiveDateTime As System.Windows.Forms.Label
    Friend WithEvents lblResponsabilityEntity As System.Windows.Forms.Label
    Friend WithEvents lblPreservationOriginalInformation As System.Windows.Forms.Label
    Friend WithEvents lblExternalDescriptiveInfo As System.Windows.Forms.Label
    Friend WithEvents lblArchivingProfile As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCaptureEntityCorporate As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents miReportMetaOD As System.Windows.Forms.MenuItem
    Friend WithEvents miReportPreservationInfDO As System.Windows.Forms.MenuItem
    Friend WithEvents miReportImagesDO As System.Windows.Forms.MenuItem
    Friend WithEvents miReportDigitalizationProfiles As System.Windows.Forms.MenuItem
    Friend WithEvents miReportRevisionDO As System.Windows.Forms.MenuItem
    Friend WithEvents About As System.Windows.Forms.MenuItem
    Friend WithEvents ckbActive As System.Windows.Forms.CheckBox
    Friend WithEvents lvwDO As System.Windows.Forms.ListView
    Friend WithEvents lblAttention As System.Windows.Forms.Label
    Friend WithEvents btnAssociate As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblProcessingActions As System.Windows.Forms.Label
    Friend WithEvents lblColorManager As System.Windows.Forms.Label
    Friend WithEvents lblProcessingOSVersion As System.Windows.Forms.Label
    Friend WithEvents lblProcessingOSName As System.Windows.Forms.Label
    Friend WithEvents lblProcessingSoftwareName As System.Windows.Forms.Label
    Friend WithEvents lblProcessingSoftwareVersion As System.Windows.Forms.Label
    Friend WithEvents lblExposureTime As System.Windows.Forms.Label
    Friend WithEvents lblFocalLength As System.Windows.Forms.Label
    Friend WithEvents lblFNumber As System.Windows.Forms.Label
    Friend WithEvents btnPOD As System.Windows.Forms.Button
    Friend WithEvents lblTPlatform As System.Windows.Forms.Label
    Friend WithEvents lblMeteringMode As System.Windows.Forms.Label
    Friend WithEvents lblAutoFocus As System.Windows.Forms.Label
    Friend WithEvents lblProcessingDateTime As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents tBxColor As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblMimeType As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tvwDescriptionInfo As System.Windows.Forms.TreeView
    Friend WithEvents ImageListTVDigitarq As System.Windows.Forms.ImageList
    Friend WithEvents lblOriginalName As System.Windows.Forms.Label
    Friend WithEvents txtOriginalName As MGOD.ColorTextBox
    Friend WithEvents fileChooser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnDeleteDerivatives As System.Windows.Forms.Button
    Friend WithEvents cmTree As System.Windows.Forms.ContextMenu
    Friend WithEvents miNew As System.Windows.Forms.MenuItem
    Friend WithEvents miRename As System.Windows.Forms.MenuItem
    Friend WithEvents miDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents miReportReformattingNorms As System.Windows.Forms.MenuItem
    Friend WithEvents miReportReformattingMethods As System.Windows.Forms.MenuItem
    Friend WithEvents miUIDigitalization As System.Windows.Forms.MenuItem
    Friend WithEvents miProjects As System.Windows.Forms.MenuItem
    Friend WithEvents miClose As System.Windows.Forms.MenuItem
    Friend WithEvents miEdit As System.Windows.Forms.MenuItem
    Friend WithEvents miDigitalizationProfiles As System.Windows.Forms.MenuItem
    Friend WithEvents miTechnologicalPlatform As System.Windows.Forms.MenuItem
    Friend WithEvents miLampTypes As System.Windows.Forms.MenuItem
    Friend WithEvents miMeteringModes As System.Windows.Forms.MenuItem
    Friend WithEvents miAutoFocus As System.Windows.Forms.MenuItem
    Friend WithEvents miRevisionInterval As System.Windows.Forms.MenuItem
    Friend WithEvents miReports As System.Windows.Forms.MenuItem
    Friend WithEvents miHelp As System.Windows.Forms.MenuItem
    Friend WithEvents miOpenProjects As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents imglDigitalObjects As System.Windows.Forms.ImageList
    Friend WithEvents miFilesRename As System.Windows.Forms.MenuItem
    Friend WithEvents miPOD As System.Windows.Forms.MenuItem
    Friend WithEvents imgBox As PictureBoxCtrl.PictureBox
    Friend WithEvents treeImg As System.Windows.Forms.TreeView
    Friend WithEvents btnFind As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnAdjust As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnZoomOut As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnZoomInOut As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnZoomIn As mkccontrols.windows.forms.control.mkc_Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DigitalObjectsForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.btnEditDO = New MGOD.ColorButton
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button
        Me.tabOD = New System.Windows.Forms.TabControl
        Me.tabMetaInfoStruct = New System.Windows.Forms.TabPage
        Me.btnAdjust = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnZoomOut = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnZoomInOut = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnZoomIn = New mkccontrols.windows.forms.control.mkc_Button
        Me.imgBox = New PictureBoxCtrl.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblProcessingActions = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblColorManager = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblProcessingOSVersion = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblProcessingOSName = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblProcessingSoftwareName = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblProcessingSoftwareVersion = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblProcessingDateTime = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnPOD = New System.Windows.Forms.Button
        Me.btnAssociate = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblExposureTime = New System.Windows.Forms.Label
        Me.lblMeteringMode = New System.Windows.Forms.Label
        Me.lblAutoFocus = New System.Windows.Forms.Label
        Me.lblFocalLength = New System.Windows.Forms.Label
        Me.lblFNumber = New System.Windows.Forms.Label
        Me.lblLampType1 = New System.Windows.Forms.Label
        Me.lblLampType = New System.Windows.Forms.Label
        Me.lblScanner1 = New System.Windows.Forms.Label
        Me.lblTPlatform = New System.Windows.Forms.Label
        Me.lblProfundidade = New System.Windows.Forms.Label
        Me.lblTamanho = New System.Windows.Forms.Label
        Me.lblCores = New System.Windows.Forms.Label
        Me.lblResolucao = New System.Windows.Forms.Label
        Me.lblLargura = New System.Windows.Forms.Label
        Me.lblAltura = New System.Windows.Forms.Label
        Me.lblPerfil = New System.Windows.Forms.Label
        Me.lblCompressao = New System.Windows.Forms.Label
        Me.lblTipoMIME = New System.Windows.Forms.Label
        Me.lblResolution = New System.Windows.Forms.Label
        Me.tBxColor = New System.Windows.Forms.Label
        Me.lblHeight = New System.Windows.Forms.Label
        Me.lblWidth = New System.Windows.Forms.Label
        Me.lblMimeType = New System.Windows.Forms.Label
        Me.lblBitDepth = New System.Windows.Forms.Label
        Me.lblCompression = New System.Windows.Forms.Label
        Me.lblProfile = New System.Windows.Forms.Label
        Me.lblSize = New System.Windows.Forms.Label
        Me.treeImg = New System.Windows.Forms.TreeView
        Me.cmTree = New System.Windows.Forms.ContextMenu
        Me.miNew = New System.Windows.Forms.MenuItem
        Me.miRename = New System.Windows.Forms.MenuItem
        Me.miDelete = New System.Windows.Forms.MenuItem
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.tabMetaInfoTec = New System.Windows.Forms.TabPage
        Me.btnDeleteDerivatives = New System.Windows.Forms.Button
        Me.groupInfoPreservation = New System.Windows.Forms.GroupBox
        Me.lblArchivingProfile = New System.Windows.Forms.Label
        Me.lblExternalDescriptiveInfo = New System.Windows.Forms.Label
        Me.lblPreservationOriginalInformation = New System.Windows.Forms.Label
        Me.txtArchivingProfile = New MGOD.ColorTextBox
        Me.txtExternalDescriptiveInfo = New MGOD.ColorTextBox
        Me.txtPreservationOriginalInformation = New MGOD.ColorTextBox
        Me.lblTM14 = New System.Windows.Forms.Label
        Me.lblTM13 = New System.Windows.Forms.Label
        Me.lblTM15 = New System.Windows.Forms.Label
        Me.groupInfoGeral = New System.Windows.Forms.GroupBox
        Me.lblOriginalName = New System.Windows.Forms.Label
        Me.txtOriginalName = New MGOD.ColorTextBox
        Me.tvwDescriptionInfo = New System.Windows.Forms.TreeView
        Me.ImageListTVDigitarq = New System.Windows.Forms.ImageList(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblTopographicalQuota = New System.Windows.Forms.Label
        Me.lblArchiveID = New System.Windows.Forms.Label
        Me.ckbActive = New System.Windows.Forms.CheckBox
        Me.lblName = New System.Windows.Forms.Label
        Me.lblIP = New System.Windows.Forms.Label
        Me.lblTM4 = New System.Windows.Forms.Label
        Me.txtTopographicalQuota = New MGOD.ColorTextBox
        Me.lblTM1 = New System.Windows.Forms.Label
        Me.txtArchiveID = New MGOD.ColorTextBox
        Me.lblTM2 = New System.Windows.Forms.Label
        Me.lblTM3 = New System.Windows.Forms.Label
        Me.lblNumImg = New System.Windows.Forms.Label
        Me.lblTM5 = New System.Windows.Forms.Label
        Me.groupDates = New System.Windows.Forms.GroupBox
        Me.lblArchiveDateTime = New System.Windows.Forms.Label
        Me.lblCreationDateTime = New System.Windows.Forms.Label
        Me.txtArchiveDateTime = New MGOD.DateTextBox
        Me.txtCreationDateTime = New MGOD.DateTextBox
        Me.lblRevisionDateTime = New System.Windows.Forms.Label
        Me.lblTM10 = New System.Windows.Forms.Label
        Me.lblTM8 = New System.Windows.Forms.Label
        Me.lblTM6 = New System.Windows.Forms.Label
        Me.lblTM7 = New System.Windows.Forms.Label
        Me.lblDepositDateTime = New System.Windows.Forms.Label
        Me.txtDepositDateTime = New MGOD.DateTextBox
        Me.groupEntities = New System.Windows.Forms.GroupBox
        Me.lblCaptureEntityCorporate = New System.Windows.Forms.Label
        Me.lblResponsabilityEntity = New System.Windows.Forms.Label
        Me.txtResponsabilityEntity = New MGOD.ColorTextBox
        Me.lblTM11 = New System.Windows.Forms.Label
        Me.lblTM12 = New System.Windows.Forms.Label
        Me.txtCaptureEntityCorporate = New MGOD.ColorTextBox
        Me.tabMetaInfoPreserv = New System.Windows.Forms.TabPage
        Me.btnHistorical = New System.Windows.Forms.Button
        Me.btnSavePreservationInfo = New System.Windows.Forms.Button
        Me.grpBxEsrtuturaReformatacao = New System.Windows.Forms.GroupBox
        Me.btnChooseReformattingNorms = New System.Windows.Forms.Button
        Me.btnChooseReformattingMethod = New System.Windows.Forms.Button
        Me.lbxReformattingNormsChoosen = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtReformattingMethod = New MGOD.ColorTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtParameters = New MGOD.ColorTextBox
        Me.txtInputFormat = New MGOD.ColorTextBox
        Me.txtRenderEngine = New MGOD.ColorTextBox
        Me.txtPlatform = New MGOD.ColorTextBox
        Me.txtTransformer = New MGOD.ColorTextBox
        Me.lblTransformerObject = New System.Windows.Forms.Label
        Me.lblInputFormat = New System.Windows.Forms.Label
        Me.lblRenderEngine = New System.Windows.Forms.Label
        Me.lblParameters = New System.Windows.Forms.Label
        Me.lblPlatform = New System.Windows.Forms.Label
        Me.btnDeleteDO = New System.Windows.Forms.Button
        Me.groupLstProjects = New System.Windows.Forms.GroupBox
        Me.btnFind = New mkccontrols.windows.forms.control.mkc_Button
        Me.lblAttention = New System.Windows.Forms.Label
        Me.lvwDO = New System.Windows.Forms.ListView
        Me.imglDigitalObjects = New System.Windows.Forms.ImageList(Me.components)
        Me.btnNewDO = New System.Windows.Forms.Button
        Me.btnDeleteOD = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.miProjects = New System.Windows.Forms.MenuItem
        Me.miOpenProjects = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.miClose = New System.Windows.Forms.MenuItem
        Me.miEdit = New System.Windows.Forms.MenuItem
        Me.miDigitalizationProfiles = New System.Windows.Forms.MenuItem
        Me.miTechnologicalPlatform = New System.Windows.Forms.MenuItem
        Me.miLampTypes = New System.Windows.Forms.MenuItem
        Me.miMeteringModes = New System.Windows.Forms.MenuItem
        Me.miAutoFocus = New System.Windows.Forms.MenuItem
        Me.miRevisionInterval = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.miFilesRename = New System.Windows.Forms.MenuItem
        Me.miPOD = New System.Windows.Forms.MenuItem
        Me.miReports = New System.Windows.Forms.MenuItem
        Me.miReportDigitalizationProfiles = New System.Windows.Forms.MenuItem
        Me.miReportReformattingNorms = New System.Windows.Forms.MenuItem
        Me.miReportReformattingMethods = New System.Windows.Forms.MenuItem
        Me.miReportMetaOD = New System.Windows.Forms.MenuItem
        Me.miReportPreservationInfDO = New System.Windows.Forms.MenuItem
        Me.miReportImagesDO = New System.Windows.Forms.MenuItem
        Me.miReportRevisionDO = New System.Windows.Forms.MenuItem
        Me.miUIDigitalization = New System.Windows.Forms.MenuItem
        Me.miHelp = New System.Windows.Forms.MenuItem
        Me.About = New System.Windows.Forms.MenuItem
        Me.fileChooser = New System.Windows.Forms.FolderBrowserDialog
        Me.tabOD.SuspendLayout()
        Me.tabMetaInfoStruct.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabMetaInfoTec.SuspendLayout()
        Me.groupInfoPreservation.SuspendLayout()
        Me.groupInfoGeral.SuspendLayout()
        Me.groupDates.SuspendLayout()
        Me.groupEntities.SuspendLayout()
        Me.tabMetaInfoPreserv.SuspendLayout()
        Me.grpBxEsrtuturaReformatacao.SuspendLayout()
        Me.groupLstProjects.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEditDO
        '
        Me.btnEditDO.BackColor = System.Drawing.Color.White
        Me.btnEditDO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditDO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditDO.ImageIndex = 3
        Me.btnEditDO.ImageList = Me.imglButtons
        Me.btnEditDO.Location = New System.Drawing.Point(344, 577)
        Me.btnEditDO.Name = "btnEditDO"
        Me.btnEditDO.Size = New System.Drawing.Size(88, 25)
        Me.btnEditDO.TabIndex = 13
        Me.btnEditDO.Text = "Editar"
        Me.btnEditDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
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
        Me.btnCancel.Location = New System.Drawing.Point(439, 577)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 25)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabOD
        '
        Me.tabOD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabOD.Controls.Add(Me.tabMetaInfoStruct)
        Me.tabOD.Controls.Add(Me.tabMetaInfoTec)
        Me.tabOD.Controls.Add(Me.tabMetaInfoPreserv)
        Me.tabOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabOD.Location = New System.Drawing.Point(192, 8)
        Me.tabOD.Name = "tabOD"
        Me.tabOD.SelectedIndex = 0
        Me.tabOD.Size = New System.Drawing.Size(680, 640)
        Me.tabOD.TabIndex = 5
        '
        'tabMetaInfoStruct
        '
        Me.tabMetaInfoStruct.BackColor = System.Drawing.Color.White
        Me.tabMetaInfoStruct.Controls.Add(Me.btnAdjust)
        Me.tabMetaInfoStruct.Controls.Add(Me.btnZoomOut)
        Me.tabMetaInfoStruct.Controls.Add(Me.btnZoomInOut)
        Me.tabMetaInfoStruct.Controls.Add(Me.btnZoomIn)
        Me.tabMetaInfoStruct.Controls.Add(Me.imgBox)
        Me.tabMetaInfoStruct.Controls.Add(Me.GroupBox3)
        Me.tabMetaInfoStruct.Controls.Add(Me.GroupBox1)
        Me.tabMetaInfoStruct.Controls.Add(Me.GroupBox2)
        Me.tabMetaInfoStruct.Controls.Add(Me.treeImg)
        Me.tabMetaInfoStruct.Location = New System.Drawing.Point(4, 22)
        Me.tabMetaInfoStruct.Name = "tabMetaInfoStruct"
        Me.tabMetaInfoStruct.Size = New System.Drawing.Size(672, 614)
        Me.tabMetaInfoStruct.TabIndex = 2
        Me.tabMetaInfoStruct.Text = "Informação estrutural"
        '
        'btnAdjust
        '
        Me.btnAdjust.BorderColor = System.Drawing.Color.White
        Me.btnAdjust.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjust.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdjust.ButtonImage = CType(resources.GetObject("btnAdjust.ButtonImage"), System.Drawing.Image)
        Me.btnAdjust.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdjust.ButtonShowShadow = True
        Me.btnAdjust.ButtonText = ""
        Me.btnAdjust.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdjust.ButtonTransparentColor = System.Drawing.Color.White
        Me.btnAdjust.HighlightBackgroundColor = System.Drawing.Color.FromArgb(CType(252, Byte), CType(252, Byte), CType(252, Byte))
        Me.btnAdjust.Location = New System.Drawing.Point(174, 4)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(25, 25)
        Me.btnAdjust.TabIndex = 109
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomOut.BorderColor = System.Drawing.Color.White
        Me.btnZoomOut.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomOut.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnZoomOut.ButtonImage = CType(resources.GetObject("btnZoomOut.ButtonImage"), System.Drawing.Image)
        Me.btnZoomOut.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomOut.ButtonShowShadow = True
        Me.btnZoomOut.ButtonText = ""
        Me.btnZoomOut.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomOut.ButtonTransparentColor = System.Drawing.Color.White
        Me.btnZoomOut.HighlightBackgroundColor = System.Drawing.Color.FromArgb(CType(252, Byte), CType(252, Byte), CType(252, Byte))
        Me.btnZoomOut.Location = New System.Drawing.Point(384, 4)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(25, 25)
        Me.btnZoomOut.TabIndex = 108
        '
        'btnZoomInOut
        '
        Me.btnZoomInOut.BorderColor = System.Drawing.Color.White
        Me.btnZoomInOut.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomInOut.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnZoomInOut.ButtonImage = CType(resources.GetObject("btnZoomInOut.ButtonImage"), System.Drawing.Image)
        Me.btnZoomInOut.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomInOut.ButtonShowShadow = True
        Me.btnZoomInOut.ButtonText = ""
        Me.btnZoomInOut.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomInOut.ButtonTransparentColor = System.Drawing.Color.White
        Me.btnZoomInOut.HighlightBackgroundColor = System.Drawing.Color.FromArgb(CType(252, Byte), CType(252, Byte), CType(252, Byte))
        Me.btnZoomInOut.Location = New System.Drawing.Point(208, 4)
        Me.btnZoomInOut.Name = "btnZoomInOut"
        Me.btnZoomInOut.Size = New System.Drawing.Size(25, 25)
        Me.btnZoomInOut.TabIndex = 107
        '
        'btnZoomIn
        '
        Me.btnZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomIn.BorderColor = System.Drawing.Color.White
        Me.btnZoomIn.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomIn.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnZoomIn.ButtonImage = CType(resources.GetObject("btnZoomIn.ButtonImage"), System.Drawing.Image)
        Me.btnZoomIn.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomIn.ButtonShowShadow = True
        Me.btnZoomIn.ButtonText = ""
        Me.btnZoomIn.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomIn.ButtonTransparentColor = System.Drawing.Color.White
        Me.btnZoomIn.HighlightBackgroundColor = System.Drawing.Color.FromArgb(CType(252, Byte), CType(252, Byte), CType(252, Byte))
        Me.btnZoomIn.Location = New System.Drawing.Point(420, 4)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(25, 25)
        Me.btnZoomIn.TabIndex = 106
        '
        'imgBox
        '
        Me.imgBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgBox.Border = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgBox.Image = Nothing
        Me.imgBox.Location = New System.Drawing.Point(174, 32)
        Me.imgBox.Name = "imgBox"
        Me.imgBox.Size = New System.Drawing.Size(272, 524)
        Me.imgBox.TabIndex = 103
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.lblProcessingActions)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.lblColorManager)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.lblProcessingOSVersion)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.lblProcessingOSName)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.lblProcessingSoftwareName)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblProcessingSoftwareVersion)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.lblProcessingDateTime)
        Me.GroupBox3.Location = New System.Drawing.Point(452, 426)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(215, 184)
        Me.GroupBox3.TabIndex = 102
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tratamento da imagem"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(9, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 16)
        Me.Label14.TabIndex = 99
        Me.Label14.Text = "Tratamento"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcessingActions
        '
        Me.lblProcessingActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingActions.Location = New System.Drawing.Point(104, 40)
        Me.lblProcessingActions.Name = "lblProcessingActions"
        Me.lblProcessingActions.Size = New System.Drawing.Size(104, 16)
        Me.lblProcessingActions.TabIndex = 100
        Me.lblProcessingActions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(9, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 16)
        Me.Label16.TabIndex = 97
        Me.Label16.Text = "Gestão cor"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColorManager
        '
        Me.lblColorManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColorManager.Location = New System.Drawing.Point(104, 160)
        Me.lblColorManager.Name = "lblColorManager"
        Me.lblColorManager.Size = New System.Drawing.Size(104, 16)
        Me.lblColorManager.TabIndex = 98
        Me.lblColorManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(9, 136)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 16)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "Versão SO"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcessingOSVersion
        '
        Me.lblProcessingOSVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingOSVersion.Location = New System.Drawing.Point(104, 136)
        Me.lblProcessingOSVersion.Name = "lblProcessingOSVersion"
        Me.lblProcessingOSVersion.Size = New System.Drawing.Size(104, 16)
        Me.lblProcessingOSVersion.TabIndex = 94
        Me.lblProcessingOSVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(9, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "Sistema operativo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcessingOSName
        '
        Me.lblProcessingOSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingOSName.Location = New System.Drawing.Point(104, 112)
        Me.lblProcessingOSName.Name = "lblProcessingOSName"
        Me.lblProcessingOSName.Size = New System.Drawing.Size(104, 16)
        Me.lblProcessingOSName.TabIndex = 92
        Me.lblProcessingOSName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(9, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Software"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcessingSoftwareName
        '
        Me.lblProcessingSoftwareName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingSoftwareName.Location = New System.Drawing.Point(104, 64)
        Me.lblProcessingSoftwareName.Name = "lblProcessingSoftwareName"
        Me.lblProcessingSoftwareName.Size = New System.Drawing.Size(104, 16)
        Me.lblProcessingSoftwareName.TabIndex = 90
        Me.lblProcessingSoftwareName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(9, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Versão software"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcessingSoftwareVersion
        '
        Me.lblProcessingSoftwareVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingSoftwareVersion.Location = New System.Drawing.Point(104, 88)
        Me.lblProcessingSoftwareVersion.Name = "lblProcessingSoftwareVersion"
        Me.lblProcessingSoftwareVersion.Size = New System.Drawing.Size(104, 16)
        Me.lblProcessingSoftwareVersion.TabIndex = 88
        Me.lblProcessingSoftwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Data tratamento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcessingDateTime
        '
        Me.lblProcessingDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingDateTime.Location = New System.Drawing.Point(104, 16)
        Me.lblProcessingDateTime.Name = "lblProcessingDateTime"
        Me.lblProcessingDateTime.Size = New System.Drawing.Size(104, 16)
        Me.lblProcessingDateTime.TabIndex = 86
        Me.lblProcessingDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnPOD)
        Me.GroupBox1.Controls.Add(Me.btnAssociate)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 559)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 50)
        Me.GroupBox1.TabIndex = 101
        Me.GroupBox1.TabStop = False
        '
        'btnPOD
        '
        Me.btnPOD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOD.BackColor = System.Drawing.Color.White
        Me.btnPOD.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnPOD.Enabled = False
        Me.btnPOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOD.Image = CType(resources.GetObject("btnPOD.Image"), System.Drawing.Image)
        Me.btnPOD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPOD.Location = New System.Drawing.Point(296, 15)
        Me.btnPOD.Name = "btnPOD"
        Me.btnPOD.Size = New System.Drawing.Size(136, 25)
        Me.btnPOD.TabIndex = 105
        Me.btnPOD.Text = "Associar descrições..."
        Me.btnPOD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAssociate
        '
        Me.btnAssociate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAssociate.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(255, Byte), CType(230, Byte))
        Me.btnAssociate.Enabled = False
        Me.btnAssociate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssociate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssociate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAssociate.ImageIndex = 6
        Me.btnAssociate.ImageList = Me.imglButtons
        Me.btnAssociate.Location = New System.Drawing.Point(8, 15)
        Me.btnAssociate.Name = "btnAssociate"
        Me.btnAssociate.Size = New System.Drawing.Size(128, 25)
        Me.btnAssociate.TabIndex = 13
        Me.btnAssociate.Text = "Adicionar ficheiros..."
        Me.btnAssociate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.lblExposureTime)
        Me.GroupBox2.Controls.Add(Me.lblMeteringMode)
        Me.GroupBox2.Controls.Add(Me.lblAutoFocus)
        Me.GroupBox2.Controls.Add(Me.lblFocalLength)
        Me.GroupBox2.Controls.Add(Me.lblFNumber)
        Me.GroupBox2.Controls.Add(Me.lblLampType1)
        Me.GroupBox2.Controls.Add(Me.lblLampType)
        Me.GroupBox2.Controls.Add(Me.lblScanner1)
        Me.GroupBox2.Controls.Add(Me.lblTPlatform)
        Me.GroupBox2.Controls.Add(Me.lblProfundidade)
        Me.GroupBox2.Controls.Add(Me.lblTamanho)
        Me.GroupBox2.Controls.Add(Me.lblCores)
        Me.GroupBox2.Controls.Add(Me.lblResolucao)
        Me.GroupBox2.Controls.Add(Me.lblLargura)
        Me.GroupBox2.Controls.Add(Me.lblAltura)
        Me.GroupBox2.Controls.Add(Me.lblPerfil)
        Me.GroupBox2.Controls.Add(Me.lblCompressao)
        Me.GroupBox2.Controls.Add(Me.lblTipoMIME)
        Me.GroupBox2.Controls.Add(Me.lblResolution)
        Me.GroupBox2.Controls.Add(Me.tBxColor)
        Me.GroupBox2.Controls.Add(Me.lblHeight)
        Me.GroupBox2.Controls.Add(Me.lblWidth)
        Me.GroupBox2.Controls.Add(Me.lblMimeType)
        Me.GroupBox2.Controls.Add(Me.lblBitDepth)
        Me.GroupBox2.Controls.Add(Me.lblCompression)
        Me.GroupBox2.Controls.Add(Me.lblProfile)
        Me.GroupBox2.Controls.Add(Me.lblSize)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(452, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(215, 400)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informação Ficheiro"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Navy
        Me.Label18.Location = New System.Drawing.Point(7, 353)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 16)
        Me.Label18.TabIndex = 103
        Me.Label18.Text = "Distância focal lente"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Navy
        Me.Label19.Location = New System.Drawing.Point(7, 281)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 16)
        Me.Label19.TabIndex = 99
        Me.Label19.Text = "Abertura objectiva"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Navy
        Me.Label20.Location = New System.Drawing.Point(7, 329)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 16)
        Me.Label20.TabIndex = 101
        Me.Label20.Text = "Forma medição"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.Location = New System.Drawing.Point(7, 305)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 16)
        Me.Label21.TabIndex = 100
        Me.Label21.Text = "Tempo exposição"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Navy
        Me.Label22.Location = New System.Drawing.Point(7, 377)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 16)
        Me.Label22.TabIndex = 102
        Me.Label22.Text = "Tipo focagem"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExposureTime
        '
        Me.lblExposureTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExposureTime.Location = New System.Drawing.Point(103, 305)
        Me.lblExposureTime.Name = "lblExposureTime"
        Me.lblExposureTime.Size = New System.Drawing.Size(104, 16)
        Me.lblExposureTime.TabIndex = 105
        Me.lblExposureTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMeteringMode
        '
        Me.lblMeteringMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeteringMode.Location = New System.Drawing.Point(103, 329)
        Me.lblMeteringMode.Name = "lblMeteringMode"
        Me.lblMeteringMode.Size = New System.Drawing.Size(104, 16)
        Me.lblMeteringMode.TabIndex = 106
        Me.lblMeteringMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAutoFocus
        '
        Me.lblAutoFocus.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoFocus.Location = New System.Drawing.Point(103, 377)
        Me.lblAutoFocus.Name = "lblAutoFocus"
        Me.lblAutoFocus.Size = New System.Drawing.Size(104, 16)
        Me.lblAutoFocus.TabIndex = 107
        Me.lblAutoFocus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFocalLength
        '
        Me.lblFocalLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFocalLength.Location = New System.Drawing.Point(103, 353)
        Me.lblFocalLength.Name = "lblFocalLength"
        Me.lblFocalLength.Size = New System.Drawing.Size(104, 16)
        Me.lblFocalLength.TabIndex = 108
        Me.lblFocalLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFNumber
        '
        Me.lblFNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFNumber.Location = New System.Drawing.Point(103, 281)
        Me.lblFNumber.Name = "lblFNumber"
        Me.lblFNumber.Size = New System.Drawing.Size(104, 16)
        Me.lblFNumber.TabIndex = 104
        Me.lblFNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLampType1
        '
        Me.lblLampType1.BackColor = System.Drawing.Color.Transparent
        Me.lblLampType1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLampType1.ForeColor = System.Drawing.Color.Navy
        Me.lblLampType1.Location = New System.Drawing.Point(8, 209)
        Me.lblLampType1.Name = "lblLampType1"
        Me.lblLampType1.Size = New System.Drawing.Size(96, 16)
        Me.lblLampType1.TabIndex = 95
        Me.lblLampType1.Text = "Iluminância"
        Me.lblLampType1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLampType
        '
        Me.lblLampType.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLampType.Location = New System.Drawing.Point(104, 209)
        Me.lblLampType.Name = "lblLampType"
        Me.lblLampType.Size = New System.Drawing.Size(104, 16)
        Me.lblLampType.TabIndex = 96
        '
        'lblScanner1
        '
        Me.lblScanner1.BackColor = System.Drawing.Color.Transparent
        Me.lblScanner1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanner1.ForeColor = System.Drawing.Color.Navy
        Me.lblScanner1.Location = New System.Drawing.Point(8, 257)
        Me.lblScanner1.Name = "lblScanner1"
        Me.lblScanner1.Size = New System.Drawing.Size(96, 16)
        Me.lblScanner1.TabIndex = 93
        Me.lblScanner1.Text = "Plataforma"
        Me.lblScanner1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTPlatform
        '
        Me.lblTPlatform.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTPlatform.Location = New System.Drawing.Point(104, 257)
        Me.lblTPlatform.Name = "lblTPlatform"
        Me.lblTPlatform.Size = New System.Drawing.Size(104, 16)
        Me.lblTPlatform.TabIndex = 94
        '
        'lblProfundidade
        '
        Me.lblProfundidade.BackColor = System.Drawing.Color.Transparent
        Me.lblProfundidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfundidade.ForeColor = System.Drawing.Color.Navy
        Me.lblProfundidade.Location = New System.Drawing.Point(8, 89)
        Me.lblProfundidade.Name = "lblProfundidade"
        Me.lblProfundidade.Size = New System.Drawing.Size(96, 16)
        Me.lblProfundidade.TabIndex = 80
        Me.lblProfundidade.Text = "Profundidade Bits"
        Me.lblProfundidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTamanho
        '
        Me.lblTamanho.BackColor = System.Drawing.Color.Transparent
        Me.lblTamanho.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTamanho.ForeColor = System.Drawing.Color.Navy
        Me.lblTamanho.Location = New System.Drawing.Point(8, 17)
        Me.lblTamanho.Name = "lblTamanho"
        Me.lblTamanho.Size = New System.Drawing.Size(96, 16)
        Me.lblTamanho.TabIndex = 75
        Me.lblTamanho.Text = "Tamanho"
        Me.lblTamanho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCores
        '
        Me.lblCores.BackColor = System.Drawing.Color.Transparent
        Me.lblCores.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCores.ForeColor = System.Drawing.Color.Navy
        Me.lblCores.Location = New System.Drawing.Point(8, 65)
        Me.lblCores.Name = "lblCores"
        Me.lblCores.Size = New System.Drawing.Size(96, 16)
        Me.lblCores.TabIndex = 77
        Me.lblCores.Text = "Cores"
        Me.lblCores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResolucao
        '
        Me.lblResolucao.BackColor = System.Drawing.Color.Transparent
        Me.lblResolucao.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolucao.ForeColor = System.Drawing.Color.Navy
        Me.lblResolucao.Location = New System.Drawing.Point(8, 41)
        Me.lblResolucao.Name = "lblResolucao"
        Me.lblResolucao.Size = New System.Drawing.Size(96, 16)
        Me.lblResolucao.TabIndex = 76
        Me.lblResolucao.Text = "Resolução"
        Me.lblResolucao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLargura
        '
        Me.lblLargura.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLargura.ForeColor = System.Drawing.Color.Navy
        Me.lblLargura.Location = New System.Drawing.Point(8, 137)
        Me.lblLargura.Name = "lblLargura"
        Me.lblLargura.Size = New System.Drawing.Size(96, 16)
        Me.lblLargura.TabIndex = 79
        Me.lblLargura.Text = "Largura"
        Me.lblLargura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAltura
        '
        Me.lblAltura.BackColor = System.Drawing.Color.Transparent
        Me.lblAltura.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltura.ForeColor = System.Drawing.Color.Navy
        Me.lblAltura.Location = New System.Drawing.Point(8, 113)
        Me.lblAltura.Name = "lblAltura"
        Me.lblAltura.Size = New System.Drawing.Size(96, 16)
        Me.lblAltura.TabIndex = 78
        Me.lblAltura.Text = "Altura"
        Me.lblAltura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPerfil
        '
        Me.lblPerfil.BackColor = System.Drawing.Color.Transparent
        Me.lblPerfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPerfil.ForeColor = System.Drawing.Color.Navy
        Me.lblPerfil.Location = New System.Drawing.Point(8, 233)
        Me.lblPerfil.Name = "lblPerfil"
        Me.lblPerfil.Size = New System.Drawing.Size(96, 16)
        Me.lblPerfil.TabIndex = 83
        Me.lblPerfil.Text = "Perfil"
        Me.lblPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompressao
        '
        Me.lblCompressao.BackColor = System.Drawing.Color.Transparent
        Me.lblCompressao.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompressao.ForeColor = System.Drawing.Color.Navy
        Me.lblCompressao.Location = New System.Drawing.Point(8, 185)
        Me.lblCompressao.Name = "lblCompressao"
        Me.lblCompressao.Size = New System.Drawing.Size(96, 16)
        Me.lblCompressao.TabIndex = 82
        Me.lblCompressao.Text = "Compressão"
        Me.lblCompressao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoMIME
        '
        Me.lblTipoMIME.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoMIME.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMIME.ForeColor = System.Drawing.Color.Navy
        Me.lblTipoMIME.Location = New System.Drawing.Point(8, 161)
        Me.lblTipoMIME.Name = "lblTipoMIME"
        Me.lblTipoMIME.Size = New System.Drawing.Size(96, 16)
        Me.lblTipoMIME.TabIndex = 81
        Me.lblTipoMIME.Text = "Tipo MIME"
        Me.lblTipoMIME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResolution
        '
        Me.lblResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolution.Location = New System.Drawing.Point(104, 41)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(104, 16)
        Me.lblResolution.TabIndex = 85
        Me.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tBxColor
        '
        Me.tBxColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tBxColor.Location = New System.Drawing.Point(104, 65)
        Me.tBxColor.Name = "tBxColor"
        Me.tBxColor.Size = New System.Drawing.Size(104, 16)
        Me.tBxColor.TabIndex = 86
        Me.tBxColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHeight
        '
        Me.lblHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(104, 113)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(104, 16)
        Me.lblHeight.TabIndex = 87
        Me.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWidth
        '
        Me.lblWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(104, 137)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(104, 16)
        Me.lblWidth.TabIndex = 88
        Me.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMimeType
        '
        Me.lblMimeType.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMimeType.Location = New System.Drawing.Point(104, 161)
        Me.lblMimeType.Name = "lblMimeType"
        Me.lblMimeType.Size = New System.Drawing.Size(104, 16)
        Me.lblMimeType.TabIndex = 89
        Me.lblMimeType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBitDepth
        '
        Me.lblBitDepth.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBitDepth.Location = New System.Drawing.Point(104, 89)
        Me.lblBitDepth.Name = "lblBitDepth"
        Me.lblBitDepth.Size = New System.Drawing.Size(104, 16)
        Me.lblBitDepth.TabIndex = 90
        Me.lblBitDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompression
        '
        Me.lblCompression.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompression.Location = New System.Drawing.Point(104, 185)
        Me.lblCompression.Name = "lblCompression"
        Me.lblCompression.Size = New System.Drawing.Size(104, 16)
        Me.lblCompression.TabIndex = 91
        Me.lblCompression.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProfile
        '
        Me.lblProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfile.Location = New System.Drawing.Point(104, 233)
        Me.lblProfile.Name = "lblProfile"
        Me.lblProfile.Size = New System.Drawing.Size(104, 16)
        Me.lblProfile.TabIndex = 92
        '
        'lblSize
        '
        Me.lblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(104, 17)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(104, 16)
        Me.lblSize.TabIndex = 84
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'treeImg
        '
        Me.treeImg.AllowDrop = True
        Me.treeImg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.treeImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.treeImg.ContextMenu = Me.cmTree
        Me.treeImg.ImageList = Me.ImageListTree
        Me.treeImg.Location = New System.Drawing.Point(6, 32)
        Me.treeImg.Name = "treeImg"
        Me.treeImg.Size = New System.Drawing.Size(160, 524)
        Me.treeImg.TabIndex = 105
        '
        'cmTree
        '
        Me.cmTree.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miNew, Me.miRename, Me.miDelete})
        '
        'miNew
        '
        Me.miNew.Index = 0
        Me.miNew.Text = "Novo"
        '
        'miRename
        '
        Me.miRename.Index = 1
        Me.miRename.Text = "Renomear"
        '
        'miDelete
        '
        Me.miDelete.Index = 2
        Me.miDelete.Text = "Eliminar"
        '
        'ImageListTree
        '
        Me.ImageListTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageListTree.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListTree.ImageStream = CType(resources.GetObject("ImageListTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTree.TransparentColor = System.Drawing.Color.Transparent
        '
        'tabMetaInfoTec
        '
        Me.tabMetaInfoTec.BackColor = System.Drawing.Color.White
        Me.tabMetaInfoTec.Controls.Add(Me.btnDeleteDerivatives)
        Me.tabMetaInfoTec.Controls.Add(Me.groupInfoPreservation)
        Me.tabMetaInfoTec.Controls.Add(Me.groupInfoGeral)
        Me.tabMetaInfoTec.Controls.Add(Me.groupDates)
        Me.tabMetaInfoTec.Controls.Add(Me.groupEntities)
        Me.tabMetaInfoTec.Controls.Add(Me.btnEditDO)
        Me.tabMetaInfoTec.Controls.Add(Me.btnCancel)
        Me.tabMetaInfoTec.Location = New System.Drawing.Point(4, 22)
        Me.tabMetaInfoTec.Name = "tabMetaInfoTec"
        Me.tabMetaInfoTec.Size = New System.Drawing.Size(672, 614)
        Me.tabMetaInfoTec.TabIndex = 1
        Me.tabMetaInfoTec.Text = "Informação técnica"
        '
        'btnDeleteDerivatives
        '
        Me.btnDeleteDerivatives.BackColor = System.Drawing.Color.White
        Me.btnDeleteDerivatives.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteDerivatives.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteDerivatives.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteDerivatives.ImageIndex = 1
        Me.btnDeleteDerivatives.ImageList = Me.imglButtons
        Me.btnDeleteDerivatives.Location = New System.Drawing.Point(20, 577)
        Me.btnDeleteDerivatives.Name = "btnDeleteDerivatives"
        Me.btnDeleteDerivatives.Size = New System.Drawing.Size(132, 25)
        Me.btnDeleteDerivatives.TabIndex = 131
        Me.btnDeleteDerivatives.Text = "Eliminar derivadas"
        Me.btnDeleteDerivatives.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupInfoPreservation
        '
        Me.groupInfoPreservation.BackColor = System.Drawing.Color.WhiteSmoke
        Me.groupInfoPreservation.Controls.Add(Me.lblArchivingProfile)
        Me.groupInfoPreservation.Controls.Add(Me.lblExternalDescriptiveInfo)
        Me.groupInfoPreservation.Controls.Add(Me.lblPreservationOriginalInformation)
        Me.groupInfoPreservation.Controls.Add(Me.txtArchivingProfile)
        Me.groupInfoPreservation.Controls.Add(Me.txtExternalDescriptiveInfo)
        Me.groupInfoPreservation.Controls.Add(Me.txtPreservationOriginalInformation)
        Me.groupInfoPreservation.Controls.Add(Me.lblTM14)
        Me.groupInfoPreservation.Controls.Add(Me.lblTM13)
        Me.groupInfoPreservation.Controls.Add(Me.lblTM15)
        Me.groupInfoPreservation.Location = New System.Drawing.Point(20, 416)
        Me.groupInfoPreservation.Name = "groupInfoPreservation"
        Me.groupInfoPreservation.Size = New System.Drawing.Size(507, 138)
        Me.groupInfoPreservation.TabIndex = 130
        Me.groupInfoPreservation.TabStop = False
        Me.groupInfoPreservation.Text = "Informação preservação"
        '
        'lblArchivingProfile
        '
        Me.lblArchivingProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArchivingProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchivingProfile.Location = New System.Drawing.Point(140, 96)
        Me.lblArchivingProfile.Name = "lblArchivingProfile"
        Me.lblArchivingProfile.Size = New System.Drawing.Size(350, 32)
        Me.lblArchivingProfile.TabIndex = 128
        '
        'lblExternalDescriptiveInfo
        '
        Me.lblExternalDescriptiveInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExternalDescriptiveInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExternalDescriptiveInfo.Location = New System.Drawing.Point(140, 59)
        Me.lblExternalDescriptiveInfo.Name = "lblExternalDescriptiveInfo"
        Me.lblExternalDescriptiveInfo.Size = New System.Drawing.Size(350, 32)
        Me.lblExternalDescriptiveInfo.TabIndex = 127
        '
        'lblPreservationOriginalInformation
        '
        Me.lblPreservationOriginalInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreservationOriginalInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreservationOriginalInformation.Location = New System.Drawing.Point(140, 22)
        Me.lblPreservationOriginalInformation.Name = "lblPreservationOriginalInformation"
        Me.lblPreservationOriginalInformation.Size = New System.Drawing.Size(350, 32)
        Me.lblPreservationOriginalInformation.TabIndex = 126
        '
        'txtArchivingProfile
        '
        Me.txtArchivingProfile.BackColor = System.Drawing.Color.White
        Me.txtArchivingProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArchivingProfile.Location = New System.Drawing.Point(140, 96)
        Me.txtArchivingProfile.Multiline = True
        Me.txtArchivingProfile.Name = "txtArchivingProfile"
        Me.txtArchivingProfile.Size = New System.Drawing.Size(350, 32)
        Me.txtArchivingProfile.TabIndex = 12
        Me.txtArchivingProfile.Text = ""
        '
        'txtExternalDescriptiveInfo
        '
        Me.txtExternalDescriptiveInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExternalDescriptiveInfo.Location = New System.Drawing.Point(140, 59)
        Me.txtExternalDescriptiveInfo.Multiline = True
        Me.txtExternalDescriptiveInfo.Name = "txtExternalDescriptiveInfo"
        Me.txtExternalDescriptiveInfo.Size = New System.Drawing.Size(350, 32)
        Me.txtExternalDescriptiveInfo.TabIndex = 11
        Me.txtExternalDescriptiveInfo.Text = ""
        '
        'txtPreservationOriginalInformation
        '
        Me.txtPreservationOriginalInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPreservationOriginalInformation.Location = New System.Drawing.Point(140, 22)
        Me.txtPreservationOriginalInformation.Multiline = True
        Me.txtPreservationOriginalInformation.Name = "txtPreservationOriginalInformation"
        Me.txtPreservationOriginalInformation.Size = New System.Drawing.Size(350, 32)
        Me.txtPreservationOriginalInformation.TabIndex = 10
        Me.txtPreservationOriginalInformation.Text = ""
        '
        'lblTM14
        '
        Me.lblTM14.BackColor = System.Drawing.Color.Transparent
        Me.lblTM14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM14.Location = New System.Drawing.Point(20, 59)
        Me.lblTM14.Name = "lblTM14"
        Me.lblTM14.Size = New System.Drawing.Size(113, 28)
        Me.lblTM14.TabIndex = 92
        Me.lblTM14.Text = "Informação descritiva externa"
        Me.lblTM14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM13
        '
        Me.lblTM13.BackColor = System.Drawing.Color.Transparent
        Me.lblTM13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM13.Location = New System.Drawing.Point(20, 22)
        Me.lblTM13.Name = "lblTM13"
        Me.lblTM13.Size = New System.Drawing.Size(113, 28)
        Me.lblTM13.TabIndex = 91
        Me.lblTM13.Text = "Preservação do objecto digital original"
        Me.lblTM13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM15
        '
        Me.lblTM15.BackColor = System.Drawing.Color.Transparent
        Me.lblTM15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM15.Location = New System.Drawing.Point(20, 96)
        Me.lblTM15.Name = "lblTM15"
        Me.lblTM15.Size = New System.Drawing.Size(113, 28)
        Me.lblTM15.TabIndex = 93
        Me.lblTM15.Text = "Documentação de apoio"
        Me.lblTM15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'groupInfoGeral
        '
        Me.groupInfoGeral.BackColor = System.Drawing.Color.WhiteSmoke
        Me.groupInfoGeral.Controls.Add(Me.lblOriginalName)
        Me.groupInfoGeral.Controls.Add(Me.txtOriginalName)
        Me.groupInfoGeral.Controls.Add(Me.tvwDescriptionInfo)
        Me.groupInfoGeral.Controls.Add(Me.Label7)
        Me.groupInfoGeral.Controls.Add(Me.Label5)
        Me.groupInfoGeral.Controls.Add(Me.lblTopographicalQuota)
        Me.groupInfoGeral.Controls.Add(Me.lblArchiveID)
        Me.groupInfoGeral.Controls.Add(Me.ckbActive)
        Me.groupInfoGeral.Controls.Add(Me.lblName)
        Me.groupInfoGeral.Controls.Add(Me.lblIP)
        Me.groupInfoGeral.Controls.Add(Me.lblTM4)
        Me.groupInfoGeral.Controls.Add(Me.txtTopographicalQuota)
        Me.groupInfoGeral.Controls.Add(Me.lblTM1)
        Me.groupInfoGeral.Controls.Add(Me.txtArchiveID)
        Me.groupInfoGeral.Controls.Add(Me.lblTM2)
        Me.groupInfoGeral.Controls.Add(Me.lblTM3)
        Me.groupInfoGeral.Controls.Add(Me.lblNumImg)
        Me.groupInfoGeral.Controls.Add(Me.lblTM5)
        Me.groupInfoGeral.Location = New System.Drawing.Point(20, 21)
        Me.groupInfoGeral.Name = "groupInfoGeral"
        Me.groupInfoGeral.Size = New System.Drawing.Size(507, 235)
        Me.groupInfoGeral.TabIndex = 129
        Me.groupInfoGeral.TabStop = False
        Me.groupInfoGeral.Text = "Informação geral"
        '
        'lblOriginalName
        '
        Me.lblOriginalName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblOriginalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOriginalName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalName.Location = New System.Drawing.Point(140, 47)
        Me.lblOriginalName.Name = "lblOriginalName"
        Me.lblOriginalName.Size = New System.Drawing.Size(350, 20)
        Me.lblOriginalName.TabIndex = 130
        Me.lblOriginalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOriginalName
        '
        Me.txtOriginalName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOriginalName.BackColor = System.Drawing.Color.White
        Me.txtOriginalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOriginalName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginalName.Location = New System.Drawing.Point(140, 47)
        Me.txtOriginalName.Name = "txtOriginalName"
        Me.txtOriginalName.Size = New System.Drawing.Size(350, 20)
        Me.txtOriginalName.TabIndex = 1
        Me.txtOriginalName.Text = ""
        '
        'tvwDescriptionInfo
        '
        Me.tvwDescriptionInfo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tvwDescriptionInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwDescriptionInfo.ImageList = Me.ImageListTVDigitarq
        Me.tvwDescriptionInfo.Location = New System.Drawing.Point(140, 72)
        Me.tvwDescriptionInfo.Name = "tvwDescriptionInfo"
        Me.tvwDescriptionInfo.Size = New System.Drawing.Size(350, 48)
        Me.tvwDescriptionInfo.TabIndex = 128
        '
        'ImageListTVDigitarq
        '
        Me.ImageListTVDigitarq.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListTVDigitarq.ImageStream = CType(resources.GetObject("ImageListTVDigitarq.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTVDigitarq.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 48)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "Referências das desc. arquivísticas"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 20)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Nome original"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTopographicalQuota
        '
        Me.lblTopographicalQuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTopographicalQuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTopographicalQuota.Location = New System.Drawing.Point(140, 150)
        Me.lblTopographicalQuota.Name = "lblTopographicalQuota"
        Me.lblTopographicalQuota.Size = New System.Drawing.Size(350, 20)
        Me.lblTopographicalQuota.TabIndex = 124
        Me.lblTopographicalQuota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblArchiveID
        '
        Me.lblArchiveID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArchiveID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchiveID.Location = New System.Drawing.Point(140, 125)
        Me.lblArchiveID.Name = "lblArchiveID"
        Me.lblArchiveID.Size = New System.Drawing.Size(350, 20)
        Me.lblArchiveID.TabIndex = 123
        Me.lblArchiveID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbActive
        '
        Me.ckbActive.Enabled = False
        Me.ckbActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbActive.Location = New System.Drawing.Point(403, 208)
        Me.ckbActive.Name = "ckbActive"
        Me.ckbActive.Size = New System.Drawing.Size(87, 20)
        Me.ckbActive.TabIndex = 4
        Me.ckbActive.Text = "Activo"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(140, 22)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(350, 20)
        Me.lblName.TabIndex = 119
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIP
        '
        Me.lblIP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIP.Location = New System.Drawing.Point(140, 175)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(350, 20)
        Me.lblIP.TabIndex = 121
        Me.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM4
        '
        Me.lblTM4.BackColor = System.Drawing.Color.Transparent
        Me.lblTM4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM4.Location = New System.Drawing.Point(20, 175)
        Me.lblTM4.Name = "lblTM4"
        Me.lblTM4.Size = New System.Drawing.Size(113, 20)
        Me.lblTM4.TabIndex = 120
        Me.lblTM4.Text = "Indivíduo produtor"
        Me.lblTM4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTopographicalQuota
        '
        Me.txtTopographicalQuota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTopographicalQuota.BackColor = System.Drawing.Color.White
        Me.txtTopographicalQuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTopographicalQuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTopographicalQuota.Location = New System.Drawing.Point(140, 150)
        Me.txtTopographicalQuota.Name = "txtTopographicalQuota"
        Me.txtTopographicalQuota.Size = New System.Drawing.Size(350, 20)
        Me.txtTopographicalQuota.TabIndex = 3
        Me.txtTopographicalQuota.Text = ""
        '
        'lblTM1
        '
        Me.lblTM1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM1.ForeColor = System.Drawing.Color.Red
        Me.lblTM1.Location = New System.Drawing.Point(20, 22)
        Me.lblTM1.Name = "lblTM1"
        Me.lblTM1.Size = New System.Drawing.Size(113, 20)
        Me.lblTM1.TabIndex = 117
        Me.lblTM1.Text = "Nome"
        Me.lblTM1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtArchiveID
        '
        Me.txtArchiveID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtArchiveID.BackColor = System.Drawing.Color.White
        Me.txtArchiveID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArchiveID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchiveID.Location = New System.Drawing.Point(140, 125)
        Me.txtArchiveID.Name = "txtArchiveID"
        Me.txtArchiveID.Size = New System.Drawing.Size(350, 20)
        Me.txtArchiveID.TabIndex = 2
        Me.txtArchiveID.Text = ""
        '
        'lblTM2
        '
        Me.lblTM2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM2.Location = New System.Drawing.Point(20, 125)
        Me.lblTM2.Name = "lblTM2"
        Me.lblTM2.Size = New System.Drawing.Size(113, 20)
        Me.lblTM2.TabIndex = 82
        Me.lblTM2.Text = "Identificação suporte"
        Me.lblTM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM3
        '
        Me.lblTM3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM3.Location = New System.Drawing.Point(20, 150)
        Me.lblTM3.Name = "lblTM3"
        Me.lblTM3.Size = New System.Drawing.Size(113, 20)
        Me.lblTM3.TabIndex = 83
        Me.lblTM3.Text = "Cota topográfica"
        Me.lblTM3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumImg
        '
        Me.lblNumImg.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblNumImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumImg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumImg.Location = New System.Drawing.Point(140, 208)
        Me.lblNumImg.Name = "lblNumImg"
        Me.lblNumImg.Size = New System.Drawing.Size(90, 20)
        Me.lblNumImg.TabIndex = 101
        Me.lblNumImg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM5
        '
        Me.lblTM5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM5.Location = New System.Drawing.Point(20, 208)
        Me.lblTM5.Name = "lblTM5"
        Me.lblTM5.Size = New System.Drawing.Size(113, 20)
        Me.lblTM5.TabIndex = 88
        Me.lblTM5.Text = "Nº Imagens"
        Me.lblTM5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'groupDates
        '
        Me.groupDates.BackColor = System.Drawing.Color.WhiteSmoke
        Me.groupDates.Controls.Add(Me.lblArchiveDateTime)
        Me.groupDates.Controls.Add(Me.lblCreationDateTime)
        Me.groupDates.Controls.Add(Me.txtArchiveDateTime)
        Me.groupDates.Controls.Add(Me.txtCreationDateTime)
        Me.groupDates.Controls.Add(Me.lblRevisionDateTime)
        Me.groupDates.Controls.Add(Me.lblTM10)
        Me.groupDates.Controls.Add(Me.lblTM8)
        Me.groupDates.Controls.Add(Me.lblTM6)
        Me.groupDates.Controls.Add(Me.lblTM7)
        Me.groupDates.Controls.Add(Me.lblDepositDateTime)
        Me.groupDates.Controls.Add(Me.txtDepositDateTime)
        Me.groupDates.Location = New System.Drawing.Point(20, 256)
        Me.groupDates.Name = "groupDates"
        Me.groupDates.Size = New System.Drawing.Size(507, 80)
        Me.groupDates.TabIndex = 128
        Me.groupDates.TabStop = False
        Me.groupDates.Text = "Datas"
        '
        'lblArchiveDateTime
        '
        Me.lblArchiveDateTime.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblArchiveDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArchiveDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchiveDateTime.Location = New System.Drawing.Point(400, 22)
        Me.lblArchiveDateTime.Name = "lblArchiveDateTime"
        Me.lblArchiveDateTime.Size = New System.Drawing.Size(90, 20)
        Me.lblArchiveDateTime.TabIndex = 131
        Me.lblArchiveDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreationDateTime
        '
        Me.lblCreationDateTime.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCreationDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreationDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreationDateTime.Location = New System.Drawing.Point(140, 22)
        Me.lblCreationDateTime.Name = "lblCreationDateTime"
        Me.lblCreationDateTime.Size = New System.Drawing.Size(90, 20)
        Me.lblCreationDateTime.TabIndex = 129
        Me.lblCreationDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtArchiveDateTime
        '
        Me.txtArchiveDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtArchiveDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArchiveDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchiveDateTime.Location = New System.Drawing.Point(400, 22)
        Me.txtArchiveDateTime.Mask = "####-##-##"
        Me.txtArchiveDateTime.MaxLength = 10
        Me.txtArchiveDateTime.Name = "txtArchiveDateTime"
        Me.txtArchiveDateTime.Size = New System.Drawing.Size(90, 20)
        Me.txtArchiveDateTime.TabIndex = 6
        Me.txtArchiveDateTime.Text = ""
        '
        'txtCreationDateTime
        '
        Me.txtCreationDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreationDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreationDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreationDateTime.Location = New System.Drawing.Point(140, 22)
        Me.txtCreationDateTime.Mask = "####-##-##"
        Me.txtCreationDateTime.MaxLength = 10
        Me.txtCreationDateTime.Name = "txtCreationDateTime"
        Me.txtCreationDateTime.Size = New System.Drawing.Size(90, 20)
        Me.txtCreationDateTime.TabIndex = 5
        Me.txtCreationDateTime.Text = ""
        '
        'lblRevisionDateTime
        '
        Me.lblRevisionDateTime.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblRevisionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRevisionDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevisionDateTime.Location = New System.Drawing.Point(400, 48)
        Me.lblRevisionDateTime.Name = "lblRevisionDateTime"
        Me.lblRevisionDateTime.Size = New System.Drawing.Size(90, 20)
        Me.lblRevisionDateTime.TabIndex = 125
        Me.lblRevisionDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM10
        '
        Me.lblTM10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM10.Location = New System.Drawing.Point(304, 48)
        Me.lblTM10.Name = "lblTM10"
        Me.lblTM10.Size = New System.Drawing.Size(93, 20)
        Me.lblTM10.TabIndex = 124
        Me.lblTM10.Text = "Data revisão"
        Me.lblTM10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM8
        '
        Me.lblTM8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM8.Location = New System.Drawing.Point(20, 48)
        Me.lblTM8.Name = "lblTM8"
        Me.lblTM8.Size = New System.Drawing.Size(113, 20)
        Me.lblTM8.TabIndex = 120
        Me.lblTM8.Text = "Data depósito"
        Me.lblTM8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM6
        '
        Me.lblTM6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM6.ForeColor = System.Drawing.Color.Red
        Me.lblTM6.Location = New System.Drawing.Point(20, 22)
        Me.lblTM6.Name = "lblTM6"
        Me.lblTM6.Size = New System.Drawing.Size(113, 20)
        Me.lblTM6.TabIndex = 85
        Me.lblTM6.Text = "Data criação"
        Me.lblTM6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM7
        '
        Me.lblTM7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM7.ForeColor = System.Drawing.Color.Red
        Me.lblTM7.Location = New System.Drawing.Point(304, 22)
        Me.lblTM7.Name = "lblTM7"
        Me.lblTM7.Size = New System.Drawing.Size(93, 20)
        Me.lblTM7.TabIndex = 87
        Me.lblTM7.Text = "Data integração"
        Me.lblTM7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepositDateTime
        '
        Me.lblDepositDateTime.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblDepositDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDepositDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepositDateTime.Location = New System.Drawing.Point(140, 48)
        Me.lblDepositDateTime.Name = "lblDepositDateTime"
        Me.lblDepositDateTime.Size = New System.Drawing.Size(90, 20)
        Me.lblDepositDateTime.TabIndex = 130
        Me.lblDepositDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepositDateTime
        '
        Me.txtDepositDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepositDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepositDateTime.Location = New System.Drawing.Point(140, 48)
        Me.txtDepositDateTime.Mask = "####-##-##"
        Me.txtDepositDateTime.MaxLength = 10
        Me.txtDepositDateTime.Name = "txtDepositDateTime"
        Me.txtDepositDateTime.Size = New System.Drawing.Size(90, 20)
        Me.txtDepositDateTime.TabIndex = 7
        Me.txtDepositDateTime.Text = ""
        '
        'groupEntities
        '
        Me.groupEntities.BackColor = System.Drawing.Color.WhiteSmoke
        Me.groupEntities.Controls.Add(Me.lblCaptureEntityCorporate)
        Me.groupEntities.Controls.Add(Me.lblResponsabilityEntity)
        Me.groupEntities.Controls.Add(Me.txtResponsabilityEntity)
        Me.groupEntities.Controls.Add(Me.lblTM11)
        Me.groupEntities.Controls.Add(Me.lblTM12)
        Me.groupEntities.Controls.Add(Me.txtCaptureEntityCorporate)
        Me.groupEntities.Location = New System.Drawing.Point(20, 336)
        Me.groupEntities.Name = "groupEntities"
        Me.groupEntities.Size = New System.Drawing.Size(507, 80)
        Me.groupEntities.TabIndex = 127
        Me.groupEntities.TabStop = False
        Me.groupEntities.Text = "Entidades"
        '
        'lblCaptureEntityCorporate
        '
        Me.lblCaptureEntityCorporate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCaptureEntityCorporate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptureEntityCorporate.Location = New System.Drawing.Point(140, 48)
        Me.lblCaptureEntityCorporate.Name = "lblCaptureEntityCorporate"
        Me.lblCaptureEntityCorporate.Size = New System.Drawing.Size(350, 20)
        Me.lblCaptureEntityCorporate.TabIndex = 125
        Me.lblCaptureEntityCorporate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResponsabilityEntity
        '
        Me.lblResponsabilityEntity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResponsabilityEntity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsabilityEntity.Location = New System.Drawing.Point(140, 22)
        Me.lblResponsabilityEntity.Name = "lblResponsabilityEntity"
        Me.lblResponsabilityEntity.Size = New System.Drawing.Size(350, 20)
        Me.lblResponsabilityEntity.TabIndex = 124
        Me.lblResponsabilityEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResponsabilityEntity
        '
        Me.txtResponsabilityEntity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResponsabilityEntity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResponsabilityEntity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponsabilityEntity.Location = New System.Drawing.Point(140, 22)
        Me.txtResponsabilityEntity.Name = "txtResponsabilityEntity"
        Me.txtResponsabilityEntity.Size = New System.Drawing.Size(350, 20)
        Me.txtResponsabilityEntity.TabIndex = 8
        Me.txtResponsabilityEntity.Text = ""
        '
        'lblTM11
        '
        Me.lblTM11.BackColor = System.Drawing.Color.Transparent
        Me.lblTM11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM11.Location = New System.Drawing.Point(20, 22)
        Me.lblTM11.Name = "lblTM11"
        Me.lblTM11.Size = New System.Drawing.Size(113, 20)
        Me.lblTM11.TabIndex = 110
        Me.lblTM11.Text = "Entidade responsável"
        Me.lblTM11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTM12
        '
        Me.lblTM12.BackColor = System.Drawing.Color.Transparent
        Me.lblTM12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTM12.Location = New System.Drawing.Point(20, 48)
        Me.lblTM12.Name = "lblTM12"
        Me.lblTM12.Size = New System.Drawing.Size(113, 20)
        Me.lblTM12.TabIndex = 108
        Me.lblTM12.Text = "Entidade produtora"
        Me.lblTM12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCaptureEntityCorporate
        '
        Me.txtCaptureEntityCorporate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCaptureEntityCorporate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaptureEntityCorporate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaptureEntityCorporate.Location = New System.Drawing.Point(140, 48)
        Me.txtCaptureEntityCorporate.Name = "txtCaptureEntityCorporate"
        Me.txtCaptureEntityCorporate.Size = New System.Drawing.Size(350, 20)
        Me.txtCaptureEntityCorporate.TabIndex = 9
        Me.txtCaptureEntityCorporate.Text = ""
        '
        'tabMetaInfoPreserv
        '
        Me.tabMetaInfoPreserv.BackColor = System.Drawing.Color.White
        Me.tabMetaInfoPreserv.Controls.Add(Me.btnHistorical)
        Me.tabMetaInfoPreserv.Controls.Add(Me.btnSavePreservationInfo)
        Me.tabMetaInfoPreserv.Controls.Add(Me.grpBxEsrtuturaReformatacao)
        Me.tabMetaInfoPreserv.Location = New System.Drawing.Point(4, 22)
        Me.tabMetaInfoPreserv.Name = "tabMetaInfoPreserv"
        Me.tabMetaInfoPreserv.Size = New System.Drawing.Size(672, 614)
        Me.tabMetaInfoPreserv.TabIndex = 3
        Me.tabMetaInfoPreserv.Text = "Informação de preservação"
        '
        'btnHistorical
        '
        Me.btnHistorical.BackColor = System.Drawing.Color.White
        Me.btnHistorical.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistorical.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistorical.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHistorical.Location = New System.Drawing.Point(368, 344)
        Me.btnHistorical.Name = "btnHistorical"
        Me.btnHistorical.Size = New System.Drawing.Size(88, 25)
        Me.btnHistorical.TabIndex = 59
        Me.btnHistorical.Text = "Histórico"
        '
        'btnSavePreservationInfo
        '
        Me.btnSavePreservationInfo.BackColor = System.Drawing.Color.White
        Me.btnSavePreservationInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePreservationInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePreservationInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSavePreservationInfo.ImageIndex = 2
        Me.btnSavePreservationInfo.ImageList = Me.imglButtons
        Me.btnSavePreservationInfo.Location = New System.Drawing.Point(472, 344)
        Me.btnSavePreservationInfo.Name = "btnSavePreservationInfo"
        Me.btnSavePreservationInfo.Size = New System.Drawing.Size(88, 25)
        Me.btnSavePreservationInfo.TabIndex = 60
        Me.btnSavePreservationInfo.Text = "Guardar"
        Me.btnSavePreservationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpBxEsrtuturaReformatacao
        '
        Me.grpBxEsrtuturaReformatacao.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.btnChooseReformattingNorms)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.btnChooseReformattingMethod)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.lbxReformattingNormsChoosen)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.Label2)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.txtReformattingMethod)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.Label1)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.txtParameters)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.txtInputFormat)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.txtRenderEngine)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.txtPlatform)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.txtTransformer)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.lblTransformerObject)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.lblInputFormat)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.lblRenderEngine)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.lblParameters)
        Me.grpBxEsrtuturaReformatacao.Controls.Add(Me.lblPlatform)
        Me.grpBxEsrtuturaReformatacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBxEsrtuturaReformatacao.Location = New System.Drawing.Point(24, 24)
        Me.grpBxEsrtuturaReformatacao.Name = "grpBxEsrtuturaReformatacao"
        Me.grpBxEsrtuturaReformatacao.Size = New System.Drawing.Size(536, 304)
        Me.grpBxEsrtuturaReformatacao.TabIndex = 14
        Me.grpBxEsrtuturaReformatacao.TabStop = False
        Me.grpBxEsrtuturaReformatacao.Text = "Estrutura de reformatação do objecto digital"
        '
        'btnChooseReformattingNorms
        '
        Me.btnChooseReformattingNorms.BackColor = System.Drawing.Color.White
        Me.btnChooseReformattingNorms.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChooseReformattingNorms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChooseReformattingNorms.Location = New System.Drawing.Point(504, 214)
        Me.btnChooseReformattingNorms.Name = "btnChooseReformattingNorms"
        Me.btnChooseReformattingNorms.Size = New System.Drawing.Size(24, 20)
        Me.btnChooseReformattingNorms.TabIndex = 58
        Me.btnChooseReformattingNorms.Text = "..."
        '
        'btnChooseReformattingMethod
        '
        Me.btnChooseReformattingMethod.BackColor = System.Drawing.Color.White
        Me.btnChooseReformattingMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChooseReformattingMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChooseReformattingMethod.Location = New System.Drawing.Point(504, 185)
        Me.btnChooseReformattingMethod.Name = "btnChooseReformattingMethod"
        Me.btnChooseReformattingMethod.Size = New System.Drawing.Size(24, 20)
        Me.btnChooseReformattingMethod.TabIndex = 56
        Me.btnChooseReformattingMethod.Text = "..."
        '
        'lbxReformattingNormsChoosen
        '
        Me.lbxReformattingNormsChoosen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbxReformattingNormsChoosen.Location = New System.Drawing.Point(144, 214)
        Me.lbxReformattingNormsChoosen.Name = "lbxReformattingNormsChoosen"
        Me.lbxReformattingNormsChoosen.Size = New System.Drawing.Size(350, 80)
        Me.lbxReformattingNormsChoosen.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 21)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Normas de reformatação"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReformattingMethod
        '
        Me.txtReformattingMethod.BackColor = System.Drawing.Color.White
        Me.txtReformattingMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReformattingMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReformattingMethod.Location = New System.Drawing.Point(144, 185)
        Me.txtReformattingMethod.Name = "txtReformattingMethod"
        Me.txtReformattingMethod.Size = New System.Drawing.Size(350, 20)
        Me.txtReformattingMethod.TabIndex = 55
        Me.txtReformattingMethod.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 21)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Método de reformatação"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtParameters
        '
        Me.txtParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtParameters.Location = New System.Drawing.Point(144, 144)
        Me.txtParameters.Multiline = True
        Me.txtParameters.Name = "txtParameters"
        Me.txtParameters.Size = New System.Drawing.Size(350, 32)
        Me.txtParameters.TabIndex = 54
        Me.txtParameters.Text = ""
        '
        'txtInputFormat
        '
        Me.txtInputFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInputFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInputFormat.Location = New System.Drawing.Point(144, 115)
        Me.txtInputFormat.Name = "txtInputFormat"
        Me.txtInputFormat.Size = New System.Drawing.Size(350, 20)
        Me.txtInputFormat.TabIndex = 53
        Me.txtInputFormat.Text = ""
        '
        'txtRenderEngine
        '
        Me.txtRenderEngine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRenderEngine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenderEngine.Location = New System.Drawing.Point(144, 86)
        Me.txtRenderEngine.Name = "txtRenderEngine"
        Me.txtRenderEngine.Size = New System.Drawing.Size(350, 20)
        Me.txtRenderEngine.TabIndex = 52
        Me.txtRenderEngine.Text = ""
        '
        'txtPlatform
        '
        Me.txtPlatform.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlatform.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlatform.Location = New System.Drawing.Point(144, 57)
        Me.txtPlatform.Name = "txtPlatform"
        Me.txtPlatform.Size = New System.Drawing.Size(350, 20)
        Me.txtPlatform.TabIndex = 51
        Me.txtPlatform.Text = ""
        '
        'txtTransformer
        '
        Me.txtTransformer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransformer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransformer.Location = New System.Drawing.Point(144, 28)
        Me.txtTransformer.Name = "txtTransformer"
        Me.txtTransformer.Size = New System.Drawing.Size(350, 20)
        Me.txtTransformer.TabIndex = 50
        Me.txtTransformer.Text = ""
        '
        'lblTransformerObject
        '
        Me.lblTransformerObject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransformerObject.Location = New System.Drawing.Point(7, 28)
        Me.lblTransformerObject.Name = "lblTransformerObject"
        Me.lblTransformerObject.Size = New System.Drawing.Size(136, 21)
        Me.lblTransformerObject.TabIndex = 37
        Me.lblTransformerObject.Text = "Transformador"
        Me.lblTransformerObject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInputFormat
        '
        Me.lblInputFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputFormat.Location = New System.Drawing.Point(7, 115)
        Me.lblInputFormat.Name = "lblInputFormat"
        Me.lblInputFormat.Size = New System.Drawing.Size(136, 21)
        Me.lblInputFormat.TabIndex = 47
        Me.lblInputFormat.Text = "Formato de entrada"
        Me.lblInputFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRenderEngine
        '
        Me.lblRenderEngine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRenderEngine.Location = New System.Drawing.Point(7, 86)
        Me.lblRenderEngine.Name = "lblRenderEngine"
        Me.lblRenderEngine.Size = New System.Drawing.Size(136, 21)
        Me.lblRenderEngine.TabIndex = 45
        Me.lblRenderEngine.Text = "Dispositivo visualização"
        Me.lblRenderEngine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblParameters
        '
        Me.lblParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParameters.Location = New System.Drawing.Point(7, 144)
        Me.lblParameters.Name = "lblParameters"
        Me.lblParameters.Size = New System.Drawing.Size(136, 21)
        Me.lblParameters.TabIndex = 43
        Me.lblParameters.Text = "Parâmetros"
        Me.lblParameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPlatform
        '
        Me.lblPlatform.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlatform.Location = New System.Drawing.Point(7, 57)
        Me.lblPlatform.Name = "lblPlatform"
        Me.lblPlatform.Size = New System.Drawing.Size(136, 21)
        Me.lblPlatform.TabIndex = 41
        Me.lblPlatform.Text = "Plataforma"
        Me.lblPlatform.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDeleteDO
        '
        Me.btnDeleteDO.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDeleteDO.BackColor = System.Drawing.Color.White
        Me.btnDeleteDO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteDO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteDO.ImageIndex = 1
        Me.btnDeleteDO.ImageList = Me.imglButtons
        Me.btnDeleteDO.Location = New System.Drawing.Point(8, 600)
        Me.btnDeleteDO.Name = "btnDeleteDO"
        Me.btnDeleteDO.Size = New System.Drawing.Size(168, 25)
        Me.btnDeleteDO.TabIndex = 24
        Me.btnDeleteDO.Text = "Eliminar objecto digital"
        Me.btnDeleteDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupLstProjects
        '
        Me.groupLstProjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupLstProjects.BackColor = System.Drawing.Color.WhiteSmoke
        Me.groupLstProjects.Controls.Add(Me.btnFind)
        Me.groupLstProjects.Controls.Add(Me.lblAttention)
        Me.groupLstProjects.Controls.Add(Me.lvwDO)
        Me.groupLstProjects.Controls.Add(Me.btnNewDO)
        Me.groupLstProjects.Controls.Add(Me.btnDeleteDO)
        Me.groupLstProjects.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupLstProjects.Location = New System.Drawing.Point(8, 8)
        Me.groupLstProjects.Name = "groupLstProjects"
        Me.groupLstProjects.Size = New System.Drawing.Size(184, 640)
        Me.groupLstProjects.TabIndex = 1
        Me.groupLstProjects.TabStop = False
        Me.groupLstProjects.Text = "Objectos digitais"
        '
        'btnFind
        '
        Me.btnFind.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnFind.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFind.ButtonImage = CType(resources.GetObject("btnFind.ButtonImage"), System.Drawing.Image)
        Me.btnFind.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnFind.ButtonShowShadow = True
        Me.btnFind.ButtonText = ""
        Me.btnFind.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnFind.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnFind.HighlightBackgroundColor = System.Drawing.Color.FromArgb(CType(252, Byte), CType(252, Byte), CType(252, Byte))
        Me.btnFind.Location = New System.Drawing.Point(151, 20)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(24, 24)
        Me.btnFind.TabIndex = 107
        '
        'lblAttention
        '
        Me.lblAttention.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAttention.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttention.Image = CType(resources.GetObject("lblAttention.Image"), System.Drawing.Image)
        Me.lblAttention.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAttention.Location = New System.Drawing.Point(8, 578)
        Me.lblAttention.Name = "lblAttention"
        Me.lblAttention.Size = New System.Drawing.Size(128, 20)
        Me.lblAttention.TabIndex = 106
        Me.lblAttention.Text = "Carece de revisão"
        Me.lblAttention.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAttention.Visible = False
        '
        'lvwDO
        '
        Me.lvwDO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwDO.HideSelection = False
        Me.lvwDO.Location = New System.Drawing.Point(8, 48)
        Me.lvwDO.Name = "lvwDO"
        Me.lvwDO.Size = New System.Drawing.Size(168, 530)
        Me.lvwDO.SmallImageList = Me.imglDigitalObjects
        Me.lvwDO.StateImageList = Me.imglDigitalObjects
        Me.lvwDO.TabIndex = 105
        '
        'imglDigitalObjects
        '
        Me.imglDigitalObjects.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglDigitalObjects.ImageStream = CType(resources.GetObject("imglDigitalObjects.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglDigitalObjects.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnNewDO
        '
        Me.btnNewDO.BackColor = System.Drawing.Color.White
        Me.btnNewDO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewDO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewDO.ImageIndex = 0
        Me.btnNewDO.ImageList = Me.imglButtons
        Me.btnNewDO.Location = New System.Drawing.Point(8, 20)
        Me.btnNewDO.Name = "btnNewDO"
        Me.btnNewDO.Size = New System.Drawing.Size(136, 25)
        Me.btnNewDO.TabIndex = 4
        Me.btnNewDO.Text = "Novo objecto digital"
        Me.btnNewDO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDeleteOD
        '
        Me.btnDeleteOD.BackColor = System.Drawing.Color.White
        Me.btnDeleteOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteOD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDeleteOD.ImageIndex = 3
        Me.btnDeleteOD.Location = New System.Drawing.Point(344, 560)
        Me.btnDeleteOD.Name = "btnDeleteOD"
        Me.btnDeleteOD.Size = New System.Drawing.Size(136, 24)
        Me.btnDeleteOD.TabIndex = 104
        Me.btnDeleteOD.Text = "Recuperar"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miProjects, Me.miEdit, Me.MenuItem4, Me.miReports, Me.miHelp})
        '
        'miProjects
        '
        Me.miProjects.Index = 0
        Me.miProjects.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miOpenProjects, Me.MenuItem2, Me.miClose})
        Me.miProjects.Text = CType(configurationAppSettings.GetValue("MenuFicheiro.Text", GetType(System.String)), String)
        '
        'miOpenProjects
        '
        Me.miOpenProjects.Index = 0
        Me.miOpenProjects.Text = "Listar projectos..."
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'miClose
        '
        Me.miClose.Index = 2
        Me.miClose.Text = CType(configurationAppSettings.GetValue("SairM.Text", GetType(System.String)), String)
        '
        'miEdit
        '
        Me.miEdit.Index = 1
        Me.miEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miDigitalizationProfiles, Me.miTechnologicalPlatform, Me.miLampTypes, Me.miMeteringModes, Me.miAutoFocus, Me.miRevisionInterval})
        Me.miEdit.Text = CType(configurationAppSettings.GetValue("MenuItem3.Text", GetType(System.String)), String)
        '
        'miDigitalizationProfiles
        '
        Me.miDigitalizationProfiles.Index = 0
        Me.miDigitalizationProfiles.Text = CType(configurationAppSettings.GetValue("EditPD.Text", GetType(System.String)), String)
        '
        'miTechnologicalPlatform
        '
        Me.miTechnologicalPlatform.Index = 1
        Me.miTechnologicalPlatform.Text = CType(configurationAppSettings.GetValue("EditPT.Text", GetType(System.String)), String)
        '
        'miLampTypes
        '
        Me.miLampTypes.Index = 2
        Me.miLampTypes.Text = CType(configurationAppSettings.GetValue("EditLT.Text", GetType(System.String)), String)
        '
        'miMeteringModes
        '
        Me.miMeteringModes.Index = 3
        Me.miMeteringModes.Text = CType(configurationAppSettings.GetValue("EditBD.Text", GetType(System.String)), String)
        '
        'miAutoFocus
        '
        Me.miAutoFocus.Index = 4
        Me.miAutoFocus.Text = CType(configurationAppSettings.GetValue("EditIC.Text", GetType(System.String)), String)
        '
        'miRevisionInterval
        '
        Me.miRevisionInterval.Index = 5
        Me.miRevisionInterval.Text = CType(configurationAppSettings.GetValue("EditIR.Text", GetType(System.String)), String)
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFilesRename, Me.miPOD})
        Me.MenuItem4.Text = "&Ferramentas"
        '
        'miFilesRename
        '
        Me.miFilesRename.Index = 0
        Me.miFilesRename.Text = "Renomeador de ficheiros..."
        '
        'miPOD
        '
        Me.miPOD.Index = 1
        Me.miPOD.Text = "Associação de descrições..."
        '
        'miReports
        '
        Me.miReports.Index = 3
        Me.miReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miReportDigitalizationProfiles, Me.miReportReformattingNorms, Me.miReportReformattingMethods, Me.miReportMetaOD, Me.miReportPreservationInfDO, Me.miReportImagesDO, Me.miReportRevisionDO, Me.miUIDigitalization})
        Me.miReports.Text = CType(configurationAppSettings.GetValue("MenuRelatorios.Text", GetType(System.String)), String)
        '
        'miReportDigitalizationProfiles
        '
        Me.miReportDigitalizationProfiles.Index = 0
        Me.miReportDigitalizationProfiles.Text = "Perfis de digitalização"
        '
        'miReportReformattingNorms
        '
        Me.miReportReformattingNorms.Index = 1
        Me.miReportReformattingNorms.Text = "Normas de preservação"
        '
        'miReportReformattingMethods
        '
        Me.miReportReformattingMethods.Index = 2
        Me.miReportReformattingMethods.Text = "Métodos de preservação"
        '
        'miReportMetaOD
        '
        Me.miReportMetaOD.Index = 3
        Me.miReportMetaOD.Text = "Metainformação do OD"
        '
        'miReportPreservationInfDO
        '
        Me.miReportPreservationInfDO.Index = 4
        Me.miReportPreservationInfDO.Text = "Informação de Preservação do OD"
        '
        'miReportImagesDO
        '
        Me.miReportImagesDO.Index = 5
        Me.miReportImagesDO.Text = "Imagens do OD"
        '
        'miReportRevisionDO
        '
        Me.miReportRevisionDO.Index = 6
        Me.miReportRevisionDO.Text = "Revisão de OD"
        '
        'miUIDigitalization
        '
        Me.miUIDigitalization.Index = 7
        Me.miUIDigitalization.Text = "UI digitalizadas por fundo"
        '
        'miHelp
        '
        Me.miHelp.Index = 4
        Me.miHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.About})
        Me.miHelp.Text = CType(configurationAppSettings.GetValue("MenuItem9.Text", GetType(System.String)), String)
        Me.miHelp.Visible = False
        '
        'About
        '
        Me.About.Index = 0
        Me.About.Text = CType(configurationAppSettings.GetValue("About.Text", GetType(System.String)), String)
        '
        'fileChooser
        '
        Me.fileChooser.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'DigitalObjectsForm
        '
        Me.AcceptButton = Me.btnAssociate
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(880, 657)
        Me.Controls.Add(Me.groupLstProjects)
        Me.Controls.Add(Me.tabOD)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.Name = "DigitalObjectsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = CType(configurationAppSettings.GetValue("Application.Name", GetType(System.String)), String)
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabOD.ResumeLayout(False)
        Me.tabMetaInfoStruct.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.tabMetaInfoTec.ResumeLayout(False)
        Me.groupInfoPreservation.ResumeLayout(False)
        Me.groupInfoGeral.ResumeLayout(False)
        Me.groupDates.ResumeLayout(False)
        Me.groupEntities.ResumeLayout(False)
        Me.tabMetaInfoPreserv.ResumeLayout(False)
        Me.grpBxEsrtuturaReformatacao.ResumeLayout(False)
        Me.groupLstProjects.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private properties"

    Private myProjectID As Integer
    Private myProjectName As String

    Private myDigitalObjectID As Int64
    Private myDOName As String
    Private myDOStructure As String

    Private myData1 As DataSet
    Private database As New SqlCommands
    Private tree As New CTree
    Private IsLoaded As Boolean
    Private configReader As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

    '// NOTE: These variables are shared so they can be accessed by other forms.
    Public Shared g_oTv As TreeView
    Dim m_bFormIsActivated As Boolean
    Dim m_tnSource As TreeNode
    Dim tn, tn2 As TreeNode
    Dim index As Integer

    Private tnAux As TreeNode

    Private myImage As System.Drawing.Image

#End Region


#Region "DigitalObjectsForm"

    Private Sub DigitalObjectsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetMDIContainerBackColor(System.Drawing.Color.White)


        Dim frmChooseProject As New ChooseProjectForm
        frmChooseProject.ShowDialog()
        myProjectID = frmChooseProject.ProjectID
        myProjectName = frmChooseProject.ProjectName

        Me.Text = General.GetFormTitle("[" & Constants.UserLogon & "]")

        CreateLvwDO()
        LoadData()
        EnableDisableZoom(False)
        If frmChooseProject.CreatedNewDO Then
            Me.btnNewDO_Click(sender, e)
        End If
        If Me.lvwDO.Items.Count > 0 Then
            Me.btnEditDO.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        End If
        g_oTv = treeImg
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

    Private Sub FormDO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '// The LoadTreeView() method only functions correctly when called from the
        '// Form.Activated() event because it requires access to UI elements that
        '// may not be available in the Form.Load() event.  The variable 
        '// m_bFormIsActivated is used to ensure the LoadTreeView() is called only
        '// once.
        If m_bFormIsActivated = False Then
            If Me.lvwDO.Items.Count > 0 Then
                LoadTreeView()
                m_bFormIsActivated = True
            End If
        End If
    End Sub

    Private Sub FormDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnCancel.Enabled Then
                If Me.btnEditDO.Tag = "New" Then
                    SaveNew()
                ElseIf Me.btnEditDO.Tag = "Update" Then
                    SaveChanges()
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If btnCancel.Enabled Then
                Cancel()
            Else
                Me.Close()
            End If
        End If
    End Sub

#End Region

#Region "Menus"

#Region "miProjects"

    Private Sub miOpenProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOpenProjects.Click
        Dim frmChooseProject As New ChooseProjectForm
        frmChooseProject.ShowDialog()
        myProjectID = frmChooseProject.ProjectID
        myProjectName = frmChooseProject.ProjectName

        LoadData()
    End Sub

    Private Sub miClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miClose.Click
        Me.Close()
    End Sub

#End Region

#Region "miPreferences"

    Private Sub EditPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDigitalizationProfiles.Click
        Dim formDP As New DigitalizationProfilesForm
        formDP.ShowDialog(Me)
    End Sub

    Private Sub EditPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTechnologicalPlatform.Click
        Dim formTP As New TechnologicalPlataformForm
        formTP.ShowDialog(Me)
    End Sub

    Private Sub EditLT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLampTypes.Click
        Dim formLP As New LampTypeForm
        formLP.ShowDialog(Me)
    End Sub

    Private Sub EditIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRevisionInterval.Click
        Dim form As New RevisionIntervalForm
        form.ShowDialog(Me)
    End Sub

    Private Sub EditMeteringModes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMeteringModes.Click
        Dim form As New MeteringModesForm
        form.ShowDialog(Me)
    End Sub

    Private Sub EditAutoFocus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAutoFocus.Click
        Dim form As New AutoFocusForm
        form.ShowDialog(Me)
    End Sub

#End Region

#Region "miTools"

    Private Sub miFilesRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFilesRename.Click
        Dim tv As New FilesRenameForm
        tv.ShowDialog(Me)
    End Sub

    Private Sub miPOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPOD.Click
        Dim PODForm As New MPOD.AssociationForm(Constants.UserLogon, myProjectID, myProjectName, Me.lvwDO.SelectedItems(0).Tag)
        PODForm.Show()
    End Sub

#End Region

#Region "miReports"

    Private Sub miReportDigitalizationProfiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportDigitalizationProfiles.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As DigitalizationProfilesData = RepDSBuilder.GenerateDPReportData

        Dim Report As New DigitalizationProfilesReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

    Private Sub miReportReformattingNorms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportReformattingNorms.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As ReformattingNormsData = RepDSBuilder.GenerateReformattingNormsReportData

        Dim Report As New ReformattingNormsReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

    Private Sub miReportReformattingMethods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportReformattingMethods.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As ReformattingMethodsData = RepDSBuilder.GenerateReformattingMethodsReportData

        Dim Report As New ReformattingMethodsReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

    Private Sub miReportMetaOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportMetaOD.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As DigitalObjectsData = RepDSBuilder.GenerateMIDigitalObjectsReportData(Me.lvwDO.Items)

        Dim Report As New MIDigitalObjectsReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

    Private Sub miReportPreservationInfDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportPreservationInfDO.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As PreservationInfoData = RepDSBuilder.GeneratePreservationInfoReportData(Me.lvwDO.Items)

        Dim Report As New PreservationInformationReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

    Private Sub miReportImagesDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportImagesDO.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As DOImagesData = RepDSBuilder.GenerateMIImagesReportData(Me.lvwDO.Items)

        Dim Report As New MIDOFilesReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

    Private Sub miReportRevisionDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miReportRevisionDO.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As DORevisionData = RepDSBuilder.GenerateDORevisionReportData(Me.lvwDO.Items)

        Dim Report As New DORevisionReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

    Private Sub miUIDigitalization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miUIDigitalization.Click
        Dim RepDSBuilder As New ReportDataSetBuilder
        Dim ReportDataSet As UIDigitalizationData = RepDSBuilder.GenerateUIDigitalizationReportData

        Dim Report As New UIDigitalizationReport
        Report.SetDataSource(ReportDataSet)
        Dim viewReport As New ReportPreviewForm(Report)
        viewReport.Show()
    End Sub

#End Region

#End Region

#Region "Structural metadata"

#Region "Image TreeView"

    Private Sub treeImg_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeImg.AfterSelect
        Try
            If Me.lvwDO.SelectedItems.Count > 0 Then

                ClearMetadataImage()
                EnableDisableZoom(True)
                e.Node.SelectedImageIndex = e.Node.ImageIndex

                If e.Node.ImageIndex >= 0 Then

                    If e.Node.ImageIndex = Constants.IMAGE_WITH_DERIVATIVE Then
                        myImage = database.getImage(e.Node.Text, Me.lvwDO.SelectedItems(0).Tag)

                        If Not myImage Is Nothing Then
                            Me.imgBox.PicBox.Size = ResizeImage(myImage.Size)
                            Me.imgBox.Image = myImage
                        End If

                        'verImgTd.Text = configReader.GetValue("Normal", GetType(String))
                        'verImgTd.Enabled = True

                    ElseIf e.Node.ImageIndex = Constants.TRANSCRIPTION Then
                        imgBox.Image = Nothing
                        database.getFile(e.Node.Text, Me.lvwDO.SelectedItems(0).Tag)
                        ViewPDf()
                        'verImgTd.Visible = False
                        EnableDisableZoom(False)
                    End If
                    BindMetadataImage()
                Else
                    EnableDisableZoom(False)
                    'Me.verImgTd.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try

    End Sub


    Private Function ResizeImage(ByVal Size As Size) As Size
        Dim OriginalImageHeight As Integer = Size.Height
        Dim OriginalImageWidth As Integer = Size.Width
        Size = New Size(OriginalImageWidth, OriginalImageHeight)

        If OriginalImageWidth > Me.imgBox.Width Then
            Dim Width1 As Integer = Me.imgBox.Width - 5
            Dim Height1 As Integer = OriginalImageHeight * Width1 / OriginalImageWidth
            Size = New Size(Width1, Height1)

            If Height1 > Me.imgBox.Height Then
                Dim Height2 As Integer = Me.imgBox.Height - 5
                Dim Width2 As Integer = Width1 * Height2 / Height1
                Size = New Size(Width2, Height2)
            End If
        End If

        Return Size
    End Function


#End Region

#Region "Image Viewer"

    Private Sub ViewPDf()
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\view1.pdf") Then
                Process.Start(Application.StartupPath & "\view1.pdf")
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um problema ao tentar abrir o ficheiro (*.pdf).", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnZoomInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomInOut.Click
        Me.imgBox.PicBox.Size = myImage.Size
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
        Me.imgBox.PicBox.Size = New Size(Me.imgBox.PicBox.Width * 1.2, Me.imgBox.PicBox.Height * 1.2)
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        Me.imgBox.PicBox.Size = New Size(Me.imgBox.PicBox.Width * 0.8, Me.imgBox.PicBox.Height * 0.8)
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        Me.imgBox.PicBox.Size = ResizeImage(myImage.Size)
    End Sub

    Private Sub EnableDisableZoom(ByVal blnEnable As Boolean)
        Me.btnZoomIn.Enabled = blnEnable
        Me.btnZoomInOut.Enabled = blnEnable
        Me.btnZoomOut.Enabled = blnEnable
        Me.btnAdjust.Enabled = blnEnable
    End Sub

#End Region

#Region "DO listview"

    Private Sub lvwDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDO.SelectedIndexChanged
        'If IsLoaded Then
        If Me.lvwDO.SelectedItems.Count > 0 Then
            Me.btnAssociate.Enabled = True
            Me.btnPOD.Enabled = True
            Me.BindingContext(myData1, myData1.Tables(0).ToString).Position = Me.lvwDO.SelectedIndices(0)
            LoadDescriptionInfo(Me.lvwDO.SelectedItems(0).Tag)

            '// Populate the TreeView with nodes.
            treeImg.Nodes.Clear()
            myDOStructure = database.getDOStructure(Me.lvwDO.SelectedItems(0).Tag)

            If Not (myDOStructure Is Nothing) Then
                tree.LoadTreeViewFromXmlFile(myDOStructure, treeImg)
                treeImg.ExpandAll()
            End If
        End If
        'End If
    End Sub

    Private Sub lvwDO_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwDO.DoubleClick
        If Not (lvwDO.SelectedItems Is Nothing) Then
            Select Case Me.lvwDO.SelectedItems(0).ImageIndex
                Case 0
                    tabOD.SelectedTab = Me.tabMetaInfoPreserv
                    Me.tabMetaInfoPreserv.Show()
                Case 1
                    If MsgBox(InfoMessage("DigitalObjects.Offline"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If Me.lvwDO.SelectedItems.Count > 0 Then
                            database.setActive(Me.lvwDO.SelectedItems(0).Tag, 0)
                            'MsgBox(InfoMessage("DigitalObjects.ActiveFalse"), MsgBoxStyle.Information)
                            LoadData(Me.lvwDO.SelectedIndices(0))
                        End If
                    End If
                Case 2
                    If MsgBox(InfoMessage("DigitalObjects.Online"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If Me.lvwDO.SelectedItems.Count > 0 Then
                            database.setActive(Me.lvwDO.SelectedItems(0).Tag, 1)
                            'MsgBox(InfoMessage("DigitalObjects.ActiveTrue"), MsgBoxStyle.Information)
                            LoadData(Me.lvwDO.SelectedIndices(0))
                        End If
                    End If
            End Select
        End If
    End Sub

#End Region

#Region "New DO"

    Public Sub btnNewDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDO.Click
        Dim myProgramState As New ProgramState
        tabOD.SelectedTab = Me.tabMetaInfoTec
        Me.tabMetaInfoTec.Show()

        ClearFields()
        NewDO()
        EnableEdition()
        Me.btnEditDO.Tag = "New"

        Try
            Me.txtArchiveID.Text = myProgramState.LastArchiveID
            Me.txtTopographicalQuota.Text = myProgramState.LastTopographicalQuota
            Me.txtResponsabilityEntity.Text = myProgramState.LastResponsabilityEntity
            Me.txtCaptureEntityCorporate.Text = myProgramState.LastCaptureEntityCorporate
        Catch ex As Exception
        End Try
    End Sub

    Private Sub NewDO()
        Dim myDate As Date = Now
        Dim numOD, intProjectLength As Integer

        intProjectLength = myProjectName.Length
        Dim lastDO As String = database.LastDO(myProjectName)

        If lastDO = "" Then
            numOD = 1
        Else
            numOD = CType(lastDO.Remove(0, intProjectLength + 2), Integer) + 1
        End If

        Me.lblName.Text = myProjectName & "OD" & numOD
        Me.lblIP.Text = Constants.UserLogon
        Me.txtCreationDateTime.Text = DateToDB(myDate)
        Me.txtArchiveDateTime.Text = DateToDB(myDate)
        Me.lblNumImg.Text = 0
        Me.ckbActive.Checked = True
        txtResponsabilityEntity.AppendText(CType(configReader.GetValue("ResponsabilityEntity", GetType(System.String)), String))
        txtCaptureEntityCorporate.AppendText(CType(configReader.GetValue("CaptureEntityCorporate", GetType(System.String)), String))
    End Sub



    Private Sub disableControls()

    End Sub

    Private Sub enableControls()

    End Sub

#End Region

#Region "Find"

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim FindDOForm As New FindDOForm(myProjectID)
        FindDOForm.ShowDialog(Me)
    End Sub

#End Region

#Region "POD"

    Private Sub btnPOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOD.Click
        Dim PODForm As New MPOD.AssociationForm(Constants.UserLogon, myProjectID, myProjectName, Me.lvwDO.SelectedItems(0).Tag)
        PODForm.Show()
    End Sub

#End Region

#Region "Associate new files"

    Private Sub btnAssociate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssociate.Click
        Dim AddImageForm As New AddImageForm(myProjectID, Me.lvwDO.SelectedItems(0).Tag)
        Dim Username As String

        If lvwDO.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Int64 = Me.lvwDO.SelectedIndices(0)
            Dim myDP As DigitalizationProfileCollection = database.SelectDigitalizationProfiles
            If myDP.Count > 0 Then
                AddImageForm.ShowDialog(Me)
            Else
                MsgBox(InfoMessage("DigitalObjects.EmptyDigitalizationProfiles"), MsgBoxStyle.Exclamation)
                Dim DigitalalizationProfilesForm As New DigitalizationProfilesForm
                DigitalalizationProfilesForm.ShowDialog(Me)
            End If
            If AddImageForm.AssocitedFile Then
                LoadData(intSelectedIndex)
            End If
        End If
    End Sub

#End Region

#Region "Recover DO"

    Private Sub btnRecover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvwDO.SelectedItems.Count < 1 Then
            MsgBox("Não existe um Item seleccionado", MsgBoxStyle.Exclamation)
        Else
            If fileChooser.ShowDialog() = DialogResult.OK Then
                Dim strPath As String = fileChooser.SelectedPath.ToString
            End If
        End If

        'Try
        '    If lvwDO.SelectedItems.Count < 1 Then
        '        MsgBox("Não existe um Item seleccionado", MsgBoxStyle.Exclamation)
        '    Else
        '        'Dim index As Integer = lstDO.SelectedNode.Index
        '        Dim handle As String = Me.lvwDO.SelectedItems(0).Text
        '        Dim SoundDeviceQuery As New SelectQuery("Win32_CDROMDrive")
        '        Dim SoundDeviceSearch As New ManagementObjectSearcher("SELECT * FROM Win32_CDROMDrive")

        '        Dim SoundDeviceInfo As ManagementBaseObject
        '        Dim IdDigitalObject As Integer = Me.lvwDO.SelectedItems(0).Tag
        '        Dim NamePath As String
        '        Dim CD, RevisionInterval As Integer
        '        Dim RevisionDateTime As Date

        '        For Each SoundDeviceInfo In SoundDeviceSearch.Get()
        '            MsgBox(InfoMessage("DigitalObjects.LoadCD"), MsgBoxStyle.Information, InfoMessage("DigitalObjects.LoadingCD"))
        '            Dim SizeInBytes As Long = Val(SoundDeviceInfo("Size").ToString())
        '            Dim SizeInKB As Double = Int(SizeInBytes / 1024)
        '            Dim sizeOD As Double = database.getDOSize(IdDigitalObject)
        '            Dim NumCD As Double = Math.Ceiling(sizeOD / SizeInKB)   '//Nº de CDs que contêm o OD

        '            If NumCD > 0 Then
        '                For CD = 1 To NumCD
        '                    LoadFromCD(CD, IdDigitalObject, handle, SoundDeviceInfo)
        '                    If CD < NumCD Then
        '                        MsgBox(InfoMessage("DigitalObjects.NextCD"), MsgBoxStyle.Information, InfoMessage("DigitalObjects.LoadingCD"))
        '                    End If
        '                Next CD
        '            Else
        '                LoadFromCD(NumCD, IdDigitalObject, handle, SoundDeviceInfo)
        '                Exit For
        '            End If

        '            RevisionInterval = database.getRevisionInterval()
        '            RevisionDateTime = CDate(database.getRevisionDateTimeDO(IdDigitalObject))
        '            If RevisionDateTime <= Now.ToShortDateString Then
        '                database.UpdateRevisionDateTimeDO(IdDigitalObject, RevisionDateTime.AddYears(RevisionInterval))
        '                MsgBox(InfoMessage("DigitalObjects.RevisionDateTime") & RevisionDateTime.AddYears(RevisionInterval))
        '            End If
        '        Next

        '        MsgBox(InfoMessage("DigitalObjects.AllImagesRecovered"), MsgBoxStyle.Information)
        '    End If
        'Catch ex As Exception
        '    MessageBoxes.MsgBoxException(ex)
        'End Try
    End Sub

    Sub LoadFromCD(ByVal num As Integer, ByVal IdDigitalObject As Integer, ByVal DOName As String, ByVal SoundDeviceInfo As ManagementObject)
        Dim pBar1 As New ProgressBarForm
        Dim directory, directory_D, project, username As String
        Dim count, NumDirectories As Integer
        Dim img As System.Drawing.Image
        Dim files() As String
        Dim fs As Directory
        Dim content As String() = fs.GetFileSystemEntries(SoundDeviceInfo("drive").ToString())
        Dim imageProcess As New MyImageProcessing

        NumDirectories = content.Length
        count = 0

        For Each str As String In content
            Dim DObject As String = str.Substring(2)
            If DObject.CompareTo(DOName) = 0 Then
                Dim pathFile As String = str & "\"

                files = fs.GetFiles(pathFile)
                pBar1.Show()
                ' Display the ProgressBar control.
                pBar1.ProgressBar1.Visible = True
                ' Set Minimum to 1 to represent the first file being copied.
                pBar1.ProgressBar1.Minimum = 1
                ' Set Maximum to the total number of files to copy.
                pBar1.ProgressBar1.Maximum = files.Length
                ' Set the initial value of the ProgressBar.
                pBar1.ProgressBar1.Value = 1
                ' Set the Step property to a value of 1 to represent each file being copied.
                pBar1.ProgressBar1.Step = 1
                pBar1.Text = InfoMessage("DigitalObjects.Recovering") & DOName & "..."

                For Each file As String In files

                    If file.EndsWith("tif") = True Then
                        Try
                            '//save image in file system
                            Dim fileName As String = Path.GetFileName(file)
                            img = img.FromFile(file)

                            pBar1.lblNameImage.Text = fileName

                            Dim idImage As Integer = database.getFileID(IdDigitalObject, fileName)
                            Dim profileID As Integer = database.getProfileID(IdDigitalObject, fileName)
                            Dim IdProject As Integer = database.getProjectID(IdDigitalObject)
                            Dim checkSumDB As String = database.getCheckSumValue(IdDigitalObject, fileName)
                            Dim checkSumCD As String = database.generateHash(file)

                            If Not checkSumDB.Equals(checkSumCD) Then
                                MsgBox(InfoMessage("DigitalObjects.Image") & fileName & " (" & DOName & ")" & _
                                InfoMessage("DigitalObjects.Corrupted") & ControlChars.NewLine & _
                                InfoMessage("DigitalObjects.Recover"), MsgBoxStyle.Exclamation)

                                'Dim derivative As String = imageProcess.generateDerivative(file, DOName, idImage, IdProject)
                                'Dim derivative As String = imageProcess.GeneDerivative(file, DOName, idImage, IdProject, 10)
                                'database.setImage(file, IdDigitalObject, idImage)
                                database.UpdateCheckSumDOFile(idImage, checkSumCD)

                                Log.Append(Constants.UserLogon, Log.EditNode, "New derivative " & file & " generated at revision time of digital object" & DOName & "!")
                            End If

                            '//Perform the increment on the ProgressBar.
                            pBar1.ProgressBar1.PerformStep()
                            'garbage collection cleans all variables
                            GC.Collect()
                        Catch ex As Exception
                            MessageBoxes.MsgBoxException(ex)
                        End Try
                    End If
                Next
            Else
                count = count + 1
            End If
            pBar1.Close()
        Next
        If count = NumDirectories Then
            MsgBox(InfoMessage("DigitalObjects.InvalidCD"), MsgBoxStyle.Critical, _
            InfoMessage("DigitalObjects.LoadingCD"))
            Exit Sub
        End If
    End Sub

    'Sub LoadDO(ByVal DigitalObjectID As Integer, ByVal DOName As String)
    '    Dim pBar1 As New ProgressBarForm
    '    Dim directory, directory_D, project, username As String
    '    Dim count, NumDirectories As Integer
    '    Dim img As LEAD.Drawing.Image
    '    Dim files() As String
    '    Dim fs As Directory
    '    Dim content As String() = fs.GetFileSystemEntries(SoundDeviceInfo("drive").ToString())
    '    Dim imageProcess As New MyImageProcessing

    '    NumDirectories = content.Length
    '    count = 0

    '    For Each str As String In content
    '        Dim DObject As String = str.Substring(2)
    '        If DObject.CompareTo(DOName) = 0 Then
    '            Dim pathFile As String = str & "\"

    '            files = fs.GetFiles(pathFile)
    '            pBar1.Show()
    '            ' Display the ProgressBar control.
    '            pBar1.ProgressBar1.Visible = True
    '            ' Set Minimum to 1 to represent the first file being copied.
    '            pBar1.ProgressBar1.Minimum = 1
    '            ' Set Maximum to the total number of files to copy.
    '            pBar1.ProgressBar1.Maximum = files.Length
    '            ' Set the initial value of the ProgressBar.
    '            pBar1.ProgressBar1.Value = 1
    '            ' Set the Step property to a value of 1 to represent each file being copied.
    '            pBar1.ProgressBar1.Step = 1
    '            pBar1.Text = InfoMessage("DigitalObjects.Recovering") & DOName & "..."

    '            For Each file As String In files

    '                If file.EndsWith("tif") = True Then
    '                    Try
    '                        '//save image in file system
    '                        Dim fileName As String = Path.GetFileName(file)
    '                        img = img.FromFile(file)

    '                        pBar1.lblNameImage.Text = fileName

    '                        Dim idImage As Integer = database.getIdFile(IdDigitalObject, fileName)
    '                        Dim profileID As Integer = database.getIdProfile(IdDigitalObject, fileName)
    '                        Dim IdProject As Integer = database.getIdProject(IdDigitalObject)
    '                        Dim checkSumDB As String = database.getCheckSumValue(IdDigitalObject, fileName)
    '                        Dim checkSumCD As String = database.generateHash(file)

    '                        If Not checkSumDB.Equals(checkSumCD) Then
    '                            MsgBox(InfoMessage("DigitalObjects.Image") & fileName & " (" & DOName & ")" & _
    '                            InfoMessage("DigitalObjects.Corrupted") & ControlChars.NewLine & _
    '                            InfoMessage("DigitalObjects.Recover"), MsgBoxStyle.Exclamation)

    '                            'Dim derivative As String = imageProcess.generateDerivative(file, DOName, idImage, IdProject)
    '                            Dim derivative As String = imageProcess.GeneDerivative(file, DOName, idImage, IdProject, 10)
    '                            database.setImage(file, IdDigitalObject, idImage)
    '                            database.UpdateCheckSumDOFile(idImage, checkSumCD)

    '                            Log.Append(Constants.UserLogon, Log.EditNode, "New derivative " & file & " generated at revision time of digital object" & DOName & "!")
    '                        End If

    '                        '//Perform the increment on the ProgressBar.
    '                        pBar1.ProgressBar1.PerformStep()
    '                        'garbage collection cleans all variables
    '                        GC.Collect()
    '                    Catch ex As Exception
    '                        MessageBoxes.MsgBoxException(ex)
    '                    End Try
    '                End If
    '            Next
    '        Else
    '            count = count + 1
    '        End If
    '        pBar1.Close()
    '    Next
    '    If count = NumDirectories Then
    '        MsgBox(InfoMessage("DigitalObjects.InvalidCD"), MsgBoxStyle.Critical, _
    '        InfoMessage("DigitalObjects.LoadingCD"))
    '        Exit Sub
    '    End If
    'End Sub

#End Region

#Region "Structure"

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    '// NOTE: frmNewNode will update the UI state variables.
    '    Dim fAddNode As New AddNodeForm

    '    If treeImg.SelectedNode Is Nothing Then
    '        nodeSelected = treeImg.Nodes(0)
    '    Else
    '        nodeSelected = treeImg.SelectedNode
    '    End If

    '    ' este teste é para permitir adicionar nodos apenas a directorias
    '    If nodeSelected.Tag Is Nothing Then
    '        If treeImg.GetNodeCount(True) > 0 Then
    '            fAddNode.ShowDialog(Me)
    '        End If
    '    Else
    '        MsgBox(InfoMessage("DigitalObjects.InvalidNode"), MsgBoxStyle.Information)
    '    End If

    '    '// Update the UI State.
    '    SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty)
    'End Sub

    'Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    Dim node As XmlNode
    '    Dim xml_doc As New XmlDocument
    '    Dim tn As TreeNode
    '    Dim Username As String

    '    '// is one node selected and isn't the root
    '    If Not (treeImg.SelectedNode Is Nothing) Then

    '        myDOStructure = database.getDOStructure(Me.lvwDO.SelectedItems(0).Tag)
    '        xml_doc.LoadXml(myDOStructure)

    '        If Me.treeImg.SelectedNode.ImageIndex = 3 Then
    '            node = xml_doc.SelectSingleNode(String.Format("//treenode[@id=""_{0}""]", _
    '                   Me.treeImg.SelectedNode.Tag))
    '        ElseIf Me.treeImg.SelectedNode.ImageIndex = 1 Or Me.treeImg.SelectedNode.ImageIndex = 2 Then
    '            node = xml_doc.SelectSingleNode(String.Format("//treenode[@id=""_{0}""]", _
    '                    Me.treeImg.SelectedNode.Tag))
    '            '// is directory
    '        Else
    '            '// none children
    '            If treeImg.SelectedNode.GetNodeCount(True) = 0 Then
    '                node = xml_doc.SelectSingleNode(String.Format("TREENODES/treenode[@Type=""directory"" and @Text=""{0}""]", Me.lvwDO.SelectedItems(0).Text))
    '            Else
    '                MsgBox(InfoMessage("DigitalObjects.DeleteDirectory"), MsgBoxStyle.Information)
    '            End If
    '        End If

    '        If MsgBox(InfoMessage("DigitalObjects.DeleteFile") & Me.lvwDO.SelectedItems(0).Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

    '            If Not node Is Nothing Then
    '                '// is directory
    '                If node.Attributes.Count = 1 Then
    '                    treeImg.Nodes.Remove(treeImg.SelectedNode)
    '                    '// is a file
    '                Else
    '                    If database.DeleteFile(CInt(node.Attributes("id").Value.TrimStart("_"))) Then
    '                        database.setQuantityOfTerminalObjects(Me.lvwDO.SelectedItems(0).Tag)

    '                        MsgBox(InfoMessage("DigitalObjects.DeletedFile"), MsgBoxStyle.Information)
    '                        treeImg.Nodes.Remove(treeImg.SelectedNode)

    '                        Log.Append(Constants.UserLogon, Log.EditNode, "File " & treeImg.SelectedNode.Text & " was deleted!")
    '                    End If
    '                End If

    '                If treeImg.GetNodeCount(False) > 0 Then
    '                    tn = treeImg.Nodes(0)
    '                End If

    '                tree.SaveNodeCollection(Me.lvwDO.SelectedItems(0).Tag, tn)
    '                '// Update the UI.
    '                g_bState_NodesDirty = False
    '                SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty)
    '            Else
    '                MsgBox(InfoMessage("DigitalObjects.NoneSelected"), MsgBoxStyle.Exclamation)
    '            End If
    '        End If

    '    End If
    'End Sub

    'Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
    '    Dim iRet As Integer
    '    Dim sRet, Username As String
    '    Dim tn As TreeNode

    '    Try
    '        If Not (treeImg.SelectedNode Is Nothing) Then

    '            If (treeImg.SelectedNode.Parent Is Nothing) Then ' is the root
    '                MsgBox("Não é possível alterar o nome da raiz!", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If

    '            tn = treeImg.SelectedNode
    '            sRet = InputBox("Introduza o novo nome:", "Nome", tn.Text)
    '            sRet = Trim(sRet)
    '            If sRet <> "" Then
    '                If Len(sRet) > 50 Then
    '                    iRet = MsgBox("Tamanho máximo: " & vbCrLf & _
    '                                  "50 caracteres?", _
    '                                  MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or _
    '                                  MsgBoxStyle.Question)
    '                    If iRet = vbYes Then
    '                        sRet = sRet.Substring(0, 50)
    '                        tn.Text = sRet
    '                        g_bState_NodesDirty = True
    '                        SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, _
    '                            g_bState_NodesDirty)
    '                    Else
    '                        MsgBox("O nome do nodo não será mudado.", _
    '                            MsgBoxStyle.Exclamation)
    '                    End If
    '                Else
    '                    g_bState_NodesDirty = True
    '                    SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty)
    '                    If Not database.UpdateNameDOFile(Me.lvwDO.SelectedItems(0).Tag, tn.Text, sRet) Then
    '                        MsgBox(InfoMessage("DigitalObjects.InvalidName"), MsgBoxStyle.Exclamation)
    '                    Else
    '                        Log.Append(Constants.UserLogon, Log.EditNode, "Name of node " & tn.Text & " was changed to " & sRet & ".")
    '                        tn.Text = sRet
    '                    End If
    '                End If
    '            Else
    '                MsgBox(InfoMessage("DigitalObjects.EmptyNode"), MsgBoxStyle.OKOnly Or _
    '                    MsgBoxStyle.Exclamation)
    '            End If
    '        Else
    '            MsgBox(InfoMessage("DigitalObjects.RenomeNode"), MsgBoxStyle.OKOnly Or _
    '                MsgBoxStyle.Information)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Dim tn As TreeNode

    '    If treeImg.GetNodeCount(False) > 0 Then
    '        tn = treeImg.Nodes(0)
    '    End If

    '    'Constants.IdDigitalObject = lstDO.SelectedNode.Tag
    '    tree.SaveNodeCollection(Me.lvwDO.SelectedItems(0).Tag, tn)
    '    Log.Append(Constants.UserLogon, Log.EditNode, "Saved structure of digital object " & Me.lvwDO.SelectedItems(0).Text & "!")
    '    '// Update the UI.
    '    g_bState_NodesDirty = False
    '    SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty)
    'End Sub

    'Public Sub SetUIState(ByVal bNodesPresent As Boolean, _
    '                  ByVal bNodeSelected As Boolean, _
    '                  ByVal bNodesDirty As Boolean)

    '    If bNodesPresent = True Then
    '        If bNodeSelected = True Then
    '            btnAdd.Enabled = True
    '            btnDelete.Enabled = True
    '            btnRename.Enabled = True
    '            'btnEditDP.Enabled = True
    '            'btnEditLT.Enabled = True
    '            'btnEditTP.Enabled = True
    '        Else
    '            btnAdd.Enabled = False
    '            btnDelete.Enabled = False
    '            btnRename.Enabled = False
    '            'btnEditDP.Enabled = False
    '            'btnEditLT.Enabled = False
    '            'btnEditTP.Enabled = False
    '        End If
    '        If bNodesDirty = True Then
    '            btnSave.Enabled = True
    '        Else
    '            btnSave.Enabled = False
    '        End If
    '    Else
    '        btnAdd.Enabled = True
    '        btnDelete.Enabled = False
    '        btnRename.Enabled = False
    '        'btnEditDP.Enabled = False
    '        'btnEditLT.Enabled = False
    '        'btnEditTP.Enabled = False

    '        If bNodesDirty = True Then
    '            btnSave.Enabled = True
    '        Else
    '            btnSave.Enabled = False
    '        End If
    '    End If
    'End Sub

    Private Sub LoadTreeView()

        '// Populate the TreeView with nodes.
        treeImg.Nodes.Clear()
        tree.LoadTreeViewFromXmlFile(myDOStructure, treeImg)
        treeImg.ExpandAll()
        treeImg.Nodes(0).EnsureVisible()

    End Sub






#End Region

#Region "Image metadata"

    'Private Sub btnEditLT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim form As New LampTypeForm
    '    Dim res As Boolean

    '    'form.btnChoose.Enabled = True
    '    form.LampTypeValue = Me.lblLampType.Tag
    '    form.ShowDialog(Me)

    '    If form.Choose Then
    '        res = database.UpdateLTDOFile(Me.lvwDO.SelectedItems(0).Tag, treeImg.SelectedNode.Text, form.LampTypeValue)

    '        If res Then
    '            LoadData()
    '            Me.lblLampType.Text = form.LampTypeText
    '            MsgBox(InfoMessage("DigitalObjects.LTChange"), MsgBoxStyle.Information)
    '        End If
    '    End If
    'End Sub

    'Private Sub btnEditDP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim DPForm As New DigitalizationProfilesForm
    '    Dim res As Boolean

    '    DPForm.btnChoose.Enabled = True
    '    DPForm.strDigitalizationProfileValue = Me.lblProfile.Tag
    '    DPForm.ShowDialog()

    '    If DPForm.choose Then
    '        res = database.UpdateDPDOFile(Me.lvwDO.SelectedItems(0).Tag, treeImg.SelectedNode.Text, DPForm.strDigitalizationProfileValue)
    '        If res Then
    '            Me.lblProfile.Tag = DPForm.strDigitalizationProfileValue
    '            Me.lblProfile.Text = DPForm.strDigitalizationProfileText
    '            LoadData()
    '            MsgBox(InfoMessage("DigitalObjects.DPChange"), MsgBoxStyle.Information)
    '        End If
    '    End If
    'End Sub

    'Private Sub btnEditTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim TPForm As New TechnologicalPlataformForm
    '    Dim res As Boolean

    '    TPForm.btnChoose.Enabled = True
    '    TPForm.strTecnologicalPlataformValue = Me.lblTPlatform.Tag
    '    TPForm.ShowDialog(Me)

    '    If TPForm.Choose Then
    '        res = database.UpdateTPDOFile(Me.lvwDO.SelectedItems(0).Tag, treeImg.SelectedNode.Text, TPForm.strTecnologicalPlataformValue)
    '        If res Then
    '            Me.lblTPlatform.Tag = TPForm.strTecnologicalPlataformValue
    '            Me.lblTPlatform.Text = TPForm.strTecnologicalPlataformText
    '            LoadData()
    '            MsgBox(InfoMessage("DigitalObjects.TPChange"), MsgBoxStyle.Information)
    '        End If
    '    End If
    'End Sub

#End Region

#End Region

#Region "Technical metadata"

#Region "New/Edit/Save"

    Private Sub btnEditOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDO.Click
        Dim Success As Boolean
        If btnEditDO.Text.Equals(configReader.GetValue("btnEdit.Text", GetType(String))) Then
            EnableEdition()
            Me.btnEditDO.Tag = "Update"

        ElseIf btnEditDO.Text.Equals(configReader.GetValue("btnSave.Text", GetType(String))) Then
            Select Case Me.btnEditDO.Tag
                Case "New"
                    Success = SaveNew()
                Case "Update"
                    Success = SaveChanges()
            End Select
            If Success Then
                tabOD.SelectedTab = Me.tabMetaInfoStruct
                Me.tabMetaInfoStruct.Show()
            End If
        End If
    End Sub

    Private Function SaveNew() As Boolean
        Dim myRevisionDate As String
        Dim myProgramState As New ProgramState

        Try
            If txtArchiveDateTime.Text.Length <> 0 And Not IsDate(txtArchiveDateTime.Text) Then
                txtArchiveDateTime.Text = DateToDB(Now)
                Return False
            End If
            If txtDepositDateTime.Text.Length <> 0 And Not IsDate(txtDepositDateTime.Text) Then
                txtDepositDateTime.Text = ""
                Return False
            End If

            If txtArchiveDateTime.Text.Length = 0 Then
                MsgBox(InfoMessage("DigitalObjects.MissingArchiveDateTime"), MsgBoxStyle.Exclamation)
                txtArchiveDateTime.Focus()
                Return False
            ElseIf CDate(txtCreationDateTime.Text) > CDate(txtArchiveDateTime.Text) Then
                MsgBox(InfoMessage("DigitalObjects.WrongCreationDate"), MsgBoxStyle.OKOnly)
                Return False
            ElseIf txtDepositDateTime.Text.Length <> 0 Then
                If CDate(txtCreationDateTime.Text) > CDate(txtDepositDateTime.Text) Then
                    MsgBox(InfoMessage("DigitalObjects.WrongDepositDate"), MsgBoxStyle.OKOnly)
                    Return False
                End If
            End If

            Dim myRevisionValue As Integer = database.getIdRevisionInterval()
            myRevisionDate = CDate(txtCreationDateTime.Text).AddYears(myRevisionValue)

            myDOStructure = "<TREENODES><treenode Text=""" & Me.lblName.Text & """ Type=""" & "directory" & """></treenode></TREENODES>"

            database.InsertDigitalObject(myProjectID, Me.lblName.Text, Me.txtOriginalName.Text, Me.txtArchiveID.Text, _
                   Me.txtArchivingProfile.Text, Me.txtCaptureEntityCorporate.Text, Me.txtResponsabilityEntity.Text, _
                   Me.txtCreationDateTime.Text, Me.txtArchiveDateTime.Text, Me.txtDepositDateTime.Text, _
                   DateToDB(myRevisionDate), Me.txtExternalDescriptiveInfo.Text, Me.txtPreservationOriginalInformation.Text, 0, _
                   Me.txtTopographicalQuota.Text, myDOStructure, Constants.UserLogon, BoolToDB(Me.ckbActive.Checked))

            Log.Append(Constants.UserLogon, Log.AppendNode, "New digital object (" & lblName.Text & ") was created!")

            myDigitalObjectID = database.LastDO

            myProgramState.LastArchiveID = Me.txtArchiveID.Text
            myProgramState.LastTopographicalQuota = Me.txtTopographicalQuota.Text
            myProgramState.LastResponsabilityEntity = Me.txtResponsabilityEntity.Text
            myProgramState.LastCaptureEntityCorporate = Me.txtCaptureEntityCorporate.Text
            myProgramState.Save()

            DisableEdition()
            btnAssociate.Enabled = True
            LoadData(0)
            Return True
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Function

    Private Function SaveChanges() As Boolean
        Dim myProgramState As New ProgramState
        Dim intDigitalObjectID As Int64 = Me.lvwDO.SelectedItems(0).Tag

        If txtArchiveDateTime.Text.Length <> 0 And Not IsDate(txtArchiveDateTime.Text) Then
            txtArchiveDateTime.Text = DateToDB(Now)
            Return False
        End If
        If txtDepositDateTime.Text.Length <> 0 And Not IsDate(txtDepositDateTime.Text) Then
            txtDepositDateTime.Text = ""
            Return False
        End If

        If txtArchiveDateTime.Text.Length = 0 Then
            MsgBox(InfoMessage("DigitalObjects.MissingArchiveDateTime"), MsgBoxStyle.Exclamation)
            txtArchiveDateTime.Focus()
            Return False
        ElseIf CDate(txtCreationDateTime.Text) > CDate(txtArchiveDateTime.Text) Then
            MsgBox(InfoMessage("DigitalObjects.WrongCreationDate"), MsgBoxStyle.OKOnly)
            Return False
        ElseIf txtDepositDateTime.Text.Length <> 0 Then
            If CDate(txtCreationDateTime.Text) > CDate(txtDepositDateTime.Text) Then
                MsgBox(InfoMessage("DigitalObjects.WrongDepositDate"), MsgBoxStyle.OKOnly)
                Return False
            End If
        End If
        Try

            database.UpdateDigitalObject(intDigitalObjectID, Me.txtOriginalName.Text, Me.txtArchiveID.Text, _
                    Me.txtArchivingProfile.Text, Me.txtCaptureEntityCorporate.Text, Me.txtResponsabilityEntity.Text, _
                    Me.txtArchiveDateTime.Text, Me.txtDepositDateTime.Text, Me.txtExternalDescriptiveInfo.Text, _
                    Me.txtPreservationOriginalInformation.Text, Me.txtTopographicalQuota.Text, BoolToDB(Me.ckbActive.Checked))

            Log.Append(Constants.UserLogon, Log.EditNode, "Digital object " & Me.lvwDO.SelectedItems(0).Text & " was edited!")

            myProgramState.LastArchiveID = Me.txtArchiveID.Text
            myProgramState.LastResponsabilityEntity = Me.txtResponsabilityEntity.Text
            myProgramState.LastCaptureEntityCorporate = Me.txtCaptureEntityCorporate.Text
            myProgramState.LastTopographicalQuota = Me.txtTopographicalQuota.Text
            myProgramState.Save()

            DisableEdition()
            LoadData(Me.lvwDO.SelectedIndices(0))
            Return True
        Catch ex As Exception
            MessageBoxes.MsgBoxSqlException(ex)
        End Try
    End Function

#End Region

#Region "Cancel"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisableEdition()
        Me.btnEditDO.Tag = "Update"
        LoadData()
    End Sub

    Private Sub Cancel()


        'lbxDO.Enabled = True
        'btnCancel.Enabled = False
        'btnEditDO.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        'If newOD Then
        '    ClearFields()
        '    txtArchiveID.Clear()
        '    enableControls()
        'End If
        ''SendToBackGeral()
        'DisableEdition()
        'lblName.Text = nome
        'newOD = False
    End Sub

#End Region

#Region "Remove of line"

    Private Sub btnRemoveDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox(InfoMessage("DigitalObjects.Offline"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If database.setActive(Me.lvwDO.SelectedItems(0).Tag, 0) Then
                MsgBox(InfoMessage("DigitalObjects.ActiveFalse"), MsgBoxStyle.Information)
                Log.Append(Constants.UserLogon, Log.RemoveNode, "State of digital object " & Me.lvwDO.SelectedItems(0).Tag & " was changed to inactive!")
                LoadData()
            End If
        End If
    End Sub

#End Region

#Region "Delete"

    Private Sub btnEliminarOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDO.Click
        If Not Me.lvwDO.SelectedItems(0) Is Nothing Then
            '// it's allowed to delete a digital object if there is no files associated
            'If lblNumImg.Text.ToString.Equals("0") Then
            If MsgBox(InfoMessage("DigitalObjects.DeleteOD"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If database.DeleteDigitalObjects(Me.lvwDO.SelectedItems(0).Tag) Then
                    Log.Append(Constants.UserLogon, Log.RemoveNode, "Digital object " & Me.lvwDO.SelectedItems(0).Text & " was deleted from database!")
                    'MsgBox(InfoMessage("DigitalObjects.DeletedOD"), MsgBoxStyle.Information)
                    LoadData()
                End If
            End If
            'Else
            '    MsgBox(InfoMessage("DigitalObjects.ImpossibleDelete"), MsgBoxStyle.Exclamation)
            'End If
        End If
    End Sub

    Private Sub btnDeleteDerivatives_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDerivatives.Click
        If Not Me.lvwDO.SelectedItems(0) Is Nothing Then
            If MsgBox(InfoMessage("DigitalObjects.DeleteDerivatives"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If database.DeleteDerivatives(Me.lvwDO.SelectedItems(0).Tag) Then
                    Log.Append(Constants.UserLogon, Log.EditNode, "Derivatives of digital object " & Me.lvwDO.SelectedItems(0).Text & " was deleted from database!")
                    'MsgBox(InfoMessage("DigitalObjects.DeletedDerivatives"), MsgBoxStyle.Information)
                    LoadData()
                End If
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Preservation metadata"

    Private Sub btnChooseReformattingMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseReformattingMethod.Click
        Dim ReformattingMethodForm As New ReformattingMethodsForm
        ReformattingMethodForm.ShowDialog(Me)
    End Sub

    Private Sub btnChooseReformattingNorms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseReformattingNorms.Click
        Dim ReformattingNormsForm As New ReformattingNormsForm
        ReformattingNormsForm.ShowDialog(Me)
    End Sub

    Private Sub btnSavePreservationInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePreservationInfo.Click
        Dim i As Integer
        Dim altNorms As New ArrayList

        Dim myRevisionValue As Integer = database.getIdRevisionInterval()
        Dim strRevisionNextDateTime As String = DateToDB(Now.AddYears(myRevisionValue))

        For i = 0 To Me.lbxReformattingNormsChoosen.Items.Count - 1
            Me.lbxReformattingNormsChoosen.SelectedIndex = i
            altNorms.Add(Me.lbxReformattingNormsChoosen.SelectedValue)
            Me.lbxReformattingNormsChoosen.SetSelected(i, False)
        Next
        Dim ret1 As Integer = database.InsertPrervationAction(strRevisionNextDateTime, DateToDB(Now), _
        Me.txtTransformer.Text, Me.txtPlatform.Text, Me.txtRenderEngine.Text, Me.txtInputFormat.Text, _
        Me.txtParameters.Text, Me.txtReformattingMethod.Tag, Me.lvwDO.SelectedItems(0).Tag, altNorms)
        Dim ret2 As Boolean = database.setRevisionDateTime(Me.lvwDO.SelectedItems(0).Tag, strRevisionNextDateTime)
        If ret1 And ret2 Then
            ClearPreservationInfo()
            Log.Append(Constants.UserLogon, Log.AppendNode, "New Preservation Action was associated to DO " & Me.lvwDO.SelectedItems(0).Text & ".")
            MsgBox(InfoMessage("PreservationAction.NewValue") & vbNewLine & "Próxima data de revisão: " & strRevisionNextDateTime, MsgBoxStyle.Information, InfoMessage("PreservationAction.Title"))
        End If
    End Sub

    Private Sub btnHistorical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorical.Click
        Dim HistoricalPreservationForm As New HistoricalPreservationForm(Me.lvwDO.SelectedItems(0).Tag)
        HistoricalPreservationForm.ShowDialog(Me)
    End Sub

#End Region



#Region "Clear Fields"

    Private Sub ClearFields()
        Me.lblName.Text = ""
        Me.lblOriginalName.Text = ""
        Me.tvwDescriptionInfo.Nodes.Clear()
        Me.txtArchiveID.Text = ""
        Me.txtTopographicalQuota.Text = ""
        Me.txtCreationDateTime.Text = ""
        Me.txtArchiveDateTime.Text = ""
        Me.txtDepositDateTime.Text = ""
        Me.lblRevisionDateTime.Text = ""
        Me.lblNumImg.Text = ""
        Me.txtCaptureEntityCorporate.Text = ""
        Me.txtResponsabilityEntity.Text = ""
        Me.txtPreservationOriginalInformation.Text = ""
        Me.txtExternalDescriptiveInfo.Text = ""
        Me.txtArchivingProfile.Text = ""
    End Sub

    Private Sub ClearAll()
        Me.lvwDO.Items.Clear()

        Me.ckbActive.DataBindings.Clear()

        Me.lblNumImg.DataBindings.Clear()

        Me.lblName.DataBindings.Clear()

        Me.lblOriginalName.DataBindings.Clear()

        Me.txtArchiveID.DataBindings.Clear()
        Me.lblArchiveID.DataBindings.Clear()

        Me.txtTopographicalQuota.DataBindings.Clear()
        Me.lblTopographicalQuota.DataBindings.Clear()

        Me.lblIP.DataBindings.Clear()

        Me.txtCreationDateTime.DataBindings.Clear()
        Me.lblCreationDateTime.DataBindings.Clear()

        Me.txtArchiveDateTime.DataBindings.Clear()
        Me.lblArchiveDateTime.DataBindings.Clear()

        Me.txtDepositDateTime.DataBindings.Clear()
        Me.lblDepositDateTime.DataBindings.Clear()

        Me.lblRevisionDateTime.DataBindings.Clear()

        Me.lblNumImg.DataBindings.Clear()

        Me.txtCaptureEntityCorporate.DataBindings.Clear()
        Me.lblCaptureEntityCorporate.DataBindings.Clear()

        Me.txtResponsabilityEntity.DataBindings.Clear()
        Me.lblResponsabilityEntity.DataBindings.Clear()

        Me.txtPreservationOriginalInformation.DataBindings.Clear()
        Me.lblPreservationOriginalInformation.DataBindings.Clear()

        Me.txtExternalDescriptiveInfo.DataBindings.Clear()
        Me.lblExternalDescriptiveInfo.DataBindings.Clear()

        Me.txtArchivingProfile.DataBindings.Clear()
        Me.lblArchivingProfile.DataBindings.Clear()
    End Sub

    Private Sub ClearMetadataImage()
        Me.imgBox.Image = Nothing

        Me.lblSize.Text = ""
        Me.lblResolution.Text = ""
        Me.tBxColor.Text = ""
        Me.lblBitDepth.Text = ""
        Me.lblHeight.Text = ""
        Me.lblWidth.Text = ""
        Me.lblMimeType.Text = ""
        Me.lblCompression.Text = ""
        Me.lblLampType.Text = ""
        Me.lblProfile.Text = ""
        Me.lblTPlatform.Text = ""
        Me.lblFNumber.Text = ""
        Me.lblExposureTime.Text = ""
        Me.lblMeteringMode.Text = ""
        Me.lblFocalLength.Text = ""
        Me.lblAutoFocus.Text = ""

        Me.lblProcessingDateTime.Text = ""
        Me.lblProcessingActions.Text = ""
        Me.lblProcessingSoftwareName.Text = ""
        Me.lblProcessingSoftwareVersion.Text = ""
        Me.lblProcessingOSName.Text = ""
        Me.lblProcessingOSVersion.Text = ""
        Me.lblColorManager.Text = ""
    End Sub

    Private Sub ClearPreservationInfo()
        Me.txtTransformer.Text = ""
        Me.txtPlatform.Text = ""
        Me.txtRenderEngine.Text = ""
        Me.txtInputFormat.Text = ""
        Me.txtParameters.Text = ""
        Me.txtReformattingMethod.Text = ""
        Me.lbxReformattingNormsChoosen.DataSource = Nothing
        Me.lbxReformattingNormsChoosen.Items.Clear()
    End Sub

#End Region

#Region "Load Data"

    Public Sub LoadData(Optional ByVal intIndex As Int64 = 0, Optional ByVal dsData As DataSet = Nothing)
        Try
            ClearAll()
            IsLoaded = False
            If dsData Is Nothing Then
                myData1 = database.SelectDigitalObjectsByID(myProjectID)
            Else
                myData1 = dsData
            End If
            FillLvwDO()
            IsLoaded = True
            ' tabulador "Informação Geral"
            If myData1.Tables.Count > 0 Then
                BindMetadataOD()

                '// Populate the TreeView with nodes.
                treeImg.Nodes.Clear()

                If lvwDO.Items.Count > 0 Then
                    Me.lvwDO.Items(Convert.ToInt32(intIndex)).Selected = True
                    myDOStructure = database.getDOStructure(Me.lvwDO.Items(Convert.ToInt32(intIndex)).Tag)

                    If Not (myDOStructure Is Nothing) Then
                        tree.LoadTreeViewFromXmlFile(myDOStructure, treeImg)
                        treeImg.ExpandAll()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub

    Private Sub CreateLvwDO()
        Me.lvwDO.View = View.Details
        Me.lvwDO.LabelEdit = False
        Me.lvwDO.FullRowSelect = True
        Me.lvwDO.MultiSelect = False

        ' Create columns for the items and subitems.
        Me.lvwDO.Columns.Add("Objectos digitais", Me.lvwDO.Width - 10, HorizontalAlignment.Left)
        Me.lvwDO.Columns.Add("", 10, HorizontalAlignment.Left)
    End Sub

    Private Sub FillLvwDO()

        Dim DOtoCheck As Boolean = False
        Dim myTable As DataTable = myData1.Tables(0)

        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            If (myRow.RowState <> DataRowState.Deleted) Then
                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("Name").ToString())
                lvi.Tag = myRow.Item("DigitalObjectID")
                Me.lvwDO.Items.Add(lvi)
                If myTable.Rows(i).Item("RevisiondateTime") < DateToDB(Now) Then
                    lvi.ImageIndex = 0
                    DOtoCheck = True
                ElseIf myTable.Rows(i).Item("Active") = 1 Then
                    lvi.ImageIndex = 1
                ElseIf myTable.Rows(i).Item("Active") = 0 Then
                    lvi.ImageIndex = 2
                End If
            End If
        Next
        Me.groupLstProjects.Text = "Objectos digitais [" & Me.lvwDO.Items.Count & "]"
        If DOtoCheck Then
            lblAttention.Visible = True
        Else
            lblAttention.Visible = False
        End If
    End Sub

#End Region

#Region "Bind Metadata of DigitalObject"

    Private Sub BindMetadataOD()
        Me.ckbActive.DataBindings.Add(New Binding("Checked", myData1, myData1.Tables(0).ToString & ".Active"))

        Me.lblName.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".Name"))

        Me.lblOriginalName.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".OriginalName"))

        Me.txtArchiveID.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ArchiveID"))
        Me.lblArchiveID.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ArchiveID"))

        Me.txtTopographicalQuota.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".TopographicalQuota"))
        Me.lblTopographicalQuota.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".TopographicalQuota"))

        Me.lblIP.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".Username"))

        Me.lblCreationDateTime.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".CreationDateTime"))
        Me.txtCreationDateTime.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".CreationDateTime"))

        Me.lblArchiveDateTime.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ArchiveDateTime"))
        Me.txtArchiveDateTime.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ArchiveDateTime"))

        Me.lblDepositDateTime.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".DepositDateTime"))
        Me.txtDepositDateTime.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".DepositDateTime"))

        Me.lblRevisionDateTime.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".RevisionDateTime"))
        Me.lblNumImg.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".QuantityOfTerminalObjects"))

        Me.txtCaptureEntityCorporate.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".CaptureEntityCorporate"))
        Me.lblCaptureEntityCorporate.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".CaptureEntityCorporate"))

        Me.txtResponsabilityEntity.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ResponsabilityEntity"))
        Me.lblResponsabilityEntity.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ResponsabilityEntity"))

        Me.txtPreservationOriginalInformation.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".PreservationOriginalInformation"))
        Me.lblPreservationOriginalInformation.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".PreservationOriginalInformation"))

        Me.txtExternalDescriptiveInfo.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ExternalDescriptiveInformation"))
        Me.lblExternalDescriptiveInfo.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ExternalDescriptiveInformation"))

        Me.txtArchivingProfile.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ArchivingProfile"))
        Me.lblArchivingProfile.DataBindings.Add(New Binding("Text", myData1, myData1.Tables(0).ToString & ".ArchivingProfile"))

    End Sub

    Private Sub LoadDescriptionInfo(ByVal DOID As Int64)
        Dim tnNew As TreeNode
        Dim mydata As New DataSet
        Dim i, count As Integer

        mydata = database.SelectInfoAssociations(DOID)
        count = mydata.Tables(0).Rows.Count - 1

        Me.tvwDescriptionInfo.Nodes.Clear()
        For i = 0 To count
            tnNew = New TreeNode(mydata.Tables(0).Rows(i).Item("CompleteUnitId")) 'Me.tvwDescriptionInfo.Nodes.Add(mydata.Tables(0).Rows(i).Item("CompleteUnitId"))
            With tnNew
                .Tag = mydata.Tables(0).Rows(i).Item("ComponentID")
                .ImageIndex = getImageIndex(mydata.Tables(0).Rows(i).Item("OtherLevel"))
                .SelectedImageIndex() = getImageIndex(mydata.Tables(0).Rows(i).Item("OtherLevel"))
            End With
            Me.tvwDescriptionInfo.Nodes.Add(tnNew)
        Next i
    End Sub

    Function getImageIndex(ByVal level As String) As Integer
        If level = "F" Then
            Return 0
        End If
        If level = "SF" Then
            Return 1
        End If
        If level = "UI" Then
            Return 2
        End If
        If level = "SR" Then
            Return 3
        End If
        If level = "SSR" Then
            Return 4
        End If
        If level = "SC" Then
            Return 5
        End If
        If level = "SSC" Then
            Return 6
        End If
        If level = "SSSC" Then
            Return 7
        End If
        If level = "DC" Then
            Return 8
        End If
        If level = "D" Then
            Return 9
        End If
    End Function

#End Region

#Region "Bind Metadata of Image"

    Private Sub BindMetadataImage()
        Dim myMetadataImage = database.SelectMetadataImageByName(Me.lvwDO.SelectedItems(0).Tag, Me.treeImg.SelectedNode.Text)

        If myMetadataImage.Tables(0).Rows.Count > 0 Then

            Dim row As DataRow = myMetadataImage.Tables(0).Rows(0)
            Me.lblSize.Text = DBToStr(row.Item("ImageSize") & " KB")
            Me.lblResolution.Text = DBToStr(row.Item("Resolution"))
            Me.tBxColor.Text = DBToStr(row.Item("ColorSpace"))
            Me.lblBitDepth.Text = DBToStr(row.Item("BitDepth"))
            Me.lblHeight.Text = DBToStr(row.Item("ImageHeight"))
            Me.lblWidth.Text = DBToStr(row.Item("ImageWidth"))
            Me.lblMimeType.Text = DBToStr(row.Item("MIMEType"))
            Me.lblCompression.Text = DBToStr(row.Item("Compression"))
            Me.lblLampType.Text = DBToStr(row.Item("LTDescription"))
            Me.lblProfile.Text = DBToStr(row.Item("ProfileName"))
            Me.lblTPlatform.Text = DBToStr(row.Item("ScannerMN"))
            Me.lblFNumber.Text = DBToStr(row.Item("FNumber"))
            Me.lblExposureTime.Text = DBToStr(row.Item("ExposureTime"))
            Me.lblMeteringMode.Text = DBToStr(row.Item("MeteringMode"))
            Me.lblFocalLength.Text = DBToStr(row.Item("Focallength"))
            Me.lblAutoFocus.Text = DBToStr(row.Item("AutoFocus"))

            Me.lblProcessingDateTime.Text = DBToStr(row.Item("ProcessingDateTime"))
            Me.lblProcessingActions.Text = DBToStr(row.Item("ProcessingActions"))
            Me.lblProcessingSoftwareName.Text = DBToStr(row.Item("ProcessingSoftwareName"))
            Me.lblProcessingSoftwareVersion.Text = DBToStr(row.Item("ProcessingSoftwareVersion"))
            Me.lblProcessingOSName.Text = DBToStr(row.Item("ProcessingOSName"))
            Me.lblProcessingOSVersion.Text = DBToStr(row.Item("ProcessingOSVersion"))
            Me.lblColorManager.Text = DBToStr(row.Item("ColorManager"))
        End If
    End Sub

#End Region

#Region "Enable/Disable Textboxs"

    Private Sub EnableEdition()
        Me.txtOriginalName.BringToFront()
        Me.txtArchiveID.BringToFront()
        Me.txtTopographicalQuota.BringToFront()
        Me.txtPreservationOriginalInformation.BringToFront()
        Me.txtExternalDescriptiveInfo.BringToFront()
        Me.txtArchivingProfile.BringToFront()
        Me.txtResponsabilityEntity.BringToFront()
        Me.txtCaptureEntityCorporate.BringToFront()
        Me.txtArchiveDateTime.BringToFront()
        Me.txtDepositDateTime.BringToFront()
        Me.ckbActive.Enabled = True

        Me.btnNewDO.Enabled = False
        Me.lvwDO.Enabled = False
        Me.btnDeleteDO.Enabled = False
        Me.btnEditDO.Text = configReader.GetValue("btnSave.Text", GetType(String))
        Me.btnEditDO.ImageIndex = 2
        Me.btnCancel.Enabled = True
    End Sub

    Private Sub DisableEdition()
        Me.txtOriginalName.SendToBack()
        Me.txtArchiveID.SendToBack()
        Me.txtTopographicalQuota.SendToBack()
        Me.txtPreservationOriginalInformation.SendToBack()
        Me.txtExternalDescriptiveInfo.SendToBack()
        Me.txtArchivingProfile.SendToBack()
        Me.txtResponsabilityEntity.SendToBack()
        Me.txtCaptureEntityCorporate.SendToBack()
        Me.txtCreationDateTime.SendToBack()
        Me.txtArchiveDateTime.SendToBack()
        Me.txtDepositDateTime.SendToBack()
        Me.ckbActive.Enabled = False

        Me.btnNewDO.Enabled = True
        Me.lvwDO.Enabled = True
        Me.btnDeleteDO.Enabled = True
        Me.btnEditDO.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        Me.btnEditDO.ImageIndex = 3
        Me.btnEditDO.Enabled = True
        Me.btnCancel.Enabled = False
    End Sub

#End Region

#Region "Context menu selected fond tree "

    Private Sub miNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNew.Click
        NewNode(Me.treeImg.SelectedNode)
    End Sub

    Private Sub miDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDelete.Click
        If Me.treeImg.SelectedNode.GetNodeCount(True) > 0 Then
            If MsgBox(InfoMessage("DigitalObjects.DeleteAllFiles"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DeleteChildNodes(Me.treeImg.SelectedNode)
                Me.treeImg.SelectedNode.Remove()
                SaveStructure()
            End If
        Else
            If MsgBox(InfoMessage("DigitalObjects.DeleteFile") & Me.lvwDO.SelectedItems(0).Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DeleteChildNodes(Me.treeImg.SelectedNode)
                Me.treeImg.SelectedNode.Remove()
                SaveStructure()
            End If
        End If
    End Sub

    Private Sub miRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRename.Click
        RenameNode(Me.treeImg.SelectedNode)
    End Sub

    Private Sub NewNode(ByVal tn As TreeNode)
        '// NOTE: frmNewNode will update the UI state variables.

        If Not tn Is Nothing Then
            ' add nodes to directories only
            If tn.ImageIndex <= Constants.DIRECTORY Then
                If treeImg.GetNodeCount(True) > 0 Then
                    Dim AddNodeForm As New AddNodeForm
                    AddNodeForm.Op = "New"
                    AddNodeForm.FullPath = tn.FullPath
                    AddNodeForm.ShowDialog(Me)
                    Dim NewTreeNode As TreeNode = tn.Nodes.Add(AddNodeForm.NodeName)
                    Me.treeImg.SelectedNode = NewTreeNode
                End If
            Else
                MsgBox(InfoMessage("DigitalObjects.InvalidNode"), MsgBoxStyle.Information)
            End If
            SaveStructure()
        End If
    End Sub


    Private Sub DeleteChildNodes(ByVal tn As TreeNode)
        Try
            If Not tn Is Nothing Then
                If (tn.Parent Is Nothing) Then ' is the root
                    Exit Sub
                End If

                If tn.GetNodeCount(True) > 0 Then
                    For Each tnode As TreeNode In tn.Nodes
                        Call DeleteChildNodes(tnode)
                        Dim nodename As String = tnode.Text
                    Next
                Else
                    If Not tn.Tag Is Nothing Then
                        database.DeleteFile(tn.Tag)
                        Me.lblNumImg.Text = database.setQuantityOfTerminalObjects(Me.lvwDO.SelectedItems(0).Tag)
                        Log.Append(Constants.UserLogon, Log.RemoveNode, "File " & tn.Text & " was deleted!")
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RenameNode(ByVal tn As TreeNode)
        Dim sRet As String

        Try
            If Not (tn Is Nothing) Then

                If (tn.Parent Is Nothing) Then ' is the root
                    MsgBox("Não é possível alterar o nome da raiz!", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Dim AddNodeForm As New AddNodeForm
                AddNodeForm.Op = "Rename"
                AddNodeForm.FullPath = tn.FullPath
                AddNodeForm.NodeName = tn.Text
                AddNodeForm.ShowDialog(Me)
                sRet = AddNodeForm.NodeName

                If sRet <> "" Then
                    If Not database.UpdateNameDOFile(Me.lvwDO.SelectedItems(0).Tag, tn.Text, sRet) Then
                        MsgBox(InfoMessage("DigitalObjects.InvalidName"), MsgBoxStyle.Exclamation)
                    Else
                        Log.Append(Constants.UserLogon, Log.EditNode, "Name of node " & tn.Text & " was changed to " & sRet & ".")
                        tn.Text = sRet
                    End If
                Else
                    MsgBox(InfoMessage("DigitalObjects.EmptyNode"), MsgBoxStyle.OKOnly Or _
                        MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox(InfoMessage("DigitalObjects.RenomeNode"), MsgBoxStyle.OKOnly Or _
                    MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        SaveStructure()
    End Sub


    Public Sub treeImg_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles treeImg.DragEnter

        e.Effect = DragDropEffects.Move

    End Sub


    Public Sub treeImg_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles treeImg.DragDrop

        Dim pt As Point
        Dim tnDestination As TreeNode
        Dim tnNew As TreeNode
        Dim tnSourceParent As TreeNode

        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then

            '// Get a handle to the destination node.
            pt = treeImg.PointToClient(New Point(e.X, e.Y))
            tnDestination = treeImg.GetNodeAt(pt)

            If tree.IsDropAllowed(m_tnSource, tnDestination) = True Then
                '// Need to remember the Source's Parent because the reference
                '// will be scrambled in the cloning process.
                If Not m_tnSource.Tag Is Nothing And Not tnDestination.Tag Is Nothing Then

                    tnNew = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

                    Dim OrderNext As Boolean
                    If tnDestination.Index < m_tnSource.Index Then
                        OrderNext = True
                    Else
                        OrderNext = False
                    End If

                    Dim tn As TreeNode
                    tn = tnDestination
                    Dim col As New Collection
                    Do Until tn Is m_tnSource
                        Dim a(2) As String
                        a(0) = tn.Tag
                        a(1) = tn.Text
                        col.Add(a)
                        If OrderNext Then
                            tn = tn.NextNode
                        Else
                            tn = tn.PrevNode
                        End If
                    Loop

                    tn = tnDestination
                    tnDestination.Tag = m_tnSource.Tag
                    tnDestination.Text = m_tnSource.Text
                    Dim i As Integer = 1
                    Do Until tn Is m_tnSource
                        If OrderNext Then
                            tn.NextNode.Tag = col.Item(i)(0)
                            tn.NextNode.Text = col.Item(i)(1)
                            tn = tn.NextNode
                        Else
                            tn.PrevNode.Tag = col.Item(i)(0)
                            tn.PrevNode.Text = col.Item(i)(1)
                            tn = tn.PrevNode
                        End If
                        i = i + 1
                    Loop

                Else
                    tnSourceParent = m_tnSource.Parent

                    '// Create a new node based on the data contained in the dragged node.
                    tnNew = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
                    tnDestination.Nodes.Add(CType(tnNew.Clone, TreeNode))
                    tnDestination.ExpandAll()
                    tnNew.Remove()

                    treeImg.SelectedNode = Nothing
                End If

            Else
                '// Drop is not allowed because it will create a cyclical reference.
                '// May want to put a messagebox here explaining to the user why
                '// the drop cannot be completed.
                MsgBox(InfoMessage("DigitalObjects.CircularDependence"), _
                       MsgBoxStyle.Exclamation)
            End If  '// If tv.IsDropAllowed(...)«
        End If
        SaveStructure()
    End Sub

    Public Sub treeImg_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles treeImg.ItemDrag

        m_tnSource = CType(e.Item, TreeNode)
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub treeImg_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treeImg.BeforeSelect
        index = e.Node.ImageIndex
    End Sub

    Private Sub SaveStructure()
        Dim tn As TreeNode

        If treeImg.GetNodeCount(False) > 0 Then
            tn = treeImg.Nodes(0)
        End If

        tree.SaveNodeCollection(Me.lvwDO.SelectedItems(0).Tag, tn)
    End Sub

    Private Sub treeImg_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles treeImg.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim tn As TreeNode = Me.treeImg.GetNodeAt(e.X, e.Y)
            If Not tn Is Nothing Then
                Me.treeImg.SelectedNode = tn
            End If
        End If
    End Sub

#End Region


End Class
