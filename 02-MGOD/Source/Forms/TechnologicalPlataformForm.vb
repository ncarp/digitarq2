
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

Public Class TechnologicalPlataformForm
    Inherits System.Windows.Forms.Form

    Private database As New SqlCommands
    Private myData As New DataSet
    Private configReader As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Public strTecnologicalPlataformValue As String = ""
    Public strTecnologicalPlataformText As String
    Public Choose As Boolean

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
    Friend WithEvents lblScanningSoftwareVersion As System.Windows.Forms.Label
    Friend WithEvents lblScanningSoftware As System.Windows.Forms.Label
    Friend WithEvents lblScannerManufacturer As System.Windows.Forms.Label
    Friend WithEvents lblDeviceSource As System.Windows.Forms.Label
    Friend WithEvents lblOSVersion As System.Windows.Forms.Label
    Friend WithEvents lblOperatingSystem As System.Windows.Forms.Label
    Friend WithEvents txtScanningSoftware As ColorTextBox
    Friend WithEvents txtScannerManufacturer As ColorTextBox
    Friend WithEvents txtDeviceSource As ColorTextBox
    Friend WithEvents txtOperatingSystem As ColorTextBox
    Friend WithEvents txtOSVersion As ColorTextBox
    Friend WithEvents txtModelName As ColorTextBox
    Friend WithEvents lblScannerManufacturer1 As System.Windows.Forms.Label
    Friend WithEvents lblScanningSoftwareVersion1 As System.Windows.Forms.Label
    Friend WithEvents lblScanningSoftware1 As System.Windows.Forms.Label
    Friend WithEvents lblDeviceSource1 As System.Windows.Forms.Label
    Friend WithEvents lblOSVersion1 As System.Windows.Forms.Label
    Friend WithEvents lblOperatingSystem1 As System.Windows.Forms.Label
    Friend WithEvents lblModelName As System.Windows.Forms.Label
    Friend WithEvents txtScanningSoftwareVersion As MGOD.ColorTextBox
    Friend WithEvents btnChange As MGOD.ColorButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents lbxModels As System.Windows.Forms.ListBox
    Friend WithEvents gbxTechnologicalPlatform As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents lblModelName1 As System.Windows.Forms.Label
    Friend WithEvents gbxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TechnologicalPlataformForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.gbxInfo = New System.Windows.Forms.GroupBox
        Me.lblModelName = New System.Windows.Forms.Label
        Me.txtModelName = New MGOD.ColorTextBox
        Me.lblModelName1 = New System.Windows.Forms.Label
        Me.lblScanningSoftwareVersion = New System.Windows.Forms.Label
        Me.lblScanningSoftware = New System.Windows.Forms.Label
        Me.lblScannerManufacturer = New System.Windows.Forms.Label
        Me.lblDeviceSource = New System.Windows.Forms.Label
        Me.lblScannerManufacturer1 = New System.Windows.Forms.Label
        Me.txtScanningSoftware = New MGOD.ColorTextBox
        Me.txtScanningSoftwareVersion = New MGOD.ColorTextBox
        Me.lblScanningSoftwareVersion1 = New System.Windows.Forms.Label
        Me.txtScannerManufacturer = New MGOD.ColorTextBox
        Me.lblScanningSoftware1 = New System.Windows.Forms.Label
        Me.txtDeviceSource = New MGOD.ColorTextBox
        Me.lblDeviceSource1 = New System.Windows.Forms.Label
        Me.lblOSVersion = New System.Windows.Forms.Label
        Me.lblOperatingSystem = New System.Windows.Forms.Label
        Me.txtOperatingSystem = New MGOD.ColorTextBox
        Me.txtOSVersion = New MGOD.ColorTextBox
        Me.lblOSVersion1 = New System.Windows.Forms.Label
        Me.lblOperatingSystem1 = New System.Windows.Forms.Label
        Me.btnChange = New MGOD.ColorButton
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.gbxTechnologicalPlatform = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.lbxModels = New System.Windows.Forms.ListBox
        Me.gbxInfo.SuspendLayout()
        Me.gbxTechnologicalPlatform.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxInfo
        '
        Me.gbxInfo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxInfo.Controls.Add(Me.lblModelName)
        Me.gbxInfo.Controls.Add(Me.txtModelName)
        Me.gbxInfo.Controls.Add(Me.lblModelName1)
        Me.gbxInfo.Controls.Add(Me.lblScanningSoftwareVersion)
        Me.gbxInfo.Controls.Add(Me.lblScanningSoftware)
        Me.gbxInfo.Controls.Add(Me.lblScannerManufacturer)
        Me.gbxInfo.Controls.Add(Me.lblDeviceSource)
        Me.gbxInfo.Controls.Add(Me.lblScannerManufacturer1)
        Me.gbxInfo.Controls.Add(Me.txtScanningSoftware)
        Me.gbxInfo.Controls.Add(Me.txtScanningSoftwareVersion)
        Me.gbxInfo.Controls.Add(Me.lblScanningSoftwareVersion1)
        Me.gbxInfo.Controls.Add(Me.txtScannerManufacturer)
        Me.gbxInfo.Controls.Add(Me.lblScanningSoftware1)
        Me.gbxInfo.Controls.Add(Me.txtDeviceSource)
        Me.gbxInfo.Controls.Add(Me.lblDeviceSource1)
        Me.gbxInfo.Controls.Add(Me.lblOSVersion)
        Me.gbxInfo.Controls.Add(Me.lblOperatingSystem)
        Me.gbxInfo.Controls.Add(Me.txtOperatingSystem)
        Me.gbxInfo.Controls.Add(Me.txtOSVersion)
        Me.gbxInfo.Controls.Add(Me.lblOSVersion1)
        Me.gbxInfo.Controls.Add(Me.lblOperatingSystem1)
        Me.gbxInfo.Controls.Add(Me.btnChange)
        Me.gbxInfo.Controls.Add(Me.btnCancel)
        Me.gbxInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxInfo.Location = New System.Drawing.Point(240, 16)
        Me.gbxInfo.Name = "gbxInfo"
        Me.gbxInfo.Size = New System.Drawing.Size(373, 320)
        Me.gbxInfo.TabIndex = 19
        Me.gbxInfo.TabStop = False
        Me.gbxInfo.Text = "Informação"
        '
        'lblModelName
        '
        Me.lblModelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelName.Location = New System.Drawing.Point(127, 24)
        Me.lblModelName.Name = "lblModelName"
        Me.lblModelName.Size = New System.Drawing.Size(233, 20)
        Me.lblModelName.TabIndex = 2
        '
        'txtModelName
        '
        Me.txtModelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModelName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelName.Location = New System.Drawing.Point(127, 24)
        Me.txtModelName.Name = "txtModelName"
        Me.txtModelName.Size = New System.Drawing.Size(233, 20)
        Me.txtModelName.TabIndex = 2
        Me.txtModelName.Text = ""
        '
        'lblModelName1
        '
        Me.lblModelName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelName1.ForeColor = System.Drawing.Color.Red
        Me.lblModelName1.Location = New System.Drawing.Point(8, 24)
        Me.lblModelName1.Name = "lblModelName1"
        Me.lblModelName1.Size = New System.Drawing.Size(112, 19)
        Me.lblModelName1.TabIndex = 74
        Me.lblModelName1.Text = "Modelo"
        Me.lblModelName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScanningSoftwareVersion
        '
        Me.lblScanningSoftwareVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanningSoftwareVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanningSoftwareVersion.Location = New System.Drawing.Point(127, 152)
        Me.lblScanningSoftwareVersion.Name = "lblScanningSoftwareVersion"
        Me.lblScanningSoftwareVersion.Size = New System.Drawing.Size(233, 20)
        Me.lblScanningSoftwareVersion.TabIndex = 17
        '
        'lblScanningSoftware
        '
        Me.lblScanningSoftware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanningSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanningSoftware.Location = New System.Drawing.Point(127, 120)
        Me.lblScanningSoftware.Name = "lblScanningSoftware"
        Me.lblScanningSoftware.Size = New System.Drawing.Size(233, 20)
        Me.lblScanningSoftware.TabIndex = 16
        '
        'lblScannerManufacturer
        '
        Me.lblScannerManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScannerManufacturer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScannerManufacturer.Location = New System.Drawing.Point(127, 88)
        Me.lblScannerManufacturer.Name = "lblScannerManufacturer"
        Me.lblScannerManufacturer.Size = New System.Drawing.Size(233, 20)
        Me.lblScannerManufacturer.TabIndex = 15
        '
        'lblDeviceSource
        '
        Me.lblDeviceSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDeviceSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceSource.Location = New System.Drawing.Point(127, 56)
        Me.lblDeviceSource.Name = "lblDeviceSource"
        Me.lblDeviceSource.Size = New System.Drawing.Size(233, 20)
        Me.lblDeviceSource.TabIndex = 14
        '
        'lblScannerManufacturer1
        '
        Me.lblScannerManufacturer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScannerManufacturer1.Location = New System.Drawing.Point(8, 88)
        Me.lblScannerManufacturer1.Name = "lblScannerManufacturer1"
        Me.lblScannerManufacturer1.Size = New System.Drawing.Size(112, 19)
        Me.lblScannerManufacturer1.TabIndex = 60
        Me.lblScannerManufacturer1.Text = "Fabricante"
        Me.lblScannerManufacturer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtScanningSoftware
        '
        Me.txtScanningSoftware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScanningSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScanningSoftware.Location = New System.Drawing.Point(127, 120)
        Me.txtScanningSoftware.Name = "txtScanningSoftware"
        Me.txtScanningSoftware.Size = New System.Drawing.Size(233, 20)
        Me.txtScanningSoftware.TabIndex = 5
        Me.txtScanningSoftware.Text = ""
        '
        'txtScanningSoftwareVersion
        '
        Me.txtScanningSoftwareVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScanningSoftwareVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScanningSoftwareVersion.Location = New System.Drawing.Point(127, 152)
        Me.txtScanningSoftwareVersion.Name = "txtScanningSoftwareVersion"
        Me.txtScanningSoftwareVersion.Size = New System.Drawing.Size(233, 20)
        Me.txtScanningSoftwareVersion.TabIndex = 6
        Me.txtScanningSoftwareVersion.Text = ""
        '
        'lblScanningSoftwareVersion1
        '
        Me.lblScanningSoftwareVersion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanningSoftwareVersion1.Location = New System.Drawing.Point(8, 152)
        Me.lblScanningSoftwareVersion1.Name = "lblScanningSoftwareVersion1"
        Me.lblScanningSoftwareVersion1.Size = New System.Drawing.Size(112, 19)
        Me.lblScanningSoftwareVersion1.TabIndex = 66
        Me.lblScanningSoftwareVersion1.Text = "Versão do Software "
        Me.lblScanningSoftwareVersion1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtScannerManufacturer
        '
        Me.txtScannerManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScannerManufacturer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScannerManufacturer.Location = New System.Drawing.Point(127, 88)
        Me.txtScannerManufacturer.Name = "txtScannerManufacturer"
        Me.txtScannerManufacturer.Size = New System.Drawing.Size(233, 20)
        Me.txtScannerManufacturer.TabIndex = 4
        Me.txtScannerManufacturer.Text = ""
        '
        'lblScanningSoftware1
        '
        Me.lblScanningSoftware1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanningSoftware1.Location = New System.Drawing.Point(8, 120)
        Me.lblScanningSoftware1.Name = "lblScanningSoftware1"
        Me.lblScanningSoftware1.Size = New System.Drawing.Size(112, 19)
        Me.lblScanningSoftware1.TabIndex = 64
        Me.lblScanningSoftware1.Text = "Software captura"
        Me.lblScanningSoftware1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeviceSource
        '
        Me.txtDeviceSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeviceSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceSource.Location = New System.Drawing.Point(127, 56)
        Me.txtDeviceSource.Name = "txtDeviceSource"
        Me.txtDeviceSource.Size = New System.Drawing.Size(233, 20)
        Me.txtDeviceSource.TabIndex = 3
        Me.txtDeviceSource.Text = ""
        '
        'lblDeviceSource1
        '
        Me.lblDeviceSource1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceSource1.Location = New System.Drawing.Point(8, 56)
        Me.lblDeviceSource1.Name = "lblDeviceSource1"
        Me.lblDeviceSource1.Size = New System.Drawing.Size(112, 19)
        Me.lblDeviceSource1.TabIndex = 58
        Me.lblDeviceSource1.Text = "Dispositivo captura"
        Me.lblDeviceSource1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOSVersion
        '
        Me.lblOSVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOSVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSVersion.Location = New System.Drawing.Point(127, 216)
        Me.lblOSVersion.Name = "lblOSVersion"
        Me.lblOSVersion.Size = New System.Drawing.Size(233, 20)
        Me.lblOSVersion.TabIndex = 19
        '
        'lblOperatingSystem
        '
        Me.lblOperatingSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOperatingSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperatingSystem.Location = New System.Drawing.Point(127, 184)
        Me.lblOperatingSystem.Name = "lblOperatingSystem"
        Me.lblOperatingSystem.Size = New System.Drawing.Size(233, 20)
        Me.lblOperatingSystem.TabIndex = 18
        '
        'txtOperatingSystem
        '
        Me.txtOperatingSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperatingSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperatingSystem.Location = New System.Drawing.Point(127, 184)
        Me.txtOperatingSystem.Name = "txtOperatingSystem"
        Me.txtOperatingSystem.Size = New System.Drawing.Size(233, 20)
        Me.txtOperatingSystem.TabIndex = 7
        Me.txtOperatingSystem.Text = ""
        '
        'txtOSVersion
        '
        Me.txtOSVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOSVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOSVersion.Location = New System.Drawing.Point(127, 216)
        Me.txtOSVersion.Name = "txtOSVersion"
        Me.txtOSVersion.Size = New System.Drawing.Size(233, 20)
        Me.txtOSVersion.TabIndex = 8
        Me.txtOSVersion.Text = ""
        '
        'lblOSVersion1
        '
        Me.lblOSVersion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSVersion1.Location = New System.Drawing.Point(8, 216)
        Me.lblOSVersion1.Name = "lblOSVersion1"
        Me.lblOSVersion1.Size = New System.Drawing.Size(112, 19)
        Me.lblOSVersion1.TabIndex = 60
        Me.lblOSVersion1.Text = "Versão"
        Me.lblOSVersion1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOperatingSystem1
        '
        Me.lblOperatingSystem1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperatingSystem1.Location = New System.Drawing.Point(8, 184)
        Me.lblOperatingSystem1.Name = "lblOperatingSystem1"
        Me.lblOperatingSystem1.Size = New System.Drawing.Size(112, 19)
        Me.lblOperatingSystem1.TabIndex = 59
        Me.lblOperatingSystem1.Text = "Sistema Operativo"
        Me.lblOperatingSystem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnChange
        '
        Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChange.BackColor = System.Drawing.Color.White
        Me.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChange.ImageIndex = 3
        Me.btnChange.ImageList = Me.imglButtons
        Me.btnChange.Location = New System.Drawing.Point(177, 282)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(88, 25)
        Me.btnChange.TabIndex = 10
        Me.btnChange.Text = "Editar"
        Me.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.ImageList = Me.imglButtons
        Me.btnCancel.Location = New System.Drawing.Point(272, 282)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 25)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Fechar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.BackColor = System.Drawing.Color.White
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.ImageIndex = 0
        Me.btnNew.ImageList = Me.imglButtons
        Me.btnNew.Location = New System.Drawing.Point(7, 20)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(206, 25)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "Novo"
        '
        'gbxTechnologicalPlatform
        '
        Me.gbxTechnologicalPlatform.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxTechnologicalPlatform.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxTechnologicalPlatform.Controls.Add(Me.btnDelete)
        Me.gbxTechnologicalPlatform.Controls.Add(Me.lbxModels)
        Me.gbxTechnologicalPlatform.Controls.Add(Me.btnNew)
        Me.gbxTechnologicalPlatform.Location = New System.Drawing.Point(7, 16)
        Me.gbxTechnologicalPlatform.Name = "gbxTechnologicalPlatform"
        Me.gbxTechnologicalPlatform.Size = New System.Drawing.Size(224, 320)
        Me.gbxTechnologicalPlatform.TabIndex = 28
        Me.gbxTechnologicalPlatform.TabStop = False
        Me.gbxTechnologicalPlatform.Text = "Plataforma tecnológica"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.White
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imglButtons
        Me.btnDelete.Location = New System.Drawing.Point(7, 282)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(206, 25)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = CType(configurationAppSettings.GetValue("btnDelete.Text", GetType(System.String)), String)
        '
        'lbxModels
        '
        Me.lbxModels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxModels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbxModels.HorizontalScrollbar = True
        Me.lbxModels.Location = New System.Drawing.Point(7, 52)
        Me.lbxModels.Name = "lbxModels"
        Me.lbxModels.Size = New System.Drawing.Size(206, 223)
        Me.lbxModels.TabIndex = 0
        '
        'TechnologicalPlataformForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(619, 349)
        Me.Controls.Add(Me.gbxTechnologicalPlatform)
        Me.Controls.Add(Me.gbxInfo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "TechnologicalPlataformForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Plataforma tecnológica"
        Me.gbxInfo.ResumeLayout(False)
        Me.gbxTechnologicalPlatform.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub TecnologicalPlataform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        Choose = False
    End Sub

    Private Sub lbxModels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxModels.SelectedIndexChanged
        Me.BindingContext(myData, myData.Tables(0).ToString).Position = lbxModels.SelectedIndex
    End Sub


#Region "Insert new item"

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Clear()
        txtModelName.Focus()

        txtModelName.Clear()
        txtDeviceSource.Clear()
        txtScannerManufacturer.Clear()
        txtScanningSoftware.Clear()
        txtScanningSoftwareVersion.Clear()
        txtOperatingSystem.Clear()
        txtOSVersion.Clear()

        EnableEdition()
        Me.btnChange.Tag = "New"
    End Sub

#End Region

#Region "Choose"

    'Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
    '    If MsgBox(InfoMessage("TechnologicalPlatform.ChangeScanner"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '        strTecnologicalPlataformValue = lbxModels.SelectedValue
    '        strTecnologicalPlataformText = lbxModels.GetItemText(Me.lbxModels.SelectedItem)
    '        Choose = True
    '        Me.Close()
    '    Else
    '        Choose = False
    '        Me.Close()
    '    End If
    'End Sub

#End Region

#Region "Save/Edit Info"

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If btnChange.Text.Equals(configReader.GetValue("btnEdit.Text", GetType(String))) Then
            Me.btnChange.Tag = "Update"
            EnableEdition()

        ElseIf btnChange.Text.Equals(configReader.GetValue("btnSave.Text", GetType(String))) Then
            Save()
        End If
    End Sub

    Private Sub Save()
        Dim res As Integer

        If txtModelName.Text.Length = 0 Then
            MsgBox(InfoMessage("TechnologicalPlatform.InvalidName"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Select Case Me.btnChange.Tag
            Case "New"
                res = database.InsertTechnologicalPlatform(txtModelName.Text, _
                                txtDeviceSource.Text, txtScannerManufacturer.Text, txtScanningSoftware.Text, _
                                txtScanningSoftwareVersion.Text, txtOperatingSystem.Text, txtOSVersion.Text)
                If res = 1 Then
                    LoadData()
                    DisableEdition()
                    Log.Append(Constants.UserLogon, Log.AppendNode, "New technological platform " & txtModelName.Text & " was added to database.")
                    'MsgBox(InfoMessage("TechnologicalPlatform.Insert"), MsgBoxStyle.Information)
                End If

            Case "Update"
                res = database.UpdateTechnologicalPlatform(lbxModels.SelectedValue, txtModelName.Text, _
                                txtDeviceSource.Text, txtScannerManufacturer.Text, txtScanningSoftware.Text, _
                                txtScanningSoftwareVersion.Text, txtOperatingSystem.Text, txtOSVersion.Text)
                If res = 1 Then
                    LoadData()
                    DisableEdition()
                    Log.Append(Constants.UserLogon, Log.EditNode, "Technological platform " & txtModelName.Text & " was edited.")
                    'MsgBox(InfoMessage("TechnologicalPlatform.Changed"), MsgBoxStyle.Information)
                End If
        End Select
    End Sub



#End Region

#Region "Cancel"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnCancel.Text.Equals(configReader.GetValue("btnCancel.Text", GetType(String))) Then
            DisableEdition()
        Else
            Me.Close()
        End If
    End Sub

#End Region

#Region "Delete"

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox(InfoMessage("TechnologicalPlatform.DeleteScanner"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            database.DeleteTecnhologicalPlatform(lbxModels.SelectedValue)
            Log.Append(Constants.UserLogon, Log.RemoveNode, "Technological platform " & lbxModels.GetItemText(lbxModels.SelectedItem) & " was deleted from database.")
            'MsgBox(InfoMessage("TechnologicalPlatform.Delete"), MsgBoxStyle.Information)
            LoadData()
        End If
    End Sub

#End Region


#Region "Load data"

    Private Sub LoadData()
        myData = New DataSet
        myData = database.SelectAllTechnologicalPlatform
        lbxModels.DataBindings.Clear()
        Clear()

        If myData.Tables.Count <> 0 Then
            lbxModels.DataSource = myData.Tables(0)
            lbxModels.DisplayMember = "ScannerModelName"
            lbxModels.ValueMember = "TPlatformID"

            lblModelName.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScannerModelName"))
            txtModelName.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScannerModelName"))
            txtDeviceSource.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".DeviceSource"))
            lblDeviceSource.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".DeviceSource"))
            txtScannerManufacturer.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScannerManufacturer"))
            lblScannerManufacturer.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScannerManufacturer"))
            txtScanningSoftware.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScanningSoftware"))
            lblScanningSoftware.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScanningSoftware"))
            txtScanningSoftwareVersion.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScanningSoftwareVersionNo"))
            lblScanningSoftwareVersion.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".ScanningSoftwareVersionNo"))
            txtOperatingSystem.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".OperatingSystem"))
            lblOperatingSystem.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".OperatingSystem"))
            txtOSVersion.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".OperatingSystemVersion"))
            lblOSVersion.DataBindings.Add(New Binding("Text", myData, myData.Tables(0).ToString & ".OperatingSystemVersion"))

            If strTecnologicalPlataformValue.Length <> 0 Then
                lbxModels.SelectedValue = strTecnologicalPlataformValue
            End If
        End If
    End Sub

#End Region

#Region "Clear"

    Private Sub Clear()
        txtModelName.DataBindings.Clear()
        lblModelName.DataBindings.Clear()
        txtDeviceSource.DataBindings.Clear()
        lblDeviceSource.DataBindings.Clear()
        txtScannerManufacturer.DataBindings.Clear()
        lblScannerManufacturer.DataBindings.Clear()
        txtScanningSoftware.DataBindings.Clear()
        lblScanningSoftware.DataBindings.Clear()
        txtScanningSoftwareVersion.DataBindings.Clear()
        lblScanningSoftwareVersion.DataBindings.Clear()
        txtOperatingSystem.DataBindings.Clear()
        lblOperatingSystem.DataBindings.Clear()
        txtOSVersion.DataBindings.Clear()
        lblOSVersion.DataBindings.Clear()
    End Sub

#End Region

#Region "Enable/Disable edition"

    Private Sub EnableEdition()
        txtModelName.BringToFront()
        txtDeviceSource.BringToFront()
        txtScannerManufacturer.BringToFront()
        txtScanningSoftware.BringToFront()
        txtScanningSoftwareVersion.BringToFront()
        txtOperatingSystem.BringToFront()
        txtOSVersion.BringToFront()

        'btnCancel.Enabled = True
        lbxModels.Enabled = False
        btnDelete.Enabled = False
        btnNew.Enabled = False
        btnChange.Text = configReader.GetValue("btnSave.Text", GetType(String))
        btnCancel.Text = configReader.GetValue("btnCancel.Text", GetType(String))
        btnChange.ImageIndex = 2
    End Sub

    Private Sub DisableEdition()
        txtModelName.SendToBack()
        txtDeviceSource.SendToBack()
        txtScannerManufacturer.SendToBack()
        txtScanningSoftware.SendToBack()
        txtScanningSoftwareVersion.SendToBack()
        txtOperatingSystem.SendToBack()
        txtOSVersion.SendToBack()

        'btnCancel.Enabled = False
        lbxModels.Enabled = True
        btnDelete.Enabled = True
        btnNew.Enabled = True
        btnChange.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        btnCancel.Text = configReader.GetValue("btnClose.Text", GetType(String))
        btnChange.ImageIndex = 3
    End Sub

#End Region

#Region "Others"

    Private Sub TecnologicalPlataform_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If btnCancel.Enabled Then
                DisableEdition()
            Else
                Me.Close()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If btnCancel.Enabled Then
                Save()
            End If
        End If
    End Sub

#End Region

End Class
