
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

Imports CollapsiblePanel
Imports System.Web.mail
Imports System.Threading
Imports System.Configuration

Public Class ErrorHandlingForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal Username As String, ByVal Exception As Exception)
        MyBase.New()
        myUsername = Username
        myException = Exception

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
    Friend WithEvents bttnSendError As System.Windows.Forms.Button
    Friend WithEvents bttnClose As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gbxErrorDetails As ErrorHandling.ErrorDetails
    Friend WithEvents collapseBox As collapseBox
    Friend WithEvents lblModule As System.Windows.Forms.Label
    Friend WithEvents txbComment As System.Windows.Forms.TextBox
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblModule_ As System.Windows.Forms.Label
    Friend WithEvents lblComment_ As System.Windows.Forms.Label
    Friend WithEvents lblInstitution_ As System.Windows.Forms.Label
    Friend WithEvents lblUsername_ As System.Windows.Forms.Label
    Friend WithEvents lblInstitution As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblDate_ As System.Windows.Forms.Label
    Friend WithEvents pbxWarning As System.Windows.Forms.PictureBox
    Friend WithEvents pbxBanner As System.Windows.Forms.PictureBox
    Friend WithEvents lblSend As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ErrorHandlingForm))
        Me.bttnSendError = New System.Windows.Forms.Button
        Me.bttnClose = New System.Windows.Forms.Button
        Me.lblInfo = New System.Windows.Forms.Label
        Me.gbxErrorDetails = New ErrorHandling.ErrorDetails
        Me.collapseBox = New CollapsiblePanel.CollapseBox
        Me.lblModule_ = New System.Windows.Forms.Label
        Me.lblInstitution_ = New System.Windows.Forms.Label
        Me.lblUsername_ = New System.Windows.Forms.Label
        Me.lblComment_ = New System.Windows.Forms.Label
        Me.lblModule = New System.Windows.Forms.Label
        Me.lblInstitution = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.txbComment = New System.Windows.Forms.TextBox
        Me.pBar = New System.Windows.Forms.ProgressBar
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblDate_ = New System.Windows.Forms.Label
        Me.lblSend = New System.Windows.Forms.Label
        Me.pbxWarning = New System.Windows.Forms.PictureBox
        Me.pbxBanner = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'bttnSendError
        '
        Me.bttnSendError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnSendError.BackColor = System.Drawing.Color.White
        Me.bttnSendError.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnSendError.Location = New System.Drawing.Point(320, 306)
        Me.bttnSendError.Name = "bttnSendError"
        Me.bttnSendError.TabIndex = 1
        Me.bttnSendError.Text = "Enviar"
        '
        'bttnClose
        '
        Me.bttnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnClose.BackColor = System.Drawing.Color.White
        Me.bttnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bttnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnClose.Location = New System.Drawing.Point(401, 306)
        Me.bttnClose.Name = "bttnClose"
        Me.bttnClose.TabIndex = 0
        Me.bttnClose.Text = "Não enviar"
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.White
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(72, 10)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(376, 48)
        Me.lblInfo.TabIndex = 5
        Me.lblInfo.Text = "O DigitArq encontrou um problema ao executar uma tarefa. A última informação intr" & _
        "oduzida poderá ser perdida."
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbxErrorDetails
        '
        Me.gbxErrorDetails.Caption = "Mostrar detalhes"
        Me.gbxErrorDetails.Location = New System.Drawing.Point(16, 261)
        Me.gbxErrorDetails.Name = "gbxErrorDetails"
        Me.gbxErrorDetails.Size = New System.Drawing.Size(460, 20)
        Me.gbxErrorDetails.TabIndex = 6
        Me.gbxErrorDetails.Tag = "Minimize"
        '
        'collapseBox
        '
        Me.collapseBox.IsPlus = False
        Me.collapseBox.Location = New System.Drawing.Point(0, 0)
        Me.collapseBox.Name = "collapseBox"
        Me.collapseBox.TabIndex = 0
        '
        'lblModule_
        '
        Me.lblModule_.Location = New System.Drawing.Point(16, 78)
        Me.lblModule_.Name = "lblModule_"
        Me.lblModule_.Size = New System.Drawing.Size(128, 16)
        Me.lblModule_.TabIndex = 7
        Me.lblModule_.Text = "Módulo: "
        '
        'lblInstitution_
        '
        Me.lblInstitution_.Location = New System.Drawing.Point(16, 100)
        Me.lblInstitution_.Name = "lblInstitution_"
        Me.lblInstitution_.Size = New System.Drawing.Size(66, 16)
        Me.lblInstitution_.TabIndex = 8
        Me.lblInstitution_.Text = "Instituição: "
        '
        'lblUsername_
        '
        Me.lblUsername_.Location = New System.Drawing.Point(16, 122)
        Me.lblUsername_.Name = "lblUsername_"
        Me.lblUsername_.Size = New System.Drawing.Size(66, 16)
        Me.lblUsername_.TabIndex = 9
        Me.lblUsername_.Text = "Utilizador: "
        '
        'lblComment_
        '
        Me.lblComment_.Location = New System.Drawing.Point(16, 167)
        Me.lblComment_.Name = "lblComment_"
        Me.lblComment_.Size = New System.Drawing.Size(160, 16)
        Me.lblComment_.TabIndex = 11
        Me.lblComment_.Text = "Descrição do problema: "
        '
        'lblModule
        '
        Me.lblModule.Location = New System.Drawing.Point(86, 78)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(390, 16)
        Me.lblModule.TabIndex = 12
        '
        'lblInstitution
        '
        Me.lblInstitution.Location = New System.Drawing.Point(86, 100)
        Me.lblInstitution.Name = "lblInstitution"
        Me.lblInstitution.Size = New System.Drawing.Size(390, 16)
        Me.lblInstitution.TabIndex = 13
        '
        'lblUsername
        '
        Me.lblUsername.Location = New System.Drawing.Point(86, 122)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(390, 16)
        Me.lblUsername.TabIndex = 14
        '
        'txbComment
        '
        Me.txbComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txbComment.Location = New System.Drawing.Point(16, 189)
        Me.txbComment.Multiline = True
        Me.txbComment.Name = "txbComment"
        Me.txbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txbComment.Size = New System.Drawing.Size(460, 56)
        Me.txbComment.TabIndex = 15
        Me.txbComment.Text = ""
        '
        'pBar
        '
        Me.pBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pBar.Location = New System.Drawing.Point(-8, 294)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(510, 6)
        Me.pBar.TabIndex = 16
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(86, 144)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(390, 16)
        Me.lblDate.TabIndex = 18
        '
        'lblDate_
        '
        Me.lblDate_.Location = New System.Drawing.Point(16, 144)
        Me.lblDate_.Name = "lblDate_"
        Me.lblDate_.Size = New System.Drawing.Size(66, 16)
        Me.lblDate_.TabIndex = 17
        Me.lblDate_.Text = "Data: "
        '
        'lblSend
        '
        Me.lblSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSend.Location = New System.Drawing.Point(16, 311)
        Me.lblSend.Name = "lblSend"
        Me.lblSend.Size = New System.Drawing.Size(288, 16)
        Me.lblSend.TabIndex = 19
        Me.lblSend.Text = "Enviar relatório de erros para o suporte técnico."
        '
        'pbxWarning
        '
        Me.pbxWarning.BackColor = System.Drawing.Color.White
        Me.pbxWarning.Image = CType(resources.GetObject("pbxWarning.Image"), System.Drawing.Image)
        Me.pbxWarning.Location = New System.Drawing.Point(11, 8)
        Me.pbxWarning.Name = "pbxWarning"
        Me.pbxWarning.Size = New System.Drawing.Size(50, 50)
        Me.pbxWarning.TabIndex = 20
        Me.pbxWarning.TabStop = False
        '
        'pbxBanner
        '
        Me.pbxBanner.Image = CType(resources.GetObject("pbxBanner.Image"), System.Drawing.Image)
        Me.pbxBanner.Location = New System.Drawing.Point(0, 0)
        Me.pbxBanner.Name = "pbxBanner"
        Me.pbxBanner.Size = New System.Drawing.Size(497, 68)
        Me.pbxBanner.TabIndex = 3
        Me.pbxBanner.TabStop = False
        '
        'ErrorHandlingForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 335)
        Me.Controls.Add(Me.pbxWarning)
        Me.Controls.Add(Me.lblSend)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblDate_)
        Me.Controls.Add(Me.pBar)
        Me.Controls.Add(Me.txbComment)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblInstitution)
        Me.Controls.Add(Me.lblModule)
        Me.Controls.Add(Me.lblComment_)
        Me.Controls.Add(Me.lblUsername_)
        Me.Controls.Add(Me.lblInstitution_)
        Me.Controls.Add(Me.lblModule_)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.pbxBanner)
        Me.Controls.Add(Me.bttnClose)
        Me.Controls.Add(Me.bttnSendError)
        Me.Controls.Add(Me.gbxErrorDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ErrorHandlingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Evento inesperado"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myModule As String
    Private myUsername As String
    Private myException As Exception

    Private Sub ErrorHandlingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Dim InstitutionSettings As Hashtable = ConfigurationManager.GetSection("InstitutionSettings")
        Me.collapseBox = Me.gbxErrorDetails.collapseBox
        Dim GbxErrorDetails As ErrorDetails = New ErrorDetails
        Me.gbxErrorDetails.Size = GbxErrorDetails.Size
        Me.gbxErrorDetails.Minimize()

        Me.lblModule.Text = String.Format(ConfigurationManager.AppSettings("Application.FullName"), CStr(ConfigurationManager.AppSettings("Application.Version")))
        Me.lblInstitution.Text = InstitutionSettings.Item("Institution.Name")
        Me.lblUsername.Text = myUsername
        Me.lblDate.Text = Date.Now
        Me.gbxErrorDetails.txbErrorDetails.Text = MsgException(myException)
    End Sub

    Private Sub bttnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnClose.Click
        Me.Close()
    End Sub

    Public Sub collapseBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles collapseBox.Click
        If Me.collapseBox.Tag = "Minimize" Then
            Me.gbxErrorDetails.Caption = "Esconder detalhes"
            Me.collapseBox.Tag = "Maximize"
            Me.Height = Me.Height + Me.gbxErrorDetails.txbErrorDetails.Height + 10
        ElseIf Me.collapseBox.Tag = "Maximize" Then
            Me.gbxErrorDetails.Caption = "Mostrar detalhes"
            Me.collapseBox.Tag = "Minimize"
            Me.Height = Me.Height - Me.gbxErrorDetails.txbErrorDetails.Height - 10
        End If
    End Sub

    Private Sub bttnSendError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnSendError.Click
        Dim t As Thread
        Dim EmailSettings As Hashtable = ConfigurationManager.GetSection("EmailSettings")

        Dim objEmail As New MailMessage
        objEmail.From = EmailSettings.Item("Email.From")
        objEmail.To = EmailSettings.Item("Email.To")
        objEmail.Subject = EmailSettings.Item("Email.Subject")
        objEmail.Body = BuilEmailBody()
        objEmail.BodyFormat = MailFormat.Text
        SmtpMail.SmtpServer = EmailSettings.Item("SmtpMail.SmtpServer")

        Try
            SmtpMail.Send(objEmail)
            For i As Integer = 0 To pBar.Maximum
                pBar.PerformStep()
                t.Sleep(2)
            Next
            Me.Close()
        Catch ex As Exception
            Me.lblSend.ForeColor = Color.Red
            Me.lblSend.Text = ErrorMessage("ErrorHandling.Exception")
        Finally
            objEmail = Nothing
        End Try
    End Sub

    Private Function BuilEmailBody() As String
        Dim strRet As New System.Text.StringBuilder
        strRet.Append(Me.lblModule_.Text)
        strRet.Append(Me.lblModule.Text)
        strRet.Append(vbNewLine)
        strRet.Append(vbNewLine)
        strRet.Append(Me.lblInstitution_.Text)
        strRet.Append(Me.lblInstitution.Text)
        strRet.Append(vbNewLine)
        strRet.Append(vbNewLine)
        strRet.Append(Me.lblUsername_.Text)
        strRet.Append(Me.lblUsername.Text)
        strRet.Append(vbNewLine)
        strRet.Append(vbNewLine)
        strRet.Append(Me.lblDate_.Text)
        strRet.Append(Me.lblDate.Text)
        strRet.Append(vbNewLine)
        strRet.Append(vbNewLine)
        strRet.Append(Me.lblComment_.Text)
        strRet.Append(Me.txbComment.Text)
        strRet.Append(vbNewLine)
        strRet.Append(vbNewLine)
        strRet.Append("Excepção:")
        strRet.Append(vbNewLine)
        strRet.Append(Me.gbxErrorDetails.txbErrorDetails.Text)
        Return strRet.ToString
    End Function

End Class
