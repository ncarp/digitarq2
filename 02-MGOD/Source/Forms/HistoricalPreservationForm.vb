
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

Imports System.IO

Public Class HistoricalPreservationForm
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intDigitalObjectID As Integer)
        MyBase.New()

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvwHistoricalPreservation As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvwNorms As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HistoricalPreservationForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lvwHistoricalPreservation = New System.Windows.Forms.ListView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lvwNorms = New System.Windows.Forms.ListView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.lvwHistoricalPreservation)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(876, 280)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hist�rico"
        '
        'lvwHistoricalPreservation
        '
        Me.lvwHistoricalPreservation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwHistoricalPreservation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwHistoricalPreservation.FullRowSelect = True
        Me.lvwHistoricalPreservation.GridLines = True
        Me.lvwHistoricalPreservation.Location = New System.Drawing.Point(8, 24)
        Me.lvwHistoricalPreservation.Name = "lvwHistoricalPreservation"
        Me.lvwHistoricalPreservation.Size = New System.Drawing.Size(860, 248)
        Me.lvwHistoricalPreservation.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.lvwNorms)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 304)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(876, 128)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Normas de reformata��o utilizadas"
        '
        'lvwNorms
        '
        Me.lvwNorms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwNorms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwNorms.FullRowSelect = True
        Me.lvwNorms.GridLines = True
        Me.lvwNorms.Location = New System.Drawing.Point(8, 24)
        Me.lvwNorms.Name = "lvwNorms"
        Me.lvwNorms.Size = New System.Drawing.Size(860, 96)
        Me.lvwNorms.TabIndex = 1
        '
        'HistoricalPreservationForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(892, 446)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HistoricalPreservationForm"
        Me.Text = "Hist�rico das ac��es de reformata��o do OD"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myDigitalObjectID As Int64
    Private myHistoricalPreservation As DataSet
    Private database As New SqlCommands

    Private Sub HistoricalPreservationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lvwHistoricalPreservation.View = View.Details
        lvwHistoricalPreservation.LabelEdit = False
        lvwHistoricalPreservation.AllowColumnReorder = True
        lvwHistoricalPreservation.FullRowSelect = True
        lvwHistoricalPreservation.MultiSelect = True

        lvwHistoricalPreservation.Columns.Add("", 0, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("Data migra��o", 90, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("Data revis�o", 90, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("Transformador", 90, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("Plataforma", 90, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("Dispositivo visualiza��o", 150, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("Formato de entrada", 110, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("Par�metros", 90, HorizontalAlignment.Left)
        lvwHistoricalPreservation.Columns.Add("M�todo de Reformata��o", 150, HorizontalAlignment.Left)

        lvwNorms.View = View.Details
        lvwNorms.LabelEdit = False
        lvwNorms.AllowColumnReorder = True
        lvwNorms.FullRowSelect = True
        lvwNorms.MultiSelect = True

        lvwNorms.Columns.Add("Norma", 400, HorizontalAlignment.Left)
        lvwNorms.Columns.Add("Descri��o", 460, HorizontalAlignment.Left)

        LoadListView()
    End Sub

    Private Sub LoadListView()
        Me.myHistoricalPreservation = database.SelectHistoricalPresevation(myDigitalObjectID)
        Dim myTable As DataTable = Me.myHistoricalPreservation.Tables(0)

        'Clear the ListView control
        Me.lvwHistoricalPreservation.Items.Clear()

        'Display items in the ListView control
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)

            If (myRow.RowState <> DataRowState.Deleted) Then

                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("PreservationActionID").ToString())
                lvi.SubItems.Add(myRow.Item("ArchiveNextDateTime").ToString())
                lvi.SubItems.Add(myRow.Item("RevisionDateTime").ToString())
                lvi.SubItems.Add(myRow.Item("Transformer").ToString())
                lvi.SubItems.Add(myRow.Item("Platform").ToString())
                lvi.SubItems.Add(myRow.Item("RenderEngine").ToString())
                lvi.SubItems.Add(myRow.Item("InputFormat").ToString())
                lvi.SubItems.Add(myRow.Item("Parameters").ToString())
                lvi.SubItems.Add(myRow.Item("ReformattingMethod").ToString())

                Me.lvwHistoricalPreservation.Items.Add(lvi)
            End If
        Next
    End Sub

    Private Sub LoadNormsListView(ByVal intPreservationActionID As Integer)
        Dim dsNorms As DataSet = database.SelectReformattingNorms(intPreservationActionID)
        Dim myTable As DataTable = dsNorms.Tables(0)

        'Clear the ListView control
        Me.lvwNorms.Items.Clear()

        'Display items in the ListView control
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)

            If (myRow.RowState <> DataRowState.Deleted) Then
                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("ReformattingNorm").ToString())
                lvi.SubItems.Add(myRow.Item("Description").ToString())
                lvi.Tag = myRow.Item("ReformattingNormID").ToString()

                Me.lvwNorms.Items.Add(lvi)
            End If
        Next
    End Sub

    Private Sub lvwHistoricalPreservation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwHistoricalPreservation.SelectedIndexChanged
        If Me.lvwHistoricalPreservation.SelectedItems.Count > 0 Then
            LoadNormsListView(CInt(Me.lvwHistoricalPreservation.SelectedItems(0).SubItems(0).Text))
        End If
    End Sub

End Class
