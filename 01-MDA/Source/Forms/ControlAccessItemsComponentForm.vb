
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

Public Class ControlAccessItemsComponentForm
    Inherits System.Windows.Forms.Form

#Region "Private Properties"
    Private myFondsID As Integer
    Private myComponentID As Integer
    Private myControlAccess As ControlAccess
#End Region


#Region " Windows Form Designer generated code "


    Public Sub New(ByVal FondsID As Integer, ByRef ControlAccess As ControlAccess)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        myFondsID = FondsID
        myControlAccess = ControlAccess
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
    Friend WithEvents lblControlAccessExisting As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ListViewAllItems As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAllItemsItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAllItemsType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFondsItemsItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFondsItemsType As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblControlAccessComponentItems As System.Windows.Forms.Label
    Friend WithEvents ListViewComponentItems As System.Windows.Forms.ListView
    Friend WithEvents btnCancelControlAccessAssociation As System.Windows.Forms.Button
    Friend WithEvents btnOkControlAccessAssociation As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ControlAccessItemsComponentForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnOkControlAccessAssociation = New System.Windows.Forms.Button
        Me.btnCancelControlAccessAssociation = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.FondsIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblControlAccessComponentItems = New System.Windows.Forms.Label
        Me.lblControlAccessExisting = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.ListViewAllItems = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.chAllItemsItem = New System.Windows.Forms.ColumnHeader
        Me.chAllItemsType = New System.Windows.Forms.ColumnHeader
        Me.ListViewComponentItems = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.chFondsItemsItem = New System.Windows.Forms.ColumnHeader
        Me.chFondsItemsType = New System.Windows.Forms.ColumnHeader
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnOkControlAccessAssociation)
        Me.Panel2.Controls.Add(Me.btnCancelControlAccessAssociation)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 335)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(522, 40)
        Me.Panel2.TabIndex = 4
        '
        'btnOkControlAccessAssociation
        '
        Me.btnOkControlAccessAssociation.BackColor = System.Drawing.Color.White
        Me.btnOkControlAccessAssociation.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOkControlAccessAssociation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOkControlAccessAssociation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOkControlAccessAssociation.ImageIndex = 1
        Me.btnOkControlAccessAssociation.ImageList = Me.imglButtons
        Me.btnOkControlAccessAssociation.Location = New System.Drawing.Point(337, 8)
        Me.btnOkControlAccessAssociation.Name = "btnOkControlAccessAssociation"
        Me.btnOkControlAccessAssociation.Size = New System.Drawing.Size(75, 25)
        Me.btnOkControlAccessAssociation.TabIndex = 3
        Me.btnOkControlAccessAssociation.Text = "&Ok"
        Me.btnOkControlAccessAssociation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelControlAccessAssociation
        '
        Me.btnCancelControlAccessAssociation.BackColor = System.Drawing.Color.White
        Me.btnCancelControlAccessAssociation.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelControlAccessAssociation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelControlAccessAssociation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelControlAccessAssociation.ImageIndex = 0
        Me.btnCancelControlAccessAssociation.ImageList = Me.imglButtons
        Me.btnCancelControlAccessAssociation.Location = New System.Drawing.Point(419, 8)
        Me.btnCancelControlAccessAssociation.Name = "btnCancelControlAccessAssociation"
        Me.btnCancelControlAccessAssociation.Size = New System.Drawing.Size(85, 25)
        Me.btnCancelControlAccessAssociation.TabIndex = 2
        Me.btnCancelControlAccessAssociation.Text = CType(configurationAppSettings.GetValue("btnCancelControlAccessAssociation.Text", GetType(System.String)), String)
        Me.btnCancelControlAccessAssociation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Panel1.Controls.Add(Me.lblControlAccessComponentItems)
        Me.Panel1.Controls.Add(Me.lblControlAccessExisting)
        Me.Panel1.Controls.Add(Me.btnRemove)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.ListViewAllItems)
        Me.Panel1.Controls.Add(Me.ListViewComponentItems)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(522, 335)
        Me.Panel1.TabIndex = 5
        '
        'lblControlAccessComponentItems
        '
        Me.lblControlAccessComponentItems.Location = New System.Drawing.Point(280, 24)
        Me.lblControlAccessComponentItems.Name = "lblControlAccessComponentItems"
        Me.lblControlAccessComponentItems.Size = New System.Drawing.Size(144, 16)
        Me.lblControlAccessComponentItems.TabIndex = 32
        Me.lblControlAccessComponentItems.Text = CType(configurationAppSettings.GetValue("lblControlAccessComponentItems.Text", GetType(System.String)), String)
        '
        'lblControlAccessExisting
        '
        Me.lblControlAccessExisting.Location = New System.Drawing.Point(16, 24)
        Me.lblControlAccessExisting.Name = "lblControlAccessExisting"
        Me.lblControlAccessExisting.Size = New System.Drawing.Size(100, 16)
        Me.lblControlAccessExisting.TabIndex = 31
        Me.lblControlAccessExisting.Text = CType(configurationAppSettings.GetValue("lblControlAccessExisting.Text", GetType(System.String)), String)
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.White
        Me.btnRemove.Enabled = False
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Location = New System.Drawing.Point(240, 168)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(32, 23)
        Me.btnRemove.TabIndex = 30
        Me.btnRemove.Text = "<<"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Enabled = False
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(240, 136)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 23)
        Me.btnAdd.TabIndex = 29
        Me.btnAdd.Text = ">>"
        '
        'ListViewAllItems
        '
        Me.ListViewAllItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewAllItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.chAllItemsItem, Me.chAllItemsType})
        Me.ListViewAllItems.FullRowSelect = True
        Me.ListViewAllItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewAllItems.Location = New System.Drawing.Point(16, 40)
        Me.ListViewAllItems.Name = "ListViewAllItems"
        Me.ListViewAllItems.Size = New System.Drawing.Size(216, 264)
        Me.ListViewAllItems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewAllItems.TabIndex = 28
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
        Me.chAllItemsItem.Width = 139
        '
        'chAllItemsType
        '
        Me.chAllItemsType.Text = CType(configurationAppSettings.GetValue("chAllItemsType.Text", GetType(System.String)), String)
        Me.chAllItemsType.Width = 118
        '
        'ListViewComponentItems
        '
        Me.ListViewComponentItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewComponentItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.chFondsItemsItem, Me.chFondsItemsType})
        Me.ListViewComponentItems.FullRowSelect = True
        Me.ListViewComponentItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewComponentItems.Location = New System.Drawing.Point(280, 40)
        Me.ListViewComponentItems.Name = "ListViewComponentItems"
        Me.ListViewComponentItems.Size = New System.Drawing.Size(224, 264)
        Me.ListViewComponentItems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewComponentItems.TabIndex = 27
        Me.ListViewComponentItems.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'chFondsItemsItem
        '
        Me.chFondsItemsItem.Text = CType(configurationAppSettings.GetValue("chFondsItemsItem.Text", GetType(System.String)), String)
        Me.chFondsItemsItem.Width = 149
        '
        'chFondsItemsType
        '
        Me.chFondsItemsType.Text = CType(configurationAppSettings.GetValue("chFondsItemsType.Text", GetType(System.String)), String)
        Me.chFondsItemsType.Width = 123
        '
        'ControlAccessItemsComponentForm
        '
        Me.AcceptButton = Me.btnOkControlAccessAssociation
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelControlAccessAssociation
        Me.ClientSize = New System.Drawing.Size(522, 375)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 1024)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "ControlAccessItemsComponentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Termos de Indexação"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region






#Region "Items/Components"


    Private Sub LoadComponentItemsList()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Try
            Dim ItemsInFondsList As ControlAccessItemCollection =
                                                        SQLLazyNode.GetControlAccessItemListInFonds(
                                                            SQLServerSettings.Item("ServerAddress"),
                                                            SQLServerSettings.Item("Database"),
                                                            SQLServerSettings.Item("Username"),
                                                            SQLServerSettings.Item("Password"),
                                                            myFondsID
                                                        )

            ListViewAllItems.Items.Clear()
            Dim Item As ControlAccessItemItem
            For Each Item In ItemsInFondsList
                If Not myControlAccess.Contains(New ControlAccessItem(Item.ID)) Then
                    Dim ID As New ListViewItem(Item.ID.ToString)
                    Dim ItemDesc As New ListViewItem.ListViewSubItem(ID, Item.Item)
                    Dim Type As New ListViewItem.ListViewSubItem(ID, Item.Type)
                    ID.SubItems.Add(ItemDesc)
                    ID.SubItems.Add(Type)
                    ListViewAllItems.Items.Add(ID)
                End If
            Next

            ListViewComponentItems.Items.Clear()
            Dim cItem As ControlAccessItem
            For Each cItem In myControlAccess
                Dim ID As New ListViewItem(cItem.ID.ToString)
                Dim ItemDesc As New ListViewItem.ListViewSubItem(ID, cItem.Item)
                Dim Type As New ListViewItem.ListViewSubItem(ID, cItem.Type)
                ID.SubItems.Add(ItemDesc)
                ID.SubItems.Add(Type)
                ListViewComponentItems.Items.Add(ID)
            Next

        Catch ex As SqlException
            MessageBoxes.MsgBoxSqlException(ex)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)

        End Try
    End Sub



    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim SelectedItem As ListViewItem
        For Each SelectedItem In ListViewAllItems.SelectedItems
            Me.ListViewComponentItems.Items.Add(SelectedItem.Clone)
            ListViewAllItems.Items.Remove(SelectedItem)
        Next

        'Me.LoadComponentItemsList()
        AddButton_Activate(Me, Nothing)

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        Dim SelectedItem As ListViewItem
        For Each SelectedItem In ListViewComponentItems.SelectedItems
            ListViewAllItems.Items.Add(SelectedItem.Clone)
            Me.ListViewComponentItems.Items.Remove(SelectedItem)

        Next
        'Me.LoadComponentItemsList()
        RemoveButton_Activate(Me, Nothing)
    End Sub


    Private Sub AddButton_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewAllItems.SelectedIndexChanged
        If ListViewAllItems.SelectedItems.Count > 0 Then
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub RemoveButton_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewComponentItems.SelectedIndexChanged
        If ListViewComponentItems.SelectedItems.Count > 0 Then
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub


    Private Sub ListAllItems_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewAllItems.DoubleClick
        btnAdd_Click(Me, Nothing)
    End Sub

    Private Sub ListFondstems_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewComponentItems.DoubleClick
        btnRemove_Click(Me, Nothing)
    End Sub



#End Region



    Private Sub ControlAccessItemsComponentForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadComponentItemsList()
    End Sub



    Private Sub Upload()
        myControlAccess.Clear()
        Dim Item As ListViewItem
        For Each Item In ListViewComponentItems.Items
            myControlAccess.Add(Item.SubItems(0).Text, Item.SubItems(2).Text, Item.SubItems(1).Text)
        Next
    End Sub

    Private Sub btnOkControlAccessAssociation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkControlAccessAssociation.Click
        Upload()
        Close()
    End Sub
End Class

