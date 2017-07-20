
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

Public Class DigitalizationProfilesForm
    Inherits System.Windows.Forms.Form

    Private database As New SqlCommands
    Private mydata As New DataSet
    Private configReader As System.Configuration.AppSettingsReader = _
                    New System.Configuration.AppSettingsReader
    Public strDigitalizationProfileValue As String = ""
    Public strDigitalizationProfileText As String
    Public choose As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New() 'ByVal scanner As scanner)
        MyBase.New()
        'Me.scanner = scanner

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
    Friend WithEvents lblBlur As System.Windows.Forms.Label
    Friend WithEvents lblSharpness As System.Windows.Forms.Label
    Friend WithEvents lblContrast As System.Windows.Forms.Label
    Friend WithEvents lblBrightness As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblProfileName As System.Windows.Forms.Label
    Friend WithEvents lblDescription2 As System.Windows.Forms.Label
    Friend WithEvents lblProfileName2 As System.Windows.Forms.Label
    Friend WithEvents lblBrightness2 As System.Windows.Forms.Label
    Friend WithEvents lblContrast2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBrightness2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtContrast2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtSharpness2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtBlur2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblBlur2 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lbxDigitalizationProfiles As System.Windows.Forms.ListBox
    Friend WithEvents gbxDigitalizationProfiles As System.Windows.Forms.GroupBox
    Friend WithEvents txtBrightness As MGOD.ColorTextBox
    Friend WithEvents txtContrast As MGOD.ColorTextBox
    Friend WithEvents txtSharpness As MGOD.ColorTextBox
    Friend WithEvents txtBlur As MGOD.ColorTextBox
    Friend WithEvents txtProfileName As MGOD.ColorTextBox
    Friend WithEvents txtProfileName2 As MGOD.ColorTextBox
    Friend WithEvents txtDescription As MGOD.ColorTextBox
    Friend WithEvents txtDescription2 As MGOD.ColorTextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnChange As MGOD.ColorButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancelNew As System.Windows.Forms.Button
    Friend WithEvents gbxNewDigitalizationProfile As System.Windows.Forms.GroupBox
    Friend WithEvents cbxRotation As System.Windows.Forms.CheckBox
    Friend WithEvents cbxRotation2 As System.Windows.Forms.CheckBox
    Friend WithEvents lblBitDepth2 As System.Windows.Forms.Label
    Friend WithEvents txtBitDepth2 As MGOD.ColorTextBox
    Friend WithEvents lblResolution2 As System.Windows.Forms.Label
    Friend WithEvents txtResolution2 As MGOD.ColorTextBox
    Friend WithEvents lblFormat2 As System.Windows.Forms.Label
    Friend WithEvents txtFormat2 As MGOD.ColorTextBox
    Friend WithEvents lblCompression2 As System.Windows.Forms.Label
    Friend WithEvents txtCompression2 As MGOD.ColorTextBox
    Friend WithEvents lblCompression As System.Windows.Forms.Label
    Friend WithEvents lblBitDepth As System.Windows.Forms.Label
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents txtCompression As MGOD.ColorTextBox
    Friend WithEvents txtBitDepth As MGOD.ColorTextBox
    Friend WithEvents txtFormat As MGOD.ColorTextBox
    Friend WithEvents txtResolution As MGOD.ColorTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFormat1 As System.Windows.Forms.Label
    Friend WithEvents lblResolution1 As System.Windows.Forms.Label
    Friend WithEvents lblBitDepth1 As System.Windows.Forms.Label
    Friend WithEvents lblProfileName1 As System.Windows.Forms.Label
    Friend WithEvents lblDescription1 As System.Windows.Forms.Label
    Friend WithEvents lblCompression1 As System.Windows.Forms.Label
    Friend WithEvents lblBlur1 As System.Windows.Forms.Label
    Friend WithEvents lblContrast1 As System.Windows.Forms.Label
    Friend WithEvents lblSharpness1 As System.Windows.Forms.Label
    Friend WithEvents gbxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblBrightness1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelUpdate As System.Windows.Forms.Button
    Friend WithEvents lBlSharpen2 As System.Windows.Forms.Label
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents btnDelete As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DigitalizationProfilesForm))
        Me.btnNew = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnChange = New MGOD.ColorButton
        Me.gbxInfo = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCompression = New System.Windows.Forms.Label
        Me.lblCompression1 = New System.Windows.Forms.Label
        Me.lblBitDepth = New System.Windows.Forms.Label
        Me.lblFormat = New System.Windows.Forms.Label
        Me.lblResolution = New System.Windows.Forms.Label
        Me.lblFormat1 = New System.Windows.Forms.Label
        Me.lblResolution1 = New System.Windows.Forms.Label
        Me.lblBitDepth1 = New System.Windows.Forms.Label
        Me.txtCompression = New MGOD.ColorTextBox
        Me.txtBitDepth = New MGOD.ColorTextBox
        Me.txtFormat = New MGOD.ColorTextBox
        Me.txtResolution = New MGOD.ColorTextBox
        Me.lblProfileName1 = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtDescription = New MGOD.ColorTextBox
        Me.lblBlur = New System.Windows.Forms.Label
        Me.lblBlur1 = New System.Windows.Forms.Label
        Me.lblSharpness = New System.Windows.Forms.Label
        Me.lblContrast = New System.Windows.Forms.Label
        Me.lblBrightness = New System.Windows.Forms.Label
        Me.lblDescription1 = New System.Windows.Forms.Label
        Me.lblContrast1 = New System.Windows.Forms.Label
        Me.lblBrightness1 = New System.Windows.Forms.Label
        Me.lblSharpness1 = New System.Windows.Forms.Label
        Me.txtBlur = New MGOD.ColorTextBox
        Me.txtSharpness = New MGOD.ColorTextBox
        Me.txtContrast = New MGOD.ColorTextBox
        Me.txtBrightness = New MGOD.ColorTextBox
        Me.lblProfileName = New System.Windows.Forms.Label
        Me.txtProfileName = New MGOD.ColorTextBox
        Me.cbxRotation = New System.Windows.Forms.CheckBox
        Me.btnCancelUpdate = New System.Windows.Forms.Button
        Me.lbxDigitalizationProfiles = New System.Windows.Forms.ListBox
        Me.gbxDigitalizationProfiles = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.gbxNewDigitalizationProfile = New System.Windows.Forms.GroupBox
        Me.lblCompression2 = New System.Windows.Forms.Label
        Me.txtCompression2 = New MGOD.ColorTextBox
        Me.lblFormat2 = New System.Windows.Forms.Label
        Me.txtFormat2 = New MGOD.ColorTextBox
        Me.lblBitDepth2 = New System.Windows.Forms.Label
        Me.txtBitDepth2 = New MGOD.ColorTextBox
        Me.lblResolution2 = New System.Windows.Forms.Label
        Me.txtResolution2 = New MGOD.ColorTextBox
        Me.txtDescription2 = New MGOD.ColorTextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancelNew = New System.Windows.Forms.Button
        Me.lblDescription2 = New System.Windows.Forms.Label
        Me.txtSharpness2 = New System.Windows.Forms.NumericUpDown
        Me.txtBlur2 = New System.Windows.Forms.NumericUpDown
        Me.txtBrightness2 = New System.Windows.Forms.NumericUpDown
        Me.txtProfileName2 = New MGOD.ColorTextBox
        Me.lblProfileName2 = New System.Windows.Forms.Label
        Me.lBlSharpen2 = New System.Windows.Forms.Label
        Me.lblBlur2 = New System.Windows.Forms.Label
        Me.lblBrightness2 = New System.Windows.Forms.Label
        Me.txtContrast2 = New System.Windows.Forms.NumericUpDown
        Me.lblContrast2 = New System.Windows.Forms.Label
        Me.cbxRotation2 = New System.Windows.Forms.CheckBox
        Me.gbxInfo.SuspendLayout()
        Me.gbxDigitalizationProfiles.SuspendLayout()
        Me.gbxNewDigitalizationProfile.SuspendLayout()
        CType(Me.txtSharpness2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBlur2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBrightness2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContrast2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.BackColor = System.Drawing.Color.White
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.ImageIndex = 0
        Me.btnNew.ImageList = Me.imglButtons
        Me.btnNew.Location = New System.Drawing.Point(16, 35)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(152, 25)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = CType(configurationAppSettings.GetValue("DP.btnNewProfile.Text", GetType(System.String)), String)
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnChange
        '
        Me.btnChange.BackColor = System.Drawing.Color.White
        Me.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChange.ImageIndex = 3
        Me.btnChange.ImageList = Me.imglButtons
        Me.btnChange.Location = New System.Drawing.Point(200, 305)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(80, 25)
        Me.btnChange.TabIndex = 11
        Me.btnChange.Text = "Editar"
        Me.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbxInfo
        '
        Me.gbxInfo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxInfo.Controls.Add(Me.GroupBox1)
        Me.gbxInfo.Controls.Add(Me.lblCompression)
        Me.gbxInfo.Controls.Add(Me.lblCompression1)
        Me.gbxInfo.Controls.Add(Me.lblBitDepth)
        Me.gbxInfo.Controls.Add(Me.lblFormat)
        Me.gbxInfo.Controls.Add(Me.lblResolution)
        Me.gbxInfo.Controls.Add(Me.lblFormat1)
        Me.gbxInfo.Controls.Add(Me.lblResolution1)
        Me.gbxInfo.Controls.Add(Me.lblBitDepth1)
        Me.gbxInfo.Controls.Add(Me.txtCompression)
        Me.gbxInfo.Controls.Add(Me.txtBitDepth)
        Me.gbxInfo.Controls.Add(Me.txtFormat)
        Me.gbxInfo.Controls.Add(Me.txtResolution)
        Me.gbxInfo.Controls.Add(Me.lblProfileName1)
        Me.gbxInfo.Controls.Add(Me.lblDescription)
        Me.gbxInfo.Controls.Add(Me.txtDescription)
        Me.gbxInfo.Controls.Add(Me.lblBlur)
        Me.gbxInfo.Controls.Add(Me.lblBlur1)
        Me.gbxInfo.Controls.Add(Me.lblSharpness)
        Me.gbxInfo.Controls.Add(Me.lblContrast)
        Me.gbxInfo.Controls.Add(Me.lblBrightness)
        Me.gbxInfo.Controls.Add(Me.lblDescription1)
        Me.gbxInfo.Controls.Add(Me.lblContrast1)
        Me.gbxInfo.Controls.Add(Me.lblBrightness1)
        Me.gbxInfo.Controls.Add(Me.lblSharpness1)
        Me.gbxInfo.Controls.Add(Me.txtBlur)
        Me.gbxInfo.Controls.Add(Me.txtSharpness)
        Me.gbxInfo.Controls.Add(Me.txtContrast)
        Me.gbxInfo.Controls.Add(Me.txtBrightness)
        Me.gbxInfo.Controls.Add(Me.lblProfileName)
        Me.gbxInfo.Controls.Add(Me.txtProfileName)
        Me.gbxInfo.Controls.Add(Me.cbxRotation)
        Me.gbxInfo.Controls.Add(Me.btnChange)
        Me.gbxInfo.Controls.Add(Me.btnCancelUpdate)
        Me.gbxInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxInfo.ForeColor = System.Drawing.Color.Black
        Me.gbxInfo.Location = New System.Drawing.Point(201, 14)
        Me.gbxInfo.Name = "gbxInfo"
        Me.gbxInfo.Size = New System.Drawing.Size(389, 340)
        Me.gbxInfo.TabIndex = 17
        Me.gbxInfo.TabStop = False
        Me.gbxInfo.Text = "Informação"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(13, 288)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 3)
        Me.GroupBox1.TabIndex = 101
        Me.GroupBox1.TabStop = False
        '
        'lblCompression
        '
        Me.lblCompression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompression.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompression.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCompression.Location = New System.Drawing.Point(298, 168)
        Me.lblCompression.Name = "lblCompression"
        Me.lblCompression.Size = New System.Drawing.Size(69, 20)
        Me.lblCompression.TabIndex = 100
        Me.lblCompression.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompression1
        '
        Me.lblCompression1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompression1.Location = New System.Drawing.Point(224, 168)
        Me.lblCompression1.Name = "lblCompression1"
        Me.lblCompression1.Size = New System.Drawing.Size(72, 17)
        Me.lblCompression1.TabIndex = 99
        Me.lblCompression1.Text = "Compressão"
        Me.lblCompression1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBitDepth
        '
        Me.lblBitDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBitDepth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBitDepth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBitDepth.Location = New System.Drawing.Point(107, 168)
        Me.lblBitDepth.Name = "lblBitDepth"
        Me.lblBitDepth.Size = New System.Drawing.Size(69, 20)
        Me.lblBitDepth.TabIndex = 98
        Me.lblBitDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFormat
        '
        Me.lblFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFormat.Location = New System.Drawing.Point(298, 136)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(69, 20)
        Me.lblFormat.TabIndex = 96
        Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResolution
        '
        Me.lblResolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolution.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblResolution.Location = New System.Drawing.Point(107, 136)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(69, 20)
        Me.lblResolution.TabIndex = 97
        Me.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFormat1
        '
        Me.lblFormat1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormat1.Location = New System.Drawing.Point(224, 136)
        Me.lblFormat1.Name = "lblFormat1"
        Me.lblFormat1.Size = New System.Drawing.Size(72, 20)
        Me.lblFormat1.TabIndex = 95
        Me.lblFormat1.Text = "Formato"
        Me.lblFormat1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResolution1
        '
        Me.lblResolution1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolution1.Location = New System.Drawing.Point(32, 136)
        Me.lblResolution1.Name = "lblResolution1"
        Me.lblResolution1.Size = New System.Drawing.Size(72, 20)
        Me.lblResolution1.TabIndex = 89
        Me.lblResolution1.Text = "Resolução"
        Me.lblResolution1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBitDepth1
        '
        Me.lblBitDepth1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBitDepth1.Location = New System.Drawing.Point(32, 168)
        Me.lblBitDepth1.Name = "lblBitDepth1"
        Me.lblBitDepth1.Size = New System.Drawing.Size(72, 24)
        Me.lblBitDepth1.TabIndex = 90
        Me.lblBitDepth1.Text = "Profundidade bits"
        Me.lblBitDepth1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompression
        '
        Me.txtCompression.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCompression.BackColor = System.Drawing.Color.White
        Me.txtCompression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompression.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompression.Location = New System.Drawing.Point(298, 168)
        Me.txtCompression.Name = "txtCompression"
        Me.txtCompression.Size = New System.Drawing.Size(69, 20)
        Me.txtCompression.TabIndex = 94
        Me.txtCompression.Text = ""
        '
        'txtBitDepth
        '
        Me.txtBitDepth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBitDepth.BackColor = System.Drawing.Color.White
        Me.txtBitDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBitDepth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBitDepth.Location = New System.Drawing.Point(107, 168)
        Me.txtBitDepth.Name = "txtBitDepth"
        Me.txtBitDepth.Size = New System.Drawing.Size(69, 20)
        Me.txtBitDepth.TabIndex = 93
        Me.txtBitDepth.Text = ""
        '
        'txtFormat
        '
        Me.txtFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFormat.BackColor = System.Drawing.Color.White
        Me.txtFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormat.Location = New System.Drawing.Point(298, 136)
        Me.txtFormat.Name = "txtFormat"
        Me.txtFormat.Size = New System.Drawing.Size(69, 20)
        Me.txtFormat.TabIndex = 92
        Me.txtFormat.Text = ""
        '
        'txtResolution
        '
        Me.txtResolution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResolution.BackColor = System.Drawing.Color.White
        Me.txtResolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResolution.Location = New System.Drawing.Point(107, 136)
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.Size = New System.Drawing.Size(69, 20)
        Me.txtResolution.TabIndex = 91
        Me.txtResolution.Text = ""
        '
        'lblProfileName1
        '
        Me.lblProfileName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfileName1.Location = New System.Drawing.Point(32, 35)
        Me.lblProfileName1.Name = "lblProfileName1"
        Me.lblProfileName1.Size = New System.Drawing.Size(72, 20)
        Me.lblProfileName1.TabIndex = 88
        Me.lblProfileName1.Text = "Nome Perfil"
        Me.lblProfileName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription
        '
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDescription.Location = New System.Drawing.Point(107, 69)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(260, 48)
        Me.lblDescription.TabIndex = 87
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(107, 69)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(260, 48)
        Me.txtDescription.TabIndex = 86
        Me.txtDescription.Text = ""
        '
        'lblBlur
        '
        Me.lblBlur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBlur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBlur.Location = New System.Drawing.Point(298, 232)
        Me.lblBlur.Name = "lblBlur"
        Me.lblBlur.Size = New System.Drawing.Size(69, 20)
        Me.lblBlur.TabIndex = 76
        Me.lblBlur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBlur1
        '
        Me.lblBlur1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlur1.Location = New System.Drawing.Point(224, 232)
        Me.lblBlur1.Name = "lblBlur1"
        Me.lblBlur1.Size = New System.Drawing.Size(72, 20)
        Me.lblBlur1.TabIndex = 75
        Me.lblBlur1.Text = "Desfocagem"
        Me.lblBlur1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSharpness
        '
        Me.lblSharpness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSharpness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSharpness.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSharpness.Location = New System.Drawing.Point(107, 232)
        Me.lblSharpness.Name = "lblSharpness"
        Me.lblSharpness.Size = New System.Drawing.Size(69, 20)
        Me.lblSharpness.TabIndex = 71
        Me.lblSharpness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContrast
        '
        Me.lblContrast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContrast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContrast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblContrast.Location = New System.Drawing.Point(298, 200)
        Me.lblContrast.Name = "lblContrast"
        Me.lblContrast.Size = New System.Drawing.Size(69, 20)
        Me.lblContrast.TabIndex = 70
        Me.lblContrast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBrightness
        '
        Me.lblBrightness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrightness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrightness.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBrightness.Location = New System.Drawing.Point(107, 200)
        Me.lblBrightness.Name = "lblBrightness"
        Me.lblBrightness.Size = New System.Drawing.Size(69, 20)
        Me.lblBrightness.TabIndex = 70
        Me.lblBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription1
        '
        Me.lblDescription1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription1.Location = New System.Drawing.Point(32, 69)
        Me.lblDescription1.Name = "lblDescription1"
        Me.lblDescription1.Size = New System.Drawing.Size(72, 20)
        Me.lblDescription1.TabIndex = 65
        Me.lblDescription1.Text = "Descrição"
        Me.lblDescription1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContrast1
        '
        Me.lblContrast1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContrast1.Location = New System.Drawing.Point(224, 200)
        Me.lblContrast1.Name = "lblContrast1"
        Me.lblContrast1.Size = New System.Drawing.Size(72, 20)
        Me.lblContrast1.TabIndex = 63
        Me.lblContrast1.Text = "Contraste"
        Me.lblContrast1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBrightness1
        '
        Me.lblBrightness1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrightness1.Location = New System.Drawing.Point(32, 200)
        Me.lblBrightness1.Name = "lblBrightness1"
        Me.lblBrightness1.Size = New System.Drawing.Size(72, 20)
        Me.lblBrightness1.TabIndex = 3
        Me.lblBrightness1.Text = "Brilho"
        Me.lblBrightness1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSharpness1
        '
        Me.lblSharpness1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSharpness1.Location = New System.Drawing.Point(32, 232)
        Me.lblSharpness1.Name = "lblSharpness1"
        Me.lblSharpness1.Size = New System.Drawing.Size(72, 20)
        Me.lblSharpness1.TabIndex = 4
        Me.lblSharpness1.Text = "Focagem"
        Me.lblSharpness1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBlur
        '
        Me.txtBlur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBlur.BackColor = System.Drawing.Color.White
        Me.txtBlur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBlur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBlur.Location = New System.Drawing.Point(298, 232)
        Me.txtBlur.Name = "txtBlur"
        Me.txtBlur.Size = New System.Drawing.Size(69, 20)
        Me.txtBlur.TabIndex = 9
        Me.txtBlur.Text = ""
        '
        'txtSharpness
        '
        Me.txtSharpness.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSharpness.BackColor = System.Drawing.Color.White
        Me.txtSharpness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSharpness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSharpness.Location = New System.Drawing.Point(107, 232)
        Me.txtSharpness.Name = "txtSharpness"
        Me.txtSharpness.Size = New System.Drawing.Size(69, 20)
        Me.txtSharpness.TabIndex = 8
        Me.txtSharpness.Text = ""
        '
        'txtContrast
        '
        Me.txtContrast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContrast.BackColor = System.Drawing.Color.White
        Me.txtContrast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContrast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContrast.Location = New System.Drawing.Point(298, 200)
        Me.txtContrast.Name = "txtContrast"
        Me.txtContrast.Size = New System.Drawing.Size(69, 20)
        Me.txtContrast.TabIndex = 7
        Me.txtContrast.Text = ""
        '
        'txtBrightness
        '
        Me.txtBrightness.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBrightness.BackColor = System.Drawing.Color.White
        Me.txtBrightness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBrightness.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrightness.Location = New System.Drawing.Point(107, 200)
        Me.txtBrightness.Name = "txtBrightness"
        Me.txtBrightness.Size = New System.Drawing.Size(69, 20)
        Me.txtBrightness.TabIndex = 6
        Me.txtBrightness.Text = ""
        '
        'lblProfileName
        '
        Me.lblProfileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProfileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfileName.ForeColor = System.Drawing.Color.Black
        Me.lblProfileName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProfileName.Location = New System.Drawing.Point(107, 35)
        Me.lblProfileName.Name = "lblProfileName"
        Me.lblProfileName.Size = New System.Drawing.Size(260, 20)
        Me.lblProfileName.TabIndex = 84
        Me.lblProfileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProfileName
        '
        Me.txtProfileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfileName.BackColor = System.Drawing.Color.White
        Me.txtProfileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProfileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProfileName.Location = New System.Drawing.Point(107, 35)
        Me.txtProfileName.Name = "txtProfileName"
        Me.txtProfileName.Size = New System.Drawing.Size(260, 20)
        Me.txtProfileName.TabIndex = 4
        Me.txtProfileName.Text = ""
        '
        'cbxRotation
        '
        Me.cbxRotation.Enabled = False
        Me.cbxRotation.Location = New System.Drawing.Point(107, 264)
        Me.cbxRotation.Name = "cbxRotation"
        Me.cbxRotation.Size = New System.Drawing.Size(117, 20)
        Me.cbxRotation.TabIndex = 20
        Me.cbxRotation.Text = CType(configurationAppSettings.GetValue("DP.cbxRotation.Text", GetType(System.String)), String)
        '
        'btnCancelUpdate
        '
        Me.btnCancelUpdate.BackColor = System.Drawing.Color.White
        Me.btnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelUpdate.ImageIndex = 5
        Me.btnCancelUpdate.ImageList = Me.imglButtons
        Me.btnCancelUpdate.Location = New System.Drawing.Point(287, 305)
        Me.btnCancelUpdate.Name = "btnCancelUpdate"
        Me.btnCancelUpdate.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelUpdate.TabIndex = 12
        Me.btnCancelUpdate.Text = CType(configurationAppSettings.GetValue("btnClose.Text", GetType(System.String)), String)
        Me.btnCancelUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbxDigitalizationProfiles
        '
        Me.lbxDigitalizationProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxDigitalizationProfiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbxDigitalizationProfiles.Location = New System.Drawing.Point(16, 67)
        Me.lbxDigitalizationProfiles.Name = "lbxDigitalizationProfiles"
        Me.lbxDigitalizationProfiles.Size = New System.Drawing.Size(152, 223)
        Me.lbxDigitalizationProfiles.TabIndex = 2
        '
        'gbxDigitalizationProfiles
        '
        Me.gbxDigitalizationProfiles.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxDigitalizationProfiles.Controls.Add(Me.btnDelete)
        Me.gbxDigitalizationProfiles.Controls.Add(Me.lbxDigitalizationProfiles)
        Me.gbxDigitalizationProfiles.Controls.Add(Me.btnNew)
        Me.gbxDigitalizationProfiles.Location = New System.Drawing.Point(9, 14)
        Me.gbxDigitalizationProfiles.Name = "gbxDigitalizationProfiles"
        Me.gbxDigitalizationProfiles.Size = New System.Drawing.Size(185, 340)
        Me.gbxDigitalizationProfiles.TabIndex = 20
        Me.gbxDigitalizationProfiles.TabStop = False
        Me.gbxDigitalizationProfiles.Text = "Perfis de digitalização"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.White
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imglButtons
        Me.btnDelete.Location = New System.Drawing.Point(16, 305)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(152, 25)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = CType(configurationAppSettings.GetValue("DP.btnDeleteProfile.Text", GetType(System.String)), String)
        '
        'gbxNewDigitalizationProfile
        '
        Me.gbxNewDigitalizationProfile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblCompression2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtCompression2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblFormat2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtFormat2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblBitDepth2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtBitDepth2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblResolution2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtResolution2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtDescription2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.GroupBox4)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.btnSave)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.btnCancelNew)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblDescription2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtSharpness2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtBlur2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtBrightness2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtProfileName2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblProfileName2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lBlSharpen2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblBlur2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblBrightness2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.txtContrast2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.lblContrast2)
        Me.gbxNewDigitalizationProfile.Controls.Add(Me.cbxRotation2)
        Me.gbxNewDigitalizationProfile.Location = New System.Drawing.Point(201, 14)
        Me.gbxNewDigitalizationProfile.Name = "gbxNewDigitalizationProfile"
        Me.gbxNewDigitalizationProfile.Size = New System.Drawing.Size(389, 340)
        Me.gbxNewDigitalizationProfile.TabIndex = 21
        Me.gbxNewDigitalizationProfile.TabStop = False
        Me.gbxNewDigitalizationProfile.Text = "Novo perfil de digitalização"
        Me.gbxNewDigitalizationProfile.Visible = False
        '
        'lblCompression2
        '
        Me.lblCompression2.BackColor = System.Drawing.Color.Transparent
        Me.lblCompression2.Location = New System.Drawing.Point(224, 168)
        Me.lblCompression2.Name = "lblCompression2"
        Me.lblCompression2.Size = New System.Drawing.Size(72, 17)
        Me.lblCompression2.TabIndex = 65
        Me.lblCompression2.Text = "Compressão"
        Me.lblCompression2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompression2
        '
        Me.txtCompression2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompression2.Location = New System.Drawing.Point(298, 168)
        Me.txtCompression2.Name = "txtCompression2"
        Me.txtCompression2.Size = New System.Drawing.Size(69, 20)
        Me.txtCompression2.TabIndex = 6
        Me.txtCompression2.Text = ""
        '
        'lblFormat2
        '
        Me.lblFormat2.BackColor = System.Drawing.Color.Transparent
        Me.lblFormat2.Location = New System.Drawing.Point(224, 136)
        Me.lblFormat2.Name = "lblFormat2"
        Me.lblFormat2.Size = New System.Drawing.Size(72, 20)
        Me.lblFormat2.TabIndex = 63
        Me.lblFormat2.Text = "Formato"
        Me.lblFormat2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFormat2
        '
        Me.txtFormat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormat2.Location = New System.Drawing.Point(298, 136)
        Me.txtFormat2.Name = "txtFormat2"
        Me.txtFormat2.Size = New System.Drawing.Size(69, 20)
        Me.txtFormat2.TabIndex = 4
        Me.txtFormat2.Text = ""
        '
        'lblBitDepth2
        '
        Me.lblBitDepth2.BackColor = System.Drawing.Color.Transparent
        Me.lblBitDepth2.Location = New System.Drawing.Point(32, 168)
        Me.lblBitDepth2.Name = "lblBitDepth2"
        Me.lblBitDepth2.Size = New System.Drawing.Size(72, 24)
        Me.lblBitDepth2.TabIndex = 61
        Me.lblBitDepth2.Text = "Profundidade bits"
        Me.lblBitDepth2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBitDepth2
        '
        Me.txtBitDepth2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBitDepth2.Location = New System.Drawing.Point(107, 168)
        Me.txtBitDepth2.Name = "txtBitDepth2"
        Me.txtBitDepth2.Size = New System.Drawing.Size(69, 20)
        Me.txtBitDepth2.TabIndex = 5
        Me.txtBitDepth2.Text = ""
        '
        'lblResolution2
        '
        Me.lblResolution2.BackColor = System.Drawing.Color.Transparent
        Me.lblResolution2.Location = New System.Drawing.Point(32, 136)
        Me.lblResolution2.Name = "lblResolution2"
        Me.lblResolution2.Size = New System.Drawing.Size(72, 20)
        Me.lblResolution2.TabIndex = 59
        Me.lblResolution2.Text = "Resolução"
        Me.lblResolution2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResolution2
        '
        Me.txtResolution2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResolution2.Location = New System.Drawing.Point(107, 136)
        Me.txtResolution2.Name = "txtResolution2"
        Me.txtResolution2.Size = New System.Drawing.Size(69, 20)
        Me.txtResolution2.TabIndex = 3
        Me.txtResolution2.Text = ""
        '
        'txtDescription2
        '
        Me.txtDescription2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription2.Location = New System.Drawing.Point(107, 69)
        Me.txtDescription2.Multiline = True
        Me.txtDescription2.Name = "txtDescription2"
        Me.txtDescription2.Size = New System.Drawing.Size(260, 49)
        Me.txtDescription2.TabIndex = 2
        Me.txtDescription2.Text = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(13, 288)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(360, 3)
        Me.GroupBox4.TabIndex = 56
        Me.GroupBox4.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.ImageIndex = 2
        Me.btnSave.ImageList = Me.imglButtons
        Me.btnSave.Location = New System.Drawing.Point(201, 305)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 25)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelNew
        '
        Me.btnCancelNew.BackColor = System.Drawing.Color.White
        Me.btnCancelNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelNew.ImageIndex = 5
        Me.btnCancelNew.ImageList = Me.imglButtons
        Me.btnCancelNew.Location = New System.Drawing.Point(287, 305)
        Me.btnCancelNew.Name = "btnCancelNew"
        Me.btnCancelNew.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelNew.TabIndex = 13
        Me.btnCancelNew.Text = "Cancelar"
        Me.btnCancelNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescription2
        '
        Me.lblDescription2.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription2.Location = New System.Drawing.Point(32, 69)
        Me.lblDescription2.Name = "lblDescription2"
        Me.lblDescription2.Size = New System.Drawing.Size(72, 20)
        Me.lblDescription2.TabIndex = 53
        Me.lblDescription2.Text = "Descrição"
        Me.lblDescription2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSharpness2
        '
        Me.txtSharpness2.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtSharpness2.Location = New System.Drawing.Point(107, 232)
        Me.txtSharpness2.Name = "txtSharpness2"
        Me.txtSharpness2.Size = New System.Drawing.Size(69, 20)
        Me.txtSharpness2.TabIndex = 9
        '
        'txtBlur2
        '
        Me.txtBlur2.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtBlur2.Location = New System.Drawing.Point(298, 232)
        Me.txtBlur2.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtBlur2.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txtBlur2.Name = "txtBlur2"
        Me.txtBlur2.Size = New System.Drawing.Size(69, 20)
        Me.txtBlur2.TabIndex = 10
        '
        'txtBrightness2
        '
        Me.txtBrightness2.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtBrightness2.Location = New System.Drawing.Point(107, 200)
        Me.txtBrightness2.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtBrightness2.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.txtBrightness2.Name = "txtBrightness2"
        Me.txtBrightness2.Size = New System.Drawing.Size(69, 20)
        Me.txtBrightness2.TabIndex = 7
        '
        'txtProfileName2
        '
        Me.txtProfileName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProfileName2.Location = New System.Drawing.Point(107, 35)
        Me.txtProfileName2.Name = "txtProfileName2"
        Me.txtProfileName2.Size = New System.Drawing.Size(260, 20)
        Me.txtProfileName2.TabIndex = 1
        Me.txtProfileName2.Text = ""
        '
        'lblProfileName2
        '
        Me.lblProfileName2.BackColor = System.Drawing.Color.Transparent
        Me.lblProfileName2.ForeColor = System.Drawing.Color.Red
        Me.lblProfileName2.Location = New System.Drawing.Point(32, 35)
        Me.lblProfileName2.Name = "lblProfileName2"
        Me.lblProfileName2.Size = New System.Drawing.Size(72, 20)
        Me.lblProfileName2.TabIndex = 51
        Me.lblProfileName2.Text = "Nome Perfil"
        Me.lblProfileName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lBlSharpen2
        '
        Me.lBlSharpen2.BackColor = System.Drawing.Color.Transparent
        Me.lBlSharpen2.Location = New System.Drawing.Point(32, 232)
        Me.lBlSharpen2.Name = "lBlSharpen2"
        Me.lBlSharpen2.Size = New System.Drawing.Size(72, 20)
        Me.lBlSharpen2.TabIndex = 42
        Me.lBlSharpen2.Text = "Focagem"
        Me.lBlSharpen2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBlur2
        '
        Me.lblBlur2.BackColor = System.Drawing.Color.Transparent
        Me.lblBlur2.Location = New System.Drawing.Point(224, 232)
        Me.lblBlur2.Name = "lblBlur2"
        Me.lblBlur2.Size = New System.Drawing.Size(72, 20)
        Me.lblBlur2.TabIndex = 41
        Me.lblBlur2.Text = "Desfocagem"
        Me.lblBlur2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBrightness2
        '
        Me.lblBrightness2.BackColor = System.Drawing.Color.Transparent
        Me.lblBrightness2.Location = New System.Drawing.Point(32, 200)
        Me.lblBrightness2.Name = "lblBrightness2"
        Me.lblBrightness2.Size = New System.Drawing.Size(72, 20)
        Me.lblBrightness2.TabIndex = 50
        Me.lblBrightness2.Text = "Brilho"
        Me.lblBrightness2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContrast2
        '
        Me.txtContrast2.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtContrast2.Location = New System.Drawing.Point(298, 200)
        Me.txtContrast2.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtContrast2.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.txtContrast2.Name = "txtContrast2"
        Me.txtContrast2.Size = New System.Drawing.Size(69, 20)
        Me.txtContrast2.TabIndex = 8
        '
        'lblContrast2
        '
        Me.lblContrast2.BackColor = System.Drawing.Color.Transparent
        Me.lblContrast2.Location = New System.Drawing.Point(224, 200)
        Me.lblContrast2.Name = "lblContrast2"
        Me.lblContrast2.Size = New System.Drawing.Size(72, 20)
        Me.lblContrast2.TabIndex = 48
        Me.lblContrast2.Text = "Contraste"
        Me.lblContrast2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxRotation2
        '
        Me.cbxRotation2.BackColor = System.Drawing.Color.Transparent
        Me.cbxRotation2.Location = New System.Drawing.Point(107, 264)
        Me.cbxRotation2.Name = "cbxRotation2"
        Me.cbxRotation2.Size = New System.Drawing.Size(88, 20)
        Me.cbxRotation2.TabIndex = 11
        Me.cbxRotation2.Text = "Rotação 90°"
        '
        'DigitalizationProfilesForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(600, 366)
        Me.Controls.Add(Me.gbxDigitalizationProfiles)
        Me.Controls.Add(Me.gbxInfo)
        Me.Controls.Add(Me.gbxNewDigitalizationProfile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "DigitalizationProfilesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Perfis de digitalização"
        Me.gbxInfo.ResumeLayout(False)
        Me.gbxDigitalizationProfiles.ResumeLayout(False)
        Me.gbxNewDigitalizationProfile.ResumeLayout(False)
        CType(Me.txtSharpness2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBlur2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBrightness2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContrast2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "DigitalizationProfiles Form"

    Private Sub DigitalizationProfilesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Constants.UserLogon.Equals("admin") Then
            Me.btnDelete.Enabled = True
        End If
        Me.btnChange.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        LoadData()
    End Sub

    Private Sub lbxDigitalizationProfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxDigitalizationProfiles.SelectedIndexChanged
        Me.BindingContext(mydata, mydata.Tables(0).ToString).Position = lbxDigitalizationProfiles.SelectedIndex
    End Sub

    Private Sub DigitalizationProfiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Me.gbxNewDigitalizationProfile.Visible Then
                Me.gbxNewDigitalizationProfile.Visible = False
                Me.gbxInfo.Visible = True
            ElseIf btnCancelUpdate.Enabled Then
                DisableEdition()
            Else
                Me.Close()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Me.gbxNewDigitalizationProfile.Visible Then
                SaveNew()
            ElseIf btnCancelUpdate.Enabled Then
                SaveChanges()
            End If
        End If
    End Sub

#End Region

#Region "New/Edit/Save"

    Private Sub bttnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.btnNew.Enabled = False
        Me.gbxNewDigitalizationProfile.BringToFront()
        Me.gbxNewDigitalizationProfile.Visible = True
        Me.txtProfileName2.Focus()
    End Sub

    Private Sub bttnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If btnChange.Text.Equals(configReader.GetValue("btnEdit.Text", GetType(String))) Then
            EnableEdition()

        ElseIf btnChange.Text.Equals(configReader.GetValue("btnSave.Text", GetType(String))) Then
            SaveChanges()
        End If
    End Sub

    Private Sub bttnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveNew()
    End Sub

    Private Sub SaveNew()
        Try
            If txtProfileName2.Text.Length = 0 Then
                MsgBox(InfoMessage("DigitalizationProfiles.InvalidName"), MsgBoxStyle.Exclamation)
                txtProfileName2.Focus()
                Exit Sub
            End If

            Dim Profile As DigitalizationProfile = LoadNewProfile()
            If database.InsertDigitalizationProfile(Profile) Then
                LoadData()
                Log.Append(Constants.UserLogon, Log.AppendNode, "New digitalization profile (" & txtProfileName2.Text & ") was added to database.")
                'MsgBox(InfoMessage("DigitalizationProfiles.New"))
                Me.gbxNewDigitalizationProfile.SendToBack()
            End If
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub

    Private Sub SaveChanges()
        Dim Profile As DigitalizationProfile = LoadProfileUpdated()
        If database.UpdateDigitalizationProfile(Profile) Then
            Log.Append(Constants.UserLogon, Log.EditNode, "Digitalization profile edited (" & txtProfileName.Text & ").")
            'MsgBox(InfoMessage("DigitalizationProfiles.Changed"))

            DisableEdition()
            LoadData()
        End If
    End Sub

#End Region

#Region "Cancel"

    Private Sub btnCancelNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelNew.Click
        Me.gbxNewDigitalizationProfile.Visible = False
        Me.gbxInfo.BringToFront()
        Me.btnNew.Enabled = True
    End Sub

    Private Sub bttnCancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelUpdate.Click
        If Me.btnCancelUpdate.Text.Equals(configReader.GetValue("btnCancel.Text", GetType(String))) Then
            DisableEdition()
        Else
            Me.Close()
        End If
    End Sub

#End Region

#Region "Delete"

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim username As String
        If MsgBox(String.Format(InfoMessage("DigitalizationProfiles.Delete"), txtProfileName.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Log.Append(Constants.UserLogon, Log.RemoveNode, "Digitalization profile (" & txtProfileName.Text & ") was removed from database.")

            database.DeleteDigitalizationProfiles(lbxDigitalizationProfiles.SelectedValue)
            LoadData()
            'MsgBox(InfoMessage("DigitalizationProfiles.Success"))
        End If
    End Sub

#End Region



#Region "Load Data"

    Private Sub LoadData()
        mydata = database.SelectAllDigitalizationProfiles()
        Clear()
        FillListView()
    End Sub

    Private Sub FillListView()
        If mydata.Tables.Count <> 0 Then
            Clear()
            lbxDigitalizationProfiles.DataSource = mydata.Tables(0)
            lbxDigitalizationProfiles.DisplayMember = "ProfileName"
            lbxDigitalizationProfiles.ValueMember = "ProfileID"

            lblProfileName.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".ProfileName"))
            txtProfileName.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".ProfileName"))
            txtDescription.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Description"))
            lblDescription.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Description"))
            cbxRotation.DataBindings.Add(New Binding("Checked", mydata, mydata.Tables(0).ToString & ".Rotation"))
            lblBrightness.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Brightness"))
            txtBrightness.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Brightness"))
            lblContrast.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Contrast"))
            txtContrast.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Contrast"))
            lblSharpness.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Sharpness"))
            txtSharpness.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Sharpness"))
            lblBlur.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Blur"))
            txtBlur.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Blur"))
            lblResolution.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Resolution"))
            txtResolution.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Resolution"))
            lblBitDepth.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".BitDepth"))
            txtBitDepth.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".BitDepth"))
            lblFormat.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Format"))
            txtFormat.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Format"))
            lblCompression.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Compression"))
            txtCompression.DataBindings.Add(New Binding("Text", mydata, mydata.Tables(0).ToString & ".Compression"))

            If Me.strDigitalizationProfileValue.Length <> 0 Then
                lbxDigitalizationProfiles.SelectedValue = Me.strDigitalizationProfileValue
            End If
        End If
    End Sub

    Private Function LoadNewProfile() As DigitalizationProfile
        Dim Profile As New DigitalizationProfile
        Profile.ProfileName = StrToDB(Me.txtProfileName2.Text)
        Profile.Description = Me.txtDescription2.Text
        Profile.Rotation = Me.cbxRotation2.Checked
        Profile.Brightness = Me.txtBrightness2.Text
        Profile.Contrast = Me.txtContrast2.Text
        Profile.Sharpness = Me.txtSharpness2.Text
        Profile.Blur = Me.txtBlur2.Text
        Profile.Resolution = Me.txtResolution2.Text
        Profile.BitDepth = Me.txtBitDepth2.Text
        Profile.Format = Me.txtFormat2.Text
        Profile.Compression = Me.txtCompression2.Text

        Return Profile
    End Function

    Private Function LoadProfileUpdated() As DigitalizationProfile
        Dim Profile As New DigitalizationProfile
        Profile.ProfileID = Me.lbxDigitalizationProfiles.SelectedValue
        Profile.ProfileName = Me.txtProfileName.Text
        Profile.Description = Me.txtDescription.Text
        Profile.Rotation = Me.cbxRotation.Checked
        Profile.Brightness = Me.txtBrightness.Text
        Profile.Contrast = Me.txtContrast.Text
        Profile.Sharpness = Me.txtSharpness.Text
        Profile.Blur = Me.txtBlur.Text
        Profile.Resolution = Me.txtResolution.Text
        Profile.BitDepth = Me.txtBitDepth.Text
        Profile.Format = Me.txtFormat.Text
        Profile.Compression = Me.txtCompression.Text

        Return Profile
    End Function

#End Region

#Region "Clear"

    Private Sub Clear()
        Me.lbxDigitalizationProfiles.DataBindings.Clear()
        Me.lblProfileName.DataBindings.Clear()
        Me.txtProfileName.DataBindings.Clear()
        Me.cbxRotation.DataBindings.Clear()
        Me.lblResolution.DataBindings.Clear()
        Me.txtResolution.DataBindings.Clear()
        Me.lblBitDepth.DataBindings.Clear()
        Me.txtBitDepth.DataBindings.Clear()
        Me.lblFormat.DataBindings.Clear()
        Me.txtFormat.DataBindings.Clear()
        Me.lblCompression.DataBindings.Clear()
        Me.txtCompression.DataBindings.Clear()
        Me.lblBrightness.DataBindings.Clear()
        Me.txtBrightness.DataBindings.Clear()
        Me.lblContrast.DataBindings.Clear()
        Me.txtContrast.DataBindings.Clear()
        Me.lblSharpness.DataBindings.Clear()
        Me.txtSharpness.DataBindings.Clear()
        Me.lblBlur.DataBindings.Clear()
        Me.txtBlur.DataBindings.Clear()
        Me.txtDescription.DataBindings.Clear()
        Me.lblDescription.DataBindings.Clear()
    End Sub

#End Region

#Region "Enable/Disable Edition"

    Private Sub EnableEdition()
        Me.txtProfileName.BringToFront()
        Me.cbxRotation.Enabled = True
        Me.txtResolution.BringToFront()
        Me.txtBitDepth.BringToFront()
        Me.txtFormat.BringToFront()
        Me.txtCompression.BringToFront()
        Me.txtBrightness.BringToFront()
        Me.txtContrast.BringToFront()
        Me.txtSharpness.BringToFront()
        Me.txtBlur.BringToFront()
        Me.txtDescription.BringToFront()

        Me.btnNew.Enabled = False
        Me.btnDelete.Enabled = False
        Me.lbxDigitalizationProfiles.Enabled = False
        'Me.btnCancelUpdate.Enabled = True
        Me.btnChange.Text = configReader.GetValue("btnSave.Text", GetType(String))
        Me.btnCancelUpdate.Text = configReader.GetValue("btnCancel.Text", GetType(String))
        Me.btnChange.ImageIndex = 2
    End Sub

    Private Sub DisableEdition()
        Me.txtProfileName.SendToBack()
        Me.cbxRotation.Enabled = False
        Me.txtResolution.SendToBack()
        Me.txtBitDepth.SendToBack()
        Me.txtFormat.SendToBack()
        Me.txtCompression.SendToBack()
        Me.txtBrightness.SendToBack()
        Me.txtContrast.SendToBack()
        Me.txtSharpness.SendToBack()
        Me.txtBlur.SendToBack()
        Me.txtDescription.SendToBack()

        Me.btnNew.Enabled = True
        Me.btnDelete.Enabled = True
        Me.lbxDigitalizationProfiles.Enabled = True
        'Me.btnCancelUpdate.Enabled = False
        Me.btnChange.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        Me.btnCancelUpdate.Text = configReader.GetValue("btnClose.Text", GetType(String))
        Me.btnChange.ImageIndex = 3
    End Sub

#End Region

End Class
