
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

Public Class MeteringModesForm
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
    Friend WithEvents gbxLampTypes As System.Windows.Forms.GroupBox
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lbxMeteringModes As System.Windows.Forms.ListBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MeteringModesForm))
        Me.gbxLampTypes = New System.Windows.Forms.GroupBox
        Me.txtNew = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.lbxMeteringModes = New System.Windows.Forms.ListBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.gbxLampTypes.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxLampTypes
        '
        Me.gbxLampTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxLampTypes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbxLampTypes.Controls.Add(Me.txtNew)
        Me.gbxLampTypes.Controls.Add(Me.btnCancel)
        Me.gbxLampTypes.Controls.Add(Me.btnEdit)
        Me.gbxLampTypes.Controls.Add(Me.btnDelete)
        Me.gbxLampTypes.Controls.Add(Me.lbxMeteringModes)
        Me.gbxLampTypes.Controls.Add(Me.btnNew)
        Me.gbxLampTypes.Location = New System.Drawing.Point(7, 14)
        Me.gbxLampTypes.Name = "gbxLampTypes"
        Me.gbxLampTypes.Size = New System.Drawing.Size(224, 320)
        Me.gbxLampTypes.TabIndex = 10
        Me.gbxLampTypes.TabStop = False
        Me.gbxLampTypes.Text = CType(configurationAppSettings.GetValue("groupIluminancia.Text", GetType(System.String)), String)
        '
        'txtNew
        '
        Me.txtNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNew.Location = New System.Drawing.Point(13, 234)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Size = New System.Drawing.Size(199, 20)
        Me.txtNew.TabIndex = 69
        Me.txtNew.Text = ""
        Me.txtNew.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Window
        Me.btnCancel.Enabled = False
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.ImageList = Me.imglButtons
        Me.btnCancel.Location = New System.Drawing.Point(13, 288)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 25)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = CType(configurationAppSettings.GetValue("btnChoose.Text", GetType(System.String)), String)
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Window
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 3
        Me.btnEdit.ImageList = Me.imglButtons
        Me.btnEdit.Location = New System.Drawing.Point(132, 261)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(80, 25)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = CType(configurationAppSettings.GetValue("btnEdit.Text", GetType(System.String)), String)
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Window
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.ImageList = Me.imglButtons
        Me.btnDelete.Location = New System.Drawing.Point(132, 288)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 25)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = CType(configurationAppSettings.GetValue("btnDelete.Text", GetType(System.String)), String)
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbxMeteringModes
        '
        Me.lbxMeteringModes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxMeteringModes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbxMeteringModes.Location = New System.Drawing.Point(13, 21)
        Me.lbxMeteringModes.Name = "lbxMeteringModes"
        Me.lbxMeteringModes.Size = New System.Drawing.Size(199, 210)
        Me.lbxMeteringModes.TabIndex = 10
        '
        'btnNew
        '
        Me.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNew.BackColor = System.Drawing.SystemColors.Window
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.ImageIndex = 0
        Me.btnNew.ImageList = Me.imglButtons
        Me.btnNew.Location = New System.Drawing.Point(13, 261)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(80, 25)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = CType(configurationAppSettings.GetValue("btnNew.Text", GetType(System.String)), String)
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MeteringModesForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(239, 349)
        Me.Controls.Add(Me.gbxLampTypes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MeteringModesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formas de medição"
        Me.gbxLampTypes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private database As New SqlCommands
    Private mydata As New DataSet
    Private configReader As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader


#Region "MeteringModesForm"

    Private Sub MeteringModesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        DisableEdition()
    End Sub

    Private Sub MeteringModesForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If btnCancel.Enabled Then
                DisableEdition()
            Else
                Me.Close()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If btnCancel.Enabled Then
                Me.btnEdit_Click(sender, e)
            End If
        End If
    End Sub

#End Region

#Region "New/Edit/Save"

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        EnableEdition()
        Me.txtNew.Text = ""
        Me.txtNew.Focus()
        Me.btnEdit.Tag = "New"
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If btnEdit.Text.Equals(configReader.GetValue("btnEdit.Text", GetType(String))) Then
            If Not Me.lbxMeteringModes.SelectedItem Is Nothing Then
                EnableEdition()
                Me.txtNew.Text = Me.lbxMeteringModes.SelectedItem.Description
                Me.txtNew.Focus()
                Me.btnEdit.Tag = "Update"
            End If
        Else
            Select Case Me.btnEdit.Tag
                Case "Update"
                    If Me.txtNew.Text.Trim <> "" Then
                        Dim res As Boolean = database.UpdateMeteringMode(lbxMeteringModes.SelectedItem.MeteringModeID, Me.txtNew.Text)
                        If res Then
                            Log.Append(Constants.UserLogon, Log.EditNode, "Metering mode " & Me.lbxMeteringModes.SelectedItem.Description & " was edited.")
                            LoadData()
                        End If
                    End If
                Case "New"
                    If Me.txtNew.Text.Trim <> "" Then
                        Dim res As Boolean = database.InsertMeteringMode(Me.txtNew.Text)
                        If res Then
                            Log.Append(Constants.UserLogon, Log.AppendNode, "New metering mode was added to database.")
                            LoadData()
                        End If
                    End If
            End Select
            DisableEdition()
        End If
    End Sub

#End Region

#Region "Delete"

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As Boolean

        If MsgBox(InfoMessage("MeteringMode.DeleteMeteringMode") & Me.lbxMeteringModes.GetItemText(Me.lbxMeteringModes.SelectedItem) & "' da base de dados?", MsgBoxStyle.YesNo, InfoMessage("MeteringMode.Title")) = MsgBoxResult.Yes Then
            Log.Append(Constants.UserLogon, Log.RemoveNode, "Metering mode " & Me.lbxMeteringModes.SelectedItem.Description & " was deleted from database.")
            res = database.DeleteMeteringMode(Me.lbxMeteringModes.SelectedItem.MeteringModeID)
            If res Then
                LoadData()
            End If
        End If
    End Sub

#End Region

#Region "Cancel"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisableEdition()
    End Sub

#End Region

#Region "Enable/Disable Edition"

    Private Sub EnableEdition()
        Me.btnEdit.Text = configReader.GetValue("btnSave.Text", GetType(String))
        Me.btnEdit.ImageIndex = 2
        Me.btnCancel.Enabled = True
        Me.btnNew.Enabled = False
        Me.btnDelete.Enabled = False
        Me.txtNew.Visible = True
    End Sub

    Private Sub DisableEdition()
        Me.btnEdit.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        Me.btnEdit.ImageIndex = 3
        Me.btnCancel.Enabled = False
        Me.btnNew.Enabled = True
        Me.btnDelete.Enabled = True
        Me.txtNew.Visible = False
    End Sub

#End Region

#Region "Load Data"

    Private Sub LoadData()
        Dim mydata As MeteringModeCollection = database.SelectAllMeteringModes

        Me.lbxMeteringModes.Items.Clear()

        For Each myMeteringMode As MeteringMode In mydata
            Me.lbxMeteringModes.Items.Add(New MeteringMode(myMeteringMode.Description, myMeteringMode.MeteringModeID))
        Next
    End Sub

#End Region

End Class
