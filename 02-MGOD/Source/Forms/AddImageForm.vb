
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
Imports System.Xml
Imports System.Threading


Public Class AddImageForm
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intProjectID As Int64, ByVal intDigitalObjectID As Int64)
        MyBase.New()

        myProjectID = intProjectID
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
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents grpBxConfiguracoesDigitalizacao As System.Windows.Forms.GroupBox
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents lblCompression As System.Windows.Forms.Label
    Friend WithEvents lblMimeType As System.Windows.Forms.Label
    Friend WithEvents lblBitDepth As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lblColorSpace As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblCompression2 As System.Windows.Forms.Label
    Friend WithEvents lbl12 As System.Windows.Forms.Label
    Friend WithEvents lblImageWidth As System.Windows.Forms.Label
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents lbl21 As System.Windows.Forms.Label
    Friend WithEvents lblLampType As System.Windows.Forms.Label
    Friend WithEvents lblMimeType2 As System.Windows.Forms.Label
    Friend WithEvents lblImageLength As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents grpBxPlataformaTecnologica As System.Windows.Forms.GroupBox
    Friend WithEvents lblOSVersion As System.Windows.Forms.Label
    Friend WithEvents lblOperatingSystem As System.Windows.Forms.Label
    Friend WithEvents lblScanningSoftwareVersionNo As System.Windows.Forms.Label
    Friend WithEvents lblScanningSoftware As System.Windows.Forms.Label
    Friend WithEvents lblScannerManufacturer As System.Windows.Forms.Label
    Friend WithEvents lblDeviceSource As System.Windows.Forms.Label
    Friend WithEvents lbl7 As System.Windows.Forms.Label
    Friend WithEvents lblScannermodelName As System.Windows.Forms.Label
    Friend WithEvents lbl9 As System.Windows.Forms.Label
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents lbl8 As System.Windows.Forms.Label
    Friend WithEvents lbl10 As System.Windows.Forms.Label
    Friend WithEvents lbl11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bttnFxRename As System.Windows.Forms.Button
    Friend WithEvents pBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cbxDerivative As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lbl13 As System.Windows.Forms.Label
    Friend WithEvents cbxQuality As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblHandle As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxScannerModelName As System.Windows.Forms.ComboBox
    Friend WithEvents cbxLampType As System.Windows.Forms.ComboBox
    Friend WithEvents cbxProfileID As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtColorManager As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingOSVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingOSName As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingSoftwareversion As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingSoftwareName As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingActions As System.Windows.Forms.TextBox
    Friend WithEvents cbxAutoFocus As System.Windows.Forms.ComboBox
    Friend WithEvents cbxMeteringMode As System.Windows.Forms.ComboBox
    Friend WithEvents txtExposureTime As System.Windows.Forms.TextBox
    Friend WithEvents txtFocalLength As System.Windows.Forms.TextBox
    Friend WithEvents txtFNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingDateTime As MGOD.DateTextBox
    Friend WithEvents ttpGeneral As System.Windows.Forms.ToolTip
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents lvwDOFiles As System.Windows.Forms.ListView
    Friend WithEvents imglDOFiles As System.Windows.Forms.ImageList
    Friend WithEvents tBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblDerivativeValue As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AddImageForm))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lvwDOFiles = New System.Windows.Forms.ListView
        Me.imglDOFiles = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtProcessingDateTime = New MGOD.DateTextBox
        Me.txtColorManager = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtProcessingOSVersion = New System.Windows.Forms.TextBox
        Me.txtProcessingOSName = New System.Windows.Forms.TextBox
        Me.txtProcessingSoftwareversion = New System.Windows.Forms.TextBox
        Me.txtProcessingSoftwareName = New System.Windows.Forms.TextBox
        Me.txtProcessingActions = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDerivativeValue = New System.Windows.Forms.Label
        Me.tBar = New System.Windows.Forms.TrackBar
        Me.cbxQuality = New System.Windows.Forms.ComboBox
        Me.lbl13 = New System.Windows.Forms.Label
        Me.pBar1 = New System.Windows.Forms.ProgressBar
        Me.cbxDerivative = New System.Windows.Forms.CheckBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.grpBxPlataformaTecnologica = New System.Windows.Forms.GroupBox
        Me.lblOSVersion = New System.Windows.Forms.Label
        Me.lblOperatingSystem = New System.Windows.Forms.Label
        Me.lblScanningSoftwareVersionNo = New System.Windows.Forms.Label
        Me.lblScanningSoftware = New System.Windows.Forms.Label
        Me.lblScannerManufacturer = New System.Windows.Forms.Label
        Me.lblDeviceSource = New System.Windows.Forms.Label
        Me.cbxScannerModelName = New System.Windows.Forms.ComboBox
        Me.lbl7 = New System.Windows.Forms.Label
        Me.lblScannermodelName = New System.Windows.Forms.Label
        Me.lbl9 = New System.Windows.Forms.Label
        Me.lbl6 = New System.Windows.Forms.Label
        Me.lbl8 = New System.Windows.Forms.Label
        Me.lbl10 = New System.Windows.Forms.Label
        Me.lbl11 = New System.Windows.Forms.Label
        Me.grpBxConfiguracoesDigitalizacao = New System.Windows.Forms.GroupBox
        Me.cbxAutoFocus = New System.Windows.Forms.ComboBox
        Me.cbxMeteringMode = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtExposureTime = New System.Windows.Forms.TextBox
        Me.txtFocalLength = New System.Windows.Forms.TextBox
        Me.txtFNumber = New System.Windows.Forms.TextBox
        Me.lblWidth = New System.Windows.Forms.Label
        Me.lblHeight = New System.Windows.Forms.Label
        Me.lblCompression = New System.Windows.Forms.Label
        Me.lblMimeType = New System.Windows.Forms.Label
        Me.lblBitDepth = New System.Windows.Forms.Label
        Me.lblResolution = New System.Windows.Forms.Label
        Me.lblColorSpace = New System.Windows.Forms.Label
        Me.lblSize = New System.Windows.Forms.Label
        Me.cbxLampType = New System.Windows.Forms.ComboBox
        Me.cbxProfileID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblCompression2 = New System.Windows.Forms.Label
        Me.lbl12 = New System.Windows.Forms.Label
        Me.lblImageWidth = New System.Windows.Forms.Label
        Me.lbl5 = New System.Windows.Forms.Label
        Me.lbl21 = New System.Windows.Forms.Label
        Me.lblLampType = New System.Windows.Forms.Label
        Me.lblMimeType2 = New System.Windows.Forms.Label
        Me.lblImageLength = New System.Windows.Forms.Label
        Me.lbl1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblHandle = New System.Windows.Forms.Label
        Me.bttnFxRename = New System.Windows.Forms.Button
        Me.ttpGeneral = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBxPlataformaTecnologica.SuspendLayout()
        Me.grpBxConfiguracoesDigitalizacao.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox5.Controls.Add(Me.lvwDOFiles)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Controls.Add(Me.grpBxPlataformaTecnologica)
        Me.GroupBox5.Controls.Add(Me.grpBxConfiguracoesDigitalizacao)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(825, 558)
        Me.GroupBox5.TabIndex = 86
        Me.GroupBox5.TabStop = False
        '
        'lvwDOFiles
        '
        Me.lvwDOFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwDOFiles.Location = New System.Drawing.Point(8, 19)
        Me.lvwDOFiles.Name = "lvwDOFiles"
        Me.lvwDOFiles.Size = New System.Drawing.Size(192, 524)
        Me.lvwDOFiles.SmallImageList = Me.imglDOFiles
        Me.lvwDOFiles.StateImageList = Me.imglDOFiles
        Me.lvwDOFiles.TabIndex = 93
        '
        'imglDOFiles
        '
        Me.imglDOFiles.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglDOFiles.ImageStream = CType(resources.GetObject("imglDOFiles.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglDOFiles.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.txtProcessingDateTime)
        Me.GroupBox2.Controls.Add(Me.txtColorManager)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtProcessingOSVersion)
        Me.GroupBox2.Controls.Add(Me.txtProcessingOSName)
        Me.GroupBox2.Controls.Add(Me.txtProcessingSoftwareversion)
        Me.GroupBox2.Controls.Add(Me.txtProcessingSoftwareName)
        Me.GroupBox2.Controls.Add(Me.txtProcessingActions)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(512, 251)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 222)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tratamento da imagem"
        '
        'txtProcessingDateTime
        '
        Me.txtProcessingDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessingDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingDateTime.Location = New System.Drawing.Point(120, 29)
        Me.txtProcessingDateTime.Mask = "####-##-##"
        Me.txtProcessingDateTime.MaxLength = 10
        Me.txtProcessingDateTime.Name = "txtProcessingDateTime"
        Me.txtProcessingDateTime.Size = New System.Drawing.Size(90, 20)
        Me.txtProcessingDateTime.TabIndex = 127
        Me.txtProcessingDateTime.Text = ""
        '
        'txtColorManager
        '
        Me.txtColorManager.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColorManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColorManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColorManager.Location = New System.Drawing.Point(121, 192)
        Me.txtColorManager.Name = "txtColorManager"
        Me.txtColorManager.Size = New System.Drawing.Size(170, 20)
        Me.txtColorManager.TabIndex = 74
        Me.txtColorManager.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label7.Location = New System.Drawing.Point(9, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 20)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Gestão cor"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProcessingOSVersion
        '
        Me.txtProcessingOSVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessingOSVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingOSVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingOSVersion.Location = New System.Drawing.Point(120, 165)
        Me.txtProcessingOSVersion.Name = "txtProcessingOSVersion"
        Me.txtProcessingOSVersion.Size = New System.Drawing.Size(170, 20)
        Me.txtProcessingOSVersion.TabIndex = 72
        Me.txtProcessingOSVersion.Text = ""
        '
        'txtProcessingOSName
        '
        Me.txtProcessingOSName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessingOSName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingOSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingOSName.Location = New System.Drawing.Point(120, 138)
        Me.txtProcessingOSName.Name = "txtProcessingOSName"
        Me.txtProcessingOSName.Size = New System.Drawing.Size(170, 20)
        Me.txtProcessingOSName.TabIndex = 71
        Me.txtProcessingOSName.Text = ""
        '
        'txtProcessingSoftwareversion
        '
        Me.txtProcessingSoftwareversion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessingSoftwareversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingSoftwareversion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingSoftwareversion.Location = New System.Drawing.Point(120, 111)
        Me.txtProcessingSoftwareversion.Name = "txtProcessingSoftwareversion"
        Me.txtProcessingSoftwareversion.Size = New System.Drawing.Size(170, 20)
        Me.txtProcessingSoftwareversion.TabIndex = 70
        Me.txtProcessingSoftwareversion.Text = ""
        '
        'txtProcessingSoftwareName
        '
        Me.txtProcessingSoftwareName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessingSoftwareName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingSoftwareName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingSoftwareName.Location = New System.Drawing.Point(120, 84)
        Me.txtProcessingSoftwareName.Name = "txtProcessingSoftwareName"
        Me.txtProcessingSoftwareName.Size = New System.Drawing.Size(170, 20)
        Me.txtProcessingSoftwareName.TabIndex = 69
        Me.txtProcessingSoftwareName.Text = ""
        '
        'txtProcessingActions
        '
        Me.txtProcessingActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessingActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingActions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingActions.Location = New System.Drawing.Point(120, 57)
        Me.txtProcessingActions.Name = "txtProcessingActions"
        Me.txtProcessingActions.Size = New System.Drawing.Size(170, 20)
        Me.txtProcessingActions.TabIndex = 68
        Me.txtProcessingActions.Text = ""
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label8.Location = New System.Drawing.Point(8, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 20)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Software tratamento"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label9.Location = New System.Drawing.Point(8, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 20)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Data tratamento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label10.Location = New System.Drawing.Point(8, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 20)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Sistema operativo "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label11.Location = New System.Drawing.Point(8, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 20)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Tratamento"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label12.Location = New System.Drawing.Point(8, 110)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 20)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Versão software"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label13.Location = New System.Drawing.Point(8, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 20)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Versão SO"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.lblDerivativeValue)
        Me.GroupBox1.Controls.Add(Me.tBar)
        Me.GroupBox1.Controls.Add(Me.cbxQuality)
        Me.GroupBox1.Controls.Add(Me.lbl13)
        Me.GroupBox1.Controls.Add(Me.pBar1)
        Me.GroupBox1.Controls.Add(Me.cbxDerivative)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Location = New System.Drawing.Point(207, 472)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 72)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        '
        'lblDerivativeValue
        '
        Me.lblDerivativeValue.Location = New System.Drawing.Point(432, 14)
        Me.lblDerivativeValue.Name = "lblDerivativeValue"
        Me.lblDerivativeValue.Size = New System.Drawing.Size(40, 24)
        Me.lblDerivativeValue.TabIndex = 78
        '
        'tBar
        '
        Me.tBar.Location = New System.Drawing.Point(232, 11)
        Me.tBar.Maximum = 100
        Me.tBar.Name = "tBar"
        Me.tBar.Size = New System.Drawing.Size(190, 42)
        Me.tBar.TabIndex = 77
        Me.tBar.TickFrequency = 10
        Me.tBar.Value = 60
        '
        'cbxQuality
        '
        Me.cbxQuality.DisplayMember = "80"
        Me.cbxQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxQuality.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxQuality.Location = New System.Drawing.Point(240, 14)
        Me.cbxQuality.Name = "cbxQuality"
        Me.cbxQuality.Size = New System.Drawing.Size(48, 21)
        Me.cbxQuality.TabIndex = 75
        Me.cbxQuality.ValueMember = "50"
        '
        'lbl13
        '
        Me.lbl13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl13.Location = New System.Drawing.Point(120, 14)
        Me.lbl13.Name = "lbl13"
        Me.lbl13.Size = New System.Drawing.Size(120, 18)
        Me.lbl13.TabIndex = 76
        Me.lbl13.Text = "Qualidade da derivada"
        Me.lbl13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pBar1
        '
        Me.pBar1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pBar1.Location = New System.Drawing.Point(7, 54)
        Me.pBar1.Name = "pBar1"
        Me.pBar1.Size = New System.Drawing.Size(585, 9)
        Me.pBar1.TabIndex = 74
        '
        'cbxDerivative
        '
        Me.cbxDerivative.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxDerivative.Checked = True
        Me.cbxDerivative.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxDerivative.Location = New System.Drawing.Point(7, 14)
        Me.cbxDerivative.Name = "cbxDerivative"
        Me.cbxDerivative.Size = New System.Drawing.Size(112, 20)
        Me.cbxDerivative.TabIndex = 20
        Me.cbxDerivative.Text = "Gerar Derivada"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSave.Enabled = False
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.ImageIndex = 2
        Me.btnSave.ImageList = Me.imglButtons
        Me.btnSave.Location = New System.Drawing.Point(512, 20)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 25)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'grpBxPlataformaTecnologica
        '
        Me.grpBxPlataformaTecnologica.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lblOSVersion)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lblOperatingSystem)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lblScanningSoftwareVersionNo)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lblScanningSoftware)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lblScannerManufacturer)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lblDeviceSource)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.cbxScannerModelName)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lbl7)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lblScannermodelName)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lbl9)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lbl6)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lbl8)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lbl10)
        Me.grpBxPlataformaTecnologica.Controls.Add(Me.lbl11)
        Me.grpBxPlataformaTecnologica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBxPlataformaTecnologica.Location = New System.Drawing.Point(207, 251)
        Me.grpBxPlataformaTecnologica.Name = "grpBxPlataformaTecnologica"
        Me.grpBxPlataformaTecnologica.Size = New System.Drawing.Size(300, 222)
        Me.grpBxPlataformaTecnologica.TabIndex = 89
        Me.grpBxPlataformaTecnologica.TabStop = False
        Me.grpBxPlataformaTecnologica.Text = "Plataforma Tecnológica"
        '
        'lblOSVersion
        '
        Me.lblOSVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOSVersion.Location = New System.Drawing.Point(120, 191)
        Me.lblOSVersion.Name = "lblOSVersion"
        Me.lblOSVersion.Size = New System.Drawing.Size(170, 20)
        Me.lblOSVersion.TabIndex = 19
        '
        'lblOperatingSystem
        '
        Me.lblOperatingSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOperatingSystem.Location = New System.Drawing.Point(120, 164)
        Me.lblOperatingSystem.Name = "lblOperatingSystem"
        Me.lblOperatingSystem.Size = New System.Drawing.Size(170, 20)
        Me.lblOperatingSystem.TabIndex = 18
        '
        'lblScanningSoftwareVersionNo
        '
        Me.lblScanningSoftwareVersionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanningSoftwareVersionNo.Location = New System.Drawing.Point(120, 137)
        Me.lblScanningSoftwareVersionNo.Name = "lblScanningSoftwareVersionNo"
        Me.lblScanningSoftwareVersionNo.Size = New System.Drawing.Size(170, 20)
        Me.lblScanningSoftwareVersionNo.TabIndex = 17
        '
        'lblScanningSoftware
        '
        Me.lblScanningSoftware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanningSoftware.Location = New System.Drawing.Point(120, 110)
        Me.lblScanningSoftware.Name = "lblScanningSoftware"
        Me.lblScanningSoftware.Size = New System.Drawing.Size(170, 20)
        Me.lblScanningSoftware.TabIndex = 16
        '
        'lblScannerManufacturer
        '
        Me.lblScannerManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScannerManufacturer.Location = New System.Drawing.Point(120, 83)
        Me.lblScannerManufacturer.Name = "lblScannerManufacturer"
        Me.lblScannerManufacturer.Size = New System.Drawing.Size(170, 20)
        Me.lblScannerManufacturer.TabIndex = 15
        '
        'lblDeviceSource
        '
        Me.lblDeviceSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDeviceSource.Location = New System.Drawing.Point(120, 56)
        Me.lblDeviceSource.Name = "lblDeviceSource"
        Me.lblDeviceSource.Size = New System.Drawing.Size(170, 20)
        Me.lblDeviceSource.TabIndex = 14
        '
        'cbxScannerModelName
        '
        Me.cbxScannerModelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxScannerModelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxScannerModelName.Location = New System.Drawing.Point(120, 28)
        Me.cbxScannerModelName.Name = "cbxScannerModelName"
        Me.cbxScannerModelName.Size = New System.Drawing.Size(170, 21)
        Me.cbxScannerModelName.TabIndex = 13
        '
        'lbl7
        '
        Me.lbl7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl7.Location = New System.Drawing.Point(8, 83)
        Me.lbl7.Name = "lbl7"
        Me.lbl7.Size = New System.Drawing.Size(110, 20)
        Me.lbl7.TabIndex = 60
        Me.lbl7.Text = "Fabricante"
        Me.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScannermodelName
        '
        Me.lblScannermodelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblScannermodelName.Location = New System.Drawing.Point(8, 28)
        Me.lblScannermodelName.Name = "lblScannermodelName"
        Me.lblScannermodelName.Size = New System.Drawing.Size(110, 20)
        Me.lblScannermodelName.TabIndex = 62
        Me.lblScannermodelName.Text = "Modelo dispositivo"
        Me.lblScannermodelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl9
        '
        Me.lbl9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl9.Location = New System.Drawing.Point(8, 137)
        Me.lbl9.Name = "lbl9"
        Me.lbl9.Size = New System.Drawing.Size(110, 20)
        Me.lbl9.TabIndex = 66
        Me.lbl9.Text = "Versão do Software "
        Me.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl6
        '
        Me.lbl6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl6.Location = New System.Drawing.Point(8, 56)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(110, 20)
        Me.lbl6.TabIndex = 58
        Me.lbl6.Text = "Dispositivo captura"
        Me.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl8
        '
        Me.lbl8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl8.Location = New System.Drawing.Point(8, 110)
        Me.lbl8.Name = "lbl8"
        Me.lbl8.Size = New System.Drawing.Size(110, 20)
        Me.lbl8.TabIndex = 64
        Me.lbl8.Text = "Software captura"
        Me.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl10
        '
        Me.lbl10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl10.Location = New System.Drawing.Point(8, 164)
        Me.lbl10.Name = "lbl10"
        Me.lbl10.Size = New System.Drawing.Size(110, 20)
        Me.lbl10.TabIndex = 54
        Me.lbl10.Text = "Sistema Operativo"
        Me.lbl10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl11
        '
        Me.lbl11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl11.Location = New System.Drawing.Point(8, 191)
        Me.lbl11.Name = "lbl11"
        Me.lbl11.Size = New System.Drawing.Size(110, 20)
        Me.lbl11.TabIndex = 56
        Me.lbl11.Text = "Versão SO"
        Me.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpBxConfiguracoesDigitalizacao
        '
        Me.grpBxConfiguracoesDigitalizacao.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.cbxAutoFocus)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.cbxMeteringMode)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.Label2)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.Label3)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.Label4)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.Label5)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.Label6)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.txtExposureTime)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.txtFocalLength)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.txtFNumber)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblWidth)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblHeight)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblCompression)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblMimeType)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblBitDepth)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblResolution)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblColorSpace)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblSize)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.cbxLampType)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.cbxProfileID)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.Label1)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.LblCompression2)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lbl12)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblImageWidth)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lbl5)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lbl21)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblLampType)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblMimeType2)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lblImageLength)
        Me.grpBxConfiguracoesDigitalizacao.Controls.Add(Me.lbl1)
        Me.grpBxConfiguracoesDigitalizacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBxConfiguracoesDigitalizacao.Location = New System.Drawing.Point(207, 78)
        Me.grpBxConfiguracoesDigitalizacao.Name = "grpBxConfiguracoesDigitalizacao"
        Me.grpBxConfiguracoesDigitalizacao.Size = New System.Drawing.Size(605, 167)
        Me.grpBxConfiguracoesDigitalizacao.TabIndex = 87
        Me.grpBxConfiguracoesDigitalizacao.TabStop = False
        Me.grpBxConfiguracoesDigitalizacao.Text = "Configurações Digitalização"
        '
        'cbxAutoFocus
        '
        Me.cbxAutoFocus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAutoFocus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAutoFocus.Location = New System.Drawing.Point(496, 134)
        Me.cbxAutoFocus.Name = "cbxAutoFocus"
        Me.cbxAutoFocus.Size = New System.Drawing.Size(100, 21)
        Me.cbxAutoFocus.TabIndex = 79
        '
        'cbxMeteringMode
        '
        Me.cbxMeteringMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMeteringMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMeteringMode.Location = New System.Drawing.Point(496, 80)
        Me.cbxMeteringMode.Name = "cbxMeteringMode"
        Me.cbxMeteringMode.Size = New System.Drawing.Size(100, 21)
        Me.cbxMeteringMode.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label2.Location = New System.Drawing.Point(400, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Tipo focagem"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label3.Location = New System.Drawing.Point(400, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Tempo exposição"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label4.Location = New System.Drawing.Point(400, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Forma medição"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label5.Location = New System.Drawing.Point(400, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 26)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Distância focal da lente"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label6.Location = New System.Drawing.Point(400, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Abertura objectiva"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExposureTime
        '
        Me.txtExposureTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExposureTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExposureTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExposureTime.Location = New System.Drawing.Point(496, 54)
        Me.txtExposureTime.Name = "txtExposureTime"
        Me.txtExposureTime.TabIndex = 72
        Me.txtExposureTime.Text = ""
        '
        'txtFocalLength
        '
        Me.txtFocalLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFocalLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFocalLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFocalLength.Location = New System.Drawing.Point(496, 108)
        Me.txtFocalLength.Name = "txtFocalLength"
        Me.txtFocalLength.TabIndex = 70
        Me.txtFocalLength.Text = ""
        '
        'txtFNumber
        '
        Me.txtFNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFNumber.Location = New System.Drawing.Point(496, 27)
        Me.txtFNumber.Name = "txtFNumber"
        Me.txtFNumber.TabIndex = 68
        Me.txtFNumber.Text = ""
        '
        'lblWidth
        '
        Me.lblWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWidth.Location = New System.Drawing.Point(280, 80)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(100, 20)
        Me.lblWidth.TabIndex = 10
        '
        'lblHeight
        '
        Me.lblHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeight.Location = New System.Drawing.Point(280, 53)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(100, 20)
        Me.lblHeight.TabIndex = 33
        '
        'lblCompression
        '
        Me.lblCompression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompression.Location = New System.Drawing.Point(88, 134)
        Me.lblCompression.Name = "lblCompression"
        Me.lblCompression.Size = New System.Drawing.Size(100, 21)
        Me.lblCompression.TabIndex = 8
        '
        'lblMimeType
        '
        Me.lblMimeType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMimeType.Location = New System.Drawing.Point(88, 107)
        Me.lblMimeType.Name = "lblMimeType"
        Me.lblMimeType.Size = New System.Drawing.Size(100, 20)
        Me.lblMimeType.TabIndex = 7
        '
        'lblBitDepth
        '
        Me.lblBitDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBitDepth.Location = New System.Drawing.Point(88, 80)
        Me.lblBitDepth.Name = "lblBitDepth"
        Me.lblBitDepth.Size = New System.Drawing.Size(100, 20)
        Me.lblBitDepth.TabIndex = 6
        '
        'lblResolution
        '
        Me.lblResolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResolution.Location = New System.Drawing.Point(88, 53)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(100, 20)
        Me.lblResolution.TabIndex = 5
        '
        'lblColorSpace
        '
        Me.lblColorSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColorSpace.Location = New System.Drawing.Point(280, 26)
        Me.lblColorSpace.Name = "lblColorSpace"
        Me.lblColorSpace.Size = New System.Drawing.Size(100, 20)
        Me.lblColorSpace.TabIndex = 9
        '
        'lblSize
        '
        Me.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSize.Location = New System.Drawing.Point(88, 26)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(100, 20)
        Me.lblSize.TabIndex = 5
        '
        'cbxLampType
        '
        Me.cbxLampType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxLampType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLampType.Location = New System.Drawing.Point(280, 107)
        Me.cbxLampType.Name = "cbxLampType"
        Me.cbxLampType.Size = New System.Drawing.Size(100, 21)
        Me.cbxLampType.TabIndex = 11
        '
        'cbxProfileID
        '
        Me.cbxProfileID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProfileID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProfileID.Location = New System.Drawing.Point(280, 134)
        Me.cbxProfileID.Name = "cbxProfileID"
        Me.cbxProfileID.Size = New System.Drawing.Size(100, 21)
        Me.cbxProfileID.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(208, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 29)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Perfil digitalização"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCompression2
        '
        Me.LblCompression2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.LblCompression2.Location = New System.Drawing.Point(8, 134)
        Me.LblCompression2.Name = "LblCompression2"
        Me.LblCompression2.Size = New System.Drawing.Size(80, 20)
        Me.LblCompression2.TabIndex = 18
        Me.LblCompression2.Text = "Compressão"
        Me.LblCompression2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl12
        '
        Me.lbl12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl12.Location = New System.Drawing.Point(8, 53)
        Me.lbl12.Name = "lbl12"
        Me.lbl12.Size = New System.Drawing.Size(80, 20)
        Me.lbl12.TabIndex = 4
        Me.lbl12.Text = "Resolução (dpi)"
        Me.lbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImageWidth
        '
        Me.lblImageWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblImageWidth.Location = New System.Drawing.Point(208, 78)
        Me.lblImageWidth.Name = "lblImageWidth"
        Me.lblImageWidth.Size = New System.Drawing.Size(80, 20)
        Me.lblImageWidth.TabIndex = 10
        Me.lblImageWidth.Text = "Largura"
        Me.lblImageWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl5
        '
        Me.lbl5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl5.Location = New System.Drawing.Point(8, 78)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(80, 26)
        Me.lbl5.TabIndex = 12
        Me.lbl5.Text = "Profundidade dos bits"
        Me.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl21
        '
        Me.lbl21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl21.Location = New System.Drawing.Point(208, 26)
        Me.lbl21.Name = "lbl21"
        Me.lbl21.Size = New System.Drawing.Size(80, 20)
        Me.lbl21.TabIndex = 6
        Me.lbl21.Text = "Cores"
        Me.lbl21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLampType
        '
        Me.lblLampType.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblLampType.Location = New System.Drawing.Point(208, 107)
        Me.lblLampType.Name = "lblLampType"
        Me.lblLampType.Size = New System.Drawing.Size(80, 22)
        Me.lblLampType.TabIndex = 16
        Me.lblLampType.Text = "Iluminância"
        Me.lblLampType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMimeType2
        '
        Me.lblMimeType2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblMimeType2.Location = New System.Drawing.Point(8, 107)
        Me.lblMimeType2.Name = "lblMimeType2"
        Me.lblMimeType2.Size = New System.Drawing.Size(80, 20)
        Me.lblMimeType2.TabIndex = 14
        Me.lblMimeType2.Text = "Formato"
        Me.lblMimeType2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImageLength
        '
        Me.lblImageLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lblImageLength.Location = New System.Drawing.Point(208, 53)
        Me.lblImageLength.Name = "lblImageLength"
        Me.lblImageLength.Size = New System.Drawing.Size(80, 20)
        Me.lblImageLength.TabIndex = 8
        Me.lblImageLength.Text = "Altura"
        Me.lblImageLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl1
        '
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.lbl1.Location = New System.Drawing.Point(8, 26)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(80, 20)
        Me.lbl1.TabIndex = 2
        Me.lbl1.Text = "Tamanho (KB)"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox4.Controls.Add(Me.btnSearch)
        Me.GroupBox4.Controls.Add(Me.txtName)
        Me.GroupBox4.Controls.Add(Me.lblHandle)
        Me.GroupBox4.Location = New System.Drawing.Point(207, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(605, 58)
        Me.GroupBox4.TabIndex = 86
        Me.GroupBox4.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(570, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 20)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "..."
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(88, 24)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(472, 20)
        Me.txtName.TabIndex = 2
        Me.txtName.Text = ""
        '
        'lblHandle
        '
        Me.lblHandle.BackColor = System.Drawing.Color.Transparent
        Me.lblHandle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHandle.Location = New System.Drawing.Point(16, 24)
        Me.lblHandle.Name = "lblHandle"
        Me.lblHandle.Size = New System.Drawing.Size(80, 16)
        Me.lblHandle.TabIndex = 75
        Me.lblHandle.Text = "Ficheiros"
        '
        'bttnFxRename
        '
        Me.bttnFxRename.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bttnFxRename.BackColor = System.Drawing.Color.White
        Me.bttnFxRename.Cursor = System.Windows.Forms.Cursors.Default
        Me.bttnFxRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnFxRename.Location = New System.Drawing.Point(678, 6)
        Me.bttnFxRename.Name = "bttnFxRename"
        Me.bttnFxRename.Size = New System.Drawing.Size(154, 25)
        Me.bttnFxRename.TabIndex = 1
        Me.bttnFxRename.Text = "Renomeador de ficheiros"
        '
        'AddImageForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(840, 598)
        Me.Controls.Add(Me.bttnFxRename)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AddImageForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Adicionar Ficheiro"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBxPlataformaTecnologica.ResumeLayout(False)
        Me.grpBxConfiguracoesDigitalizacao.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private properties"

    Private myProjectID As Int64
    Private myProjectName As String

    Private myDigitalObjectID As Int64
    Private myDOName As String
    Private myDOStructure As String

    Private myProgramState As ProgramState
    Private currentDirectory As String
    Private myPathName As String
    Private myFiles As New ArrayList
    Private myDigitalizationProfiles, myTechnologicalPlatform As DataSet
    Private database As New SqlCommands
    Private XmlDoc As New XmlDocument
    Public AssocitedFile As Boolean = False

    Private Thread As Thread

#End Region

#Region "AddImage Form"

    Private Sub AddImageForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myProgramState As New ProgramState

        Me.myDOName = database.getDOName(myDigitalObjectID)
        Me.myDOStructure = database.getDOStructure(myDigitalObjectID)

        FillDigitalizationProfiles()
        FillLampType()
        FillMeteringModes()
        FillAutoFocus()
        FillTechnologicalPlatform()
        CreateLvwDOFiles()
        FillDOFiles()

        Try
            Me.cbxProfileID.SelectedValue = CInt(myProgramState.LastProfileID)
            Me.cbxLampType.SelectedValue = CInt(myProgramState.LastLampType)
            Me.cbxScannerModelName.SelectedValue = CInt(myProgramState.LastScannerModelName)
            Me.cbxAutoFocus.SelectedValue = CInt(myProgramState.LastAutoFocus)
            Me.cbxMeteringMode.SelectedValue = CInt(myProgramState.LastMeteringMode)
            Me.cbxScannerModelName.SelectedValue = CInt(myProgramState.LastScannerModelName)
            If myProgramState.LastDerivativeQuality > 0 Then
                Me.tBar.Value = myProgramState.LastDerivativeQuality
            End If
        Catch ex As Exception
        End Try
        Me.lblDerivativeValue.Text = Me.tBar.Value.ToString

        XmlDoc.LoadXml(myDOStructure)
    End Sub

    Private Sub cBxScannermodelName_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxScannerModelName.SelectedIndexChanged
        Me.BindingContext(myTechnologicalPlatform, myTechnologicalPlatform.Tables(0).ToString).Position = cbxScannerModelName.SelectedIndex
    End Sub

    Private Sub cbxDerivative_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDerivative.CheckedChanged
        If Me.cbxDerivative.Checked Then
            Me.cbxQuality.Enabled = True
        Else
            Me.cbxQuality.Enabled = False
        End If
    End Sub

#End Region

#Region "Files Rename"

    Private Sub bttnFxRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnFxRename.Click
        Dim tv As New FilesRenameForm
        tv.ShowDialog(Me)
    End Sub

#End Region

#Region "Open"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Open()
    End Sub

    Private Sub Open()
        Dim openFileDialog As New OpenFileDialog

        Clear()
        Try
            openFileDialog.Multiselect = True

            openFileDialog.Filter = "Ficheiros TIF (*.tif,*.tiff)|*.tif;*.tiff|Ficheiros JPEG (*.jpg)|*.jpg|Ficheiros PDF (*.pdf)|*.pdf"
            openFileDialog.Title = "Abrir..."
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Me.btnSave.Enabled = True
            Else
                Exit Sub
            End If

            myFiles.AddRange(openFileDialog.FileNames)

            For Each file As String In openFileDialog.FileNames
                Dim FileName As String = Path.GetFileName(file)
                Dim lvi As ListViewItem = New ListViewItem(FileName)
                lvi.Tag = file
                Me.lvwDOFiles.Items.Insert(0, lvi)
                lvi.ImageIndex = 2
            Next

            '// is a PDF file, so we don't generate derivative
            If lblMimeType.Text.ToLower.EndsWith("raspdf") Then
                Me.cbxDerivative.Visible = False
                Me.cbxDerivative.Checked = False
            Else
                Me.cbxDerivative.Visible = True
                Me.cbxDerivative.Checked = True
            End If
        Catch ex As Exception
            MsgBox(InfoMessage("AddFile.FormatNotSupported"), MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region "SaveImage"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If cbxProfileID.Text.Length = 0 Then
            MsgBox(InfoMessage("AddFile.ChooseProfile"), MsgBoxStyle.Exclamation)
            Return
        End If

        pBar1.Visible = True
        pBar1.Minimum = 0
        pBar1.Maximum = myFiles.Count
        pBar1.Value = 1
        pBar1.Step = 1

        'Save images
        DisableFormCloseButton(Me)
        Thread = New Thread(AddressOf SaveImages)
        Thread.Start()
    End Sub


    Private Sub SaveImages()

        For i As Integer = 0 To myFiles.Count - 1
            SaveImage(myFiles(i))
            pBar1.PerformStep()
            If i = myFiles.Count - 1 Then
                database.setDOStructure(myDigitalObjectID, myDOStructure)
                FillDOFiles()
                Clear()
                myProgramState = New ProgramState
                myProgramState.LastProfileID = Me.cbxProfileID.SelectedValue
                myProgramState.LastLampType = Me.cbxLampType.SelectedValue
                myProgramState.LastScannerModelName = Me.cbxScannerModelName.SelectedValue
                myProgramState.LastAutoFocus = Me.cbxAutoFocus.SelectedValue
                myProgramState.LastMeteringMode = Me.cbxMeteringMode.SelectedValue
                myProgramState.LastDerivativeQuality = Me.tBar.Value.ToString 'Me.cbxQuality.SelectedIndex
                myProgramState.Save()

                'MsgBox(InfoMessage("AddFile.NewFile"), MsgBoxStyle.Information)
                Me.AssocitedFile = True
                Me.Close()
            End If
        Next
    End Sub


    Private Sub SaveImage(ByVal strFilePath As String)
        Dim strProjectDir As String
        Dim strCheckSum As String
        Dim intPage As Integer
        Dim ImageProcess As New MyImageProcessing
        Dim strDerivativeFileName, strThumbFileName As String
        Dim intFileID As Integer

        ' get Image info

        Dim strFileName As String = Path.GetFileName(strFilePath)
        Dim count As Integer = database.CountImages(myDigitalObjectID, strFileName)

        If count = 0 Then

            Dim objDOFile As DOFile = LoadDOFile(strFilePath)
            database.InsertDOFile(objDOFile)

            Log.Append(Constants.UserLogon, Log.AppendNode, "New file " & strFileName & " associated at digital object.")

            database.setQuantityOfTerminalObjects(myDigitalObjectID)
            Dim intLastFileID As Integer = database.LastImage()

            If lblMimeType.Text.ToLower.EndsWith("raspdf") Then
                Dim elem As XmlElement = XmlDoc.CreateElement("treenode")
                Dim att1 As XmlAttribute = XmlDoc.CreateAttribute("Text")
                att1.Value = strFileName
                Dim att2 As XmlAttribute = XmlDoc.CreateAttribute("Type")
                att2.Value = "transcription"
                Dim att3 As XmlAttribute = XmlDoc.CreateAttribute("id")
                att3.Value = "_" & intLastFileID
                elem.Attributes.Append(att1)
                elem.Attributes.Append(att2)
                elem.Attributes.Append(att3)
                XmlDoc.DocumentElement.FirstChild.AppendChild(elem)
            Else
                Dim elem As XmlElement = XmlDoc.CreateElement("treenode")
                Dim att1 As XmlAttribute = XmlDoc.CreateAttribute("Text")
                att1.Value = strFileName
                Dim att2 As XmlAttribute = XmlDoc.CreateAttribute("Type")
                att2.Value = "image"
                Dim att3 As XmlAttribute = XmlDoc.CreateAttribute("id")
                att3.Value = "_" & intLastFileID
                elem.Attributes.Append(att1)
                elem.Attributes.Append(att2)
                elem.Attributes.Append(att3)
                XmlDoc.DocumentElement.FirstChild.AppendChild(elem)
            End If

            Dim root As XmlNode = XmlDoc.DocumentElement
            myDOStructure = root.OuterXml()

            If Me.cbxDerivative.Checked = True And Not strFilePath.ToUpper.EndsWith(".PDF") Then
                Dim Res(2) As String

                Res = ImageProcess.GeneDerivative(strFilePath, myDOName, intLastFileID, myProjectID, Me.tBar.Value)
                database.setDerivative(Res(1), myDigitalObjectID, intLastFileID)
                database.setThumb(Res(2), myDigitalObjectID, intLastFileID)

            ElseIf strFilePath.ToUpper.EndsWith(".PDF") Then
                database.setFile(strFilePath, myDigitalObjectID, database.LastImage())
            End If
        Else
            If MsgBox(InfoMessage("AddFile.FileAlreadyExist") & ControlChars.NewLine & _
                InfoMessage("AddFile.Override"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim FileID As Int64 = database.getFileID(myDigitalObjectID, strFileName)

                Dim objDOFile As DOFile = LoadDOFile(strFilePath)
                objDOFile.FileID = FileID
                database.updateDOFile(objDOFile)

                Log.Append(Constants.UserLogon, Log.EditNode, "File " & strFileName & " associated at digital object was changed.")

                If Me.cbxDerivative.Checked = True And Not strFilePath.ToUpper.EndsWith(".PDF") Then
                    Dim Res(2) As String

                    Res = ImageProcess.GeneDerivative(strFilePath, myDOName, FileID, myProjectID, Me.tBar.Value)
                    database.setDerivative(Res(1), myDigitalObjectID, FileID)
                    database.setThumb(Res(2), myDigitalObjectID, FileID)

                ElseIf strFilePath.ToUpper.EndsWith(".PDF") Then
                    database.setFile(strFilePath, myDigitalObjectID, FileID)
                End If
            End If
        End If
    End Sub

#End Region


#Region "Fill DigitalizationProfiles"

    Private Sub FillDigitalizationProfiles()
        Dim myArray As New ArrayList
        Dim myData As DigitalizationProfileCollection = database.SelectDigitalizationProfiles

        Me.cbxProfileID.Items.Clear()

        For Each myDigitalizationProfile As DigitalizationProfile In myData
            myArray.Add(New DigitalizationProfile(myDigitalizationProfile.ProfileName, myDigitalizationProfile.ProfileID))
        Next
        myArray.Insert(0, New DigitalizationProfile("", 0))
        With Me.cbxProfileID
            .DisplayMember = "ProfileName"
            .ValueMember = "ProfileID"
            .DataSource = myArray
        End With
    End Sub

#End Region

#Region "Fill LampType"

    Private Sub FillLampType()
        Dim myArray As New ArrayList
        Dim mydata As LampTypeCollection = database.SelectAllLampTypes

        Me.cbxLampType.Items.Clear()

        For Each myLampType As LampType In mydata
            myArray.Add(New LampType(myLampType.Description, myLampType.LampTypeID))
        Next
        myArray.Insert(0, New LampType("", 0))
        With Me.cbxLampType
            .DisplayMember = "Description"
            .ValueMember = "LampTypeID"
            .DataSource = myArray
        End With
    End Sub

#End Region

#Region "Fill MeteringModes"

    Private Sub FillMeteringModes()
        Dim myArray As New ArrayList
        Dim mydata As MeteringModeCollection = database.SelectAllMeteringModes

        Me.cbxMeteringMode.Items.Clear()

        For Each myMeteringMode As MeteringMode In mydata
            myArray.Add(New MeteringMode(myMeteringMode.Description, myMeteringMode.MeteringModeID))
        Next
        myArray.Insert(0, New MeteringMode("", 0))
        With Me.cbxMeteringMode
            .DisplayMember = "Description"
            .ValueMember = "MeteringModeID"
            .DataSource = myArray
        End With
    End Sub

#End Region

#Region "Fill AutoFocus"

    Private Sub FillAutoFocus()
        Dim myArray As New ArrayList
        Dim mydata As AutoFocusCollection = database.SelectAllAutoFocus

        Me.cbxAutoFocus.Items.Clear()

        For Each myAutoFocus As AutoFocus In mydata
            myArray.Add(New AutoFocus(myAutoFocus.Description, myAutoFocus.AutoFocusID))
        Next
        myArray.Insert(0, New AutoFocus("", 0))
        With Me.cbxAutoFocus
            .DisplayMember = "Description"
            .ValueMember = "AutoFocusID"
            .DataSource = myArray
        End With
    End Sub

#End Region

#Region "Fill TechnologicalPlatform"

    Private Sub FillTechnologicalPlatform()
        myTechnologicalPlatform = database.SelectAllTechnologicalPlatform

        cbxScannerModelName.DataBindings.Clear()
        lblScannerManufacturer.DataBindings.Clear()
        lblDeviceSource.DataBindings.Clear()
        lblScanningSoftware.DataBindings.Clear()
        lblScanningSoftwareVersionNo.DataBindings.Clear()
        lblOperatingSystem.DataBindings.Clear()
        lblOSVersion.DataBindings.Clear()

        If myTechnologicalPlatform.Tables.Count <> 0 Then
            cbxScannerModelName.DataSource = myTechnologicalPlatform.Tables(0)
            cbxScannerModelName.DisplayMember = "ScannerModelName"
            cbxScannerModelName.ValueMember = "TPlatformID"
            lblDeviceSource.DataBindings.Add(New Binding("Text", myTechnologicalPlatform, myTechnologicalPlatform.Tables(0).ToString & ".DeviceSource"))
            lblScannerManufacturer.DataBindings.Add(New Binding("Text", myTechnologicalPlatform, myTechnologicalPlatform.Tables(0).ToString & ".ScannerManufacturer"))
            lblScanningSoftware.DataBindings.Add(New Binding("Text", myTechnologicalPlatform, myTechnologicalPlatform.Tables(0).ToString & ".ScanningSoftware"))
            lblScanningSoftwareVersionNo.DataBindings.Add(New Binding("Text", myTechnologicalPlatform, myTechnologicalPlatform.Tables(0).ToString & ".ScanningSoftwareVersionNo"))
            lblOperatingSystem.DataBindings.Add(New Binding("Text", myTechnologicalPlatform, myTechnologicalPlatform.Tables(0).ToString & ".OperatingSystem"))
            lblOSVersion.DataBindings.Add(New Binding("Text", myTechnologicalPlatform, myTechnologicalPlatform.Tables(0).ToString & ".OperatingSystemVersion"))
        End If
    End Sub


#End Region

#Region "Fill DOFiles"

    Private Sub CreateLvwDOFiles()
        Me.lvwDOFiles.View = View.Details
        Me.lvwDOFiles.LabelEdit = False
        Me.lvwDOFiles.FullRowSelect = True
        Me.lvwDOFiles.MultiSelect = False

        ' Create columns for the items and subitems.
        Me.lvwDOFiles.Columns.Add("Ficheiros", Me.lvwDOFiles.Width - 10, HorizontalAlignment.Left)
        Me.lvwDOFiles.Columns.Add("", 10, HorizontalAlignment.Left)
    End Sub

    Private Sub FillDOFiles()
        Dim isDerivative As Integer
        Dim DOtoCheck As Boolean = False
        Dim ds As DataSet = database.SelectAllDOImagesByDigitalObjectID(myDigitalObjectID)
        Dim myTable As DataTable = ds.Tables(0)

        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            If (myRow.RowState <> DataRowState.Deleted) Then
                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("Name").ToString())
                lvi.Tag = myRow.Item("FileID")
                Me.lvwDOFiles.Items.Add(lvi)
                isDerivative = database.haveDerivative(myRow.Item("FileID"))
                If isDerivative = 0 Then
                    lvi.ImageIndex = 0
                Else
                    lvi.ImageIndex = 1
                End If
            End If
        Next
    End Sub

#End Region

#Region "Derivative quality"

    Private Sub tBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBar.Scroll
        Me.lblDerivativeValue.Text = Me.tBar.Value.ToString
    End Sub

#End Region

#Region "Clear"

    Sub Clear()
        txtName.Clear()
        lblColorSpace.Text = ""
        lblResolution.Text = ""
        lblWidth.Text = ""
        lblHeight.Text = ""
        lblBitDepth.Text = ""
        lblMimeType.Text = ""
        lblSize.Text = ""
        lblCompression.Text = ""
    End Sub

#End Region

#Region "Other functions"

    Public Function GetFileSize(ByVal fileName As String) As Int64
        Return Math.Round(FileLen(fileName))
    End Function

    Public Function BytesToKB(ByVal intSize As Long) As Int64
        Return Math.Round(intSize / 1024)
    End Function

    Public Function GetCompression(ByVal val As String) '(ByVal image As LEAD.Drawing.Image) As String
        If val = "None" Then
            Return "Sem"
        Else
            Return val
        End If
    End Function

    Public Function GetColorSpace(ByVal val As String) '(ByVal image As LEAD.Drawing.Image) As String
        If val = 1 Then 'image.GetPixelFormatSize(PictureBox.LEADImage.PixelFormat.GetHashCode) = 1 Then
            Return "BW"
        ElseIf val = 8 Then 'Image.GetPixelFormatSize(PictureBox.LEADImage.PixelFormat.GetHashCode) = 8 Then
            Return "Gray"
        ElseIf val = 24 Then 'Image.GetPixelFormatSize(PictureBox.LEADImage.PixelFormat.GetHashCode) = 24 Then
            Return "RGB"
        End If
    End Function

    Property FilePathName()
        Get
            Return myPathName
        End Get
        Set(ByVal Value)
            myPathName = Value
        End Set
    End Property

#End Region

#Region "LoadFileInfo"

    Private Function LoadDOFile(ByVal strFilePath As String) As DOFile
        Try
            Dim objImage As New DOFile
            Dim intPage As Integer

            Dim strFileFullPath As String = Path.GetFullPath(strFilePath)
            Dim strFileName As String = Path.GetFileName(strFilePath)
            Dim strCheckSum As String = database.generateHash(strFileFullPath)

            objImage.DigitalObjectID = myDigitalObjectID
            objImage.CreationDateTime = DateToDB(Now)
            objImage.Name = strFileName

            If strFileName.ToUpper.EndsWith(".PDF") Then
                objImage.ImageSize = GetFileSize(strFilePath)
                objImage.MIMEType = "PDF"
                objImage.LampTypeID = "NULL"
                objImage.ProfileID = "NULL"
                objImage.MeteringModeID = "NULL"
                objImage.AutoFocusID = "NULL"
                objImage.TPlatformID = "NULL"
            Else
                Dim r As ExifExtractor.EXIFextractor = New ExifExtractor.EXIFextractor(strFilePath)

                objImage.ImageSize = GetFileSize(strFilePath)
                objImage.Resolution = r.Resolution
                objImage.BitsPerPixel = r.BitsPerPixel
                objImage.MIMEType = r.Format
                objImage.Compression = r.Compression

                objImage.ColorSpace = r.ColorSpace
                objImage.ImageHeight = r.Height
                objImage.ImageWidth = r.Width
                objImage.LampTypeID = IntToDB(Me.cbxLampType.SelectedValue)
                objImage.ProfileID = IntToDB(Me.cbxProfileID.SelectedValue)

                objImage.FNumber = r.FNumber
                objImage.ExposureTime = r.ExposureTime
                objImage.MeteringModeID = IntToDB(Me.cbxMeteringMode.SelectedValue)
                objImage.FocalLength = r.FocalLength
                objImage.AutoFocusID = IntToDB(Me.cbxAutoFocus.SelectedValue)

                objImage.TPlatformID = IntToDB(Me.cbxScannerModelName.SelectedValue)

                objImage.ProcessingDateTime = Me.txtProcessingDateTime.Text
                objImage.ProcessingActions = Me.txtProcessingActions.Text
                objImage.ProcessingSoftwareName = Me.txtProcessingSoftwareName.Text
                objImage.ProcessingSoftwareVersion = Me.txtProcessingSoftwareversion.Text
                objImage.ProcessingOSName = Me.txtProcessingOSName.Text
                objImage.ProcessingOSVersion = Me.txtProcessingOSVersion.Text
                objImage.ColorManager = Me.txtColorManager.Text
            End If

            objImage.CheckSumCreationDateTime = DateToDB(Now)
            objImage.CheckSumValue = strCheckSum
            objImage.UserName = Constants.UserLogon

            Return objImage
        Catch ex As Exception
            MsgBox(InfoMessage("AddFile.FormatNotSupported"), MsgBoxStyle.Critical)
        End Try
    End Function

#End Region

#Region "Fill File Info"

    Private Sub lvwDOFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDOFiles.SelectedIndexChanged
        If Me.lvwDOFiles.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = Me.lvwDOFiles.SelectedItems(0)
            Select Case selectedItem.ImageIndex
                Case 0, 1
                    BindMetadataImage(selectedItem.Tag)
                Case 2
                    FillFileInfo(selectedItem.Tag)
            End Select
        End If
    End Sub

    Private Sub FillFileInfo(ByVal strFilePath As String)
        Try
            Dim intPage As Integer

            If strFilePath.ToUpper.EndsWith(".PDF") Then
                Me.lblSize.Text = BytesToKB(GetFileSize(strFilePath))
                Me.lblMimeType.Text = "PDF"
            Else
                Dim r As ExifExtractor.EXIFextractor = New ExifExtractor.EXIFextractor(strFilePath)

                Me.lblSize.Text = BytesToKB(GetFileSize(strFilePath))
                Me.lblResolution.Text = r.Resolution
                Me.lblBitDepth.Text = r.BitsPerPixel
                Me.lblMimeType.Text = r.Format
                Me.lblCompression.Text = r.Compression
                Me.lblColorSpace.Text = r.ColorSpace
                Me.lblHeight.Text = r.Height
                Me.lblWidth.Text = r.Width
                Me.txtFNumber.Text = r.FNumber
                Me.txtExposureTime.Text = r.ExposureTime
                Me.txtFocalLength.Text = r.FocalLength
            End If
        Catch ex As Exception
            MsgBox(InfoMessage("AddFile.FormatNotSupported"), MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BindMetadataImage(ByVal DOFileId As Int64)
        Try
            Dim myMetadataImage As DataSet = database.SelectMetadataImageByID(myDigitalObjectID, DOFileId)

            If myMetadataImage.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = myMetadataImage.Tables(0).Rows(0)

                Me.lblSize.Text = BytesToKB(DBToStr(row.Item("ImageSize")))
                Me.lblResolution.Text = DBToStr(row.Item("Resolution"))
                Me.lblBitDepth.Text = DBToStr(row.Item("BitDepth"))
                Me.lblMimeType.Text = DBToStr(row.Item("MIMEType"))
                Me.lblCompression.Text = DBToStr(row.Item("Compression"))

                Me.lblColorSpace.Text = DBToStr(row.Item("ColorSpace"))
                Me.lblHeight.Text = DBToStr(row.Item("ImageHeight"))
                Me.lblWidth.Text = DBToStr(row.Item("ImageWidth"))
                Me.cbxLampType.SelectedValue = DBToInt(row.Item("LampTypeID"))
                Me.cbxProfileID.SelectedValue = DBToInt(row.Item("ProfileID"))

                Me.txtFNumber.Text = DBToStr(row.Item("FNumber"))
                Me.txtExposureTime.Text = DBToStr(row.Item("ExposureTime"))
                Me.cbxMeteringMode.SelectedValue = DBToInt(row.Item("MeteringModeID"))
                Me.txtFocalLength.Text = DBToStr(row.Item("FocalLength"))
                Me.cbxAutoFocus.SelectedValue = DBToInt(row.Item("AutoFocusID"))

                Me.cbxScannerModelName.SelectedValue = DBToInt(row.Item("TPlatformID"))

                Me.txtProcessingDateTime.Text = DBToStr(row.Item("ProcessingDateTime"))
                Me.txtProcessingActions.Text = DBToStr(row.Item("ProcessingActions"))
                Me.txtProcessingSoftwareName.Text = DBToStr(row.Item("ProcessingSoftwareName"))
                Me.txtProcessingSoftwareversion.Text = DBToStr(row.Item("ProcessingSoftwareVersion"))
                Me.txtProcessingOSName.Text = DBToStr(row.Item("ProcessingOSName"))
                Me.txtProcessingOSVersion.Text = DBToStr(row.Item("ProcessingOSVersion"))
                Me.txtColorManager.Text = DBToStr(row.Item("ColorManager"))
            End If
        Catch ex As Exception
            MsgBox(InfoMessage("AddFile.FormatNotSupported"), MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region " Enable\Disable a Form's Close Button "

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer

    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    Private Const SC_CLOSE As Integer = &HF060

    Private Const MF_BYCOMMAND As Integer = &H0

    Private Const MF_GRAYED As Integer = &H1

    Private Const MF_ENABLED As Integer = &H0

    Public Sub DisableFormCloseButton(ByVal form As System.Windows.Forms.Form)

        ' The return value specifies the previous state of the menu item (it is either

        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates that the menu item does not exist.

        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)

            Case MF_ENABLED

            Case MF_GRAYED

            Case &HFFFFFFFF

                Throw New Exception("The Close menu item does not exist.")

            Case Else

        End Select

    End Sub

    Public Sub EnableFormCloseButton(ByVal form As System.Windows.Forms.Form)

        EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND)

    End Sub

#End Region

End Class

