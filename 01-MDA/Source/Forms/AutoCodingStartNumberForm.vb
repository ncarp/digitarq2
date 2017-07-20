
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

Public Class AutoCodingStartNumberForm
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
    Friend WithEvents Number As ValidTextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents btnOkAutoCoding As System.Windows.Forms.Button
    Friend WithEvents btnCancelAutoCoding As System.Windows.Forms.Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AutoCodingStartNumberForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnOkAutoCoding = New System.Windows.Forms.Button
        Me.btnCancelAutoCoding = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.Number = New MDA.ValidTextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnOkAutoCoding)
        Me.Panel2.Controls.Add(Me.btnCancelAutoCoding)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(226, 40)
        Me.Panel2.TabIndex = 5
        '
        'btnOkAutoCoding
        '
        Me.btnOkAutoCoding.BackColor = System.Drawing.Color.White
        Me.btnOkAutoCoding.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOkAutoCoding.Enabled = False
        Me.btnOkAutoCoding.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOkAutoCoding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOkAutoCoding.ImageIndex = 1
        Me.btnOkAutoCoding.ImageList = Me.imglButtons
        Me.btnOkAutoCoding.Location = New System.Drawing.Point(56, 8)
        Me.btnOkAutoCoding.Name = "btnOkAutoCoding"
        Me.btnOkAutoCoding.Size = New System.Drawing.Size(70, 25)
        Me.btnOkAutoCoding.TabIndex = 3
        Me.btnOkAutoCoding.Text = CType(configurationAppSettings.GetValue("btnOkAutoCoding.Text", GetType(System.String)), String)
        Me.btnOkAutoCoding.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelAutoCoding
        '
        Me.btnCancelAutoCoding.BackColor = System.Drawing.Color.White
        Me.btnCancelAutoCoding.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelAutoCoding.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelAutoCoding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelAutoCoding.ImageIndex = 0
        Me.btnCancelAutoCoding.ImageList = Me.imglButtons
        Me.btnCancelAutoCoding.Location = New System.Drawing.Point(133, 8)
        Me.btnCancelAutoCoding.Name = "btnCancelAutoCoding"
        Me.btnCancelAutoCoding.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelAutoCoding.TabIndex = 2
        Me.btnCancelAutoCoding.Text = CType(configurationAppSettings.GetValue("btnCancelAutoCoding.Text", GetType(System.String)), String)
        Me.btnCancelAutoCoding.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'Number
        '
        Me.Number.AllowErrorMessage = True
        Me.Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Number.FieldType = MDA.ValidTextBox.FieldTypes.IntegerField
        Me.Number.Location = New System.Drawing.Point(168, 20)
        Me.Number.Name = "Number"
        Me.Number.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Number.Size = New System.Drawing.Size(45, 20)
        Me.Number.TabIndex = 24
        Me.Number.Text = "1"
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(8, 20)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(155, 20)
        Me.lblDescription.TabIndex = 23
        Me.lblDescription.Text = CType(configurationAppSettings.GetValue("AutoCodingFormlblDescription.Text", GetType(System.String)), String)
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AutoCodingStartNumberForm
        '
        Me.AcceptButton = Me.btnOkAutoCoding
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelAutoCoding
        Me.ClientSize = New System.Drawing.Size(226, 95)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.Number)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoCodingStartNumberForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = CType(configurationAppSettings.GetValue("AutoCodingStartNumberForm.Text", GetType(System.String)), String)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Property Value() As Integer
        Get
            Return StrToInt(Number.Text)
        End Get
        Set(ByVal Value As Integer)
            Number.Text = IntToStr(Value)
        End Set
    End Property

    Private Sub Number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Number.TextChanged
        Me.btnOkAutoCoding.Enabled = Number.Text.Length > 0 AndAlso Number.isValid
    End Sub

End Class
