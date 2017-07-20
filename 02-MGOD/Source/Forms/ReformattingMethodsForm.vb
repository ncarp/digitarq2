
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

Public Class ReformattingMethodsForm
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
    Friend WithEvents btnChoose As System.Windows.Forms.Button
    Friend WithEvents gbxNorms As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As MGOD.ColorButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As MGOD.ColorButton
    Friend WithEvents txtDescription As MGOD.ColorTextBox
    Friend WithEvents txtNorm As MGOD.ColorTextBox
    Friend WithEvents lvwMethods As System.Windows.Forms.ListView
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReformattingMethodsForm))
        Me.btnChoose = New System.Windows.Forms.Button
        Me.gbxNorms = New System.Windows.Forms.GroupBox
        Me.lvwMethods = New System.Windows.Forms.ListView
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New MGOD.ColorButton
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New MGOD.ColorButton
        Me.txtDescription = New MGOD.ColorTextBox
        Me.txtNorm = New MGOD.ColorTextBox
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxNorms.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnChoose
        '
        Me.btnChoose.BackColor = System.Drawing.Color.White
        Me.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChoose.ImageIndex = 0
        Me.btnChoose.ImageList = Me.imglButtons
        Me.btnChoose.Location = New System.Drawing.Point(638, 127)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(88, 25)
        Me.btnChoose.TabIndex = 120
        Me.btnChoose.Text = "Adicionar"
        Me.btnChoose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbxNorms
        '
        Me.gbxNorms.Controls.Add(Me.lvwMethods)
        Me.gbxNorms.Location = New System.Drawing.Point(15, 15)
        Me.gbxNorms.Name = "gbxNorms"
        Me.gbxNorms.Size = New System.Drawing.Size(616, 240)
        Me.gbxNorms.TabIndex = 119
        Me.gbxNorms.TabStop = False
        Me.gbxNorms.Text = "Métodos"
        '
        'lvwMethods
        '
        Me.lvwMethods.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwMethods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwMethods.GridLines = True
        Me.lvwMethods.LabelEdit = True
        Me.lvwMethods.Location = New System.Drawing.Point(8, 16)
        Me.lvwMethods.Name = "lvwMethods"
        Me.lvwMethods.Size = New System.Drawing.Size(600, 216)
        Me.lvwMethods.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.White
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imglButtons
        Me.btnDelete.Location = New System.Drawing.Point(638, 95)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(88, 25)
        Me.btnDelete.TabIndex = 118
        Me.btnDelete.Text = CType(configurationAppSettings.GetValue("btnDelete.Text", GetType(System.String)), String)
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNew
        '
        Me.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNew.BackColor = System.Drawing.SystemColors.Window
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.ImageIndex = 0
        Me.btnNew.ImageList = Me.imglButtons
        Me.btnNew.Location = New System.Drawing.Point(638, 31)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(88, 25)
        Me.btnNew.TabIndex = 117
        Me.btnNew.Text = CType(configurationAppSettings.GetValue("btnNew.Text", GetType(System.String)), String)
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.ImageIndex = 2
        Me.btnSave.ImageList = Me.imglButtons
        Me.btnSave.Location = New System.Drawing.Point(638, 263)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 25)
        Me.btnSave.TabIndex = 116
        Me.btnSave.Text = CType(configurationAppSettings.GetValue("btnSave.Text", GetType(System.String)), String)
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Window
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 3
        Me.btnEdit.ImageList = Me.imglButtons
        Me.btnEdit.Location = New System.Drawing.Point(638, 63)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(88, 25)
        Me.btnEdit.TabIndex = 115
        Me.btnEdit.Text = CType(configurationAppSettings.GetValue("btnEdit.Text", GetType(System.String)), String)
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(24, 287)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(600, 32)
        Me.txtDescription.TabIndex = 114
        Me.txtDescription.Text = "Descrição"
        Me.txtDescription.Visible = False
        '
        'txtNorm
        '
        Me.txtNorm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNorm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNorm.Location = New System.Drawing.Point(24, 263)
        Me.txtNorm.Name = "txtNorm"
        Me.txtNorm.Size = New System.Drawing.Size(600, 20)
        Me.txtNorm.TabIndex = 113
        Me.txtNorm.Text = "Método"
        Me.txtNorm.Visible = False
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'ReformattingMethodsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(736, 334)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.gbxNorms)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtNorm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ReformattingMethodsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Métodos de reformatação"
        Me.gbxNorms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private database As New SqlCommands
    Private myReformattingMethods As DataSet
    'Public myReformattingMethodsChoosen As Collection


    Private Sub ReformattingMethodsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lvwMethods.View = View.Details
        lvwMethods.LabelEdit = False
        lvwMethods.AllowColumnReorder = True
        lvwMethods.FullRowSelect = True
        lvwMethods.MultiSelect = True
        lvwMethods.CheckBoxes = True

        lvwMethods.Columns.Add("Método", 250, HorizontalAlignment.Left)
        lvwMethods.Columns.Add("Descrição", 350, HorizontalAlignment.Left)

        LoadListView()
    End Sub

    Private Sub LoadListView()
        Me.myReformattingMethods = database.SelectAllReformattingMethods
        Dim myTable As DataTable = myReformattingMethods.Tables(0)

        'Clear the ListView control
        Me.lvwMethods.Items.Clear()

        'Display items in the ListView control
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            'Only row that have not been deleted
            If (myRow.RowState <> DataRowState.Deleted) Then

                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("ReformattingMethod").ToString())
                lvi.SubItems.Add(myRow.Item("Description").ToString())
                lvi.Tag = myRow.Item("ReformattingMethodID")

                Me.lvwMethods.Items.Add(lvi)
            End If
        Next
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If lvwMethods.SelectedIndices.Count = 0 Then
            MsgBox("Não está nenhum item seleccionado!")
        Else
            Me.txtNorm.Visible = True
            Me.txtDescription.Visible = True
            Me.btnSave.Visible = True
            Me.btnSave.Tag = "Update"
            Me.txtNorm.Text = Me.lvwMethods.SelectedItems.Item(0).SubItems(0).Text
            Me.txtDescription.Text = Me.lvwMethods.SelectedItems.Item(0).SubItems(1).Text
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.txtNorm.Visible = True
        Me.txtDescription.Visible = True
        Me.btnSave.Visible = True
        Me.btnSave.Tag = "New"
        Me.txtNorm.Text = "Nome do método"
        Me.txtDescription.Text = "Descrição"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.txtNorm.Text = "" Then
            MsgBox("Campo norma vazio!")
        Else
            Select Case Me.btnSave.Tag
                Case "New"
                    database.InsertReformattingMethod(Me.txtNorm.Text, Me.txtDescription.Text)
                    Me.txtNorm.Visible = False
                    Me.txtDescription.Visible = False
                    Me.btnSave.Visible = False
                    LoadListView()
                    MsgBox(InfoMessage("ReformattingMethod.NewValue"), MsgBoxStyle.Information)
                    Log.Append(Constants.UserLogon, Log.AppendNode, "Reformatting method was added.")
                Case "Update"
                    database.UpdateReformattingMethod(Me.lvwMethods.SelectedItems(0).Tag, Me.txtNorm.Text, Me.txtDescription.Text)
                    Me.txtNorm.Visible = False
                    Me.txtDescription.Visible = False
                    Me.btnSave.Visible = False
                    LoadListView()
                    MsgBox(InfoMessage("ReformattingMethod.EditedValue"), MsgBoxStyle.Information)
                    Log.Append(Constants.UserLogon, Log.AppendNode, "Reformatting method was edited.")
            End Select
        End If
    End Sub

    Private Sub bttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lvwMethods.SelectedIndices.Count = 0 Then
            MsgBox("Não está nenhum item seleccionado!")
        Else
            database.DeleteReformattingMethod(Me.lvwMethods.SelectedItems(0).Tag)
            LoadListView()
            MsgBox(InfoMessage("ReformattingMethod.DeletedValue"), MsgBoxStyle.Information)
            Log.Append(Constants.UserLogon, Log.AppendNode, "Reformatting method was deleted.")
        End If
    End Sub

    Private Sub txtNorm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNorm.Click
        If Me.btnSave.Tag = "New" Then
            Me.txtNorm.Text = ""
        End If
    End Sub

    Private Sub txtDescription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.Click
        If Me.btnSave.Tag = "New" Then
            Me.txtDescription.Text = ""
        End If
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If Me.lvwMethods.CheckedItems.Count = 0 Then
            MsgBox("Não está nenhum item seleccionado! Seleccione o método na ceckbox respectiva.")
        Else
            Dim DOForm As DigitalObjectsForm = Me.Owner
            For Each lvi As ListViewItem In lvwMethods.CheckedItems
                DOForm.txtReformattingMethod.Text = lvi.SubItems(0).Text
                DOForm.txtReformattingMethod.Tag = lvi.Tag
            Next
            Me.Close()
        End If
    End Sub

    Private Sub lvwMethods_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvwMethods.ItemCheck
        For Each lvi As ListViewItem In lvwMethods.CheckedItems
            If lvi.Index <> e.Index Then
                lvi.Checked = False
            End If
        Next
    End Sub

End Class
