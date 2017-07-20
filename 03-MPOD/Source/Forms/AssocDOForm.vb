
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

Public Class AssocDOForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal DigitalObjectName As String, ByVal DigitalObjectID As Integer, Optional ByVal FileName As String = "", Optional ByVal FileID As Int64 = -1)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        DOName = DigitalObjectName
        DOID = DigitalObjectID
        DOFileName = FileName
        DOFileID = FileID
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvwDescriptions As System.Windows.Forms.ListView
    Friend WithEvents imglTvwDigitarq As System.Windows.Forms.ImageList
    Friend WithEvents btnRemoveAssociation As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents gbxDescriptions As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssocDOForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.imglTvwDigitarq = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxDescriptions = New System.Windows.Forms.GroupBox
        Me.lvwDescriptions = New System.Windows.Forms.ListView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnRemoveAssociation = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnClose = New System.Windows.Forms.Button
        Me.gbxDescriptions.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'imglTvwDigitarq
        '
        Me.imglTvwDigitarq.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglTvwDigitarq.ImageStream = CType(resources.GetObject("imglTvwDigitarq.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglTvwDigitarq.TransparentColor = System.Drawing.Color.Transparent
        '
        'gbxDescriptions
        '
        Me.gbxDescriptions.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxDescriptions.Controls.Add(Me.lvwDescriptions)
        Me.gbxDescriptions.Location = New System.Drawing.Point(8, 8)
        Me.gbxDescriptions.Name = "gbxDescriptions"
        Me.gbxDescriptions.Size = New System.Drawing.Size(504, 216)
        Me.gbxDescriptions.TabIndex = 2
        Me.gbxDescriptions.TabStop = False
        Me.gbxDescriptions.Text = "Descri��es"
        '
        'lvwDescriptions
        '
        Me.lvwDescriptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwDescriptions.HideSelection = False
        Me.lvwDescriptions.Location = New System.Drawing.Point(8, 16)
        Me.lvwDescriptions.Name = "lvwDescriptions"
        Me.lvwDescriptions.Size = New System.Drawing.Size(488, 192)
        Me.lvwDescriptions.SmallImageList = Me.imglTvwDigitarq
        Me.lvwDescriptions.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.btnRemoveAssociation)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(504, 48)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'btnRemoveAssociation
        '
        Me.btnRemoveAssociation.BackColor = System.Drawing.Color.White
        Me.btnRemoveAssociation.Enabled = False
        Me.btnRemoveAssociation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveAssociation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveAssociation.ImageIndex = 1
        Me.btnRemoveAssociation.ImageList = Me.imglButtons
        Me.btnRemoveAssociation.Location = New System.Drawing.Point(267, 14)
        Me.btnRemoveAssociation.Name = "btnRemoveAssociation"
        Me.btnRemoveAssociation.Size = New System.Drawing.Size(142, 25)
        Me.btnRemoveAssociation.TabIndex = 8
        Me.btnRemoveAssociation.Text = CType(configurationAppSettings.GetValue("btnDeleteAssociation.Text", GetType(System.String)), String)
        Me.btnRemoveAssociation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageIndex = 5
        Me.btnClose.ImageList = Me.imglButtons
        Me.btnClose.Location = New System.Drawing.Point(416, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 25)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = CType(configurationAppSettings.GetValue("btnClose.Text", GetType(System.String)), String)
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AssocDOForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(520, 278)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbxDescriptions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "AssocDOForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxDescriptions.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim database As New database
    Private DOName As String
    Private DOID As Int64
    Private DOFileName As String
    Private DOFileID As Int64
    Public DeletedItem As Boolean = False


    Private Sub ConsultAssocs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DOFileID <> -1 Then
            Me.Text = GetFormTitle("[" & DOName & "/" & DOFileName & "]")
        Else
            Me.Text = GetFormTitle("[" & DOName & "]")
        End If
        CreateLvwDO()
        LoadDescriptions()
    End Sub

    Private Sub CreateLvwDO()
        Me.lvwDescriptions.View = View.Details
        Me.lvwDescriptions.LabelEdit = False
        Me.lvwDescriptions.AllowColumnReorder = False
        Me.lvwDescriptions.FullRowSelect = True
        Me.lvwDescriptions.MultiSelect = True

        Me.lvwDescriptions.Columns.Add("Refer�ncia", Convert.ToInt32(Me.lvwDescriptions.Width * 0.6), HorizontalAlignment.Left)
        Me.lvwDescriptions.Columns.Add("T�tulo", Convert.ToInt32(Me.lvwDescriptions.Width * 0.4), HorizontalAlignment.Left)
    End Sub

    Private Sub LoadDescriptions()
        Dim myData As New DataSet
        Dim myTable As DataTable
        myData = database.SelectInfoAssociations(DOID, DOFileID)
        myTable = myData.Tables(0)
        Me.lvwDescriptions.Items.Clear()

        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            Me.btnRemoveAssociation.Enabled = True

            Dim lvi As ListViewItem = New ListViewItem(myRow.Item("CompleteUnitID").ToString())
            lvi.SubItems.Add(myRow.Item("UnitTitle").ToString())
            lvi.Tag = myRow.Item("ID").ToString
            lvi.ImageIndex = getImageIndex(myRow.Item("OtherLevel"))

            Me.lvwDescriptions.Items.Add(lvi)
        Next
        Me.gbxDescriptions.Text = "Descri��es [" & Me.lvwDescriptions.Items.Count.ToString & "]"
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

    Private Sub ConsultAssocs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnRemoveAssociation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAssociation.Click
        Dim index As Integer
        If Me.lvwDescriptions.SelectedItems.Count > 0 Then
            For i As Integer = 0 To Me.lvwDescriptions.SelectedItems.Count - 1
                database.DeleteAssociation(Me.lvwDescriptions.SelectedItems(i).Tag, DOID, DOFileID)
            Next
            DeletedItem = True
            LoadDescriptions()
        End If
        If Me.lvwDescriptions.Items.Count > 0 Then
            Me.lvwDescriptions.Items(0).Selected = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class
