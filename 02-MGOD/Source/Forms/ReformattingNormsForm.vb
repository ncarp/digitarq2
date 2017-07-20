
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

Public Class ReformattingNormsForm
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
    Friend WithEvents btnEdit As MGOD.ColorButton
    Friend WithEvents txtNorm As MGOD.ColorTextBox
    Friend WithEvents txtDescription As MGOD.ColorTextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As MGOD.ColorButton
    Friend WithEvents bttnDelete As System.Windows.Forms.Button
    Friend WithEvents gbxNorms As System.Windows.Forms.GroupBox
    Friend WithEvents lvwNorms As System.Windows.Forms.ListView
    Friend WithEvents btnChoose As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReformattingNormsForm))
        Me.txtNorm = New MGOD.ColorTextBox
        Me.txtDescription = New MGOD.ColorTextBox
        Me.btnEdit = New MGOD.ColorButton
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNew = New MGOD.ColorButton
        Me.bttnDelete = New System.Windows.Forms.Button
        Me.gbxNorms = New System.Windows.Forms.GroupBox
        Me.lvwNorms = New System.Windows.Forms.ListView
        Me.btnChoose = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxNorms.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNorm
        '
        Me.txtNorm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNorm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNorm.Location = New System.Drawing.Point(24, 263)
        Me.txtNorm.Name = "txtNorm"
        Me.txtNorm.Size = New System.Drawing.Size(600, 20)
        Me.txtNorm.TabIndex = 18
        Me.txtNorm.Text = "Norma"
        Me.txtNorm.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(24, 287)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(600, 32)
        Me.txtDescription.TabIndex = 104
        Me.txtDescription.Text = "Descri��o"
        Me.txtDescription.Visible = False
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
        Me.btnEdit.TabIndex = 107
        Me.btnEdit.Text = CType(configurationAppSettings.GetValue("btnEdit.Text", GetType(System.String)), String)
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnSave.TabIndex = 108
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Visible = False
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
        Me.btnNew.TabIndex = 109
        Me.btnNew.Text = "Novo"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bttnDelete
        '
        Me.bttnDelete.BackColor = System.Drawing.Color.White
        Me.bttnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bttnDelete.ImageIndex = 1
        Me.bttnDelete.ImageList = Me.imglButtons
        Me.bttnDelete.Location = New System.Drawing.Point(638, 95)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(88, 25)
        Me.bttnDelete.TabIndex = 110
        Me.bttnDelete.Text = "Eliminar"
        Me.bttnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbxNorms
        '
        Me.gbxNorms.Controls.Add(Me.lvwNorms)
        Me.gbxNorms.Location = New System.Drawing.Point(15, 15)
        Me.gbxNorms.Name = "gbxNorms"
        Me.gbxNorms.Size = New System.Drawing.Size(616, 240)
        Me.gbxNorms.TabIndex = 111
        Me.gbxNorms.TabStop = False
        Me.gbxNorms.Text = "Normas"
        '
        'lvwNorms
        '
        Me.lvwNorms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwNorms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwNorms.GridLines = True
        Me.lvwNorms.LabelEdit = True
        Me.lvwNorms.Location = New System.Drawing.Point(8, 16)
        Me.lvwNorms.Name = "lvwNorms"
        Me.lvwNorms.Size = New System.Drawing.Size(600, 216)
        Me.lvwNorms.TabIndex = 1
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
        Me.btnChoose.TabIndex = 112
        Me.btnChoose.Text = "Adicionar"
        Me.btnChoose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'ReformattingNormsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(736, 334)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.gbxNorms)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtNorm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ReformattingNormsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Normas de reformata��o"
        Me.gbxNorms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private database As New SqlCommands
    Private myReformattingNorms As DataSet




    Private Sub ReformattingNormsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' Set the view to show details.
        lvwNorms.View = View.Details
        ' Allow the user to edit item text.
        lvwNorms.LabelEdit = False
        ' Allow the user to rearrange columns.
        lvwNorms.AllowColumnReorder = True
        ' Select the item and subitems when selection is made.
        lvwNorms.FullRowSelect = True
        lvwNorms.MultiSelect = False
        lvwNorms.CheckBoxes = True

        ' Create columns for the items and subitems.
        lvwNorms.Columns.Add("Norma", 250, HorizontalAlignment.Left)
        lvwNorms.Columns.Add("Descri��o", 350, HorizontalAlignment.Left)


        LoadListView()
    End Sub

    Private Sub LoadListView()
        Me.myReformattingNorms = database.SelectAllReformattingNorms
        Dim myTable As DataTable = myReformattingNorms.Tables(0)

        'Clear the ListView control
        Me.lvwNorms.Items.Clear()

        'Display items in the ListView control
        For i As Integer = 0 To myTable.Rows.Count - 1
            Dim myRow As DataRow = myTable.Rows(i)
            'Only row that have not been deleted
            If (myRow.RowState <> DataRowState.Deleted) Then

                Dim lvi As ListViewItem = New ListViewItem(myRow.Item("ReformattingNorm").ToString())
                lvi.SubItems.Add(myRow.Item("Description").ToString())
                lvi.Tag = myRow.Item("ReformattingNormID")


                Me.lvwNorms.Items.Add(lvi)
            End If
        Next
    End Sub


    Private Sub lvwNorms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.btnEdit.Enabled = True
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If lvwNorms.SelectedIndices.Count = 0 Then
            MsgBox("N�o est� nenhum item seleccionado!")
        Else
            Me.txtNorm.Visible = True
            Me.txtDescription.Visible = True
            Me.btnSave.Visible = True
            Me.btnSave.Tag = "Update"
            Me.txtNorm.Text = Me.lvwNorms.SelectedItems.Item(0).SubItems(0).Text
            Me.txtDescription.Text = Me.lvwNorms.SelectedItems.Item(0).SubItems(1).Text
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.txtNorm.Visible = True
        Me.txtDescription.Visible = True
        Me.btnSave.Visible = True
        Me.btnSave.Tag = "New"
        Me.txtNorm.Text = "Nome da norma"
        Me.txtDescription.Text = "Descri��o"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.txtNorm.Text = "" Then
            MsgBox("Campo norma vazio!")
        Else
            Select Case Me.btnSave.Tag
                Case "New"
                    database.InsertReformattingNorm(Me.txtNorm.Text, Me.txtDescription.Text)
                    Me.txtNorm.Visible = False
                    Me.txtDescription.Visible = False
                    Me.btnSave.Visible = False
                    LoadListView()
                    MsgBox(InfoMessage("ReformattingNorm.NewValue"), MsgBoxStyle.Information)
                    Log.Append(Constants.UserLogon, Log.AppendNode, "Reformatting norm was added.")
                Case "Update"
                    database.UpdateReformattingNorm(Me.lvwNorms.SelectedItems(0).Tag, Me.txtNorm.Text, Me.txtDescription.Text)
                    Me.txtNorm.Visible = False
                    Me.txtDescription.Visible = False
                    Me.btnSave.Visible = False
                    LoadListView()
                    MsgBox(InfoMessage("ReformattingNorm.EditedValue"), MsgBoxStyle.Information)
                    Log.Append(Constants.UserLogon, Log.EditNode, "Reformatting norm was edited.")
            End Select
        End If
    End Sub

    Private Sub bttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If lvwNorms.SelectedIndices.Count = 0 Then
            MsgBox("N�o est� nenhum item seleccionado!")
        Else
            database.DeleteReformattingNorm(Me.lvwNorms.SelectedItems(0).Tag)
            LoadListView()
            MsgBox(InfoMessage("ReformattingNorm.DeletedValue"), MsgBoxStyle.Information)
            Log.Append(Constants.UserLogon, Log.RemoveNode, "Reformatting norm was deleted.")
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
        If lvwNorms.CheckedItems.Count = 0 Then
            MsgBox("N�o est� nenhum item seleccionado! Seleccione a(s) norma(s) na(s) ceckbox(s) respectiva(s).")
        Else
            Dim DOForm As DigitalObjectsForm = Me.Owner
            Dim myReformattingNormsChoosen As New DataTable
            myReformattingNormsChoosen.Columns.Add("ReformattingNormID")
            myReformattingNormsChoosen.Columns.Add("ReformattingNorm")

            For Each lvi As ListViewItem In lvwNorms.CheckedItems
                Dim dr As DataRow = myReformattingNormsChoosen.NewRow()
                dr.Item("ReformattingNormID") = lvi.Tag
                dr.Item("ReformattingNorm") = lvi.SubItems(0).Text
                myReformattingNormsChoosen.Rows.Add(dr)
            Next
            DOForm.lbxReformattingNormsChoosen.DataSource = myReformattingNormsChoosen
            DOForm.lbxReformattingNormsChoosen.ValueMember = "ReformattingNormID"
            DOForm.lbxReformattingNormsChoosen.DisplayMember = "ReformattingNorm"
            Me.Close()
        End If
    End Sub

End Class
