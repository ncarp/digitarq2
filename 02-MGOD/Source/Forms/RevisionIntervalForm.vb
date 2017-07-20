
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

Public Class RevisionIntervalForm
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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEdit As MGOD.ColorButton
    Friend WithEvents txtRevisionInterval As MGOD.ColorTextBox
    Friend WithEvents lblRevisionInterval As System.Windows.Forms.Label
    Friend WithEvents lblRevisionInterval_ As System.Windows.Forms.Label
    Friend WithEvents lblYears As System.Windows.Forms.Label
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RevisionIntervalForm))
        Me.lblRevisionInterval_ = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnEdit = New MGOD.ColorButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblYears = New System.Windows.Forms.Label
        Me.txtRevisionInterval = New MGOD.ColorTextBox
        Me.lblRevisionInterval = New System.Windows.Forms.Label
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'lblRevisionInterval_
        '
        Me.lblRevisionInterval_.BackColor = System.Drawing.Color.Transparent
        Me.lblRevisionInterval_.Location = New System.Drawing.Point(13, 24)
        Me.lblRevisionInterval_.Name = "lblRevisionInterval_"
        Me.lblRevisionInterval_.Size = New System.Drawing.Size(144, 20)
        Me.lblRevisionInterval_.TabIndex = 0
        Me.lblRevisionInterval_.Text = CType(configurationAppSettings.GetValue("RI.lblRevisionInterval_.Text", GetType(System.String)), String)
        Me.lblRevisionInterval_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Enabled = False
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.ImageList = Me.imglButtons
        Me.btnCancel.Location = New System.Drawing.Point(168, 83)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 25)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = CType(configurationAppSettings.GetValue("btnCancel.Text", GetType(System.String)), String)
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 3
        Me.btnEdit.ImageList = Me.imglButtons
        Me.btnEdit.Location = New System.Drawing.Point(89, 83)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 25)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = CType(configurationAppSettings.GetValue("btnEdit.Text", GetType(System.String)), String)
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(7, 69)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(246, 3)
        Me.GroupBox4.TabIndex = 57
        Me.GroupBox4.TabStop = False
        '
        'lblYears
        '
        Me.lblYears.BackColor = System.Drawing.Color.Transparent
        Me.lblYears.Location = New System.Drawing.Point(213, 24)
        Me.lblYears.Name = "lblYears"
        Me.lblYears.Size = New System.Drawing.Size(40, 20)
        Me.lblYears.TabIndex = 58
        Me.lblYears.Text = CType(configurationAppSettings.GetValue("RI.lblYears.Text", GetType(System.String)), String)
        Me.lblYears.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtRevisionInterval
        '
        Me.txtRevisionInterval.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRevisionInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRevisionInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRevisionInterval.Location = New System.Drawing.Point(160, 24)
        Me.txtRevisionInterval.Name = "txtRevisionInterval"
        Me.txtRevisionInterval.Size = New System.Drawing.Size(47, 20)
        Me.txtRevisionInterval.TabIndex = 59
        Me.txtRevisionInterval.Text = ""
        '
        'lblRevisionInterval
        '
        Me.lblRevisionInterval.BackColor = System.Drawing.Color.Transparent
        Me.lblRevisionInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRevisionInterval.Location = New System.Drawing.Point(160, 24)
        Me.lblRevisionInterval.Name = "lblRevisionInterval"
        Me.lblRevisionInterval.Size = New System.Drawing.Size(47, 20)
        Me.lblRevisionInterval.TabIndex = 60
        Me.lblRevisionInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'RevisionIntervalForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(266, 117)
        Me.Controls.Add(Me.lblRevisionInterval)
        Me.Controls.Add(Me.txtRevisionInterval)
        Me.Controls.Add(Me.lblYears)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblRevisionInterval_)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "RevisionIntervalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = CType(configurationAppSettings.GetValue("RI.Text", GetType(System.String)), String)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myData As New DataSet
    Private database As New SqlCommands
    Private configReader As System.Configuration.AppSettingsReader = _
                 New System.Configuration.AppSettingsReader

#Region "Load data"

    Private Sub LoadData()
        myData = New DataSet
        myData = database.SelectAllRevisionInterval
    End Sub

#End Region

#Region "Save"

    Private Sub Save()
        Dim res As Boolean

        If txtRevisionInterval.Text.Length = 0 Then
            MsgBox(InfoMessage("RevisionInterval.InvalidValue"), MsgBoxStyle.Exclamation)
            txtRevisionInterval.Focus()
            Exit Sub
        End If

        res = database.UpdateRevisionInterval(myData.Tables(0).Rows(0).Item("RevisionIntervalID"), txtRevisionInterval.Text)
        If res Then
            Log.Append(Constants.UserLogon, Log.EditNode, "Revision interval was changed.")
            'MsgBox(InfoMessage("RevisionInterval.ChangedValue"), MsgBoxStyle.Information)
            'lblRevisionInterval.BringToFront()
            'btnEdit.Text = configReader.GetValue("btnEdit.Text", GetType(String))
            LoadData()
            lblRevisionInterval.Text = myData.Tables(0).Rows(0).Item("revisionValue")
            txtRevisionInterval.Text = myData.Tables(0).Rows(0).Item("revisionValue")
            DisableEdition()
            'btnCancel.Enabled = True
        End If
    End Sub

#End Region

    Private Sub EditRevisionInterval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()

        If myData.Tables.Count <> 0 Then
            lblRevisionInterval.Text = myData.Tables(0).Rows(0).Item("revisionValue")
            txtRevisionInterval.Text = myData.Tables(0).Rows(0).Item("revisionValue")
        Else
            If MsgBox(InfoMessage("RevisionInterval.NewInterval"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim myobject As Object = InputBox(InfoMessage("RevisionInterval.NewValue"), "MGOD")
                While Not myobject.GetType().Equals(GetType(Integer))
                    myobject = InputBox(InfoMessage("RevisionInterval.NewValue"), "MGOD")
                End While
                database.InsertRevisionInterval(myobject.ToString())
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim res As Boolean

        If btnEdit.Text.Equals(configReader.GetValue("btnEdit.Text", GetType(String))) Then
            'txtRevisionInterval.BringToFront()
            'txtRevisionInterval.Focus()
            'btnEdit.Text = configReader.GetValue("btnSave.Text", GetType(String))
            'btnCancel.Enabled = True
            EnableEdition()
        ElseIf btnEdit.Text.Equals(configReader.GetValue("btnSave.Text", GetType(String))) Then
            Save()
        End If
    End Sub


    Private Sub EditRevisionInterval_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnCancel.Enabled Then
                Save()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If btnCancel.Enabled Then
                DisableEdition()
                'lblRevisionInterval.BringToFront()
                'btnEdit.Text = configReader.GetValue("btnEdit.Text", GetType(String))
                'btnCancel.Enabled = False
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisableEdition()
        'lblRevisionInterval.BringToFront()
        'btnEdit.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        'btnCancel.Enabled = False
    End Sub

#Region "Enable/Disable Edition"

    Private Sub EnableEdition()
        Me.txtRevisionInterval.BringToFront()
        Me.txtRevisionInterval.Focus()
        Me.btnEdit.Text = configReader.GetValue("btnSave.Text", GetType(String))
        Me.btnEdit.ImageIndex = 2
        Me.btnEdit.Enabled = True
        Me.btnCancel.Enabled = True
    End Sub

    Private Sub DisableEdition()
        lblRevisionInterval.BringToFront()
        Me.btnEdit.Text = configReader.GetValue("btnEdit.Text", GetType(String))
        Me.btnEdit.ImageIndex = 3
        Me.btnEdit.Enabled = True
        Me.btnCancel.Enabled = False
    End Sub

#End Region

End Class
