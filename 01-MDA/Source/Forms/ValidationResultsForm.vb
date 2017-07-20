
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articula��o com a Direc��o-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordena��o
'* inform�tica da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Portugu�s.
'* ---------------------------------------------------
'*
'* A redistribui��o e utiliza��o deste produto sob a
'* forma de c�digo-fonte ou programa compilado, com ou
'* sem modifica��es, � permitida desde que o seguinte
'* conjunto de condi��es seja cumprido:
'* 
'*	* Todas as redistribui��es do c�digo-fonte 
'*	  deste produto dever�o ser acompanhadas do
'*	  texto que comp�e esta licen�a, incluindo o 
'*	  texto inicial de atribui��o de autoria,
'*	  esta lista de condi��es e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direc��o-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto n�o dever�o ser utilizados na 
'*	  promo��o de produtos derivados deste 
'*	  sem que seja obtido consentimento pr�vio, por
'*	  escrito, por parte dos visados.

'*	* A utiliza��o da designa��o DigitArq, seus 
'*	  log�tipos e nomes institucionais associados
'*	  � apenas permitida em distribui��es que sejam
'*	  c�pias exactas da vers�o oficial deste produto
'*	  aprovada e/ou distribu�da pela Direc��o-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto � permitido desde que a designa��o 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais n�o sejam utilizados em todo e
'*	  qualquer tipo de distribui��o e/ou promo��o 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE � DISTRIBUIDO PELA DIREC��O-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUN��O DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS N�O LIMITADO A, GARANTIAS ASSOCIADAS
'* A COM�RCIO DE PRODUTOS OU DECLARA��O DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNST�NCIA PODER� A DIREC��O-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONS�VEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZA��O DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS N�O LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FAL�NCIA, INDEVIDA PRESTA��O DE SERVI�OS
'* OU NEGLIG�NCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORR�NCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informa��o sobre este produto ou a sua 
'* licen�a, � favor consultar o endere�o electr�nico
'* http://www.digitarq.pt

#End Region

Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration
Imports System.IO

Public Class ValidationResultsForm
    Inherits System.Windows.Forms.Form


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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents OtherLevelIcons As System.Windows.Forms.ImageList
    Friend WithEvents chOtherLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUnitId As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUnitTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents btnGoto As System.Windows.Forms.Button
    Friend WithEvents chErrorDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblErrorCount As System.Windows.Forms.Label
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ValidationResultsForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblErrorCount = New System.Windows.Forms.Label
        Me.btnGoto = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListView = New System.Windows.Forms.ListView
        Me.chOtherLevel = New System.Windows.Forms.ColumnHeader
        Me.chUnitId = New System.Windows.Forms.ColumnHeader
        Me.chUnitTitle = New System.Windows.Forms.ColumnHeader
        Me.chErrorDescription = New System.Windows.Forms.ColumnHeader
        Me.chID = New System.Windows.Forms.ColumnHeader
        Me.OtherLevelIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblErrorCount)
        Me.Panel2.Controls.Add(Me.btnGoto)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 295)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(546, 40)
        Me.Panel2.TabIndex = 4
        '
        'lblErrorCount
        '
        Me.lblErrorCount.Location = New System.Drawing.Point(16, 8)
        Me.lblErrorCount.Name = "lblErrorCount"
        Me.lblErrorCount.Size = New System.Drawing.Size(328, 25)
        Me.lblErrorCount.TabIndex = 4
        Me.lblErrorCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGoto
        '
        Me.btnGoto.BackColor = System.Drawing.Color.White
        Me.btnGoto.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGoto.Location = New System.Drawing.Point(382, 8)
        Me.btnGoto.Name = "btnGoto"
        Me.btnGoto.Size = New System.Drawing.Size(75, 25)
        Me.btnGoto.TabIndex = 3
        Me.btnGoto.Text = CType(configurationAppSettings.GetValue("FindResults.btnGoto.Text", GetType(System.String)), String)
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageIndex = 0
        Me.btnClose.ImageList = Me.imglButtons
        Me.btnClose.Location = New System.Drawing.Point(464, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 25)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = CType(configurationAppSettings.GetValue("FindResults.btnClose.Text", GetType(System.String)), String)
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListView)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 295)
        Me.Panel1.TabIndex = 5
        '
        'ListView
        '
        Me.ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chOtherLevel, Me.chUnitId, Me.chUnitTitle, Me.chErrorDescription, Me.chID})
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.FullRowSelect = True
        Me.ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView.Location = New System.Drawing.Point(0, 0)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(546, 295)
        Me.ListView.SmallImageList = Me.OtherLevelIcons
        Me.ListView.TabIndex = 26
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'chOtherLevel
        '
        Me.chOtherLevel.Text = ""
        Me.chOtherLevel.Width = 20
        '
        'chUnitId
        '
        Me.chUnitId.Text = "Refer�ncia"
        Me.chUnitId.Width = 69
        '
        'chUnitTitle
        '
        Me.chUnitTitle.Text = "T�tulo"
        Me.chUnitTitle.Width = 154
        '
        'chErrorDescription
        '
        Me.chErrorDescription.Text = CType(configurationAppSettings.GetValue("chErrorDescription.Text", GetType(System.String)), String)
        Me.chErrorDescription.Width = 278
        '
        'chID
        '
        Me.chID.Text = "ID"
        Me.chID.Width = 0
        '
        'OtherLevelIcons
        '
        Me.OtherLevelIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.OtherLevelIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.OtherLevelIcons.ImageStream = CType(resources.GetObject("OtherLevelIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.OtherLevelIcons.TransparentColor = System.Drawing.Color.OldLace
        '
        'ValidationResultsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(546, 335)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 1024)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "ValidationResultsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resultados"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myValidationResults As ValidationErrorCollection
    Private myLazyTree As LazyTree

    Public Sub New(ByVal ValidationResults As ValidationErrorCollection, ByVal LazyTree As LazyTree)
        Me.New()
        myLazyTree = LazyTree
        myValidationResults = ValidationResults
    End Sub



    Private Sub FindResultsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadResultsList()
    End Sub



    Private Sub LoadResultsList()
        ListView.Items.Clear()
        Dim ValidationError As ValidationError
        For Each ValidationError In myValidationResults
            Dim Row As New ListViewItem("", ValidationError.LazyNode.OtherLevelIndex)
            Row.UseItemStyleForSubItems = False
            Dim Icon As New ListViewItem.ListViewSubItem(Row, "")
            Dim UnitId As New ListViewItem.ListViewSubItem(Row, ValidationError.LazyNode.UnitId)
            Dim UnitTitle As New ListViewItem.ListViewSubItem(Row, ValidationError.LazyNode.UnitTitle)
            Dim ErrorDescription As New ListViewItem.ListViewSubItem(Row, ValidationError.ErrorDescription)
            Dim ID As New ListViewItem.ListViewSubItem(Row, IntToStr(ValidationError.LazyNode.ID))

            Row.SubItems.Add(UnitId)
            Row.SubItems.Add(UnitTitle)
            Row.SubItems.Add(ErrorDescription)
            Row.SubItems.Add(ID)
            ListView.Items.Add(Row)
        Next
        lblErrorCount.Text = String.Format(InfoMessage("ValidationResults.ErrorCount"), ListView.Items.Count)

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnGoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoto.Click
        If ListView.SelectedIndices.Count <> 1 Then Exit Sub
        If myLazyTree Is Nothing Then Exit Sub
        myLazyTree.SelectedLazyNode = myValidationResults.Item(ListView.SelectedIndices.Item(0)).LazyNode
    End Sub

    Private Sub ListView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView.DoubleClick
        btnGoto_Click(sender, e)
    End Sub
End Class

