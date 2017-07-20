
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

Imports System.Configuration

Public Class NewFondsForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtReference.FieldType = ValidTextBox.FieldTypes.FondsReferenceField
        txtReference.AllowErrorMessage = False

        txtTitle.FieldType = ValidTextBox.FieldTypes.NotEmptyField
        txtTitle.AllowErrorMessage = False
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReference As ValidTextBox
    Friend WithEvents txtTitle As ValidTextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCountryCode As MDA.ValidTextBox
    Friend WithEvents txtRepositoryCode As MDA.ValidTextBox
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NewFondsForm))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTitle = New MDA.ValidTextBox
        Me.txtReference = New MDA.ValidTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCountryCode = New MDA.ValidTextBox
        Me.txtRepositoryCode = New MDA.ValidTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Refer�ncia:"
        '
        'txtTitle
        '
        Me.txtTitle.AllowErrorMessage = False
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitle.FieldType = MDA.ValidTextBox.FieldTypes.NotEmptyField
        Me.txtTitle.Location = New System.Drawing.Point(88, 64)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTitle.Size = New System.Drawing.Size(272, 20)
        Me.txtTitle.TabIndex = 2
        Me.txtTitle.Text = ""
        Me.ToolTip.SetToolTip(Me.txtTitle, "T�tulo do Fundo (e.g. Tribunal de Rela��o do Porto)")
        '
        'txtReference
        '
        Me.txtReference.AllowErrorMessage = False
        Me.txtReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReference.FieldType = MDA.ValidTextBox.FieldTypes.NotEmptyField
        Me.txtReference.Location = New System.Drawing.Point(88, 40)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReference.Size = New System.Drawing.Size(184, 20)
        Me.txtReference.TabIndex = 0
        Me.txtReference.Text = ""
        Me.ToolTip.SetToolTip(Me.txtReference, "Refer�ncia do Fundo. (e.g. JUD/TRPRT)")
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "T�tulo:"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.White
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.ImageIndex = 0
        Me.btnOk.ImageList = Me.imglButtons
        Me.btnOk.Location = New System.Drawing.Point(193, 96)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "&Gravar"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 1
        Me.btnCancel.ImageList = Me.imglButtons
        Me.btnCancel.Location = New System.Drawing.Point(275, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCountryCode
        '
        Me.txtCountryCode.AllowErrorMessage = False
        Me.txtCountryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountryCode.FieldType = MDA.ValidTextBox.FieldTypes.NotEmptyField
        Me.txtCountryCode.Location = New System.Drawing.Point(88, 16)
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCountryCode.Size = New System.Drawing.Size(40, 20)
        Me.txtCountryCode.TabIndex = 6
        Me.txtCountryCode.Text = ""
        Me.ToolTip.SetToolTip(Me.txtCountryCode, "Refer�ncia do Fundo. (e.g. JUD/TRPRT)")
        '
        'txtRepositoryCode
        '
        Me.txtRepositoryCode.AllowErrorMessage = False
        Me.txtRepositoryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRepositoryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRepositoryCode.FieldType = MDA.ValidTextBox.FieldTypes.NotEmptyField
        Me.txtRepositoryCode.Location = New System.Drawing.Point(192, 16)
        Me.txtRepositoryCode.Name = "txtRepositoryCode"
        Me.txtRepositoryCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepositoryCode.Size = New System.Drawing.Size(80, 20)
        Me.txtRepositoryCode.TabIndex = 8
        Me.txtRepositoryCode.Text = ""
        Me.ToolTip.SetToolTip(Me.txtRepositoryCode, "Refer�ncia do Fundo. (e.g. JUD/TRPRT)")
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Pa�s:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(136, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Institui��o:"
        '
        'NewFondsForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(378, 136)
        Me.Controls.Add(Me.txtRepositoryCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCountryCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtReference)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewFondsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = CType(configurationAppSettings.GetValue("NewFondsForm.Text", GetType(System.String)), String)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Function GetUnitId() As String
        Return txtReference.Text
    End Function

    Public Function GetUnitTitle() As String
        Return txtTitle.Text
    End Function

    Public Function GetCountryCode() As String
        Return txtCountryCode.Text
    End Function

    Public Function GetRepositoryCode() As String
        Return txtRepositoryCode.Text
    End Function


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not txtReference.isValid() Then
            Dim AcceptProblem As Boolean = txtReference.ShowErrorMessage(ErrorMessage("NotFondsReference"))
            txtReference.Focus()
            If (AcceptProblem) Then DialogResult = DialogResult.OK
        ElseIf Not txtTitle.isValid() Then
            txtTitle.ShowErrorMessage(ErrorMessage("EmptyField"))
            txtTitle.Focus()
        Else
            DialogResult = DialogResult.OK
            'Close()
        End If
    End Sub

    Private Sub NewFondsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim InstitutionSettings As Hashtable = ConfigurationManager.GetSection("InstitutionSettings")
        Me.txtCountryCode.Text = VisualFieldLabel("CountryCode.DefaultValue")
        Me.txtRepositoryCode.Text = InstitutionSettings.Item("Institution.Code")
    End Sub

End Class
