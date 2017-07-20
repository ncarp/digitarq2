
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

Public Class SearchReplaceForm
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
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents txtReplace As System.Windows.Forms.TextBox
    Friend WithEvents lblReplace As System.Windows.Forms.Label
    Friend WithEvents lblFind As System.Windows.Forms.Label
    Friend WithEvents cbFields As ComboBoxImage
    Friend WithEvents CheckBoxCaseSensitive As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRegExp As System.Windows.Forms.CheckBox
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents lblField As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents CheckBoxWholeWordOnly As System.Windows.Forms.CheckBox
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SearchReplaceForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnFind = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnReplace = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CheckBoxWholeWordOnly = New System.Windows.Forms.CheckBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblField = New System.Windows.Forms.Label
        Me.txtFind = New System.Windows.Forms.TextBox
        Me.CheckBoxRegExp = New System.Windows.Forms.CheckBox
        Me.CheckBoxCaseSensitive = New System.Windows.Forms.CheckBox
        Me.cbFields = New MDA.ComboBoxImage
        Me.txtReplace = New System.Windows.Forms.TextBox
        Me.lblReplace = New System.Windows.Forms.Label
        Me.lblFind = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnFind)
        Me.Panel2.Controls.Add(Me.btnReplace)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 159)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(386, 40)
        Me.Panel2.TabIndex = 1
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.White
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.ImageIndex = 2
        Me.btnFind.ImageList = Me.imglButtons
        Me.btnFind.Location = New System.Drawing.Point(212, 8)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(85, 25)
        Me.btnFind.TabIndex = 9
        Me.btnFind.Text = CType(configurationAppSettings.GetValue("btnFind.Text", GetType(System.String)), String)
        Me.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnReplace
        '
        Me.btnReplace.BackColor = System.Drawing.Color.White
        Me.btnReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReplace.Location = New System.Drawing.Point(104, 8)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(80, 25)
        Me.btnReplace.TabIndex = 7
        Me.btnReplace.Text = "Substituir..."
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageIndex = 0
        Me.btnClose.ImageList = Me.imglButtons
        Me.btnClose.Location = New System.Drawing.Point(304, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 25)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "&Fechar"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBoxWholeWordOnly)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblField)
        Me.Panel1.Controls.Add(Me.txtFind)
        Me.Panel1.Controls.Add(Me.CheckBoxRegExp)
        Me.Panel1.Controls.Add(Me.CheckBoxCaseSensitive)
        Me.Panel1.Controls.Add(Me.cbFields)
        Me.Panel1.Controls.Add(Me.txtReplace)
        Me.Panel1.Controls.Add(Me.lblReplace)
        Me.Panel1.Controls.Add(Me.lblFind)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 159)
        Me.Panel1.TabIndex = 0
        '
        'CheckBoxWholeWordOnly
        '
        Me.CheckBoxWholeWordOnly.Location = New System.Drawing.Point(104, 112)
        Me.CheckBoxWholeWordOnly.Name = "CheckBoxWholeWordOnly"
        Me.CheckBoxWholeWordOnly.Size = New System.Drawing.Size(168, 16)
        Me.CheckBoxWholeWordOnly.TabIndex = 12341
        Me.CheckBoxWholeWordOnly.Text = "Apenas palavras inteiras"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 88)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12340
        Me.PictureBox1.TabStop = False
        '
        'lblField
        '
        Me.lblField.Location = New System.Drawing.Point(16, 18)
        Me.lblField.Name = "lblField"
        Me.lblField.Size = New System.Drawing.Size(88, 16)
        Me.lblField.TabIndex = 12339
        Me.lblField.Text = CType(configurationAppSettings.GetValue("ReplaceForm.lblField.Text", GetType(System.String)), String)
        Me.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFind
        '
        Me.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFind.Location = New System.Drawing.Point(104, 40)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(272, 20)
        Me.txtFind.TabIndex = 2
        Me.txtFind.Text = ""
        '
        'CheckBoxRegExp
        '
        Me.CheckBoxRegExp.Location = New System.Drawing.Point(104, 128)
        Me.CheckBoxRegExp.Name = "CheckBoxRegExp"
        Me.CheckBoxRegExp.Size = New System.Drawing.Size(120, 16)
        Me.CheckBoxRegExp.TabIndex = 4
        Me.CheckBoxRegExp.Text = "Expressão regular"
        '
        'CheckBoxCaseSensitive
        '
        Me.CheckBoxCaseSensitive.Location = New System.Drawing.Point(104, 96)
        Me.CheckBoxCaseSensitive.Name = "CheckBoxCaseSensitive"
        Me.CheckBoxCaseSensitive.Size = New System.Drawing.Size(144, 16)
        Me.CheckBoxCaseSensitive.TabIndex = 5
        Me.CheckBoxCaseSensitive.Text = "Maiúsculas/minúsculas"
        '
        'cbFields
        '
        Me.cbFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFields.ImageList = Nothing
        Me.cbFields.Location = New System.Drawing.Point(104, 16)
        Me.cbFields.MaxDropDownItems = 12
        Me.cbFields.Name = "cbFields"
        Me.cbFields.Size = New System.Drawing.Size(144, 21)
        Me.cbFields.TabIndex = 1
        '
        'txtReplace
        '
        Me.txtReplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReplace.Location = New System.Drawing.Point(104, 64)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.Size = New System.Drawing.Size(272, 20)
        Me.txtReplace.TabIndex = 3
        Me.txtReplace.Text = ""
        '
        'lblReplace
        '
        Me.lblReplace.Location = New System.Drawing.Point(16, 64)
        Me.lblReplace.Name = "lblReplace"
        Me.lblReplace.Size = New System.Drawing.Size(88, 16)
        Me.lblReplace.TabIndex = 12323
        Me.lblReplace.Text = "Substituir por:"
        Me.lblReplace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFind
        '
        Me.lblFind.Location = New System.Drawing.Point(16, 40)
        Me.lblFind.Name = "lblFind"
        Me.lblFind.Size = New System.Drawing.Size(88, 16)
        Me.lblFind.TabIndex = 12334
        Me.lblFind.Text = CType(configurationAppSettings.GetValue("Replace.FormlblFind.Text", GetType(System.String)), String)
        Me.lblFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SearchReplaceForm
        '
        Me.AcceptButton = Me.btnFind
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(386, 199)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SearchReplaceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Localizar/Substituir..."
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties "
    Private myRootLazyNode As LazyNode
    Private myLazyTree As LazyTree
    Private myProgressDialog As ProgressDialog
    Private myAllowReplace As Boolean
#End Region

#Region "Initialization"

    Public Sub New(ByVal RootLazyNode As LazyNode, ByVal LazyTree As LazyTree, Optional ByVal AllowReplace As Boolean = True)
        Me.New()
        myRootLazyNode = RootLazyNode
        myLazyTree = LazyTree
        myAllowReplace = AllowReplace

        If Not AllowReplace Then
            btnReplace.Visible = False
            txtReplace.Visible = False
            lblReplace.Visible = False
        End If
    End Sub

    Private Sub ReplaceForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFieldsComboBox()
    End Sub


    Private Sub LoadFieldsComboBox()
        With Me.cbFields
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("UnitId").Replace(":", ""), "UnitId"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("UnitTitle").Replace(":", ""), "UnitTitle"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("GenreForm").Replace(":", ""), "GenreForm"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("GeogName").Replace(":", ""), "GeogName"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("PhysFacet").Replace(":", ""), "PhysFacet"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("PhysLoc").Replace(":", ""), "PhysLoc"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("MaterialSpec").Replace(":", ""), "MaterialSpec"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("LangMaterial").Replace(":", ""), "LangMaterial"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OriginationScrivener").Replace(":", ""), "OriginationScrivener"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OriginationAuthor").Replace(":", ""), "OriginationAuthor"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OriginationDestination").Replace(":", ""), "OriginationDestination"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OriginationAuthorAddress").Replace(":", ""), "OriginationAuthorAddress"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OriginationNotary").Replace(":", ""), "OriginationNotary"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("ScopeContent").Replace(":", ""), "ScopeContent"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("BiogHist").Replace(":", ""), "BiogHist"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OtherFindAid").Replace(":", ""), "OtherFindAids"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OriginalNumbering").Replace(":", ""), "OriginalNumbering"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("Note").Replace(":", ""), "Note"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("RelatedMaterial").Replace(":", ""), "RelatedMaterial"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("PhysTech").Replace(":", ""), "PhysTech"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("AcqInfo").Replace(":", ""), "AcqInfo"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("Arrangement").Replace(":", ""), "Arrangement"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("CustodHist").Replace(":", ""), "CustodHist"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("AltFormAvail").Replace(":", ""), "AltFormAvail"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("Appraisal").Replace(":", ""), "Appraisal"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("AccessRestrict").Replace(":", ""), "AccessRestrict"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("LegalStatus").Replace(":", ""), "LegalStatus"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("Accruals").Replace(":", ""), "Accruals"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("UseRestrict").Replace(":", ""), "UseRestrict"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OriginalsLoc").Replace(":", ""), "OriginalsLoc"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("PreferCite").Replace(":", ""), "PreferCite"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("SeparatedMaterial").Replace(":", ""), "SeparatedMaterial"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("Abstract").Replace(":", ""), "Abstract"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("Repository").Replace(":", ""), "Repository"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("FilePlan").Replace(":", ""), "FilePlan"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("Dimensions").Replace(":", ""), "Dimensions"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("UnitDateInitial").Replace(":", ""), "UnitDateInitial"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("UnitDateFinal").Replace(":", ""), "UnitDateFinal"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("UnitDateBulk").Replace(":", ""), "UnitDateBulk"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("OtherLevel").Replace(":", ""), "OtherLevel"))
            .Items.Add(New ComboBoxImageItem(VisualFieldLabel("ContainerType").Replace(":", ""), "ContainerType"))
            If Not myAllowReplace Then
                .Items.Add(New ComboBoxImageItem(VisualFieldLabel("ControlAccess").Replace(":", ""), "ControlAccess"))
            End If

            .Sorted = True
            .SelectedIndex = 0
        End With
    End Sub

#End Region

#Region "Form events"

    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        If cbFields.SelectedText = VisualFieldLabel("OtherLevel").Replace(":", "") Then
            If (Not Validator.IsValidOtherLevel(Me.txtFind.Text) OrElse Not Validator.IsValidOtherLevel(Me.txtReplace.Text)) OrElse _
               (Me.txtFind.Text = EADDefinitions.OTHERLEVEL_FONDS OrElse Me.txtReplace.Text = EADDefinitions.OTHERLEVEL_FONDS) Then
                MsgBox(InfoMessage("SearchReplace.UnkownOtherLevel"))
                Exit Sub
            End If
        ElseIf cbFields.SelectedText = VisualFieldLabel("ContainerType").Replace(":", "") Then
            If Not Validator.IsValidContainerType(Me.txtReplace.Text) Then
                '(Not Validator.IsValidContainerType(Me.txtFind.Text) OrElse 
                MsgBox(InfoMessage("SearchReplace.UnkownContainerType"))
                Exit Sub
            End If
        End If

        Dim iterator As New Iterator(Me.myRootLazyNode)
        Dim SelectedField As String = cbFields.SelectedValue
        Dim Args As New Hashtable
        With Args
            .Add("FieldName", SelectedField)
            If Me.CheckBoxWholeWordOnly.Checked Then
                .Add("SearchString", String.Format("\b{0}\b", Me.txtFind.Text))
                .Add("RegExp", True)
            ElseIf cbFields.SelectedText = VisualFieldLabel("OtherLevel").Replace(":", "") OrElse cbFields.SelectedText = VisualFieldLabel("ContainerType").Replace(":", "") Then
                .Add("SearchString", String.Format("^{0}$", Me.txtFind.Text))
                .Add("RegExp", True)
            Else
                .Add("SearchString", Me.txtFind.Text)
                .Add("RegExp", Me.CheckBoxRegExp.Checked)
            End If
            .Add("ReplaceBy", Me.txtReplace.Text)
            .Add("CaseSensitive", Me.CheckBoxCaseSensitive.Checked)
            .Add("ProcessInfoName", myLazyTree.ProcessInfoName)
        End With
        iterator.Argument = Args
        EnableButtons(False)
        iterator.Start(iterator.Action.SearchReplace)
        MsgBox(String.Format(InfoMessage("SearchReplace.NumberReplacements"), CType(iterator.Result, Integer)), MsgBoxStyle.Information)
        EnableButtons(True)
    End Sub




    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        If cbFields.SelectedText = VisualFieldLabel("OtherLevel").Replace(":", "") Then
            If Not Validator.IsValidOtherLevel(Me.txtFind.Text) Then
                MsgBox(InfoMessage("Search.UnkownOtherLevel"))
                Exit Sub
            End If
        End If


        Dim iterator As New Iterator(Me.myRootLazyNode)
        Dim SelectedField As String = cbFields.SelectedValue
        Dim Args As New Hashtable
        With Args
            .Add("FieldName", SelectedField)
            If Me.CheckBoxWholeWordOnly.Checked Then
                .Add("SearchString", String.Format("\b{0}\b", Me.txtFind.Text))
                .Add("RegExp", True)
            ElseIf cbFields.SelectedText = VisualFieldLabel("OtherLevel").Replace(":", "") OrElse cbFields.SelectedText = VisualFieldLabel("ContainerType").Replace(":", "") Then
                .Add("SearchString", String.Format("^{0}$", Me.txtFind.Text))
                .Add("RegExp", True)
            Else
                .Add("SearchString", Me.txtFind.Text)
                .Add("RegExp", Me.CheckBoxRegExp.Checked)
            End If
            .Add("CaseSensitive", Me.CheckBoxCaseSensitive.Checked)
        End With
        iterator.Argument = Args

        Dim Hits As LazyNodeCollection
        EnableButtons(False)
        Hits = iterator.Start(iterator.Action.Search)
        EnableButtons(True)

        Dim frmFindResults As New FindResultsForm(Hits, myLazyTree)
        'frmFindResults.TopMost = True
        frmFindResults.Show()

        Cursor.Current = Cursors.Default

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub CheckBoxWholeWordOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxWholeWordOnly.CheckedChanged
        If CheckBoxWholeWordOnly.Checked Then Me.CheckBoxRegExp.Checked = False
        Me.CheckBoxRegExp.Enabled = Not CheckBoxWholeWordOnly.Checked
    End Sub

    Private Sub cbFields_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFields.SelectedIndexChanged
        If cbFields.SelectedText = VisualFieldLabel("OtherLevel").Replace(":", "") OrElse cbFields.SelectedText = VisualFieldLabel("ContainerType").Replace(":", "") Then
            Me.CheckBoxWholeWordOnly.Enabled = False
            Me.CheckBoxCaseSensitive.Enabled = False
            Me.CheckBoxRegExp.Enabled = False

            Me.CheckBoxWholeWordOnly.Checked = False
            Me.CheckBoxCaseSensitive.Checked = True
            Me.CheckBoxRegExp.Checked = True
        Else
            Me.CheckBoxWholeWordOnly.Enabled = True
            Me.CheckBoxCaseSensitive.Enabled = True
            Me.CheckBoxRegExp.Enabled = True
        End If

    End Sub
#End Region

#Region "Auxiliary functions"
    Private Sub EnableButtons(ByVal Enable As Boolean)
        Me.btnReplace.Enabled = Enable
        Me.btnFind.Enabled = Enable
    End Sub
#End Region



End Class

