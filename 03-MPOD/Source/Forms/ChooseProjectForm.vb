
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

Public Class ChooseProjectForm
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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents gbxProjects As System.Windows.Forms.GroupBox
    Friend WithEvents gbxButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnOpenProject As System.Windows.Forms.Button
    Friend WithEvents lvwProjects As System.Windows.Forms.ListView
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChooseProjectForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.gbxProjects = New System.Windows.Forms.GroupBox
        Me.lvwProjects = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxButtons = New System.Windows.Forms.GroupBox
        Me.btnOpenProject = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxProjects.SuspendLayout()
        Me.gbxButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxProjects
        '
        Me.gbxProjects.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxProjects.Controls.Add(Me.lvwProjects)
        Me.gbxProjects.Location = New System.Drawing.Point(8, 6)
        Me.gbxProjects.Name = "gbxProjects"
        Me.gbxProjects.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbxProjects.Size = New System.Drawing.Size(552, 256)
        Me.gbxProjects.TabIndex = 2
        Me.gbxProjects.TabStop = False
        Me.gbxProjects.Text = "Projectos"
        '
        'lvwProjects
        '
        Me.lvwProjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwProjects.Location = New System.Drawing.Point(16, 24)
        Me.lvwProjects.Name = "lvwProjects"
        Me.lvwProjects.Size = New System.Drawing.Size(520, 197)
        Me.lvwProjects.TabIndex = 6
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'gbxButtons
        '
        Me.gbxButtons.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxButtons.Controls.Add(Me.btnOpenProject)
        Me.gbxButtons.Location = New System.Drawing.Point(8, 267)
        Me.gbxButtons.Name = "gbxButtons"
        Me.gbxButtons.Size = New System.Drawing.Size(552, 48)
        Me.gbxButtons.TabIndex = 3
        Me.gbxButtons.TabStop = False
        '
        'btnOpenProject
        '
        Me.btnOpenProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenProject.BackColor = System.Drawing.Color.White
        Me.btnOpenProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpenProject.ImageIndex = 6
        Me.btnOpenProject.ImageList = Me.imglButtons
        Me.btnOpenProject.Location = New System.Drawing.Point(432, 13)
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.Size = New System.Drawing.Size(104, 25)
        Me.btnOpenProject.TabIndex = 8
        Me.btnOpenProject.Text = CType(configurationAppSettings.GetValue("btnOpenProject.Text", GetType(System.String)), String)
        Me.btnOpenProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'ChooseProjectForm
        '
        Me.AcceptButton = Me.btnOpenProject
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(568, 325)
        Me.Controls.Add(Me.gbxButtons)
        Me.Controls.Add(Me.gbxProjects)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ChooseProjectForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxProjects.ResumeLayout(False)
        Me.gbxButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private database As New database
    Private myData As New DataSet
    Private myProjectID As Int64
    Private myProjectName As String


#Region "ChooseProject Form"

    Private Sub ChooseProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = GetFormTitle("[" & Constants.UserLogon & "]")
            CreateLvwProjects()
            LoadData()
            If Me.lvwProjects.Items.Count > 0 Then
                Me.lvwProjects.Items(0).Selected = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        goToDigitalObjects()
    End Sub

    Private Sub lbxProjects_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        goToDigitalObjects()
    End Sub

    Private Sub goToDigitalObjects()
        If Me.lvwProjects.SelectedItems.Count > 0 Then
            Me.ProjectID = Me.lvwProjects.SelectedItems(0).Tag
            Me.ProjectName = Me.lvwProjects.SelectedItems(0).Text
            Me.Close()
        End If
    End Sub

    'Private Sub lbxProjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.BindingContext(myData, myData.Tables(0).ToString).Position = Me.lbxProjects.SelectedIndex
    'End Sub

    Private Sub ChooseProject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            goToDigitalObjects()
        End If
    End Sub

#End Region


#Region "Load Data"

    Private Sub CreateLvwProjects()
        Me.lvwProjects.View = View.Details
        Me.lvwProjects.LabelEdit = False
        Me.lvwProjects.FullRowSelect = True
        Me.lvwProjects.MultiSelect = False

        ' Create columns for the items and subitems.
        Me.lvwProjects.Columns.Add("Designação", 150, HorizontalAlignment.Left)
        Me.lvwProjects.Columns.Add("", 30, HorizontalAlignment.Right)
        Me.lvwProjects.Columns.Add("Responsável", 120, HorizontalAlignment.Left)
        Me.lvwProjects.Columns.Add("Data criação", 100, HorizontalAlignment.Left)
        Me.lvwProjects.Columns.Add("Última alteração", 100, HorizontalAlignment.Left)
    End Sub

    Private Sub LoadData()
        myData = New DataSet
        myData = database.SelectAllProjects()

        If myData.Tables.Count <> 0 Then
            FillListView(myData)
        End If

        If Me.lvwProjects.Items.Count = 0 Then
            MsgBox(InfoMessage("ChooseProjects.EmptyProjectList"), MsgBoxStyle.Exclamation)
            Application.Exit()
        End If
    End Sub

    Private Sub FillListView(ByVal myData As DataSet)

        'Dim array As ArrayList = database.SelectProjectsToCheck
        Dim DOtoCheck As Boolean = False
        Dim myTable As DataTable = myData.Tables(0)

        Me.lvwProjects.Items.Clear()
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            If (myRow.RowState <> DataRowState.Deleted) Then
                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("Name").ToString())
                lvi.SubItems.Add(myRow.Item("DOCount").ToString())
                lvi.SubItems.Add(myRow.Item("Username").ToString())
                lvi.SubItems.Add(myRow.Item("CreationDateTime").ToString())
                lvi.SubItems.Add(myRow.Item("LastUpdateDateTime").ToString())

                lvi.Tag = myRow.Item("ProjectID")
                Me.lvwProjects.Items.Add(lvi)
            End If
        Next
        Me.gbxProjects.Text = "Projectos [" & Me.lvwProjects.Items.Count & "]"
    End Sub

    Private Sub btnOpenProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenProject.Click
        goToDigitalObjects()
    End Sub

    Private Sub lvwProjects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwProjects.DoubleClick
        goToDigitalObjects()
    End Sub

#End Region


#Region "Properties"

    Public Property ProjectID() As Int64
        Get
            Return myProjectID
        End Get
        Set(ByVal Value As Int64)
            myProjectID = Value
        End Set
    End Property

    Public Property ProjectName() As String
        Get
            Return myProjectName
        End Get
        Set(ByVal Value As String)
            myProjectName = Value
        End Set
    End Property

#End Region


End Class
