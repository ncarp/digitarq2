
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

Public Class ControlAccessForm
    Inherits System.Windows.Forms.Form


#Region "Private Properties"


    Private myFondsID As Integer
#End Region


#Region " Windows Form Designer generated code "


    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.TabControlControlAccess.Controls.Remove(Me.TabPageControlAccessItemsFonds)
    End Sub


    Public Sub New(ByVal FondsComponentID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        myFondsID = FondsComponentID
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Type As System.Windows.Forms.TextBox
    Friend WithEvents ListViewTypes As System.Windows.Forms.ListView
    Friend WithEvents ControlAccessTypeIDHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents ControlAccessTypeHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents TypeComboBox As ComboBoxImage
    Friend WithEvents ListViewItems As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ControlAccessItemType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ControlAccessItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabControlControlAccess As System.Windows.Forms.TabControl
    Friend WithEvents TabPageControlAccessTypes As System.Windows.Forms.TabPage
    Friend WithEvents TabPageControlAccessItems As System.Windows.Forms.TabPage
    Friend WithEvents TabPageControlAccessItemsFonds As System.Windows.Forms.TabPage
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents btnCloseControlAccess As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblControlAccessExisting As System.Windows.Forms.Label
    Friend WithEvents lblControlAccessSelected As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ListViewAllItems As System.Windows.Forms.ListView
    Friend WithEvents chAllItemsItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAllItemsType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListViewFondsItems As System.Windows.Forms.ListView
    Friend WithEvents chFondsItemsItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFondsItemsType As System.Windows.Forms.ColumnHeader
    Friend WithEvents UpDownArrowButtons As System.Windows.Forms.ImageList
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents btnAddItem As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnRemoveItem As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnRemoveType As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnAddType As mkccontrols.windows.forms.control.mkc_Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ControlAccessForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnCloseControlAccess = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.FondsIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlControlAccess = New System.Windows.Forms.TabControl
        Me.TabPageControlAccessTypes = New System.Windows.Forms.TabPage
        Me.btnRemoveType = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnAddType = New mkccontrols.windows.forms.control.mkc_Button
        Me.Type = New System.Windows.Forms.TextBox
        Me.ListViewTypes = New System.Windows.Forms.ListView
        Me.ControlAccessTypeIDHeader = New System.Windows.Forms.ColumnHeader
        Me.ControlAccessTypeHeader = New System.Windows.Forms.ColumnHeader
        Me.TabPageControlAccessItems = New System.Windows.Forms.TabPage
        Me.btnRemoveItem = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnAddItem = New mkccontrols.windows.forms.control.mkc_Button
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.TypeComboBox = New MDA.ComboBoxImage
        Me.ListViewItems = New System.Windows.Forms.ListView
        Me.ColumnHeaderID = New System.Windows.Forms.ColumnHeader
        Me.ControlAccessItemType = New System.Windows.Forms.ColumnHeader
        Me.ControlAccessItem = New System.Windows.Forms.ColumnHeader
        Me.TabPageControlAccessItemsFonds = New System.Windows.Forms.TabPage
        Me.lblControlAccessSelected = New System.Windows.Forms.Label
        Me.lblControlAccessExisting = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.ListViewAllItems = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.chAllItemsItem = New System.Windows.Forms.ColumnHeader
        Me.chAllItemsType = New System.Windows.Forms.ColumnHeader
        Me.ListViewFondsItems = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.chFondsItemsItem = New System.Windows.Forms.ColumnHeader
        Me.chFondsItemsType = New System.Windows.Forms.ColumnHeader
        Me.UpDownArrowButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControlControlAccess.SuspendLayout()
        Me.TabPageControlAccessTypes.SuspendLayout()
        Me.TabPageControlAccessItems.SuspendLayout()
        Me.TabPageControlAccessItemsFonds.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCloseControlAccess)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 335)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(522, 40)
        Me.Panel2.TabIndex = 4
        '
        'btnCloseControlAccess
        '
        Me.btnCloseControlAccess.BackColor = System.Drawing.Color.White
        Me.btnCloseControlAccess.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCloseControlAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseControlAccess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCloseControlAccess.ImageIndex = 0
        Me.btnCloseControlAccess.ImageList = Me.imglButtons
        Me.btnCloseControlAccess.Location = New System.Drawing.Point(429, 8)
        Me.btnCloseControlAccess.Name = "btnCloseControlAccess"
        Me.btnCloseControlAccess.Size = New System.Drawing.Size(75, 25)
        Me.btnCloseControlAccess.TabIndex = 2
        Me.btnCloseControlAccess.Text = "&Fechar"
        Me.btnCloseControlAccess.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
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
        Me.Panel1.Controls.Add(Me.TabControlControlAccess)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(522, 335)
        Me.Panel1.TabIndex = 5
        '
        'TabControlControlAccess
        '
        Me.TabControlControlAccess.Controls.Add(Me.TabPageControlAccessTypes)
        Me.TabControlControlAccess.Controls.Add(Me.TabPageControlAccessItems)
        Me.TabControlControlAccess.Controls.Add(Me.TabPageControlAccessItemsFonds)
        Me.TabControlControlAccess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlControlAccess.Location = New System.Drawing.Point(0, 0)
        Me.TabControlControlAccess.Name = "TabControlControlAccess"
        Me.TabControlControlAccess.SelectedIndex = 0
        Me.TabControlControlAccess.Size = New System.Drawing.Size(522, 335)
        Me.TabControlControlAccess.TabIndex = 18
        '
        'TabPageControlAccessTypes
        '
        Me.TabPageControlAccessTypes.Controls.Add(Me.btnRemoveType)
        Me.TabPageControlAccessTypes.Controls.Add(Me.btnAddType)
        Me.TabPageControlAccessTypes.Controls.Add(Me.Type)
        Me.TabPageControlAccessTypes.Controls.Add(Me.ListViewTypes)
        Me.TabPageControlAccessTypes.Location = New System.Drawing.Point(4, 22)
        Me.TabPageControlAccessTypes.Name = "TabPageControlAccessTypes"
        Me.TabPageControlAccessTypes.Size = New System.Drawing.Size(514, 309)
        Me.TabPageControlAccessTypes.TabIndex = 0
        Me.TabPageControlAccessTypes.Text = "Tipos de termos"
        '
        'btnRemoveType
        '
        Me.btnRemoveType.BorderColor = System.Drawing.SystemColors.Control
        Me.btnRemoveType.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveType.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemoveType.ButtonImage = CType(resources.GetObject("btnRemoveType.ButtonImage"), System.Drawing.Image)
        Me.btnRemoveType.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveType.ButtonShowShadow = True
        Me.btnRemoveType.ButtonText = ""
        Me.btnRemoveType.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveType.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnRemoveType.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnRemoveType.Location = New System.Drawing.Point(480, 40)
        Me.btnRemoveType.Name = "btnRemoveType"
        Me.btnRemoveType.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveType.TabIndex = 25
        '
        'btnAddType
        '
        Me.btnAddType.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAddType.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddType.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddType.ButtonImage = CType(resources.GetObject("btnAddType.ButtonImage"), System.Drawing.Image)
        Me.btnAddType.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddType.ButtonShowShadow = True
        Me.btnAddType.ButtonText = ""
        Me.btnAddType.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddType.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAddType.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnAddType.Location = New System.Drawing.Point(480, 16)
        Me.btnAddType.Name = "btnAddType"
        Me.btnAddType.Size = New System.Drawing.Size(20, 20)
        Me.btnAddType.TabIndex = 24
        '
        'Type
        '
        Me.Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Type.Location = New System.Drawing.Point(24, 16)
        Me.Type.Name = "Type"
        Me.Type.Size = New System.Drawing.Size(448, 20)
        Me.Type.TabIndex = 21
        Me.Type.Text = ""
        '
        'ListViewTypes
        '
        Me.ListViewTypes.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.ListViewTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewTypes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ControlAccessTypeIDHeader, Me.ControlAccessTypeHeader})
        Me.ListViewTypes.FullRowSelect = True
        Me.ListViewTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewTypes.HideSelection = False
        Me.ListViewTypes.Location = New System.Drawing.Point(24, 40)
        Me.ListViewTypes.MultiSelect = False
        Me.ListViewTypes.Name = "ListViewTypes"
        Me.ListViewTypes.Size = New System.Drawing.Size(448, 248)
        Me.ListViewTypes.TabIndex = 20
        Me.ListViewTypes.View = System.Windows.Forms.View.Details
        '
        'ControlAccessTypeIDHeader
        '
        Me.ControlAccessTypeIDHeader.Text = "ID"
        Me.ControlAccessTypeIDHeader.Width = 0
        '
        'ControlAccessTypeHeader
        '
        Me.ControlAccessTypeHeader.Width = 350
        '
        'TabPageControlAccessItems
        '
        Me.TabPageControlAccessItems.Controls.Add(Me.btnRemoveItem)
        Me.TabPageControlAccessItems.Controls.Add(Me.btnAddItem)
        Me.TabPageControlAccessItems.Controls.Add(Me.txtItem)
        Me.TabPageControlAccessItems.Controls.Add(Me.TypeComboBox)
        Me.TabPageControlAccessItems.Controls.Add(Me.ListViewItems)
        Me.TabPageControlAccessItems.Location = New System.Drawing.Point(4, 22)
        Me.TabPageControlAccessItems.Name = "TabPageControlAccessItems"
        Me.TabPageControlAccessItems.Size = New System.Drawing.Size(514, 309)
        Me.TabPageControlAccessItems.TabIndex = 1
        Me.TabPageControlAccessItems.Text = "Termos de indexação"
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.BorderColor = System.Drawing.SystemColors.Control
        Me.btnRemoveItem.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveItem.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemoveItem.ButtonImage = CType(resources.GetObject("btnRemoveItem.ButtonImage"), System.Drawing.Image)
        Me.btnRemoveItem.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveItem.ButtonShowShadow = True
        Me.btnRemoveItem.ButtonText = ""
        Me.btnRemoveItem.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveItem.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnRemoveItem.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnRemoveItem.Location = New System.Drawing.Point(480, 40)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveItem.TabIndex = 24
        '
        'btnAddItem
        '
        Me.btnAddItem.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAddItem.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddItem.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddItem.ButtonImage = CType(resources.GetObject("btnAddItem.ButtonImage"), System.Drawing.Image)
        Me.btnAddItem.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddItem.ButtonShowShadow = True
        Me.btnAddItem.ButtonText = ""
        Me.btnAddItem.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddItem.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAddItem.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnAddItem.Location = New System.Drawing.Point(480, 16)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(20, 20)
        Me.btnAddItem.TabIndex = 23
        '
        'txtItem
        '
        Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItem.Location = New System.Drawing.Point(200, 16)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(272, 20)
        Me.txtItem.TabIndex = 22
        Me.txtItem.Text = ""
        '
        'TypeComboBox
        '
        Me.TypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.ImageList = Nothing
        Me.TypeComboBox.ItemHeight = 13
        Me.TypeComboBox.Location = New System.Drawing.Point(24, 16)
        Me.TypeComboBox.MaxDropDownItems = 12
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(168, 19)
        Me.TypeComboBox.Sorted = True
        Me.TypeComboBox.TabIndex = 21
        '
        'ListViewItems
        '
        Me.ListViewItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderID, Me.ControlAccessItemType, Me.ControlAccessItem})
        Me.ListViewItems.FullRowSelect = True
        Me.ListViewItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewItems.Location = New System.Drawing.Point(24, 40)
        Me.ListViewItems.Name = "ListViewItems"
        Me.ListViewItems.Size = New System.Drawing.Size(448, 248)
        Me.ListViewItems.TabIndex = 20
        Me.ListViewItems.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderID
        '
        Me.ColumnHeaderID.Text = "ID"
        Me.ColumnHeaderID.Width = 0
        '
        'ControlAccessItemType
        '
        Me.ControlAccessItemType.Text = CType(configurationAppSettings.GetValue("ControlAccessItemType.Text", GetType(System.String)), String)
        Me.ControlAccessItemType.Width = 170
        '
        'ControlAccessItem
        '
        Me.ControlAccessItem.Text = CType(configurationAppSettings.GetValue("ControlAccessItem.Text", GetType(System.String)), String)
        Me.ControlAccessItem.Width = 268
        '
        'TabPageControlAccessItemsFonds
        '
        Me.TabPageControlAccessItemsFonds.Controls.Add(Me.lblControlAccessSelected)
        Me.TabPageControlAccessItemsFonds.Controls.Add(Me.lblControlAccessExisting)
        Me.TabPageControlAccessItemsFonds.Controls.Add(Me.btnRemove)
        Me.TabPageControlAccessItemsFonds.Controls.Add(Me.btnAdd)
        Me.TabPageControlAccessItemsFonds.Controls.Add(Me.ListViewAllItems)
        Me.TabPageControlAccessItemsFonds.Controls.Add(Me.ListViewFondsItems)
        Me.TabPageControlAccessItemsFonds.Location = New System.Drawing.Point(4, 22)
        Me.TabPageControlAccessItemsFonds.Name = "TabPageControlAccessItemsFonds"
        Me.TabPageControlAccessItemsFonds.Size = New System.Drawing.Size(514, 309)
        Me.TabPageControlAccessItemsFonds.TabIndex = 2
        Me.TabPageControlAccessItemsFonds.Text = "Termos / Fundos"
        '
        'lblControlAccessSelected
        '
        Me.lblControlAccessSelected.Location = New System.Drawing.Point(280, 16)
        Me.lblControlAccessSelected.Name = "lblControlAccessSelected"
        Me.lblControlAccessSelected.Size = New System.Drawing.Size(144, 16)
        Me.lblControlAccessSelected.TabIndex = 26
        Me.lblControlAccessSelected.Text = CType(configurationAppSettings.GetValue("lblControlAccessSelected.Text", GetType(System.String)), String)
        '
        'lblControlAccessExisting
        '
        Me.lblControlAccessExisting.Location = New System.Drawing.Point(16, 16)
        Me.lblControlAccessExisting.Name = "lblControlAccessExisting"
        Me.lblControlAccessExisting.Size = New System.Drawing.Size(100, 16)
        Me.lblControlAccessExisting.TabIndex = 25
        Me.lblControlAccessExisting.Text = CType(configurationAppSettings.GetValue("lblControlAccessExisting.Text", GetType(System.String)), String)
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Location = New System.Drawing.Point(240, 160)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(32, 23)
        Me.btnRemove.TabIndex = 24
        Me.btnRemove.Text = "<<"
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(240, 128)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 23)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = ">>"
        '
        'ListViewAllItems
        '
        Me.ListViewAllItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewAllItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.chAllItemsItem, Me.chAllItemsType})
        Me.ListViewAllItems.FullRowSelect = True
        Me.ListViewAllItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewAllItems.Location = New System.Drawing.Point(16, 32)
        Me.ListViewAllItems.Name = "ListViewAllItems"
        Me.ListViewAllItems.Size = New System.Drawing.Size(216, 264)
        Me.ListViewAllItems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewAllItems.TabIndex = 22
        Me.ListViewAllItems.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ID"
        Me.ColumnHeader4.Width = 0
        '
        'chAllItemsItem
        '
        Me.chAllItemsItem.Text = CType(configurationAppSettings.GetValue("chAllItemsItem.Text", GetType(System.String)), String)
        Me.chAllItemsItem.Width = 207
        '
        'chAllItemsType
        '
        Me.chAllItemsType.Text = CType(configurationAppSettings.GetValue("chAllItemsType.Text", GetType(System.String)), String)
        Me.chAllItemsType.Width = 118
        '
        'ListViewFondsItems
        '
        Me.ListViewFondsItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewFondsItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.chFondsItemsItem, Me.chFondsItemsType})
        Me.ListViewFondsItems.FullRowSelect = True
        Me.ListViewFondsItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFondsItems.Location = New System.Drawing.Point(280, 32)
        Me.ListViewFondsItems.Name = "ListViewFondsItems"
        Me.ListViewFondsItems.Size = New System.Drawing.Size(224, 264)
        Me.ListViewFondsItems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewFondsItems.TabIndex = 21
        Me.ListViewFondsItems.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'chFondsItemsItem
        '
        Me.chFondsItemsItem.Text = CType(configurationAppSettings.GetValue("chFondsItemsItem.Text", GetType(System.String)), String)
        Me.chFondsItemsItem.Width = 207
        '
        'chFondsItemsType
        '
        Me.chFondsItemsType.Text = CType(configurationAppSettings.GetValue("chFondsItemsType.Text", GetType(System.String)), String)
        Me.chFondsItemsType.Width = 123
        '
        'UpDownArrowButtons
        '
        Me.UpDownArrowButtons.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.UpDownArrowButtons.ImageSize = New System.Drawing.Size(19, 19)
        Me.UpDownArrowButtons.ImageStream = CType(resources.GetObject("UpDownArrowButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.UpDownArrowButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'ControlAccessForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCloseControlAccess
        Me.ClientSize = New System.Drawing.Size(522, 375)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 1024)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "ControlAccessForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Termos de Indexação"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControlControlAccess.ResumeLayout(False)
        Me.TabPageControlAccessTypes.ResumeLayout(False)
        Me.TabPageControlAccessItems.ResumeLayout(False)
        Me.TabPageControlAccessItemsFonds.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Form Events"


    Private Sub TabControlControlAccess_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlControlAccess.SelectedIndexChanged
        LoadLists()
    End Sub

    Private Sub LoadLists()
        If TabControlControlAccess.SelectedTab Is Me.TabPageControlAccessItems Then
            Me.LoadItemsList()
            Me.LoadTypesList()
        ElseIf TabControlControlAccess.SelectedTab Is Me.TabPageControlAccessItemsFonds Then
            Me.LoadItemsFondsList()
        ElseIf TabControlControlAccess.SelectedTab Is Me.TabPageControlAccessTypes Then
            Me.LoadTypesList()
        End If
    End Sub


    Private Sub ControlAccessForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLists()
    End Sub


#End Region


#Region "Types"

    Private Sub ListViewTypes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewTypes.DoubleClick
        If ListViewTypes.SelectedItems.Count <> 1 Then Exit Sub
        Dim frmEdit As New ControlAccessTypeEditForm
        Dim TypeID As Integer = StrToInt(ListViewTypes.SelectedItems(0).SubItems(0).Text)
        frmEdit.Value = ListViewTypes.SelectedItems(0).SubItems(1).Text

        If frmEdit.ShowDialog = DialogResult.OK Then
            'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
            Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
            Try
                SQLLazyNode.UpdateControlAccessType(SQLServerSettings.Item("ServerAddress"),
                                                    SQLServerSettings.Item("Database"),
                                                    SQLServerSettings.Item("Username"),
                                                    SQLServerSettings.Item("Password"),
                                                    TypeID, frmEdit.Value)
                Me.LoadTypesList()
                Me.LoadItemsList()
            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)

            End Try

        End If
    End Sub


    Private Sub LoadTypesList()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Try
            Dim TypesList As ControlAccessTypeCollection = SQLLazyNode.GetControlAccessTypeList( _
                                                            SQLServerSettings.Item("ServerAddress"), _
                                                            SQLServerSettings.Item("Database"), _
                                                            SQLServerSettings.Item("Username"), _
                                                            SQLServerSettings.Item("Password") _
                                                        )

            TypeComboBox.Items.Clear()
            ListViewTypes.Items.Clear()
            Debug.WriteLine("Lista de tipos: " & ListViewTypes.Items.Count.ToString)
            Dim Item As ControlAccessTypeItem
            For Each Item In TypesList
                Dim ID As New ListViewItem(Item.ID.ToString)
                Dim Type As New ListViewItem.ListViewSubItem(ID, Item.Type)
                ID.SubItems.Add(Type)
                ListViewTypes.Items.Add(ID)
                TypeComboBox.Items.Add(New ComboBoxImageItem(Item.Type, Item.ID.ToString, -1))

            Next

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)

        End Try
    End Sub


    Private Sub btnAddType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddType.Click
        If Type.Text = "" Then Exit Sub
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Try

            SQLLazyNode.CreateNewControlAccessType(SQLServerSettings.Item("ServerAddress"),
                                                   SQLServerSettings.Item("Database"),
                                                   SQLServerSettings.Item("Username"),
                                                   SQLServerSettings.Item("Password"),
                                                   Me.Type.Text)
            Type.Text = ""
            Type.Focus()
            LoadTypesList()
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)

        End Try
    End Sub


    Private Sub btnRemoveType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveType.Click
        If ListViewTypes.SelectedItems.Count <> 1 Then Exit Sub

        If MsgBox(InfoMessage("RemoveControlAccessType.Confirm"), MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim TypeID As Integer = StrToInt(ListViewTypes.SelectedItems(0).SubItems(0).Text)

        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Try
            SQLLazyNode.RemoveControlAccessType(SQLServerSettings.Item("ServerAddress"), _
                                                SQLServerSettings.Item("Database"), _
                                                SQLServerSettings.Item("Username"), _
                                                SQLServerSettings.Item("Password"), _
                                                TypeID)
            Me.LoadTypesList()

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub


    Private Sub Type_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Type.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            btnAddType_Click(sender, e)
        End If
    End Sub

#End Region


#Region "Items"


    Private Sub ListViewItems_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewItems.DoubleClick
        If ListViewItems.SelectedItems.Count <> 1 Then Exit Sub
        Dim frmEdit As New ControlAccessItemEditForm
        Dim ItemID As Integer = StrToInt(ListViewItems.SelectedItems(0).SubItems(0).Text)
        Dim Type As String = ListViewItems.SelectedItems(0).SubItems(1).Text
        Dim Item As String = ListViewItems.SelectedItems(0).SubItems(2).Text

        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Try
            frmEdit.Item = Item
            frmEdit.Types = SQLLazyNode.GetControlAccessTypeList( _
                                                            SQLServerSettings.Item("ServerAddress"), _
                                                            SQLServerSettings.Item("Database"), _
                                                            SQLServerSettings.Item("Username"), _
                                                            SQLServerSettings.Item("Password") _
                                                        )
            frmEdit.SelectType(Type)

            If frmEdit.ShowDialog = DialogResult.OK Then
                SQLLazyNode.UpdateControlAccessItem(SQLServerSettings.Item("ServerAddress"), _
                                                    SQLServerSettings.Item("Database"), _
                                                    SQLServerSettings.Item("Username"), _
                                                    SQLServerSettings.Item("Password"), _
                                                    ItemID, frmEdit.TypeID, frmEdit.Item)
                Me.LoadItemsList()
            End If
        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)

        End Try


    End Sub


    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        If (TypeComboBox.SelectedItem Is Nothing) OrElse (txtItem.Text = "") Then Exit Sub

        Dim TypeID As String = CType(TypeComboBox.SelectedItem, ComboBoxImageItem).Value
        Dim Item As String = txtItem.Text

        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Try
            SQLLazyNode.CreateNewControlAccessItem(SQLServerSettings.Item("ServerAddress"),
                                                   SQLServerSettings.Item("Database"),
                                                   SQLServerSettings.Item("Username"),
                                                   SQLServerSettings.Item("Password"),
                                                   TypeID, Item)

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
        txtItem.Text = ""
        txtItem.Focus()
        LoadItemsList()
    End Sub


    Private Sub Item_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            btnAddItem_Click(sender, e)
        End If
    End Sub


    Private Sub btnRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItem.Click
        If ListViewItems.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox(InfoMessage("RemoveControlAccessItem.Confirm"), MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim SelectedItem As ListViewItem
        For Each SelectedItem In ListViewItems.SelectedItems
            Dim ItemID As Integer = StrToInt(SelectedItem.SubItems(0).Text)

            'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
            Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

            Try
                SQLLazyNode.RemoveControlAccessItem(SQLServerSettings.Item("ServerAddress"), _
                                                    SQLServerSettings.Item("Database"), _
                                                    SQLServerSettings.Item("Username"), _
                                                    SQLServerSettings.Item("Password"), _
                                                    ItemID)

            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            End Try

        Next

        Me.LoadItemsList()
    End Sub


    Private Sub LoadItemsList()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Try
            Dim ItemsList As ControlAccessItemCollection = SQLLazyNode.GetControlAccessItemList( _
                                                            SQLServerSettings.Item("ServerAddress"), _
                                                            SQLServerSettings.Item("Database"), _
                                                            SQLServerSettings.Item("Username"), _
                                                            SQLServerSettings.Item("Password") _
                                                        )

            ListViewItems.Items.Clear()
            Dim Item As ControlAccessItemItem
            For Each Item In ItemsList
                Dim ID As New ListViewItem(Item.ID.ToString)
                Dim Type As New ListViewItem.ListViewSubItem(ID, Item.Type)
                Dim ItemDesc As New ListViewItem.ListViewSubItem(ID, Item.Item)
                Debug.WriteLine("LoadItemsList:" & Item.Item)
                ID.SubItems.Add(Type)
                ID.SubItems.Add(ItemDesc)
                ListViewItems.Items.Add(ID)
            Next

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub


#End Region


#Region "Items/Fonds"


    Private Sub LoadItemsFondsList()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Try
            Dim ItemsInFondsList As ControlAccessItemCollection = SQLLazyNode.GetControlAccessItemListInFonds(
                                                            SQLServerSettings.Item("ServerAddress"),
                                                            SQLServerSettings.Item("Database"),
                                                            SQLServerSettings.Item("Username"),
                                                            SQLServerSettings.Item("Password"),
                                                            myFondsID
                                                        )

            Dim ItemsNotInFondsList As ControlAccessItemCollection = SQLLazyNode.GetControlAccessItemListNotInFonds(
                                                            SQLServerSettings.Item("ServerAddress"),
                                                            SQLServerSettings.Item("Database"),
                                                            SQLServerSettings.Item("Username"),
                                                            SQLServerSettings.Item("Password"),
                                                            myFondsID
                                                        )

            ListViewAllItems.Items.Clear()
            Dim Item As ControlAccessItemItem
            For Each Item In ItemsNotInFondsList
                Dim ID As New ListViewItem(Item.ID.ToString)
                Dim ItemDesc As New ListViewItem.ListViewSubItem(ID, Item.Item)
                Dim Type As New ListViewItem.ListViewSubItem(ID, Item.Type)
                ID.SubItems.Add(ItemDesc)
                ID.SubItems.Add(Type)
                ListViewAllItems.Items.Add(ID)
            Next

            ListViewFondsItems.Items.Clear()
            For Each Item In ItemsInFondsList
                Dim ID As New ListViewItem(Item.ID.ToString)
                Dim ItemDesc As New ListViewItem.ListViewSubItem(ID, Item.Item)
                Dim Type As New ListViewItem.ListViewSubItem(ID, Item.Type)
                ID.SubItems.Add(ItemDesc)
                ID.SubItems.Add(Type)
                ListViewFondsItems.Items.Add(ID)
            Next

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)

        End Try
    End Sub



    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")


        Dim SelectedItem As ListViewItem
        For Each SelectedItem In ListViewAllItems.SelectedItems
            Dim ItemID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
            Try
                SQLLazyNode.AssociateItemToFonds(SQLServerSettings.Item("ServerAddress"), _
                                                 SQLServerSettings.Item("Database"), _
                                                 SQLServerSettings.Item("Username"), _
                                                 SQLServerSettings.Item("Password"), _
                                                 myFondsID, ItemID _
                                                )


            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)

            End Try
        Next
        Me.LoadItemsFondsList()
        AddButton_Activate(Me, Nothing)

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")


        Dim SelectedItem As ListViewItem
        For Each SelectedItem In ListViewFondsItems.SelectedItems
            Dim ItemID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
            Try
                SQLLazyNode.DeassociateItemFromFonds(SQLServerSettings.Item("ServerAddress"), _
                                                 SQLServerSettings.Item("Database"), _
                                                 SQLServerSettings.Item("Username"), _
                                                 SQLServerSettings.Item("Password"), _
                                                 myFondsID, ItemID _
                                                )


            Catch ex As SqlException
                MessageBoxes.MsgBoxSqlException(ex)
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)

            End Try
        Next
        Me.LoadItemsFondsList()
        RemoveButton_Activate(Me, Nothing)
    End Sub


    Private Sub AddButton_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewAllItems.SelectedIndexChanged
        If ListViewAllItems.SelectedItems.Count > 0 Then
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub RemoveButton_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewFondsItems.SelectedIndexChanged
        If ListViewFondsItems.SelectedItems.Count > 0 Then
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub


    Private Sub ListAllItems_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewAllItems.DoubleClick
        btnAdd_Click(Me, Nothing)
    End Sub

    Private Sub ListFondstems_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListViewFondsItems.DoubleClick
        btnRemove_Click(Me, Nothing)
    End Sub



#End Region


End Class

