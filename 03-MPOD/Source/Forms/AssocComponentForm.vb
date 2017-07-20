
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

Public Class AssocComponentForm
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strDOName As String, ByVal intComponentID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        myDOName = strDOName
        myComponentID = intComponentID
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
    Friend WithEvents lvwDigitalObjects As System.Windows.Forms.ListView
    Friend WithEvents imglTvwImages As System.Windows.Forms.ImageList
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAssociation As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents gbxDigitalObjects As System.Windows.Forms.GroupBox
    Friend WithEvents gbxButtons As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssocComponentForm))
        Me.gbxDigitalObjects = New System.Windows.Forms.GroupBox
        Me.lvwDigitalObjects = New System.Windows.Forms.ListView
        Me.imglTvwImages = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxButtons = New System.Windows.Forms.GroupBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnRemoveAssociation = New System.Windows.Forms.Button
        Me.gbxDigitalObjects.SuspendLayout()
        Me.gbxButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxDigitalObjects
        '
        Me.gbxDigitalObjects.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxDigitalObjects.Controls.Add(Me.lvwDigitalObjects)
        Me.gbxDigitalObjects.Location = New System.Drawing.Point(8, 8)
        Me.gbxDigitalObjects.Name = "gbxDigitalObjects"
        Me.gbxDigitalObjects.Size = New System.Drawing.Size(504, 216)
        Me.gbxDigitalObjects.TabIndex = 1
        Me.gbxDigitalObjects.TabStop = False
        Me.gbxDigitalObjects.Text = CType(configurationAppSettings.GetValue("AC.gbxDigitalObjects.Text", GetType(System.String)), String)
        '
        'lvwDigitalObjects
        '
        Me.lvwDigitalObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwDigitalObjects.HideSelection = False
        Me.lvwDigitalObjects.Location = New System.Drawing.Point(8, 16)
        Me.lvwDigitalObjects.Name = "lvwDigitalObjects"
        Me.lvwDigitalObjects.Size = New System.Drawing.Size(488, 192)
        Me.lvwDigitalObjects.SmallImageList = Me.imglTvwImages
        Me.lvwDigitalObjects.TabIndex = 0
        '
        'imglTvwImages
        '
        Me.imglTvwImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglTvwImages.ImageStream = CType(resources.GetObject("imglTvwImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglTvwImages.TransparentColor = System.Drawing.Color.Transparent
        '
        'gbxButtons
        '
        Me.gbxButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxButtons.Controls.Add(Me.btnClose)
        Me.gbxButtons.Controls.Add(Me.btnRemoveAssociation)
        Me.gbxButtons.Location = New System.Drawing.Point(8, 224)
        Me.gbxButtons.Name = "gbxButtons"
        Me.gbxButtons.Size = New System.Drawing.Size(504, 48)
        Me.gbxButtons.TabIndex = 9
        Me.gbxButtons.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageIndex = 5
        Me.btnClose.ImageList = Me.imglButtons
        Me.btnClose.Location = New System.Drawing.Point(416, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 25)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = CType(configurationAppSettings.GetValue("btnClose.Text", GetType(System.String)), String)
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnRemoveAssociation
        '
        Me.btnRemoveAssociation.BackColor = System.Drawing.Color.White
        Me.btnRemoveAssociation.Enabled = False
        Me.btnRemoveAssociation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveAssociation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveAssociation.ImageIndex = 1
        Me.btnRemoveAssociation.ImageList = Me.imglButtons
        Me.btnRemoveAssociation.Location = New System.Drawing.Point(273, 14)
        Me.btnRemoveAssociation.Name = "btnRemoveAssociation"
        Me.btnRemoveAssociation.Size = New System.Drawing.Size(136, 25)
        Me.btnRemoveAssociation.TabIndex = 9
        Me.btnRemoveAssociation.Text = CType(configurationAppSettings.GetValue("btnDeleteAssociation.Text", GetType(System.String)), String)
        Me.btnRemoveAssociation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AssocComponentForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(520, 278)
        Me.Controls.Add(Me.gbxButtons)
        Me.Controls.Add(Me.gbxDigitalObjects)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AssocComponentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxDigitalObjects.ResumeLayout(False)
        Me.gbxButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myDOName As String
    Private myComponentID As Int64
    Private database As New database
    Public DeletedItem As Boolean

    Private Sub AssocComponentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = GetFormTitle("[" & myDOName & "]")
        CreateLvwDO()
        LoadDigitalObjects()
    End Sub

    Private Sub CreateLvwDO()
        Me.lvwDigitalObjects.View = View.Details
        Me.lvwDigitalObjects.LabelEdit = False
        Me.lvwDigitalObjects.AllowColumnReorder = False
        Me.lvwDigitalObjects.FullRowSelect = True
        Me.lvwDigitalObjects.MultiSelect = True

        Me.lvwDigitalObjects.Columns.Add("     Projecto", Convert.ToInt32(Me.lvwDigitalObjects.Width * 0.3), HorizontalAlignment.Left)
        Me.lvwDigitalObjects.Columns.Add("Objecto Digital", Convert.ToInt32(Me.lvwDigitalObjects.Width * 0.4), HorizontalAlignment.Left)
        Me.lvwDigitalObjects.Columns.Add("Ficheiro", Convert.ToInt32(Me.lvwDigitalObjects.Width * 0.3), HorizontalAlignment.Left)
    End Sub

    Private Sub LoadDigitalObjects()
        Dim myData As New DataSet
        Dim myTable As DataTable
        myData = database.SelectInfoAssociationsF(myComponentID)
        myTable = myData.Tables(0)
        Me.lvwDigitalObjects.Items.Clear()

        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            Dim a(2) As Int64
            Me.btnRemoveAssociation.Enabled = True

            Dim lvi As ListViewItem = New ListViewItem(myRow.Item("ProjectName").ToString())
            lvi.SubItems.Add(myRow.Item("DOName").ToString())
            lvi.SubItems.Add(myRow.Item("DOFileName").ToString())
            a(1) = myRow.Item("DigitalObjectID")
            a(2) = myRow.Item("FileID")
            lvi.Tag = a
            If myRow.Item("Type") Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 1
            End If

            Me.lvwDigitalObjects.Items.Add(lvi)
        Next
        Me.gbxDigitalObjects.Text = "Objectos digitais [" & Me.lvwDigitalObjects.Items.Count.ToString & "]"
    End Sub

    Private Sub AssocComponentForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub RemoveAssociation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAssociation.Click
        If Me.lvwDigitalObjects.SelectedItems.Count > 0 Then
            For i As Integer = 0 To Me.lvwDigitalObjects.SelectedItems.Count - 1
                database.DeleteAssociation(myComponentID, Me.lvwDigitalObjects.SelectedItems(i).Tag(1), Me.lvwDigitalObjects.SelectedItems(i).Tag(2))
            Next
            LoadDigitalObjects()
            DeletedItem = True
        End If
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class
